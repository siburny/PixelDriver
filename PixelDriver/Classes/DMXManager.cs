using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acn;
using Acn.Sockets;
using Acn.Helpers;

namespace PixelDriver
{
	public sealed class DMXManager
	{
		private static readonly DMXManager instance = new DMXManager();
		public static DMXManager Instance
		{
			get
			{
				return instance;
			}
		}

		private DMXManager() 
		{
		}

		private StreamingAcnSocket socket;
		private DmxStreamer dmxOutput;
		private Dictionary<byte, DmxUniverse> universes = new Dictionary<byte, DmxUniverse>();

		public Boolean IsStreaming
		{
			get
			{
				return dmxOutput != null && dmxOutput.Streaming;
			}
		}

		public void Start()
		{
			PatchManager.Instance.Init();

			socket = new StreamingAcnSocket(Guid.NewGuid(), "PixelDriver");
			socket.Open(new System.Net.IPAddress(new byte[] { 192, 168, 1, 50 }));

			foreach(Byte u in PatchManager.Instance.Universes)
			{
				socket.JoinDmxUniverse(u);
				universes.Add(u, new DmxUniverse(u));
			}

			dmxOutput = new DmxStreamer(socket);
			foreach(KeyValuePair<byte, DmxUniverse> universe in universes)
				dmxOutput.AddUniverse(universe.Value);
			dmxOutput.Start();
		}

		public void Stop()
		{
			dmxOutput.Stop();
			socket.Close();
			universes.Clear();
		}

		public void SetPixel(byte universe, int startChannel, byte r, byte g, byte b)
		{
			universes[universe].DmxData[startChannel] = r;
			universes[universe].DmxData[startChannel + 1] = g;
			universes[universe].DmxData[startChannel + 2] = b;
			universes[universe].AliveTime = 3;
		}

		public void SetPixel(byte universe, int startChannel, System.Drawing.Color c)
		{
			SetPixel(universe, startChannel, c.R, c.G, c.B);
		}
	}
}
