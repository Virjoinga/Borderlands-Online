using System.Xml.Serialization;

namespace XsdSettings
{
	public class LootGroup
	{
		private Loot[] m_lootListField;

		public string m_name { get; set; }

		[XmlArrayItem("m_loot", IsNullable = false)]
		public Loot[] m_lootList { get; set; }
	}
}
