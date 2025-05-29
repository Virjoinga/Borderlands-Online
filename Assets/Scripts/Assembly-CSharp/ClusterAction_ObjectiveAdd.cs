using UnityEngine;

public class ClusterAction_ObjectiveAdd : ClusterAction
{
	public string m_objectiveId;

	public string m_titleId;

	public string m_detailId;

	public override object Clone()
	{
		ClusterAction_ObjectiveAdd clusterAction_ObjectiveAdd = ScriptableObject.CreateInstance(GetType()) as ClusterAction_ObjectiveAdd;
		clusterAction_ObjectiveAdd.m_objectiveId = m_objectiveId;
		clusterAction_ObjectiveAdd.m_titleId = m_titleId;
		clusterAction_ObjectiveAdd.m_detailId = m_detailId;
		clusterAction_ObjectiveAdd.m_executionOrder = m_executionOrder;
		return clusterAction_ObjectiveAdd;
	}
}
