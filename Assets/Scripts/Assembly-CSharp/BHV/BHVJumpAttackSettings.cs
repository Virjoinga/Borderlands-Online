using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using XsdSettings;

namespace BHV
{
	public class BHVJumpAttackSettings : BHVTaskSettings
	{
		[CompilerGenerated]
		private int c0644ddd67b72233cfead01a724ede0ac;

		[CompilerGenerated]
		private AttackSubType c9ae65802fad117cdd7a403aca9c6630c;

		[CompilerGenerated]
		private int c3f80906ae0d2952019ae97d5406052c7;

		[CompilerGenerated]
		private float c0f455d48221aa43fdbe3fca51495dec7;

		[CompilerGenerated]
		private float cf8e1c7dde6dfe561567b00152f8101fd;

		[CompilerGenerated]
		private AttackSubType c90da6eb56af80c4762f4ad9d960f8ec4;

		[CompilerGenerated]
		private float cc303fe0a3729973759fc6721b658b213;

		[CompilerGenerated]
		private bool cf26264920908f6c4baf8b92a31ff970e;

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

		[DefaultValue(1)]
		public int m_onTheSpotAttackDamage
		{
			[CompilerGenerated]
			get
			{
				return c3f80906ae0d2952019ae97d5406052c7;
			}
			[CompilerGenerated]
			set
			{
				c3f80906ae0d2952019ae97d5406052c7 = value;
			}
		}

		[DefaultValue(typeof(float), "0.01")]
		public float m_onTheSpotAttackRange
		{
			[CompilerGenerated]
			get
			{
				return c0f455d48221aa43fdbe3fca51495dec7;
			}
			[CompilerGenerated]
			set
			{
				c0f455d48221aa43fdbe3fca51495dec7 = value;
			}
		}

		[DefaultValue(typeof(float), "0.3")]
		public float m_jumpAttackDetectRadius
		{
			[CompilerGenerated]
			get
			{
				return cf8e1c7dde6dfe561567b00152f8101fd;
			}
			[CompilerGenerated]
			set
			{
				cf8e1c7dde6dfe561567b00152f8101fd = value;
			}
		}

		[DefaultValue(AttackSubType.AreaGeneric)]
		public AttackSubType m_onTheSpotAttackSubType
		{
			[CompilerGenerated]
			get
			{
				return c90da6eb56af80c4762f4ad9d960f8ec4;
			}
			[CompilerGenerated]
			set
			{
				c90da6eb56af80c4762f4ad9d960f8ec4 = value;
			}
		}

		public float m_warningZoneRadius
		{
			[CompilerGenerated]
			get
			{
				return cc303fe0a3729973759fc6721b658b213;
			}
			[CompilerGenerated]
			set
			{
				cc303fe0a3729973759fc6721b658b213 = value;
			}
		}

		[XmlIgnore]
		public bool m_warningZoneRadiusSpecified
		{
			[CompilerGenerated]
			get
			{
				return cf26264920908f6c4baf8b92a31ff970e;
			}
			[CompilerGenerated]
			set
			{
				cf26264920908f6c4baf8b92a31ff970e = value;
			}
		}

		public BHVJumpAttackSettings()
		{
			m_attackDamage = 1;
			m_attackSubType = AttackSubType.MeleeGeneric;
			m_onTheSpotAttackDamage = 1;
			m_onTheSpotAttackRange = 0.01f;
			m_jumpAttackDetectRadius = 0.3f;
			m_onTheSpotAttackSubType = AttackSubType.AreaGeneric;
		}
	}
}
