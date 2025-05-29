using System;

[Serializable]
public class NpcSpawningSettings
{
	public enum InitialState
	{
		Patrol = 0,
		Idle = 1,
		Cover = 2,
		Spawn = 3,
		AdvanceSpawn = 4,
		CombatSpawn = 5
	}

	public InitialState m_initialState;

	public PatrolSettings m_patrolSetting = new PatrolSettings();

	public bool m_bDefenseMode;

	public bool m_bCombatSlot;
}
