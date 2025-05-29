using System;
using System.IO;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;

namespace XsdSettings
{
	public class ShieldRarityStore
	{
		public const string AssetPath = "Assets/Resources/WeaponEditor/ShieldRarity.XML";

		public const string ResourcesAssetPath = "WeaponEditor/ShieldRarity";

		public ShieldRaritySetup m_shieldRaritySetup = new ShieldRaritySetup();

		private static ShieldRarityStore s_shieldRarityStore;

		public static ShieldRarityStore c3c7fc3eebc5708808cd1027e22f609f0
		{
			get
			{
				if (s_shieldRarityStore == null)
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
					c6171fdabcac1940c1e7ef3f68862086f();
				}
				return s_shieldRarityStore;
			}
			protected set
			{
				s_shieldRarityStore = value;
			}
		}

		private static void c6171fdabcac1940c1e7ef3f68862086f()
		{
			s_shieldRarityStore = new ShieldRarityStore();
			TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("WeaponEditor/ShieldRarity") as TextAsset;
			XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c84de81232036ce891e6d20b869c87028.cc1720d05c75832f704b87474932341c3()));
			Stream stream = new MemoryStream(textAsset.bytes);
			try
			{
				s_shieldRarityStore.m_shieldRaritySetup = (ShieldRaritySetup)xmlSerializer.Deserialize(stream);
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

		public int c3bce211af4ebaab88eaecbd89de457cd(ItemRarity c5a992ec28dff4a3b9ba8bb92463990a3, ShieldSubPart c740fb87e58adaf9671b066d0900f1176)
		{
			if ((int)c5a992ec28dff4a3b9ba8bb92463990a3 < m_shieldRaritySetup.m_shieldRarities.Length)
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
				if ((int)c740fb87e58adaf9671b066d0900f1176 < m_shieldRaritySetup.m_shieldRarities[(int)c5a992ec28dff4a3b9ba8bb92463990a3].m_subparts.Length)
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
					for (int i = 0; i < m_shieldRaritySetup.m_shieldRarities.Length; i++)
					{
						if (m_shieldRaritySetup.m_shieldRarities[i].m_rarity != (ShieldRarity)c5a992ec28dff4a3b9ba8bb92463990a3)
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
							break;
						}
						for (int j = 0; j < m_shieldRaritySetup.m_shieldRarities[i].m_subparts.Length; j++)
						{
							if (m_shieldRaritySetup.m_shieldRarities[i].m_subparts[j].m_shieldSubpart != c740fb87e58adaf9671b066d0900f1176)
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
							float num = 0f;
							ShieldSubpartChoice[] subpartChoices = m_shieldRaritySetup.m_shieldRarities[i].m_subparts[j].m_subpartChoices;
							foreach (ShieldSubpartChoice shieldSubpartChoice in subpartChoices)
							{
								num += shieldSubpartChoice.m_probability;
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
							float num2 = UnityEngine.Random.Range(0f, num);
							float num3 = 0f;
							ShieldSubpartChoice[] subpartChoices2 = m_shieldRaritySetup.m_shieldRarities[i].m_subparts[j].m_subpartChoices;
							foreach (ShieldSubpartChoice shieldSubpartChoice2 in subpartChoices2)
							{
								if (num2 >= num3)
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
									if (num2 < num3 + shieldSubpartChoice2.m_probability)
									{
										while (true)
										{
											switch (6)
											{
											case 0:
												break;
											default:
												return shieldSubpartChoice2.m_subpartIndex;
											}
										}
									}
								}
								num3 += shieldSubpartChoice2.m_probability;
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
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
				}
			}
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, "Theare are not possibile rarity subpart setup for this shield, will use subpart 0. rarity:" + c5a992ec28dff4a3b9ba8bb92463990a3.ToString() + ", subpart:" + c740fb87e58adaf9671b066d0900f1176);
			return 0;
		}
	}
}
