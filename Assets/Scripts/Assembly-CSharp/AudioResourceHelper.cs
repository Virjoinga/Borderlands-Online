using System.Xml;
using A;
using Core;
using UnityEngine;

internal class AudioResourceHelper
{
	public static string c6b7293c17d19e4daecdf94924961394a(string c8cfc468235c994038a1845ccabe31724)
	{
		return "Audio/" + c8cfc468235c994038a1845ccabe31724;
	}

	public static string cbd60f3731d2ac132cb80b0c363564a68(string c8cfc468235c994038a1845ccabe31724)
	{
		return "Assets/Resources/Audio/" + c8cfc468235c994038a1845ccabe31724 + ".xml";
	}

	public static XmlDocument c48358dcd6a2e220a4897f930f2fc7d0b(string c8cfc468235c994038a1845ccabe31724)
	{
		XmlDocument c7088de59e49f7108f520cf7e0bae167e = cd3235d0d97607e107fda458aca6101d5.c7088de59e49f7108f520cf7e0bae167e;
		try
		{
			c7088de59e49f7108f520cf7e0bae167e = new XmlDocument();
			TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c6b7293c17d19e4daecdf94924961394a(c8cfc468235c994038a1845ccabe31724)) as TextAsset;
			if (null == textAsset)
			{
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "Loading error: " + c6b7293c17d19e4daecdf94924961394a(c8cfc468235c994038a1845ccabe31724) + " missing");
					c7088de59e49f7108f520cf7e0bae167e = cd3235d0d97607e107fda458aca6101d5.c7088de59e49f7108f520cf7e0bae167e;
					break;
				}
			}
			else
			{
				c7088de59e49f7108f520cf7e0bae167e.LoadXml(textAsset.text);
			}
		}
		catch
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "Error loading Xml doc from resource: " + c8cfc468235c994038a1845ccabe31724);
			c7088de59e49f7108f520cf7e0bae167e = cd3235d0d97607e107fda458aca6101d5.c7088de59e49f7108f520cf7e0bae167e;
		}
		return c7088de59e49f7108f520cf7e0bae167e;
	}
}
