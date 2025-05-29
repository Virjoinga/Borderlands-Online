using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using XsdSettings;

public class InventoryService : OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>, IInventoryService
{
	public enum UpdateEventType
	{
		AddItemsToInventory = 0,
		EquipNewWeapon = 1,
		UpdateAmmo = 2
	}

	private List<ItemRewardCallback> mItemRewardCallbacks = new List<ItemRewardCallback>();

	private List<InventoryCallback> mInventoryCallbacks;

	private Dictionary<int, Inventory> mInventories;

	private List<GetInventoryCallback> mGetInventoryCallbacks = new List<GetInventoryCallback>();

	private List<WarehouseCallback> mWarehouseCallbacks = new List<WarehouseCallback>();

	private Warehouse mWarehouse;

	public InventoryService()
	{
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(196, OnNewInventory);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(88, OnNewInventory);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(222, OnServerInventoryUpdate);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(99, OnNewWarehouse);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(168, OnServerWarehouseUpdate);
		PhotonNetwork.networkingPeer.c89f9569b4330d0286992724cb1480f55(222, OnInventoryUpdated);
		PhotonNetwork.networkingPeer.c89f9569b4330d0286992724cb1480f55(221, OnInventoryAction);
		mInventories = new Dictionary<int, Inventory>();
		mInventoryCallbacks = new List<InventoryCallback>();
	}

	public void c234b6e5b8ed8e7dc06b7d1ec110c895d(int c5dfde30d8784694fb9999709d290e6c4)
	{
		mInventories.Remove(c5dfde30d8784694fb9999709d290e6c4);
	}

