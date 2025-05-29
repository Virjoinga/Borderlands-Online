using System.Collections;
using System.Collections.Generic;
using A;

internal class SkillTreeService : OnAccessSingleton<ISkillTreeService, SkillTreeService, SkillTreeServiceOffline>, ISkillTreeService
{
	private List<SkillPointEarnedCallback> mSkillPointEarnedCallbacks = new List<SkillPointEarnedCallback>();

	private GetSkillPointsCallback mGetSkillPointsCallback;

	private GetInvestedSkillPointsCallback mGetInvestedSkillPointsCallback;

	private InvestSkillPointCallback mInvestSkillPointCallback;

	private InvestMultipleSkillPointsCallback mInvestMultipleSkillPointsCallback;

	private ResetSkillPointsCallback mResetSkillPointsCallback;

	public SkillTreeService()
	{
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(173, OnGetMySkillPoints);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(171, OnGetInvestedSkillPoints);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(170, OnInvestSkillPoint);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(169, OnInvestMultipleSkillPoints);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(168, OnResetSkillPoints);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(216, OnSkillPointEarned);
	}

	public void cfef95a32127bfb3897865c32b38a72a3(GetSkillPointsCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mGetSkillPointsCallback = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(173, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnGetMySkillPoints(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mGetSkillPointsCallback == null)
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
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				Hashtable[] array = (Hashtable[])parameters[3];
				List<InvestedSkill> list = new List<InvestedSkill>();
				Hashtable[] array2 = array;
				foreach (Hashtable hashtable in array2)
				{
					Hashtable hashtable2 = hashtable;
					if (hashtable2 == null)
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
					list.Add(new InvestedSkill((int)hashtable2[0], (int)hashtable2[1]));
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
				mGetSkillPointsCallback((int)parameters[0], (int)parameters[1], (int)parameters[2], list);
			}
			else
			{
				mGetSkillPointsCallback(0, 0, 0, cd9e7a6c5ce500d6e9d8bb4168302c845.c7088de59e49f7108f520cf7e0bae167e);
			}
			mGetSkillPointsCallback = ca5956dc2b0633b4582da8f716bf802a4.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c7fe14ccbaeef789d0411030045ae63f3(int c5dfde30d8784694fb9999709d290e6c4, GetInvestedSkillPointsCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mGetInvestedSkillPointsCallback = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(171, array);
	}

	private void OnGetInvestedSkillPoints(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mGetInvestedSkillPointsCallback == null)
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
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				Hashtable[] array = (Hashtable[])parameters[1];
				List<InvestedSkill> list = new List<InvestedSkill>();
				Hashtable[] array2 = array;
				foreach (Hashtable hashtable in array2)
				{
					Hashtable hashtable2 = hashtable;
					if (hashtable2 == null)
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
					list.Add(new InvestedSkill((int)hashtable2[0], (int)hashtable2[1]));
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
				mGetInvestedSkillPointsCallback((int)parameters[0], list);
			}
			else
			{
				mGetInvestedSkillPointsCallback(0, cd9e7a6c5ce500d6e9d8bb4168302c845.c7088de59e49f7108f520cf7e0bae167e);
			}
			mGetInvestedSkillPointsCallback = c08000000a307ba33a1caea4aa42f224c.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void ca386063cf1e9f62374d53cb460ea8131(int cdc3aad41bf2754930ba17d687011c2ea, InvestSkillPointCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mInvestSkillPointCallback = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = cdc3aad41bf2754930ba17d687011c2ea;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(170, array);
	}

	private void OnInvestSkillPoint(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mInvestSkillPointCallback == null)
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
				mInvestSkillPointCallback((int)parameters[0], (int)parameters[1], true);
			}
			else
			{
				mInvestSkillPointCallback(0, 0, false);
			}
			mInvestSkillPointCallback = cd8ddc9e7fa44a8821d35eb05d68b1012.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void cf139283d44a3a850f9d9872a8c0c74f2(List<InvestedSkill> c3f381ce5aea55f604e88efed1ea621bd, InvestMultipleSkillPointsCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mInvestMultipleSkillPointsCallback = c2db84530ef366a6deb001d449d4aa151;
		Dictionary<int, Hashtable> dictionary = new Dictionary<int, Hashtable>();
		int num = 0;
		using (List<InvestedSkill>.Enumerator enumerator = c3f381ce5aea55f604e88efed1ea621bd.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				InvestedSkill current = enumerator.Current;
				dictionary[num++] = new Hashtable
				{
					{ 0, current.cca02a1eac8c42296f4fdb7cf3612badb },
					{ 1, current.c965a511d00f8d94f0770a443a06696e5 }
				};
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
				break;
			}
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = dictionary;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(169, array);
	}

	private void OnInvestMultipleSkillPoints(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mInvestMultipleSkillPointsCallback == null)
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
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				Dictionary<int, Hashtable> dictionary = (Dictionary<int, Hashtable>)parameters[1];
				List<InvestedSkill> list = new List<InvestedSkill>();
				using (Dictionary<int, Hashtable>.Enumerator enumerator = dictionary.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<int, Hashtable> current = enumerator.Current;
						list.Add(new InvestedSkill((int)current.Value[0], (int)current.Value[1]));
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							goto end_IL_00a4;
						}
						continue;
						end_IL_00a4:
						break;
					}
				}
				mInvestMultipleSkillPointsCallback((int)parameters[0], list, true);
			}
			else
			{
				mInvestMultipleSkillPointsCallback(0, null, false);
			}
			mInvestMultipleSkillPointsCallback = c5f7f56541c3ec4950437bbceffa31435.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void cc5937332e02452fa6fb4760b2f5c7c81(ResetSkillPointsCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mResetSkillPointsCallback = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(168, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnResetSkillPoints(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mResetSkillPointsCallback == null)
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
				mResetSkillPointsCallback((int)parameters[0], true);
			}
			else
			{
				mResetSkillPointsCallback(0, false);
			}
			mResetSkillPointsCallback = cb4c6e42096ec2db06617dd134f7379dd.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void cc728faa57c0b09d666b6465dc3512818(SkillPointEarnedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mSkillPointEarnedCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c6bcdbd47128698a043e3dd32cecb6894(SkillPointEarnedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mSkillPointEarnedCallbacks.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void OnSkillPointEarned(Dictionary<byte, object> parameters)
	{
		mSkillPointEarnedCallbacks.ForEach(delegate(SkillPointEarnedCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151((int)parameters[0], (int)parameters[1]);
		});
	}
}
