using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class ExtraAttributeStore
{
	public const string AttrSlotAssetPath = "Settings/ExtraAttrSlot";

	public const string AttrLevelEffectAssetPath = "Settings/ExtraAttrLevelEffect";

	public const string AttrEffectAssetPath = "Settings/ExtraAttrEffect";

	public ExtraAttrSlotSetup m_slotSetups = new ExtraAttrSlotSetup();

	public ExtraAttrLevelEffectSetup m_levelEffectSetups = new ExtraAttrLevelEffectSetup();

	public ExtraAttrEffectSetup m_effectSetups = new ExtraAttrEffectSetup();

	private static ExtraAttributeStore s_extraAttributeStore;

	public static ExtraAttributeStore c2e69c2ee08703c97ae2f380010f975a8
	{
		get
		{
			if (s_extraAttributeStore == null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c6171fdabcac1940c1e7ef3f68862086f();
			}
			return s_extraAttributeStore;
		}
		protected set
		{
			s_extraAttributeStore = value;
		}
	}

	public List<SkillAttributeConfig> c7495388aceb7889e8ef8e2d021bdb97f(WeaponDNA c8845f28fdcd69fafc8894476a17e43db)
	{
		List<SkillAttributeConfig> list = new List<SkillAttributeConfig>();
		for (int i = 0; i < ItemDNA.m_extraEffectNums; i++)
		{
			EffectType effectType = (EffectType)c8845f28fdcd69fafc8894476a17e43db.m_extraEffect[i];
			int num = c8845f28fdcd69fafc8894476a17e43db.m_extraEffectIndex[i];
			SkillAttributeConfig skillAttributeConfig = new SkillAttributeConfig(effectType);
			int num2 = 0;
			while (true)
			{
				if (num2 < m_effectSetups.m_extraAttrEffectList.Length)
				{
					if (m_effectSetups.m_extraAttrEffectList[num2].m_rarity == c8845f28fdcd69fafc8894476a17e43db.c5681693ba1dda13f5ded7392b68c1e19())
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
						if (m_effectSetups.m_extraAttrEffectList[num2].m_effect == effectType)
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
							if (m_effectSetups.m_extraAttrEffectList[num2].m_index == num)
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
								skillAttributeConfig.m_bModified = true;
								skillAttributeConfig.m_affectType = m_effectSetups.m_extraAttrEffectList[num2].m_affectType;
								skillAttributeConfig.m_attrValue = m_effectSetups.m_extraAttrEffectList[num2].m_attributeValue;
								list.Add(skillAttributeConfig);
								break;
							}
						}
					}
					num2++;
					continue;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				break;
			}
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			return list;
		}
	}

	public SkillAttributeConfig c82e31e42e80eaa911946671ffebf023e(WeaponDNA c8845f28fdcd69fafc8894476a17e43db, EffectType c470c62d408de8861af01a7e0dbd93430)
	{
		for (int i = 0; i < c8845f28fdcd69fafc8894476a17e43db.m_extraEffect.Length; i++)
		{
			if (c8845f28fdcd69fafc8894476a17e43db.m_extraEffect[i] != (int)c470c62d408de8861af01a7e0dbd93430)
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
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			for (int j = 0; j < m_effectSetups.m_extraAttrEffectList.Length; j++)
			{
				ExtraAttrEffect extraAttrEffect = m_effectSetups.m_extraAttrEffectList[j];
				if (extraAttrEffect.m_rarity != c8845f28fdcd69fafc8894476a17e43db.c5681693ba1dda13f5ded7392b68c1e19())
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
				if (extraAttrEffect.m_effect != c470c62d408de8861af01a7e0dbd93430)
				{
					continue;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (extraAttrEffect.m_index != c8845f28fdcd69fafc8894476a17e43db.m_extraEffectIndex[i])
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
					SkillAttributeConfig skillAttributeConfig = new SkillAttributeConfig(c470c62d408de8861af01a7e0dbd93430);
					skillAttributeConfig.m_affectType = extraAttrEffect.m_affectType;
					skillAttributeConfig.m_attrValue = extraAttrEffect.m_attributeValue;
					return skillAttributeConfig;
				}
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public void c8c8d8f585c6a5597f327b5f36ac3ed7b(WeaponDNA caedbc1db6c28d44eab6021e7d674eab3)
	{
		List<SkillAttributeConfig> list = c7495388aceb7889e8ef8e2d021bdb97f(caedbc1db6c28d44eab6021e7d674eab3);
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "start output extra effects, this weapon rarity is " + caedbc1db6c28d44eab6021e7d674eab3.c5681693ba1dda13f5ded7392b68c1e19().ToString() + " have ");
		for (int i = 0; i < list.Count; i++)
		{
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
			array[0] = list[i].m_attrType.ToString();
			array[1] = " value ";
			array[2] = list[i].m_attrValue;
			array[3] = " affecttype ";
			array[4] = list[i].m_affectType.ToString();
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array));
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "end output extra effects");
			return;
		}
	}

	private static void c6171fdabcac1940c1e7ef3f68862086f()
	{
		s_extraAttributeStore = new ExtraAttributeStore();
		TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/ExtraAttrSlot") as TextAsset;
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c3e0f3ff92a43708816efe2ca98d704f3.cc1720d05c75832f704b87474932341c3()));
		Stream stream = new MemoryStream(textAsset.bytes);
		try
		{
			s_extraAttributeStore.m_slotSetups = (ExtraAttrSlotSetup)xmlSerializer.Deserialize(stream);
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					((IDisposable)stream).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset);
		TextAsset textAsset2 = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/ExtraAttrLevelEffect") as TextAsset;
		XmlSerializer xmlSerializer2 = new XmlSerializer(Type.GetTypeFromHandle(c53c65e8b0e63d13f4d8be9e7ee299e44.cc1720d05c75832f704b87474932341c3()));
		Stream stream2 = new MemoryStream(textAsset2.bytes);
		try
		{
			s_extraAttributeStore.m_levelEffectSetups = (ExtraAttrLevelEffectSetup)xmlSerializer2.Deserialize(stream2);
			stream2.Close();
		}
		finally
		{
			if (stream2 != null)
			{
				while (true)
				{
					switch (7)
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
		TextAsset textAsset3 = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/ExtraAttrEffect") as TextAsset;
		XmlSerializer xmlSerializer3 = new XmlSerializer(Type.GetTypeFromHandle(c4e7faf4a1125ae7972f54f8036bf8dcc.cc1720d05c75832f704b87474932341c3()));
		Stream stream3 = new MemoryStream(textAsset3.bytes);
		try
		{
			s_extraAttributeStore.m_effectSetups = (ExtraAttrEffectSetup)xmlSerializer3.Deserialize(stream3);
			stream3.Close();
		}
		finally
		{
			if (stream3 != null)
			{
				while (true)
				{
					switch (5)
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
