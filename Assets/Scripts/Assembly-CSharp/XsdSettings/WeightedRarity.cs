namespace XsdSettings
{
	public class WeightedRarity
	{
		public WeaponRarity m_rarity { get; set; }

		public float m_weight { get; set; }

		public WeightedRarity()
		{
			m_rarity = WeaponRarity.Common;
			m_weight = 1f;
		}
	}
}
