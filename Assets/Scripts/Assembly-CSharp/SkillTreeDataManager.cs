using System;
using System.Collections.Generic;
using A;
using Core;
using XsdSettings;

public class SkillTreeDataManager : ISkillTreeServiceNotificationListerner
{
	public delegate void OnGetInvestedDataCallBack(List<InvestedSkill> investedSkillPoints);

	public delegate void OnGetUnspentSkillPtCallBack(int earned, int unspent);

	protected XsdSettings.SkillTree _skillTreeData;

	protected Dictionary<int, int> _dicRequiredSkillPtToUnlockNextTier = new Dictionary<int, int>();

	protected Dictionary<int, Dictionary<int, int>> _dicSkillPtDetailOfEachGroup = new Dictionary<int, Dictionary<int, int>>();

	protected Dictionary<int, int> _dicTierIdOfEachSkill = new Dictionary<int, int>();

	protected Dictionary<int, int> _dicGroupIdOfEachSkill = new Dictionary<int, int>();

	protected Dictionary<int, int> _dicInvestedSkillPtOfEachSkill = new Dictionary<int, int>();

	protected Dictionary<int, int> _dicTotalInvestedPtOfEachGroup = new Dictionary<int, int>();

	protected List<InvestedSkill> _investedSkill = new List<InvestedSkill>();

	protected int _iUnspentPt;

	protected int _iEarnedPt;

	protected int _iTotalInvestedSkillPt;

	protected int _iOnUpdatingSkillID = -1;

	protected bool _bOnWaitNetworkResponse;

	protected OnGetInvestedDataCallBack _onInvestDataCallBackList;

	protected OnGetUnspentSkillPtCallBack _onUnspentSkillPtCallBackList;

	protected static SkillTreeDataManager _skillTreeDataMgrInstance;

	public int cf911a35d05d3ab36f43509e78d4765b3
	{
		get
		{
			return _iOnUpdatingSkillID;
		}
	}

	public XsdSettings.SkillTree c08678cb5a9f2ec077be4dd868efd1453
	{
		get
		{
			return _skillTreeData;
		}
	}

	public int c4d24a9cadafffc413bf9c8df83bdec2d
	{
		get
		{
			return _iUnspentPt;
		}
	}

	public int cd2a5c391c1d46ff36a39370815c88946
	{
		get
		{
			return _iEarnedPt;
		}
	}

	public List<InvestedSkill> c1c854731c4ee6c7c125777fa11db8c5d
	{
		get
		{
			return _investedSkill;
		}
	}

