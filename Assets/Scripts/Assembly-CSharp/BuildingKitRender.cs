using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public class BuildingKitRender
{
	public BuildingKit mBuildingKit;

	private BuildingUnit mBuildingUnit;

	private GameObject mCharacter;

	public BuildingUnit ccf784a7191cc76b4e0c079ff7b1e7ac7
	{
		get
		{
			return mBuildingUnit;
		}
		set
		{
			if (value.bkID != mBuildingUnit.bkID)
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
				mBuildingUnit = value;
				for (int i = 0; i < mBuildingUnit.c0761d87ad5ab43e93d435ee4f6817098(); i++)
				{
					if (mBuildingUnit.c693accb7f953ed2c388675c890c1e685(i) == null)
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
					int num = mBuildingKit.c6ff6428f3ff765ca80c712124c47e83c(i);
					if (num <= 0)
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
					if (mBuildingUnit.mFBXs[i] >= num)
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
						mBuildingUnit.mFBXs[i] = 0;
						string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(7);
						array[0] = "Incorrect Fbx For Part[";
						array[1] = mBuildingKit.ca913b520ff8d58edc1ad8cddd5eba04e(i);
						array[2] = "]from Building Kit[";
						array[3] = mBuildingKit.c47e99b30b26b61d5866d7266a2e73bc8();
						array[4] = "][";
						array[5] = mBuildingKit.cbb732e063b58a30b5dc6ec326627d01e();
						array[6] = "]";
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, string.Concat(array));
					}
					int num2 = mBuildingKit.c627db55a4773c34acc049b18a3e399a6(i, mBuildingUnit.mFBXs[i]);
					if (num2 <= 0)
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
					if (mBuildingUnit.mMats[i] < num2)
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
						break;
					}
					mBuildingUnit.mMats[i] = 0;
					string[] array2 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(7);
					array2[0] = "Incorrect Material For Part [";
					array2[1] = mBuildingKit.ca913b520ff8d58edc1ad8cddd5eba04e(i);
					array2[2] = "] from Building Kit[";
					array2[3] = mBuildingKit.c47e99b30b26b61d5866d7266a2e73bc8();
					array2[4] = "][";
					array2[5] = mBuildingKit.cbb732e063b58a30b5dc6ec326627d01e();
					array2[6] = "]";
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, string.Concat(array2));
				}
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
		}
	}

	private BuildingKitRender()
	{
	}

	public BuildingKitRender(string cca40301c51a71b4c1581ccc122ba2fa4, string c2ddf18d5a4dd7984d76b7b77711c2a6a)
	{
		uint num = BuildingKitManager.c06dee53a8ffacfe3c3e5815489a62508(cca40301c51a71b4c1581ccc122ba2fa4, c2ddf18d5a4dd7984d76b7b77711c2a6a);
		mBuildingKit = BuildingKitManager.cf35675a65469fa29b2d1a69927efca64(num);
		c8895306a52d7e41e386db2ac80f5e2db(num);
	}

	public BuildingKitRender(uint c5ef7be88b7cd502e8bb4a640b91ac1df)
	{
		mBuildingKit = BuildingKitManager.cf35675a65469fa29b2d1a69927efca64(c5ef7be88b7cd502e8bb4a640b91ac1df);
		c8895306a52d7e41e386db2ac80f5e2db(c5ef7be88b7cd502e8bb4a640b91ac1df);
	}

	public BuildingKitRender(BuildingUnit c41e41bb00590bc67f6b9b1af59e7b1d3)
	{
		mBuildingKit = BuildingKitManager.cf35675a65469fa29b2d1a69927efca64(c41e41bb00590bc67f6b9b1af59e7b1d3.bkID);
		mBuildingUnit = c41e41bb00590bc67f6b9b1af59e7b1d3;
	}

	private void c8895306a52d7e41e386db2ac80f5e2db(uint c5ef7be88b7cd502e8bb4a640b91ac1df)
	{
		if (mBuildingKit != null)
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
					mBuildingUnit = new BuildingUnit(mBuildingKit.caa0fdc2398c34830d3d15f05bcff2020());
					mBuildingUnit.bkID = c5ef7be88b7cd502e8bb4a640b91ac1df;
					return;
				}
			}
		}
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "BuildingKit create fail since the wrong ID!!");
	}

	public void c090e54583724a369a50a88fc3eb5592a()
	{
		new BuildingKitGenerator().c73b071ad863418024417716b8be899d1(mBuildingUnit);
	}

	public void c67915f2da62d83244da1e904f44dcc85(bool c8b6e31e8301cd4d1eb7e3b6e854baf78 = true)
	{
		new BuildingKitGenerator().cba02ca1a8a050ac54c694317b191cc63(mBuildingUnit, c8b6e31e8301cd4d1eb7e3b6e854baf78);
	}

	public void c5f562c5a8498db03688b38f3dcdf7faf(bool c8b6e31e8301cd4d1eb7e3b6e854baf78 = true)
	{
		new BuildingKitGenerator().c9ac1c3f48a17eeb883683f7058855366(mBuildingUnit, c8b6e31e8301cd4d1eb7e3b6e854baf78);
	}

	public GameObject c3309affdc4b59cba5f457bbaec5f0762()
	{
		mCharacter = new BuildingKitGenerator().c3ec92e17a377a835b74cf48e005fe134(mBuildingUnit);
		return mCharacter;
	}

	public GameObject cca6fe4e85fa02d8c2a4d33c08a268939()
	{
		if (mCharacter != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					BuildingKitGenerator buildingKitGenerator = new BuildingKitGenerator();
					return buildingKitGenerator.c0a6259fccb95aae60756b4a48cccb967(mCharacter, mBuildingUnit);
				}
				}
			}
		}
		return c3309affdc4b59cba5f457bbaec5f0762();
	}

	public Object c7f3e848db953bbd8ebbaec6fb47ca55d()
	{
		return (Object)new BuildingKitBoneBodyLoader(mBuildingKit).c588e7dbcd383d8230b2d83d7b44af23b();
	}

	public int c0ea5dc09f2bcde02ec9c097cf6e3a2b4()
	{
		return mBuildingKit.caa0fdc2398c34830d3d15f05bcff2020();
	}

	public bool cb79e2e0b0d782d2f9097beab23a5e191(int c5ecf39c31cb10d10fc229bf29ed52790)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 > mBuildingKit.caa0fdc2398c34830d3d15f05bcff2020())
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
					return false;
				}
			}
		}
		if (mBuildingKit.c6ff6428f3ff765ca80c712124c47e83c(c5ecf39c31cb10d10fc229bf29ed52790) < 2)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		List<byte> mFBXs;
		List<byte> list = (mFBXs = mBuildingUnit.mFBXs);
		int index;
		int index2 = (index = c5ecf39c31cb10d10fc229bf29ed52790);
		byte b = mFBXs[index];
		list[index2] = (byte)(b + 1);
		if (mBuildingUnit.mFBXs[c5ecf39c31cb10d10fc229bf29ed52790] >= mBuildingKit.c6ff6428f3ff765ca80c712124c47e83c(c5ecf39c31cb10d10fc229bf29ed52790))
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
			mBuildingUnit.mFBXs[c5ecf39c31cb10d10fc229bf29ed52790] = 0;
		}
		mBuildingUnit.mMats[c5ecf39c31cb10d10fc229bf29ed52790] = 0;
		return true;
	}

	public bool cb41f27f58a35a325e0a1ff1b026bb4e5(int c5ecf39c31cb10d10fc229bf29ed52790, int c5612a459a84ffdb41c885401433cd62d)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 > mBuildingKit.caa0fdc2398c34830d3d15f05bcff2020())
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
					return false;
				}
			}
		}
		if (mBuildingKit.c6ff6428f3ff765ca80c712124c47e83c(c5ecf39c31cb10d10fc229bf29ed52790) <= c5612a459a84ffdb41c885401433cd62d)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (mBuildingUnit.mFBXs[c5ecf39c31cb10d10fc229bf29ed52790] == c5612a459a84ffdb41c885401433cd62d)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		mBuildingUnit.mFBXs[c5ecf39c31cb10d10fc229bf29ed52790] = (byte)c5612a459a84ffdb41c885401433cd62d;
		return true;
	}

	public bool c96b14062db96371df537de25e2089af1(int c5ecf39c31cb10d10fc229bf29ed52790)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 > mBuildingKit.caa0fdc2398c34830d3d15f05bcff2020())
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
					return false;
				}
			}
		}
		if (mBuildingKit.c627db55a4773c34acc049b18a3e399a6(c5ecf39c31cb10d10fc229bf29ed52790, mBuildingUnit.mFBXs[c5ecf39c31cb10d10fc229bf29ed52790]) < 2)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		List<byte> mMats;
		List<byte> list = (mMats = mBuildingUnit.mMats);
		int index;
		int index2 = (index = c5ecf39c31cb10d10fc229bf29ed52790);
		byte b = mMats[index];
		list[index2] = (byte)(b + 1);
		if (mBuildingUnit.mMats[c5ecf39c31cb10d10fc229bf29ed52790] >= mBuildingKit.c627db55a4773c34acc049b18a3e399a6(c5ecf39c31cb10d10fc229bf29ed52790, mBuildingUnit.mFBXs[c5ecf39c31cb10d10fc229bf29ed52790]))
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
			mBuildingUnit.mMats[c5ecf39c31cb10d10fc229bf29ed52790] = 0;
		}
		return true;
	}

	public bool c73b3e333e93633e0d4e21fb2e41d7d14(int c5ecf39c31cb10d10fc229bf29ed52790, int c5612a459a84ffdb41c885401433cd62d)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 > mBuildingKit.caa0fdc2398c34830d3d15f05bcff2020())
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
					return false;
				}
			}
		}
		if (mBuildingKit.c627db55a4773c34acc049b18a3e399a6(c5ecf39c31cb10d10fc229bf29ed52790, mBuildingUnit.mFBXs[c5ecf39c31cb10d10fc229bf29ed52790]) <= c5612a459a84ffdb41c885401433cd62d)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (mBuildingUnit.mMats[c5ecf39c31cb10d10fc229bf29ed52790] == c5612a459a84ffdb41c885401433cd62d)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		mBuildingUnit.mMats[c5ecf39c31cb10d10fc229bf29ed52790] = (byte)c5612a459a84ffdb41c885401433cd62d;
		return true;
	}

	public void c93ec83bb34f69e6982403e6557d61756()
	{
		for (int i = 0; i < mBuildingKit.caa0fdc2398c34830d3d15f05bcff2020(); i++)
		{
			mBuildingUnit.mFBXs[i] = (byte)Random.Range(0, mBuildingKit.c6ff6428f3ff765ca80c712124c47e83c(i) - 1);
			mBuildingUnit.mMats[i] = (byte)Random.Range(0, mBuildingKit.c627db55a4773c34acc049b18a3e399a6(i, mBuildingUnit.mFBXs[i]));
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
			return;
		}
	}

	public void c365a77c63c91e13de4ca19c9a953aa5e()
	{
		if (!(mCharacter != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			Object.Destroy(mCharacter);
			return;
		}
	}

	public List<string> c0c98f9aa4067deab3caf8159826ae606(bool c8b6e31e8301cd4d1eb7e3b6e854baf78 = true)
	{
		List<string> list = new List<string>();
		if (!new BuildingKitBoneBodyLoader(mBuildingKit).cc0a53fa7d0e20f793f5143d553cd734f())
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
			list.Add(mBuildingKit.c8a776141b9026555e9e5009d8f6c57e7());
		}
		for (int i = 0; i < mBuildingKit.caa0fdc2398c34830d3d15f05bcff2020(); i++)
		{
			if (mBuildingKit.cc985d3ce3968b538b964e683c1676ef0(i, mBuildingUnit.mFBXs[i]) == BuildingKit.emptyPart)
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
			}
			else
			{
				if (new BuildingKitFbxLoader(mBuildingKit, i, mBuildingUnit.mFBXs[i]).cc0a53fa7d0e20f793f5143d553cd734f())
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
					break;
				}
				list.Add(mBuildingKit.c702db42bc09810f190028fd685ba6ee8(i, mBuildingUnit.mFBXs[i]));
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			for (int j = 0; j < mBuildingKit.caa0fdc2398c34830d3d15f05bcff2020(); j++)
			{
				if (mBuildingKit.cc985d3ce3968b538b964e683c1676ef0(j, mBuildingUnit.mFBXs[j]) == BuildingKit.emptyPart)
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
					continue;
				}
				if (!c8b6e31e8301cd4d1eb7e3b6e854baf78)
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
				string item = mBuildingKit.ce53f057551dc40db40d79611a545cbea(j, mBuildingUnit.mFBXs[j], mBuildingUnit.mMats[j]);
				if (!new BuildingKitMaterialLoader(mBuildingKit, j, mBuildingUnit.mFBXs[j], mBuildingUnit.mMats[j]).cc0a53fa7d0e20f793f5143d553cd734f())
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
					if (!list.Contains(item))
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
						list.Add(item);
					}
				}
				for (int k = 0; k < mBuildingKit.c19986b1d5c10a3b1e3d663ea11d99381(j, mBuildingUnit.mFBXs[j], mBuildingUnit.mMats[j]); k++)
				{
					string item2 = mBuildingKit.cdc42c79663ca79a71f3537492abcec13(j, mBuildingUnit.mFBXs[j], mBuildingUnit.mMats[j], k);
					if (new BuildingKitTextureLoader(mBuildingKit, j, mBuildingUnit.mFBXs[j], mBuildingUnit.mMats[j], k).cc0a53fa7d0e20f793f5143d553cd734f())
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
					if (list.Contains(item2))
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
					list.Add(item2);
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
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				return list;
			}
		}
	}

	public List<string> ca8a5af6eb0b2329ae9c0880a0712d3b8()
	{
		List<string> list = new List<string>();
		if (!new BuildingKitBoneBodyLoader(mBuildingKit).cc0a53fa7d0e20f793f5143d553cd734f())
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
			list.Add(mBuildingKit.c8a776141b9026555e9e5009d8f6c57e7());
		}
		for (int i = 0; i < mBuildingKit.caa0fdc2398c34830d3d15f05bcff2020(); i++)
		{
			for (int j = 0; j < mBuildingKit.c6ff6428f3ff765ca80c712124c47e83c(i); j++)
			{
				if (mBuildingKit.cc985d3ce3968b538b964e683c1676ef0(i, j) == BuildingKit.emptyPart)
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
					continue;
				}
				if (!new BuildingKitFbxLoader(mBuildingKit, i, j).cc0a53fa7d0e20f793f5143d553cd734f())
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
					list.Add(mBuildingKit.c702db42bc09810f190028fd685ba6ee8(i, j));
				}
				for (int k = 0; k < mBuildingKit.c627db55a4773c34acc049b18a3e399a6(i, j); k++)
				{
					string item = mBuildingKit.ce53f057551dc40db40d79611a545cbea(i, j, k);
					if (!new BuildingKitMaterialLoader(mBuildingKit, i, j, k).cc0a53fa7d0e20f793f5143d553cd734f())
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
						if (!list.Contains(item))
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
							list.Add(item);
						}
					}
					for (int l = 0; l < mBuildingKit.c19986b1d5c10a3b1e3d663ea11d99381(i, j, k); l++)
					{
						string item2 = mBuildingKit.cdc42c79663ca79a71f3537492abcec13(i, j, k, l);
						if (new BuildingKitTextureLoader(mBuildingKit, i, j, k, l).cc0a53fa7d0e20f793f5143d553cd734f())
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
						if (list.Contains(item2))
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
						list.Add(item2);
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							goto end_IL_017b;
						}
						continue;
						end_IL_017b:
						break;
					}
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
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					goto end_IL_01c0;
				}
				continue;
				end_IL_01c0:
				break;
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return list;
		}
	}
}
