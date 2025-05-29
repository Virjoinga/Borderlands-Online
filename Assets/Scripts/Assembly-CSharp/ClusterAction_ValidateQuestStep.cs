using UnityEngine;

public class ClusterAction_ValidateQuestStep : ClusterAction
{
	public int m_questId;

	public int m_stepId;

	public override object Clone()
	{
		ClusterAction_ValidateQuestStep clusterAction_ValidateQuestStep = ScriptableObject.CreateInstance(GetType()) as ClusterAction_ValidateQuestStep;
		clusterAction_ValidateQuestStep.m_questId = m_questId;
		clusterAction_ValidateQuestStep.m_stepId = m_stepId;
		clusterAction_ValidateQuestStep.m_executionOrder = m_executionOrder;
		return clusterAction_ValidateQuestStep;
	}
}
