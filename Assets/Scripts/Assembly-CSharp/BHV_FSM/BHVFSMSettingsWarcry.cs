using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsWarcry : BHVPropertySettings
	{
		[CompilerGenerated]
		private int c11dae0fd8096c3fdbda613fa8b5c7263;

		[CompilerGenerated]
		private float ca51fa8c9663b75bb9b96196d70c36f30;

		[CompilerGenerated]
		private float c3063d71ec7d3c60fa704fbcc53a097dc;

		[DefaultValue(60)]
		public int m_damageAmount
		{
			[CompilerGenerated]
			get
			{
				return c11dae0fd8096c3fdbda613fa8b5c7263;
			}
			[CompilerGenerated]
			set
			{
				c11dae0fd8096c3fdbda613fa8b5c7263 = value;
			}
		}

		[DefaultValue(typeof(float), "2")]
		public float m_time
		{
			[CompilerGenerated]
			get
			{
				return ca51fa8c9663b75bb9b96196d70c36f30;
			}
			[CompilerGenerated]
			set
			{
				ca51fa8c9663b75bb9b96196d70c36f30 = value;
			}
		}

		[DefaultValue(typeof(float), "5")]
		public float m_CoolDownTime
		{
			[CompilerGenerated]
			get
			{
				return c3063d71ec7d3c60fa704fbcc53a097dc;
			}
			[CompilerGenerated]
			set
			{
				c3063d71ec7d3c60fa704fbcc53a097dc = value;
			}
		}

		public BHVFSMSettingsWarcry()
		{
			m_damageAmount = 60;
			m_time = 2f;
			m_CoolDownTime = 5f;
		}
	}
}
