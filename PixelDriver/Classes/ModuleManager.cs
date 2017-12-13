using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixelDriver
{
	public sealed class ModuleManager
	{
		private static readonly ModuleManager instance = new ModuleManager();
		public static ModuleManager Instance
		{
			get
			{
				return instance;
			}
		}

		public List<ModuleBase> Modules = new List<ModuleBase>();

		private ModuleManager()
		{
			Modules.Add(new ModuleColor());
			Modules.Add(new ModuleColorFader());
			Modules.Add(new ModuleColorLevels());
			Modules.Add(new ModuleRGBColorFader());
			Modules.Add(new ModuleLineShifter());

			foreach (ModuleBase m in Modules)
				m.Initialize(ConfigManager.Instance.Width, ConfigManager.Instance.Height);
		}

		public ModuleBase GetDefaultModule()
		{
			return Modules[0];
		}

		public ModuleBase GetModule(int i)
		{
			if (i < 0 || i >= Modules.Count)
				return null;

			return Modules[i];
		}
	}
}
