using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using pumpkin.display;

namespace pumpkin.text
{
	public class TextFieldLocalization
	{
		private XmlDocument xmlDoc;

		private List<string> m_StringList = new List<string>();

		public bool loadFromResource(string name)
		{
			TextAsset textAsset = (TextAsset)Resources.Load(name);
			return parseXml(textAsset.text, name);
		}

		public bool parseXml(string xml, string srcCilename)
		{
			xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(xml);
			m_StringList = new List<string>();
			XmlNode firstChild = xmlDoc.FirstChild;
			foreach (XmlNode item in firstChild)
			{
				m_StringList.Add(item.Name);
			}
			return false;
		}

		public string getString(string name)
		{
			return getString(name, null);
		}

		public string getString(string name, string defaultString)
		{
			XmlNode firstChild = xmlDoc.FirstChild;
			foreach (XmlNode item in firstChild)
			{
				if (item.Name == name)
				{
					return item.InnerText;
				}
			}
			return defaultString;
		}

		public void applyToDisplayObjectContainer(DisplayObjectContainer parent)
		{
			applyToDisplayObjectContainer(parent, true);
		}

		public void applyToDisplayObjectContainer(DisplayObjectContainer parent, bool recurse)
		{
			for (int i = 0; i < parent.numChildren; i++)
			{
				DisplayObject childAt = parent.getChildAt(i);
				if (!(childAt is TextField))
				{
					if (recurse && childAt is DisplayObjectContainer)
					{
						applyToDisplayObjectContainer(childAt as DisplayObjectContainer, true);
					}
					continue;
				}
				TextField textField = childAt as TextField;
				if (m_StringList.IndexOf(textField.localizationName) != -1)
				{
					textField.text = getString(textField.localizationName);
				}
				else if (m_StringList.IndexOf(textField.text) != -1)
				{
					textField.localizationName = textField.text;
					textField.text = getString(textField.localizationName);
				}
			}
		}
	}
}
