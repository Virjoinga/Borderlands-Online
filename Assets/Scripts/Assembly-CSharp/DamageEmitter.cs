using XsdSettings;

public struct DamageEmitter
{
	public int m_owner;

	public int m_receiver;

	public sbyte m_weakpointIndex;

	public AttackInfo.ElementalType m_elementalType;

	public AttackSubType m_attackSubType;

	public float m_damagePerSecond;

	public float m_frequency;

	public float m_duration;

	public float m_startDate;

	public int m_damageApplicationCounter;
}
