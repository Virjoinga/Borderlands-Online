using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsTeleport : BHVPropertySettings
	{
		[CompilerGenerated]
		private float c909819da4fbd38fa6e73007905e4b649;

		[CompilerGenerated]
		private float c512241cac9beedee87b544f3316fe168;

		[CompilerGenerated]
		private float cd3695a7cce387f8d2b04b5ad06a39406;

		[CompilerGenerated]
		private float c1e16e51404de53b09d6c285121c0a4f1;

		[CompilerGenerated]
		private float c8717f7122ab372a5c7368c916cac327a;

		[CompilerGenerated]
		private float ca2c29db3961de71717c9e63b10163beb;

		[CompilerGenerated]
		private float cbd92a1370f705dccd4c66f8e259ac0e1;

		[CompilerGenerated]
		private float cda42bd05ef169f135e5b1dc01be09126;

		[DefaultValue(typeof(float), "10")]
		public float m_teleportDistanceMin
		{
			[CompilerGenerated]
			get
			{
				return c909819da4fbd38fa6e73007905e4b649;
			}
			[CompilerGenerated]
			set
			{
				c909819da4fbd38fa6e73007905e4b649 = value;
			}
		}

		[DefaultValue(typeof(float), "50")]
		public float m_teleportDistanceMax
		{
			[CompilerGenerated]
			get
			{
				return c512241cac9beedee87b544f3316fe168;
			}
			[CompilerGenerated]
			set
			{
				c512241cac9beedee87b544f3316fe168 = value;
			}
		}

		[DefaultValue(typeof(float), "5")]
		public float m_teleportDistanceToTarget
		{
			[CompilerGenerated]
			get
			{
				return cd3695a7cce387f8d2b04b5ad06a39406;
			}
			[CompilerGenerated]
			set
			{
				cd3695a7cce387f8d2b04b5ad06a39406 = value;
			}
		}

		[DefaultValue(typeof(float), "360")]
		public float m_telepartAngelToTarge
		{
			[CompilerGenerated]
			get
			{
				return c1e16e51404de53b09d6c285121c0a4f1;
			}
			[CompilerGenerated]
			set
			{
				c1e16e51404de53b09d6c285121c0a4f1 = value;
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

		[DefaultValue(typeof(float), "0.5")]
		public float m_teleportTimeMin
		{
			[CompilerGenerated]
			get
			{
				return ca2c29db3961de71717c9e63b10163beb;
			}
			[CompilerGenerated]
			set
			{
				ca2c29db3961de71717c9e63b10163beb = value;
			}
		}

		[DefaultValue(typeof(float), "3")]
		public float m_teleportTimeMax
		{
			[CompilerGenerated]
			get
			{
				return cbd92a1370f705dccd4c66f8e259ac0e1;
			}
			[CompilerGenerated]
			set
			{
				cbd92a1370f705dccd4c66f8e259ac0e1 = value;
			}
		}

		[DefaultValue(typeof(float), "0.5")]
		public float m_idleTimeBeforeHide
		{
			[CompilerGenerated]
			get
			{
				return cda42bd05ef169f135e5b1dc01be09126;
			}
			[CompilerGenerated]
			set
			{
				cda42bd05ef169f135e5b1dc01be09126 = value;
			}
		}

		public BHVFSMSettingsTeleport()
		{
			m_teleportDistanceMin = 10f;
			m_teleportDistanceMax = 50f;
			m_teleportDistanceToTarget = 5f;
			m_telepartAngelToTarge = 360f;
			m_attackChanceWeight = 1f;
			m_teleportTimeMin = 0.5f;
			m_teleportTimeMax = 3f;
			m_idleTimeBeforeHide = 0.5f;
		}
	}
}
