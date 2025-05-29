using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public class LoginBehaviour : StepBehaviour
{
	private const string SCENE_NAME = "Lobby_01";

	private const string MODEL_GROUP_NAME = "Model_Group";

	private const string MODEL_FASTTRAVEL_NAME = "PRO_FastTravel";

	private const string MODEL_SHINNINGLIGHT_NAME = "PTL_ShiningLight";

	protected LoginView _loginView;

	private GameObject _modelGroup;

	private GameObject _fastTravelModel;

	private GameObject _shinningLight;

	private Camera _camera;

	public override void OnShow(FrontEndStepManager.StepState lastStep, object data = null)
	{
		StartCoroutine(cc667edb2d84ae8231e0a6d4ae53a936b(lastStep));
	}

	public override void ca9a7e4f5830bea46045e5de793b42658(FrontEndStepManager.StepState c4563c3e865ced83101267c98f318b921)
	{
		c49373361820f2c450bf91f86dc13134c();
	}

	private IEnumerator cc667edb2d84ae8231e0a6d4ae53a936b(FrontEndStepManager.StepState c6cb4782d4bd417527304c501b904f4fb)
	{
		if ("Lobby_01" != Application.loadedLevelName)
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
			yield return StartCoroutine(c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c8af82aebcb8b0e0e756c3e54e337464d("Lobby_01"));
			_camera = GameObject.Find("Class_selection_Camera").camera;
			_camera.enabled = false;
			_modelGroup = GameObject.Find("Model_Group");
			if (_modelGroup != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				yield return StartCoroutine(_modelGroup.GetComponent<UIAvatarManager>().cd93285db16841148ed53a5bbeb35cf20());
			}
			_camera.enabled = true;
			_camera.animation.Play("ANI_Looby_LoginCameraMovement");
		}
		ce3f504efb6392c4be602371f4714b17d();
		yield return StartCoroutine(cc4e962a4d0289692a1c05cb71eaef8f8());
		ce404255c381f9decb7f14fdfc7c0df1b();
		cfe8cebcb3aa062da9e7b72636cd55bbc();
	}

	private void c49373361820f2c450bf91f86dc13134c()
	{
		GameObject gameObject = GameObject.Find("LA");
		if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Transform transform = gameObject.transform.FindChild("Scenes/PRO_Looby_Logo");
			if (transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				transform.gameObject.SetActive(false);
			}
		}
		if (_loginView == null)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cdda1108806b8a31337c338a488b30f1e();
			_loginView.cac7688b05e921e2be3f92479ba44b4a8();
			_loginView = c4b3e12dec43f0b486699cfa29a4ee50e.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	private void cfe8cebcb3aa062da9e7b72636cd55bbc()
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_enableSndaLogin)
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
					cf54ad66cd295957df13a55870ed51497(ShandaWrapper.ShandaTicket, "*");
					return;
				}
			}
		}
		_loginView = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<LoginView>();
		_loginView._logicBehaviour = this;
		_loginView.cd93285db16841148ed53a5bbeb35cf20();
		_loginView.cd8807a5234c8bc932a35c30ae53838ee(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c3b8d7ef091ecb61c8a7ddeaa2a74c5c0, c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c86c4af95f93a5ad7dc980e3792620d3c);
	}

	private void ce3f504efb6392c4be602371f4714b17d()
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().cb3797f1f72105333c59934e3f0944657();
		_fastTravelModel = GameObject.Find("PRO_FastTravel");
		if (_fastTravelModel == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "No fastTravelModel found!!");
		}
		_shinningLight = GameObject.Find("PTL_ShiningLight");
		if (_shinningLight == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "No SHINNINGLIGHT found!!");
					return;
				}
			}
		}
		_shinningLight.SetActive(false);
	}

	public void cf54ad66cd295957df13a55870ed51497(string cd99af21e22e356018b8f72d4a7e4872a, string c86c4af95f93a5ad7dc980e3792620d3c)
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c3b8d7ef091ecb61c8a7ddeaa2a74c5c0 = cd99af21e22e356018b8f72d4a7e4872a;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c86c4af95f93a5ad7dc980e3792620d3c = c86c4af95f93a5ad7dc980e3792620d3c;
		if (_loginView != null)
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
			_loginView.cc6d8fb0627b56c504494f2637f0707f0(false);
		}
		c542ed1dfa08e936773af61f4d05d45f2(cd99af21e22e356018b8f72d4a7e4872a, c86c4af95f93a5ad7dc980e3792620d3c);
	}

	public void c542ed1dfa08e936773af61f4d05d45f2(string cd99af21e22e356018b8f72d4a7e4872a, string c86c4af95f93a5ad7dc980e3792620d3c)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<NetworkManager>() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "fail to get network manager");
			if (_loginView != null)
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
				_loginView.cc6d8fb0627b56c504494f2637f0707f0(true);
			}
		}
		else
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "succeeded to get network manager");
		}
		if (!c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c3baaa4a6dea0fa0c8840ad6ec2f669bb(typeof(NetworkManager.AuthenticateAsyncTask)))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
				{
					NetworkManager.AuthenticateAsyncTask authenticateAsyncTask = new NetworkManager.AuthenticateAsyncTask();
					authenticateAsyncTask.c7cc9411392f033dee9802f9b9ca15b21(cd99af21e22e356018b8f72d4a7e4872a);
					c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(authenticateAsyncTask, OnAuthenticate);
					return;
				}
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.c5a4ebf25aa046ef293fa9ea449fcbb09();
	}

	private void OnAuthenticate(cac110d4f4a99811889eb5dc85c420d82 task, c2597280f86604f98f89309a4de95dd62 result)
	{
		if (result == c2597280f86604f98f89309a4de95dd62.Success)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					OnlineService.c123f97c79fbb5492a276d756505ecfe3((task as NetworkManager.AuthenticateAsyncTask).m_login);
					CharacterService.GetCharacterListAsyncTask getCharacterListAsyncTask = new CharacterService.GetCharacterListAsyncTask();
					getCharacterListAsyncTask.c7cc9411392f033dee9802f9b9ca15b21();
					c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(getCharacterListAsyncTask, OnGetCharacterList);
					return;
				}
				}
			}
		}
		if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_enableSndaLogin)
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
			cf54ad66cd295957df13a55870ed51497(ShandaWrapper.ShandaTicket, "*");
			return;
		}
	}

	private void OnGetCharacterList(cac110d4f4a99811889eb5dc85c420d82 task, c2597280f86604f98f89309a4de95dd62 result)
	{
		if (result != c2597280f86604f98f89309a4de95dd62.Success)
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
			c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cdcc658e3c5be5baafd088fd0bf889371(true);
		}
		List<Character> characters = (task as CharacterService.GetCharacterListAsyncTask).m_characters;
		if (characters.Count > 0)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c7c80683fbe2a8ba978d53115286c4c8a = true;
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.CharacterSelect, characters);
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c7c80683fbe2a8ba978d53115286c4c8a = false;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.ClassSelect, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
	}

	private IEnumerator cc4e962a4d0289692a1c05cb71eaef8f8()
	{
		if (!(_fastTravelModel != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			Animation tempAnimation = _fastTravelModel.transform.FindChild("Fast_Travel").animation;
			tempAnimation["Open"].wrapMode = WrapMode.Once;
			tempAnimation.Play("Open");
			BaseEventTriggerCtl m_AudioCtl = _fastTravelModel.GetComponentInChildren<BaseEventTriggerCtl>();
			if (m_AudioCtl != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_AudioCtl.TriggerEventByName("UI_FastTravel_Open");
			}
			while (tempAnimation != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (tempAnimation.isPlaying)
				{
					yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
					continue;
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
			yield break;
		}
	}

	private void ce404255c381f9decb7f14fdfc7c0df1b()
	{
		if (_shinningLight != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			_shinningLight.SetActive(true);
		}
		if (_fastTravelModel == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		Animation animation = _fastTravelModel.transform.FindChild("Fast_Travel").animation;
		animation["Idle"].wrapMode = WrapMode.Loop;
		animation.CrossFade("Idle");
	}
}
