using UnityEngine;

public class LootingSlot : MonoBehaviour
{
	public enum LootingSlotType
	{
		Item = 0,
		Weapon = 1
	}

	public LootingSlotType m_slotType;

	public int m_lootNumber;

	public int m_lootIndex;

	public float m_lootLightPillarDelay;

	public float m_lootPickableDelay;
}
