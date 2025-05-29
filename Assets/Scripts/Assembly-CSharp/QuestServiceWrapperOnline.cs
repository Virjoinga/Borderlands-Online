using System.Collections.Generic;
using A;
using XsdSettings;

public class QuestServiceWrapperOnline : IQuestServiceWrapper, IServiceWrapper
{
	private bool m_isInitializing;

	private bool m_initialized;

	private void ce3999f448884c350b5510fc0d77e1e46(int c24a23635a8b6b95d7730eefdf77f7b9e, Dictionary<int, QuestProgress> cd563a3564d781de51750031f869a03aa)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnQuestProgress(c24a23635a8b6b95d7730eefdf77f7b9e, cd563a3564d781de51750031f869a03aa);
		m_initialized = true;
	}

	public void c05a53e9c364719e9f724ca2748a9199c(int c24a23635a8b6b95d7730eefdf77f7b9e, int c731f8f565b2035819f3412520ff285b3, QuestState c5e55314b6446c3aaa542cdc053941d3c)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnQuestUpdate(c24a23635a8b6b95d7730eefdf77f7b9e, c731f8f565b2035819f3412520ff285b3, c5e55314b6446c3aaa542cdc053941d3c);
	}

	public void c2a3032f0f25bc999ccd55ea47e8f7864(int c24a23635a8b6b95d7730eefdf77f7b9e, int c731f8f565b2035819f3412520ff285b3)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnQuestAccepted(c24a23635a8b6b95d7730eefdf77f7b9e, c731f8f565b2035819f3412520ff285b3);
	}

	public void c07214bf834ee8a335a0e4430845aa350(int c24a23635a8b6b95d7730eefdf77f7b9e, int c731f8f565b2035819f3412520ff285b3, QuestReward[] c55dd37540e00b15834b57c55fd71369f)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnQuestRewardClaimed(c24a23635a8b6b95d7730eefdf77f7b9e, c731f8f565b2035819f3412520ff285b3, c55dd37540e00b15834b57c55fd71369f);
	}

	public void c18c9cc5319431bb4d2a77a18b0d2676f(Dictionary<int, DailyQuestInfo> c7ef601ca66dcb647c906b9aa00299351)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnGetPlayerDailyQuestsContent(c7ef601ca66dcb647c906b9aa00299351);
	}

	public void cb2ca92f632bc4d4aef2057a6bce6a8db()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnClearPlayerDailyQuest();
	}

	public void cd93285db16841148ed53a5bbeb35cf20()
	{
		if (m_isInitializing)
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
			if (m_initialized)
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
				m_isInitializing = true;
				OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c4c0bdfafe8e95354b5fbeb52e4c32d3d(c2a3032f0f25bc999ccd55ea47e8f7864);
				OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c530831a7ae824f7a624d7d8e23a5a064(c07214bf834ee8a335a0e4430845aa350);
				OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c44c96f389ef3a2876896b4e3f64f453c(c05a53e9c364719e9f724ca2748a9199c);
				OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cb78578f9da078d41ec650239fe560809(c18c9cc5319431bb4d2a77a18b0d2676f);
				OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ca52c9e2259d0b538edee5722aa748096(cb2ca92f632bc4d4aef2057a6bce6a8db);
				OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c43f812e5db31871c2108e9f7fc8a0a73();
				OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c4bd163e6f603f6c0724372fd12f5f4cb(OnlineService.s_characterId, ce3999f448884c350b5510fc0d77e1e46);
				return;
			}
		}
	}

	public bool c39df47367fa21412aabfef05d9972f8c()
	{
		return m_initialized;
	}

	public void c5fdc976a8c3f9e6e8516525fd2a5396f(int c731f8f565b2035819f3412520ff285b3)
	{
		OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c5fdc976a8c3f9e6e8516525fd2a5396f(OnlineService.s_characterId, c731f8f565b2035819f3412520ff285b3);
	}

	public void cf7f98b1de39f26f9a9d63b5d8ac5a26b(int c731f8f565b2035819f3412520ff285b3)
	{
		OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cf7f98b1de39f26f9a9d63b5d8ac5a26b(OnlineService.s_characterId, c731f8f565b2035819f3412520ff285b3);
	}

	public void c43f812e5db31871c2108e9f7fc8a0a73()
	{
		OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c43f812e5db31871c2108e9f7fc8a0a73();
	}

	public Dictionary<int, QuestProgress> c4bd163e6f603f6c0724372fd12f5f4cb()
	{
		return OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c4bd163e6f603f6c0724372fd12f5f4cb(OnlineService.s_characterId, ce3999f448884c350b5510fc0d77e1e46);
	}

	public void cddb1928d6bb517752689884a3e06f40b(int c5dfde30d8784694fb9999709d290e6c4, int c731f8f565b2035819f3412520ff285b3)
	{
		OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cddb1928d6bb517752689884a3e06f40b(c5dfde30d8784694fb9999709d290e6c4, c731f8f565b2035819f3412520ff285b3);
	}

	public void cb534083a07db3bd6b74a38a62625f875(TalkToNPCCallback c2db84530ef366a6deb001d449d4aa151, int c731f8f565b2035819f3412520ff285b3, int c43e3d8b3e47e153da82a98666f9b6412)
	{
		OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cb534083a07db3bd6b74a38a62625f875(c2db84530ef366a6deb001d449d4aa151, c731f8f565b2035819f3412520ff285b3, c43e3d8b3e47e153da82a98666f9b6412);
	}

	public void c069e3e12ab95ff8518fd20364724de3f(BringToNPCCallback c2db84530ef366a6deb001d449d4aa151, int c731f8f565b2035819f3412520ff285b3, int c43e3d8b3e47e153da82a98666f9b6412)
	{
		OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c069e3e12ab95ff8518fd20364724de3f(c2db84530ef366a6deb001d449d4aa151, c731f8f565b2035819f3412520ff285b3, c43e3d8b3e47e153da82a98666f9b6412);
	}

	public void c509488e7555f17435dc7dacc1709e509(int c5dfde30d8784694fb9999709d290e6c4, int c731f8f565b2035819f3412520ff285b3)
	{
		OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c509488e7555f17435dc7dacc1709e509(c5dfde30d8784694fb9999709d290e6c4, c731f8f565b2035819f3412520ff285b3);
	}
}
