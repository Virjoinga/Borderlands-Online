using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;

internal class ProgressionService : OnAccessSingleton<IProgressionService, ProgressionService, ProgressionServiceOffline>, IProgressionService
{
	private Dictionary<int, int> mMyCachedUnlockedInstances = new Dictionary<int, int>();

	private List<InstanceUnlockedCallback> mInstanceUnlockedCallbacks = new List<InstanceUnlockedCallback>();

	private List<GetUnlockedInstancesCallback> mUnlockedInstancesCallback = new List<GetUnlockedInstancesCallback>();

	public ProgressionService()
	{
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(180, OnGetUnlockedInstances);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(179, OnCompleteInstance);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(205, OnInstanceUnlockedEvent);
		PhotonNetwork.networkingPeer.c89f9569b4330d0286992724cb1480f55(219, OnCompleteInstance);
	}

	public void cfc7db85f7cf2e51258ea6bcd864d4d2a(GetUnlockedInstancesCallback c2db84530ef366a6deb001d449d4aa151 = null)
	{
		if (c2db84530ef366a6deb001d449d4aa151 != null)
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
			mUnlockedInstancesCallback.Add(c2db84530ef366a6deb001d449d4aa151);
		}
		if (mUnlockedInstancesCallback.Count > 1)
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
			PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(180, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
			return;
		}
	}

	public Dictionary<int, int> c50c5e39d33643f03b4da08ee3c5dce44()
	{
		return mMyCachedUnlockedInstances;
	}

	public void OnGetUnlockedInstances(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
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
			mMyCachedUnlockedInstances = (Dictionary<int, int>)parameters[0];
		}
		if (mUnlockedInstancesCallback == null)
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
			mUnlockedInstancesCallback.ForEach(delegate(GetUnlockedInstancesCallback c5ebdc65d5cb420faf7ba524809963aa9)
			{
				c5ebdc65d5cb420faf7ba524809963aa9(mMyCachedUnlockedInstances);
			});
			mUnlockedInstancesCallback.Clear();
			return;
		}
	}

	public void cb88d873077b3039ed077ba472c62236c(InstanceInfo c388a00f101ddb02038b658208b4b9db0)
	{
		mMyCachedUnlockedInstances = c388a00f101ddb02038b658208b4b9db0.UnlockedInstances;
		if (mUnlockedInstancesCallback == null)
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
			mUnlockedInstancesCallback.ForEach(delegate(GetUnlockedInstancesCallback c5ebdc65d5cb420faf7ba524809963aa9)
			{
				c5ebdc65d5cb420faf7ba524809963aa9(mMyCachedUnlockedInstances);
			});
			mUnlockedInstancesCallback.Clear();
			return;
		}
	}

	public void cc67a53eb7c93420824fef0c7016fd77b(int c5dfde30d8784694fb9999709d290e6c4, int c02dd9cb4734ae12d5f983d2c1e5f0c45)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		array[1] = c02dd9cb4734ae12d5f983d2c1e5f0c45;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(178, array);
	}

	public void ca2d57544072df39cffe0a22b0cb2bcfa(int c5dfde30d8784694fb9999709d290e6c4, int c02dd9cb4734ae12d5f983d2c1e5f0c45, int c46b57735a769802f4565a74b7185cc1f)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(3);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		array[1] = c02dd9cb4734ae12d5f983d2c1e5f0c45;
		array[2] = c46b57735a769802f4565a74b7185cc1f;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(179, array);
	}

	public void OnCompleteInstance(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse != 0)
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
				if (parameters.Count <= 0)
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
					if (PhotonNetwork.networkingPeer == null)
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
						int num = (int)parameters[0];
						int num2 = (int)parameters[1];
						int num3 = (int)parameters[2];
						Hashtable hashtable = new Hashtable();
						hashtable.Add(0, num);
						hashtable.Add(1, num2);
						hashtable.Add(2, num3);
						Hashtable c98406db696ab6ddbd25ee108c3e91e6a = hashtable;
						PhotonNetwork.networkingPeer.c3f632fdd31c8a3f2463924fbc1ced8b4(219, c98406db696ab6ddbd25ee108c3e91e6a, true, 0);
						return;
					}
				}
			}
		}
	}

	public void OnCompleteInstance(Dictionary<byte, object> parameters)
	{
		Hashtable hashtable = (Hashtable)parameters[245];
		int num = (int)hashtable[0];
		int key = (int)hashtable[1];
		int value = (int)hashtable[2];
		if (num != OnlineService.s_characterId)
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
			mMyCachedUnlockedInstances[key] = value;
			return;
		}
	}

	public void c93da630efea1a10cb46ea9bd9ab69472(InstanceUnlockedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mInstanceUnlockedCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c0af077e6188d35f820a260793f344af6(InstanceUnlockedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mInstanceUnlockedCallbacks.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void OnInstanceUnlockedEvent(Dictionary<byte, object> parameters)
	{
		cfc7db85f7cf2e51258ea6bcd864d4d2a(c31470d5d8142001f03d27919f59c0ed7.c7088de59e49f7108f520cf7e0bae167e);
		mInstanceUnlockedCallbacks.ForEach(delegate(InstanceUnlockedCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151((int)parameters[0]);
		});
	}

	[CompilerGenerated]
	private void ca574fd226bcd3c106ad33c8f3cc033bb(GetUnlockedInstancesCallback c5ebdc65d5cb420faf7ba524809963aa9)
	{
		c5ebdc65d5cb420faf7ba524809963aa9(mMyCachedUnlockedInstances);
	}

	[CompilerGenerated]
	private void c75cfb47dd73c5e06a6ce9dc9c91227b5(GetUnlockedInstancesCallback c5ebdc65d5cb420faf7ba524809963aa9)
	{
		c5ebdc65d5cb420faf7ba524809963aa9(mMyCachedUnlockedInstances);
	}
}
