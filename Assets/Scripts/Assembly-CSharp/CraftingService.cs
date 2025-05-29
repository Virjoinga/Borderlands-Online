using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using XsdSettings;

internal class CraftingService : OnAccessSingleton<ICraftingService, CraftingService, CraftingServiceOffline>, ICraftingService
{
	private List<OnUpgradeStarExperience> mOnUpgradeStarExperience;

	private List<OnUpgradeStarLevel> mOnUpgradeStarLevel;

	private OnSmeltWeapon mOnSmeltWeapon;

	private OnCraftWeapon mOnCraftWeapon;

	private OnGetMyCraftedWeapons mOnGetMyCraftedWeapons;

	[CompilerGenerated]
	private static Action<OnUpgradeStarExperience> _003C_003Ef__am_0024cache5;

	[CompilerGenerated]
	private static Action<OnUpgradeStarLevel> _003C_003Ef__am_0024cache6;

	public CraftingService()
	{
		mOnUpgradeStarExperience = new List<OnUpgradeStarExperience>();
		mOnUpgradeStarLevel = new List<OnUpgradeStarLevel>();
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(154, OnWeaponSmelted);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(153, OnWeaponCrafted);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(143, OnGetMyCraftedWeaponsResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(69, OnUpgradeStarExperienceResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(68, OnUpgradeStarLevelResponse);
	}

	public void c2b738a0787415710b9ab86768a28207d(OnSmeltWeapon c2db84530ef366a6deb001d449d4aa151, int cd27037dd3bf1006e6e39ebf89cbd7b03)
	{
		mOnSmeltWeapon = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = cd27037dd3bf1006e6e39ebf89cbd7b03;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(154, array);
	}

	private void OnWeaponSmelted(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnSmeltWeapon == null)
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
			if (operationResponse == 0)
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
				mOnSmeltWeapon(true);
			}
			else
			{
				mOnSmeltWeapon(false);
			}
			mOnSmeltWeapon = cd89da6de9d645aa145bbddb1bf0fdf90.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c99dc1247f2835cc10ef79f23e75449c8(OnCraftWeapon c2db84530ef366a6deb001d449d4aa151, WeaponType c27b7430edc94b8f5b543605119ec4a72)
	{
		mOnCraftWeapon = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = (int)c27b7430edc94b8f5b543605119ec4a72;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(153, array);
	}

	private void OnWeaponCrafted(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnCraftWeapon == null)
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
			if (operationResponse == 0)
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
				mOnCraftWeapon(true, (int)parameters[1], ItemDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2((Hashtable)parameters[0]));
			}
			else
			{
				mOnCraftWeapon(false, -1, c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
			}
			mOnCraftWeapon = c7fdc7feb259b463a2aeaa5fa7c6061a6.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c1ce781f2f9808d850e290cc8196d4f10(OnUpgradeStarExperience c2db84530ef366a6deb001d449d4aa151, int cc9e01f27c0efed9577d81fb17c1fba75)
	{
		if (c2db84530ef366a6deb001d449d4aa151 != null)
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
			mOnUpgradeStarExperience.Add(c2db84530ef366a6deb001d449d4aa151);
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = cc9e01f27c0efed9577d81fb17c1fba75;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(69, array);
	}

	private void OnUpgradeStarExperienceResponse(short operationResponse, Dictionary<byte, object> parameters)
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
			mOnUpgradeStarExperience.ForEach(delegate(OnUpgradeStarExperience c5ebdc65d5cb420faf7ba524809963aa9)
			{
				c5ebdc65d5cb420faf7ba524809963aa9(ItemDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2((Hashtable)parameters[0]));
			});
		}
		else
		{
			List<OnUpgradeStarExperience> list = mOnUpgradeStarExperience;
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
				_003C_003Ef__am_0024cache5 = delegate(OnUpgradeStarExperience c5ebdc65d5cb420faf7ba524809963aa9)
				{
					c5ebdc65d5cb420faf7ba524809963aa9(c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
				};
			}
			list.ForEach(_003C_003Ef__am_0024cache5);
		}
		mOnUpgradeStarExperience.Clear();
	}

	public void c85f327d439d363ea060637d0fb984bef(OnUpgradeStarLevel c2db84530ef366a6deb001d449d4aa151, int cc9e01f27c0efed9577d81fb17c1fba75)
	{
		if (c2db84530ef366a6deb001d449d4aa151 != null)
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
			mOnUpgradeStarLevel.Add(c2db84530ef366a6deb001d449d4aa151);
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = cc9e01f27c0efed9577d81fb17c1fba75;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(68, array);
	}

	private void OnUpgradeStarLevelResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
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
			mOnUpgradeStarLevel.ForEach(delegate(OnUpgradeStarLevel c5ebdc65d5cb420faf7ba524809963aa9)
			{
				c5ebdc65d5cb420faf7ba524809963aa9((bool)parameters[0], ItemDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2((Hashtable)parameters[1]));
			});
		}
		else
		{
			List<OnUpgradeStarLevel> list = mOnUpgradeStarLevel;
			if (_003C_003Ef__am_0024cache6 == null)
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
				_003C_003Ef__am_0024cache6 = delegate(OnUpgradeStarLevel c5ebdc65d5cb420faf7ba524809963aa9)
				{
					c5ebdc65d5cb420faf7ba524809963aa9(false, c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
				};
			}
			list.ForEach(_003C_003Ef__am_0024cache6);
		}
		mOnUpgradeStarLevel.Clear();
	}

	public void cd5ebddd4f7d88647487b39fa8b1ae798(OnGetMyCraftedWeapons c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGetMyCraftedWeapons = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(143, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnGetMyCraftedWeaponsResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGetMyCraftedWeapons == null)
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
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					if (parameters[0] != null)
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
						int[] craftedWeapons = (int[])parameters[0];
						mOnGetMyCraftedWeapons(craftedWeapons);
						goto IL_0082;
					}
				}
			}
			mOnGetMyCraftedWeapons(cdaeaf95d71df33e056aef814d5b686ff.c7088de59e49f7108f520cf7e0bae167e);
			goto IL_0082;
			IL_0082:
			mOnCraftWeapon = c7fdc7feb259b463a2aeaa5fa7c6061a6.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	[CompilerGenerated]
	private static void c3e5b17b9a02b01b312f3480ee68e7d9d(OnUpgradeStarExperience c5ebdc65d5cb420faf7ba524809963aa9)
	{
		c5ebdc65d5cb420faf7ba524809963aa9(c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
	}

	[CompilerGenerated]
	private static void c0eaf7d82401c82c52de011a5152d3f70(OnUpgradeStarLevel c5ebdc65d5cb420faf7ba524809963aa9)
	{
		c5ebdc65d5cb420faf7ba524809963aa9(false, c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
	}
}
