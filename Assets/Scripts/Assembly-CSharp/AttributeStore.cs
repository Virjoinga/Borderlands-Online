using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;
using XsdSettings;

[Serializable]
public class AttributeStore
{
	public const string AssetPath = "Assets/Resources/WeaponEditor/Attribute.XML";

	public const string ResourcesAssetPath = "WeaponEditor/Attribute";

	[SerializeField]
	public List<AttributeValueType> m_AttributeDic = new List<AttributeValueType>();

	[SerializeField]
	public List<string> m_AttributeTypeNames = new List<string>();

	private static AttributeStore m_attributeStore;

	public static AttributeStore attributeStore
	{
		get
		{
			if (m_attributeStore == null)
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
				c5694a7c59f02973598b1acd9edb41164();
				m_attributeStore.c7a3a9c22cd95b108e71a40ce2ee85008();
			}
			return m_attributeStore;
		}
		protected set
		{
			m_attributeStore = value;
		}
	}

	public AttributeStore()
	{
	}

	public AttributeStore(bool ccb88cc9ce41c4f9df0c68fa9f9360ffc)
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
			m_AttributeDic.Clear();
			IEnumerator enumerator = Enum.GetValues(Type.GetTypeFromHandle(c25a6363a7a7e86d9c74685be52d97b15.cc1720d05c75832f704b87474932341c3())).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					AttributeType attributeType = (AttributeType)(int)enumerator.Current;
					m_AttributeTypeNames.Add(Enum.GetName(Type.GetTypeFromHandle(c25a6363a7a7e86d9c74685be52d97b15.cc1720d05c75832f704b87474932341c3()), attributeType));
					m_AttributeDic.Add(AttributeValueType.FloatAttributeValue);
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
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable == null)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							goto end_IL_00bf;
						}
						continue;
						end_IL_00bf:
						break;
					}
				}
				else
				{
					disposable.Dispose();
				}
			}
		}
	}

	public BOLAttribute cb66e09406d31e61e068f9c0f2be88f8f(AttributeType c2b4f43f34e21572af6ab4414f04cee36)
	{
		BOLAttribute result = c378d322232643e81023171a357f5db5e.c7088de59e49f7108f520cf7e0bae167e;
		if (m_AttributeDic.Count > (int)c2b4f43f34e21572af6ab4414f04cee36)
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
			result = new BOLAttribute(c2b4f43f34e21572af6ab4414f04cee36);
		}
		return result;
	}

	public BOLAttribute cb66e09406d31e61e068f9c0f2be88f8f()
	{
		return new BOLAttribute();
	}

	public AttributeValueType ccf8b867ebe626fbd9a2992c0ef6fa576(AttributeType c2b4f43f34e21572af6ab4414f04cee36)
	{
		return m_AttributeDic[(int)c2b4f43f34e21572af6ab4414f04cee36];
	}

	public AttributeValue ced9ccbb2ae629d205bc0aeebee27f84b(AttributeType c2b4f43f34e21572af6ab4414f04cee36)
	{
		string typeName = "XsdSettings." + Enum.GetName(Type.GetTypeFromHandle(c926135a85cf6697c6fc9af4dfae75375.cc1720d05c75832f704b87474932341c3()), m_AttributeDic[(int)c2b4f43f34e21572af6ab4414f04cee36]);
		Type type = Type.GetType(typeName, true);
		return (AttributeValue)Activator.CreateInstance(type);
	}

	public AttributeValue ced9ccbb2ae629d205bc0aeebee27f84b(AttributeType c2b4f43f34e21572af6ab4414f04cee36, AttributeValue cefda2fdc3ce4e04f38bab77fc7998241)
	{
		AttributeValue attributeValue = ced9ccbb2ae629d205bc0aeebee27f84b(c2b4f43f34e21572af6ab4414f04cee36);
		attributeValue.c651a84d619af0768400f8763b8926673(cefda2fdc3ce4e04f38bab77fc7998241);
		return attributeValue;
	}

	public void c7a3a9c22cd95b108e71a40ce2ee85008()
	{
		List<string> list = new List<string>();
		List<AttributeValueType> list2 = new List<AttributeValueType>();
		IEnumerator enumerator = Enum.GetValues(Type.GetTypeFromHandle(c25a6363a7a7e86d9c74685be52d97b15.cc1720d05c75832f704b87474932341c3())).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				AttributeType attributeType = (AttributeType)(int)enumerator.Current;
				string name = Enum.GetName(Type.GetTypeFromHandle(c25a6363a7a7e86d9c74685be52d97b15.cc1720d05c75832f704b87474932341c3()), attributeType);
				if (m_AttributeTypeNames.Contains(name))
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
					int index = m_AttributeTypeNames.FindIndex((string c8afd0d53d6687bf18e0654bc7cf43a65) => c8afd0d53d6687bf18e0654bc7cf43a65.Equals(name));
					list.Add(name);
					list2.Add(m_AttributeDic[index]);
				}
				else
				{
					list.Add(name);
					list2.Add(AttributeValueType.FloatAttributeValue);
				}
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_00ef;
				}
				continue;
				end_IL_00ef:
				break;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						goto end_IL_0107;
					}
					continue;
					end_IL_0107:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
		m_AttributeDic = list2;
		m_AttributeTypeNames = list;
	}

	public static void c8247be8931d105f752fb9d8392ea62dc()
	{
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(cfde76e557d544f47b88838133e7938e9.cc1720d05c75832f704b87474932341c3()));
		TextWriter textWriter = new StreamWriter("Assets/Resources/WeaponEditor/Attribute.XML");
		try
		{
			xmlSerializer.Serialize(textWriter, m_attributeStore);
			textWriter.Close();
		}
		finally
		{
			if (textWriter != null)
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
					((IDisposable)textWriter).Dispose();
					break;
				}
			}
		}
	}

	private static void c5694a7c59f02973598b1acd9edb41164()
	{
		TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("WeaponEditor/Attribute") as TextAsset;
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(cfde76e557d544f47b88838133e7938e9.cc1720d05c75832f704b87474932341c3()));
		Stream stream = new MemoryStream(textAsset.bytes);
		try
		{
			m_attributeStore = (AttributeStore)xmlSerializer.Deserialize(stream);
			stream.Close();
		}
		finally
		{
			if (stream != null)
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
					((IDisposable)stream).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset);
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "System.GC.Collect");
		GC.Collect();
	}
}
