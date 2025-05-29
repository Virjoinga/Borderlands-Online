using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;

public class GroupService : OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>, IGroupService
{
	public readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

	private List<OnReceivedGroupInvitation> mOnReceivedGroupInvitation = new List<OnReceivedGroupInvitation>();

	private List<OnKickedFromGroup> mOnKickedFromGroup = new List<OnKickedFromGroup>();

	private List<OnNewGroupLeader> mOnNewGroupLeader = new List<OnNewGroupLeader>();

	private List<OnNewGroupMember> mOnNewGroupMember = new List<OnNewGroupMember>();

	private List<OnGroupInviteRejected> mOnGroupInviteRejected = new List<OnGroupInviteRejected>();

	private List<OnGroupMemberLeft> mOnGroupMemberLeft = new List<OnGroupMemberLeft>();

	private List<OnGroupDisbanded> mOnGroupDisbanded = new List<OnGroupDisbanded>();

	private List<OnGroupMatchmakingStarted> mOnGroupMatchmakingStarted = new List<OnGroupMatchmakingStarted>();

	private OnGotMyGroupInfo mOnGotMyGroupInfo;

	private OnSendGroupInvitation mOnSendGroupInvitation;

	private OnGroupInviteAccepted mOnGroupInviteAccepted;

	private OnKickPlayerFromGroup mOnKickPlayerFromGroup;

	private OnLeaveGroup mOnLeaveGroup;

	private OnGotMyGroupInfo mOnRejoinGroup;

	[CompilerGenerated]
	private static Action<OnKickedFromGroup> _003C_003Ef__am_0024cacheF;

	[CompilerGenerated]
	private static Action<OnGroupDisbanded> _003C_003Ef__am_0024cache10;

	[CompilerGenerated]
	private static Action<OnGroupMatchmakingStarted> _003C_003Ef__am_0024cache11;

