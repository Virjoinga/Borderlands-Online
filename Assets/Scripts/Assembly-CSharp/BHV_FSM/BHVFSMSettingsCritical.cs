using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsCritical : BHVPropertySettings
	{
		[CompilerGenerated]
		private float c8bb7214d8638aca13b1924dc8ebaa184;

		[CompilerGenerated]
		private float c88fa1a09c57f4d042715662365716654;

		[CompilerGenerated]
		private float ca51fa8c9663b75bb9b96196d70c36f30;

		[CompilerGenerated]
		private float ca3dba72dd2db788d1077697c6eee694f;

		[DefaultValue(typeof(float), "2")]
		public float m_damageMultiplier
		{
			[CompilerGenerated]
			get
			{
				return c8bb7214d8638aca13b1924dc8ebaa184;
			}
			[CompilerGenerated]
			set
			{
				c8bb7214d8638aca13b1924dc8ebaa184 = value;
			}
		}

		[DefaultValue(typeof(float), "5")]
		public float m_coolDownTime
		{
			[CompilerGenerated]
			get
			{
				return c88fa1a09c57f4d042715662365716654;
			}
			[CompilerGenerated]
			set
			{
				c88fa1a09c57f4d042715662365716654 = value;
			}
		}

		[DefaultValue(typeof(float), "2")]
		public float m_time
		{
			[CompilerGenerated]
			get
			{
				return ca51fa8c9663b75bb9b96196d70c36f30;
			}
			[CompilerGenerated]
			set
			{
				ca51fa8c9663b75bb9b96196d70c36f30 = value;
			}
		}

		[DefaultValue(typeof(float), "0.01")]
		public float m_damageOfMaxHPPercent
		{
			[CompilerGenerated]
			get
			{
				return ca3dba72dd2db788d1077697c6eee694f;
			}
			[CompilerGenerated]
			set
			{
				ca3dba72dd2db788d1077697c6eee694f = value;
			}
		}

		public BHVFSMSettingsCritical()
		{
			m_damageMultiplier = 2f;
			m_coolDownTime = 5f;
			m_time = 2f;
			m_damageOfMaxHPPercent = 0.01f;
		}
	}
}
