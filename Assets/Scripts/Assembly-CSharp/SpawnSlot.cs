using System;
using UnityEngine;

[Serializable]
public class SpawnSlot : Slot
{
	[HideInInspector]
	public SpawnSlotContainer m_container;

	public NpcSpawningSettings.InitialState m_initialState;

	public bool m_bDefenseMode = true;

	public bool m_bCombatSlot = true;

	public override SlotContainer c21fba8ad45fb411f3f304287d294575f()
	{
		return m_container;
	}

	public override void c1d303e3aadbc00416e803827a0896f3f(SlotContainer cfeb8370582646b8696da2d4f86e1197f)
	{
		m_container = (SpawnSlotContainer)cfeb8370582646b8696da2d4f86e1197f;
	}

	public override object Clone()
	{
		return (SpawnSlot)MemberwiseClone();
	}
}
