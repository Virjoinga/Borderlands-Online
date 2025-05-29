using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Core;
using XsdSettings;

public class Inventory
{
	private const int MAX_MATERIAL_STACK = 99;

	private Dictionary<int, InventoryItem> mItems = new Dictionary<int, InventoryItem>();

	private Dictionary<int, int> mAmmoCounts = new Dictionary<int, int>();

	private Dictionary<int, int> mMaxAmmoCounts = new Dictionary<int, int>();

	private ItemDNA[] mEquippedWeapons = cd7e95b9c3ab3ea52b4fc74831d35ced6.c0a0cdf4a196914163f7334d9b0781a04(4);

	private ItemDNA mShield;

	private ItemDNA mClassMod;

	private ItemDNA mGrenadeMod;

	private byte mActiveWeapon;

	private byte mNumWeaponSlots = 2;

	private int mCharacterId;

	private int mMaxSlots = 42;

	[CompilerGenerated]
	private static Predicate<InventoryItem> _003C_003Ef__am_0024cacheB;

	[CompilerGenerated]
	private static Func<InventoryItem, ItemRarity> _003C_003Ef__am_0024cacheC;

	[CompilerGenerated]
	private static Func<InventoryItem, InventoryItem> _003C_003Ef__am_0024cacheD;

	public int c53fd283cda80105bc6325451be44376d
	{
		get
		{
			return mItems.Count;
		}
	}

