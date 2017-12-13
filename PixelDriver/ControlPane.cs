using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PixelDriver
{
	public partial class ControlPane : UserControl
	{
		private const int TotalNumber = 20;
		public ControlPane()
		{
			InitializeComponent();

			InitDefaultControls();
		}

		private void InitDefaultControls()
		{
			for (int i = 0; i < TotalNumber; i++)
			{
				Button b = new Button();
				b.Text = i.ToString();
				b.Width = b.Height = 45;
				b.Margin = new Padding(0);
				b.Tag = i;
				b.MouseEnter += new EventHandler(ModuleButton_MouseEnter);
				b.MouseLeave += new EventHandler(ModuleButton_MouseLeave);
				flowLayoutPanel.Controls.Add(b);
			}
		}

		private Button currentPreviewModule = null;

		private void ModuleButton_MouseEnter(object sender, EventArgs e)
		{
			currentPreviewModule = (Button)sender;
			previewTimer.Enabled = true;
		}

		private void ModuleButton_MouseLeave(object sender, EventArgs e)
		{
			previewTimer.Enabled = false;
		}

		private void previewTimer_Tick(object sender, EventArgs e)
		{
			int cubeSize = 2, cubePadding = 0;
			ModuleBase currentModule = ModuleManager.Instance.GetModule(int.Parse(currentPreviewModule.Tag.ToString()));

			if (currentModule != null)
			{
				currentModule.Render();

				Bitmap bmp = new Bitmap(45, 45);
				using (Graphics g = Graphics.FromImage(bmp))
				{
					for (int w = 0; w < 20; w++)
						for (int h = 0; h < 5; h++)
							g.FillRectangle(new SolidBrush(currentModule.matrix[w, h]), w * cubeSize, h * cubeSize, cubeSize - cubePadding, cubeSize - cubePadding);
				}
				currentPreviewModule.CreateGraphics().DrawImage(bmp, 4, 4);
			}
		}
	}
}
