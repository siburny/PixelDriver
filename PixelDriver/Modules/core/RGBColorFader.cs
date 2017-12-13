using System;
using System.Drawing;

namespace PixelDriver
{
	[ModuleRender("Core")]
	public class ModuleRGBColorFader : ModuleBase
	{
		int steps = 100;
		int currentStep = 0, ds = 1;
		int color = 0;
		double dc = 0;

		public ModuleRGBColorFader()
		{
			dc = 255.0 / steps;
		}

		override public void Render()
		{
			Color c = Color.FromArgb(color == 0 ? (int)(currentStep * dc) : 0, color == 1 ? (int)(currentStep * dc) : 0, color == 2 ? (int)(currentStep * dc) : 0);

			for (int w = 0; w < width; w++)
				for (int h = 0; h < height; h++)
					matrix[w, h] = c;

			currentStep += ds;
			if (currentStep + ds == steps)
				ds = -1;
			else if (currentStep + ds == -1)
			{
				ds = 1;
				color = ++color % 3;
			}
		}
	}
}
