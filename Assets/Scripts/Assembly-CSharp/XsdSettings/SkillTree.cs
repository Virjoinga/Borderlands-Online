using System.Xml.Serialization;

namespace XsdSettings
{
	public class SkillTree
	{
		private AvatarType m_avatarTypeField;

		private SkillTreeTier[] m_tierListField;

		public AvatarType m_avatarType { get; set; }

		[XmlArrayItem("m_tier", typeof(SkillTreeTier), IsNullable = false)]
		public SkillTreeTier[] m_tierList { get; set; }

		[XmlArrayItem("m_name", IsNullable = false)]
		public string[] m_groupNameList { get; set; }
	}
}
