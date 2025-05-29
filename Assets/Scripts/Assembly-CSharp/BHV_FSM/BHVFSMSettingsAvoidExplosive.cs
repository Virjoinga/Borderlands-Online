using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsAvoidExplosive : BHVPropertySettings
	{
		[CompilerGenerated]
		private float c63f316c93e41372f7a53fcabcdf35e9c;

		[CompilerGenerated]
		private float c8b5e64f593d9d662aff5630ed144a8d5;

		[CompilerGenerated]
		private float c9a718a912af268b81fd2df363cf2aeac;

		[CompilerGenerated]
		private float c5c124395ff9ff0e6e7d9c932390b8eb4;

		[CompilerGenerated]
		private float cc427e75e81824f43771e2b35aec564ec;

		[DefaultValue(typeof(float), "1")]
		public float m_checkExplosiveTime
		{
			[CompilerGenerated]
			get
			{
				return c63f316c93e41372f7a53fcabcdf35e9c;
			}
			[CompilerGenerated]
			set
			{
				c63f316c93e41372f7a53fcabcdf35e9c = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_dodgeChance
		{
			[CompilerGenerated]
			get
			{
				return c8b5e64f593d9d662aff5630ed144a8d5;
			}
			[CompilerGenerated]
			set
			{
				c8b5e64f593d9d662aff5630ed144a8d5 = value;
			}
		}

		[DefaultValue(typeof(float), "2.56")]
		public float m_dodgeDistance
		{
			[CompilerGenerated]
			get
			{
				return c9a718a912af268b81fd2df363cf2aeac;
			}
			[CompilerGenerated]
			set
			{
				c9a718a912af268b81fd2df363cf2aeac = value;
			}
		}

		[DefaultValue(typeof(float), "5")]
		public float m_distanceToExplosive
		{
			[CompilerGenerated]
			get
			{
				return c5c124395ff9ff0e6e7d9c932390b8eb4;
			}
			[CompilerGenerated]
			set
			{
				c5c124395ff9ff0e6e7d9c932390b8eb4 = value;
			}
		}

		[DefaultValue(typeof(float), "3")]
		public float m_dodgeRepeatTime
		{
			[CompilerGenerated]
			get
			{
				return cc427e75e81824f43771e2b35aec564ec;
			}
			[CompilerGenerated]
			set
			{
				cc427e75e81824f43771e2b35aec564ec = value;
			}
		}

		public BHVFSMSettingsAvoidExplosive()
		{
			m_checkExplosiveTime = 1f;
			m_dodgeChance = 1f;
			m_dodgeDistance = 2.56f;
			m_distanceToExplosive = 5f;
			m_dodgeRepeatTime = 3f;
		}
	}
}
