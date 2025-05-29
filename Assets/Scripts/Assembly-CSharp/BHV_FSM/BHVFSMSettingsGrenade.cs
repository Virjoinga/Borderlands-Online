using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsGrenade : BHVPropertySettings
	{
		[CompilerGenerated]
		private float c81ff12f2dc608cb50cda996bfd42ab4b;

		[DefaultValue(typeof(float), "1")]
		public float m_timeBeforeExplosion
		{
			[CompilerGenerated]
			get
			{
				return c81ff12f2dc608cb50cda996bfd42ab4b;
			}
			[CompilerGenerated]
			set
			{
				c81ff12f2dc608cb50cda996bfd42ab4b = value;
			}
		}

		public BHVFSMSettingsGrenade()
		{
			m_timeBeforeExplosion = 1f;
		}
	}
}
