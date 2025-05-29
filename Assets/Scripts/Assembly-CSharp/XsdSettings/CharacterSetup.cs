using System.Xml.Serialization;

namespace XsdSettings
{
	public class CharacterSetup
	{
		private InventorySetup m_inventorySetupField;

		private AvatarType m_avatarTypeField;

		public InventorySetup m_inventorySetup { get; set; }

		[XmlArrayItem("m_id", IsNullable = false)]
		public int[] m_quests { get; set; }

		[XmlArrayItem("m_id", IsNullable = false)]
		public int[] m_instances { get; set; }

		public AvatarType m_avatarType { get; set; }
	}
}
