using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using UnityEngine;
using XsdSettings;

public class GameSettingMgr : c06ca0e618478c23eba3419653a19760f<GameSettingMgr>
{
	public enum SettingItemDataType
	{
		ConfigItem = 0,
		KeyBinding = 1
	}

	public class SettingItemData
	{
		public bool bDirty;

		public bool bEnable = true;

		public SettingItemDataType type;

		public SettingItemValueContainer curValue = new SettingItemValueContainer();

		public SettingItemValueContainer newValue = new SettingItemValueContainer();

		public SettingItem config;

		public ControlAction controlAction;

		public List<SettingItemData> children = new List<SettingItemData>();

		public void c89e353632385d799ae18926f4d1896ab()
		{
			if (!bEnable)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						curValue.fValue = newValue.fValue;
						curValue.iIndex = newValue.iIndex;
						curValue.bOn = newValue.bOn;
						curValue.keyBinding.primaryKey = newValue.keyBinding.primaryKey;
						curValue.keyBinding.seconderyKey = newValue.keyBinding.seconderyKey;
						bDirty = false;
						return;
					}
				}
			}
			if (bDirty)
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
				cc84907fc81a9d84c98dd3bd48c4f7297(newValue);
				curValue.fValue = newValue.fValue;
				curValue.iIndex = newValue.iIndex;
				curValue.bOn = newValue.bOn;
				curValue.keyBinding.primaryKey = newValue.keyBinding.primaryKey;
				curValue.keyBinding.seconderyKey = newValue.keyBinding.seconderyKey;
				bDirty = false;
			}
			using (List<SettingItemData>.Enumerator enumerator = children.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					SettingItemData current = enumerator.Current;
					current.c89e353632385d799ae18926f4d1896ab();
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

		protected void cc84907fc81a9d84c98dd3bd48c4f7297(SettingItemValueContainer c73e922e268b0abc66aaf3f8e9f3ff2f2)
		{
			if (type == SettingItemDataType.ConfigItem)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						if (config == null)
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
									return;
								}
							}
						}
						AudioBusManager audioBusManager = c26e9bf24729ce08e5a52fb0e34a69391.c7088de59e49f7108f520cf7e0bae167e;
						if (c06ca0e618478c23eba3419653a19760f<AudioManager>.c5def92cf2ece25f46fbe9356a28a245b)
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
							audioBusManager = cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.cc6e3847a57e10af584d6f85377557e52;
						}
						PlayerBehavior playerBehavior = cb3ec701ea449e1e464abb972e20f8c31.c7088de59e49f7108f520cf7e0bae167e;
						if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86)
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
								playerBehavior = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689().GetComponent<PlayerBehavior>();
							}
						}
						switch (config.mFunctionType)
						{
						case SettingFunctionType.Mute:
							cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c9d5aded6668d31de4d83fc0acc0b5378 = c73e922e268b0abc66aaf3f8e9f3ff2f2.bOn;
							break;
						case SettingFunctionType.MasterVolume:
							if (audioBusManager != null)
							{
								while (true)
								{
									switch (1)
									{
									case 0:
										break;
									default:
										if (c73e922e268b0abc66aaf3f8e9f3ff2f2.fValue >= 0f)
										{
											while (true)
											{
												switch (1)
												{
												case 0:
													break;
												default:
												{
													int num2 = config.mRange.RightValue - config.mRange.LeftValue;
													audioBusManager.cdec556f45be085037f7dd85ddc1b9e24(AudioBusManager.BusDescriptor.Master, c73e922e268b0abc66aaf3f8e9f3ff2f2.fValue / (float)num2);
													return;
												}
												}
											}
										}
										return;
									}
								}
							}
							break;
						case SettingFunctionType.SFXVolume:
							if (audioBusManager != null)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
									{
										int num3 = config.mRange.RightValue - config.mRange.LeftValue;
										audioBusManager.cdec556f45be085037f7dd85ddc1b9e24(AudioBusManager.BusDescriptor.SFX, c73e922e268b0abc66aaf3f8e9f3ff2f2.fValue / (float)num3);
										return;
									}
									}
								}
							}
							break;
						case SettingFunctionType.MusicVolume:
							if (audioBusManager != null)
							{
								while (true)
								{
									switch (6)
									{
									case 0:
										break;
									default:
									{
										int num = config.mRange.RightValue - config.mRange.LeftValue;
										audioBusManager.cdec556f45be085037f7dd85ddc1b9e24(AudioBusManager.BusDescriptor.Music, c73e922e268b0abc66aaf3f8e9f3ff2f2.fValue / (float)num);
										return;
									}
									}
								}
							}
							break;
						case SettingFunctionType.MouseSensitivity:
							if (playerBehavior != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
										playerBehavior.c3389544f22fed31da6c1ef5fb1f1ede8(c73e922e268b0abc66aaf3f8e9f3ff2f2.fValue);
										return;
									}
								}
							}
							break;
						case SettingFunctionType.OverallQuality:
							QualitySettings.SetQualityLevel(c73e922e268b0abc66aaf3f8e9f3ff2f2.iIndex);
							c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0152ca5a8975604e439dc2408c0c7cd9();
							break;
						case SettingFunctionType.FullScreen:
							c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.cd70fb9db099576feedfa82fd12a495b5(c73e922e268b0abc66aaf3f8e9f3ff2f2.bOn);
							c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0152ca5a8975604e439dc2408c0c7cd9();
							break;
						case SettingFunctionType.ScreenResolution:
							if (c73e922e268b0abc66aaf3f8e9f3ff2f2.iIndex < config.mResolutions.Length)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
									{
										IntPair intPair = config.mResolutions[c73e922e268b0abc66aaf3f8e9f3ff2f2.iIndex];
										c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.cfd94cabf4bc48ab0b63510121c0c5a11(intPair.LeftValue, intPair.RightValue);
										c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0152ca5a8975604e439dc2408c0c7cd9();
										return;
									}
									}
								}
							}
							break;
						case SettingFunctionType.InvertMouse:
							if (playerBehavior != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
							{
								while (true)
								{
									switch (6)
									{
									case 0:
										break;
									default:
										playerBehavior.c3e1675ba5245fab3594c507dca5bd645(c73e922e268b0abc66aaf3f8e9f3ff2f2.bOn);
										return;
									}
								}
							}
							break;
						case SettingFunctionType.CustomKeyBinding:
							break;
						case SettingFunctionType.HoldCrouching:
							if (playerBehavior != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
							{
								while (true)
								{
									switch (2)
									{
									case 0:
										break;
									default:
										playerBehavior.holdToCrouch = c73e922e268b0abc66aaf3f8e9f3ff2f2.bOn;
										return;
									}
								}
							}
							break;
						case SettingFunctionType.EchoDuration:
							if (c73e922e268b0abc66aaf3f8e9f3ff2f2.fValue > 0f)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
									{
										float fValue = c73e922e268b0abc66aaf3f8e9f3ff2f2.fValue;
										c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<EchoMessageView>().c138a9bf6f68646f1b362f208658268f1(fValue);
										return;
									}
									}
								}
							}
							break;
						case SettingFunctionType.AlwaysShowWeaponSlots:
							c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPlayerInfoView>().bAlwaysShowWeaponSlot = c73e922e268b0abc66aaf3f8e9f3ff2f2.bOn;
							break;
						case SettingFunctionType.ResetAllKeybindings:
							break;
						}
						return;
					}
					}
				}
			}
			if (type != SettingItemDataType.KeyBinding)
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
				c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c239cb24a0f61f5bdbbe34f8bc97732bc(controlAction.ToString(), c73e922e268b0abc66aaf3f8e9f3ff2f2.keyBinding.primaryKey, c73e922e268b0abc66aaf3f8e9f3ff2f2.keyBinding.seconderyKey);
				return;
			}
		}

		public void Reset()
		{
			c041cb08aebadb4da70b49eff0473237c();
			using (List<SettingItemData>.Enumerator enumerator = children.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					SettingItemData current = enumerator.Current;
					current.Reset();
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
					return;
				}
			}
		}

		protected void c041cb08aebadb4da70b49eff0473237c()
		{
			if (type != 0)
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
						return;
					}
				}
			}
			if (config == null)
			{
				return;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				if (config.mFunctionType == SettingFunctionType.CustomKeyBinding)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cbe349de0b5402dfd2f6c96aa50be7175();
							c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c036a49c5ac819ed8d99ca3f017217db5();
							return;
						}
					}
				}
				newValue.fValue = (curValue.fValue = config.mDefaultFloat);
				newValue.iIndex = (curValue.iIndex = config.mDefaultInt);
				newValue.bOn = (curValue.bOn = config.mDefaultBool);
				cc84907fc81a9d84c98dd3bd48c4f7297(curValue);
				return;
			}
		}

		public void c040ee5dc6011ac6f76e73d8f329ca070()
		{
			c7ed40b66320169efc03005c6b3d672cb();
			using (List<SettingItemData>.Enumerator enumerator = children.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					SettingItemData current = enumerator.Current;
					current.c7ed40b66320169efc03005c6b3d672cb();
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
					return;
				}
			}
		}

		protected void c7ed40b66320169efc03005c6b3d672cb()
		{
			if (!bDirty)
			{
				return;
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
				newValue.fValue = curValue.fValue;
				newValue.iIndex = curValue.iIndex;
				newValue.bOn = curValue.bOn;
				newValue.keyBinding.primaryKey = curValue.keyBinding.primaryKey;
				newValue.keyBinding.seconderyKey = curValue.keyBinding.seconderyKey;
				bDirty = false;
				return;
			}
		}

		public bool cdf7c343bf83c02bf4b38b1a0f00c8b5f()
		{
			int num;
			if (bDirty)
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
				num = (bEnable ? 1 : 0);
			}
			else
			{
				num = 0;
			}
			bool flag = (byte)num != 0;
			if (!flag)
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
				using (List<SettingItemData>.Enumerator enumerator = children.GetEnumerator())
				{
					while (true)
					{
						if (enumerator.MoveNext())
						{
							SettingItemData current = enumerator.Current;
							if (!current.cdf7c343bf83c02bf4b38b1a0f00c8b5f())
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
								flag = true;
								break;
							}
							break;
						}
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								goto end_IL_006f;
							}
							continue;
							end_IL_006f:
							break;
						}
						break;
					}
				}
			}
			return flag;
		}
	}

	public class SettingItemValueContainer
	{
		public float fValue = -1f;

		public int iIndex = -1;

		public bool bOn;

		public InputManager.InputKeyBinding keyBinding = new InputManager.InputKeyBinding();
	}

	public enum SettingSavingKeyword
	{
		dataType = 0,
		functionType = 1,
		fValue = 2,
		iIndex = 3,
		bOn = 4,
		action = 5,
		prikey = 6,
		seckey = 7,
		child = 8
	}

	protected class SettingNotificationListener : ICharacterServiceNotificationListerner
	{
		void ICharacterServiceNotificationListerner.OnGotMyCurrencies(CurrencyInfo currency)
		{
		}

		void ICharacterServiceNotificationListerner.OnExperienceUpdated(int experience)
		{
		}

		void ICharacterServiceNotificationListerner.OnGetPersonalSettings(string strSettings)
		{
			c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.OnGetPlayerSettingFromServer();
		}

		void ICharacterServiceNotificationListerner.OnSetPersonalSettings(int iResult)
		{
		}
	}

	protected const string PLAYERSETTING_KEY = "PlayerSetting";

	protected Dictionary<SettingCategory, List<SettingItemData>> _dicSettingsByCategory = new Dictionary<SettingCategory, List<SettingItemData>>();

	protected Dictionary<SettingFunctionType, SettingItemData> _dicSettingsByFunctionType = new Dictionary<SettingFunctionType, SettingItemData>();

	protected SettingNotificationListener _settingsListener = new SettingNotificationListener();

	protected bool _bNeedRestoreSettings;

	private void Start()
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/SettingMenu");
		SettingMenuSetup c7088de59e49f7108f520cf7e0bae167e = c2eb2bc806b4323d3b6604b78df855711.c7088de59e49f7108f520cf7e0bae167e;
		StringReader stringReader = new StringReader(textAsset.text);
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c5e39672077687e120035ac27f0a8725c.cc1720d05c75832f704b87474932341c3()));
			c7088de59e49f7108f520cf7e0bae167e = xmlSerializer.Deserialize(stringReader) as SettingMenuSetup;
			Category[] settings = c7088de59e49f7108f520cf7e0bae167e.Settings;
			foreach (Category category in settings)
			{
				List<SettingItemData> value = c70fb1e9764824c0e5eea76bc553d5e06.c7088de59e49f7108f520cf7e0bae167e;
				if (!_dicSettingsByCategory.TryGetValue(category.mCategoryType, out value))
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
					value = new List<SettingItemData>();
					_dicSettingsByCategory.Add(category.mCategoryType, value);
				}
				if (category.mConfigItems == null)
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
				SettingItem[] mConfigItems = category.mConfigItems;
				foreach (SettingItem settingItem in mConfigItems)
				{
					SettingItemData settingItemData = new SettingItemData();
					settingItemData.config = settingItem;
					settingItemData.curValue.fValue = settingItem.mDefaultFloat;
					settingItemData.curValue.iIndex = settingItem.mDefaultInt;
					settingItemData.curValue.bOn = settingItem.mDefaultBool;
					value.Add(settingItemData);
					_dicSettingsByFunctionType.Add(settingItem.mFunctionType, settingItemData);
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
				switch (4)
				{
				case 0:
					break;
				default:
					goto end_IL_017a;
				}
				continue;
				end_IL_017a:
				break;
			}
		}
		finally
		{
			if (stringReader != null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					((IDisposable)stringReader).Dispose();
					break;
				}
			}
		}
		c036a49c5ac819ed8d99ca3f017217db5();
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(_settingsListener);
		c8015718ea218f68d79d6da1042d65374();
		JSONObject jSONObject = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c6564f26209b847a2389a131f9a3d3768("PlayerSetting");
		if (jSONObject != null)
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
			OnGetSavedSettingsStrings(jSONObject.ToString());
		}
		string @string = PlayerPrefs.GetString("PlayerSetting");
		OnGetSavedSettingsStrings(@string);
		cba9a1d533f296a781d1a6f5df178eb4a();
		Resources.UnloadAsset(textAsset);
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		_dicSettingsByCategory.Clear();
		_dicSettingsByFunctionType.Clear();
	}

	public Dictionary<SettingCategory, List<SettingItemData>> c2fe4b25baec7aa8444d50ef50a249e27()
	{
		return _dicSettingsByCategory;
	}

	public void cdc7e489b7c407c7945b1a30f95c525c8(SettingCategory ccc12d01a2caed4c0bee1fb76f94cbefa)
	{
		List<SettingItemData> value = c70fb1e9764824c0e5eea76bc553d5e06.c7088de59e49f7108f520cf7e0bae167e;
		if (!_dicSettingsByCategory.TryGetValue(ccc12d01a2caed4c0bee1fb76f94cbefa, out value))
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
			using (List<SettingItemData>.Enumerator enumerator = value.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					SettingItemData current = enumerator.Current;
					current.Reset();
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}
	}

	public bool c645e159b14c940d3fb6c0970dff95827()
	{
		bool result = false;
		using (Dictionary<SettingFunctionType, SettingItemData>.ValueCollection.Enumerator enumerator = _dicSettingsByFunctionType.Values.GetEnumerator())
		{
			while (true)
			{
				if (enumerator.MoveNext())
				{
					SettingItemData current = enumerator.Current;
					if (!current.cdf7c343bf83c02bf4b38b1a0f00c8b5f())
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
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						result = true;
						break;
					}
					break;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						goto end_IL_004f;
					}
					continue;
					end_IL_004f:
					break;
				}
				break;
			}
		}
		return result;
	}

	public void cba9a1d533f296a781d1a6f5df178eb4a()
	{
		if (!c645e159b14c940d3fb6c0970dff95827())
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
			_bNeedRestoreSettings = true;
			using (Dictionary<SettingFunctionType, SettingItemData>.ValueCollection.Enumerator enumerator = _dicSettingsByFunctionType.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					SettingItemData current = enumerator.Current;
					current.c89e353632385d799ae18926f4d1896ab();
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
	}

	public void ca065b101124effd962c1722e232bfef8()
	{
		using (Dictionary<SettingFunctionType, SettingItemData>.ValueCollection.Enumerator enumerator = _dicSettingsByFunctionType.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				SettingItemData current = enumerator.Current;
				current.c040ee5dc6011ac6f76e73d8f329ca070();
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
				return;
			}
		}
	}

	public void cd70fb9db099576feedfa82fd12a495b5(bool cc7a217f366b539d5bf1ad385a25f2d22)
	{
		if (c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c13d6075d6ee54181527ae5452bddb1f9 != cc7a217f366b539d5bf1ad385a25f2d22)
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
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.cdc9296eaeada8fb29e6327e8ea46c263(cc7a217f366b539d5bf1ad385a25f2d22);
		}
		if (!cc7a217f366b539d5bf1ad385a25f2d22)
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
			Resolution resolution = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c89e060370172be264cf70d913cf785f5();
			SettingItemData value = null;
			if (!_dicSettingsByFunctionType.TryGetValue(SettingFunctionType.ScreenResolution, out value))
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
				if (value.config.mResolutions == null)
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
					if (value.config.mResolutions.Length <= 0)
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
						int iIndex = 0;
						int num = 0;
						while (true)
						{
							if (num < value.config.mResolutions.Length)
							{
								if (resolution.width == value.config.mResolutions[num].LeftValue)
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
									if (resolution.height == value.config.mResolutions[num].RightValue)
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
										iIndex = num;
										break;
									}
								}
								num++;
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
							break;
						}
						value.curValue.iIndex = iIndex;
						value.newValue.iIndex = iIndex;
						value.bDirty = false;
						return;
					}
				}
			}
		}
	}

	public void ce9c468c80f530b448d1ac8906148c9a2()
	{
		SettingItemData value = null;
		if (!_dicSettingsByFunctionType.TryGetValue(SettingFunctionType.FullScreen, out value))
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
			SettingItemData value2 = null;
			if (!_dicSettingsByFunctionType.TryGetValue(SettingFunctionType.ScreenResolution, out value2))
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
				if (value.bDirty)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							value2.bEnable = !value.newValue.bOn;
							return;
						}
					}
				}
				value2.bEnable = !value.curValue.bOn;
				return;
			}
		}
	}

	public bool cbe5897c1bba97712ed8ffb95b193d497(SettingFunctionType cf11bf683acb62f2e2660a87f610641f0)
	{
		bool result = false;
		SettingItemData value = null;
		if (_dicSettingsByFunctionType.TryGetValue(cf11bf683acb62f2e2660a87f610641f0, out value))
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
			result = value.curValue.bOn;
		}
		return result;
	}

	public float c93a361c45829617f798f69b2d0c74a59(SettingFunctionType cf11bf683acb62f2e2660a87f610641f0)
	{
		float result = 0f;
		SettingItemData value = null;
		if (_dicSettingsByFunctionType.TryGetValue(cf11bf683acb62f2e2660a87f610641f0, out value))
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
			result = value.curValue.fValue;
		}
		return result;
	}

	public void OnGetPlayerSettingFromServer()
	{
		JSONObject jSONObject = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c6564f26209b847a2389a131f9a3d3768("PlayerSetting");
		if (jSONObject == null)
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
			OnGetSavedSettingsStrings(jSONObject.ToString());
			return;
		}
	}

	public void c036a49c5ac819ed8d99ca3f017217db5()
	{
		SettingItemData value = null;
		if (!_dicSettingsByFunctionType.TryGetValue(SettingFunctionType.CustomKeyBinding, out value))
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
			value.children.Clear();
			using (Dictionary<string, InputManager.InputKeyBinding>.Enumerator enumerator = c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c713514ae3f84c625e27a4bcd88260196().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, InputManager.InputKeyBinding> current = enumerator.Current;
					SettingItemData settingItemData = new SettingItemData();
					settingItemData.type = SettingItemDataType.KeyBinding;
					settingItemData.controlAction = (ControlAction)(int)Enum.Parse(Type.GetTypeFromHandle(c2010035149f209604d9f68049baef5aa.cc1720d05c75832f704b87474932341c3()), current.Key);
					settingItemData.curValue.keyBinding.primaryKey = current.Value.primaryKey;
					settingItemData.curValue.keyBinding.seconderyKey = current.Value.seconderyKey;
					settingItemData.newValue.keyBinding.primaryKey = current.Value.primaryKey;
					settingItemData.newValue.keyBinding.seconderyKey = current.Value.seconderyKey;
					value.children.Add(settingItemData);
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}
	}

	protected void c8015718ea218f68d79d6da1042d65374()
	{
		Resolution resolution = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c89e060370172be264cf70d913cf785f5();
		Resolution c36964cf41281414170f34ee68bef6c = default(Resolution);
		c6db7dc205a7d9988b99bd67708d3c321.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		c36964cf41281414170f34ee68bef6c.height = 0;
		c36964cf41281414170f34ee68bef6c.width = 0;
		Resolution c36964cf41281414170f34ee68bef6c2 = default(Resolution);
		c6db7dc205a7d9988b99bd67708d3c321.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c2);
		c36964cf41281414170f34ee68bef6c2.height = 0;
		c36964cf41281414170f34ee68bef6c2.width = 0;
		bool bOn = false;
		SettingItemData value = null;
		SettingItemData value2 = null;
		if (!_dicSettingsByFunctionType.TryGetValue(SettingFunctionType.ScreenResolution, out value))
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
					return;
				}
			}
		}
		if (!_dicSettingsByFunctionType.TryGetValue(SettingFunctionType.FullScreen, out value2))
		{
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
		List<IntPair> list = new List<IntPair>(value.config.mResolutions);
		int num = 0;
		while (num < list.Count)
		{
			if (list[num].LeftValue <= resolution.width)
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
				if (list[num].RightValue <= resolution.height)
				{
					num++;
					continue;
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
			list.RemoveAt(num);
		}
		Resolution c36964cf41281414170f34ee68bef6c3 = default(Resolution);
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			value.config.mResolutions = list.ToArray();
			bool flag = value.curValue.iIndex < 0;
			if (!flag)
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
				if (value.config != null)
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
					if (value.config.mResolutions != null)
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
						if (value.curValue.iIndex < value.config.mResolutions.Length)
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
							c36964cf41281414170f34ee68bef6c.width = value.config.mResolutions[value.curValue.iIndex].LeftValue;
							c36964cf41281414170f34ee68bef6c.height = value.config.mResolutions[value.curValue.iIndex].RightValue;
						}
					}
				}
				if (resolution.width >= c36964cf41281414170f34ee68bef6c.width)
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
					if (resolution.height >= c36964cf41281414170f34ee68bef6c.height)
					{
						goto IL_023b;
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
				flag = true;
			}
			goto IL_023b;
			IL_023b:
			if (flag)
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
				if (value.config != null)
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
					if (value.config.mResolutions != null)
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
						IntPair[] mResolutions = value.config.mResolutions;
						int num2 = 0;
						while (true)
						{
							if (num2 < mResolutions.Length)
							{
								IntPair intPair = mResolutions[num2];
								if (intPair.LeftValue == resolution.width)
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
									if (intPair.RightValue == resolution.height)
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
										c36964cf41281414170f34ee68bef6c2 = resolution;
										bOn = true;
										break;
									}
								}
								num2++;
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
							break;
						}
					}
				}
				if (c36964cf41281414170f34ee68bef6c2.width == 0)
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
					List<Resolution> list2 = new List<Resolution>();
					if (value.config != null)
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
						if (value.config.mResolutions != null)
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
							IntPair[] mResolutions2 = value.config.mResolutions;
							foreach (IntPair intPair2 in mResolutions2)
							{
								c6db7dc205a7d9988b99bd67708d3c321.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c3);
								c36964cf41281414170f34ee68bef6c3.width = intPair2.LeftValue;
								c36964cf41281414170f34ee68bef6c3.height = intPair2.RightValue;
								list2.Add(c36964cf41281414170f34ee68bef6c3);
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
							list2.Sort(c26be2e55cd36a2b4d22eee14eaeb3cae);
						}
					}
					using (List<Resolution>.Enumerator enumerator = list2.GetEnumerator())
					{
						while (true)
						{
							if (enumerator.MoveNext())
							{
								Resolution current = enumerator.Current;
								if (current.width >= resolution.width)
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
								if (current.height >= resolution.height)
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
									c36964cf41281414170f34ee68bef6c2 = current;
									bOn = false;
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
									goto end_IL_0424;
								}
								continue;
								end_IL_0424:
								break;
							}
							break;
						}
					}
				}
			}
			else
			{
				c36964cf41281414170f34ee68bef6c2 = c36964cf41281414170f34ee68bef6c;
				if (value2 != null)
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
					bOn = value2.curValue.bOn;
				}
			}
			if (c36964cf41281414170f34ee68bef6c2.width == 0)
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
				if (c36964cf41281414170f34ee68bef6c2.height == 0)
				{
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
				if (value.config != null)
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
					if (value.config.mResolutions != null)
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
						for (int j = 0; j < value.config.mResolutions.Length; j++)
						{
							if (value.config.mResolutions[j].LeftValue != c36964cf41281414170f34ee68bef6c2.width)
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
							if (value.config.mResolutions[j].RightValue != c36964cf41281414170f34ee68bef6c2.height)
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
								break;
							}
							value.newValue.iIndex = j;
							value.bDirty = true;
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
				}
				if (value2 == null)
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
					value2.newValue.bOn = bOn;
					value2.bDirty = true;
					return;
				}
			}
		}
	}

	protected int c26be2e55cd36a2b4d22eee14eaeb3cae(Resolution cb23757880698a65db256be0a48f561b3, Resolution cc1fa3171fa0e7211805389773c23a296)
	{
		return cb23757880698a65db256be0a48f561b3.width - cc1fa3171fa0e7211805389773c23a296.width;
	}

	public void c0d2abbe8042d63a7b888a59e687a440a()
	{
		if (!_bNeedRestoreSettings)
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
					return;
				}
			}
		}
		ce9c468c80f530b448d1ac8906148c9a2();
		List<SettingItemData> list = new List<SettingItemData>();
		List<SettingItemData> list2 = new List<SettingItemData>();
		using (Dictionary<SettingFunctionType, SettingItemData>.ValueCollection.Enumerator enumerator = _dicSettingsByFunctionType.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				SettingItemData current = enumerator.Current;
				SettingStoreLocation mStoreLocation = current.config.mStoreLocation;
				if (mStoreLocation != 0)
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
					if (mStoreLocation != SettingStoreLocation.Local)
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
					}
					else
					{
						list2.Add(current);
					}
				}
				else
				{
					list.Add(current);
				}
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					goto end_IL_009a;
				}
				continue;
				end_IL_009a:
				break;
			}
		}
		JSONObject jSONObject = new JSONObject();
		JSONObject jSONObject2 = new JSONObject();
		using (List<SettingItemData>.Enumerator enumerator2 = list.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				SettingItemData current2 = enumerator2.Current;
				JSONObject obj = ceb362f0233d1234ea1ce72980e41205c(current2);
				jSONObject.Add(obj);
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					goto end_IL_00f7;
				}
				continue;
				end_IL_00f7:
				break;
			}
		}
		using (List<SettingItemData>.Enumerator enumerator3 = list2.GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				SettingItemData current3 = enumerator3.Current;
				JSONObject obj2 = ceb362f0233d1234ea1ce72980e41205c(current3);
				jSONObject2.Add(obj2);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					goto end_IL_0147;
				}
				continue;
				end_IL_0147:
				break;
			}
		}
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ca8e28f0eeee09fefe7987ee42cd7926d("PlayerSetting", jSONObject);
		string value = jSONObject2.ToString();
		PlayerPrefs.SetString("PlayerSetting", value);
		_bNeedRestoreSettings = false;
	}

	public void OnGetSavedSettingsStrings(string strPlayerSettings)
	{
		if (strPlayerSettings != null)
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
			if (strPlayerSettings.Length > 0)
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
				c8d3446ec163c7645fba62e0aa6c2daac(strPlayerSettings);
			}
		}
		ce9c468c80f530b448d1ac8906148c9a2();
		cba9a1d533f296a781d1a6f5df178eb4a();
	}

	protected JSONObject ceb362f0233d1234ea1ce72980e41205c(SettingItemData c591d56a94543e3559945c497f37126c4)
	{
		if (c591d56a94543e3559945c497f37126c4 == null)
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
					return null;
				}
			}
		}
		JSONObject jSONObject = new JSONObject();
		jSONObject.AddField(0.ToString(), (int)c591d56a94543e3559945c497f37126c4.type);
		if (c591d56a94543e3559945c497f37126c4.type == SettingItemDataType.ConfigItem)
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
			jSONObject.AddField(1.ToString(), (int)c591d56a94543e3559945c497f37126c4.config.mFunctionType);
			switch (c591d56a94543e3559945c497f37126c4.config.mDisplayType)
			{
			case SettingDisplayType.Range:
				jSONObject.AddField(2.ToString(), c591d56a94543e3559945c497f37126c4.curValue.fValue);
				break;
			case SettingDisplayType.Options:
				jSONObject.AddField(3.ToString(), c591d56a94543e3559945c497f37126c4.curValue.iIndex);
				break;
			case SettingDisplayType.Toggle:
				jSONObject.AddField(4.ToString(), c591d56a94543e3559945c497f37126c4.curValue.bOn);
				break;
			}
		}
		else if (c591d56a94543e3559945c497f37126c4.type == SettingItemDataType.KeyBinding)
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
			jSONObject.AddField(5.ToString(), (int)c591d56a94543e3559945c497f37126c4.controlAction);
			jSONObject.AddField(6.ToString(), (int)c591d56a94543e3559945c497f37126c4.curValue.keyBinding.primaryKey);
			jSONObject.AddField(7.ToString(), (int)c591d56a94543e3559945c497f37126c4.curValue.keyBinding.seconderyKey);
		}
		JSONObject jSONObject2 = new JSONObject();
		for (int i = 0; i < c591d56a94543e3559945c497f37126c4.children.Count; i++)
		{
			SettingItemData c591d56a94543e3559945c497f37126c5 = c591d56a94543e3559945c497f37126c4.children[i];
			JSONObject obj = ceb362f0233d1234ea1ce72980e41205c(c591d56a94543e3559945c497f37126c5);
			jSONObject2.Add(obj);
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			jSONObject.AddField(8.ToString(), jSONObject2);
			return jSONObject;
		}
	}

	protected void c8d3446ec163c7645fba62e0aa6c2daac(string c4044ad14fb75a75e4d249a5ce7bf7047)
	{
		JSONObject jSONObject = JSONObject.Create(c4044ad14fb75a75e4d249a5ce7bf7047);
		if (jSONObject == null)
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
			if (jSONObject.list == null)
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
			using (List<JSONObject>.Enumerator enumerator = jSONObject.list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					JSONObject current = enumerator.Current;
					JSONObject field = current.GetField(1.ToString());
					SettingItemData value = null;
					if (field == null)
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
					int num = (int)field.n;
					SettingFunctionType key = (SettingFunctionType)num;
					if (!_dicSettingsByFunctionType.TryGetValue(key, out value))
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
					cca106dc8ea3f0aafee8baf79c652f046(current, value);
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
	}

	protected void cca106dc8ea3f0aafee8baf79c652f046(JSONObject cd62a05ffb74b80a7158b8a2dafb7b689, SettingItemData c6887d67d8a0ccf1b733f90ce230cfbc1)
	{
		if (cd62a05ffb74b80a7158b8a2dafb7b689 == null)
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
			if (c6887d67d8a0ccf1b733f90ce230cfbc1 == null)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			JSONObject c7088de59e49f7108f520cf7e0bae167e = c1fc109ab9a1a5aeb1d8cb5eb3690b9be.c7088de59e49f7108f520cf7e0bae167e;
			if (c6887d67d8a0ccf1b733f90ce230cfbc1.type == SettingItemDataType.ConfigItem)
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
				switch (c6887d67d8a0ccf1b733f90ce230cfbc1.config.mDisplayType)
				{
				case SettingDisplayType.Range:
				{
					c7088de59e49f7108f520cf7e0bae167e = cd62a05ffb74b80a7158b8a2dafb7b689.GetField(2.ToString());
					if (c7088de59e49f7108f520cf7e0bae167e == null)
					{
						break;
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
					float n = c7088de59e49f7108f520cf7e0bae167e.n;
					c6887d67d8a0ccf1b733f90ce230cfbc1.curValue.fValue = n;
					c6887d67d8a0ccf1b733f90ce230cfbc1.newValue.fValue = n;
					break;
				}
				case SettingDisplayType.Options:
				{
					c7088de59e49f7108f520cf7e0bae167e = cd62a05ffb74b80a7158b8a2dafb7b689.GetField(3.ToString());
					if (c7088de59e49f7108f520cf7e0bae167e == null)
					{
						break;
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
					int iIndex = (int)c7088de59e49f7108f520cf7e0bae167e.n;
					c6887d67d8a0ccf1b733f90ce230cfbc1.curValue.iIndex = iIndex;
					c6887d67d8a0ccf1b733f90ce230cfbc1.newValue.iIndex = iIndex;
					break;
				}
				case SettingDisplayType.Toggle:
				{
					c7088de59e49f7108f520cf7e0bae167e = cd62a05ffb74b80a7158b8a2dafb7b689.GetField(4.ToString());
					if (c7088de59e49f7108f520cf7e0bae167e == null)
					{
						break;
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
					bool b = c7088de59e49f7108f520cf7e0bae167e.b;
					c6887d67d8a0ccf1b733f90ce230cfbc1.curValue.bOn = b;
					c6887d67d8a0ccf1b733f90ce230cfbc1.newValue.bOn = b;
					break;
				}
				}
			}
			else if (c6887d67d8a0ccf1b733f90ce230cfbc1.type == SettingItemDataType.KeyBinding)
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
				c7088de59e49f7108f520cf7e0bae167e = cd62a05ffb74b80a7158b8a2dafb7b689.GetField(6.ToString());
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
					int primaryKey = (int)c7088de59e49f7108f520cf7e0bae167e.n;
					c6887d67d8a0ccf1b733f90ce230cfbc1.curValue.keyBinding.primaryKey = (KeyCode)primaryKey;
					c6887d67d8a0ccf1b733f90ce230cfbc1.newValue.keyBinding.primaryKey = (KeyCode)primaryKey;
				}
				c7088de59e49f7108f520cf7e0bae167e = cd62a05ffb74b80a7158b8a2dafb7b689.GetField(7.ToString());
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
					int seconderyKey = (int)c7088de59e49f7108f520cf7e0bae167e.n;
					c6887d67d8a0ccf1b733f90ce230cfbc1.curValue.keyBinding.seconderyKey = (KeyCode)seconderyKey;
					c6887d67d8a0ccf1b733f90ce230cfbc1.newValue.keyBinding.seconderyKey = (KeyCode)seconderyKey;
				}
			}
			c6887d67d8a0ccf1b733f90ce230cfbc1.bDirty = true;
			JSONObject field = cd62a05ffb74b80a7158b8a2dafb7b689.GetField(8.ToString());
			if (field == null)
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
				if (field.list == null)
				{
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
				using (List<SettingItemData>.Enumerator enumerator = c6887d67d8a0ccf1b733f90ce230cfbc1.children.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						SettingItemData current = enumerator.Current;
						if (current.type != SettingItemDataType.KeyBinding)
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
						using (List<JSONObject>.Enumerator enumerator2 = field.list.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								JSONObject current2 = enumerator2.Current;
								JSONObject field2 = current2.GetField(5.ToString());
								if (field2 == null)
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
								int num = (int)field2.n;
								int controlAction = (int)current.controlAction;
								if (num != controlAction)
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
								cca106dc8ea3f0aafee8baf79c652f046(current2, current);
							}
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
									goto end_IL_02df;
								}
								continue;
								end_IL_02df:
								break;
							}
						}
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
			}
		}
	}
}
