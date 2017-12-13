using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PixelDriver
{
	public sealed class PatchManager
	{
		private static readonly PatchManager instance = new PatchManager();
		public static PatchManager Instance
		{
			get
			{
				return instance;
			}
		}

		private PatchManager()
		{
		}

		private List<PatchItem> patches = new List<PatchItem>();
		public List<PatchItem> Patches
		{
			get
			{
				return patches;
			}
			set
			{
				patches = value;
			}
		}

		public List<byte> Universes
		{
			get
			{
				List<byte> u = new List<byte>();

				foreach (PatchItem p in PatchManager.Instance.Patches)
					if (!u.Contains(p.universe))
						u.Add(p.universe);

				return u;
			}
		}

		public bool IsHit(Point startPosition, Point currentPosition)
		{
			bool isHit = false;
			foreach (PatchItem p in PatchManager.Instance.Patches)
				isHit = isHit || p.IsHit(startPosition, currentPosition);
			return isHit;
		}

		public List<Pixel> Pixels = new List<Pixel>();
		public void Init()
		{
			Pixels.Clear();

			foreach (PatchItem p in Patches)
			{
				int dx = p.direction ? 1 : 0, dy = !p.direction ? 1 : 0;
				if (p.length < 0)
				{
					dx = -dx;
					dy = -dy;
				}

				for (int i = 0; i < Math.Abs(p.length); i++)
					Pixels.Add(new Pixel(p.universe, p.startChannel + 3 * i, p.x + i * dx, p.y + i * dy));
			}
		}
	}

	public class Pixel
	{
		public byte universe;
		public int channel;
		public int x;
		public int y;

		public Pixel(byte _universe, int _channel, int _x, int _y)
		{
			universe = _universe;
			channel = _channel;
			x = _x;
			y = _y;
		}
	}

	public class PatchItem
	{
		public int x;
		public int y;
		public int length;
		public bool direction;
		public byte universe;
		public int startChannel;

		public void Draw(Graphics g, int zoom)
		{
			Point p = (new Point(x, y)).ToPanelXY(zoom);
			PatchItem.Draw(g, p, new Point(p.X + 2 * zoom * (direction ? Math.Sign(length) * (Math.Abs(length) - 1) : 0), p.Y + 2 * zoom * (!direction ? Math.Sign(length) * (Math.Abs(length) - 1) : 0)), zoom);
		}

		public static void Draw(Graphics g, Point startPosition, Point currentPosition, int zoom)
		{
			Pen darkBlue = new Pen(Color.DarkBlue, 1);
			if (startPosition.X == currentPosition.X)
			{
				if (startPosition.Y > currentPosition.Y)
				{
					g.DrawLine(darkBlue, startPosition.X, startPosition.Y, startPosition.X, startPosition.Y - zoom);
					g.DrawLine(darkBlue, startPosition.X, startPosition.Y - zoom, startPosition.X - 0.25f * zoom, startPosition.Y - 0.75f * zoom);
					g.DrawLine(darkBlue, startPosition.X, startPosition.Y - zoom, startPosition.X + 0.25f * zoom, startPosition.Y - 0.75f * zoom);

					g.DrawRoundedRectangle(darkBlue, new RectangleF(currentPosition.X - 0.75f * zoom, currentPosition.Y - 0.75f * zoom, startPosition.X - currentPosition.X + 1.5f * zoom, startPosition.Y - currentPosition.Y + 1.5f * zoom), zoom / 2);
				}
				else
				{
					g.DrawLine(darkBlue, startPosition.X, startPosition.Y, startPosition.X, startPosition.Y + zoom);
					g.DrawLine(darkBlue, startPosition.X, startPosition.Y + zoom, startPosition.X - 0.25f * zoom, startPosition.Y + 0.75f * zoom);
					g.DrawLine(darkBlue, startPosition.X, startPosition.Y + zoom, startPosition.X + 0.25f * zoom, startPosition.Y + 0.75f * zoom);

					g.DrawRoundedRectangle(darkBlue, new RectangleF(startPosition.X - 0.75f * zoom, startPosition.Y - 0.75f * zoom, currentPosition.X - startPosition.X + 1.5f * zoom, currentPosition.Y - startPosition.Y + 1.5f * zoom), zoom / 2);
				}
			}
			else
			{
				if (startPosition.X > currentPosition.X)
				{
					g.DrawLine(darkBlue, startPosition.X, startPosition.Y, startPosition.X - zoom, startPosition.Y);
					g.DrawLine(darkBlue, startPosition.X - zoom, startPosition.Y, startPosition.X - 0.75f * zoom, startPosition.Y - 0.25f * zoom);
					g.DrawLine(darkBlue, startPosition.X - zoom, startPosition.Y, startPosition.X - 0.75f * zoom, startPosition.Y + 0.25f * zoom);

					g.DrawRoundedRectangle(darkBlue, new RectangleF(currentPosition.X - 0.75f * zoom, currentPosition.Y - 0.75f * zoom, startPosition.X - currentPosition.X + 1.5f * zoom, startPosition.Y - currentPosition.Y + 1.5f * zoom), zoom / 2);
				}
				else
				{
					g.DrawLine(darkBlue, startPosition.X, startPosition.Y, startPosition.X + zoom, startPosition.Y);
					g.DrawLine(darkBlue, startPosition.X + zoom, startPosition.Y, startPosition.X + 0.75f * zoom, startPosition.Y - 0.25f * zoom);
					g.DrawLine(darkBlue, startPosition.X + zoom, startPosition.Y, startPosition.X + 0.75f * zoom, startPosition.Y + 0.25f * zoom);

					g.DrawRoundedRectangle(darkBlue, new RectangleF(startPosition.X - 0.75f * zoom, startPosition.Y - 0.75f * zoom, currentPosition.X - startPosition.X + 1.5f * zoom, currentPosition.Y - startPosition.Y + 1.5f * zoom), zoom / 2);
				}
			}
		}

		public bool IsHit(Point startPosition, Point currentPosition)
		{
			int dx = direction ? 1 : 0, dy = !direction ? 1 : 0;
			if (length < 0)
			{
				dx = -dx;
				dy = -dy;
			}

			List<Point> lst = new List<Point>();
			for (int i = 0; i < Math.Abs(length); i++)
				lst.Add(new Point(x + i * dx, y + i * dy));

			dx = startPosition.X != currentPosition.X ? 1 : 0;
			dy = startPosition.X == currentPosition.X ? 1 : 0;
			if (currentPosition.X - startPosition.X < 0 || currentPosition.Y - startPosition.Y < 0)
			{
				dx = -dx;
				dy = -dy;
			}

			Point p;
			for (int i = 0; i < Math.Abs(currentPosition.X - startPosition.X + currentPosition.Y - startPosition.Y) + 1; i++)
			{
				p = new Point(startPosition.X + i * dx, startPosition.Y + i * dy);
				if (lst.Contains(p))
					return true;
			}
			return false;
		}
	}
}
