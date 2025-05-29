using System.Xml;
using A;
using Core;

public class AudioSwitchManager : UniqueAudioObjectManager<AudioSwitch>
{
	private static readonly string DEFAULT_RESOURCE_NAME = "SwitchConfig";

	private static readonly string SWITCH_TAG_NAME = "Switch";

	public string cab21c5eb17b47a54f86327a013aff0cc
	{
		get
		{
			return AudioResourceHelper.cbd60f3731d2ac132cb80b0c363564a68(DEFAULT_RESOURCE_NAME);
		}
	}

	public override void c89e353632385d799ae18926f4d1896ab()
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlNode newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e);
		xmlDocument.AppendChild(newChild);
		XmlNode xmlNode = xmlDocument.CreateElement("SwitchConfig");
		xmlDocument.AppendChild(xmlNode);
		for (int i = 0; i < base.c1805d5170a48b3a8510e57fd9095ce11.Count; i++)
		{
			AudioSwitch audioSwitch = base.c1805d5170a48b3a8510e57fd9095ce11[i];
			XmlElement xmlElement = xmlDocument.CreateElement(SWITCH_TAG_NAME);
			xmlNode.AppendChild(xmlElement);
			audioSwitch.c9742307d0830ac7381f2acd66ed5a6e2(xmlElement);
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
			xmlDocument.Save(cab21c5eb17b47a54f86327a013aff0cc);
			return;
		}
	}

	public override void c38aeacc59bd560b59403945ae7996d79()
	{
		base.c38aeacc59bd560b59403945ae7996d79();
		XmlDocument xmlDocument = AudioResourceHelper.c48358dcd6a2e220a4897f930f2fc7d0b(DEFAULT_RESOURCE_NAME);
		if (xmlDocument == null)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "Error loading Switches from file: " + cab21c5eb17b47a54f86327a013aff0cc);
					return;
				}
			}
		}
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(SWITCH_TAG_NAME);
		for (int i = 0; i < elementsByTagName.Count; i++)
		{
			XmlNode cab83bba925e6355b7d0df9fe7c31c6e = elementsByTagName[i];
			AudioSwitch audioSwitch = new AudioSwitch();
			audioSwitch.cc09306479ed0f9f54a5e4e8dd8d72b99(cab83bba925e6355b7d0df9fe7c31c6e);
			c6f49409b2929e4f0c4160ced1e7704fb(audioSwitch, string.Empty);
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}
}
