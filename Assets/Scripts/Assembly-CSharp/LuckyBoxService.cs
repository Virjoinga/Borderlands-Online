using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using XsdSettings;

internal class LuckyBoxService : OnAccessSingleton<ILuckyBoxService, LuckyBoxService, LuckyBoxServiceOffline>, ILuckyBoxService
{
	private List<OnLuckyBoxOpened> mLuckyBoxOpenedCallbacks;

	private List<OnLuckyBoxAwarded> mLuckyBoxAwardedCallbacks;

	[CompilerGenerated]
	private static Action<OnLuckyBoxOpened> _003C_003Ef__am_0024cache2;

	public LuckyBoxService()
	{
		mLuckyBoxAwardedCallbacks = new List<OnLuckyBoxAwarded>();
		mLuckyBoxOpenedCallbacks = new List<OnLuckyBoxOpened>();
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(71, OnOpenLuckyBox);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(70, OnAwardLuckyBox);
	}

	public void cc153f529c9d81cda8397e0213df6f866(OnLuckyBoxOpened c2db84530ef366a6deb001d449d4aa151, int c5612a459a84ffdb41c885401433cd62d, bool c4cc507173518aa9977af6f5db77f0b09)
	{
		if (c2db84530ef366a6deb001d449d4aa151 != null)
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
			mLuckyBoxOpenedCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c5612a459a84ffdb41c885401433cd62d;
		array[1] = c4cc507173518aa9977af6f5db77f0b09;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(71, array);
	}

	private void OnOpenLuckyBox(short operationResponse, Dictionary<byte, object> parameters)
	{
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			bool locked = (bool)parameters[0];
			int index = (int)parameters[1];
			ItemDNA rewardedItem = ItemDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2((Hashtable)parameters[2]);
			ItemDNA dummyItem1 = ItemDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2((Hashtable)parameters[3]);
			ItemDNA dummyItem2 = ItemDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2((Hashtable)parameters[4]);
			mLuckyBoxOpenedCallbacks.ForEach(delegate(OnLuckyBoxOpened c5ebdc65d5cb420faf7ba524809963aa9)
			{
				c5ebdc65d5cb420faf7ba524809963aa9(locked, index, rewardedItem, dummyItem1, dummyItem2);
			});
		}
		else
		{
			List<OnLuckyBoxOpened> list = mLuckyBoxOpenedCallbacks;
			if (_003C_003Ef__am_0024cache2 == null)
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
				_003C_003Ef__am_0024cache2 = delegate(OnLuckyBoxOpened c5ebdc65d5cb420faf7ba524809963aa9)
				{
					c5ebdc65d5cb420faf7ba524809963aa9(false, 0, null, null, c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
				};
			}
			list.ForEach(_003C_003Ef__am_0024cache2);
		}
		mLuckyBoxOpenedCallbacks.Clear();
	}

	public void c7f5063fa13b4fa99234b72030b7f1abc(OnLuckyBoxAwarded c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4, int c02dd9cb4734ae12d5f983d2c1e5f0c45, ELevelDifficulty c46b57735a769802f4565a74b7185cc1f, InstanceGrade c9c280b2e5a5aaf667489e5c36b47bcb2, int cf5a64769d5c20650f954eec6cf015d1f)
	{
		if (c2db84530ef366a6deb001d449d4aa151 != null)
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
			mLuckyBoxAwardedCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		array[1] = c02dd9cb4734ae12d5f983d2c1e5f0c45;
		array[2] = (int)c46b57735a769802f4565a74b7185cc1f;
		array[3] = (int)c9c280b2e5a5aaf667489e5c36b47bcb2;
		array[4] = cf5a64769d5c20650f954eec6cf015d1f;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(70, array);
	}

	private void OnAwardLuckyBox(short operationResponse, Dictionary<byte, object> parameters)
	{
		mLuckyBoxAwardedCallbacks.ForEach(delegate(OnLuckyBoxAwarded c5ebdc65d5cb420faf7ba524809963aa9)
		{
			c5ebdc65d5cb420faf7ba524809963aa9(operationResponse == 0);
		});
		mLuckyBoxAwardedCallbacks.Clear();
	}

	[CompilerGenerated]
	private static void cc71bb375ad95c26f56ba2fb075b955e0(OnLuckyBoxOpened c5ebdc65d5cb420faf7ba524809963aa9)
	{
		c5ebdc65d5cb420faf7ba524809963aa9(false, 0, null, null, c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
	}
}
