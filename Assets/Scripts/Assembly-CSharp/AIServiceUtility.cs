using System.Collections.Generic;
using A;
using BHV;
using UnityEngine;

public class AIServiceUtility
{
	public struct strTaskParam
	{
		public int index;

		public int hp;

		public BHVTaskManager taskManager;
	}

	private static readonly AIServiceUtility s_instance = new AIServiceUtility();

	private Dictionary<int, Entity> m_destructibleObjList = new Dictionary<int, Entity>();

	private int m_curIndex;

	public BHVTaskParamDestoryMissile m_destroyMissileParam = new BHVTaskParamDestoryMissile();

	public int m_playerCount_cheat = -1;

	public bool m_bPlayerNoDeath;

	public bool m_bShowNpcHP;

	public bool m_bPlayCutScene;

	public int m_npcLayer = -1;

	public List<strTaskParam> m_taskList;

	private GameObject m_warningZone;

	private ParticleSystem[] m_warningZonePs = c2f24cc5d013ceeb97e912045d443d2ab.c0a0cdf4a196914163f7334d9b0781a04(3);

	private Projector m_warningProjector;

	public static AIServiceUtility c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			return s_instance;
		}
	}

	private AIServiceUtility()
	{
		m_curIndex = 0;
		m_npcLayer = ~((1 << LayerMask.NameToLayer("Npc")) | (1 << LayerMask.NameToLayer("Ragdoll")) | (1 << LayerMask.NameToLayer("Ignore Raycast")) | (1 << LayerMask.NameToLayer("WeakPoint")) | (1 << LayerMask.NameToLayer("MeshWire")) | (1 << LayerMask.NameToLayer("AirWall")));
	}

	public int c963ef5d4b51a9309fa9483d743ab9b33(Entity cebae66039aadeac8deb1211786332a72)
	{
		if (m_destructibleObjList != null)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					m_destructibleObjList.Add(m_curIndex, cebae66039aadeac8deb1211786332a72);
					return m_curIndex++;
				}
			}
		}
		return -1;
	}

	public void c9fed2b73e654eeb03ea3ad8521c9ae89(int c212885fdedb9b9fd5818b72e1ba772cf)
	{
		if (!m_destructibleObjList.ContainsKey(c212885fdedb9b9fd5818b72e1ba772cf))
		{
			return;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_destructibleObjList.Remove(c212885fdedb9b9fd5818b72e1ba772cf);
			return;
		}
	}

	public void ccea6604e5df6fe408bddcb2ff37758ef(AttackInfo c00bb86ffbeb6764fbe60d7b64859db7f)
	{
	}

	public void cc68caa211e09465abc8826c12bc6904d(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (m_destructibleObjList == null)
		{
			return;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!m_destructibleObjList.ContainsKey(c5612a459a84ffdb41c885401433cd62d))
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			IDestructibleObj destructibleObj = m_destructibleObjList[c5612a459a84ffdb41c885401433cd62d] as IDestructibleObj;
			if (destructibleObj == null)
			{
				return;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				destructibleObj.c918693d78025ee181080696108945498();
				return;
			}
		}
	}

	public void ca97706914b3798af26c15d29a21cdcb1(int c5612a459a84ffdb41c885401433cd62d, int c0e0b6548ee9ac8354c15e369d7f01c5f)
	{
		if (m_destructibleObjList == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!m_destructibleObjList.ContainsKey(c5612a459a84ffdb41c885401433cd62d))
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			IDestructibleObj destructibleObj = m_destructibleObjList[c5612a459a84ffdb41c885401433cd62d] as IDestructibleObj;
			if (destructibleObj == null)
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
				destructibleObj.c24573231c964a8e1b6c359bcdc11ac2e(c0e0b6548ee9ac8354c15e369d7f01c5f);
				return;
			}
		}
	}

	public void cc5af0a72cac219b86ee5ccc931325456(Vector3 c330987c4414f384d6c951ab9f68460d8, float cbac8b1e8ba44d23d7b3364e72446ccf7)
	{
		if (m_warningZone == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Object @object = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Entities/Object/Effect/BossWarningZone");
			if (@object != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_warningZone = (GameObject)Object.Instantiate(@object);
			}
			if (m_warningZone == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			m_warningZonePs = m_warningZone.GetComponentsInChildren<ParticleSystem>();
			m_warningProjector = m_warningZone.GetComponentInChildren<Projector>();
			if (m_warningZonePs == null)
			{
				return;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			if (m_warningZonePs.Length == 0)
			{
				return;
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
			if (m_warningProjector == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}
		m_warningZone.transform.position = c330987c4414f384d6c951ab9f68460d8;
		for (int i = 0; i < m_warningZonePs.Length; i++)
		{
			m_warningZonePs[i].startSize = cbac8b1e8ba44d23d7b3364e72446ccf7;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			m_warningProjector.orthographic = true;
			m_warningProjector.orthographicSize = cbac8b1e8ba44d23d7b3364e72446ccf7;
			m_warningZone.gameObject.SetActive(true);
			return;
		}
	}

	public void cf26f5e09ef041b20e768bbd7e1d13f3a()
	{
		if (m_warningZone == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		m_warningZone.gameObject.SetActive(false);
	}

	public void c590aee60e79226f59f47e3e6e2d12842(BHVTaskManager cfc241af7ab51814fc074e767be1a0bb8)
	{
		if (cfc241af7ab51814fc074e767be1a0bb8.m_navAgent != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			cfc241af7ab51814fc074e767be1a0bb8.m_navAgent.enabled = true;
		}
		if (cfc241af7ab51814fc074e767be1a0bb8.m_entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c57e4d4cd41f3be21d7e24a71aa08c6ba(cfc241af7ab51814fc074e767be1a0bb8.m_entity);
			(cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).cbe69c00ee6a961f5e519fe230d87c736();
			if (cfc241af7ab51814fc074e767be1a0bb8.GetComponent<BHVBrain>().m_isDamageable)
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
				DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cf3d2cb82d21abb0d2de84f85c25fdb49(cfc241af7ab51814fc074e767be1a0bb8.m_entity);
			}
		}
		NPCAnimationManagerFSM nPCAnimationManagerFSM = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as NPCAnimationManagerFSM;
		if (nPCAnimationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			nPCAnimationManagerFSM.OnNpcRespawn();
		}
		Utils.ce6378e8b5a8ae9a4202182e1876677fe(cfc241af7ab51814fc074e767be1a0bb8.transform, LayerMask.NameToLayer("Default"), true);
		cfc241af7ab51814fc074e767be1a0bb8.gameObject.layer = LayerMask.NameToLayer("Npc");
		int num = 0;
		while (true)
		{
			if (num < cfc241af7ab51814fc074e767be1a0bb8.transform.childCount)
			{
				GameObject gameObject = cfc241af7ab51814fc074e767be1a0bb8.transform.GetChild(num).gameObject;
				if (gameObject.name == "BoundingBox")
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					gameObject.layer = LayerMask.NameToLayer("Npc");
					break;
				}
				num++;
				continue;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			break;
		}
		CollisionManager component = cfc241af7ab51814fc074e767be1a0bb8.GetComponent<CollisionManager>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			component.cd632e5715ef3decbdd36429dcbc891cf();
			component.c0921477f0f5481900f5ba2cf3bf4c322();
		}
		ce674c03a24ec89ef7cb066f5795f06c8(cfc241af7ab51814fc074e767be1a0bb8, true);
		if ((bool)cfc241af7ab51814fc074e767be1a0bb8)
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
			if ((bool)cfc241af7ab51814fc074e767be1a0bb8.m_entity)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (cfc241af7ab51814fc074e767be1a0bb8.m_entity.cdcf5e0592c05a681a8470f66674efd0b() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					AIInventory aIInventory = cfc241af7ab51814fc074e767be1a0bb8.m_entity.cdcf5e0592c05a681a8470f66674efd0b();
					if (aIInventory != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (aIInventory.m_weapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							aIInventory.m_weapon.gameObject.SetActive(true);
						}
					}
				}
			}
		}
		BHVTaskUtils.c524eadbff83910c7600158a6c6eebcdd(cfc241af7ab51814fc074e767be1a0bb8.m_entity, false);
	}

	public void ce674c03a24ec89ef7cb066f5795f06c8(BHVTaskManager cfc241af7ab51814fc074e767be1a0bb8, bool c38daa1ecfc4be57f0bab6f15b4488ecc)
	{
		BHVTaskUtils.c9910e85b3d98c0029a8824c312afef63(cfc241af7ab51814fc074e767be1a0bb8.m_entity, c38daa1ecfc4be57f0bab6f15b4488ecc);
		CollisionManager component = cfc241af7ab51814fc074e767be1a0bb8.GetComponent<CollisionManager>();
		if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			component.c1ce44495f53aa451cfab609bd34340d2().enabled = c38daa1ecfc4be57f0bab6f15b4488ecc;
			return;
		}
	}
}
