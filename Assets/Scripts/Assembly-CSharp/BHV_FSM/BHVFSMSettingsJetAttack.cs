using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsJetAttack : BHVPropertySettingsAttackBase
	{
		[CompilerGenerated]
		private int c81753de50853810305a1ab22cb89ed29;

		[CompilerGenerated]
		private float cbd00af3656261386400308a7e42e63c6;

		[CompilerGenerated]
		private float c608c18ed805012647528a0e368bf9df4;

		[CompilerGenerated]
		private float cb59667717ee3f63762b713f9591164d4;

		[CompilerGenerated]
		private float caf26f443d142719c59dd6baeec35a6af;

		[CompilerGenerated]
		private float cac9ddf669a973f2ee3626dc42ace0733;

		[DefaultValue(60)]
		public int m_jetAttackDamage
		{
			[CompilerGenerated]
			get
			{
				return c81753de50853810305a1ab22cb89ed29;
			}
			[CompilerGenerated]
			set
			{
				c81753de50853810305a1ab22cb89ed29 = value;
			}
		}

		[DefaultValue(typeof(float), "30")]
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

		[DefaultValue(typeof(float), "5")]
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

		[DefaultValue(typeof(float), "3")]
		public float m_damageRadius
		{
			[CompilerGenerated]
			get
			{
				return cb59667717ee3f63762b713f9591164d4;
			}
			[CompilerGenerated]
			set
			{
				cb59667717ee3f63762b713f9591164d4 = value;
			}
		}

		[DefaultValue(typeof(float), "15")]
		public float m_jetFlyingSpeed
		{
			[CompilerGenerated]
			get
			{
				return caf26f443d142719c59dd6baeec35a6af;
			}
			[CompilerGenerated]
			set
			{
				caf26f443d142719c59dd6baeec35a6af = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_jetAttackIdleTime
		{
			[CompilerGenerated]
			get
			{
				return cac9ddf669a973f2ee3626dc42ace0733;
			}
			[CompilerGenerated]
			set
			{
				cac9ddf669a973f2ee3626dc42ace0733 = value;
			}
		}

		public BHVFSMSettingsJetAttack()
		{
			m_jetAttackDamage = 60;
			m_attackDistanceMin = 30f;
			m_attackDistanceMax = 5f;
			m_damageRadius = 3f;
			m_jetFlyingSpeed = 15f;
			m_jetAttackIdleTime = 1f;
		}
	}
}
