using UnityEngine;
using XsdSettings;

public class ClusterAction_GiveAmmo : ClusterAction
{
	public AmmoType m_ammoType;

	public int m_count = 10;

	public override object Clone()
	{
		ClusterAction_GiveAmmo clusterAction_GiveAmmo = ScriptableObject.CreateInstance(GetType()) as ClusterAction_GiveAmmo;
		clusterAction_GiveAmmo.m_ammoType = m_ammoType;
		clusterAction_GiveAmmo.m_count = m_count;
		clusterAction_GiveAmmo.m_executionOrder = m_executionOrder;
		return clusterAction_GiveAmmo;
	}
}
