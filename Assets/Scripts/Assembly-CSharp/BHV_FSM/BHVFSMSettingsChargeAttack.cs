using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsChargeAttack : BHVPropertySettingsAttackBase
	{
		[CompilerGenerated]
		private float c57d36979729395c5978ed9d7794a3a71;

		[CompilerGenerated]
		private float c59a0fdfb1b3316acfc7080345583bd2f;

		[CompilerGenerated]
		private float c18e565bfa418389c97081047c4c01f8b;

		[CompilerGenerated]
		private float cecdb54c6edb2d2d849ccd6237ff7fa26;

		[CompilerGenerated]
		private float c6a74453e76ecff38ad032ec9ed69afa2;

		[DefaultValue(typeof(float), "8")]
		public float m_chargeDistanceMin
		{
			[CompilerGenerated]
			get
			{
				return c57d36979729395c5978ed9d7794a3a71;
			}
			[CompilerGenerated]
			set
			{
				c57d36979729395c5978ed9d7794a3a71 = value;
			}
		}

		[DefaultValue(typeof(float), "16")]
		public float m_chargeDistanceMax
		{
			[CompilerGenerated]
			get
			{
				return c59a0fdfb1b3316acfc7080345583bd2f;
			}
			[CompilerGenerated]
			set
			{
				c59a0fdfb1b3316acfc7080345583bd2f = value;
			}
		}

		[DefaultValue(typeof(float), "15")]
		public float m_chargeAttackAngle
		{
			[CompilerGenerated]
			get
			{
				return c18e565bfa418389c97081047c4c01f8b;
			}
			[CompilerGenerated]
			set
			{
				c18e565bfa418389c97081047c4c01f8b = value;
			}
		}

		[DefaultValue(typeof(float), "0.5")]
		public float m_chargeAttackIdleTime
		{
			[CompilerGenerated]
			get
			{
				return cecdb54c6edb2d2d849ccd6237ff7fa26;
			}
			[CompilerGenerated]
			set
			{
				cecdb54c6edb2d2d849ccd6237ff7fa26 = value;
			}
		}

		[DefaultValue(typeof(float), "2")]
		public float m_distanceBehindTarget
		{
			[CompilerGenerated]
			get
			{
				return c6a74453e76ecff38ad032ec9ed69afa2;
			}
			[CompilerGenerated]
			set
			{
				c6a74453e76ecff38ad032ec9ed69afa2 = value;
			}
		}

		public BHVFSMSettingsChargeAttack()
		{
			m_chargeDistanceMin = 8f;
			m_chargeDistanceMax = 16f;
			m_chargeAttackAngle = 15f;
			m_chargeAttackIdleTime = 0.5f;
			m_distanceBehindTarget = 2f;
		}
	}
}
