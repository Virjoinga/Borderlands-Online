namespace XsdSettings
{
	public class BoxRank
	{
		public LuckyBoxRank m_rank { get; set; }

		public LuckyBoxRank m_keyRank { get; set; }

		public int m_keyCount { get; set; }

		public BoxRank()
		{
			m_rank = LuckyBoxRank.Platinum;
			m_keyRank = LuckyBoxRank.None;
			m_keyCount = 0;
		}
	}
}
