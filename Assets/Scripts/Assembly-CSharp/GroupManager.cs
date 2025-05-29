using System;
using System.Collections.Generic;
using System.Linq;
using A;
using Core;

public class GroupManager : IGroupServiceNotificationListerner
{
	public enum InviteMessageStatus
	{
		e_None = 0,
		e_WaitingForDecide = 1,
		e_Decided = 2,
		e_Locked = 3,
		e_JoinFailed = 4,
		e_Accepted = 5,
		e_Rejected = 6
	}

	private class GroupInviteData
	{
		public int m_nMessageId;

		public PlayerProperties InviterInfo;

		public InviteMessageStatus InviteStatus;

		public GroupInviteData()
		{
			InviterInfo = new PlayerProperties();
			InviteStatus = InviteMessageStatus.e_WaitingForDecide;
		}
	}

	public delegate void DeleOnGetGroupInfo(int groupId, List<Presence> members);

	protected static GroupManager _GroupInstance;

	private Dictionary<int, GroupInviteData> m_InviteDataMap;

	private Dictionary<int, int> m_InviteMessageMap;

	public Dictionary<int, Presence> m_GroupInfoMap;

	public int m_nLeaderId;

	public bool m_bInGroup;

	public int m_nAcceptId;

	public int m_nGroupId = -1;

	protected DeleOnGetGroupInfo m_cbOnGetGroupInfo;

	private bool m_bFirstLogin = true;

	private int m_TargetCharacterId = -1;

