using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using UnityEngine;

public class BuildingKitManager
{
	public static string[] shaderTexPropertyNames;

	public static string[] mergeableShaderTexPropertyNames;

	public static bool OnlineHostMinResMode;

	private static BuildingKitTable bkTableStrings;

	private static Dictionary<uint, BuildingKit> bkTable;

	public static BuildingKitTable c93b8a9cdba26e37d7c55b1e834e4d92e
	{
		get
		{
			if (bkTableStrings == null)
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
				TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("BuildingKit/BuildingKitTable/bkTable") as TextAsset;
				Stream stream = new MemoryStream(textAsset.bytes);
				try
				{
					XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c0e37afdd194b23e38b0d4667d1a387f6.cc1720d05c75832f704b87474932341c3()));
					bkTableStrings = (BuildingKitTable)xmlSerializer.Deserialize(stream);
				}
				finally
				{
					if (stream != null)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								continue;
							}
							((IDisposable)stream).Dispose();
							break;
						}
					}
				}
				ResourcesLoader.cc054e122aa35d5a0be5d36720b44c779(textAsset);
			}
			return bkTableStrings;
		}
		private set
		{
			bkTableStrings = value;
		}
	}

	protected BuildingKitManager()
	{
	}

	static BuildingKitManager()
	{
		string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(9);
		array[0] = "_MainTex";
		array[1] = "_MaskTex";
		array[2] = "_BumpMap";
		array[3] = "_Cube";
		array[4] = "_PatternTex";
		array[5] = "_Patten0Tex";
		array[6] = "_Patten1Tex";
		array[7] = "_DecalTex";
		array[8] = "_Ramp";
		shaderTexPropertyNames = array;
		string[] array2 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(5);
		array2[0] = "_MaskTex";
		array2[1] = "_BumpMap";
		array2[2] = "_Patten0Tex";
		array2[3] = "_Patten1Tex";
		array2[4] = "_MainTex";
		mergeableShaderTexPropertyNames = array2;
		OnlineHostMinResMode = false;
		bkTable = new Dictionary<uint, BuildingKit>();
	}

	public static BuildingKit cf35675a65469fa29b2d1a69927efca64(uint ca58e85c219fbd78fe97cebc80d364240)
	{
		BuildingKit value = cdb738ec8c8a01cc9bc318b9044b3bd1f.c7088de59e49f7108f520cf7e0bae167e;
		if (!bkTable.TryGetValue(ca58e85c219fbd78fe97cebc80d364240, out value))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			value = new BuildingKit(c93b8a9cdba26e37d7c55b1e834e4d92e.ce2f139146222cb1b456b26870cac104e(ca58e85c219fbd78fe97cebc80d364240));
			bkTable.Add(ca58e85c219fbd78fe97cebc80d364240, value);
		}
		return value;
	}

	public static uint c06dee53a8ffacfe3c3e5815489a62508(string cca40301c51a71b4c1581ccc122ba2fa4, string cc50f2ab59bea70bd4bd461b7e69d0429)
	{
		string c7c80fef79e3c330ae5014832d44fcd = cca40301c51a71b4c1581ccc122ba2fa4 + cc50f2ab59bea70bd4bd461b7e69d0429;
		return Utility.cf642a65627df2adf4e90330457651907(c7c80fef79e3c330ae5014832d44fcd);
	}
}
