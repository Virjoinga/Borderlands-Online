using System.Xml.Serialization;

namespace XsdSettings
{
	public class SkillTreeTier
	{
		private NodeGroup[] m_nodeGroupListField;

		public int m_id { get; set; }

		public int m_pointToUnlockNextTier { get; set; }

		[XmlArrayItem("m_nodeGroup", IsNullable = false)]
		public NodeGroup[] m_nodeGroupList { get; set; }
	}
}
