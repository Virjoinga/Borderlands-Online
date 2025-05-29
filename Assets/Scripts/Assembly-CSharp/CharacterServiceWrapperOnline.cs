using A;

public class CharacterServiceWrapperOnline : ICharacterServiceWrapper, IServiceWrapper
{
	private bool m_initialized;

	private PlayerProperties m_localPlayer;

	private int m_townId;

	private CurrencyInfo m_currency;

	public void cd93285db16841148ed53a5bbeb35cf20()
	{
		m_localPlayer = c06ca0e618478c23eba3419653a19760f<PlayerManager>.c5ee19dc8d4cccf5ae2de225410458b86.ccc826da979542be7370386df94069f47();
		OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c21e522aeeaf7bcca3d0ea44730a13b6d(OnGetPresence);
		OnAccessSingleton<ICurrencyService, CurrencyService, CurrencyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c9a1a020b9c227311aeba9b5e48ccec2b(OnCurrenciesUpdated);
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c96afde9869ce72bec33e53eac31aee4a(OnExperienceUpdated);
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c5a95ad57c06b3b86edf0157165f29afc(c392a0beb915da2369756a99fcca0ed3a);
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c26ab8d967b8fbc4f5361d98ef23ea236(ce3ae3fa9bdf363cbf07f5065b8e342f8);
	}

	public void ccc266b2f103e4a81ebf4e8e0e3e0aeb2(CurrencyInfo cd5d61b84acd91f0e5a5a5f850d5999cd)
	{
		m_currency = cd5d61b84acd91f0e5a5a5f850d5999cd;
	}

	private void OnGetPresence(Presence presence)
	{
		m_townId = -1;
		if (presence != null)
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
			m_townId = presence.mCurrentTown;
		}
		if (m_townId == -1)
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
			m_townId = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c19004a784fb16baa81abb5ab1b6ccdd0();
		}
		m_initialized = true;
	}

	public bool c39df47367fa21412aabfef05d9972f8c()
	{
		if (m_initialized)
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
			m_localPlayer = c06ca0e618478c23eba3419653a19760f<PlayerManager>.c5ee19dc8d4cccf5ae2de225410458b86.ccc826da979542be7370386df94069f47();
			if (m_localPlayer != null)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		return false;
	}

	public int c623008f5bbe4bf72af447d08f62aa043()
	{
		return m_localPlayer.m_exp;
	}

	public int c7513e66c4e0fc55e6fea9dd9cb8b9943()
	{
		return c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(m_localPlayer.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a(), m_localPlayer.m_exp);
	}

	public string c4c40c6af474a3f102f58135c8f5f8409()
	{
		return m_localPlayer.m_name;
	}

	public int ceb10167333758220ffb9bc66317ad763()
	{
		return m_localPlayer.m_id;
	}

	public AvatarDNA c093d70e3287743ce2bc905d2c4b341f3()
	{
		return m_localPlayer.m_avatarDna;
	}

	public CurrencyInfo c9f30498b55d5d8ebb2b670dc3a42584b()
	{
		return m_currency;
	}

	public void ceaf946a4b1d023143d622c7be7019235()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnGotCurrencies(m_currency);
	}

	private void OnCurrenciesUpdated(int bondCurrency, int circulateCurrency, int specialCurrency)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnGotCurrencies(m_currency);
	}

	public int cb202b2ca376fe940339ca78de78383ab()
	{
		return m_townId;
	}

	public void OnExperienceUpdated(int experience)
	{
		if (m_localPlayer != null)
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
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				int num = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(c093d70e3287743ce2bc905d2c4b341f3().c071244a19e2d9f70f4d2d6d38677162a(), m_localPlayer.m_exp);
				int num2 = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(c093d70e3287743ce2bc905d2c4b341f3().c071244a19e2d9f70f4d2d6d38677162a(), experience);
				m_localPlayer.m_exp = experience;
				playerInfoSync.m_exp = experience;
				if (num2 > num)
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
					c06ca0e618478c23eba3419653a19760f<ce9388431a2de8f3d6a4d9565d5f8f8a0>.c5ee19dc8d4cccf5ae2de225410458b86.cc3a03c998d897c7a7aa6b2d0b7da8767("OnLevelUp", playerInfoSync);
				}
			}
		}
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnExperienceUpdated(experience);
	}

	public void c3357ebacf41523207dec1c272b0c2753()
	{
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c3357ebacf41523207dec1c272b0c2753();
	}

	private void c392a0beb915da2369756a99fcca0ed3a(string cd2e0bebe497fc016a1867e4165d94adf)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnGetPersonalSettings(cd2e0bebe497fc016a1867e4165d94adf);
	}

	public void cdfa79ad431f569bb78954d4da9bf4eec(string cd2e0bebe497fc016a1867e4165d94adf)
	{
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cdfa79ad431f569bb78954d4da9bf4eec(cd2e0bebe497fc016a1867e4165d94adf);
	}

	private void ce3ae3fa9bdf363cbf07f5065b8e342f8(int c1e2fba0a1513e46d2b88a170424c5d56)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnSetPersonalSettings(c1e2fba0a1513e46d2b88a170424c5d56);
	}

	public void cb7dd5fe3098d3d1cbef965add21fb7c0(byte[] ca35c0055cf7b1f9aafdd9d211099db29)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cb7dd5fe3098d3d1cbef965add21fb7c0(ca35c0055cf7b1f9aafdd9d211099db29);
	}
}
