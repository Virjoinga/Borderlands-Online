using System.Collections.Generic;
using System.Linq;
using A;
using Core;

public class GuildManager : IGuildServiceNotificationListerner
{
	public struct GuildInvitationData
	{
		public int guildId;

		public string guildName;

		public string guildMasterName;
	}

	public enum ApplicationStatus
	{
		e_WaitingForDecide = 0,
		e_Accepted = 1,
		e_Rejected = 2
	}

	private class GuildApplicationData
	{
		public Presence ApplicantPresence;

		public ApplicationStatus Status;

		public GuildApplicationData()
		{
			Status = ApplicationStatus.e_WaitingForDecide;
		}
	}

	public int m_nMaxGuildMemberCount = 200;

	public int m_nMaxGuildManagerCount = 3;

	protected static GuildManager _GuildInstance;

	private bool m_bInGuild;

	private int m_nChairmanID = -1;

	public bool m_bCanShowMessage = true;

	public GuildInvitationData m_Invitation;

	private string m_strGuildDec = string.Empty;

	private int m_nMaxLevel;

	private Guild m_MyGuildInfo;

	private List<Guild> m_SearchResult;

	private List<Guild> m_AppliedGuild;

	private List<int> m_AppliedGuildID;

	private Dictionary<int, GuildApplicationData> m_ApplicationMap;

	private List<GuildNews> m_GuildNews;

	private List<int> m_GuildManagerList;

	private List<int> m_GuildSkillList;

	private Dictionary<int, int> m_GuildProgressionTable;

