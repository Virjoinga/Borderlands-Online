using System;
using System.IO;
using System.Xml.Serialization;
using A;
using UnityEngine;

public class BuildingKitXmlLoader : BuildingKitLoader
{
	private string str;

	public BuildingKitXmlLoader(string c3b20aeacd4dbc6ccc30bb556ab42eabd)
	{
		str = c3b20aeacd4dbc6ccc30bb556ab42eabd;
	}

	protected override object c38aeacc59bd560b59403945ae7996d79()
	{
		string c8aa0e7ee156ed339de23d3fe5557b = str;
		TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c8aa0e7ee156ed339de23d3fe5557b) as TextAsset;
		MemoryStream memoryStream = new MemoryStream(textAsset.bytes);
		ComposableCharacter composableCharacter;
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c8303b7077ef3d5d476d3998c827b8358.cc1720d05c75832f704b87474932341c3()));
			composableCharacter = (ComposableCharacter)xmlSerializer.Deserialize(memoryStream);
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
					composableCharacter.m_aParts.Clear();
				}
			}
			memoryStream.Close();
		}
		finally
		{
			if (memoryStream != null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					((IDisposable)memoryStream).Dispose();
					break;
				}
			}
		}
		ResourcesLoader.cc054e122aa35d5a0be5d36720b44c779(textAsset);
		return composableCharacter;
	}

	protected override uint c4cd4ae93a018bdeba99fff632cb3f04a()
	{
		return Utility.cf642a65627df2adf4e90330457651907(str);
	}
}
