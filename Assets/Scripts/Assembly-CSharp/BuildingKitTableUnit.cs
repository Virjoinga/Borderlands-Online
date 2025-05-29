using System;

[Serializable]
public class BuildingKitTableUnit
{
	public uint bkID;

	public string filePath;

	private BuildingKitTableUnit()
	{
	}

	public BuildingKitTableUnit(uint c29a834d12d3895f5680e69a30e6cd9a3, string cd1e3dee5c83b42041dac36bf26b36d23)
	{
		bkID = c29a834d12d3895f5680e69a30e6cd9a3;
		filePath = cd1e3dee5c83b42041dac36bf26b36d23;
	}
}
