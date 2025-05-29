using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsThreat : BHVPropertySettings
	{
		[CompilerGenerated]
		private float caeba35d744cde131c3e81f2073312181;

		[CompilerGenerated]
		private float c0acc3cecc627379c1b720ab00d482ed2;

		[DefaultValue(typeof(float), "-0.5")]
		public float m_distanceFactor
		{
			[CompilerGenerated]
			get
			{
				return caeba35d744cde131c3e81f2073312181;
			}
			[CompilerGenerated]
			set
			{
				caeba35d744cde131c3e81f2073312181 = value;
			}
		}

		[DefaultValue(typeof(float), "0.5")]
		public float m_damageFactor
		{
			[CompilerGenerated]
			get
			{
				return c0acc3cecc627379c1b720ab00d482ed2;
			}
			[CompilerGenerated]
			set
			{
				c0acc3cecc627379c1b720ab00d482ed2 = value;
			}
		}

		public BHVFSMSettingsThreat()
		{
			m_distanceFactor = -0.5f;
			m_damageFactor = 0.5f;
		}
	}
}
