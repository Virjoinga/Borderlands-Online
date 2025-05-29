using System.Xml.Serialization;

namespace XsdSettings
{
	[XmlInclude(typeof(ScoringSetupPVP))]
	[XmlInclude(typeof(ScoringSetupPVE))]
	public class ScoringBase : ScoringType
	{
		public float m_moneyStandardReward { get; set; }

		public float m_modeModifierEXP { get; set; }

		public float m_modeModifierSoftCurrency { get; set; }

		public float m_winBonusEXP { get; set; }

		public float m_winBonusSoftCurrency { get; set; }

		[XmlArrayItem("m_value", IsNullable = false)]
		public float[] m_moneyRewardRatePerLevel { get; set; }

		[XmlArrayItem("m_value", IsNullable = false)]
		public float[] m_expRewardRatePerLevel { get; set; }
	}
}
