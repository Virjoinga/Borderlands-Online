using System;

[Serializable]
public class TensityControlElement
{
	public TensityState m_state;

	public string m_event;

	public TensityStateChangeEventPackage[] m_eventPackages;
}
