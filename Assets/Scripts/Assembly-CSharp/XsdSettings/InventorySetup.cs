using System.Xml.Serialization;

namespace XsdSettings
{
	public class InventorySetup
	{
		private AmmoSetup[] m_ammosField;

		private ItemSetup[] m_itemsField;

		public int m_startingInventorySlotsCount { get; set; }

		public int m_maxInventorySlotsCount { get; set; }

		public int m_weapon1 { get; set; }

		public int m_weapon2 { get; set; }

		public int m_weapon3 { get; set; }

		public int m_weapon4 { get; set; }

		public int m_shield { get; set; }

		public int m_classMod { get; set; }

		public int m_grenadeMod { get; set; }

		[XmlArrayItem("m_ammoSetup", IsNullable = false)]
		public AmmoSetup[] m_ammos { get; set; }

		[XmlArrayItem("m_itemSetup", IsNullable = false)]
		public ItemSetup[] m_items { get; set; }

		public InventorySetup()
		{
			m_weapon1 = -1;
			m_weapon2 = -1;
			m_weapon3 = -1;
			m_weapon4 = -1;
			m_shield = -1;
			m_classMod = -1;
			m_grenadeMod = -1;
		}
	}
}
