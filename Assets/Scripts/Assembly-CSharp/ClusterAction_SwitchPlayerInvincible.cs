using UnityEngine;

public class ClusterAction_SwitchPlayerInvincible : ClusterAction
{
	public bool m_isInvulnerable;

	public override object Clone()
	{
		ClusterAction_SwitchPlayerInvincible clusterAction_SwitchPlayerInvincible = ScriptableObject.CreateInstance(GetType()) as ClusterAction_SwitchPlayerInvincible;
		clusterAction_SwitchPlayerInvincible.m_isInvulnerable = m_isInvulnerable;
		clusterAction_SwitchPlayerInvincible.m_executionOrder = m_executionOrder;
		return clusterAction_SwitchPlayerInvincible;
	}
}
