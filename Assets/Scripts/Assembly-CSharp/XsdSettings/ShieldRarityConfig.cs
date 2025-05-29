using System.Xml.Serialization;

namespace XsdSettings
{
	public class ShieldRarityConfig
	{
		private ShieldRarity m_rarityField;

		private ShieldSubpartsInRarity[] m_subpartsField;

		public ShieldRarity m_rarity { get; set; }

		[XmlArrayItem("m_subpartsInRarity", IsNullable = false)]
		public ShieldSubpartsInRarity[] m_subparts { get; set; }
	}
}
