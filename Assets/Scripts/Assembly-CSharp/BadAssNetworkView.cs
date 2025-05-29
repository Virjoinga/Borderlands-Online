using System;
using A;

public class BadAssNetworkView : PhotonView
{
	private new void Awake()
	{
		base.Awake();
	}

	private void Start()
	{
		InstantiateManager component = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<InstantiateManager>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			component.c76f6e01303388351d94423282930f308(base.gameObject);
		}
		NetworkManager component2 = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<NetworkManager>();
		if (!(component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			component2.c067a069fc32be238b53d9b3e1725f179(this);
			return;
		}
	}

	private new void OnDestroy()
	{
		AppManager c5ee19dc8d4cccf5ae2de225410458b = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86;
		if (!(c5ee19dc8d4cccf5ae2de225410458b != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			InstantiateManager component = c5ee19dc8d4cccf5ae2de225410458b.GetComponent<InstantiateManager>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				component.c77ad3ea1777a263169b5b42beafc6a44(base.gameObject);
			}
			NetworkManager component2 = c5ee19dc8d4cccf5ae2de225410458b.GetComponent<NetworkManager>();
			if (!(component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				component2.c9102a7afa9603b27d23d3470c21b34c8(this);
				return;
			}
		}
	}

	public int c1be7daf43cffd44f2ffdbd251a6a3fe8()
	{
		return base.ce57f12a4f7e693a5fe0c4049dc56fa7c;
	}

	public static BadAssNetworkView c16cef725419dd5314991ac769ad60eb9(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		int count = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<NetworkManager>().cd5b2d1a3a14637e9081fc019ba36ea0f.Count;
		for (int i = 0; i < count; i++)
		{
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<NetworkManager>().cd5b2d1a3a14637e9081fc019ba36ea0f[i].c1be7daf43cffd44f2ffdbd251a6a3fe8() != c35f98ccbfa8c6bf09319c620b21b5dc5)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<NetworkManager>().cd5b2d1a3a14637e9081fc019ba36ea0f[i];
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public static Entity cd45cbc6284a89fa5c2b29c7ad9718528(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		Entity result = c72d1b2b1b60b723ae8df41127652adb5.c7088de59e49f7108f520cf7e0bae167e;
		BadAssNetworkView badAssNetworkView = c16cef725419dd5314991ac769ad60eb9(c35f98ccbfa8c6bf09319c620b21b5dc5);
		if (badAssNetworkView != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			result = (Entity)badAssNetworkView.GetComponent(Type.GetTypeFromHandle(c55d5dd99976c8f85dca17e59f9a38969.cc1720d05c75832f704b87474932341c3()));
		}
		return result;
	}
}
