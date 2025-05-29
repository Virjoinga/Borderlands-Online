using UnityEngine;

public class ClusterCondition_LevelTrigger : ClusterCondition
{
	public LevelTrigger m_trigger;

	public override object Clone()
	{
		ClusterCondition_LevelTrigger clusterCondition_LevelTrigger = ScriptableObject.CreateInstance(GetType()) as ClusterCondition_LevelTrigger;
		clusterCondition_LevelTrigger.m_trigger = m_trigger;
		clusterCondition_LevelTrigger.m_ownerCluster = m_ownerCluster;
		clusterCondition_LevelTrigger.m_isValid = m_isValid;
		return clusterCondition_LevelTrigger;
	}
}
