using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Core;
using XsdSettings;

public class CharacterService : OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>, ICharacterService
{
	public class GetCharacterListAsyncTask : c89c54c08043729ce8a5a497efa546af3
	{
		public List<Character> m_characters = new List<Character>();

		public void c7cc9411392f033dee9802f9b9ca15b21()
		{
			c92c7f03b81b92c00ce0b49a2b9058106 = 30f;
		}

		public override void Start()
		{
			base.Start();
			OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c1d309289b19d1731266e05df9a0d0a59(OnGetCharacterList);
		}

		private void OnGetCharacterList(List<Character> characters)
		{
			List<Character> characters2;
			if (characters == null)
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
				characters2 = new List<Character>();
			}
			else
			{
				characters2 = characters;
			}
			m_characters = characters2;
			c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Success);
		}
	}

	public class SelectCharacterAsyncTask : c89c54c08043729ce8a5a497efa546af3
	{
		private int m_characterId;

		public Character m_character;

		public void c7cc9411392f033dee9802f9b9ca15b21(int c5dfde30d8784694fb9999709d290e6c4)
		{
			c92c7f03b81b92c00ce0b49a2b9058106 = 30f;
			m_characterId = c5dfde30d8784694fb9999709d290e6c4;
		}

		public override void Start()
		{
			base.Start();
			OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c4e6b2ff8a59760b88bf7b115eec5e023(OnGetCharacter, m_characterId);
		}

		private void OnGetCharacter(Character character)
		{
			if (character == null)
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
						c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Error_NoCharacter);
						return;
					}
				}
			}
			OnlineService.s_characterId = character.Id;
			PhotonNetwork.ceb41162a7cd2a1d5c4a03830e02b4198.ccd6fde3cd72529d9bc2523ed219b2bd4(new Hashtable { 
			{
				"CharacterId",
				OnlineService.s_characterId
			} });
			m_character = character;
			if (c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86 != null)
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c26dcadb6c3e9da3320f7f77afe3b6f30(m_character);
			}
			OnAccessSingleton<IProgressionService, ProgressionService, ProgressionServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cb88d873077b3039ed077ba472c62236c(m_character.Instances);
			c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Success);
		}
	}

	public class CreateCharacterAsyncTask : c89c54c08043729ce8a5a497efa546af3
	{
		private string m_name;

		private AvatarDNA m_avatarDna;

		public Character m_character;

		[CompilerGenerated]
		private static Func<byte, string> _003C_003Ef__am_0024cache3;

		[CompilerGenerated]
		private static Func<byte, string> _003C_003Ef__am_0024cache4;

		public void c7cc9411392f033dee9802f9b9ca15b21(string cd99af21e22e356018b8f72d4a7e4872a, AvatarDNA c1b8ddc4fe6a625049176e7c0fd558566)
		{
			c92c7f03b81b92c00ce0b49a2b9058106 = 30f;
			m_name = cd99af21e22e356018b8f72d4a7e4872a;
			m_avatarDna = c1b8ddc4fe6a625049176e7c0fd558566;
		}

		public override void Start()
		{
			base.Start();
			ICharacterService c5ee19dc8d4cccf5ae2de225410458b = OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86;
			OnCreateCharacter c2db84530ef366a6deb001d449d4aa = OnCreateCharacter;
			string name = m_name;
			AvatarType c951097a6ef3eb670bc38dce2cd336b7a = m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a();
			uint bkID = m_avatarDna.m_buildingUnit.bkID;
			List<byte> mFBXs = m_avatarDna.m_buildingUnit.mFBXs;
			if (_003C_003Ef__am_0024cache3 == null)
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
				_003C_003Ef__am_0024cache3 = (byte c7c80fef79e3c330ae5014832d44fcd28) => c7c80fef79e3c330ae5014832d44fcd28.ToString();
			}
			string cae80a9f4f672fadf39e72d87ae1e9e = string.Join(",", mFBXs.Select(_003C_003Ef__am_0024cache3).ToArray());
			List<byte> mMats = m_avatarDna.m_buildingUnit.mMats;
			if (_003C_003Ef__am_0024cache4 == null)
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
				_003C_003Ef__am_0024cache4 = (byte c7c80fef79e3c330ae5014832d44fcd28) => c7c80fef79e3c330ae5014832d44fcd28.ToString();
			}
			c5ee19dc8d4cccf5ae2de225410458b.cfea7b08f44245df70e20eb1d37766b74(c2db84530ef366a6deb001d449d4aa, name, c951097a6ef3eb670bc38dce2cd336b7a, bkID, cae80a9f4f672fadf39e72d87ae1e9e, string.Join(",", mMats.Select(_003C_003Ef__am_0024cache4).ToArray()));
		}

		private void OnCreateCharacter(CharacterOperationResult result, Character character)
		{
			if (result == CharacterOperationResult.Ok)
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
				if (character != null)
				{
					OnlineService.s_characterId = character.Id;
					PhotonNetwork.ceb41162a7cd2a1d5c4a03830e02b4198.ccd6fde3cd72529d9bc2523ed219b2bd4(new Hashtable { 
					{
						"CharacterId",
						OnlineService.s_characterId
					} });
					m_character = character;
					if (c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86 != null)
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
						c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c26dcadb6c3e9da3320f7f77afe3b6f30(m_character);
					}
					OnAccessSingleton<IProgressionService, ProgressionService, ProgressionServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cb88d873077b3039ed077ba472c62236c(m_character.Instances);
					c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Success);
					return;
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
			switch (result)
			{
			case CharacterOperationResult.Error_NameAlreadyExists:
				c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Error_NameAlreadyExists);
				break;
			case CharacterOperationResult.Error_NameContainsIllegalWords:
				c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Error_NameContainsIllegalWords);
				break;
			case CharacterOperationResult.Error_NameTooLong:
				c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Error_NameTooLong);
				break;
			default:
				c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Error_NoCharacter);
				break;
			}
		}

		[CompilerGenerated]
		private static string cc9b2e71e93aba3e8da08bbb50e2b0f11(byte c7c80fef79e3c330ae5014832d44fcd28)
		{
			return c7c80fef79e3c330ae5014832d44fcd28.ToString();
		}

		[CompilerGenerated]
		private static string c55ad6eafe79deca45f8f72f1d6ea1d5e(byte c7c80fef79e3c330ae5014832d44fcd28)
		{
			return c7c80fef79e3c330ae5014832d44fcd28.ToString();
		}
	}

	public class GetSelectedCharacterAsyncTask : c89c54c08043729ce8a5a497efa546af3
	{
		public Character m_character;

		public void c7cc9411392f033dee9802f9b9ca15b21()
		{
			c92c7f03b81b92c00ce0b49a2b9058106 = 30f;
		}

		public override void Start()
		{
			base.Start();
			OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cb9427f8203768e92d6a2876d77325c3a(OnGetCharacter);
		}

		private void OnGetCharacter(Character character)
		{
			if (character == null)
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
						c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Error_NoCharacter);
						return;
					}
				}
			}
			m_character = character;
			if (c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86 != null)
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c26dcadb6c3e9da3320f7f77afe3b6f30(m_character);
			}
			OnAccessSingleton<IProgressionService, ProgressionService, ProgressionServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cb88d873077b3039ed077ba472c62236c(m_character.Instances);
			c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Success);
		}
	}

	private List<OnGetCharacterList> mOnGetCharacterList = new List<OnGetCharacterList>();

	private List<OnGetCharacter> mOnSelectCharacter = new List<OnGetCharacter>();

	private List<OnCreateCharacter> mOnCreateCharacter = new List<OnCreateCharacter>();

	private List<OnGetCharacter> mOnGetCharacter = new List<OnGetCharacter>();

	private List<OnUpdateCharacterExperience> mOnUpdateCharacterExperience = new List<OnUpdateCharacterExperience>();

	private List<OnGetPersonalSettings> mOnGetPersonalSettings = new List<OnGetPersonalSettings>();

	private List<OnSetPersonalSettings> mOnSetPersonalSettings = new List<OnSetPersonalSettings>();

	private List<OnExperienceUpdated> mOnExperienceUpdated = new List<OnExperienceUpdated>();

	private List<OnLevelUp> mOnLevelUp = new List<OnLevelUp>();

	private List<OnNotifyAntiAddiction> mOnNotifyAntiAddiction = new List<OnNotifyAntiAddiction>();

	private List<OnGPKDynCode> mOnGPKDynCode = new List<OnGPKDynCode>();

	private List<OnGPKAuthData> mOnGPKAuthData = new List<OnGPKAuthData>();

	private List<OnGPKAuthReply> mOnGPKAuthReply = new List<OnGPKAuthReply>();

	[CompilerGenerated]
	private static Action<OnGetCharacterList> _003C_003Ef__am_0024cacheD;

	[CompilerGenerated]
	private static Action<OnGetCharacter> _003C_003Ef__am_0024cacheE;

	[CompilerGenerated]
	private static Action<OnGetCharacter> _003C_003Ef__am_0024cacheF;

	[CompilerGenerated]
	private static Action<OnUpdateCharacterExperience> _003C_003Ef__am_0024cache10;

	[CompilerGenerated]
	private static Action<OnGetCharacter> _003C_003Ef__am_0024cache11;

	[CompilerGenerated]
	private static Action<OnGetPersonalSettings> _003C_003Ef__am_0024cache12;

	public CharacterService()
	{
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(84, OnGetCharacterListResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(83, OnSelectCharacterResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(82, OnCreateCharacterResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(80, OnGetCharacterResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(81, OnGetCharacterResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(79, OnUpdateCharacterExperienceResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(75, OnGetPersonalSettingsResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(74, OnSetPersonalSettingsResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(62, OnGPKAuthReplyResponse);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(206, OnExperienceUpdatedEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(204, OnLevelUpEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(162, OnNotifyAntiAddictionEvent);
	}

	public void c1d309289b19d1731266e05df9a0d0a59(OnGetCharacterList c2db84530ef366a6deb001d449d4aa151)
	{
		if (c2db84530ef366a6deb001d449d4aa151 != null)
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
			mOnGetCharacterList.Add(c2db84530ef366a6deb001d449d4aa151);
		}
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(84, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnGetCharacterListResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
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
			List<Character> characters = new List<Character>();
			IDictionaryEnumerator enumerator = ((Hashtable)parameters[0]).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
					characters.Add(new Character((Hashtable)dictionaryEntry.Value));
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						goto end_IL_0078;
					}
					continue;
					end_IL_0078:
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
						switch (6)
						{
						case 0:
							break;
						default:
							goto end_IL_008e;
						}
						continue;
						end_IL_008e:
						break;
					}
				}
				else
				{
					disposable.Dispose();
				}
			}
			mOnGetCharacterList.ForEach(delegate(OnGetCharacterList cbd1639b67f4774915e463c3fd4e982f3)
			{
				cbd1639b67f4774915e463c3fd4e982f3(characters);
			});
		}
		else
		{
			List<OnGetCharacterList> list = mOnGetCharacterList;
			if (_003C_003Ef__am_0024cacheD == null)
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
				_003C_003Ef__am_0024cacheD = delegate(OnGetCharacterList cbd1639b67f4774915e463c3fd4e982f3)
				{
					cbd1639b67f4774915e463c3fd4e982f3(c3a340316af1de502d92f7d437a7a96de.c7088de59e49f7108f520cf7e0bae167e);
				};
			}
			list.ForEach(_003C_003Ef__am_0024cacheD);
		}
		mOnGetCharacterList.Clear();
	}

	public void c4e6b2ff8a59760b88bf7b115eec5e023(OnGetCharacter c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (c2db84530ef366a6deb001d449d4aa151 != null)
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
			mOnSelectCharacter.Add(c2db84530ef366a6deb001d449d4aa151);
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(83, array);
	}

	private void OnSelectCharacterResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
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
			Character character = new Character((Hashtable)parameters[0]);
			mOnSelectCharacter.ForEach(delegate(OnGetCharacter cbd1639b67f4774915e463c3fd4e982f3)
			{
				cbd1639b67f4774915e463c3fd4e982f3(character);
			});
		}
		else
		{
			List<OnGetCharacter> list = mOnSelectCharacter;
			if (_003C_003Ef__am_0024cacheE == null)
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
				_003C_003Ef__am_0024cacheE = delegate(OnGetCharacter cbd1639b67f4774915e463c3fd4e982f3)
				{
					cbd1639b67f4774915e463c3fd4e982f3(c997d65b1778a9a000b321a974141fe05.c7088de59e49f7108f520cf7e0bae167e);
				};
			}
			list.ForEach(_003C_003Ef__am_0024cacheE);
		}
		mOnSelectCharacter.Clear();
	}

	public void cfea7b08f44245df70e20eb1d37766b74(OnCreateCharacter c2db84530ef366a6deb001d449d4aa151, string cd99af21e22e356018b8f72d4a7e4872a, AvatarType c951097a6ef3eb670bc38dce2cd336b7a, uint ca938ea365c8e111e058825536bf0df26, string cae80a9f4f672fadf39e72d87ae1e9e79, string c05e4d2ddd62623e1e855164cca3fa3b5)
	{
		if (c2db84530ef366a6deb001d449d4aa151 != null)
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
			mOnCreateCharacter.Add(c2db84530ef366a6deb001d449d4aa151);
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
		array[0] = cd99af21e22e356018b8f72d4a7e4872a;
		array[1] = (int)c951097a6ef3eb670bc38dce2cd336b7a;
		array[2] = ca938ea365c8e111e058825536bf0df26.ToString();
		array[3] = cae80a9f4f672fadf39e72d87ae1e9e79;
		array[4] = c05e4d2ddd62623e1e855164cca3fa3b5;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(82, array);
	}

	private void OnCreateCharacterResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
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
			Character character = new Character((Hashtable)parameters[0]);
			mOnCreateCharacter.ForEach(delegate(OnCreateCharacter cbd1639b67f4774915e463c3fd4e982f3)
			{
				cbd1639b67f4774915e463c3fd4e982f3(CharacterOperationResult.Ok, character);
			});
		}
		else
		{
			CharacterOperationResult errorCode = CharacterOperationResult.Error_Unknown;
			switch (result)
			{
			case 32732:
				errorCode = CharacterOperationResult.Error_NameAlreadyExists;
				break;
			case 32734:
				errorCode = CharacterOperationResult.Error_NameContainsIllegalWords;
				break;
			case 32733:
				errorCode = CharacterOperationResult.Error_NameTooLong;
				break;
			}
			mOnCreateCharacter.ForEach(delegate(OnCreateCharacter cbd1639b67f4774915e463c3fd4e982f3)
			{
				cbd1639b67f4774915e463c3fd4e982f3(errorCode, c997d65b1778a9a000b321a974141fe05.c7088de59e49f7108f520cf7e0bae167e);
			});
		}
		mOnCreateCharacter.Clear();
	}

	public void cb9427f8203768e92d6a2876d77325c3a(OnGetCharacter c2db84530ef366a6deb001d449d4aa151)
	{
		if (c2db84530ef366a6deb001d449d4aa151 != null)
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
			mOnGetCharacter.Add(c2db84530ef366a6deb001d449d4aa151);
		}
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(80, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	public void cf1fa48b975ff7ac8672738194fcf30b4(OnGetCharacter c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (c2db84530ef366a6deb001d449d4aa151 != null)
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
			mOnGetCharacter.Add(c2db84530ef366a6deb001d449d4aa151);
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(81, array);
	}

	private void OnGetCharacterResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
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
			Character character = new Character((Hashtable)parameters[0]);
			mOnGetCharacter.ForEach(delegate(OnGetCharacter cbd1639b67f4774915e463c3fd4e982f3)
			{
				cbd1639b67f4774915e463c3fd4e982f3(character);
			});
		}
		else
		{
			List<OnGetCharacter> list = mOnGetCharacter;
			if (_003C_003Ef__am_0024cacheF == null)
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
				_003C_003Ef__am_0024cacheF = delegate(OnGetCharacter cbd1639b67f4774915e463c3fd4e982f3)
				{
					cbd1639b67f4774915e463c3fd4e982f3(c997d65b1778a9a000b321a974141fe05.c7088de59e49f7108f520cf7e0bae167e);
				};
			}
			list.ForEach(_003C_003Ef__am_0024cacheF);
		}
		mOnGetCharacter.Clear();
	}

	public void ce54b50e42eaa9359290d45b0a70d35d4(OnUpdateCharacterExperience c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4, int ce1d3462fabdc95947675319f9d54f976)
	{
		if (c2db84530ef366a6deb001d449d4aa151 != null)
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
			mOnUpdateCharacterExperience.Add(c2db84530ef366a6deb001d449d4aa151);
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		array[1] = ce1d3462fabdc95947675319f9d54f976;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(79, array);
	}

	public void c3357ebacf41523207dec1c272b0c2753()
	{
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(75, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	public void cdfa79ad431f569bb78954d4da9bf4eec(string c7e6bfb9029303a26d69314500f450e13)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c7e6bfb9029303a26d69314500f450e13;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(74, array);
	}

	private void OnUpdateCharacterExperienceResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
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
			List<OnUpdateCharacterExperience> list = mOnUpdateCharacterExperience;
			if (_003C_003Ef__am_0024cache10 == null)
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
				_003C_003Ef__am_0024cache10 = delegate(OnUpdateCharacterExperience cbd1639b67f4774915e463c3fd4e982f3)
				{
					cbd1639b67f4774915e463c3fd4e982f3();
				};
			}
			list.ForEach(_003C_003Ef__am_0024cache10);
		}
		else
		{
			List<OnGetCharacter> list2 = mOnGetCharacter;
			if (_003C_003Ef__am_0024cache11 == null)
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
				_003C_003Ef__am_0024cache11 = delegate(OnGetCharacter cbd1639b67f4774915e463c3fd4e982f3)
				{
					cbd1639b67f4774915e463c3fd4e982f3(c997d65b1778a9a000b321a974141fe05.c7088de59e49f7108f520cf7e0bae167e);
				};
			}
			list2.ForEach(_003C_003Ef__am_0024cache11);
		}
		mOnUpdateCharacterExperience.Clear();
	}

	private void OnGetPersonalSettingsResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					string settings = (string)parameters[0];
					mOnGetPersonalSettings.ForEach(delegate(OnGetPersonalSettings cbd1639b67f4774915e463c3fd4e982f3)
					{
						cbd1639b67f4774915e463c3fd4e982f3(settings);
					});
					return;
				}
				}
			}
		}
		List<OnGetPersonalSettings> list = mOnGetPersonalSettings;
		if (_003C_003Ef__am_0024cache12 == null)
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
			_003C_003Ef__am_0024cache12 = delegate(OnGetPersonalSettings cbd1639b67f4774915e463c3fd4e982f3)
			{
				cbd1639b67f4774915e463c3fd4e982f3(c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e);
			};
		}
		list.ForEach(_003C_003Ef__am_0024cache12);
	}

	private void OnSetPersonalSettingsResponse(short result, Dictionary<byte, object> parameters)
	{
		mOnSetPersonalSettings.ForEach(delegate(OnSetPersonalSettings cbd1639b67f4774915e463c3fd4e982f3)
		{
			cbd1639b67f4774915e463c3fd4e982f3(result);
		});
	}

	public void cb7dd5fe3098d3d1cbef965add21fb7c0(byte[] c1085967e882b59c9c37b671c465d1472)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c1085967e882b59c9c37b671c465d1472;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(62, array);
	}

	private void OnGPKAuthReplyResponse(short result, Dictionary<byte, object> parameters)
	{
		mOnGPKAuthReply.ForEach(delegate(OnGPKAuthReply cbd1639b67f4774915e463c3fd4e982f3)
		{
			cbd1639b67f4774915e463c3fd4e982f3(result);
		});
	}

	public void cabc2eda7c543c0bd71dabf94afc17a90(OnGPKDynCode c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGPKDynCode.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cfeac6e7f466c21d36e1a29eb1c94c1ba(OnGPKDynCode c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGPKDynCode.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c7dd4624d9c3a72d4118d18bb6ab1cacd(OnGPKAuthData c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGPKAuthData.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cec8d342731b6d6ebc828fcd5f5dae562(OnGPKAuthData c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGPKAuthData.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c67bc25d770eba6323bf0b6b3a06e045a(OnGPKAuthReply c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGPKAuthReply.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cf33fdb1ee20db9f794c9edbc91a85323(OnGPKAuthReply c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGPKAuthReply.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c96afde9869ce72bec33e53eac31aee4a(OnExperienceUpdated c2db84530ef366a6deb001d449d4aa151)
	{
		mOnExperienceUpdated.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c613f1b4f864b4e225369dd3f92a949ff(OnLevelUp c2db84530ef366a6deb001d449d4aa151)
	{
		mOnLevelUp.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void ce44f2a4a8767f0c745f29d10533f3624(OnNotifyAntiAddiction c2db84530ef366a6deb001d449d4aa151)
	{
		mOnNotifyAntiAddiction.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cd0d81d8a5597efc859cb244f9e023f95(OnExperienceUpdated c2db84530ef366a6deb001d449d4aa151)
	{
		mOnExperienceUpdated.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c6d9fe5aeebc6c50c07133973e8cc6ac1(OnLevelUp c2db84530ef366a6deb001d449d4aa151)
	{
		mOnLevelUp.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cad0143fb8914a0b052fc270dd1d5385d(OnNotifyAntiAddiction c2db84530ef366a6deb001d449d4aa151)
	{
		mOnNotifyAntiAddiction.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c5a95ad57c06b3b86edf0157165f29afc(OnGetPersonalSettings c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGetPersonalSettings.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c26ab8d967b8fbc4f5361d98ef23ea236(OnSetPersonalSettings c2db84530ef366a6deb001d449d4aa151)
	{
		mOnSetPersonalSettings.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c94da62724c6d5a439f4011792c2d82b1(OnGetPersonalSettings c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGetPersonalSettings.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c3cdc796edd63ade947ca70a4e16cafff(OnSetPersonalSettings c2db84530ef366a6deb001d449d4aa151)
	{
		mOnSetPersonalSettings.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnExperienceUpdatedEvent(Dictionary<byte, object> parameters)
	{
		int newExperience = (int)parameters[0];
		mOnExperienceUpdated.ForEach(delegate(OnExperienceUpdated c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(newExperience);
		});
	}

	private void OnLevelUpEvent(Dictionary<byte, object> parameters)
	{
		int characterId = (int)parameters[0];
		int newExperience = (int)parameters[1];
		int newLevel = (int)parameters[2];
		mOnLevelUp.ForEach(delegate(OnLevelUp c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(characterId, newLevel, newExperience);
		});
	}

	private void OnNotifyAntiAddictionEvent(Dictionary<byte, object> parameters)
	{
		int onlineMinutes = (int)parameters[0];
		int offlineMinutes = (int)parameters[1];
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "AntiAddiction onlineMinutes:";
		array[1] = onlineMinutes;
		array[2] = " offlineMinutes: ";
		array[3] = offlineMinutes;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array));
		mOnNotifyAntiAddiction.ForEach(delegate(OnNotifyAntiAddiction c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(onlineMinutes, offlineMinutes);
		});
	}

	private void OnGPKDynCodeEvent(Dictionary<byte, object> parameters)
	{
		byte[] DynCode = (byte[])parameters[0];
		mOnGPKDynCode.ForEach(delegate(OnGPKDynCode c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(DynCode);
		});
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "OnGPKDynCodeEvent:" + DynCode.Length);
	}

	private void OnGPKAuthDataEvent(Dictionary<byte, object> parameters)
	{
		byte[] authData = (byte[])parameters[0];
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "OnGPKAuthDataEvent:" + authData.Length);
		mOnGPKAuthData.ForEach(delegate(OnGPKAuthData c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(authData);
		});
	}

	[CompilerGenerated]
	private static void c8bfb05cac3f9ffe6f85ad50c7d5dde73(OnGetCharacterList cbd1639b67f4774915e463c3fd4e982f3)
	{
		cbd1639b67f4774915e463c3fd4e982f3(c3a340316af1de502d92f7d437a7a96de.c7088de59e49f7108f520cf7e0bae167e);
	}

	[CompilerGenerated]
	private static void c53303702b473f06fa9e72e61f568261e(OnGetCharacter cbd1639b67f4774915e463c3fd4e982f3)
	{
		cbd1639b67f4774915e463c3fd4e982f3(c997d65b1778a9a000b321a974141fe05.c7088de59e49f7108f520cf7e0bae167e);
	}

	[CompilerGenerated]
	private static void cf0d48811121d5a2c5c4c0c3dae86d388(OnGetCharacter cbd1639b67f4774915e463c3fd4e982f3)
	{
		cbd1639b67f4774915e463c3fd4e982f3(c997d65b1778a9a000b321a974141fe05.c7088de59e49f7108f520cf7e0bae167e);
	}

	[CompilerGenerated]
	private static void cf18458bf3d7e889c707585289c42a36c(OnUpdateCharacterExperience cbd1639b67f4774915e463c3fd4e982f3)
	{
		cbd1639b67f4774915e463c3fd4e982f3();
	}

	[CompilerGenerated]
	private static void cbbef488639c96e3dd2595f1b9848f199(OnGetCharacter cbd1639b67f4774915e463c3fd4e982f3)
	{
		cbd1639b67f4774915e463c3fd4e982f3(c997d65b1778a9a000b321a974141fe05.c7088de59e49f7108f520cf7e0bae167e);
	}

	[CompilerGenerated]
	private static void cc66ade5079728743a5fd9f6a19fee8da(OnGetPersonalSettings cbd1639b67f4774915e463c3fd4e982f3)
	{
		cbd1639b67f4774915e463c3fd4e982f3(c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e);
	}
}
