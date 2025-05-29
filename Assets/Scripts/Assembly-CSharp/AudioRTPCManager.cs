using System.Collections.Generic;
using System.Xml;
using A;
using Core;

public class AudioRTPCManager : UniqueAudioObjectManager<AudioRTPCDefinition>
{
	private Dictionary<string, AudioEventResponser> m_RTPCrsponserHolder;

	public List<AudioObjectFolder<AudioRTPCDefinition>> m_audioRTPCFolderList = new List<AudioObjectFolder<AudioRTPCDefinition>>();

	private static readonly string DEFAULT_RESOURCE_NAME = "AudioRTPCcfgList";

	private static readonly string RTPC_TAG_NAME = "AudioRTPCobj";

	private static readonly string RTPC_FOLDER_NAME = "AudioRTPCFolder";

	public string cc7ea8535312cfcb86b44db709be0047b
	{
		get
		{
			return AudioResourceHelper.cbd60f3731d2ac132cb80b0c363564a68(DEFAULT_RESOURCE_NAME);
		}
	}

	protected override void c09d511c3784ab095450edb35ff70e674()
	{
		for (int i = 0; i < m_audioRTPCFolderList.Count; i++)
		{
			m_audioRTPCFolderList[i].cf5212e6903ec0c0b27816142c32a2d13();
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
			m_audioRTPCFolderList.Clear();
			base.c09d511c3784ab095450edb35ff70e674();
			return;
		}
	}

	public override void c89e353632385d799ae18926f4d1896ab()
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlNode newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e);
		xmlDocument.AppendChild(newChild);
		XmlNode xmlNode = xmlDocument.CreateElement("AudioRTPClist");
		xmlDocument.AppendChild(xmlNode);
		using (List<AudioObjectFolder<AudioRTPCDefinition>>.Enumerator enumerator = m_audioRTPCFolderList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				AudioObjectFolder<AudioRTPCDefinition> current = enumerator.Current;
				XmlElement xmlElement = xmlDocument.CreateElement(RTPC_FOLDER_NAME);
				current.c9742307d0830ac7381f2acd66ed5a6e2(xmlElement);
				xmlNode.AppendChild(xmlElement);
				for (int i = 0; i < current.cbd727a994978fbc688a671f62ad6415b.Count; i++)
				{
					AudioRTPCDefinition audioRTPCDefinition = current.cbd727a994978fbc688a671f62ad6415b[i];
					XmlElement xmlElement2 = xmlDocument.CreateElement(RTPC_TAG_NAME);
					xmlElement.AppendChild(xmlElement2);
					audioRTPCDefinition.c9742307d0830ac7381f2acd66ed5a6e2(xmlElement2);
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_00f6;
				}
				continue;
				end_IL_00f6:
				break;
			}
		}
		xmlDocument.Save(cc7ea8535312cfcb86b44db709be0047b);
		c38aeacc59bd560b59403945ae7996d79();
	}

	public override void c38aeacc59bd560b59403945ae7996d79()
	{
		base.c38aeacc59bd560b59403945ae7996d79();
		XmlDocument xmlDocument = AudioResourceHelper.c48358dcd6a2e220a4897f930f2fc7d0b(DEFAULT_RESOURCE_NAME);
		if (xmlDocument == null)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "Loading error: " + DEFAULT_RESOURCE_NAME + " missing");
					return;
				}
			}
		}
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(RTPC_FOLDER_NAME);
		if (elementsByTagName == null)
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
			m_audioRTPCFolderList.Clear();
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				XmlNode xmlNode = elementsByTagName[i];
				AudioObjectFolder<AudioRTPCDefinition> audioObjectFolder = new AudioObjectFolder<AudioRTPCDefinition>();
				audioObjectFolder.cc09306479ed0f9f54a5e4e8dd8d72b99(xmlNode);
				m_audioRTPCFolderList.Add(audioObjectFolder);
				XmlNodeList childNodes = xmlNode.ChildNodes;
				for (int j = 0; j < childNodes.Count; j++)
				{
					XmlNode cab83bba925e6355b7d0df9fe7c31c6e = childNodes[j];
					AudioRTPCDefinition audioRTPCDefinition = new AudioRTPCDefinition();
					audioRTPCDefinition.cc09306479ed0f9f54a5e4e8dd8d72b99(cab83bba925e6355b7d0df9fe7c31c6e);
					c6f49409b2929e4f0c4160ced1e7704fb(audioRTPCDefinition, string.Empty);
					audioObjectFolder.cb5c99fd46b7ccbb8badbe459550dcf36(audioRTPCDefinition);
					audioRTPCDefinition.m_parentFolder = audioObjectFolder;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_00fe;
					}
					continue;
					end_IL_00fe:
					break;
				}
			}
			while (true)
			{
				switch (1)
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
