using System;
using A;
using Core;
using UnityEngine;

public class ClientSession : SessionLogic, IClientSession
{
	private Utils.Timer m_interludeTimer = new Utils.Timer();

	private Utils.Timer m_syncTimer = new Utils.Timer();

	private int m_staticNetworkObjectCount;

	private bool m_isDisplayingWrapupPage;

	public override bool cb9efc4af2006b47000b468b9df139a30()
	{
		return m_SessionSM.ccbc3718dd3d0e1356fa98d45c46d48ea("Playing");
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		ShootingTestMenu shootingTestMenu = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.gameObject.AddComponent<ShootingTestMenu>();
		shootingTestMenu.m_Visible = false;
	}

	public override void c5c15220c3e633306fef152f245ce53fa()
	{
		if (!m_isDisplayingWrapupPage)
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
			GameFlowManager c5ee19dc8d4cccf5ae2de225410458b = c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86;
			if (c5ee19dc8d4cccf5ae2de225410458b != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c5ee19dc8d4cccf5ae2de225410458b.cec9cdae23444bbac5cad953e7fc1f8e9();
			}
		}
		if (!(c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c20e43347435e746a8d6d3d2c3d99c2f6().cad4b9805ada962a49e6eb4b43bce403b(false);
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c20e43347435e746a8d6d3d2c3d99c2f6().c881ca682404299c847daa474407e6ac0(false);
			return;
		}
	}

	public override void cad90a477761d59d842235621762e4fe8()
	{
		m_SessionSM.c64dc51f788493a1a9e7999e9e2317ddf("Waiting");
		m_SessionSM.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0("Waiting").c29bd491ddfcae67753d8f527c6012787 += cc039f2d04a9cc4387bf84914b3ac3709;
		m_SessionSM.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0("Waiting").c0fd9a54cc4e27ca7b74690de5048cac1 += c635c150f673e0a0fed891fd1f7be9ca6;
		m_SessionSM.c64dc51f788493a1a9e7999e9e2317ddf("Loading");
		m_SessionSM.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0("Loading").cd8433fc60d5e36e141ca687753779c1f += c4a03b66c7907e319a5bb0c979d7ec9a5;
		m_SessionSM.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0("Loading").c0fd9a54cc4e27ca7b74690de5048cac1 += c679626d7341b8cdd8040f78b34953068;
		m_SessionSM.c64dc51f788493a1a9e7999e9e2317ddf("StaticSynchronizing");
		m_SessionSM.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0("StaticSynchronizing").cd8433fc60d5e36e141ca687753779c1f += ce05969195cf0432ee226ea7b6021cab9;
		m_SessionSM.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0("StaticSynchronizing").c29bd491ddfcae67753d8f527c6012787 += ca73afb83cb8a028e05cec53171c4d6bc;
		m_SessionSM.c64dc51f788493a1a9e7999e9e2317ddf("DynamicSynchronizing");
		m_SessionSM.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0("DynamicSynchronizing").cd8433fc60d5e36e141ca687753779c1f += c4674decb6210c5affb3ea3046fada378;
		m_SessionSM.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0("DynamicSynchronizing").c29bd491ddfcae67753d8f527c6012787 += c0d9d0bcad6300f178e624828573930b8;
		m_SessionSM.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0("DynamicSynchronizing").c0fd9a54cc4e27ca7b74690de5048cac1 += cd0da9bf83e04fcce3738333f3263a97a;
		m_SessionSM.c64dc51f788493a1a9e7999e9e2317ddf("Playing");
		m_SessionSM.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0("Playing").cd8433fc60d5e36e141ca687753779c1f += cc70df5a59d4ac03df8ae3fed91092d87;
		m_SessionSM.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0("Playing").c29bd491ddfcae67753d8f527c6012787 += c300586fdc7ebdf32fb1ca0dd85a152d5;
		m_SessionSM.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0("Playing").c0fd9a54cc4e27ca7b74690de5048cac1 += c92aa468a36f5a9bb65cafe0bb03354d0;
		m_SessionSM.c64dc51f788493a1a9e7999e9e2317ddf("Interlude");
		m_SessionSM.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0("Interlude").cd8433fc60d5e36e141ca687753779c1f += cfe3430c8ec8473fd3ace351981257b1a;
		m_SessionSM.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0("Interlude").c29bd491ddfcae67753d8f527c6012787 += c82a89ea35b1202afdb2cd1afb203200a;
		m_SessionSM.c3d651aa95fd9820e9e2c328cc63e13e9("Waiting");
	}

