using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsTimers : BHVPropertySettings
	{
		[CompilerGenerated]
		private float ca7a7720ccc3541ba7b4cec202b84704b;

		[CompilerGenerated]
		private float cdb05d2091cb366b37455b9db809dfc9a;

		[CompilerGenerated]
		private float c302c794d8216f350dc9be45929ad6086;

		[CompilerGenerated]
		private float c80af919c22fe68c6b75b933d2068ab20;

		[CompilerGenerated]
		private float c0a5b565b888a21cf512495a3318d4661;

		[CompilerGenerated]
		private float cf56aba0a3ea1a554ee7c5b3c586e780f;

		[CompilerGenerated]
		private float cadd7808bad84f42c24ea7ebf81baecff;

		[CompilerGenerated]
		private float c89f3c34e3527d9f16b5a60c0f92b4039;

		[CompilerGenerated]
		private float cfa301cd3fbaf8fc6918805755639ccbb;

		[CompilerGenerated]
		private float c8ae2e7247b8f7523eca3266b5f483521;

		[CompilerGenerated]
		private float ca12306e81689f5045391ab76826f25f4;

		[CompilerGenerated]
		private float cf0cf4eca42417fb9a15a1a1cb1843112;

		[DefaultValue(typeof(float), "0")]
		public float m_selectTargetTimer
		{
			[CompilerGenerated]
			get
			{
				return ca7a7720ccc3541ba7b4cec202b84704b;
			}
			[CompilerGenerated]
			set
			{
				ca7a7720ccc3541ba7b4cec202b84704b = value;
			}
		}

		[DefaultValue(typeof(float), "0")]
		public float m_selectPositionTimer
		{
			[CompilerGenerated]
			get
			{
				return cdb05d2091cb366b37455b9db809dfc9a;
			}
			[CompilerGenerated]
			set
			{
				cdb05d2091cb366b37455b9db809dfc9a = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_checkAttackModeTimer
		{
			[CompilerGenerated]
			get
			{
				return c302c794d8216f350dc9be45929ad6086;
			}
			[CompilerGenerated]
			set
			{
				c302c794d8216f350dc9be45929ad6086 = value;
			}
		}

		[DefaultValue(typeof(float), "3")]
		public float m_alertFightTimer
		{
			[CompilerGenerated]
			get
			{
				return c80af919c22fe68c6b75b933d2068ab20;
			}
			[CompilerGenerated]
			set
			{
				c80af919c22fe68c6b75b933d2068ab20 = value;
			}
		}

		[DefaultValue(typeof(float), "30")]
		public float m_alertTimer
		{
			[CompilerGenerated]
			get
			{
				return c0a5b565b888a21cf512495a3318d4661;
			}
			[CompilerGenerated]
			set
			{
				c0a5b565b888a21cf512495a3318d4661 = value;
			}
		}

		[DefaultValue(typeof(float), "2")]
		public float m_selectPositionInCoverTimer
		{
			[CompilerGenerated]
			get
			{
				return cf56aba0a3ea1a554ee7c5b3c586e780f;
			}
			[CompilerGenerated]
			set
			{
				cf56aba0a3ea1a554ee7c5b3c586e780f = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_lightDamageReactionCoolDownTimer
		{
			[CompilerGenerated]
			get
			{
				return cadd7808bad84f42c24ea7ebf81baecff;
			}
			[CompilerGenerated]
			set
			{
				cadd7808bad84f42c24ea7ebf81baecff = value;
			}
		}

		[DefaultValue(typeof(float), "5")]
		public float m_heaveDamageReactionCoolDownTimer
		{
			[CompilerGenerated]
			get
			{
				return c89f3c34e3527d9f16b5a60c0f92b4039;
			}
			[CompilerGenerated]
			set
			{
				c89f3c34e3527d9f16b5a60c0f92b4039 = value;
			}
		}

		[DefaultValue(typeof(float), "2")]
		public float m_checkPositionMoveToCoverTimerMin
		{
			[CompilerGenerated]
			get
			{
				return cfa301cd3fbaf8fc6918805755639ccbb;
			}
			[CompilerGenerated]
			set
			{
				cfa301cd3fbaf8fc6918805755639ccbb = value;
			}
		}

		[DefaultValue(typeof(float), "4")]
		public float m_checkPositionMoveToCoverTimerMax
		{
			[CompilerGenerated]
			get
			{
				return c8ae2e7247b8f7523eca3266b5f483521;
			}
			[CompilerGenerated]
			set
			{
				c8ae2e7247b8f7523eca3266b5f483521 = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_checkPositionMoveToOpenSpaceTimerMin
		{
			[CompilerGenerated]
			get
			{
				return ca12306e81689f5045391ab76826f25f4;
			}
			[CompilerGenerated]
			set
			{
				ca12306e81689f5045391ab76826f25f4 = value;
			}
		}

		[DefaultValue(typeof(float), "2")]
		public float m_checkPositionMoveToOpenSpaceTimerMax
		{
			[CompilerGenerated]
			get
			{
				return cf0cf4eca42417fb9a15a1a1cb1843112;
			}
			[CompilerGenerated]
			set
			{
				cf0cf4eca42417fb9a15a1a1cb1843112 = value;
			}
		}

		public BHVFSMSettingsTimers()
		{
			m_selectTargetTimer = 0f;
			m_selectPositionTimer = 0f;
			m_checkAttackModeTimer = 1f;
			m_alertFightTimer = 3f;
			m_alertTimer = 30f;
			m_selectPositionInCoverTimer = 2f;
			m_lightDamageReactionCoolDownTimer = 1f;
			m_heaveDamageReactionCoolDownTimer = 5f;
			m_checkPositionMoveToCoverTimerMin = 2f;
			m_checkPositionMoveToCoverTimerMax = 4f;
			m_checkPositionMoveToOpenSpaceTimerMin = 1f;
			m_checkPositionMoveToOpenSpaceTimerMax = 2f;
		}
	}
}
