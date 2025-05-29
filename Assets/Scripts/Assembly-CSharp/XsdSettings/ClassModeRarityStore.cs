using System;
using System.IO;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;

namespace XsdSettings
{
	public class ClassModeRarityStore
	{
		public const string AssetPath = "Assets/Resources/WeaponEditor/ClassModeRarity.XML";

		public const string ResourcesAssetPath = "WeaponEditor/ClassModeRarity";

		public ClassModeRaritySetup m_classModeRaritySetup = new ClassModeRaritySetup();

		private static ClassModeRarityStore s_classModeRarityStore;

		public static ClassModeRarityStore c922af22d5da6d560167ffa19a38beecd
		{
			get
			{
				if (s_classModeRarityStore == null)
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
					c6171fdabcac1940c1e7ef3f68862086f();
				}
				return s_classModeRarityStore;
			}
			protected set
			{
				s_classModeRarityStore = value;
			}
		}

		private static void c6171fdabcac1940c1e7ef3f68862086f()
		{
			s_classModeRarityStore = new ClassModeRarityStore();
			TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("WeaponEditor/ClassModeRarity") as TextAsset;
			XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c9f21a25fd1f9c9da80c074059c0b5774.cc1720d05c75832f704b87474932341c3()));
			Stream stream = new MemoryStream(textAsset.bytes);
			try
			{
				s_classModeRarityStore.m_classModeRaritySetup = (ClassModeRaritySetup)xmlSerializer.Deserialize(stream);
				stream.Close();
			}
			finally
			{
				if (stream != null)
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
						((IDisposable)stream).Dispose();
						break;
					}
				}
			}
			Resources.UnloadAsset(textAsset);
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "System.GC.Collect");
			GC.Collect();
		}

		public int c3bce211af4ebaab88eaecbd89de457cd(ClassModeType c1a9ed24ee3a9dca4f8ac14fd536a001d, ItemRarity c5a992ec28dff4a3b9ba8bb92463990a3, ClassModeSubPart c740fb87e58adaf9671b066d0900f1176)
		{
			if ((int)c1a9ed24ee3a9dca4f8ac14fd536a001d < m_classModeRaritySetup.m_classModeRarities.Length)
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
				if ((int)c5a992ec28dff4a3b9ba8bb92463990a3 < m_classModeRaritySetup.m_classModeRarities[(int)c1a9ed24ee3a9dca4f8ac14fd536a001d].m_raritiyTypes.Length)
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
					if ((int)c740fb87e58adaf9671b066d0900f1176 < m_classModeRaritySetup.m_classModeRarities[(int)c1a9ed24ee3a9dca4f8ac14fd536a001d].m_raritiyTypes[(int)c5a992ec28dff4a3b9ba8bb92463990a3].m_subparts.Length)
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
						for (int i = 0; i < m_classModeRaritySetup.m_classModeRarities.Length; i++)
						{
							if (m_classModeRaritySetup.m_classModeRarities[i].m_classModeType != c1a9ed24ee3a9dca4f8ac14fd536a001d)
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
							for (int j = 0; j < m_classModeRaritySetup.m_classModeRarities[i].m_raritiyTypes.Length; j++)
							{
								if (m_classModeRaritySetup.m_classModeRarities[i].m_raritiyTypes[j].m_rarity != c5a992ec28dff4a3b9ba8bb92463990a3)
								{
									continue;
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
								for (int k = 0; k < m_classModeRaritySetup.m_classModeRarities[i].m_raritiyTypes[j].m_subparts.Length; k++)
								{
									if (m_classModeRaritySetup.m_classModeRarities[i].m_raritiyTypes[j].m_subparts[k].m_classModeSubpart != c740fb87e58adaf9671b066d0900f1176)
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
									float num = 0f;
									ClassModeSubpartChoice[] subpartChoices = m_classModeRaritySetup.m_classModeRarities[i].m_raritiyTypes[j].m_subparts[k].m_subpartChoices;
									foreach (ClassModeSubpartChoice classModeSubpartChoice in subpartChoices)
									{
										num += classModeSubpartChoice.m_probability;
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
									float num2 = UnityEngine.Random.Range(0f, num);
									float num3 = 0f;
									ClassModeSubpartChoice[] subpartChoices2 = m_classModeRaritySetup.m_classModeRarities[i].m_raritiyTypes[j].m_subparts[k].m_subpartChoices;
									foreach (ClassModeSubpartChoice classModeSubpartChoice2 in subpartChoices2)
									{
										if (num2 >= num3)
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
											if (num2 < num3 + classModeSubpartChoice2.m_probability)
											{
												while (true)
												{
													switch (4)
													{
													case 0:
														break;
													default:
														return classModeSubpartChoice2.m_subpartIndex;
													}
												}
											}
										}
										num3 += classModeSubpartChoice2.m_probability;
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
									switch (5)
									{
									case 0:
										continue;
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
								break;
							}
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
				}
			}
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, "Theare are not possibile rarity subpart setup for this classMode, will use subpart 0. rarity:" + c5a992ec28dff4a3b9ba8bb92463990a3.ToString() + ", subpart:" + c740fb87e58adaf9671b066d0900f1176);
			return 0;
		}
	}
}
