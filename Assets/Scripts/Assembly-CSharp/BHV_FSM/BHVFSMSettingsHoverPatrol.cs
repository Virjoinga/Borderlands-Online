using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsHoverPatrol : BHVPropertySettings
	{
		[CompilerGenerated]
		private float cb02226640b6839f49a5cd4828017544e;

		[CompilerGenerated]
		private float c2bcbedcb7f376c574f9db760439bc0df;

		[DefaultValue(typeof(float), "20")]
		public float m_patrolTime
		{
			[CompilerGenerated]
			get
			{
				return cb02226640b6839f49a5cd4828017544e;
			}
			[CompilerGenerated]
			set
			{
				cb02226640b6839f49a5cd4828017544e = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_chanceToOtherPatrolPoint
		{
			[CompilerGenerated]
			get
			{
				return c2bcbedcb7f376c574f9db760439bc0df;
			}
			[CompilerGenerated]
			set
			{
				c2bcbedcb7f376c574f9db760439bc0df = value;
			}
		}

		public BHVFSMSettingsHoverPatrol()
		{
			m_patrolTime = 20f;
			m_chanceToOtherPatrolPoint = 1f;
		}
	}
}
