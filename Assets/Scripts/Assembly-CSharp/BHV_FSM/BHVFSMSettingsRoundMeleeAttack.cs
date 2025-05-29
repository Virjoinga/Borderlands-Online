using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsRoundMeleeAttack : BHVPropertySettingsAttackBase
	{
		[CompilerGenerated]
		private int cbfa575ba45cfa56d7d37d12bc7e02a16;

		[CompilerGenerated]
		private int c2e124c29b311759b908f09800cb80c96;

		[CompilerGenerated]
		private float c788595e2708a7200d45ff8e0f4e47e1b;

		[CompilerGenerated]
		private float c661bb2f9e9ea52d64e131494c08d36ba;

		[CompilerGenerated]
		private float c9105995c4f950e4451fb844e0569ae33;

		[CompilerGenerated]
		private float cb2952b1973848d765969dd161d6c1f1d;

		[CompilerGenerated]
		private float ce4e8151ffd27200688686fc71163fc74;

		[CompilerGenerated]
		private float cd77e45db8959491717529520ab2fd33e;

		[CompilerGenerated]
		private float cc167b510f7abef442d231cd5f5d1bc06;

		[DefaultValue(2)]
		public int m_meleeAttackCountMin
		{
			[CompilerGenerated]
			get
			{
				return cbfa575ba45cfa56d7d37d12bc7e02a16;
			}
			[CompilerGenerated]
			set
			{
				cbfa575ba45cfa56d7d37d12bc7e02a16 = value;
			}
		}

		[DefaultValue(4)]
		public int m_meleeAttackCountMax
		{
			[CompilerGenerated]
			get
			{
				return c2e124c29b311759b908f09800cb80c96;
			}
			[CompilerGenerated]
			set
			{
				c2e124c29b311759b908f09800cb80c96 = value;
			}
		}

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

		[DefaultValue(typeof(float), "5")]
		public float m_moveBackDistanceMin
		{
			[CompilerGenerated]
			get
			{
				return ce4e8151ffd27200688686fc71163fc74;
			}
			[CompilerGenerated]
			set
			{
				ce4e8151ffd27200688686fc71163fc74 = value;
			}
		}

		[DefaultValue(typeof(float), "10")]
		public float m_moveBackDistanceMax
		{
			[CompilerGenerated]
			get
			{
				return cd77e45db8959491717529520ab2fd33e;
			}
			[CompilerGenerated]
			set
			{
				cd77e45db8959491717529520ab2fd33e = value;
			}
		}

		[DefaultValue(typeof(float), "0.5")]
		public float m_moveBackChance
		{
			[CompilerGenerated]
			get
			{
				return cc167b510f7abef442d231cd5f5d1bc06;
			}
			[CompilerGenerated]
			set
			{
				cc167b510f7abef442d231cd5f5d1bc06 = value;
			}
		}

		public BHVFSMSettingsRoundMeleeAttack()
		{
			m_meleeAttackCountMin = 2;
			m_meleeAttackCountMax = 4;
			m_meleeAttackDistanceMin = 0f;
			m_meleeAttackDistanceMax = 0f;
			m_meleeAttackAngle = 0f;
			m_meleeAttackIdleTime = 0f;
			m_moveBackDistanceMin = 5f;
			m_moveBackDistanceMax = 10f;
			m_moveBackChance = 0.5f;
		}
	}
}
