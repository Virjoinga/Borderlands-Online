using System;

[Serializable]
public class ParticleInfo
{
	public float m_delay;

	public ENPCParticleType m_particleToPlay;

	public float m_duration = 1f;

	public bool m_alreadyPlayed;

	public bool m_hideDefaultTransformWhenPlay;
}
