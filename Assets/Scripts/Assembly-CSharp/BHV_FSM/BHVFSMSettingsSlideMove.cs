using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsSlideMove : BHVPropertySettings
	{
		[CompilerGenerated]
		private float c7d2c00ace55cd6ff440536dd535f7b67;

		[CompilerGenerated]
		private float c87547c75823f35c51daf0ecc93a16d1e;

		[CompilerGenerated]
		private float ca5b5004503751093ce3a2ff7d04fead3;

		[DefaultValue(typeof(float), "5")]
		public float m_slideMoveSpeed
		{
			[CompilerGenerated]
			get
			{
				return c7d2c00ace55cd6ff440536dd535f7b67;
			}
			[CompilerGenerated]
			set
			{
				c7d2c00ace55cd6ff440536dd535f7b67 = value;
			}
		}

		[DefaultValue(typeof(float), "10")]
		public float m_slideRushSpeed
		{
			[CompilerGenerated]
			get
			{
				return c87547c75823f35c51daf0ecc93a16d1e;
			}
			[CompilerGenerated]
			set
			{
				c87547c75823f35c51daf0ecc93a16d1e = value;
			}
		}

		[DefaultValue(typeof(float), "20")]
		public float m_acceleration
		{
			[CompilerGenerated]
			get
			{
				return ca5b5004503751093ce3a2ff7d04fead3;
			}
			[CompilerGenerated]
			set
			{
				ca5b5004503751093ce3a2ff7d04fead3 = value;
			}
		}

		public BHVFSMSettingsSlideMove()
		{
			m_slideMoveSpeed = 5f;
			m_slideRushSpeed = 10f;
			m_acceleration = 20f;
		}
	}
}
