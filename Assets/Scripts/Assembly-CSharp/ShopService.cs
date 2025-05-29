using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;

public class ShopService : OnAccessSingleton<IShopService, ShopService, ShopServiceOffline>, IShopService
{
	private List<OnGetShop> mOnGetShop = new List<OnGetShop>();

	private List<OnBuyItem> mOnBuyItem = new List<OnBuyItem>();

	private List<OnSellItem> mOnSellItem = new List<OnSellItem>();

	[CompilerGenerated]
	private static Action<OnGetShop> _003C_003Ef__am_0024cache3;

	[CompilerGenerated]
	private static Action<OnBuyItem> _003C_003Ef__am_0024cache4;

	[CompilerGenerated]
	private static Action<OnSellItem> _003C_003Ef__am_0024cache5;

	public ShopService()
	{
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(121, OnGetShopResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(120, OnBuyItemResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(119, OnSellItemResponse);
	}

	public void cee370ce68b9715d7b8caecb310431e99(OnGetShop c2db84530ef366a6deb001d449d4aa151, int c7fb5526882c47c390d0b3d05b4af3c20)
	{
		if (c2db84530ef366a6deb001d449d4aa151 != null)
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
			mOnGetShop.Add(c2db84530ef366a6deb001d449d4aa151);
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c7fb5526882c47c390d0b3d05b4af3c20;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(121, array);
	}

	public void c7f28ddd1220dda589dc52ee35675cae0(OnBuyItem c2db84530ef366a6deb001d449d4aa151, int c7fb5526882c47c390d0b3d05b4af3c20, int c36fe912d113b7822ea652039402f655e)
	{
		c7f28ddd1220dda589dc52ee35675cae0(c2db84530ef366a6deb001d449d4aa151, c7fb5526882c47c390d0b3d05b4af3c20, c36fe912d113b7822ea652039402f655e, 1);
	}

	public void c7f28ddd1220dda589dc52ee35675cae0(OnBuyItem c2db84530ef366a6deb001d449d4aa151, int c7fb5526882c47c390d0b3d05b4af3c20, int c36fe912d113b7822ea652039402f655e, int c71bf89d19a5e197aade34b29b90c8497)
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
			mOnBuyItem.Add(c2db84530ef366a6deb001d449d4aa151);
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(3);
		array[0] = c7fb5526882c47c390d0b3d05b4af3c20;
		array[1] = c36fe912d113b7822ea652039402f655e;
		array[2] = c71bf89d19a5e197aade34b29b90c8497;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(120, array);
	}

	public void c5b864eec9f929b1fcd70afbe269e3bd2(OnBuyItem c2db84530ef366a6deb001d449d4aa151, int c7fb5526882c47c390d0b3d05b4af3c20, int c36fe912d113b7822ea652039402f655e)
	{
		c7f28ddd1220dda589dc52ee35675cae0(c2db84530ef366a6deb001d449d4aa151, c7fb5526882c47c390d0b3d05b4af3c20, c36fe912d113b7822ea652039402f655e + 14, 1);
	}

	public void c5b864eec9f929b1fcd70afbe269e3bd2(OnBuyItem c2db84530ef366a6deb001d449d4aa151, int c7fb5526882c47c390d0b3d05b4af3c20, int c36fe912d113b7822ea652039402f655e, int c71bf89d19a5e197aade34b29b90c8497)
	{
		c7f28ddd1220dda589dc52ee35675cae0(c2db84530ef366a6deb001d449d4aa151, c7fb5526882c47c390d0b3d05b4af3c20, c36fe912d113b7822ea652039402f655e + 14, c71bf89d19a5e197aade34b29b90c8497);
	}

	public void cad34423fd2aee433703096e2c5a63d71(OnSellItem c2db84530ef366a6deb001d449d4aa151, int c7fb5526882c47c390d0b3d05b4af3c20, int c50d6c76e4607113cf1a4b7da4dbea4dc)
	{
		cad34423fd2aee433703096e2c5a63d71(c2db84530ef366a6deb001d449d4aa151, c7fb5526882c47c390d0b3d05b4af3c20, c50d6c76e4607113cf1a4b7da4dbea4dc, 1);
	}

	public void cad34423fd2aee433703096e2c5a63d71(OnSellItem c2db84530ef366a6deb001d449d4aa151, int c7fb5526882c47c390d0b3d05b4af3c20, int c50d6c76e4607113cf1a4b7da4dbea4dc, int c71bf89d19a5e197aade34b29b90c8497)
	{
		if (c2db84530ef366a6deb001d449d4aa151 != null)
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
			mOnSellItem.Add(c2db84530ef366a6deb001d449d4aa151);
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(3);
		array[0] = c7fb5526882c47c390d0b3d05b4af3c20;
		array[1] = c50d6c76e4607113cf1a4b7da4dbea4dc;
		array[2] = c71bf89d19a5e197aade34b29b90c8497;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(119, array);
	}

	private void OnGetShopResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
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
			Shop shop = new Shop((Hashtable)parameters[0]);
			mOnGetShop.ForEach(delegate(OnGetShop cbd1639b67f4774915e463c3fd4e982f3)
			{
				cbd1639b67f4774915e463c3fd4e982f3(shop);
			});
		}
		else
		{
			List<OnGetShop> list = mOnGetShop;
			if (_003C_003Ef__am_0024cache3 == null)
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
				_003C_003Ef__am_0024cache3 = delegate(OnGetShop cbd1639b67f4774915e463c3fd4e982f3)
				{
					cbd1639b67f4774915e463c3fd4e982f3(c4b7fc26aed2aca8eae67b1022fddca4e.c7088de59e49f7108f520cf7e0bae167e);
				};
			}
			list.ForEach(_003C_003Ef__am_0024cache3);
		}
		mOnGetShop.Clear();
	}

	private void OnBuyItemResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
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
			ItemDNA newItem = ItemDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2((Hashtable)parameters[0]);
			mOnBuyItem.ForEach(delegate(OnBuyItem cbd1639b67f4774915e463c3fd4e982f3)
			{
				cbd1639b67f4774915e463c3fd4e982f3(newItem);
			});
		}
		else
		{
			List<OnBuyItem> list = mOnBuyItem;
			if (_003C_003Ef__am_0024cache4 == null)
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
				_003C_003Ef__am_0024cache4 = delegate(OnBuyItem cbd1639b67f4774915e463c3fd4e982f3)
				{
					cbd1639b67f4774915e463c3fd4e982f3(c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
				};
			}
			list.ForEach(_003C_003Ef__am_0024cache4);
		}
		mOnBuyItem.Clear();
	}

	private void OnSellItemResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
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
			int sellPrice = (int)parameters[0];
			ItemDNA soldItem = ItemDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2((Hashtable)parameters[1]);
			mOnSellItem.ForEach(delegate(OnSellItem cbd1639b67f4774915e463c3fd4e982f3)
			{
				cbd1639b67f4774915e463c3fd4e982f3(sellPrice, soldItem);
			});
		}
		else
		{
			List<OnSellItem> list = mOnSellItem;
			if (_003C_003Ef__am_0024cache5 == null)
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
				_003C_003Ef__am_0024cache5 = delegate(OnSellItem cbd1639b67f4774915e463c3fd4e982f3)
				{
					cbd1639b67f4774915e463c3fd4e982f3(0, c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
				};
			}
			list.ForEach(_003C_003Ef__am_0024cache5);
		}
		mOnSellItem.Clear();
	}

	[CompilerGenerated]
	private static void c90572df051e9e2fff9fd8945979e3ada(OnGetShop cbd1639b67f4774915e463c3fd4e982f3)
	{
		cbd1639b67f4774915e463c3fd4e982f3(c4b7fc26aed2aca8eae67b1022fddca4e.c7088de59e49f7108f520cf7e0bae167e);
	}

	[CompilerGenerated]
	private static void ca9cd02e514a67f206764d4402c335143(OnBuyItem cbd1639b67f4774915e463c3fd4e982f3)
	{
		cbd1639b67f4774915e463c3fd4e982f3(c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
	}

	[CompilerGenerated]
	private static void c0b14fc3de8e45919bddc746d832c8a99(OnSellItem cbd1639b67f4774915e463c3fd4e982f3)
	{
		cbd1639b67f4774915e463c3fd4e982f3(0, c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
	}
}
