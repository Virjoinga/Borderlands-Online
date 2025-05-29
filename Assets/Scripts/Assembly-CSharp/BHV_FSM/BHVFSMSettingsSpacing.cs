using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsSpacing : BHVPropertySettings
	{
		[CompilerGenerated]
		private float c414443e2dc69e5f5aa5a3267befd8f5b;

		[CompilerGenerated]
		private float c5d00ecc8cd2b1bd0201775b03bee7c19;

		[CompilerGenerated]
		private float c8744aa53599706ee5ef761a7a531d327;

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

		public BHVFSMSettingsSpacing()
		{
			m_spacingTime = 5f;
			m_spacingRangeMin = 10f;
			m_spacingRangeMax = 18f;
		}
	}
}
