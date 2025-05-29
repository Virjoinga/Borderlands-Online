using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsShieldRush : BHVPropertySettings
	{
		[CompilerGenerated]
		private float c896391b65d9240fdad9239a456c1757b;

		[CompilerGenerated]
		private float ca73b49b503b7c1cec4f077e38c49ddcc;

		[CompilerGenerated]
		private float c56dc32b70593b934f270ad94f034495f;

		[CompilerGenerated]
		private float c8717f7122ab372a5c7368c916cac327a;

		[DefaultValue(typeof(float), "10")]
		public float m_rushAttackDistanceMin
		{
			[CompilerGenerated]
			get
			{
				return c896391b65d9240fdad9239a456c1757b;
			}
			[CompilerGenerated]
			set
			{
				c896391b65d9240fdad9239a456c1757b = value;
			}
		}

		[DefaultValue(typeof(float), "50")]
		public float m_rushAttackDistanceMax
		{
			[CompilerGenerated]
			get
			{
				return ca73b49b503b7c1cec4f077e38c49ddcc;
			}
			[CompilerGenerated]
			set
			{
				ca73b49b503b7c1cec4f077e38c49ddcc = value;
			}
		}

		[DefaultValue(typeof(float), "5")]
		public float m_distanceBeforeTarget
		{
			[CompilerGenerated]
			get
			{
				return c56dc32b70593b934f270ad94f034495f;
			}
			[CompilerGenerated]
			set
			{
				c56dc32b70593b934f270ad94f034495f = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_attackChanceWeight
		{
			[CompilerGenerated]
			get
			{
				return c8717f7122ab372a5c7368c916cac327a;
			}
			[CompilerGenerated]
			set
			{
				c8717f7122ab372a5c7368c916cac327a = value;
			}
		}

		public BHVFSMSettingsShieldRush()
		{
			m_rushAttackDistanceMin = 10f;
			m_rushAttackDistanceMax = 50f;
			m_distanceBeforeTarget = 5f;
			m_attackChanceWeight = 1f;
		}
	}
}
