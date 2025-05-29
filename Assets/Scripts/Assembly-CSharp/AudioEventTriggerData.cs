using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using A;
using Core;
using UnityEngine;

[ExecuteInEditMode]
public class AudioEventTriggerData : EventTriggerData
{
	public enum ResourceStrategy
	{
		Automatic = 0,
		Manual = 1,
		Player = 2,
		Player_Town = 3
	}

	private enum ResourceStrategyUtil
	{
		END = 4
	}

	private const string MODULES_NODE_NAME = "Modules";

	private const string MODULE_NODE_NAME = "Module";

	private const string MODULE_FILE_ATTR_NAME = "Filename";

	private const string XML_FILE_EXTENSION = ".xml";

	private const int MAX_MODULE_DEPTH = 10;

	public ResourceStrategy m_resourceStrategy;

	public static readonly string AUDIOEVENTLIST_TAG_NAME = "AudioEventList";

	public static readonly string RESOURCESTRATEGY_ATTR_NAME = "ResourceStrategy";

	public static readonly string AUDIOEVENT_TAG_NAME = "AudioEvent";

	public static readonly string AUDIOEVENTNAME_TAG_NAME = "EventName";

	public static readonly string AUDIOPREFABNAME_TAG_NAME = "AudioPrefabName";

	public static readonly string CLASSSPECIFIC_ATTRNAME = "ClassSpecific";

	public static readonly string LOCALPLAYERONLY_ATTRNAME = "LocalPlayer";

	private static string ccb7def2d51ee4a9136913a43fc85dd0b
	{
		get
		{
			return "Assets/Resources/" + c1d1901b83dd8fd9ea041279dcf003f71;
		}
	}

	private static string c1d1901b83dd8fd9ea041279dcf003f71
	{
		get
		{
			return "Audio/EventLists/";
		}
	}

	public static ResourceStrategy ca643b2acc68e3dd3f8be89b0b0209379(string c7c80fef79e3c330ae5014832d44fcd28)
	{
		ResourceStrategy result = ResourceStrategy.Automatic;
		try
		{
			result = (ResourceStrategy)(int)Enum.Parse(typeof(ResourceStrategy), c7c80fef79e3c330ae5014832d44fcd28);
		}
		catch (Exception ex)
		{
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Unknown resource strategy: " + c7c80fef79e3c330ae5014832d44fcd28 + " - from: " + ex.ToString());
		}
		return result;
	}

