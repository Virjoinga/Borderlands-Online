using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsRailGunAttack : BHVPropertySettingsAttackBase
	{
		[CompilerGenerated]
		private float c8440e68ec1692157f5638f1a7c2bbe77;

		[CompilerGenerated]
		private float c77523b4216e39a49275f2ad3a347e8f8;

		[CompilerGenerated]
		private float c4e8db9e98d82ed22e27b199bfa89b8b0;

		[CompilerGenerated]
		private float c39343c393add600e1b3669423e3f465d;

		[DefaultValue(typeof(float), "0.2")]
		public float m_plasmaBallDamage
		{
			[CompilerGenerated]
			get
			{
				return c8440e68ec1692157f5638f1a7c2bbe77;
			}
			[CompilerGenerated]
			set
			{
				c8440e68ec1692157f5638f1a7c2bbe77 = value;
			}
		}

		[DefaultValue(typeof(float), "20")]
		public float m_plasmaBallSpeed
		{
			[CompilerGenerated]
			get
			{
				return c77523b4216e39a49275f2ad3a347e8f8;
			}
			[CompilerGenerated]
			set
			{
				c77523b4216e39a49275f2ad3a347e8f8 = value;
			}
		}

		[DefaultValue(typeof(float), "1.5")]
		public float m_plasmaBallDamageRadius
		{
			[CompilerGenerated]
			get
			{
				return c4e8db9e98d82ed22e27b199bfa89b8b0;
			}
			[CompilerGenerated]
			set
			{
				c4e8db9e98d82ed22e27b199bfa89b8b0 = value;
			}
		}

		[DefaultValue(typeof(float), "2")]
		public float m_plasmaBallDamageDuration
		{
			[CompilerGenerated]
			get
			{
				return c39343c393add600e1b3669423e3f465d;
			}
			[CompilerGenerated]
			set
			{
				c39343c393add600e1b3669423e3f465d = value;
			}
		}

		public BHVFSMSettingsRailGunAttack()
		{
			m_plasmaBallDamage = 0.2f;
			m_plasmaBallSpeed = 20f;
			m_plasmaBallDamageRadius = 1.5f;
			m_plasmaBallDamageDuration = 2f;
		}
	}
}
