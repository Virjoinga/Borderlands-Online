using System;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniTeamMatePortraitView : HUDTeamMatePortraitView
{
	private class TeamMateInfo : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_MateInfo;

		private TextField m_NameField;

		private TextField m_LevelField;

		private MovieClip mc_Icon;

		private MovieClip mc_Sheild;

		private MovieClip mc_Health;

		private MovieClip mc_Shark;

		private MovieClip mc_Captain;

		private MovieClip mc_Status;

		private int m_LastSheild = 1000;

		private int m_LastHP = 1000;

		private bool m_bInited;

		private int m_nCharacterId = -1;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mc_MateInfo = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mc_MateInfo == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: TeamMateInfo onInit() 'mc_MateInfo' is null! TeamMateInfo won't work!!!");
						return;
					}
				}
			}
			mc_Status = mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus");
			m_NameField = mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<TextField>("playername");
			m_LevelField = mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<TextField>("level");
			mc_Icon = mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("icon");
			mc_Sheild = mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("shield");
			mc_Health = mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("health");
			mc_Captain = mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("mc_captain");
			if (mc_Health != null)
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
				mc_Shark = mc_Health.getChildByName<MovieClip>("mc_Shark");
			}
			mc_MateInfo.visible = false;
			mc_Captain.visible = false;
			mc_MateInfo.addEventListener(CEvent.ENTER_FRAME, c263a18e823d534fe933bf797fd17c221);
			mc_MateInfo.addFrameScript("off", cce6adadf40a70610ce3ae5dd40479620);
			m_bInited = true;
			ca37fcdce7d4937b60735f4033eb55695.addEventListener(MouseEvent.CLICK, c08130acd007550718ff046af7741e9c7);
		}

		private void c2edaae0d348e73a4522503a25365b9c4(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6)
		{
			if (mc_Sheild == null)
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
			if (!mc_Sheild.visible)
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
				mc_Sheild.visible = true;
			}
			if (ca78de5e2084d6b058e6ebdc8e85d7fae == 0)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						mc_Sheild.gotoAndStop(100);
						return;
					}
				}
			}
			int num = (int)Math.Ceiling(100.0 * (double)ca78de5e2084d6b058e6ebdc8e85d7fae / (double)ce565b32ce48270d8a80781c7ab11cae6);
			if (num == m_LastSheild)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						if (mc_Sheild.currentFrame != 101 - num)
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									break;
								default:
									mc_Sheild.gotoAndStop(101 - num);
									return;
								}
							}
						}
						return;
					}
				}
			}
			mc_Sheild.gotoAndStop(101 - num);
			m_LastSheild = num;
		}

		private void cab478a9dbd639cc459c21d4e2b0bd54c(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6)
		{
			if (mc_Health == null)
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
						return;
					}
				}
			}
			if (ca78de5e2084d6b058e6ebdc8e85d7fae == 0)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						if (mc_Health.getCurrentFrame() <= 100)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
									mc_Health.gotoAndPlay(101);
									return;
								}
							}
						}
						return;
					}
				}
			}
			int num = (int)Math.Ceiling(100.0 * (double)ca78de5e2084d6b058e6ebdc8e85d7fae / (double)ce565b32ce48270d8a80781c7ab11cae6);
			if (num == m_LastHP)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						if (mc_Health.currentFrame != 101 - num)
						{
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									mc_Health.gotoAndStop(101 - num);
									return;
								}
							}
						}
						return;
					}
				}
			}
			mc_Health.gotoAndStop(101 - num);
			if (m_LastHP > 40)
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
				if (num <= 40)
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
					if (mc_Shark == null)
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
						mc_Shark = mc_Health.getChildByName<MovieClip>("mc_shark");
						mc_Shark.play();
					}
					else if (!mc_Shark.isPlaying)
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
						mc_Shark.play();
					}
				}
			}
			m_LastHP = num;
		}

		private void c08130acd007550718ff046af7741e9c7(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9a04348ee34715fee1de211171471b35(m_nCharacterId);
		}

		private void c263a18e823d534fe933bf797fd17c221(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			try
			{
				m_NameField = mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<TextField>("playername");
				m_LevelField = mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<TextField>("level");
				mc_Icon = mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("icon");
				mc_Sheild = mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("shield");
				mc_Health = mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("health");
				mc_Captain = mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("mc_captain");
			}
			catch
			{
			}
		}

		public void Update(PlayerInfoSync playerInfo)
		{
			if (!m_bInited)
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
			if (playerInfo == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						mc_MateInfo.visible = false;
						return;
					}
				}
			}
			m_nCharacterId = playerInfo.m_characterId;
			if (!mc_MateInfo.visible)
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
				mc_MateInfo.visible = true;
				cd2d87578e397fe6a8d3d350c2a512f51(playerInfo);
				mc_MateInfo.gotoAndPlay("IN");
				mc_MateInfo.addFrameScript("off", cce6adadf40a70610ce3ae5dd40479620);
			}
			if (mc_MateInfo.isPlaying)
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
				cd2d87578e397fe6a8d3d350c2a512f51(playerInfo);
				return;
			}
		}

		public void Update(Presence presence)
		{
			if (!m_bInited)
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
						return;
					}
				}
			}
			if (presence == null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						mc_MateInfo.visible = false;
						return;
					}
				}
			}
			m_nCharacterId = presence.mCharacterId;
			if (!mc_MateInfo.visible)
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
				mc_MateInfo.visible = true;
				cd2d87578e397fe6a8d3d350c2a512f51(presence);
				mc_MateInfo.gotoAndPlay("IN");
				mc_MateInfo.addFrameScript("off", cce6adadf40a70610ce3ae5dd40479620);
			}
			if (mc_MateInfo.isPlaying)
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
				cd2d87578e397fe6a8d3d350c2a512f51(presence);
				return;
			}
		}

		private void cd2d87578e397fe6a8d3d350c2a512f51(Presence c57b01bb713a45dd68b36b4f255e08dff)
		{
			try
			{
				if (c57b01bb713a45dd68b36b4f255e08dff.mIsOnline)
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
					if (mc_Status.currentLabel == "death")
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
						mc_Status.gotoAndStop("normal");
						m_NameField.textFormat.color = Color.white;
						m_LevelField.textFormat.color = Color.white;
					}
				}
				else if (mc_Status.currentLabel == "normal")
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
					mc_Status.gotoAndStop("death");
					m_NameField.textFormat.color = Color.gray;
					m_LevelField.textFormat.color = Color.gray;
				}
				if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().m_nLeaderId == c57b01bb713a45dd68b36b4f255e08dff.mCharacterId)
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
					mc_Captain.visible = true;
				}
				else
				{
					mc_Captain.visible = false;
				}
				if (m_NameField.text != c57b01bb713a45dd68b36b4f255e08dff.mCharacterName)
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
					m_NameField.text = c57b01bb713a45dd68b36b4f255e08dff.mCharacterName;
				}
				if (m_LevelField.text != "LV:" + c57b01bb713a45dd68b36b4f255e08dff.mCharacterLevel)
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
					m_LevelField.text = "LV:" + c57b01bb713a45dd68b36b4f255e08dff.mCharacterLevel;
				}
				AvatarType mAvatarType = c57b01bb713a45dd68b36b4f255e08dff.mAvatarType;
				if (mc_Icon.getFrameLabel(mAvatarType.ToString()) != mc_Icon.currentFrame)
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
					mc_Icon.gotoAndStop(mAvatarType.ToString());
				}
				PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8cf93402888880ff350d877e135603b6(c57b01bb713a45dd68b36b4f255e08dff.mCharacterId);
				if (playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
						{
							EntityShield entityShield = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689().c136b0f223897fdf01d18a9a5e3745433();
							if (entityShield != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								c2edaae0d348e73a4522503a25365b9c4(100, 100);
							}
							else
							{
								c2edaae0d348e73a4522503a25365b9c4(0, 100);
							}
							if (!mc_Sheild.visible)
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
								mc_Sheild.visible = true;
							}
							if (!mc_Health.visible)
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
								mc_Health.visible = true;
							}
							cab478a9dbd639cc459c21d4e2b0bd54c(100, 100);
							return;
						}
						}
					}
				}
				mc_Sheild.visible = false;
				mc_Health.visible = false;
			}
			catch
			{
			}
		}

		private void cd2d87578e397fe6a8d3d350c2a512f51(PlayerInfoSync c25f5f36a54095a8f73d85c7f7b5af196)
		{
			try
			{
				if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().m_nLeaderId == c25f5f36a54095a8f73d85c7f7b5af196.m_characterId)
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
					mc_Captain.visible = true;
				}
				else
				{
					mc_Captain.visible = false;
				}
				if (m_NameField.text != c25f5f36a54095a8f73d85c7f7b5af196.m_name)
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
					m_NameField.text = c25f5f36a54095a8f73d85c7f7b5af196.m_name;
				}
				EquipmentInventoryEntity equipmentInventoryEntity = c25f5f36a54095a8f73d85c7f7b5af196.c66b232dbebded7c7e9a89c1e8bd84689().c5ca38fad98337fc5c7255384b2cd1a86();
				if (!(equipmentInventoryEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					AvatarType c951097a6ef3eb670bc38dce2cd336b7a = c25f5f36a54095a8f73d85c7f7b5af196.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a();
					if (m_LevelField.text != "LV:" + c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(c951097a6ef3eb670bc38dce2cd336b7a, c25f5f36a54095a8f73d85c7f7b5af196.m_exp))
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
						m_LevelField.text = "LV:" + c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(c951097a6ef3eb670bc38dce2cd336b7a, c25f5f36a54095a8f73d85c7f7b5af196.m_exp);
					}
					if (mc_Icon.getFrameLabel(c25f5f36a54095a8f73d85c7f7b5af196.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a().ToString()) != mc_Icon.currentFrame)
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
						mc_Icon.gotoAndStop(c25f5f36a54095a8f73d85c7f7b5af196.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a().ToString());
					}
					c2edaae0d348e73a4522503a25365b9c4(equipmentInventoryEntity.ce7804365a7377021025c46a16aa79db4(), equipmentInventoryEntity.ca937003ba4cbf4130cad1fcc9da2873e());
					cab478a9dbd639cc459c21d4e2b0bd54c(equipmentInventoryEntity.ca2ff7a501878363cb1d5f0472e306620(), equipmentInventoryEntity.ccfad1bf47b003333c5ddd084f14d33e7());
					return;
				}
			}
			catch
			{
				if (!(c25f5f36a54095a8f73d85c7f7b5af196 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					c436878e72c3f41f685182d6752cc29fd();
					return;
				}
			}
		}

		public void c436878e72c3f41f685182d6752cc29fd()
		{
			if (!m_bInited)
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
						return;
					}
				}
			}
			if (!mc_MateInfo.visible)
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
				if (mc_MateInfo.isPlaying)
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
					mc_MateInfo.gotoAndPlay("out");
					mc_MateInfo.addFrameScript("off", cce6adadf40a70610ce3ae5dd40479620);
					return;
				}
			}
		}

		public void cce6adadf40a70610ce3ae5dd40479620(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mc_MateInfo.visible = false;
			mc_MateInfo.removeFrameScript("off", cce6adadf40a70610ce3ae5dd40479620);
		}
	}

	private class TeamMatePortraitPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip mcSelf;

		private bool m_bInitilized;

		private List<TeamMateInfo> m_TeamInfoList = new List<TeamMateInfo>();

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mcSelf != null)
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
							return mcSelf.visible;
						}
					}
				}
				return false;
			}
			set
			{
				if (mcSelf == null)
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
					mcSelf.visible = value;
					return;
				}
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mcSelf == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: TeamMatePortraitPanel onInit() 'mcSelf' is null! TeamMatePortraitPanel won't work!!!");
						return;
					}
				}
			}
			TeamMateInfo teamMateInfo = new TeamMateInfo();
			teamMateInfo.c130648b59a0c8debea60aa153f844879(mcSelf.getChildByName<MovieClip>("MateInfo1"));
			TeamMateInfo teamMateInfo2 = new TeamMateInfo();
			teamMateInfo2.c130648b59a0c8debea60aa153f844879(mcSelf.getChildByName<MovieClip>("MateInfo2"));
			TeamMateInfo teamMateInfo3 = new TeamMateInfo();
			teamMateInfo3.c130648b59a0c8debea60aa153f844879(mcSelf.getChildByName<MovieClip>("MateInfo3"));
			m_TeamInfoList.Add(teamMateInfo);
			m_TeamInfoList.Add(teamMateInfo2);
			m_TeamInfoList.Add(teamMateInfo3);
			m_bInitilized = true;
		}

		public void c44876808e95896388d925e502682f8ea()
		{
			if (!m_bInitilized)
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
				for (int i = 0; i < m_TeamInfoList.Count; i++)
				{
					if (!m_TeamInfoList[i].mc_MateInfo.visible)
					{
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
					m_TeamInfoList[i].c436878e72c3f41f685182d6752cc29fd();
				}
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
		}

		public void cd2d87578e397fe6a8d3d350c2a512f51(Presence c57b01bb713a45dd68b36b4f255e08dff, int c62a53388af21c9e5e206591a30eb9f80, int cda006944e0a48ec273d9f0f39027c415)
		{
			if (!m_bInitilized)
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
			if (c57b01bb713a45dd68b36b4f255e08dff == null)
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
				if (c62a53388af21c9e5e206591a30eb9f80 > m_TeamInfoList.Count - 1)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				m_TeamInfoList[c62a53388af21c9e5e206591a30eb9f80].Update(c57b01bb713a45dd68b36b4f255e08dff);
				if (c62a53388af21c9e5e206591a30eb9f80 != cda006944e0a48ec273d9f0f39027c415 - 1)
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
					if (cda006944e0a48ec273d9f0f39027c415 == m_TeamInfoList.Count)
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
						for (int i = cda006944e0a48ec273d9f0f39027c415; i < m_TeamInfoList.Count; i++)
						{
							m_TeamInfoList[i].c436878e72c3f41f685182d6752cc29fd();
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

		public void cd2d87578e397fe6a8d3d350c2a512f51(PlayerInfoSync c25f5f36a54095a8f73d85c7f7b5af196, int c62a53388af21c9e5e206591a30eb9f80, int cda006944e0a48ec273d9f0f39027c415)
		{
			if (!m_bInitilized)
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
						return;
					}
				}
			}
			if (c25f5f36a54095a8f73d85c7f7b5af196 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (c62a53388af21c9e5e206591a30eb9f80 > m_TeamInfoList.Count - 1)
				{
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
				if (c25f5f36a54095a8f73d85c7f7b5af196.c66b232dbebded7c7e9a89c1e8bd84689() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				if (c25f5f36a54095a8f73d85c7f7b5af196.c66b232dbebded7c7e9a89c1e8bd84689().c5ca38fad98337fc5c7255384b2cd1a86() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_TeamInfoList[c62a53388af21c9e5e206591a30eb9f80].Update(c25f5f36a54095a8f73d85c7f7b5af196);
				if (c62a53388af21c9e5e206591a30eb9f80 != cda006944e0a48ec273d9f0f39027c415 - 1)
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
					if (cda006944e0a48ec273d9f0f39027c415 == m_TeamInfoList.Count)
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
						for (int i = cda006944e0a48ec273d9f0f39027c415; i < m_TeamInfoList.Count; i++)
						{
							m_TeamInfoList[i].c436878e72c3f41f685182d6752cc29fd();
						}
						while (true)
						{
							switch (1)
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

		public void c82f241bb57637ca41c5b6d7848763fcc()
		{
			for (int i = 0; i < m_TeamInfoList.Count; i++)
			{
				m_TeamInfoList[i].mc_MateInfo.y += 40f;
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
				return;
			}
		}

		public void c6810cd9a6a3203151434638da596c1af()
		{
			for (int i = 0; i < m_TeamInfoList.Count; i++)
			{
				m_TeamInfoList[i].mc_MateInfo.y -= 40f;
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
				return;
			}
		}
	}

	private TeamMatePortraitPanel _TeamMatePanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("2014_Team_mate_protrait.swf", "TeamMateInfo", ce694c52464e5b8deb186c7af476dc294);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_TeamMatePanel);
		_TeamMatePanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("2014_Team_mate_protrait.swf");
	}

	private void ce694c52464e5b8deb186c7af476dc294(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_TeamMatePanel = new TeamMatePortraitPanel();
		_TeamMatePanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_TeamMatePanel);
	}

	public override void cd2d87578e397fe6a8d3d350c2a512f51(PlayerInfoSync c25f5f36a54095a8f73d85c7f7b5af196, int c62a53388af21c9e5e206591a30eb9f80, int cda006944e0a48ec273d9f0f39027c415)
	{
		base.cd2d87578e397fe6a8d3d350c2a512f51(c25f5f36a54095a8f73d85c7f7b5af196, c62a53388af21c9e5e206591a30eb9f80, cda006944e0a48ec273d9f0f39027c415);
		if (_TeamMatePanel == null)
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
			_TeamMatePanel.cd2d87578e397fe6a8d3d350c2a512f51(c25f5f36a54095a8f73d85c7f7b5af196, c62a53388af21c9e5e206591a30eb9f80, cda006944e0a48ec273d9f0f39027c415);
			return;
		}
	}

	public override void cd2d87578e397fe6a8d3d350c2a512f51(Presence c57b01bb713a45dd68b36b4f255e08dff, int c62a53388af21c9e5e206591a30eb9f80, int cda006944e0a48ec273d9f0f39027c415)
	{
		base.cd2d87578e397fe6a8d3d350c2a512f51(c57b01bb713a45dd68b36b4f255e08dff, c62a53388af21c9e5e206591a30eb9f80, cda006944e0a48ec273d9f0f39027c415);
		if (_TeamMatePanel == null)
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
			_TeamMatePanel.cd2d87578e397fe6a8d3d350c2a512f51(c57b01bb713a45dd68b36b4f255e08dff, c62a53388af21c9e5e206591a30eb9f80, cda006944e0a48ec273d9f0f39027c415);
			return;
		}
	}

	public override void cbfadbedd34e283c5ad417e3ad4508cbf()
	{
		base.cbfadbedd34e283c5ad417e3ad4508cbf();
		if (_TeamMatePanel == null)
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
			_TeamMatePanel.c44876808e95896388d925e502682f8ea();
			return;
		}
	}

	public override void c36fd4813ad9b975cc3b7ac4bb183989e()
	{
		if (_TeamMatePanel == null)
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
			_TeamMatePanel.c82f241bb57637ca41c5b6d7848763fcc();
			return;
		}
	}

	public override void c79e1bdec2df2e04b5deae501daa2314f()
	{
		if (_TeamMatePanel == null)
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
			_TeamMatePanel.c6810cd9a6a3203151434638da596c1af();
			return;
		}
	}
}
