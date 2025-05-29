using UnityEngine;

public class ClusterCondition_ClusterCompletion : ClusterCondition
{
	public Scene m_cluster;

	public override object Clone()
	{
		ClusterCondition_ClusterCompletion clusterCondition_ClusterCompletion = ScriptableObject.CreateInstance(GetType()) as ClusterCondition_ClusterCompletion;
		clusterCondition_ClusterCompletion.m_cluster = m_cluster;
		clusterCondition_ClusterCompletion.m_ownerCluster = m_ownerCluster;
		clusterCondition_ClusterCompletion.m_isValid = m_isValid;
		return clusterCondition_ClusterCompletion;
	}
}