	private SkillTreeDataManager()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(this);
		_investedSkill = c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cbdc3d31ee9ec65e6f0badf60655c8747();
		_iUnspentPt = c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c712934bdea3cc2467880c2bc67073dcf;
		_iEarnedPt = c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ce9364445e85feaedbf51005d8d0a00d0;
	}

	public static SkillTreeDataManager c71f6ce28731edfd43c976fbd57c57bea()
	{
		if (_skillTreeDataMgrInstance == null)
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
			_skillTreeDataMgrInstance = new SkillTreeDataManager();
		}
		return _skillTreeDataMgrInstance;
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		_onInvestDataCallBackList = null;
		_onUnspentSkillPtCallBackList = null;
	}

	public void ce299e6d366e2dbedce1e85e4f5aaedf8(OnGetInvestedDataCallBack c8985f47f4f91c32134aa4602ac2debef)
	{
		_onInvestDataCallBackList = (OnGetInvestedDataCallBack)Delegate.Combine(_onInvestDataCallBackList, c8985f47f4f91c32134aa4602ac2debef);
	}

	public void c39e911336cb557f0eec128814bdf7728(OnGetUnspentSkillPtCallBack c8985f47f4f91c32134aa4602ac2debef)
	{
		_onUnspentSkillPtCallBackList = (OnGetUnspentSkillPtCallBack)Delegate.Combine(_onUnspentSkillPtCallBackList, c8985f47f4f91c32134aa4602ac2debef);
	}

	public void c813c04cff18bcb0a23378cfc5a4c4e9a(OnGetInvestedDataCallBack c8985f47f4f91c32134aa4602ac2debef)
	{
		_onInvestDataCallBackList = (OnGetInvestedDataCallBack)Delegate.Remove(_onInvestDataCallBackList, c8985f47f4f91c32134aa4602ac2debef);
	}

	public void c47e881bbdb23d9f2d20b66a55626b570(OnGetUnspentSkillPtCallBack c8985f47f4f91c32134aa4602ac2debef)
	{
		_onUnspentSkillPtCallBackList = (OnGetUnspentSkillPtCallBack)Delegate.Remove(_onUnspentSkillPtCallBackList, c8985f47f4f91c32134aa4602ac2debef);
	}

	protected void c319256c67b4cfab06138c17580513fd8()
	{
		if (!(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
				c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<PlayerSkillTreeManage>().OnLocalSkillUpgrade();
				return;
			}
		}
	}

	public void c1c15f3fcf8a83518063cfbba8d5b51fc()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cc5937332e02452fa6fb4760b2f5c7c81();
	}

	public void cb2129d5ac409250d4c0820338b1540f1(int c1bbe7ac27bc57192b9ca7f2cd055cabd)
	{
		if (_iUnspentPt <= 0)
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
			if (_bOnWaitNetworkResponse)
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ca386063cf1e9f62374d53cb460ea8131(c1bbe7ac27bc57192b9ca7f2cd055cabd);
				_bOnWaitNetworkResponse = true;
				return;
			}
		}
	}

	public void OnGetPlayerSkillPt(int characterId, int earned, int unspent, List<InvestedSkill> investedSkillPoints)
	{
		_iUnspentPt = unspent;
		_iEarnedPt = earned;
		if (_onUnspentSkillPtCallBackList != null)
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
			_onUnspentSkillPtCallBackList(earned, unspent);
		}
		OnGetInvestedSkillPt(OnlineService.s_characterId, investedSkillPoints);
	}

	public void OnInvestedSkillPt(int characterId, int skillId, bool wasSuccessful)
	{
		_bOnWaitNetworkResponse = false;
		_iOnUpdatingSkillID = skillId;
		if (!wasSuccessful)
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
			OnGetPlayerSkillPt(OnlineService.s_characterId, c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ce9364445e85feaedbf51005d8d0a00d0, c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c712934bdea3cc2467880c2bc67073dcf, c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cbdc3d31ee9ec65e6f0badf60655c8747());
			return;
		}
	}

	public void OnResetSkillPt(int characterId, bool wasSuccessful)
	{
		if (!wasSuccessful)
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
			OnGetPlayerSkillPt(OnlineService.s_characterId, c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ce9364445e85feaedbf51005d8d0a00d0, c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c712934bdea3cc2467880c2bc67073dcf, c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cbdc3d31ee9ec65e6f0badf60655c8747());
			return;
		}
	}

	public void OnSkillPtEarned(int characterId, int numEarned)
	{
		OnGetPlayerSkillPt(OnlineService.s_characterId, c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ce9364445e85feaedbf51005d8d0a00d0, c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c712934bdea3cc2467880c2bc67073dcf, c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cbdc3d31ee9ec65e6f0badf60655c8747());
	}

	public void OnGetInvestedSkillPt(int characterId, List<InvestedSkill> investedSkillPoints)
	{
		_investedSkill = investedSkillPoints;
		c81d48924cdead6f4bf6d4098f31c2422();
		c319256c67b4cfab06138c17580513fd8();
		if (_onInvestDataCallBackList == null)
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
			_onInvestDataCallBackList(investedSkillPoints);
			return;
		}
	}

	public void c076bcbb538ab7a02f13183c99cc8c79e()
	{
		AvatarType avatarType = AvatarType.SIREN;
		avatarType = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c093d70e3287743ce2bc905d2c4b341f3().c071244a19e2d9f70f4d2d6d38677162a();
		XsdSettings.SkillTree skillTree = c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c42b56e549eb01b78a7f940b86feef507(avatarType);
		if (skillTree == null)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "Can not get the skill tree data in SkillTreeView!");
					return;
				}
			}
		}
		_dicRequiredSkillPtToUnlockNextTier.Clear();
		_dicTierIdOfEachSkill.Clear();
		_dicGroupIdOfEachSkill.Clear();
		_skillTreeData = skillTree;
		SkillTreeTier[] tierList = _skillTreeData.m_tierList;
		foreach (SkillTreeTier skillTreeTier in tierList)
		{
			int id = skillTreeTier.m_id;
			_dicRequiredSkillPtToUnlockNextTier.Add(id, skillTreeTier.m_pointToUnlockNextTier);
			NodeGroup[] nodeGroupList = skillTreeTier.m_nodeGroupList;
			foreach (NodeGroup nodeGroup in nodeGroupList)
			{
				int id2 = nodeGroup.m_id;
				if (!_dicTotalInvestedPtOfEachGroup.ContainsKey(id2))
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
					_dicTotalInvestedPtOfEachGroup.Add(id2, 0);
				}
				SkillNode[] nodeList = nodeGroup.m_nodeList;
				foreach (SkillNode skillNode in nodeList)
				{
					int key = Convert.ToInt32(skillNode.m_id);
					_dicGroupIdOfEachSkill.Add(key, id2);
					_dicTierIdOfEachSkill.Add(key, id);
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						goto end_IL_014e;
					}
					continue;
					end_IL_014e:
					break;
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					goto end_IL_0169;
				}
				continue;
				end_IL_0169:
				break;
			}
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			c81d48924cdead6f4bf6d4098f31c2422();
			return;
		}
	}

	public int cea0fda735aa58693de81cd5dabada6f7(int c1bbe7ac27bc57192b9ca7f2cd055cabd)
	{
		int result = 0;
		if (!_dicInvestedSkillPtOfEachSkill.ContainsKey(c1bbe7ac27bc57192b9ca7f2cd055cabd))
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
					return result;
				}
			}
		}
		return _dicInvestedSkillPtOfEachSkill[c1bbe7ac27bc57192b9ca7f2cd055cabd];
	}

	public bool c5ecba50bdb5dc4dcc6028fbc4131f8bd(int c026d78bf74853e7058639078ccf224f7, int cafca817057c766204a83f95430d51b8f)
	{
		bool result = false;
		if (c026d78bf74853e7058639078ccf224f7 == 1)
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
			result = _iEarnedPt >= 1;
		}
		else
		{
			if (c026d78bf74853e7058639078ccf224f7 != 2)
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
				if (c026d78bf74853e7058639078ccf224f7 != 3)
				{
					int num = cd78331e7b4177995178d1f1bab6810b9(c026d78bf74853e7058639078ccf224f7 - 1);
					if (_dicTotalInvestedPtOfEachGroup.ContainsKey(cafca817057c766204a83f95430d51b8f))
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
						result = _dicTotalInvestedPtOfEachGroup[cafca817057c766204a83f95430d51b8f] >= num;
					}
					goto IL_0090;
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
			}
			result = _iTotalInvestedSkillPt >= c026d78bf74853e7058639078ccf224f7 - 1;
		}
		goto IL_0090;
		IL_0090:
		return result;
	}

	public int cd6ef934b24b5c66ce894c3d83366b5e8(int cafca817057c766204a83f95430d51b8f)
	{
		int num = _dicTotalInvestedPtOfEachGroup[cafca817057c766204a83f95430d51b8f];
		int num2 = 0;
		int num3 = 3;
		while (true)
		{
			if (num3 <= _dicRequiredSkillPtToUnlockNextTier.Count)
			{
				num2 += _dicRequiredSkillPtToUnlockNextTier[num3];
				if (num2 > num)
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
					break;
				}
				num3++;
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
			break;
		}
		int result;
		if (num3 > 8)
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
			result = 8;
		}
		else
		{
			result = num3;
		}
		return result;
	}

	public float cc372931d6207ce6ae7b685ff7f8ca879(int c026d78bf74853e7058639078ccf224f7, int cafca817057c766204a83f95430d51b8f)
	{
		float num = -1f;
		int num2 = cd78331e7b4177995178d1f1bab6810b9(c026d78bf74853e7058639078ccf224f7 - 1);
		int num3 = _dicTotalInvestedPtOfEachGroup[cafca817057c766204a83f95430d51b8f];
		int num4 = _dicRequiredSkillPtToUnlockNextTier[c026d78bf74853e7058639078ccf224f7];
		return (float)(num3 - num2) / (float)num4;
	}

	public int cd78331e7b4177995178d1f1bab6810b9(int c026d78bf74853e7058639078ccf224f7)
	{
		int num = 0;
		for (int i = 3; i <= c026d78bf74853e7058639078ccf224f7; i++)
		{
			num += _dicRequiredSkillPtToUnlockNextTier[i];
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
			return num;
		}
	}

	protected void c81d48924cdead6f4bf6d4098f31c2422()
	{
		if (_investedSkill == null)
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
			if (_investedSkill.Count == 0)
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
			_iTotalInvestedSkillPt = 0;
			_dicSkillPtDetailOfEachGroup.Clear();
			_dicInvestedSkillPtOfEachSkill.Clear();
			List<int> list = new List<int>(_dicTotalInvestedPtOfEachGroup.Keys);
			using (List<int>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					_dicTotalInvestedPtOfEachGroup[current] = 0;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_0092;
					}
					continue;
					end_IL_0092:
					break;
				}
			}
			using (List<InvestedSkill>.Enumerator enumerator2 = _investedSkill.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					InvestedSkill current2 = enumerator2.Current;
					int cca02a1eac8c42296f4fdb7cf3612badb = current2.cca02a1eac8c42296f4fdb7cf3612badb;
					_iTotalInvestedSkillPt += current2.c965a511d00f8d94f0770a443a06696e5;
					if (!_dicTierIdOfEachSkill.ContainsKey(cca02a1eac8c42296f4fdb7cf3612badb))
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
					if (!_dicGroupIdOfEachSkill.ContainsKey(cca02a1eac8c42296f4fdb7cf3612badb))
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
						continue;
					}
					int key = _dicTierIdOfEachSkill[current2.cca02a1eac8c42296f4fdb7cf3612badb];
					int num = _dicGroupIdOfEachSkill[current2.cca02a1eac8c42296f4fdb7cf3612badb];
					Dictionary<int, int> value = ca75facec0dca07cee5ebd517a6e858ff.c7088de59e49f7108f520cf7e0bae167e;
					_dicSkillPtDetailOfEachGroup.TryGetValue(key, out value);
					if (value == null)
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
						value = new Dictionary<int, int>();
						_dicSkillPtDetailOfEachGroup.Add(key, value);
					}
					if (!value.ContainsKey(num))
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
						value.Add(num, 0);
					}
					Dictionary<int, int> dictionary;
					Dictionary<int, int> dictionary2 = (dictionary = value);
					int key2;
					int key3 = (key2 = num);
					key2 = dictionary[key2];
					dictionary2[key3] = key2 + current2.c965a511d00f8d94f0770a443a06696e5;
					Dictionary<int, int> dicTotalInvestedPtOfEachGroup;
					Dictionary<int, int> dictionary3 = (dicTotalInvestedPtOfEachGroup = _dicTotalInvestedPtOfEachGroup);
					int key4 = (key2 = num);
					key2 = dicTotalInvestedPtOfEachGroup[key2];
					dictionary3[key4] = key2 + current2.c965a511d00f8d94f0770a443a06696e5;
					_dicInvestedSkillPtOfEachSkill.Add(cca02a1eac8c42296f4fdb7cf3612badb, current2.c965a511d00f8d94f0770a443a06696e5);
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
}