	private void cc039f2d04a9cc4387bf84914b3ac3709()
	{
	}

	private void c635c150f673e0a0fed891fd1f7be9ca6()
	{
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.gameObject.AddComponent<PlayerSkillTreeManage>();
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.gameObject.AddComponent<PassiveSkillsManager>();
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
					if (InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.gameObject.AddComponent<InteractionManager>();
					}
					if (c06ca0e618478c23eba3419653a19760f<TownNpcManager>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.gameObject.AddComponent<TownNpcManager>();
					}
					if (c06ca0e618478c23eba3419653a19760f<VisibilityManager>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.gameObject.AddComponent<VisibilityManager>();
								return;
							}
						}
					}
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.gameObject.AddComponent<AttackManager>();
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.gameObject.AddComponent<Arbitrator>();
		DamageManager damageManager = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.gameObject.AddComponent<DamageManager>();
		damageManager.c5c5b57d23b5b73637a6ed6524fed2be5(c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86);
		damageManager.c5c5b57d23b5b73637a6ed6524fed2be5(c06ca0e618478c23eba3419653a19760f<ScoringManager>.c5ee19dc8d4cccf5ae2de225410458b86);
	}

	private void c4a03b66c7907e319a5bb0c979d7ec9a5()
	{
		if ((bool)LevelObjectSyncManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			LevelObjectSyncManager.c5ee19dc8d4cccf5ae2de225410458b86.cac7688b05e921e2be3f92479ba44b4a8();
		}
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "SessionInfo_Loading_OnEnter:" + Time.time);
		m_isMapLoaded = false;
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c68fd59435d154e97d7b60dac8301ed39(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.ce5a94914572053ccdd4c35353ff8d650());
		c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134("guidance_selection");
	}

	private void c679626d7341b8cdd8040f78b34953068()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "SessionInfo_Loading_OnExit:" + Time.time);
		c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c78d87698736a1e200b5e7caf5ae1d950();
		m_isMapLoaded = true;
	}

	private void ce05969195cf0432ee226ea7b6021cab9()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "SessionInfo_StaticSynchronizing_OnEnter:" + Time.time);
		UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(Type.GetTypeFromHandle(c25d4851649a424abaab00ff33fb1765a.cc1720d05c75832f704b87474932341c3()));
		m_staticNetworkObjectCount = array.Length;
		PhotonNetwork.cda9bc04ce8997ffe268cc6b552dd0dca(1, true);
	}

	private void ca73afb83cb8a028e05cec53171c4d6bc()
	{
		int num = c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c6d037f57d903e6bcdcc24348eeefb88c(Entity.EntityType.Object);
		if (num < m_staticNetworkObjectCount)
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
			m_SessionSM.c3d651aa95fd9820e9e2c328cc63e13e9("DynamicSynchronizing");
			return;
		}
	}

	private void c4674decb6210c5affb3ea3046fada378()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "SessionInfo_DynamicSynchronizing_OnEnter:" + Time.time);
		PhotonNetwork.cda9bc04ce8997ffe268cc6b552dd0dca(2, true);
		m_syncTimer.Start(1f);
	}

	private void c0d9d0bcad6300f178e624828573930b8()
	{
		if (!m_syncTimer.cf928603d375f06225f9eb5213fb17bd4())
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
			m_SessionSM.c3d651aa95fd9820e9e2c328cc63e13e9("Playing");
			return;
		}
	}

	private void cd0da9bf83e04fcce3738333f3263a97a()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "SessionInfo_DynamicSynchronizing_OnExit:" + Time.time);
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (!(playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			PhotonNetwork.cda9bc04ce8997ffe268cc6b552dd0dca(3, true);
			SessionInfo.c5ee19dc8d4cccf5ae2de225410458b86.ca832d3b6a21513f8e2e31d2d553b63bc();
			return;
		}
	}

	private void cc70df5a59d4ac03df8ae3fed91092d87()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "SessionInfo_Playing_OnEnter:" + Time.time);
		c06ca0e618478c23eba3419653a19760f<ScoringManager>.c5ee19dc8d4cccf5ae2de225410458b86.c287eb409bca23d40ccca6e805052673d();
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (!playerInfoSync)
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
			c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0888ee52497af70d4cc14624cbd11269();
			return;
		}
	}

	private void c300586fdc7ebdf32fb1ca0dd85a152d5()
	{
	}

	private void c92aa468a36f5a9bb65cafe0bb03354d0()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "SessionInfo_Playing_OnExit:" + Time.time);
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if ((bool)playerInfoSync)
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
			switch (playerInfoSync.c2d17ea39faa888e633ce06615ddf5c6a)
			{
			case PlayerInfoSync.PlayerState.PlayerAndMapReady:
			case PlayerInfoSync.PlayerState.Spawned:
				playerInfoSync.c2d17ea39faa888e633ce06615ddf5c6a = PlayerInfoSync.PlayerState.PlayerReady;
				break;
			case PlayerInfoSync.PlayerState.MapReady:
				playerInfoSync.c2d17ea39faa888e633ce06615ddf5c6a = PlayerInfoSync.PlayerState.None;
				break;
			}
		}
		PhotonNetwork.cda9bc04ce8997ffe268cc6b552dd0dca(1, false);
		PhotonNetwork.cda9bc04ce8997ffe268cc6b552dd0dca(2, false);
		PhotonNetwork.cda9bc04ce8997ffe268cc6b552dd0dca(3, false);
	}

	private void cfe3430c8ec8473fd3ace351981257b1a()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "SessionInfo_Interlude_OnEnter:" + Time.time);
		m_isDisplayingWrapupPage = false;
		if (string.IsNullOrEmpty(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.ce5a94914572053ccdd4c35353ff8d650()))
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
			c06ca0e618478c23eba3419653a19760f<ScoringManager>.c5ee19dc8d4cccf5ae2de225410458b86.ceff4c174ebf3c3bce652f8cad735b333();
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Framework, "Client Session -- Deinitialize  -- ShowSummaryBoard");
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPvPInfoView>().c4effbb7e0f68e0d6297d5bb56a935bfb();
					m_isDisplayingWrapupPage = true;
					goto IL_0154;
				}
			}
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (!(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c1492faa4c1a9b76581845cee4d47d460() == "GamemodePvE"))
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
					if (!(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c1492faa4c1a9b76581845cee4d47d460() == "GameModeSurvival"))
					{
						goto IL_0154;
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWrapupView>().c6c0790cec120a0223fe798ec4a63029a();
				m_isDisplayingWrapupPage = true;
			}
		}
		goto IL_0154;
		IL_0154:
		m_interludeTimer.Start(1f);
	}

	private void c82a89ea35b1202afdb2cd1afb203200a()
	{
		if (string.IsNullOrEmpty(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.ce5a94914572053ccdd4c35353ff8d650()))
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
		if (!m_interludeTimer.cf928603d375f06225f9eb5213fb17bd4())
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
			m_SessionSM.c3d651aa95fd9820e9e2c328cc63e13e9("Loading");
			return;
		}
	}

	public void c199c572672377bf874bb8b15ab36279e()
	{
		m_isDisplayingWrapupPage = true;
	}

	public override void OnMapChange()
	{
		if (!m_SessionSM.ccbc3718dd3d0e1356fa98d45c46d48ea("Playing"))
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
			if (!m_SessionSM.ccbc3718dd3d0e1356fa98d45c46d48ea("Waiting"))
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
				break;
			}
		}
		m_SessionSM.c3d651aa95fd9820e9e2c328cc63e13e9("Interlude");
	}

	public override void OnGoToSubInstance(string mapName)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "ClientSession.OnGoToSubInstance: ";
		array[1] = mapName;
		array[2] = " ...done - ";
		array[3] = Time.realtimeSinceStartup;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array));
		m_SessionSM.c3d651aa95fd9820e9e2c328cc63e13e9("StaticSynchronizing");
	}

	public override void OnGoToInstance()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "Am I ready");
		SessionInfo.c5ee19dc8d4cccf5ae2de225410458b86.cd3e3b856c4fdfeb7ba47c5b0f4236dbd(OnlineService.s_characterId);
	}
}
