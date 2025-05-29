using UnityEngine;

public class ClusterAction_DisplayEchoMessage : ClusterAction
{
	public string m_echoId;

	public override object Clone()
	{
		ClusterAction_DisplayEchoMessage clusterAction_DisplayEchoMessage = ScriptableObject.CreateInstance(GetType()) as ClusterAction_DisplayEchoMessage;
		clusterAction_DisplayEchoMessage.m_echoId = m_echoId;
		clusterAction_DisplayEchoMessage.m_executionOrder = m_executionOrder;
		return clusterAction_DisplayEchoMessage;
	}
}
