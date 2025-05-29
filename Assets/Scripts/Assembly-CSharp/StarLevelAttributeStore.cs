using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class StarLevelAttributeStore
{
	public const string LevelAttributeAssetPath = "Settings/StarLevelAttributeSetup";

	public const string LevelUpgradeAssetPath = "Settings/StarLevelUpgrade";

	public const string ExpUpgradeAssetPath = "Settings/StarExpUpgrade";

	public StarLevelAttributeSetup m_starLevelAttrSetup = new StarLevelAttributeSetup();

	public StarLevelUpgradeSetup m_starLevelUpgradeSetup = new StarLevelUpgradeSetup();

	public StarExpUpgradeSetup m_starExpUpgradeSetup = new StarExpUpgradeSetup();

	private static StarLevelAttributeStore s_starLevelAttributeStore;

	public static StarLevelAttributeStore cecd5638d8f5bf49105ca7c28afbbfba4
	{
		get
		{
			if (s_starLevelAttributeStore == null)
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
				c5694a7c59f02973598b1acd9edb41164();
			}
			return s_starLevelAttributeStore;
		}
		protected set
		{
			s_starLevelAttributeStore = value;
		}
	}

	public List<SingleWeaponAttribute> c0df9dda41628088f6ce9fe9d256faaaa(WeaponType c27b7430edc94b8f5b543605119ec4a72, int cb28988bdc2f2c56c6f1f1f5f12f2f370)
	{
		return m_starLevelAttrSetup.c3c4c965dd8b39195a54e450ba7e26923(c27b7430edc94b8f5b543605119ec4a72, cb28988bdc2f2c56c6f1f1f5f12f2f370);
	}

	public int c15e38327c5b5eed2c917ce1e8b78d24a(WeaponType c27b7430edc94b8f5b543605119ec4a72, int cb28988bdc2f2c56c6f1f1f5f12f2f370, int cd41ab51966c5ff00c67973a4755d4730, WeaponRarity c335b432937e6c5b61e3fce114d6b6ca5)
	{
		return m_starLevelUpgradeSetup.c15e38327c5b5eed2c917ce1e8b78d24a(c27b7430edc94b8f5b543605119ec4a72, cb28988bdc2f2c56c6f1f1f5f12f2f370, cd41ab51966c5ff00c67973a4755d4730, c335b432937e6c5b61e3fce114d6b6ca5);
	}

	public ConsumedMaterial[] c427b782717fb7214fcc0f2cf5778100a(WeaponType c27b7430edc94b8f5b543605119ec4a72)
	{
		return m_starExpUpgradeSetup.c427b782717fb7214fcc0f2cf5778100a(c27b7430edc94b8f5b543605119ec4a72);
	}

	public ItemConsume cd1b950d28832dc51f746809d8f189d68(WeaponType c27b7430edc94b8f5b543605119ec4a72, int cb28988bdc2f2c56c6f1f1f5f12f2f370)
	{
		return m_starLevelUpgradeSetup.cd1b950d28832dc51f746809d8f189d68(c27b7430edc94b8f5b543605119ec4a72, cb28988bdc2f2c56c6f1f1f5f12f2f370);
	}

	private static void c5694a7c59f02973598b1acd9edb41164()
	{
		s_starLevelAttributeStore = new StarLevelAttributeStore();
		if (s_starLevelAttributeStore == null)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/StarLevelAttributeSetup") as TextAsset;
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c7ff5f569397c0e67b42ab89b759d23c9.cc1720d05c75832f704b87474932341c3()));
		Stream stream = new MemoryStream(textAsset.bytes);
		try
		{
			s_starLevelAttributeStore.m_starLevelAttrSetup = (StarLevelAttributeSetup)xmlSerializer.Deserialize(stream);
			stream.Close();
		}
		finally
		{
			if (stream != null)
			{
				while (true)
				{
					switch (1)
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
		TextAsset textAsset2 = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/StarLevelUpgrade") as TextAsset;
		XmlSerializer xmlSerializer2 = new XmlSerializer(Type.GetTypeFromHandle(c2f7ad37534f65f97c3509d488024bf0e.cc1720d05c75832f704b87474932341c3()));
		Stream stream2 = new MemoryStream(textAsset2.bytes);
		try
		{
			s_starLevelAttributeStore.m_starLevelUpgradeSetup = (StarLevelUpgradeSetup)xmlSerializer2.Deserialize(stream2);
			stream2.Close();
		}
		finally
		{
			if (stream2 != null)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					((IDisposable)stream2).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset2);
		TextAsset textAsset3 = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/StarExpUpgrade") as TextAsset;
		XmlSerializer xmlSerializer3 = new XmlSerializer(Type.GetTypeFromHandle(c1b74306644c8dbe20cffebd5f3c208ed.cc1720d05c75832f704b87474932341c3()));
		Stream stream3 = new MemoryStream(textAsset3.bytes);
		try
		{
			s_starLevelAttributeStore.m_starExpUpgradeSetup = (StarExpUpgradeSetup)xmlSerializer3.Deserialize(stream3);
			stream3.Close();
		}
		finally
		{
			if (stream3 != null)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					((IDisposable)stream3).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset3);
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "System.GC.Collect");
		GC.Collect();
	}
}
