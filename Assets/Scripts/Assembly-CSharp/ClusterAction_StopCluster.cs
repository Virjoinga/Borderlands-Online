using UnityEngine;

public class ClusterAction_StopCluster : ClusterAction
{
	public Cluster m_stopCluster;

	public override object Clone()
	{
		ClusterAction_StopCluster clusterAction_StopCluster = ScriptableObject.CreateInstance(GetType()) as ClusterAction_StopCluster;
		clusterAction_StopCluster.m_stopCluster = m_stopCluster;
		clusterAction_StopCluster.m_executionOrder = m_executionOrder;
		return clusterAction_StopCluster;
	}
}
