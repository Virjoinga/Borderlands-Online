using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class InputManager : c06ca0e618478c23eba3419653a19760f<InputManager>
{
	public class InputKeyBinding
	{
		public KeyCode primaryKey;

		public KeyCode seconderyKey;

		public InputKeyBinding()
		{
		}

		public InputKeyBinding(KeyCode c9e132bdc97a9dead215c517590fd951d, KeyCode cfc67c43484c0d1b4c7451fc4de630e94)
		{
			primaryKey = c9e132bdc97a9dead215c517590fd951d;
			seconderyKey = cfc67c43484c0d1b4c7451fc4de630e94;
		}
	}

	public delegate void OnKeySettingsChanged(Dictionary<string, InputKeyBinding> newKeySettings);

	private bool m_isControlLocked;

	private bool m_isPlayerDead;

	private InputReader m_reader = new RegularInputReader();

	private ControlSchemeSetup m_presetControlSchemeSetup;

	private Dictionary<string, InputKeyBinding> m_inputMap = new Dictionary<string, InputKeyBinding>();

	private Dictionary<string, InputKeyBinding> m_defaultInputMap = new Dictionary<string, InputKeyBinding>();

	private Dictionary<KeyboardCode, KeyCode> m_configToGlobalKeycodeMap = new Dictionary<KeyboardCode, KeyCode>();

	private HashSet<string> m_customableFunctionCollection = new HashSet<string>();

	private HashSet<KeyCode> m_customableKeycodeCollection = new HashSet<KeyCode>();

	private List<OnKeySettingsChanged> m_listenersOnSettingsChanged = new List<OnKeySettingsChanged>();

	public void c3f0d9cf7bb65072c8cb6a400c2468eea(InputReader cffaa6c92023d3015930a3f2cdd0fff46)
	{
		m_reader = cffaa6c92023d3015930a3f2cdd0fff46;
	}

	private void Start()
	{
		m_inputMap.Clear();
		m_defaultInputMap.Clear();
		m_configToGlobalKeycodeMap.Clear();
		m_customableKeycodeCollection.Clear();
		m_customableFunctionCollection.Clear();
		m_listenersOnSettingsChanged.Clear();
		KeyboardCode[] array = (KeyboardCode[])Enum.GetValues(Type.GetTypeFromHandle(c19927516ab8c08225c621e212e8980cc.cc1720d05c75832f704b87474932341c3()));
		foreach (KeyboardCode keyboardCode in array)
		{
			KeyCode keyCode = (KeyCode)(int)Enum.Parse(Type.GetTypeFromHandle(c07e9775a0c4aff92e07b4b9d70104c71.cc1720d05c75832f704b87474932341c3()), keyboardCode.ToString());
			m_configToGlobalKeycodeMap.Add(keyboardCode, keyCode);
			m_customableKeycodeCollection.Add(keyCode);
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
			TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/ControlScheme");
			StringReader stringReader = new StringReader(textAsset.text);
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(cb1eb078283a62733157f8d08220dc6e8.cc1720d05c75832f704b87474932341c3()));
				m_presetControlSchemeSetup = xmlSerializer.Deserialize(stringReader) as ControlSchemeSetup;
			}
			finally
			{
				if (stringReader != null)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						((IDisposable)stringReader).Dispose();
						break;
					}
				}
			}
			ResourcesLoader.cc054e122aa35d5a0be5d36720b44c779(textAsset);
			cbe349de0b5402dfd2f6c96aa50be7175();
			return;
		}
	}

	public void cca84ca4deababdecf8f3d8cc7a45edb9(bool c23c1940b66e93237a494117e616d16ac = false)
	{
		if (c23c1940b66e93237a494117e616d16ac)
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
			m_isPlayerDead = true;
		}
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Input, "InputManager.LockControl - was: " + m_isControlLocked);
		m_isControlLocked = true;
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86)
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
			PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
			if (!playerInfoSync)
			{
				return;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				StatisticsManager.StatSheet statSheet = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdcb2ff44fc70c31a5ec9c7f0156d8f27(playerInfoSync);
				if (statSheet == null)
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
					statSheet.cca84ca4deababdecf8f3d8cc7a45edb9(true);
					return;
				}
			}
		}
	}

	public void c0888ee52497af70d4cc14624cbd11269(bool c9faceea6fac2da2018de691f55c8270d = false)
	{
		if (c9faceea6fac2da2018de691f55c8270d)
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
			m_isPlayerDead = false;
		}
		if (m_isPlayerDead)
		{
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
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Input, "InputManager.UnlockControl - was: " + m_isControlLocked);
		if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86)
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
			PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
			if ((bool)playerInfoSync)
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
				StatisticsManager.StatSheet statSheet = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdcb2ff44fc70c31a5ec9c7f0156d8f27(playerInfoSync);
				if (statSheet != null)
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
					statSheet.cca84ca4deababdecf8f3d8cc7a45edb9(false);
				}
			}
		}
		m_isControlLocked = false;
	}

	public bool cf5958ca7bf2c10a23368dbc19f24a619()
	{
		return m_isControlLocked;
	}

	public bool c0c86fb4d044c654b1e26019953887548(string c212885fdedb9b9fd5818b72e1ba772cf)
	{
		InputKeyBinding inputKeyBinding = cb6c3e11921c393d0b4fa2ae883504d64(c212885fdedb9b9fd5818b72e1ba772cf);
		if (inputKeyBinding.primaryKey == KeyCode.None)
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
			if (inputKeyBinding.seconderyKey == KeyCode.None)
			{
				return m_reader.c0c86fb4d044c654b1e26019953887548(c212885fdedb9b9fd5818b72e1ba772cf);
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
		int result;
		if (!m_reader.c7757051abb1c6405db9836fc93b27b1e(inputKeyBinding.primaryKey))
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
			result = (m_reader.c7757051abb1c6405db9836fc93b27b1e(inputKeyBinding.seconderyKey) ? 1 : 0);
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	public float c8bb22a671c1c2a7c9a01ddc52a812d1d(string c212885fdedb9b9fd5818b72e1ba772cf)
	{
		return m_reader.c8bb22a671c1c2a7c9a01ddc52a812d1d(c212885fdedb9b9fd5818b72e1ba772cf);
	}

	public bool c335a1480fba59f7a546ea6803a9374b9(string c212885fdedb9b9fd5818b72e1ba772cf)
	{
		InputKeyBinding inputKeyBinding = cb6c3e11921c393d0b4fa2ae883504d64(c212885fdedb9b9fd5818b72e1ba772cf);
		if (inputKeyBinding.primaryKey == KeyCode.None)
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
			if (inputKeyBinding.seconderyKey == KeyCode.None)
			{
				return m_reader.c335a1480fba59f7a546ea6803a9374b9(c212885fdedb9b9fd5818b72e1ba772cf);
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
		int result;
		if (!m_reader.cd506b2de8384c3adbc5bfedd9c774b24(inputKeyBinding.primaryKey))
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
			result = (m_reader.cd506b2de8384c3adbc5bfedd9c774b24(inputKeyBinding.seconderyKey) ? 1 : 0);
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	public bool cd9a869e29c4cce44fbee025f63774fa9(string c212885fdedb9b9fd5818b72e1ba772cf)
	{
		InputKeyBinding inputKeyBinding = cb6c3e11921c393d0b4fa2ae883504d64(c212885fdedb9b9fd5818b72e1ba772cf);
		if (inputKeyBinding.primaryKey == KeyCode.None)
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
			if (inputKeyBinding.seconderyKey == KeyCode.None)
			{
				return m_reader.cd9a869e29c4cce44fbee025f63774fa9(c212885fdedb9b9fd5818b72e1ba772cf);
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
		int result;
		if (!m_reader.cbf1d27094f0bbdacb081739b10f4671c(inputKeyBinding.primaryKey))
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
			result = (m_reader.cbf1d27094f0bbdacb081739b10f4671c(inputKeyBinding.seconderyKey) ? 1 : 0);
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	private InputKeyBinding cb6c3e11921c393d0b4fa2ae883504d64(string c212885fdedb9b9fd5818b72e1ba772cf)
	{
		if (m_inputMap.ContainsKey(c212885fdedb9b9fd5818b72e1ba772cf))
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
					return m_inputMap[c212885fdedb9b9fd5818b72e1ba772cf];
				}
			}
		}
		return new InputKeyBinding(KeyCode.None, KeyCode.None);
	}

	public bool cf444c2ed32312476a266d34e37bfd02f(int cc5b2a83f0ff489309eb5bc89970fb973, bool cb4545d0934b9eb94d684000578dcd1ac = false)
	{
		return m_reader.cf444c2ed32312476a266d34e37bfd02f(cc5b2a83f0ff489309eb5bc89970fb973, cb4545d0934b9eb94d684000578dcd1ac);
	}

	public bool ca561485909b8620867b83991201b70d3(int cc5b2a83f0ff489309eb5bc89970fb973, bool cb4545d0934b9eb94d684000578dcd1ac = false)
	{
		return m_reader.ca561485909b8620867b83991201b70d3(cc5b2a83f0ff489309eb5bc89970fb973, cb4545d0934b9eb94d684000578dcd1ac);
	}

	public bool c5adfffc6150c77758b5ca44b059aee74(int cc5b2a83f0ff489309eb5bc89970fb973, bool cb4545d0934b9eb94d684000578dcd1ac = false)
	{
		return m_reader.c5adfffc6150c77758b5ca44b059aee74(cc5b2a83f0ff489309eb5bc89970fb973, cb4545d0934b9eb94d684000578dcd1ac);
	}

	public Dictionary<string, InputKeyBinding> c713514ae3f84c625e27a4bcd88260196()
	{
		Dictionary<string, InputKeyBinding> dictionary = new Dictionary<string, InputKeyBinding>();
		using (Dictionary<string, InputKeyBinding>.Enumerator enumerator = m_inputMap.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, InputKeyBinding> current = enumerator.Current;
				if (!m_customableFunctionCollection.Contains(current.Key))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				dictionary.Add(current.Key, current.Value);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				return dictionary;
			}
		}
	}

	public KeyCode c9c68d4ce4ddf219f5a364d5155b6555c()
	{
		KeyCode result = KeyCode.None;
		using (HashSet<KeyCode>.Enumerator enumerator = m_customableKeycodeCollection.GetEnumerator())
		{
			while (true)
			{
				if (enumerator.MoveNext())
				{
					KeyCode current = enumerator.Current;
					if (!m_reader.cbf1d27094f0bbdacb081739b10f4671c(current))
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
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						result = current;
						break;
					}
					break;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_004e;
					}
					continue;
					end_IL_004e:
					break;
				}
				break;
			}
		}
		return result;
	}

	public InputKeyBinding c6424e83f699e460eeacbecd73faa194e(string c8e67188c9a1ee9e95f98cd7c0a6c285d)
	{
		InputKeyBinding value = null;
		m_inputMap.TryGetValue(c8e67188c9a1ee9e95f98cd7c0a6c285d, out value);
		return value;
	}

	public void cbe349de0b5402dfd2f6c96aa50be7175(string c8e67188c9a1ee9e95f98cd7c0a6c285d)
	{
		InputKeyBinding value = null;
		if (!m_defaultInputMap.TryGetValue(c8e67188c9a1ee9e95f98cd7c0a6c285d, out value))
		{
			return;
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
			c239cb24a0f61f5bdbbe34f8bc97732bc(c8e67188c9a1ee9e95f98cd7c0a6c285d, value.primaryKey, value.seconderyKey);
			return;
		}
	}

	public void c239cb24a0f61f5bdbbe34f8bc97732bc(string c8e67188c9a1ee9e95f98cd7c0a6c285d, KeyCode c9e132bdc97a9dead215c517590fd951d, KeyCode cfc67c43484c0d1b4c7451fc4de630e94)
	{
		InputKeyBinding value = null;
		if (m_inputMap.TryGetValue(c8e67188c9a1ee9e95f98cd7c0a6c285d, out value))
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					value.primaryKey = c9e132bdc97a9dead215c517590fd951d;
					value.seconderyKey = cfc67c43484c0d1b4c7451fc4de630e94;
					return;
				}
			}
		}
		value = new InputKeyBinding(c9e132bdc97a9dead215c517590fd951d, cfc67c43484c0d1b4c7451fc4de630e94);
		m_inputMap.Add(c8e67188c9a1ee9e95f98cd7c0a6c285d, value);
	}

	public void cbe349de0b5402dfd2f6c96aa50be7175()
	{
		m_inputMap.Clear();
		m_defaultInputMap.Clear();
		if (m_presetControlSchemeSetup.mControlSchemeList != null)
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
			if (m_presetControlSchemeSetup.mControlSchemeList.Length > 0)
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
				ControlScheme controlScheme = m_presetControlSchemeSetup.mControlSchemeList[0];
				if (controlScheme != null)
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
					if (controlScheme.mKeyBindingList != null)
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
						KeyBindingItem[] mKeyBindingList = controlScheme.mKeyBindingList;
						foreach (KeyBindingItem keyBindingItem in mKeyBindingList)
						{
							KeyCode value = KeyCode.None;
							KeyCode value2 = KeyCode.None;
							m_configToGlobalKeycodeMap.TryGetValue(keyBindingItem.mPrimaryKey, out value);
							m_configToGlobalKeycodeMap.TryGetValue(keyBindingItem.mSecondaryKey, out value2);
							c239cb24a0f61f5bdbbe34f8bc97732bc(keyBindingItem.mControlAction.ToString(), value, value2);
							InputKeyBinding value3 = new InputKeyBinding(value, value2);
							m_defaultInputMap.Add(keyBindingItem.mControlAction.ToString(), value3);
							m_customableFunctionCollection.Add(keyBindingItem.mControlAction.ToString());
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
			}
		}
		m_inputMap.Add("Escape", new InputKeyBinding(KeyCode.Escape, KeyCode.None));
		m_inputMap.Add("UIChatInput", new InputKeyBinding(KeyCode.Return, KeyCode.None));
		m_inputMap.Add("Fire1", new InputKeyBinding(KeyCode.Mouse0, KeyCode.None));
		m_inputMap.Add("Delete", new InputKeyBinding(KeyCode.Delete, KeyCode.None));
	}

	public void c482304868a321945e477a8cb4ab73e0c(OnKeySettingsChanged c2db84530ef366a6deb001d449d4aa151)
	{
		if (m_listenersOnSettingsChanged.Contains(c2db84530ef366a6deb001d449d4aa151))
		{
			return;
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
			m_listenersOnSettingsChanged.Add(c2db84530ef366a6deb001d449d4aa151);
			return;
		}
	}

	public void ca0ba7ae34e33da09ae2c07b68968aedc(OnKeySettingsChanged c2db84530ef366a6deb001d449d4aa151)
	{
		if (!m_listenersOnSettingsChanged.Contains(c2db84530ef366a6deb001d449d4aa151))
		{
			return;
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_listenersOnSettingsChanged.Remove(c2db84530ef366a6deb001d449d4aa151);
			return;
		}
	}
}
