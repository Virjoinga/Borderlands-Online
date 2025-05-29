using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using UnityEngine;
using XsdSettings;

public class UIAvatarManager : MonoBehaviour
{
	private const string MODEL_SOLDIER_NAME = "CHR_Soldier_Skeleton_01";

	private const string MODEL_SIREN_NAME = "CHR_Siren_Skeleton_01";

	private const string MODEL_BERSERKER_NAME = "CHR_Berserker_Skeleton_01";

	private const string MODEL_HUNTER_NAME = "CHR_Hunter_Skeleton_01";

	private int m_waitToPlayExtraIdle = -1;

	private Animator m_playerAnimator;

	public int BerserkerWeaponID = 2;

	public int HunterWeaponID = 3;

	public int SirenWeaponID = 4;

	public int SoldierWeaponID = 5;

	public int ClassSelectIdle_Min = 100;

	public int ClassSelectIdle_Max = 300;

	public int CustomizeBodyIdle_Min = 100;

	public int CustomizeBodyIdle_Max = 200;

	public int CustomizeHeadIdle_Min = 50;

	public int CustomizeHeadIdle_Max = 100;

	protected Dictionary<AvatarType, FE_ClassInfo> _mapClassInfo;

	[CompilerGenerated]
	private static Dictionary<string, int> _003C_003Ef__switch_0024map2;

	[CompilerGenerated]
	private static Dictionary<string, int> _003C_003Ef__switch_0024map3;

	public UIAvatarManager()
	{
		_mapClassInfo = new Dictionary<AvatarType, FE_ClassInfo>
		{
			{
				AvatarType.SIREN,
				new FE_ClassInfo(AvatarType.SIREN)
			},
			{
				AvatarType.SOLDIER,
				new FE_ClassInfo(AvatarType.SOLDIER)
			},
			{
				AvatarType.BERSERKER,
				new FE_ClassInfo(AvatarType.BERSERKER)
			},
			{
				AvatarType.HUNTER,
				new FE_ClassInfo(AvatarType.HUNTER)
			}
		};
	}

	private void Awake()
	{
	}

	public FE_ClassInfo c776f10275205e9a738d414973e864515(AvatarType c5943e4322e38343cbc5579c0e1d46b95)
	{
		return _mapClassInfo[c5943e4322e38343cbc5579c0e1d46b95];
	}

	private SkinnedMeshRenderer c8508eb359e57bf7ef9712c8a0fcd50ff(GameObject c9b22b99c4009be721768a81dd80c0f38)
	{
		return c9b22b99c4009be721768a81dd80c0f38.GetComponentInChildren<SkinnedMeshRenderer>();
	}

