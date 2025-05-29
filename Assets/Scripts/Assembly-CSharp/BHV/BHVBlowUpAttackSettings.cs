using System.ComponentModel;
using System.Runtime.CompilerServices;
using XsdSettings;

namespace BHV
{
	public class BHVBlowUpAttackSettings : BHVTaskSettings
	{
		[CompilerGenerated]
		private float cb13f939b4bd77911d45ddf73a368cee3;

		[CompilerGenerated]
		private int c0644ddd67b72233cfead01a724ede0ac;

		[CompilerGenerated]
		private float c3bf4436b8b953f8ece740063ad74c613;

		[CompilerGenerated]
		private float cb9088e90498180b699e6d5095fa6acde;

		[CompilerGenerated]
		private AttackSubType c9ae65802fad117cdd7a403aca9c6630c;

		[DefaultValue(typeof(float), "0.01")]
		public float m_attackRange
		{
			[CompilerGenerated]
			get
			{
				return cb13f939b4bd77911d45ddf73a368cee3;
			}
			[CompilerGenerated]
			set
			{
				cb13f939b4bd77911d45ddf73a368cee3 = value;
			}
		}

		[DefaultValue(1)]
		public int m_attackDamage
		{
			[CompilerGenerated]
			get
			{
				return c0644ddd67b72233cfead01a724ede0ac;
			}
			[CompilerGenerated]
			set
			{
				c0644ddd67b72233cfead01a724ede0ac = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_attackDamageMultiplier
		{
			[CompilerGenerated]
			get
			{
				return c3bf4436b8b953f8ece740063ad74c613;
			}
			[CompilerGenerated]
			set
			{
				c3bf4436b8b953f8ece740063ad74c613 = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_playerAttackDamageMultiplier
		{
			[CompilerGenerated]
			get
			{
				return cb9088e90498180b699e6d5095fa6acde;
			}
			[CompilerGenerated]
			set
			{
				cb9088e90498180b699e6d5095fa6acde = value;
			}
		}

		[DefaultValue(AttackSubType.AreaExplosion)]
		public AttackSubType m_attackSubType
		{
			[CompilerGenerated]
			get
			{
				return c9ae65802fad117cdd7a403aca9c6630c;
			}
			[CompilerGenerated]
			set
			{
				c9ae65802fad117cdd7a403aca9c6630c = value;
			}
		}

		public BHVBlowUpAttackSettings()
		{
			m_attackRange = 0.01f;
			m_attackDamage = 1;
			m_attackDamageMultiplier = 1f;
			m_playerAttackDamageMultiplier = 1f;
			m_attackSubType = AttackSubType.AreaExplosion;
		}
	}
}
