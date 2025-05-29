using System.Collections.Generic;
using A;
using Core;
using XsdSettings;

public class LuckyBoxManager
{
	protected static LuckyBoxManager _LuckyBoxInstance;

	public bool m_bLuckyBoxOpened;

	public bool m_bLockedLuckyBoxOpened;

	private int m_nOpenIndex;

	private int m_nLockedOpenIndex;

	private List<ItemDNA> m_RewardItems;

	private List<ItemDNA> m_DiamondItems;

	private LuckyBoxManager()
	{
		m_RewardItems = new List<ItemDNA>();
		m_RewardItems.Clear();
		m_DiamondItems = new List<ItemDNA>();
		m_DiamondItems.Clear();
	}

	public static LuckyBoxManager c71f6ce28731edfd43c976fbd57c57bea()
	{
		if (_LuckyBoxInstance == null)
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
			_LuckyBoxInstance = new LuckyBoxManager();
		}
		return _LuckyBoxInstance;
	}

	public void ccd1915f63612800089346222af58f509()
	{
		m_bLuckyBoxOpened = false;
		m_bLockedLuckyBoxOpened = false;
		m_nOpenIndex = 0;
		m_nLockedOpenIndex = 0;
		m_RewardItems.Clear();
		m_DiamondItems.Clear();
	}

	public void cc153f529c9d81cda8397e0213df6f866(int c62a53388af21c9e5e206591a30eb9f80, bool cbd1884b6d3b625a8ec599b0ab246eb01)
	{
		if (cbd1884b6d3b625a8ec599b0ab246eb01)
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
			if (m_bLockedLuckyBoxOpened)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			if (!c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c9f30498b55d5d8ebb2b670dc3a42584b().c6d1a6bc2728f2d802903c307c555a497.ContainsKey(LuckyBoxRank.Diamond))
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
				break;
			}
			if (c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c9f30498b55d5d8ebb2b670dc3a42584b().c6d1a6bc2728f2d802903c307c555a497[LuckyBoxRank.Diamond].Count <= 0)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			m_bLockedLuckyBoxOpened = true;
			m_nLockedOpenIndex = c62a53388af21c9e5e206591a30eb9f80;
		}
		else
		{
			if (m_bLuckyBoxOpened)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			m_bLuckyBoxOpened = true;
			m_nOpenIndex = c62a53388af21c9e5e206591a30eb9f80;
		}
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409() + " open lucky box " + cbd1884b6d3b625a8ec599b0ab246eb01);
		OnAccessSingleton<ILuckyBoxService, LuckyBoxService, LuckyBoxServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cc153f529c9d81cda8397e0213df6f866(OnLuckyBoxOpened, c62a53388af21c9e5e206591a30eb9f80, cbd1884b6d3b625a8ec599b0ab246eb01);
	}

	public void c9ea1e516f59bdd69e72560dbbcf36e29()
	{
		if (m_bLuckyBoxOpened)
		{
			while (true)
			{
				switch (4)
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
		m_bLuckyBoxOpened = true;
		m_nOpenIndex = 2;
		OnAccessSingleton<ILuckyBoxService, LuckyBoxService, LuckyBoxServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cc153f529c9d81cda8397e0213df6f866(OnLuckyBoxOpened, m_nOpenIndex, false);
	}

	public void OnLuckyBoxOpened(bool locked, int index, ItemDNA rewardedItem, ItemDNA dummyItem1, ItemDNA dummyItem2)
	{
		if (!locked)
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
			m_RewardItems.Clear();
			m_bLuckyBoxOpened = true;
		}
		else
		{
			m_DiamondItems.Clear();
			m_bLockedLuckyBoxOpened = true;
		}
		if (rewardedItem == null)
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
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "rewardedItem is null");
		}
		else
		{
			string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(7);
			array[0] = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409();
			array[1] = " get rewardedItem ";
			array[2] = rewardedItem.m_type.ToString();
			array[3] = " itemID:";
			array[4] = rewardedItem.m_itemId.ToString();
			array[5] = " Locked:";
			array[6] = locked.ToString();
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, string.Concat(array));
			if (!locked)
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
				m_RewardItems.Add(rewardedItem);
			}
			else
			{
				m_DiamondItems.Add(rewardedItem);
			}
		}
		if (dummyItem1 == null)
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
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "dummyItem1 is null");
		}
		else
		{
			string[] array2 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(7);
			array2[0] = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409();
			array2[1] = " get dummyItem1 ";
			array2[2] = dummyItem1.m_type.ToString();
			array2[3] = " itemID:";
			array2[4] = dummyItem1.m_itemId.ToString();
			array2[5] = " Locked:";
			array2[6] = locked.ToString();
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, string.Concat(array2));
			if (!locked)
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
				m_RewardItems.Add(dummyItem1);
			}
			else
			{
				m_DiamondItems.Add(dummyItem1);
			}
		}
		if (dummyItem2 == null)
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
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "dummyItem2 is null");
		}
		else
		{
			string[] array3 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(7);
			array3[0] = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409();
			array3[1] = " get dummyItem2 ";
			array3[2] = dummyItem2.m_type.ToString();
			array3[3] = " itemID:";
			array3[4] = dummyItem2.m_itemId.ToString();
			array3[5] = " Locked:";
			array3[6] = locked.ToString();
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, string.Concat(array3));
			if (!locked)
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
				m_RewardItems.Add(dummyItem2);
			}
			else
			{
				m_DiamondItems.Add(dummyItem2);
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTreasureBoxView>().c01a658b50fbe8877dbf1c7e9881dd684(locked);
	}

	public int cf9ca16030e575997356fc88266bdcca7(bool cbd1884b6d3b625a8ec599b0ab246eb01 = false)
	{
		if (!cbd1884b6d3b625a8ec599b0ab246eb01)
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
					return m_nOpenIndex;
				}
			}
		}
		return m_nLockedOpenIndex;
	}

	public int c1b6f1885552cdca583b20160d9e865b8(bool cbd1884b6d3b625a8ec599b0ab246eb01 = false)
	{
		if (!cbd1884b6d3b625a8ec599b0ab246eb01)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return m_RewardItems.Count;
				}
			}
		}
		return m_DiamondItems.Count;
	}

	public ItemDNA c02bc6f816bafc46b05ad6ab3fda2f3b2(bool cbd1884b6d3b625a8ec599b0ab246eb01 = false)
	{
		if (!cbd1884b6d3b625a8ec599b0ab246eb01)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (m_RewardItems.Count == 0)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								return null;
							}
						}
					}
					return m_RewardItems[0];
				}
			}
		}
		if (m_DiamondItems.Count == 0)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return null;
				}
			}
		}
		return m_DiamondItems[0];
	}

	public ItemDNA ca98df7948f1e617dffb496037571e81c(int c5612a459a84ffdb41c885401433cd62d, bool cbd1884b6d3b625a8ec599b0ab246eb01 = false)
	{
		if (!cbd1884b6d3b625a8ec599b0ab246eb01)
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
					if (c5612a459a84ffdb41c885401433cd62d >= 0)
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
						if (c5612a459a84ffdb41c885401433cd62d <= m_RewardItems.Count - 1)
						{
							return m_RewardItems[c5612a459a84ffdb41c885401433cd62d];
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
					}
					return null;
				}
			}
		}
		if (c5612a459a84ffdb41c885401433cd62d >= 0)
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
			if (c5612a459a84ffdb41c885401433cd62d <= m_DiamondItems.Count - 1)
			{
				return m_DiamondItems[c5612a459a84ffdb41c885401433cd62d];
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
		}
		return null;
	}

	public ItemDNA c0b887ca3b7074404bde04f358415edb8(int c5612a459a84ffdb41c885401433cd62d, bool cbd1884b6d3b625a8ec599b0ab246eb01 = false)
	{
		if (!cbd1884b6d3b625a8ec599b0ab246eb01)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (c5612a459a84ffdb41c885401433cd62d >= 0)
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
						if (c5612a459a84ffdb41c885401433cd62d <= m_RewardItems.Count - 1)
						{
							return m_RewardItems[c5612a459a84ffdb41c885401433cd62d];
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
					}
					return null;
				}
			}
		}
		if (c5612a459a84ffdb41c885401433cd62d >= 0)
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
			if (c5612a459a84ffdb41c885401433cd62d <= m_DiamondItems.Count - 1)
			{
				return m_DiamondItems[c5612a459a84ffdb41c885401433cd62d];
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
		}
		return null;
	}
}
