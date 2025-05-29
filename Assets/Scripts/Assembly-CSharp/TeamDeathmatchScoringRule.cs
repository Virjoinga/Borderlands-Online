using System.Collections.Generic;
using A;
using UnityEngine;
using XsdSettings;

public class TeamDeathmatchScoringRule : DeathmatchScoringRule
{
	public override void ccc9d3a38966dc10fedb531ea17d24611()
	{
		m_scoringSettings = "Settings/ScoringTeamDeathmatch";
		base.ccc9d3a38966dc10fedb531ea17d24611();
		c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().c848291d78ee9357cec9ec917ab8b8969(1);
		c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().c848291d78ee9357cec9ec917ab8b8969(2);
	}

	protected override void c6801c882739c1f352f7cda27583c5876(EntityPlayer c69c9048ba99134b4874005cbefa8a7df, Entity c22049b7d048f5ceaad7bdef828bdb85c, Entity cf7ee7f254a35f9c53a393957e2758a0a, AttackSubType ccefb70d1c6517764559a52080e56d522)
	{
		if (c69c9048ba99134b4874005cbefa8a7df == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		int num = 0;
		if (c22049b7d048f5ceaad7bdef828bdb85c != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (cf7ee7f254a35f9c53a393957e2758a0a != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				PlayerInfoSync playerInfoSync = c69c9048ba99134b4874005cbefa8a7df.cd95354b53e674ec7dc9594e66e4d316f();
				PlayerInfoSync playerInfoSync2 = c22049b7d048f5ceaad7bdef828bdb85c.cd95354b53e674ec7dc9594e66e4d316f();
				PlayerInfoSync playerInfoSync3 = cf7ee7f254a35f9c53a393957e2758a0a.cd95354b53e674ec7dc9594e66e4d316f();
				if (playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (playerInfoSync2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (playerInfoSync3 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							num = (int)((float)(c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(playerInfoSync3.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a(), playerInfoSync3.m_exp) - c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(playerInfoSync2.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a(), playerInfoSync2.m_exp)) / 2f);
							num = Mathf.Max(num, 0);
							EntityPlayer entityPlayer = c22049b7d048f5ceaad7bdef828bdb85c as EntityPlayer;
							EntityPlayer entityPlayer2 = cf7ee7f254a35f9c53a393957e2758a0a as EntityPlayer;
							if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								if (entityPlayer2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
									if (entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3 is HunterManage)
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
										if (MarkManager.c5ee19dc8d4cccf5ae2de225410458b86.m_titleCrl.cbab2dad8aaf1583a05752c4116f9b8c4(entityPlayer2))
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
											ccefb70d1c6517764559a52080e56d522 = EntityPlayer.c1bfdbbec3309b974f6b968fbb351a0ee(ccefb70d1c6517764559a52080e56d522);
										}
									}
								}
							}
							c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPvPInfoView>().c763c3f7eaf4d35f4e79c81e24b3a2dc1(playerInfoSync2.m_name, playerInfoSync3.m_name, ccefb70d1c6517764559a52080e56d522, m_lastKillActions, playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194());
							c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPvPKillStampView>().c688eefebe626d5700c624d4b6429f6ab(playerInfoSync2.m_name, m_lastKillActions);
						}
					}
				}
			}
		}
		int num2 = 0;
		for (int i = 0; i < m_lastKillActions.Count; i++)
		{
			int num3 = c1cf78bc79484f63267d4766d6776b199(m_lastKillActions[i]);
			if (m_lastKillActions[i] == ScoringActionType.BasicKill)
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
				num3 += (int)((float)num3 * ((float)num / 4f));
			}
			num2 += num3;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			c06ca0e618478c23eba3419653a19760f<ScoringManager>.c5ee19dc8d4cccf5ae2de225410458b86.c18579147ba07990b87d69fc90271e7b1(c69c9048ba99134b4874005cbefa8a7df.cd95354b53e674ec7dc9594e66e4d316f().m_teamID, true, num2);
			c06ca0e618478c23eba3419653a19760f<ScoringManager>.c5ee19dc8d4cccf5ae2de225410458b86.c18579147ba07990b87d69fc90271e7b1(c69c9048ba99134b4874005cbefa8a7df.cd95354b53e674ec7dc9594e66e4d316f().m_characterId, false, num2);
			m_lastKillActions.Clear();
			return;
		}
	}

	protected override void cd9c519a74cde5252d0d020120b723490(StatisticsManager.SessionStats c79481ca22d0ff4b145e4fe24cc5d6f6b)
	{
		if (c79481ca22d0ff4b145e4fe24cc5d6f6b == null)
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
					return;
				}
			}
		}
		ScoringSetupPVP scoringSetupPVP = m_scoreSetup.m_ScoringSetup as ScoringSetupPVP;
		if (scoringSetupPVP == null)
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
			StatisticsManager.StatSheet statSheet = c79481ca22d0ff4b145e4fe24cc5d6f6b.c167429e9be097e1e036172092ef72105();
			List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
			c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
			for (int i = 0; i < c9c8de68aa0982db2bbd496692c37e.Count; i++)
			{
				StatisticsManager.StatSheet statSheet2 = c79481ca22d0ff4b145e4fe24cc5d6f6b.cdcb2ff44fc70c31a5ec9c7f0156d8f27(c9c8de68aa0982db2bbd496692c37e[i]);
				int a = c79481ca22d0ff4b145e4fe24cc5d6f6b.c2016963052207f2f80b6eef4a79c4c1a(c9c8de68aa0982db2bbd496692c37e[i]);
				a = Mathf.Max(a, 1);
				int num = scoringSetupPVP.m_honorStandardReward / a * (c9c8de68aa0982db2bbd496692c37e.Count / 8);
				int num2;
				if (statSheet.m_teamId == c9c8de68aa0982db2bbd496692c37e[i].m_teamID)
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
					num2 = scoringSetupPVP.m_honorWinBonus;
				}
				else
				{
					num2 = 0;
				}
				statSheet2.m_honorValue = num + num2;
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

	public override void OnEndMatch()
	{
		base.OnEndMatch();
		StatisticsManager.SessionStats sessionStats = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25();
		if (sessionStats == null)
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
					return;
				}
			}
		}
		StatisticsManager.StatSheet statSheet = sessionStats.c4df8d7d860c0beb0ca3ba64510fb0ba9(1);
		if (statSheet == null)
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
		StatisticsManager.StatSheet statSheet2 = sessionStats.c4df8d7d860c0beb0ca3ba64510fb0ba9(2);
		if (statSheet2 == null)
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
		if (statSheet.m_score == statSheet2.m_score)
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
		int c90e9d4f1ee59a50dc4a2bba06b34cc = c1cf78bc79484f63267d4766d6776b199(ScoringActionType.BonusTeamWin);
		int num = 1;
		if (statSheet2.m_score > statSheet.m_score)
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
			num = 2;
		}
		c06ca0e618478c23eba3419653a19760f<ScoringManager>.c5ee19dc8d4cccf5ae2de225410458b86.c18579147ba07990b87d69fc90271e7b1(num, true, c90e9d4f1ee59a50dc4a2bba06b34cc);
		List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
		if (c9c8de68aa0982db2bbd496692c37e == null)
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
			using (List<PlayerInfoSync>.Enumerator enumerator = c9c8de68aa0982db2bbd496692c37e.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PlayerInfoSync current = enumerator.Current;
					Entity entity = current.c66b232dbebded7c7e9a89c1e8bd84689();
					if (!(entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					StatisticsManager.StatSheet statSheet3 = sessionStats.cdcb2ff44fc70c31a5ec9c7f0156d8f27(current);
					if (statSheet3 == null)
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
					if (statSheet3.m_killCount == 0)
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
						if (statSheet3.m_teamId == num)
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
							m_inGameActions.Add(ScoringActionType.BonusBloodlessVictory);
						}
					}
					cb00315f714de219141d9c78f5ebabdd1(entity as EntityPlayer, m_inGameActions);
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
}
