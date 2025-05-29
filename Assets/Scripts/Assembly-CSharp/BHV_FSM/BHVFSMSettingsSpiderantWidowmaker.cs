using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsSpiderantWidowmaker : BHVPropertySettingsPhase
	{
		[CompilerGenerated]
		private float cc69a3ce8e5b0fc60b8b59f94c6d2c552;

		[CompilerGenerated]
		private float c3ceeef714296de6b81b92e0553efcde0;

		[CompilerGenerated]
		private float c36445e7688cf6ce6cd2a38ce91c9b772;

		[CompilerGenerated]
		private float c3bad27238a1c3626118db941fc75b692;

		[CompilerGenerated]
		private float c8ec8adb049644ac541d97543fe284afd;

		[CompilerGenerated]
		private float ccf981ea11360fa40f9c91598876c2d5f;

		[CompilerGenerated]
		private float c414443e2dc69e5f5aa5a3267befd8f5b;

		[CompilerGenerated]
		private float c5d00ecc8cd2b1bd0201775b03bee7c19;

		[CompilerGenerated]
		private float c8744aa53599706ee5ef761a7a531d327;

		[CompilerGenerated]
		private float c15b1081fca36b2700d0afa97ff832e5e;

		[DefaultValue(typeof(float), "0.66")]
		public float m_exitPhase_hp
		{
			[CompilerGenerated]
			get
			{
				return cc69a3ce8e5b0fc60b8b59f94c6d2c552;
			}
			[CompilerGenerated]
			set
			{
				cc69a3ce8e5b0fc60b8b59f94c6d2c552 = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_damageBuffMultiplier
		{
			[CompilerGenerated]
			get
			{
				return c3ceeef714296de6b81b92e0553efcde0;
			}
			[CompilerGenerated]
			set
			{
				c3ceeef714296de6b81b92e0553efcde0 = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_meleeAttackWeight
		{
			[CompilerGenerated]
			get
			{
				return c36445e7688cf6ce6cd2a38ce91c9b772;
			}
			[CompilerGenerated]
			set
			{
				c36445e7688cf6ce6cd2a38ce91c9b772 = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_jumpAttackWeight
		{
			[CompilerGenerated]
			get
			{
				return c3bad27238a1c3626118db941fc75b692;
			}
			[CompilerGenerated]
			set
			{
				c3bad27238a1c3626118db941fc75b692 = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_radiusAttackWeight
		{
			[CompilerGenerated]
			get
			{
				return c8ec8adb049644ac541d97543fe284afd;
			}
			[CompilerGenerated]
			set
			{
				c8ec8adb049644ac541d97543fe284afd = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_burrowAttackWeight
		{
			[CompilerGenerated]
			get
			{
				return ccf981ea11360fa40f9c91598876c2d5f;
			}
			[CompilerGenerated]
			set
			{
				ccf981ea11360fa40f9c91598876c2d5f = value;
			}
		}

		[DefaultValue(typeof(float), "5")]
		public float m_spacingTime
		{
			[CompilerGenerated]
			get
			{
				return c414443e2dc69e5f5aa5a3267befd8f5b;
			}
			[CompilerGenerated]
			set
			{
				c414443e2dc69e5f5aa5a3267befd8f5b = value;
			}
		}

		[DefaultValue(typeof(float), "10")]
		public float m_spacingRangeMin
		{
			[CompilerGenerated]
			get
			{
				return c5d00ecc8cd2b1bd0201775b03bee7c19;
			}
			[CompilerGenerated]
			set
			{
				c5d00ecc8cd2b1bd0201775b03bee7c19 = value;
			}
		}

		[DefaultValue(typeof(float), "18")]
		public float m_spacingRangeMax
		{
			[CompilerGenerated]
			get
			{
				return c8744aa53599706ee5ef761a7a531d327;
			}
			[CompilerGenerated]
			set
			{
				c8744aa53599706ee5ef761a7a531d327 = value;
			}
		}

		[DefaultValue(typeof(float), "0")]
		public float m_webTrapWeight
		{
			[CompilerGenerated]
			get
			{
				return c15b1081fca36b2700d0afa97ff832e5e;
			}
			[CompilerGenerated]
			set
			{
				c15b1081fca36b2700d0afa97ff832e5e = value;
			}
		}

		public BHVFSMSettingsSpiderantWidowmaker()
		{
			m_exitPhase_hp = 0.66f;
			m_damageBuffMultiplier = 1f;
			m_meleeAttackWeight = 1f;
			m_jumpAttackWeight = 1f;
			m_radiusAttackWeight = 1f;
			m_burrowAttackWeight = 1f;
			m_spacingTime = 5f;
			m_spacingRangeMin = 10f;
			m_spacingRangeMax = 18f;
			m_webTrapWeight = 0f;
		}
	}
}
