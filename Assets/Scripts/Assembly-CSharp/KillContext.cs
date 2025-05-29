using XsdSettings;

public struct KillContext
{
	public Entity m_killer;

	public Entity m_victim;

	public WeakPoint.StrengthType m_strengthType;

	public WeakPoint.PartInfo m_partInfo;

	public AttackSubType m_subType;

	public AttackInfo.ElementalType m_elementalType;

	public float m_killDistance;

	public bool m_isRemote;
}