	private GuildManager()
	{
		if (m_SearchResult == null)
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
			m_SearchResult = new List<Guild>();
			m_SearchResult.Clear();
		}
		if (m_AppliedGuild == null)
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
			m_AppliedGuild = new List<Guild>();
			m_AppliedGuild.Clear();
		}
		if (m_AppliedGuildID == null)
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
			m_AppliedGuildID = new List<int>();
			m_AppliedGuildID.Clear();
		}
		if (m_ApplicationMap == null)
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
			m_ApplicationMap = new Dictionary<int, GuildApplicationData>();
			m_ApplicationMap.Clear();
		}
		if (m_GuildNews == null)
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
			m_GuildNews = new List<GuildNews>();
			m_GuildNews.Clear();
		}
		if (m_GuildProgressionTable == null)
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
			m_GuildProgressionTable = new Dictionary<int, int>();
			m_GuildProgressionTable.Clear();
			cbc9a74857d353451fd654ec5778b2fc0();
		}
		if (m_GuildManagerList == null)
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
			m_GuildManagerList = new List<int>();
			m_GuildManagerList.Clear();
		}
		if (m_GuildSkillList != null)
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
			m_GuildSkillList = new List<int>();
			m_GuildSkillList.Clear();
			return;
		}
	}

	public static GuildManager c71f6ce28731edfd43c976fbd57c57bea()
	{
		if (_GuildInstance == null)
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
			_GuildInstance = new GuildManager();
			c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(_GuildInstance);
		}
		return _GuildInstance;
	}

	protected void cbc9a74857d353451fd654ec5778b2fc0()
	{
		m_GuildProgressionTable.Clear();
		for (int i = 0; i < c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_progressionTable.Length; i++)
		{
			int levelNumber = c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_progressionTable[i].m_levelNumber;
			int expRequirement = c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_progressionTable[i].m_expRequirement;
			if (levelNumber > m_nMaxLevel)
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
				m_nMaxLevel = levelNumber;
			}
			m_GuildProgressionTable.Add(levelNumber, expRequirement);
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

	public bool c66bf8bbd3d688c43085d847b766f9e5b(int ceb2d2e60d53f84002efe014b8c698355)
	{
		if (m_MyGuildInfo == null)
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
					return false;
				}
			}
		}
		for (int i = 0; i < m_MyGuildInfo.ced4f209cd82cf504446bed630a19d684.Count; i++)
		{
			if (m_MyGuildInfo.ced4f209cd82cf504446bed630a19d684[i].mCharacterId != ceb2d2e60d53f84002efe014b8c698355)
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
				return true;
			}
		}
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

	public int c2324f607a3388f1d247741a5c264a1bd()
	{
		if (m_MyGuildInfo != null)
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
					return m_MyGuildInfo.Experience;
				}
			}
		}
		return 0;
	}

	public int c7482cb3fb4cd3ed0c583554787567bf5()
	{
		if (m_MyGuildInfo == null)
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
					return 0;
				}
			}
		}
		int level = m_MyGuildInfo.Level;
		if (level > m_nMaxLevel)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return m_GuildProgressionTable[m_nMaxLevel];
				}
			}
		}
		if (m_GuildProgressionTable.ContainsKey(level))
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return m_GuildProgressionTable[level];
				}
			}
		}
		return m_GuildProgressionTable[m_nMaxLevel];
	}

	public int c3259223a7c3b756dc4e83b75fbe50b09()
	{
		if (m_MyGuildInfo == null)
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
					return 0;
				}
			}
		}
		int num = m_MyGuildInfo.Level + 1;
		if (num > m_nMaxLevel)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return m_GuildProgressionTable[m_nMaxLevel];
				}
			}
		}
		if (m_GuildProgressionTable.ContainsKey(num))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return m_GuildProgressionTable[num];
				}
			}
		}
		return m_GuildProgressionTable[m_nMaxLevel];
	}

	public bool c50c0301c45aeaef550d68b8337bd23b2()
	{
		if (!cd19cb80dca29b5c813acffe07d4eb050())
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
					if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					AvatarDNA avatarDna = playerInfoSync.m_avatarDna;
					if (avatarDna == null)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					return c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(avatarDna.c071244a19e2d9f70f4d2d6d38677162a(), playerInfoSync.m_exp) >= LevelingManager.CREATEGUILD_UNLOCK_LEVEL;
				}
				}
			}
		}
		return false;
	}

	public bool cb7a25096669180e2e90e9c1acb5e62c2()
	{
		if (!cd19cb80dca29b5c813acffe07d4eb050())
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
					return true;
				}
			}
		}
		return false;
	}

	public bool cd19cb80dca29b5c813acffe07d4eb050()
	{
		return m_bInGuild;
	}

	public bool c17ba091c28b756583dc29d3eec870622()
	{
		if (m_bInGuild)
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
					return OnlineService.s_characterId == m_nChairmanID;
				}
			}
		}
		return false;
	}

	public bool c17ba091c28b756583dc29d3eec870622(int cec67817d5516cb3510fc67791505c37e)
	{
		return cec67817d5516cb3510fc67791505c37e == m_nChairmanID;
	}

	public void c2322c5712f68c0fb21443e577a94e14b()
	{
		if (m_MyGuildInfo.mMemberList.Count <= 1)
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c263a18e823d534fe933bf797fd17c221(GuildSearchView.GuildSearchPart.e_GuildMember);
					return;
				}
			}
		}
		m_MyGuildInfo.mMemberList.Sort(c5b085f5cea00efc95e341543833639d3);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c263a18e823d534fe933bf797fd17c221(GuildSearchView.GuildSearchPart.e_GuildMember);
	}

	public void c9be8dfdfec9eb72150c0a63a13ec1fc4()
	{
		if (m_MyGuildInfo.mMemberList.Count <= 1)
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c263a18e823d534fe933bf797fd17c221(GuildSearchView.GuildSearchPart.e_GuildMember);
					return;
				}
			}
		}
		m_MyGuildInfo.mMemberList.Sort(c3d1bb3692c0855c4147e6387b76d54a6);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c263a18e823d534fe933bf797fd17c221(GuildSearchView.GuildSearchPart.e_GuildMember);
	}

	private int c3d1bb3692c0855c4147e6387b76d54a6(Presence cfb724368a3fa3bbd82dd2f1d7e4bfe47, Presence c1ad7a5a20221cf18e17547b794ebc902)
	{
		if (c1ad7a5a20221cf18e17547b794ebc902.mCharacterId == m_MyGuildInfo.MasterCharacterId)
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
					return 1;
				}
			}
		}
		if (cfb724368a3fa3bbd82dd2f1d7e4bfe47.mCharacterId == m_MyGuildInfo.MasterCharacterId)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return -1;
				}
			}
		}
		if (!cd6451c6b5252840b2be641871236928f(cfb724368a3fa3bbd82dd2f1d7e4bfe47.mCharacterId))
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
			if (cd6451c6b5252840b2be641871236928f(c1ad7a5a20221cf18e17547b794ebc902.mCharacterId))
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return 1;
					}
				}
			}
		}
		if (cfb724368a3fa3bbd82dd2f1d7e4bfe47.mCharacterId != m_MyGuildInfo.MasterCharacterId)
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
			if (!cd6451c6b5252840b2be641871236928f(cfb724368a3fa3bbd82dd2f1d7e4bfe47.mCharacterId))
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
				if (!cfb724368a3fa3bbd82dd2f1d7e4bfe47.mIsOnline)
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
					if (c1ad7a5a20221cf18e17547b794ebc902.mIsOnline)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								return 1;
							}
						}
					}
				}
			}
		}
		if (cfb724368a3fa3bbd82dd2f1d7e4bfe47.mCharacterId == c1ad7a5a20221cf18e17547b794ebc902.mCharacterId)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return 1;
				}
			}
		}
		return -1;
	}

	private int c5b085f5cea00efc95e341543833639d3(Presence cfb724368a3fa3bbd82dd2f1d7e4bfe47, Presence c1ad7a5a20221cf18e17547b794ebc902)
	{
		if (cfb724368a3fa3bbd82dd2f1d7e4bfe47.mIsOnline)
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
			if (c1ad7a5a20221cf18e17547b794ebc902.mIsOnline)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (cfb724368a3fa3bbd82dd2f1d7e4bfe47.mCharacterId != m_MyGuildInfo.MasterCharacterId)
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
							if (c1ad7a5a20221cf18e17547b794ebc902.mCharacterId == m_MyGuildInfo.MasterCharacterId)
							{
								while (true)
								{
									switch (1)
									{
									case 0:
										break;
									default:
										return 1;
									}
								}
							}
						}
						if (cfb724368a3fa3bbd82dd2f1d7e4bfe47.mCharacterId == m_MyGuildInfo.MasterCharacterId)
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
							if (c1ad7a5a20221cf18e17547b794ebc902.mCharacterId != m_MyGuildInfo.MasterCharacterId)
							{
								while (true)
								{
									switch (4)
									{
									case 0:
										break;
									default:
										return -1;
									}
								}
							}
						}
						return 0;
					}
				}
			}
		}
		if (!cfb724368a3fa3bbd82dd2f1d7e4bfe47.mIsOnline)
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
			if (c1ad7a5a20221cf18e17547b794ebc902.mIsOnline)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return 1;
					}
				}
			}
		}
		if (cfb724368a3fa3bbd82dd2f1d7e4bfe47.mIsOnline)
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
			if (!c1ad7a5a20221cf18e17547b794ebc902.mIsOnline)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return -1;
					}
				}
			}
		}
		if (!cfb724368a3fa3bbd82dd2f1d7e4bfe47.mIsOnline)
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
			if (!c1ad7a5a20221cf18e17547b794ebc902.mIsOnline)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return 0;
					}
				}
			}
		}
		return 0;
	}

	public void c1c30180f8cf8e8933128caa5e48f49ae()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c1c30180f8cf8e8933128caa5e48f49ae(c71163b3ee1f3b51ee98096502e92e415);
	}

	public void cc4de3bcc457c8dac1f7fc8883cf00603(string cf27a660a95304c4a0227e15480d7fa07, string c9478cdd50593b57c5e1b6b55441c8075, GuildPreference c6895cb3f6c7f5284072399c244b895cd)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cc4de3bcc457c8dac1f7fc8883cf00603(ca0fd2a9b02c5baf3a9c40a54c02af558, cf27a660a95304c4a0227e15480d7fa07, c9478cdd50593b57c5e1b6b55441c8075, c6895cb3f6c7f5284072399c244b895cd);
	}

	public int c71058e47b33ad98116def30435511982()
	{
		if (m_MyGuildInfo != null)
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
					return m_MyGuildInfo.MaxMemberCount;
				}
			}
		}
		return m_nMaxGuildMemberCount;
	}

	public void c375b2f5564171f0063c8aa9c5f2f9c91()
	{
		if (m_MyGuildInfo == null)
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
			if (!c17ba091c28b756583dc29d3eec870622())
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GUILD_Dismiss_WARNING")), ca131ac030d74d9bdd378fddf7107a229, c7c2ebf9a4704bd5defd809a6b06e889a);
				return;
			}
		}
	}

	protected void ca131ac030d74d9bdd378fddf7107a229()
	{
		if (m_MyGuildInfo == null)
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
			if (!c17ba091c28b756583dc29d3eec870622())
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c375b2f5564171f0063c8aa9c5f2f9c91(ca7029b112fff56fb9f2691d6a92c386f, m_MyGuildInfo.Id);
				return;
			}
		}
	}

	protected void c7c2ebf9a4704bd5defd809a6b06e889a()
	{
	}

	public void c811064378d00bd87d4c577faf379e610(string c36532a5ac2b51ee2e46e8ba000b8fcb1)
	{
		if (!c17ba091c28b756583dc29d3eec870622())
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
			m_strGuildDec = c36532a5ac2b51ee2e46e8ba000b8fcb1;
			c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c75ac0309824b917125cffbd55c6fbd78(c75d506f1162fa2e8274b41977af694a4, m_MyGuildInfo.Id, c36532a5ac2b51ee2e46e8ba000b8fcb1);
			return;
		}
	}

	protected void c75d506f1162fa2e8274b41977af694a4(bool ce789f9c3fe56ee71c44c6992c4b590bb)
	{
		if (!ce789f9c3fe56ee71c44c6992c4b590bb)
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
			m_strGuildDec = m_MyGuildInfo.Banner;
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c263a18e823d534fe933bf797fd17c221();
	}

	public void ceeacb24fb9f8879f890a919879452431()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ceeacb24fb9f8879f890a919879452431(ca0e0dc3b184fd1e420b37977fc171d24, m_MyGuildInfo.Id);
	}

	protected void ca0e0dc3b184fd1e420b37977fc171d24(List<Presence> cf1f5eeb43119c9b234d648ebaefe9c4f)
	{
		m_ApplicationMap.Clear();
		if (cf1f5eeb43119c9b234d648ebaefe9c4f == null)
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
			for (int i = 0; i < cf1f5eeb43119c9b234d648ebaefe9c4f.Count; i++)
			{
				GuildApplicationData guildApplicationData = new GuildApplicationData();
				guildApplicationData.ApplicantPresence = cf1f5eeb43119c9b234d648ebaefe9c4f[i];
				if (m_ApplicationMap.ContainsKey(cf1f5eeb43119c9b234d648ebaefe9c4f[i].mCharacterId))
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
				m_ApplicationMap.Add(cf1f5eeb43119c9b234d648ebaefe9c4f[i].mCharacterId, guildApplicationData);
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

	public void c0c7f75ee8b5d1b8baa3f0d2bfba94079(string ca042f766af288ad9dff312ace59213d1)
	{
	}

	public int c392389f80491f6afb198ca0180c79236()
	{
		return m_SearchResult.Count;
	}

	public int c0f68d664365a72d62b5d68a988978557()
	{
		return m_AppliedGuild.Count;
	}

	public void cd41b0678b505218e3df266adeecfb371(bool c16ab5ac56bd5dacacf0e2c2e1e945042)
	{
		List<InvitationReply> list = new List<InvitationReply>();
		InvitationReply invitationReply = new InvitationReply();
		invitationReply.Reply = c16ab5ac56bd5dacacf0e2c2e1e945042;
		invitationReply.GuildId = m_Invitation.guildId;
		list.Add(invitationReply);
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cefc501f26eaeadd3f3849859260459bd(cdf244fc8eb0139b70ae50013902ef830, list);
	}

	public void c5754d5650a3df3b3f78db32c9e4a0591(int c1cc10478b0fb75a49477a8f3df0d162c, bool c16ab5ac56bd5dacacf0e2c2e1e945042)
	{
		if (!c17ba091c28b756583dc29d3eec870622())
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
					return;
				}
			}
		}
		List<ApplicantApproval> list = new List<ApplicantApproval>();
		list.Clear();
		ApplicantApproval applicantApproval = new ApplicantApproval();
		applicantApproval.IsAllowedToJoin = c16ab5ac56bd5dacacf0e2c2e1e945042;
		applicantApproval.ApplicantCharacterId = c1cc10478b0fb75a49477a8f3df0d162c;
		list.Add(applicantApproval);
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c5754d5650a3df3b3f78db32c9e4a0591(c0f2a2a4dd8be21e27c51b68deb07f600, m_MyGuildInfo.Id, list);
		if (m_ApplicationMap.ContainsKey(c1cc10478b0fb75a49477a8f3df0d162c))
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
			m_ApplicationMap.Remove(c1cc10478b0fb75a49477a8f3df0d162c);
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c263a18e823d534fe933bf797fd17c221();
	}

	public void c1347808c45481ed9d11a556bed90f456(int c4186652e5fea2643d3dd292dd25ca6c8)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c80dccacb4ad2025da2fe6f19283df8f6(c0046f307099fd607aa34fb7f77937c19, c4186652e5fea2643d3dd292dd25ca6c8);
	}

	public void c474237584e28f7acc3d8d13d9e2a60c8(int c4186652e5fea2643d3dd292dd25ca6c8)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ca17ae57694723b206af5bc3f02aa4d80(ce595ffacbd57155a388accae8a40bf65, c4186652e5fea2643d3dd292dd25ca6c8);
	}

	public void c3523f24b7f5c8c0e8868cf3e73f36d20(object c591d56a94543e3559945c497f37126c4)
	{
		if (!c17ba091c28b756583dc29d3eec870622())
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
			if (!cd6451c6b5252840b2be641871236928f())
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
				break;
			}
		}
		if (m_MyGuildInfo == null)
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3523f24b7f5c8c0e8868cf3e73f36d20(cfc0baa78739bf6e2b331bde552a1b902, m_MyGuildInfo.Id, (int)c591d56a94543e3559945c497f37126c4);
			return;
		}
	}

	public void c4452951e7bee358152c6581c43d96ef4(int cec67817d5516cb3510fc67791505c37e)
	{
	}

	public void cd6f90e917c845ddd5202db36d56473e6(GuildPreference c6895cb3f6c7f5284072399c244b895cd, int c81fdc8f345ce9bb23579d1db3a613b4c)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cd6f90e917c845ddd5202db36d56473e6(cabbf1cb66f954bcd06d39bf636e18d81, c6895cb3f6c7f5284072399c244b895cd, c81fdc8f345ce9bb23579d1db3a613b4c);
	}

	public void OnReceivedGuildMemberJoin(int guildId, int characterId)
	{
	}

	public void OnReceivedGuildMemberQuit(int guildId, int characterId)
	{
	}

	public void cd7f2c3b464455db93ee7e906dea031be()
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GUILD_QUIT_WARNING")), cb448a13457b461e53aba77f849b83b5d, c7d651aaa1089facff09b5f4a0e4cae3b);
	}

	private void cb448a13457b461e53aba77f849b83b5d()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cd7f2c3b464455db93ee7e906dea031be(c516a81f734a76d8e295d7554b3849807, m_MyGuildInfo.Id);
	}

	private void c7d651aaa1089facff09b5f4a0e4cae3b()
	{
	}

	public void c00df27457e44f5f399286b3f83145d4a(object c591d56a94543e3559945c497f37126c4)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c00df27457e44f5f399286b3f83145d4a(c746743e68a4ab52eb9f65164d987fc82, m_MyGuildInfo.Id, (int)c591d56a94543e3559945c497f37126c4);
	}

	protected void c37a4dfdfe0bb6a77bfa70d0189c5d0c3()
	{
	}

	protected void c27617d53253ac92976ca1e80eb6c0228()
	{
		m_bInGuild = true;
	}

	protected void c2e549f12ce0fd7db1f81b4bf1043d1f0()
	{
		m_bInGuild = false;
	}

	protected void c480130eba3c1b3cdab30b4631e4b5a6b()
	{
		m_bInGuild = true;
	}

	protected void c516a81f734a76d8e295d7554b3849807(bool cc76b4d742c039cbe828e163818855cc2)
	{
		if (!cc76b4d742c039cbe828e163818855cc2)
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
			m_bInGuild = false;
			m_nChairmanID = -1;
			m_MyGuildInfo = ce7a54a45dbe39fa8df21d851b9bd8980.c7088de59e49f7108f520cf7e0bae167e;
			m_GuildSkillList.Clear();
			if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().cd0069281ff5290a7e6c484b6aed3933d)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c150264a18c2cb408479d3f072cac8cc1 = false;
				return;
			}
		}
	}

	protected void c746743e68a4ab52eb9f65164d987fc82(bool ce789f9c3fe56ee71c44c6992c4b590bb, int caf6eab443a2932d5f7821586008dc1a3)
	{
		if (!ce789f9c3fe56ee71c44c6992c4b590bb)
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
			int num = -1;
			int num2 = 0;
			while (true)
			{
				if (num2 < m_MyGuildInfo.mMemberList.Count)
				{
					if (m_MyGuildInfo.mMemberList[num2].mCharacterId == caf6eab443a2932d5f7821586008dc1a3)
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
						num = num2;
						break;
					}
					num2++;
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
				break;
			}
			if (num == -1)
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
				m_MyGuildInfo.mMemberList.RemoveAt(num);
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c263a18e823d534fe933bf797fd17c221();
				return;
			}
		}
	}

	protected void c6c8c2af729555d5dd621e23fe9d20d9d(bool ce789f9c3fe56ee71c44c6992c4b590bb)
	{
		if (!ce789f9c3fe56ee71c44c6992c4b590bb)
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
			m_bInGuild = false;
			m_nChairmanID = -1;
			m_MyGuildInfo = ce7a54a45dbe39fa8df21d851b9bd8980.c7088de59e49f7108f520cf7e0bae167e;
			m_GuildSkillList.Clear();
			return;
		}
	}

	protected void c0ee8b8a4cadfb5c18684bb1afadaa7e4()
	{
	}

	public void OnReceivedFreeGuildSkillSlotGiven(int guildId, int remainFreeSkillCount)
	{
		c1c30180f8cf8e8933128caa5e48f49ae();
	}

	public void OnReceivedGuildSkillSelected(int guildId, int skillId, int remainFreeSkillCount)
	{
		if (!m_GuildSkillList.Contains(skillId))
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
			m_GuildSkillList.Add(skillId);
		}
		m_MyGuildInfo.FreeSkillCount = remainFreeSkillCount;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c263a18e823d534fe933bf797fd17c221();
	}

	public void OnReceivedGuildManagerAssigned(int guildId)
	{
		if (m_MyGuildInfo == null)
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
			if (m_MyGuildInfo.Id != guildId)
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
				if (m_GuildManagerList.Contains(OnlineService.s_characterId))
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
					m_GuildManagerList.Add(OnlineService.s_characterId);
					c9be8dfdfec9eb72150c0a63a13ec1fc4();
					return;
				}
			}
		}
	}

	public void OnReceivedGuildManagerDischarged(int guildId)
	{
		if (m_MyGuildInfo == null)
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
			if (m_MyGuildInfo.Id != guildId)
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
				if (!m_GuildManagerList.Contains(OnlineService.s_characterId))
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
					m_GuildManagerList.Remove(OnlineService.s_characterId);
					c9be8dfdfec9eb72150c0a63a13ec1fc4();
					return;
				}
			}
		}
	}

	public void OnReceivedGuildMasterChanged(int guildId)
	{
		c1c30180f8cf8e8933128caa5e48f49ae();
	}

	public void OnReceivedGuildInvitation(int guildId, string guildMasterNick, string guildName)
	{
		if (!m_bCanShowMessage)
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
			if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildOptionView>().cd0069281ff5290a7e6c484b6aed3933d)
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
				m_Invitation.guildId = guildId;
				m_Invitation.guildMasterName = guildMasterNick;
				m_Invitation.guildName = guildName;
				m_bCanShowMessage = false;
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildOptionView>().c150264a18c2cb408479d3f072cac8cc1 = true;
				return;
			}
		}
	}

	public void OnReceivedGuildJoined(int guildId, string guildName)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().cd0069281ff5290a7e6c484b6aed3933d)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c150264a18c2cb408479d3f072cac8cc1 = false;
		}
		c1c30180f8cf8e8933128caa5e48f49ae();
	}

	public void OnReceivedGuildExpelled(int guildId, string guildName)
	{
		if (m_MyGuildInfo == null)
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
			if (guildId != m_MyGuildInfo.Id)
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
				m_bInGuild = false;
				m_nChairmanID = -1;
				m_MyGuildInfo = ce7a54a45dbe39fa8df21d851b9bd8980.c7088de59e49f7108f520cf7e0bae167e;
				return;
			}
		}
	}

	protected void c635d2b4d45fc333661ef1440f14112f2()
	{
	}

	protected void c587b9ee913e731d59d9017d0743e1fd5()
	{
	}

	protected void c56330feeb39cac76b1880484b6cf26d8(string c49e5556fdc935f4f47cca749aa75e63e)
	{
	}

	protected void ca0fd2a9b02c5baf3a9c40a54c02af558(GuildCreationResult c72943404493c5c9abc349e4b65bfe91b, Guild c81664fee9b4eab9211583682c6e8eea5)
	{
		if (c81664fee9b4eab9211583682c6e8eea5 != null)
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
			m_bInGuild = true;
			m_nChairmanID = c81664fee9b4eab9211583682c6e8eea5.MasterCharacterId;
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildCreateView>().cd0069281ff5290a7e6c484b6aed3933d)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildCreateView>().cc130a2d46a451dc54b61a8f0d60794ae();
			}
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().cd0069281ff5290a7e6c484b6aed3933d)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().c9e01e4a7637451efd443facb83612139();
			}
			NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.None);
		}
		else
		{
			if (c72943404493c5c9abc349e4b65bfe91b == GuildCreationResult.FAILURE_GUILDNAME_EXISTS)
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
				c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5("81003");
			}
			if (c72943404493c5c9abc349e4b65bfe91b == GuildCreationResult.FAILURE_INSUFFICIENCY_MONEY)
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
				c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5("81004");
			}
			if (c72943404493c5c9abc349e4b65bfe91b == GuildCreationResult.FAILURE_GUILDNAME_PROFANITY)
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
				c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5("81007");
			}
		}
		m_MyGuildInfo = c81664fee9b4eab9211583682c6e8eea5;
	}

	private void cea5e9eb33be12b3f58817af0a3d06f80(int c4186652e5fea2643d3dd292dd25ca6c8, Guild c81664fee9b4eab9211583682c6e8eea5)
	{
		if (c81664fee9b4eab9211583682c6e8eea5 != null)
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
			if (c81664fee9b4eab9211583682c6e8eea5.Id != -1)
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
				m_bInGuild = true;
				m_nChairmanID = c81664fee9b4eab9211583682c6e8eea5.MasterCharacterId;
			}
		}
		m_MyGuildInfo = c81664fee9b4eab9211583682c6e8eea5;
	}

	private void c71163b3ee1f3b51ee98096502e92e415(int c4186652e5fea2643d3dd292dd25ca6c8, Guild c81664fee9b4eab9211583682c6e8eea5)
	{
		if (c81664fee9b4eab9211583682c6e8eea5 != null)
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
			if (c81664fee9b4eab9211583682c6e8eea5.Id != -1)
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
				m_bInGuild = true;
				m_nChairmanID = c81664fee9b4eab9211583682c6e8eea5.MasterCharacterId;
				m_strGuildDec = c81664fee9b4eab9211583682c6e8eea5.Banner;
			}
		}
		m_MyGuildInfo = c81664fee9b4eab9211583682c6e8eea5;
		if (m_MyGuildInfo == null)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					m_bInGuild = false;
					c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c508b282423394afe3d81a9f7faa2967b(c07c5cd5c0fdb2e053a6bf9b6862fad3f);
					return;
				}
			}
		}
		c7960fcef25da79e0adcf535b540f54eb();
		cd39d9f93990f17659465652406bdc997();
	}

	public void cd39d9f93990f17659465652406bdc997()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cd39d9f93990f17659465652406bdc997(c4225392143761d03a22bb5ca308521ee);
	}

	private void c4225392143761d03a22bb5ca308521ee(List<GuildSkill> c002fe47a6f957dcdea1d66b202fb0e9c)
	{
		m_GuildSkillList.Clear();
		for (int i = 0; i < c002fe47a6f957dcdea1d66b202fb0e9c.Count; i++)
		{
			m_GuildSkillList.Add(c002fe47a6f957dcdea1d66b202fb0e9c[i].Id);
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c263a18e823d534fe933bf797fd17c221(GuildSearchView.GuildSearchPart.e_GuildSkill);
			return;
		}
	}

	public void ce626290c115689a580e2ebc12dd2526d(int c7ee11c3571ca5bba1b824447823455dc)
	{
		if (!c17ba091c28b756583dc29d3eec870622())
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
			if (!cd6451c6b5252840b2be641871236928f())
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
				break;
			}
		}
		if (m_MyGuildInfo == null)
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
			if (m_MyGuildInfo.FreeSkillCount <= 0)
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c853aeff2d4c1e254c7e2970939494fb5(c7316726c02035255d888de3bc8e7d190, c7ee11c3571ca5bba1b824447823455dc);
				return;
			}
		}
	}

	private void c7316726c02035255d888de3bc8e7d190(bool ce789f9c3fe56ee71c44c6992c4b590bb, int cdc3aad41bf2754930ba17d687011c2ea)
	{
		if (!ce789f9c3fe56ee71c44c6992c4b590bb)
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
			if (!m_GuildSkillList.Contains(cdc3aad41bf2754930ba17d687011c2ea))
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
				m_GuildSkillList.Add(cdc3aad41bf2754930ba17d687011c2ea);
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c263a18e823d534fe933bf797fd17c221();
			return;
		}
	}

	public bool c497b35769b9508f621afc5281220456a(int c7ee11c3571ca5bba1b824447823455dc)
	{
		if (m_MyGuildInfo == null)
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
					return true;
				}
			}
		}
		if (m_GuildSkillList.Contains(c7ee11c3571ca5bba1b824447823455dc))
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
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_guildSkills.Length)
			{
				if (c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_guildSkills[num2].m_id == c7ee11c3571ca5bba1b824447823455dc)
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
					num = c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_guildSkills[num2].m_unlockLevel;
					break;
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
		if (num == 0)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return true;
				}
			}
		}
		if (m_MyGuildInfo.Level < num)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return true;
				}
			}
		}
		int num3 = -1;
		int num4 = -1;
		int num5 = 0;
		for (int i = 0; i < c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_guildSkills.Length; i++)
		{
			if (c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_guildSkills[i].m_unlockLevel != num)
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
			if (num5 == 0)
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
				num3 = c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_guildSkills[i].m_id;
				num5++;
			}
			else
			{
				num4 = c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_guildSkills[i].m_id;
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (num3 == c7ee11c3571ca5bba1b824447823455dc)
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
				if (m_GuildSkillList.Contains(num4))
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							return true;
						}
					}
				}
			}
			if (num4 == c7ee11c3571ca5bba1b824447823455dc)
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
				if (m_GuildSkillList.Contains(num3))
				{
					while (true)
					{
						switch (4)
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
	}

	public bool c354e921f1ff059ad29b4691d49cd75b2(int c0701990a8ae673273aa1faa2d9a3ac0a)
	{
		return m_GuildSkillList.Contains(c0701990a8ae673273aa1faa2d9a3ac0a);
	}

	public void c7960fcef25da79e0adcf535b540f54eb()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7960fcef25da79e0adcf535b540f54eb(cc87f1ae8a806d9385908160c240a79c6, m_MyGuildInfo.Id);
	}

	public void cc87f1ae8a806d9385908160c240a79c6(List<int> cdd2c98492d309036597aaeac6a5bec61)
	{
		m_GuildManagerList.Clear();
		for (int i = 0; i < cdd2c98492d309036597aaeac6a5bec61.Count; i++)
		{
			m_GuildManagerList.Add(cdd2c98492d309036597aaeac6a5bec61[i]);
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
			c9be8dfdfec9eb72150c0a63a13ec1fc4();
			return;
		}
	}

	private void ca7029b112fff56fb9f2691d6a92c386f(bool ce789f9c3fe56ee71c44c6992c4b590bb)
	{
		if (!ce789f9c3fe56ee71c44c6992c4b590bb)
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
			m_bInGuild = false;
			m_nChairmanID = -1;
			m_MyGuildInfo = ce7a54a45dbe39fa8df21d851b9bd8980.c7088de59e49f7108f520cf7e0bae167e;
			if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<NPCInteractiveView>().cd0069281ff5290a7e6c484b6aed3933d)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<NPCInteractiveView>().c1355bc0152e0d2e697663842a602d128();
				return;
			}
		}
	}

	private void cabbf1cb66f954bcd06d39bf636e18d81(List<Guild> c4619151681e13c611690c37967ae26e2)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().ce96b33ee40abc99c97f8a8ea66a99632() == 0)
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
			m_SearchResult.Clear();
			if (c4619151681e13c611690c37967ae26e2 != null)
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
				for (int i = 0; i < c4619151681e13c611690c37967ae26e2.Count; i++)
				{
					m_SearchResult.Add(c4619151681e13c611690c37967ae26e2[i]);
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().cb4e02cff1512be57edd191db2eec2b0a(c4619151681e13c611690c37967ae26e2.Count);
		}
		else
		{
			if (c4619151681e13c611690c37967ae26e2.Count != 0)
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
				m_SearchResult.Clear();
				if (c4619151681e13c611690c37967ae26e2 != null)
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
					for (int j = 0; j < c4619151681e13c611690c37967ae26e2.Count; j++)
					{
						m_SearchResult.Add(c4619151681e13c611690c37967ae26e2[j]);
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
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().cb4e02cff1512be57edd191db2eec2b0a(c4619151681e13c611690c37967ae26e2.Count);
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c263a18e823d534fe933bf797fd17c221();
	}

	private void c0046f307099fd607aa34fb7f77937c19(bool ce789f9c3fe56ee71c44c6992c4b590bb, int c4186652e5fea2643d3dd292dd25ca6c8)
	{
		if (ce789f9c3fe56ee71c44c6992c4b590bb)
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
			if (!m_AppliedGuildID.Contains(c4186652e5fea2643d3dd292dd25ca6c8))
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
				m_AppliedGuildID.Add(c4186652e5fea2643d3dd292dd25ca6c8);
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c263a18e823d534fe933bf797fd17c221();
	}

	public bool ca8e1c31c1cd2d0d3e5fd8c60e2ec1587()
	{
		return m_AppliedGuild.Count > 10;
	}

	public bool c8f6b66556de9658f8929503bb43e0b1f(int c4186652e5fea2643d3dd292dd25ca6c8)
	{
		return m_AppliedGuildID.Contains(c4186652e5fea2643d3dd292dd25ca6c8);
	}

	public int ce4966e5102b8689f56a50d45f9ab777c()
	{
		if (m_AppliedGuild.Count > 10)
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
					return 0;
				}
			}
		}
		return 10 - m_AppliedGuild.Count;
	}

	public bool cfd711de3351af645b2d20a2bea350915(int c4186652e5fea2643d3dd292dd25ca6c8)
	{
		bool flag = true;
		flag = !ca8e1c31c1cd2d0d3e5fd8c60e2ec1587();
		if (m_MyGuildInfo != null)
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
			if (m_MyGuildInfo.Id == c4186652e5fea2643d3dd292dd25ca6c8)
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
				flag = false;
			}
		}
		else if (m_AppliedGuildID.Contains(c4186652e5fea2643d3dd292dd25ca6c8))
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
			flag = false;
		}
		else
		{
			int num = 0;
			while (true)
			{
				if (num < m_AppliedGuild.Count)
				{
					if (c4186652e5fea2643d3dd292dd25ca6c8 == m_AppliedGuild[num].Id)
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
						flag = false;
						break;
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
		}
		return flag;
	}

	public void c508b282423394afe3d81a9f7faa2967b()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c508b282423394afe3d81a9f7faa2967b(c07c5cd5c0fdb2e053a6bf9b6862fad3f);
	}

	public Guild c06a3c1c3a086f54cdad2babac747cf54(int c872943035f78644fd01b267deff00547)
	{
		Guild result = ce7a54a45dbe39fa8df21d851b9bd8980.c7088de59e49f7108f520cf7e0bae167e;
		if (c872943035f78644fd01b267deff00547 >= 0)
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
			if (c872943035f78644fd01b267deff00547 < m_SearchResult.Count)
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
				result = m_SearchResult[c872943035f78644fd01b267deff00547];
			}
		}
		return result;
	}

	public Guild c2262ea095e753c6e870bd09796d69f55(int c5612a459a84ffdb41c885401433cd62d)
	{
		Guild result = ce7a54a45dbe39fa8df21d851b9bd8980.c7088de59e49f7108f520cf7e0bae167e;
		if (c5612a459a84ffdb41c885401433cd62d >= 0)
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
			if (c5612a459a84ffdb41c885401433cd62d < m_AppliedGuild.Count)
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
				result = m_AppliedGuild[c5612a459a84ffdb41c885401433cd62d];
			}
		}
		return result;
	}

	public Presence c02470b148853eea1ca9740b81d13751f(int c5612a459a84ffdb41c885401433cd62d)
	{
		Presence result = cce1d54b58f77fe2e3eead34ccfa0c349.c7088de59e49f7108f520cf7e0bae167e;
		if (c5612a459a84ffdb41c885401433cd62d >= 0)
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
			if (c5612a459a84ffdb41c885401433cd62d < m_ApplicationMap.Count)
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
				result = m_ApplicationMap.ElementAt(c5612a459a84ffdb41c885401433cd62d).Value.ApplicantPresence;
			}
		}
		return result;
	}

	public Presence cfcb510191c7a829452983b49c9afb8e5(int c5612a459a84ffdb41c885401433cd62d)
	{
		Presence result = cce1d54b58f77fe2e3eead34ccfa0c349.c7088de59e49f7108f520cf7e0bae167e;
		if (c5612a459a84ffdb41c885401433cd62d >= 0)
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
			if (c5612a459a84ffdb41c885401433cd62d < m_MyGuildInfo.mMemberList.Count)
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
				result = m_MyGuildInfo.mMemberList[c5612a459a84ffdb41c885401433cd62d];
			}
		}
		return result;
	}

	public int c8362b5a3b1526fd771678993faa4c0bf()
	{
		int result = 0;
		if (m_MyGuildInfo != null)
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
			result = m_MyGuildInfo.mMemberList.Count;
		}
		return result;
	}

	public int c8ceb61cd1200718c24169268b6f6633b()
	{
		int num = 0;
		if (m_MyGuildInfo != null)
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
			for (int i = 0; i < m_MyGuildInfo.mMemberList.Count; i++)
			{
				if (!m_MyGuildInfo.mMemberList[i].mIsOnline)
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
					break;
				}
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, m_MyGuildInfo.mMemberList[i].mCharacterName + " online!");
				num++;
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
		}
		return num;
	}

	public bool c4a9760ee198e35c4a8a01417d3c09b4d()
	{
		bool result = false;
		int num = 0;
		while (true)
		{
			if (num < m_MyGuildInfo.mMemberList.Count)
			{
				if (c17ba091c28b756583dc29d3eec870622(m_MyGuildInfo.mMemberList[num].mCharacterId))
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
					result = m_MyGuildInfo.mMemberList[num].mIsOnline;
					break;
				}
				num++;
				continue;
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
			break;
		}
		return result;
	}

	public ApplicationStatus c0c36f47b5eb99cef21538d13b28fbcdc(int c5612a459a84ffdb41c885401433cd62d)
	{
		ApplicationStatus result = ApplicationStatus.e_WaitingForDecide;
		if (c5612a459a84ffdb41c885401433cd62d >= 0)
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
			if (c5612a459a84ffdb41c885401433cd62d < m_ApplicationMap.Count)
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
				result = m_ApplicationMap.ElementAt(c5612a459a84ffdb41c885401433cd62d).Value.Status;
			}
		}
		return result;
	}

	public int c24a619997c1daa6d6672175b34cb8b83()
	{
		return m_ApplicationMap.Count;
	}

	private void cdf244fc8eb0139b70ae50013902ef830(Guild cac1a6bf54856bbcaa40f28036a43012f)
	{
		m_bCanShowMessage = true;
		if (cac1a6bf54856bbcaa40f28036a43012f != null)
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
			m_bInGuild = true;
			m_nChairmanID = cac1a6bf54856bbcaa40f28036a43012f.MasterAccountId;
			m_MyGuildInfo = cac1a6bf54856bbcaa40f28036a43012f;
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildOptionView>().c150264a18c2cb408479d3f072cac8cc1 = false;
	}

	private void cfc0baa78739bf6e2b331bde552a1b902(GuildInvitationResult c72943404493c5c9abc349e4b65bfe91b)
	{
		if (c72943404493c5c9abc349e4b65bfe91b == GuildInvitationResult.SUCCESS)
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
			c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5("81001");
			return;
		}
	}

	private void c07c5cd5c0fdb2e053a6bf9b6862fad3f(List<Guild> cf43b3b61a97639c0878fe27092f9a99e)
	{
		m_AppliedGuild.Clear();
		m_AppliedGuildID.Clear();
		if (cf43b3b61a97639c0878fe27092f9a99e != null)
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
			for (int i = 0; i < cf43b3b61a97639c0878fe27092f9a99e.Count; i++)
			{
				m_AppliedGuild.Add(cf43b3b61a97639c0878fe27092f9a99e[i]);
				m_AppliedGuildID.Add(cf43b3b61a97639c0878fe27092f9a99e[i].Id);
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
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c263a18e823d534fe933bf797fd17c221();
	}

	private void ce595ffacbd57155a388accae8a40bf65(bool ce789f9c3fe56ee71c44c6992c4b590bb)
	{
		if (!ce789f9c3fe56ee71c44c6992c4b590bb)
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c508b282423394afe3d81a9f7faa2967b(c07c5cd5c0fdb2e053a6bf9b6862fad3f);
			return;
		}
	}

	private void c0f2a2a4dd8be21e27c51b68deb07f600(int c461ff493f2218328a1c7e70d38d7bc72, int cacedcb56d35c529daebaf5b7b4430e51)
	{
		if (cacedcb56d35c529daebaf5b7b4430e51 <= 0)
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
			c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5("81009");
			return;
		}
	}

	public bool cd6451c6b5252840b2be641871236928f()
	{
		if (m_bInGuild)
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
					return m_GuildManagerList.Contains(OnlineService.s_characterId);
				}
			}
		}
		return false;
	}

	public bool cd6451c6b5252840b2be641871236928f(int cec67817d5516cb3510fc67791505c37e)
	{
		if (m_GuildManagerList.Contains(cec67817d5516cb3510fc67791505c37e))
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
					return true;
				}
			}
		}
		return false;
	}

	public void cb883fc7044d8839b5e1c445e7c5959ab(object c591d56a94543e3559945c497f37126c4)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cb883fc7044d8839b5e1c445e7c5959ab(c78ed7c1ead38fc4aeca1a3a462f9daef, m_MyGuildInfo.Id, (int)c591d56a94543e3559945c497f37126c4);
	}

	private void c78ed7c1ead38fc4aeca1a3a462f9daef(bool ce789f9c3fe56ee71c44c6992c4b590bb, int cec67817d5516cb3510fc67791505c37e)
	{
		if (ce789f9c3fe56ee71c44c6992c4b590bb)
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
					if (!m_GuildManagerList.Contains(cec67817d5516cb3510fc67791505c37e))
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								m_GuildManagerList.Add(cec67817d5516cb3510fc67791505c37e);
								c9be8dfdfec9eb72150c0a63a13ec1fc4();
								return;
							}
						}
					}
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5("81014");
	}

	public void cbe14e0cf727992257c34640ca9933a47(object c591d56a94543e3559945c497f37126c4)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cbe14e0cf727992257c34640ca9933a47(c98a3d551201d1d191d94c1e120b5cd69, m_MyGuildInfo.Id, (int)c591d56a94543e3559945c497f37126c4);
	}

	private void c98a3d551201d1d191d94c1e120b5cd69(bool ce789f9c3fe56ee71c44c6992c4b590bb, int cec67817d5516cb3510fc67791505c37e)
	{
		if (!ce789f9c3fe56ee71c44c6992c4b590bb)
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
			if (!m_GuildManagerList.Contains(cec67817d5516cb3510fc67791505c37e))
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
				m_GuildManagerList.Remove(cec67817d5516cb3510fc67791505c37e);
				c9be8dfdfec9eb72150c0a63a13ec1fc4();
				return;
			}
		}
	}

	public void c779b55c400efe6490d8243ee1bd96e4d(object c591d56a94543e3559945c497f37126c4)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c779b55c400efe6490d8243ee1bd96e4d(c7e569de34c14137b3b8a4de2ab400c0a, (int)c591d56a94543e3559945c497f37126c4);
	}

	private void c7e569de34c14137b3b8a4de2ab400c0a(bool ce789f9c3fe56ee71c44c6992c4b590bb, int c9ab3c3d0c17f00500136dd6ed6fda285)
	{
		if (!ce789f9c3fe56ee71c44c6992c4b590bb)
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
			m_MyGuildInfo.MasterCharacterId = c9ab3c3d0c17f00500136dd6ed6fda285;
			m_nChairmanID = c9ab3c3d0c17f00500136dd6ed6fda285;
			c9be8dfdfec9eb72150c0a63a13ec1fc4();
			return;
		}
	}

	public string cdfc3c128a8ef3481d219619ff7c528ef()
	{
		if (m_MyGuildInfo != null)
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
					return m_MyGuildInfo.Name;
				}
			}
		}
		return string.Empty;
	}

	public int c846bf4a4017139a7dce7c6d98220157c()
	{
		int result = 1;
		if (m_MyGuildInfo != null)
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
			result = m_MyGuildInfo.Level;
		}
		return result;
	}

	public string c65298fc86b05864e137848a671fdf996()
	{
		return m_strGuildDec;
	}

	public void cf10dc670a45bb0104e6966f4a2b2d3e9()
	{
		m_SearchResult.Clear();
	}

	public void cc94fcaeab5d835c80bf5ec715de08e9a()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cc94fcaeab5d835c80bf5ec715de08e9a(c7d6eda605ca752be516d4b2ec957ec34);
	}

	protected void c7d6eda605ca752be516d4b2ec957ec34(List<GuildNews> c6fd052646537b76010d98e3472ecadda)
	{
		m_GuildNews.Clear();
		if (c6fd052646537b76010d98e3472ecadda != null)
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
			for (int i = 0; i < c6fd052646537b76010d98e3472ecadda.Count; i++)
			{
				m_GuildNews.Add(c6fd052646537b76010d98e3472ecadda[i]);
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
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c263a18e823d534fe933bf797fd17c221(GuildSearchView.GuildSearchPart.e_GuildNews);
	}

	public int cef77de19f0228e00b7b1845e7c887019()
	{
		return m_GuildNews.Count;
	}

	public Presence c9adc655cdda083dfb3dbd17ece0f54db(int cec67817d5516cb3510fc67791505c37e)
	{
		Presence result = cce1d54b58f77fe2e3eead34ccfa0c349.c7088de59e49f7108f520cf7e0bae167e;
		if (m_MyGuildInfo != null)
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
			int num = 0;
			while (true)
			{
				if (num < m_MyGuildInfo.ced4f209cd82cf504446bed630a19d684.Count)
				{
					if (m_MyGuildInfo.ced4f209cd82cf504446bed630a19d684[num].mCharacterId == cec67817d5516cb3510fc67791505c37e)
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
						result = m_MyGuildInfo.ced4f209cd82cf504446bed630a19d684[num];
						break;
					}
					num++;
					continue;
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
				break;
			}
		}
		return result;
	}

	public GuildNews c70379a017e027584de6c517a58028c52(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (c5612a459a84ffdb41c885401433cd62d >= 0)
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
			if (c5612a459a84ffdb41c885401433cd62d < m_GuildNews.Count)
			{
				return m_GuildNews[c5612a459a84ffdb41c885401433cd62d];
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
		return null;
	}

	public int c718d841fbf38cce02a34f1e1bb2242d8()
	{
		int result = 0;
		if (m_MyGuildInfo != null)
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
					return m_MyGuildInfo.FreeSkillCount;
				}
			}
		}
		return result;
	}

	public void c055fde1cbb50b2caadff9b9898ec0f9a(int cec67817d5516cb3510fc67791505c37e)
	{
		if (cec67817d5516cb3510fc67791505c37e == -1)
		{
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
				return;
			}
		}
		Presence presence = c9adc655cdda083dfb3dbd17ece0f54db(cec67817d5516cb3510fc67791505c37e);
		MenuItemDef[] array = cacffdc9bda8a41773c3ac61797275a6c.c0a0cdf4a196914163f7334d9b0781a04(7);
		array[0].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Group_Invitation"));
		array[0].itemData = cec67817d5516cb3510fc67791505c37e;
		if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
		{
			goto IL_00a9;
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
		if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c8a142a1ecdf6817b0b02b74d6d1c8796())
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
			if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c87b271fc3048524b0894366245574631(cec67817d5516cb3510fc67791505c37e))
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
				goto IL_00a9;
			}
		}
		array[0].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
		goto IL_0107;
		IL_039f:
		array[4].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GUILD_Manager_Discharge"));
		array[4].itemData = cec67817d5516cb3510fc67791505c37e;
		if (c17ba091c28b756583dc29d3eec870622())
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
			if (cd6451c6b5252840b2be641871236928f(cec67817d5516cb3510fc67791505c37e))
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
				if (OnlineService.s_characterId != cec67817d5516cb3510fc67791505c37e)
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
					array[4].itemFunc = cbe14e0cf727992257c34640ca9933a47;
					goto IL_0434;
				}
			}
		}
		array[4].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
		goto IL_0434;
		IL_0434:
		array[5].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GUILD_Owner_Assign"));
		array[5].itemData = cec67817d5516cb3510fc67791505c37e;
		if (c17ba091c28b756583dc29d3eec870622())
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
			if (OnlineService.s_characterId != cec67817d5516cb3510fc67791505c37e)
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
				array[5].itemFunc = c779b55c400efe6490d8243ee1bd96e4d;
				goto IL_04b4;
			}
		}
		array[5].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
		goto IL_04b4;
		IL_04b4:
		array[6].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Chat_Send"));
		if (presence != null)
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
			array[6].itemData = presence.mCharacterName;
			if (presence.mIsOnline)
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
				if (presence.mCharacterName == c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409())
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
					array[6].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
				}
				else
				{
					array[6].itemFunc = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ChatView>().c9c8e5a517b23a2b1acabe838f9baf845;
				}
			}
			else
			{
				array[6].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
			}
		}
		else
		{
			array[6].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().c687c56ed531550f24368180c4c3bc947(array);
		return;
		IL_02c4:
		array[2].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
		goto IL_02d5;
		IL_00a9:
		if (cec67817d5516cb3510fc67791505c37e != m_MyGuildInfo.MasterCharacterId)
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
			array[0].itemFunc = GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c89fcb77276a7956cd51b61c3a4437b0f;
		}
		else
		{
			array[0].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
		}
		goto IL_0107;
		IL_02d5:
		array[3].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GUILD_Manager_Assign"));
		array[3].itemData = cec67817d5516cb3510fc67791505c37e;
		if (c17ba091c28b756583dc29d3eec870622())
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
			if (!cd6451c6b5252840b2be641871236928f(cec67817d5516cb3510fc67791505c37e))
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
				if (OnlineService.s_characterId != cec67817d5516cb3510fc67791505c37e)
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
					if (m_GuildManagerList.Count < m_nMaxGuildManagerCount)
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
						array[3].itemFunc = cb883fc7044d8839b5e1c445e7c5959ab;
					}
					else
					{
						array[3].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
					}
					goto IL_039f;
				}
			}
		}
		array[3].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
		goto IL_039f;
		IL_01b6:
		array[2].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Group_Exple"));
		array[2].itemData = cec67817d5516cb3510fc67791505c37e;
		if (!c17ba091c28b756583dc29d3eec870622())
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
			if (!cd6451c6b5252840b2be641871236928f())
			{
				goto IL_02c4;
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
		if (cec67817d5516cb3510fc67791505c37e == m_MyGuildInfo.MasterCharacterId)
		{
			goto IL_02c4;
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
		if (c17ba091c28b756583dc29d3eec870622())
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
			array[2].itemFunc = c00df27457e44f5f399286b3f83145d4a;
		}
		else if (cd6451c6b5252840b2be641871236928f())
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
			if (cd6451c6b5252840b2be641871236928f(cec67817d5516cb3510fc67791505c37e))
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
				array[2].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
			}
			else
			{
				array[2].itemFunc = c00df27457e44f5f399286b3f83145d4a;
			}
		}
		else
		{
			array[2].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
		}
		goto IL_02d5;
		IL_0107:
		array[1].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Friend_Invitation"));
		array[1].itemData = cec67817d5516cb3510fc67791505c37e;
		if (!FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c52b0e4c302961935453bec436d84dc68(cec67817d5516cb3510fc67791505c37e))
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
			if (cec67817d5516cb3510fc67791505c37e != m_MyGuildInfo.MasterCharacterId)
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
				if (FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c20292dc0112b596d061ae25400743cc5())
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
					array[1].itemFunc = FriendManager.c71f6ce28731edfd43c976fbd57c57bea().cbbcfd0bf92e11cfa6ba6b913e85d9791;
					goto IL_01b6;
				}
			}
		}
		array[1].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
		goto IL_01b6;
	}
}
