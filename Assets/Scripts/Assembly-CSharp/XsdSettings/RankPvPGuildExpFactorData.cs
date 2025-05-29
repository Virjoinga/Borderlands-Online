namespace XsdSettings
{
	public class RankPvPGuildExpFactorData
	{
		public int m_rankNumber { get; set; }

		public int m_minPlayer { get; set; }

		public int m_expValue { get; set; }

		public RankPvPGuildExpFactorData()
		{
			m_rankNumber = 0;
			m_minPlayer = 1;
			m_expValue = 0;
		}
	}
}
