using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using A;
using UnityEngine;
using XsdSettings;

public class BinaryLotGenerator
{
	internal abstract class BinaryGenerator
	{
		protected TextAsset textAsset;

		protected string input;

		protected string output;

		protected string filter;

		public bool ca3f160af19a466b44682674cd8630ec6(string cad81294edeb19af379ad80a7ec73e394)
		{
			textAsset = Resources.LoadAssetAtPath(cad81294edeb19af379ad80a7ec73e394, Type.GetTypeFromHandle(cda4706963b5b94cc26d866126dd86f9c.cc1720d05c75832f704b87474932341c3())) as TextAsset;
			return c846c1ae2a4dd6b46625f5bbdf334b1a9();
		}

		public string[] cf5e48405ae73609373e12ae1c2108b6c()
		{
			return Directory.GetFiles(input, filter);
		}

		protected FileStream c6262cfabd0191048688ff6119f43ba97(string cdbee49fe29de456df5bf99adb8c01e72)
		{
			string path = cdbee49fe29de456df5bf99adb8c01e72 + textAsset.name + ".bytes";
			if (File.Exists(path))
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
				File.SetAttributes(path, FileAttributes.Normal);
				File.Delete(path);
			}
			return File.Open(path, FileMode.Create);
		}

		protected abstract bool c846c1ae2a4dd6b46625f5bbdf334b1a9();

