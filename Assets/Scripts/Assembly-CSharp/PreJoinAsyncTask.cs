using A;
using UnityEngine;

public class PreJoinAsyncTask : cac110d4f4a99811889eb5dc85c420d82
{
	private AsyncOperation m_resourcesLoading;

	public PlayerProperties m_playerProperties;

	public void c7cc9411392f033dee9802f9b9ca15b21()
	{
		c92c7f03b81b92c00ce0b49a2b9058106 = 60f;
	}

	public override void Start()
	{
		base.Start();
		MatchmakingService.LeaveRoomAsyncTask leaveRoomAsyncTask = new MatchmakingService.LeaveRoomAsyncTask();
		leaveRoomAsyncTask.c7cc9411392f033dee9802f9b9ca15b21();
		c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(leaveRoomAsyncTask, OnLeaveRoom);
	}

	private void OnLeaveRoom(cac110d4f4a99811889eb5dc85c420d82 task, c2597280f86604f98f89309a4de95dd62 result)
	{
		if (!(task is MatchmakingService.LeaveRoomAsyncTask))
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
		if (c762acfd9de32c566fab82e7bbfb0e93f())
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
		m_resourcesLoading = Application.LoadLevelAsync("ResourcesLoading");
	}

	public override void Update(float time)
	{
		base.Update(time);
		if (m_resourcesLoading == null)
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
			if (!m_resourcesLoading.isDone)
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
				m_resourcesLoading = ce9190133550e22a84e0d1dc4ba986de7.c7088de59e49f7108f520cf7e0bae167e;
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.c6738a99a1dd128185a2728e161db856b(true);
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c1206463c349318a3daf072e855c7eaec();
				MenuManager component = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<MenuManager>();
				if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					component.ca2697a254bbeb745c522c64f883c925a(MenuManager.MenuPage.None);
					c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1bdd1e7aa891de56d871ae24289f5f8b();
				}
				RetrieveCurrentCharacterDataAsyncTask retrieveCurrentCharacterDataAsyncTask = new RetrieveCurrentCharacterDataAsyncTask();
				retrieveCurrentCharacterDataAsyncTask.c7cc9411392f033dee9802f9b9ca15b21();
				c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(retrieveCurrentCharacterDataAsyncTask, OnRetrieveCurrentCharacterData);
				return;
			}
		}
	}

	private void OnRetrieveCurrentCharacterData(cac110d4f4a99811889eb5dc85c420d82 task, c2597280f86604f98f89309a4de95dd62 result)
	{
		if (c762acfd9de32c566fab82e7bbfb0e93f())
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
					return;
				}
			}
		}
		c27b389b7bd08230f8586d5ac4896cc41(result);
	}
}
