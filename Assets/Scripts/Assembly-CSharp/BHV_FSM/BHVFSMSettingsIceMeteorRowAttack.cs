using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsIceMeteorRowAttack : BHVPropertySettingsAttackBase
	{
		[CompilerGenerated]
		private int ca8721f3546c875e338cac46b52b2f9a2;

		[CompilerGenerated]
		private int c7db66e49ccd0dee0f178ef7dbe9ee44a;

		[CompilerGenerated]
		private float c5be4b410be93e886a811581f3fb0c75e;

		[CompilerGenerated]
		private float c5d50c044eb8357f047b8cd599ccb2f47;

		[DefaultValue(3)]
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

		public BHVFSMSettingsIceMeteorRowAttack()
		{
			m_shardAmount = 3;
			m_shardDamage = 30;
			m_shardDamageRadius = 1.5f;
			m_shardDistanceInterval = 1.5f;
		}
	}
}
