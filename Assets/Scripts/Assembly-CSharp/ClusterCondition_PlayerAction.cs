using UnityEngine;

public class ClusterCondition_PlayerAction : ClusterCondition
{
	private PlayerAction m_action = PlayerAction.Aim;

	public override object Clone()
	{
		ClusterCondition_PlayerAction clusterCondition_PlayerAction = ScriptableObject.CreateInstance(GetType()) as ClusterCondition_PlayerAction;
		clusterCondition_PlayerAction.m_action = m_action;
		clusterCondition_PlayerAction.m_ownerCluster = m_ownerCluster;
		clusterCondition_PlayerAction.m_isValid = m_isValid;
		return clusterCondition_PlayerAction;
	}
}