		public abstract void c027cd496d170349393a89eb7936d8536();
	}

	internal class BktBinaryGenerator : BinaryGenerator
	{
		private ComposableCharacter m_character;

		public BktBinaryGenerator()
		{
			input = "Assets/Resources/BuildingKit/Xml/";
			output = "Assets/Resources/BuildingKit/";
			filter = "BKT_*.xml";
		}

		protected override bool c846c1ae2a4dd6b46625f5bbdf334b1a9()
		{
			bool result = false;
			MemoryStream memoryStream = new MemoryStream(textAsset.bytes);
			try
			{
				try
				{
					XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c8303b7077ef3d5d476d3998c827b8358.cc1720d05c75832f704b87474932341c3()));
					m_character = (ComposableCharacter)xmlSerializer.Deserialize(memoryStream);
					result = true;
				}
				catch
				{
				}
				finally
				{
					memoryStream.Close();
					Resources.UnloadAsset(textAsset);
				}
			}
			finally
			{
				if (memoryStream != null)
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
						((IDisposable)memoryStream).Dispose();
						break;
					}
				}
			}
			return result;
		}

		public override void c027cd496d170349393a89eb7936d8536()
		{
			Stream stream = c6262cfabd0191048688ff6119f43ba97(output);
			BinaryWriter binaryWriter = new BinaryWriter(stream);
			try
			{
				binaryWriter.Write(m_character.bkID);
				binaryWriter.Write(m_character.m_sTypeName.Length);
				binaryWriter.Write(Encoding.Unicode.GetBytes(m_character.m_sTypeName));
				binaryWriter.Write(m_character.m_sCharacterName.Length);
				binaryWriter.Write(Encoding.Unicode.GetBytes(m_character.m_sCharacterName));
				binaryWriter.Write(m_character.m_sSkeletonName.Length);
				binaryWriter.Write(Encoding.Unicode.GetBytes(m_character.m_sSkeletonName));
				c5a7c6dddc3c8a0ed0449e4b810bbc168(binaryWriter, m_character.m_aParts.ToArray());
				stream.Dispose();
				binaryWriter.Close();
			}
			finally
			{
				if (binaryWriter != null)
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
						((IDisposable)binaryWriter).Dispose();
						break;
					}
				}
			}
		}

		private void c5a7c6dddc3c8a0ed0449e4b810bbc168(BinaryWriter cf091eb31c92344c44853475890b1e534, ComposablePart[] c6cec8ea8e5cb32da380065ffbbfa047f)
		{
			cf091eb31c92344c44853475890b1e534.Write(c6cec8ea8e5cb32da380065ffbbfa047f.Length);
			for (int i = 0; i < c6cec8ea8e5cb32da380065ffbbfa047f.Length; i++)
			{
				cf091eb31c92344c44853475890b1e534.Write(c6cec8ea8e5cb32da380065ffbbfa047f[i].m_sPartName.Length);
				cf091eb31c92344c44853475890b1e534.Write(Encoding.Unicode.GetBytes(c6cec8ea8e5cb32da380065ffbbfa047f[i].m_sPartName));
				c2c9f0661f760c874aac305c1c51b6777(cf091eb31c92344c44853475890b1e534, c6cec8ea8e5cb32da380065ffbbfa047f[i].m_aFbxs.ToArray());
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
				return;
			}
		}

		private void c2c9f0661f760c874aac305c1c51b6777(BinaryWriter cf091eb31c92344c44853475890b1e534, ComposableFBX[] c4e02c123f3436505f18aeedd1fa25d62)
		{
			cf091eb31c92344c44853475890b1e534.Write(c4e02c123f3436505f18aeedd1fa25d62.Length);
			for (int i = 0; i < c4e02c123f3436505f18aeedd1fa25d62.Length; i++)
			{
				cf091eb31c92344c44853475890b1e534.Write(c4e02c123f3436505f18aeedd1fa25d62[i].m_sFileName.Length);
				cf091eb31c92344c44853475890b1e534.Write(Encoding.Unicode.GetBytes(c4e02c123f3436505f18aeedd1fa25d62[i].m_sFileName));
				c1fdfb3c961fbac6083b3e48c2cd16e3a(cf091eb31c92344c44853475890b1e534, c4e02c123f3436505f18aeedd1fa25d62[i].m_aMaterials.ToArray());
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
				return;
			}
		}

		private void c1fdfb3c961fbac6083b3e48c2cd16e3a(BinaryWriter cf091eb31c92344c44853475890b1e534, ComposableMaterial[] c1c9974c0ef535b4b38bf8ddbb79d6700)
		{
			cf091eb31c92344c44853475890b1e534.Write(c1c9974c0ef535b4b38bf8ddbb79d6700.Length);
			int num = 0;
			while (num < c1c9974c0ef535b4b38bf8ddbb79d6700.Length)
			{
				cf091eb31c92344c44853475890b1e534.Write(c1c9974c0ef535b4b38bf8ddbb79d6700[num].m_sMaterial.Length);
				cf091eb31c92344c44853475890b1e534.Write(Encoding.Unicode.GetBytes(c1c9974c0ef535b4b38bf8ddbb79d6700[num].m_sMaterial));
				cf091eb31c92344c44853475890b1e534.Write(c1c9974c0ef535b4b38bf8ddbb79d6700[num].m_sShader.Length);
				cf091eb31c92344c44853475890b1e534.Write(Encoding.Unicode.GetBytes(c1c9974c0ef535b4b38bf8ddbb79d6700[num].m_sShader));
				cf091eb31c92344c44853475890b1e534.Write(c1c9974c0ef535b4b38bf8ddbb79d6700[num].m_sTexName.Count);
				for (int i = 0; i < c1c9974c0ef535b4b38bf8ddbb79d6700[num].m_sTexName.Count; i++)
				{
					cf091eb31c92344c44853475890b1e534.Write(c1c9974c0ef535b4b38bf8ddbb79d6700[num].m_sTexName[i].Length);
					cf091eb31c92344c44853475890b1e534.Write(Encoding.Unicode.GetBytes(c1c9974c0ef535b4b38bf8ddbb79d6700[num].m_sTexName[i]));
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
					cf091eb31c92344c44853475890b1e534.Write(c1c9974c0ef535b4b38bf8ddbb79d6700[num].m_sTexFileName.Count);
					for (int j = 0; j < c1c9974c0ef535b4b38bf8ddbb79d6700[num].m_sTexFileName.Count; j++)
					{
						cf091eb31c92344c44853475890b1e534.Write(c1c9974c0ef535b4b38bf8ddbb79d6700[num].m_sTexFileName[j].Length);
						cf091eb31c92344c44853475890b1e534.Write(Encoding.Unicode.GetBytes(c1c9974c0ef535b4b38bf8ddbb79d6700[num].m_sTexFileName[j]));
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							goto end_IL_0165;
						}
						continue;
						end_IL_0165:
						break;
					}
					ca4087de68d93982ba2cd096a9bb2de57(cf091eb31c92344c44853475890b1e534, c1c9974c0ef535b4b38bf8ddbb79d6700[num].m_sShaderProperties.ToArray());
					num++;
					break;
				}
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}

		private void ca4087de68d93982ba2cd096a9bb2de57(BinaryWriter cf091eb31c92344c44853475890b1e534, ShaderProperty[] c607c1382dfb8a835e49f4838e1637e04)
		{
			cf091eb31c92344c44853475890b1e534.Write(c607c1382dfb8a835e49f4838e1637e04.Length);
			for (int i = 0; i < c607c1382dfb8a835e49f4838e1637e04.Length; i++)
			{
				cf091eb31c92344c44853475890b1e534.Write((byte)c607c1382dfb8a835e49f4838e1637e04[i].mType);
				cf091eb31c92344c44853475890b1e534.Write(c607c1382dfb8a835e49f4838e1637e04[i].mName.Length);
				cf091eb31c92344c44853475890b1e534.Write(Encoding.Unicode.GetBytes(c607c1382dfb8a835e49f4838e1637e04[i].mName));
				cf091eb31c92344c44853475890b1e534.Write(c607c1382dfb8a835e49f4838e1637e04[i].mDesc.Length);
				cf091eb31c92344c44853475890b1e534.Write(Encoding.Unicode.GetBytes(c607c1382dfb8a835e49f4838e1637e04[i].mDesc));
				cf091eb31c92344c44853475890b1e534.Write(c607c1382dfb8a835e49f4838e1637e04[i].mValue.Length);
				cf091eb31c92344c44853475890b1e534.Write(Encoding.Unicode.GetBytes(c607c1382dfb8a835e49f4838e1637e04[i].mValue));
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
				return;
			}
		}
	}

	internal class PresetWpnBinaryGenerator : BinaryGenerator
	{
		private WeaponDNA[] m_weapons;

		public PresetWpnBinaryGenerator()
		{
			input = "Assets/Resources/WeaponEditor/";
			output = "Assets/Resources/WeaponEditor/Bin/";
			filter = "Preset_Weapons*.xml";
		}

		protected override bool c846c1ae2a4dd6b46625f5bbdf334b1a9()
		{
			bool result = false;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(textAsset.text);
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("Weapon");
			try
			{
				m_weapons = ce76974377b1b0ebb92a9280be375eb48.c0a0cdf4a196914163f7334d9b0781a04(elementsByTagName.Count);
				int num = 0;
				IEnumerator enumerator = elementsByTagName.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						WeaponType weaponType = (WeaponType)(int)Enum.Parse(Type.GetTypeFromHandle(cb69030d5cbca58447fc871be9aade1a0.cc1720d05c75832f704b87474932341c3()), xmlNode.Attributes["type"].Value);
						WeaponDNA weaponDNA = new WeaponDNA();
						weaponDNA.m_name = xmlNode.Attributes["name"].Value;
						weaponDNA.m_id = Convert.ToInt32(xmlNode.Attributes["id"].Value);
						weaponDNA.m_type = weaponType;
						weaponDNA.m_rarity = (WeaponRarity)(int)Enum.Parse(Type.GetTypeFromHandle(c7035278b710159f614630f761d2ec0d0.cc1720d05c75832f704b87474932341c3()), xmlNode.Attributes["raritytype"].Value);
						weaponDNA.m_level = Convert.ToInt32(xmlNode.Attributes["level"].Value);
						int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(9);
						if (xmlNode.Attributes["ExtraSlot"] != null)
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
							if (xmlNode.Attributes["ExtraSlot"].Value != null)
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
								weaponDNA.m_extraEffectCount = Convert.ToInt32(xmlNode.Attributes["ExtraSlot"].Value);
								List<EffectType> list = new List<EffectType>();
								if (weaponDNA.m_extraEffectCount > 0)
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
									int num2 = 0;
									for (int i = 0; i < weaponDNA.m_extraEffectCount; i++)
									{
										string name = "EffectType" + (i + 1);
										if (xmlNode.Attributes[name] == null)
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
										if (xmlNode.Attributes[name].Value == null)
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
										EffectType effectType = (EffectType)(int)Enum.Parse(Type.GetTypeFromHandle(c494d7a9577f7e64983f9c532ef82600b.cc1720d05c75832f704b87474932341c3()), xmlNode.Attributes[name].Value);
										weaponDNA.m_extraEffect[i] = (int)effectType;
										list.Add(effectType);
										num2++;
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
									if (weaponDNA.m_extraEffectCount - num2 > 0)
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
										int[] array2 = ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.m_levelEffectSetups.cb5ca053b99d0243a3db761c01bcca458(weaponDNA.c5681693ba1dda13f5ded7392b68c1e19(), weaponDNA.m_level, weaponDNA.m_extraEffectCount - num2, list);
										for (int j = 0; j < weaponDNA.m_extraEffectCount - num2; j++)
										{
											weaponDNA.m_extraEffect[j + num2] = array2[j];
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
									}
									weaponDNA.m_extraEffectIndex = ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.m_effectSetups.c7f598feb0b9cb42385696406189e52a3(weaponDNA.c5681693ba1dda13f5ded7392b68c1e19(), weaponDNA.m_extraEffect);
								}
							}
						}
						IEnumerator enumerator2 = Enum.GetValues(Type.GetTypeFromHandle(cbd6d334b1b2c7df454eca020d8c24cc2.cc1720d05c75832f704b87474932341c3())).GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								WeaponSubPart weaponSubPart = (WeaponSubPart)(int)enumerator2.Current;
								if (weaponSubPart == WeaponSubPart.MAX)
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
								}
								else
								{
									SubPartWpn subPartWpn = new SubPartWpn(weaponType, weaponSubPart);
									subPartWpn.m_Index = Convert.ToInt32(xmlNode.Attributes[Enum.GetName(Type.GetTypeFromHandle(cbd6d334b1b2c7df454eca020d8c24cc2.cc1720d05c75832f704b87474932341c3()), weaponSubPart)].Value);
									array[(int)weaponSubPart] = subPartWpn.GetHashCode();
								}
							}
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									goto end_IL_0430;
								}
								continue;
								end_IL_0430:
								break;
							}
						}
						finally
						{
							IDisposable disposable = enumerator2 as IDisposable;
							if (disposable == null)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
										goto end_IL_0449;
									}
									continue;
									end_IL_0449:
									break;
								}
							}
							else
							{
								disposable.Dispose();
							}
						}
						weaponDNA.m_subPartsCode = array;
						m_weapons[num] = weaponDNA;
						num++;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							goto end_IL_0481;
						}
						continue;
						end_IL_0481:
						break;
					}
				}
				finally
				{
					IDisposable disposable2 = enumerator as IDisposable;
					if (disposable2 == null)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								goto end_IL_049a;
							}
							continue;
							end_IL_049a:
							break;
						}
					}
					else
					{
						disposable2.Dispose();
					}
				}
				result = true;
			}
			catch
			{
			}
			finally
			{
				Resources.UnloadAsset(textAsset);
			}
			return result;
		}

		public override void c027cd496d170349393a89eb7936d8536()
		{
			Stream stream = c6262cfabd0191048688ff6119f43ba97(output);
			BinaryWriter binaryWriter = new BinaryWriter(stream);
			try
			{
				binaryWriter.Write(m_weapons.Length);
				int num = 0;
				while (num < m_weapons.Length)
				{
					binaryWriter.Write(m_weapons[num].m_name);
					binaryWriter.Write(m_weapons[num].m_id);
					binaryWriter.Write((byte)m_weapons[num].m_type);
					binaryWriter.Write((byte)m_weapons[num].m_rarity);
					binaryWriter.Write(m_weapons[num].m_level);
					binaryWriter.Write(m_weapons[num].m_extraEffectCount);
					for (int i = 0; i < ItemDNA.m_extraEffectNums; i++)
					{
						binaryWriter.Write(m_weapons[num].m_extraEffect[i]);
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						for (int j = 0; j < ItemDNA.m_extraEffectNums; j++)
						{
							binaryWriter.Write(m_weapons[num].m_extraEffectIndex[j]);
						}
						while (true)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							for (int k = 0; k < m_weapons[num].m_subPartsCode.Length; k++)
							{
								binaryWriter.Write(m_weapons[num].m_subPartsCode[k]);
							}
							while (true)
							{
								switch (7)
								{
								case 0:
									break;
								default:
									goto end_IL_0141;
								}
								continue;
								end_IL_0141:
								break;
							}
							num++;
							break;
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
					stream.Dispose();
					binaryWriter.Close();
					return;
				}
			}
			finally
			{
				if (binaryWriter != null)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						((IDisposable)binaryWriter).Dispose();
						break;
					}
				}
			}
		}
	}

	internal class SubPartsBinaryGenerator : BinaryGenerator
	{
		private SubPartStoreSetup m_setup;

		public SubPartsBinaryGenerator()
		{
			input = "Assets/Resources/WeaponEditor/";
			output = "Assets/Resources/WeaponEditor/Bin/";
			filter = "SubParts_*.xml";
		}

		protected override bool c846c1ae2a4dd6b46625f5bbdf334b1a9()
		{
			bool result = false;
			Stream stream = new MemoryStream(textAsset.bytes);
			try
			{
				try
				{
					XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(cc8b66103e6ab26be7636126ff0248621.cc1720d05c75832f704b87474932341c3()));
					m_setup = (SubPartStoreSetup)xmlSerializer.Deserialize(stream);
					result = true;
				}
				catch
				{
				}
				finally
				{
					stream.Close();
					Resources.UnloadAsset(textAsset);
				}
			}
			finally
			{
				if (stream != null)
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
						((IDisposable)stream).Dispose();
						break;
					}
				}
			}
			return result;
		}

		public override void c027cd496d170349393a89eb7936d8536()
		{
			Stream stream = c6262cfabd0191048688ff6119f43ba97(output);
			BinaryWriter binaryWriter = new BinaryWriter(stream);
			try
			{
				binaryWriter.Write(m_setup.m_subParts.Length);
				for (int i = 0; i < m_setup.m_subParts.Length; i++)
				{
					binaryWriter.Write(m_setup.m_subParts[i].m_Index);
					binaryWriter.Write((byte)m_setup.m_subParts[i].m_weaponType);
					binaryWriter.Write((byte)m_setup.m_subParts[i].m_partType);
					binaryWriter.Write(m_setup.m_subParts[i].m_BuildingPart.bkID);
					binaryWriter.Write(m_setup.m_subParts[i].m_BuildingPart.mPart);
					binaryWriter.Write(m_setup.m_subParts[i].m_BuildingPart.mFBX);
					binaryWriter.Write(m_setup.m_subParts[i].m_BuildingPart.mMat);
					binaryWriter.Write(m_setup.m_subParts[i].m_partName);
					binaryWriter.Write(m_setup.m_subParts[i].m_namePriority);
					cfecf688ec7453818d02b0427849eee99(binaryWriter, m_setup.m_subParts[i].m_Attributes);
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
					stream.Dispose();
					binaryWriter.Close();
					return;
				}
			}
			finally
			{
				if (binaryWriter != null)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						((IDisposable)binaryWriter).Dispose();
						break;
					}
				}
			}
		}

		private void cfecf688ec7453818d02b0427849eee99(BinaryWriter cf091eb31c92344c44853475890b1e534, BOLAttribute[] cec78b0b10bdd29e178920658b90dae6e)
		{
			if (cec78b0b10bdd29e178920658b90dae6e == null)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						cf091eb31c92344c44853475890b1e534.Write(0);
						return;
					}
				}
			}
			cf091eb31c92344c44853475890b1e534.Write(cec78b0b10bdd29e178920658b90dae6e.Length);
			for (int i = 0; i < cec78b0b10bdd29e178920658b90dae6e.Length; i++)
			{
				cf091eb31c92344c44853475890b1e534.Write((byte)cec78b0b10bdd29e178920658b90dae6e[i].m_attributeType);
				cf091eb31c92344c44853475890b1e534.Write((byte)cec78b0b10bdd29e178920658b90dae6e[i].m_attributeValue.m_type);
				cf091eb31c92344c44853475890b1e534.Write((byte)cec78b0b10bdd29e178920658b90dae6e[i].m_attributeValue.m_affectType);
				cf091eb31c92344c44853475890b1e534.Write(cec78b0b10bdd29e178920658b90dae6e[i].m_attributeValue.c4e0f63f4b4d409c5e3992c71520e30a0());
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	internal class RarityBinaryGenerator : BinaryGenerator
	{
		private RarityStore m_rarity;

		public RarityBinaryGenerator()
		{
			input = "Assets/Resources/WeaponEditor/";
			output = "Assets/Resources/WeaponEditor/Bin/";
			filter = "Rarity.xml";
		}

		protected override bool c846c1ae2a4dd6b46625f5bbdf334b1a9()
		{
			bool result = false;
			MemoryStream memoryStream = new MemoryStream(textAsset.bytes);
			try
			{
				try
				{
					XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(ceb9ee015f9ea7787eca4956b058cf6ec.cc1720d05c75832f704b87474932341c3()));
					m_rarity = (RarityStore)xmlSerializer.Deserialize(memoryStream);
					result = true;
				}
				catch
				{
				}
				finally
				{
					memoryStream.Close();
					Resources.UnloadAsset(textAsset);
				}
			}
			finally
			{
				if (memoryStream != null)
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
						((IDisposable)memoryStream).Dispose();
						break;
					}
				}
			}
			return result;
		}

		public override void c027cd496d170349393a89eb7936d8536()
		{
			Stream stream = c6262cfabd0191048688ff6119f43ba97(output);
			BinaryWriter binaryWriter = new BinaryWriter(stream);
			try
			{
				for (int i = 0; i < 5; i++)
				{
					for (int j = 0; j < 6; j++)
					{
						int num = 0;
						while (num < 9)
						{
							int count = m_rarity.m_weaponRarityAttr[i].m_weaponRarityType[j].m_subPartTypes[num].m_subParts.Count;
							binaryWriter.Write(count);
							for (int k = 0; k < count; k++)
							{
								binaryWriter.Write(m_rarity.m_weaponRarityAttr[i].m_weaponRarityType[j].m_subPartTypes[num].m_subParts[k].m_subpartIndex);
								binaryWriter.Write(m_rarity.m_weaponRarityAttr[i].m_weaponRarityType[j].m_subPartTypes[num].m_subParts[k].m_probability);
								binaryWriter.Write((byte)m_rarity.m_weaponRarityAttr[i].m_weaponRarityType[j].m_subPartTypes[num].m_subParts[k].m_modifier);
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
								num++;
								break;
							}
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								goto end_IL_017e;
							}
							continue;
							end_IL_017e:
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
							goto end_IL_0193;
						}
						continue;
						end_IL_0193:
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
					stream.Dispose();
					binaryWriter.Close();
					return;
				}
			}
			finally
			{
				if (binaryWriter != null)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						((IDisposable)binaryWriter).Dispose();
						break;
					}
				}
			}
		}
	}

	internal class WeaponBinaryGenerator : BinaryGenerator
	{
		private WeaponStore m_weapon;

		public WeaponBinaryGenerator()
		{
			input = "Assets/Resources/WeaponEditor/";
			output = "Assets/Resources/WeaponEditor/Bin/";
			filter = "Weapon.xml";
		}

		protected override bool c846c1ae2a4dd6b46625f5bbdf334b1a9()
		{
			bool result = false;
			MemoryStream memoryStream = new MemoryStream(textAsset.bytes);
			try
			{
				try
				{
					XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c062fd1b7d7315b9283a174e4056160be.cc1720d05c75832f704b87474932341c3()));
					m_weapon = (WeaponStore)xmlSerializer.Deserialize(memoryStream);
					result = true;
				}
				catch
				{
				}
				finally
				{
					memoryStream.Close();
					Resources.UnloadAsset(textAsset);
				}
			}
			finally
			{
				if (memoryStream != null)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						((IDisposable)memoryStream).Dispose();
						break;
					}
				}
			}
			return result;
		}

		public override void c027cd496d170349393a89eb7936d8536()
		{
			BinaryWriter binaryWriter = new BinaryWriter(c6262cfabd0191048688ff6119f43ba97(output));
			try
			{
				for (int i = 0; i <= 5; i++)
				{
					int count = m_weapon.m_weaponDic[i].m_weaponAttribute.Count;
					for (int j = 0; j < count; j++)
					{
						bool flag = false;
						float value = 0f;
						try
						{
							value = m_weapon.m_weaponDic[i].m_weaponAttribute[j].m_attributeValue.c4e0f63f4b4d409c5e3992c71520e30a0();
							flag = true;
						}
						catch
						{
						}
						binaryWriter.Write((byte)m_weapon.m_weaponDic[i].m_weaponAttribute[j].m_attributeType);
						binaryWriter.Write((byte)m_weapon.m_weaponDic[i].m_weaponAttribute[j].m_attributeValue.m_type);
						binaryWriter.Write((byte)m_weapon.m_weaponDic[i].m_weaponAttribute[j].m_attributeValue.m_affectType);
						binaryWriter.Write(flag);
						if (!flag)
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
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						binaryWriter.Write(value);
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							goto end_IL_014e;
						}
						continue;
						end_IL_014e:
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
					binaryWriter.BaseStream.Dispose();
					binaryWriter.Close();
					return;
				}
			}
			finally
			{
				if (binaryWriter != null)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						((IDisposable)binaryWriter).Dispose();
						break;
					}
				}
			}
		}
	}

	private BinaryGenerator binaryGenerator;

	public BinaryLotGenerator(BinaryType c2be6c68b56e302527774bcaac5ce84c3)
	{
		switch (c2be6c68b56e302527774bcaac5ce84c3)
		{
		case BinaryType.BktBinaryGenerator:
			binaryGenerator = new BktBinaryGenerator();
			break;
		case BinaryType.PresetWpnBinaryGenerator:
			binaryGenerator = new PresetWpnBinaryGenerator();
			break;
		case BinaryType.SubPartsBinaryGenerator:
			binaryGenerator = new SubPartsBinaryGenerator();
			break;
		case BinaryType.RarityBinaryGenerator:
			binaryGenerator = new RarityBinaryGenerator();
			break;
		case BinaryType.WeaponBinaryGenerator:
			binaryGenerator = new WeaponBinaryGenerator();
			break;
		}
	}

	public void c2baf51c1d22954606acb7f8f426f2681()
	{
		string[] array = binaryGenerator.cf5e48405ae73609373e12ae1c2108b6c();
		for (int i = 0; i < array.Length; i++)
		{
			if (!binaryGenerator.ca3f160af19a466b44682674cd8630ec6(array[i]))
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
			binaryGenerator.c027cd496d170349393a89eb7936d8536();
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
