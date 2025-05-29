using System.Collections.Generic;
using A;

public class InventoryServiceOffline : IInventoryService
{
	private Dictionary<int, Inventory> mInventories = new Dictionary<int, Inventory>();

	private List<InventoryCallback> mInventoryCallbacks = new List<InventoryCallback>();

	public Inventory c844f1a916a01fdb8a6a6e640d1811cf2(int c5dfde30d8784694fb9999709d290e6c4, GetInventoryCallback c2db84530ef366a6deb001d449d4aa151 = null)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return null;
				}
			}
		}
		WeaponGeneratorService component = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<WeaponGeneratorService>();
		if (component == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return null;
				}
			}
		}
		return mInventories[c5dfde30d8784694fb9999709d290e6c4];
	}

	public void cd2ff2d0b9710155a2e44c955d431a48d(int c5dfde30d8784694fb9999709d290e6c4)
	{
	}

	public void c234b6e5b8ed8e7dc06b7d1ec110c895d(int c5dfde30d8784694fb9999709d290e6c4)
	{
		mInventories.Remove(c5dfde30d8784694fb9999709d290e6c4);
	}

	public void cd5aabef23453e5fe1dc51bd3dddabd23()
	{
	}

	public void c7d08ed02a7697465eaaf348e5256df6d(InventoryCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mInventoryCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c0e99b4914f8c6b80f6233d720bf3d53f(InventoryCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mInventoryCallbacks.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c49cacf0466f30da65d9fd1bbf2c43d64(ItemRewardCallback c2db84530ef366a6deb001d449d4aa151)
	{
	}

	public void c2d4a239826a505d83e051d84f6235017(ItemRewardCallback c2db84530ef366a6deb001d449d4aa151)
	{
	}

	public void c42841eb15edb296c94c38f237f57d3dd(int c5dfde30d8784694fb9999709d290e6c4, ItemDNA ca57e1c076c01141c5ce58c7341db7833, byte cffaf6142283f4f4e6fddf855bae4597e)
	{
		if (c5dfde30d8784694fb9999709d290e6c4 != OnlineService.s_characterId)
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
			c844f1a916a01fdb8a6a6e640d1811cf2(c5dfde30d8784694fb9999709d290e6c4, cb8d3896b4fab7d0390a49fc34789c675.c7088de59e49f7108f520cf7e0bae167e).c42841eb15edb296c94c38f237f57d3dd(ca57e1c076c01141c5ce58c7341db7833, cffaf6142283f4f4e6fddf855bae4597e);
			return;
		}
	}

	public void cd881bce8c275328b4429276a57a0175e(int c5dfde30d8784694fb9999709d290e6c4, Dictionary<int, int> c9ce1c28bef8a1d03500a302b2e3a3ac5)
	{
		if (c5dfde30d8784694fb9999709d290e6c4 != OnlineService.s_characterId)
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
			c844f1a916a01fdb8a6a6e640d1811cf2(c5dfde30d8784694fb9999709d290e6c4, cb8d3896b4fab7d0390a49fc34789c675.c7088de59e49f7108f520cf7e0bae167e).cd881bce8c275328b4429276a57a0175e(c9ce1c28bef8a1d03500a302b2e3a3ac5);
			return;
		}
	}

	public void c52d5efe740f1c586cada86a418a5bfdd(int c5dfde30d8784694fb9999709d290e6c4)
	{
	}

	public void OnInventoryModification(Inventory inventory)
	{
		mInventoryCallbacks.ForEach(delegate(InventoryCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(inventory);
		});
	}

	public void c05f80d16e3170409ad1eb25c2513dafe(WarehouseCallback c2db84530ef366a6deb001d449d4aa151)
	{
	}

	public void c65c59da24f9798ba26f34e1faad4f76a(WarehouseCallback c2db84530ef366a6deb001d449d4aa151)
	{
	}
}
