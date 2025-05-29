using System.Xml.Serialization;

namespace XsdSettings
{
	public class PvEGuildExpFactorDataList
	{
		private PlaytimePvEGuildExpFactorData[] m_playtimeFactorsField;

		private ScorePvEGuildExpFactorData[] m_scoreFactorsField;

		private DifficultyPvEGuildExpFactorData[] m_difficultyFactorsField;

		[XmlArrayItem("m_expPlaytime", IsNullable = false)]
		public PlaytimePvEGuildExpFactorData[] m_playtimeFactors { get; set; }

		[XmlArrayItem("m_expScore", IsNullable = false)]
		public ScorePvEGuildExpFactorData[] m_scoreFactors { get; set; }

		[XmlArrayItem("m_expDifficulty", IsNullable = false)]
		public DifficultyPvEGuildExpFactorData[] m_difficultyFactors { get; set; }
	}
}
