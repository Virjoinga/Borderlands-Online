using A;

public abstract class OnAccessSingleton<Interface, OnlineImpl, OfflineImpl> where OnlineImpl : Interface, new() where OfflineImpl : Interface, new()
{
	private static Interface gInstance;

	public static Interface c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			if (gInstance == null)
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
				if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_offlineMode)
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
					object obj;
					if (default(OnlineImpl) != null)
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
						obj = default(OnlineImpl);
					}
					else
					{
						obj = new OnlineImpl();
					}
					gInstance = (Interface)(object)(OnlineImpl)obj;
				}
				else
				{
					object obj2;
					if (default(OfflineImpl) != null)
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
						obj2 = default(OfflineImpl);
					}
					else
					{
						obj2 = new OfflineImpl();
					}
					gInstance = (Interface)(object)(OfflineImpl)obj2;
				}
			}
			return gInstance;
		}
	}
}
