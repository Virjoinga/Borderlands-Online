using XsdSettings;

public class ShieldAttributeConfig
{
	public float m_attrValue;

	public ShieldAttributeType m_attrType;

	public static float s_maxShieldPoint = 100f;

	public static float s_regenerationCD = 5f;

	public static float s_regenRatePercent = 0.2f;

	public ShieldAttributeConfig(ShieldAttributeType cdc8afd29b145cd41766452ed8ad942b9)
	{
		m_attrType = cdc8afd29b145cd41766452ed8ad942b9;
		switch (m_attrType)
		{
		case ShieldAttributeType.Capacity:
			m_attrValue = s_maxShieldPoint;
			break;
		case ShieldAttributeType.RechargeDelay:
			m_attrValue = s_regenerationCD;
			break;
		case ShieldAttributeType.RechargeRate:
			m_attrValue = s_regenRatePercent;
			break;
		case ShieldAttributeType.Manufacturer:
			m_attrValue = 0f;
			break;
		default:
			m_attrValue = 0f;
			break;
		}
	}
}
