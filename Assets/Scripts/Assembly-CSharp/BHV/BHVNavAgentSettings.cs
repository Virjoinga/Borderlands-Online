using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

namespace BHV
{
	public class BHVNavAgentSettings : BHVTaskSettings
	{
		[XmlIgnore]
		public float c5c8eaa675f4b93ec7995dc3464329e0c = 0.5f;

		[XmlIgnore]
		public float c3565b17b86b7da2c7f03b96582834e00 = 1f;

		[XmlIgnore]
		public float c1e98f1733f8d31a42d9a8d8c0b0f5a99 = 8f;

		[XmlIgnore]
		public float cbb69e1235c94924bc5278486044765af = 360f;

		[XmlIgnore]
		public float cc4fb5c05be8c66a0a917295be22e3556;

		[XmlIgnore]
		public ObstacleAvoidanceType c3371f2b99d8ec54342d2681932fdb585 = ObstacleAvoidanceType.MedQualityObstacleAvoidance;

		[CompilerGenerated]
		private float c0f4d4610fd580da4e1334b298711a042;

		[CompilerGenerated]
		private float c0e4dfa6ad8b70c1b5c5710543ce2de43;

		[CompilerGenerated]
		private float c0d715c43065d5551eeb70a0fc88c56a5;

		[CompilerGenerated]
		private float c07c9cb8b0ec2a7f90f528f452e907d9e;

		[CompilerGenerated]
		private float cf9d5fc730256b4b0add6646928601e27;

		[CompilerGenerated]
		private float c64ed95f955e1331983d9092b4339575c;

		[CompilerGenerated]
		private bool cb432ad1e487bb208190e77855b59d9fb;

		[CompilerGenerated]
		private float c3c6f9a7eaa9003d9fa88f2d8d6d7ec49;

		[CompilerGenerated]
		private float ce05da3a6a46cfc96752cf56fd893c93c;

		[DefaultValue(typeof(float), "0.01")]
		public float m_walkSpeed
		{
			[CompilerGenerated]
			get
			{
				return c0f4d4610fd580da4e1334b298711a042;
			}
			[CompilerGenerated]
			set
			{
				c0f4d4610fd580da4e1334b298711a042 = value;
			}
		}

		[DefaultValue(typeof(float), "0.01")]
		public float m_walkCombatSpeed
		{
			[CompilerGenerated]
			get
			{
				return c0e4dfa6ad8b70c1b5c5710543ce2de43;
			}
			[CompilerGenerated]
			set
			{
				c0e4dfa6ad8b70c1b5c5710543ce2de43 = value;
			}
		}

		[DefaultValue(typeof(float), "0.01")]
		public float m_runSpeed
		{
			[CompilerGenerated]
			get
			{
				return c0d715c43065d5551eeb70a0fc88c56a5;
			}
			[CompilerGenerated]
			set
			{
				c0d715c43065d5551eeb70a0fc88c56a5 = value;
			}
		}

		[DefaultValue(typeof(float), "0.01")]
		public float m_sprintSpeed
		{
			[CompilerGenerated]
			get
			{
				return c07c9cb8b0ec2a7f90f528f452e907d9e;
			}
			[CompilerGenerated]
			set
			{
				c07c9cb8b0ec2a7f90f528f452e907d9e = value;
			}
		}

		[DefaultValue(typeof(float), "0.01")]
		public float m_jumpSpeed
		{
			[CompilerGenerated]
			get
			{
				return cf9d5fc730256b4b0add6646928601e27;
			}
			[CompilerGenerated]
			set
			{
				cf9d5fc730256b4b0add6646928601e27 = value;
			}
		}

		[DefaultValue(typeof(float), "0.01")]
		public float m_chargeSpeed
		{
			[CompilerGenerated]
			get
			{
				return c64ed95f955e1331983d9092b4339575c;
			}
			[CompilerGenerated]
			set
			{
				c64ed95f955e1331983d9092b4339575c = value;
			}
		}

		[DefaultValue(true)]
		public bool m_canUseFacingLogic
		{
			[CompilerGenerated]
			get
			{
				return cb432ad1e487bb208190e77855b59d9fb;
			}
			[CompilerGenerated]
			set
			{
				cb432ad1e487bb208190e77855b59d9fb = value;
			}
		}

		[DefaultValue(typeof(float), "0.1")]
		public float m_stopDistance
		{
			[CompilerGenerated]
			get
			{
				return c3c6f9a7eaa9003d9fa88f2d8d6d7ec49;
			}
			[CompilerGenerated]
			set
			{
				c3c6f9a7eaa9003d9fa88f2d8d6d7ec49 = value;
			}
		}

		[DefaultValue(typeof(float), "0.3")]
		public float m_combatSpawnDuration
		{
			[CompilerGenerated]
			get
			{
				return ce05da3a6a46cfc96752cf56fd893c93c;
			}
			[CompilerGenerated]
			set
			{
				ce05da3a6a46cfc96752cf56fd893c93c = value;
			}
		}

		public BHVNavAgentSettings()
		{
			m_walkSpeed = 0.01f;
			m_walkCombatSpeed = 0.01f;
			m_runSpeed = 0.01f;
			m_sprintSpeed = 0.01f;
			m_jumpSpeed = 0.01f;
			m_chargeSpeed = 0.01f;
			m_canUseFacingLogic = true;
			m_stopDistance = 0.1f;
			m_combatSpawnDuration = 0.3f;
		}
	}
}
