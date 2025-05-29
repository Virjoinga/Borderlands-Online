using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV
{
	public class BHVMortarAttackSettings : BHVTaskSettings
	{
		[CompilerGenerated]
		private int c572c47835abf74ae7f98a4252fec53eb;

		[CompilerGenerated]
		private int c0d6dc0fd033ab2bce38e7242c8ec0e7e;

		[CompilerGenerated]
		private float c3816454174d91b0113ba4d5d5babea35;

		[CompilerGenerated]
		private float c8ec92e4e131c91b903663a44f7f40968;

		[DefaultValue(30)]
		public int m_shellDamage
		{
			[CompilerGenerated]
			get
			{
				return c572c47835abf74ae7f98a4252fec53eb;
			}
			[CompilerGenerated]
			set
			{
				c572c47835abf74ae7f98a4252fec53eb = value;
			}
		}

		[DefaultValue(3)]
		public int m_shellAmount
		{
			[CompilerGenerated]
			get
			{
				return c0d6dc0fd033ab2bce38e7242c8ec0e7e;
			}
			[CompilerGenerated]
			set
			{
				c0d6dc0fd033ab2bce38e7242c8ec0e7e = value;
			}
		}

		[DefaultValue(typeof(float), "1.5")]
		public float m_shellDamageRadius
		{
			[CompilerGenerated]
			get
			{
				return c3816454174d91b0113ba4d5d5babea35;
			}
			[CompilerGenerated]
			set
			{
				c3816454174d91b0113ba4d5d5babea35 = value;
			}
		}

		[DefaultValue(typeof(float), "15")]
		public float m_shellFlyingSpeed
		{
			[CompilerGenerated]
			get
			{
				return c8ec92e4e131c91b903663a44f7f40968;
			}
			[CompilerGenerated]
			set
			{
				c8ec92e4e131c91b903663a44f7f40968 = value;
			}
		}

		public BHVMortarAttackSettings()
		{
			m_shellDamage = 30;
			m_shellAmount = 3;
			m_shellDamageRadius = 1.5f;
			m_shellFlyingSpeed = 15f;
		}
	}
}
