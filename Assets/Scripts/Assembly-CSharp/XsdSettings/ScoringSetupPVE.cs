using System.Xml.Serialization;

namespace XsdSettings
{
	public class ScoringSetupPVE : ScoringBase
	{
		private PerformanceRankDifficulty[] m_performanceRankBonusField;

		private LevelAdjustmentData[] m_levelAdjustmentsField;

		[XmlArrayItem("m_performanceRank", IsNullable = false)]
		public PerformanceRankDifficulty[] m_performanceRankBonus { get; set; }

		[XmlArrayItem("m_levelAdjustment", IsNullable = false)]
		public LevelAdjustmentData[] m_levelAdjustments { get; set; }
	}
}
