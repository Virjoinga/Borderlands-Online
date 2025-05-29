using System.Xml.Serialization;

namespace XsdSettings
{
	public class GuidanceTipsSetup
	{
		private GuidanceTip[] m_tipsField;

		[XmlArrayItem("m_tip", IsNullable = false)]
		public GuidanceTip[] m_tips { get; set; }
	}
}
