using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class DNACreateBehaviour : StepBehaviour
{
	private const string MODEL_SOLDIER_NAME = "CHR_Soldier_Skeleton_01";

	private const string MODEL_SIREN_NAME = "CHR_Siren_Skeleton_01";

	private const string MODEL_BERSERKER_NAME = "CHR_Berserker_Skeleton_01";

	private const string MODEL_HUNTER_NAME = "CHR_Hunter_Skeleton_01";

	private BuildingKitRender generator;

	protected UIAvatarManager _avatarManager;

	private AvatarDNA _CustomPlayerDNA;

	private string _characterName;

	private GameObject _avatar;

	private GameObject _modelGroup;

	private GameObject cameraObj;

	private AvatarSubPart focusPart = AvatarSubPart.BODY;

	private UIModelController _modelCtrl;

	private Vector3 _v3RotateSpeed = new Vector3(-0.5f, 0f, 0f);

	[CompilerGenerated]
	private static Dictionary<string, int> _003C_003Ef__switch_0024map1;

	public AvatarSubPart c5785fb2096ff4aad7a50f699f1663f1f
	{
		get
		{
			return focusPart;
		}
		private set
		{
			focusPart = value;
		}
	}

	private void Awake()
	{
		_CustomPlayerDNA = new AvatarDNA();
		cameraObj = GameObject.Find("Class_selection_Camera");
	}

	public override void OnShow(FrontEndStepManager.StepState lastStep, object data = null)
	{
		cdfb3f6d661941f6bba41493452e55b09();
		cfe8cebcb3aa062da9e7b72636cd55bbc();
	}

	public override void ca9a7e4f5830bea46045e5de793b42658(FrontEndStepManager.StepState c4563c3e865ced83101267c98f318b921)
	{
		if (c4563c3e865ced83101267c98f318b921 == FrontEndStepManager.StepState.ClassSelect)
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
			if (_modelCtrl != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				_modelCtrl.c68d90d817b360f3767f83d5ba152ef76();
				Object.Destroy(_modelCtrl);
				_modelCtrl = c72da72cdd2313288f94c2c6d7947d8ea.c7088de59e49f7108f520cf7e0bae167e;
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<ClassCustomView>();
	}

	protected void cdfb3f6d661941f6bba41493452e55b09()
	{
		_modelGroup = GameObject.Find("Model_Group");
		if (_modelGroup != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			_avatarManager = _modelGroup.GetComponent<UIAvatarManager>();
			if (_avatarManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "----------initAvatarModel---------");
			}
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
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (_003C_003Ef__switch_0024map1 == null)
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
					dictionary.Add("CHR_Soldier_Skeleton_01", 0);
					dictionary.Add("CHR_Siren_Skeleton_01", 1);
					dictionary.Add("CHR_Berserker_Skeleton_01", 2);
					dictionary.Add("CHR_Hunter_Skeleton_01", 3);
					_003C_003Ef__switch_0024map1 = dictionary;
				}
				int value;
				if (!_003C_003Ef__switch_0024map1.TryGetValue(text, out value))
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
				switch (value)
				{
				case 0:
					transform.gameObject.SetActive(false);
					if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c530262bed2fed8bf0fa08fae31480158 != AvatarType.SOLDIER)
					{
						break;
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
					_avatar = transform.gameObject;
					_avatar.SetActive(true);
					break;
				case 1:
					transform.gameObject.SetActive(false);
					if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c530262bed2fed8bf0fa08fae31480158 != 0)
					{
						break;
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
					_avatar = transform.gameObject;
					_avatar.SetActive(true);
					break;
				case 2:
					transform.gameObject.SetActive(false);
					if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c530262bed2fed8bf0fa08fae31480158 != AvatarType.BERSERKER)
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
					_avatar = transform.gameObject;
					_avatar.SetActive(true);
					break;
				case 3:
					transform.gameObject.SetActive(false);
					if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c530262bed2fed8bf0fa08fae31480158 != AvatarType.HUNTER)
					{
						break;
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
					_avatar = transform.gameObject;
					_avatar.SetActive(true);
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
				break;
			}
		}
		_CustomPlayerDNA.m_type = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c530262bed2fed8bf0fa08fae31480158;
		generator = _avatarManager.c776f10275205e9a738d414973e864515(_CustomPlayerDNA.m_type).buildingKitRender;
		_CustomPlayerDNA.m_buildingUnit = _avatarManager.c776f10275205e9a738d414973e864515(_CustomPlayerDNA.m_type).buildingKitRender.ccf784a7191cc76b4e0c079ff7b1e7ac7;
		_modelCtrl = _avatar.GetComponent<UIModelController>();
		if (!(_modelCtrl == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			_modelCtrl = _avatar.AddComponent<UIModelController>();
			return;
		}
	}

	protected void cfe8cebcb3aa062da9e7b72636cd55bbc()
	{
		ClassCustomView classCustomView = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ClassCustomView>();
		classCustomView.ce82e275cb065bd8e3c15b8d2b7396422();
		classCustomView.cd93285db16841148ed53a5bbeb35cf20();
		classCustomView._logicBehaviour = this;
	}

	private IEnumerator c3222ba22becafdb3ce60548705cebd3d(GameObject c25bee12d2abe952bd1c1d924e75c330a, AvatarDNA cd3a5dc9faa8a2425d23aa29e154122e4, string c2b8e31702fae33167fb34bfa350e82c9)
	{
		yield return StartCoroutine(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad618dcc0547ebee513a30332046d81f(generator.c0c98f9aa4067deab3caf8159826ae606()));
		c25bee12d2abe952bd1c1d924e75c330a = generator.cca6fe4e85fa02d8c2a4d33c08a268939();
		Renderer[] componentsInChildren = c25bee12d2abe952bd1c1d924e75c330a.GetComponentsInChildren<Renderer>();
		foreach (Renderer iter in componentsInChildren)
		{
			iter.enabled = true;
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
			yield break;
		}
	}

	private void ca1d555e5dc458c1cfc992a165ecc0921(AvatarDNA cd3a5dc9faa8a2425d23aa29e154122e4, byte c716466036ca83f8907f5a0c81b0e432d, byte c35f98ccbfa8c6bf09319c620b21b5dc5, bool ce689d065a6f44bd222565697a0c3b0f9 = true)
	{
		switch (c716466036ca83f8907f5a0c81b0e432d)
		{
		case 0:
			cd3a5dc9faa8a2425d23aa29e154122e4.ca1fe7b61e26d6fd9fe0781630e0e7bdd(0, c35f98ccbfa8c6bf09319c620b21b5dc5);
			if (!ce689d065a6f44bd222565697a0c3b0f9)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				focusPart = AvatarSubPart.HAIR;
				return;
			}
		case 1:
			cd3a5dc9faa8a2425d23aa29e154122e4.ca1fe7b61e26d6fd9fe0781630e0e7bdd(1, c35f98ccbfa8c6bf09319c620b21b5dc5);
			if (!ce689d065a6f44bd222565697a0c3b0f9)
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
				focusPart = AvatarSubPart.HEAD;
				return;
			}
		case 2:
			cd3a5dc9faa8a2425d23aa29e154122e4.ca1fe7b61e26d6fd9fe0781630e0e7bdd(2, c35f98ccbfa8c6bf09319c620b21b5dc5);
			if (!ce689d065a6f44bd222565697a0c3b0f9)
			{
				break;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				focusPart = AvatarSubPart.MASK;
				return;
			}
		case 3:
			cd3a5dc9faa8a2425d23aa29e154122e4.cf83de9b24939a64c5b795af7d70153b4(3, c35f98ccbfa8c6bf09319c620b21b5dc5);
			cd3a5dc9faa8a2425d23aa29e154122e4.cf83de9b24939a64c5b795af7d70153b4(7, c35f98ccbfa8c6bf09319c620b21b5dc5);
			if (!ce689d065a6f44bd222565697a0c3b0f9)
			{
				break;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				focusPart = AvatarSubPart.BODY;
				return;
			}
		case 4:
			cd3a5dc9faa8a2425d23aa29e154122e4.cf83de9b24939a64c5b795af7d70153b4(4, c35f98ccbfa8c6bf09319c620b21b5dc5);
			if (!ce689d065a6f44bd222565697a0c3b0f9)
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
				focusPart = AvatarSubPart.PANTS;
				return;
			}
		case 5:
			cd3a5dc9faa8a2425d23aa29e154122e4.cf83de9b24939a64c5b795af7d70153b4(5, c35f98ccbfa8c6bf09319c620b21b5dc5);
			if (!ce689d065a6f44bd222565697a0c3b0f9)
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
				focusPart = AvatarSubPart.SHOE;
				return;
			}
		default:
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "Wrong Parameter in customization part mapping");
			break;
		}
	}

	private void Update()
	{
		if (!(Input.mousePosition.x > (float)Screen.width))
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
						switch (2)
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
						switch (3)
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
					switch (1)
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
			switch (1)
			{
			case 0:
				continue;
			}
			_modelCtrl.c0611c0503cb7e55eec97e2f0b356bbcd(Vector3.zero);
			return;
		}
	}

	public void c92d57f37bbd6f97e11c80978db66cb16(byte c716466036ca83f8907f5a0c81b0e432d)
	{
		Animation component = cameraObj.GetComponent<Animation>();
		if (c716466036ca83f8907f5a0c81b0e432d == (byte)focusPart)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (focusPart == AvatarSubPart.BODY)
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
				if (c716466036ca83f8907f5a0c81b0e432d != 0)
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
					if (c716466036ca83f8907f5a0c81b0e432d != 2)
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
						if (c716466036ca83f8907f5a0c81b0e432d != 1)
						{
							goto IL_0092;
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
					}
				}
				component["ANI_Looby_CustemerZoomBodytoHead"].speed = 1f;
				component.Play("ANI_Looby_CustemerZoomBodytoHead");
				goto IL_0092;
			}
			goto IL_00d3;
			IL_00d3:
			if (focusPart != 0)
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
				if (focusPart != AvatarSubPart.MASK)
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
					if (focusPart != AvatarSubPart.HEAD)
					{
						goto IL_01a8;
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
			}
			if (c716466036ca83f8907f5a0c81b0e432d == 3)
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
				component["ANI_Looby_CustemerZoomBodytoHead"].time = component["ANI_Looby_CustemerZoomBodytoHead"].length;
				component["ANI_Looby_CustemerZoomBodytoHead"].speed = -1f;
				component.Play("ANI_Looby_CustemerZoomBodytoHead");
			}
			if (c716466036ca83f8907f5a0c81b0e432d != 4)
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
				if (c716466036ca83f8907f5a0c81b0e432d != 5)
				{
					goto IL_01a8;
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
			}
			component["ANI_Looby_CustemerZoomHeadtoFeet"].speed = 1f;
			component.Play("ANI_Looby_CustemerZoomHeadtoFeet");
			goto IL_01a8;
			IL_01a8:
			if (focusPart != AvatarSubPart.PANTS)
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
				if (focusPart != AvatarSubPart.SHOE)
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
					break;
				}
			}
			if (c716466036ca83f8907f5a0c81b0e432d == 3)
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
				component["ANI_Looby_CustemerZoomBodytoFeet"].time = component["ANI_Looby_CustemerZoomBodytoFeet"].length;
				component["ANI_Looby_CustemerZoomBodytoFeet"].speed = -1f;
				component.Play("ANI_Looby_CustemerZoomBodytoFeet");
			}
			if (c716466036ca83f8907f5a0c81b0e432d != 0)
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
				if (c716466036ca83f8907f5a0c81b0e432d != 2)
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
					if (c716466036ca83f8907f5a0c81b0e432d != 1)
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
				}
			}
			component["ANI_Looby_CustemerZoomHeadtoFeet"].time = component["ANI_Looby_CustemerZoomHeadtoFeet"].length;
			component["ANI_Looby_CustemerZoomHeadtoFeet"].speed = -1f;
			component.Play("ANI_Looby_CustemerZoomHeadtoFeet");
			return;
			IL_0092:
			if (c716466036ca83f8907f5a0c81b0e432d != 5)
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
				if (c716466036ca83f8907f5a0c81b0e432d != 4)
				{
					goto IL_00d3;
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
			}
			component["ANI_Looby_CustemerZoomBodytoFeet"].speed = 1f;
			component.Play("ANI_Looby_CustemerZoomBodytoFeet");
			goto IL_00d3;
		}
	}

	public void c5f036d9797e7523ba491832594238078(byte c716466036ca83f8907f5a0c81b0e432d, byte c343f09726f61b6b56d24591379c667b9, bool cb843f97c9f7026e9f00dccd9de16cd3e = true)
	{
		if (cb843f97c9f7026e9f00dccd9de16cd3e)
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
			c92d57f37bbd6f97e11c80978db66cb16(c716466036ca83f8907f5a0c81b0e432d);
		}
		ca1d555e5dc458c1cfc992a165ecc0921(_CustomPlayerDNA, c716466036ca83f8907f5a0c81b0e432d, c343f09726f61b6b56d24591379c667b9, cb843f97c9f7026e9f00dccd9de16cd3e);
	}

	public void c9c8c2e259fa10b28eef998125e51490f(string c27f942e94722365b856fea0bc9f82871)
	{
		StartCoroutine(c3222ba22becafdb3ce60548705cebd3d(_avatar, _CustomPlayerDNA, c27f942e94722365b856fea0bc9f82871));
	}

	public void c49fa125ba4362ced3a0bd1ce8f3c8188(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		_characterName = cd99af21e22e356018b8f72d4a7e4872a;
	}

	public void c742aaec0df3b68985ab7230816610221()
	{
		CharacterService.CreateCharacterAsyncTask createCharacterAsyncTask = new CharacterService.CreateCharacterAsyncTask();
		createCharacterAsyncTask.c7cc9411392f033dee9802f9b9ca15b21(_characterName, _CustomPlayerDNA);
		c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(createCharacterAsyncTask, OnAvatarCreated);
	}

	private void OnAvatarCreated(cac110d4f4a99811889eb5dc85c420d82 task, c2597280f86604f98f89309a4de95dd62 result)
	{
		if (result == c2597280f86604f98f89309a4de95dd62.Success)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					Character character = (task as CharacterService.CreateCharacterAsyncTask).m_character;
					PlayerProperties playerProperties = new PlayerProperties();
					playerProperties.m_id = character.Id;
					playerProperties.m_name = character.Name;
					playerProperties.m_exp = character.Experience;
					playerProperties.m_level = character.Level;
					AvatarDNA avatarDNA = new AvatarDNA();
					avatarDNA.c300c4ff719a5623d8161bef607d268f1(character.AvatarType, character.AvatarParts, character.AvatarMaterials, character.AvatarId);
					playerProperties.m_avatarDna = avatarDNA;
					c06ca0e618478c23eba3419653a19760f<PlayerManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd48a53289a0d0d4ec50069243545b823(playerProperties, true);
					if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_skipTutorial)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.none, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
								c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cec9cdae23444bbac5cad953e7fc1f8e9();
								return;
							}
						}
					}
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.none, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
					c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c72a5f2477f9a9a1490ac1711fe849b07();
					return;
				}
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c3baaa4a6dea0fa0c8840ad6ec2f669bb(task.GetType()))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.none, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
					c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cdcc658e3c5be5baafd088fd0bf889371(true);
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ClassCustomView>().c7d1840b98a06410c4a22d4c051ecae9f(result);
	}
}
