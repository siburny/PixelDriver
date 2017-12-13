using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Un4seen.Bass;

namespace PixelDriver
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			BassNet.Registration("siburny@gmail.com", "2X28293417152222");
			SoundManager.Instance.InitManager();
			ConfigManager.Instance.Init();
		}

		private void buttonStartStop_Click(object sender, EventArgs e)
		{
			if (DMXManager.Instance.IsStreaming)
			{
				DMXManager.Instance.Stop();
				buttonStartStop.Text = "Start";
			}
			else
			{
				DMXManager.Instance.Start();
				buttonStartStop.Text = "Stop";
			}
		}

		private void mainTimer_Tick(object sender, EventArgs e)
		{
			previewPaneA.Render();
			float[] buf = SoundManager.Instance.GetSoundLevels();
			label1.Text = SoundManager.Instance.BufferLength().ToString();
			SoundManager.Instance.ClearBuffer();
		}

		private void patchGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			(new PatchGeneratorForm()).ShowDialog();
		}
	}
}
