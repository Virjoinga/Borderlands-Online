using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsBasic : BHVPropertySettings
	{
		[CompilerGenerated]
		private int c76dcca136a9b3546af0cdfddceb25d62;

		[CompilerGenerated]
		private int cafbb493a21727a616b5620f8b0de94e0;

		[CompilerGenerated]
		private float cf041aa526ea2dff317009f03cfc2aed6;

		[CompilerGenerated]
		private float c9b8a578ed10ddc86586c85594a0e9651;

		[CompilerGenerated]
		private bool c6d27d91dceed87d1d053cdf02a3eaeff;

		[CompilerGenerated]
		private float c677e9b77a2439b91d32716ed85b21314;

		[CompilerGenerated]
		private bool cc1eb0a58375fac175fa8428e06ea1cdf;

		[CompilerGenerated]
		private float ccb9dd1fddc9dc95a9e2127abd4cf2c99;

		[CompilerGenerated]
		private float ca39d6ef149be3245e5826d1e681df692;

		[DefaultValue(0)]
		public int m_healthPoint
		{
			[CompilerGenerated]
			get
			{
				return c76dcca136a9b3546af0cdfddceb25d62;
			}
			[CompilerGenerated]
			set
			{
				c76dcca136a9b3546af0cdfddceb25d62 = value;
			}
		}

		[DefaultValue(0)]
		public int m_shieldPoint
		{
			[CompilerGenerated]
			get
			{
				return cafbb493a21727a616b5620f8b0de94e0;
			}
			[CompilerGenerated]
			set
			{
				cafbb493a21727a616b5620f8b0de94e0 = value;
			}
		}

		[DefaultValue(typeof(float), "0")]
		public float m_beenShotAtDuration
		{
			[CompilerGenerated]
			get
			{
				return cf041aa526ea2dff317009f03cfc2aed6;
			}
			[CompilerGenerated]
			set
			{
				cf041aa526ea2dff317009f03cfc2aed6 = value;
			}
		}

		[DefaultValue(typeof(float), "30")]
		public float m_enemyAlertRange
		{
			[CompilerGenerated]
			get
			{
				return c9b8a578ed10ddc86586c85594a0e9651;
			}
			[CompilerGenerated]
			set
			{
				c9b8a578ed10ddc86586c85594a0e9651 = value;
			}
		}

		[DefaultValue(true)]
		public bool m_bHasLightHurtEffect
		{
			[CompilerGenerated]
			get
			{
				return c6d27d91dceed87d1d053cdf02a3eaeff;
			}
			[CompilerGenerated]
			set
			{
				c6d27d91dceed87d1d053cdf02a3eaeff = value;
			}
		}

		[DefaultValue(typeof(float), "5")]
		public float m_startMoveDistance
		{
			[CompilerGenerated]
			get
			{
				return c677e9b77a2439b91d32716ed85b21314;
			}
			[CompilerGenerated]
			set
			{
				c677e9b77a2439b91d32716ed85b21314 = value;
			}
		}

		[DefaultValue(false)]
		public bool m_bHasCoverAbility
		{
			[CompilerGenerated]
			get
			{
				return cc1eb0a58375fac175fa8428e06ea1cdf;
			}
			[CompilerGenerated]
			set
			{
				cc1eb0a58375fac175fa8428e06ea1cdf = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_alertCoverChanceWeight
		{
			[CompilerGenerated]
			get
			{
				return ccb9dd1fddc9dc95a9e2127abd4cf2c99;
			}
			[CompilerGenerated]
			set
			{
				ccb9dd1fddc9dc95a9e2127abd4cf2c99 = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_alertMoveToGPPChanceWeight
		{
			[CompilerGenerated]
			get
			{
				return ca39d6ef149be3245e5826d1e681df692;
			}
			[CompilerGenerated]
			set
			{
				ca39d6ef149be3245e5826d1e681df692 = value;
			}
		}

		public BHVFSMSettingsBasic()
		{
			m_healthPoint = 0;
			m_shieldPoint = 0;
			m_beenShotAtDuration = 0f;
			m_enemyAlertRange = 30f;
			m_bHasLightHurtEffect = true;
			m_startMoveDistance = 5f;
			m_bHasCoverAbility = false;
			m_alertCoverChanceWeight = 1f;
			m_alertMoveToGPPChanceWeight = 1f;
		}
	}
}
