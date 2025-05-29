namespace XsdSettings
{
	public class RaretyAdjustValue
	{
		public WeaponRarity m_rarety { get; set; }

		public float m_adjustValue { get; set; }

		public RaretyAdjustValue()
		{
			m_rarety = WeaponRarity.Common;
			m_adjustValue = 0f;
		}
	}
}
