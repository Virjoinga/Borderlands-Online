using XsdSettings;

public struct DamageInfo
{
	public AttackSubType m_attackSubType;

	public AttackInfo.ElementalType m_elementalType;

	public int m_from;

	public int m_healthDamagePoints;

	public int m_shieldDamagePoints;

	public float m_force;

	public int m_weakPointIndex;

	public bool m_isTriggeringDamageOverTime;

	public bool m_isLethal;
}
