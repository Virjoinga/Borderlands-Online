using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsThrowGrenade : BHVPropertySettings
	{
		[CompilerGenerated]
		private float c2e45def85102637c19df0f9c300a5bcb;

		[DefaultValue(typeof(float), "0.2")]
		public float m_throwGrenadeChance
		{
			[CompilerGenerated]
			get
			{
				return c2e45def85102637c19df0f9c300a5bcb;
			}
			[CompilerGenerated]
			set
			{
				c2e45def85102637c19df0f9c300a5bcb = value;
			}
		}

		public BHVFSMSettingsThrowGrenade()
		{
			m_throwGrenadeChance = 0.2f;
		}
	}
}
