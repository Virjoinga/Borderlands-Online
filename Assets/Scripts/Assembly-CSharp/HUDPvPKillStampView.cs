using System.Collections.Generic;
using A;
using XsdSettings;

public class HUDPvPKillStampView : BaseView
{
	public enum KillStampType
	{
		Red = 0,
		Blue = 1,
		Green = 2
	}

	public class KillStampInfo
	{
		public bool bDisplayed;

		public float fTimeLeft;

		public ScoringActionType ScoringType;
	}

	private const float m_KillStampDurationInSec = 5f;

	public int m_nMaxHistoryCount = 4;

	public int m_nNewStampCount;

	protected Queue<KillStampInfo> m_killstampInfoHistoryQueue = new Queue<KillStampInfo>();

	protected Queue<ScoringActionType> m_killstampInfoQueue = new Queue<ScoringActionType>();

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		m_killstampInfoQueue.Clear();
		m_killstampInfoHistoryQueue.Clear();
	}

	public void c688eefebe626d5700c624d4b6429f6ab(string ca15db9170f4b2624eb418325113f24a1, List<ScoringActionType> cb0d5d15056e0d7a6e60a76492d8203a3)
	{
		while (m_killstampInfoHistoryQueue.Count != 0)
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
			if (m_killstampInfoHistoryQueue.Peek().bDisplayed)
			{
				m_killstampInfoHistoryQueue.Dequeue();
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
		m_nNewStampCount = 0;
		if (ca15db9170f4b2624eb418325113f24a1 == c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409())
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
			for (int i = 0; i < cb0d5d15056e0d7a6e60a76492d8203a3.Count; i++)
			{
				switch (cb0d5d15056e0d7a6e60a76492d8203a3[i])
				{
				case ScoringActionType.BasicSuicide:
				case ScoringActionType.BasicAssist:
				case ScoringActionType.BonusHeadShot:
				case ScoringActionType.BonusCritical:
				case ScoringActionType.BonusMelee:
				case ScoringActionType.BonusLastKill:
				case ScoringActionType.BonusRevenge:
				case ScoringActionType.BonusTurretKill:
				case ScoringActionType.BonusFirebirdKill:
				case ScoringActionType.BonusPunchKill:
				case ScoringActionType.BonusMarkedKill:
				case ScoringActionType.BonusGrenadesKill:
					m_nNewStampCount++;
					c688eefebe626d5700c624d4b6429f6ab(cb0d5d15056e0d7a6e60a76492d8203a3[i]);
					cf09b848e87388789ed793817b2c1e9cb(cb0d5d15056e0d7a6e60a76492d8203a3[i]);
					KillingStampManager.c71f6ce28731edfd43c976fbd57c57bea().c102955633a925cc7f3fbaaed7e4fc54e(cb0d5d15056e0d7a6e60a76492d8203a3[i]);
					break;
				}
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
		if (m_nNewStampCount > m_nMaxHistoryCount)
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
			m_nNewStampCount = m_nMaxHistoryCount;
		}
		if (m_nNewStampCount <= 0)
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
			c81a375d8b79e8fcd506826a96d93f5a9();
			return;
		}
	}

	public void c81a375d8b79e8fcd506826a96d93f5a9()
	{
		KillStampInfo[] array = m_killstampInfoHistoryQueue.ToArray();
		for (int i = 0; i < m_nMaxHistoryCount; i++)
		{
			if (i < array.Length)
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
				KillStampType killStampType = KillStampType.Red;
				ScoringActionType scoringType = array[i].ScoringType;
				if (scoringType != ScoringActionType.BasicSuicide)
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
					if (scoringType != ScoringActionType.BasicAssist)
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
						killStampType = KillStampType.Red;
					}
					else
					{
						killStampType = KillStampType.Green;
					}
				}
				else
				{
					killStampType = KillStampType.Blue;
				}
				bool c9f7c402f1ebc33034fcb504a965dc = array[i].fTimeLeft <= 0f;
				bool c09cca5eafd4fdb6dcb625d = i >= array.Length - m_nNewStampCount;
				cedf24d0882cf193b727925a6e497eec5(i, killStampType, array[i].ScoringType, c09cca5eafd4fdb6dcb625d, c9f7c402f1ebc33034fcb504a965dc);
			}
			else
			{
				cedf24d0882cf193b727925a6e497eec5(i, KillStampType.Blue, ScoringActionType.BasicKill, false, false, false);
			}
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

	public virtual void cedf24d0882cf193b727925a6e497eec5(int c5612a459a84ffdb41c885401433cd62d, KillStampType c3dd63cbbc9b91e00848374d9fbadeb4a, ScoringActionType c912c4e044d875453592ee1f909d9f481, bool c09cca5eafd4fdb6dcb625d1475568049, bool c9f7c402f1ebc33034fcb504a965dc666 = false, bool c214eb97a4f62e21be4c73db2476e2f9e = true)
	{
	}

	protected void c688eefebe626d5700c624d4b6429f6ab(ScoringActionType c2b4f43f34e21572af6ab4414f04cee36)
	{
		m_killstampInfoQueue.Enqueue(c2b4f43f34e21572af6ab4414f04cee36);
	}

	protected void cf09b848e87388789ed793817b2c1e9cb(ScoringActionType c2b4f43f34e21572af6ab4414f04cee36)
	{
		if (m_killstampInfoHistoryQueue.Count >= m_nMaxHistoryCount)
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
			m_killstampInfoHistoryQueue.Dequeue();
		}
		KillStampInfo killStampInfo = new KillStampInfo();
		killStampInfo.bDisplayed = false;
		killStampInfo.ScoringType = c2b4f43f34e21572af6ab4414f04cee36;
		killStampInfo.fTimeLeft = 5f;
		m_killstampInfoHistoryQueue.Enqueue(killStampInfo);
	}

	public void cbeb688edaa441785de1fc7ac739eb868()
	{
		if (m_killstampInfoQueue.Count == 0)
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
			ScoringActionType scoringActionType = m_killstampInfoQueue.Dequeue();
			if (scoringActionType == ScoringActionType.BasicAssist)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						cdd0cd5262d80c1cc266da986bdbb86b0(KillStampType.Green, scoringActionType);
						return;
					}
				}
			}
			if (scoringActionType == ScoringActionType.BasicSuicide)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						cdd0cd5262d80c1cc266da986bdbb86b0(KillStampType.Blue, scoringActionType);
						return;
					}
				}
			}
			cdd0cd5262d80c1cc266da986bdbb86b0(KillStampType.Red, scoringActionType);
			return;
		}
	}

	public virtual void cdd0cd5262d80c1cc266da986bdbb86b0(KillStampType c3dd63cbbc9b91e00848374d9fbadeb4a, ScoringActionType c912c4e044d875453592ee1f909d9f481)
	{
	}

	public virtual void Update(float fDeltaTime)
	{
		KillStampInfo[] array = m_killstampInfoHistoryQueue.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].fTimeLeft -= fDeltaTime;
			if (!(array[i].fTimeLeft < 0f))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			array[i].fTimeLeft = 0f;
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

	public void ceb2a336a7402b963f4c512e2e1cb652f(int c5612a459a84ffdb41c885401433cd62d)
	{
		KillStampInfo[] array = m_killstampInfoHistoryQueue.ToArray();
		if (c5612a459a84ffdb41c885401433cd62d >= array.Length)
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
			array[c5612a459a84ffdb41c885401433cd62d].bDisplayed = true;
			return;
		}
	}

	public bool c545b62695c10a2d217ace6482461f480(int c5612a459a84ffdb41c885401433cd62d)
	{
		KillStampInfo[] array = m_killstampInfoHistoryQueue.ToArray();
		if (c5612a459a84ffdb41c885401433cd62d < array.Length)
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
					return array[c5612a459a84ffdb41c885401433cd62d].bDisplayed;
				}
			}
		}
		return true;
	}

	public bool c3b3dabaf53de10c093171899c8cf1ebc(int c5612a459a84ffdb41c885401433cd62d)
	{
		KillStampInfo[] array = m_killstampInfoHistoryQueue.ToArray();
		if (c5612a459a84ffdb41c885401433cd62d >= array.Length)
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
					return false;
				}
			}
		}
		if (array[c5612a459a84ffdb41c885401433cd62d].fTimeLeft <= 0f)
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
		return false;
	}

	public bool cf4d3d28e57a2c2d7aa9123542e91d803(int c5612a459a84ffdb41c885401433cd62d)
	{
		KillStampInfo[] array = m_killstampInfoHistoryQueue.ToArray();
		if (c5612a459a84ffdb41c885401433cd62d >= array.Length)
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
		return true;
	}
}
