namespace XsdSettings
{
	public class NPCLevelMultipliers
	{
		public int m_levelID { get; set; }

		public float m_HPMultiplier { get; set; }

		public float m_shieldPointsMultiplier { get; set; }

		public float m_damageMeleeMultiplier { get; set; }

		public float m_damageRangeMultiplier { get; set; }

		public float m_expRewardMultiplier { get; set; }

		public NPCLevelMultipliers()
		{
			m_levelID = 1;
			m_HPMultiplier = 1f;
			m_shieldPointsMultiplier = 1f;
			m_damageMeleeMultiplier = 1f;
			m_damageRangeMultiplier = 1f;
			m_expRewardMultiplier = 1f;
		}
	}
}
