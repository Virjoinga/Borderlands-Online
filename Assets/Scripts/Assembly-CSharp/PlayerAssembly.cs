using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class PlayerAssembly : MonoBehaviour, InstantiateManager.InstanciationClient
{
	private enum PlayerNetworkPeerType
	{
		Host = 0,
		Local = 1,
		Remote = 2
	}

	public enum ResourceGenerateType
	{
		BuildingKit = 0,
		Prefab = 1
	}

	public enum InstallType
	{
		Animator_3rd = 0,
		Animator_1st_Siren = 1,
		Animator_1st_Soldier = 2,
		Animator_1st_Berserker = 3,
		Animator_1st_Hunter = 4,
		FPSCamera = 5,
		TitleObj = 6,
		Default = 7
	}

	public struct ResourceInfo
	{
		public string mPath;

		public string mParentPath;

		public ResourceGenerateType mFrom;

		public InstallType mInstallType;

		public ResourceInfo(string c30ff8a534c59c4627deedbde3180f9a9, string c072d62d4edaec97afba470332ae2bbe8, ResourceGenerateType c28340657247ce0251dabfe62d39c3ff3, InstallType cf25fdf710bf6dbe4ea6ae2d583a29e9e)
		{
			mPath = c30ff8a534c59c4627deedbde3180f9a9;
			mParentPath = c072d62d4edaec97afba470332ae2bbe8;
			mFrom = c28340657247ce0251dabfe62d39c3ff3;
			mInstallType = cf25fdf710bf6dbe4ea6ae2d583a29e9e;
		}
	}

	public class AssemblyManual
	{
		public List<ResourceInfo> mResources = new List<ResourceInfo>();

		public InstallType c109bb530e9f08f94f9d2ab6328146efd(string cd99af21e22e356018b8f72d4a7e4872a)
		{
			using (List<ResourceInfo>.Enumerator enumerator = mResources.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ResourceInfo current = enumerator.Current;
					if (!(cd99af21e22e356018b8f72d4a7e4872a == current.mPath))
					{
						continue;
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
						return current.mInstallType;
					}
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						goto end_IL_0053;
					}
					continue;
					end_IL_0053:
					break;
				}
			}
			return InstallType.Default;
		}
	}

	private string sName_Root = "Root";

	private PlayerNetworkPeerType mNetPeer;

	private AssemblyManual mManual;

	private Dictionary<PlayerNetworkPeerType, AssemblyManual> mManuals = new Dictionary<PlayerNetworkPeerType, AssemblyManual>();

	private Dictionary<string, GameObject> mInstantiatedObjects = new Dictionary<string, GameObject>();

	private BuildingKitRender m_generator;

	private void Awake()
	{
		if (mManuals.Count != 0)
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
			c05eb90c1334884f2bb6b372ace237455(GetComponent<EntityPlayer>().m_AssemblyConfig);
			return;
		}
	}

	public void c3cd93b8cbfde89ff0736ee1900e85d93(bool c8deb2a5c44d4b73af31513cda816e756, AvatarType c4f09c39924e70788c7b055c1d1490578)
	{
		ccc9d3a38966dc10fedb531ea17d24611(c8deb2a5c44d4b73af31513cda816e756, c4f09c39924e70788c7b055c1d1490578);
		InstantiateManager.SpawnRequest cf4d0bdd2d52180fa1fb008e654aef5fb = default(InstantiateManager.SpawnRequest);
		using (List<ResourceInfo>.Enumerator enumerator = mManual.mResources.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ResourceInfo current = enumerator.Current;
				ResourceGenerateType mFrom = current.mFrom;
				if (mFrom != 0)
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
					if (mFrom != ResourceGenerateType.Prefab)
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
						continue;
					}
					cf4d0bdd2d52180fa1fb008e654aef5fb.m_prefabName = current.mPath;
					cf4d0bdd2d52180fa1fb008e654aef5fb.m_position = Vector3.zero;
					cf4d0bdd2d52180fa1fb008e654aef5fb.m_rotation = Quaternion.identity;
					cf4d0bdd2d52180fa1fb008e654aef5fb.m_group = InstantiateManager.NetworkReplicationGroup.InGame;
					cf4d0bdd2d52180fa1fb008e654aef5fb.m_spawnData = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
					cf4d0bdd2d52180fa1fb008e654aef5fb.m_spawnData[0] = NetworkManager.cf6124bd5254101846a57acc03f545846();
					cf4d0bdd2d52180fa1fb008e654aef5fb.m_callbackData = c5045159a57582d4577b6fa1bce364dca.c7088de59e49f7108f520cf7e0bae167e;
					cf4d0bdd2d52180fa1fb008e654aef5fb.m_isNetworkInstanciate = false;
					cf4d0bdd2d52180fa1fb008e654aef5fb.m_caller = this;
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<InstantiateManager>().cae70a8c23e816b09c686c0715bf1337c(cf4d0bdd2d52180fa1fb008e654aef5fb);
				}
				else
				{
					c1a5e5c4d1722e41cffdfa72f4923590e(current.mPath);
				}
			}
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
	}

	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
		mInstantiatedObjects[request.m_prefabName] = instance;
		c9a035706c5e77df82dbfa5a2b15e0949();
	}

	public bool cf268464cb332d61d2843c5afe02ae344()
	{
		if (m_generator == null)
		{
			while (true)
			{
				switch (6)
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
		EntityPlayer component = GetComponent<EntityPlayer>();
		if (component.c59c4cd4b0f739ff1266013913fd2588a() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (mNetPeer == PlayerNetworkPeerType.Local)
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
				BuildingKitRender c08e7e52da87900283104d9f3edfb = new BuildingKitRender(m_generator.ccf784a7191cc76b4e0c079ff7b1e7ac7);
				component.cb768055bae24957dda6e466dfabe8b02(c08e7e52da87900283104d9f3edfb);
			}
		}
		component.c002774b2c8a7098f9730129583e3722b(cc51c46f028b2d39e675051bf5d7c46a5(InstallType.Animator_3rd).transform.Find("displayObj"));
		c274dc7f44d62175a12523e9756ade9a7();
		return true;
	}

	private void c2a59056ba992de236d63d5acf5464aee(GameObject cd030fe6b7e8a43b5b62b1dc8e6d6988b)
	{
		PlayerThirdPersonAnimationManagerFSM component = base.transform.GetComponent<PlayerThirdPersonAnimationManagerFSM>();
		component.cfad7b897be050bfdbda2828a48ed8767(cd030fe6b7e8a43b5b62b1dc8e6d6988b);
		cd030fe6b7e8a43b5b62b1dc8e6d6988b.AddComponent<RootMotionController>();
		if (mNetPeer != PlayerNetworkPeerType.Local)
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
			cd5c4055be57450be01ec949697497407(cd030fe6b7e8a43b5b62b1dc8e6d6988b);
		}
		if (mNetPeer == PlayerNetworkPeerType.Remote)
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
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					(component.m_animationEventController = cd030fe6b7e8a43b5b62b1dc8e6d6988b.AddComponent<TownPlayerAnimationEventController>()).ce40f0b6c3f7714ac1c3daa73f26d266d();
					goto IL_00bd;
				}
			}
			(component.m_animationEventController = cd030fe6b7e8a43b5b62b1dc8e6d6988b.AddComponent<AnimationEventController>()).ce40f0b6c3f7714ac1c3daa73f26d266d();
		}
		goto IL_00bd;
		IL_00bd:
		GetComponent<CollisionManager>().cd93285db16841148ed53a5bbeb35cf20(!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51());
		Rigidbody[] componentsInChildren = cd030fe6b7e8a43b5b62b1dc8e6d6988b.GetComponentsInChildren<Rigidbody>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].useGravity = false;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	private void cd5c4055be57450be01ec949697497407(GameObject c92be84c2929e14255cef0634f9677b3f)
	{
		GetComponent<EntityPlayer>().m_skeleton = c92be84c2929e14255cef0634f9677b3f.AddComponent<Skeleton>();
		StartCoroutine(GetComponent<EntityPlayer>().c422d603e64552d7acc420ac5ab4616d4());
	}

	private void c274dc7f44d62175a12523e9756ade9a7()
	{
		GameObject gameObject = cc51c46f028b2d39e675051bf5d7c46a5(InstallType.Animator_3rd);
		if (!(gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
			{
				skinnedMeshRenderer.enabled = false;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				VFXManager componentInChildren = gameObject.GetComponentInChildren<VFXManager>();
				if (!(componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					UnityEngine.Object.Destroy(componentInChildren);
					return;
				}
			}
		}
	}

	private void cf820a8c181ce0437945e8136f1f89fcf(GameObject c4e4982777fd2dba1e4c3aa662b8c4fc9)
	{
		base.transform.GetComponent<PlayerThirdPersonAnimationManagerFSM>().c5dc1b6879970886d76af1f53e75eb849(c4e4982777fd2dba1e4c3aa662b8c4fc9.GetComponent<Animator>());
		c274dc7f44d62175a12523e9756ade9a7();
		cd5c4055be57450be01ec949697497407(c4e4982777fd2dba1e4c3aa662b8c4fc9);
		EntityPlayer component = GetComponent<EntityPlayer>();
		Skeleton component2 = c4e4982777fd2dba1e4c3aa662b8c4fc9.GetComponent<Skeleton>();
		BadAssFPSCamera component3 = cc51c46f028b2d39e675051bf5d7c46a5(InstallType.FPSCamera).GetComponent<BadAssFPSCamera>();
		component3.ccc9d3a38966dc10fedb531ea17d24611(component, component2.c709750b2d9310309de8766e1f010dd3e());
		component.c66cb355a7c605747a1511357ef03c679(component3);
		cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.c3ec6c8a3b3017de44fe7215da4f4ba2d(component3.transform);
		c2f5157c22a121931c1306237f602f5cb(c4e4982777fd2dba1e4c3aa662b8c4fc9, component3);
		GetComponent<PlayerControllerLocal>().c3eaf7e24e28d40faca678a6afc594878(component2.caf8ace1abab4e578d22e1156ba53dd04(), component2.c5f221d74056f6e418f625fb75143c9dc(), component2.c44a36eec8bfed33afbb5a63e5aae6c2f());
		component3.GetComponent<Camera>().enabled = true;
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			GetComponent<CollisionManager>().c240cef3c15ad5ab6ce89665d079c3bc2();
			return;
		}
	}

	private void c81dec30ed0ed8bf1915b705a84746eb0(GameObject c1087f89b8b2555789d1360401784b8ff)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c7ae0e7b8e80603cfc335a2df380802c8();
		c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ca5bd80f5ff7a2e9ca939a6283399ec2d().c62d6e942d709562f158104952dad345a(c1087f89b8b2555789d1360401784b8ff);
		c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ca5bd80f5ff7a2e9ca939a6283399ec2d().c25075cfed962291f0d0b630ce9ee8669();
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1570506bf0b326e191d0406037cb4fef();
	}

	private void c073c25eb6261a0c409588a3cd32f2381(string cd99af21e22e356018b8f72d4a7e4872a, GameObject cebae66039aadeac8deb1211786332a72)
	{
		Transform parent = c250783c219e5191f706df9ed222f6b38(cd99af21e22e356018b8f72d4a7e4872a);
		cebae66039aadeac8deb1211786332a72.transform.parent = parent;
		cebae66039aadeac8deb1211786332a72.transform.localPosition = Vector3.zero;
		cebae66039aadeac8deb1211786332a72.transform.localRotation = Quaternion.identity;
	}

	private void c9a035706c5e77df82dbfa5a2b15e0949()
	{
		if (!c3985d50d680053abe814fe1703d6da25())
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
		using (Dictionary<string, GameObject>.Enumerator enumerator = mInstantiatedObjects.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, GameObject> current = enumerator.Current;
				string key = current.Key;
				GameObject value = current.Value;
				switch (mManual.c109bb530e9f08f94f9d2ab6328146efd(key))
				{
				case InstallType.Animator_3rd:
					c073c25eb6261a0c409588a3cd32f2381(key, value);
					c2a59056ba992de236d63d5acf5464aee(value);
					break;
				case InstallType.Animator_1st_Siren:
					cf820a8c181ce0437945e8136f1f89fcf(value);
					c073c25eb6261a0c409588a3cd32f2381(key, value);
					break;
				case InstallType.Animator_1st_Soldier:
					cf820a8c181ce0437945e8136f1f89fcf(value);
					c073c25eb6261a0c409588a3cd32f2381(key, value);
					break;
				case InstallType.Animator_1st_Berserker:
					cf820a8c181ce0437945e8136f1f89fcf(value);
					c073c25eb6261a0c409588a3cd32f2381(key, value);
					break;
				case InstallType.Animator_1st_Hunter:
					cf820a8c181ce0437945e8136f1f89fcf(value);
					c073c25eb6261a0c409588a3cd32f2381(key, value);
					break;
				case InstallType.FPSCamera:
					c81dec30ed0ed8bf1915b705a84746eb0(value);
					break;
				default:
					c073c25eb6261a0c409588a3cd32f2381(key, value);
					break;
				}
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_00f6;
				}
				continue;
				end_IL_00f6:
				break;
			}
		}
		c62f73f3107dd8c7a49199a11cc8df4bb();
	}

	private void c62f73f3107dd8c7a49199a11cc8df4bb()
	{
		bool cb3e620f7e2e0ab93c5a062a93fd9a = mNetPeer != PlayerNetworkPeerType.Remote;
		PlayerThirdPersonAnimationManagerFSM component = GetComponent<PlayerThirdPersonAnimationManagerFSM>();
		EntityPlayer component2 = GetComponent<EntityPlayer>();
		if (mNetPeer == PlayerNetworkPeerType.Local)
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
			BuildingKitRender c08e7e52da87900283104d9f3edfb = new BuildingKitRender(m_generator.ccf784a7191cc76b4e0c079ff7b1e7ac7);
			component2.cb768055bae24957dda6e466dfabe8b02(c08e7e52da87900283104d9f3edfb);
		}
		component.cd6f933bd268aaf1967c46349307f50eb(cb3e620f7e2e0ab93c5a062a93fd9a);
		component.ce9ffc91c96fab37637f0807e22fe4ba4();
		component2.ccaf53be8b86b7016efd6970ff8c92ad3.OnPostAssembly();
		component2.ca85441e335aa8deaaaf1078789d9a19b(cc51c46f028b2d39e675051bf5d7c46a5(InstallType.TitleObj));
		if (!component2.caac907d451029d68503484a63934c93f())
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
			component2.cbe6462ca5e54bdba2f8ce0af7023cd3a();
		}
		component2.c002774b2c8a7098f9730129583e3722b(cc51c46f028b2d39e675051bf5d7c46a5(InstallType.Animator_3rd).transform.Find("displayObj"));
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			if (!NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cd885bd4479d20f52c6f209bf46f58b98)
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
				component2.c6a81925b944ea7d0f6008bd83da0380d(true);
				return;
			}
		}
	}

	private void c1a5e5c4d1722e41cffdfa72f4923590e(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		AvatarDNA avatarDna = GetComponent<EntityPlayer>().cd95354b53e674ec7dc9594e66e4d316f().m_avatarDna;
		uint num = avatarDna.m_buildingUnit.bkID;
		if (num == 0)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "bkID is 0 in InstantiatedByBuildingKit");
			num = BuildingKitManager.c06dee53a8ffacfe3c3e5815489a62508("CHR", "Siren");
		}
		BuildingKitRender buildingKitRender = new BuildingKitRender(num);
		if (!BuildingKitManager.OnlineHostMinResMode)
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
			buildingKitRender.ccf784a7191cc76b4e0c079ff7b1e7ac7 = avatarDna.m_buildingUnit;
		}
		m_generator = buildingKitRender;
		GameObject value = buildingKitRender.c3309affdc4b59cba5f457bbaec5f0762();
		mInstantiatedObjects[cd99af21e22e356018b8f72d4a7e4872a] = value;
	}

	private void OnAssetBundleLoaded(object param = null)
	{
	}

	private Transform c250783c219e5191f706df9ed222f6b38(string ca3a295c7d8d99671eb9e891588f5da9e)
	{
		string text = string.Empty;
		using (List<ResourceInfo>.Enumerator enumerator = mManual.mResources.GetEnumerator())
		{
			while (true)
			{
				if (enumerator.MoveNext())
				{
					ResourceInfo current = enumerator.Current;
					if (!(current.mPath == ca3a295c7d8d99671eb9e891588f5da9e))
					{
						continue;
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
						text = current.mParentPath;
						break;
					}
					break;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						goto end_IL_005e;
					}
					continue;
					end_IL_005e:
					break;
				}
				break;
			}
		}
		if (text == sName_Root)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return base.gameObject.transform;
				}
			}
		}
		using (Dictionary<string, GameObject>.Enumerator enumerator2 = mInstantiatedObjects.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				KeyValuePair<string, GameObject> current2 = enumerator2.Current;
				if (!(current2.Key == text))
				{
					continue;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					return current2.Value.transform;
				}
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					goto end_IL_00f7;
				}
				continue;
				end_IL_00f7:
				break;
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "GetParent() error");
		return null;
	}

	private void c814348ba2edadb2188c9332572412a69(PlayerNetworkPeerType ccc74f835d6632b9f08b459cb4a84569e, AvatarType c4f09c39924e70788c7b055c1d1490578)
	{
		if (ccc74f835d6632b9f08b459cb4a84569e == PlayerNetworkPeerType.Local)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					mManual = new AssemblyManual();
					using (List<ResourceInfo>.Enumerator enumerator = mManuals[ccc74f835d6632b9f08b459cb4a84569e].mResources.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ResourceInfo current = enumerator.Current;
							if (current.mInstallType == InstallType.Animator_1st_Siren)
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
								if (c4f09c39924e70788c7b055c1d1490578 == AvatarType.SIREN)
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
									mManual.mResources.Add(current);
								}
							}
							else if (current.mInstallType == InstallType.Animator_1st_Soldier)
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
								if (c4f09c39924e70788c7b055c1d1490578 == AvatarType.SOLDIER)
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
									mManual.mResources.Add(current);
								}
							}
							else if (current.mInstallType == InstallType.Animator_1st_Berserker)
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
								if (c4f09c39924e70788c7b055c1d1490578 == AvatarType.BERSERKER)
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
									mManual.mResources.Add(current);
								}
							}
							else if (current.mInstallType == InstallType.Animator_1st_Hunter)
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
								if (c4f09c39924e70788c7b055c1d1490578 == AvatarType.HUNTER)
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
									mManual.mResources.Add(current);
								}
							}
							else
							{
								mManual.mResources.Add(current);
							}
						}
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								return;
							}
						}
					}
				}
				}
			}
		}
		mManual = mManuals[ccc74f835d6632b9f08b459cb4a84569e];
	}

	private void OnDestroy()
	{
		using (Dictionary<string, GameObject>.Enumerator enumerator = mInstantiatedObjects.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, GameObject> current = enumerator.Current;
				if (!(current.Value != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				UnityEngine.Object.Destroy(current.Value);
			}
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
	}

	private void ccc9d3a38966dc10fedb531ea17d24611(bool c8deb2a5c44d4b73af31513cda816e756, AvatarType c4f09c39924e70788c7b055c1d1490578)
	{
		mNetPeer = cc4121571fa1eb7037b8cb200bece830e(c8deb2a5c44d4b73af31513cda816e756);
		c814348ba2edadb2188c9332572412a69(mNetPeer, c4f09c39924e70788c7b055c1d1490578);
		using (Dictionary<string, GameObject>.Enumerator enumerator = mInstantiatedObjects.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, GameObject> current = enumerator.Current;
				if (!(current.Value != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				UnityEngine.Object.Destroy(current.Value);
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					goto end_IL_0079;
				}
				continue;
				end_IL_0079:
				break;
			}
		}
		mInstantiatedObjects.Clear();
		using (List<ResourceInfo>.Enumerator enumerator2 = mManual.mResources.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				ResourceInfo current2 = enumerator2.Current;
				mInstantiatedObjects.Add(current2.mPath, null);
			}
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

	private PlayerNetworkPeerType cc4121571fa1eb7037b8cb200bece830e(bool c8deb2a5c44d4b73af31513cda816e756)
	{
		if (c8deb2a5c44d4b73af31513cda816e756)
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
					return PlayerNetworkPeerType.Local;
				}
			}
		}
		return PlayerNetworkPeerType.Remote;
	}

	private bool c3985d50d680053abe814fe1703d6da25()
	{
		using (Dictionary<string, GameObject>.ValueCollection.Enumerator enumerator = mInstantiatedObjects.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				GameObject current = enumerator.Current;
				if (!(current == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
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
					return false;
				}
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_0052;
				}
				continue;
				end_IL_0052:
				break;
			}
		}
		return true;
	}

	private GameObject cc51c46f028b2d39e675051bf5d7c46a5(InstallType c4f09c39924e70788c7b055c1d1490578)
	{
		using (List<ResourceInfo>.Enumerator enumerator = mManual.mResources.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ResourceInfo current = enumerator.Current;
				if (current.mInstallType != c4f09c39924e70788c7b055c1d1490578)
				{
					continue;
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
					return mInstantiatedObjects[current.mPath];
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					goto end_IL_005e;
				}
				continue;
				end_IL_005e:
				break;
			}
		}
		return null;
	}

	private void c2f5157c22a121931c1306237f602f5cb(GameObject ccf24681862bae286c19d5c9b16296be5, BadAssFPSCamera c1087f89b8b2555789d1360401784b8ff)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
		{
			while (true)
			{
				switch (6)
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
		Shader shader = Shader.Find("Custom/ClearDepthFov");
		if (shader == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (c1087f89b8b2555789d1360401784b8ff == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		WeaponCameraControl componentInChildren = c1087f89b8b2555789d1360401784b8ff.GetComponentInChildren<WeaponCameraControl>();
		if (componentInChildren == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		SkinnedMeshRenderer componentInChildren2 = ccf24681862bae286c19d5c9b16296be5.GetComponentInChildren<SkinnedMeshRenderer>();
		EntityPlayer component = GetComponent<EntityPlayer>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			component.m_fpHandMaterial = UnityEngine.Object.Instantiate(componentInChildren2.material) as Material;
			component.c7c26d0231ca6afec48218d109bffb68d(false);
		}
		componentInChildren2.material.shader = shader;
		componentInChildren2.material.SetMatrix("_ProjMat", componentInChildren.cd392a2edecfcb3ad1e1ec6bcd9e0afde());
	}

	private void c05eb90c1334884f2bb6b372ace237455(TextAsset ce10ef6ffb5efd846bbc214527cf6fa6d)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(ce10ef6ffb5efd846bbc214527cf6fa6d.text);
		string[] names = Enum.GetNames(typeof(PlayerNetworkPeerType));
		foreach (string value in names)
		{
			PlayerNetworkPeerType key = (PlayerNetworkPeerType)(int)Enum.Parse(typeof(PlayerNetworkPeerType), value);
			AssemblyManual assemblyManual = new AssemblyManual();
			XmlNode xmlNode = xmlDocument.GetElementsByTagName(value)[0];
			c90ff74a4144d6ab741ed9297d7ef8e4e(xmlNode.FirstChild, assemblyManual);
			mManuals.Add(key, assemblyManual);
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
			return;
		}
	}

	private static void c90ff74a4144d6ab741ed9297d7ef8e4e(XmlNode c50c6ea638921e561e64ee9ed0a7cbcf3, AssemblyManual c69ae1b9ae073bc3fc0ac14647054a894)
	{
		IEnumerator enumerator = c50c6ea638921e561e64ee9ed0a7cbcf3.ChildNodes.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				string value = xmlNode.Attributes["Path"].Value;
				string value2 = c50c6ea638921e561e64ee9ed0a7cbcf3.Attributes["Path"].Value;
				string value3 = xmlNode.Attributes["GenerateType"].Value;
				string value4 = xmlNode.Attributes["InstallType"].Value;
				c69ae1b9ae073bc3fc0ac14647054a894.mResources.Add(new ResourceInfo(value, value2, (ResourceGenerateType)(int)Enum.Parse(typeof(ResourceGenerateType), value3), (InstallType)(int)Enum.Parse(typeof(InstallType), value4)));
				c90ff74a4144d6ab741ed9297d7ef8e4e(xmlNode, c69ae1b9ae073bc3fc0ac14647054a894);
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
				return;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						goto end_IL_0110;
					}
					continue;
					end_IL_0110:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
	}
}
