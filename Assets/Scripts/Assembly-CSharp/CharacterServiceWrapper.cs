using System.Collections.Generic;
using A;
using XsdSettings;

public class CharacterServiceWrapper : ServiceWrapper<ICharacterServiceWrapper, CharacterServiceWrapper>
{
	private Character m_character;

	private List<ICharacterServiceNotificationListerner> m_listerner = new List<ICharacterServiceNotificationListerner>();

	private JSONObject m_PlayerSettingContainer;

	public void c28e7fb4a7d03eef0acca90b1bd76a2c9(ICharacterServiceNotificationListerner c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_listerner.Add(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void c704834a4a19f1f8555b44d9c021845ab(ICharacterServiceNotificationListerner c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_listerner.Remove(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void c26dcadb6c3e9da3320f7f77afe3b6f30(Character caadc19f3b6ef506913862a46cd09ddf6)
	{
		m_character = caadc19f3b6ef506913862a46cd09ddf6;
		if (m_wrapperOnline != null)
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
			(m_wrapperOnline as CharacterServiceWrapperOnline).ccc266b2f103e4a81ebf4e8e0e3e0aeb2(m_character.Currency);
		}
		if (m_wrapperSession == null)
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
			(m_wrapperSession as CharacterServiceWrapperSession).ccc266b2f103e4a81ebf4e8e0e3e0aeb2(m_character.Currency);
			return;
		}
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		m_wrapperOnline = new CharacterServiceWrapperOnline();
		m_wrapperSession = new CharacterServiceWrapperSession();
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ce44f2a4a8767f0c745f29d10533f3624(OnNotifyAntiAddiction);
		c3357ebacf41523207dec1c272b0c2753();
		base.cd93285db16841148ed53a5bbeb35cf20();
	}

	protected override ICharacterServiceWrapper c9374c9e18d64e753feff5ba5622a02ad()
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
				if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
					if (m_wrapperSession.c39df47367fa21412aabfef05d9972f8c())
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								return m_wrapperSession;
							}
						}
					}
				}
			}
		}
		return m_wrapperOnline;
	}

	public int c623008f5bbe4bf72af447d08f62aa043()
	{
		return c9374c9e18d64e753feff5ba5622a02ad().c623008f5bbe4bf72af447d08f62aa043();
	}

	public int c7513e66c4e0fc55e6fea9dd9cb8b9943()
	{
		return c9374c9e18d64e753feff5ba5622a02ad().c7513e66c4e0fc55e6fea9dd9cb8b9943();
	}

	public string c4c40c6af474a3f102f58135c8f5f8409()
	{
		return c9374c9e18d64e753feff5ba5622a02ad().c4c40c6af474a3f102f58135c8f5f8409();
	}

	public int ceb10167333758220ffb9bc66317ad763()
	{
		return c9374c9e18d64e753feff5ba5622a02ad().ceb10167333758220ffb9bc66317ad763();
	}

	public CurrencyInfo c9f30498b55d5d8ebb2b670dc3a42584b()
	{
		return c9374c9e18d64e753feff5ba5622a02ad().c9f30498b55d5d8ebb2b670dc3a42584b();
	}

	public AvatarDNA c093d70e3287743ce2bc905d2c4b341f3()
	{
		return c9374c9e18d64e753feff5ba5622a02ad().c093d70e3287743ce2bc905d2c4b341f3();
	}

	private void cc32a9c0a9f235c7d77e84473fc0c0a68(string cd2e0bebe497fc016a1867e4165d94adf)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cdfa79ad431f569bb78954d4da9bf4eec(cd2e0bebe497fc016a1867e4165d94adf);
	}

	public void c3357ebacf41523207dec1c272b0c2753()
	{
		c9374c9e18d64e753feff5ba5622a02ad().c3357ebacf41523207dec1c272b0c2753();
	}

	public void cb7dd5fe3098d3d1cbef965add21fb7c0(byte[] ca35c0055cf7b1f9aafdd9d211099db29)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cb7dd5fe3098d3d1cbef965add21fb7c0(ca35c0055cf7b1f9aafdd9d211099db29);
	}

	public float ce34672c48c333964ff0b398bfef60e97()
	{
		ItemDNA itemDNA = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4e0dae6a16a8a80ddb5214a896b9df58(c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c91233b4b8268e8e24a4daa8c053e41ec());
		if (itemDNA == null)
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
					return 0f;
				}
			}
		}
		WeaponAttribute attribute = itemDNA.ca79da172938fdc8c067fb64242b6174a().m_attribute;
		if (attribute == null)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return 0f;
				}
			}
		}
		return FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(attribute.m_weaponAttribute[100].m_attributeValue as FloatAttributeValue);
	}

	public int c21ba23788489638976ebd81412cb81fb(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b, CharacterSetup cf8e1b1eccef027335add5c2897880a2c)
	{
		for (int i = 0; i < cf8e1b1eccef027335add5c2897880a2c.m_inventorySetup.m_ammos.Length; i++)
		{
			if (cf8e1b1eccef027335add5c2897880a2c.m_inventorySetup.m_ammos[i].m_ammoType != c1e73ae4c18ab95639cb0c7604f21dc2b)
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
				return cf8e1b1eccef027335add5c2897880a2c.m_inventorySetup.m_ammos[i].m_ammoCount;
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			return 0;
		}
	}

	public int c19004a784fb16baa81abb5ab1b6ccdd0()
	{
		Dictionary<int, int>.Enumerator enumerator = OnAccessSingleton<IProgressionService, ProgressionService, ProgressionServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c50c5e39d33643f03b4da08ee3c5dce44().GetEnumerator();
		while (enumerator.MoveNext())
		{
			int key = enumerator.Current.Key;
			Playlist playlist = MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c2718b579e09549a1cd47620188a40a38(key);
			if (playlist == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!(playlist.m_gameMode == "GameModeTown"))
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
				return playlist.m_id;
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			return -1;
		}
	}

	public void ceaf946a4b1d023143d622c7be7019235()
	{
		c9374c9e18d64e753feff5ba5622a02ad().ceaf946a4b1d023143d622c7be7019235();
	}

	public void OnGotCurrencies(CurrencyInfo currency)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnGotMyCurrencies(currency);
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

	public void OnCurrenciesUpdated(CurrencyInfo currency)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnGotMyCurrencies(currency);
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
			return;
		}
	}

	public void OnExperienceUpdated(int experience)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnExperienceUpdated(experience);
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
			return;
		}
	}

	public int cb202b2ca376fe940339ca78de78383ab()
	{
		return (m_wrapperOnline as CharacterServiceWrapperOnline).cb202b2ca376fe940339ca78de78383ab();
	}

	public void OnNotifyAntiAddiction(int onlineMinutes, int offlineMinutes)
	{
		string text = AntiAddiction.ce195d62b7ed2e415d471893d74d8d9c7(onlineMinutes);
		if (string.IsNullOrEmpty(text))
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
			ChatView chatView = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ChatView>();
			if (chatView != null)
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
				chatView.cdf1b518a606ae8fae32a93c7d3abd6b2(ChatParameter.System, string.Empty, text, 0, string.Empty);
			}
			HUDWarningView hUDWarningView = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>();
			if (hUDWarningView == null)
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
				hUDWarningView.cea4468dc2438c0952d375da1a5a17607(text, OnClickedFunction, c68ab6f5d12f16a1d54aa92651de73463.c7088de59e49f7108f520cf7e0bae167e);
				return;
			}
		}
	}

	private void OnClickedFunction()
	{
	}

	public void OnSetPersonalSettings(int iResult)
	{
		using (List<ICharacterServiceNotificationListerner>.Enumerator enumerator = m_listerner.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ICharacterServiceNotificationListerner current = enumerator.Current;
				current.OnSetPersonalSettings(iResult);
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
				return;
			}
		}
	}

	public void OnGetPersonalSettings(string strSettings)
	{
		if (strSettings != null)
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
			if (strSettings.Length > 0)
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
				m_PlayerSettingContainer = JSONObject.Create(strSettings);
			}
		}
		using (List<ICharacterServiceNotificationListerner>.Enumerator enumerator = m_listerner.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ICharacterServiceNotificationListerner current = enumerator.Current;
				current.OnGetPersonalSettings(strSettings);
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

	public void ca8e28f0eeee09fefe7987ee42cd7926d(string c2fa253a94c3cb11f99907f0bc6f0b2f6, JSONObject cfeb8370582646b8696da2d4f86e1197f)
	{
		if (m_PlayerSettingContainer == null)
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
			m_PlayerSettingContainer = new JSONObject();
		}
		else if (m_PlayerSettingContainer.HasField(c2fa253a94c3cb11f99907f0bc6f0b2f6))
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
			m_PlayerSettingContainer.RemoveField(c2fa253a94c3cb11f99907f0bc6f0b2f6);
		}
		m_PlayerSettingContainer.AddField(c2fa253a94c3cb11f99907f0bc6f0b2f6, cfeb8370582646b8696da2d4f86e1197f);
		cc32a9c0a9f235c7d77e84473fc0c0a68(m_PlayerSettingContainer.ToString());
	}

	public JSONObject c6564f26209b847a2389a131f9a3d3768(string ca1a9e12162895aaee8db9abb22581bcc)
	{
		JSONObject result = c1fc109ab9a1a5aeb1d8cb5eb3690b9be.c7088de59e49f7108f520cf7e0bae167e;
		if (m_PlayerSettingContainer != null)
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
			if (m_PlayerSettingContainer.HasField(ca1a9e12162895aaee8db9abb22581bcc))
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
				result = m_PlayerSettingContainer.GetField(ca1a9e12162895aaee8db9abb22581bcc);
			}
		}
		return result;
	}

	public void c477993f7df71f5e855c29bbb49da309a(string c2fa253a94c3cb11f99907f0bc6f0b2f6, List<int> ca04b8fe5d43144ba3361431c00741486)
	{
		JSONObject jSONObject = new JSONObject();
		using (List<int>.Enumerator enumerator = ca04b8fe5d43144ba3361431c00741486.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				int current = enumerator.Current;
				jSONObject.Add(current);
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
				break;
			}
		}
		ca8e28f0eeee09fefe7987ee42cd7926d(c2fa253a94c3cb11f99907f0bc6f0b2f6, jSONObject);
	}

	public List<int> c5266987abcd60f99a820999013f389f4(string c2fa253a94c3cb11f99907f0bc6f0b2f6)
	{
		List<int> list = new List<int>();
		if (m_PlayerSettingContainer != null)
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
			JSONObject field = m_PlayerSettingContainer.GetField(c2fa253a94c3cb11f99907f0bc6f0b2f6);
			if (field != null)
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
				if (field.list != null)
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
					using (List<JSONObject>.Enumerator enumerator = m_PlayerSettingContainer.GetField(c2fa253a94c3cb11f99907f0bc6f0b2f6).list.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							JSONObject current = enumerator.Current;
							list.Add((int)current.n);
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								goto end_IL_0091;
							}
							continue;
							end_IL_0091:
							break;
						}
					}
				}
			}
		}
		return list;
	}
}
