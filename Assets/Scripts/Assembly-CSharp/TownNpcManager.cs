using System;
using System.IO;
using System.Xml.Serialization;
using A;
using UnityEngine;
using XsdSettings;

public class TownNpcManager : c06ca0e618478c23eba3419653a19760f<TownNpcManager>
{
	public TownNpcSetup m_npcsSetup;

	private void Start()
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/TownNpcSetup");
		StringReader stringReader = new StringReader(textAsset.text);
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c1cbafdc56016e2c59d712e583f56df90.cc1720d05c75832f704b87474932341c3()));
			m_npcsSetup = xmlSerializer.Deserialize(stringReader) as TownNpcSetup;
		}
		finally
		{
			if (stringReader != null)
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
					((IDisposable)stringReader).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset);
	}

	public XsdSettings.TownNpc ccbe5d1e1f0775e8297e932586eaf130f(int c8ec990d5544137f3982e5f5cefbe2bb5)
	{
		for (int i = 0; i < m_npcsSetup.m_npcs.Length; i++)
		{
			if (m_npcsSetup.m_npcs[i].m_id != c8ec990d5544137f3982e5f5cefbe2bb5)
			{
				continue;
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
				return m_npcsSetup.m_npcs[i];
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public NpcTitleMgr.NPC_ICON_TYPE c4853bb633cd73a41e5f8cedf7e0668ae(int cd65cbd799175f1375d6ecf8d91f04e56)
	{
		NpcTitleMgr.NPC_ICON_TYPE nPC_ICON_TYPE = QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().cb2eb54c3368a58ea14ecbe8882783c55(cd65cbd799175f1375d6ecf8d91f04e56);
		if (nPC_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE)
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
			XsdSettings.TownNpc townNpc = ccbe5d1e1f0775e8297e932586eaf130f(cd65cbd799175f1375d6ecf8d91f04e56);
			if (townNpc != null)
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
				if (townNpc.m_occupations != null)
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
					if (townNpc.m_occupations.Length > 0)
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
						switch (townNpc.m_occupations[0])
						{
						case NpcOccupation.Crafting:
						case NpcOccupation.Melting:
							nPC_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_CRAFT;
							break;
						case NpcOccupation.Guild:
							nPC_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_GUILD;
							break;
						case NpcOccupation.Mail:
						{
							int num;
							if (c1ee7921b0c3cce194fb7cae41b5a9d82<MailServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7115852a11d7d7b2222deb4caf2937ed() > 0)
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
								num = 12;
							}
							else
							{
								num = 11;
							}
							nPC_ICON_TYPE = (NpcTitleMgr.NPC_ICON_TYPE)num;
							break;
						}
						case NpcOccupation.CoinShieldShop:
						case NpcOccupation.ClassModeShop:
						case NpcOccupation.WeaponShop:
							nPC_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SHOP;
							break;
						case NpcOccupation.Warehouse:
							nPC_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_WAREHOUSE;
							break;
						case NpcOccupation.WeaponUpgrade:
							nPC_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_UPGRADE;
							break;
						}
					}
				}
			}
		}
		return nPC_ICON_TYPE;
	}
}
