using System;

namespace PixelDriver
{
	[AttributeUsage(AttributeTargets.Class)]
	public class ModuleRenderAttribute : System.Attribute
	{
		private string category;

		public ModuleRenderAttribute(string category)
		{
			this.category = category;
		}
	}
}
