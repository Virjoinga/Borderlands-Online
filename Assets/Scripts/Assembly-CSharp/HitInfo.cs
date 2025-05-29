using UnityEngine;
using XsdSettings;

public class HitInfo : Arbitrator.ArbitrableData
{
	public int m_from;

	public int m_to;

	public int m_owner;

	public sbyte m_weakPointIndex;

	public Vector3 m_rayOrigin;

	public Vector3 m_rayDirection;

	public float m_distance;

	public double m_timeStamp;

	public int m_damagePoint;

	public AttackSubType m_attackSubType;

	public AttackInfo.ElementalType m_elementalType;
}
