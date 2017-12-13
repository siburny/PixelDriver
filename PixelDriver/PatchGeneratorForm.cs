using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PixelDriver
{
	public partial class PatchGeneratorForm : Form
	{
		private bool isDragging = false;
		private Point startPosition = new Point(-100, -100);
		private Point currentPosition = new Point(-100, -100);
		private int zoom = 10;
		private PatchItem selectedPatch = null;
		private List<PatchItem> allPatches = new List<PatchItem>();

		private MouseStatus currentStatus = MouseStatus.selecting;
		private enum MouseStatus {
			selecting = 0,
			drawing
 		}

		public PatchGeneratorForm()
		{
			InitializeComponent();
		}

		private void buttonAddPatch_Click(object sender, EventArgs e)
		{
			currentStatus = MouseStatus.drawing;
			buttonAddPatch.Visible = false;
			buttonCancel.Visible = true;

			groupBoxPatchInfo.Visible = true;
			labelX.Text = "N/A";
			labelY.Text = "N/A";
			labelLength.Text = "N/A";
			textBoxUniverse.Text = "1";
			textBoxStartChannel.Text = "1";
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			buttonAddPatch.Visible = true;
			buttonCancel.Visible = false;
			currentStatus = MouseStatus.selecting;
			selectedPatch = null;
			groupBoxPatchInfo.Visible = false;
			startPosition = currentPosition = new Point(-1, -1);
			panelPatchContainer.Refresh();
		}

		private void buttonSavePatch_Click(object sender, EventArgs e)
		{
			if (selectedPatch == null)
			{
				PatchItem p = new PatchItem();
				p.x = startPosition.X;
				p.y = startPosition.Y;
				p.length = (currentPosition.X - startPosition.X + currentPosition.Y - startPosition.Y);
				if (p.length > 0)
					p.length++;
				else
					p.length--;
				p.direction = (currentPosition.X != startPosition.X);
				p.universe = byte.Parse(textBoxUniverse.Text);
				p.startChannel = int.Parse(textBoxStartChannel.Text);

				PatchManager.Instance.Patches.Add(p);
				ConfigManager.Instance.Save();

				buttonCancel_Click(sender, e);
			}
		}

		private void panelPatchContainer_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			for (int w = 0; w < ConfigManager.Instance.Width; w++)
				for (int h = 0; h < ConfigManager.Instance.Height; h++)
					g.DrawEllipse(new Pen(Color.Black, 1), zoom + 2 * w * zoom - zoom / 2, zoom + 2 * h * zoom - zoom / 2, zoom, zoom);

			if (!startPosition.Equals(currentPosition))
			{
				bool isHit = false;
				foreach (PatchItem p in PatchManager.Instance.Patches)
					isHit = isHit || p.IsHit(startPosition, currentPosition);
				if (!isHit)
					PatchItem.Draw(g, startPosition.ToPanelXY(zoom), currentPosition.ToPanelXY(zoom), zoom);
			}

			foreach (PatchItem p in PatchManager.Instance.Patches)
				p.Draw(g, zoom);
		}

		private void panelPatchContainer_MouseDown(object sender, MouseEventArgs e)
		{
			if (currentStatus == MouseStatus.drawing)
			{
				isDragging = true;
				int x = e.Location.X;
				int y = e.Location.Y;

				//x = (int)(zoom + 2 * zoom * (Math.Round(0.5 * (x - zoom) / zoom)));
				//y = (int)(zoom + 2 * zoom * (Math.Round(0.5 * (y - zoom) / zoom)));

				startPosition = currentPosition = (new Point(x, y)).ToPixelXY(zoom);
			}
		}

		private void panelPatchContainer_MouseMove(object sender, MouseEventArgs e)
		{
			if (isDragging && currentStatus == MouseStatus.drawing)
			{
				int x = e.Location.X;
				int y = e.Location.Y;

				currentPosition = (new Point(x, y)).ToPixelXY(zoom);

				if (Math.Abs(currentPosition.Y - startPosition.Y) > Math.Abs(currentPosition.X - startPosition.X))
				{
					currentPosition.X = startPosition.X;
				}
				else
				{
					currentPosition.Y = startPosition.Y;
				}

				panelPatchContainer.Refresh();
			}
			else
			{
				
			}
		}

		private void panelPatchContainer_MouseUp(object sender, MouseEventArgs e)
		{
			if (currentStatus == MouseStatus.drawing)
			{
				isDragging = false;

				if (PatchManager.Instance.IsHit(startPosition, currentPosition))
				{
					currentPosition = startPosition = new Point(-1, -1);
					buttonCancel_Click(sender, e);
				}
			}
		}
	}
	public static class ExtensionMethod
	{
		public static void DrawRoundedRectangle(this Graphics gfx, Pen DrawPen, RectangleF Bounds, int CornerRadius)
		{
			int strokeOffset = Convert.ToInt32(Math.Ceiling(DrawPen.Width));
			Bounds = RectangleF.Inflate(Bounds, -strokeOffset, -strokeOffset);

			DrawPen.EndCap = DrawPen.StartCap = LineCap.Round;

			GraphicsPath gfxPath = new GraphicsPath();
			gfxPath.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
			gfxPath.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
			gfxPath.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
			gfxPath.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
			gfxPath.CloseAllFigures();

			//gfx.FillPath(new SolidBrush(FillColor), gfxPath);
			gfx.DrawPath(DrawPen, gfxPath);
		}

		public static Point ToPanelXY(this Point p, int zoom)
		{
			return new Point(zoom + 2 * p.X * zoom, zoom + 2 * p.Y * zoom);
		}

		public static Point ToPixelXY(this Point p, int zoom)
		{
			return new Point((int)(Math.Round(0.5 * (p.X - zoom) / zoom)), (int)(Math.Round(0.5 * (p.Y - zoom) / zoom)));
		}
	}

	class DoubleBufferedPanel : Panel
	{
		public DoubleBufferedPanel()
		{
			this.DoubleBuffered = true;
			this.ResizeRedraw = true;
		}
	}
}
