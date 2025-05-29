using UnityEngine;
using XsdSettings;

public class ClusterCondition_RemainingAmmo : ClusterCondition
{
	public AmmoType m_ammoType;

	public int m_count = 10;

	public override object Clone()
	{
		ClusterCondition_RemainingAmmo clusterCondition_RemainingAmmo = ScriptableObject.CreateInstance(GetType()) as ClusterCondition_RemainingAmmo;
		clusterCondition_RemainingAmmo.m_ammoType = m_ammoType;
		clusterCondition_RemainingAmmo.m_count = m_count;
		clusterCondition_RemainingAmmo.m_ownerCluster = m_ownerCluster;
		clusterCondition_RemainingAmmo.m_isValid = m_isValid;
		return clusterCondition_RemainingAmmo;
	}
}
