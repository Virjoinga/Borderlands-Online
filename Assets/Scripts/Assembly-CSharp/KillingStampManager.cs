using System.Collections.Generic;
using XsdSettings;

public class KillingStampManager
{
	protected static KillingStampManager _KillingStampManager;

	private List<ScoringActionType> m_KillingStampList;

	private KillingStampManager()
	{
		m_KillingStampList = new List<ScoringActionType>();
		m_KillingStampList.Clear();
	}

	public static KillingStampManager c71f6ce28731edfd43c976fbd57c57bea()
	{
		if (_KillingStampManager == null)
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
			_KillingStampManager = new KillingStampManager();
		}
		return _KillingStampManager;
	}

	public void c78a38df0552e24750c35e93bc2c466e3()
	{
		m_KillingStampList.Clear();
	}

	public void c102955633a925cc7f3fbaaed7e4fc54e(ScoringActionType c2b4f43f34e21572af6ab4414f04cee36)
	{
		if (m_KillingStampList.Contains(c2b4f43f34e21572af6ab4414f04cee36))
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
			m_KillingStampList.Add(c2b4f43f34e21572af6ab4414f04cee36);
			return;
		}
	}

	public int ccbac5ab0a2855b0adc4324fe26e033a9()
	{
		return m_KillingStampList.Count;
	}

	public ScoringActionType c97d7a5a735063b7fad4db0bbb901032c(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (c5612a459a84ffdb41c885401433cd62d >= 0)
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
			if (c5612a459a84ffdb41c885401433cd62d < m_KillingStampList.Count)
			{
				return m_KillingStampList[c5612a459a84ffdb41c885401433cd62d];
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
		return ScoringActionType.BasicKill;
	}

	public void c0b882af59ca89c1cc74bf810af28e400()
	{
		m_KillingStampList.Clear();
		m_KillingStampList.Add(ScoringActionType.BasicAssist);
		m_KillingStampList.Add(ScoringActionType.BasicSuicide);
		m_KillingStampList.Add(ScoringActionType.BonusFirebirdKill);
		m_KillingStampList.Add(ScoringActionType.BonusHeadShot);
		m_KillingStampList.Add(ScoringActionType.BonusRevenge);
		m_KillingStampList.Add(ScoringActionType.BonusLastKill);
		m_KillingStampList.Add(ScoringActionType.BonusTurretKill);
	}
}
