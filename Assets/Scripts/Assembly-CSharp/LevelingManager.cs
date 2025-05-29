using System;
using System.IO;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class LevelingManager : c06ca0e618478c23eba3419653a19760f<LevelingManager>, IDamageListener
{
	public static int MAIL_UNLOCK_LEVEL = 1;

	public static int JOINGUILD_UNLOCK_LEVEL = 1;

	public static int SELLING_UNLOCK_LEVEL = 2;

	public static int CLASSMODESHOP_UNLOCK_LEVEL = 7;

	public static int MELTING_UNLOCK_LEVEL = 2;

	public static int WAREHOUSE_UNLOCK_LEVEL = 3;

	public static int CRAFTING_UNLOCK_LEVEL = 6;

	public static int PVP_UNLOCK_LEVEL = 10;

	public static int UPGRADE_UNLOCK_LEVEL = 18;

	public static int CREATEGUILD_UNLOCK_LEVEL = 7;

	public bool m_giveExpOnKill;

	public PlayerProgressionSetup m_progressionSetup = new PlayerProgressionSetup();

	private void Start()
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/PlayerProgression");
		StringReader stringReader = new StringReader(textAsset.text);
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c951884c359cc5a746511445dea457459.cc1720d05c75832f704b87474932341c3()));
			m_progressionSetup = xmlSerializer.Deserialize(stringReader) as PlayerProgressionSetup;
		}
		finally
		{
			if (stringReader != null)
			{
				while (true)
				{
					switch (6)
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

	public int c39fd4c78a602619219c550a2d33b6cea(AvatarType c951097a6ef3eb670bc38dce2cd336b7a)
	{
		return m_progressionSetup.m_experienceTable[m_progressionSetup.m_experienceTable.Length - 1].m_requiredXp;
	}

	public int c3d4a2204551e355f1fd6519ba35e0de2(AvatarType c951097a6ef3eb670bc38dce2cd336b7a)
	{
		int num = 0;
		switch (c951097a6ef3eb670bc38dce2cd336b7a)
		{
		case AvatarType.BERSERKER:
			num = m_progressionSetup.m_defaultAttribute.BerserkerHP;
			break;
		case AvatarType.HUNTER:
			num = m_progressionSetup.m_defaultAttribute.HunterHP;
			break;
		case AvatarType.SIREN:
			num = m_progressionSetup.m_defaultAttribute.SirenHP;
			break;
		case AvatarType.SOLDIER:
			num = m_progressionSetup.m_defaultAttribute.SoldierHP;
			break;
		}
		return (int)((float)num * m_progressionSetup.m_experienceTable[m_progressionSetup.m_experienceTable.Length - 1].m_powerRating);
	}

	public int c6de0f39084fc3425d6b29d876ff17854()
	{
		return m_progressionSetup.m_experienceTable.Length;
	}

	public int c1ee9148b69b784ee94cf0d54409c8ee0(AvatarType c951097a6ef3eb670bc38dce2cd336b7a, int cf13fd632f93aa296c99679582ff35a65)
	{
		for (int i = 1; i < m_progressionSetup.m_experienceTable.Length; i++)
		{
			if (cf13fd632f93aa296c99679582ff35a65 >= m_progressionSetup.m_experienceTable[i].m_requiredXp)
			{
				continue;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return i;
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return m_progressionSetup.m_experienceTable.Length;
		}
	}

	public int c22535483c584afec3f67e9f95446a8f4(AvatarType c951097a6ef3eb670bc38dce2cd336b7a, int cd6bb591c33b2ee3ab93e98aa43a6da63)
	{
		cd6bb591c33b2ee3ab93e98aa43a6da63--;
		if (cd6bb591c33b2ee3ab93e98aa43a6da63 < m_progressionSetup.m_experienceTable.Length)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return m_progressionSetup.m_experienceTable[cd6bb591c33b2ee3ab93e98aa43a6da63].m_requiredXp;
				}
			}
		}
		return c39fd4c78a602619219c550a2d33b6cea(c951097a6ef3eb670bc38dce2cd336b7a);
	}

	public int c4459dc4cce1d07c3d1484ae8659420f3(AvatarType c951097a6ef3eb670bc38dce2cd336b7a, int cd6bb591c33b2ee3ab93e98aa43a6da63)
	{
		cd6bb591c33b2ee3ab93e98aa43a6da63--;
		if (cd6bb591c33b2ee3ab93e98aa43a6da63 < m_progressionSetup.m_experienceTable.Length)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					int num = 0;
					switch (c951097a6ef3eb670bc38dce2cd336b7a)
					{
					case AvatarType.BERSERKER:
						num = m_progressionSetup.m_defaultAttribute.BerserkerHP;
						break;
					case AvatarType.HUNTER:
						num = m_progressionSetup.m_defaultAttribute.HunterHP;
						break;
					case AvatarType.SIREN:
						num = m_progressionSetup.m_defaultAttribute.SirenHP;
						break;
					case AvatarType.SOLDIER:
						num = m_progressionSetup.m_defaultAttribute.SoldierHP;
						break;
					}
					float num2 = (float)num * m_progressionSetup.m_experienceTable[cd6bb591c33b2ee3ab93e98aa43a6da63].m_powerRating;
					return (int)num2;
				}
				}
			}
		}
		return c3d4a2204551e355f1fd6519ba35e0de2(c951097a6ef3eb670bc38dce2cd336b7a);
	}

	public float c0ebc9ff966482c92935f5b954e66a18b(int cc94be3685c24bbbca06b26f5dc51a92c)
	{
		cc94be3685c24bbbca06b26f5dc51a92c--;
		if (cc94be3685c24bbbca06b26f5dc51a92c < m_progressionSetup.m_experienceTable.Length)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return m_progressionSetup.m_experienceTable[cc94be3685c24bbbca06b26f5dc51a92c].m_powerRating;
				}
			}
		}
		return c5216004c85993c1fca7ac1d94a5ab8d1();
	}

	public float c5216004c85993c1fca7ac1d94a5ab8d1()
	{
		return m_progressionSetup.m_experienceTable[m_progressionSetup.m_experienceTable.Length - 1].m_powerRating;
	}

	public void OnDamaged(DamageContext context)
	{
	}

	public void OnEntityKill(KillContext context)
	{
	}

	private void OnLevelUp(PlayerInfoSync player)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "LevelUP");
		if (!(player != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
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
			Entity entity = player.c66b232dbebded7c7e9a89c1e8bd84689();
			if (!(entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				return;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				AvatarType c951097a6ef3eb670bc38dce2cd336b7a = player.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a();
				EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = entity.c5ca38fad98337fc5c7255384b2cd1a86() as EquipmentInventoryEntityPlayer;
				if (!(equipmentInventoryEntityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					return;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					int cd6bb591c33b2ee3ab93e98aa43a6da = c1ee9148b69b784ee94cf0d54409c8ee0(c951097a6ef3eb670bc38dce2cd336b7a, player.m_exp);
					equipmentInventoryEntityPlayer.c34fa9ca078c2cc90fb0cae8284ed10d7(c4459dc4cce1d07c3d1484ae8659420f3(c951097a6ef3eb670bc38dce2cd336b7a, cd6bb591c33b2ee3ab93e98aa43a6da));
					if (NetworkManager.c449802e708e91a9150466060fbab2ad6())
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
						if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_offlineMode)
						{
							return;
						}
						while (true)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					if (!player.c16d1154aec91a0f8f4a52d77fc081194())
					{
						return;
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPlayerInfoView>().cacb0973399bda5328a4e13f27d851fdb(c1ee9148b69b784ee94cf0d54409c8ee0(c951097a6ef3eb670bc38dce2cd336b7a, player.m_exp));
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPlayerInfoView>().c722314920476b2c350e95cac25fa5871(c1ee9148b69b784ee94cf0d54409c8ee0(c951097a6ef3eb670bc38dce2cd336b7a, player.m_exp));
						return;
					}
				}
			}
		}
	}
}
