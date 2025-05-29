using System;

[Serializable]
public class ElementalDamageSettings
{
	public AttackInfo.ElementalType m_elemental;

	public float m_effectDuration;

	public float m_baseProcRatio;

	public float m_damageValueRatio;

	public float m_damageCoefFlesh;

	public float m_damageCoefShield;

	public float m_damageCoefArmor;
}
