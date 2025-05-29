using System.Xml.Serialization;

namespace XsdSettings
{
	public class WeaponCraftConfig
	{
		private WeaponType m_WeaponTypeField;

		private WeaponCraftCondition[] m_CraftConditionsField;

		private WeaponCraftRarity[] m_rarityListField;

		public int m_MinLevel { get; set; }

		public int m_MaxLevel { get; set; }

		public int m_Currency { get; set; }

		public WeaponType m_WeaponType { get; set; }

		[XmlArrayItem("m_CraftCondition", IsNullable = false)]
		public WeaponCraftCondition[] m_CraftConditions { get; set; }

		[XmlArrayItem("m_rarity", IsNullable = false)]
		public WeaponCraftRarity[] m_rarityList { get; set; }
	}
}
