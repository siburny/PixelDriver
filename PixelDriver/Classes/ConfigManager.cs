using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PixelDriver
{
	public sealed class ConfigManager
	{
		private static readonly ConfigManager instance = new ConfigManager();
		public static ConfigManager Instance
		{
			get
			{
				return instance;
			}
		}

		private string ConfigLocation = "";
		private ConfigStorage Configuration = new ConfigStorage(); 
	
		private ConfigManager()
		{
			string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
			ConfigLocation = path.Substring(0, path.LastIndexOf(@"\") + 1) + "settings.xml";
		}

		internal void Init()
		{
			if (File.Exists(ConfigLocation) && (new FileInfo(ConfigLocation)).Length > 0)
			{
				TextReader s = new StreamReader(ConfigLocation);
				XmlSerializer x = new XmlSerializer(typeof(ConfigStorage));
				Configuration = (ConfigStorage)x.Deserialize(s);
				s.Close();
			}
		}

		public void Save()
		{
			TextWriter s = new StreamWriter(ConfigLocation);
			XmlSerializer x = new XmlSerializer(typeof(ConfigStorage));
			x.Serialize(s, Configuration);
		}

		public int Width
		{
			get
			{
				return Configuration.Width;
			}
		}

		public int Height
		{
			get
			{
				return Configuration.Height;
			}
		}
	}

	public class ConfigStorage
	{
		public int Width = 40;
		public int Height = 40;
		public List<PatchItem> Patches
		{
			get
			{
				return PatchManager.Instance.Patches;
			}
			set
			{
				PatchManager.Instance.Patches = value;
			}
		}
	}
}
