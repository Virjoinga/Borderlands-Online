using A;
using Core;
using UnityEngine;

[ExecuteInEditMode]
public class AudioManager : c10946b3d2521e665fb036b763a24460a<AudioManager>
{
	private static string AUDIO_SYSTEM_GO_NAME = "Audio Controller";

	public static void c7cc9411392f033dee9802f9b9ca15b21()
	{
		if (!cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
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
			c1d4e2859d79b21c1bd0b8108933ba4a7();
		}
		if (c06ca0e618478c23eba3419653a19760f<AudioManager>.c5def92cf2ece25f46fbe9356a28a245b)
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
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5def92cf2ece25f46fbe9356a28a245b)
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
				if (c06ca0e618478c23eba3419653a19760f<AudioManager>.c5ee19dc8d4cccf5ae2de225410458b86.transform.parent != c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.transform)
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
					c021d685273b7e43881c601da68a00491();
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<AudioManager>.c5def92cf2ece25f46fbe9356a28a245b)
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
			cdc6412c237d46799b582f1db2f224307();
			return;
		}
	}

	private static AudioSystem c1d4e2859d79b21c1bd0b8108933ba4a7()
	{
		cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c90236f85f4a0b603b56f8daf34c2279e();
		cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.cd93285db16841148ed53a5bbeb35cf20();
		return cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86;
	}

	private static GameObject c434f795f02cadbb95ff7cda3b9827e0a()
	{
		GameObject gameObject = GameObject.Find(AUDIO_SYSTEM_GO_NAME);
		if (null == gameObject)
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "AudioManager.GetAudioGameObject: creating audio GO");
			gameObject = new GameObject(AUDIO_SYSTEM_GO_NAME);
			gameObject.name = AUDIO_SYSTEM_GO_NAME;
			if (null != c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86)
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
				gameObject.transform.parent = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.transform;
			}
			Object.DontDestroyOnLoad(gameObject);
		}
		return gameObject;
	}

	private static void cdc6412c237d46799b582f1db2f224307()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "AudioManager.CreateAudioController()");
		GameObject gameObject = c434f795f02cadbb95ff7cda3b9827e0a();
		gameObject.AddComponent<AudioManager>();
		cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.c3ec6c8a3b3017de44fe7215da4f4ba2d(gameObject.transform);
		GlobalAudioParameterValues.ce23645e7886ffd0e3f287a569d30e42b(gameObject);
	}

	private static void c021d685273b7e43881c601da68a00491()
	{
		if (!c06ca0e618478c23eba3419653a19760f<AudioManager>.c5def92cf2ece25f46fbe9356a28a245b)
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "AudioManager.DestroyAudioController()");
			AudioManager audioManager = c06ca0e618478c23eba3419653a19760f<AudioManager>.c5ee19dc8d4cccf5ae2de225410458b86;
			audioManager.c171d6c47254e2f80258c2d73744c3f56();
			Object.DestroyImmediate(audioManager.gameObject);
			return;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		base.gameObject.hideFlags = HideFlags.DontSave;
		if (!cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
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
			cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c91a7840b219e99c4672cde05157d8b6d(this);
			return;
		}
	}

	protected override void OnDestroy()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "AudioManager.OnDestroy");
		if (cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
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
			cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c91a7840b219e99c4672cde05157d8b6d(c7c135035652c1304a1a3f6ca13062858.c7088de59e49f7108f520cf7e0bae167e);
		}
		base.OnDestroy();
	}

	private void Update()
	{
		cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.Update();
	}

	private void OnLevelWasLoaded(int iLevel)
	{
		cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c8972ba92b262823f7442f6167f31765f();
		cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.cf1cac2831a88ef421c1c1a462d53c86a();
	}

	public void cd366b61ae0481f13c86f0ddbf0a11b55(string cbd985eaff34a1c675cf76d61032274dd)
	{
		if (!cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
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
		if (null == c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86)
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
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (null == playerInfoSync)
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
		Entity entity = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689();
		if (null == entity)
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
		BaseEventTriggerCtl component = entity.gameObject.GetComponent<BaseEventTriggerCtl>();
		if (null == entity)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "AudioManager.TriggerEventByNameOnLocalPlayer: local player entity doesn't contain a BaseEventTriggerCtl component");
					return;
				}
			}
		}
		component.TriggerEventByName(cbd985eaff34a1c675cf76d61032274dd);
	}
}
