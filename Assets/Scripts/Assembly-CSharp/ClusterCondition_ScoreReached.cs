using UnityEngine;

public class ClusterCondition_ScoreReached : ClusterCondition
{
	public enum ThresholdType
	{
		Score = 0,
		Kill = 1
	}

	public ThresholdType m_thresholdType;

	public int m_countToReach = 1000;

	public override object Clone()
	{
		ClusterCondition_ScoreReached clusterCondition_ScoreReached = ScriptableObject.CreateInstance(GetType()) as ClusterCondition_ScoreReached;
		clusterCondition_ScoreReached.m_thresholdType = m_thresholdType;
		clusterCondition_ScoreReached.m_countToReach = m_countToReach;
		clusterCondition_ScoreReached.m_ownerCluster = m_ownerCluster;
		clusterCondition_ScoreReached.m_isValid = m_isValid;
		return clusterCondition_ScoreReached;
	}
}
