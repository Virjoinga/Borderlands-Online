using System.Xml.Serialization;

namespace XsdSettings
{
	public class SkillTreeSetup
	{
		private SkillTree[] m_treesField;

		[XmlArrayItem("m_tree", IsNullable = false)]
		public SkillTree[] m_trees { get; set; }
	}
}
