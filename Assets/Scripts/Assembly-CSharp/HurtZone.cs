using UnityEngine;

public class HurtZone : MonoBehaviour
{
	public AttackInfo.ElementalType m_elementalDamage;

	public float m_damageRatioPerSecond;

	public int m_fixedDamagePerSecond;

	public bool m_hurtPlayer = true;

	public bool m_hurtNpc;

	public bool m_hurtBoss;
}
