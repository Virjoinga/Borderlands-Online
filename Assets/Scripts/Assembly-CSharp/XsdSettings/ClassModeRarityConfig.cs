using System.Xml.Serialization;

namespace XsdSettings
{
	public class ClassModeRarityConfig
	{
		private ClassModeType m_classModeTypeField;

		private ClassModeRarityTypeConfig[] m_raritiyTypesField;

		public ClassModeType m_classModeType { get; set; }

		[XmlArrayItem("m_rarityType", IsNullable = false)]
		public ClassModeRarityTypeConfig[] m_raritiyTypes { get; set; }
	}
}
