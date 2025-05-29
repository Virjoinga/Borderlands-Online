using System.Xml.Serialization;

namespace XsdSettings
{
	public class ClassModeRarityTypeConfig
	{
		private ItemRarity m_rarityField;

		private ClassModeSubpartsInRarity[] m_subpartsField;

		public ItemRarity m_rarity { get; set; }

		[XmlArrayItem("m_subpartsInRarity", IsNullable = false)]
		public ClassModeSubpartsInRarity[] m_subparts { get; set; }
	}
}
