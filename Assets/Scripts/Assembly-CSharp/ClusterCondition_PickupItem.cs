using UnityEngine;

public class ClusterCondition_PickupItem : ClusterCondition, ILootListener
{
	public EntityObject.EntitySubType m_itemType = EntityObject.EntitySubType.Weapon;

	public override object Clone()
	{
		ClusterCondition_PickupItem clusterCondition_PickupItem = ScriptableObject.CreateInstance(GetType()) as ClusterCondition_PickupItem;
		clusterCondition_PickupItem.m_itemType = m_itemType;
		clusterCondition_PickupItem.m_ownerCluster = m_ownerCluster;
		clusterCondition_PickupItem.m_isValid = m_isValid;
		return clusterCondition_PickupItem;
	}

	public void OnPickedUp(EntityPlayer picker, EntityObject item)
	{
	}
}
