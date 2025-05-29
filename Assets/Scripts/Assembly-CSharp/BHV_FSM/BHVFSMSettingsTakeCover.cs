using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsTakeCover : BHVPropertySettings
	{
		[CompilerGenerated]
		private float c36b55a7af76831127e460288a3bbb620;

		[CompilerGenerated]
		private float c4f2c95c8d1a27831bfe3a122f79d9137;

		[DefaultValue(typeof(float), "0.5")]
		public float m_initialCoverChance
		{
			[CompilerGenerated]
			get
			{
				return c36b55a7af76831127e460288a3bbb620;
			}
			[CompilerGenerated]
			set
			{
				c36b55a7af76831127e460288a3bbb620 = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_dangerCoverChance
		{
			[CompilerGenerated]
			get
			{
				return c4f2c95c8d1a27831bfe3a122f79d9137;
			}
			[CompilerGenerated]
			set
			{
				c4f2c95c8d1a27831bfe3a122f79d9137 = value;
			}
		}

		public BHVFSMSettingsTakeCover()
		{
			m_initialCoverChance = 0.5f;
			m_dangerCoverChance = 1f;
		}
	}
}
