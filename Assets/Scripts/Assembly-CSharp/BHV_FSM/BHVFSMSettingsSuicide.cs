using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsSuicide : BHVPropertySettingsAttackBase
	{
		[CompilerGenerated]
		private float c57e566537bf816f2e3c3dea173652256;

		[CompilerGenerated]
		private float c81ff12f2dc608cb50cda996bfd42ab4b;

		[DefaultValue(typeof(float), "5")]
		public float m_distanceToTarget
		{
			[CompilerGenerated]
			get
			{
				return c57e566537bf816f2e3c3dea173652256;
			}
			[CompilerGenerated]
			set
			{
				c57e566537bf816f2e3c3dea173652256 = value;
			}
		}

		[DefaultValue(typeof(float), "2")]
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

		public BHVFSMSettingsSuicide()
		{
			m_distanceToTarget = 5f;
			m_timeBeforeExplosion = 2f;
		}
	}
}
