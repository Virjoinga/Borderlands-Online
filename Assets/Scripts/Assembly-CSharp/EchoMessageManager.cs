using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using UnityEngine;
using XsdSettings;

public class EchoMessageManager : c06ca0e618478c23eba3419653a19760f<EchoMessageManager>
{
	private Dictionary<string, EchoMessage> m_messages = new Dictionary<string, EchoMessage>();

	private void Start()
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/EchoMessages");
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(cd9737f1583136ebed227d3d6120c5abd.cc1720d05c75832f704b87474932341c3()));
		EchoMessagesSetup echoMessagesSetup = xmlSerializer.Deserialize(new StringReader(textAsset.text)) as EchoMessagesSetup;
		Resources.UnloadAsset(textAsset);
		for (int i = 0; i < echoMessagesSetup.m_messages.Length; i++)
		{
			echoMessagesSetup.m_messages[i].m_localizedText = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(echoMessagesSetup.m_messages[i].m_localizedText));
			m_messages.Add(echoMessagesSetup.m_messages[i].m_id, echoMessagesSetup.m_messages[i]);
		}
		while (true)
		{
			switch (1)
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

	public EchoMessage c8c999e73064d771340dff4b02b6cf511(string c63de2eeba7a7020bdb8f0e9d43918973)
	{
		EchoMessage value = c25395d56b1f942dc9eb460a7898b1cf0.c7088de59e49f7108f520cf7e0bae167e;
		m_messages.TryGetValue(c63de2eeba7a7020bdb8f0e9d43918973, out value);
		return value;
	}
}
