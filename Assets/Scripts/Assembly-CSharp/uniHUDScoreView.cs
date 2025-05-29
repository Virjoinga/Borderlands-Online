using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniHUDScoreView : HUDScoreView
{
	public class ScoreBoard : c196099a1254db61d3be10d70e14e7422
	{
		protected ScoreItem[] m_ScoreItemArray = new ScoreItem[12];

		protected string m_strLinePrefix = "mcLine_";

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			if (movieClip.name.Contains(m_strLinePrefix))
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
				string name = movieClip.name;
				char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = '_';
				string[] array2 = name.Split(array);
				string value = array2[array2.Length - 1];
				int num = Convert.ToInt32(value);
				if (num >= 1)
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
					if (num <= m_ScoreItemArray.Length)
					{
						m_ScoreItemArray[num - 1] = new ScoreItem();
						m_ScoreItemArray[num - 1].c130648b59a0c8debea60aa153f844879(movieClip);
						movieClip.visible = false;
						result = true;
						goto IL_00c6;
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
				}
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "PVP_HUD.swf:ScoreBoard   Wrong MovieClip index : " + movieClip.name);
				return result;
			}
			goto IL_00c6;
			IL_00c6:
			return result;
		}

		public void c40b5bc409cf38b17f8cc13dd745279ee(List<StatisticsManager.StatSheet> cf88105fa1080da7ad31590d7de60ae5a)
		{
			int count = cf88105fa1080da7ad31590d7de60ae5a.Count;
			for (int i = 0; i < m_ScoreItemArray.Length; i++)
			{
				if (i < count)
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
					m_ScoreItemArray[i].c785dc99f380e21252755b1fcda3d67f0(cf88105fa1080da7ad31590d7de60ae5a[i], i + 1);
					m_ScoreItemArray[i].c43cbb41bf755dfa61de619fc6e86ab31(true);
					m_ScoreItemArray[i].ca1272bcb3438d16f27c027b94532d7e0(cf88105fa1080da7ad31590d7de60ae5a[i].m_name == c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_name);
				}
				else
				{
					m_ScoreItemArray[i].c43cbb41bf755dfa61de619fc6e86ab31(false);
				}
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

	public class ScoreItem : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip m_NetworkStatus;

		protected MovieClip m_Rank;

		protected MovieClip m_PlayerName;

		protected MovieClip m_Score;

		protected MovieClip m_KillCount;

		protected MovieClip m_DeathCount;

		protected bool m_bIsLocalPlayer;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map19;

		public void c43cbb41bf755dfa61de619fc6e86ab31(bool c8b64aef39806bef0c330f87521f7b940)
		{
			ca37fcdce7d4937b60735f4033eb55695.visible = c8b64aef39806bef0c330f87521f7b940;
		}

		public void ca1272bcb3438d16f27c027b94532d7e0(bool c303d6a858dfd020772297b64fc2b7030)
		{
			if (m_bIsLocalPlayer == c303d6a858dfd020772297b64fc2b7030)
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
				if (c303d6a858dfd020772297b64fc2b7030)
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
					(ca37fcdce7d4937b60735f4033eb55695 as MovieClip).gotoAndPlay("myline");
				}
				else
				{
					(ca37fcdce7d4937b60735f4033eb55695 as MovieClip).gotoAndPlay("normal");
				}
				m_bIsLocalPlayer = c303d6a858dfd020772297b64fc2b7030;
				return;
			}
		}

		public void c785dc99f380e21252755b1fcda3d67f0(StatisticsManager.StatSheet c5ea65450b74a8ce2c1741f2c7b3d6017, int c4e278a539e18dfd9b06dd3e3b8958a40)
		{
			m_PlayerName.getChildByName<TextField>("textField").text = c5ea65450b74a8ce2c1741f2c7b3d6017.m_name;
			m_Score.getChildByName<TextField>("textField").text = Convert.ToString(c5ea65450b74a8ce2c1741f2c7b3d6017.m_score);
			m_KillCount.getChildByName<TextField>("textField").text = Convert.ToString(c5ea65450b74a8ce2c1741f2c7b3d6017.m_killCount);
			m_DeathCount.getChildByName<TextField>("textField").text = Convert.ToString(c5ea65450b74a8ce2c1741f2c7b3d6017.m_deathcount);
			if (c5ea65450b74a8ce2c1741f2c7b3d6017.m_ping == StatisticsManager.PingQuality.Low)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				m_NetworkStatus.gotoAndStop("red");
			}
			else if (c5ea65450b74a8ce2c1741f2c7b3d6017.m_ping == StatisticsManager.PingQuality.Medium)
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
				m_NetworkStatus.gotoAndStop("orange");
			}
			else if (c5ea65450b74a8ce2c1741f2c7b3d6017.m_ping == StatisticsManager.PingQuality.High)
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
				m_NetworkStatus.gotoAndStop("green");
			}
			if (c4e278a539e18dfd9b06dd3e3b8958a40 == 1)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						m_Rank.getChildByName<TextField>("textField").text = "1st";
						return;
					}
				}
			}
			if (c4e278a539e18dfd9b06dd3e3b8958a40 == 2)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						m_Rank.getChildByName<TextField>("textField").text = "2nd";
						return;
					}
				}
			}
			if (c4e278a539e18dfd9b06dd3e3b8958a40 == 3)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						m_Rank.getChildByName<TextField>("textField").text = "3rd";
						return;
					}
				}
			}
			m_Rank.getChildByName<TextField>("textField").text = Convert.ToString(c4e278a539e18dfd9b06dd3e3b8958a40);
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			if (name != null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (_003C_003Ef__switch_0024map19 == null)
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
					dictionary.Add("mcRank", 0);
					dictionary.Add("mcPlayerName", 1);
					dictionary.Add("mcScore", 2);
					dictionary.Add("mcKillCount", 3);
					dictionary.Add("mcDeathCount", 4);
					dictionary.Add("mcNetworkStatus", 5);
					_003C_003Ef__switch_0024map19 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map19.TryGetValue(name, out value))
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
					switch (value)
					{
					case 0:
						m_Rank = movieClip;
						return true;
					case 1:
						m_PlayerName = movieClip;
						return true;
					case 2:
						m_Score = movieClip;
						return true;
					case 3:
						m_KillCount = movieClip;
						return true;
					case 4:
						m_DeathCount = movieClip;
						return true;
					case 5:
						m_NetworkStatus = movieClip;
						return true;
					}
				}
			}
			return true;
		}
	}

	public class SummaryBoard : c196099a1254db61d3be10d70e14e7422
	{
		protected SummaryItem[] m_SummaryItemArray = new SummaryItem[12];

		protected string m_strLinePrefix = "mcRank_";

		protected Delegate_ReturnLobby m_returnLobby;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b m_btnReturnLobby;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			if (movieClip.name.Contains(m_strLinePrefix))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				string name = movieClip.name;
				char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = '_';
				string[] array2 = name.Split(array);
				string value = array2[array2.Length - 1];
				int num = Convert.ToInt32(value);
				if (num >= 1)
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
					if (num <= m_SummaryItemArray.Length)
					{
						m_SummaryItemArray[num - 1] = new SummaryItem();
						m_SummaryItemArray[num - 1].c130648b59a0c8debea60aa153f844879(movieClip, "normal", cbe803aa457a8311ef24963f141c06f73.c7088de59e49f7108f520cf7e0bae167e);
						m_SummaryItemArray[num - 1].c130648b59a0c8debea60aa153f844879(movieClip, "myline", cbe803aa457a8311ef24963f141c06f73.c7088de59e49f7108f520cf7e0bae167e);
						movieClip.visible = false;
						result = true;
						goto IL_0149;
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
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "PVP_HUD.swf:ScoreBoard   Wrong MovieClip index : " + movieClip.name);
				return result;
			}
			if (movieClip.name == "mcReturnLobby")
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
				m_btnReturnLobby = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
				m_btnReturnLobby.c130648b59a0c8debea60aa153f844879(movieClip);
				m_btnReturnLobby.addEventListener(MouseEvent.CLICK, cf032d831d0a7c0b81e5c495cdf6931a2);
			}
			goto IL_0149;
			IL_0149:
			return result;
		}

		public void c40b5bc409cf38b17f8cc13dd745279ee(List<StatisticsManager.StatSheet> cf88105fa1080da7ad31590d7de60ae5a)
		{
			int count = cf88105fa1080da7ad31590d7de60ae5a.Count;
			string text = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409();
			for (int i = 0; i < m_SummaryItemArray.Length; i++)
			{
				if (i < count)
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
					m_SummaryItemArray[i].c785dc99f380e21252755b1fcda3d67f0(cf88105fa1080da7ad31590d7de60ae5a[i], i + 1);
					m_SummaryItemArray[i].ca1272bcb3438d16f27c027b94532d7e0(cf88105fa1080da7ad31590d7de60ae5a[i].m_name == text);
					m_SummaryItemArray[i].c43cbb41bf755dfa61de619fc6e86ab31(true);
				}
				else
				{
					m_SummaryItemArray[i].c43cbb41bf755dfa61de619fc6e86ab31(false);
				}
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

		public void c43cbb41bf755dfa61de619fc6e86ab31(bool c8b64aef39806bef0c330f87521f7b940)
		{
			MovieClip movieClip = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (c8b64aef39806bef0c330f87521f7b940)
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
						movieClip.gotoAndPlay("fadein");
						movieClip.visible = true;
						return;
					}
				}
			}
			movieClip.visible = false;
		}

		public void c55907b671469545b97b0f6a3d888cc69(Delegate_ReturnLobby cfc14651b88662559358baa00bf137aba)
		{
			m_returnLobby = cfc14651b88662559358baa00bf137aba;
		}

		protected void cf032d831d0a7c0b81e5c495cdf6931a2(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			m_returnLobby();
		}
	}

	public class SummaryItem : c196099a1254db61d3be10d70e14e7422
	{
		protected bool m_bIsLocalPlayer;

		public void c43cbb41bf755dfa61de619fc6e86ab31(bool c8b64aef39806bef0c330f87521f7b940)
		{
			(ca37fcdce7d4937b60735f4033eb55695 as MovieClip).visible = c8b64aef39806bef0c330f87521f7b940;
		}

		public void ca1272bcb3438d16f27c027b94532d7e0(bool c303d6a858dfd020772297b64fc2b7030)
		{
			if (m_bIsLocalPlayer == c303d6a858dfd020772297b64fc2b7030)
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
				if (c303d6a858dfd020772297b64fc2b7030)
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
					(ca37fcdce7d4937b60735f4033eb55695 as MovieClip).gotoAndPlay("myline");
				}
				else
				{
					(ca37fcdce7d4937b60735f4033eb55695 as MovieClip).gotoAndPlay("normal");
				}
				m_bIsLocalPlayer = c303d6a858dfd020772297b64fc2b7030;
				return;
			}
		}

		public void c785dc99f380e21252755b1fcda3d67f0(StatisticsManager.StatSheet c5ea65450b74a8ce2c1741f2c7b3d6017, int c4e278a539e18dfd9b06dd3e3b8958a40)
		{
			MovieClip movieClip = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			movieClip.visible = true;
			movieClip.getChildByName<TextField>("text_playername").text = c5ea65450b74a8ce2c1741f2c7b3d6017.m_name;
			movieClip.getChildByName<TextField>("text_score").text = Convert.ToString(c5ea65450b74a8ce2c1741f2c7b3d6017.m_score);
			movieClip.getChildByName<TextField>("text_killcount").text = Convert.ToString(c5ea65450b74a8ce2c1741f2c7b3d6017.m_killCount);
			movieClip.getChildByName<TextField>("text_deathcount").text = Convert.ToString(c5ea65450b74a8ce2c1741f2c7b3d6017.m_deathcount);
			movieClip.getChildByName<TextField>("text_exp").text = Convert.ToString(c5ea65450b74a8ce2c1741f2c7b3d6017.m_score);
			if (c4e278a539e18dfd9b06dd3e3b8958a40 == 1)
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
						movieClip.getChildByName<TextField>("text_ranklist").text = "1st";
						return;
					}
				}
			}
			if (c4e278a539e18dfd9b06dd3e3b8958a40 == 2)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						movieClip.getChildByName<TextField>("text_ranklist").text = "2nd";
						return;
					}
				}
			}
			if (c4e278a539e18dfd9b06dd3e3b8958a40 == 3)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						movieClip.getChildByName<TextField>("text_ranklist").text = "3rd";
						return;
					}
				}
			}
			movieClip.getChildByName<TextField>("text_ranklist").text = Convert.ToString(c4e278a539e18dfd9b06dd3e3b8958a40) + "th";
		}
	}

	public delegate void Delegate_ReturnLobby();

	protected ScoreBoard m_ScoreBoard;

	protected SummaryBoard m_SummaryBoard;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("PVP_HUD.swf", "ScoreBoard", c45da093a99d4c1f8e5b2169a1e3376f1);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("PVP_HUD.swf", "RankBoard", c52261b9ec7a46d285814d9b43570e141);
	}

	private void c45da093a99d4c1f8e5b2169a1e3376f1(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		m_ScoreBoard = new ScoreBoard();
		m_ScoreBoard.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8, "normal", cbe803aa457a8311ef24963f141c06f73.c7088de59e49f7108f520cf7e0bae167e);
		m_ScoreBoard.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8, "fadeout", cbe803aa457a8311ef24963f141c06f73.c7088de59e49f7108f520cf7e0bae167e);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.visible = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(m_ScoreBoard);
	}

	private void c52261b9ec7a46d285814d9b43570e141(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		m_SummaryBoard = new SummaryBoard();
		m_SummaryBoard.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8, "fadein", cbe803aa457a8311ef24963f141c06f73.c7088de59e49f7108f520cf7e0bae167e);
		m_SummaryBoard.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8, "normal", cbe803aa457a8311ef24963f141c06f73.c7088de59e49f7108f520cf7e0bae167e);
		m_SummaryBoard.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8, "fadeout", cbe803aa457a8311ef24963f141c06f73.c7088de59e49f7108f520cf7e0bae167e);
		m_SummaryBoard.c55907b671469545b97b0f6a3d888cc69(base.c8764d38baaff094368eb4fed91f2e592);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.visible = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(m_SummaryBoard);
	}

	public override void c4b79dd2406b9a346ab9d6050a383ffb4(StatisticsManager.StatSheet[] c912f5d0ee7cccfc3d9bfe9cd831d54a7)
	{
		base.c4b79dd2406b9a346ab9d6050a383ffb4(c912f5d0ee7cccfc3d9bfe9cd831d54a7);
		cf0fa6c8aa6b2ef4abd7303b5b9b8d636();
	}

	public override void c9c6080e1b1663d026afd1cc2c9b9a906(StatisticsManager.StatSheet[] c09ca635c6106f923fefa1dc01370ac42)
	{
		base.c9c6080e1b1663d026afd1cc2c9b9a906(c09ca635c6106f923fefa1dc01370ac42);
		List<StatisticsManager.StatSheet> list = new List<StatisticsManager.StatSheet>();
		for (int i = 0; i < c09ca635c6106f923fefa1dc01370ac42.Length; i++)
		{
			if (c09ca635c6106f923fefa1dc01370ac42[i].m_name == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			list.Add(c09ca635c6106f923fefa1dc01370ac42[i]);
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			list.Sort(base.ca33854696368819ae699ceaa1aab640f);
			MovieClip movieClip = m_SummaryBoard.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			movieClip.visible = true;
			movieClip.gotoAndPlay("fadein");
			m_SummaryBoard.c40b5bc409cf38b17f8cc13dd745279ee(list);
			return;
		}
	}

	public override void c2061c84033e144e4c9761c26f0ee9a5d(bool c8be1fcd630e5fe96821376d111325750)
	{
		if (m_bScoreBoardVisible == c8be1fcd630e5fe96821376d111325750)
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
		m_bScoreBoardVisible = c8be1fcd630e5fe96821376d111325750;
		MovieClip movieClip = m_ScoreBoard.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
		if (c8be1fcd630e5fe96821376d111325750)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					movieClip.gotoAndPlay("normal");
					movieClip.visible = true;
					return;
				}
			}
		}
		movieClip.gotoAndPlay("fadeout");
	}

	protected void cf0fa6c8aa6b2ef4abd7303b5b9b8d636()
	{
		m_ScoreBoard.c40b5bc409cf38b17f8cc13dd745279ee(m_scoreCardList);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(m_ScoreBoard);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(m_SummaryBoard);
		m_ScoreBoard = null;
		m_SummaryBoard = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("PVP_HUD.swf");
	}
}
