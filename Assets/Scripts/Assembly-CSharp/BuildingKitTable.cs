using System;
using System.Collections.Generic;
using Core;

[Serializable]
public class BuildingKitTable
{
	public List<BuildingKitTableUnit> bkTable;

	public BuildingKitTable()
	{
		bkTable = new List<BuildingKitTableUnit>();
	}

	public void c9172684ab57085e2a77c2a3af69cb426(uint c29a834d12d3895f5680e69a30e6cd9a3, string cd1e3dee5c83b42041dac36bf26b36d23)
	{
		bkTable.Add(new BuildingKitTableUnit(c29a834d12d3895f5680e69a30e6cd9a3, cd1e3dee5c83b42041dac36bf26b36d23));
	}

	public string ce2f139146222cb1b456b26870cac104e(uint c29a834d12d3895f5680e69a30e6cd9a3)
	{
		for (int i = 0; i < bkTable.Count; i++)
		{
			if (bkTable[i].bkID != c29a834d12d3895f5680e69a30e6cd9a3)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return bkTable[i].filePath;
			}
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Can't find building kit by this ID :" + c29a834d12d3895f5680e69a30e6cd9a3);
			return string.Empty;
		}
	}
}
