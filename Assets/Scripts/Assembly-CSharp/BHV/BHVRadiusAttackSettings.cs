using System.ComponentModel;
using System.Runtime.CompilerServices;
using XsdSettings;

namespace BHV
{
	public class BHVRadiusAttackSettings : BHVTaskSettings
	{
		[CompilerGenerated]
		private int c0644ddd67b72233cfead01a724ede0ac;

		[CompilerGenerated]
		private AttackSubType c9ae65802fad117cdd7a403aca9c6630c;

		[DefaultValue(15)]
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

		[DefaultValue(AttackSubType.AreaGeneric)]
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

		public BHVRadiusAttackSettings()
		{
			m_attackDamage = 15;
			m_attackSubType = AttackSubType.AreaGeneric;
		}
	}
}
