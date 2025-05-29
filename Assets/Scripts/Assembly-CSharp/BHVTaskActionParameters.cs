using UnityEngine;
using XsdSettings;

public sealed class BHVTaskActionParameters
{
	public int m_targetEntity;

	public int m_meleeDamageAmount;

	public int m_areaDamageAmount;

	public int m_spitDamageAmount;

	public int m_chargeDamageAmount;

	public float m_areaDamageRange;

	public float m_spitDamageRange;

	public float m_ChargeDamageRange;

	public AttackSubType m_attackSubType;

	public Vector3 m_fireDirection;

	public Vector3 m_spitPosition;

	public Vector3 m_chargePosition;

	public Vector3 m_vAreaDamageCenter;

	public bool m_bIgnoreAngle;
}
