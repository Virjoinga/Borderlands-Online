using System;
using UnityEngine;

[Serializable]
public class ClusterCondition : ScriptableObject, ICloneable
{
	protected Scene m_ownerCluster;

	protected bool m_isValid;

	public Scene Owner
	{
		get
		{
			return m_ownerCluster;
		}
		private set
		{
		}
	}

	public virtual object Clone()
	{
		ClusterCondition clusterCondition = ScriptableObject.CreateInstance(GetType()) as ClusterCondition;
		clusterCondition.m_ownerCluster = m_ownerCluster;
		clusterCondition.m_isValid = m_isValid;
		return clusterCondition;
	}

	public void c91bb4511235368d115f238ec63e9fb24(Scene c2acd1a8feebf87b83e5d6d609dc53067)
	{
		m_ownerCluster = c2acd1a8feebf87b83e5d6d609dc53067;
	}

	public void caf3df0cd4df215222aaa3f9ff254f1bd()
	{
		m_isValid = true;
	}

	public virtual bool c943bc6a18586b3e0e6f0214717aca479()
	{
		return m_isValid;
	}

	public virtual void Reset()
	{
		m_isValid = false;
	}
}
