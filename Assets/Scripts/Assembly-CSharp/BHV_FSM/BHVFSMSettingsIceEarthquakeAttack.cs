using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsIceEarthquakeAttack : BHVPropertySettingsAttackBase
	{
		[CompilerGenerated]
		private int ca8721f3546c875e338cac46b52b2f9a2;

		[CompilerGenerated]
		private int c7db66e49ccd0dee0f178ef7dbe9ee44a;

		[CompilerGenerated]
		private int ca42df88d1ac21132077fc22e342b2ee9;

		[CompilerGenerated]
		private float c5be4b410be93e886a811581f3fb0c75e;

		[CompilerGenerated]
		private float cfd62903dd7e5e2447a7b3bdcb2509a2d;

		[CompilerGenerated]
		private float c5d50c044eb8357f047b8cd599ccb2f47;

		[DefaultValue(10)]
		public int m_shardAmount
		{
			[CompilerGenerated]
			get
			{
				return ca8721f3546c875e338cac46b52b2f9a2;
			}
			[CompilerGenerated]
			set
			{
				ca8721f3546c875e338cac46b52b2f9a2 = value;
			}
		}

		[DefaultValue(30)]
		public int m_shardDamage
		{
			[CompilerGenerated]
			get
			{
				return c7db66e49ccd0dee0f178ef7dbe9ee44a;
			}
			[CompilerGenerated]
			set
			{
				c7db66e49ccd0dee0f178ef7dbe9ee44a = value;
			}
		}

		[DefaultValue(5)]
		public int m_shardFollowNumber
		{
			[CompilerGenerated]
			get
			{
				return ca42df88d1ac21132077fc22e342b2ee9;
			}
			[CompilerGenerated]
			set
			{
				ca42df88d1ac21132077fc22e342b2ee9 = value;
			}
		}

		[DefaultValue(typeof(float), "1.5")]
		public float m_shardDamageRadius
		{
			[CompilerGenerated]
			get
			{
				return c5be4b410be93e886a811581f3fb0c75e;
			}
			[CompilerGenerated]
			set
			{
				c5be4b410be93e886a811581f3fb0c75e = value;
			}
		}

		[DefaultValue(typeof(float), "0.5")]
		public float m_shardTimeInterval
		{
			[CompilerGenerated]
			get
			{
				return cfd62903dd7e5e2447a7b3bdcb2509a2d;
			}
			[CompilerGenerated]
			set
			{
				cfd62903dd7e5e2447a7b3bdcb2509a2d = value;
			}
		}

		[DefaultValue(typeof(float), "1.5")]
		public float m_shardDistanceInterval
		{
			[CompilerGenerated]
			get
			{
				return c5d50c044eb8357f047b8cd599ccb2f47;
			}
			[CompilerGenerated]
			set
			{
				c5d50c044eb8357f047b8cd599ccb2f47 = value;
			}
		}

		public BHVFSMSettingsIceEarthquakeAttack()
		{
			m_shardAmount = 10;
			m_shardDamage = 30;
			m_shardFollowNumber = 5;
			m_shardDamageRadius = 1.5f;
			m_shardTimeInterval = 0.5f;
			m_shardDistanceInterval = 1.5f;
		}
	}
}
