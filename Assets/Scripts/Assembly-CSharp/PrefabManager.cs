using System;
using System.Xml;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;

public sealed class PrefabManager
{
	public static bool c846c1ae2a4dd6b46625f5bbdf334b1a9<c272566d4edbf24bb8c4df6114a524ac9>(XmlNode c3c514e9daf2ec42b56a8e9f47ed4b484, ref c272566d4edbf24bb8c4df6114a524ac9 c591d56a94543e3559945c497f37126c4)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(c591d56a94543e3559945c497f37126c4.GetType());
		if (xmlSerializer == null)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return false;
				}
			}
		}
		XmlNodeReader xmlNodeReader = new XmlNodeReader(c3c514e9daf2ec42b56a8e9f47ed4b484);
		if (xmlNodeReader == null)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		try
		{
			c591d56a94543e3559945c497f37126c4 = (c272566d4edbf24bb8c4df6114a524ac9)xmlSerializer.Deserialize(xmlNodeReader);
		}
		catch (Exception ex)
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, ex.ToString());
			return false;
		}
		return true;
	}

	private static XmlNode ca9bf17523b5135c316284bc695b503c7(string ca88b7727d50bef1c1bfb2158b357fc87, string c62ffcf99479756bd5edc92e248bdff1e)
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c62ffcf99479756bd5edc92e248bdff1e);
		if (textAsset != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return ca9bf17523b5135c316284bc695b503c7(ca88b7727d50bef1c1bfb2158b357fc87, textAsset);
				}
			}
		}
		return null;
	}

	private static string ca9bf17523b5135c316284bc695b503c7(string c62ffcf99479756bd5edc92e248bdff1e)
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c62ffcf99479756bd5edc92e248bdff1e);
		if (textAsset == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return null;
				}
			}
		}
		return textAsset.text;
	}

	private static XmlNode ca9bf17523b5135c316284bc695b503c7(string ca88b7727d50bef1c1bfb2158b357fc87, TextAsset cf3e7cf89a11174b74b3c79da570effd9)
	{
		if (string.IsNullOrEmpty(ca88b7727d50bef1c1bfb2158b357fc87))
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
					return null;
				}
			}
		}
		if (cf3e7cf89a11174b74b3c79da570effd9 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return null;
				}
			}
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(cf3e7cf89a11174b74b3c79da570effd9.text);
		return xmlDocument.GetElementsByTagName(ca88b7727d50bef1c1bfb2158b357fc87)[0];
	}

	public static bool c467e74afab95ccaf4c794df74516df56(GameObject c80822505abd04406a7a821211bd77371, TextAsset cf3e7cf89a11174b74b3c79da570effd9)
	{
		if (c80822505abd04406a7a821211bd77371 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return false;
				}
			}
		}
		XmlNode xmlNode = ca9bf17523b5135c316284bc695b503c7("ComponentList", cf3e7cf89a11174b74b3c79da570effd9);
		if (xmlNode == null)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		XmlNodeList childNodes = xmlNode.ChildNodes;
		if (childNodes == null)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		for (int i = 0; i < childNodes.Count; i++)
		{
			XmlNode xmlNode2 = childNodes[i];
			if (xmlNode2.Name == "Prefab")
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
				if (!(c80822505abd04406a7a821211bd77371.GetComponent<EntityPlayer>() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (c10be7cee1fc6a6c4953804e095ef73a3(c80822505abd04406a7a821211bd77371, xmlNode2))
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "GameObject: " + c80822505abd04406a7a821211bd77371.name + " has Invalid Prefab: " + xmlNode2.OuterXml);
					return false;
				}
			}
			if (xmlNode2.Name == "MonoBehaviour")
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
				if (ce667ff6e525ceb46ac3d444105538e6b(c80822505abd04406a7a821211bd77371, xmlNode2))
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "GameObject: " + c80822505abd04406a7a821211bd77371.name + " has Invalid MonoBehaviour: " + xmlNode2.OuterXml);
					return false;
				}
			}
			if (xmlNode2.Name == "Collider")
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
				if (c8d2eaf02dcfbc412beba1e169e11fd0b(c80822505abd04406a7a821211bd77371, xmlNode2))
				{
					continue;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "GameObject: " + c80822505abd04406a7a821211bd77371.name + " has Invalid Collider: " + xmlNode2.OuterXml);
					return false;
				}
			}
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "Unkown Component");
			return false;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return true;
		}
	}

	public static bool c3911f9551fc7e67d65f7b9825f756fd9(GameObject c80822505abd04406a7a821211bd77371)
	{
		c80822505abd04406a7a821211bd77371.SendMessage("OnSpawnCompleted", null, SendMessageOptions.DontRequireReceiver);
		return true;
	}

	private static bool c10be7cee1fc6a6c4953804e095ef73a3(GameObject cfa6ad6a1a2ba88e0885574e6724a9fcf, XmlNode ccc8ac6a495059265b75b0cb7079fa668)
	{
		if (cfa6ad6a1a2ba88e0885574e6724a9fcf == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				return false;
			}
		}
		if (ccc8ac6a495059265b75b0cb7079fa668 == null)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				return false;
			}
		}
		XmlAttribute c7088de59e49f7108f520cf7e0bae167e = c6d81a8519da32d6c528a0fed72584807.c7088de59e49f7108f520cf7e0bae167e;
		bool flag = true;
		c7088de59e49f7108f520cf7e0bae167e = ccc8ac6a495059265b75b0cb7079fa668.Attributes["IsLocalOnly"];
		if (c7088de59e49f7108f520cf7e0bae167e != null)
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
			if (c7088de59e49f7108f520cf7e0bae167e.Value.ToUpper() == "TRUE")
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
				flag = cfa6ad6a1a2ba88e0885574e6724a9fcf.GetComponent<Entity>().caac907d451029d68503484a63934c93f();
			}
		}
		c7088de59e49f7108f520cf7e0bae167e = ccc8ac6a495059265b75b0cb7079fa668.Attributes["IsRemoteOnly"];
		if (c7088de59e49f7108f520cf7e0bae167e != null)
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
			if (c7088de59e49f7108f520cf7e0bae167e.Value.ToUpper() == "TRUE")
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
				flag = !cfa6ad6a1a2ba88e0885574e6724a9fcf.GetComponent<Entity>().caac907d451029d68503484a63934c93f();
			}
		}
		if (flag)
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
			c7088de59e49f7108f520cf7e0bae167e = ccc8ac6a495059265b75b0cb7079fa668.Attributes["NeedInstantiate"];
			if (c7088de59e49f7108f520cf7e0bae167e != null)
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
				if (!(c7088de59e49f7108f520cf7e0bae167e.Value.ToUpper() == "TRUE"))
				{
					goto IL_026c;
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
			c7088de59e49f7108f520cf7e0bae167e = ccc8ac6a495059265b75b0cb7079fa668.Attributes["Name"];
			if (c7088de59e49f7108f520cf7e0bae167e == null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					return false;
				}
			}
			UnityEngine.Object @object = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c7088de59e49f7108f520cf7e0bae167e.Value);
			if (@object == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					return false;
				}
			}
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(@object);
			if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					return false;
				}
			}
			gameObject.transform.parent = cfa6ad6a1a2ba88e0885574e6724a9fcf.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			c7088de59e49f7108f520cf7e0bae167e = ccc8ac6a495059265b75b0cb7079fa668.Attributes["Scale"];
			if (c7088de59e49f7108f520cf7e0bae167e != null)
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
				float result = 1f;
				float.TryParse(c7088de59e49f7108f520cf7e0bae167e.Value, out result);
				if (result > float.Epsilon)
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
					gameObject.transform.localScale = Vector3.one * result;
				}
			}
		}
		goto IL_026c;
		IL_026c:
		return true;
	}

	private static Component c0e4a46b1c8cd9f179553ca42b6a9dca0(GameObject cfa6ad6a1a2ba88e0885574e6724a9fcf, XmlNode ccc8ac6a495059265b75b0cb7079fa668, ref bool c86f1495d73996f269272cb765dc912fb)
	{
		if (cfa6ad6a1a2ba88e0885574e6724a9fcf == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				return null;
			}
		}
		if (ccc8ac6a495059265b75b0cb7079fa668 == null)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				return null;
			}
		}
		XmlAttribute c7088de59e49f7108f520cf7e0bae167e = c6d81a8519da32d6c528a0fed72584807.c7088de59e49f7108f520cf7e0bae167e;
		bool flag = true;
		c7088de59e49f7108f520cf7e0bae167e = ccc8ac6a495059265b75b0cb7079fa668.Attributes["IsLocalOnly"];
		if (c7088de59e49f7108f520cf7e0bae167e != null)
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
			if (c7088de59e49f7108f520cf7e0bae167e.Value.ToUpper() == "TRUE")
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
				flag = cfa6ad6a1a2ba88e0885574e6724a9fcf.GetComponent<Entity>().caac907d451029d68503484a63934c93f();
			}
		}
		c7088de59e49f7108f520cf7e0bae167e = ccc8ac6a495059265b75b0cb7079fa668.Attributes["IsRemoteOnly"];
		if (c7088de59e49f7108f520cf7e0bae167e != null)
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
			if (c7088de59e49f7108f520cf7e0bae167e.Value.ToUpper() == "TRUE")
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
				flag = !cfa6ad6a1a2ba88e0885574e6724a9fcf.GetComponent<Entity>().caac907d451029d68503484a63934c93f();
			}
		}
		if (!flag)
		{
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
		c7088de59e49f7108f520cf7e0bae167e = ccc8ac6a495059265b75b0cb7079fa668.Attributes["Type"];
		if (c7088de59e49f7108f520cf7e0bae167e == null)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				return null;
			}
		}
		Component c7088de59e49f7108f520cf7e0bae167e2 = c31730e97b2094a509ad3220ed5868185.c7088de59e49f7108f520cf7e0bae167e;
		string value = c7088de59e49f7108f520cf7e0bae167e.Value;
		c7088de59e49f7108f520cf7e0bae167e = ccc8ac6a495059265b75b0cb7079fa668.Attributes["NeedInstantiate"];
		if (c7088de59e49f7108f520cf7e0bae167e != null)
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
			if (!(c7088de59e49f7108f520cf7e0bae167e.Value.ToUpper() == "TRUE"))
			{
				c7088de59e49f7108f520cf7e0bae167e2 = cfa6ad6a1a2ba88e0885574e6724a9fcf.GetComponent(value);
				goto IL_0191;
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
		c7088de59e49f7108f520cf7e0bae167e2 = cfa6ad6a1a2ba88e0885574e6724a9fcf.AddComponent(value);
		goto IL_0191;
		IL_0191:
		c7088de59e49f7108f520cf7e0bae167e = ccc8ac6a495059265b75b0cb7079fa668.Attributes["NeedInitialize"];
		int num;
		if (c7088de59e49f7108f520cf7e0bae167e != null)
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
			num = ((c7088de59e49f7108f520cf7e0bae167e.Value.ToUpper() == "TRUE") ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		c86f1495d73996f269272cb765dc912fb = (byte)num != 0;
		return c7088de59e49f7108f520cf7e0bae167e2;
	}

	private static bool ce667ff6e525ceb46ac3d444105538e6b(GameObject cfa6ad6a1a2ba88e0885574e6724a9fcf, XmlNode ccc8ac6a495059265b75b0cb7079fa668)
	{
		bool c86f1495d73996f269272cb765dc912fb = false;
		Component component = c0e4a46b1c8cd9f179553ca42b6a9dca0(cfa6ad6a1a2ba88e0885574e6724a9fcf, ccc8ac6a495059265b75b0cb7079fa668, ref c86f1495d73996f269272cb765dc912fb);
		if (component == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return true;
				}
			}
		}
		if (c86f1495d73996f269272cb765dc912fb)
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
			if (component is IPrefabManagerXmlSetup)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					XmlNode xmlNode = ccc8ac6a495059265b75b0cb7079fa668.FirstChild;
					if (xmlNode == null)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					if (xmlNode.Name != "Settings")
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					XmlAttribute c7088de59e49f7108f520cf7e0bae167e = c6d81a8519da32d6c528a0fed72584807.c7088de59e49f7108f520cf7e0bae167e;
					c7088de59e49f7108f520cf7e0bae167e = xmlNode.Attributes["Type"];
					if (c7088de59e49f7108f520cf7e0bae167e == null)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					if (c7088de59e49f7108f520cf7e0bae167e.Value.ToUpper() == "XML")
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
						c7088de59e49f7108f520cf7e0bae167e = xmlNode.Attributes["FileName"];
						if (c7088de59e49f7108f520cf7e0bae167e == null)
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									continue;
								}
								return false;
							}
						}
						xmlNode = ca9bf17523b5135c316284bc695b503c7("Settings", c7088de59e49f7108f520cf7e0bae167e.Value);
						if (xmlNode == null)
						{
							while (true)
							{
								switch (7)
								{
								case 0:
									break;
								default:
									return false;
								}
							}
						}
					}
					else if (c7088de59e49f7108f520cf7e0bae167e.Value.ToUpper() != "ATTRIBUTES")
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					return ((IPrefabManagerXmlSetup)component).ceb70887701f0c688b6ddc239066fdda5(xmlNode);
				}
			}
			if (component is IPrefabManagerXmlGenericSetup)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
					{
						XmlNode firstChild = ccc8ac6a495059265b75b0cb7079fa668.FirstChild;
						if (firstChild == null)
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
									return false;
								}
							}
						}
						if (firstChild.Name != "Settings")
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									break;
								default:
									return false;
								}
							}
						}
						XmlAttribute c7088de59e49f7108f520cf7e0bae167e2 = c6d81a8519da32d6c528a0fed72584807.c7088de59e49f7108f520cf7e0bae167e;
						c7088de59e49f7108f520cf7e0bae167e2 = firstChild.Attributes["Type"];
						if (c7088de59e49f7108f520cf7e0bae167e2 == null)
						{
							while (true)
							{
								switch (7)
								{
								case 0:
									break;
								default:
									return false;
								}
							}
						}
						if (c7088de59e49f7108f520cf7e0bae167e2.Value.ToUpper() != "XMLGENERIC")
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									break;
								default:
									return false;
								}
							}
						}
						c7088de59e49f7108f520cf7e0bae167e2 = firstChild.Attributes["FileName"];
						if (c7088de59e49f7108f520cf7e0bae167e2 == null)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									return false;
								}
							}
						}
						string text = ca9bf17523b5135c316284bc695b503c7(c7088de59e49f7108f520cf7e0bae167e2.Value);
						if (string.IsNullOrEmpty(text))
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									break;
								default:
									return false;
								}
							}
						}
						return ((IPrefabManagerXmlGenericSetup)component).ceb70887701f0c688b6ddc239066fdda5(text);
					}
					}
				}
			}
		}
		return true;
	}

	private static bool c8d2eaf02dcfbc412beba1e169e11fd0b(GameObject cfa6ad6a1a2ba88e0885574e6724a9fcf, XmlNode ccc8ac6a495059265b75b0cb7079fa668)
	{
		bool c86f1495d73996f269272cb765dc912fb = false;
		Component component = c0e4a46b1c8cd9f179553ca42b6a9dca0(cfa6ad6a1a2ba88e0885574e6724a9fcf, ccc8ac6a495059265b75b0cb7079fa668, ref c86f1495d73996f269272cb765dc912fb);
		if (component == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return true;
				}
			}
		}
		if (c86f1495d73996f269272cb765dc912fb)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					XmlNode firstChild = ccc8ac6a495059265b75b0cb7079fa668.FirstChild;
					if (firstChild == null)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					if (firstChild.Name != "Settings")
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					XmlAttribute c7088de59e49f7108f520cf7e0bae167e = c6d81a8519da32d6c528a0fed72584807.c7088de59e49f7108f520cf7e0bae167e;
					c7088de59e49f7108f520cf7e0bae167e = firstChild.Attributes["Type"];
					if (c7088de59e49f7108f520cf7e0bae167e == null)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					if (c7088de59e49f7108f520cf7e0bae167e.Value.ToUpper() != "ATTRIBUTES")
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					return cfb25186c689c818206938a7cf00d6f69(cfa6ad6a1a2ba88e0885574e6724a9fcf, component, firstChild);
				}
				}
			}
		}
		return true;
	}

	private static bool cfb25186c689c818206938a7cf00d6f69(GameObject cfa6ad6a1a2ba88e0885574e6724a9fcf, Component c07d89e791d9882e4345ad1040077b340, XmlNode c75f178a624b47b0b130c5c2b0a08cada)
	{
		if (cfa6ad6a1a2ba88e0885574e6724a9fcf == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return false;
				}
			}
		}
		if (c75f178a624b47b0b130c5c2b0a08cada == null)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (c07d89e791d9882e4345ad1040077b340 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (c07d89e791d9882e4345ad1040077b340.GetType() == Type.GetTypeFromHandle(c2fcf2298bf9381decb710f97d6fd5c31.cc1720d05c75832f704b87474932341c3()))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
				{
					XmlAttribute c7088de59e49f7108f520cf7e0bae167e = c6d81a8519da32d6c528a0fed72584807.c7088de59e49f7108f520cf7e0bae167e;
					float result = 0.5f;
					c7088de59e49f7108f520cf7e0bae167e = c75f178a624b47b0b130c5c2b0a08cada.Attributes["Radius"];
					if (c7088de59e49f7108f520cf7e0bae167e == null)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					float.TryParse(c7088de59e49f7108f520cf7e0bae167e.Value, out result);
					if (result > 0f)
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
						((CapsuleCollider)c07d89e791d9882e4345ad1040077b340).radius = result;
					}
					float result2 = 1f;
					c7088de59e49f7108f520cf7e0bae167e = c75f178a624b47b0b130c5c2b0a08cada.Attributes["Height"];
					if (c7088de59e49f7108f520cf7e0bae167e == null)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					float.TryParse(c7088de59e49f7108f520cf7e0bae167e.Value, out result2);
					if (result2 > 0f)
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
						((CapsuleCollider)c07d89e791d9882e4345ad1040077b340).height = result2;
						((CapsuleCollider)c07d89e791d9882e4345ad1040077b340).center = new Vector3(0f, result2 / 2f, 0f);
					}
					return true;
				}
				}
			}
		}
		if (c07d89e791d9882e4345ad1040077b340.GetType() == Type.GetTypeFromHandle(c977e9f3fa324b0c54a519ed832def0d6.cc1720d05c75832f704b87474932341c3()))
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
				{
					XmlAttribute c7088de59e49f7108f520cf7e0bae167e2 = c6d81a8519da32d6c528a0fed72584807.c7088de59e49f7108f520cf7e0bae167e;
					float result3 = 0.5f;
					c7088de59e49f7108f520cf7e0bae167e2 = c75f178a624b47b0b130c5c2b0a08cada.Attributes["Radius"];
					if (c7088de59e49f7108f520cf7e0bae167e2 == null)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					float.TryParse(c7088de59e49f7108f520cf7e0bae167e2.Value, out result3);
					if (result3 > 0f)
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
						((CharacterController)c07d89e791d9882e4345ad1040077b340).radius = result3;
					}
					float result4 = 1f;
					c7088de59e49f7108f520cf7e0bae167e2 = c75f178a624b47b0b130c5c2b0a08cada.Attributes["Height"];
					if (c7088de59e49f7108f520cf7e0bae167e2 == null)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					float.TryParse(c7088de59e49f7108f520cf7e0bae167e2.Value, out result4);
					if (result4 > 0f)
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
						((CharacterController)c07d89e791d9882e4345ad1040077b340).height = result4;
						((CharacterController)c07d89e791d9882e4345ad1040077b340).center = new Vector3(0f, result4 / 2f, 0f);
					}
					return true;
				}
				}
			}
		}
		return false;
	}
}
