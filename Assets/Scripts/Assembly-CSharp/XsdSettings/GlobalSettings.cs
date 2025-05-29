namespace XsdSettings
{
	public class GlobalSettings
	{
		public float m_interactionDistance { get; set; }

		public float m_visualInteractionDistance { get; set; }

		public float m_lootSpinningMoveSpeed { get; set; }

		public float m_lootSpinningRotateSpeed { get; set; }

		public float m_lootSpinningHeightOffset { get; set; }

		public GlobalSettings()
		{
			m_interactionDistance = 3f;
			m_visualInteractionDistance = 20f;
			m_lootSpinningMoveSpeed = 5f;
			m_lootSpinningRotateSpeed = 150f;
			m_lootSpinningHeightOffset = 1f;
		}
	}
}
