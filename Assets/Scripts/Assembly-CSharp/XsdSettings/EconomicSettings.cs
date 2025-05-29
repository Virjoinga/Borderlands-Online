using System.Xml.Serialization;

namespace XsdSettings
{
	public class EconomicSettings
	{
		private ItemPriceSetting[] m_priceSettingsField;

		[XmlArrayItem("m_itemPriceSetting", IsNullable = false)]
		public ItemPriceSetting[] m_priceSettings { get; set; }
	}
}
