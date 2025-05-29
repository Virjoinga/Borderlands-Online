using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace BHV_Anim
{
	public class BHVAnimationManagerSetup
	{
		private BHVAnimationManagerSettings c305aaef8d56d5b1f02fda09469963853;

		[CompilerGenerated]
		private BHVAnimationManagerSettings c060f3f139026189a4d6cac9b07b0f03e;

		[CompilerGenerated]
		private string[] c743431e2625354a67c9140963a2c8ddc;

		[CompilerGenerated]
		private string[] c93b800b72a459c3f024bbf3501b2cbcb;

		public BHVAnimationManagerSettings m_settings
		{
			[CompilerGenerated]
			get
			{
				return c060f3f139026189a4d6cac9b07b0f03e;
			}
			[CompilerGenerated]
			set
			{
				c060f3f139026189a4d6cac9b07b0f03e = value;
			}
		}

		[XmlArrayItem("m_stateName", IsNullable = false)]
		public string[] m_animationStateList
		{
			[CompilerGenerated]
			get
			{
				return c743431e2625354a67c9140963a2c8ddc;
			}
			[CompilerGenerated]
			set
			{
				c743431e2625354a67c9140963a2c8ddc = value;
			}
		}

		[XmlArrayItem("m_stateName", IsNullable = false)]
		public string[] m_animationUpperBodyStateList
		{
			[CompilerGenerated]
			get
			{
				return c93b800b72a459c3f024bbf3501b2cbcb;
			}
			[CompilerGenerated]
			set
			{
				c93b800b72a459c3f024bbf3501b2cbcb = value;
			}
		}
	}
}
