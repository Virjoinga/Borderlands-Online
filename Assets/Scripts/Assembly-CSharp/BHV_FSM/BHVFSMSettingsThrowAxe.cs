using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsThrowAxe : BHVPropertySettings
	{
		[CompilerGenerated]
		private float c0fb58ebb99707d43297eacd2cb97c1b7;

		[CompilerGenerated]
		private float cc00adb55900c9cabc92bafffaabfc430;

		[DefaultValue(typeof(float), "5")]
		public float m_throwAxeDistanceMin
		{
			[CompilerGenerated]
			get
			{
				return c0fb58ebb99707d43297eacd2cb97c1b7;
			}
			[CompilerGenerated]
			set
			{
				c0fb58ebb99707d43297eacd2cb97c1b7 = value;
			}
		}

		[DefaultValue(typeof(float), "30")]
		public float m_throwAxeDistanceMax
		{
			[CompilerGenerated]
			get
			{
				return cc00adb55900c9cabc92bafffaabfc430;
			}
			[CompilerGenerated]
			set
			{
				cc00adb55900c9cabc92bafffaabfc430 = value;
			}
		}

		public BHVFSMSettingsThrowAxe()
		{
			m_throwAxeDistanceMin = 5f;
			m_throwAxeDistanceMax = 30f;
		}
	}
}
