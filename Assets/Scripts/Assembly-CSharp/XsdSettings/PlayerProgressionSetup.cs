using System.Xml.Serialization;

namespace XsdSettings
{
	public class PlayerProgressionSetup
	{
		private ProgressionData[] m_experienceTableField;

		private DefaultAttributeData m_defaultAttributeField;

		[XmlArrayItem("m_level", IsNullable = false)]
		public ProgressionData[] m_experienceTable { get; set; }

		public DefaultAttributeData m_defaultAttribute { get; set; }
	}
}
