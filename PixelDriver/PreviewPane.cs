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
	public partial class PreviewPane : UserControl
	{
		const int cubeSize = 5;
		const int cubePadding = 1;
		const float zoomTransform = 1;

		ModuleBase currentModule;
		public PreviewPane()
		{
			InitializeComponent();

			InitModules();

			currentModule = ModuleManager.Instance.GetDefaultModule();
		}

		void InitModules()
		{
		}

		public void Render()
		{
			if (currentModule != null)
			{
				currentModule.Render();
				if (DMXManager.Instance.IsStreaming)
				{
					foreach(Pixel p in PatchManager.Instance.Pixels)
						DMXManager.Instance.SetPixel(p.universe, p.channel, currentModule.matrix[p.x, p.y]);
				}

				Bitmap bmp = new Bitmap(pictureBoxPreview.Width, pictureBoxPreview.Height);
				using (Graphics g = Graphics.FromImage(bmp))
				{
					if (zoomTransform != 1)
						g.ScaleTransform(zoomTransform, zoomTransform);
					for (int w = 0; w < ConfigManager.Instance.Width; w++)
						for (int h = 0; h < ConfigManager.Instance.Height; h++)
							g.FillRectangle(new SolidBrush(currentModule.matrix[w, h]), w * cubeSize, h * cubeSize, cubeSize - cubePadding, cubeSize - cubePadding);
				}
				pictureBoxPreview.Image = bmp;
			}
		}
	}
}
