using UnityEngine;

public class ClusterAction_SetPlayerActions : ClusterAction
{
	public int m_actions;

	public override object Clone()
	{
		ClusterAction_SetPlayerActions clusterAction_SetPlayerActions = ScriptableObject.CreateInstance(GetType()) as ClusterAction_SetPlayerActions;
		clusterAction_SetPlayerActions.m_actions = m_actions;
		clusterAction_SetPlayerActions.m_executionOrder = m_executionOrder;
		return clusterAction_SetPlayerActions;
	}
}
