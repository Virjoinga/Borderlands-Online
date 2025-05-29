using System.Xml.Serialization;

namespace XsdSettings
{
	public class LootGroups
	{
		private LootGroup[] m_lootGroupListField;

		public string m_name { get; set; }

		[XmlArrayItem("m_lootGroup", IsNullable = false)]
		public LootGroup[] m_lootGroupList { get; set; }
	}
}
