using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsBurrowAttack : BHVPropertySettingsAttackBase
	{
		[CompilerGenerated]
		private float c27176b16af106b99090bba16223dd775;

		[CompilerGenerated]
		private float c9daff6141a5c2d94f9bdc763e6c8547a;

		[DefaultValue(typeof(float), "2")]
		public float m_underGroundTime
		{
			[CompilerGenerated]
			get
			{
				return c27176b16af106b99090bba16223dd775;
			}
			[CompilerGenerated]
			set
			{
				c27176b16af106b99090bba16223dd775 = value;
			}
		}

		[DefaultValue(typeof(float), "10")]
		public float m_undergroundTravelDistance
		{
			[CompilerGenerated]
			get
			{
				return c9daff6141a5c2d94f9bdc763e6c8547a;
			}
			[CompilerGenerated]
			set
			{
				c9daff6141a5c2d94f9bdc763e6c8547a = value;
			}
		}

		public BHVFSMSettingsBurrowAttack()
		{
			m_underGroundTime = 2f;
			m_undergroundTravelDistance = 10f;
		}
	}
}
