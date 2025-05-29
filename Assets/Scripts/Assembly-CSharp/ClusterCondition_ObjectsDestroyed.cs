using UnityEngine;

public class ClusterCondition_ObjectsDestroyed : ClusterCondition
{
	public GameObject m_object;

	public override object Clone()
	{
		ClusterCondition_ObjectsDestroyed clusterCondition_ObjectsDestroyed = ScriptableObject.CreateInstance(GetType()) as ClusterCondition_ObjectsDestroyed;
		clusterCondition_ObjectsDestroyed.m_object = m_object;
		clusterCondition_ObjectsDestroyed.m_ownerCluster = m_ownerCluster;
		clusterCondition_ObjectsDestroyed.m_isValid = m_isValid;
		return clusterCondition_ObjectsDestroyed;
	}
}
