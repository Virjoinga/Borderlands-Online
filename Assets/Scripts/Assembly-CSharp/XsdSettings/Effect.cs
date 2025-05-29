namespace XsdSettings
{
	public class Effect
	{
		public EffectType m_type { get; set; }

		public string m_attribute { get; set; }

		public string m_behavior { get; set; }

		public string m_operation { get; set; }

		public float m_firstGrade { get; set; }

		public float m_perGrade { get; set; }

		public float m_duration { get; set; }

		public Effect()
		{
			m_type = EffectType.Invalid;
		}
	}
}
