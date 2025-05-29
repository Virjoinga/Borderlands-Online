using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class CharacterSelectBehaviour : StepBehaviour
{
	private const string SCENE_NAME = "Lobby_01";

	private const string MODEL_SOLDIER_NAME = "CHR_Soldier_Skeleton_01";

	private const string MODEL_SIREN_NAME = "CHR_Siren_Skeleton_01";

	private const string MODEL_BERSERKER_NAME = "CHR_Berserker_Skeleton_01";

	private const string MODEL_HUNTER_NAME = "CHR_Hunter_Skeleton_01";

	private List<Character> characters;

	protected CharacterSelectView _characterSelectView;

	protected GameObject characterModel;

	private UIModelController _modelCtrl;

	private Vector3 _v3RotateSpeed = new Vector3(-0.5f, 0f, 0f);

	private static List<Character> cachedCharacter;

	[CompilerGenerated]
	private static Dictionary<string, int> _003C_003Ef__switch_0024map0;

	public override void OnShow(FrontEndStepManager.StepState lastStep, object data = null)
	{
		if (data != null)
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
			cachedCharacter = data as List<Character>;
		}
		object obj;
		if (data == null)
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
			obj = cachedCharacter;
		}
		else
		{
			obj = data as List<Character>;
		}
		characters = (List<Character>)obj;
		StartCoroutine(cc667edb2d84ae8231e0a6d4ae53a936b(lastStep));
	}

	public override void ca9a7e4f5830bea46045e5de793b42658(FrontEndStepManager.StepState c4563c3e865ced83101267c98f318b921)
	{
		if ((bool)characterModel)
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
			Object.Destroy(characterModel);
		}
		c49373361820f2c450bf91f86dc13134c();
	}

	private void c49373361820f2c450bf91f86dc13134c()
	{
		_characterSelectView.cac7688b05e921e2be3f92479ba44b4a8();
		_characterSelectView = c4847715fff44d4b7457799c5c1b13218.c7088de59e49f7108f520cf7e0bae167e;
		characters = c3a340316af1de502d92f7d437a7a96de.c7088de59e49f7108f520cf7e0bae167e;
	}

	private void ce3f504efb6392c4be602371f4714b17d()
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().cee3677bab0ba68add73016d37ed87bd2();
	}

	private void cfe8cebcb3aa062da9e7b72636cd55bbc()
	{
		_characterSelectView = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CharacterSelectView>();
		_characterSelectView._logicBehaviour = this;
		_characterSelectView.cd93285db16841148ed53a5bbeb35cf20();
		_characterSelectView.c697cea1a39d7a5dfd46cd14d3c068be3(characters);
	}

	public virtual void ccd4de5ee253f41f4bb424ad2d551276c(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		CharacterService.SelectCharacterAsyncTask selectCharacterAsyncTask = new CharacterService.SelectCharacterAsyncTask();
		selectCharacterAsyncTask.c7cc9411392f033dee9802f9b9ca15b21(c35f98ccbfa8c6bf09319c620b21b5dc5);
		c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(selectCharacterAsyncTask, OnSelecteCharacter);
	}

	private Character ca4423d084c350c41ef4dccef260f83dc(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		using (List<Character>.Enumerator enumerator = characters.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Character current = enumerator.Current;
				if (current.Id != c35f98ccbfa8c6bf09319c620b21b5dc5)
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return current;
				}
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					goto end_IL_0047;
				}
				continue;
				end_IL_0047:
				break;
			}
		}
		return null;
	}

	public void c090a1e1498ac2bf3b242fa7878200faa(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		Character character = ca4423d084c350c41ef4dccef260f83dc(c35f98ccbfa8c6bf09319c620b21b5dc5);
		if (character == null)
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
		PlayerProperties playerProperties = new PlayerProperties();
		playerProperties.m_id = character.Id;
		playerProperties.m_name = character.Name;
		playerProperties.m_exp = character.Experience;
		playerProperties.m_level = character.Level;
		AvatarDNA avatarDNA = new AvatarDNA();
		avatarDNA.c300c4ff719a5623d8161bef607d268f1(character.AvatarType, character.AvatarParts, character.AvatarMaterials, character.AvatarId);
		playerProperties.m_avatarDna = avatarDNA;
		c06ca0e618478c23eba3419653a19760f<PlayerManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd48a53289a0d0d4ec50069243545b823(playerProperties, true);
		StartCoroutine(caf0b4c32dd85f739e8c430236a1e15bc(avatarDNA, character));
	}

	public void OnSelecteCharacter(cac110d4f4a99811889eb5dc85c420d82 task, c2597280f86604f98f89309a4de95dd62 result)
	{
		if (result == c2597280f86604f98f89309a4de95dd62.Success)
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
					c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cec9cdae23444bbac5cad953e7fc1f8e9();
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.none, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cdcc658e3c5be5baafd088fd0bf889371(true);
	}

	private IEnumerator caf0b4c32dd85f739e8c430236a1e15bc(AvatarDNA caedbc1db6c28d44eab6021e7d674eab3, Character caadc19f3b6ef506913862a46cd09ddf6)
	{
		uint bkID = caedbc1db6c28d44eab6021e7d674eab3.m_buildingUnit.bkID;
		if (bkID == 0)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "bkID is 0 in Character Select Behaviour");
		}
		BuildingKitRender generator = new BuildingKitRender(bkID);
		if (!BuildingKitManager.OnlineHostMinResMode)
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
			generator.ccf784a7191cc76b4e0c079ff7b1e7ac7 = caedbc1db6c28d44eab6021e7d674eab3.m_buildingUnit;
		}
		GameObject model = generator.c3309affdc4b59cba5f457bbaec5f0762();
		if ((bool)characterModel)
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
			Object.DestroyImmediate(characterModel);
		}
		characterModel = model;
		_modelCtrl = characterModel.GetComponent<UIModelController>();
		if (_modelCtrl == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			_modelCtrl = characterModel.AddComponent<UIModelController>();
		}
		GameObject _modelGroup = GameObject.Find("Model_Group");
		GameObject _skeleton = GameObject.Find("Model_Group/CHR_Custom_Skeleton_01");
		characterModel.transform.parent = _skeleton.transform;
		characterModel.transform.localRotation = Quaternion.identity;
		characterModel.transform.localPosition = Vector3.zero;
		string controllerPath2 = string.Empty;
		Vector3 targetPosition = Vector3.zero;
		_skeleton.transform.localPosition = GameObject.Find("Model_Group/CHR_Temp_Position").transform.localPosition;
		Transform[] componentsInChildren = _modelGroup.GetComponentsInChildren<Transform>(true);
		foreach (Transform transform in componentsInChildren)
		{
			string text = transform.gameObject.name;
			if (text == null)
			{
				continue;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			if (_003C_003Ef__switch_0024map0 == null)
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
				Dictionary<string, int> dictionary = new Dictionary<string, int>(4);
				dictionary.Add("CHR_Soldier_Skeleton_01", 0);
				dictionary.Add("CHR_Siren_Skeleton_01", 1);
				dictionary.Add("CHR_Berserker_Skeleton_01", 2);
				dictionary.Add("CHR_Hunter_Skeleton_01", 3);
				_003C_003Ef__switch_0024map0 = dictionary;
			}
			int value;
			if (!_003C_003Ef__switch_0024map0.TryGetValue(text, out value))
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
			switch (value)
			{
			case 0:
				if (caedbc1db6c28d44eab6021e7d674eab3.c071244a19e2d9f70f4d2d6d38677162a() != AvatarType.SOLDIER)
				{
					break;
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
				controllerPath2 = "Entities/Player_Mecanim/Soldier_3rd_Controller_UI";
				targetPosition = transform.localPosition;
				_skeleton.transform.localRotation = transform.localRotation;
				break;
			case 1:
				if (caedbc1db6c28d44eab6021e7d674eab3.c071244a19e2d9f70f4d2d6d38677162a() != 0)
				{
					break;
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
				controllerPath2 = "Entities/Player_Mecanim/Siren_3rd_Controller_UI";
				targetPosition = transform.localPosition;
				_skeleton.transform.localRotation = transform.localRotation;
				break;
			case 2:
				if (caedbc1db6c28d44eab6021e7d674eab3.c071244a19e2d9f70f4d2d6d38677162a() != AvatarType.BERSERKER)
				{
					break;
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
				controllerPath2 = "Entities/Player_Mecanim/Berserker_3rd_Controller_UI";
				targetPosition = transform.localPosition;
				_skeleton.transform.localRotation = transform.localRotation;
				break;
			case 3:
				if (caedbc1db6c28d44eab6021e7d674eab3.c071244a19e2d9f70f4d2d6d38677162a() != AvatarType.HUNTER)
				{
					break;
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
				controllerPath2 = "Entities/Player_Mecanim/Hunter_3rd_Controller_UI";
				targetPosition = transform.localPosition;
				_skeleton.transform.localRotation = transform.localRotation;
				break;
			}
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			Animator animator = characterModel.GetComponent<Animator>();
			if (animator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (controllerPath2 != string.Empty)
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
					controllerPath2 = "Entities/Player_Mecanim/Siren_3rd_Controller_Town";
					animator.runtimeAnimatorController = (RuntimeAnimatorController)Object.Instantiate(Resources.Load(controllerPath2));
					animator.SetFloat("fDefaultPose", (float)caedbc1db6c28d44eab6021e7d674eab3.c071244a19e2d9f70f4d2d6d38677162a());
				}
			}
			Rigidbody[] rigs = characterModel.GetComponentsInChildren<Rigidbody>();
			for (int i = 0; i < rigs.Length; i++)
			{
				rigs[i].isKinematic = true;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				WeaponDNA weaponDNA = caadc19f3b6ef506913862a46cd09ddf6.Inventory.c3941dac8608f650ceb15dc36294a741c().ca79da172938fdc8c067fb64242b6174a();
				if (animator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					PlayerAnimationIkController playerIkController = animator.gameObject.AddComponent<PlayerAnimationIkController>();
					playerIkController.m_enableLeftHandIK = true;
					playerIkController.m_currentWeaponType = weaponDNA.c83e548e5608cd7f222098a6966b16545();
					int weaponType = (int)playerIkController.m_currentWeaponType;
					animator.SetInteger("iWeaponType", weaponType);
					GameObject cameraObj = GameObject.Find("Class_selection_Camera");
					if (cameraObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						playerIkController.c1e667d6f38b9e5836b1229ac7567f858(cameraObj);
						playerIkController.m_enableLookIK = true;
					}
				}
				AvatarGeneratorService avatarGeneratorService = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<AvatarGeneratorService>();
				yield return StartCoroutine(avatarGeneratorService.c55b4878c03d9f87b4d34de1f79de2705(_skeleton.gameObject, weaponDNA));
				_skeleton.GetComponentInChildren<ModelFadeIn>().cd93285db16841148ed53a5bbeb35cf20();
				_skeleton.transform.localPosition = targetPosition;
				StartCoroutine(cbc280d67529b16f86fad43416ec9fc71(_skeleton, true));
				yield break;
			}
		}
	}

	private IEnumerator cbc280d67529b16f86fad43416ec9fc71(GameObject cd1505a8bc35681ef0fed8cd958a8b539, bool c6359e4e1d086ef9cafbd3f88e51b3174)
	{
		if (!(cd1505a8bc35681ef0fed8cd958a8b539 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			yield break;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!c6359e4e1d086ef9cafbd3f88e51b3174)
			{
				yield break;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				cd1505a8bc35681ef0fed8cd958a8b539.SetActive(true);
				GameObject _modelGroup = GameObject.Find("Model_Group");
				Transform effectParent = _modelGroup.transform.FindChild("PTL_Resurrection");
				if (effectParent == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							yield break;
						}
					}
				}
				ParticleSystem effct = effectParent.particleSystem;
				if (effct == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							yield break;
						}
					}
				}
				effectParent.gameObject.SetActive(true);
				effct.Play();
				ModelFadeIn tempfadeInEff = cd1505a8bc35681ef0fed8cd958a8b539.GetComponentInChildren<ModelFadeIn>();
				if (!(tempfadeInEff != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					yield break;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					tempfadeInEff.c0a75d7afd2f7f1e47a5aadaab61303c7();
					while (tempfadeInEff.c27b8b8f2b26d9420fc1ac46dcae468c9)
					{
						yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							yield break;
						}
					}
				}
			}
		}
	}

	private void Update()
	{
		if (!(Input.mousePosition.x > (float)Screen.width))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!(Input.mousePosition.y > (float)Screen.height))
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
				if (!(Input.mousePosition.x < 0f))
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
					if (!(Input.mousePosition.y < 0f))
					{
						goto IL_00ad;
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
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ClassCustomView>().c69b7264d5f6dc27474e86b241d437906(true);
		goto IL_00ad;
		IL_00ad:
		if (_modelCtrl == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c7239543e613e42c603e3f4786aa2ecb7())
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
			if (Input.GetMouseButtonDown(0))
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
				_modelCtrl.c0611c0503cb7e55eec97e2f0b356bbcd(_v3RotateSpeed);
			}
		}
		if (!Input.GetMouseButtonUp(0))
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
			_modelCtrl.c0611c0503cb7e55eec97e2f0b356bbcd(Vector3.zero);
			return;
		}
	}

	private IEnumerator cc667edb2d84ae8231e0a6d4ae53a936b(FrontEndStepManager.StepState c6cb4782d4bd417527304c501b904f4fb)
	{
		if ("Lobby_01" != Application.loadedLevelName)
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
			yield return StartCoroutine(c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c8af82aebcb8b0e0e756c3e54e337464d("Lobby_01"));
		}
		ce3f504efb6392c4be602371f4714b17d();
		cfe8cebcb3aa062da9e7b72636cd55bbc();
	}
}
