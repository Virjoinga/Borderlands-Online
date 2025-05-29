using UnityEngine;

public class ClusterAction_KillAllNpcs : ClusterAction
{
	public Cluster m_cluster;

	public override object Clone()
	{
		ClusterAction_KillAllNpcs clusterAction_KillAllNpcs = ScriptableObject.CreateInstance(GetType()) as ClusterAction_KillAllNpcs;
		clusterAction_KillAllNpcs.m_cluster = m_cluster;
		clusterAction_KillAllNpcs.m_executionOrder = m_executionOrder;
		return clusterAction_KillAllNpcs;
	}
}