	public static ResourceStrategy c3786a95cc06d25a606cd3e215b8378b2(XmlDocument c9ddf78c2ea46c4f4f3adfbe216ccd747)
	{
		ResourceStrategy result = ResourceStrategy.Automatic;
		if (c9ddf78c2ea46c4f4f3adfbe216ccd747.DocumentElement.HasAttribute(RESOURCESTRATEGY_ATTR_NAME))
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
			result = ca643b2acc68e3dd3f8be89b0b0209379(c9ddf78c2ea46c4f4f3adfbe216ccd747.DocumentElement.GetAttribute(RESOURCESTRATEGY_ATTR_NAME));
		}
		return result;
	}

	private static string c9faefba255915b12f17609ff5f07ac65(string c01440692451b416ecf5f5472334f32a0)
	{
		return Path.GetFileNameWithoutExtension(c01440692451b416ecf5f5472334f32a0) + ".xml";
	}

	public static string c58c0a64e85542b753600bd7f7da540f7(string cb4dc1183147fa8c3709acbbf2bfec5df)
	{
		return Path.Combine(ccb7def2d51ee4a9136913a43fc85dd0b, c9faefba255915b12f17609ff5f07ac65(cb4dc1183147fa8c3709acbbf2bfec5df));
	}

	private void ce7800a64d48be484667aa9bc47b999f5(CSoundPrefabInfo c00bb86ffbeb6764fbe60d7b64859db7f, XmlNode cab83bba925e6355b7d0df9fe7c31c6e1)
	{
		if (cab83bba925e6355b7d0df9fe7c31c6e1.Attributes[AUDIOPREFABNAME_TAG_NAME] != null)
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
			c00bb86ffbeb6764fbe60d7b64859db7f.m_sAudioPrefabName = cab83bba925e6355b7d0df9fe7c31c6e1.Attributes[AUDIOPREFABNAME_TAG_NAME].Value;
		}
		if (cab83bba925e6355b7d0df9fe7c31c6e1.Attributes["Interval"] != null)
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
			c00bb86ffbeb6764fbe60d7b64859db7f.m_fInterval = Convert.ToSingle(cab83bba925e6355b7d0df9fe7c31c6e1.Attributes["Interval"].Value);
		}
		if (cab83bba925e6355b7d0df9fe7c31c6e1.Attributes["Delay"] != null)
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
			c00bb86ffbeb6764fbe60d7b64859db7f.m_fDelay = Convert.ToSingle(cab83bba925e6355b7d0df9fe7c31c6e1.Attributes["Delay"].Value);
		}
		if (cab83bba925e6355b7d0df9fe7c31c6e1.Attributes["DistanceToTrigger"] != null)
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
			c00bb86ffbeb6764fbe60d7b64859db7f.m_fDistanceToTrigger = Convert.ToSingle(cab83bba925e6355b7d0df9fe7c31c6e1.Attributes["DistanceToTrigger"].Value);
		}
		if (cab83bba925e6355b7d0df9fe7c31c6e1.Attributes["Behaviour"] != null)
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
			try
			{
				c00bb86ffbeb6764fbe60d7b64859db7f.m_eAction = (AudioEventAction)(int)Enum.Parse(Type.GetTypeFromHandle(c3d85738c4afad39d3b4baef08244a6ce.cc1720d05c75832f704b87474932341c3()), cab83bba925e6355b7d0df9fe7c31c6e1.Attributes["Behaviour"].Value);
			}
			catch
			{
				c00bb86ffbeb6764fbe60d7b64859db7f.m_eAction = AudioEventAction.Play;
			}
		}
		if (cab83bba925e6355b7d0df9fe7c31c6e1.Attributes["FadeTime"] != null)
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
			c00bb86ffbeb6764fbe60d7b64859db7f.m_fFadeTime = Convert.ToSingle(cab83bba925e6355b7d0df9fe7c31c6e1.Attributes["FadeTime"].Value);
		}
		if (cab83bba925e6355b7d0df9fe7c31c6e1.Attributes[CLASSSPECIFIC_ATTRNAME] != null)
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
			c00bb86ffbeb6764fbe60d7b64859db7f.m_isClassSpecific = Convert.ToBoolean(cab83bba925e6355b7d0df9fe7c31c6e1.Attributes[CLASSSPECIFIC_ATTRNAME].Value);
		}
		if (cab83bba925e6355b7d0df9fe7c31c6e1.Attributes[LOCALPLAYERONLY_ATTRNAME] == null)
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
			c00bb86ffbeb6764fbe60d7b64859db7f.m_isLocalPlayerOnly = Convert.ToBoolean(cab83bba925e6355b7d0df9fe7c31c6e1.Attributes[LOCALPLAYERONLY_ATTRNAME].Value);
			return;
		}
	}

	public bool c38aeacc59bd560b59403945ae7996d79(string cd1e3dee5c83b42041dac36bf26b36d23, List<string> c8748b7dab763ef2a3136f2000e3c056d = null)
	{
		cac7688b05e921e2be3f92479ba44b4a8();
		m_fileName = cd1e3dee5c83b42041dac36bf26b36d23;
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			string text = c1d1901b83dd8fd9ea041279dcf003f71 + Path.GetFileNameWithoutExtension(cd1e3dee5c83b42041dac36bf26b36d23);
			TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(text) as TextAsset;
			if (textAsset == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					throw new ArgumentException("Could not load resource from: " + text);
				}
			}
			xmlDocument.LoadXml(textAsset.text);
			ResourcesLoader.cc054e122aa35d5a0be5d36720b44c779(textAsset);
		}
		catch
		{
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Audio Event Trigger Control file doesn't exist @: " + cd1e3dee5c83b42041dac36bf26b36d23);
			return false;
		}
		m_resourceStrategy = c3786a95cc06d25a606cd3e215b8378b2(xmlDocument);
		if (!c1eb8f8244329cf6cc3d30a9b80cb2f90(xmlDocument.DocumentElement, c8748b7dab763ef2a3136f2000e3c056d))
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
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(AUDIOEVENT_TAG_NAME);
		for (int i = 0; i < elementsByTagName.Count; i++)
		{
			XmlNode xmlNode = elementsByTagName[i];
			AudioEventHandler audioEventHandler = new AudioEventHandler();
			if (xmlNode.Attributes[AUDIOEVENTNAME_TAG_NAME] != null)
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
				audioEventHandler.m_eventName = xmlNode.Attributes[AUDIOEVENTNAME_TAG_NAME].Value;
			}
			if (xmlNode.Attributes["Type"] != null)
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
				audioEventHandler.m_type = (EventTriggerType)(int)Enum.Parse(Type.GetTypeFromHandle(c93bf7513315c078eab0bec07aa21cfdc.cc1720d05c75832f704b87474932341c3()), xmlNode.Attributes["Type"].Value);
			}
			if (xmlNode.Attributes["MyltiPrefab"] == null)
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
				audioEventHandler.cc88ed4d299a92e70baa384198512a535();
				audioEventHandler.m_distanceToTrigger = Convert.ToSingle(xmlNode.Attributes["DistanceToTrigger"].Value);
				ce7800a64d48be484667aa9bc47b999f5(audioEventHandler.m_aSoundPrefabList[0], xmlNode);
				cc34cf6dc3d05cb2aa7a0a66991dcc81d(audioEventHandler.m_eventName, audioEventHandler, true);
				continue;
			}
			int num = Convert.ToInt32(xmlNode.Attributes["MyltiPrefab"].Value);
			for (int j = 0; j < num; j++)
			{
				audioEventHandler.cc88ed4d299a92e70baa384198512a535();
				XmlNode cab83bba925e6355b7d0df9fe7c31c6e = xmlNode.ChildNodes[j];
				ce7800a64d48be484667aa9bc47b999f5(audioEventHandler.m_aSoundPrefabList[j], cab83bba925e6355b7d0df9fe7c31c6e);
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
			cc34cf6dc3d05cb2aa7a0a66991dcc81d(audioEventHandler.m_eventName, audioEventHandler, true);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			elementsByTagName = xmlDocument.GetElementsByTagName("RandomEventTrigger");
			for (int k = 0; k < elementsByTagName.Count; k++)
			{
				XmlNode xmlNode2 = elementsByTagName[k];
				EventRandomTrigger eventRandomTrigger = new EventRandomTrigger();
				if (xmlNode2.Attributes[AUDIOEVENTNAME_TAG_NAME] != null)
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
					eventRandomTrigger.m_eventName = xmlNode2.Attributes[AUDIOEVENTNAME_TAG_NAME].Value;
				}
				if (xmlNode2.Attributes["RangeMin"] != null)
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
					eventRandomTrigger.m_rangeMin = Convert.ToSingle(xmlNode2.Attributes["RangeMin"].Value);
				}
				if (xmlNode2.Attributes["RangeMax"] != null)
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
					eventRandomTrigger.m_rangeMax = Convert.ToSingle(xmlNode2.Attributes["RangeMax"].Value);
				}
				m_randomTriggers.Add(eventRandomTrigger);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				return true;
			}
		}
	}

	private void c4408ab535a8d5a9011434a7e2f86a6e1(XmlElement c8cdf32bf22d12159787983a37acfba0c)
	{
		XmlDocument ownerDocument = c8cdf32bf22d12159787983a37acfba0c.OwnerDocument;
		XmlNodeList elementsByTagName = ownerDocument.GetElementsByTagName("Module");
		if (elementsByTagName.Count <= 0)
		{
			return;
		}
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
			m_moduleFileNames = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(elementsByTagName.Count);
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				XmlElement xmlElement = elementsByTagName[i] as XmlElement;
				m_moduleFileNames[i] = xmlElement.GetAttribute("Filename");
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	private bool c1eb8f8244329cf6cc3d30a9b80cb2f90(XmlElement c8cdf32bf22d12159787983a37acfba0c, List<string> c8748b7dab763ef2a3136f2000e3c056d)
	{
		bool result = true;
		c4408ab535a8d5a9011434a7e2f86a6e1(c8cdf32bf22d12159787983a37acfba0c);
		if (c1ec2cc085280a41891379cc1a1f0af4c())
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
			if (c8748b7dab763ef2a3136f2000e3c056d == null)
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
				c8748b7dab763ef2a3136f2000e3c056d = new List<string>();
			}
			int count = c8748b7dab763ef2a3136f2000e3c056d.Count;
			if (count >= 10)
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
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Suspiciously high AudioEventData dependency depth for module: " + m_fileName + " in AudioEventData hierarchy: " + string.Join(", ", c8748b7dab763ef2a3136f2000e3c056d.ToArray()));
			}
			c8748b7dab763ef2a3136f2000e3c056d.Add(m_fileName);
			AudioEventTriggerData audioEventTriggerData = new AudioEventTriggerData();
			for (int i = 0; i < m_moduleFileNames.Length; i++)
			{
				string text = m_moduleFileNames[i];
				if (c8748b7dab763ef2a3136f2000e3c056d.Contains(text))
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Cyclic AudioEventTriggerData module dependency for module: " + text + " in AudioEventData hierarchy: " + string.Join(", ", c8748b7dab763ef2a3136f2000e3c056d.ToArray()));
					result = false;
					continue;
				}
				if (!audioEventTriggerData.c38aeacc59bd560b59403945ae7996d79(text, c8748b7dab763ef2a3136f2000e3c056d))
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
					result = false;
					continue;
				}
				using (Dictionary<string, BaseEventHandler>.Enumerator enumerator = audioEventTriggerData.cce042d6921b01754b4b5d8013356a44d.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<string, BaseEventHandler> current = enumerator.Current;
						cc34cf6dc3d05cb2aa7a0a66991dcc81d(current.Key, current.Value, true);
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							goto end_IL_0155;
						}
						continue;
						end_IL_0155:
						break;
					}
				}
				int count2 = audioEventTriggerData.cc66b9d16556a63e2369ebb16c1657ca0.Count;
				for (int j = 0; j < count2; j++)
				{
					m_randomTriggers.Add(audioEventTriggerData.cc66b9d16556a63e2369ebb16c1657ca0[j]);
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
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			using (Dictionary<string, BaseEventHandler>.Enumerator enumerator2 = m_eventHandlers.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					BaseEventHandler value = enumerator2.Current.Value;
					value.c833355f28871126c97086f4d9e61227e(false);
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						goto end_IL_020c;
					}
					continue;
					end_IL_020c:
					break;
				}
			}
			for (int k = 0; k < m_randomTriggers.Count; k++)
			{
				m_randomTriggers[k].c833355f28871126c97086f4d9e61227e(false);
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
			if (c8748b7dab763ef2a3136f2000e3c056d.Count > count)
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
				c8748b7dab763ef2a3136f2000e3c056d.RemoveRange(count, c8748b7dab763ef2a3136f2000e3c056d.Count - count);
			}
		}
		return result;
	}
}