	public GroupService()
	{
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(158, OnMyGroupInfoGot);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(163, OnGroupInvitationSent);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(162, OnGroupInvitationAccepted);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(160, OnPlayerKickedFromGroup);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(159, OnGroupLeft);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(151, OnGroupRejoined);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(215, OnKickedFromGroupEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(214, OnNewGroupLeaderEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(213, OnNewGroupMemberEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(212, OnGroupInviteRejectedEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(211, OnGroupMemberLeftEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(210, OnGroupGameStarted);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(209, OnGroupDisbanded);
		PhotonNetwork.networkingPeer.c89f9569b4330d0286992724cb1480f55(165, OnGroupMatchmakingStarted);
		PhotonNetwork.networkingPeer.c71111ea3c8afdb98963505d86a8495b6(199, OnGameInvitationAccepted);
		PhotonNetwork.networkingPeer.c89f9569b4330d0286992724cb1480f55(210, OnHostCreated);
		OnAccessSingleton<IMessagingService, MessagingService, MessagingServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c87d2b468801f2ac5185e4eea8e8cf7a3("group_invitation", OnGroupInvitationReceived);
	}

	public void c84e7d656f39a60ef71f428c59209c060(OnGotMyGroupInfo c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGotMyGroupInfo = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(158, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnMyGroupInfoGot(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGotMyGroupInfo == null)
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
				if (parameters[0] == null)
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
					mOnGotMyGroupInfo(-1, new List<Presence>());
				}
				else
				{
					int num = (int)parameters[0];
					List<Presence> list = new List<Presence>();
					if (num > 0)
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
						Hashtable[] array = (Hashtable[])parameters[1];
						Hashtable[] array2 = array;
						foreach (Hashtable c90ecb087828ed9ceb9c00eafb6d52f4c in array2)
						{
							list.Add(new Presence(c90ecb087828ed9ceb9c00eafb6d52f4c));
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
					}
					mOnGotMyGroupInfo(num, list);
				}
			}
			else
			{
				mOnGotMyGroupInfo(-1, new List<Presence>());
			}
			mOnGotMyGroupInfo = c6e7292294638af662dd19e40be656986.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void cde4925fdec123105628516489c324acf(OnGotMyGroupInfo c2db84530ef366a6deb001d449d4aa151)
	{
		mOnRejoinGroup = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(151, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnGroupRejoined(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnRejoinGroup == null)
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
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (parameters[0] == null)
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
					mOnRejoinGroup(-1, new List<Presence>());
				}
				else
				{
					int num = (int)parameters[0];
					List<Presence> list = new List<Presence>();
					if (num > 0)
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
						Hashtable[] array = (Hashtable[])parameters[1];
						Hashtable[] array2 = array;
						foreach (Hashtable c90ecb087828ed9ceb9c00eafb6d52f4c in array2)
						{
							list.Add(new Presence(c90ecb087828ed9ceb9c00eafb6d52f4c));
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
					mOnRejoinGroup(num, list);
				}
			}
			else
			{
				mOnRejoinGroup(-1, new List<Presence>());
			}
			mOnRejoinGroup = c6e7292294638af662dd19e40be656986.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c89fcb77276a7956cd51b61c3a4437b0f(OnSendGroupInvitation c2db84530ef366a6deb001d449d4aa151, int ca8606b1ba21cbc6f2fc0045fe691e617)
	{
		mOnSendGroupInvitation = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = ca8606b1ba21cbc6f2fc0045fe691e617;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(163, array);
	}

	private void OnGroupInvitationSent(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnSendGroupInvitation == null)
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
				int groupId = (int)parameters[0];
				mOnSendGroupInvitation(groupId);
			}
			else
			{
				mOnSendGroupInvitation(-1);
			}
			mOnSendGroupInvitation = ca3372e44db6df652a6763984407a072b.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c134957d891c1a5e48a3b0e225297e7cb()
	{
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(157, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	public void cdabc733e8aacf96718d8617e58274f40(OnGroupInviteAccepted c2db84530ef366a6deb001d449d4aa151, int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		mOnGroupInviteAccepted = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c93f916e26c7f7aec4117058ff8a6c39d;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(162, array);
	}

	private void OnGroupInvitationAccepted(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGroupInviteAccepted == null)
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
				int num = (int)parameters[0];
				List<Presence> list = new List<Presence>();
				if (num > 0)
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
					Hashtable[] array = (Hashtable[])parameters[2];
					Hashtable[] array2 = array;
					foreach (Hashtable c90ecb087828ed9ceb9c00eafb6d52f4c in array2)
					{
						list.Add(new Presence(c90ecb087828ed9ceb9c00eafb6d52f4c));
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
				mOnGroupInviteAccepted(true, (int)parameters[0], (int)parameters[1], list);
			}
			else
			{
				mOnGroupInviteAccepted(false, -1, -1, new List<Presence>());
			}
			mOnGroupInviteAccepted = ca62b6cb639b157114316f1c38f378036.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c574e1ae38231526cf898f00f985e88b2(int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c93f916e26c7f7aec4117058ff8a6c39d;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(161, array);
	}

	public void c347662a41df388198423d3559d957132(OnKickPlayerFromGroup c2db84530ef366a6deb001d449d4aa151, int c1f6894ec2553584a258c0f0df766fc1f)
	{
		mOnKickPlayerFromGroup = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c1f6894ec2553584a258c0f0df766fc1f;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(160, array);
	}

	private void OnPlayerKickedFromGroup(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnKickPlayerFromGroup == null)
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
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				mOnKickPlayerFromGroup(true, (int)parameters[0]);
			}
			else
			{
				mOnKickPlayerFromGroup(false, -1);
			}
			mOnKickPlayerFromGroup = c8ecd442ccdb6aa95cfe9f37424e35edd.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c635f796eee513fdcf0733537d7f44398(OnLeaveGroup c2db84530ef366a6deb001d449d4aa151)
	{
		mOnLeaveGroup = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(159, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnGroupLeft(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnLeaveGroup == null)
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
			if (operationResponse == 0)
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
				mOnLeaveGroup(true);
			}
			else
			{
				mOnLeaveGroup(false);
			}
			mOnLeaveGroup = c35969989a11dc73465df31d3a23fd892.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	private void OnGroupInvitationReceived(Message message)
	{
		mOnReceivedGroupInvitation.ForEach(delegate(OnReceivedGroupInvitation c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(message.mSender, Convert.ToInt32(message.mPayload), message.mId);
		});
	}

	public void c114948ed36fb1a4d6b353138ed1010db(OnReceivedGroupInvitation c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedGroupInvitation.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cfd07b637390da8aee13e37dd02fcbc7b(OnReceivedGroupInvitation c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedGroupInvitation.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnKickedFromGroupEvent(Dictionary<byte, object> parameters)
	{
		List<OnKickedFromGroup> list = mOnKickedFromGroup;
		if (_003C_003Ef__am_0024cacheF == null)
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
			_003C_003Ef__am_0024cacheF = delegate(OnKickedFromGroup c2db84530ef366a6deb001d449d4aa151)
			{
				c2db84530ef366a6deb001d449d4aa151();
			};
		}
		list.ForEach(_003C_003Ef__am_0024cacheF);
	}

	public void ca45843961de8374d80cdeb8f94dd31f8(OnKickedFromGroup c2db84530ef366a6deb001d449d4aa151)
	{
		mOnKickedFromGroup.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c8a8b34a64d252f526dab4bb4484538c4(OnKickedFromGroup c2db84530ef366a6deb001d449d4aa151)
	{
		mOnKickedFromGroup.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnNewGroupLeaderEvent(Dictionary<byte, object> parameters)
	{
		int characterId = (int)parameters[0];
		mOnNewGroupLeader.ForEach(delegate(OnNewGroupLeader c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(characterId);
		});
	}

	public void c94a7691c6a1d4fa906b09f9848bba0b4(OnNewGroupLeader c2db84530ef366a6deb001d449d4aa151)
	{
		mOnNewGroupLeader.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c2422f42a222120baeb37d0ddc0f4d1ff(OnNewGroupLeader c2db84530ef366a6deb001d449d4aa151)
	{
		mOnNewGroupLeader.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnNewGroupMemberEvent(Dictionary<byte, object> parameters)
	{
		Hashtable c90ecb087828ed9ceb9c00eafb6d52f4c = (Hashtable)parameters[0];
		Presence characterinfo = new Presence(c90ecb087828ed9ceb9c00eafb6d52f4c);
		mOnNewGroupMember.ForEach(delegate(OnNewGroupMember c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(characterinfo);
		});
	}

	public void cf5aa79a863e007ea7d17ed638a8485e4(OnNewGroupMember c2db84530ef366a6deb001d449d4aa151)
	{
		mOnNewGroupMember.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c98af7f9a526ed44220afff4dd1b10485(OnNewGroupMember c2db84530ef366a6deb001d449d4aa151)
	{
		mOnNewGroupMember.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnGroupInviteRejectedEvent(Dictionary<byte, object> parameters)
	{
		int characterId = (int)parameters[0];
		mOnGroupInviteRejected.ForEach(delegate(OnGroupInviteRejected c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(characterId);
		});
	}

	public void cd43c84a879fddb291140293638a5954e(OnGroupInviteRejected c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGroupInviteRejected.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cf17170d26b4e534aad58bdc2e305ff80(OnGroupInviteRejected c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGroupInviteRejected.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnGroupMemberLeftEvent(Dictionary<byte, object> parameters)
	{
		int characterId = (int)parameters[0];
		mOnGroupMemberLeft.ForEach(delegate(OnGroupMemberLeft c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(characterId);
		});
	}

	public void c2efe9c168d27384ff717b5892166a339(OnGroupMemberLeft c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGroupMemberLeft.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c1bb26fc09507a3767762322c772323ee(OnGroupMemberLeft c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGroupMemberLeft.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnHostCreated(Dictionary<byte, object> parameters)
	{
		c134957d891c1a5e48a3b0e225297e7cb();
	}

	private void OnGroupGameStarted(Dictionary<byte, object> parameters)
	{
		PhotonNetwork.networkingPeer.c50190e0c5838cf36bc56ebceb28dcdaa(199, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnGameInvitationAccepted(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse != 0)
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
			if (parameters == null)
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
				if (!parameters.ContainsKey(0))
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId = (int)parameters[1];
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "GroupService.OnGameInvitationAccepted - " + c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId);
					c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cfe7182ecd28c1d073193664c0a470e42("OnGoToInstance", (string)parameters[0]);
					return;
				}
			}
		}
	}

	private void OnGroupDisbanded(Dictionary<byte, object> parameters)
	{
		List<OnGroupDisbanded> list = mOnGroupDisbanded;
		if (_003C_003Ef__am_0024cache10 == null)
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
			_003C_003Ef__am_0024cache10 = delegate(OnGroupDisbanded c2db84530ef366a6deb001d449d4aa151)
			{
				c2db84530ef366a6deb001d449d4aa151();
			};
		}
		list.ForEach(_003C_003Ef__am_0024cache10);
	}

	public void c4673957369c18711eb5a4fda7176b105(OnGroupDisbanded c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGroupDisbanded.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c31df6084a60b4f088073d616ba325bb6(OnGroupDisbanded c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGroupDisbanded.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnGroupMatchmakingStarted(Dictionary<byte, object> parameters)
	{
		List<OnGroupMatchmakingStarted> list = mOnGroupMatchmakingStarted;
		if (_003C_003Ef__am_0024cache11 == null)
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
			_003C_003Ef__am_0024cache11 = delegate(OnGroupMatchmakingStarted c2db84530ef366a6deb001d449d4aa151)
			{
				c2db84530ef366a6deb001d449d4aa151();
			};
		}
		list.ForEach(_003C_003Ef__am_0024cache11);
	}

	public void c57758adca9bd95b067ddf8df3f4e8939(OnGroupMatchmakingStarted c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGroupMatchmakingStarted.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c11375e2d310fed9d1afb1e151a77d71d(OnGroupMatchmakingStarted c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGroupMatchmakingStarted.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	[CompilerGenerated]
	private static void c31f3ba9dd8c3cfed8ce525bf53e12f50(OnKickedFromGroup c2db84530ef366a6deb001d449d4aa151)
	{
		c2db84530ef366a6deb001d449d4aa151();
	}

	[CompilerGenerated]
	private static void ce2ea8af8525f74e47b96fe6586238f93(OnGroupDisbanded c2db84530ef366a6deb001d449d4aa151)
	{
		c2db84530ef366a6deb001d449d4aa151();
	}

	[CompilerGenerated]
	private static void c212aeac388e4a06ddffe8921abebe3ca(OnGroupMatchmakingStarted c2db84530ef366a6deb001d449d4aa151)
	{
		c2db84530ef366a6deb001d449d4aa151();
	}
}
