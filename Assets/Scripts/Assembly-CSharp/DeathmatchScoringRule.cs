using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class DeathmatchScoringRule : GeneralScoringRule
{
	protected const float dominationBonusDelay = 3f;

	protected const float multiKillingBonusDelay = 5f;

	protected List<ScoringActionType> m_lastKillActions = new List<ScoringActionType>();

	protected List<ScoringActionType> m_lastVictimActions = new List<ScoringActionType>();

	protected List<ScoringActionType> m_inGameActions = new List<ScoringActionType>();

	protected HashSet<int> m_multiKillWinner = new HashSet<int>();

	protected bool m_lastKillUnderDominationDelay;

	protected bool m_lastKillmultiKillingDelay;

	public override void ccc9d3a38966dc10fedb531ea17d24611()
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c0fa185c7b0349f8cb220d2aefb47d990())
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
			m_scoringSettings = "Settings/ScoringDeathmatch";
		}
		base.ccc9d3a38966dc10fedb531ea17d24611();
	}

	public override void OnDamagedPreStat(DamageContext context)
	{
	}

	public override void OnDamagedPostStat(DamageContext context)
	{
	}

	public override void OnEntityKillPreStat(KillContext context)
	{
		m_lastKillUnderDominationDelay = false;
		ScoringActionType scoringActionType = cbec04450b5919289f22f49257ebe1392(context);
		if (scoringActionType == ScoringActionType.BasicSuicide)
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
					m_lastKillActions.Add(scoringActionType);
					return;
				}
			}
		}
		c522a61ebf201acbc87a8ca32f98bd499(context);
		m_lastKillActions.Clear();
		m_lastKillActions.Add(scoringActionType);
		if (!(context.m_killer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(context.m_victim != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				PlayerInfoSync playerInfoSync = context.m_killer.cd95354b53e674ec7dc9594e66e4d316f();
				if (!playerInfoSync)
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
					StatisticsManager.StatSheet statSheet = sessionStats.cdcb2ff44fc70c31a5ec9c7f0156d8f27(playerInfoSync);
					if (statSheet == null)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, "DeathmatchScoringRule:CheckAssist - missing stats for player[" + statSheet.m_name + "]");
								return;
							}
						}
					}
					if (Time.time - statSheet.m_lastKillTime <= 3f)
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
						m_lastKillUnderDominationDelay = true;
					}
					PlayerInfoSync playerInfoSync2 = context.m_victim.cd95354b53e674ec7dc9594e66e4d316f();
					if (!playerInfoSync2)
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
						StatisticsManager.StatSheet statSheet2 = sessionStats.cdcb2ff44fc70c31a5ec9c7f0156d8f27(playerInfoSync2);
						if (statSheet2 == null)
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
							if (statSheet2.m_lastKillerForRevenge == context.m_killer.cc7403315505256d19a7b92aa614a8f10())
							{
								while (true)
								{
									switch (6)
									{
									case 0:
										break;
									default:
										if (++statSheet2.m_sameVictimCount == 3)
										{
											while (true)
											{
												switch (5)
												{
												case 0:
													break;
												default:
													m_lastKillActions.Add(ScoringActionType.BonusArchNemesis);
													statSheet2.m_sameVictimCount = 0;
													return;
												}
											}
										}
										return;
									}
								}
							}
							statSheet2.m_sameVictimCount = 1;
							return;
						}
					}
				}
			}
		}
	}

	public override void OnEntityKillPostStat(KillContext context)
	{
		StatisticsManager.SessionStats sessionStats = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25();
		PlayerInfoSync playerInfoSync = c7cfa05fd8fe0a2d1791d3ae1202ecb42.c7088de59e49f7108f520cf7e0bae167e;
		StatisticsManager.StatSheet statSheet = null;
		StatisticsManager.StatSheet.KillType c1f2da5d5df942706db1acaf5e = StatisticsManager.StatSheet.KillType.Normal;
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			playerInfoSync = context.m_killer.cd95354b53e674ec7dc9594e66e4d316f();
		}
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
			statSheet = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdcb2ff44fc70c31a5ec9c7f0156d8f27(playerInfoSync);
		}
		if (sessionStats.m_killCount == 1)
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
			m_lastKillActions.Add(ScoringActionType.BonusFirstBlood);
		}
		if (context.m_partInfo == WeakPoint.PartInfo.Head)
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
			m_lastKillActions.Add(ScoringActionType.BonusHeadShot);
			c1f2da5d5df942706db1acaf5e = StatisticsManager.StatSheet.KillType.HeadShot;
			statSheet.m_headshotKillCount++;
		}
		else if (context.m_strengthType == WeakPoint.StrengthType.VeryWeak)
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
			m_lastKillActions.Add(ScoringActionType.BonusCritical);
			c1f2da5d5df942706db1acaf5e = StatisticsManager.StatSheet.KillType.Critical;
		}
		if (AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(context.m_subType) == AttackInfo.AttackType.Melee)
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
			m_lastKillActions.Add(ScoringActionType.BonusMelee);
			statSheet.m_meleeKillCount++;
		}
		if (context.m_subType == AttackSubType.AreaGrenade)
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
			statSheet.m_grenadeKillCount++;
		}
		if (AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(context.m_subType) == AttackInfo.AttackType.Projectile)
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
			if (playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				Entity entity = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689();
				if (entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = entity.c5ca38fad98337fc5c7255384b2cd1a86() as EquipmentInventoryEntityPlayer;
					if (equipmentInventoryEntityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						EntityWeapon entityWeapon = equipmentInventoryEntityPlayer.cdda217ef6662acf86a5584ba19758192();
						if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							statSheet.c47cc5329fc69109ff70ca356b2f22bb6(entityWeapon.c83e548e5608cd7f222098a6966b16545(), c1f2da5d5df942706db1acaf5e);
						}
					}
				}
			}
		}
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
			if (context.m_victim != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (statSheet != null)
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
					if (statSheet.m_killStreak > 1)
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
						if (m_lastKillUnderDominationDelay)
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
							m_lastKillActions.Add(ScoringActionType.BonusDominating);
						}
						else if (statSheet.m_killStreak == 2)
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
							m_lastKillActions.Add(ScoringActionType.BonusKillStreak);
						}
						else if (statSheet.m_killStreak == 3)
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
							m_lastKillActions.Add(ScoringActionType.BonusNaturalbornKiller);
						}
						else if (statSheet.m_killStreak == 5)
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
							m_lastKillActions.Add(ScoringActionType.BonusOneManArmy);
						}
					}
					int item = context.m_killer.cc7403315505256d19a7b92aa614a8f10();
					if (m_multiKillWinner.Contains(item))
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
						m_lastKillActions.Add(ScoringActionType.BonusOneShotTwoKills);
						m_multiKillWinner.Remove(item);
					}
					if (statSheet.c4bf4414fb603fdda6c5240ff6e49d374(3) < 5f)
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
						m_lastKillActions.Add(ScoringActionType.BonusGenocide);
						statSheet.c94a3dded3cebe251338ae0047e5e7c0f();
					}
					else if (statSheet.c4bf4414fb603fdda6c5240ff6e49d374(2) < 5f)
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
						m_lastKillActions.Add(ScoringActionType.BonusTripleKilling);
					}
					else if (statSheet.c4bf4414fb603fdda6c5240ff6e49d374(1) < 5f)
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
						m_lastKillActions.Add(ScoringActionType.BonusOneStoneTwoBird);
					}
				}
			}
		}
		if (context.m_killer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (context.m_victim != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (statSheet.m_lastKillerForRevenge == context.m_victim.cc7403315505256d19a7b92aa614a8f10())
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
						if (context.m_victim.cc7403315505256d19a7b92aa614a8f10() != context.m_killer.cc7403315505256d19a7b92aa614a8f10())
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
							m_lastKillActions.Add(ScoringActionType.BonusRevenge);
							statSheet.m_lastKillerForRevenge = 0;
							statSheet.m_nemesisCount++;
						}
					}
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().m_endScore > 0)
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
			if (c06ca0e618478c23eba3419653a19760f<ScoringManager>.c5ee19dc8d4cccf5ae2de225410458b86.c415f9dee531e543fc447806c04e5e5f9() >= c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().m_endScore)
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
					m_lastKillActions.Add(ScoringActionType.BonusLastKill);
				}
			}
		}
		if (context.m_killer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (context.m_victim != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (context.m_subType == AttackSubType.SkillTurretProjectile)
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
					m_lastKillActions.Add(ScoringActionType.BonusTurretKill);
				}
				else if (context.m_subType == AttackSubType.AreaFirebird)
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
					m_lastKillActions.Add(ScoringActionType.BonusFirebirdKill);
				}
				else if (context.m_subType == AttackSubType.MeleeSkillBerserkPunch)
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
					m_lastKillActions.Add(ScoringActionType.BonusPunchKill);
				}
				else if (context.m_subType == AttackSubType.AreaGrenade)
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
					m_lastKillActions.Add(ScoringActionType.BonusGrenadesKill);
				}
				EntityPlayer entityPlayer = context.m_killer as EntityPlayer;
				if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3 is HunterManage)
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
						if (MarkManager.c5ee19dc8d4cccf5ae2de225410458b86.m_titleCrl.cbab2dad8aaf1583a05752c4116f9b8c4(context.m_victim))
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
							m_lastKillActions.Add(ScoringActionType.BonusMarkedKill);
						}
					}
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
					if (playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						StatisticsManager.StatSheet statSheet2 = sessionStats.c4df8d7d860c0beb0ca3ba64510fb0ba9(playerInfoSync.m_teamID);
						if (statSheet2 != null)
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
							if (statSheet2.m_killCount == 1)
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
								m_lastKillActions.Add(ScoringActionType.BonusFirstBullet);
							}
						}
					}
				}
				c8135095acd6994859e22de85ccda4fba(statSheet.m_nemesisCount, ScoringActionType.BonusPayback, ScoringActionType.BonusAvenger);
				c8135095acd6994859e22de85ccda4fba(statSheet.m_meleeKillCount, ScoringActionType.BonusBucher, ScoringActionType.BonusBushido);
				c8135095acd6994859e22de85ccda4fba(statSheet.m_grenadeKillCount, ScoringActionType.BonusShotPutter, ScoringActionType.BonusCatapult);
				c8135095acd6994859e22de85ccda4fba(statSheet.m_headshotKillCount, ScoringActionType.BonusSharpShooter, ScoringActionType.BonusHeadHunter);
				if (context.m_victim.cc7403315505256d19a7b92aa614a8f10() == statSheet.m_lastDamager)
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
					if (Time.time - statSheet.m_lastDamageTime < 3f)
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
						m_lastKillActions.Add(ScoringActionType.BonusGiveAndTake);
					}
				}
				PlayerController component = context.m_victim.GetComponent<PlayerController>();
				if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (component.cc398985de9cbef8f2199a7f1eebc37dd())
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
						m_lastKillActions.Add(ScoringActionType.BonusShameless);
					}
				}
				PlayerInfoSync playerInfoSync2 = context.m_victim.cd95354b53e674ec7dc9594e66e4d316f();
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
					StatisticsManager.StatSheet statSheet3 = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdcb2ff44fc70c31a5ec9c7f0156d8f27(playerInfoSync2);
					if (statSheet3 != null)
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
						if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c94ce42c8036c46b4b3e8327e21fffce0() > (double)((float)sessionStats.m_timeLimit * 0.5f))
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
							if (sessionStats.c415f9dee531e543fc447806c04e5e5f9() == statSheet3.m_score)
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
								m_lastKillActions.Add(ScoringActionType.BonusAssassin);
							}
						}
						if (statSheet3.m_killCount > 0)
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
							if (Time.time - statSheet3.m_lastKillTime < 3f)
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
								m_lastVictimActions.Add(ScoringActionType.BonusLoveShot);
							}
						}
					}
				}
				if (Vector3.Distance(context.m_victim.transform.position, context.m_killer.transform.position) > 30f)
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
					m_lastKillActions.Add(ScoringActionType.BonusEagleEye);
				}
				Vector3 lhs = context.m_victim.transform.TransformDirection(Vector3.forward);
				Vector3 rhs = context.m_killer.transform.position - context.m_victim.transform.position;
				if (Vector3.Dot(lhs, rhs) < 0f)
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
					m_lastKillActions.Add(ScoringActionType.BonusBackStabbing);
				}
				PlayerThirdPersonAnimationManagerFSM component2 = context.m_victim.GetComponent<PlayerThirdPersonAnimationManagerFSM>();
				if (component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (component2.ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerReload))
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
						m_lastKillActions.Add(ScoringActionType.BonusShameless);
					}
					if (component2.ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerMove))
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
						AnimationPlayerMoveState animationPlayerMoveState = component2.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerMove)) as AnimationPlayerMoveState;
						if (animationPlayerMoveState.c1c067e605f60d78f4fd6324f61461644 >= 0.6f)
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
							m_lastKillActions.Add(ScoringActionType.BonusRoadtoHell);
						}
					}
				}
			}
		}
		c6801c882739c1f352f7cda27583c5876(context.m_killer as EntityPlayer, context.m_killer, context.m_victim, context.m_subType);
		cb00315f714de219141d9c78f5ebabdd1(context.m_victim as EntityPlayer, m_lastVictimActions);
	}

	private void c8135095acd6994859e22de85ccda4fba(int c58bda81e8182122e809f8c789f59a6e4, ScoringActionType c08b8d3131f22797e94b8db14a8c0a212, ScoringActionType cce286b35cfa77dfd3e7187dc395ff7d6)
	{
		if (c58bda81e8182122e809f8c789f59a6e4 == 5)
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
					m_lastKillActions.Add(c08b8d3131f22797e94b8db14a8c0a212);
					return;
				}
			}
		}
		if (c58bda81e8182122e809f8c789f59a6e4 != 10)
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
			m_lastKillActions.Add(cce286b35cfa77dfd3e7187dc395ff7d6);
			return;
		}
	}

	private void c522a61ebf201acbc87a8ca32f98bd499(KillContext c2970555c0fc69d9442a248a8e3fc971c)
	{
		ScoringActionType scoringActionType = cbec04450b5919289f22f49257ebe1392(c2970555c0fc69d9442a248a8e3fc971c);
		if (scoringActionType == ScoringActionType.BasicSuicide)
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
			m_inGameActions.Clear();
			if (c2970555c0fc69d9442a248a8e3fc971c.m_victim == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c2970555c0fc69d9442a248a8e3fc971c.m_killer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			PlayerInfoSync playerInfoSync = c2970555c0fc69d9442a248a8e3fc971c.m_victim.cd95354b53e674ec7dc9594e66e4d316f();
			if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
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
			StatisticsManager.StatSheet statSheet = sessionStats.cdcb2ff44fc70c31a5ec9c7f0156d8f27(playerInfoSync);
			if (statSheet == null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, "DeathmatchScoringRule:CheckAssist - missing stats for player[" + playerInfoSync.m_name + "]");
						return;
					}
				}
			}
			Entity entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(statSheet.m_lastDamager);
			if (entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c2970555c0fc69d9442a248a8e3fc971c.m_killer.ceb10167333758220ffb9bc66317ad763() == entity.ceb10167333758220ffb9bc66317ad763())
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
				if (c2970555c0fc69d9442a248a8e3fc971c.m_killer.cc7403315505256d19a7b92aa614a8f10() != statSheet.m_lastDamager)
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
					m_inGameActions.Add(ScoringActionType.BasicAssist);
				}
			}
			if (m_inGameActions.Count == 0)
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
			cb00315f714de219141d9c78f5ebabdd1(entity as EntityPlayer, m_inGameActions);
			return;
		}
	}

	protected virtual void c6801c882739c1f352f7cda27583c5876(EntityPlayer c69c9048ba99134b4874005cbefa8a7df, Entity c22049b7d048f5ceaad7bdef828bdb85c, Entity cf7ee7f254a35f9c53a393957e2758a0a, AttackSubType ccefb70d1c6517764559a52080e56d522)
	{
		if (c69c9048ba99134b4874005cbefa8a7df == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		PlayerInfoSync playerInfoSync = c69c9048ba99134b4874005cbefa8a7df.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		int num = 0;
		if (c22049b7d048f5ceaad7bdef828bdb85c != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (cf7ee7f254a35f9c53a393957e2758a0a != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								switch (4)
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
									switch (1)
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
										switch (2)
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
											switch (4)
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
					switch (5)
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
			switch (4)
			{
			case 0:
				continue;
			}
			c06ca0e618478c23eba3419653a19760f<ScoringManager>.c5ee19dc8d4cccf5ae2de225410458b86.c18579147ba07990b87d69fc90271e7b1(c69c9048ba99134b4874005cbefa8a7df.cd95354b53e674ec7dc9594e66e4d316f().m_characterId, false, num2);
			m_lastKillActions.Clear();
			return;
		}
	}

	protected virtual void cb00315f714de219141d9c78f5ebabdd1(EntityPlayer c69c9048ba99134b4874005cbefa8a7df, List<ScoringActionType> ca1448015b46b0b3de8a1d594ed11cf48)
	{
		if (ca1448015b46b0b3de8a1d594ed11cf48.Count == 0)
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
		if (c69c9048ba99134b4874005cbefa8a7df == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		PlayerInfoSync playerInfoSync = c69c9048ba99134b4874005cbefa8a7df.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPvPKillStampView>().c688eefebe626d5700c624d4b6429f6ab(playerInfoSync.m_name, ca1448015b46b0b3de8a1d594ed11cf48);
		int num = 0;
		for (int i = 0; i < ca1448015b46b0b3de8a1d594ed11cf48.Count; i++)
		{
			int num2 = c1cf78bc79484f63267d4766d6776b199(ca1448015b46b0b3de8a1d594ed11cf48[i]);
			num += num2;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			c06ca0e618478c23eba3419653a19760f<ScoringManager>.c5ee19dc8d4cccf5ae2de225410458b86.c18579147ba07990b87d69fc90271e7b1(c69c9048ba99134b4874005cbefa8a7df.cd95354b53e674ec7dc9594e66e4d316f().m_characterId, false, num);
			ca1448015b46b0b3de8a1d594ed11cf48.Clear();
			return;
		}
	}

	public ScoringActionType cbec04450b5919289f22f49257ebe1392(KillContext c2970555c0fc69d9442a248a8e3fc971c)
	{
		if (c2970555c0fc69d9442a248a8e3fc971c.m_victim != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c2970555c0fc69d9442a248a8e3fc971c.m_killer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (c2970555c0fc69d9442a248a8e3fc971c.m_victim.cc7403315505256d19a7b92aa614a8f10() == c2970555c0fc69d9442a248a8e3fc971c.m_killer.cc7403315505256d19a7b92aa614a8f10())
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							return ScoringActionType.BasicSuicide;
						}
					}
				}
			}
		}
		return ScoringActionType.BasicKill;
	}

	public override void cb61f0369d09ada426256a3f4b80236fa(int c8a7f3986726d4793d7b3f3bbcc750943)
	{
		m_multiKillWinner.Add(c8a7f3986726d4793d7b3f3bbcc750943);
	}

	public override void c79b0bc249fb8e76dcf6d1941f8abaee5(Entity cf7ee7f254a35f9c53a393957e2758a0a)
	{
		EquipmentInventoryEntity equipmentInventoryEntity = cf7ee7f254a35f9c53a393957e2758a0a.c5ca38fad98337fc5c7255384b2cd1a86();
		if (!(equipmentInventoryEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (equipmentInventoryEntity.ce7804365a7377021025c46a16aa79db4() != equipmentInventoryEntity.ca937003ba4cbf4130cad1fcc9da2873e())
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
				if (!((float)equipmentInventoryEntity.ca2ff7a501878363cb1d5f0472e306620() < (float)equipmentInventoryEntity.ccfad1bf47b003333c5ddd084f14d33e7() * 0.1f))
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
					m_inGameActions.Add(ScoringActionType.BonusResuscitation);
					cb00315f714de219141d9c78f5ebabdd1(cf7ee7f254a35f9c53a393957e2758a0a as EntityPlayer, m_lastVictimActions);
					return;
				}
			}
		}
	}

	public override int c1cf78bc79484f63267d4766d6776b199(ScoringActionType c861de212c63da4e42109937e3cac1a44)
	{
		ScoringSetupPVP scoringSetupPVP = m_scoreSetup.m_ScoringSetup as ScoringSetupPVP;
		if (scoringSetupPVP != null)
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
			for (int i = 0; i < scoringSetupPVP.m_scoringActions.Length; i++)
			{
				if (scoringSetupPVP.m_scoringActions[i].m_scoringActionType != c861de212c63da4e42109937e3cac1a44)
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
					return scoringSetupPVP.m_scoringActions[i].m_value;
				}
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
		return 0;
	}

	public override void OnUpdateMatch()
	{
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
		if (c9c8de68aa0982db2bbd496692c37e == null)
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
			using (List<PlayerInfoSync>.Enumerator enumerator = c9c8de68aa0982db2bbd496692c37e.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PlayerInfoSync current = enumerator.Current;
					EntityPlayer entityPlayer = current.c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
					if (!(entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					StatisticsManager.StatSheet statSheet = sessionStats.cdcb2ff44fc70c31a5ec9c7f0156d8f27(current);
					if (statSheet != null)
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
						statSheet.m_livingInterval += Time.deltaTime;
						if (statSheet.m_livingInterval > 300f)
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
							m_inGameActions.Add(ScoringActionType.BonusLongevity);
							statSheet.m_livingInterval = 0f;
						}
						BadAssCharacterMotorLite component = entityPlayer.GetComponent<BadAssCharacterMotorLite>();
						if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							if (component.jumping.jumping)
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
								statSheet.m_flyingInterval += Time.deltaTime;
								if (statSheet.m_flyingInterval > 3f)
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
									m_inGameActions.Add(ScoringActionType.BonusAirBourne);
									statSheet.m_flyingInterval = 0f;
								}
							}
							else
							{
								statSheet.m_flyingInterval = 0f;
							}
						}
						statSheet.m_lastPos = entityPlayer.transform.position;
					}
					cb00315f714de219141d9c78f5ebabdd1(entityPlayer, m_inGameActions);
				}
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
		}
	}

	public override void OnEndMatch()
	{
		StatisticsManager.SessionStats sessionStats = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25();
		if (sessionStats == null)
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
		List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
		if (c9c8de68aa0982db2bbd496692c37e == null)
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
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					StatisticsManager.StatSheet statSheet = sessionStats.cdcb2ff44fc70c31a5ec9c7f0156d8f27(current);
					if (statSheet == null)
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
					if (statSheet.m_killCount == 0)
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
						if (statSheet.m_deathcount == 0)
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
							m_inGameActions.Add(ScoringActionType.BonusAFK);
						}
					}
					cb00315f714de219141d9c78f5ebabdd1(entity as EntityPlayer, m_inGameActions);
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
	}

	protected override float c0dd068b2130e237656c77f780031a1fd(StatisticsManager.SessionStats c79481ca22d0ff4b145e4fe24cc5d6f6b, StatisticsManager.StatSheet c1226047aa159ca56aa73e4e8edceb917, bool cb4610728586d2d9e4e7cf12764a1f555)
	{
		ScoringSetupPVP scoringSetupPVP = m_scoreSetup.m_ScoringSetup as ScoringSetupPVP;
		if (scoringSetupPVP != null)
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
					int num = c79481ca22d0ff4b145e4fe24cc5d6f6b.c415f9dee531e543fc447806c04e5e5f9();
					for (int i = 0; i < scoringSetupPVP.m_performanceRankBonus.Length - 1; i++)
					{
						if ((float)c1226047aa159ca56aa73e4e8edceb917.m_score >= scoringSetupPVP.m_performanceRankBonus[i].m_condition * (float)num)
						{
							while (true)
							{
								switch (7)
								{
								case 0:
									break;
								default:
								{
									float result;
									if (cb4610728586d2d9e4e7cf12764a1f555)
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
										result = scoringSetupPVP.m_performanceRankBonus[i].m_softCurrencyBonus;
									}
									else
									{
										result = scoringSetupPVP.m_performanceRankBonus[i].m_EXPBonus;
									}
									return result;
								}
								}
							}
						}
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
						{
							int num2 = scoringSetupPVP.m_performanceRankBonus.Length - 1;
							float result2;
							if (cb4610728586d2d9e4e7cf12764a1f555)
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
								result2 = scoringSetupPVP.m_performanceRankBonus[num2].m_softCurrencyBonus;
							}
							else
							{
								result2 = scoringSetupPVP.m_performanceRankBonus[num2].m_EXPBonus;
							}
							return result2;
						}
						}
					}
				}
				}
			}
		}
		return 1f;
	}

	protected virtual void cd9c519a74cde5252d0d020120b723490(StatisticsManager.SessionStats c79481ca22d0ff4b145e4fe24cc5d6f6b)
	{
		if (c79481ca22d0ff4b145e4fe24cc5d6f6b == null)
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
		ScoringSetupPVP scoringSetupPVP = m_scoreSetup.m_ScoringSetup as ScoringSetupPVP;
		if (scoringSetupPVP == null)
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
			List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
			c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
			for (int i = 0; i < c9c8de68aa0982db2bbd496692c37e.Count; i++)
			{
				StatisticsManager.StatSheet statSheet = c79481ca22d0ff4b145e4fe24cc5d6f6b.cdcb2ff44fc70c31a5ec9c7f0156d8f27(c9c8de68aa0982db2bbd496692c37e[i]);
				int a = c79481ca22d0ff4b145e4fe24cc5d6f6b.c2016963052207f2f80b6eef4a79c4c1a(c9c8de68aa0982db2bbd496692c37e[i]);
				a = Mathf.Max(a, 1);
				statSheet.m_honorValue = scoringSetupPVP.m_honorStandardReward / a * (c9c8de68aa0982db2bbd496692c37e.Count / 8) + scoringSetupPVP.m_honorWinBonus / a;
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

	protected void ce690563ece2c0a8075187ac6219dbc1c(StatisticsManager.SessionStats c79481ca22d0ff4b145e4fe24cc5d6f6b)
	{
		if (c79481ca22d0ff4b145e4fe24cc5d6f6b == null)
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
		ScoringSetupPVP scoringSetupPVP = m_scoreSetup.m_ScoringSetup as ScoringSetupPVP;
		if (scoringSetupPVP == null)
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
			List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
			c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
			for (int i = 0; i < c9c8de68aa0982db2bbd496692c37e.Count; i++)
			{
				StatisticsManager.StatSheet statSheet = c79481ca22d0ff4b145e4fe24cc5d6f6b.cdcb2ff44fc70c31a5ec9c7f0156d8f27(c9c8de68aa0982db2bbd496692c37e[i]);
				int cf13fd632f93aa296c99679582ff35a = (int)(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_duration * scoringSetupPVP.m_expStandardReward * cc9105d91b160c7c4fec0ad4753e96fe0(statSheet.m_level, false) * scoringSetupPVP.m_modeModifierEXP * scoringSetupPVP.m_winBonusEXP * c0dd068b2130e237656c77f780031a1fd(c79481ca22d0ff4b145e4fe24cc5d6f6b, statSheet, false));
				statSheet.cdb2127413cce26bb79a7ae953459f365(cf13fd632f93aa296c99679582ff35a);
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

	protected float cb1807b036d0b26bfcba4379c4169983d(PlayerInfoSync cb81a1815f0c8bdc240cd7d107c2aab17)
	{
		EntityPlayer entityPlayer = cb81a1815f0c8bdc240cd7d107c2aab17.c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
		if ((bool)entityPlayer)
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
					return entityPlayer.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.XPBonus);
				}
			}
		}
		return 1f;
	}

	protected void cf2c4d0e30728d4d71f26e565ad651c4b(StatisticsManager.SessionStats c79481ca22d0ff4b145e4fe24cc5d6f6b)
	{
		if (c79481ca22d0ff4b145e4fe24cc5d6f6b == null)
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
		PvPGuildExpFactorDataList pvPGuildExpFactorDataList = c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>.c5ee19dc8d4cccf5ae2de225410458b86.c77fe1ac83d798509afba70d186e176bb();
		List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
		for (int i = 0; i < c9c8de68aa0982db2bbd496692c37e.Count; i++)
		{
			StatisticsManager.StatSheet statSheet = c79481ca22d0ff4b145e4fe24cc5d6f6b.cdcb2ff44fc70c31a5ec9c7f0156d8f27(c9c8de68aa0982db2bbd496692c37e[i]);
			int num = 0;
			if (c06ca0e618478c23eba3419653a19760f<ScoringManager>.c5ee19dc8d4cccf5ae2de225410458b86.ce01a42bf0027493da7880d4eae90961c(c9c8de68aa0982db2bbd496692c37e[i]))
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
				num = pvPGuildExpFactorDataList.m_expWinFactor.m_basicExpValue;
				int num2 = c79481ca22d0ff4b145e4fe24cc5d6f6b.c2016963052207f2f80b6eef4a79c4c1a(c9c8de68aa0982db2bbd496692c37e[i]);
				if (num2 > 0)
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
					if (num2 <= pvPGuildExpFactorDataList.m_expWinFactor.m_rankFactors.Length)
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
						if (c9c8de68aa0982db2bbd496692c37e.Count > pvPGuildExpFactorDataList.m_expWinFactor.m_rankFactors[num2 - 1].m_minPlayer)
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
							num += pvPGuildExpFactorDataList.m_expWinFactor.m_rankFactors[num2 - 1].m_expValue;
						}
					}
				}
			}
			else
			{
				num = pvPGuildExpFactorDataList.m_expLoseFactor.m_basicExpValue;
			}
			statSheet.m_guildExp += num;
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

	public override void c8016e12695c9b13b19ba1bba03f30c6f(StatisticsManager.SessionStats c79481ca22d0ff4b145e4fe24cc5d6f6b)
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
		c2b758e371d939e85369ea9f744b16819(c79481ca22d0ff4b145e4fe24cc5d6f6b);
		cd9c519a74cde5252d0d020120b723490(c79481ca22d0ff4b145e4fe24cc5d6f6b);
		ce690563ece2c0a8075187ac6219dbc1c(c79481ca22d0ff4b145e4fe24cc5d6f6b);
		cf2c4d0e30728d4d71f26e565ad651c4b(c79481ca22d0ff4b145e4fe24cc5d6f6b);
	}
}
