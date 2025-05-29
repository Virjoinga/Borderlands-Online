using System;
using System.Collections.Generic;
using A;
using UnityEngine;

public class SpawnPointSettings : MonoBehaviour, InstantiateManager.InstanciationClient
{
	private Queue<InstantiateManager.InstanciationClient> m_callbacks = new Queue<InstantiateManager.InstanciationClient>();

	public SpawnInfo m_spawnInfo;

	public SpawnInfo[] m_spawnInfos = c132792f505ef44e07d704f2804a2b6ae.c0a0cdf4a196914163f7334d9b0781a04(0);

	public NpcSpawningSettings.InitialState m_slotInitialState;

	public bool m_bDefenseMode;

	public bool m_bCombatSlot;

	public static List<string> m_npcFamilyList = new List<string>();

	public static int m_npcSmallTypeLevelMax = 12;

	public static int m_npcMiddleTypeLevelMax = 12;

	private void Start()
	{
		if (m_spawnInfos != null)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_spawnInfos.Length > 0)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				m_spawnInfo = m_spawnInfos[0];
			}
		}
		cee52e7a146650179ebef174dffa1ad34();
	}

	public static void cee52e7a146650179ebef174dffa1ad34()
	{
		m_npcFamilyList.Add(EntityNpc.EntitySubType.CHR_BanditKiller.ToString());
		m_npcFamilyList.Add(EntityNpc.EntitySubType.CHR_BanditRaider.ToString());
		m_npcFamilyList.Add(EntityNpc.EntitySubType.CHR_BanditScout.ToString());
	}

	public Entity.EntityType c6420f67f9249b1d533531d9f351a36e0()
	{
		return m_spawnInfo.m_entity;
	}

	public static SpawnPointSettings[] cdbce0a2958a2a3f29f8301ed33509659(Entity.EntityType c5d720f6d007abb0c4a21d6a654e405bb = Entity.EntityType.None)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("SpawnPoint");
		SpawnPointSettings[] array2 = c8a7a8403f3b051eae8396aa3877b607d.c0a0cdf4a196914163f7334d9b0781a04(array.Length);
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			SpawnPointSettings component = array[i].GetComponent<SpawnPointSettings>();
			if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				continue;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Entity.EntityType entityType = component.c6420f67f9249b1d533531d9f351a36e0();
			if (c5d720f6d007abb0c4a21d6a654e405bb != 0)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (c5d720f6d007abb0c4a21d6a654e405bb != entityType)
				{
					continue;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			array2[num] = component;
			num++;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			SpawnPointSettings[] array3 = c8a7a8403f3b051eae8396aa3877b607d.c0a0cdf4a196914163f7334d9b0781a04(num);
			Array.Copy(array2, 0, array3, 0, array3.Length);
			return array3;
		}
	}

	public static string c02417b5fee2e080f5632063f57e5a000(string c232627c2642fa3f0b8e9eb70ceec3b7d)
	{
		string text = c232627c2642fa3f0b8e9eb70ceec3b7d.Replace("CHR_", string.Empty);
		string text2;
		if (text.EndsWith("XML"))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			text2 = text.Replace("XML", string.Empty);
		}
		else
		{
			text2 = text;
		}
		return "BKT|NPC|" + text2;
	}

	public static string cb9faeb5e5202b46b73cdae6f2423d491(string c232627c2642fa3f0b8e9eb70ceec3b7d, int cd6bb591c33b2ee3ab93e98aa43a6da63)
	{
		string text = c232627c2642fa3f0b8e9eb70ceec3b7d.Replace("CHR_", string.Empty);
		return "BKT|NPC|" + text;
	}

	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
	}
}
