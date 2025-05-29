using System.Xml.Serialization;

namespace XsdSettings
{
	public class GuildProgression
	{
		private ExpProgressionData[] m_progressionTableField;

		private GuildSkillData[] m_guildSkillsField;

		private GuildExpFactorDataList m_guildExpFactorsField;

		[XmlArrayItem("m_level", IsNullable = false)]
		public ExpProgressionData[] m_progressionTable { get; set; }

		[XmlArrayItem("m_guildSkill", IsNullable = false)]
		public GuildSkillData[] m_guildSkills { get; set; }

		public GuildExpFactorDataList m_guildExpFactors { get; set; }

		public int m_guildSkillSelectStep { get; set; }
	}
}
