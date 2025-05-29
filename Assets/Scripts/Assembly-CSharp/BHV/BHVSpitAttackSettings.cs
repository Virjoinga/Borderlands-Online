using System.ComponentModel;
using System.Runtime.CompilerServices;
using XsdSettings;

namespace BHV
{
	public class BHVSpitAttackSettings : BHVTaskSettings
	{
		[CompilerGenerated]
		private int c0644ddd67b72233cfead01a724ede0ac;

		[CompilerGenerated]
		private AttackSubType c9ae65802fad117cdd7a403aca9c6630c;

		[DefaultValue(60)]
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

		[DefaultValue(AttackSubType.ProjectileSpit)]
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

		public BHVSpitAttackSettings()
		{
			m_attackDamage = 60;
			m_attackSubType = AttackSubType.ProjectileSpit;
		}
	}
}
