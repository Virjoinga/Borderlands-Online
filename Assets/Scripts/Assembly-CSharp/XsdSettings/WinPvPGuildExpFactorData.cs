using System.Xml.Serialization;

namespace XsdSettings
{
	public class WinPvPGuildExpFactorData
	{
		private RankPvPGuildExpFactorData[] m_rankFactorsField;

		[XmlArrayItem("m_expRank", IsNullable = false)]
		public RankPvPGuildExpFactorData[] m_rankFactors { get; set; }

		public int m_basicExpValue { get; set; }
	}
}
