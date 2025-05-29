using System.Collections.Generic;
using A;

public class RetrieveCurrentCharacterDataAsyncTask : cac110d4f4a99811889eb5dc85c420d82, ISkillTreeServiceNotificationListerner
{
	private bool m_isCharacterServiceWrapperReady;

	private bool m_isInventoryServiceWrapperReady;

	private bool m_isSkillTreeServiceWrapperReady;

	private bool m_isQuestServiceWrapperReady;

	private bool m_isFriendServiceWrapperReady;

	private bool m_isGroupServiceWrapperReady;

	private bool m_isGuildServiceWrapperReady;

	private bool m_isCraftingServiceWrapperReady;

	private bool m_isLobbyServiceWrapperReady;

	private bool m_isMailServiceWrapperReady;

	private bool m_isShopServiceWrapperReady;

	private bool m_isChatServiceWarpperReady;

	private bool m_isWaitingSkillPoint;

	public Character m_character;

	public void c7cc9411392f033dee9802f9b9ca15b21()
	{
		c92c7f03b81b92c00ce0b49a2b9058106 = 60f;
	}

	public override void Start()
	{
		base.Start();
		c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(this);
		CharacterService.GetSelectedCharacterAsyncTask getSelectedCharacterAsyncTask = new CharacterService.GetSelectedCharacterAsyncTask();
		getSelectedCharacterAsyncTask.c7cc9411392f033dee9802f9b9ca15b21();
		c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(getSelectedCharacterAsyncTask, OnGetMyCharacter);
	}

	public override void cdada4c3678c9c23c38aaf0754a94a620()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c704834a4a19f1f8555b44d9c021845ab(this);
		base.cdada4c3678c9c23c38aaf0754a94a620();
	}

	private void OnGetMyCharacter(cac110d4f4a99811889eb5dc85c420d82 task, c2597280f86604f98f89309a4de95dd62 result)
	{
		if (c762acfd9de32c566fab82e7bbfb0e93f())
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
					return;
				}
			}
		}
		if (result != c2597280f86604f98f89309a4de95dd62.Success)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					c27b389b7bd08230f8586d5ac4896cc41(result);
					return;
				}
			}
		}
		m_character = (task as CharacterService.GetSelectedCharacterAsyncTask).m_character;
		PlayerProperties playerProperties = c06ca0e618478c23eba3419653a19760f<PlayerManager>.c5ee19dc8d4cccf5ae2de225410458b86.ccc826da979542be7370386df94069f47();
		if (playerProperties != null)
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
			playerProperties.m_exp = m_character.Experience;
		}
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cd93285db16841148ed53a5bbeb35cf20();
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c26dcadb6c3e9da3320f7f77afe3b6f30(m_character);
		c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cd93285db16841148ed53a5bbeb35cf20();
		c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cd93285db16841148ed53a5bbeb35cf20();
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cd93285db16841148ed53a5bbeb35cf20();
		c1ee7921b0c3cce194fb7cae41b5a9d82<FriendServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cd93285db16841148ed53a5bbeb35cf20();
		c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cd93285db16841148ed53a5bbeb35cf20();
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cd93285db16841148ed53a5bbeb35cf20();
		c1ee7921b0c3cce194fb7cae41b5a9d82<CraftingServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cd93285db16841148ed53a5bbeb35cf20();
		c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cd93285db16841148ed53a5bbeb35cf20();
		c1ee7921b0c3cce194fb7cae41b5a9d82<ShopServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cd93285db16841148ed53a5bbeb35cf20();
		c1ee7921b0c3cce194fb7cae41b5a9d82<MailServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cd93285db16841148ed53a5bbeb35cf20();
		c1ee7921b0c3cce194fb7cae41b5a9d82<ChatServiceWarpper>.c5ee19dc8d4cccf5ae2de225410458b86.cd93285db16841148ed53a5bbeb35cf20();
		c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cfef95a32127bfb3897865c32b38a72a3();
	}

	public override void Update(float time)
	{
		base.Update(time);
		if (m_isWaitingSkillPoint)
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
			if (!m_isCharacterServiceWrapperReady)
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
				if (!m_isInventoryServiceWrapperReady)
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
					if (!m_isSkillTreeServiceWrapperReady)
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
						if (!m_isQuestServiceWrapperReady)
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
							if (!m_isFriendServiceWrapperReady)
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
								if (!m_isGroupServiceWrapperReady)
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
									if (!m_isGuildServiceWrapperReady)
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
										if (!m_isCraftingServiceWrapperReady)
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
											if (!m_isLobbyServiceWrapperReady)
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
												if (!m_isShopServiceWrapperReady)
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
													if (!m_isMailServiceWrapperReady)
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
														if (!m_isChatServiceWarpperReady)
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
															c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cfef95a32127bfb3897865c32b38a72a3();
															m_isWaitingSkillPoint = true;
															return;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}

	public void OnGetPlayerSkillPt(int characterId, int earned, int unspent, List<InvestedSkill> investedSkillPoints)
	{
		if (characterId == OnlineService.s_characterId)
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
					c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Success);
					return;
				}
			}
		}
		c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Error);
	}

	public void OnGetInvestedSkillPt(int characterId, List<InvestedSkill> investedSkillPoints)
	{
	}

	public void OnInvestedSkillPt(int characterId, int skillId, bool wasSuccessful)
	{
	}

	public void OnResetSkillPt(int characterId, bool wasSuccessful)
	{
	}

	public void OnSkillPtEarned(int characterId, int numEarned)
	{
	}
}
