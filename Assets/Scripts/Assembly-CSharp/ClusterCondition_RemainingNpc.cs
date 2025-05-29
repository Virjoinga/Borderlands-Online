using UnityEngine;

public class ClusterCondition_RemainingNpc : ClusterCondition
{
	public Cluster m_cluster;

	public int m_remainingNpc;

	public override object Clone()
	{
		ClusterCondition_RemainingNpc clusterCondition_RemainingNpc = ScriptableObject.CreateInstance(GetType()) as ClusterCondition_RemainingNpc;
		clusterCondition_RemainingNpc.m_cluster = m_cluster;
		clusterCondition_RemainingNpc.m_remainingNpc = m_remainingNpc;
		clusterCondition_RemainingNpc.m_ownerCluster = m_ownerCluster;
		clusterCondition_RemainingNpc.m_isValid = m_isValid;
		return clusterCondition_RemainingNpc;
	}
}
