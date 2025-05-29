using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsRadiusAttack : BHVPropertySettingsAttackBase
	{
		[CompilerGenerated]
		private float cb59667717ee3f63762b713f9591164d4;

		[CompilerGenerated]
		private float c118181f39cd00d83342f9314e2a1a70f;

		[DefaultValue(typeof(float), "5")]
		public float m_damageRadius
		{
			[CompilerGenerated]
			get
			{
				return cb59667717ee3f63762b713f9591164d4;
			}
			[CompilerGenerated]
			set
			{
				cb59667717ee3f63762b713f9591164d4 = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_attackIdleTime
		{
			[CompilerGenerated]
			get
			{
				return c118181f39cd00d83342f9314e2a1a70f;
			}
			[CompilerGenerated]
			set
			{
				c118181f39cd00d83342f9314e2a1a70f = value;
			}
		}

		public BHVFSMSettingsRadiusAttack()
		{
			m_damageRadius = 5f;
			m_attackIdleTime = 1f;
		}
	}
}
