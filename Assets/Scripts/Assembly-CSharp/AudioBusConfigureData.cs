using System.Xml;
using A;
using Core;
using UnityEngine;

[ExecuteInEditMode]
public class AudioBusConfigureData
{
	public static void c89e353632385d799ae18926f4d1896ab(AudioBus c995788b6691378d76327efb841379455, string c4a07f27e5d8384641ced7df24579e4a8)
	{
		if (c995788b6691378d76327efb841379455 == null)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "masterBus == null!");
					return;
				}
			}
		}
		XmlDocument xmlDocument = new XmlDocument();
		XmlNode newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e);
		xmlDocument.AppendChild(newChild);
		XmlNode xmlNode = xmlDocument.CreateElement("AudioBusConfigure");
		xmlDocument.AppendChild(xmlNode);
		c995788b6691378d76327efb841379455.cf25b199c4a97f4ad49b976f44b213869(xmlNode);
		xmlDocument.Save(c4a07f27e5d8384641ced7df24579e4a8);
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "save bus configure done!");
	}

	public static AudioBus c38aeacc59bd560b59403945ae7996d79(string c8cfc468235c994038a1845ccabe31724)
	{
		AudioBus audioBus = new AudioBus();
		XmlDocument xmlDocument = AudioResourceHelper.c48358dcd6a2e220a4897f930f2fc7d0b(c8cfc468235c994038a1845ccabe31724);
		if (xmlDocument != null)
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
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("AudioBusConfigure");
			if (elementsByTagName.Count > 1)
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
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "more than one master bus!");
			}
			XmlNode firstChild = elementsByTagName[0].FirstChild;
			audioBus.cd7ec3c3d315215baa32be83f43e88843(firstChild);
		}
		else
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "Could not load Bus configuration data");
		}
		return audioBus;
	}
}
