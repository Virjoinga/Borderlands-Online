namespace XsdSettings
{
	public class GuildSkillData
	{
		public int m_id { get; set; }

		public int m_unlockLevel { get; set; }

		public string m_type { get; set; }

		public float m_value { get; set; }

		public GuildSkillData()
		{
			m_id = 0;
			m_unlockLevel = 1;
			m_type = "scale";
			m_value = 0f;
		}
	}
}
