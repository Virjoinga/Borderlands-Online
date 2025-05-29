using System.Xml.Serialization;

namespace XsdSettings
{
	public class NodeGroup
	{
		private SkillNode[] m_nodeListField;

		public int m_id { get; set; }

		[XmlArrayItem("m_node", IsNullable = false)]
		public SkillNode[] m_nodeList { get; set; }
	}
}
