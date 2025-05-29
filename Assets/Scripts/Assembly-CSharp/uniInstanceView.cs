using A;
using Core;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniInstanceView : InstanceView
{
	private class InstanceButton : c82f7c0afbcfc8c5382a8c6daa9365b7b
	{
		public MovieClip mc_root;

		public MovieClip mc_QuestTrack;

		public TextField tf_InstanceLevel;

		public string m_strContent = string.Empty;

		public Color m_color = Color.white;

		public bool m_bShowQuestTrack;

		public bool m_bShowDailyQuestTrack;

		protected override void c9f8eeb310eab54c590c996dd8e63e346()
		{
			base.c9f8eeb310eab54c590c996dd8e63e346();
			Update();
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mc_root = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			mc_QuestTrack = mc_root.getChildByName<MovieClip>("mc_QuestTrack");
			tf_InstanceLevel = mc_root.getChildByName<TextField>("tf_DifficultyTips");
			mc_root.addEventListener(CEvent.ENTER_FRAME, c12b196ef16d3d89b666906481f435d35);
		}

		protected void c12b196ef16d3d89b666906481f435d35(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			Update();
		}

		public void c17dcae1546a28dc174f875d88ef705a8(string c8d66b12b22e9ec7ce9c17caaaadbe2e5)
		{
			mc_QuestTrack.gotoAndStop(c8d66b12b22e9ec7ce9c17caaaadbe2e5);
		}

		private void Update()
		{
			if (!m_bShowQuestTrack)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (!m_bShowDailyQuestTrack)
				{
					mc_QuestTrack.visible = false;
					goto IL_0047;
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
			}
			mc_QuestTrack.visible = true;
			goto IL_0047;
			IL_0047:
			tf_InstanceLevel.textFormat.color = m_color;
			tf_InstanceLevel.text = m_strContent;
		}
	}

	private class InstancePanel : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_root;

		public MovieClip mc_Top;

		public MovieClip mc_Bottom;

		public InstanceButton _CommonBtn;

		public InstanceButton _HeroBtn;

		public InstanceButton _HellBtn;

		public MovieClip mc_BossClip;

		public MovieClip mc_BossName;

		public MovieClip mc_BossNameEffect;

		public TextField tf_Description;

		private int m_nSelectInstanceId;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mc_root != null)
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
							return mc_root.visible;
						}
					}
				}
				return false;
			}
			set
			{
				if (mc_root == null)
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
					if (value)
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
						c6e60c2fee70e34d9216b0c5ccef9e96f();
					}
					mc_Top.visible = value;
					mc_root.visible = value;
					return;
				}
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mc_root = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mc_root == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: InstancePanel onInit() 'mc_root' is null! InstancePanel won't work!!!");
						return;
					}
				}
			}
			mc_Top = mc_root.getChildByName<MovieClip>("mc_top");
			mc_Bottom = mc_root.getChildByName<MovieClip>("mcNPCDialog");
			mc_Top.visible = false;
			mc_Bottom.visible = false;
			_CommonBtn = new InstanceButton();
			_CommonBtn.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_Common_Button"));
			_CommonBtn.addEventListener(MouseEvent.CLICK, c92fc275f094b162c1660c6e90ab0df54);
			_CommonBtn.c150264a18c2cb408479d3f072cac8cc1 = false;
			_HeroBtn = new InstanceButton();
			_HeroBtn.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_Hero_Button"));
			_HeroBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			_HeroBtn.addEventListener(MouseEvent.CLICK, c1d50fee13de2a58b59d4abf3d7d419ce);
			_HeroBtn.c150264a18c2cb408479d3f072cac8cc1 = false;
			_HellBtn = new InstanceButton();
			_HellBtn.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_Hell_Button"));
			_HellBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			_HellBtn.addEventListener(MouseEvent.CLICK, c363848a9494899923781c17a0e944480);
			_HellBtn.c150264a18c2cb408479d3f072cac8cc1 = false;
			mc_BossClip = mc_Bottom.getChildByName<MovieClip>("mc_speical");
			tf_Description = mc_Bottom.getChildByName<TextField>("textDescription");
			mc_BossClip.stopAll();
			mc_BossName = mc_BossClip.getChildByName<MovieClip>("mc_bossName");
			mc_BossNameEffect = mc_BossClip.getChildByName<MovieClip>("mc_bossnameEffect");
		}

		public void c27cf1b53196bc572070383b92d74e95d()
		{
			mc_root.visible = true;
			mc_Top.visible = true;
			mc_root.gotoAndStop(1);
		}

		public void ca87cffae0818e55a54d063c924b4b310()
		{
			mc_Top.visible = false;
			mc_root.visible = false;
		}

		private void c6e60c2fee70e34d9216b0c5ccef9e96f()
		{
			c2a1f45e0392a0e9d068240b98aee0484();
			switch (LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().c18d0e40d91f45fe30c88eb7febeda940(InstanceBehaviour.c1a605e22757a2d6d1113ddab3d23567a()))
			{
			case 0:
				_CommonBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
				_HeroBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
				_HellBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
				break;
			case 1:
				_CommonBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
				_HeroBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
				_HellBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
				break;
			case 2:
			case 3:
				_CommonBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
				_HeroBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
				_HellBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
				break;
			default:
				_CommonBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
				_HeroBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
				_HellBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
				break;
			}
			NpcTitleMgr.NPC_ICON_TYPE nPC_ICON_TYPE = QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().ca481ed3c1b498d8142b62adaf2d68067(InstanceBehaviour.c1a605e22757a2d6d1113ddab3d23567a(), 0);
			if (nPC_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
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
				_CommonBtn.m_bShowQuestTrack = true;
				_CommonBtn.m_bShowDailyQuestTrack = false;
				_CommonBtn.c17dcae1546a28dc174f875d88ef705a8("normal");
			}
			else if (nPC_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE)
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
				_CommonBtn.m_bShowQuestTrack = false;
				_CommonBtn.m_bShowDailyQuestTrack = true;
				_CommonBtn.c17dcae1546a28dc174f875d88ef705a8("daily");
			}
			else
			{
				_CommonBtn.m_bShowQuestTrack = false;
				_CommonBtn.m_bShowDailyQuestTrack = false;
			}
			NpcTitleMgr.NPC_ICON_TYPE nPC_ICON_TYPE2 = QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().ca481ed3c1b498d8142b62adaf2d68067(InstanceBehaviour.c1a605e22757a2d6d1113ddab3d23567a(), 1);
			if (nPC_ICON_TYPE2 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
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
				_HeroBtn.m_bShowQuestTrack = true;
				_HeroBtn.m_bShowDailyQuestTrack = true;
				_HeroBtn.c17dcae1546a28dc174f875d88ef705a8("normal");
			}
			else if (nPC_ICON_TYPE2 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE)
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
				_HeroBtn.m_bShowQuestTrack = false;
				_HeroBtn.m_bShowDailyQuestTrack = true;
				_HeroBtn.c17dcae1546a28dc174f875d88ef705a8("daily");
			}
			else
			{
				_HeroBtn.m_bShowQuestTrack = false;
				_HeroBtn.m_bShowDailyQuestTrack = false;
			}
			NpcTitleMgr.NPC_ICON_TYPE nPC_ICON_TYPE3 = QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().ca481ed3c1b498d8142b62adaf2d68067(InstanceBehaviour.c1a605e22757a2d6d1113ddab3d23567a(), 2);
			if (nPC_ICON_TYPE3 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
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
				_HellBtn.m_bShowQuestTrack = true;
				_HellBtn.m_bShowDailyQuestTrack = false;
				_HellBtn.c17dcae1546a28dc174f875d88ef705a8("normal");
			}
			else if (nPC_ICON_TYPE3 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE)
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
				_HellBtn.m_bShowQuestTrack = false;
				_HellBtn.m_bShowDailyQuestTrack = true;
				_HellBtn.c17dcae1546a28dc174f875d88ef705a8("daily");
			}
			else
			{
				_HellBtn.m_bShowQuestTrack = false;
				_HellBtn.m_bShowDailyQuestTrack = false;
			}
			Playlist playlist = MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c2718b579e09549a1cd47620188a40a38(InstanceBehaviour.c1a605e22757a2d6d1113ddab3d23567a());
			int normal_LevelMin = playlist.m_normal_LevelMin;
			int hard_LevelMin = playlist.m_hard_LevelMin;
			int hell_LevelMin = playlist.m_hell_LevelMin;
			int cdc506bba956023baa6dd9e64f3955b = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7513e66c4e0fc55e6fea9dd9cb8b9943();
			cf4a123b21559200fb4412df870a31d7f(_CommonBtn, cdc506bba956023baa6dd9e64f3955b, normal_LevelMin);
			cf4a123b21559200fb4412df870a31d7f(_HeroBtn, cdc506bba956023baa6dd9e64f3955b, hard_LevelMin);
			cf4a123b21559200fb4412df870a31d7f(_HellBtn, cdc506bba956023baa6dd9e64f3955b, hell_LevelMin);
		}

		private void cf4a123b21559200fb4412df870a31d7f(InstanceButton cc5b2a83f0ff489309eb5bc89970fb973, int cdc506bba956023baa6dd9e64f3955b64, int c4ace84bc4ae49374d12b438b4e920e62)
		{
			if (cdc506bba956023baa6dd9e64f3955b64 - c4ace84bc4ae49374d12b438b4e920e62 >= 5)
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
				cc5b2a83f0ff489309eb5bc89970fb973.m_color = Color.grey;
			}
			else
			{
				if (cdc506bba956023baa6dd9e64f3955b64 - c4ace84bc4ae49374d12b438b4e920e62 >= 2)
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
					if (cdc506bba956023baa6dd9e64f3955b64 - c4ace84bc4ae49374d12b438b4e920e62 <= 4)
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
						cc5b2a83f0ff489309eb5bc89970fb973.m_color = Color.green;
						goto IL_00dd;
					}
				}
				if (cdc506bba956023baa6dd9e64f3955b64 - c4ace84bc4ae49374d12b438b4e920e62 >= -1)
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
					if (cdc506bba956023baa6dd9e64f3955b64 - c4ace84bc4ae49374d12b438b4e920e62 <= 1)
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
						cc5b2a83f0ff489309eb5bc89970fb973.m_color = Color.yellow;
						goto IL_00dd;
					}
				}
				if (cdc506bba956023baa6dd9e64f3955b64 - c4ace84bc4ae49374d12b438b4e920e62 >= -4)
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
					if (cdc506bba956023baa6dd9e64f3955b64 - c4ace84bc4ae49374d12b438b4e920e62 <= -2)
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
						cc5b2a83f0ff489309eb5bc89970fb973.m_color = Color.Lerp(Color.red, Color.yellow, 0.5f);
						goto IL_00dd;
					}
				}
				cc5b2a83f0ff489309eb5bc89970fb973.m_color = Color.red;
			}
			goto IL_00dd;
			IL_00dd:
			cc5b2a83f0ff489309eb5bc89970fb973.m_strContent = "Lv." + c4ace84bc4ae49374d12b438b4e920e62;
		}

		private void c2a1f45e0392a0e9d068240b98aee0484()
		{
			if (!_CommonBtn.hasEventListener("onClickCommonButton"))
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
				_CommonBtn.addEventListener(MouseEvent.CLICK, c92fc275f094b162c1660c6e90ab0df54);
			}
			if (!_HeroBtn.hasEventListener("onClickHeroButton"))
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
				_HeroBtn.addEventListener(MouseEvent.CLICK, c1d50fee13de2a58b59d4abf3d7d419ce);
			}
			if (_HellBtn.hasEventListener("onClickHellButton"))
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
				_HellBtn.addEventListener(MouseEvent.CLICK, c363848a9494899923781c17a0e944480);
				return;
			}
		}

		private void c6a7d7774a886c5636c01ea8aea489f8d()
		{
			_CommonBtn.removeEventListener(MouseEvent.CLICK, c92fc275f094b162c1660c6e90ab0df54);
			_HeroBtn.removeEventListener(MouseEvent.CLICK, c1d50fee13de2a58b59d4abf3d7d419ce);
			_HellBtn.removeEventListener(MouseEvent.CLICK, c363848a9494899923781c17a0e944480);
		}

		private void c92fc275f094b162c1660c6e90ab0df54(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cefe421697a3bbbea5cbd44ad193a066d(InstanceBehaviour.c1a605e22757a2d6d1113ddab3d23567a(), 0);
		}

		private void c1d50fee13de2a58b59d4abf3d7d419ce(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cefe421697a3bbbea5cbd44ad193a066d(InstanceBehaviour.c1a605e22757a2d6d1113ddab3d23567a(), 1);
		}

		private void c363848a9494899923781c17a0e944480(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cefe421697a3bbbea5cbd44ad193a066d(InstanceBehaviour.c1a605e22757a2d6d1113ddab3d23567a(), 2);
		}

		private void cefe421697a3bbbea5cbd44ad193a066d(int c717dab0494f3f0f159b8bd8bc7c8b729, int c7486913f1565c2422cca435709ed0d68)
		{
			if (c717dab0494f3f0f159b8bd8bc7c8b729 == 0)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_difficulty = (ELevelDifficulty)c7486913f1565c2422cca435709ed0d68;
				m_nSelectInstanceId = c717dab0494f3f0f159b8bd8bc7c8b729;
				c6a7d7774a886c5636c01ea8aea489f8d();
				cccc843b3926f1286a2f7113e8d84a602();
				return;
			}
		}

		public void c23ffb495db7c9da62404f1cc24a67351()
		{
			mc_Bottom.visible = true;
			_CommonBtn.c150264a18c2cb408479d3f072cac8cc1 = true;
			_HeroBtn.c150264a18c2cb408479d3f072cac8cc1 = true;
			_HellBtn.c150264a18c2cb408479d3f072cac8cc1 = true;
			c6e60c2fee70e34d9216b0c5ccef9e96f();
			mc_root.gotoAndPlay("fadein");
			tf_Description.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Instance_" + InstanceBehaviour.c1a605e22757a2d6d1113ddab3d23567a() + "_des"));
			if (InstanceBehaviour.c89a7636a8125a41cf8849c69c2136973())
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						mc_BossClip.gotoAndPlay(1);
						mc_BossName.gotoAndStop(InstanceBehaviour.c57944e4bbc6cec134bb74186f64f35a5());
						mc_BossNameEffect.gotoAndStop(InstanceBehaviour.c57944e4bbc6cec134bb74186f64f35a5());
						return;
					}
				}
			}
			mc_BossClip.gotoAndStop(1);
		}

		public void cccc843b3926f1286a2f7113e8d84a602()
		{
			TownInstanceSelectionControl.c2f18a3b5ccc9813ca1b7e1fcfcffdc75(false);
			mc_root.gotoAndPlay("fadeout");
			mc_root.addFrameScript("fadeoutEnd", ca45aa4038153928bb3c25fc71e6c45e1);
		}

		private void ca45aa4038153928bb3c25fc71e6c45e1(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mc_root.removeFrameScript("fadeoutEnd", ca45aa4038153928bb3c25fc71e6c45e1);
			mc_root.visible = false;
			InstanceBehaviour.c08db3656c23a73a47b1a938945909eac();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceView>().c150264a18c2cb408479d3f072cac8cc1 = false;
			c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5("80001");
			LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c4909d1c0768ec3bfe69de624ebc2ff32(m_nSelectInstanceId);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().m_gameMode = GamemodeType.GamemodePvE;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().c150264a18c2cb408479d3f072cac8cc1 = true;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().ca495c34d792d9b5bb233b4388b3dcb1d();
		}

		public void cce6adadf40a70610ce3ae5dd40479620(bool c833e0f3245c0c3d635f4d49323bef5d8)
		{
			if (c833e0f3245c0c3d635f4d49323bef5d8)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						mc_root.gotoAndPlay("fadeout");
						mc_root.addFrameScript("fadeoutEnd", c64731ac8bb5cc084887d0eaa39fdee64);
						return;
					}
				}
			}
			mc_root.gotoAndPlay("ESC fadeout");
			InstanceBehaviour.c08db3656c23a73a47b1a938945909eac();
		}

		public void c0d3c2b5d6f46d8dea9768d6ae770dd9d()
		{
			mc_BossClip.gotoAndStop(1);
			mc_root.gotoAndPlay("btn_fadeout");
			InstanceBehaviour.c08db3656c23a73a47b1a938945909eac();
		}

		private void c64731ac8bb5cc084887d0eaa39fdee64(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mc_root.removeFrameScript("fadeoutEnd", c64731ac8bb5cc084887d0eaa39fdee64);
			mc_root.visible = false;
			InstanceBehaviour.c08db3656c23a73a47b1a938945909eac();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<UniUIManager>().c27542a6dc8f97862ef53db1d4f3a6db8(this);
		}
	}

	private InstancePanel _instancePanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("instanceSelect_Jan2014.swf", "whole", c6113d13a2974cd045607a20c6e1b8582);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_instancePanel);
		_instancePanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("instanceSelect_Jan2014.swf");
	}

	private void c6113d13a2974cd045607a20c6e1b8582(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_instancePanel = new InstancePanel();
		_instancePanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_instancePanel.c150264a18c2cb408479d3f072cac8cc1 = false;
	}

	public override void cfe3722be9d3db53de899f357df1ae081()
	{
		base.cfe3722be9d3db53de899f357df1ae081();
		if (m_bDifficultyShown)
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
			m_bDifficultyShown = true;
			_instancePanel.c23ffb495db7c9da62404f1cc24a67351();
			return;
		}
	}

	public override void c0d3c2b5d6f46d8dea9768d6ae770dd9d()
	{
		base.c0d3c2b5d6f46d8dea9768d6ae770dd9d();
		if (_instancePanel != null)
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
			_instancePanel.c0d3c2b5d6f46d8dea9768d6ae770dd9d();
		}
		m_bDifficultyShown = false;
	}

	public override void cc5441980ac3f22768080730945fcb58e()
	{
		base.cc5441980ac3f22768080730945fcb58e();
		if (_instancePanel != null)
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
			_instancePanel.cce6adadf40a70610ce3ae5dd40479620(m_bDifficultyShown);
		}
		m_bDifficultyShown = false;
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (c8be1fcd630e5fe96821376d111325750)
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<UniUIManager>().cb4341b3564e3d55dc9f38df4b813c5da(_instancePanel);
					_instancePanel.c27cf1b53196bc572070383b92d74e95d();
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<UniUIManager>().c27542a6dc8f97862ef53db1d4f3a6db8(_instancePanel);
	}
}
