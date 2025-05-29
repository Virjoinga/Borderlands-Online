using UnityEngine;

public struct ImpactContext
{
	public enum ImpactType
	{
		Terrain = 0,
		Entity = 1
	}

	public ImpactType m_impactType;

	public float m_resolutionTime;

	public GameObject m_affectedObject;

	public AttackInfo.ElementalType m_elementalType;

	public Vector3 m_position;

	public Vector3 m_forward;

	public Vector3 m_normal;

	public Entity m_victim;

	public DamageInfo m_damageInfo;
}
