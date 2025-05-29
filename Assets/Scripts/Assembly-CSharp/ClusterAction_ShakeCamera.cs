using UnityEngine;

public class ClusterAction_ShakeCamera : ClusterAction
{
	public BadAssFPSCamera.ShakeType m_intensity;

	public override object Clone()
	{
		ClusterAction_ShakeCamera clusterAction_ShakeCamera = ScriptableObject.CreateInstance(GetType()) as ClusterAction_ShakeCamera;
		clusterAction_ShakeCamera.m_intensity = m_intensity;
		clusterAction_ShakeCamera.m_executionOrder = m_executionOrder;
		return clusterAction_ShakeCamera;
	}
}
