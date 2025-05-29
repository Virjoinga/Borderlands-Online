using System;
using System.IO;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class CraftingServiceWrapper : ServiceWrapper<IServiceWrapper, CraftingServiceWrapper>
{
	public WeaponMeltManager m_meltMgr;

	public WeaponCraftManager m_craftMgr;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/WeaponMelting");
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(cdc2a4e2be7c5b83aa4dd68ab562f7ce6.cc1720d05c75832f704b87474932341c3()));
		m_meltMgr = xmlSerializer.Deserialize(new StringReader(textAsset.text)) as WeaponMeltManager;
		Resources.UnloadAsset(textAsset);
		textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/WeaponCrafting");
		xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c1a491031818854580286f624b6873836.cc1720d05c75832f704b87474932341c3()));
		m_craftMgr = xmlSerializer.Deserialize(new StringReader(textAsset.text)) as WeaponCraftManager;
		Resources.UnloadAsset(textAsset);
	}

	public AcquiredMaterial[] c8f918c4274c34c1d3e8adb2ea8dd8022(WeaponDNA cbda03aa3bdab3eefdc618fdc810106b4)
	{
		if (cbda03aa3bdab3eefdc618fdc810106b4 != null)
		{
			while (true)
			{
				switch (1)
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
			if (m_meltMgr != null)
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
				if (m_meltMgr.m_WeaponMeltConfigs != null)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					for (int i = 0; i < m_meltMgr.m_WeaponMeltConfigs.Length; i++)
					{
						if (cbda03aa3bdab3eefdc618fdc810106b4.m_level < m_meltMgr.m_WeaponMeltConfigs[i].m_MinWeaponLevel)
						{
							continue;
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
						if (cbda03aa3bdab3eefdc618fdc810106b4.m_level > m_meltMgr.m_WeaponMeltConfigs[i].m_MaxWeaponLevel)
						{
							continue;
						}
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						if (cbda03aa3bdab3eefdc618fdc810106b4.m_rarity != m_meltMgr.m_WeaponMeltConfigs[i].m_WeaponRarity)
						{
							continue;
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
						if (cbda03aa3bdab3eefdc618fdc810106b4.m_type != m_meltMgr.m_WeaponMeltConfigs[i].m_WeaponType)
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
							return m_meltMgr.m_WeaponMeltConfigs[i].m_AcquiredMaterials;
						}
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
				}
			}
		}
		else
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "the melted weapon is not exist or it dosen't have DNA");
		}
		return null;
	}

	public override bool c39df47367fa21412aabfef05d9972f8c()
	{
		return true;
	}

	public void c2b738a0787415710b9ab86768a28207d(OnSmeltWeapon c2db84530ef366a6deb001d449d4aa151, int cd27037dd3bf1006e6e39ebf89cbd7b03)
	{
		OnAccessSingleton<ICraftingService, CraftingService, CraftingServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c2b738a0787415710b9ab86768a28207d(c2db84530ef366a6deb001d449d4aa151, cd27037dd3bf1006e6e39ebf89cbd7b03);
	}

	public void c99dc1247f2835cc10ef79f23e75449c8(OnCraftWeapon c2db84530ef366a6deb001d449d4aa151, WeaponType c27b7430edc94b8f5b543605119ec4a72)
	{
		OnAccessSingleton<ICraftingService, CraftingService, CraftingServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c99dc1247f2835cc10ef79f23e75449c8(c2db84530ef366a6deb001d449d4aa151, c27b7430edc94b8f5b543605119ec4a72);
	}

	public void cd5ebddd4f7d88647487b39fa8b1ae798(OnGetMyCraftedWeapons c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<ICraftingService, CraftingService, CraftingServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cd5ebddd4f7d88647487b39fa8b1ae798(c2db84530ef366a6deb001d449d4aa151);
	}
}
