using Core;
using UnityEngine;

public class ClusterAction_TutorialLesson : ClusterAction
{
	public UIMessage m_message = new UIMessage();

	public GameObject m_lessonTargetObject;

	public override object Clone()
	{
		ClusterAction_TutorialLesson clusterAction_TutorialLesson = ScriptableObject.CreateInstance(GetType()) as ClusterAction_TutorialLesson;
		clusterAction_TutorialLesson.m_message = m_message;
		clusterAction_TutorialLesson.m_lessonTargetObject = m_lessonTargetObject;
		clusterAction_TutorialLesson.m_executionOrder = m_executionOrder;
		return clusterAction_TutorialLesson;
	}
}
