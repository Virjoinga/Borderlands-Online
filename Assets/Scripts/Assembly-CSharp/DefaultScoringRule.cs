using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class DefaultScoringRule : GeneralScoringRule
{
	[CompilerGenerated]
	private static Comparison<StatisticsManager.StatSheet> _003C_003Ef__am_0024cache0;

	[CompilerGenerated]
	private static Comparison<StatisticsManager.StatSheet> _003C_003Ef__am_0024cache1;

	public override void ccc9d3a38966dc10fedb531ea17d24611()
	{
		m_scoringSettings = "Settings/ScoringPVE";
		base.ccc9d3a38966dc10fedb531ea17d24611();
	}

	private void ce690563ece2c0a8075187ac6219dbc1c(StatisticsManager.SessionStats c79481ca22d0ff4b145e4fe24cc5d6f6b)
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
		List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
		for (int i = 0; i < c9c8de68aa0982db2bbd496692c37e.Count; i++)
		{
			StatisticsManager.StatSheet statSheet = c79481ca22d0ff4b145e4fe24cc5d6f6b.cdcb2ff44fc70c31a5ec9c7f0156d8f27(c9c8de68aa0982db2bbd496692c37e[i]);
			Playlist playlist = MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c2718b579e09549a1cd47620188a40a38(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_playlistId);
			int num = 1;
			float num2 = 1f;
			switch (c79481ca22d0ff4b145e4fe24cc5d6f6b.m_difficulty)
			{
			case ELevelDifficulty.Normal:
				num = playlist.m_normal_Exp;
				num2 = c245d29329153f2f7015b939afea8d16e(playlist.m_normal_LevelMin, statSheet.m_level);
				break;
			case ELevelDifficulty.Hard:
				num = playlist.m_hard_Exp;
				num2 = c245d29329153f2f7015b939afea8d16e(playlist.m_hard_LevelMin, statSheet.m_level);
				break;
			case ELevelDifficulty.Hell:
				num = playlist.m_hell_Exp;
				num2 = c245d29329153f2f7015b939afea8d16e(playlist.m_hell_LevelMin, statSheet.m_level);
				break;
			}
			int cf13fd632f93aa296c99679582ff35a = (int)((float)num * num2 * c0dd068b2130e237656c77f780031a1fd(c79481ca22d0ff4b145e4fe24cc5d6f6b, statSheet, false));
			statSheet.cdb2127413cce26bb79a7ae953459f365(cf13fd632f93aa296c99679582ff35a);
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

	private void cf2c4d0e30728d4d71f26e565ad651c4b(StatisticsManager.SessionStats c79481ca22d0ff4b145e4fe24cc5d6f6b)
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
		PvEGuildExpFactorDataList pvEGuildExpFactorDataList = c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>.c5ee19dc8d4cccf5ae2de225410458b86.cd55fb11a9eb5c38a725c0ab6000bf385();
		List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
		for (int i = 0; i < c9c8de68aa0982db2bbd496692c37e.Count; i++)
		{
			StatisticsManager.StatSheet statSheet = c79481ca22d0ff4b145e4fe24cc5d6f6b.cdcb2ff44fc70c31a5ec9c7f0156d8f27(c9c8de68aa0982db2bbd496692c37e[i]);
			int num = 0;
			int num2 = 0;
			while (true)
			{
				if (num2 < pvEGuildExpFactorDataList.m_playtimeFactors.Length)
				{
					if (c79481ca22d0ff4b145e4fe24cc5d6f6b.m_duration > (float)(pvEGuildExpFactorDataList.m_playtimeFactors[num2].m_minTime * 60))
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
						if (c79481ca22d0ff4b145e4fe24cc5d6f6b.m_duration <= (float)(pvEGuildExpFactorDataList.m_playtimeFactors[num2].m_maxTime * 60))
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
							num = pvEGuildExpFactorDataList.m_playtimeFactors[num2].m_expValue;
							break;
						}
					}
					num2++;
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
			int num3 = 0;
			int ca329c5118ba5116b53cec9efd5542cff = (int)statSheet.ca329c5118ba5116b53cec9efd5542cff;
			if (ca329c5118ba5116b53cec9efd5542cff < pvEGuildExpFactorDataList.m_scoreFactors.Length)
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
				num3 = pvEGuildExpFactorDataList.m_scoreFactors[ca329c5118ba5116b53cec9efd5542cff].m_expValue;
			}
			int num4 = 0;
			int difficulty = (int)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_difficulty;
			if (difficulty - 1 >= 0)
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
				if (difficulty - 1 < pvEGuildExpFactorDataList.m_difficultyFactors.Length)
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
					num4 = pvEGuildExpFactorDataList.m_difficultyFactors[difficulty - 1].m_expValue;
				}
			}
			float num5 = num + num3 + num4;
			num5 *= AntiAddiction.ccb82e6b2e7ea42ec09135d0657ab0b7d(c9c8de68aa0982db2bbd496692c37e[i].m_antiAddictionLevel);
			statSheet.m_guildExp += (int)num5;
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

	protected override float c0dd068b2130e237656c77f780031a1fd(StatisticsManager.SessionStats c79481ca22d0ff4b145e4fe24cc5d6f6b, StatisticsManager.StatSheet c1226047aa159ca56aa73e4e8edceb917, bool cb4610728586d2d9e4e7cf12764a1f555)
	{
		ScoringSetupPVE scoringSetupPVE = m_scoreSetup.m_ScoringSetup as ScoringSetupPVE;
		if (scoringSetupPVE != null)
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
					float result = 1f;
					int ca329c5118ba5116b53cec9efd5542cff = (int)c1226047aa159ca56aa73e4e8edceb917.ca329c5118ba5116b53cec9efd5542cff;
					if (ca329c5118ba5116b53cec9efd5542cff < scoringSetupPVE.m_performanceRankBonus.Length)
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
						ELevelDifficulty difficulty = c79481ca22d0ff4b145e4fe24cc5d6f6b.m_difficulty;
						PerformanceRankPVE performanceRankPVE = cee6fceff7abe43c590931a04964ff983.c7088de59e49f7108f520cf7e0bae167e;
						switch (difficulty)
						{
						case ELevelDifficulty.Normal:
							performanceRankPVE = scoringSetupPVE.m_performanceRankBonus[ca329c5118ba5116b53cec9efd5542cff].m_performanceRankNormal;
							break;
						case ELevelDifficulty.Hard:
							performanceRankPVE = scoringSetupPVE.m_performanceRankBonus[ca329c5118ba5116b53cec9efd5542cff].m_performanceRankHard;
							break;
						case ELevelDifficulty.Hell:
							performanceRankPVE = scoringSetupPVE.m_performanceRankBonus[ca329c5118ba5116b53cec9efd5542cff].m_performanceRankHell;
							break;
						}
						if (performanceRankPVE == null)
						{
							return 1f;
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
						float num;
						if (cb4610728586d2d9e4e7cf12764a1f555)
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
							num = performanceRankPVE.m_softCurrencyBonus;
						}
						else
						{
							num = performanceRankPVE.m_EXPBonus;
						}
						result = num;
					}
					return result;
				}
				}
			}
		}
		return 1f;
	}

	private float c245d29329153f2f7015b939afea8d16e(int cc91b88c0d703701bf50ef9e3ab825ed3, int cd4d8c55bd2855de1a5bd4f403255ca53)
	{
		ScoringSetupPVE scoringSetupPVE = m_scoreSetup.m_ScoringSetup as ScoringSetupPVE;
		if (scoringSetupPVE != null)
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
					int num = cc91b88c0d703701bf50ef9e3ab825ed3 - cd4d8c55bd2855de1a5bd4f403255ca53;
					for (int i = 0; i < scoringSetupPVE.m_levelAdjustments.Length - 1; i++)
					{
						if (num <= scoringSetupPVE.m_levelAdjustments[i].m_instanceCharacterLevelDiff)
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									break;
								default:
									return scoringSetupPVE.m_levelAdjustments[i].m_modifier;
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
							return scoringSetupPVE.m_levelAdjustments[scoringSetupPVE.m_levelAdjustments.Length - 1].m_modifier;
						}
					}
				}
				}
			}
		}
		return 1f;
	}

	public override void c8016e12695c9b13b19ba1bba03f30c6f(StatisticsManager.SessionStats c79481ca22d0ff4b145e4fe24cc5d6f6b)
	{
		for (int i = 0; i < c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets.Count; i++)
		{
			c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[i].m_score = 0;
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
			int num = 45;
			if (c79481ca22d0ff4b145e4fe24cc5d6f6b.m_duration < 420f)
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
				num += 5;
			}
			StatisticsManager.StatSheet[] array = c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets.ToArray();
			if (_003C_003Ef__am_0024cache0 == null)
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
				_003C_003Ef__am_0024cache0 = (StatisticsManager.StatSheet c2993f6f258fe4579223a84a5bae0ed06, StatisticsManager.StatSheet c568f0fb646e0f9df3ef10d50dec7cdaa) => -c2993f6f258fe4579223a84a5bae0ed06.m_totalDamage.CompareTo(c568f0fb646e0f9df3ef10d50dec7cdaa.m_totalDamage);
			}
			Array.Sort(array, _003C_003Ef__am_0024cache0);
			StatisticsManager.StatSheet[] array2 = c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets.ToArray();
			if (_003C_003Ef__am_0024cache1 == null)
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
				_003C_003Ef__am_0024cache1 = delegate(StatisticsManager.StatSheet c2993f6f258fe4579223a84a5bae0ed06, StatisticsManager.StatSheet c568f0fb646e0f9df3ef10d50dec7cdaa)
				{
					int num8;
					if (c2993f6f258fe4579223a84a5bae0ed06.m_hitNumber != 0)
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
						num8 = c2993f6f258fe4579223a84a5bae0ed06.m_criticalHitNumber / c2993f6f258fe4579223a84a5bae0ed06.m_hitNumber;
					}
					else
					{
						num8 = 0;
					}
					float num9 = num8;
					int num10;
					if (c568f0fb646e0f9df3ef10d50dec7cdaa.m_hitNumber != 0)
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
						num10 = c568f0fb646e0f9df3ef10d50dec7cdaa.m_criticalHitNumber / c568f0fb646e0f9df3ef10d50dec7cdaa.m_hitNumber;
					}
					else
					{
						num10 = 0;
					}
					float value = num10;
					return -num9.CompareTo(value);
				};
			}
			Array.Sort(array2, _003C_003Ef__am_0024cache1);
			for (int j = 0; j < c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets.Count; j++)
			{
				int num2;
				if (c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[j].m_deathcount > 0)
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
					num2 = 5;
				}
				else
				{
					num2 = 0;
				}
				int num3 = num2;
				num3 += c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[j].m_deathcount * 5;
				num3 = Mathf.Min(num3, 20);
				int a = c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[j].m_badassKill * 2 + c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[j].m_bossKill * 10;
				a = Mathf.Min(a, 10);
				int num4 = 20;
				int num5 = 0;
				while (true)
				{
					if (num5 < array.Length)
					{
						if (c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[j].m_name == array[num5].m_name)
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
							num4 -= num5 * 2;
							break;
						}
						num5++;
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
				int num6 = 20;
				int num7 = 0;
				while (true)
				{
					if (num7 < array.Length)
					{
						if (c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[j].m_name == array2[num7].m_name)
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
							num6 -= num7 * 2;
							break;
						}
						num7++;
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
				c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[j].m_score += num + num4 + num6 + a - num3;
				object[] array3 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(14);
				array3[0] = "CalculateScore for";
				array3[1] = c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[j].m_name;
				array3[2] = ": ";
				array3[3] = num;
				array3[4] = "+";
				array3[5] = num4;
				array3[6] = "+";
				array3[7] = num6;
				array3[8] = "+";
				array3[9] = a;
				array3[10] = "-";
				array3[11] = num3;
				array3[12] = "=";
				array3[13] = c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[j].m_score;
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array3));
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				c2b758e371d939e85369ea9f744b16819(c79481ca22d0ff4b145e4fe24cc5d6f6b);
				ce690563ece2c0a8075187ac6219dbc1c(c79481ca22d0ff4b145e4fe24cc5d6f6b);
				cf2c4d0e30728d4d71f26e565ad651c4b(c79481ca22d0ff4b145e4fe24cc5d6f6b);
				return;
			}
		}
	}

	[CompilerGenerated]
	private static int c6535386b306b0f3d6d8720779179bf9f(StatisticsManager.StatSheet c2993f6f258fe4579223a84a5bae0ed06, StatisticsManager.StatSheet c568f0fb646e0f9df3ef10d50dec7cdaa)
	{
		return -c2993f6f258fe4579223a84a5bae0ed06.m_totalDamage.CompareTo(c568f0fb646e0f9df3ef10d50dec7cdaa.m_totalDamage);
	}

	[CompilerGenerated]
	private static int c34a3e446625f4b53e5f90647b4d688fb(StatisticsManager.StatSheet c2993f6f258fe4579223a84a5bae0ed06, StatisticsManager.StatSheet c568f0fb646e0f9df3ef10d50dec7cdaa)
	{
		int num;
		if (c2993f6f258fe4579223a84a5bae0ed06.m_hitNumber != 0)
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
			num = c2993f6f258fe4579223a84a5bae0ed06.m_criticalHitNumber / c2993f6f258fe4579223a84a5bae0ed06.m_hitNumber;
		}
		else
		{
			num = 0;
		}
		float num2 = num;
		int num3;
		if (c568f0fb646e0f9df3ef10d50dec7cdaa.m_hitNumber != 0)
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
			num3 = c568f0fb646e0f9df3ef10d50dec7cdaa.m_criticalHitNumber / c568f0fb646e0f9df3ef10d50dec7cdaa.m_hitNumber;
		}
		else
		{
			num3 = 0;
		}
		float value = num3;
		return -num2.CompareTo(value);
	}
}
