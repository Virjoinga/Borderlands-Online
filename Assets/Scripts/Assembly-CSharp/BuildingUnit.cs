using System;
using System.Collections.Generic;
using A;
using XsdSettings;

[Serializable]
public class BuildingUnit : ICloneable
{
	public uint bkID;

	public List<byte> mFBXs;

	public List<byte> mMats;

	private BuildingUnit()
	{
	}

	public BuildingUnit(int cbaa18f2c94c59e186827489ba007c223)
	{
		bkID = 0u;
		mFBXs = new List<byte>();
		mMats = new List<byte>();
		for (int i = 0; i < cbaa18f2c94c59e186827489ba007c223; i++)
		{
			mFBXs.Add(0);
			mMats.Add(0);
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
			return;
		}
	}

	public BuildingUnit(BuildingPart[] c72cd67947f0fe64deb9820c92f4b6fa3)
	{
		bkID = c72cd67947f0fe64deb9820c92f4b6fa3[0].bkID;
		mFBXs = new List<byte>();
		mMats = new List<byte>();
		for (int i = 0; i < c72cd67947f0fe64deb9820c92f4b6fa3.Length; i++)
		{
			for (int j = 0; j < c72cd67947f0fe64deb9820c92f4b6fa3.Length; j++)
			{
				if (c72cd67947f0fe64deb9820c92f4b6fa3[j].mPart != i)
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
				mFBXs.Add(c72cd67947f0fe64deb9820c92f4b6fa3[j].mFBX);
				mMats.Add(c72cd67947f0fe64deb9820c92f4b6fa3[j].mMat);
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					goto end_IL_0088;
				}
				continue;
				end_IL_0088:
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
				return;
			}
		}
	}

	public void c6ffbe4dfbf5b2b24cb42ecec6c479cd5(BuildingPart c716466036ca83f8907f5a0c81b0e432d)
	{
		if (c716466036ca83f8907f5a0c81b0e432d.bkID != bkID)
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
			if (c716466036ca83f8907f5a0c81b0e432d.mPart >= mFBXs.Count)
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
				mFBXs[c716466036ca83f8907f5a0c81b0e432d.mPart] = c716466036ca83f8907f5a0c81b0e432d.mFBX;
				mMats[c716466036ca83f8907f5a0c81b0e432d.mPart] = c716466036ca83f8907f5a0c81b0e432d.mMat;
				return;
			}
		}
	}

	public BuildingPart c693accb7f953ed2c388675c890c1e685(int c872943035f78644fd01b267deff00547)
	{
		return new BuildingPart(bkID, (byte)c872943035f78644fd01b267deff00547, mFBXs[c872943035f78644fd01b267deff00547], mMats[c872943035f78644fd01b267deff00547]);
	}

	public BuildingPart[] c3a417921dfeb89c98e3e07a967681267()
	{
		BuildingPart[] array = c015251fb9f02fd840fd03897a90706e4.c0a0cdf4a196914163f7334d9b0781a04(mFBXs.Count);
		for (int i = 0; i < mFBXs.Count; i++)
		{
			array[i] = new BuildingPart(bkID, (byte)i, mFBXs[i], mMats[i]);
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
			return array;
		}
	}

	public int c0761d87ad5ab43e93d435ee4f6817098()
	{
		return mFBXs.Count;
	}

	public object Clone()
	{
		return (BuildingUnit)MemberwiseClone();
	}

	public override bool Equals(object obj)
	{
		BuildingUnit buildingUnit = obj as BuildingUnit;
		if (buildingUnit != null)
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
			if (bkID == buildingUnit.bkID)
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
				if (mFBXs == buildingUnit.mFBXs)
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
					if (mMats == buildingUnit.mMats)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								return true;
							}
						}
					}
				}
			}
		}
		return false;
	}

	public override int GetHashCode()
	{
		return bkID.GetHashCode() ^ mFBXs.GetHashCode() ^ mMats.GetHashCode();
	}
}
