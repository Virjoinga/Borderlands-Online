using System.Collections.Generic;
using A;
using UnityEngine;
using XsdSettings;

public class TownInstanceSelectionTrigger : MonoBehaviour, InteractionClient
{
	public enum SelectionView
	{
		Instance = 0,
		Town = 1
	}

	public SelectionView m_selectionView;

	protected CollisionManager m_collisionManager;

	protected List<int> m_iInstanceIDList = new List<int>();

	protected MapObjectMark m_mapObjMark;

	protected Transform m_childEyeIcon;

	private HighlightWrapper m_highlight_wrapper = new HighlightWrapper();

	private void Awake()
	{
		if ((bool)InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86.c57e4d4cd41f3be21d7e24a71aa08c6ba(this);
		}
		m_collisionManager = base.gameObject.AddComponent<CollisionManager>();
	}

	private void Start()
	{
		m_collisionManager.cf19d18e7c73d5aff0a6786700d4e529d(GetComponent<Collider>());
		c577b8a45a9c47c70af791f50eac43e20();
	}

	private void OnLevelWasLoaded(int iLevel)
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			if (m_selectionView != 0)
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
				QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().cd35ec9bc0560c63369b10ad39d5c179b(ce135a3a51fc7a19afcdd3081b0a7cc53);
				m_iInstanceIDList = TownInstanceSelectionControl.c0010e81ac585c9de1e18e6b8c90850de();
				m_childEyeIcon = base.transform.Find("PRO_Quest_eye_catch_icon");
				return;
			}
		}
	}

	private void OnDestroy()
	{
		QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().c7c83d311f62c1a786291ae4fe56d1bd3(ce135a3a51fc7a19afcdd3081b0a7cc53);
	}

	protected void ce135a3a51fc7a19afcdd3081b0a7cc53(Dictionary<int, QuestProgress> cd563a3564d781de51750031f869a03aa)
	{
		if (m_iInstanceIDList == null)
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
					return;
				}
			}
		}
		bool flag = false;
		using (Dictionary<int, QuestProgress>.ValueCollection.Enumerator enumerator = cd563a3564d781de51750031f869a03aa.Values.GetEnumerator())
		{
			while (true)
			{
				if (enumerator.MoveNext())
				{
					QuestProgress current = enumerator.Current;
					if (current.mStatus != QuestState.InProgress)
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
						continue;
					}
					Quest quest = c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0c8ccd79e03879ffc929ddac44fbc31c(current.mQuestId);
					if (quest == null)
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
					if (!quest.mIsBoundInstance)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							flag = true;
							break;
						}
						break;
					}
					int[] mBoundInstanceList = quest.mBoundInstanceList;
					int num = 0;
					while (true)
					{
						if (num < mBoundInstanceList.Length)
						{
							int item = mBoundInstanceList[num];
							if (m_iInstanceIDList.Contains(item))
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
					if (!flag)
					{
						continue;
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							goto end_IL_00e5;
						}
						continue;
						end_IL_00e5:
						break;
					}
					break;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						goto end_IL_00ff;
					}
					continue;
					end_IL_00ff:
					break;
				}
				break;
			}
		}
		if (m_childEyeIcon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_childEyeIcon.gameObject.activeInHierarchy != flag)
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
				m_childEyeIcon.gameObject.SetActive(flag);
			}
		}
		if (!flag)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (m_mapObjMark == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								c577b8a45a9c47c70af791f50eac43e20();
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (!(m_mapObjMark != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			Object.Destroy(m_mapObjMark);
			m_mapObjMark = c9fc073e905a817f354312f6329e15773.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	protected void c577b8a45a9c47c70af791f50eac43e20()
	{
		m_mapObjMark = base.gameObject.AddComponent<MapObjectMark>();
		SelectionView selectionView = m_selectionView;
		if (selectionView != 0)
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
			if (selectionView != SelectionView.Town)
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
			}
			else
			{
				m_mapObjMark.ObjType = UIMapDataManager.MiniMapObjectType.WorldMapDevice;
			}
		}
		else
		{
			m_mapObjMark.ObjType = UIMapDataManager.MiniMapObjectType.TownExit;
		}
		m_mapObjMark.cd26ab2539c05dcb4fe11c30d0792cfaf();
	}

	public bool c0c9ccf9f6d8cef1e33079d8eaf757b12(Ray cdb5cb253ef1339831696a37475f7233f, ref float c85645ac328a4c6e6c17d3da3be1e11f0)
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
					return false;
				}
			}
		}
		CollisionManager collisionManager = m_collisionManager;
		if (collisionManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			RaycastHit c3ced719b4780c1919017d69e82521ab;
			if (collisionManager.cd7c958f1e0eea8f346b44512bf8f1ea4(cdb5cb253ef1339831696a37475f7233f, out c3ced719b4780c1919017d69e82521ab, ref c85645ac328a4c6e6c17d3da3be1e11f0))
			{
				while (true)
				{
					switch (6)
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
		if (WorldMapSelectionController.c201e69461401637f68794a86ca99b782())
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		SelectionView selectionView = m_selectionView;
		if (selectionView != 0)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (selectionView != SelectionView.Town)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					return true;
				}
			}
		}
		return !c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceView>().c150264a18c2cb408479d3f072cac8cc1;
	}

	public void c4f2632dc55b69776a2b25638b97dedb6(Entity c5d720f6d007abb0c4a21d6a654e405bb, bool c1ccd82293d4f02d70adb2db899caf66f = false)
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
		SelectionView selectionView = m_selectionView;
		if (selectionView != 0)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (selectionView != SelectionView.Town)
					{
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WorldMapSelectView>().c150264a18c2cb408479d3f072cac8cc1 = true;
					return;
				}
			}
		}
		if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c2930d24fac8ce6b56448c4a0665627c0())
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceView>().c150264a18c2cb408479d3f072cac8cc1 = true;
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Instance_teammate_feedback")), c2bfec9a57278d156490c5b819b7c3d8c, c68ab6f5d12f16a1d54aa92651de73463.c7088de59e49f7108f520cf7e0bae167e);
	}

	public void c2bfec9a57278d156490c5b819b7c3d8c()
	{
	}

	public bool cafe5e3051445e4e581a42f13d84472ee()
	{
		return false;
	}

	public Vector3 c4cf00ced2bc60ae908904eb73692869f()
	{
		return base.transform.position;
	}

	public E_USE_TYPE c2aae0ed9fb0e39619e71e33a2e3fc48b()
	{
		return E_USE_TYPE.E_OPEN;
	}

	private void Update()
	{
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
				switch (1)
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

	public void ca3a4e42c026dd118d96d9b26744e311b(E_HighlightType cf2353f300f592cfe033872788352a1be, bool cbf33c7320016d4f4097ef66731046d7b = false)
	{
		if (!(base.transform.parent != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(base.transform.parent.gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_highlight_wrapper.c3fa255c4c719e308e0d4504a40033428(base.transform.parent.gameObject, cf2353f300f592cfe033872788352a1be, cbf33c7320016d4f4097ef66731046d7b);
				return;
			}
		}
	}

	private void OnRenderObject()
	{
		m_highlight_wrapper.OnRenderObject(base.gameObject);
	}
}
