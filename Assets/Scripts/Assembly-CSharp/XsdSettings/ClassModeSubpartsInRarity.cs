using System.Xml.Serialization;

namespace XsdSettings
{
	public class ClassModeSubpartsInRarity
	{
		private ClassModeSubPart m_classModeSubpartField;

		private ClassModeSubpartChoice[] m_subpartChoicesField;

		public ClassModeSubPart m_classModeSubpart { get; set; }

		[XmlArrayItem("m_subpartChoice", IsNullable = false)]
		public ClassModeSubpartChoice[] m_subpartChoices { get; set; }
	}
}
