using System;
using System.Drawing;

namespace PixelDriver
{
	[ModuleRender("Core")]
	public class ModuleColor : ModuleBase
	{
		private Color color;

		public ModuleColor() : this(Color.White) { }

		public ModuleColor(Color _color)
		{
			this.color = _color;
		}

		override public void Render()
		{
			for (int w = 0; w < width; w++)
				for (int h = 0; h < height; h++)
					matrix[w, h] = color;
		}
	}
}