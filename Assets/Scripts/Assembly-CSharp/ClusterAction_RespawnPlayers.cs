using UnityEngine;

public class ClusterAction_RespawnPlayers : ClusterAction
{
	public bool m_onlyRespawnDeadPlayer = true;

	public override object Clone()
	{
		ClusterAction_RespawnPlayers clusterAction_RespawnPlayers = ScriptableObject.CreateInstance(GetType()) as ClusterAction_RespawnPlayers;
		clusterAction_RespawnPlayers.m_onlyRespawnDeadPlayer = m_onlyRespawnDeadPlayer;
		clusterAction_RespawnPlayers.m_executionOrder = m_executionOrder;
		return clusterAction_RespawnPlayers;
	}
}
