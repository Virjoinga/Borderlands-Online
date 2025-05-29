using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsMeleeAttack : BHVPropertySettingsAttackBase
	{
		[CompilerGenerated]
		private float c788595e2708a7200d45ff8e0f4e47e1b;

		[CompilerGenerated]
		private float c661bb2f9e9ea52d64e131494c08d36ba;

		[CompilerGenerated]
		private float c9105995c4f950e4451fb844e0569ae33;

		[CompilerGenerated]
		private float cb2952b1973848d765969dd161d6c1f1d;

		[CompilerGenerated]
		private float cf3719703ef068084ba6f977afcc18c44;

		[DefaultValue(typeof(float), "0")]
		public float m_meleeAttackDistanceMin
		{
			[CompilerGenerated]
			get
			{
				return c788595e2708a7200d45ff8e0f4e47e1b;
			}
			[CompilerGenerated]
			set
			{
				c788595e2708a7200d45ff8e0f4e47e1b = value;
			}
		}

		[DefaultValue(typeof(float), "0")]
		public float m_meleeAttackDistanceMax
		{
			[CompilerGenerated]
			get
			{
				return c661bb2f9e9ea52d64e131494c08d36ba;
			}
			[CompilerGenerated]
			set
			{
				c661bb2f9e9ea52d64e131494c08d36ba = value;
			}
		}

		[DefaultValue(typeof(float), "0")]
		public float m_meleeAttackAngle
		{
			[CompilerGenerated]
			get
			{
				return c9105995c4f950e4451fb844e0569ae33;
			}
			[CompilerGenerated]
			set
			{
				c9105995c4f950e4451fb844e0569ae33 = value;
			}
		}

		[DefaultValue(typeof(float), "0")]
		public float m_meleeAttackIdleTime
		{
			[CompilerGenerated]
			get
			{
				return cb2952b1973848d765969dd161d6c1f1d;
			}
			[CompilerGenerated]
			set
			{
				cb2952b1973848d765969dd161d6c1f1d = value;
			}
		}

		[DefaultValue(typeof(float), "6")]
		public float m_cancelMeleeAttackTimer
		{
			[CompilerGenerated]
			get
			{
				return cf3719703ef068084ba6f977afcc18c44;
			}
			[CompilerGenerated]
			set
			{
				cf3719703ef068084ba6f977afcc18c44 = value;
			}
		}

		public BHVFSMSettingsMeleeAttack()
		{
			m_meleeAttackDistanceMin = 0f;
			m_meleeAttackDistanceMax = 0f;
			m_meleeAttackAngle = 0f;
			m_meleeAttackIdleTime = 0f;
			m_cancelMeleeAttackTimer = 6f;
		}
	}
}