	private GroupManager()
	{
		m_bFirstLogin = true;
		if (m_InviteDataMap == null)
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
			m_InviteDataMap = new Dictionary<int, GroupInviteData>();
			m_InviteDataMap.Clear();
		}
		if (m_InviteMessageMap == null)
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
			m_InviteMessageMap = new Dictionary<int, int>();
			m_InviteMessageMap.Clear();
		}
		if (m_GroupInfoMap == null)
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
			m_GroupInfoMap = new Dictionary<int, Presence>();
			m_GroupInfoMap.Clear();
		}
		OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ce9889db06033bab789a717780b17135d(OnPresenceUpdated);
	}

	public static GroupManager c71f6ce28731edfd43c976fbd57c57bea()
	{
		if (_GroupInstance == null)
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
			_GroupInstance = new GroupManager();
			c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(_GroupInstance);
		}
		return _GroupInstance;
	}

	public void c0d1b2121def725b11ad7317d4212131a(int c8e89ffcc462dde16f23bd6ad8cc1962b)
	{
		m_TargetCharacterId = c8e89ffcc462dde16f23bd6ad8cc1962b;
	}

	protected void OnPresenceUpdated(Presence presence)
	{
		if (presence == null)
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
		if (!m_GroupInfoMap.ContainsKey(presence.mCharacterId))
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
			m_GroupInfoMap[presence.mCharacterId].mCharacterLevel = presence.mCharacterLevel;
			m_GroupInfoMap[presence.mCharacterId].mIsOnline = presence.mIsOnline;
			m_GroupInfoMap[presence.mCharacterId].mLastOnline = presence.mLastOnline;
			m_GroupInfoMap[presence.mCharacterId].mCurrentTown = presence.mCurrentTown;
			return;
		}
	}

	public void c811bfd9ce159c8db556114e4b7a09e8c()
	{
		m_InviteDataMap.Clear();
		m_InviteMessageMap.Clear();
		for (int i = 0; i < 33; i++)
		{
			GroupInviteData groupInviteData = new GroupInviteData();
			groupInviteData.InviterInfo.m_level = i;
			groupInviteData.InviterInfo.m_name = "test" + i;
			groupInviteData.InviterInfo.m_id = i;
			m_InviteDataMap.Add(i, groupInviteData);
			m_InviteMessageMap.Add(i, i);
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
			return;
		}
	}

	public void c6d00de83b1a38d26c8edadea7d1bc278(Presence c57b01bb713a45dd68b36b4f255e08dff)
	{
		if (!m_InviteDataMap.ContainsKey(c57b01bb713a45dd68b36b4f255e08dff.mCharacterId))
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
			GroupInviteData groupInviteData = new GroupInviteData();
			groupInviteData.m_nMessageId = m_InviteMessageMap[c57b01bb713a45dd68b36b4f255e08dff.mCharacterId];
			groupInviteData.InviterInfo.m_avatarDna = c57b01bb713a45dd68b36b4f255e08dff.mAvatarDNA;
			groupInviteData.InviterInfo.m_exp = c57b01bb713a45dd68b36b4f255e08dff.mCharacterExperience;
			groupInviteData.InviterInfo.m_id = c57b01bb713a45dd68b36b4f255e08dff.mCharacterId;
			groupInviteData.InviterInfo.m_level = c57b01bb713a45dd68b36b4f255e08dff.mCharacterLevel;
			groupInviteData.InviterInfo.m_bondCurrency = c57b01bb713a45dd68b36b4f255e08dff.mCurrency;
			groupInviteData.InviterInfo.m_name = c57b01bb713a45dd68b36b4f255e08dff.mCharacterName;
			m_InviteDataMap.Add(c57b01bb713a45dd68b36b4f255e08dff.mCharacterId, groupInviteData);
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().cd0069281ff5290a7e6c484b6aed3933d)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().ccf6f266a84f582fbc9e1b9a4784ed057();
			}
		}
		else
		{
			m_InviteDataMap[c57b01bb713a45dd68b36b4f255e08dff.mCharacterId].m_nMessageId = m_InviteMessageMap[c57b01bb713a45dd68b36b4f255e08dff.mCharacterId];
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GroupView>().c263a18e823d534fe933bf797fd17c221();
	}

	public int c06288d57de4bf58c453289eef8b13572()
	{
		return m_InviteDataMap.Count();
	}

	public InviteMessageStatus cd32f7e7341db49df05a3ff0c78164577(int c5dfde30d8784694fb9999709d290e6c4)
	{
		return m_InviteDataMap[c5dfde30d8784694fb9999709d290e6c4].InviteStatus;
	}

	public PlayerProperties cf27a45b19d5e6ff6e43fa1bead37845d(int c62a53388af21c9e5e206591a30eb9f80)
	{
		if (c62a53388af21c9e5e206591a30eb9f80 >= 0)
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
			if (c62a53388af21c9e5e206591a30eb9f80 < m_InviteDataMap.Count())
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return m_InviteDataMap.ElementAt(c62a53388af21c9e5e206591a30eb9f80).Value.InviterInfo;
					}
				}
			}
		}
		return null;
	}

	public InviteMessageStatus cd2c1dcde9ac2bf09ccb7722c26a5d77d(int c62a53388af21c9e5e206591a30eb9f80)
	{
		if (c62a53388af21c9e5e206591a30eb9f80 >= 0)
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
			if (c62a53388af21c9e5e206591a30eb9f80 < m_InviteDataMap.Count())
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return m_InviteDataMap.ElementAt(c62a53388af21c9e5e206591a30eb9f80).Value.InviteStatus;
					}
				}
			}
		}
		return InviteMessageStatus.e_None;
	}

	public bool c7c5f912483194aee7c558f9a8f924590(int c5dfde30d8784694fb9999709d290e6c4)
	{
		return m_InviteDataMap.ContainsKey(c5dfde30d8784694fb9999709d290e6c4);
	}

	public void c22c0a7b8423eb5b25577f471880712bf()
	{
		for (int i = 0; i < m_InviteDataMap.Count(); i++)
		{
			if (m_InviteDataMap.ElementAt(i).Value.InviteStatus != InviteMessageStatus.e_WaitingForDecide)
			{
				continue;
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_InviteDataMap.ElementAt(i).Value.InviteStatus = InviteMessageStatus.e_Locked;
		}
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

	public void c13a7e13767f8197d90fa51f9273687f0()
	{
		for (int i = 0; i < m_InviteDataMap.Count(); i++)
		{
			if (m_InviteDataMap.ElementAt(i).Value.InviteStatus != InviteMessageStatus.e_Locked)
			{
				continue;
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_InviteDataMap.ElementAt(i).Value.InviteStatus = InviteMessageStatus.e_WaitingForDecide;
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

	public void cb7ee8d2eab4d145b881da6d1131c599c()
	{
		List<int> list = new List<int>();
		list.Clear();
		for (int i = 0; i < m_InviteDataMap.Count(); i++)
		{
			if (m_InviteDataMap.ElementAt(i).Value.InviteStatus == InviteMessageStatus.e_WaitingForDecide)
			{
				continue;
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			list.Add(m_InviteDataMap.ElementAt(i).Key);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			for (int j = 0; j < list.Count(); j++)
			{
				m_InviteDataMap.Remove(list[j]);
				m_InviteMessageMap.Remove(list[j]);
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
	}

	private GroupInviteData c3f07262604ab437078ee80d501a7a35b(int c5dfde30d8784694fb9999709d290e6c4)
	{
		GroupInviteData groupInviteData = new GroupInviteData();
		groupInviteData.InviteStatus = InviteMessageStatus.e_Accepted;
		groupInviteData.m_nMessageId = m_InviteMessageMap[c5dfde30d8784694fb9999709d290e6c4];
		groupInviteData.InviterInfo.m_avatarDna = m_InviteDataMap[c5dfde30d8784694fb9999709d290e6c4].InviterInfo.m_avatarDna;
		groupInviteData.InviterInfo.m_exp = m_InviteDataMap[c5dfde30d8784694fb9999709d290e6c4].InviterInfo.m_exp;
		groupInviteData.InviterInfo.m_id = m_InviteDataMap[c5dfde30d8784694fb9999709d290e6c4].InviterInfo.m_id;
		groupInviteData.InviterInfo.m_level = m_InviteDataMap[c5dfde30d8784694fb9999709d290e6c4].InviterInfo.m_level;
		groupInviteData.InviterInfo.m_bondCurrency = m_InviteDataMap[c5dfde30d8784694fb9999709d290e6c4].InviterInfo.m_bondCurrency;
		groupInviteData.InviterInfo.m_name = m_InviteDataMap[c5dfde30d8784694fb9999709d290e6c4].InviterInfo.m_name;
		return groupInviteData;
	}

	public void OnGroupInviteAccepted(bool successful, int sender, int groupId, List<Presence> members)
	{
		if (successful)
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
			GroupInviteData groupInviteData = c3f07262604ab437078ee80d501a7a35b(sender);
			for (int i = 0; i < m_InviteDataMap.Count(); i++)
			{
				if (m_InviteDataMap.ElementAt(i).Key == sender)
				{
					continue;
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
				if (!m_InviteMessageMap.ContainsKey(m_InviteDataMap.ElementAt(i).Key))
				{
					continue;
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
				m_InviteMessageMap.Remove(m_InviteDataMap.ElementAt(i).Key);
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
			m_InviteDataMap.Clear();
			m_InviteDataMap.Add(groupInviteData.InviterInfo.m_id, groupInviteData);
			m_bInGroup = true;
			m_nGroupId = groupId;
			cf893c6ac1edf850a78998b57f5b766f4(members);
			if (m_cbOnGetGroupInfo != null)
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
				m_cbOnGetGroupInfo(groupId, members);
			}
		}
		else
		{
			c13a7e13767f8197d90fa51f9273687f0();
			GroupInviteData value;
			if (m_InviteDataMap.TryGetValue(sender, out value))
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
				value.InviteStatus = InviteMessageStatus.e_JoinFailed;
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GroupView>().c263a18e823d534fe933bf797fd17c221();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().c93da48f317472e2d30deca60386d9a58();
	}

	public void cdbf6ca3febfb43b0ac5385a805224dba(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (c5dfde30d8784694fb9999709d290e6c4 == -1)
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
			if (!m_InviteMessageMap.ContainsKey(c5dfde30d8784694fb9999709d290e6c4))
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
				m_InviteDataMap[c5dfde30d8784694fb9999709d290e6c4].InviteStatus = InviteMessageStatus.e_Decided;
				c22c0a7b8423eb5b25577f471880712bf();
				m_nAcceptId = c5dfde30d8784694fb9999709d290e6c4;
				c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cdabc733e8aacf96718d8617e58274f40(OnGroupInviteAccepted, m_InviteMessageMap[c5dfde30d8784694fb9999709d290e6c4]);
				return;
			}
		}
	}

	public void cdfec21f23b7b4cb0a9ca48d4fa122044(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (c5dfde30d8784694fb9999709d290e6c4 == -1)
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
			if (!m_InviteMessageMap.ContainsKey(c5dfde30d8784694fb9999709d290e6c4))
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c574e1ae38231526cf898f00f985e88b2(m_InviteMessageMap[c5dfde30d8784694fb9999709d290e6c4]);
				m_InviteDataMap[c5dfde30d8784694fb9999709d290e6c4].InviteStatus = InviteMessageStatus.e_Rejected;
				m_InviteDataMap.Remove(c5dfde30d8784694fb9999709d290e6c4);
				m_InviteMessageMap.Remove(c5dfde30d8784694fb9999709d290e6c4);
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GroupView>().c263a18e823d534fe933bf797fd17c221();
				return;
			}
		}
	}

	public void c89fcb77276a7956cd51b61c3a4437b0f(object c591d56a94543e3559945c497f37126c4)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c89fcb77276a7956cd51b61c3a4437b0f(c1a21316c07f1880cead3c77a7beb3efc, m_TargetCharacterId);
	}

	protected void c1a21316c07f1880cead3c77a7beb3efc(int c32ff4f1e8a0e5e4602838dbec2556455)
	{
	}

	public void OnReceivedGroupInvitation(int senderCharacterId, int groupId, int messageId)
	{
		if (m_InviteMessageMap.ContainsKey(senderCharacterId))
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
			m_InviteMessageMap[senderCharacterId] = messageId;
		}
		else
		{
			m_InviteMessageMap.Add(senderCharacterId, messageId);
		}
		OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c171cc9079535e716dc2c8dd3677a6256(senderCharacterId, c6d00de83b1a38d26c8edadea7d1bc278);
	}

	public void OnKickedFromGroup()
	{
		m_bInGroup = false;
		m_nGroupId = -1;
		m_GroupInfoMap.Clear();
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cec9cdae23444bbac5cad953e7fc1f8e9();
			return;
		}
	}

	public void OnNewGroupLeader(int characterId)
	{
		if (characterId == -1)
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
		m_nLeaderId = characterId;
		if (c8a142a1ecdf6817b0b02b74d6d1c8796())
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
			LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().c3fe05a58a92948d50c3f4ae173e922ca();
		}
		c490e1cdbd91f441f8899c3b557cbc807();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().c93da48f317472e2d30deca60386d9a58();
	}

	public void c490e1cdbd91f441f8899c3b557cbc807()
	{
		if (m_bInGroup)
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
					if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().cd0069281ff5290a7e6c484b6aed3933d)
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
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().c490e1cdbd91f441f8899c3b557cbc807(c8a142a1ecdf6817b0b02b74d6d1c8796());
					}
					if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPlayerInfoView>().cd0069281ff5290a7e6c484b6aed3933d)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPlayerInfoView>().c490e1cdbd91f441f8899c3b557cbc807(c8a142a1ecdf6817b0b02b74d6d1c8796());
								return;
							}
						}
					}
					return;
				}
			}
		}
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().c490e1cdbd91f441f8899c3b557cbc807(false);
		}
		if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPlayerInfoView>().cd0069281ff5290a7e6c484b6aed3933d)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPlayerInfoView>().c490e1cdbd91f441f8899c3b557cbc807(false);
			return;
		}
	}

	public void OnNewGroupMember(Presence characterinfo)
	{
		if (characterinfo == null)
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
		if (characterinfo.mCharacterId == -1)
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
		if (!m_bInGroup)
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
			m_nLeaderId = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_characterId;
			m_bInGroup = true;
			c490e1cdbd91f441f8899c3b557cbc807();
		}
		if (!m_GroupInfoMap.ContainsKey(characterinfo.mCharacterId))
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
			m_GroupInfoMap.Add(characterinfo.mCharacterId, characterinfo);
		}
		if (!c8a142a1ecdf6817b0b02b74d6d1c8796())
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
			LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().c3fe05a58a92948d50c3f4ae173e922ca();
			return;
		}
	}

	public void OnGroupInviteRejected(int characterId)
	{
	}

	public void OnGroupMemberLeft(int characterId)
	{
		if (m_GroupInfoMap.ContainsKey(characterId))
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
			m_GroupInfoMap.Remove(characterId);
		}
		if (!c8a142a1ecdf6817b0b02b74d6d1c8796())
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
			LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().c3fe05a58a92948d50c3f4ae173e922ca();
			return;
		}
	}

	public void OnGroupDisbanded()
	{
		m_bInGroup = false;
		m_nGroupId = -1;
		m_nLeaderId = -1;
		m_GroupInfoMap.Clear();
		LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().c3fe05a58a92948d50c3f4ae173e922ca();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().c93da48f317472e2d30deca60386d9a58();
	}

	public bool c87b271fc3048524b0894366245574631(int c5dfde30d8784694fb9999709d290e6c4)
	{
		return m_GroupInfoMap.ContainsKey(c5dfde30d8784694fb9999709d290e6c4);
	}

	public bool c9b5f43fba87a5416412d8faadde1992a()
	{
		return m_bInGroup;
	}

	public bool c8a142a1ecdf6817b0b02b74d6d1c8796()
	{
		return OnlineService.s_characterId == m_nLeaderId;
	}

	public bool c2930d24fac8ce6b56448c4a0665627c0()
	{
		if (!m_bInGroup)
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
					if (!LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c76154b5d193e30b53344242a665f1fe4())
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								return true;
							}
						}
					}
					if (LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c03e08ddbd7a06ade357b3ce0364b3f94())
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								return true;
							}
						}
					}
					return false;
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_characterId == m_nLeaderId)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return true;
				}
			}
		}
		return false;
	}

	public void c84e7d656f39a60ef71f428c59209c060()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c84e7d656f39a60ef71f428c59209c060(OnGotMyGroupInfo);
	}

	private void OnGotMyGroupInfo(int groupId, List<Presence> members)
	{
		m_GroupInfoMap.Clear();
		if (groupId != -1)
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
					m_bInGroup = true;
					m_nGroupId = groupId;
					cf893c6ac1edf850a78998b57f5b766f4(members);
					if (m_cbOnGetGroupInfo != null)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								m_cbOnGetGroupInfo(groupId, members);
								return;
							}
						}
					}
					return;
				}
			}
		}
		m_bInGroup = false;
		m_nGroupId = -1;
	}

	public void c9a04348ee34715fee1de211171471b35(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (!m_bInGroup)
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
			if (c8a142a1ecdf6817b0b02b74d6d1c8796())
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
					{
						MenuItemDef[] array = cacffdc9bda8a41773c3ac61797275a6c.c0a0cdf4a196914163f7334d9b0781a04(2);
						array[0].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Group_Exple"));
						array[0].itemData = c5dfde30d8784694fb9999709d290e6c4;
						array[0].itemFunc = c60391e061cd6d8a60db5fc9a6f83aafe;
						array[1].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Group_Leave"));
						array[1].itemData = c5dfde30d8784694fb9999709d290e6c4;
						array[1].itemFunc = c3bdf56faf210277f6d5c501ade8fad5f;
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().c687c56ed531550f24368180c4c3bc947(array);
						return;
					}
					}
				}
			}
			MenuItemDef[] array2 = cacffdc9bda8a41773c3ac61797275a6c.c0a0cdf4a196914163f7334d9b0781a04(1);
			array2[0].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Group_Leave"));
			array2[0].itemData = c5dfde30d8784694fb9999709d290e6c4;
			array2[0].itemFunc = c3bdf56faf210277f6d5c501ade8fad5f;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().c687c56ed531550f24368180c4c3bc947(array2);
			return;
		}
	}

	private void OnKickPlayerFromGroup(bool successful, int kickedCharacterId)
	{
		if (!successful)
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
			if (!m_GroupInfoMap.ContainsKey(kickedCharacterId))
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
				m_GroupInfoMap.Remove(kickedCharacterId);
				return;
			}
		}
	}

	private void OnLeaveGroup(bool successful)
	{
		if (successful)
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
					m_bInGroup = false;
					m_nGroupId = -1;
					m_GroupInfoMap.Clear();
					LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().c3fe05a58a92948d50c3f4ae173e922ca();
					if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
						c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cec9cdae23444bbac5cad953e7fc1f8e9();
					}
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().c93da48f317472e2d30deca60386d9a58();
					return;
				}
			}
		}
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_name + " leave group failed!!!");
	}

	public void c60391e061cd6d8a60db5fc9a6f83aafe(object c591d56a94543e3559945c497f37126c4)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c347662a41df388198423d3559d957132(OnKickPlayerFromGroup, (int)c591d56a94543e3559945c497f37126c4);
	}

	public void c60391e061cd6d8a60db5fc9a6f83aafe(int c5dfde30d8784694fb9999709d290e6c4)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c347662a41df388198423d3559d957132(OnKickPlayerFromGroup, c5dfde30d8784694fb9999709d290e6c4);
	}

	public void c3bdf56faf210277f6d5c501ade8fad5f(object c591d56a94543e3559945c497f37126c4)
	{
		if (!m_bInGroup)
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c635f796eee513fdcf0733537d7f44398(OnLeaveGroup);
			return;
		}
	}

	public void cbbe9fff63c456ab61d7d04aab4ae5f01()
	{
		if (m_bFirstLogin)
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
			if (m_bInGroup)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Group_Crash_Back")), cde4925fdec123105628516489c324acf, c635f796eee513fdcf0733537d7f44398);
			}
		}
		m_bFirstLogin = false;
	}

	public void c635f796eee513fdcf0733537d7f44398()
	{
		if (!m_bInGroup)
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c635f796eee513fdcf0733537d7f44398(OnLeaveGroup);
			return;
		}
	}

	protected void cde4925fdec123105628516489c324acf()
	{
		if (!m_bInGroup)
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cde4925fdec123105628516489c324acf(c8f6c0959dcf84aa2caaf1c82e10ef510);
			return;
		}
	}

	private void c8f6c0959dcf84aa2caaf1c82e10ef510(int c096e36f17994e915a6f91e11e71970d1, List<Presence> c72e4ada3dec90a66a68989a85ec6c74b)
	{
		m_GroupInfoMap.Clear();
		if (c096e36f17994e915a6f91e11e71970d1 == -1)
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
			m_bInGroup = false;
			m_nGroupId = -1;
		}
		else
		{
			cf893c6ac1edf850a78998b57f5b766f4(c72e4ada3dec90a66a68989a85ec6c74b);
			if (m_cbOnGetGroupInfo != null)
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
				m_cbOnGetGroupInfo(c096e36f17994e915a6f91e11e71970d1, c72e4ada3dec90a66a68989a85ec6c74b);
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().c93da48f317472e2d30deca60386d9a58();
	}

	public void OnGroupMatchmakingStarted()
	{
		if (c8a142a1ecdf6817b0b02b74d6d1c8796())
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().c150264a18c2cb408479d3f072cac8cc1 = true;
			return;
		}
	}

	public void c39867fdd7ae4787e9572c6b3b3f71e11(DeleOnGetGroupInfo c8985f47f4f91c32134aa4602ac2debef)
	{
		m_cbOnGetGroupInfo = (DeleOnGetGroupInfo)Delegate.Combine(m_cbOnGetGroupInfo, c8985f47f4f91c32134aa4602ac2debef);
	}

	public void c30bfa60542449d4304af71ccef259137(DeleOnGetGroupInfo c8985f47f4f91c32134aa4602ac2debef)
	{
		m_cbOnGetGroupInfo = (DeleOnGetGroupInfo)Delegate.Remove(m_cbOnGetGroupInfo, c8985f47f4f91c32134aa4602ac2debef);
	}

	private void cf893c6ac1edf850a78998b57f5b766f4(List<Presence> c72e4ada3dec90a66a68989a85ec6c74b)
	{
		m_GroupInfoMap.Clear();
		for (int i = 0; i < c72e4ada3dec90a66a68989a85ec6c74b.Count; i++)
		{
			if (i == 0)
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
				m_GroupInfoMap.Add(c72e4ada3dec90a66a68989a85ec6c74b[i].mCharacterId, c72e4ada3dec90a66a68989a85ec6c74b[i]);
				OnNewGroupLeader(c72e4ada3dec90a66a68989a85ec6c74b[i].mCharacterId);
			}
			else
			{
				OnNewGroupMember(c72e4ada3dec90a66a68989a85ec6c74b[i]);
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

	public int c70efc936706715f53a45697f04944f99(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (m_GroupInfoMap.ContainsKey(c5dfde30d8784694fb9999709d290e6c4))
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
					return m_GroupInfoMap[c5dfde30d8784694fb9999709d290e6c4].mCharacterLevel;
				}
			}
		}
		return 0;
	}

	public Presence[] c5b73c8ec4cf5992b0576375f00ee04d9()
	{
		List<Presence> list = new List<Presence>();
		if (m_GroupInfoMap.ContainsKey(m_nLeaderId))
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
			if (!c8a142a1ecdf6817b0b02b74d6d1c8796())
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
				list.Add(m_GroupInfoMap[m_nLeaderId]);
			}
		}
		for (int i = 0; i < m_GroupInfoMap.Count; i++)
		{
			if (m_GroupInfoMap.ElementAt(i).Key == m_nLeaderId)
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
			if (m_GroupInfoMap.ElementAt(i).Key == OnlineService.s_characterId)
			{
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
			list.Add(m_GroupInfoMap.ElementAt(i).Value);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			return list.ToArray();
		}
	}
}
