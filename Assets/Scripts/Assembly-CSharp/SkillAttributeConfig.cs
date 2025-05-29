using XsdSettings;

public class SkillAttributeConfig
{
	public AffectType m_affectType;

	public float m_attrValue;

	public EffectType m_attrType;

	public bool m_bModified;

	public SkillAttributeConfig(EffectType cdc8afd29b145cd41766452ed8ad942b9)
	{
		m_attrType = cdc8afd29b145cd41766452ed8ad942b9;
		m_attrValue = 0f;
		m_affectType = AffectType.PostAdd;
		m_bModified = false;
	}
}
