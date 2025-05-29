using UnityEngine;

public class ClusterAction_GiveXP : ClusterAction
{
	public int m_xpBonus;

	public int m_maxLevelRewarded;

	public override object Clone()
	{
		ClusterAction_GiveXP clusterAction_GiveXP = ScriptableObject.CreateInstance(GetType()) as ClusterAction_GiveXP;
		clusterAction_GiveXP.m_xpBonus = m_xpBonus;
		clusterAction_GiveXP.m_maxLevelRewarded = m_maxLevelRewarded;
		clusterAction_GiveXP.m_executionOrder = m_executionOrder;
		return clusterAction_GiveXP;
	}
}
