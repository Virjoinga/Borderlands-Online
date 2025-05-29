using System;

[Serializable]
public class TensityStateChangeEventPackage
{
	public TensityState m_targetState;

	public float m_lastingTime;

	public TensityState m_autoTurnToState;
}
