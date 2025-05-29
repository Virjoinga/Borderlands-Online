using System.Xml.Serialization;

namespace XsdSettings
{
	public class ClassModeRaritySetup
	{
		private ClassModeRarityConfig[] m_classModeRaritiesField;

		[XmlArrayItem("m_classModeRarity", IsNullable = false)]
		public ClassModeRarityConfig[] m_classModeRarities { get; set; }
	}
}
