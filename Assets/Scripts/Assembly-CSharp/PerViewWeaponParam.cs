using System;

[Serializable]
public class PerViewWeaponParam : ICloneable
{
	public float m_AccuracyMin;

	public float m_AccuracyMax;

	public float m_AccuracyDecrease;

	public float m_AccuracyRegenerationRateActive;

	public float m_AccuracyRegenerationRateOnIdle;

	public float m_rotationTime;

	public float m_switchViewTime;

	public float m_InnerAccuracyMin;

	public float m_InnerAccuracyMax;

	public float m_InnerAccuracyDecrease;

	public float m_InnerAccuracyRegenerationRateActive;

	public float m_InnerAccuracyRatio;

	public float m_InnerAccuracy;

	public float m_recoverTime = 0.2f;

	public object Clone()
	{
		return (PerViewWeaponParam)MemberwiseClone();
	}
}
