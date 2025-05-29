using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using UnityEngine;
using XsdSettings;

[Serializable]
public class RarityStore
{
	public const string AssetPath = "Assets/Resources/WeaponEditor/Rarity.XML";

	public const string ResourcesAssetPath = "WeaponEditor/Bin/Rarity";

	[SerializeField]
	public List<WeaponRarityAttr> m_weaponRarityAttr = new List<WeaponRarityAttr>();

	private static RarityStore s_rarityStore;

	public static RarityStore rarityStore
	{
		get
		{
			if (s_rarityStore == null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c599ef15da60b8dda61f4bda7adc851b3();
				s_rarityStore.c44f9e79fa85546625edd2986a4083fbf();
			}
			return s_rarityStore;
		}
		protected set
		{
			s_rarityStore = value;
		}
	}

	public RarityStore()
	{
	}

	public RarityStore(bool ccb88cc9ce41c4f9df0c68fa9f9360ffc)
	{
		if (!ccb88cc9ce41c4f9df0c68fa9f9360ffc)
		{
			return;
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
			m_weaponRarityAttr.Clear();
			for (int i = 0; i < 5; i++)
			{
				m_weaponRarityAttr.Add(new WeaponRarityAttr(true, (WeaponType)i));
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

	public void c44f9e79fa85546625edd2986a4083fbf()
	{
		List<WeaponRarityAttr> list = new List<WeaponRarityAttr>();
		for (int i = 0; i < 5; i++)
		{
			WeaponType weaponType = (WeaponType)i;
			int num = m_weaponRarityAttr.FindIndex((WeaponRarityAttr c8afd0d53d6687bf18e0654bc7cf43a65) => c8afd0d53d6687bf18e0654bc7cf43a65.m_weaponType == weaponType);
			if (num >= 0)
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
				list.Add(m_weaponRarityAttr[num]);
			}
			else
			{
				list.Add(new WeaponRarityAttr(true, weaponType));
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			m_weaponRarityAttr = list;
			for (int j = 0; j < m_weaponRarityAttr.Count; j++)
			{
				m_weaponRarityAttr[j].c7a3a9c22cd95b108e71a40ce2ee85008();
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

	public static void c8247be8931d105f752fb9d8392ea62dc()
	{
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(ceb9ee015f9ea7787eca4956b058cf6ec.cc1720d05c75832f704b87474932341c3()));
		TextWriter textWriter = new StreamWriter("Assets/Resources/WeaponEditor/Rarity.XML");
		try
		{
			xmlSerializer.Serialize(textWriter, s_rarityStore);
			textWriter.Close();
		}
		finally
		{
			if (textWriter != null)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					((IDisposable)textWriter).Dispose();
					break;
				}
			}
		}
	}

	private static void c6171fdabcac1940c1e7ef3f68862086f()
	{
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(ceb9ee015f9ea7787eca4956b058cf6ec.cc1720d05c75832f704b87474932341c3()));
		if (!File.Exists("Assets/Resources/WeaponEditor/Rarity.XML"))
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
					s_rarityStore = new RarityStore(true);
					c8247be8931d105f752fb9d8392ea62dc();
					return;
				}
			}
		}
		FileStream fileStream = File.OpenRead("Assets/Resources/WeaponEditor/Rarity.XML");
		try
		{
			s_rarityStore = (RarityStore)xmlSerializer.Deserialize(fileStream);
			fileStream.Close();
		}
		finally
		{
			if (fileStream != null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					((IDisposable)fileStream).Dispose();
					break;
				}
			}
		}
	}

	private static void c599ef15da60b8dda61f4bda7adc851b3()
	{
		TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("WeaponEditor/Bin/Rarity") as TextAsset;
		Stream stream = new MemoryStream(textAsset.bytes);
		BinaryReader binaryReader = new BinaryReader(stream);
		try
		{
			s_rarityStore = new RarityStore(true);
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					int num = 0;
					while (num < 9)
					{
						int num2 = binaryReader.ReadInt32();
						for (int k = 0; k < num2; k++)
						{
							s_rarityStore.m_weaponRarityAttr[i].m_weaponRarityType[j].m_subPartTypes[num].m_subParts.Add(new SubpartChoice());
							s_rarityStore.m_weaponRarityAttr[i].m_weaponRarityType[j].m_subPartTypes[num].m_subParts[k].m_subpartIndex = binaryReader.ReadInt32();
							s_rarityStore.m_weaponRarityAttr[i].m_weaponRarityType[j].m_subPartTypes[num].m_subParts[k].m_probability = binaryReader.ReadSingle();
							s_rarityStore.m_weaponRarityAttr[i].m_weaponRarityType[j].m_subPartTypes[num].m_subParts[k].m_modifier = (ProbabilityModifier)binaryReader.ReadByte();
						}
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
							num++;
							break;
						}
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							goto end_IL_01a4;
						}
						continue;
						end_IL_01a4:
						break;
					}
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						goto end_IL_01bc;
					}
					continue;
					end_IL_01bc:
					break;
				}
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				stream.Dispose();
				binaryReader.Close();
				break;
			}
		}
		finally
		{
			if (binaryReader != null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					((IDisposable)binaryReader).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset);
	}

	public int c3bce211af4ebaab88eaecbd89de457cd(WeaponType c27b7430edc94b8f5b543605119ec4a72, WeaponRarity c5a992ec28dff4a3b9ba8bb92463990a3, WeaponSubPart c740fb87e58adaf9671b066d0900f1176)
	{
		if ((int)c27b7430edc94b8f5b543605119ec4a72 < m_weaponRarityAttr.Count)
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
			if ((int)c5a992ec28dff4a3b9ba8bb92463990a3 < m_weaponRarityAttr[(int)c27b7430edc94b8f5b543605119ec4a72].m_weaponRarityType.Count)
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
				if ((int)c740fb87e58adaf9671b066d0900f1176 < m_weaponRarityAttr[(int)c27b7430edc94b8f5b543605119ec4a72].m_weaponRarityType[(int)c5a992ec28dff4a3b9ba8bb92463990a3].m_subPartTypes.Count)
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
					List<SubpartChoice> list = new List<SubpartChoice>();
					for (int i = 0; i < m_weaponRarityAttr[(int)c27b7430edc94b8f5b543605119ec4a72].m_weaponRarityType[(int)c5a992ec28dff4a3b9ba8bb92463990a3].m_subPartTypes[(int)c740fb87e58adaf9671b066d0900f1176].m_subParts.Count; i++)
					{
						SubpartChoice item = (SubpartChoice)m_weaponRarityAttr[(int)c27b7430edc94b8f5b543605119ec4a72].m_weaponRarityType[(int)c5a992ec28dff4a3b9ba8bb92463990a3].m_subPartTypes[(int)c740fb87e58adaf9671b066d0900f1176].m_subParts[i].Clone();
						list.Add(item);
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					if (list.Count == 0)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							return 0;
						}
					}
					int num = 1;
					if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						EntityPlayer entityPlayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
						if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							num = entityPlayer.m_awesomeLevel;
						}
					}
					float num2 = 0f;
					for (int j = 0; j < list.Count; j++)
					{
						if (list[j].m_modifier == ProbabilityModifier.Square)
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
							list[j].m_probability *= Mathf.Pow(1.05f, num - 1);
						}
						else if (list[j].m_modifier == ProbabilityModifier.MultipleLevel)
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
							list[j].m_probability *= num;
						}
						num2 += list[j].m_probability;
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
					float num3 = UnityEngine.Random.Range(0f, num2);
					float num4 = 0f;
					for (int k = 0; k < list.Count; k++)
					{
						if (num3 >= num4)
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
							if (num3 < num4 + list[k].m_probability)
							{
								while (true)
								{
									switch (2)
									{
									case 0:
										break;
									default:
										return list[k].m_subpartIndex;
									}
								}
							}
						}
						num4 += list[k].m_probability;
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
			}
		}
		return 0;
	}
}
