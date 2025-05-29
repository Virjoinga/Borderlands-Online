using System.Xml.Serialization;

namespace XsdSettings
{
	public class ScoringSetupPVP : ScoringBase
	{
		private PerformanceRankPVP[] m_performanceRankBonusField;

		private ScoringAction[] m_scoringActionsField;

		public int m_honorWinBonus { get; set; }

		public int m_honorStandardReward { get; set; }

		public float m_expStandardReward { get; set; }

		[XmlArrayItem("m_performanceRank", IsNullable = false)]
		public PerformanceRankPVP[] m_performanceRankBonus { get; set; }

		[XmlArrayItem("m_scoringAction", IsNullable = false)]
		public ScoringAction[] m_scoringActions { get; set; }
	}
}
