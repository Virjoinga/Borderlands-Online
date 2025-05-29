using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using UnityEngine;
using XsdSettings;

public class ShopServiceWrapper : ServiceWrapper<IServiceWrapper, ShopServiceWrapper>
{
	private ShopSetup m_setup;

	protected List<IShopServiceNotificationListerner> m_notificationListeners = new List<IShopServiceNotificationListerner>();

	protected Dictionary<int, Shop> m_shops = new Dictionary<int, Shop>();

	protected List<ShopItem> m_soldItemList = new List<ShopItem>();

	public EconomicSettings m_economicSettings { get; private set; }

	public ShopSetup c4a75d81249f55113c773cfaeb64936ea
	{
		get
		{
			return m_setup;
		}
	}

	public void ca2884d7256ce0aea83f1514943d01516(IShopServiceNotificationListerner c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_notificationListeners.Add(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void ca26d27966aa77e63db313b86dba22cf2(IShopServiceNotificationListerner c472a3b7c9dbd0d177f87c4386db7570d)
	{
		if (!m_notificationListeners.Contains(c472a3b7c9dbd0d177f87c4386db7570d))
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
			m_notificationListeners.Remove(c472a3b7c9dbd0d177f87c4386db7570d);
			return;
		}
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/Shops");
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(cac7765d9138f306d6af48c627816bbe2.cc1720d05c75832f704b87474932341c3()));
		m_setup = xmlSerializer.Deserialize(new StringReader(textAsset.text)) as ShopSetup;
		Resources.UnloadAsset(textAsset);
		m_soldItemList = new List<ShopItem>();
		textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/EconomicSettings");
		xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c78da4ce30e3d6a9b227232f66cb01e18.cc1720d05c75832f704b87474932341c3()));
		m_economicSettings = xmlSerializer.Deserialize(new StringReader(textAsset.text)) as EconomicSettings;
		Resources.UnloadAsset(textAsset);
	}

	public int cea43b56720acf4921bdb69611f03ebdb(ItemDNA ca57e1c076c01141c5ce58c7341db7833)
	{
		int num = 0;
		for (int i = 0; i < m_economicSettings.m_priceSettings.Length; i++)
		{
			ItemPriceSetting itemPriceSetting = m_economicSettings.m_priceSettings[i];
			if (itemPriceSetting.m_adjustements == null)
			{
				continue;
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (ca57e1c076c01141c5ce58c7341db7833.m_type != itemPriceSetting.m_itemType)
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
			num = itemPriceSetting.m_basicValue;
			for (int j = 0; j < itemPriceSetting.m_adjustements.Length; j++)
			{
				if (itemPriceSetting.m_adjustements[j].m_rarety != (WeaponRarity)ca57e1c076c01141c5ce58c7341db7833.cdb37a58b3efd54adcd5545eac569695f)
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
					return num * (int)((double)itemPriceSetting.m_adjustements[j].m_adjustValue * (double)ca57e1c076c01141c5ce58c7341db7833.c7513e66c4e0fc55e6fea9dd9cb8b9943());
				}
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
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			return num;
		}
	}

	public Shop cee370ce68b9715d7b8caecb310431e99(int cf610d94618b9f7d566b3ae454dc2189f, bool c3a04e75b6adb59123df6196d778ced76 = false)
	{
		Shop value = c4b7fc26aed2aca8eae67b1022fddca4e.c7088de59e49f7108f520cf7e0bae167e;
		if (m_shops.TryGetValue(cf610d94618b9f7d566b3ae454dc2189f, out value))
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
			if (!c3a04e75b6adb59123df6196d778ced76)
			{
				goto IL_0051;
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
		}
		OnAccessSingleton<IShopService, ShopService, ShopServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cee370ce68b9715d7b8caecb310431e99(OnGetShop, cf610d94618b9f7d566b3ae454dc2189f);
		goto IL_0051;
		IL_0051:
		return value;
	}

	public List<ShopItem> c5c425976647efd150c2c4d1b924e1640()
	{
		return m_soldItemList;
	}

	public void c7f28ddd1220dda589dc52ee35675cae0(int cf610d94618b9f7d566b3ae454dc2189f, int cbddd1469f329dec33f64f1fd0accd476, int c19c97216472918df7449a5e047301b39 = 1)
	{
		OnAccessSingleton<IShopService, ShopService, ShopServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c7f28ddd1220dda589dc52ee35675cae0(OnBuyItem, cf610d94618b9f7d566b3ae454dc2189f, cbddd1469f329dec33f64f1fd0accd476, c19c97216472918df7449a5e047301b39);
	}

	public void cad34423fd2aee433703096e2c5a63d71(int c0c983470cbce55528681b855c522ac6c, int c68b9fe9faf16aafaf4602ca058560ac2, int c19c97216472918df7449a5e047301b39 = 1)
	{
		OnAccessSingleton<IShopService, ShopService, ShopServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cad34423fd2aee433703096e2c5a63d71(OnSellItem, c0c983470cbce55528681b855c522ac6c, c68b9fe9faf16aafaf4602ca058560ac2, c19c97216472918df7449a5e047301b39);
	}

	private void OnGetShop(Shop shop)
	{
		if (shop == null)
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
					return;
				}
			}
		}
		if (m_shops.ContainsKey(shop.Id))
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
			m_shops[shop.Id] = shop;
		}
		else
		{
			m_shops.Add(shop.Id, shop);
		}
		using (List<IShopServiceNotificationListerner>.Enumerator enumerator = m_notificationListeners.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				IShopServiceNotificationListerner current = enumerator.Current;
				current.OnGetShop(shop);
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	private void OnBuyItem(ItemDNA itemDna)
	{
	}

	private void OnSellItem(int newBondCurrency, ItemDNA soldItem)
	{
		int num = -1;
		int num2 = 0;
		while (true)
		{
			if (num2 < m_soldItemList.Count)
			{
				if (m_soldItemList[num2] == null)
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
					num = num2;
					break;
				}
				num2++;
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
			break;
		}
		ShopItem shopItem = new ShopItem();
		shopItem.Item = soldItem;
		shopItem.Price = newBondCurrency;
		if (num == -1)
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
			m_soldItemList.Add(shopItem);
		}
		else
		{
			m_soldItemList[num] = shopItem;
		}
		using (List<IShopServiceNotificationListerner>.Enumerator enumerator = m_notificationListeners.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				IShopServiceNotificationListerner current = enumerator.Current;
				current.OnSellItem(newBondCurrency);
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

	public void c43edc1499847c0402cc4e606bd144483(int c9526cedaae8a6f13c52592df57f78e6e)
	{
		if (c9526cedaae8a6f13c52592df57f78e6e >= m_soldItemList.Count)
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
			OnAccessSingleton<IShopService, ShopService, ShopServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c5b864eec9f929b1fcd70afbe269e3bd2(OnRedeemItem, 0, c9526cedaae8a6f13c52592df57f78e6e);
			m_soldItemList[c9526cedaae8a6f13c52592df57f78e6e] = null;
			return;
		}
	}

	public void OnRedeemItem(ItemDNA item)
	{
		using (List<IShopServiceNotificationListerner>.Enumerator enumerator = m_notificationListeners.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				IShopServiceNotificationListerner current = enumerator.Current;
				current.OnRedeemItem(item);
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
				return;
			}
		}
	}

	public override bool c39df47367fa21412aabfef05d9972f8c()
	{
		return true;
	}
}
