using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsCrouchRollDodge : BHVPropertySettings
	{
		[CompilerGenerated]
		private float c1681535bc00ccccde92f1fcfa8ec008b;

		[CompilerGenerated]
		private float ca6b39a167e7f5254fb824e97c6b93ca1;

		[CompilerGenerated]
		private float cc427e75e81824f43771e2b35aec564ec;

		[CompilerGenerated]
		private float c8b5e64f593d9d662aff5630ed144a8d5;

		[CompilerGenerated]
		private float c1a4cf459e5d88382c38c590877c73184;

		[DefaultValue(typeof(float), "1")]
		public float m_changeStanceChanceSafe
		{
			[CompilerGenerated]
			get
			{
				return c1681535bc00ccccde92f1fcfa8ec008b;
			}
			[CompilerGenerated]
			set
			{
				c1681535bc00ccccde92f1fcfa8ec008b = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_changeStanceChanceDanger
		{
			[CompilerGenerated]
			get
			{
				return ca6b39a167e7f5254fb824e97c6b93ca1;
			}
			[CompilerGenerated]
			set
			{
				ca6b39a167e7f5254fb824e97c6b93ca1 = value;
			}
		}

		[DefaultValue(typeof(float), "2")]
		public float m_dodgeRepeatTime
		{
			[CompilerGenerated]
			get
			{
				return cc427e75e81824f43771e2b35aec564ec;
			}
			[CompilerGenerated]
			set
			{
				cc427e75e81824f43771e2b35aec564ec = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_dodgeChance
		{
			[CompilerGenerated]
			get
			{
				return c8b5e64f593d9d662aff5630ed144a8d5;
			}
			[CompilerGenerated]
			set
			{
				c8b5e64f593d9d662aff5630ed144a8d5 = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_rollChance
		{
			[CompilerGenerated]
			get
			{
				return c1a4cf459e5d88382c38c590877c73184;
			}
			[CompilerGenerated]
			set
			{
				c1a4cf459e5d88382c38c590877c73184 = value;
			}
		}

		public BHVFSMSettingsCrouchRollDodge()
		{
			m_changeStanceChanceSafe = 1f;
			m_changeStanceChanceDanger = 1f;
			m_dodgeRepeatTime = 2f;
			m_dodgeChance = 1f;
			m_rollChance = 1f;
		}
	}
}
