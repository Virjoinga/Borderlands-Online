using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class InstantiateManager : c06ca0e618478c23eba3419653a19760f<InstantiateManager>
{
	public interface InstanciationClient
	{
		void OnInstanciate(GameObject instance, SpawnRequest request);
	}

	public enum NetworkReplicationGroup
	{
		Lobby = 0,
		StaticSync = 1,
		DynamicSync = 2,
		InGame = 3
	}

	public struct SpawnRequest
	{
		public bool m_isNetworkInstanciate;

		public string m_prefabName;

		public Vector3 m_position;

		public Quaternion m_rotation;

		public NetworkReplicationGroup m_group;

		public object[] m_spawnData;

		public object[] m_callbackData;

		public InstanciationClient m_caller;
	}

	public List<string> m_itstantiateObjectDic = new List<string>();

	private List<GameObject> m_instantiateObject;

	private List<SpawnRequest> m_waitingSpawningRequest = new List<SpawnRequest>();

	public List<GameObject> cee6ec96a3084a4e84b1b188ca2da7aec
	{
		get
		{
			return m_instantiateObject;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		m_instantiateObject = new List<GameObject>();
		m_itstantiateObjectDic.Clear();
		using (List<BuildingKitTableUnit>.Enumerator enumerator = BuildingKitManager.c93b8a9cdba26e37d7c55b1e834e4d92e.bkTable.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				BuildingKitTableUnit current = enumerator.Current;
				string filePath = current.filePath;
				char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = '/';
				string text = filePath.Split(array)[1];
				text = text.Replace('_', '|');
				m_itstantiateObjectDic.Add(text);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				break;
			}
		}
		m_itstantiateObjectDic.Add("Entities/Object/Weapon/Weapon");
		m_itstantiateObjectDic.Add("Entities/Object/Item/PRO_Pack_HP_P");
		m_itstantiateObjectDic.Add("Entities/Object/Item/PRO_Ammo_SMG_P");
		m_itstantiateObjectDic.Add("Entities/Object/Item/PRO_Ammo_Sniper_P");
		m_itstantiateObjectDic.Add("Entities/Object/Item/PRO_Ammo_RepeaterPistol_P");
		m_itstantiateObjectDic.Add("Entities/Object/Item/PRO_Ammo_Grenade_P");
		m_itstantiateObjectDic.Add("Entities/Object/Item/PRO_Cash_P");
		m_itstantiateObjectDic.Add("Entities/Object/Launchable/Grenade");
		m_itstantiateObjectDic.Add("Session");
		m_itstantiateObjectDic.Add("LevelObjectManager");
		m_itstantiateObjectDic.Add("Player");
		m_itstantiateObjectDic.Add("Entities/Object/ExplosiveDestructibleObj/ExposiveDestructible_BarrelXML");
		m_itstantiateObjectDic.Add("Entities/Player_Mecanim/CHR_Player_Root");
		m_itstantiateObjectDic.Add("Entities/Player_Mecanim/Siren/CHR_Town_Siren_Root");
		m_itstantiateObjectDic.Add("Entities/Player_Mecanim/Siren/CHR_Siren_Root");
		m_itstantiateObjectDic.Add("Entities/Player_Mecanim/Soldier/CHR_Town_Soldier_Root");
		m_itstantiateObjectDic.Add("Entities/Player_Mecanim/Soldier/CHR_Soldier_Root");
		m_itstantiateObjectDic.Add("Entities/Player_Mecanim/Berserker/CHR_Town_Berserker_Root");
		m_itstantiateObjectDic.Add("Entities/Player_Mecanim/Berserker/CHR_Berserker_Root");
		m_itstantiateObjectDic.Sort();
	}

	public void cae70a8c23e816b09c686c0715bf1337c(SpawnRequest cf4d0bdd2d52180fa1fb008e654aef5fb)
	{
		m_waitingSpawningRequest.Add(cf4d0bdd2d52180fa1fb008e654aef5fb);
	}

	public void c76f6e01303388351d94423282930f308(GameObject ca7f2fd1aa3ebf4853484333fd7866f9f)
	{
		m_instantiateObject.Add(ca7f2fd1aa3ebf4853484333fd7866f9f);
	}

	public void c77ad3ea1777a263169b5b42beafc6a44(GameObject ca7f2fd1aa3ebf4853484333fd7866f9f)
	{
		m_instantiateObject.Remove(ca7f2fd1aa3ebf4853484333fd7866f9f);
	}

	public EntityWeapon ced7f8f71bffe8b45eee62a9a84d360fd(WeaponDNA caedbc1db6c28d44eab6021e7d674eab3, Vector3 c330987c4414f384d6c951ab9f68460d8, Quaternion c2a8e8b393b40d6cde9e5177c7a9adb48, bool cd5677c335a8abc9e44f07dbaff3560bf)
	{
		EntityWeapon c7088de59e49f7108f520cf7e0bae167e = ceaa467e9f01cebcf620c4729a7dcef3f.c7088de59e49f7108f520cf7e0bae167e;
		if (cd5677c335a8abc9e44f07dbaff3560bf)
		{
			while (true)
			{
				switch (3)
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
			c7088de59e49f7108f520cf7e0bae167e = (EntityWeapon)cbf43efce245fabdfb9d3009487ba8085(ItemDNA.c8284b9f225995cc6a6e1888c9c037b06(caedbc1db6c28d44eab6021e7d674eab3), c330987c4414f384d6c951ab9f68460d8, c2a8e8b393b40d6cde9e5177c7a9adb48, Vector3.zero);
		}
		else
		{
			string c8aa0e7ee156ed339de23d3fe5557b = ItemGeneratorService.c75919981e281c6d31567ac93867ca150(ItemType.Weapon);
			GameObject gameObject = (GameObject)Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c8aa0e7ee156ed339de23d3fe5557b), c330987c4414f384d6c951ab9f68460d8, c2a8e8b393b40d6cde9e5177c7a9adb48);
			c7088de59e49f7108f520cf7e0bae167e = gameObject.GetComponent<EntityWeapon>();
		}
		c7088de59e49f7108f520cf7e0bae167e.c68cd0a841e044876d964965d7ec944bd(caedbc1db6c28d44eab6021e7d674eab3);
		return c7088de59e49f7108f520cf7e0bae167e;
	}

	public EntityShield cfe93941b14e28baa59c497f98102ccd5(ItemDNA caedbc1db6c28d44eab6021e7d674eab3, Vector3 c330987c4414f384d6c951ab9f68460d8, Quaternion c2a8e8b393b40d6cde9e5177c7a9adb48, bool cd5677c335a8abc9e44f07dbaff3560bf)
	{
		EntityShield c7088de59e49f7108f520cf7e0bae167e = cfdcd4b1e38674bf0a07bf7a1172dc29c.c7088de59e49f7108f520cf7e0bae167e;
		if (cd5677c335a8abc9e44f07dbaff3560bf)
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
			c7088de59e49f7108f520cf7e0bae167e = (EntityShield)cbf43efce245fabdfb9d3009487ba8085(ItemDNA.c8f331a9c3beba42f2ccd0923c0c67e0a(caedbc1db6c28d44eab6021e7d674eab3.m_shiled), c330987c4414f384d6c951ab9f68460d8, c2a8e8b393b40d6cde9e5177c7a9adb48, Vector3.zero);
		}
		else
		{
			string c8aa0e7ee156ed339de23d3fe5557b = ItemGeneratorService.c75919981e281c6d31567ac93867ca150(ItemType.Shield);
			GameObject gameObject = (GameObject)Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c8aa0e7ee156ed339de23d3fe5557b), c330987c4414f384d6c951ab9f68460d8, c2a8e8b393b40d6cde9e5177c7a9adb48);
			c7088de59e49f7108f520cf7e0bae167e = gameObject.GetComponent<EntityShield>();
		}
		c7088de59e49f7108f520cf7e0bae167e.c68cd0a841e044876d964965d7ec944bd(caedbc1db6c28d44eab6021e7d674eab3.c8e074b9d0135ff808166cc324407f74c(), c72d1b2b1b60b723ae8df41127652adb5.c7088de59e49f7108f520cf7e0bae167e);
		return c7088de59e49f7108f520cf7e0bae167e;
	}

	public EntityShield cfe93941b14e28baa59c497f98102ccd5(Vector3 c330987c4414f384d6c951ab9f68460d8, Quaternion c2a8e8b393b40d6cde9e5177c7a9adb48, bool cd5677c335a8abc9e44f07dbaff3560bf)
	{
		EntityShield c7088de59e49f7108f520cf7e0bae167e = cfdcd4b1e38674bf0a07bf7a1172dc29c.c7088de59e49f7108f520cf7e0bae167e;
		if (cd5677c335a8abc9e44f07dbaff3560bf)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return (EntityShield)cbf43efce245fabdfb9d3009487ba8085(ItemDNA.c8f331a9c3beba42f2ccd0923c0c67e0a(), c330987c4414f384d6c951ab9f68460d8, c2a8e8b393b40d6cde9e5177c7a9adb48, Vector3.zero);
				}
			}
		}
		string c8aa0e7ee156ed339de23d3fe5557b = ItemGeneratorService.c75919981e281c6d31567ac93867ca150(ItemType.Shield);
		GameObject gameObject = (GameObject)Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c8aa0e7ee156ed339de23d3fe5557b), c330987c4414f384d6c951ab9f68460d8, c2a8e8b393b40d6cde9e5177c7a9adb48);
		return gameObject.GetComponent<EntityShield>();
	}

	public EntityClassMode cad906dd3da954596cb70c5723a6afa82(ItemDNA caedbc1db6c28d44eab6021e7d674eab3, Vector3 c330987c4414f384d6c951ab9f68460d8, Quaternion c2a8e8b393b40d6cde9e5177c7a9adb48, bool cd5677c335a8abc9e44f07dbaff3560bf)
	{
		EntityClassMode c7088de59e49f7108f520cf7e0bae167e = c14f6092e7187fb942b7b3a67f869f237.c7088de59e49f7108f520cf7e0bae167e;
		if (cd5677c335a8abc9e44f07dbaff3560bf)
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
			c7088de59e49f7108f520cf7e0bae167e = (EntityClassMode)cbf43efce245fabdfb9d3009487ba8085(ItemDNA.c7a1e006dac3107ddc09019d735839e9a(caedbc1db6c28d44eab6021e7d674eab3.c253c28f3a59bc5e5a528dfbb463a8a45()), c330987c4414f384d6c951ab9f68460d8, c2a8e8b393b40d6cde9e5177c7a9adb48, Vector3.zero);
		}
		else
		{
			string c8aa0e7ee156ed339de23d3fe5557b = ItemGeneratorService.c474b312bbfb73d3e8ab0cf777f80e68c(caedbc1db6c28d44eab6021e7d674eab3);
			GameObject gameObject = (GameObject)Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c8aa0e7ee156ed339de23d3fe5557b), c330987c4414f384d6c951ab9f68460d8, c2a8e8b393b40d6cde9e5177c7a9adb48);
			c7088de59e49f7108f520cf7e0bae167e = gameObject.GetComponent<EntityClassMode>();
		}
		c7088de59e49f7108f520cf7e0bae167e.c68cd0a841e044876d964965d7ec944bd(caedbc1db6c28d44eab6021e7d674eab3.c253c28f3a59bc5e5a528dfbb463a8a45());
		return c7088de59e49f7108f520cf7e0bae167e;
	}

	public EntityObject cbf43efce245fabdfb9d3009487ba8085(ItemDNA caedbc1db6c28d44eab6021e7d674eab3, Vector3 c330987c4414f384d6c951ab9f68460d8, Quaternion c2a8e8b393b40d6cde9e5177c7a9adb48, Vector3 c9165cd419ba9a89cbaa6c1cff01757c7, int c8a7f3986726d4793d7b3f3bbcc750943 = -1, int ce468e1f9a5bc2a50eb455fee1dc03495 = -1, int cbb735ebd47f14b832ee53b576f259a41 = 0, int c1c237217c91437e0fb31a30d71b0e7e5 = 0)
	{
		EntityObject result = cd106b90ad49dbab480b1d65a61bd2d9e.c7088de59e49f7108f520cf7e0bae167e;
		if (caedbc1db6c28d44eab6021e7d674eab3 != null)
		{
			while (true)
			{
				switch (6)
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
			string text = ItemGeneratorService.c474b312bbfb73d3e8ab0cf777f80e68c(caedbc1db6c28d44eab6021e7d674eab3);
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
			array[0] = caedbc1db6c28d44eab6021e7d674eab3;
			array[1] = c9165cd419ba9a89cbaa6c1cff01757c7;
			array[2] = c8a7f3986726d4793d7b3f3bbcc750943;
			array[3] = ce468e1f9a5bc2a50eb455fee1dc03495;
			array[4] = cbb735ebd47f14b832ee53b576f259a41;
			array[5] = c1c237217c91437e0fb31a30d71b0e7e5;
			GameObject gameObject;
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
				gameObject = (GameObject)Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(text), c330987c4414f384d6c951ab9f68460d8, c2a8e8b393b40d6cde9e5177c7a9adb48);
			}
			else
			{
				gameObject = PhotonNetwork.c90236f85f4a0b603b56f8daf34c2279e(text, c330987c4414f384d6c951ab9f68460d8, c2a8e8b393b40d6cde9e5177c7a9adb48, 2, array);
			}
			result = gameObject.GetComponent<EntityObject>();
		}
		return result;
	}

	public void c6b29801a7d7b62d357a2c322f8fbb8d4(PhotonPlayer ceb41162a7cd2a1d5c4a03830e02b4198)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
		array[0] = ceb41162a7cd2a1d5c4a03830e02b4198.c29a834d12d3895f5680e69a30e6cd9a3;
		array[1] = ceb41162a7cd2a1d5c4a03830e02b4198.cd99af21e22e356018b8f72d4a7e4872a;
		object obj;
		if (ceb41162a7cd2a1d5c4a03830e02b4198.customProperties.ContainsKey("AccountId"))
		{
			while (true)
			{
				switch (6)
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
			obj = ceb41162a7cd2a1d5c4a03830e02b4198.customProperties["AccountId"];
		}
		else
		{
			obj = -1;
		}
		array[2] = obj;
		object obj2;
		if (ceb41162a7cd2a1d5c4a03830e02b4198.customProperties.ContainsKey("CharacterId"))
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			obj2 = ceb41162a7cd2a1d5c4a03830e02b4198.customProperties["CharacterId"];
		}
		else
		{
			obj2 = -1;
		}
		array[3] = obj2;
		array[4] = 0;
		GameObject gameObject = PhotonNetwork.c90236f85f4a0b603b56f8daf34c2279e("Player", Vector3.zero, Quaternion.identity, 0, array);
		PlayerInfoSync component = gameObject.GetComponent<PlayerInfoSync>();
		component.ccc9d3a38966dc10fedb531ea17d24611(array, ceb41162a7cd2a1d5c4a03830e02b4198);
	}

	private void FixedUpdate()
	{
		GameObject c7088de59e49f7108f520cf7e0bae167e = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		if (m_waitingSpawningRequest.Count <= 0)
		{
			return;
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			SpawnRequest spawnRequest = m_waitingSpawningRequest[0];
			m_waitingSpawningRequest.Remove(spawnRequest);
			if (spawnRequest.m_isNetworkInstanciate)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				c7088de59e49f7108f520cf7e0bae167e = PhotonNetwork.c90236f85f4a0b603b56f8daf34c2279e(spawnRequest.m_prefabName, spawnRequest.m_position, spawnRequest.m_rotation, (int)spawnRequest.m_group, spawnRequest.m_spawnData);
			}
			else
			{
				Object original = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(spawnRequest.m_prefabName);
				c7088de59e49f7108f520cf7e0bae167e = (GameObject)Object.Instantiate(original, spawnRequest.m_position, spawnRequest.m_rotation);
			}
			if (spawnRequest.m_caller == null)
			{
				return;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				if (c7088de59e49f7108f520cf7e0bae167e != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							spawnRequest.m_caller.OnInstanciate(c7088de59e49f7108f520cf7e0bae167e, spawnRequest);
							return;
						}
					}
				}
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.System, "We have a problem");
				return;
			}
		}
	}

	public int ccf40045aeeee28a8e5e277ff102d404e()
	{
		return m_waitingSpawningRequest.Count;
	}
}
