using System.Collections.Generic;
using A;
using Core;
using XsdSettings;

public class PlayerGuildEffectManage : IGuildServiceNotificationListerner
{
	private EntityPlayer m_playerOwner;

	private List<int> m_activeEffectList = new List<int>();

	private Dictionary<int, float> m_lookupDic = new Dictionary<int, float>();

	private int m_guildID;

	public PlayerGuildEffectManage(EntityPlayer cf811c0d5de19d7fe22be8d61350b722d)
	{
		m_playerOwner = cf811c0d5de19d7fe22be8d61350b722d;
		c7e9233155eb0d27692d962b37c1d353c();
		c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(this);
	}

	public void OnGetGuildActiveEffect(int guildId, List<GuildSkill> skills)
	{
		if (guildId <= 0)
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
			if (skills == null)
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
			m_guildID = guildId;
			m_activeEffectList.Clear();
			for (int i = 0; i < skills.Count; i++)
			{
				m_activeEffectList.Add(skills[i].Id);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				m_playerOwner.c7f7764f5af0ac27b16e2d01b492e5258();
				return;
			}
		}
	}

	public void OnReceivedGuildSkillSelected(int guildId, int skillId, int remainFreeSkillCount)
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			if (m_guildID <= 0)
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
				if (m_guildID != guildId)
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
					if (!m_activeEffectList.Contains(skillId))
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								m_activeEffectList.Add(skillId);
								m_playerOwner.c7f7764f5af0ac27b16e2d01b492e5258();
								return;
							}
						}
					}
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Format("{0} is already in active effect list!", skillId));
					return;
				}
			}
		}
	}

	public void OnReceivedGuildMemberJoin(int guildId, int characterId)
	{
		if (m_playerOwner.ca15c8f7004fafacb3955a523d9a1cec9() != characterId)
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
			m_guildID = guildId;
			return;
		}
	}

	public void OnReceivedGuildMemberQuit(int guildId, int characterId)
	{
		if (m_playerOwner.ca15c8f7004fafacb3955a523d9a1cec9() != characterId)
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
			m_guildID = 0;
			m_activeEffectList.Clear();
			m_playerOwner.c7f7764f5af0ac27b16e2d01b492e5258();
			return;
		}
	}

	public float c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType c4f09c39924e70788c7b055c1d1490578, AffectType c2b72f83d79e58e8996514b22aa4e82e3)
	{
		float result = m_playerOwner.c02f3d4a4e7d1edee179f9bf7e16aeb82.c60c4bc9a822c2cf24a43a6bfce027b54(c2b72f83d79e58e8996514b22aa4e82e3);
		if (m_activeEffectList.Contains((int)c4f09c39924e70788c7b055c1d1490578))
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
			result = m_lookupDic[(int)c4f09c39924e70788c7b055c1d1490578];
		}
		return result;
	}

	private void c7e9233155eb0d27692d962b37c1d353c()
	{
		m_lookupDic.Clear();
		for (int i = 0; i < c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_guildSkills.Length; i++)
		{
			GuildSkillData guildSkillData = c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_guildSkills[i];
			m_lookupDic.Add(guildSkillData.m_id, guildSkillData.m_value);
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
			return;
		}
	}

	public void OnReceivedGuildInvitation(int guildId, string guildMasterNick, string guildName)
	{
	}

	public void OnReceivedGuildJoined(int guildId, string guildName)
	{
	}

	public void OnReceivedGuildExpelled(int guildId, string guildName)
	{
	}

	public void OnReceivedFreeGuildSkillSlotGiven(int guildId, int remainFreeSkillCount)
	{
	}

	public void OnReceivedGuildManagerAssigned(int guildId)
	{
	}

	public void OnReceivedGuildManagerDischarged(int guildId)
	{
	}

	public void OnReceivedGuildMasterChanged(int guildId)
	{
	}
}
