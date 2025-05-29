using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsDetection : BHVPropertySettings
	{
		[CompilerGenerated]
		private float cf29f9f6fb807d05d5880aedf6e6e11f3;

		[CompilerGenerated]
		private float cb4a17930f30710cc4c9c351022ae99cc;

		[CompilerGenerated]
		private float c784a42b0789ee0eda956d3ea41cf33fc;

		[CompilerGenerated]
		private float ca1689bb285a6ce9177cdcaa7a7333ee3;

		[CompilerGenerated]
		private float c1708daa8e823cf86f51340c96c2a80b7;

		[DefaultValue(typeof(float), "0")]
		public float m_visualDetectionRange
		{
			[CompilerGenerated]
			get
			{
				return cf29f9f6fb807d05d5880aedf6e6e11f3;
			}
			[CompilerGenerated]
			set
			{
				cf29f9f6fb807d05d5880aedf6e6e11f3 = value;
			}
		}

		[DefaultValue(typeof(float), "0")]
		public float m_visualDetectionAngle
		{
			[CompilerGenerated]
			get
			{
				return cb4a17930f30710cc4c9c351022ae99cc;
			}
			[CompilerGenerated]
			set
			{
				cb4a17930f30710cc4c9c351022ae99cc = value;
			}
		}

		[DefaultValue(typeof(float), "0")]
		public float m_auditionDetectionRange
		{
			[CompilerGenerated]
			get
			{
				return c784a42b0789ee0eda956d3ea41cf33fc;
			}
			[CompilerGenerated]
			set
			{
				c784a42b0789ee0eda956d3ea41cf33fc = value;
			}
		}

		[DefaultValue(typeof(float), "0.9")]
		public float m_shootAtAngle
		{
			[CompilerGenerated]
			get
			{
				return ca1689bb285a6ce9177cdcaa7a7333ee3;
			}
			[CompilerGenerated]
			set
			{
				ca1689bb285a6ce9177cdcaa7a7333ee3 = value;
			}
		}

		[DefaultValue(typeof(float), "30")]
		public float m_shootDistance
		{
			[CompilerGenerated]
			get
			{
				return c1708daa8e823cf86f51340c96c2a80b7;
			}
			[CompilerGenerated]
			set
			{
				c1708daa8e823cf86f51340c96c2a80b7 = value;
			}
		}

		public BHVFSMSettingsDetection()
		{
			m_visualDetectionRange = 0f;
			m_visualDetectionAngle = 0f;
			m_auditionDetectionRange = 0f;
			m_shootAtAngle = 0.9f;
			m_shootDistance = 30f;
		}
	}
}
