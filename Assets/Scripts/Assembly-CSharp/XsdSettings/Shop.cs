using System.Xml.Serialization;

namespace XsdSettings
{
	public class Shop
	{
		private ItemAvailabilitySettings[] m_itemAvailabilitySettingsListField;

		public int m_id { get; set; }

		public int m_refreshTime { get; set; }

		[XmlArrayItem("m_itemAvailabilitySettings", IsNullable = false)]
		public ItemAvailabilitySettings[] m_itemAvailabilitySettingsList { get; set; }

		public Shop()
		{
			m_id = 0;
			m_refreshTime = 3600;
		}
	}
}
