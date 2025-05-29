using Core;
using UnityEngine;

public class ClusterAction_ShowUIMessage : ClusterAction
{
	public UIMessage m_message = new UIMessage();

	public override object Clone()
	{
		ClusterAction_ShowUIMessage clusterAction_ShowUIMessage = ScriptableObject.CreateInstance(GetType()) as ClusterAction_ShowUIMessage;
		clusterAction_ShowUIMessage.m_message = m_message;
		clusterAction_ShowUIMessage.m_executionOrder = m_executionOrder;
		return clusterAction_ShowUIMessage;
	}
}
