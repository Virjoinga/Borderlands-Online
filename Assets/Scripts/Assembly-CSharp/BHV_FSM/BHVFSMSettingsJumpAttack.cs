using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsJumpAttack : BHVPropertySettingsAttackBase
	{
		[CompilerGenerated]
		private float c4b5db56ee306ef750ce3b4a00161c839;

		[CompilerGenerated]
		private float cb4a9e0e273cf7ac35ccb6dfa749bec07;

		[CompilerGenerated]
		private float ca055e4e429375f8dbf2e4aca95611801;

		[CompilerGenerated]
		private float c2077473cc6081ef5001dfcf5178caa48;

		[CompilerGenerated]
		private float c78c4ea041410bccf2ab02f372e859232;

		[DefaultValue(typeof(float), "4")]
		public float m_jumpDistanceMin
		{
			[CompilerGenerated]
			get
			{
				return c4b5db56ee306ef750ce3b4a00161c839;
			}
			[CompilerGenerated]
			set
			{
				c4b5db56ee306ef750ce3b4a00161c839 = value;
			}
		}

		[DefaultValue(typeof(float), "8")]
		public float m_jumpDistanceMax
		{
			[CompilerGenerated]
			get
			{
				return cb4a9e0e273cf7ac35ccb6dfa749bec07;
			}
			[CompilerGenerated]
			set
			{
				cb4a9e0e273cf7ac35ccb6dfa749bec07 = value;
			}
		}

		[DefaultValue(typeof(float), "4")]
		public float m_jumpHightMax
		{
			[CompilerGenerated]
			get
			{
				return ca055e4e429375f8dbf2e4aca95611801;
			}
			[CompilerGenerated]
			set
			{
				ca055e4e429375f8dbf2e4aca95611801 = value;
			}
		}

		[DefaultValue(typeof(float), "15")]
		public float m_jumpAttackAngle
		{
			[CompilerGenerated]
			get
			{
				return c2077473cc6081ef5001dfcf5178caa48;
			}
			[CompilerGenerated]
			set
			{
				c2077473cc6081ef5001dfcf5178caa48 = value;
			}
		}

		[DefaultValue(typeof(float), "0.5")]
		public float m_jumpAttackIdleTime
		{
			[CompilerGenerated]
			get
			{
				return c78c4ea041410bccf2ab02f372e859232;
			}
			[CompilerGenerated]
			set
			{
				c78c4ea041410bccf2ab02f372e859232 = value;
			}
		}

		public BHVFSMSettingsJumpAttack()
		{
			m_jumpDistanceMin = 4f;
			m_jumpDistanceMax = 8f;
			m_jumpHightMax = 4f;
			m_jumpAttackAngle = 15f;
			m_jumpAttackIdleTime = 0.5f;
		}
	}
}