	public Inventory(Hashtable c28cf3d24e3067ef54895f824fad7fcef)
	{
		mCharacterId = (int)c28cf3d24e3067ef54895f824fad7fcef[0];
		mNumWeaponSlots = (byte)c28cf3d24e3067ef54895f824fad7fcef[1];
		mActiveWeapon = (byte)c28cf3d24e3067ef54895f824fad7fcef[2];
		Hashtable hashtable = (Hashtable)c28cf3d24e3067ef54895f824fad7fcef[3];
		for (int i = 0; i < 4; i++)
		{
			if (!hashtable.ContainsKey(i))
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
			if (hashtable[i] == null)
			{
				continue;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			if (hashtable[i].GetType() == Type.GetTypeFromHandle(cdbba4b5ff80b1b98d2ace589ed53ef50.cc1720d05c75832f704b87474932341c3()))
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
				mEquippedWeapons[i] = ItemDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2((Hashtable)hashtable[i]);
			}
			else
			{
				mEquippedWeapons[i] = (ItemDNA)hashtable[i];
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			Hashtable hashtable2 = (Hashtable)c28cf3d24e3067ef54895f824fad7fcef[4];
			mAmmoCounts[4] = (int)hashtable2[0];
			mMaxAmmoCounts[4] = (int)hashtable2[1];
			Hashtable hashtable3 = (Hashtable)c28cf3d24e3067ef54895f824fad7fcef[5];
			mAmmoCounts[0] = (int)hashtable3[0];
			mMaxAmmoCounts[0] = (int)hashtable3[1];
			Hashtable hashtable4 = (Hashtable)c28cf3d24e3067ef54895f824fad7fcef[6];
			mAmmoCounts[3] = (int)hashtable4[0];
			mMaxAmmoCounts[3] = (int)hashtable4[1];
			Hashtable hashtable5 = (Hashtable)c28cf3d24e3067ef54895f824fad7fcef[7];
			mAmmoCounts[1] = (int)hashtable5[0];
			mMaxAmmoCounts[1] = (int)hashtable5[1];
			Hashtable hashtable6 = (Hashtable)c28cf3d24e3067ef54895f824fad7fcef[8];
			mAmmoCounts[2] = (int)hashtable6[0];
			mMaxAmmoCounts[2] = (int)hashtable6[1];
			Hashtable hashtable7 = (Hashtable)c28cf3d24e3067ef54895f824fad7fcef[12];
			mAmmoCounts[5] = (int)hashtable7[0];
			mMaxAmmoCounts[5] = (int)hashtable7[1];
			mMaxSlots = (int)c28cf3d24e3067ef54895f824fad7fcef[9];
			Hashtable hashtable8 = (Hashtable)c28cf3d24e3067ef54895f824fad7fcef[10];
			IDictionaryEnumerator enumerator = hashtable8.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
					int key = (int)dictionaryEntry.Key;
					Hashtable hashtable9 = (Hashtable)dictionaryEntry.Value;
					if (hashtable9 == null)
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
					}
					else
					{
						mItems[key] = new InventoryItem(hashtable9);
					}
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_0402;
					}
					continue;
					end_IL_0402:
					break;
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable == null)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							goto end_IL_041b;
						}
						continue;
						end_IL_041b:
						break;
					}
				}
				else
				{
					disposable.Dispose();
				}
			}
			if (c28cf3d24e3067ef54895f824fad7fcef[11] != null)
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
				mShield = ItemDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2((Hashtable)c28cf3d24e3067ef54895f824fad7fcef[11]);
			}
			if (c28cf3d24e3067ef54895f824fad7fcef[13] != null)
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
				mClassMod = ItemDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2((Hashtable)c28cf3d24e3067ef54895f824fad7fcef[13]);
			}
			if (c28cf3d24e3067ef54895f824fad7fcef[14] != null)
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
			}
			OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c7d08ed02a7697465eaaf348e5256df6d(OnNewInventory);
			return;
		}
	}

	public ItemDNA c48db535623c3c5d4028ae3a36cb12dc6(int c872943035f78644fd01b267deff00547)
	{
		if (mItems.ContainsKey(c872943035f78644fd01b267deff00547))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return mItems[c872943035f78644fd01b267deff00547].mItem;
				}
			}
		}
		return null;
	}

	public ItemDNA c4e0dae6a16a8a80ddb5214a896b9df58(byte c872943035f78644fd01b267deff00547)
	{
		if (c872943035f78644fd01b267deff00547 < mNumWeaponSlots)
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
					return mEquippedWeapons[c872943035f78644fd01b267deff00547];
				}
			}
		}
		return null;
	}

	public ItemDNA c3941dac8608f650ceb15dc36294a741c()
	{
		return mEquippedWeapons[mActiveWeapon];
	}

	public byte c91233b4b8268e8e24a4daa8c053e41ec()
	{
		return mActiveWeapon;
	}

	public int c5ddb5f74d1f3e3c06409d657ed5eb7a1(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b)
	{
		if (mAmmoCounts != null)
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
			if (mAmmoCounts.ContainsKey((int)c1e73ae4c18ab95639cb0c7604f21dc2b))
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return mAmmoCounts[(int)c1e73ae4c18ab95639cb0c7604f21dc2b];
					}
				}
			}
		}
		return 0;
	}

	public int cd164b9ec3a9d0fc37e11d7fd46792ef2(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b)
	{
		if (mMaxAmmoCounts != null)
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
			if (mMaxAmmoCounts.ContainsKey((int)c1e73ae4c18ab95639cb0c7604f21dc2b))
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return mMaxAmmoCounts[(int)c1e73ae4c18ab95639cb0c7604f21dc2b];
					}
				}
			}
		}
		return 0;
	}

	public void cc62b4b3e79f635a94d84949382bba1fc(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
		if (c42a8a9b0dd4206315a44f945fbf7331f == c5242449e40eab9ce5011e2bacd82070c)
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
					return;
				}
			}
		}
		InventoryItem value;
		mItems.TryGetValue(c42a8a9b0dd4206315a44f945fbf7331f, out value);
		InventoryItem value2;
		mItems.TryGetValue(c5242449e40eab9ce5011e2bacd82070c, out value2);
		if (value != null)
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
			mItems[c5242449e40eab9ce5011e2bacd82070c] = value;
		}
		else
		{
			mItems.Remove(c5242449e40eab9ce5011e2bacd82070c);
		}
		if (value2 != null)
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
			mItems[c42a8a9b0dd4206315a44f945fbf7331f] = value2;
		}
		else
		{
			mItems.Remove(c42a8a9b0dd4206315a44f945fbf7331f);
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c42a8a9b0dd4206315a44f945fbf7331f;
		array[1] = c5242449e40eab9ce5011e2bacd82070c;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(195, array);
		c02bf5d9a6910c3bc3097781800ce84b8(InventoryAction.SwapItems, c42a8a9b0dd4206315a44f945fbf7331f, c5242449e40eab9ce5011e2bacd82070c);
	}

	public void ccfdbed5cc5051e9ffb25bea212f7ddc6(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
		if (c42a8a9b0dd4206315a44f945fbf7331f == c5242449e40eab9ce5011e2bacd82070c)
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
					return;
				}
			}
		}
		ItemDNA itemDNA = mEquippedWeapons[c42a8a9b0dd4206315a44f945fbf7331f];
		ItemDNA itemDNA2 = mEquippedWeapons[c5242449e40eab9ce5011e2bacd82070c];
		mEquippedWeapons[c42a8a9b0dd4206315a44f945fbf7331f] = itemDNA2;
		mEquippedWeapons[c5242449e40eab9ce5011e2bacd82070c] = itemDNA;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c42a8a9b0dd4206315a44f945fbf7331f;
		array[1] = c5242449e40eab9ce5011e2bacd82070c;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(166, array);
		c02bf5d9a6910c3bc3097781800ce84b8(InventoryAction.SwapWeapons, c42a8a9b0dd4206315a44f945fbf7331f, c5242449e40eab9ce5011e2bacd82070c);
	}

	public void cccb56495987b6a4ebab7b225fb1af261(byte c793014f9fd028450a4a9908376309f26)
	{
		mItems.Remove(c793014f9fd028450a4a9908376309f26);
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c793014f9fd028450a4a9908376309f26;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(193, array);
		c02bf5d9a6910c3bc3097781800ce84b8(InventoryAction.DropItem, c793014f9fd028450a4a9908376309f26);
	}

	public void cabac189d699c8d8d56d0e1a68cd1440b(byte cd27037dd3bf1006e6e39ebf89cbd7b03, byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		if (cd27037dd3bf1006e6e39ebf89cbd7b03 >= mMaxSlots)
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
			if (c19a39247ea86ffe5f0de9d429ca0ca95 >= mNumWeaponSlots)
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
			ItemDNA itemDNA = c48db535623c3c5d4028ae3a36cb12dc6(cd27037dd3bf1006e6e39ebf89cbd7b03);
			if (mEquippedWeapons[c19a39247ea86ffe5f0de9d429ca0ca95] == null)
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
				mItems.Remove(cd27037dd3bf1006e6e39ebf89cbd7b03);
			}
			else
			{
				mItems[cd27037dd3bf1006e6e39ebf89cbd7b03] = new InventoryItem
				{
					mItem = mEquippedWeapons[c19a39247ea86ffe5f0de9d429ca0ca95]
				};
			}
			mEquippedWeapons[c19a39247ea86ffe5f0de9d429ca0ca95] = itemDNA;
			OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
			array[0] = cd27037dd3bf1006e6e39ebf89cbd7b03;
			array[1] = c19a39247ea86ffe5f0de9d429ca0ca95;
			onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(192, array);
			c02bf5d9a6910c3bc3097781800ce84b8(InventoryAction.EquipWeapon, cd27037dd3bf1006e6e39ebf89cbd7b03, c19a39247ea86ffe5f0de9d429ca0ca95);
			return;
		}
	}

	public void c89361444df98c6f8354125e8bdb18882(byte c19a39247ea86ffe5f0de9d429ca0ca95, byte cd27037dd3bf1006e6e39ebf89cbd7b03)
	{
		if (c19a39247ea86ffe5f0de9d429ca0ca95 == mActiveWeapon)
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
			if (c19a39247ea86ffe5f0de9d429ca0ca95 >= mNumWeaponSlots)
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
				if (cd27037dd3bf1006e6e39ebf89cbd7b03 >= mMaxSlots)
				{
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
				if (mEquippedWeapons[c19a39247ea86ffe5f0de9d429ca0ca95] != null)
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
					mItems[cd27037dd3bf1006e6e39ebf89cbd7b03] = new InventoryItem
					{
						mItem = mEquippedWeapons[c19a39247ea86ffe5f0de9d429ca0ca95]
					};
					mEquippedWeapons[c19a39247ea86ffe5f0de9d429ca0ca95] = null;
					OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
					object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
					array[0] = c19a39247ea86ffe5f0de9d429ca0ca95;
					array[1] = cd27037dd3bf1006e6e39ebf89cbd7b03;
					onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(191, array);
				}
				c02bf5d9a6910c3bc3097781800ce84b8(InventoryAction.UnequipWeapon, c19a39247ea86ffe5f0de9d429ca0ca95);
				return;
			}
		}
	}

	public void c89361444df98c6f8354125e8bdb18882(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		if (c19a39247ea86ffe5f0de9d429ca0ca95 == mActiveWeapon)
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
			if (c19a39247ea86ffe5f0de9d429ca0ca95 >= mNumWeaponSlots)
			{
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
			for (int i = 0; i < mMaxSlots; i++)
			{
				if (mItems.ContainsKey(i))
				{
					continue;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				c89361444df98c6f8354125e8bdb18882(c19a39247ea86ffe5f0de9d429ca0ca95, (byte)i);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	public void cb71c24b68b65fe176d7936520d63a102(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		if (c19a39247ea86ffe5f0de9d429ca0ca95 >= mNumWeaponSlots)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Default, string.Format("Set Active Weapon {0} - Invalid index", c19a39247ea86ffe5f0de9d429ca0ca95));
					return;
				}
			}
		}
		if (mEquippedWeapons[c19a39247ea86ffe5f0de9d429ca0ca95] == null)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Default, string.Format("Set Active Weapon {0} - No weapon in slot", c19a39247ea86ffe5f0de9d429ca0ca95));
					return;
				}
			}
		}
		mActiveWeapon = c19a39247ea86ffe5f0de9d429ca0ca95;
		c02bf5d9a6910c3bc3097781800ce84b8(InventoryAction.SetActiveWeapon, c19a39247ea86ffe5f0de9d429ca0ca95);
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c19a39247ea86ffe5f0de9d429ca0ca95;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(190, array);
	}

	private void OnNewInventory(Inventory inventory)
	{
		if (inventory.mCharacterId != mCharacterId)
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
			mItems = inventory.mItems;
			mEquippedWeapons = inventory.mEquippedWeapons;
			mShield = inventory.mShield;
			mClassMod = inventory.mClassMod;
			mActiveWeapon = inventory.mActiveWeapon;
			mNumWeaponSlots = inventory.mNumWeaponSlots;
			mAmmoCounts = inventory.mAmmoCounts;
			mMaxAmmoCounts = inventory.mMaxAmmoCounts;
			mMaxSlots = inventory.mMaxSlots;
			return;
		}
	}

	public void c2c88f58e2567403c799587ade8434690(int c793014f9fd028450a4a9908376309f26, ItemDNA ca57e1c076c01141c5ce58c7341db7833, int c9b15165c908ac1f9e9396c57137d3a67 = 1)
	{
		if (!mItems.ContainsKey(c793014f9fd028450a4a9908376309f26))
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					mItems[c793014f9fd028450a4a9908376309f26] = new InventoryItem
					{
						mItem = ca57e1c076c01141c5ce58c7341db7833
					};
					return;
				}
			}
		}
		if (ca57e1c076c01141c5ce58c7341db7833.m_type == ItemType.Weapon)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					throw new Exception(string.Format("Can't add {0} items to slot {1} - already has item.", c9b15165c908ac1f9e9396c57137d3a67, c793014f9fd028450a4a9908376309f26));
				}
			}
		}
		if (ca57e1c076c01141c5ce58c7341db7833.m_type == ItemType.Material)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (mItems[c793014f9fd028450a4a9908376309f26].mItem.m_materialType != ca57e1c076c01141c5ce58c7341db7833.m_materialType)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								throw new Exception(string.Format("Can't stack {0} items in slot {1} - types do not match.", c9b15165c908ac1f9e9396c57137d3a67, c793014f9fd028450a4a9908376309f26));
							}
						}
					}
					if (mItems[c793014f9fd028450a4a9908376309f26].c9a57a1c6eac92cceec2de50aa04e4757 + c9b15165c908ac1f9e9396c57137d3a67 <= 99)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								mItems[c793014f9fd028450a4a9908376309f26].c9a57a1c6eac92cceec2de50aa04e4757 += c9b15165c908ac1f9e9396c57137d3a67;
								return;
							}
						}
					}
					throw new Exception(string.Format("Can't add {0} items to slot {1} [{2}]- stack is full.", c9b15165c908ac1f9e9396c57137d3a67, c793014f9fd028450a4a9908376309f26, mItems[c793014f9fd028450a4a9908376309f26].c9a57a1c6eac92cceec2de50aa04e4757));
				}
			}
		}
		throw new Exception(string.Format("Unsupported item type ({0}).", ca57e1c076c01141c5ce58c7341db7833.m_type));
	}

	public void c42841eb15edb296c94c38f237f57d3dd(ItemDNA ca57e1c076c01141c5ce58c7341db7833, byte cffaf6142283f4f4e6fddf855bae4597e)
	{
		mEquippedWeapons[cffaf6142283f4f4e6fddf855bae4597e] = ca57e1c076c01141c5ce58c7341db7833;
	}

	public void cd881bce8c275328b4429276a57a0175e(Dictionary<int, int> c9ce1c28bef8a1d03500a302b2e3a3ac5)
	{
		mAmmoCounts = c9ce1c28bef8a1d03500a302b2e3a3ac5;
	}

	public ItemDNA c86b944a82d70502ff9ec6c7d1fa5f420()
	{
		return mClassMod;
	}

	public void c2bf177eafbfeb7beaa0bfd04facb2029(ItemDNA c4ed717bfa8e3dbe7b0f04513d76a651e)
	{
		mClassMod = c4ed717bfa8e3dbe7b0f04513d76a651e;
	}

	public ItemDNA cec5e771a298fe1e51f84e4ec6dcb5165()
	{
		return mShield;
	}

	public void c61f40925cf99c31aa9ac5df098110ada(ItemDNA c4ed717bfa8e3dbe7b0f04513d76a651e)
	{
		mShield = c4ed717bfa8e3dbe7b0f04513d76a651e;
	}

	public void c61f40925cf99c31aa9ac5df098110ada(byte cd27037dd3bf1006e6e39ebf89cbd7b03)
	{
		if (cd27037dd3bf1006e6e39ebf89cbd7b03 >= mMaxSlots)
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
					return;
				}
			}
		}
		ItemDNA itemDNA = c48db535623c3c5d4028ae3a36cb12dc6(cd27037dd3bf1006e6e39ebf89cbd7b03);
		if (mShield == null)
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
			mItems.Remove(cd27037dd3bf1006e6e39ebf89cbd7b03);
		}
		else
		{
			mItems[cd27037dd3bf1006e6e39ebf89cbd7b03] = new InventoryItem
			{
				mItem = mShield
			};
		}
		mShield = itemDNA;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = cd27037dd3bf1006e6e39ebf89cbd7b03;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(135, array);
		c02bf5d9a6910c3bc3097781800ce84b8(InventoryAction.EquipShield, cd27037dd3bf1006e6e39ebf89cbd7b03);
	}

	public void c93f9efad286d9cb79c339b238fee8953(byte cd27037dd3bf1006e6e39ebf89cbd7b03)
	{
		c8bd71a55c46846de17877d69bbae8bc3(cd27037dd3bf1006e6e39ebf89cbd7b03);
	}

	public void c8bd71a55c46846de17877d69bbae8bc3(byte cd27037dd3bf1006e6e39ebf89cbd7b03)
	{
		if (cd27037dd3bf1006e6e39ebf89cbd7b03 >= mMaxSlots)
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
		ItemDNA itemDNA = c48db535623c3c5d4028ae3a36cb12dc6(cd27037dd3bf1006e6e39ebf89cbd7b03);
		if (mClassMod == null)
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
			mItems.Remove(cd27037dd3bf1006e6e39ebf89cbd7b03);
		}
		else
		{
			mItems[cd27037dd3bf1006e6e39ebf89cbd7b03] = new InventoryItem
			{
				mItem = mClassMod
			};
		}
		mClassMod = itemDNA;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = cd27037dd3bf1006e6e39ebf89cbd7b03;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(86, array);
		c02bf5d9a6910c3bc3097781800ce84b8(InventoryAction.EquipClassMod, cd27037dd3bf1006e6e39ebf89cbd7b03);
	}

	public void c40a874384e547c8faa67b46f42047ff7(int cae5fea398599f41bfafc9b6bb6f4559b, int c6cb66aa8544c442eb14b92180640f843, int c9b15165c908ac1f9e9396c57137d3a67)
	{
		if (!mItems.ContainsKey(cae5fea398599f41bfafc9b6bb6f4559b))
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
		if (mItems.ContainsKey(c6cb66aa8544c442eb14b92180640f843))
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
		if (mItems[cae5fea398599f41bfafc9b6bb6f4559b].mItem.m_type != ItemType.Material)
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
		if (mItems[cae5fea398599f41bfafc9b6bb6f4559b].c9a57a1c6eac92cceec2de50aa04e4757 <= c9b15165c908ac1f9e9396c57137d3a67)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		mItems[cae5fea398599f41bfafc9b6bb6f4559b].c9a57a1c6eac92cceec2de50aa04e4757 -= c9b15165c908ac1f9e9396c57137d3a67;
		mItems[c6cb66aa8544c442eb14b92180640f843] = new InventoryItem
		{
			mItem = ItemDNA.c172f9d0eb2874d9d30bb9354caf9aab4(mItems[cae5fea398599f41bfafc9b6bb6f4559b].mItem.m_materialType, c9b15165c908ac1f9e9396c57137d3a67)
		};
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(3);
		array[0] = cae5fea398599f41bfafc9b6bb6f4559b;
		array[1] = c6cb66aa8544c442eb14b92180640f843;
		array[2] = c9b15165c908ac1f9e9396c57137d3a67;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(90, array);
	}

	public void cc4e9512abe46fc5b35caaac8d7081425(int cae5fea398599f41bfafc9b6bb6f4559b, int c6cb66aa8544c442eb14b92180640f843)
	{
		if (!mItems.ContainsKey(cae5fea398599f41bfafc9b6bb6f4559b))
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
		if (!mItems.ContainsKey(c6cb66aa8544c442eb14b92180640f843))
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
		if (mItems[cae5fea398599f41bfafc9b6bb6f4559b].mItem.m_type != ItemType.Material)
		{
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
		if (mItems[c6cb66aa8544c442eb14b92180640f843].mItem.m_type != ItemType.Material)
		{
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
		if (mItems[cae5fea398599f41bfafc9b6bb6f4559b].mItem.m_materialType != mItems[c6cb66aa8544c442eb14b92180640f843].mItem.m_materialType)
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
		int num = mItems[cae5fea398599f41bfafc9b6bb6f4559b].c9a57a1c6eac92cceec2de50aa04e4757 + mItems[c6cb66aa8544c442eb14b92180640f843].c9a57a1c6eac92cceec2de50aa04e4757;
		if (num > 99)
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
			mItems[c6cb66aa8544c442eb14b92180640f843] = new InventoryItem
			{
				mItem = ItemDNA.c172f9d0eb2874d9d30bb9354caf9aab4(mItems[cae5fea398599f41bfafc9b6bb6f4559b].mItem.m_materialType, 99)
			};
			mItems[cae5fea398599f41bfafc9b6bb6f4559b] = new InventoryItem
			{
				mItem = ItemDNA.c172f9d0eb2874d9d30bb9354caf9aab4(mItems[cae5fea398599f41bfafc9b6bb6f4559b].mItem.m_materialType, num - 99)
			};
		}
		else
		{
			mItems[c6cb66aa8544c442eb14b92180640f843] = new InventoryItem
			{
				mItem = ItemDNA.c172f9d0eb2874d9d30bb9354caf9aab4(mItems[cae5fea398599f41bfafc9b6bb6f4559b].mItem.m_materialType, 99)
			};
			mItems.Remove(cae5fea398599f41bfafc9b6bb6f4559b);
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = cae5fea398599f41bfafc9b6bb6f4559b;
		array[1] = c6cb66aa8544c442eb14b92180640f843;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(89, array);
	}

	public void c54c1af8457b3ce0cf22e161f5eb65749()
	{
		int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(13);
		for (MaterialType materialType = MaterialType.MT_Titanium; materialType < MaterialType.TOTAL; materialType++)
		{
			array[(int)materialType] = cdff08bd623e04fdde40092784eebdeec(materialType);
		}
		List<InventoryItem> items;
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
			items = new List<InventoryItem>(mItems.Values);
			List<InventoryItem> list = items;
			if (_003C_003Ef__am_0024cacheB == null)
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
				_003C_003Ef__am_0024cacheB = (InventoryItem c5ebdc65d5cb420faf7ba524809963aa9) => c5ebdc65d5cb420faf7ba524809963aa9.mItem.m_type == ItemType.Material;
			}
			list.RemoveAll(_003C_003Ef__am_0024cacheB);
			List<InventoryItem> source = items;
			if (_003C_003Ef__am_0024cacheC == null)
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
				_003C_003Ef__am_0024cacheC = (InventoryItem c5ebdc65d5cb420faf7ba524809963aa9) => c5ebdc65d5cb420faf7ba524809963aa9.mItem.cdb37a58b3efd54adcd5545eac569695f;
			}
			source.OrderByDescending(_003C_003Ef__am_0024cacheC);
			items.OrderBy((InventoryItem c5ebdc65d5cb420faf7ba524809963aa9) => c53ca43bfd040d91ed4eb442367f72f82(c5ebdc65d5cb420faf7ba524809963aa9.mItem.m_type));
			for (MaterialType materialType2 = MaterialType.MT_Titanium; materialType2 < MaterialType.TOTAL; materialType2++)
			{
				for (int num = array[(int)materialType2]; num > 99; num -= 99)
				{
					items.Add(new InventoryItem
					{
						mItem = ItemDNA.c172f9d0eb2874d9d30bb9354caf9aab4(materialType2, 99)
					});
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						goto end_IL_0120;
					}
					continue;
					end_IL_0120:
					break;
				}
				items.Add(new InventoryItem
				{
					mItem = ItemDNA.c172f9d0eb2874d9d30bb9354caf9aab4(materialType2, 99)
				});
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				List<InventoryItem> source2 = items;
				Func<InventoryItem, int> keySelector = (InventoryItem c5ebdc65d5cb420faf7ba524809963aa9) => items.IndexOf(c5ebdc65d5cb420faf7ba524809963aa9);
				if (_003C_003Ef__am_0024cacheD == null)
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
					_003C_003Ef__am_0024cacheD = (InventoryItem c5ebdc65d5cb420faf7ba524809963aa9) => c5ebdc65d5cb420faf7ba524809963aa9;
				}
				mItems = source2.ToDictionary(keySelector, _003C_003Ef__am_0024cacheD);
				PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(88, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
				return;
			}
		}
	}

	private int cdff08bd623e04fdde40092784eebdeec(MaterialType c424fafa6354141c1e81d53efca575d8d)
	{
		int num = 0;
		using (Dictionary<int, InventoryItem>.ValueCollection.Enumerator enumerator = mItems.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				InventoryItem current = enumerator.Current;
				if (current.mItem.m_type != ItemType.Material)
				{
					continue;
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (current.mItem.m_materialType != c424fafa6354141c1e81d53efca575d8d)
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
				num += current.c9a57a1c6eac92cceec2de50aa04e4757;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				return num;
			}
		}
	}

	private int c53ca43bfd040d91ed4eb442367f72f82(ItemType c6ca7698352db776b80b27b30e89ff904)
	{
		switch (c6ca7698352db776b80b27b30e89ff904)
		{
		default:
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
				return 99;
			}
		case ItemType.Weapon:
			return 0;
		case ItemType.Shield:
			return 1;
		case ItemType.ClassMode:
			return 2;
		}
	}

	public void cc1f64da14ce8bcd8b39fb52b32596f42(byte cd27037dd3bf1006e6e39ebf89cbd7b03)
	{
		c61f40925cf99c31aa9ac5df098110ada(cd27037dd3bf1006e6e39ebf89cbd7b03);
	}

	public void cc1f64da14ce8bcd8b39fb52b32596f42()
	{
		for (int i = 0; i < mMaxSlots; i++)
		{
			if (mItems.ContainsKey(i))
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
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			cc1f64da14ce8bcd8b39fb52b32596f42((byte)i);
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public void c02bf5d9a6910c3bc3097781800ce84b8(InventoryAction c861de212c63da4e42109937e3cac1a44, byte cae5fea398599f41bfafc9b6bb6f4559b, byte c6cb66aa8544c442eb14b92180640f843 = 0)
	{
		if (null == c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86)
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
					return;
				}
			}
		}
		if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_offlineMode)
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
			(OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86 as InventoryServiceOffline).OnInventoryModification(this);
			return;
		}
	}

	public Hashtable c2785337dcd6da152ea623eabc85b6d49()
	{
		Hashtable hashtable = new Hashtable();
		using (Dictionary<int, InventoryItem>.Enumerator enumerator = mItems.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, InventoryItem> current = enumerator.Current;
				if (current.Value == null)
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
					break;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				Hashtable value = current.Value.mItem.c2785337dcd6da152ea623eabc85b6d49();
				hashtable[current.Key] = value;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_0074;
				}
				continue;
				end_IL_0074:
				break;
			}
		}
		Hashtable hashtable2 = new Hashtable();
		for (int i = 0; i < 4; i++)
		{
			if (mEquippedWeapons[i] == null)
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
				hashtable2[i] = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			}
			else
			{
				hashtable2[i] = mEquippedWeapons[i].c2785337dcd6da152ea623eabc85b6d49();
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			object value2 = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			if (mShield != null)
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
				value2 = mShield.c2785337dcd6da152ea623eabc85b6d49();
			}
			object value3 = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			if (mClassMod != null)
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
				value3 = mClassMod.c2785337dcd6da152ea623eabc85b6d49();
			}
			Hashtable hashtable3 = new Hashtable();
			hashtable3.Add(0, mCharacterId);
			hashtable3.Add(1, mNumWeaponSlots);
			hashtable3.Add(2, mActiveWeapon);
			hashtable3.Add(3, hashtable2);
			hashtable3.Add(4, new Hashtable
			{
				{
					0,
					mAmmoCounts[4]
				},
				{
					1,
					mMaxAmmoCounts[4]
				}
			});
			hashtable3.Add(5, new Hashtable
			{
				{
					0,
					mAmmoCounts[0]
				},
				{
					1,
					mMaxAmmoCounts[0]
				}
			});
			hashtable3.Add(6, new Hashtable
			{
				{
					0,
					mAmmoCounts[3]
				},
				{
					1,
					mMaxAmmoCounts[3]
				}
			});
			hashtable3.Add(7, new Hashtable
			{
				{
					0,
					mAmmoCounts[1]
				},
				{
					1,
					mMaxAmmoCounts[1]
				}
			});
			hashtable3.Add(8, new Hashtable
			{
				{
					0,
					mAmmoCounts[2]
				},
				{
					1,
					mMaxAmmoCounts[2]
				}
			});
			hashtable3.Add(12, new Hashtable
			{
				{
					0,
					mAmmoCounts[5]
				},
				{
					1,
					mMaxAmmoCounts[5]
				}
			});
			hashtable3.Add(9, mMaxSlots);
			hashtable3.Add(10, hashtable);
			hashtable3.Add(11, value2);
			hashtable3.Add(13, value3);
			hashtable3.Add(14, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
			return hashtable3;
		}
	}

	public bool c3ac9dbf338103e5bc87b5c2d6acf117a()
	{
		bool result = true;
		int num = 0;
		while (true)
		{
			if (num < mMaxSlots)
			{
				if (!mItems.ContainsKey(num))
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
					result = false;
					break;
				}
				num++;
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
			break;
		}
		return result;
	}

	public int c5bca3d5ccc1b3ed0b9472295fb3f6c73()
	{
		return mMaxSlots;
	}

	[CompilerGenerated]
	private static bool cf3bcfadc77671eb5fd5910a36fe73cea(InventoryItem c5ebdc65d5cb420faf7ba524809963aa9)
	{
		return c5ebdc65d5cb420faf7ba524809963aa9.mItem.m_type == ItemType.Material;
	}

	[CompilerGenerated]
	private static ItemRarity c1e58d6d4cc035e3e428aa33bdf65d55b(InventoryItem c5ebdc65d5cb420faf7ba524809963aa9)
	{
		return c5ebdc65d5cb420faf7ba524809963aa9.mItem.cdb37a58b3efd54adcd5545eac569695f;
	}

	[CompilerGenerated]
	private static InventoryItem cf25ee0b7740666ae622eb039254c4482(InventoryItem c5ebdc65d5cb420faf7ba524809963aa9)
	{
		return c5ebdc65d5cb420faf7ba524809963aa9;
	}
}
