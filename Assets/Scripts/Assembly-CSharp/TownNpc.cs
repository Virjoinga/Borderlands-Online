using System.Collections.Generic;
using A;
using UnityEngine;
using XsdSettings;

public class TownNpc : MonoBehaviour, InteractionClient
{
	public int m_npcId;

	public GameObject m_dialogCam;

	public GameObject m_taskMark;

	public GameObject m_titleObj;

	public E_USE_TYPE m_interactionType = E_USE_TYPE.E_TALK;

	protected CollisionManager m_collisionManager;

	private NpcTitleMgr m_titleMng;

	private XsdSettings.TownNpc m_npcSettings;

	private bool m_isInitialized;

	private TownNPCAnimationManagerFSM m_animManager;

	private TownNPCAnimationManagerFSM.TownNpcAnimationType m_animPending = TownNPCAnimationManagerFSM.TownNpcAnimationType.GREET;

	private List<int> m_questIdAsGiver = new List<int>();

	private List<int> m_questIdAsReclaimer = new List<int>();

	private HighlightWrapper m_highlight_wrapper = new HighlightWrapper();

	private void Awake()
	{
		if ((bool)InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86.c57e4d4cd41f3be21d7e24a71aa08c6ba(this);
		}
		m_collisionManager = base.gameObject.AddComponent<CollisionManager>();
		if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
			m_titleMng = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.cd76850fff3f38531496e8d16b9a1db09();
		}
		MapObjectMark mapObjectMark = base.gameObject.AddComponent<MapObjectMark>();
		mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.NPC;
		mapObjectMark.iNPCID = m_npcId;
		mapObjectMark.cd26ab2539c05dcb4fe11c30d0792cfaf();
	}

	private void OnDestroy()
	{
		if (!InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86)
		{
			return;
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
			InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86.cf5212e6903ec0c0b27816142c32a2d13(this);
			return;
		}
	}

	private void Start()
	{
		m_collisionManager.cf19d18e7c73d5aff0a6786700d4e529d(GetComponent<Collider>());
		m_animManager = GetComponentInChildren<TownNPCAnimationManagerFSM>();
		cdbf4dac5cb41674f97488f3e977ffd47();
	}

	private void cdbf4dac5cb41674f97488f3e977ffd47()
	{
		m_questIdAsGiver.Clear();
		m_questIdAsReclaimer.Clear();
		List<Quest> list = new List<Quest>(c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cc1076a9627a18bd4b67cb59f4bee480a().Values);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].mGiverIdList.c1a84901a0a9ec83a0000feb026941d27(m_npcId))
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
				m_questIdAsGiver.Add(list[i].mId);
			}
			if (!list[i].mReclaimerIdList.c1a84901a0a9ec83a0000feb026941d27(m_npcId))
			{
				continue;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			m_questIdAsReclaimer.Add(list[i].mId);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	private void Update()
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
		{
			while (true)
			{
				switch (1)
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
		if (!m_isInitialized)
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
			if (c06ca0e618478c23eba3419653a19760f<TownNpcManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_npcSettings = c06ca0e618478c23eba3419653a19760f<TownNpcManager>.c5ee19dc8d4cccf5ae2de225410458b86.ccbe5d1e1f0775e8297e932586eaf130f(m_npcId);
				m_isInitialized = true;
				if (m_titleObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_titleMng.c56e7023c9b616eca4ee05b6fe564f13d(m_titleObj, new Vector3(0f, -0.05f, 0f), LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(m_npcSettings.m_nameId)), NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE);
				}
			}
		}
		if (m_titleObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_npcSettings != null)
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
				NpcTitleMgr.NPC_ICON_TYPE cc86191b3374befc421ca3c63c426e = c06ca0e618478c23eba3419653a19760f<TownNpcManager>.c5ee19dc8d4cccf5ae2de225410458b86.c4853bb633cd73a41e5f8cedf7e0668ae(m_npcId);
				m_titleMng.c80df4aae3a83f1614f1eb6e199fc4d52(m_titleObj, cc86191b3374befc421ca3c63c426e);
			}
		}
		cdee3d7a42cda6567728da40070be7d22();
	}

	private void cdee3d7a42cda6567728da40070be7d22()
	{
		if (c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
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
		bool ca6b449875175a0577177e0ee8f61fd0a = false;
		int num;
		if (NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cd885bd4479d20f52c6f209bf46f58b98)
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
			num = 0;
		}
		else
		{
			num = (int)c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.cf35cc45fb48a1252b0b5390ab7fd0162(this, ref ca6b449875175a0577177e0ee8f61fd0a);
		}
		E_HighlightType cf2353f300f592cfe033872788352a1be = (E_HighlightType)num;
		ca3a4e42c026dd118d96d9b26744e311b(cf2353f300f592cfe033872788352a1be, ca6b449875175a0577177e0ee8f61fd0a);
	}

	public bool c0c9ccf9f6d8cef1e33079d8eaf757b12(Ray cdb5cb253ef1339831696a37475f7233f, ref float c85645ac328a4c6e6c17d3da3be1e11f0)
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
					return false;
				}
			}
		}
		CollisionManager collisionManager = m_collisionManager;
		if (collisionManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			RaycastHit c3ced719b4780c1919017d69e82521ab;
			if (collisionManager.cd7c958f1e0eea8f346b44512bf8f1ea4(cdb5cb253ef1339831696a37475f7233f, out c3ced719b4780c1919017d69e82521ab, ref c85645ac328a4c6e6c17d3da3be1e11f0))
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		return false;
	}

	public virtual bool cafe5e3051445e4e581a42f13d84472ee()
	{
		return false;
	}

	public bool cab69fd15e36704ccac7469787a1570a0(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return false;
				}
			}
		}
		if (m_dialogCam != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_dialogCam.activeSelf)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return false;
					}
				}
			}
		}
		return true;
	}

	public void c4f2632dc55b69776a2b25638b97dedb6(Entity c5d720f6d007abb0c4a21d6a654e405bb, bool c1ccd82293d4f02d70adb2db899caf66f = false)
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
					return;
				}
			}
		}
		if (m_animManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_animManager.c979843b9afa58b1781f5d83769d1e4fb(m_animPending);
		}
		NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cca0442ccb623885a072dc61860e6655c().CurNPCCamera = m_dialogCam;
		NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cca0442ccb623885a072dc61860e6655c().CurNPCSetting = m_npcSettings;
		NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cca0442ccb623885a072dc61860e6655c().CurNPCAnimaMgr = m_animManager;
		bool flag = false;
		if (m_npcSettings != null)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			if (m_npcSettings.m_occupations != null)
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
				NpcOccupation[] occupations = m_npcSettings.m_occupations;
				int num = 0;
				while (true)
				{
					if (num < occupations.Length)
					{
						NpcOccupation npcOccupation = occupations[num];
						if (npcOccupation == NpcOccupation.Warehouse)
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
							flag = true;
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
			}
		}
		int num2;
		if (flag)
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
			num2 = 10;
		}
		else
		{
			num2 = 1;
		}
		NPC_UIFlowController.NPC_UIFlowState c4992f8f718608974873b2575dfecfda = (NPC_UIFlowController.NPC_UIFlowState)num2;
		NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(c4992f8f718608974873b2575dfecfda);
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cb534083a07db3bd6b74a38a62625f875(m_npcId);
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c069e3e12ab95ff8518fd20364724de3f(m_npcId);
		c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.cd76850fff3f38531496e8d16b9a1db09().c61079aece8524c509095139b0e9fa145(base.gameObject);
		c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c66f6f5c1adb9e048546e406c25cf43db();
	}

	public Vector3 c4cf00ced2bc60ae908904eb73692869f()
	{
		return base.transform.position;
	}

	public E_USE_TYPE c2aae0ed9fb0e39619e71e33a2e3fc48b()
	{
		return m_interactionType;
	}

	public void ca3a4e42c026dd118d96d9b26744e311b(E_HighlightType cf2353f300f592cfe033872788352a1be, bool cbf33c7320016d4f4097ef66731046d7b = false)
	{
		m_highlight_wrapper.ca3a4e42c026dd118d96d9b26744e311b(base.gameObject, cf2353f300f592cfe033872788352a1be, cbf33c7320016d4f4097ef66731046d7b);
	}

	private void OnRenderObject()
	{
		m_highlight_wrapper.OnRenderObject(base.gameObject);
	}
}
