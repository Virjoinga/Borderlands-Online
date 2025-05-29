using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsThrowDaggerAttack : BHVPropertySettingsAttackBase
	{
		[CompilerGenerated]
		private float cfe1935b758fb44d396868eed6d4ea11d;

		[CompilerGenerated]
		private float c6a392527eeb5354f652745e3503cc4b4;

		[DefaultValue(typeof(float), "70")]
		public float m_damagePoint
		{
			[CompilerGenerated]
			get
			{
				return cfe1935b758fb44d396868eed6d4ea11d;
			}
			[CompilerGenerated]
			set
			{
				cfe1935b758fb44d396868eed6d4ea11d = value;
			}
		}

		[DefaultValue(typeof(float), "0.5")]
		public float m_throwChance
		{
			[CompilerGenerated]
			get
			{
				return c6a392527eeb5354f652745e3503cc4b4;
			}
			[CompilerGenerated]
			set
			{
				c6a392527eeb5354f652745e3503cc4b4 = value;
			}
		}

		public BHVFSMSettingsThrowDaggerAttack()
		{
			m_damagePoint = 70f;
			m_throwChance = 0.5f;
		}
	}
}
