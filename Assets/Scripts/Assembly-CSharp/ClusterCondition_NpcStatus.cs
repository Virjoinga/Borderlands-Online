using UnityEngine;

public class ClusterCondition_NpcStatus : ClusterCondition
{
	public EntityNpc.EntitySubType m_npcType;

	public string m_aiState = string.Empty;

	public bool m_checkPhase;

	public bool m_checkState = true;

	public int m_phase;

	public override object Clone()
	{
		ClusterCondition_NpcStatus clusterCondition_NpcStatus = ScriptableObject.CreateInstance(GetType()) as ClusterCondition_NpcStatus;
		clusterCondition_NpcStatus.m_npcType = m_npcType;
		clusterCondition_NpcStatus.m_aiState = m_aiState;
		clusterCondition_NpcStatus.m_checkPhase = m_checkPhase;
		clusterCondition_NpcStatus.m_checkState = m_checkState;
		clusterCondition_NpcStatus.m_phase = m_phase;
		clusterCondition_NpcStatus.m_ownerCluster = m_ownerCluster;
		clusterCondition_NpcStatus.m_isValid = m_isValid;
		return clusterCondition_NpcStatus;
	}
}
