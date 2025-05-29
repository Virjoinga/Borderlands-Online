using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using A;
using Core;
using UnityEngine;

public class LocalizedStringManager : IContentManager
{
	private const string CONFIG_FILE_PREFIX_NAME = "LocalizedString_";

	private const string CONFIG_FILE_URL = "Localization/";

	protected Dictionary<string, string> _dicLocalizedStringDB = new Dictionary<string, string>();

	private string _strConfigFileName = string.Empty;

	public override void OnLanguageChange(string language)
	{
		_strConfigFileName = "Localization/LocalizedString_" + language;
		_dicLocalizedStringDB.Clear();
		TextAsset textAsset = (TextAsset)Resources.Load(_strConfigFileName, Type.GetTypeFromHandle(cda4706963b5b94cc26d866126dd86f9c.cc1720d05c75832f704b87474932341c3()));
		if (textAsset == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Framework, "Could not load localization string config: " + _strConfigFileName);
					return;
				}
			}
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("localizedString");
		IEnumerator enumerator = elementsByTagName.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				XmlNode namedItem = xmlNode.Attributes.GetNamedItem("KeyName");
				XmlNode namedItem2 = xmlNode.Attributes.GetNamedItem("Words");
				if (namedItem2 == null)
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
				if (_dicLocalizedStringDB.ContainsKey(namedItem.Value))
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
					_dicLocalizedStringDB[namedItem.Value] = namedItem2.Value;
				}
				else
				{
					_dicLocalizedStringDB.Add(namedItem.Value, namedItem2.Value);
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
						goto end_IL_017d;
					}
					continue;
					end_IL_017d:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	public override void OnContentAdded(ILocalizedContent newContent)
	{
		c60f94b0f2987ff01d5f4748fe175103d(newContent as LocalizedString);
	}

	protected virtual void c60f94b0f2987ff01d5f4748fe175103d(LocalizedString c823ca53d66c201585d99e5837e8a47ac)
	{
		if (c823ca53d66c201585d99e5837e8a47ac == null)
		{
			return;
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
			string c6ef1290751f4a29a1b80526cf77756ba = c823ca53d66c201585d99e5837e8a47ac.c6ef1290751f4a29a1b80526cf77756ba;
			if (_dicLocalizedStringDB.ContainsKey(c6ef1290751f4a29a1b80526cf77756ba))
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						c823ca53d66c201585d99e5837e8a47ac.cd957b62b335eee8b757c4f6a17d901ff(_dicLocalizedStringDB[c6ef1290751f4a29a1b80526cf77756ba]);
						return;
					}
				}
			}
			_dicLocalizedStringDB.Add(c6ef1290751f4a29a1b80526cf77756ba, LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(c823ca53d66c201585d99e5837e8a47ac));
			return;
		}
	}

	public virtual void c36f9e05964de262793948b3ea2fa75a6()
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlElement xmlElement = xmlDocument.CreateElement("localization");
		using (Dictionary<string, string>.Enumerator enumerator = _dicLocalizedStringDB.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, string> current = enumerator.Current;
				XmlElement xmlElement2 = xmlDocument.CreateElement("localizedString");
				xmlElement2.SetAttribute("KeyName", current.Key);
				xmlElement2.SetAttribute("Words", current.Value);
				xmlElement.AppendChild(xmlElement2);
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
				break;
			}
		}
		xmlDocument.AppendChild(xmlElement);
		xmlDocument.Save(_strConfigFileName + ".xml");
	}

	protected void c51c01f07857a9a6238b8f0111d2e0100(string c1277d36f3c3dbe9911af7ef59e249fbb)
	{
	}
}
