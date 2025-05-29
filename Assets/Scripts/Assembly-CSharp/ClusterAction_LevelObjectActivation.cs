using UnityEngine;

public class ClusterAction_LevelObjectActivation : ClusterAction
{
	public LevelObjectSync m_levelObject;

	public LevelObjectSync.LevelObjectSyncState m_activate = LevelObjectSync.LevelObjectSyncState.Activated;

	public override object Clone()
	{
		ClusterAction_LevelObjectActivation clusterAction_LevelObjectActivation = ScriptableObject.CreateInstance(GetType()) as ClusterAction_LevelObjectActivation;
		clusterAction_LevelObjectActivation.m_levelObject = m_levelObject;
		clusterAction_LevelObjectActivation.m_activate = m_activate;
		clusterAction_LevelObjectActivation.m_executionOrder = m_executionOrder;
		return clusterAction_LevelObjectActivation;
	}
}
