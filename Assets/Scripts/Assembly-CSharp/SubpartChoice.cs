using System;

public class SubpartChoice : ICloneable
{
	public int m_subpartIndex;

	public float m_probability = 100f;

	public ProbabilityModifier m_modifier;

	public object Clone()
	{
		return MemberwiseClone();
	}
}
