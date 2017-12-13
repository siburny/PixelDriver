using System;
using System.Drawing;

namespace PixelDriver
{
	public abstract class ModuleBase
	{
		internal int width;
		internal int height;
		public Color[,] matrix;

		public void Initialize(int _width, int _height)
		{
			this.width = _width;
			this.height = _height;
			this.matrix = new Color[_width,_height];
		}

		public virtual void Render() { }
	}
}
