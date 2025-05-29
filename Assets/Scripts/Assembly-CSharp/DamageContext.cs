using XsdSettings;

public struct DamageContext
{
	public Entity m_killer;

	public Entity m_victim;

	public WeakPoint.StrengthType m_strengthType;

	public AttackSubType m_subType;

	public DamageInfo m_damageInfo;

	public bool m_isRemote;
}
