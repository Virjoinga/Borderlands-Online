using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using UnityEngine;
using XsdSettings;

public abstract class GeneralScoringRule : ScoringRule
{
	private const float maxScoringDuration = 2700f;

	protected ScoringSetup m_scoreSetup;

	protected string m_scoringSettings = string.Empty;

	public virtual void OnDamagedPreStat(DamageContext context)
	{
	}

	public virtual void OnDamagedPostStat(DamageContext context)
	{
	}

	public virtual void OnEntityKillPreStat(KillContext context)
	{
	}

	public virtual void OnEntityKillPostStat(KillContext context)
	{
	}

	public virtual int c1cf78bc79484f63267d4766d6776b199(ScoringActionType c861de212c63da4e42109937e3cac1a44)
	{
		return 0;
	}

	public virtual void cb61f0369d09ada426256a3f4b80236fa(int c8a7f3986726d4793d7b3f3bbcc750943)
	{
	}

	public virtual void c79b0bc249fb8e76dcf6d1941f8abaee5(Entity cf7ee7f254a35f9c53a393957e2758a0a)
	{
	}

	public virtual void OnUpdateMatch()
	{
	}

	public virtual void OnEndMatch()
	{
	}

	public virtual void c8016e12695c9b13b19ba1bba03f30c6f(StatisticsManager.SessionStats c79481ca22d0ff4b145e4fe24cc5d6f6b)
	{
	}

	public virtual void ccc9d3a38966dc10fedb531ea17d24611()
	{
		if (m_scoringSettings.Length == 0)
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
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(m_scoringSettings);
		StringReader stringReader = new StringReader(textAsset.text);
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(cf362c9987addf265028668ca8e9d3fd6.cc1720d05c75832f704b87474932341c3()));
			m_scoreSetup = xmlSerializer.Deserialize(stringReader) as ScoringSetup;
		}
		finally
		{
			if (stringReader != null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					((IDisposable)stringReader).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset);
	}

	protected void c2b758e371d939e85369ea9f744b16819(StatisticsManager.SessionStats c79481ca22d0ff4b145e4fe24cc5d6f6b)
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
		ScoringBase scoringBase = m_scoreSetup.m_ScoringSetup as ScoringBase;
		if (scoringBase == null)
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
			List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
			c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
			float num = c79481ca22d0ff4b145e4fe24cc5d6f6b.m_duration;
			if (num > 2700f)
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
				num = 2700f;
			}
			for (int i = 0; i < c9c8de68aa0982db2bbd496692c37e.Count; i++)
			{
				StatisticsManager.StatSheet statSheet = c79481ca22d0ff4b145e4fe24cc5d6f6b.cdcb2ff44fc70c31a5ec9c7f0156d8f27(c9c8de68aa0982db2bbd496692c37e[i]);
				float num2 = num * scoringBase.m_moneyStandardReward * cc9105d91b160c7c4fec0ad4753e96fe0(statSheet.m_level, true) * scoringBase.m_modeModifierSoftCurrency * scoringBase.m_winBonusSoftCurrency * c0dd068b2130e237656c77f780031a1fd(c79481ca22d0ff4b145e4fe24cc5d6f6b, statSheet, true);
				statSheet.m_extraMoney = (int)(num2 * AntiAddiction.ccb82e6b2e7ea42ec09135d0657ab0b7d(c9c8de68aa0982db2bbd496692c37e[i].m_antiAddictionLevel));
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

	protected virtual float c0dd068b2130e237656c77f780031a1fd(StatisticsManager.SessionStats c79481ca22d0ff4b145e4fe24cc5d6f6b, StatisticsManager.StatSheet c1226047aa159ca56aa73e4e8edceb917, bool cb4610728586d2d9e4e7cf12764a1f555)
	{
		return 1f;
	}

	protected float cc9105d91b160c7c4fec0ad4753e96fe0(int cb9aa9404220b2b81c6745ac8d6bdabc6, bool cf330739bf5a132093f8cdd533a3891e2)
	{
		ScoringBase scoringBase = m_scoreSetup.m_ScoringSetup as ScoringBase;
		if (scoringBase != null)
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
					float[] array;
					if (cf330739bf5a132093f8cdd533a3891e2)
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
						array = scoringBase.m_moneyRewardRatePerLevel;
					}
					else
					{
						array = scoringBase.m_expRewardRatePerLevel;
					}
					float[] array2 = array;
					if (cb9aa9404220b2b81c6745ac8d6bdabc6 >= 1)
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
						if (cb9aa9404220b2b81c6745ac8d6bdabc6 <= array2.Length)
						{
							return array2[cb9aa9404220b2b81c6745ac8d6bdabc6 - 1];
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
					return 1f;
				}
				}
			}
		}
		return 1f;
	}
}
