using System.ComponentModel;
using System.Runtime.CompilerServices;
using XsdSettings;

namespace BHV
{
	public class BHVChargeAttackSettings : BHVTaskSettings
	{
		[CompilerGenerated]
		private int c0644ddd67b72233cfead01a724ede0ac;

		[CompilerGenerated]
		private float c7e8fdff7fa2c12cdbcca9fa3fc32a49d;

		[CompilerGenerated]
		private AttackSubType c9ae65802fad117cdd7a403aca9c6630c;

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

		[DefaultValue(typeof(float), "0.5")]
		public float m_checkRadius
		{
			[CompilerGenerated]
			get
			{
				return c7e8fdff7fa2c12cdbcca9fa3fc32a49d;
			}
			[CompilerGenerated]
			set
			{
				c7e8fdff7fa2c12cdbcca9fa3fc32a49d = value;
			}
		}

		[DefaultValue(AttackSubType.MeleeGeneric)]
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

		public BHVChargeAttackSettings()
		{
			m_attackDamage = 1;
			m_checkRadius = 0.5f;
			m_attackSubType = AttackSubType.MeleeGeneric;
		}
	}
}
