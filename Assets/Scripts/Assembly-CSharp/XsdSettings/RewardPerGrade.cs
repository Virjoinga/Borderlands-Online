namespace XsdSettings
{
	public class RewardPerGrade
	{
		public InstanceGrade m_grade { get; set; }

		public LuckyBoxRank m_normalRank { get; set; }

		public string m_normalReward { get; set; }

		public LuckyBoxRank m_lockedRank { get; set; }

		public string m_lockedReward { get; set; }

		public RewardPerGrade()
		{
			m_grade = InstanceGrade.S;
			m_normalRank = LuckyBoxRank.Platinum;
			m_normalReward = "KimBox";
			m_lockedRank = LuckyBoxRank.Diamond;
			m_lockedReward = "KimBox";
		}
	}
}
