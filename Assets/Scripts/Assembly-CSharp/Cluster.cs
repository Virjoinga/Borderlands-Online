using System;
using UnityEngine;
using XsdSettings;

[RequireComponent(typeof(SpawnSlotContainer))]
public class Cluster : Scene, IDamageListener, InstantiateManager.InstanciationClient
{
	public enum SpawningOrder
	{
		FixedOrder = 0,
		RandomOrder = 1
	}

	public enum InitialSpawnType
	{
		OnBegin = 0,
		OnTimer = 1,
		OnTriggerZone = 2
	}

	[Serializable]
	public class NpcSpawnProba
	{
		public string m_npc;

		public int m_probability = 100;
	}

	[Serializable]
	public class SpawningSlot
	{
		public NpcSpawnProba[] m_probabilities;

		public int m_minPlayerCount = 1;

		public ELevelDifficulty m_minDifficulty;
	}

	public enum ENextSpawnCondition
	{
		EDeath = 0,
		ETimer = 1
	}

	[HideInInspector]
	public bool m_showConfig;

	[HideInInspector]
	public bool m_showSpawningData;

	public int m_remainingNpcForCompletion;

	public float m_nextSpawnTime;

	[HideInInspector]
	public ENextSpawnCondition m_nextSpawnCondition;

	protected bool m_bSpawnPeeding;

	public SpawningOrder m_spawningOrder;

	public int m_minLevel;

	public int m_maxLevel;

	public int m_combatCount1p = 1;

	public int m_combatCount2p = 1;

	public int m_combatCount3p = 1;

	public int m_combatCount4p = 1;

	public bool m_bMissionCluster;

	public bool m_bBossLevel;

	public SpawningSlot[] m_spawningList;

	private void Start()
	{
	}

	private void OnDestroy()
	{
		DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.c67b40caae87a37a992e8004e2229b0eb(this);
	}

	protected override void cb537a7cebe404b48035eab26b9fd89b8()
	{
	}

	public virtual void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
	}

	public void OnDamaged(DamageContext context)
	{
	}

	public void OnEntityKill(KillContext context)
	{
	}

	protected override bool c6b55d8e5c9702fae8ea5ac979f1a8713()
	{
		return false;
	}
}
