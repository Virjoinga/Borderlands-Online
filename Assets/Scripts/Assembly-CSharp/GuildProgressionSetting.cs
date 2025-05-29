using System;
using System.IO;
using System.Xml.Serialization;
using A;
using UnityEngine;
using XsdSettings;

public class GuildProgressionSetting : c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>
{
	public GuildProgression m_progressionSetup = new GuildProgression();

	private void Start()
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/GuildProgression");
		StringReader stringReader = new StringReader(textAsset.text);
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c35fdf1a8fac039eed232fb83b60a97f1.cc1720d05c75832f704b87474932341c3()));
			m_progressionSetup = xmlSerializer.Deserialize(stringReader) as GuildProgression;
		}
		finally
		{
			if (stringReader != null)
			{
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
					((IDisposable)stringReader).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset);
	}

	public GuildSkillData cc5dce38711e2bbea16a914035b5feac4(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (c5612a459a84ffdb41c885401433cd62d >= 0)
		{
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
			if (c5612a459a84ffdb41c885401433cd62d <= m_progressionSetup.m_guildSkills.Length)
			{
				return m_progressionSetup.m_guildSkills[c5612a459a84ffdb41c885401433cd62d];
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		return null;
	}

	public PvEGuildExpFactorDataList cd55fb11a9eb5c38a725c0ab6000bf385()
	{
		return m_progressionSetup.m_guildExpFactors.m_PvEGuildExpFactors;
	}

	public PvPGuildExpFactorDataList c77fe1ac83d798509afba70d186e176bb()
	{
		return m_progressionSetup.m_guildExpFactors.m_PvPGuildExpFactors;
	}
}
