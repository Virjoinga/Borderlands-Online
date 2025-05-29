using A;
using XsdSettings;

public class ScoringManager : c06ca0e618478c23eba3419653a19760f<ScoringManager>, IDamageListener
{
	private ScoringRule m_scoringRule = new DefaultScoringRule();

	public void c8016e12695c9b13b19ba1bba03f30c6f(StatisticsManager.SessionStats c79481ca22d0ff4b145e4fe24cc5d6f6b)
	{
		m_scoringRule.c8016e12695c9b13b19ba1bba03f30c6f(c79481ca22d0ff4b145e4fe24cc5d6f6b);
	}

	public void c287eb409bca23d40ccca6e805052673d()
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c1492faa4c1a9b76581845cee4d47d460() == "GameModePvP")
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
			m_scoringRule = new DeathmatchScoringRule();
		}
		else if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c1492faa4c1a9b76581845cee4d47d460() == "GamemodeTeamDeathmatch")
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
			m_scoringRule = new TeamDeathmatchScoringRule();
		}
		else
		{
			m_scoringRule = new DefaultScoringRule();
		}
		m_scoringRule.ccc9d3a38966dc10fedb531ea17d24611();
	}

	public void c7a3beb0075a9a3a2a5b08cefa4fab024()
	{
		m_scoringRule.OnUpdateMatch();
	}

	public void ceff4c174ebf3c3bce652f8cad735b333()
	{
		m_scoringRule.OnEndMatch();
		m_scoringRule = new DefaultScoringRule();
	}

	public int c1cf78bc79484f63267d4766d6776b199(ScoringActionType c861de212c63da4e42109937e3cac1a44)
	{
		return m_scoringRule.c1cf78bc79484f63267d4766d6776b199(c861de212c63da4e42109937e3cac1a44);
	}

	public int c415f9dee531e543fc447806c04e5e5f9()
	{
		return c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().c415f9dee531e543fc447806c04e5e5f9();
	}

	public int cfcc8770a968e4c3000aad65be068ae99()
	{
		return c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cfcc8770a968e4c3000aad65be068ae99();
	}

	public int c4d2b897929d3a76e632db9a02da4f5ff(int c2bc932848ba0f6a13e959e0af05fcf3c)
	{
		return c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().c4d2b897929d3a76e632db9a02da4f5ff(c2bc932848ba0f6a13e959e0af05fcf3c);
	}

	public int c2016963052207f2f80b6eef4a79c4c1a(PlayerInfoSync ceb41162a7cd2a1d5c4a03830e02b4198)
	{
		return c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().c2016963052207f2f80b6eef4a79c4c1a(ceb41162a7cd2a1d5c4a03830e02b4198);
	}

	public void cb61f0369d09ada426256a3f4b80236fa(int c8a7f3986726d4793d7b3f3bbcc750943)
	{
		m_scoringRule.cb61f0369d09ada426256a3f4b80236fa(c8a7f3986726d4793d7b3f3bbcc750943);
	}

	public void c79b0bc249fb8e76dcf6d1941f8abaee5(Entity cf7ee7f254a35f9c53a393957e2758a0a)
	{
		m_scoringRule.c79b0bc249fb8e76dcf6d1941f8abaee5(cf7ee7f254a35f9c53a393957e2758a0a);
	}

	public void OnDamaged(DamageContext context)
	{
		m_scoringRule.OnDamagedPreStat(context);
		if (context.m_killer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			PlayerInfoSync playerInfoSync = context.m_killer.cd95354b53e674ec7dc9594e66e4d316f();
			if ((bool)playerInfoSync)
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
				StatisticsManager.StatSheet statSheet = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdcb2ff44fc70c31a5ec9c7f0156d8f27(playerInfoSync);
				if (statSheet != null)
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
					statSheet.c50279d3fc48f71879c00951e4c85eac6(context);
				}
			}
		}
		if (context.m_victim != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			PlayerInfoSync playerInfoSync2 = context.m_victim.cd95354b53e674ec7dc9594e66e4d316f();
			if ((bool)playerInfoSync2)
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
				StatisticsManager.StatSheet statSheet2 = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdcb2ff44fc70c31a5ec9c7f0156d8f27(playerInfoSync2);
				if (statSheet2 != null)
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
					statSheet2.ccc077a08d65555c9e21142b9eaddeb30(context);
					statSheet2.c50279d3fc48f71879c00951e4c85eac6(context);
				}
			}
		}
		m_scoringRule.OnDamagedPostStat(context);
	}

	public void OnEntityKill(KillContext context)
	{
		if (m_scoringRule == null)
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
					return;
				}
			}
		}
		m_scoringRule.OnEntityKillPreStat(context);
		StatisticsManager.SessionStats sessionStats = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25();
		if (sessionStats == null)
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
		sessionStats.cf65f5870e4d34f78dbfa13a2392d8c0b();
		if (context.m_killer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			PlayerInfoSync playerInfoSync = context.m_killer.cd95354b53e674ec7dc9594e66e4d316f();
			if ((bool)playerInfoSync)
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
				StatisticsManager.StatSheet statSheet = sessionStats.cdcb2ff44fc70c31a5ec9c7f0156d8f27(playerInfoSync);
				if (statSheet != null)
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
					statSheet.cf0fba2b784eca34c5d9a786db55811af(context);
					if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c0fa185c7b0349f8cb220d2aefb47d990())
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
						StatisticsManager.StatSheet statSheet2 = sessionStats.c4df8d7d860c0beb0ca3ba64510fb0ba9(playerInfoSync.m_teamID);
						if (statSheet2 != null)
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
							statSheet2.cf0fba2b784eca34c5d9a786db55811af(context);
						}
					}
				}
			}
		}
		if (context.m_victim != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (context.m_killer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				PlayerInfoSync playerInfoSync2 = context.m_victim.cd95354b53e674ec7dc9594e66e4d316f();
				if ((bool)playerInfoSync2)
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
					StatisticsManager.StatSheet statSheet3 = sessionStats.cdcb2ff44fc70c31a5ec9c7f0156d8f27(playerInfoSync2);
					if (statSheet3 != null)
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
						statSheet3.c839ccf8ec798aa926765aabf6701d67c(context);
					}
					if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c0fa185c7b0349f8cb220d2aefb47d990())
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
						StatisticsManager.StatSheet statSheet4 = sessionStats.c4df8d7d860c0beb0ca3ba64510fb0ba9(playerInfoSync2.m_teamID);
						if (statSheet4 != null)
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
							statSheet4.c839ccf8ec798aa926765aabf6701d67c(context);
						}
					}
				}
			}
		}
		m_scoringRule.OnEntityKillPostStat(context);
	}

	public void c18579147ba07990b87d69fc90271e7b1(int c35f98ccbfa8c6bf09319c620b21b5dc5, bool c8f7104128fac87985a6a33c1f7312579, int c90e9d4f1ee59a50dc4a2bba06b34cc71)
	{
		StatisticsManager.SessionStats sessionStats = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25();
		if (sessionStats == null)
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
					return;
				}
			}
		}
		StatisticsManager.StatSheet statSheet = sessionStats.cedee94723596d6f128e4fb046fec8bf2(c35f98ccbfa8c6bf09319c620b21b5dc5, c8f7104128fac87985a6a33c1f7312579);
		if (statSheet == null)
		{
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
		statSheet.m_score += c90e9d4f1ee59a50dc4a2bba06b34cc71;
	}

	public bool ce01a42bf0027493da7880d4eae90961c(PlayerInfoSync ceb41162a7cd2a1d5c4a03830e02b4198)
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c2ac3e7adcbabdeb8274d837bbb6a6d5a() < 2)
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
		StatisticsManager.SessionStats sessionStats = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c876ebada48854e6e8e29d50bc5352240();
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c0fa185c7b0349f8cb220d2aefb47d990())
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
				{
					int teamID = ceb41162a7cd2a1d5c4a03830e02b4198.m_teamID;
					int num;
					if (teamID == 1)
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
						num = 2;
					}
					else
					{
						num = 1;
					}
					int c804e1fb3ce017e25e147307416292d7a = num;
					if (sessionStats != null)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
							{
								StatisticsManager.StatSheet statSheet = sessionStats.c4df8d7d860c0beb0ca3ba64510fb0ba9(teamID);
								StatisticsManager.StatSheet statSheet2 = sessionStats.c4df8d7d860c0beb0ca3ba64510fb0ba9(c804e1fb3ce017e25e147307416292d7a);
								if (statSheet.m_killCount == 0)
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
									if (statSheet2.m_killCount == 0)
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
								}
								if (statSheet.m_killCount != statSheet2.m_killCount)
								{
									while (true)
									{
										switch (7)
										{
										case 0:
											break;
										default:
											return statSheet.m_killCount > statSheet2.m_killCount;
										}
									}
								}
								if (statSheet.m_deathcount != statSheet2.m_deathcount)
								{
									while (true)
									{
										switch (3)
										{
										case 0:
											break;
										default:
											return statSheet.m_deathcount < statSheet2.m_deathcount;
										}
									}
								}
								if (statSheet.m_score != statSheet2.m_score)
								{
									while (true)
									{
										switch (5)
										{
										case 0:
											break;
										default:
											return statSheet.m_score > statSheet2.m_score;
										}
									}
								}
								return statSheet.m_lastKillTime > statSheet2.m_lastKillTime;
							}
							}
						}
					}
					return false;
				}
				}
			}
		}
		StatisticsManager.StatSheet statSheet3 = sessionStats.cdcb2ff44fc70c31a5ec9c7f0156d8f27(ceb41162a7cd2a1d5c4a03830e02b4198);
		if (statSheet3 != null)
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
			if (statSheet3.m_killCount != 0)
			{
				int num2 = sessionStats.c2016963052207f2f80b6eef4a79c4c1a(ceb41162a7cd2a1d5c4a03830e02b4198);
				return num2 == 1;
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
		return false;
	}
}
