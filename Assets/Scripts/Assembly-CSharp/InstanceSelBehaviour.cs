using System.Collections;
using A;
using UnityEngine;
using XsdSettings;

public class InstanceSelBehaviour : StepBehaviour
{
	private delegate void InputCheckFunc();

	private const string SCENE_NAME = "Lobby_01";

	protected LobbyCameraController _camController;

	private InputCheckFunc _funcWaitingCheck;

	public override void OnShow(FrontEndStepManager.StepState lastStep, object data = null)
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c758cf934d27a077d85165dce3424bb11(true);
		StartCoroutine(cc667edb2d84ae8231e0a6d4ae53a936b(lastStep));
	}

	public override void ca9a7e4f5830bea46045e5de793b42658(FrontEndStepManager.StepState c4563c3e865ced83101267c98f318b921)
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c758cf934d27a077d85165dce3424bb11(true);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<InventoryView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<CharInfoView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<QuestListView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<NPCDialogView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<QuestTrackView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<MatchMakingView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<SkillTreeView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>()._enterLevelFunc = ccaddab9d4477b0348c03e66ec878a152.c7088de59e49f7108f520cf7e0bae167e;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<InstanceSelectView>();
		SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cac7688b05e921e2be3f92479ba44b4a8();
		QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cdda1108806b8a31337c338a488b30f1e();
	}

	private void caee01a15e35cf4f987cc7e586faee0b1()
	{
		GameObject gameObject = GameObject.Find("LA");
		if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Transform transform = gameObject.transform.FindChild("Camera/LobbyCameraContainer");
			if (transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				transform.gameObject.SetActive(true);
			}
			transform = gameObject.transform.FindChild("Scenes/Character_sellection");
			if (transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				transform.gameObject.SetActive(false);
			}
			transform = gameObject.transform.FindChild("Camera/Class_selection_Camera");
			if (transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				transform.gameObject.SetActive(false);
			}
		}
		gameObject = GameObject.Find("LD");
		LobbyBehaviour[] componentsInChildren = gameObject.GetComponentsInChildren<LobbyBehaviour>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i]._EnterLevelProc = c88b5b1b80a7681024b67028517f0c089;
			componentsInChildren[i].c53110ece4e7b27b1427b8ee45884568e();
		}
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

	private IEnumerator cc667edb2d84ae8231e0a6d4ae53a936b(FrontEndStepManager.StepState c6cb4782d4bd417527304c501b904f4fb)
	{
		if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_offlineMode)
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
			CharacterService.GetSelectedCharacterAsyncTask getSelectedCharacter = new CharacterService.GetSelectedCharacterAsyncTask();
			getSelectedCharacter.c7cc9411392f033dee9802f9b9ca15b21();
			c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(getSelectedCharacter, cb72721790eb9d0ca9e6f1ccfb010aa33.c7088de59e49f7108f520cf7e0bae167e);
			while (!getSelectedCharacter.c762acfd9de32c566fab82e7bbfb0e93f())
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
				break;
			}
		}
		if ("Lobby_01" != Application.loadedLevelName)
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
			yield return StartCoroutine(c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c8af82aebcb8b0e0e756c3e54e337464d("Lobby_01"));
		}
		LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().c7c03e6f29c8281984fdd564fed20468c();
		SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c076bcbb538ab7a02f13183c99cc8c79e();
		QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().ccc9d3a38966dc10fedb531ea17d24611();
		cfe8cebcb3aa062da9e7b72636cd55bbc();
		QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().c50686cce5baffaa301e3f55f448c9ac8(ce72f714dc6927f7c20a591828a3b1f2f);
	}

	private void Update()
	{
		if (_funcWaitingCheck != null)
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
			_funcWaitingCheck();
		}
		if (LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().m_bQuestInited)
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
			if (GameObject.Find("LA") != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (GameObject.Find("LD") != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().m_bQuestInited = false;
					caee01a15e35cf4f987cc7e586faee0b1();
				}
			}
		}
		c0823d0fe20486e5f04efefe34bb94d12();
	}

	public void cfe8cebcb3aa062da9e7b72636cd55bbc()
	{
		InstanceSelectView instanceSelectView = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>();
		instanceSelectView.cd93285db16841148ed53a5bbeb35cf20();
		instanceSelectView._enterLevelFunc = c88b5b1b80a7681024b67028517f0c089;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<InventoryView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<CharInfoView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<QuestTrackView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<QuestListView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<NPCDialogView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<MatchMakingView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<SkillTreeView>();
	}

	public void c88b5b1b80a7681024b67028517f0c089(int c717dab0494f3f0f159b8bd8bc7c8b729)
	{
		if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().cd0069281ff5290a7e6c484b6aed3933d)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c9d057c2188e7d2872aa3ec71517e92ae = true;
			if (c717dab0494f3f0f159b8bd8bc7c8b729 != 3)
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
				if (c717dab0494f3f0f159b8bd8bc7c8b729 != 4)
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().c23ffb495db7c9da62404f1cc24a67351();
				}
			}
			c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cfe7182ecd28c1d073193664c0a470e42("OnGoToInstance", c717dab0494f3f0f159b8bd8bc7c8b729);
			return;
		}
	}

	private void c0823d0fe20486e5f04efefe34bb94d12()
	{
		PlayerProperties playerProperties = new PlayerProperties();
		playerProperties.m_name = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409();
		playerProperties.m_exp = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c623008f5bbe4bf72af447d08f62aa043();
		playerProperties.m_avatarDna = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c093d70e3287743ce2bc905d2c4b341f3();
		playerProperties.m_level = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7513e66c4e0fc55e6fea9dd9cb8b9943();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().c0be25dad7f3b503064fc98b654b8c830(playerProperties);
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CharInfoView>() == null)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CharInfoView>().c0be25dad7f3b503064fc98b654b8c830(playerProperties);
			return;
		}
	}

	protected virtual void ce72f714dc6927f7c20a591828a3b1f2f(int c731f8f565b2035819f3412520ff285b3, QuestReward[] c55dd37540e00b15834b57c55fd71369f)
	{
		bool flag = false;
		if (!LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().cbdf72842c7a6a0a539f425affd93e61b())
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<QuestListView>().c150264a18c2cb408479d3f072cac8cc1 = false;
			return;
		}
	}
}
