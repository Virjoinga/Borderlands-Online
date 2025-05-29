using System.Xml.Serialization;

namespace XsdSettings
{
	public class ItemAvailabilitySettings
	{
		private WeightedRarity[] m_rarityDistributionField;

		private WeightedWeaponType[] m_weaponDistributionField;

		private WeightedModType[] m_modDistributionField;

		public ItemType m_itemType { get; set; }

		[XmlArrayItem("m_weightedRarity", IsNullable = false)]
		public WeightedRarity[] m_rarityDistribution { get; set; }

		[XmlArrayItem("m_weightedWeaponType", IsNullable = false)]
		public WeightedWeaponType[] m_weaponDistribution { get; set; }

		[XmlArrayItem("m_weightedModType", IsNullable = false)]
		public WeightedModType[] m_modDistribution { get; set; }

		public ItemAvailabilitySettings()
		{
			m_itemType = ItemType.Weapon;
		}
	}
}
