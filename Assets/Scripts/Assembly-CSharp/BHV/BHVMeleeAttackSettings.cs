using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using XsdSettings;

namespace BHV
{
	public class BHVMeleeAttackSettings : BHVTaskSettings
	{
		private AttackSubType[] c6ab5f92cda7d2ecf7901d7fb79c2b71a;

		[CompilerGenerated]
		private int c0644ddd67b72233cfead01a724ede0ac;

		[CompilerGenerated]
		private float c3bf4436b8b953f8ece740063ad74c613;

		[CompilerGenerated]
		private float cb9088e90498180b699e6d5095fa6acde;

		[CompilerGenerated]
		private float c034d59a3b63dc84ef11c4401a20d2c7e;

		[CompilerGenerated]
		private float cb13f939b4bd77911d45ddf73a368cee3;

		[CompilerGenerated]
		private AttackSubType[] c8d1af313b26a626f786d483aa767eaf0;

		[CompilerGenerated]
		private bool c7c56f189f0b2407e2b3bb4af3ba48f98;

		[CompilerGenerated]
		private bool c50cf06863d9488f88dfc206205c046e4;

		[DefaultValue(1)]
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

		[DefaultValue(typeof(float), "1")]
		public float m_attackDamageMultiplier
		{
			[CompilerGenerated]
			get
			{
				return c3bf4436b8b953f8ece740063ad74c613;
			}
			[CompilerGenerated]
			set
			{
				c3bf4436b8b953f8ece740063ad74c613 = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_playerAttackDamageMultiplier
		{
			[CompilerGenerated]
			get
			{
				return cb9088e90498180b699e6d5095fa6acde;
			}
			[CompilerGenerated]
			set
			{
				cb9088e90498180b699e6d5095fa6acde = value;
			}
		}

		[DefaultValue(typeof(float), "90")]
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
		public float m_attackRange
		{
			[CompilerGenerated]
			get
			{
				return cb13f939b4bd77911d45ddf73a368cee3;
			}
			[CompilerGenerated]
			set
			{
				cb13f939b4bd77911d45ddf73a368cee3 = value;
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

		[DefaultValue(false)]
		public bool m_canKnockBack
		{
			[CompilerGenerated]
			get
			{
				return c7c56f189f0b2407e2b3bb4af3ba48f98;
			}
			[CompilerGenerated]
			set
			{
				c7c56f189f0b2407e2b3bb4af3ba48f98 = value;
			}
		}

		[DefaultValue(false)]
		public bool m_canShakeCamera
		{
			[CompilerGenerated]
			get
			{
				return c50cf06863d9488f88dfc206205c046e4;
			}
			[CompilerGenerated]
			set
			{
				c50cf06863d9488f88dfc206205c046e4 = value;
			}
		}

		public BHVMeleeAttackSettings()
		{
			m_attackDamage = 1;
			m_attackDamageMultiplier = 1f;
			m_playerAttackDamageMultiplier = 1f;
			m_attackAngle = 90f;
			m_attackRange = 3f;
			m_canKnockBack = false;
			m_canShakeCamera = false;
		}
	}
}
