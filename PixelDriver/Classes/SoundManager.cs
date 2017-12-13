using System;
using Un4seen.Bass;

namespace PixelDriver
{
	public sealed class SoundManager
	{
		private static readonly SoundManager instance = new SoundManager();

		public static SoundManager Instance
		{
			get
			{
				return instance;
			}
		}

		private SoundManager()
		{
		}

		public const int MaxLevel = 20;

		private int RecordChannel;

		public void InitManager()
		{
			Bass.BASS_RecordInit(1);
			RecordChannel = Bass.BASS_RecordStart(44100, 2, BASSFlag.BASS_DEFAULT, null, IntPtr.Zero);
		}

		public int GetSoundLevel()
		{
			float[] level = new float[2];
			//Bass.BASS_ChannelGetLevel()

			if (BufferLength() > 0 && Bass.BASS_ChannelGetLevel(RecordChannel, level))
				return (int)((level[0] + level[1]) * MaxLevel / 2);
			else
				return -1;
		}

		float[] buf = new float[256];
		public float[] GetSoundLevels()
		{
			string t = "";
			if (BufferLength() > 0)
			{
				// start an unsafe code block allowing you to use native pointers
				unsafe
				{
					// pointers to managed objects need to be fixed
					fixed (float* buffer = buf)    // equivalent to buffer = &data[0]
					{
						Bass.BASS_ChannelGetData(RecordChannel, (IntPtr)buffer, (int)(BASSData.BASS_DATA_FFT256));
					}
				}
				return buf;
			}
			else
				return null;
		}

		public void ClearBuffer()
		{
			Bass.BASS_ChannelGetData(RecordChannel, IntPtr.Zero, BufferLength());
		}

		public int BufferLength()
		{
			return Bass.BASS_ChannelGetData(RecordChannel, IntPtr.Zero, (int)BASSData.BASS_DATA_AVAILABLE);
		}

		Random rnd = new Random();
		public int GetRandomSoundLevel()
		{
			return rnd.Next(MaxLevel);
		}
	}
}