	public Inventory c844f1a916a01fdb8a6a6e640d1811cf2(int c5dfde30d8784694fb9999709d290e6c4, GetInventoryCallback c2db84530ef366a6deb001d449d4aa151 = null)
	{
		if (!mInventories.ContainsKey(c5dfde30d8784694fb9999709d290e6c4))
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
						mGetInventoryCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
					}
					cd2ff2d0b9710155a2e44c955d431a48d(c5dfde30d8784694fb9999709d290e6c4);
					return null;
				}
			}
		}
		Inventory inventory = mInventories[c5dfde30d8784694fb9999709d290e6c4];
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
			c2db84530ef366a6deb001d449d4aa151(c5dfde30d8784694fb9999709d290e6c4, inventory);
		}
		return inventory;
	}

	public void cd2ff2d0b9710155a2e44c955d431a48d(int c5dfde30d8784694fb9999709d290e6c4)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(196, array);
	}

	public void c7d08ed02a7697465eaaf348e5256df6d(InventoryCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mInventoryCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c0e99b4914f8c6b80f6233d720bf3d53f(InventoryCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mInventoryCallbacks.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnNewInventory(short operationResponse, Dictionary<byte, object> parameters)
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
			c3d3a580647c12bd3016d6bf60edaf16c((Hashtable)parameters[0]);
			return;
		}
	}

	private void ca9ccd8d9ca797ff77e45b9be166a21d2(int c5dfde30d8784694fb9999709d290e6c4, ItemType c2b4f43f34e21572af6ab4414f04cee36, int c35f98ccbfa8c6bf09319c620b21b5dc5, int c9b15165c908ac1f9e9396c57137d3a67 = 1)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		array[1] = (int)c2b4f43f34e21572af6ab4414f04cee36;
		array[2] = c35f98ccbfa8c6bf09319c620b21b5dc5;
		array[3] = c9b15165c908ac1f9e9396c57137d3a67;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(194, array);
	}

	public void c42841eb15edb296c94c38f237f57d3dd(int c5dfde30d8784694fb9999709d290e6c4, ItemDNA ca57e1c076c01141c5ce58c7341db7833, byte cffaf6142283f4f4e6fddf855bae4597e)
	{
		Inventory inventory = c844f1a916a01fdb8a6a6e640d1811cf2(c5dfde30d8784694fb9999709d290e6c4, cb8d3896b4fab7d0390a49fc34789c675.c7088de59e49f7108f520cf7e0bae167e);
		if (inventory == null)
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
			inventory.c42841eb15edb296c94c38f237f57d3dd(ca57e1c076c01141c5ce58c7341db7833, cffaf6142283f4f4e6fddf855bae4597e);
			c79354dda0fa3e924320b38248ca2900a(c5dfde30d8784694fb9999709d290e6c4, UpdateEventType.EquipNewWeapon, new Hashtable { 
			{
				cffaf6142283f4f4e6fddf855bae4597e,
				ca57e1c076c01141c5ce58c7341db7833.c2785337dcd6da152ea623eabc85b6d49()
			} });
			return;
		}
	}

	public void cd881bce8c275328b4429276a57a0175e(int c5dfde30d8784694fb9999709d290e6c4, Dictionary<int, int> c9ce1c28bef8a1d03500a302b2e3a3ac5)
	{
		Inventory inventory = c844f1a916a01fdb8a6a6e640d1811cf2(c5dfde30d8784694fb9999709d290e6c4, cb8d3896b4fab7d0390a49fc34789c675.c7088de59e49f7108f520cf7e0bae167e);
		if (inventory == null)
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
			inventory.cd881bce8c275328b4429276a57a0175e(c9ce1c28bef8a1d03500a302b2e3a3ac5);
			c79354dda0fa3e924320b38248ca2900a(c5dfde30d8784694fb9999709d290e6c4, UpdateEventType.UpdateAmmo, c9ce1c28bef8a1d03500a302b2e3a3ac5);
			return;
		}
	}

	public void c52d5efe740f1c586cada86a418a5bfdd(int c5dfde30d8784694fb9999709d290e6c4)
	{
		try
		{
			Inventory inventory = c844f1a916a01fdb8a6a6e640d1811cf2(c5dfde30d8784694fb9999709d290e6c4, cb8d3896b4fab7d0390a49fc34789c675.c7088de59e49f7108f520cf7e0bae167e);
			if (inventory == null)
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
				OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = inventory.c2785337dcd6da152ea623eabc85b6d49();
				onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(177, array);
				return;
			}
		}
		catch (Exception ex)
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Format("Failed to update inventory for character {0} with error {1}", c5dfde30d8784694fb9999709d290e6c4, ex.Message));
		}
	}

	public void c79354dda0fa3e924320b38248ca2900a(int c5dfde30d8784694fb9999709d290e6c4, UpdateEventType cf1e37eb6d0553f653c2bc1306ea76d36, object c591d56a94543e3559945c497f37126c4)
	{
		if (PhotonNetwork.networkingPeer == null)
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
			Hashtable hashtable = new Hashtable();
			hashtable.Add(0, c5dfde30d8784694fb9999709d290e6c4);
			hashtable.Add(1, (byte)cf1e37eb6d0553f653c2bc1306ea76d36);
			hashtable.Add(2, c591d56a94543e3559945c497f37126c4);
			Hashtable c98406db696ab6ddbd25ee108c3e91e6a = hashtable;
			PhotonNetwork.networkingPeer.c3f632fdd31c8a3f2463924fbc1ced8b4(222, c98406db696ab6ddbd25ee108c3e91e6a, true, 0);
			return;
		}
	}

	public void OnInventoryUpdated(Dictionary<byte, object> parameters)
	{
		Hashtable hashtable = (Hashtable)parameters[245];
		int key = (int)hashtable[0];
		if (!mInventories.ContainsKey(key))
		{
			while (true)
			{
				switch (7)
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
		Inventory inventory = mInventories[key];
		switch ((UpdateEventType)(byte)hashtable[1])
		{
		case UpdateEventType.AddItemsToInventory:
		{
			Hashtable hashtable3 = (Hashtable)hashtable[2];
			IDictionaryEnumerator enumerator2 = hashtable3.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					DictionaryEntry dictionaryEntry2 = (DictionaryEntry)enumerator2.Current;
					int c793014f9fd028450a4a9908376309f = (int)dictionaryEntry2.Key;
					Hashtable ca57e1c076c01141c5ce58c7341db = (Hashtable)dictionaryEntry2.Value;
					ItemDNA ca57e1c076c01141c5ce58c7341db2 = ItemDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2(ca57e1c076c01141c5ce58c7341db);
					inventory.c2c88f58e2567403c799587ade8434690(c793014f9fd028450a4a9908376309f, ca57e1c076c01141c5ce58c7341db2);
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
			finally
			{
				IDisposable disposable2 = enumerator2 as IDisposable;
				if (disposable2 == null)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							goto end_IL_0115;
						}
						continue;
						end_IL_0115:
						break;
					}
				}
				else
				{
					disposable2.Dispose();
				}
			}
		}
		case UpdateEventType.EquipNewWeapon:
		{
			Hashtable hashtable2 = (Hashtable)hashtable[2];
			IDictionaryEnumerator enumerator = hashtable2.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
					inventory.c42841eb15edb296c94c38f237f57d3dd(ItemDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2((Hashtable)dictionaryEntry.Value), (byte)dictionaryEntry.Key);
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
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable == null)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							goto end_IL_01ac;
						}
						continue;
						end_IL_01ac:
						break;
					}
				}
				else
				{
					disposable.Dispose();
				}
			}
		}
		case UpdateEventType.UpdateAmmo:
		{
			Dictionary<int, int> c9ce1c28bef8a1d03500a302b2e3a3ac = (Dictionary<int, int>)hashtable[2];
			inventory.cd881bce8c275328b4429276a57a0175e(c9ce1c28bef8a1d03500a302b2e3a3ac);
			break;
		}
		}
	}

	public void OnInventoryAction(Dictionary<byte, object> parameters)
	{
		Hashtable hashtable = cc4f48f0020e93b4626fa4d1a4676550a.c7088de59e49f7108f520cf7e0bae167e;
		int num = 255;
		Inventory inventory = c41d147b329619ab0713ada2feb243be8.c7088de59e49f7108f520cf7e0bae167e;
		InventoryAction inventoryAction = InventoryAction.Invalid;
		byte b = byte.MaxValue;
		byte b2 = byte.MaxValue;
		try
		{
			hashtable = (Hashtable)parameters[245];
			num = (int)hashtable[0];
			if (!mInventories.ContainsKey(num))
			{
				while (true)
				{
					switch (7)
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
			inventory = mInventories[num];
			inventoryAction = (InventoryAction)(byte)hashtable[1];
			b = (byte)hashtable[2];
			b2 = (byte)hashtable[3];
			switch (inventoryAction)
			{
			case InventoryAction.DropItem:
				inventory.cccb56495987b6a4ebab7b225fb1af261(b);
				break;
			case InventoryAction.EquipWeapon:
				inventory.cabac189d699c8d8d56d0e1a68cd1440b(b, b2);
				break;
			case InventoryAction.SetActiveWeapon:
				inventory.cb71c24b68b65fe176d7936520d63a102(b);
				break;
			case InventoryAction.SwapItems:
				inventory.cc62b4b3e79f635a94d84949382bba1fc(b, b2);
				break;
			case InventoryAction.UnequipWeapon:
				inventory.c89361444df98c6f8354125e8bdb18882(b, b2);
				break;
			case InventoryAction.SwapWeapons:
				inventory.ccfdbed5cc5051e9ffb25bea212f7ddc6(b, b2);
				break;
			case InventoryAction.EquipShield:
				inventory.c61f40925cf99c31aa9ac5df098110ada(b);
				break;
			case InventoryAction.EquipClassMod:
				inventory.c8bd71a55c46846de17877d69bbae8bc3(b);
				break;
			}
		}
		catch (Exception ex)
		{
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(7);
			array[0] = ex.Message;
			int num2;
			if (hashtable == null)
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
				num2 = -1;
			}
			else
			{
				num2 = hashtable.Count;
			}
			array[1] = num2;
			array[2] = num;
			array[3] = inventory != c41d147b329619ab0713ada2feb243be8.c7088de59e49f7108f520cf7e0bae167e;
			array[4] = inventoryAction;
			array[5] = b;
			array[6] = b2;
			string text = string.Format("On Inventory Action failed with error {0}\r\n\t\t\t\tEvent Data Size: {1}\r\n\t\t\t\tCharacter ID: {2}\r\n\t\t\t\tInventory Found?  {3}\r\n\t\t\t\tAction:  {4}\r\n\t\t\t\tFrom {5} To {6}", array);
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, text);
			throw new Exception(text, ex);
		}
	}

	private void OnCompleteInstance(int characterId, int instanceId)
	{
		switch (instanceId)
		{
		case 1:
			ca9ccd8d9ca797ff77e45b9be166a21d2(characterId, ItemType.Weapon, 15);
			mItemRewardCallbacks.ForEach(delegate(ItemRewardCallback c2db84530ef366a6deb001d449d4aa151)
			{
				int characterId2 = characterId;
				int instanceId2 = instanceId;
				int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = 15;
				c2db84530ef366a6deb001d449d4aa151(characterId2, instanceId2, array);
			});
			break;
		case 2:
			ca9ccd8d9ca797ff77e45b9be166a21d2(characterId, ItemType.Weapon, 16);
			mItemRewardCallbacks.ForEach(delegate(ItemRewardCallback c2db84530ef366a6deb001d449d4aa151)
			{
				int characterId3 = characterId;
				int instanceId3 = instanceId;
				int[] array2 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(1);
				array2[0] = 16;
				c2db84530ef366a6deb001d449d4aa151(characterId3, instanceId3, array2);
			});
			break;
		case 3:
			ca9ccd8d9ca797ff77e45b9be166a21d2(characterId, ItemType.Weapon, 17);
			mItemRewardCallbacks.ForEach(delegate(ItemRewardCallback c2db84530ef366a6deb001d449d4aa151)
			{
				int characterId4 = characterId;
				int instanceId4 = instanceId;
				int[] array3 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(1);
				array3[0] = 17;
				c2db84530ef366a6deb001d449d4aa151(characterId4, instanceId4, array3);
			});
			break;
		case 4:
			ca9ccd8d9ca797ff77e45b9be166a21d2(characterId, ItemType.Weapon, 18);
			ca9ccd8d9ca797ff77e45b9be166a21d2(characterId, ItemType.Weapon, 19);
			mItemRewardCallbacks.ForEach(delegate(ItemRewardCallback c2db84530ef366a6deb001d449d4aa151)
			{
				int characterId5 = characterId;
				int instanceId5 = instanceId;
				int[] array4 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(2);
				array4[0] = 18;
				array4[1] = 19;
				c2db84530ef366a6deb001d449d4aa151(characterId5, instanceId5, array4);
			});
			break;
		case 5:
			ca9ccd8d9ca797ff77e45b9be166a21d2(characterId, ItemType.Weapon, 20);
			ca9ccd8d9ca797ff77e45b9be166a21d2(characterId, ItemType.Weapon, 21);
			mItemRewardCallbacks.ForEach(delegate(ItemRewardCallback c2db84530ef366a6deb001d449d4aa151)
			{
				int characterId6 = characterId;
				int instanceId6 = instanceId;
				int[] array5 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(2);
				array5[0] = 20;
				array5[1] = 21;
				c2db84530ef366a6deb001d449d4aa151(characterId6, instanceId6, array5);
			});
			break;
		case 6:
			ca9ccd8d9ca797ff77e45b9be166a21d2(characterId, ItemType.Weapon, 22);
			ca9ccd8d9ca797ff77e45b9be166a21d2(characterId, ItemType.Weapon, 23);
			mItemRewardCallbacks.ForEach(delegate(ItemRewardCallback c2db84530ef366a6deb001d449d4aa151)
			{
				int characterId7 = characterId;
				int instanceId7 = instanceId;
				int[] array6 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(2);
				array6[0] = 22;
				array6[1] = 23;
				c2db84530ef366a6deb001d449d4aa151(characterId7, instanceId7, array6);
			});
			break;
		case 7:
			ca9ccd8d9ca797ff77e45b9be166a21d2(characterId, ItemType.Weapon, 24);
			ca9ccd8d9ca797ff77e45b9be166a21d2(characterId, ItemType.Weapon, 25);
			mItemRewardCallbacks.ForEach(delegate(ItemRewardCallback c2db84530ef366a6deb001d449d4aa151)
			{
				int characterId8 = characterId;
				int instanceId8 = instanceId;
				int[] array7 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(2);
				array7[0] = 24;
				array7[1] = 25;
				c2db84530ef366a6deb001d449d4aa151(characterId8, instanceId8, array7);
			});
			break;
		}
	}

	public void c49cacf0466f30da65d9fd1bbf2c43d64(ItemRewardCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mItemRewardCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c2d4a239826a505d83e051d84f6235017(ItemRewardCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mItemRewardCallbacks.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void OnServerInventoryUpdate(Dictionary<byte, object> parameters)
	{
		c3d3a580647c12bd3016d6bf60edaf16c((Hashtable)parameters[0]);
	}

	private void c3d3a580647c12bd3016d6bf60edaf16c(Hashtable c28cf3d24e3067ef54895f824fad7fcef)
	{
		int num = (int)c28cf3d24e3067ef54895f824fad7fcef[0];
		Inventory inventory = new Inventory(c28cf3d24e3067ef54895f824fad7fcef);
		if (!mInventories.ContainsKey(num))
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
			mInventories[num] = inventory;
		}
		mInventoryCallbacks.ForEach(delegate(InventoryCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(inventory);
		});
		for (int i = 0; i < mGetInventoryCallbacks.Count; i++)
		{
			mGetInventoryCallbacks[i](num, inventory);
		}
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

	public void OnNewWarehouse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse != 0)
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
			ce71a9210255812074cd2ddb2a411e428((Hashtable)parameters[0]);
			return;
		}
	}

	public void OnServerWarehouseUpdate(Dictionary<byte, object> parameters)
	{
		ce71a9210255812074cd2ddb2a411e428((Hashtable)parameters[0]);
	}

	private void ce71a9210255812074cd2ddb2a411e428(Hashtable c28cf3d24e3067ef54895f824fad7fcef)
	{
		mWarehouse = new Warehouse(c28cf3d24e3067ef54895f824fad7fcef);
		mWarehouseCallbacks.ForEach(delegate(WarehouseCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(mWarehouse);
		});
	}

	public void c05f80d16e3170409ad1eb25c2513dafe(WarehouseCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mWarehouseCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c65c59da24f9798ba26f34e1faad4f76a(WarehouseCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mWarehouseCallbacks.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cd5aabef23453e5fe1dc51bd3dddabd23()
	{
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(99, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	[CompilerGenerated]
	private void c8730585fc00023ae4c182fcbde0cba2d(WarehouseCallback c2db84530ef366a6deb001d449d4aa151)
	{
		c2db84530ef366a6deb001d449d4aa151(mWarehouse);
	}
}
