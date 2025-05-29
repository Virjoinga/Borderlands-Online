namespace XsdSettings
{
	public class DefaultLootQuantity
	{
		private ItemType m_lootTypeField;

		public ItemType m_lootType { get; set; }

		public int m_lootDefaultQuantity { get; set; }

		public MaterialType m_materialType { get; set; }

		public AmmoType m_ammoType { get; set; }

		public DefaultLootQuantity()
		{
			m_lootDefaultQuantity = 1;
			m_materialType = MaterialType.TOTAL;
			m_ammoType = AmmoType.TOTAL;
		}
	}
}
