using System;
using System.Drawing;

namespace PixelDriver
{
	[ModuleRender("Core")]
	public class ModuleColorFader : ModuleBase
	{
		Color color1;
		Color color2;
		int steps = 50;
		int currentStep = 0, ds = 1;
		double dr = 0, dg = 0, db = 0, valr = 0, valg = 0, valb = 0;


		public ModuleColorFader() : this(Color.Black, Color.Red) { }

		public ModuleColorFader(Color _color1, Color _color2)
		{
			this.color1 = _color1;
			this.color2 = _color2;

			valr = _color1.R;
			valg = _color1.G;
			valb = _color1.B;
			dr = 1.0 * (color2.R - color1.R) / steps;
			dg = 1.0 * (color2.G - color1.G) / steps;
			db = 1.0 * (color2.B - color1.B) / steps;
		}

		override public void Render()
		{
			Color c = Color.FromArgb((int)(valr + currentStep * dr), (int)(valg + currentStep * dg), (int)(valb + currentStep * db));
			for (int w = 0; w < width; w++)
				for (int h = 0; h < height; h++)
					matrix[w, h] = c;

			currentStep += ds;
			if (currentStep + ds == steps)
				ds = -1;
			else if (currentStep + ds == -1)
				ds = 1;
		}
	}
}
