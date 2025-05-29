using System.Xml.Serialization;

namespace XsdSettings
{
	public class Looting
	{
		private ELootingType m_lootingTypeField;

		private LootingSubType[] m_lootingSubTypeListField;

		public ELootingType m_lootingType { get; set; }

		[XmlArrayItem("m_lootingSubType", IsNullable = false)]
		public LootingSubType[] m_lootingSubTypeList { get; set; }
	}
}
