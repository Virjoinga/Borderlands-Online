using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class GameFlowManager : c06ca0e618478c23eba3419653a19760f<GameFlowManager>
{
	private const int MAX_WAIT_AUDIO_SECONDS = 30;

	private const string AUDIO_RESOURCES_LIST_NAME = "FrontEndAudioResources";

	[HideInInspector]
	public static bool m_isPause;

	[HideInInspector]
	public static bool m_needLockedCursor;

	[HideInInspector]
	private bool m_transitionToInstanceSelection;

	[HideInInspector]
	private bool m_transitionToIngame;

	[HideInInspector]
	private bool m_transitionToLogin;

	private MenuManager m_menuManager;

	protected override void Awake()
	{
		base.Awake();
		base.gameObject.AddComponent<NetworkManager>();
		if (SystemInfo.graphicsDeviceID == 0)
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
			m_menuManager = base.gameObject.AddComponent<MenuManager>();
			return;
		}
	}

	public void c1570506bf0b326e191d0406037cb4fef()
	{
		m_needLockedCursor = true;
		Screen.lockCursor = true;
	}

	public void c1bdd1e7aa891de56d871ae24289f5f8b()
	{
		Screen.lockCursor = false;
		m_needLockedCursor = false;
	}

	private void Update()
	{
		if (NetworkManager.c449802e708e91a9150466060fbab2ad6())
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
			if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_offlineMode)
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
		if (m_needLockedCursor)
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
			if (!Screen.lockCursor)
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
				Screen.lockCursor = m_needLockedCursor;
			}
		}
		if (Input.GetKeyDown(KeyCode.F9))
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
			HudFps componentInChildren = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponentInChildren<HudFps>();
			if (componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				componentInChildren.enabled = !componentInChildren.enabled;
			}
		}
		if (!Input.GetKey(KeyCode.LeftControl))
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
			if (!Input.GetKeyDown(KeyCode.Return))
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
				Screen.lockCursor = false;
				if (!Screen.fullScreen)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							Screen.SetResolution(Screen.width, Screen.height, true);
							return;
						}
					}
				}
				Screen.SetResolution(Screen.width, Screen.height, false);
				return;
			}
		}
	}

	public void c72a5f2477f9a9a1490ac1711fe849b07()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "GoToTutorial");
		if (m_transitionToLogin)
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
			if (m_transitionToInstanceSelection)
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
				if (m_transitionToIngame)
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
					cfe7182ecd28c1d073193664c0a470e42("OnGoToInstance", MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c9bdc2c0504907130c26fceebf8d21879("lvl_Tutorial_Part1_4x").m_id);
					return;
				}
			}
		}
	}

	public void c01f60631f6d4cee6631245560d19fc36(string c2db84530ef366a6deb001d449d4aa151)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "GoToTown");
		if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c739bc996d272aeac228d6b5198b164d2())
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
			c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c040ee5dc6011ac6f76e73d8f329ca070();
		}
		if (m_transitionToIngame)
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
			m_transitionToIngame = true;
			StartCoroutine(cf5121fa48b9296b6d6cc76b5799b54a6(c2db84530ef366a6deb001d449d4aa151));
			return;
		}
	}

	public void cfe7182ecd28c1d073193664c0a470e42(string c2db84530ef366a6deb001d449d4aa151, int c596ba42a2c21a67d5d3b489c87f98a3e)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "GoToInstance");
		if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c739bc996d272aeac228d6b5198b164d2())
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
			c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c040ee5dc6011ac6f76e73d8f329ca070();
		}
		if (m_transitionToIngame)
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
			m_transitionToIngame = true;
			StartCoroutine(ccf8caad6e1036329c9e3d8b47ba3da2e(c2db84530ef366a6deb001d449d4aa151, c596ba42a2c21a67d5d3b489c87f98a3e));
			return;
		}
	}

	public void cfe7182ecd28c1d073193664c0a470e42(string c2db84530ef366a6deb001d449d4aa151, string c37dc4ee4a3a694110f0e0eb7b086137a)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "GoToInstance");
		if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c739bc996d272aeac228d6b5198b164d2())
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
			c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c040ee5dc6011ac6f76e73d8f329ca070();
		}
		if (m_transitionToIngame)
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
			m_transitionToIngame = true;
			StartCoroutine(ccf8caad6e1036329c9e3d8b47ba3da2e(c2db84530ef366a6deb001d449d4aa151, c37dc4ee4a3a694110f0e0eb7b086137a));
			return;
		}
	}

	public void cdcc658e3c5be5baafd088fd0bf889371(bool cef167460004534c74ecb038b94e41b2a = false)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "GoToLogin - " + cef167460004534c74ecb038b94e41b2a);
		if (cef167460004534c74ecb038b94e41b2a)
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
			OnlineService.s_userName = string.Empty;
		}
		if (m_transitionToInstanceSelection)
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
			if (m_transitionToIngame)
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
				m_transitionToLogin = true;
				StartCoroutine(c41b9af3a735b42c9ee0ebdc6c289b0d3(false, false));
				c7ae0e7b8e80603cfc335a2df380802c8();
				return;
			}
		}
	}

	public void cec9cdae23444bbac5cad953e7fc1f8e9()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "GoToLobby");
		if (m_transitionToLogin)
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
			if (m_transitionToInstanceSelection)
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
				if (m_transitionToIngame)
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
					c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd1ac1729b2ffe9d1bc0efb8d4f05abf8();
					StartCoroutine(c41b9af3a735b42c9ee0ebdc6c289b0d3(true, true));
					c7ae0e7b8e80603cfc335a2df380802c8();
					return;
				}
			}
		}
	}

	public void ceba244211ce5e4e3f8e412a840ec284b(string c2db84530ef366a6deb001d449d4aa151, int ca1fe61abde52868f679caf67108b2858, GamemodeType c33491fef5353a204dd899a389fc7ec52)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "GoToLobbyGame");
		if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c739bc996d272aeac228d6b5198b164d2())
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
			c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c040ee5dc6011ac6f76e73d8f329ca070();
		}
		if (m_transitionToIngame)
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
			m_transitionToIngame = true;
			StartCoroutine(c81e05b4c94598a21a8225d096f337021(c2db84530ef366a6deb001d449d4aa151, ca1fe61abde52868f679caf67108b2858, c33491fef5353a204dd899a389fc7ec52));
			return;
		}
	}

	private IEnumerator c41b9af3a735b42c9ee0ebdc6c289b0d3(bool c3df3d8811955ab953973a7e8c5c4c297, bool c748a20f361d82465b8386e36f745d058)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Loading Menu...");
		if (c3df3d8811955ab953973a7e8c5c4c297)
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
			if (c748a20f361d82465b8386e36f745d058)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_usePlaylistId)
						{
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									cfe7182ecd28c1d073193664c0a470e42("OnGoToInstance", c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId);
									yield break;
								}
							}
						}
						c01f60631f6d4cee6631245560d19fc36("OnGoToInstance");
						yield break;
					}
				}
			}
		}
		MatchmakingService.LeaveRoomAsyncTask leaveRoom = new MatchmakingService.LeaveRoomAsyncTask();
		leaveRoom.c7cc9411392f033dee9802f9b9ca15b21();
		c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(leaveRoom, cb72721790eb9d0ca9e6f1ccfb010aa33.c7088de59e49f7108f520cf7e0bae167e);
		while (!leaveRoom.c762acfd9de32c566fab82e7bbfb0e93f())
		{
			yield return 0;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			yield return Application.LoadLevelAsync("ResourcesLoading");
			if (c3df3d8811955ab953973a7e8c5c4c297)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.c6738a99a1dd128185a2728e161db856b(false);
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c1206463c349318a3daf072e855c7eaec();
			if (m_menuManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_menuManager.ca2697a254bbeb745c522c64f883c925a(MenuManager.MenuPage.None);
				c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1bdd1e7aa891de56d871ae24289f5f8b();
			}
			if (c3df3d8811955ab953973a7e8c5c4c297)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (!c748a20f361d82465b8386e36f745d058)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.WorldMap, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
									m_transitionToInstanceSelection = false;
									OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cd2ff2d0b9710155a2e44c955d431a48d(OnlineService.s_characterId);
									yield break;
								}
							}
						}
						yield break;
					}
				}
			}
			if (!string.IsNullOrEmpty(OnlineService.s_userName))
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
				NetworkManager.AuthenticateAsyncTask authenticate = new NetworkManager.AuthenticateAsyncTask();
				authenticate.c7cc9411392f033dee9802f9b9ca15b21(base.name);
				c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(authenticate, cb72721790eb9d0ca9e6f1ccfb010aa33.c7088de59e49f7108f520cf7e0bae167e);
				while (!authenticate.c762acfd9de32c566fab82e7bbfb0e93f())
				{
					yield return 0;
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
				if (authenticate.ccbba85a67aa095895787b6d432c194b3() == c2597280f86604f98f89309a4de95dd62.Success)
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
					OnlineService.c123f97c79fbb5492a276d756505ecfe3(base.name);
					CharacterService.GetSelectedCharacterAsyncTask getSelectedCharacter = new CharacterService.GetSelectedCharacterAsyncTask();
					getSelectedCharacter.c7cc9411392f033dee9802f9b9ca15b21();
					c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(getSelectedCharacter, cb72721790eb9d0ca9e6f1ccfb010aa33.c7088de59e49f7108f520cf7e0bae167e);
					while (!getSelectedCharacter.c762acfd9de32c566fab82e7bbfb0e93f())
					{
						yield return 0;
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
			else
			{
				yield return c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.StartCoroutine(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<NetworkManager>().c36588361fa2310a4571d2d4ff01ea51f());
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.Login, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
			m_transitionToLogin = false;
			yield break;
		}
	}

	private IEnumerator c8ae2431a1d2bcd7d519810f5165309b4()
	{
		int audioWaitCounter = 30;
		while (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5383bc84e8cae50fac6d2363cda700d1())
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
			if (audioWaitCounter != 0)
			{
				audioWaitCounter--;
				yield return new WaitForSeconds(1f);
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
			break;
		}
		if (audioWaitCounter != 0)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "Timeout waiting for UI Music to load");
			yield break;
		}
	}

	private IEnumerator c0f59d8573fe85c7b9757244eeff0c214()
	{
		IEnumerator UIAudioResourceLoader = cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c9f6a0386ce93c761939b8a4def1e3435.c51989e5eff27ea24d05531bbbf9de22b("FrontEndAudioResources");
		while (UIAudioResourceLoader.MoveNext())
		{
			yield return UIAudioResourceLoader.Current;
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
			yield break;
		}
	}

	public IEnumerator c8af82aebcb8b0e0e756c3e54e337464d(string c806f28438ef18823ada83a6d56d2fe21)
	{
		float downloadProgress = 0f;
		IEnumerator loader = c0f59d8573fe85c7b9757244eeff0c214();
		while (loader.MoveNext())
		{
			yield return loader.Current;
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
			IEnumerator waiter = c8ae2431a1d2bcd7d519810f5165309b4();
			while (waiter.MoveNext())
			{
				yield return waiter.Current;
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
			while (!Application.CanStreamedLevelBeLoaded(c806f28438ef18823ada83a6d56d2fe21))
			{
				downloadProgress = Application.GetStreamProgressForLevel(c806f28438ef18823ada83a6d56d2fe21);
				yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LoadingDemoCorountine progress: " + downloadProgress);
				yield return Application.LoadLevelAsync(c806f28438ef18823ada83a6d56d2fe21);
				yield break;
			}
		}
	}

	public void c68fd59435d154e97d7b60dac8301ed39(string c806f28438ef18823ada83a6d56d2fe21)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "Go to sub level[";
		array[1] = c806f28438ef18823ada83a6d56d2fe21;
		array[2] = "] -";
		array[3] = Time.realtimeSinceStartup;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, string.Concat(array));
		StartCoroutine(c9f651f6ddfee2967bb3330cac1abb9f2(c806f28438ef18823ada83a6d56d2fe21, "OnGoToSubInstance"));
	}

	public void c7ae0e7b8e80603cfc335a2df380802c8()
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<LoadingInGameView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c758cf934d27a077d85165dce3424bb11(true);
	}

	private IEnumerator c9f651f6ddfee2967bb3330cac1abb9f2(string c1acb43343199af7fddcb87e4afcf4a59, string cc23cb1c053e4a8231ab1f9139328d5a2)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<PlayerSpawnClusterManager>.c5ee19dc8d4cccf5ae2de225410458b86.Reset();
		if (!c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c696204347900a421f9e900c068ebdcc7(c1acb43343199af7fddcb87e4afcf4a59, null, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e))
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
					m_transitionToIngame = false;
					cdcc658e3c5be5baafd088fd0bf889371();
					yield break;
				}
			}
		}
		while (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c739bc996d272aeac228d6b5198b164d2())
		{
			yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			BroadcastMessage(cc23cb1c053e4a8231ab1f9139328d5a2, c1acb43343199af7fddcb87e4afcf4a59, SendMessageOptions.DontRequireReceiver);
			yield break;
		}
	}

	private IEnumerator cadac5b28fc6708e91b31417144cd23a4()
	{
		PreJoinAsyncTask preJoin = new PreJoinAsyncTask();
		preJoin.c7cc9411392f033dee9802f9b9ca15b21();
		c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(preJoin, cb72721790eb9d0ca9e6f1ccfb010aa33.c7088de59e49f7108f520cf7e0bae167e);
		while (!preJoin.c762acfd9de32c566fab82e7bbfb0e93f())
		{
			yield return 0;
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
			if (preJoin.ccbba85a67aa095895787b6d432c194b3() == c2597280f86604f98f89309a4de95dd62.Success)
			{
				yield break;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				m_transitionToIngame = false;
				if (preJoin.ccbba85a67aa095895787b6d432c194b3() != c2597280f86604f98f89309a4de95dd62.Error_Disconnected)
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
					cdcc658e3c5be5baafd088fd0bf889371();
					yield break;
				}
			}
		}
	}

	public IEnumerator cf5121fa48b9296b6d6cc76b5799b54a6(string cc23cb1c053e4a8231ab1f9139328d5a2)
	{
		yield return StartCoroutine(cadac5b28fc6708e91b31417144cd23a4());
		int townID = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cb202b2ca376fe940339ca78de78383ab();
		Playlist playlist = MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c2718b579e09549a1cd47620188a40a38(townID);
		if (playlist == null)
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "Trying to enter Playlist [" + townID + "]");
			playlist = MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c9bdc2c0504907130c26fceebf8d21879("lvl_Floasm_Small");
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId = playlist.m_id;
		MatchmakingService.FindMeAPlaylistAsyncTask findSession = new MatchmakingService.FindMeAPlaylistAsyncTask();
		findSession.c7cc9411392f033dee9802f9b9ca15b21(OnlineService.s_characterId, playlist.m_id);
		c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(findSession, cb72721790eb9d0ca9e6f1ccfb010aa33.c7088de59e49f7108f520cf7e0bae167e);
		while (!findSession.c762acfd9de32c566fab82e7bbfb0e93f())
		{
			yield return 0;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (findSession.ccbba85a67aa095895787b6d432c194b3() != c2597280f86604f98f89309a4de95dd62.Success)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						m_transitionToIngame = false;
						if (c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c3baaa4a6dea0fa0c8840ad6ec2f669bb(findSession.GetType()))
						{
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a17840ca5832714e97cc912e5552600(findSession.GetType());
									cdcc658e3c5be5baafd088fd0bf889371(true);
									yield break;
								}
							}
						}
						c01f60631f6d4cee6631245560d19fc36("OnGoToInstance");
						yield break;
					}
				}
			}
			yield return StartCoroutine(c213abf0854ee39dec6edbc3c5d19afa5(cc23cb1c053e4a8231ab1f9139328d5a2));
			yield break;
		}
	}

	public IEnumerator ccf8caad6e1036329c9e3d8b47ba3da2e(string cc23cb1c053e4a8231ab1f9139328d5a2, int c596ba42a2c21a67d5d3b489c87f98a3e)
	{
		yield return StartCoroutine(cadac5b28fc6708e91b31417144cd23a4());
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId = c596ba42a2c21a67d5d3b489c87f98a3e;
		MatchmakingService.FindMeAPlaylistAsyncTask findSession = new MatchmakingService.FindMeAPlaylistAsyncTask();
		findSession.c7cc9411392f033dee9802f9b9ca15b21(OnlineService.s_characterId, c596ba42a2c21a67d5d3b489c87f98a3e);
		c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(findSession, cb72721790eb9d0ca9e6f1ccfb010aa33.c7088de59e49f7108f520cf7e0bae167e);
		while (!findSession.c762acfd9de32c566fab82e7bbfb0e93f())
		{
			yield return 0;
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
			if (findSession.ccbba85a67aa095895787b6d432c194b3() != c2597280f86604f98f89309a4de95dd62.Success)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						m_transitionToIngame = false;
						if (c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c3baaa4a6dea0fa0c8840ad6ec2f669bb(findSession.GetType()))
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
									c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a17840ca5832714e97cc912e5552600(findSession.GetType());
									cdcc658e3c5be5baafd088fd0bf889371(true);
									yield break;
								}
							}
						}
						c01f60631f6d4cee6631245560d19fc36("OnGoToInstance");
						yield break;
					}
				}
			}
			yield return StartCoroutine(c213abf0854ee39dec6edbc3c5d19afa5(cc23cb1c053e4a8231ab1f9139328d5a2));
			yield break;
		}
	}

	public IEnumerator ccf8caad6e1036329c9e3d8b47ba3da2e(string cc23cb1c053e4a8231ab1f9139328d5a2, string c37dc4ee4a3a694110f0e0eb7b086137a)
	{
		yield return StartCoroutine(cadac5b28fc6708e91b31417144cd23a4());
		MatchmakingService.JoinRoomAsyncTask joinSession = new MatchmakingService.JoinRoomAsyncTask();
		joinSession.c7cc9411392f033dee9802f9b9ca15b21(c37dc4ee4a3a694110f0e0eb7b086137a);
		c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(joinSession, cb72721790eb9d0ca9e6f1ccfb010aa33.c7088de59e49f7108f520cf7e0bae167e);
		while (!joinSession.c762acfd9de32c566fab82e7bbfb0e93f())
		{
			yield return 0;
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
			if (joinSession.ccbba85a67aa095895787b6d432c194b3() != c2597280f86604f98f89309a4de95dd62.Success)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						m_transitionToIngame = false;
						if (c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c3baaa4a6dea0fa0c8840ad6ec2f669bb(joinSession.GetType()))
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a17840ca5832714e97cc912e5552600(joinSession.GetType());
									cdcc658e3c5be5baafd088fd0bf889371(true);
									yield break;
								}
							}
						}
						c01f60631f6d4cee6631245560d19fc36("OnGoToInstance");
						yield break;
					}
				}
			}
			yield return StartCoroutine(c213abf0854ee39dec6edbc3c5d19afa5(cc23cb1c053e4a8231ab1f9139328d5a2));
			yield break;
		}
	}

	public IEnumerator c81e05b4c94598a21a8225d096f337021(string cc23cb1c053e4a8231ab1f9139328d5a2, int c596ba42a2c21a67d5d3b489c87f98a3e, GamemodeType c33491fef5353a204dd899a389fc7ec52)
	{
		yield return StartCoroutine(cadac5b28fc6708e91b31417144cd23a4());
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId = c596ba42a2c21a67d5d3b489c87f98a3e;
		MatchmakingService.StartPvPMatchAsyncTask startPvPMatch = new MatchmakingService.StartPvPMatchAsyncTask();
		startPvPMatch.c7cc9411392f033dee9802f9b9ca15b21(c596ba42a2c21a67d5d3b489c87f98a3e, c33491fef5353a204dd899a389fc7ec52);
		c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(startPvPMatch, cb72721790eb9d0ca9e6f1ccfb010aa33.c7088de59e49f7108f520cf7e0bae167e);
		while (!startPvPMatch.c762acfd9de32c566fab82e7bbfb0e93f())
		{
			yield return 0;
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
			if (startPvPMatch.ccbba85a67aa095895787b6d432c194b3() != c2597280f86604f98f89309a4de95dd62.Success)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						m_transitionToIngame = false;
						yield break;
					}
				}
			}
			yield return StartCoroutine(c213abf0854ee39dec6edbc3c5d19afa5(cc23cb1c053e4a8231ab1f9139328d5a2));
			yield break;
		}
	}

	private IEnumerator c213abf0854ee39dec6edbc3c5d19afa5(string cc23cb1c053e4a8231ab1f9139328d5a2)
	{
		PostJoinAsyncTask postJoin = new PostJoinAsyncTask();
		postJoin.c7cc9411392f033dee9802f9b9ca15b21();
		c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(postJoin, cb72721790eb9d0ca9e6f1ccfb010aa33.c7088de59e49f7108f520cf7e0bae167e);
		while (!postJoin.c762acfd9de32c566fab82e7bbfb0e93f())
		{
			yield return 0;
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
			m_transitionToIngame = false;
			if (postJoin.ccbba85a67aa095895787b6d432c194b3() != c2597280f86604f98f89309a4de95dd62.Success)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						c01f60631f6d4cee6631245560d19fc36("OnGoToInstance");
						yield break;
					}
				}
			}
			BroadcastMessage(cc23cb1c053e4a8231ab1f9139328d5a2, SendMessageOptions.DontRequireReceiver);
			yield break;
		}
	}

	private void cd19facc18081b2cfd2ce7ee297b13ebf(Dictionary<int, int> c9697fd3fb817426cd94a594832eafa55)
	{
	}

	public void OnGoToInstance()
	{
	}
}
