using UnityEngine;

public class ClusterAction_TimerControl : ClusterAction
{
	public enum TimerAction
	{
		Stop = 0,
		Resume = 1,
		Reset = 2
	}

	public TimerCluster m_timer;

	public TimerAction m_action;

	public override object Clone()
	{
		ClusterAction_TimerControl clusterAction_TimerControl = ScriptableObject.CreateInstance(GetType()) as ClusterAction_TimerControl;
		clusterAction_TimerControl.m_timer = m_timer;
		clusterAction_TimerControl.m_action = m_action;
		clusterAction_TimerControl.m_executionOrder = m_executionOrder;
		return clusterAction_TimerControl;
	}
}
