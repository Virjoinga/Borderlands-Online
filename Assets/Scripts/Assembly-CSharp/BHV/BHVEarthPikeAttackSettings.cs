using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV
{
	public class BHVEarthPikeAttackSettings : BHVTaskSettings
	{
		[CompilerGenerated]
		private int cda769c7d50f8ae8e5a3911a19fd9ee51;

		[CompilerGenerated]
		private int c373e7466631317396c8884132906cc1f;

		[CompilerGenerated]
		private float ce32e97e85ba08de4ddf4b6010f1f8f07;

		[CompilerGenerated]
		private float c5aedc2abe00813158083d6ae8595c97d;

		[DefaultValue(30)]
		public int m_pikeDamage
		{
			[CompilerGenerated]
			get
			{
				return cda769c7d50f8ae8e5a3911a19fd9ee51;
			}
			[CompilerGenerated]
			set
			{
				cda769c7d50f8ae8e5a3911a19fd9ee51 = value;
			}
		}

		[DefaultValue(3)]
		public int m_pikeAmount
		{
			[CompilerGenerated]
			get
			{
				return c373e7466631317396c8884132906cc1f;
			}
			[CompilerGenerated]
			set
			{
				c373e7466631317396c8884132906cc1f = value;
			}
		}

		[DefaultValue(typeof(float), "1.5")]
		public float m_pikeDamageRadius
		{
			[CompilerGenerated]
			get
			{
				return ce32e97e85ba08de4ddf4b6010f1f8f07;
			}
			[CompilerGenerated]
			set
			{
				ce32e97e85ba08de4ddf4b6010f1f8f07 = value;
			}
		}

		[DefaultValue(typeof(float), "1.5")]
		public float m_distanceToPlayer
		{
			[CompilerGenerated]
			get
			{
				return c5aedc2abe00813158083d6ae8595c97d;
			}
			[CompilerGenerated]
			set
			{
				c5aedc2abe00813158083d6ae8595c97d = value;
			}
		}

		public BHVEarthPikeAttackSettings()
		{
			m_pikeDamage = 30;
			m_pikeAmount = 3;
			m_pikeDamageRadius = 1.5f;
			m_distanceToPlayer = 1.5f;
		}
	}
}
