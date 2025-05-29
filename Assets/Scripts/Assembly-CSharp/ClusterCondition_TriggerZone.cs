using UnityEngine;

public class ClusterCondition_TriggerZone : ClusterCondition
{
	public enum TriggerCondition
	{
		OnePlayer = 0,
		AtLeastHalfPlayers = 1,
		AllPlayers = 2
	}

	public bool m_linkPlayersToThisClusterFlow;

	public TriggerCondition m_triggeringCondition;

	public override object Clone()
	{
		ClusterCondition_TriggerZone clusterCondition_TriggerZone = ScriptableObject.CreateInstance(GetType()) as ClusterCondition_TriggerZone;
		clusterCondition_TriggerZone.m_linkPlayersToThisClusterFlow = m_linkPlayersToThisClusterFlow;
		clusterCondition_TriggerZone.m_triggeringCondition = m_triggeringCondition;
		clusterCondition_TriggerZone.m_ownerCluster = m_ownerCluster;
		clusterCondition_TriggerZone.m_isValid = m_isValid;
		return clusterCondition_TriggerZone;
	}
}
