using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsRangeAttack : BHVPropertySettings
	{
		[CompilerGenerated]
		private float cd7cb38ce3ca05c130a31d6c75c08b4d7;

		[CompilerGenerated]
		private float c0eba98215c85ac9051ceaa3eb1c65f4e;

		[CompilerGenerated]
		private float c93c8c6985343ccb91e9afffd43b53362;

		[CompilerGenerated]
		private int ccac4ef3270da836a46b6c658599d209d;

		[CompilerGenerated]
		private float ccbea971e29f77b149cbd408a0012b6e1;

		[DefaultValue(typeof(float), "0")]
		public float m_bestAttackDistanceMax
		{
			[CompilerGenerated]
			get
			{
				return cd7cb38ce3ca05c130a31d6c75c08b4d7;
			}
			[CompilerGenerated]
			set
			{
				cd7cb38ce3ca05c130a31d6c75c08b4d7 = value;
			}
		}

		[DefaultValue(typeof(float), "0")]
		public float m_bestAttackDistanceMin
		{
			[CompilerGenerated]
			get
			{
				return c0eba98215c85ac9051ceaa3eb1c65f4e;
			}
			[CompilerGenerated]
			set
			{
				c0eba98215c85ac9051ceaa3eb1c65f4e = value;
			}
		}

		[DefaultValue(typeof(float), "0")]
		public float m_shootIdleTime
		{
			[CompilerGenerated]
			get
			{
				return c93c8c6985343ccb91e9afffd43b53362;
			}
			[CompilerGenerated]
			set
			{
				c93c8c6985343ccb91e9afffd43b53362 = value;
			}
		}

		[DefaultValue(0)]
		public int m_burstChainedFireLoopCount
		{
			[CompilerGenerated]
			get
			{
				return ccac4ef3270da836a46b6c658599d209d;
			}
			[CompilerGenerated]
			set
			{
				ccac4ef3270da836a46b6c658599d209d = value;
			}
		}

		[DefaultValue(typeof(float), "0")]
		public float m_fireRange
		{
			[CompilerGenerated]
			get
			{
				return ccbea971e29f77b149cbd408a0012b6e1;
			}
			[CompilerGenerated]
			set
			{
				ccbea971e29f77b149cbd408a0012b6e1 = value;
			}
		}

		public BHVFSMSettingsRangeAttack()
		{
			m_bestAttackDistanceMax = 0f;
			m_bestAttackDistanceMin = 0f;
			m_shootIdleTime = 0f;
			m_burstChainedFireLoopCount = 0;
			m_fireRange = 0f;
		}
	}
}
