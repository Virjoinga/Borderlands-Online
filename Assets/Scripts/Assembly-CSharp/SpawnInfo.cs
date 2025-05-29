using System;
using UnityEngine;

[Serializable]
public class SpawnInfo
{
	public Entity.EntityType m_entity;

	public NpcSpawningSettings m_settings;

	public ItemSpawningSettings m_itemSpwan;

	[HideInInspector]
	public PlayerSpawningSettings m_playerSettings;
}
