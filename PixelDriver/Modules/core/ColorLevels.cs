using System;
using System.Drawing;

namespace PixelDriver
{
	[ModuleRender("Core")]
	public class ModuleColorLevels : ModuleBase
	{
		Color color1, color2;

		public ModuleColorLevels() : this(Color.Red, Color.Black) { }

		public ModuleColorLevels(Color _color1, Color _color2)
		{
			color1 = _color1;
			color2 = _color2;
		}

		override public void Render()
		{
			float[] level = SoundManager.Instance.GetSoundLevels();

			if(level != null)
			for (int w = 0; w < width; w++)
				for (int h = 0; h < height; h++)
					matrix[w, h] = w <= 100 * (level[h]) ? color1 : color2;

		}
	}
}
