using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsSpitAttack : BHVPropertySettingsAttackBase
	{
		[CompilerGenerated]
		private float c608c18ed805012647528a0e368bf9df4;

		[CompilerGenerated]
		private float cbd00af3656261386400308a7e42e63c6;

		[CompilerGenerated]
		private float c034d59a3b63dc84ef11c4401a20d2c7e;

		[CompilerGenerated]
		private float c118181f39cd00d83342f9314e2a1a70f;

		[CompilerGenerated]
		private int c474c3b3159951e49fb976fdf4a750fbd;

		[DefaultValue(typeof(float), "15")]
		public float m_attackDistanceMax
		{
			[CompilerGenerated]
			get
			{
				return c608c18ed805012647528a0e368bf9df4;
			}
			[CompilerGenerated]
			set
			{
				c608c18ed805012647528a0e368bf9df4 = value;
			}
		}

		[DefaultValue(typeof(float), "2")]
		public float m_attackDistanceMin
		{
			[CompilerGenerated]
			get
			{
				return cbd00af3656261386400308a7e42e63c6;
			}
			[CompilerGenerated]
			set
			{
				cbd00af3656261386400308a7e42e63c6 = value;
			}
		}

		[DefaultValue(typeof(float), "15")]
		public float m_attackAngle
		{
			[CompilerGenerated]
			get
			{
				return c034d59a3b63dc84ef11c4401a20d2c7e;
			}
			[CompilerGenerated]
			set
			{
				c034d59a3b63dc84ef11c4401a20d2c7e = value;
			}
		}

		[DefaultValue(typeof(float), "3")]
		public float m_attackIdleTime
		{
			[CompilerGenerated]
			get
			{
				return c118181f39cd00d83342f9314e2a1a70f;
			}
			[CompilerGenerated]
			set
			{
				c118181f39cd00d83342f9314e2a1a70f = value;
			}
		}

		[DefaultValue(1)]
		public int m_spitAttackAnimCount
		{
			[CompilerGenerated]
			get
			{
				return c474c3b3159951e49fb976fdf4a750fbd;
			}
			[CompilerGenerated]
			set
			{
				c474c3b3159951e49fb976fdf4a750fbd = value;
			}
		}

		public BHVFSMSettingsSpitAttack()
		{
			m_attackDistanceMax = 15f;
			m_attackDistanceMin = 2f;
			m_attackAngle = 15f;
			m_attackIdleTime = 3f;
			m_spitAttackAnimCount = 1;
		}
	}
}
