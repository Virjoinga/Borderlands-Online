using A;
using UnityEngine;

public class TeleportToTownTrigger : MonoBehaviour, InteractionClient
{
	private CollisionManager m_collisionManager;

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
	}

	private void OnDestroy()
	{
		if ((bool)InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86.cf5212e6903ec0c0b27816142c32a2d13(this);
		}
		m_collisionManager = c9f8024b034af81b611bc35895e5d22f8.c7088de59e49f7108f520cf7e0bae167e;
	}

	private void Start()
	{
		m_collisionManager.cf19d18e7c73d5aff0a6786700d4e529d(GetComponent<Collider>());
		MapObjectMark mapObjectMark = base.gameObject.AddComponent<MapObjectMark>();
		mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.InstanceExitOpen;
		mapObjectMark.cd26ab2539c05dcb4fe11c30d0792cfaf();
	}

	public bool c0c9ccf9f6d8cef1e33079d8eaf757b12(Ray cdb5cb253ef1339831696a37475f7233f, ref float c85645ac328a4c6e6c17d3da3be1e11f0)
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
		{
			while (true)
			{
				switch (7)
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
				switch (3)
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
					switch (1)
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
				switch (7)
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
		int result;
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c3a7a710a3394a641829894c7a3254abe())
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
			result = ((!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().c150264a18c2cb408479d3f072cac8cc1) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public void c4f2632dc55b69776a2b25638b97dedb6(Entity c5d720f6d007abb0c4a21d6a654e405bb, bool c1ccd82293d4f02d70adb2db899caf66f = false)
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
					return;
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().c150264a18c2cb408479d3f072cac8cc1)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("F2_Warning")), cb448a13457b461e53aba77f849b83b5d, c7d651aaa1089facff09b5f4a0e4cae3b);
			return;
		}
	}

	private void cb448a13457b461e53aba77f849b83b5d()
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWrapupView>().c6c0790cec120a0223fe798ec4a63029a();
		SessionInfo.c5ee19dc8d4cccf5ae2de225410458b86.c7a96130ad6e9df15e0a2a70215ea14b9(OnlineService.s_characterId);
	}

	private void c7d651aaa1089facff09b5f4a0e4cae3b()
	{
	}

	public bool cafe5e3051445e4e581a42f13d84472ee()
	{
		return false;
	}

	public Vector3 c4cf00ced2bc60ae908904eb73692869f()
	{
		if (base.gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return Vector3.zero;
				}
			}
		}
		return base.gameObject.transform.position;
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
			switch (2)
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
				switch (1)
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
