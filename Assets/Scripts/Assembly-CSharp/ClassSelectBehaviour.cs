using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class ClassSelectBehaviour : StepBehaviour
{
	private const string MODEL_FASTTRAVEL_NAME = "PRO_FastTravel";

	private const string SCENE_NAME = "Lobby_01";

	protected ClassSelectView _classSelectView;

	protected UIAvatarManager _avatarManager;

	protected Dictionary<AvatarType, FE_ClassInfo> _mapClassInfo;

	private GameObject _curModel;

	private GameObject _fastTravelModel;

	private GameObject _modelGroup;

	private AvatarType _curClassType = AvatarType.TOTAL;

	private void Awake()
	{
	}

	public override void OnShow(FrontEndStepManager.StepState lastStep, object data = null)
	{
		StartCoroutine(cc667edb2d84ae8231e0a6d4ae53a936b(lastStep));
	}

	public override void ca9a7e4f5830bea46045e5de793b42658(FrontEndStepManager.StepState c4563c3e865ced83101267c98f318b921)
	{
		c49373361820f2c450bf91f86dc13134c();
	}

	private void c49373361820f2c450bf91f86dc13134c()
	{
		_avatarManager.c8d95388d9b43fc5f4a94acb4d48ec519();
		_classSelectView.cac7688b05e921e2be3f92479ba44b4a8();
		_classSelectView = cfc1e2630c6509b958fc7f522c86d161d.c7088de59e49f7108f520cf7e0bae167e;
	}

	private void cfe8cebcb3aa062da9e7b72636cd55bbc()
	{
		_classSelectView = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ClassSelectView>();
		_classSelectView._logicBehaviour = this;
		_classSelectView.cd93285db16841148ed53a5bbeb35cf20();
		_classSelectView.c8ce27f07ad125dcd5d8f638ce54309f8(ce2223b4d6de4be0192a26885a86bc720);
		_classSelectView.c578cb264f55b4d0af9261c41a382b885(ceaad0b127af0aca5380a275f9a946dce);
	}

	private void ce3f504efb6392c4be602371f4714b17d()
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c5124035d2e3f608c852e4662920ed796();
		_fastTravelModel = GameObject.Find("PRO_FastTravel");
		if (_fastTravelModel == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "No fastTravelModel found!!");
		}
		_modelGroup = GameObject.Find("Model_Group");
		if (!(_modelGroup != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			_avatarManager = _modelGroup.GetComponent<UIAvatarManager>();
			return;
		}
	}

	private IEnumerator cc667edb2d84ae8231e0a6d4ae53a936b(FrontEndStepManager.StepState c6cb4782d4bd417527304c501b904f4fb)
	{
		if ("Lobby_01" != Application.loadedLevelName)
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
			yield return StartCoroutine(c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c8af82aebcb8b0e0e756c3e54e337464d("Lobby_01"));
		}
		ce3f504efb6392c4be602371f4714b17d();
		cfe8cebcb3aa062da9e7b72636cd55bbc();
		ce404255c381f9decb7f14fdfc7c0df1b();
		_classSelectView.cb061addc09fac4adf6f6700b27e998d9();
		_classSelectView.cc7fa43e9bd8fd461250ccf66a4c85f47(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c530262bed2fed8bf0fa08fae31480158);
	}

	private GameObject c949491042766d660e44c76beedb1c860(AvatarType c4d5566b45034dba2ede6abfcc93260aa)
	{
		if (c4d5566b45034dba2ede6abfcc93260aa == AvatarType.SOLDIER)
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
					return GameObject.Find("CHR_Soldier_03");
				}
			}
		}
		return null;
	}

	public void c53a2ed382a1fe705dd8822d17a195149()
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.Login, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
	}

	public void c8397eef0dff99f09c31a8779aa646f1c()
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c530262bed2fed8bf0fa08fae31480158 = _curClassType;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.CharacterCreate, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
	}

	public void ce2223b4d6de4be0192a26885a86bc720(AvatarType c530262bed2fed8bf0fa08fae31480158)
	{
		FE_ClassInfo fE_ClassInfo = _avatarManager.c776f10275205e9a738d414973e864515(c530262bed2fed8bf0fa08fae31480158);
		if (fE_ClassInfo == null)
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
		if (_curModel != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			_curModel.SetActive(false);
		}
		_curModel = fE_ClassInfo.classModel;
		_curModel.SetActive(true);
		StartCoroutine(cbc280d67529b16f86fad43416ec9fc71(fE_ClassInfo.classModel, fE_ClassInfo.bFirstTimeShow));
		_classSelectView.ce4bf9718485f72643b662cd66d5c4e8e(c530262bed2fed8bf0fa08fae31480158, fE_ClassInfo.strDisplayName, fE_ClassInfo.strIntro, fE_ClassInfo.bFirstTimeShow);
		fE_ClassInfo.bFirstTimeShow = false;
		_curClassType = c530262bed2fed8bf0fa08fae31480158;
	}

	public void ceaad0b127af0aca5380a275f9a946dce(AvatarType c530262bed2fed8bf0fa08fae31480158)
	{
		FE_ClassInfo fE_ClassInfo = _avatarManager.c776f10275205e9a738d414973e864515(c530262bed2fed8bf0fa08fae31480158);
		if (fE_ClassInfo == null)
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
		_classSelectView.ce4bf9718485f72643b662cd66d5c4e8e(c530262bed2fed8bf0fa08fae31480158, fE_ClassInfo.strDisplayName, fE_ClassInfo.strIntro, fE_ClassInfo.bFirstTimeShow);
	}

	private void OnDNACreateProcess(int errorCode)
	{
		if (errorCode != 0)
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
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_skipTutorial)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cec9cdae23444bbac5cad953e7fc1f8e9();
						return;
					}
				}
			}
			c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c72a5f2477f9a9a1490ac1711fe849b07();
			return;
		}
	}

	private void c04cc4c530372db0a04d942ee08561daa()
	{
	}

	private IEnumerator cbc280d67529b16f86fad43416ec9fc71(GameObject cd1505a8bc35681ef0fed8cd958a8b539, bool c6359e4e1d086ef9cafbd3f88e51b3174)
	{
		if (!(cd1505a8bc35681ef0fed8cd958a8b539 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				switch (4)
				{
				case 0:
					continue;
				}
				cd1505a8bc35681ef0fed8cd958a8b539.SetActive(true);
				Transform effectParent = _modelGroup.transform.FindChild("PTL_Resurrection");
				if (effectParent == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
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
				ParticleSystem effct = effectParent.particleSystem;
				if (effct == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (5)
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
					switch (1)
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
						switch (7)
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

	private void c832beb8e346636cfbd72ec1994a7214b()
	{
		if (_fastTravelModel == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		_fastTravelModel.transform.FindChild("Fast_Travel").animation.Rewind("Open");
	}

	private void ce404255c381f9decb7f14fdfc7c0df1b()
	{
		if (_fastTravelModel == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		Animation animation = _fastTravelModel.transform.FindChild("Fast_Travel").animation;
		animation["Idle"].wrapMode = WrapMode.Loop;
		animation.CrossFade("Idle");
	}

	private IEnumerator cc4e962a4d0289692a1c05cb71eaef8f8()
	{
		if (!(_fastTravelModel != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			yield break;
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
			Animation tempAnimation = _fastTravelModel.transform.FindChild("Fast_Travel").animation;
			tempAnimation["Open"].wrapMode = WrapMode.Once;
			tempAnimation.Play("Open");
			while (tempAnimation.isPlaying)
			{
				yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
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
	}
}
