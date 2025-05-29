using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using XsdSettings;

namespace BHV
{
	public class BHVFlyMeleeAttackSettings : BHVTaskSettings
	{
		private AttackSubType[] c6ab5f92cda7d2ecf7901d7fb79c2b71a;

		[CompilerGenerated]
		private float c788595e2708a7200d45ff8e0f4e47e1b;

		[CompilerGenerated]
		private float c661bb2f9e9ea52d64e131494c08d36ba;

		[CompilerGenerated]
		private float c285448ea3b296a59d7c002b98113701d;

		[CompilerGenerated]
		private float cd70ef7b23c19beb2930b442d4aa3216e;

		[CompilerGenerated]
		private bool ca5102e0600344ae531375b726f7d54df;

		[CompilerGenerated]
		private int c0644ddd67b72233cfead01a724ede0ac;

		[CompilerGenerated]
		private AttackSubType[] c8d1af313b26a626f786d483aa767eaf0;

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

		[DefaultValue(typeof(float), "2")]
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

		[DefaultValue(typeof(float), "3")]
		public float m_meleeAttackIdleTimeMin
		{
			[CompilerGenerated]
			get
			{
				return c285448ea3b296a59d7c002b98113701d;
			}
			[CompilerGenerated]
			set
			{
				c285448ea3b296a59d7c002b98113701d = value;
			}
		}

		public float m_meleeAttackIdleTimeMax
		{
			[CompilerGenerated]
			get
			{
				return cd70ef7b23c19beb2930b442d4aa3216e;
			}
			[CompilerGenerated]
			set
			{
				cd70ef7b23c19beb2930b442d4aa3216e = value;
			}
		}

		[XmlIgnore]
		public bool m_meleeAttackIdleTimeMaxSpecified
		{
			[CompilerGenerated]
			get
			{
				return ca5102e0600344ae531375b726f7d54df;
			}
			[CompilerGenerated]
			set
			{
				ca5102e0600344ae531375b726f7d54df = value;
			}
		}

		[DefaultValue(20)]
		public int m_attackDamage
		{
			[CompilerGenerated]
			get
			{
				return c0644ddd67b72233cfead01a724ede0ac;
			}
			[CompilerGenerated]
			set
			{
				c0644ddd67b72233cfead01a724ede0ac = value;
			}
		}

		[XmlArrayItem("m_attackSubType", IsNullable = false)]
		public AttackSubType[] m_attackSubTypeList
		{
			[CompilerGenerated]
			get
			{
				return c8d1af313b26a626f786d483aa767eaf0;
			}
			[CompilerGenerated]
			set
			{
				c8d1af313b26a626f786d483aa767eaf0 = value;
			}
		}

		public BHVFlyMeleeAttackSettings()
		{
			m_meleeAttackDistanceMin = 0f;
			m_meleeAttackDistanceMax = 2f;
			m_meleeAttackIdleTimeMin = 3f;
			m_attackDamage = 20;
		}
	}
}
