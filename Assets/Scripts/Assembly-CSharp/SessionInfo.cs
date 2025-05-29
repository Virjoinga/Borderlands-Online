using System;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class SessionInfo : MonoBehaviour, IPhotonView, IPhotonSerializeView
{
	private static SessionInfo s_instance;

	public PhotonView photonView { get; set; }

	public static SessionInfo c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			return s_instance;
		}
	}

	private void Awake()
	{
		base.gameObject.transform.parent = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.transform;
		if (s_instance != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "SessionInfo is already initialized");
		}
		s_instance = this;
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.c8b2526be2638bb30a29ab8314b369311)
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
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c9d8ee6a5af1e2ca6cb9e7b7a609a6d69());
					stream.caf7283cc5cd9725a88a9cdfa630d92f8((byte)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cfee2582eaf7bd61748c6f890c1e9365d());
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c09c52444051469bac987251aa703ac39());
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.m_showTimerOnScreen);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cdbdfc7767749324b8b1cdac1ae6b9f5b());
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.ce5a94914572053ccdd4c35353ff8d650());
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c1492faa4c1a9b76581845cee4d47d460());
					c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().c21abc56059d171e999147f26bbf75889(stream);
					return;
				}
			}
		}
		string c806f28438ef18823ada83a6d56d2fe = (string)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		ELevelDifficulty c46b57735a769802f4565a74b7185cc1f = (ELevelDifficulty)(byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cf835d249689e450eb7d006607c8f4570((double)stream.cbc3e6f46d26c8fb00a98f05fc700248a());
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.m_showTimerOnScreen = (bool)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		byte b = (byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		string ca437db6d1a465c4b9dfa4a10899f8b8d = (string)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		string c33491fef5353a204dd899a389fc7ec = (string)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().c21abc56059d171e999147f26bbf75889(stream);
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c0d9c8316ee1c20e101fdb8296d17b24a(c806f28438ef18823ada83a6d56d2fe, c46b57735a769802f4565a74b7185cc1f);
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cdbdfc7767749324b8b1cdac1ae6b9f5b() == b)
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
			c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cebe62854ec37f29d056b2acdf39b98b2(ca437db6d1a465c4b9dfa4a10899f8b8d, c33491fef5353a204dd899a389fc7ec);
			return;
		}
	}

	public void ca832d3b6a21513f8e2e31d2d553b63bc()
	{
		photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_RequestMapReady", PhotonTargets.MasterClient, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	public void c8e04fd0fdea380e207956035c9f9da5b()
	{
		photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_RequestRespawnPlayer", PhotonTargets.MasterClient, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	public void cd3e3b856c4fdfeb7ba47c5b0f4236dbd(int c5dfde30d8784694fb9999709d290e6c4)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "IamReadyForSession [" + c5dfde30d8784694fb9999709d290e6c4 + "]");
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_RequestPlayerReady", PhotonTargets.MasterClient, array);
	}

	public void c7a96130ad6e9df15e0a2a70215ea14b9(int c5dfde30d8784694fb9999709d290e6c4)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "IamReadyForWrapup [" + c5dfde30d8784694fb9999709d290e6c4 + "]");
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_RequestPlayerWrapup", PhotonTargets.MasterClient, array);
	}

	[RPC]
	private void RPC_RequestPlayerReady(int characterId, PhotonMessageInfo info)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "RPC_RequestPlayerReady [" + characterId + "]");
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cb062638207d3746ee631744a4709b38f(info.sender.c29a834d12d3895f5680e69a30e6cd9a3);
		playerInfoSync.m_characterId = characterId;
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8762b0b9a035bab0b07fd588a158cd62().c9fd1a16ecf13911e9185b3db92cbd5ac(playerInfoSync);
	}

	[RPC]
	private void RPC_RequestPlayerWrapup(int characterId, PhotonMessageInfo info)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "RPC_RequestPlayerWrapup [" + characterId + "]");
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cb062638207d3746ee631744a4709b38f(info.sender.c29a834d12d3895f5680e69a30e6cd9a3);
		playerInfoSync.m_characterId = characterId;
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8762b0b9a035bab0b07fd588a158cd62().cdfcb6aa8cd9490512a2c0e8ad0380009(playerInfoSync);
	}

	[RPC]
	private void RPC_RequestMapReady(PhotonMessageInfo info)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat("RPC_RequestMapReady ", info.sender, Time.realtimeSinceStartup));
		PlayerInfoSync ceb41162a7cd2a1d5c4a03830e02b = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cb062638207d3746ee631744a4709b38f(info.sender.c29a834d12d3895f5680e69a30e6cd9a3);
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8762b0b9a035bab0b07fd588a158cd62().cb9f18b5a303dcf0caaf374ee4e13f211(ceb41162a7cd2a1d5c4a03830e02b);
	}

	[RPC]
	private void RPC_RequestDisplayCountDown(float countdown, PhotonMessageInfo info)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "RPC_RequestDisplayCountDown");
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (!playerInfoSync)
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
			UIMessage uIMessage = new UIMessage();
			uIMessage.m_type = UIMessage.c7487b4eea694c61027850111354bc24f.c181a87d44cdf850bdb7592b2a6ba24f8;
			uIMessage.m_text = string.Empty;
			uIMessage.m_duration = countdown;
			uIMessage.m_displayCountDown = true;
			c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5(uIMessage);
			return;
		}
	}

	[RPC]
	private void RPC_RequestDisplayUIMessage(bool displayCountDown, float decayDate, float duration, string text, byte type, PhotonMessageInfo info)
	{
		UIMessage uIMessage = new UIMessage();
		uIMessage.m_decayDate = decayDate;
		uIMessage.m_displayCountDown = displayCountDown;
		uIMessage.m_duration = duration;
		uIMessage.m_type = (UIMessage.c7487b4eea694c61027850111354bc24f)type;
		uIMessage.m_text = text;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "RPC_RequestDisplayUIMessage - " + uIMessage.m_text);
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (!playerInfoSync)
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
			c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5(uIMessage);
			return;
		}
	}

	[RPC]
	private void RPC_RequestDisplayEchoMessage(string echoMsgId, PhotonMessageInfo info)
	{
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (!playerInfoSync)
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
			c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5(echoMsgId);
			return;
		}
	}

	[RPC]
	private void RPC_RequestActivateDevice(string deviceName, PhotonMessageInfo info)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.System, "SessionInfo.RPC_RequestActivateDevice");
		GameObject gameObject = GameObject.Find(deviceName);
		int childCount = gameObject.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			gameObject.transform.GetChild(i).gameObject.SetActive(true);
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
			return;
		}
	}

	[RPC]
	private void RPC_RequestActivateCutscene(string clusterName, bool activate, PhotonMessageInfo info)
	{
		UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(Type.GetTypeFromHandle(cb64c05cf4c8e3ae2d20393f004b6d5c1.cc1720d05c75832f704b87474932341c3()));
		for (int i = 0; i < array.Length; i++)
		{
			CutsceneCluster cutsceneCluster = array[i] as CutsceneCluster;
			if (!(cutsceneCluster != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!(cutsceneCluster.name == clusterName))
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
			if (!(cutsceneCluster.m_cutscene != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				continue;
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
			if (activate)
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
				c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c228cd5253b68fa5d8c2b33af0db7ebb4(cutsceneCluster.m_cutscene);
			}
			else
			{
				c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c49fd3d63b08aab39adae6cda3ec40c66(cutsceneCluster.m_cutscene);
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

	[RPC]
	private void RPC_RequestSyncSessionStats(object[] sessionData, PhotonMessageInfo info)
	{
		c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c06778e43cc664bde56af0583cc97cdc0(sessionData);
	}

	[RPC]
	private void RPC_RequestSendSessionStats(object[] sessionData, PhotonMessageInfo info)
	{
		c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c712cfd0ed5ca21466f48bb3a7eada465(sessionData);
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c4b8a1cb99146168143f14eed33617a47();
	}

	[RPC]
	private void RPC_RequestShakeCamera(int intensity)
	{
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		EntityPlayer entityPlayer = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
		if (entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		BadAssFPSCamera badAssFPSCamera = entityPlayer.cc6a7269e9ea93e537de47dc752b09a86();
		if (badAssFPSCamera == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		badAssFPSCamera.c19a5441553998e0c8500003947ff7737((BadAssFPSCamera.ShakeType)intensity);
	}

	[RPC]
	private void RPC_RequestSetPlayerActions(int actions)
	{
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		Entity entity = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689();
		if (entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		PlayerController component = entity.GetComponent<PlayerController>();
		if (component == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		component.cb96bf03f67eb5295e81ce489d4b82bea((PlayerAction)actions);
	}

	[RPC]
	private void RPC_SendPlayerToTown()
	{
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c01f60631f6d4cee6631245560d19fc36("OnGoToInstance");
	}

	[RPC]
	private void RPC_AddObjectiveToClient(string objectiveId, string titleId, string detailId)
	{
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		c1ee7921b0c3cce194fb7cae41b5a9d82<ObjectiveManager>.c5ee19dc8d4cccf5ae2de225410458b86.cc12be9962964908b417f759be8b7e9b9(objectiveId, titleId, detailId);
	}

	[RPC]
	private void RPC_RemoveObjectiveFromClient(string objectiveId, bool isSuccess)
	{
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		c1ee7921b0c3cce194fb7cae41b5a9d82<ObjectiveManager>.c5ee19dc8d4cccf5ae2de225410458b86.cbdcabb7d04b1a020f5dc77a9541ce50b(objectiveId, isSuccess);
	}

	[RPC]
	private void RPC_RequestRespawnPlayer(PhotonMessageInfo info)
	{
	}
}
