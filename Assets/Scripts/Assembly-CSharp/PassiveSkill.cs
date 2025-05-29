using System;

[Serializable]
public class PassiveSkill
{
	public int m_probability;

	public PassiveSkillType m_passiveSkillType;

	public int m_skillID;

	public PassiveSkill()
	{
		m_probability = 0;
		m_passiveSkillType = PassiveSkillType.None;
		m_skillID = 0;
	}
}
