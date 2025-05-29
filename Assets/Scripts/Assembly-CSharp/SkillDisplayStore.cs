using System;
using System.IO;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class SkillDisplayStore
{
	public const string ResourcesAssetPath = "Settings/UI_SkillDisplay";

	public UI_SkillDisplaySetup m_skillDisplaySetup = new UI_SkillDisplaySetup();

	private static SkillDisplayStore s_skillDisplayStore;

	public static SkillDisplayStore c44a2b51cbcd8bf73167ba6a2f008a34b
	{
		get
		{
			if (s_skillDisplayStore == null)
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
				c6171fdabcac1940c1e7ef3f68862086f();
			}
			return s_skillDisplayStore;
		}
		protected set
		{
			s_skillDisplayStore = value;
		}
	}

	private static void c6171fdabcac1940c1e7ef3f68862086f()
	{
		s_skillDisplayStore = new SkillDisplayStore();
		TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/UI_SkillDisplay") as TextAsset;
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(cee22423eb022750769f93e9ab1d9c000.cc1720d05c75832f704b87474932341c3()));
		Stream stream = new MemoryStream(textAsset.bytes);
		try
		{
			s_skillDisplayStore.m_skillDisplaySetup = (UI_SkillDisplaySetup)xmlSerializer.Deserialize(stream);
			if (s_skillDisplayStore.m_skillDisplaySetup != null)
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
				s_skillDisplayStore.m_skillDisplaySetup.c205e144c1d26465e00fad0b88805fb6e();
			}
			stream.Close();
		}
		finally
		{
			if (stream != null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					((IDisposable)stream).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset);
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "System.GC.Collect SkillDisplay");
		GC.Collect();
	}
}
