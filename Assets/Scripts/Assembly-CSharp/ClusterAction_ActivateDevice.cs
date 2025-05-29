using UnityEngine;

public class ClusterAction_ActivateDevice : ClusterAction
{
	public GameObject m_device;

	public override object Clone()
	{
		ClusterAction_ActivateDevice clusterAction_ActivateDevice = ScriptableObject.CreateInstance(GetType()) as ClusterAction_ActivateDevice;
		clusterAction_ActivateDevice.m_device = m_device;
		clusterAction_ActivateDevice.m_executionOrder = m_executionOrder;
		return clusterAction_ActivateDevice;
	}
}
