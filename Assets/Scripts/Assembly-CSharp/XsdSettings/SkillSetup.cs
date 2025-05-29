using System.Xml.Serialization;

namespace XsdSettings
{
	public class SkillSetup
	{
		private Skill[] m_skillsField;

		[XmlArrayItem("m_skill", IsNullable = false)]
		public Skill[] m_skills { get; set; }
	}
}
