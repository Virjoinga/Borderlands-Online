using UnityEngine;

public class ClusterCondition_ObjectsDamaged : ClusterCondition
{
	public GameObject m_object;

	public float m_damagePercent = 1f;

	public override object Clone()
	{
		ClusterCondition_ObjectsDamaged clusterCondition_ObjectsDamaged = ScriptableObject.CreateInstance(GetType()) as ClusterCondition_ObjectsDamaged;
		clusterCondition_ObjectsDamaged.m_object = m_object;
		clusterCondition_ObjectsDamaged.m_damagePercent = m_damagePercent;
		clusterCondition_ObjectsDamaged.m_ownerCluster = m_ownerCluster;
		clusterCondition_ObjectsDamaged.m_isValid = m_isValid;
		return clusterCondition_ObjectsDamaged;
	}
}