	public void c8d95388d9b43fc5f4a94acb4d48ec519()
	{
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>(true);
		if (componentsInChildren == null)
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
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			string text = componentsInChildren[i].gameObject.name;
			if (text == null)
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
				break;
			}
			if (_003C_003Ef__switch_0024map2 == null)
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
				Dictionary<string, int> dictionary = new Dictionary<string, int>(4);
				dictionary.Add("CHR_Berserker_Skeleton_01", 0);
				dictionary.Add("CHR_Soldier_Skeleton_01", 0);
				dictionary.Add("CHR_Siren_Skeleton_01", 0);
				dictionary.Add("CHR_Hunter_Skeleton_01", 0);
				_003C_003Ef__switch_0024map2 = dictionary;
			}
			int value;
			if (!_003C_003Ef__switch_0024map2.TryGetValue(text, out value))
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
			if (value != 0)
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
			}
			else
			{
				componentsInChildren[i].gameObject.SetActive(false);
			}
		}
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

	public IEnumerator cd93285db16841148ed53a5bbeb35cf20()
	{
		AvatarGeneratorService avatarGeneratorService = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<AvatarGeneratorService>();
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>(true);
		foreach (Transform transform in componentsInChildren)
		{
			string text = transform.gameObject.name;
			if (text != null)
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
				if (_003C_003Ef__switch_0024map3 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(4);
					dictionary.Add("CHR_Berserker_Skeleton_01", 0);
					dictionary.Add("CHR_Soldier_Skeleton_01", 1);
					dictionary.Add("CHR_Siren_Skeleton_01", 2);
					dictionary.Add("CHR_Hunter_Skeleton_01", 3);
					_003C_003Ef__switch_0024map3 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map3.TryGetValue(text, out value))
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
					switch (value)
					{
					case 0:
					{
						if (_mapClassInfo[AvatarType.BERSERKER].buildingKitRender != null)
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
							continue;
						}
						BuildingKitRender kitRender4 = new BuildingKitRender("CHR", "Berserker");
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(0, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(1, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(2, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(3, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(4, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(5, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(6, 0);
						_mapClassInfo[AvatarType.BERSERKER].buildingKitRender = kitRender4;
						yield return StartCoroutine(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad618dcc0547ebee513a30332046d81f(kitRender4.ca8a5af6eb0b2329ae9c0880a0712d3b8()));
						transform.gameObject.SetActive(true);
						GameObject kitObj = kitRender4.c3309affdc4b59cba5f457bbaec5f0762();
						kitObj.AddComponent<Skeleton>();
						string controllerPath = "Entities/Player_Mecanim/Berserker_3rd_Controller_UI";
						m_playerAnimator = kitObj.GetComponent<Animator>();
						if (m_playerAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							m_playerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Object.Instantiate(Resources.Load(controllerPath));
						}
						kitObj.transform.parent = transform;
						kitObj.transform.localPosition = Vector3.zero;
						kitObj.transform.localRotation = Quaternion.identity;
						Rigidbody[] rigs = kitObj.GetComponentsInChildren<Rigidbody>();
						for (int i = 0; i < rigs.Length; i++)
						{
							rigs[i].isKinematic = true;
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
						yield return StartCoroutine(avatarGeneratorService.c55b4878c03d9f87b4d34de1f79de2705(c8845f28fdcd69fafc8894476a17e43db: c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<WeaponGeneratorService>().c4e0dae6a16a8a80ddb5214a896b9df58(c430564e9708ee538fd1aa80f80ecffbb(AvatarType.BERSERKER)), cfe0a1153f61dcdf419049830449301da: kitObj.gameObject, c3003c6194f9f06563fb78310318e3417: 3));
						transform.gameObject.GetComponent<ModelFadeIn>().cd93285db16841148ed53a5bbeb35cf20();
						transform.gameObject.SetActive(false);
						_mapClassInfo[AvatarType.BERSERKER].classModel = transform.gameObject;
						break;
					}
					case 1:
					{
						if (_mapClassInfo[AvatarType.SOLDIER].buildingKitRender != null)
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
							continue;
						}
						BuildingKitRender kitRender4 = new BuildingKitRender("CHR", "Soldier");
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(0, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(1, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(2, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(3, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(4, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(5, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(6, 0);
						_mapClassInfo[AvatarType.SOLDIER].buildingKitRender = kitRender4;
						yield return StartCoroutine(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad618dcc0547ebee513a30332046d81f(kitRender4.ca8a5af6eb0b2329ae9c0880a0712d3b8()));
						transform.gameObject.SetActive(true);
						GameObject kitObj2 = kitRender4.c3309affdc4b59cba5f457bbaec5f0762();
						kitObj2.AddComponent<Skeleton>();
						string controllerPath2 = "Entities/Player_Mecanim/Soldier_3rd_Controller_UI";
						m_playerAnimator = kitObj2.GetComponent<Animator>();
						if (m_playerAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							m_playerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Object.Instantiate(Resources.Load(controllerPath2));
						}
						kitObj2.transform.parent = transform;
						kitObj2.transform.localPosition = Vector3.zero;
						kitObj2.transform.localRotation = Quaternion.identity;
						Rigidbody[] rigs2 = kitObj2.GetComponentsInChildren<Rigidbody>();
						for (int j = 0; j < rigs2.Length; j++)
						{
							rigs2[j].isKinematic = true;
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
						yield return StartCoroutine(avatarGeneratorService.c55b4878c03d9f87b4d34de1f79de2705(c8845f28fdcd69fafc8894476a17e43db: c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<WeaponGeneratorService>().c4e0dae6a16a8a80ddb5214a896b9df58(c430564e9708ee538fd1aa80f80ecffbb(AvatarType.SOLDIER)), cfe0a1153f61dcdf419049830449301da: kitObj2.gameObject, c3003c6194f9f06563fb78310318e3417: 3));
						transform.gameObject.GetComponent<ModelFadeIn>().cd93285db16841148ed53a5bbeb35cf20();
						transform.gameObject.SetActive(false);
						_mapClassInfo[AvatarType.SOLDIER].classModel = transform.gameObject;
						break;
					}
					case 2:
					{
						if (_mapClassInfo[AvatarType.SIREN].buildingKitRender != null)
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
							continue;
						}
						BuildingKitRender kitRender4 = new BuildingKitRender("CHR", "Siren");
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(0, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(1, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(2, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(3, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(4, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(5, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(6, 0);
						_mapClassInfo[AvatarType.SIREN].buildingKitRender = kitRender4;
						yield return StartCoroutine(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad618dcc0547ebee513a30332046d81f(kitRender4.ca8a5af6eb0b2329ae9c0880a0712d3b8()));
						transform.gameObject.SetActive(true);
						GameObject kitObj3 = kitRender4.c3309affdc4b59cba5f457bbaec5f0762();
						kitObj3.AddComponent<Skeleton>();
						string controllerPath3 = "Entities/Player_Mecanim/Siren_3rd_Controller_UI";
						m_playerAnimator = kitObj3.GetComponent<Animator>();
						if (m_playerAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							m_playerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Object.Instantiate(Resources.Load(controllerPath3));
						}
						kitObj3.transform.parent = transform;
						kitObj3.transform.localPosition = Vector3.zero;
						kitObj3.transform.localRotation = Quaternion.identity;
						Rigidbody[] rigs3 = kitObj3.GetComponentsInChildren<Rigidbody>();
						for (int k = 0; k < rigs3.Length; k++)
						{
							rigs3[k].isKinematic = true;
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
						yield return StartCoroutine(avatarGeneratorService.c55b4878c03d9f87b4d34de1f79de2705(c8845f28fdcd69fafc8894476a17e43db: c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<WeaponGeneratorService>().c4e0dae6a16a8a80ddb5214a896b9df58(c430564e9708ee538fd1aa80f80ecffbb(AvatarType.SIREN)), cfe0a1153f61dcdf419049830449301da: kitObj3.gameObject));
						transform.gameObject.GetComponent<ModelFadeIn>().cd93285db16841148ed53a5bbeb35cf20();
						transform.gameObject.SetActive(false);
						_mapClassInfo[AvatarType.SIREN].classModel = transform.gameObject;
						break;
					}
					case 3:
					{
						if (_mapClassInfo[AvatarType.HUNTER].buildingKitRender != null)
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
						BuildingKitRender kitRender4 = new BuildingKitRender("CHR", "Hunter");
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(0, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(1, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(2, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(3, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(4, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(5, 0);
						kitRender4.cb41f27f58a35a325e0a1ff1b026bb4e5(6, 0);
						_mapClassInfo[AvatarType.HUNTER].buildingKitRender = kitRender4;
						yield return StartCoroutine(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad618dcc0547ebee513a30332046d81f(kitRender4.ca8a5af6eb0b2329ae9c0880a0712d3b8()));
						transform.gameObject.SetActive(true);
						GameObject kitObj4 = kitRender4.c3309affdc4b59cba5f457bbaec5f0762();
						kitObj4.AddComponent<Skeleton>();
						string controllerPath4 = "Entities/Player_Mecanim/Hunter_3rd_Controller_UI";
						m_playerAnimator = kitObj4.GetComponent<Animator>();
						if (m_playerAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							m_playerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Object.Instantiate(Resources.Load(controllerPath4));
						}
						kitObj4.transform.parent = transform;
						kitObj4.transform.localPosition = Vector3.zero;
						kitObj4.transform.localRotation = Quaternion.identity;
						Rigidbody[] rigs4 = kitObj4.GetComponentsInChildren<Rigidbody>();
						for (int l = 0; l < rigs4.Length; l++)
						{
							rigs4[l].isKinematic = true;
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							break;
						}
						yield return StartCoroutine(avatarGeneratorService.c55b4878c03d9f87b4d34de1f79de2705(c8845f28fdcd69fafc8894476a17e43db: c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<WeaponGeneratorService>().c4e0dae6a16a8a80ddb5214a896b9df58(c430564e9708ee538fd1aa80f80ecffbb(AvatarType.HUNTER)), cfe0a1153f61dcdf419049830449301da: kitObj4.gameObject));
						transform.gameObject.GetComponent<ModelFadeIn>().cd93285db16841148ed53a5bbeb35cf20();
						transform.gameObject.SetActive(false);
						_mapClassInfo[AvatarType.HUNTER].classModel = transform.gameObject;
						break;
					}
					}
				}
			}
			if (!(m_playerAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_playerAnimator.applyRootMotion = false;
			m_playerAnimator.updateMode = AnimatorUpdateMode.Normal;
			m_playerAnimator.cullingMode = AnimatorCullingMode.BasedOnRenderers;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				break;
			default:
				yield break;
			}
		}
	}

	private void Update()
	{
		DNACreateBehaviour dNACreateBehaviour = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.ccb151936e291c93d0cc4f2fd87c06fb6();
		if (!(dNACreateBehaviour == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			c4017f50c465d34b42c9b2ec82d308df5("tExtraIdle", ClassSelectIdle_Min, ClassSelectIdle_Max);
			return;
		}
	}

	public void c4017f50c465d34b42c9b2ec82d308df5(string cfdcdf22b7605017d12b576b57b1a756a, int c1a0139d78d4b74044f06b4e676dcc511, int c8cc109d7daf35ef5b180de3c5ac6de20)
	{
		m_playerAnimator = base.gameObject.GetComponentInChildren<Animator>();
		if (m_playerAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (m_waitToPlayExtraIdle <= 0)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					m_playerAnimator.SetTrigger(cfdcdf22b7605017d12b576b57b1a756a);
					m_waitToPlayExtraIdle = Random.Range(c1a0139d78d4b74044f06b4e676dcc511, c8cc109d7daf35ef5b180de3c5ac6de20);
					return;
				}
			}
		}
		m_waitToPlayExtraIdle--;
	}

	public int c430564e9708ee538fd1aa80f80ecffbb(AvatarType c8408dd66fcefb13484d43a225c8e7395)
	{
		switch (c8408dd66fcefb13484d43a225c8e7395)
		{
		case AvatarType.BERSERKER:
			return BerserkerWeaponID;
		case AvatarType.HUNTER:
			return HunterWeaponID;
		case AvatarType.SIREN:
			return SirenWeaponID;
		case AvatarType.SOLDIER:
			return SoldierWeaponID;
		default:
			return 1;
		}
	}
}
