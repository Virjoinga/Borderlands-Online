namespace XsdSettings
{
	public class WeightedWeaponType
	{
		public WeaponType m_weaponType { get; set; }

		public float m_weight { get; set; }

		public WeightedWeaponType()
		{
			m_weaponType = WeaponType.SMG;
			m_weight = 1f;
		}
	}
}
