using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV
{
	public class BHVDazeEffectSettings : BHVTaskSettings
	{
		[CompilerGenerated]
		private bool cda2354b595701511b8a58272f6b7dc69;

		[CompilerGenerated]
		private float cab440431370fed86560866585b009b6a;

		[CompilerGenerated]
		private float c92ff36f9e9ad3b4f1292af50151bdadf;

		[DefaultValue(false)]
		public bool m_bDazeResist
		{
			[CompilerGenerated]
			get
			{
				return cda2354b595701511b8a58272f6b7dc69;
			}
			[CompilerGenerated]
			set
			{
				cda2354b595701511b8a58272f6b7dc69 = value;
			}
		}

		[DefaultValue(typeof(float), "3")]
		public float m_dazeDuration
		{
			[CompilerGenerated]
			get
			{
				return cab440431370fed86560866585b009b6a;
			}
			[CompilerGenerated]
			set
			{
				cab440431370fed86560866585b009b6a = value;
			}
		}

		[DefaultValue(typeof(float), "0.3")]
		public float m_speedRate
		{
			[CompilerGenerated]
			get
			{
				return c92ff36f9e9ad3b4f1292af50151bdadf;
			}
			[CompilerGenerated]
			set
			{
				c92ff36f9e9ad3b4f1292af50151bdadf = value;
			}
		}

		public BHVDazeEffectSettings()
		{
			m_bDazeResist = false;
			m_dazeDuration = 3f;
			m_speedRate = 0.3f;
		}
	}
}
