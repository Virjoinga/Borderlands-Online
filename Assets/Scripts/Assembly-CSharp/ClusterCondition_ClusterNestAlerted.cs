using UnityEngine;

public class ClusterCondition_ClusterNestAlerted : ClusterCondition
{
	public Cluster m_nest;

	public override object Clone()
	{
		ClusterCondition_ClusterNestAlerted clusterCondition_ClusterNestAlerted = ScriptableObject.CreateInstance(GetType()) as ClusterCondition_ClusterNestAlerted;
		clusterCondition_ClusterNestAlerted.m_nest = m_nest;
		clusterCondition_ClusterNestAlerted.m_ownerCluster = m_ownerCluster;
		clusterCondition_ClusterNestAlerted.m_isValid = m_isValid;
		return clusterCondition_ClusterNestAlerted;
	}
}
