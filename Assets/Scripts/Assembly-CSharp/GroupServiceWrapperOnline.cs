using System.Collections.Generic;
using A;

public class GroupServiceWrapperOnline : IGroupServiceWrapper, IServiceWrapper
{
	private bool m_isInitializing;

	private bool m_initialized;

	public void cd93285db16841148ed53a5bbeb35cf20()
	{
		if (m_isInitializing)
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
			if (m_initialized)
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
				m_isInitializing = true;
				OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c84e7d656f39a60ef71f428c59209c060(OnGotMyGroupInfo);
				OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c114948ed36fb1a4d6b353138ed1010db(c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnReceivedGroupInvitation);
				OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ca45843961de8374d80cdeb8f94dd31f8(c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnKickedFromGroup);
				OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c94a7691c6a1d4fa906b09f9848bba0b4(c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnNewGroupLeader);
				OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cf5aa79a863e007ea7d17ed638a8485e4(c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnNewGroupMember);
				OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cd43c84a879fddb291140293638a5954e(c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnGroupInviteRejected);
				OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c2efe9c168d27384ff717b5892166a339(c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnGroupMemberLeft);
				OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c4673957369c18711eb5a4fda7176b105(c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnGroupDisbanded);
				OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c57758adca9bd95b067ddf8df3f4e8939(c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnGroupMatchmakingStarted);
				GroupManager.c71f6ce28731edfd43c976fbd57c57bea();
				return;
			}
		}
	}

	private void OnGotMyGroupInfo(int groupId, List<Presence> members)
	{
		m_initialized = true;
	}

	public bool c39df47367fa21412aabfef05d9972f8c()
	{
		return m_initialized;
	}

	public void c84e7d656f39a60ef71f428c59209c060(OnGotMyGroupInfo c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c84e7d656f39a60ef71f428c59209c060(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c89fcb77276a7956cd51b61c3a4437b0f(OnSendGroupInvitation c2db84530ef366a6deb001d449d4aa151, int ca8606b1ba21cbc6f2fc0045fe691e617)
	{
		OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c89fcb77276a7956cd51b61c3a4437b0f(c2db84530ef366a6deb001d449d4aa151, ca8606b1ba21cbc6f2fc0045fe691e617);
	}

	public void cdabc733e8aacf96718d8617e58274f40(OnGroupInviteAccepted c2db84530ef366a6deb001d449d4aa151, int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cdabc733e8aacf96718d8617e58274f40(c2db84530ef366a6deb001d449d4aa151, c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void c574e1ae38231526cf898f00f985e88b2(int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c574e1ae38231526cf898f00f985e88b2(c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void c347662a41df388198423d3559d957132(OnKickPlayerFromGroup c2db84530ef366a6deb001d449d4aa151, int c1f6894ec2553584a258c0f0df766fc1f)
	{
		OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c347662a41df388198423d3559d957132(c2db84530ef366a6deb001d449d4aa151, c1f6894ec2553584a258c0f0df766fc1f);
	}

	public void c635f796eee513fdcf0733537d7f44398(OnLeaveGroup c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c635f796eee513fdcf0733537d7f44398(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c134957d891c1a5e48a3b0e225297e7cb()
	{
		OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c134957d891c1a5e48a3b0e225297e7cb();
	}

	public void cde4925fdec123105628516489c324acf(OnGotMyGroupInfo c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cde4925fdec123105628516489c324acf(c2db84530ef366a6deb001d449d4aa151);
	}
}
