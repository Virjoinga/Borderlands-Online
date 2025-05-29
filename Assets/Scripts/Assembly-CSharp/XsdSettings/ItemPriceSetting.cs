using System.Xml.Serialization;

namespace XsdSettings
{
	public class ItemPriceSetting
	{
		private RaretyAdjustValue[] m_adjustementsField;

		public ItemType m_itemType { get; set; }

		public int m_basicValue { get; set; }

		[XmlArrayItem("m_raretyAdjustValue", IsNullable = false)]
		public RaretyAdjustValue[] m_adjustements { get; set; }

		public ItemPriceSetting()
		{
			m_itemType = ItemType.Weapon;
			m_basicValue = 0;
		}
	}
}
