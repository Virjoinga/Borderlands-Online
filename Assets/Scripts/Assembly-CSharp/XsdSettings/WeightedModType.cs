namespace XsdSettings
{
	public class WeightedModType
	{
		public AvatarType m_modType { get; set; }

		public float m_weight { get; set; }

		public WeightedModType()
		{
			m_modType = AvatarType.SIREN;
			m_weight = 1f;
		}
	}
}
