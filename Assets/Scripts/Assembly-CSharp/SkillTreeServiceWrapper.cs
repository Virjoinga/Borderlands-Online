using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using UnityEngine;
using XsdSettings;

public class SkillTreeServiceWrapper : ServiceWrapper<ISkillTreeServiceWrapper, SkillTreeServiceWrapper>, ISkillTreeServiceNotificationListerner
{
	private SkillTreeSetup m_skillTreeSetup;

	private SkillSetup m_skillSetup;

	private bool m_bInited;

	private List<InvestedSkill> m_investedSkillPoints = new List<InvestedSkill>();

	private int m_iUnspentSkillPt;

	private int m_iEarnedSkillPt;

	private List<ISkillTreeServiceNotificationListerner> m_skillTreeListeners = new List<ISkillTreeServiceNotificationListerner>();

	public int c712934bdea3cc2467880c2bc67073dcf
	{
		get
		{
			return m_iUnspentSkillPt;
		}
	}

	public int ce9364445e85feaedbf51005d8d0a00d0
	{
		get
		{
			return m_iEarnedSkillPt;
		}
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/SkillTree");
		StringReader stringReader = new StringReader(textAsset.text);
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(cbedbe8093c0461d52f8e33fe5e88c89e.cc1720d05c75832f704b87474932341c3()));
			m_skillTreeSetup = xmlSerializer.Deserialize(stringReader) as SkillTreeSetup;
		}
		finally
		{
			if (stringReader != null)
			{
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
					((IDisposable)stringReader).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset);
		textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/SkillNode");
		StringReader stringReader2 = new StringReader(textAsset.text);
		try
		{
			XmlSerializer xmlSerializer2 = new XmlSerializer(Type.GetTypeFromHandle(c20c93244d3b1de572c3fb12fa93e3b8a.cc1720d05c75832f704b87474932341c3()));
			m_skillSetup = xmlSerializer2.Deserialize(stringReader2) as SkillSetup;
		}
		finally
		{
			if (stringReader2 != null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					((IDisposable)stringReader2).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset);
		if (!m_bInited)
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
			OnAccessSingleton<ISkillTreeService, SkillTreeService, SkillTreeServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cc728faa57c0b09d666b6465dc3512818(OnSkillPtEarned);
			m_bInited = true;
		}
		base.cd93285db16841148ed53a5bbeb35cf20();
	}

	public SkillSetup cf7c751c78f7532960e17cac5a131ac86()
	{
		return m_skillSetup;
	}

	public void c28e7fb4a7d03eef0acca90b1bd76a2c9(ISkillTreeServiceNotificationListerner c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_skillTreeListeners.Add(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void c704834a4a19f1f8555b44d9c021845ab(ISkillTreeServiceNotificationListerner c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_skillTreeListeners.Remove(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public XsdSettings.SkillTree c42b56e549eb01b78a7f940b86feef507(AvatarType c951097a6ef3eb670bc38dce2cd336b7a)
	{
		for (int i = 0; i < m_skillTreeSetup.m_trees.Length; i++)
		{
			if (m_skillTreeSetup.m_trees[i].m_avatarType != c951097a6ef3eb670bc38dce2cd336b7a)
			{
				continue;
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
				return m_skillTreeSetup.m_trees[i];
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public Skill cc68b2da7036261f61f86280fd6e61748(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		for (int i = 0; i < m_skillSetup.m_skills.Length; i++)
		{
			if (m_skillSetup.m_skills[i].m_id != c35f98ccbfa8c6bf09319c620b21b5dc5)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return m_skillSetup.m_skills[i];
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public override bool c39df47367fa21412aabfef05d9972f8c()
	{
		return true;
	}

	public List<InvestedSkill> cbdc3d31ee9ec65e6f0badf60655c8747()
	{
		return m_investedSkillPoints;
	}

	public void OnGetInvestedSkillPt(int characterId, List<InvestedSkill> investedSkillPoints)
	{
		if (investedSkillPoints != null)
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
			m_investedSkillPoints = investedSkillPoints;
		}
		using (List<ISkillTreeServiceNotificationListerner>.Enumerator enumerator = m_skillTreeListeners.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ISkillTreeServiceNotificationListerner current = enumerator.Current;
				current.OnGetInvestedSkillPt(characterId, investedSkillPoints);
			}
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
	}

	public void OnGetPlayerSkillPt(int characterId, int earned, int unspent, List<InvestedSkill> investedSkillPoints)
	{
		m_iEarnedSkillPt = earned;
		m_iUnspentSkillPt = unspent;
		using (List<ISkillTreeServiceNotificationListerner>.Enumerator enumerator = m_skillTreeListeners.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ISkillTreeServiceNotificationListerner current = enumerator.Current;
				current.OnGetPlayerSkillPt(characterId, earned, unspent, investedSkillPoints);
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
				break;
			}
		}
		OnGetInvestedSkillPt(characterId, investedSkillPoints);
	}

	public void OnInvestedSkillPt(int characterId, int skillId, bool wasSuccessful)
	{
		if (wasSuccessful)
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
			using (List<InvestedSkill>.Enumerator enumerator = m_investedSkillPoints.GetEnumerator())
			{
				while (true)
				{
					if (enumerator.MoveNext())
					{
						InvestedSkill current = enumerator.Current;
						if (current.cca02a1eac8c42296f4fdb7cf3612badb != skillId)
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
							current.c965a511d00f8d94f0770a443a06696e5++;
							break;
						}
						break;
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							goto end_IL_0065;
						}
						continue;
						end_IL_0065:
						break;
					}
					break;
				}
			}
			c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cb2129d5ac409250d4c0820338b1540f1();
			m_iUnspentSkillPt--;
		}
		using (List<ISkillTreeServiceNotificationListerner>.Enumerator enumerator2 = m_skillTreeListeners.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				ISkillTreeServiceNotificationListerner current2 = enumerator2.Current;
				current2.OnInvestedSkillPt(characterId, skillId, wasSuccessful);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_00c3;
				}
				continue;
				end_IL_00c3:
				break;
			}
		}
		int num = ce9364445e85feaedbf51005d8d0a00d0 - c712934bdea3cc2467880c2bc67073dcf;
		if (num >= 1)
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
			c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134("guidance_use_skillpoint");
		}
		if (num >= 2)
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
			c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134("guidance_use_secondary");
		}
		c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnSpentSkillPoint(m_investedSkillPoints.Count);
	}

	public void OnResetSkillPt(int characterId, bool wasSuccessful)
	{
		if (wasSuccessful)
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
			using (List<InvestedSkill>.Enumerator enumerator = m_investedSkillPoints.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					InvestedSkill current = enumerator.Current;
					current.c965a511d00f8d94f0770a443a06696e5 = 0;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_0042;
					}
					continue;
					end_IL_0042:
					break;
				}
			}
			m_iUnspentSkillPt = m_iEarnedSkillPt;
		}
		using (List<ISkillTreeServiceNotificationListerner>.Enumerator enumerator2 = m_skillTreeListeners.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				ISkillTreeServiceNotificationListerner current2 = enumerator2.Current;
				current2.OnResetSkillPt(characterId, wasSuccessful);
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

	public void OnSkillPtEarned(int characterId, int numEarned)
	{
		m_iUnspentSkillPt += numEarned;
		m_iEarnedSkillPt += numEarned;
		using (List<ISkillTreeServiceNotificationListerner>.Enumerator enumerator = m_skillTreeListeners.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ISkillTreeServiceNotificationListerner current = enumerator.Current;
				current.OnSkillPtEarned(characterId, numEarned);
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
				return;
			}
		}
	}

	public void cfef95a32127bfb3897865c32b38a72a3()
	{
		OnAccessSingleton<ISkillTreeService, SkillTreeService, SkillTreeServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cfef95a32127bfb3897865c32b38a72a3(OnGetPlayerSkillPt);
	}

	public void ca386063cf1e9f62374d53cb460ea8131(int cdc3aad41bf2754930ba17d687011c2ea)
	{
		OnAccessSingleton<ISkillTreeService, SkillTreeService, SkillTreeServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ca386063cf1e9f62374d53cb460ea8131(cdc3aad41bf2754930ba17d687011c2ea, OnInvestedSkillPt);
	}

	public void cf139283d44a3a850f9d9872a8c0c74f2(List<InvestedSkill> c3f381ce5aea55f604e88efed1ea621bd, InvestMultipleSkillPointsCallback c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<ISkillTreeService, SkillTreeService, SkillTreeServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cf139283d44a3a850f9d9872a8c0c74f2(c3f381ce5aea55f604e88efed1ea621bd, c2db84530ef366a6deb001d449d4aa151);
	}

	public void cc5937332e02452fa6fb4760b2f5c7c81()
	{
		OnAccessSingleton<ISkillTreeService, SkillTreeService, SkillTreeServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cc5937332e02452fa6fb4760b2f5c7c81(OnResetSkillPt);
	}
}
