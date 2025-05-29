using System;
using System.Collections;
using System.Collections.Generic;
using A;
using Core;

internal class PresenceService : OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>, IPresenceService
{
	public readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

	private List<OnPresenceUpdated> mOnPresenceUpdated;

	private List<OnNotifyAntiAddictionLevelEvent> mOnNotifyAntiAddictionLevelEvent;

	private OnGetPresence mOnGetPresence;

	private OnGetAntiAddictionLevel mOnGetAntiAddictionLevel;

	private OnGetFriendsPresence mOnGetFriendsPresence;

	private OnSearchForCharacter mOnSearchForCharacter;

	public PresenceService()
	{
		mOnPresenceUpdated = new List<OnPresenceUpdated>();
		mOnNotifyAntiAddictionLevelEvent = new List<OnNotifyAntiAddictionLevelEvent>();
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(147, OnGetPresenceResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(146, OnGetAllFriendsPresenceResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(152, OnCharacterSearch);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(85, OnGetAntiLevel);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(195, OnPresenceUpdatedEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(163, OnKickPlayerEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(159, OnNotifyAntiAddictionLevelEvent);
	}

	public void c171cc9079535e716dc2c8dd3677a6256(int c5dfde30d8784694fb9999709d290e6c4, OnGetPresence c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGetPresence = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(147, array);
	}

	public void c21e522aeeaf7bcca3d0ea44730a13b6d(OnGetPresence c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGetPresence = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = OnlineService.s_characterId;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(147, array);
	}

	private void OnGetPresenceResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGetPresence == null)
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
			if (operationResponse == 0)
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
				Hashtable c90ecb087828ed9ceb9c00eafb6d52f4c = (Hashtable)parameters[0];
				mOnGetPresence(new Presence(c90ecb087828ed9ceb9c00eafb6d52f4c));
			}
			else
			{
				mOnGetPresence(cce1d54b58f77fe2e3eead34ccfa0c349.c7088de59e49f7108f520cf7e0bae167e);
			}
			mOnGetPresence = c4b39d8744e894d579fac06b1430b4cb2.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c7f3c9cb8a62583c02d7f21036edfe783(OnGetFriendsPresence c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGetFriendsPresence = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(146, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnGetAllFriendsPresenceResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGetFriendsPresence == null)
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
			if (operationResponse == 0)
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
				Presence[] array = c4986910079ec7090cf155f13069c69e3.c0a0cdf4a196914163f7334d9b0781a04(parameters.Count);
				int num = 0;
				using (Dictionary<byte, object>.ValueCollection.Enumerator enumerator = parameters.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						Hashtable c90ecb087828ed9ceb9c00eafb6d52f4c = (Hashtable)current;
						array[num++] = new Presence(c90ecb087828ed9ceb9c00eafb6d52f4c);
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							goto end_IL_007d;
						}
						continue;
						end_IL_007d:
						break;
					}
				}
				mOnGetFriendsPresence(array);
			}
			else
			{
				mOnGetFriendsPresence(c858372bcea9412766bd733d814236627.c7088de59e49f7108f520cf7e0bae167e);
			}
			mOnGetFriendsPresence = c23394ff5656486b77adb4126156ef7c8.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c5e81ec29448677f59e3bf0274e44ece8(int c5dfde30d8784694fb9999709d290e6c4, int ce734554c3b497e7da4c68d5b3769da0f)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		array[1] = ce734554c3b497e7da4c68d5b3769da0f;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(155, array);
	}

	public void c072a932603fc0be0d70802256d009791(OnSearchForCharacter c2db84530ef366a6deb001d449d4aa151, string cf02cbedfd63c343e590df85de90aed56)
	{
		mOnSearchForCharacter = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = cf02cbedfd63c343e590df85de90aed56;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(152, array);
	}

	private void OnCharacterSearch(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnSearchForCharacter == null)
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
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					Hashtable c90ecb087828ed9ceb9c00eafb6d52f4c = (Hashtable)parameters[0];
					Presence presence = new Presence(c90ecb087828ed9ceb9c00eafb6d52f4c);
					mOnSearchForCharacter(presence);
					goto IL_0074;
				}
			}
			mOnSearchForCharacter(cce1d54b58f77fe2e3eead34ccfa0c349.c7088de59e49f7108f520cf7e0bae167e);
			goto IL_0074;
			IL_0074:
			mOnSearchForCharacter = cb36ec5ed71adad411d4583a6ec562978.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void OnKickPlayerEvent(Dictionary<byte, object> parameters)
	{
		string text = "You have been Kicked by Server[" + (int)parameters[0] + "]";
		if (!string.IsNullOrEmpty(text))
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
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, text);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ChatView>().cdf1b518a606ae8fae32a93c7d3abd6b2(ChatParameter.System, string.Empty, text, 0, string.Empty);
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.c5a4ebf25aa046ef293fa9ea449fcbb09();
	}

	public void c0f6aa0d444e5502c616b3ad938a680c5(int c78dba8d26b56679047a9607121c23133, OnGetAntiAddictionLevel c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGetAntiAddictionLevel = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c78dba8d26b56679047a9607121c23133;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(85, array);
	}

	public void OnGetAntiLevel(short operationResponse, Dictionary<byte, object> parameters)
	{
		int num = (int)parameters[0];
		int num2 = (int)parameters[1];
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "OnGetAntiLevel  accountId:";
		array[1] = num;
		array[2] = " antilevel:";
		array[3] = num2;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array));
		if (mOnGetAntiAddictionLevel == null)
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
			mOnGetAntiAddictionLevel(num, num2);
			return;
		}
	}

	public void ce9889db06033bab789a717780b17135d(OnPresenceUpdated c2db84530ef366a6deb001d449d4aa151)
	{
		mOnPresenceUpdated.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cd0ba1bc2fbda11d0b7735073390c54bd(OnPresenceUpdated c2db84530ef366a6deb001d449d4aa151)
	{
		mOnPresenceUpdated.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnPresenceUpdatedEvent(Dictionary<byte, object> parameters)
	{
		Presence presence = new Presence((Hashtable)parameters[0]);
		mOnPresenceUpdated.ForEach(delegate(OnPresenceUpdated c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(presence);
		});
	}

	public void cbcece01022c83b7cef2eb06b9414e3d8(OnNotifyAntiAddictionLevelEvent c2db84530ef366a6deb001d449d4aa151)
	{
		mOnNotifyAntiAddictionLevelEvent.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c2b3deeb51ec97b16a35cd9df54744fbc(OnNotifyAntiAddictionLevelEvent c2db84530ef366a6deb001d449d4aa151)
	{
		mOnNotifyAntiAddictionLevelEvent.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void OnNotifyAntiAddictionLevelEvent(Dictionary<byte, object> parameters)
	{
		int accountId = (int)parameters[0];
		int antilevel = (int)parameters[1];
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "OnNotifyAntiLevel  accountId:";
		array[1] = accountId;
		array[2] = " antilevel:";
		array[3] = antilevel;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array));
		mOnNotifyAntiAddictionLevelEvent.ForEach(delegate(OnNotifyAntiAddictionLevelEvent c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(accountId, antilevel);
		});
	}
}
