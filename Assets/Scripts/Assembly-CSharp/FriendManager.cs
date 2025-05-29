using System.Collections.Generic;
using System.Linq;
using A;
using Core;

public class FriendManager : IFriendServiceNotificationListerner
{
	protected static FriendManager _FriendInstance;

	private Dictionary<int, PlayerProperties> m_FriendMap;

	private Dictionary<int, int> m_FriendInvitationMap;

	private Dictionary<int, PlayerProperties> m_FriendInvitationInfoMap;

	private Dictionary<int, Presence> m_FriendPresenceMap;

	private Dictionary<int, Presence> m_SearchResultMap;

	private List<int> m_FriendIds;

	public bool m_bNewMessageUnread;

	private int m_TargetCharacterId = -1;

	private int m_MaxFriendNumber = 30;

	private FriendManager()
	{
		if (m_FriendMap == null)
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
			m_FriendMap = new Dictionary<int, PlayerProperties>();
			m_FriendMap.Clear();
		}
		if (m_FriendInvitationMap == null)
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
			m_FriendInvitationMap = new Dictionary<int, int>();
			m_FriendInvitationMap.Clear();
		}
		if (m_FriendInvitationInfoMap == null)
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
			m_FriendInvitationInfoMap = new Dictionary<int, PlayerProperties>();
			m_FriendInvitationInfoMap.Clear();
		}
		if (m_FriendPresenceMap == null)
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
			m_FriendPresenceMap = new Dictionary<int, Presence>();
			m_FriendPresenceMap.Clear();
		}
		if (m_SearchResultMap == null)
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
			m_SearchResultMap = new Dictionary<int, Presence>();
			m_SearchResultMap.Clear();
		}
		if (m_FriendIds == null)
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
			m_FriendIds = new List<int>();
			m_FriendIds.Clear();
		}
		c1ee7921b0c3cce194fb7cae41b5a9d82<FriendServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(this);
		OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ce9889db06033bab789a717780b17135d(OnPresenceUpdated);
	}

	void IFriendServiceNotificationListerner.OnFriendRequestReceived(FriendRequest friendRequest)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_name + " Received friend request from " + friendRequest.mSender);
		if (m_FriendInvitationMap.ContainsKey(friendRequest.mSender))
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
			m_FriendInvitationMap[friendRequest.mSender] = friendRequest.mMessageId;
		}
		else
		{
			m_FriendInvitationMap.Add(friendRequest.mSender, friendRequest.mMessageId);
		}
		OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c171cc9079535e716dc2c8dd3677a6256(friendRequest.mSender, c84c18b52ef8edc525b96f9683012fe90);
	}

	void IFriendServiceNotificationListerner.OnNewFriend(Presence friendInfo)
	{
		if (friendInfo == null)
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
			if (m_FriendPresenceMap.ContainsKey(friendInfo.mCharacterId))
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
				if (!m_FriendIds.Contains(friendInfo.mCharacterId))
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
					m_FriendIds.Add(friendInfo.mCharacterId);
				}
				m_FriendPresenceMap.Add(friendInfo.mCharacterId, friendInfo);
				c8fdc385e385da5a2faa612d3ea1448b2();
				return;
			}
		}
	}

	void IFriendServiceNotificationListerner.OnUnfriended(int friendCharacterId)
	{
		if (m_FriendPresenceMap.ContainsKey(friendCharacterId))
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
			m_FriendPresenceMap.Remove(friendCharacterId);
		}
		if (m_FriendIds.Contains(friendCharacterId))
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
			m_FriendIds.Remove(friendCharacterId);
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<FriendView>().c263a18e823d534fe933bf797fd17c221();
	}

	public static FriendManager c71f6ce28731edfd43c976fbd57c57bea()
	{
		if (_FriendInstance == null)
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
			_FriendInstance = new FriendManager();
		}
		return _FriendInstance;
	}

	public void ca3a6f1d4f75253e05b3beb3c71f0c90a()
	{
		m_FriendMap.Clear();
		m_FriendInvitationMap.Clear();
		m_FriendInvitationInfoMap.Clear();
		PlayerProperties playerProperties = new PlayerProperties();
		playerProperties.m_id = 4;
		playerProperties.m_level = 11;
		playerProperties.m_name = "hehe";
		PlayerProperties playerProperties2 = new PlayerProperties();
		playerProperties2.m_id = 5;
		playerProperties2.m_level = 13;
		playerProperties2.m_name = "heheaaa";
		PlayerProperties playerProperties3 = new PlayerProperties();
		playerProperties3.m_id = 6;
		playerProperties3.m_level = 16;
		playerProperties3.m_name = "absd";
		m_FriendMap.Add(4, playerProperties);
		m_FriendInvitationMap.Add(4, 100);
		m_FriendInvitationInfoMap.Add(4, playerProperties);
		m_FriendInvitationMap.Add(5, 101);
		m_FriendInvitationInfoMap.Add(5, playerProperties2);
		m_FriendInvitationMap.Add(6, 102);
		m_FriendInvitationInfoMap.Add(6, playerProperties3);
	}

	public void c0d1b2121def725b11ad7317d4212131a(int c82fcbab5e578dc3a31c1f662916bd87e)
	{
		m_TargetCharacterId = c82fcbab5e578dc3a31c1f662916bd87e;
	}

	protected void OnGetFriendsPresence(Presence[] presence)
	{
		m_FriendIds.Clear();
		m_FriendPresenceMap.Clear();
		if (presence != null)
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
			for (int i = 0; i < presence.Count(); i++)
			{
				m_FriendIds.Add(presence[i].mCharacterId);
				m_FriendPresenceMap.Add(presence[i].mCharacterId, presence[i]);
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
		}
		c8fdc385e385da5a2faa612d3ea1448b2();
	}

	public Presence ce9b5878739f3b5cba4562c672e5555e1(int c5612a459a84ffdb41c885401433cd62d)
	{
		int key = m_FriendIds[c5612a459a84ffdb41c885401433cd62d];
		if (m_FriendPresenceMap.ContainsKey(key))
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return m_FriendPresenceMap[key];
				}
			}
		}
		return null;
	}

	public Presence c1fc2b32eeffe87b8ba0a42dc97e8ae67(int ceb2d2e60d53f84002efe014b8c698355)
	{
		if (m_FriendPresenceMap.ContainsKey(ceb2d2e60d53f84002efe014b8c698355))
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
					return m_FriendPresenceMap[ceb2d2e60d53f84002efe014b8c698355];
				}
			}
		}
		return null;
	}

	protected void OnPresenceUpdated(Presence presence)
	{
		if (presence == null)
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
		if (!m_FriendPresenceMap.ContainsKey(presence.mCharacterId))
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
			m_FriendPresenceMap[presence.mCharacterId].mCharacterLevel = presence.mCharacterLevel;
			m_FriendPresenceMap[presence.mCharacterId].mIsOnline = presence.mIsOnline;
			m_FriendPresenceMap[presence.mCharacterId].mLastOnline = presence.mLastOnline;
			m_FriendPresenceMap[presence.mCharacterId].mCurrentTown = presence.mCurrentTown;
			m_FriendPresenceMap[presence.mCharacterId].mMatchCount = presence.mMatchCount;
			m_FriendPresenceMap[presence.mCharacterId].mHonorPoint = presence.mHonorPoint;
			m_FriendPresenceMap[presence.mCharacterId].mKillCount = presence.mKillCount;
			m_FriendPresenceMap[presence.mCharacterId].mDeathCount = presence.mDeathCount;
			m_FriendPresenceMap[presence.mCharacterId].mWinCount = presence.mWinCount;
			m_FriendPresenceMap[presence.mCharacterId].mLossCount = presence.mLossCount;
			c8fdc385e385da5a2faa612d3ea1448b2();
			if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<FriendView>().cd0069281ff5290a7e6c484b6aed3933d)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<FriendView>().c263a18e823d534fe933bf797fd17c221();
				return;
			}
		}
	}

	protected void OnGetMyFriendsList(int[] characterIds)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<FriendServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cb70aa5c7f0a7f74df164587279faa393(OnGetFriendsCharacterInfo);
	}

	protected void OnGetFriendsCharacterInfo(List<PlayerProperties> characterInfos)
	{
		m_FriendMap.Clear();
		for (int i = 0; i < characterInfos.Count(); i++)
		{
			m_FriendMap.Add(characterInfos[i].m_id, characterInfos[i]);
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
			c8fdc385e385da5a2faa612d3ea1448b2();
			return;
		}
	}

	private void c8fdc385e385da5a2faa612d3ea1448b2()
	{
		if (m_FriendPresenceMap.Count <= 1)
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
					if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<FriendView>().cd0069281ff5290a7e6c484b6aed3933d)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<FriendView>().c263a18e823d534fe933bf797fd17c221();
								return;
							}
						}
					}
					return;
				}
			}
		}
		m_FriendIds.Sort(c3d1bb3692c0855c4147e6387b76d54a6);
		if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<FriendView>().cd0069281ff5290a7e6c484b6aed3933d)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<FriendView>().c263a18e823d534fe933bf797fd17c221();
			return;
		}
	}

	private int c3d1bb3692c0855c4147e6387b76d54a6(int c206672d30216dfea0e6fa6d347a33a0d, int cfd8cb63882e7606eb5642d0540abab09)
	{
		if (!m_FriendPresenceMap[c206672d30216dfea0e6fa6d347a33a0d].mIsOnline)
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
			if (m_FriendPresenceMap[cfd8cb63882e7606eb5642d0540abab09].mIsOnline)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return 1;
					}
				}
			}
		}
		if (m_FriendPresenceMap[c206672d30216dfea0e6fa6d347a33a0d].mIsOnline)
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
			if (!m_FriendPresenceMap[cfd8cb63882e7606eb5642d0540abab09].mIsOnline)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return -1;
					}
				}
			}
		}
		return string.Compare(m_FriendPresenceMap[c206672d30216dfea0e6fa6d347a33a0d].mCharacterName, m_FriendPresenceMap[cfd8cb63882e7606eb5642d0540abab09].mCharacterName);
	}

	public void c84c18b52ef8edc525b96f9683012fe90(Presence c57b01bb713a45dd68b36b4f255e08dff)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
		array[0] = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_name;
		array[1] = " get inviter info ";
		array[2] = c57b01bb713a45dd68b36b4f255e08dff.mCharacterId;
		array[3] = " name:";
		array[4] = c57b01bb713a45dd68b36b4f255e08dff.mCharacterName;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, string.Concat(array));
		if (!m_FriendInvitationInfoMap.ContainsKey(c57b01bb713a45dd68b36b4f255e08dff.mCharacterId))
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
			PlayerProperties playerProperties = new PlayerProperties();
			playerProperties.m_avatarDna = c57b01bb713a45dd68b36b4f255e08dff.mAvatarDNA;
			playerProperties.m_exp = c57b01bb713a45dd68b36b4f255e08dff.mCharacterExperience;
			playerProperties.m_id = c57b01bb713a45dd68b36b4f255e08dff.mCharacterId;
			playerProperties.m_level = c57b01bb713a45dd68b36b4f255e08dff.mCharacterLevel;
			playerProperties.m_name = c57b01bb713a45dd68b36b4f255e08dff.mCharacterName;
			m_FriendInvitationInfoMap.Add(c57b01bb713a45dd68b36b4f255e08dff.mCharacterId, playerProperties);
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().cd0069281ff5290a7e6c484b6aed3933d)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().cf198707970ccb9ab868e90753613ed18();
			}
			else
			{
				m_bNewMessageUnread = true;
			}
		}
		else
		{
			m_FriendInvitationInfoMap[c57b01bb713a45dd68b36b4f255e08dff.mCharacterId].m_level = c57b01bb713a45dd68b36b4f255e08dff.mCharacterLevel;
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<FriendView>().c263a18e823d534fe933bf797fd17c221();
	}

	public bool c80e280b3a474879292d226409aeb70ba(int c5dfde30d8784694fb9999709d290e6c4)
	{
		return m_FriendInvitationInfoMap.ContainsKey(c5dfde30d8784694fb9999709d290e6c4);
	}

	public int c81b33504dcaf516d9419db3d8e269616()
	{
		return m_FriendInvitationInfoMap.Count();
	}

	public PlayerProperties c8b56aabd1119d63ae70495f90ba03b68(int c62a53388af21c9e5e206591a30eb9f80)
	{
		if (c62a53388af21c9e5e206591a30eb9f80 >= 0)
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
			if (c62a53388af21c9e5e206591a30eb9f80 < m_FriendInvitationInfoMap.Count())
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return m_FriendInvitationInfoMap.ElementAt(c62a53388af21c9e5e206591a30eb9f80).Value;
					}
				}
			}
		}
		return null;
	}

	public int c338f75ed0138aa7c193523682e0a180e()
	{
		int num = 0;
		for (int i = 0; i < m_FriendPresenceMap.Count(); i++)
		{
			if (!m_FriendPresenceMap.ElementAt(i).Value.mIsOnline)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			num++;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			return num;
		}
	}

	public void c0683d9083a644adf803fcc3cec6f25da()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<FriendServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ccceb0f72a209e610a05e32f2bbb3eacb(OnGetMyPendingFriendRequests);
	}

	protected void OnGetMyPendingFriendRequests(FriendRequest[] pendingFriendRequests)
	{
		m_FriendInvitationInfoMap.Clear();
		for (int i = 0; i < pendingFriendRequests.Count(); i++)
		{
			if (m_FriendInvitationMap.ContainsKey(pendingFriendRequests[i].mSender))
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
				m_FriendInvitationMap[pendingFriendRequests[i].mSender] = pendingFriendRequests[i].mMessageId;
			}
			else
			{
				m_FriendInvitationMap.Add(pendingFriendRequests[i].mSender, pendingFriendRequests[i].mMessageId);
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public void c859c14de7752fa9a9dd0c8c4e7e2ca9e()
	{
		OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c7f3c9cb8a62583c02d7f21036edfe783(OnGetFriendsPresence);
	}

	public bool c20292dc0112b596d061ae25400743cc5()
	{
		if (c5f2cb1d77cbb3465c54be16450d45d1d() >= m_MaxFriendNumber)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return false;
				}
			}
		}
		return true;
	}

	public void cbbcfd0bf92e11cfa6ba6b913e85d9791(object c591d56a94543e3559945c497f37126c4)
	{
		if (c5f2cb1d77cbb3465c54be16450d45d1d() >= m_MaxFriendNumber)
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Friend_Max")), ca131ac030d74d9bdd378fddf7107a229, c68ab6f5d12f16a1d54aa92651de73463.c7088de59e49f7108f520cf7e0bae167e);
					return;
				}
			}
		}
		c1ee7921b0c3cce194fb7cae41b5a9d82<FriendServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cbbcfd0bf92e11cfa6ba6b913e85d9791(m_TargetCharacterId);
	}

	public void c7f0dffe793ab211fb14de2aedcb03e7d(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (c5dfde30d8784694fb9999709d290e6c4 == -1)
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
			if (!m_FriendInvitationMap.ContainsKey(c5dfde30d8784694fb9999709d290e6c4))
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<FriendServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7f0dffe793ab211fb14de2aedcb03e7d(m_FriendInvitationMap[c5dfde30d8784694fb9999709d290e6c4]);
				m_FriendInvitationMap.Remove(c5dfde30d8784694fb9999709d290e6c4);
				m_FriendInvitationInfoMap.Remove(c5dfde30d8784694fb9999709d290e6c4);
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<FriendView>().c263a18e823d534fe933bf797fd17c221();
				return;
			}
		}
	}

	public void cc247771682223024f44ff9d22a219678(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (c5dfde30d8784694fb9999709d290e6c4 == -1)
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
			if (!m_FriendInvitationInfoMap.ContainsKey(c5dfde30d8784694fb9999709d290e6c4))
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<FriendServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cc247771682223024f44ff9d22a219678(m_FriendInvitationMap[c5dfde30d8784694fb9999709d290e6c4]);
				m_FriendInvitationMap.Remove(c5dfde30d8784694fb9999709d290e6c4);
				m_FriendInvitationInfoMap.Remove(c5dfde30d8784694fb9999709d290e6c4);
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<FriendView>().c263a18e823d534fe933bf797fd17c221();
				return;
			}
		}
	}

	public int c5f2cb1d77cbb3465c54be16450d45d1d()
	{
		return m_FriendIds.Count();
	}

	public int ccae2721e9f57e73654d81903f40bfc6b(int c62a53388af21c9e5e206591a30eb9f80)
	{
		if (c62a53388af21c9e5e206591a30eb9f80 >= 0)
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
			if (c62a53388af21c9e5e206591a30eb9f80 < m_FriendIds.Count())
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return m_FriendIds[c62a53388af21c9e5e206591a30eb9f80];
					}
				}
			}
		}
		return -1;
	}

	public void c1c7eba11d297c10307e34ca826071071(int cec67817d5516cb3510fc67791505c37e)
	{
		if (cec67817d5516cb3510fc67791505c37e == -1)
		{
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
				return;
			}
		}
		Presence presence = c1fc2b32eeffe87b8ba0a42dc97e8ae67(cec67817d5516cb3510fc67791505c37e);
		MenuItemDef[] array = cacffdc9bda8a41773c3ac61797275a6c.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Group_Invitation"));
		array[0].itemData = cec67817d5516cb3510fc67791505c37e;
		if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
		{
			goto IL_00ac;
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
		if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c8a142a1ecdf6817b0b02b74d6d1c8796())
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
			if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c87b271fc3048524b0894366245574631(cec67817d5516cb3510fc67791505c37e))
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
				goto IL_00ac;
			}
		}
		array[0].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
		goto IL_011c;
		IL_00ac:
		if (presence != null)
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
			if (presence.mIsOnline)
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
				array[0].itemFunc = c3a3df7377c1cc08c19b43be7807f2e2a;
			}
			else
			{
				array[0].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
			}
		}
		else
		{
			array[0].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
		}
		goto IL_011c;
		IL_011c:
		array[1].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Friend_Delete"));
		array[1].itemData = cec67817d5516cb3510fc67791505c37e;
		array[1].itemFunc = c801ecf0743bf11f674fe1e88e619c414;
		array[2].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GUILD_INVITATION"));
		array[2].itemData = cec67817d5516cb3510fc67791505c37e;
		if (!GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c17ba091c28b756583dc29d3eec870622())
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
			if (!GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd6451c6b5252840b2be641871236928f())
			{
				array[2].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
				goto IL_023c;
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
		if (presence != null)
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
			if (presence.mIsOnline)
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
				array[2].itemFunc = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c3523f24b7f5c8c0e8868cf3e73f36d20;
			}
			else
			{
				array[2].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
			}
		}
		else
		{
			array[2].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
		}
		goto IL_023c;
		IL_023c:
		array[3].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Chat_Send"));
		if (presence != null)
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
			array[3].itemData = presence.mCharacterName;
			if (presence.mIsOnline)
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
				array[3].itemFunc = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ChatView>().c9c8e5a517b23a2b1acabe838f9baf845;
			}
			else
			{
				array[3].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
			}
		}
		else
		{
			array[3].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().c687c56ed531550f24368180c4c3bc947(array);
	}

	protected void c3a3df7377c1cc08c19b43be7807f2e2a(object c591d56a94543e3559945c497f37126c4)
	{
		if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c87b271fc3048524b0894366245574631((int)c591d56a94543e3559945c497f37126c4))
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
			GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c0d1b2121def725b11ad7317d4212131a((int)c591d56a94543e3559945c497f37126c4);
			GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c89fcb77276a7956cd51b61c3a4437b0f(c591d56a94543e3559945c497f37126c4);
			return;
		}
	}

	protected void c801ecf0743bf11f674fe1e88e619c414(object c591d56a94543e3559945c497f37126c4)
	{
		if (!c52b0e4c302961935453bec436d84dc68((int)c591d56a94543e3559945c497f37126c4))
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<FriendServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cb1931c1ebff26aa30fe00faff1603cea((int)c591d56a94543e3559945c497f37126c4);
			m_FriendIds.Remove((int)c591d56a94543e3559945c497f37126c4);
			m_FriendPresenceMap.Remove((int)c591d56a94543e3559945c497f37126c4);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<FriendView>().c263a18e823d534fe933bf797fd17c221();
			return;
		}
	}

	public void cf532f18dc506947263a9adde977ea566(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c072a932603fc0be0d70802256d009791(OnGetSearchResult, cd99af21e22e356018b8f72d4a7e4872a);
	}

	private void OnGetSearchResult(Presence presence)
	{
		m_SearchResultMap.Clear();
		if (presence != null)
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
			m_SearchResultMap.Add(presence.mCharacterId, presence);
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<FriendView>().c263a18e823d534fe933bf797fd17c221();
	}

	public Presence cf263428aa6e41bad2d6cbafd66bfc3f5(int c62a53388af21c9e5e206591a30eb9f80)
	{
		if (c62a53388af21c9e5e206591a30eb9f80 >= 0)
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
			if (c62a53388af21c9e5e206591a30eb9f80 < m_SearchResultMap.Count())
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return m_SearchResultMap.ElementAt(c62a53388af21c9e5e206591a30eb9f80).Value;
					}
				}
			}
		}
		return null;
	}

	public int ce7e52320196a6b9812b8a7f22ed7b89c()
	{
		return m_SearchResultMap.Count();
	}

	public void cf10dc670a45bb0104e6966f4a2b2d3e9()
	{
		m_SearchResultMap.Clear();
	}

	public bool c52b0e4c302961935453bec436d84dc68(int c5dfde30d8784694fb9999709d290e6c4)
	{
		return m_FriendPresenceMap.ContainsKey(c5dfde30d8784694fb9999709d290e6c4);
	}

	protected void ca131ac030d74d9bdd378fddf7107a229()
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cfd58c94350618be817cfdb449a158aad();
	}
}
