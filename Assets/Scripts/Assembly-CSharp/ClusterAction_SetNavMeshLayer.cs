using UnityEngine;

public class ClusterAction_SetNavMeshLayer : ClusterAction
{
	public enum ESetAction
	{
		Enable = 0,
		Disable = 1
	}

	public string m_navmeshLayer;

	public ESetAction m_setAction;

	public override object Clone()
	{
		ClusterAction_SetNavMeshLayer clusterAction_SetNavMeshLayer = ScriptableObject.CreateInstance(GetType()) as ClusterAction_SetNavMeshLayer;
		clusterAction_SetNavMeshLayer.m_navmeshLayer = m_navmeshLayer;
		clusterAction_SetNavMeshLayer.m_setAction = m_setAction;
		clusterAction_SetNavMeshLayer.m_executionOrder = m_executionOrder;
		return clusterAction_SetNavMeshLayer;
	}
}
