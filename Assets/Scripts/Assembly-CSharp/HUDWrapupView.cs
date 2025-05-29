using System;
using A;
using XsdSettings;

public class HUDWrapupView : BaseView
{
	protected string m_LevelName = string.Empty;

	protected string m_Name = string.Empty;

	protected int m_Killed;

	protected float m_Detail;

	protected ELevelDifficulty m_Difficulty;

	protected int m_Hurt;

	protected int m_ExpGained;

	protected int m_Money;

	protected float m_Time;

	protected int m_GuildExp;

	public InstanceGrade m_instanceGrade = InstanceGrade.D;

	public HUDWrapupView()
	{
		m_Name = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409();
	}

	public override bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		return _bVisible;
	}

	public virtual void c515f796a94abd08a45b1f67775e1da8d()
	{
	}

	public virtual void c6c0790cec120a0223fe798ec4a63029a()
	{
		IClientSession clientSession = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28e186fb4c5763bc506c3ae8af6b71d2();
		if (clientSession != null)
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
			clientSession.c199c572672377bf874bb8b15ab36279e();
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cfd58c94350618be817cfdb449a158aad();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().ce14ab3b98c66fd882f4ebb627236ed4f();
		StatisticsManager.SessionStats sessionStats = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c876ebada48854e6e8e29d50bc5352240();
		StatisticsManager.StatSheet[] array = sessionStats.m_statsSheets.ToArray();
		m_Difficulty = sessionStats.m_difficulty;
		m_LevelName = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(sessionStats.m_instanceName));
		m_Time = sessionStats.m_duration;
		for (int i = 0; i < array.Length; i++)
		{
			if (!(array[i].m_name == m_Name))
			{
				continue;
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
			m_Killed = array[i].m_badassKill + array[i].m_bossKill;
			if (array[i].m_hitNumber != 0)
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
				m_Detail = (float)Math.Round((float)array[i].m_criticalHitNumber / (float)array[i].m_hitNumber * 100f);
			}
			else
			{
				m_Detail = 0f;
			}
			m_Hurt = array[i].m_totalDamage;
			m_ExpGained = array[i].m_extraExp;
			m_instanceGrade = array[i].ca329c5118ba5116b53cec9efd5542cff;
			m_Money = array[i].m_extraMoney;
			m_GuildExp = array[i].m_guildExp;
			if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd19cb80dca29b5c813acffe07d4eb050())
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
			m_GuildExp = 0;
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
