namespace XsdSettings
{
	public class ProgressionData
	{
		public int m_requiredXp { get; set; }

		public int m_skillPointGain { get; set; }

		public float m_powerRating { get; set; }

		public ProgressionData()
		{
			m_requiredXp = 0;
			m_skillPointGain = 0;
			m_powerRating = 0f;
		}
	}
}
