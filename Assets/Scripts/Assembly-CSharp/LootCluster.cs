using System;
using System.Collections.Generic;
using UnityEngine;

public class LootCluster : Scene, InstantiateManager.InstanciationClient
{
	[Serializable]
	public class LootSpawnProba
	{
		public string m_item;

		public int m_probability = 100;
	}

	[Serializable]
	public class SpawnSlot
	{
		public LootSpawnProba[] m_probabilities;
	}

	[Serializable]
	public class TreasureBoxSettings
	{
		public string m_treasureBox;

		public SpawnSlot[] m_spawningList;
	}

	public TreasureBoxSettings[] m_boxList = new TreasureBoxSettings[0];

	private SpawnPointSettings[] m_spawningPoint;

	private List<int> m_spawnedEntityIDs = new List<int>();

	private void Start()
	{
		m_spawningPoint = base.gameObject.GetComponentsInChildren<SpawnPointSettings>();
	}

	public virtual void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
	}
}
