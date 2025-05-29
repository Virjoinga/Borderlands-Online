using System.Xml.Serialization;

namespace XsdSettings
{
	public class LootingSubType
	{
		private ELootingSubType m_lootingSubTypeField;

		private LootingLevelRange[] m_lootingLevelRangeListField;

		public ELootingSubType m_lootingSubType { get; set; }

		[XmlArrayItem("m_lootingLevelRange", typeof(LootingLevelRange), IsNullable = false)]
		public LootingLevelRange[] m_lootingLevelRangeList { get; set; }
	}
}
