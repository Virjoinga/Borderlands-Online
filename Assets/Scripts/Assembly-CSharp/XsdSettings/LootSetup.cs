using System.Xml.Serialization;

namespace XsdSettings
{
	public class LootSetup
	{
		private DefaultLootQuantity[] m_lootDefaultQuantityListField;

		private Looting[] m_lootingListField;

		public float m_lootLifetime { get; set; }

		public float m_lootDropFromNpcForce { get; set; }

		[XmlArrayItem("m_lootDefaultQuantity", IsNullable = false)]
		public DefaultLootQuantity[] m_lootDefaultQuantityList { get; set; }

		[XmlArrayItem("m_looting", IsNullable = false)]
		public Looting[] m_lootingList { get; set; }

		public LootSetup()
		{
			m_lootLifetime = 5f;
			m_lootDropFromNpcForce = 1f;
		}
	}
}
