using UnityEngine;

public class ClusterAction_HideNpc : ClusterAction
{
	public bool m_bHide = true;

	public override object Clone()
	{
		ClusterAction_HideNpc clusterAction_HideNpc = ScriptableObject.CreateInstance(GetType()) as ClusterAction_HideNpc;
		clusterAction_HideNpc.m_bHide = m_bHide;
		clusterAction_HideNpc.m_executionOrder = m_executionOrder;
		return clusterAction_HideNpc;
	}
}
