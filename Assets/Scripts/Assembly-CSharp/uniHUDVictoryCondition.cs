using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using pumpkin.display;
using pumpkin.text;

public class uniHUDVictoryCondition : HUDVictoryCondition
{
	protected class RankInfo : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip mc_root;

		protected MovieClip m_achievement;

		protected MovieClip m_homeTeamScore;

		protected MovieClip m_awayTeamScore;

		protected MovieClip m_homeTeamScoreContainer;

		protected MovieClip m_awayTeamScoreContainer;

		protected MovieClip m_homeBar;

		protected MovieClip m_awayBar;

		protected MovieClip m_topScorePanel;

		protected MovieClip m_playerInfo;

		protected MovieClip m_scoreInfo;

		protected MovieClip m_killInfo;

		protected MovieClip m_scoreInfoPanel;

		protected int m_iLastUpperScore;

		public MovieClip m_timePanel;

		private uniHUDVictoryCondition rootView;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map1F;

		public uniHUDVictoryCondition cc00077a05e4b169dfcc8322da5a9e637
		{
			set
			{
				rootView = value;
			}
		}

		public void ce40505cecf808ae9bfc929326ba6be03()
		{
			string text = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c1492faa4c1a9b76581845cee4d47d460();
			if (text == "GamemodeTeamDeathmatch")
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
				StatisticsManager.SessionStats sessionStats = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25();
				if (sessionStats != null)
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
					if (sessionStats.c4df8d7d860c0beb0ca3ba64510fb0ba9(1) != null)
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
						if (sessionStats.c4df8d7d860c0beb0ca3ba64510fb0ba9(2) != null)
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
							int killCount = sessionStats.c4df8d7d860c0beb0ca3ba64510fb0ba9(1).m_killCount;
							int killCount2 = sessionStats.c4df8d7d860c0beb0ca3ba64510fb0ba9(2).m_killCount;
							c7949f87f6e53652dcc26dae3ef5b2443(m_homeTeamScoreContainer, killCount.ToString(), true, killCount > 0);
							c7949f87f6e53652dcc26dae3ef5b2443(m_awayTeamScoreContainer, killCount2.ToString(), true, killCount2 > 0);
						}
					}
				}
			}
			if (rootView.m_playerStats == null)
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
				if (rootView.m_playerStats.m_score == 0)
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
					if (rootView.m_playerStats.m_killCount == 0)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								if (m_scoreInfoPanel.visible)
								{
									while (true)
									{
										switch (5)
										{
										case 0:
											break;
										default:
											m_scoreInfoPanel.visible = false;
											return;
										}
									}
								}
								return;
							}
						}
					}
				}
				if (!m_scoreInfoPanel.visible)
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
					m_scoreInfoPanel.visible = true;
				}
				c7949f87f6e53652dcc26dae3ef5b2443(m_scoreInfoPanel.getChildByName<MovieClip>("mcScore"), rootView.m_playerStats.m_score.ToString());
				c7949f87f6e53652dcc26dae3ef5b2443(m_scoreInfoPanel.getChildByName<MovieClip>("mcKillInfo"), rootView.m_playerStats.m_killCount.ToString());
				return;
			}
		}

		public void cc97bbfe586ee64ad67844fd014202150(StatisticsManager.StatSheet cf7895de6a967b082d2d40226f6c77c73)
		{
			if (cf7895de6a967b082d2d40226f6c77c73 != null)
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
						MovieClip playerInfo = m_playerInfo;
						object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
						array[0] = "LV ";
						array[1] = cf7895de6a967b082d2d40226f6c77c73.m_level;
						array[2] = " ";
						array[3] = cf7895de6a967b082d2d40226f6c77c73.m_name;
						c7949f87f6e53652dcc26dae3ef5b2443(playerInfo, string.Concat(array));
						c7949f87f6e53652dcc26dae3ef5b2443(m_scoreInfo, cf7895de6a967b082d2d40226f6c77c73.m_score.ToString());
						c7949f87f6e53652dcc26dae3ef5b2443(m_killInfo, cf7895de6a967b082d2d40226f6c77c73.m_killCount.ToString());
						m_topScorePanel.visible = true;
						return;
					}
					}
				}
			}
			m_topScorePanel.visible = false;
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mc_root = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mc_root == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: RankInfo onInit() 'mc_root' is null! RankInfo won't work!!!");
						return;
					}
				}
			}
			m_homeBar = mc_root.getChildByName<MovieClip>("mc_HomeBar");
			m_awayBar = mc_root.getChildByName<MovieClip>("mc_AwayBar");
		}

		protected override bool OnWidgetInitialized(ref MovieClip mc, Type widgetType)
		{
			bool flag = false;
			string name = mc.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map1F == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(6);
					dictionary.Add("mcTime", 0);
					dictionary.Add("mcAwayTeamScore", 1);
					dictionary.Add("mcHomeTeamScore", 2);
					dictionary.Add("mcTopScore", 3);
					dictionary.Add("mcMyScoreInfo", 4);
					dictionary.Add("mc_achievement", 5);
					_003C_003Ef__switch_0024map1F = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map1F.TryGetValue(name, out value))
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
					switch (value)
					{
					case 0:
						m_timePanel = new MovieClip();
						m_timePanel = mc;
						return true;
					case 1:
						m_awayTeamScore = mc;
						m_awayTeamScoreContainer = m_awayTeamScore.getChildByName<MovieClip>("mcUpperScore");
						m_awayTeamScoreContainer = m_awayTeamScoreContainer.getChildByName<MovieClip>("mcTextContainer");
						c7949f87f6e53652dcc26dae3ef5b2443(m_awayTeamScoreContainer, "0");
						return true;
					case 2:
						m_homeTeamScore = mc;
						m_homeTeamScoreContainer = m_homeTeamScore.getChildByName<MovieClip>("mcUpperScore");
						m_homeTeamScoreContainer = m_homeTeamScoreContainer.getChildByName<MovieClip>("mcTextContainer");
						c7949f87f6e53652dcc26dae3ef5b2443(m_homeTeamScoreContainer, "0");
						return true;
					case 3:
						m_topScorePanel = mc;
						m_playerInfo = new MovieClip();
						m_playerInfo = m_topScorePanel.getChildByName<MovieClip>("mcPlayerInfoText");
						m_scoreInfo = new MovieClip();
						m_scoreInfo = m_topScorePanel.getChildByName<MovieClip>("mcScoreInfo");
						m_killInfo = new MovieClip();
						m_killInfo = m_topScorePanel.getChildByName<MovieClip>("mcKillingInfo");
						m_topScorePanel.visible = false;
						return true;
					case 4:
						m_scoreInfoPanel = mc;
						m_scoreInfoPanel.visible = false;
						return true;
					case 5:
						m_achievement = mc;
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
							c7949f87f6e53652dcc26dae3ef5b2443(m_achievement, LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVPMode_TeamDeathMatch")));
						}
						else
						{
							c7949f87f6e53652dcc26dae3ef5b2443(m_achievement, LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVPMode_DeathMatch")));
						}
						return true;
					}
				}
			}
			return true;
		}

		public void c1168c94ebf50ef5d83d39be0a7afbd26(bool cb4040e85ef24e4c9dea5dfc714598840)
		{
			if (cb4040e85ef24e4c9dea5dfc714598840)
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
						string text = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c1492faa4c1a9b76581845cee4d47d460();
						if (text == "GameModePvP")
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
							m_awayTeamScore.visible = false;
							m_homeTeamScore.visible = false;
							m_topScorePanel.visible = true;
							m_homeBar.visible = false;
							m_awayBar.visible = false;
						}
						else if (text == "GamemodeTeamDeathmatch")
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
							m_awayTeamScore.visible = true;
							m_homeTeamScore.visible = true;
							m_topScorePanel.visible = false;
							StatisticsManager.StatSheet statSheet = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().c9e69f6afb2b50d93703124af45d4282c();
							if (statSheet != null)
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
								if (statSheet.m_teamId == 1)
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
									m_homeBar.visible = true;
									m_awayBar.visible = false;
								}
								else
								{
									m_homeBar.visible = false;
									m_awayBar.visible = true;
								}
							}
							else
							{
								m_homeBar.visible = false;
								m_awayBar.visible = false;
							}
						}
						ca37fcdce7d4937b60735f4033eb55695.visible = true;
						return;
					}
					}
				}
			}
			ca37fcdce7d4937b60735f4033eb55695.visible = false;
		}

		private void c7949f87f6e53652dcc26dae3ef5b2443(MovieClip c6df0ceb3aa767576f3f5b0e23de52511, string c11850078118ec3368b07cfa9c60449bf, bool cb4040e85ef24e4c9dea5dfc714598840 = true, bool c08199da5b7717814ba22d0c51708b264 = false)
		{
			TextField childByName = c6df0ceb3aa767576f3f5b0e23de52511.getChildByName<TextField>("textField");
			if (childByName.text != c11850078118ec3368b07cfa9c60449bf)
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
				childByName.text = c11850078118ec3368b07cfa9c60449bf;
				if (c6df0ceb3aa767576f3f5b0e23de52511 != m_awayTeamScoreContainer)
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
					if (c6df0ceb3aa767576f3f5b0e23de52511 != m_homeTeamScoreContainer)
					{
						goto IL_0079;
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
				if (c08199da5b7717814ba22d0c51708b264)
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
					c6df0ceb3aa767576f3f5b0e23de52511.gotoAndPlay("getscore");
				}
			}
			goto IL_0079;
			IL_0079:
			if (childByName.visible == cb4040e85ef24e4c9dea5dfc714598840)
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
				childByName.visible = cb4040e85ef24e4c9dea5dfc714598840;
				return;
			}
		}

		public void c0681ed762d2c1280212506e01f096ae5(int ca5fb32f4feb4aff0ee8fdc95ae6f80ec, int c3c2131c89d76b1d389a4c7dcf15798c4, bool cb4040e85ef24e4c9dea5dfc714598840 = true)
		{
			if (m_timePanel == null)
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
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
			array[0] = ca5fb32f4feb4aff0ee8fdc95ae6f80ec;
			array[1] = "'";
			array[2] = c3c2131c89d76b1d389a4c7dcf15798c4;
			array[3] = "''";
			string c11850078118ec3368b07cfa9c60449bf = string.Concat(array);
			c7949f87f6e53652dcc26dae3ef5b2443(m_timePanel, c11850078118ec3368b07cfa9c60449bf, cb4040e85ef24e4c9dea5dfc714598840);
		}

		public void c3bdd21e16a0d22c5311b179718b189f8()
		{
			c7949f87f6e53652dcc26dae3ef5b2443(m_timePanel, "0'00''", false);
			if (m_timePanel == null)
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
				m_timePanel.gotoAndPlay("over");
				return;
			}
		}

		public void c1d51e33bf2f5c865e5a00507c3bb2561()
		{
			if (m_timePanel == null)
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
				m_timePanel.gotoAndPlay("normal");
				return;
			}
		}
	}

	protected RankInfo m_RankInfo;

	public StatisticsManager.StatSheet m_playerStats;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("2014_PVP_HUD.swf", "ScoreBar", cb84949f230f317cddc7079f4fd01b7df);
	}

	private void cb84949f230f317cddc7079f4fd01b7df(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		m_RankInfo = new RankInfo();
		m_RankInfo.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		m_RankInfo.cc00077a05e4b169dfcc8322da5a9e637 = this;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(m_RankInfo);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.visible = _bVisible;
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(m_RankInfo);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("2014_PVP_HUD.swf");
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		if (_bVisible == c8be1fcd630e5fe96821376d111325750)
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
			if (m_RankInfo == null)
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
			m_RankInfo.c1168c94ebf50ef5d83d39be0a7afbd26(c8be1fcd630e5fe96821376d111325750);
			base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
			return;
		}
	}

	public override void cd2cca57d3ef8ebc1d8ebfb19bd5a12d8(bool cda27ffec6c31265acec668af9ab6bac7)
	{
		if (m_RankInfo == null)
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
			m_RankInfo.c1168c94ebf50ef5d83d39be0a7afbd26(cda27ffec6c31265acec668af9ab6bac7);
			return;
		}
	}

	public override void cf887ab58656d86bc97c0443b84700a30(int c3675120a7d006992458a7b012bc6ae14, StatisticsManager.StatSheet c25f5f36a54095a8f73d85c7f7b5af196)
	{
		base.cf887ab58656d86bc97c0443b84700a30(c3675120a7d006992458a7b012bc6ae14);
		if (m_RankInfo == null)
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
		m_playerStats = c25f5f36a54095a8f73d85c7f7b5af196;
		if (m_bNewPhaseActived)
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
			switch (m_currentStatus)
			{
			case eTimeStatus.normal:
				m_RankInfo.c1d51e33bf2f5c865e5a00507c3bb2561();
				break;
			case eTimeStatus.over:
				m_RankInfo.c3bdd21e16a0d22c5311b179718b189f8();
				break;
			}
		}
		int ca5fb32f4feb4aff0ee8fdc95ae6f80ec = c3675120a7d006992458a7b012bc6ae14 / 60;
		int c3c2131c89d76b1d389a4c7dcf15798c = c3675120a7d006992458a7b012bc6ae14 % 60;
		if (m_currentStatus != eTimeStatus.over)
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
			m_RankInfo.c0681ed762d2c1280212506e01f096ae5(ca5fb32f4feb4aff0ee8fdc95ae6f80ec, c3c2131c89d76b1d389a4c7dcf15798c);
		}
		else
		{
			m_RankInfo.c0681ed762d2c1280212506e01f096ae5(0, 0, false);
		}
		if (c3675120a7d006992458a7b012bc6ae14 > 0)
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
			m_RankInfo.ce40505cecf808ae9bfc929326ba6be03();
		}
		m_RankInfo.cc97bbfe586ee64ad67844fd014202150(c96d07c9c1d2f219d906efac7cd5e405f());
	}
}
