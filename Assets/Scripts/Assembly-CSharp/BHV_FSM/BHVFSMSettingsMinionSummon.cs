using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsMinionSummon : BHVPropertySettingsAttackBase
	{
		[CompilerGenerated]
		private float c6ad93b575ce7e8329a6b7fc805713fbc;

		[DefaultValue(typeof(float), "10")]
		public float m_summonInterval
		{
			[CompilerGenerated]
			get
			{
				return c6ad93b575ce7e8329a6b7fc805713fbc;
			}
			[CompilerGenerated]
			set
			{
				c6ad93b575ce7e8329a6b7fc805713fbc = value;
			}
		}

		public BHVFSMSettingsMinionSummon()
		{
			m_summonInterval = 10f;
		}
	}
}
