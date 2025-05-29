using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsLaserSweep : BHVPropertySettingsAttackBase
	{
		[CompilerGenerated]
		private float c6f0bdb0d442b342040378a7c7f805d39;

		[DefaultValue(typeof(float), "16")]
		public float m_attackInterval
		{
			[CompilerGenerated]
			get
			{
				return c6f0bdb0d442b342040378a7c7f805d39;
			}
			[CompilerGenerated]
			set
			{
				c6f0bdb0d442b342040378a7c7f805d39 = value;
			}
		}

		public BHVFSMSettingsLaserSweep()
		{
			m_attackInterval = 16f;
		}
	}
}
