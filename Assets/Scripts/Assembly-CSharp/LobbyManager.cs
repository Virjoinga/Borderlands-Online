using System;
using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using XsdSettings;

public class LobbyManager : ILobbyServiceNotificationListerner
{
	protected static LobbyManager _LobbyInstance;

	private Lobby m_MyRoom;

	public int m_nTargetCharacterId = -1;

	public bool m_bCanShowLobbyECHO = true;

	private int m_nMessageId = -1;

	private Lobby m_MyPvERoom;

	private int m_nPvEInstance = -1;

	public bool m_bCanShowMessage = true;

	private Presence m_senderInfo;

	private Dictionary<int, MatchRecord> m_PlayerRecord;

	public Lobby cf5b9332c9bfbdc7648aaad2509591a7d
	{
		get
		{
			return m_MyRoom;
		}
	}

	public Lobby c02871361bbce7d8a240cb3023dd5d12c
	{
		get
		{
			return m_MyPvERoom;
		}
	}

	private LobbyManager()
	{
		if (m_PlayerRecord != null)
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
			m_PlayerRecord = new Dictionary<int, MatchRecord>();
			m_PlayerRecord.Clear();
			return;
		}
	}

	public static LobbyManager c71f6ce28731edfd43c976fbd57c57bea()
	{
		if (_LobbyInstance == null)
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
			_LobbyInstance = new LobbyManager();
			c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(_LobbyInstance);
		}
		return _LobbyInstance;
	}

	public bool c76154b5d193e30b53344242a665f1fe4()
	{
		if (m_MyRoom == null)
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
					return false;
				}
			}
		}
		return true;
	}

	public bool c03e08ddbd7a06ade357b3ce0364b3f94()
	{
		if (m_MyRoom == null)
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
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_characterId != m_MyRoom.Owner)
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
		return true;
	}

	public bool c03e08ddbd7a06ade357b3ce0364b3f94(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (m_MyRoom == null)
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
					return false;
				}
			}
		}
		if (c5dfde30d8784694fb9999709d290e6c4 != m_MyRoom.Owner)
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
		return true;
	}

	private int c3d1bb3692c0855c4147e6387b76d54a6(Presence cfb724368a3fa3bbd82dd2f1d7e4bfe47, Presence c1ad7a5a20221cf18e17547b794ebc902)
	{
		if (c1ad7a5a20221cf18e17547b794ebc902.mCharacterId == m_MyRoom.Owner)
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
					return 1;
				}
			}
		}
		return -1;
	}

	public bool c487629df5d3f6240821140b3e6ca8783()
	{
		if (m_MyRoom != null)
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
					return m_MyRoom.Members.Count >= 8;
				}
			}
		}
		return false;
	}

	public int caa44e85b88b13372e89502b18c25780d()
	{
		int result = 0;
		if (m_MyRoom != null)
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
			result = m_MyRoom.Members.Count;
		}
		return result;
	}

	public Presence c21e522aeeaf7bcca3d0ea44730a13b6d()
	{
		Presence result = cce1d54b58f77fe2e3eead34ccfa0c349.c7088de59e49f7108f520cf7e0bae167e;
		if (m_MyRoom != null)
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
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				int characterId = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_characterId;
				int num = 0;
				while (true)
				{
					if (num < m_MyRoom.Members.Count)
					{
						if (m_MyRoom.Members[num].mCharacterId == characterId)
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
							result = m_MyRoom.Members[num];
							break;
						}
						num++;
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
					break;
				}
			}
		}
		return result;
	}

	public Presence cd36269e0c4619dc5307d8034050d3c8d(int c62a53388af21c9e5e206591a30eb9f80)
	{
		if (m_MyRoom != null)
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
					if (c62a53388af21c9e5e206591a30eb9f80 >= 0)
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
						if (c62a53388af21c9e5e206591a30eb9f80 < m_MyRoom.Members.Count)
						{
							return m_MyRoom.Members[c62a53388af21c9e5e206591a30eb9f80];
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
					return null;
				}
			}
		}
		return null;
	}

	public void c5bb97cae178d4b25c1e804580f327373()
	{
		if (m_MyRoom != null)
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c400ced1c9947fde74182ee4f25a9570e(OnGetMyLobby);
			return;
		}
	}

	protected void OnGetMyLobby(Lobby room)
	{
		m_MyRoom = room;
		if (m_MyRoom == null)
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
			m_MyRoom.Members.Sort(c3d1bb3692c0855c4147e6387b76d54a6);
			return;
		}
	}

	public void c4909d1c0768ec3bfe69de624ebc2ff32(int ccc15ba28a96efe390f868ffde0345c5f)
	{
		m_nPvEInstance = ccc15ba28a96efe390f868ffde0345c5f;
		c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cf919217c11722f259176c952c8aba513(OnPvELobbyCreated, false);
	}

	public void OnPvELobbyCreated(Lobby room)
	{
		m_MyPvERoom = room;
		if (room == null)
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
			c08552dbd71d791f0c513756c98e5a635();
			return;
		}
	}

	public void c08552dbd71d791f0c513756c98e5a635()
	{
		m_MyPvERoom.GameMode = GamemodeType.GamemodePvE;
		m_MyPvERoom.Playlist = m_nPvEInstance;
		if (!cd32d91087eba68a8898d7f9466c7c721())
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c5e5cc544f50051d78abdccc1aec483a8(OnOpenPvELobby, GamemodeType.GamemodePvE, m_nPvEInstance, c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_difficulty);
			return;
		}
	}

	protected void OnOpenPvELobby(Lobby lobby)
	{
		c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5("80001");
	}

	public bool cd32d91087eba68a8898d7f9466c7c721()
	{
		if (c02871361bbce7d8a240cb3023dd5d12c == null)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "~~~~~~~" + c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409() + " MyPvELobby is null!!!");
					return false;
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "~~~~~~~" + c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409() + " Local Player is null!!!");
					return false;
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_characterId != c02871361bbce7d8a240cb3023dd5d12c.Owner)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
				{
					string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(6);
					array[0] = "~~~~~~~";
					array[1] = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409();
					array[2] = " not PvE lobby owner!!! Id:";
					array[3] = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_characterId.ToString();
					array[4] = "Owner Id:";
					array[5] = m_MyPvERoom.Owner.ToString();
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, string.Concat(array));
					return false;
				}
				}
			}
		}
		return true;
	}

	public bool cd32d91087eba68a8898d7f9466c7c721(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (c02871361bbce7d8a240cb3023dd5d12c == null)
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
					return false;
				}
			}
		}
		if (c5dfde30d8784694fb9999709d290e6c4 != c02871361bbce7d8a240cb3023dd5d12c.Owner)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return true;
	}

	public bool ccf43e054fa157ad0e22e94fc2035fd4f()
	{
		if (c02871361bbce7d8a240cb3023dd5d12c != null)
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
					return c02871361bbce7d8a240cb3023dd5d12c.Members.Count >= 4;
				}
			}
		}
		return false;
	}

	public void cb155f2586fade9c6703c740916aacf6d()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cf919217c11722f259176c952c8aba513(OnLobbyCreated, true);
	}

	public void c3f65cc88af0ef84cc42196bbe25136c4(GamemodeType c7c285f21497bec76d425ba4a0a524b46, int c62856dd6dd9686293af23b8532ee3525)
	{
		m_MyRoom.GameMode = c7c285f21497bec76d425ba4a0a524b46;
		m_MyRoom.Playlist = c62856dd6dd9686293af23b8532ee3525;
		if (!c03e08ddbd7a06ade357b3ce0364b3f94())
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c5e5cc544f50051d78abdccc1aec483a8(OnOpenLobby, c7c285f21497bec76d425ba4a0a524b46, c62856dd6dd9686293af23b8532ee3525, ELevelDifficulty.Normal);
			return;
		}
	}

	protected void OnOpenLobby(Lobby lobby)
	{
		if (!c03e08ddbd7a06ade357b3ce0364b3f94())
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
			c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5("80001");
			return;
		}
	}

	public void c9ae14989b238c7ea986761bc0a3353e2(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (!c03e08ddbd7a06ade357b3ce0364b3f94())
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ca1a46125e5889b9b6092367966900859(c2698dd60049003318842e1656ca4bae4, c5dfde30d8784694fb9999709d290e6c4);
			return;
		}
	}

	protected void c2698dd60049003318842e1656ca4bae4(bool cc76b4d742c039cbe828e163818855cc2)
	{
	}

	public void c56f2ef09c2c7b78d464a6d3be6b30e33()
	{
		if (m_nMessageId != -1)
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c56f2ef09c2c7b78d464a6d3be6b30e33(cc266c7ba8491884de50fbe239c53ece5, m_nMessageId);
		}
		else
		{
			m_nMessageId = -1;
			m_bCanShowMessage = true;
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPTipsView>().c150264a18c2cb408479d3f072cac8cc1 = false;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().cc130a2d46a451dc54b61a8f0d60794ae();
	}

	protected void cc266c7ba8491884de50fbe239c53ece5(Lobby c3202f32ecb834b115326e72e13e35ff0)
	{
		m_MyRoom = c3202f32ecb834b115326e72e13e35ff0;
		if (m_MyRoom == null)
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
			m_MyRoom.Members.Sort(c3d1bb3692c0855c4147e6387b76d54a6);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().c263a18e823d534fe933bf797fd17c221();
			return;
		}
	}

	public void cb29008727fccd108206478ea0a634586()
	{
		if (m_nMessageId != -1)
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cb29008727fccd108206478ea0a634586(c3fc458e17f75f8e4b4ef0bde23b245a7, m_nMessageId);
		}
		m_nMessageId = -1;
		m_bCanShowMessage = true;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPTipsView>().c150264a18c2cb408479d3f072cac8cc1 = false;
	}

	protected void c3fc458e17f75f8e4b4ef0bde23b245a7(bool ce789f9c3fe56ee71c44c6992c4b590bb)
	{
	}

	public void c90e08ff45bd89b1b852ef7a4959d640b(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (!c03e08ddbd7a06ade357b3ce0364b3f94())
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c90e08ff45bd89b1b852ef7a4959d640b(cd8772c3a3b0879c7d9ffafa631c811d5, c5dfde30d8784694fb9999709d290e6c4);
			if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c8a142a1ecdf6817b0b02b74d6d1c8796())
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
				if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c87b271fc3048524b0894366245574631(c5dfde30d8784694fb9999709d290e6c4))
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
					GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c60391e061cd6d8a60db5fc9a6f83aafe(c5dfde30d8784694fb9999709d290e6c4);
					return;
				}
			}
		}
	}

	private void cd8772c3a3b0879c7d9ffafa631c811d5(bool ce789f9c3fe56ee71c44c6992c4b590bb, int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (ce789f9c3fe56ee71c44c6992c4b590bb)
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
			if (m_MyRoom != null)
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
				m_MyRoom.c7e6306ae6375d9ab6d595d202da0b160(c5dfde30d8784694fb9999709d290e6c4);
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().c263a18e823d534fe933bf797fd17c221();
	}

	public void ce30914cedf948c8ebefe3783fb6c7f87()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ce30914cedf948c8ebefe3783fb6c7f87(c73195e0b03f5061cb935d15797cbb399);
	}

	protected void c73195e0b03f5061cb935d15797cbb399(bool ce789f9c3fe56ee71c44c6992c4b590bb)
	{
		if (!ce789f9c3fe56ee71c44c6992c4b590bb)
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
			m_MyRoom = c879d606e15475cf9d576cc62b721ca45.c7088de59e49f7108f520cf7e0bae167e;
			GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c635f796eee513fdcf0733537d7f44398();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().c150264a18c2cb408479d3f072cac8cc1 = false;
			return;
		}
	}

	public void c7a337098f70dabdd1dc7f3a6a249dc79()
	{
		if (!c03e08ddbd7a06ade357b3ce0364b3f94())
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
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c7a337098f70dabdd1dc7f3a6a249dc79(OnCloseLobby);
			return;
		}
	}

	protected void OnCloseLobby(bool success)
	{
		if (!success)
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
			m_MyRoom = c879d606e15475cf9d576cc62b721ca45.c7088de59e49f7108f520cf7e0bae167e;
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().cd0069281ff5290a7e6c484b6aed3933d)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().c150264a18c2cb408479d3f072cac8cc1 = false;
			}
			if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().cd0069281ff5290a7e6c484b6aed3933d)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().c150264a18c2cb408479d3f072cac8cc1 = false;
				return;
			}
		}
	}

	public void OnNewLobby(Lobby newLobby)
	{
		if (newLobby.GameMode == GamemodeType.GamemodePvE)
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
					m_MyPvERoom = newLobby;
					return;
				}
			}
		}
		m_MyRoom = newLobby;
		if (m_MyRoom != null)
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
			m_MyRoom.Members.Sort(c3d1bb3692c0855c4147e6387b76d54a6);
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().c263a18e823d534fe933bf797fd17c221();
		if (c03e08ddbd7a06ade357b3ce0364b3f94())
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
			if (m_bCanShowLobbyECHO)
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
				c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5("80001");
				m_bCanShowLobbyECHO = false;
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().c150264a18c2cb408479d3f072cac8cc1 = false;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().c150264a18c2cb408479d3f072cac8cc1 = true;
			return;
		}
	}

	public void OnPlayerJoinLobby(Presence newPlayer)
	{
		if (newPlayer == null)
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
			if (m_MyRoom != null)
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
				m_MyRoom.c824d853466705b61a4e964c504c0da81(newPlayer);
				m_MyRoom.Members.Sort(c3d1bb3692c0855c4147e6387b76d54a6);
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().c263a18e823d534fe933bf797fd17c221();
			return;
		}
	}

	public void OnPlayerLeaveLobby(int characterId)
	{
		GameUIManager gameUIManager = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3();
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
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						if (characterId == c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_characterId)
						{
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									m_MyRoom = c879d606e15475cf9d576cc62b721ca45.c7088de59e49f7108f520cf7e0bae167e;
									m_PlayerRecord.Clear();
									if (gameUIManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
									{
										while (true)
										{
											switch (3)
											{
											case 0:
												break;
											default:
											{
												PvPFlowView pvPFlowView = gameUIManager.c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>();
												if (pvPFlowView != null)
												{
													while (true)
													{
														switch (7)
														{
														case 0:
															break;
														default:
															pvPFlowView.c150264a18c2cb408479d3f072cac8cc1 = false;
															return;
														}
													}
												}
												return;
											}
											}
										}
									}
									return;
								}
							}
						}
						return;
					}
				}
			}
		}
		if (m_MyRoom != null)
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
			m_MyRoom.c7e6306ae6375d9ab6d595d202da0b160(characterId);
		}
		if (m_PlayerRecord != null)
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
			if (m_PlayerRecord.ContainsKey(characterId))
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
				m_PlayerRecord.Remove(characterId);
			}
		}
		if (!(gameUIManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			PvPFlowView pvPFlowView2 = gameUIManager.c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>();
			if (pvPFlowView2 == null)
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
				if (!pvPFlowView2.cd0069281ff5290a7e6c484b6aed3933d)
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
					pvPFlowView2.c263a18e823d534fe933bf797fd17c221();
					return;
				}
			}
		}
	}

	public void OnLobbyCreated(Lobby room)
	{
		m_MyRoom = room;
		if (m_MyRoom == null)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().c93da48f317472e2d30deca60386d9a58();
			m_MyRoom.Members.Sort(c3d1bb3692c0855c4147e6387b76d54a6);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().c263a18e823d534fe933bf797fd17c221();
			return;
		}
	}

	public void OnLobbyGameStart()
	{
	}

	public void OnLobbyClose()
	{
		if (m_MyRoom != null)
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
			m_MyRoom = c879d606e15475cf9d576cc62b721ca45.c7088de59e49f7108f520cf7e0bae167e;
			m_PlayerRecord.Clear();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().c150264a18c2cb408479d3f072cac8cc1 = false;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().c93da48f317472e2d30deca60386d9a58();
		}
		if (m_MyPvERoom == null)
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
			m_MyPvERoom = c879d606e15475cf9d576cc62b721ca45.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void OnLobbyOwnerChange(int newOwnerCharacterId)
	{
		if (m_MyRoom != null)
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
			m_MyRoom.Owner = newOwnerCharacterId;
			m_MyRoom.Members.Sort(c3d1bb3692c0855c4147e6387b76d54a6);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().c263a18e823d534fe933bf797fd17c221();
		}
		if (m_MyPvERoom == null)
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
			m_MyPvERoom.Owner = newOwnerCharacterId;
			return;
		}
	}

	public void OnGroupJoinLobby(int newGroup)
	{
	}

	public void OnGroupLeaveLobby(int newGroup)
	{
	}

	public void OnLobbyInvitationRecieved(int sender, int messageId)
	{
		if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
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
		if (!m_bCanShowMessage)
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
			m_bCanShowMessage = false;
			m_nMessageId = messageId;
			OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c171cc9079535e716dc2c8dd3677a6256(sender, c6d00de83b1a38d26c8edadea7d1bc278);
			return;
		}
	}

	public void c6d00de83b1a38d26c8edadea7d1bc278(Presence c57b01bb713a45dd68b36b4f255e08dff)
	{
		if (c57b01bb713a45dd68b36b4f255e08dff != null)
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
					m_senderInfo = c57b01bb713a45dd68b36b4f255e08dff;
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPTipsView>().c150264a18c2cb408479d3f072cac8cc1 = true;
					return;
				}
			}
		}
		m_nMessageId = -1;
		m_bCanShowMessage = true;
	}

	public string c21e3fb25e984c496cedc0a63b1159b2b()
	{
		string result = string.Empty;
		if (m_senderInfo != null)
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
			result = m_senderInfo.mCharacterName;
		}
		return result;
	}

	public void c8f46bdc59faaa4c24f98ee46924af401(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (c5dfde30d8784694fb9999709d290e6c4 == -1)
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
		m_nTargetCharacterId = c5dfde30d8784694fb9999709d290e6c4;
		if (m_PlayerRecord.ContainsKey(c5dfde30d8784694fb9999709d290e6c4))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().c84e874fe933f0054c408cf6d29002635(c5dfde30d8784694fb9999709d290e6c4);
					return;
				}
			}
		}
		OnAccessSingleton<IMatchRecordService, MatchRecordService, MatchRecordServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c01213846eb5656726889fdb7be49adac(c1ebe175bfae130ed0dd312c8b0bf5f3b, c5dfde30d8784694fb9999709d290e6c4);
	}

	public void c1ebe175bfae130ed0dd312c8b0bf5f3b(MatchRecord cc57e927eaf751968c52c3c731ce80bab)
	{
		if (cc57e927eaf751968c52c3c731ce80bab == null)
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
			if (m_PlayerRecord.ContainsKey(cc57e927eaf751968c52c3c731ce80bab.CharacterId))
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
				m_PlayerRecord.Add(cc57e927eaf751968c52c3c731ce80bab.CharacterId, cc57e927eaf751968c52c3c731ce80bab);
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().c84e874fe933f0054c408cf6d29002635(cc57e927eaf751968c52c3c731ce80bab.CharacterId);
				return;
			}
		}
	}

	public int c6619468f0932e2230c557ba2cd7304ef(int c5dfde30d8784694fb9999709d290e6c4)
	{
		return m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].TotalMatchCount;
	}

	public int ca04453b994172f72867b29f29524d679(int c5dfde30d8784694fb9999709d290e6c4)
	{
		return m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].TotalHonorPoint;
	}

	public string c20779a4b227671104ddab39ea26f409c(int c5dfde30d8784694fb9999709d290e6c4)
	{
		return m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].TotalKillCount + "/" + m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].TotalDeathCount;
	}

	public string c5247e943f91eab848d503f98588e1394(int c5dfde30d8784694fb9999709d290e6c4)
	{
		return m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].TotalWinCount + "/" + m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].TotalLossCount;
	}

	public int ce574ea8e3af3f348b2d6bf384b7bcc47(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].mMatchTypeFactors.ContainsKey(GamemodeType.GamemodeDeathmatch))
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
					Hashtable hashtable = m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].mMatchTypeFactors[GamemodeType.GamemodeDeathmatch];
					return Convert.ToInt32(hashtable[4]);
				}
				}
			}
		}
		return 0;
	}

	public int c41b3d32fd607d52a1df96c223a79b063(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].mMatchTypeFactors.ContainsKey(GamemodeType.GamemodeDeathmatch))
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					Hashtable hashtable = m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].mMatchTypeFactors[GamemodeType.GamemodeDeathmatch];
					return Convert.ToInt32(hashtable[6]);
				}
				}
			}
		}
		return 0;
	}

	public string cff276e47b032c5207a61a940cdae6a92(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].mMatchTypeFactors.ContainsKey(GamemodeType.GamemodeDeathmatch))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					Hashtable hashtable = m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].mMatchTypeFactors[GamemodeType.GamemodeDeathmatch];
					return Convert.ToInt32(hashtable[2]) + "/" + Convert.ToInt32(hashtable[3]);
				}
				}
			}
		}
		return "0/0";
	}

	public string cb2292c0a3565071b2f7b68f23c300b30(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].mMatchTypeFactors.ContainsKey(GamemodeType.GamemodeDeathmatch))
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					Hashtable hashtable = m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].mMatchTypeFactors[GamemodeType.GamemodeDeathmatch];
					return Convert.ToInt32(hashtable[0]) + "/" + Convert.ToInt32(hashtable[1]);
				}
				}
			}
		}
		return "0/0";
	}

	public int c8dcde2232ad460a011b8ad821e5a9272(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].mMatchTypeFactors.ContainsKey(GamemodeType.GamemodeTeamDeathmatch))
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
					Hashtable hashtable = m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].mMatchTypeFactors[GamemodeType.GamemodeTeamDeathmatch];
					return Convert.ToInt32(hashtable[4]);
				}
				}
			}
		}
		return 0;
	}

	public int c087b8770187c88bb321cf20e82562b03(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].mMatchTypeFactors.ContainsKey(GamemodeType.GamemodeTeamDeathmatch))
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
					Hashtable hashtable = m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].mMatchTypeFactors[GamemodeType.GamemodeTeamDeathmatch];
					return Convert.ToInt32(hashtable[6]);
				}
				}
			}
		}
		return 0;
	}

	public string c9d9fa7b15e5679d955b99ae26e527c7c(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].mMatchTypeFactors.ContainsKey(GamemodeType.GamemodeTeamDeathmatch))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					Hashtable hashtable = m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].mMatchTypeFactors[GamemodeType.GamemodeTeamDeathmatch];
					return Convert.ToInt32(hashtable[2]) + "/" + Convert.ToInt32(hashtable[3]);
				}
				}
			}
		}
		return "0/0";
	}

	public string cfd32b145462aafa7dd1957f8c1efd961(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].mMatchTypeFactors.ContainsKey(GamemodeType.GamemodeTeamDeathmatch))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					Hashtable hashtable = m_PlayerRecord[c5dfde30d8784694fb9999709d290e6c4].mMatchTypeFactors[GamemodeType.GamemodeTeamDeathmatch];
					return Convert.ToInt32(hashtable[0]) + "/" + Convert.ToInt32(hashtable[1]);
				}
				}
			}
		}
		return "0/0";
	}
}
