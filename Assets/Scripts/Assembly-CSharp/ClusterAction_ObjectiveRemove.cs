using UnityEngine;

public class ClusterAction_ObjectiveRemove : ClusterAction
{
	public string m_objectiveId;

	public bool m_isSuccess;

	public override object Clone()
	{
		ClusterAction_ObjectiveRemove clusterAction_ObjectiveRemove = ScriptableObject.CreateInstance(GetType()) as ClusterAction_ObjectiveRemove;
		clusterAction_ObjectiveRemove.m_objectiveId = m_objectiveId;
		clusterAction_ObjectiveRemove.m_executionOrder = m_executionOrder;
		return clusterAction_ObjectiveRemove;
	}
}
