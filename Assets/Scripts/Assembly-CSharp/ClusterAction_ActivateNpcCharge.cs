using UnityEngine;

public class ClusterAction_ActivateNpcCharge : ClusterAction
{
	public bool m_bActiveCharge = true;

	public GameObject m_teleportPoint;

	public override object Clone()
	{
		ClusterAction_ActivateNpcCharge clusterAction_ActivateNpcCharge = ScriptableObject.CreateInstance(GetType()) as ClusterAction_ActivateNpcCharge;
		clusterAction_ActivateNpcCharge.m_bActiveCharge = m_bActiveCharge;
		clusterAction_ActivateNpcCharge.m_teleportPoint = m_teleportPoint;
		clusterAction_ActivateNpcCharge.m_executionOrder = m_executionOrder;
		return clusterAction_ActivateNpcCharge;
	}
}
