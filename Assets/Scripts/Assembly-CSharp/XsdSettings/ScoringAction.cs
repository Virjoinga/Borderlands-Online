namespace XsdSettings
{
	public class ScoringAction
	{
		public ScoringActionType m_scoringActionType { get; set; }

		public int m_value { get; set; }

		public MedalType m_medalType { get; set; }

		public ScoringAction()
		{
			m_scoringActionType = ScoringActionType.BasicKill;
			m_value = 0;
			m_medalType = MedalType.None;
		}
	}
}
