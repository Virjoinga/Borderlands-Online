using System;
using A;
using UnityEngine;

namespace XsdSettings
{
	public class BuildingPart : ICloneable
	{
		private const byte mEmpty = byte.MaxValue;

		public uint bkID { get; set; }

		public byte mPart { get; set; }

		public byte mFBX { get; set; }

		public byte mMat { get; set; }

		public BuildingPart(uint c47a308543664a0e2f2c6c7549ee3b7c8, byte c716466036ca83f8907f5a0c81b0e432d, byte cbb09a793a43d6e23119957f68dffef0e, byte c4b37d539f2c2303a31bf314f3f555bef)
		{
			bkID = c47a308543664a0e2f2c6c7549ee3b7c8;
			mPart = c716466036ca83f8907f5a0c81b0e432d;
			mFBX = cbb09a793a43d6e23119957f68dffef0e;
			mMat = c4b37d539f2c2303a31bf314f3f555bef;
		}

		public BuildingPart(SubPartWpn c740fb87e58adaf9671b066d0900f1176)
		{
			if (c740fb87e58adaf9671b066d0900f1176 != null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						if (c740fb87e58adaf9671b066d0900f1176.m_BuildingPart.bkID != 0)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
									bkID = c740fb87e58adaf9671b066d0900f1176.m_BuildingPart.bkID;
									mPart = c740fb87e58adaf9671b066d0900f1176.m_BuildingPart.mPart;
									mFBX = c740fb87e58adaf9671b066d0900f1176.m_BuildingPart.mFBX;
									mMat = c740fb87e58adaf9671b066d0900f1176.m_BuildingPart.mMat;
									return;
								}
							}
						}
						bkID = BuildingKitManager.c06dee53a8ffacfe3c3e5815489a62508("WPN", Enum.GetName(Type.GetTypeFromHandle(cb69030d5cbca58447fc871be9aade1a0.cc1720d05c75832f704b87474932341c3()), c740fb87e58adaf9671b066d0900f1176.m_weaponType));
						BuildingKit buildingKit = BuildingKitManager.cf35675a65469fa29b2d1a69927efca64(bkID);
						mPart = (byte)Mathf.Clamp((int)c740fb87e58adaf9671b066d0900f1176.m_partType, 0, buildingKit.caa0fdc2398c34830d3d15f05bcff2020() - 1);
						mFBX = (byte)Mathf.Clamp(c740fb87e58adaf9671b066d0900f1176.m_Index, 0, buildingKit.c6ff6428f3ff765ca80c712124c47e83c((int)c740fb87e58adaf9671b066d0900f1176.m_partType) - 1);
						mMat = 0;
						return;
					}
					}
				}
			}
			bkID = 0u;
			mPart = byte.MaxValue;
			mFBX = byte.MaxValue;
			mMat = byte.MaxValue;
		}

		public BuildingPart()
		{
			bkID = 0u;
			mPart = 0;
			mFBX = 0;
			mMat = 0;
		}

		public object Clone()
		{
			return (BuildingPart)MemberwiseClone();
		}

		public override bool Equals(object obj)
		{
			BuildingPart buildingPart = obj as BuildingPart;
			if (buildingPart != null)
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
				if (bkID == buildingPart.bkID)
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
					if (mPart == buildingPart.mPart)
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
						if (mFBX == buildingPart.mFBX)
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
							if (mMat == buildingPart.mMat)
							{
								while (true)
								{
									switch (2)
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
			}
			return false;
		}

		public override int GetHashCode()
		{
			return bkID.GetHashCode() ^ mPart.GetHashCode() ^ mFBX.GetHashCode() ^ mMat.GetHashCode();
		}
	}
}
