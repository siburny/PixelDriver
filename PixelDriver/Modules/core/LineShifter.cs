using System;
using System.Drawing;
using System.Timers;

namespace PixelDriver
{
	[ModuleRender("Core")]
	public class ModuleLineShifter : ModuleBase
	{
		Timer t;
		int c = 0, lines = 5, speed = 100;
		Color col = Color.White;

		public ModuleLineShifter()
		{
			t = new Timer(speed);
			t.Elapsed += t_Elapsed;
			t.Start();
		}

		void t_Elapsed(object sender, ElapsedEventArgs e)
		{
			c = ++c % (width / lines);
		}

		override public void Render()
		{
			for (int w = 0; w < width; w++)
				for (int h = 0; h < height; h++)
					matrix[w, h] = c == (w % (width / lines)) ? col : Color.Black;
		}
	}
}
