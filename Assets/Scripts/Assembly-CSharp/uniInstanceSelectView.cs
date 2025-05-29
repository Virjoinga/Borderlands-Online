using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;

public class uniInstanceSelectView : InstanceSelectView
{
	private ShieldHealthPanel mcPlayerInfo;

	private ExpLevelPanel mcLevelInfo;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcQuestBtn;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcInventoryBtn;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcSocialBtn;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcSkillBtn;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcPVPBtn;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcSurviveBtn;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcFriendBtn;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcGroupBtn;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcGuildBtn;

	private MovieClip mcFriend;

	private MovieClip mcGroup;

	private MovieClip mcPvP;

	private MovieClip mcGuild;

	private c196099a1254db61d3be10d70e14e7422 _panel;

	private c196099a1254db61d3be10d70e14e7422 _charInfoPanel;

	[CompilerGenerated]
	private static Dictionary<string, int> _003C_003Ef__switch_0024map5;

	public override bool c57b6c6861c1d709f4f7aa7b8a699b5c9()
	{
		return false;
	}

	public override void OnTestGUI()
	{
		if (!GUI.Button(new Rect(0f, 0f, 300f, 80f), "Goto Class Selection"))
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.ClassSelect, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
			return;
		}
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("InstanceSelect.swf", "InstanceSelectPannel", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("PlayerInfoBar.swf", "ScreenPanel", c3a9fb4b28c3d5f71347e869e1a4003f3);
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_panel = new c196099a1254db61d3be10d70e14e7422();
		_panel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8, OnWidgetInitialized);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_panel);
		ce01b69c1f5aa521b180553e3031278dd(SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cd2a5c391c1d46ff36a39370815c88946, SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c4d24a9cadafffc413bf9c8df83bdec2d);
	}

	private void c3a9fb4b28c3d5f71347e869e1a4003f3(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_charInfoPanel = new c196099a1254db61d3be10d70e14e7422();
		_charInfoPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8, OnWidgetInitialized);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_charInfoPanel);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_panel);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_charInfoPanel);
		_panel = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		_charInfoPanel = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		mcPlayerInfo = c741762d7b2517e6899444b018d2cc6d5.c7088de59e49f7108f520cf7e0bae167e;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("InstanceSelect.swf");
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("PlayerInfoBar.swf");
	}

	public override void cc2c9bc0084750e845c15d14e953c9abd(bool cb2e8e0aee7c4feb88aeece01cf9c5bb1)
	{
		base.cc2c9bc0084750e845c15d14e953c9abd(cb2e8e0aee7c4feb88aeece01cf9c5bb1);
		if (mcSkillBtn == null)
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
			if (!_bSkillBtnEnable)
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
			MovieClip movieClip = mcSkillBtn.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			if (movieClip == null)
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
				if (cb2e8e0aee7c4feb88aeece01cf9c5bb1)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							movieClip.gotoAndPlay("actived");
							return;
						}
					}
				}
				movieClip.gotoAndPlay("up");
				return;
			}
		}
	}

	public override void c3a2c418e6d212d98117efef5f710e5c4(bool c38daa1ecfc4be57f0bab6f15b4488ecc)
	{
		base.c3a2c418e6d212d98117efef5f710e5c4(c38daa1ecfc4be57f0bab6f15b4488ecc);
		if (mcSkillBtn == null)
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
			mcSkillBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = c38daa1ecfc4be57f0bab6f15b4488ecc;
			return;
		}
	}

	public override void c0be25dad7f3b503064fc98b654b8c830(PlayerProperties c25f5f36a54095a8f73d85c7f7b5af196)
	{
		base.c0be25dad7f3b503064fc98b654b8c830(c25f5f36a54095a8f73d85c7f7b5af196);
		AvatarType c951097a6ef3eb670bc38dce2cd336b7a = _playerInfo.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a();
		int num = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c4459dc4cce1d07c3d1484ae8659420f3(c951097a6ef3eb670bc38dce2cd336b7a, _playerInfo.m_level);
		int num2 = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c22535483c584afec3f67e9f95446a8f4(c951097a6ef3eb670bc38dce2cd336b7a, _playerInfo.m_level);
		int num3 = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c22535483c584afec3f67e9f95446a8f4(c951097a6ef3eb670bc38dce2cd336b7a, _playerInfo.m_level + 1);
		int num4 = 120;
		if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86)
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
			if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
				EntityPlayer entityPlayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
				if ((bool)entityPlayer)
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
					EquipmentInventoryEntity equipmentInventoryEntity = entityPlayer.c5ca38fad98337fc5c7255384b2cd1a86();
					if (equipmentInventoryEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						num = equipmentInventoryEntity.ccfad1bf47b003333c5ddd084f14d33e7();
						num4 = equipmentInventoryEntity.ca937003ba4cbf4130cad1fcc9da2873e();
					}
				}
			}
		}
		if (mcPlayerInfo != null)
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
			mcPlayerInfo.cab478a9dbd639cc459c21d4e2b0bd54c(num, num);
			mcPlayerInfo.cb8ad26e2e2615a2600329d5cd8a5b93b(num4, num4);
			mcPlayerInfo.c8a7bf734d0261ddea2b853ec9c8c88ec(_playerInfo.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a());
		}
		if (mcLevelInfo == null)
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
			mcLevelInfo.cb973dc8f0b1d812e85e2c505b0659581(_playerInfo.m_exp - num2, num3 - num2);
			mcLevelInfo.c0be25dad7f3b503064fc98b654b8c830(_playerInfo.m_level, _playerInfo.m_name);
			return;
		}
	}

	public override void cacb0973399bda5328a4e13f27d851fdb(int cd6bb591c33b2ee3ab93e98aa43a6da63)
	{
		base.cacb0973399bda5328a4e13f27d851fdb(cd6bb591c33b2ee3ab93e98aa43a6da63);
		if (!_bActive)
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
			if (mcLevelInfo == null)
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
				mcLevelInfo.cacb0973399bda5328a4e13f27d851fdb(_iLevel);
				return;
			}
		}
	}

	public override void c490e1cdbd91f441f8899c3b557cbc807(bool c74232243aff1dcbf2e8fc243633bb51a)
	{
		base.c490e1cdbd91f441f8899c3b557cbc807(c74232243aff1dcbf2e8fc243633bb51a);
		if (mcPlayerInfo == null)
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
			mcPlayerInfo.c490e1cdbd91f441f8899c3b557cbc807(c74232243aff1dcbf2e8fc243633bb51a);
			return;
		}
	}

	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool result = false;
		string name = movieClip.name;
		if (name != null)
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
			if (_003C_003Ef__switch_0024map5 == null)
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
				Dictionary<string, int> dictionary = new Dictionary<string, int>(11);
				dictionary.Add("mcPlayerInfo", 0);
				dictionary.Add("mcExp", 1);
				dictionary.Add("mcPVPBtn", 2);
				dictionary.Add("mcSurviveBtn", 3);
				dictionary.Add("mcQuestBtn", 4);
				dictionary.Add("mcInventoryBtn", 5);
				dictionary.Add("mcSocialBtn", 6);
				dictionary.Add("mcSkillBtn", 7);
				dictionary.Add("mcFriendBtn", 8);
				dictionary.Add("mcGroupBtn", 9);
				dictionary.Add("mcGuildBtn", 10);
				_003C_003Ef__switch_0024map5 = dictionary;
			}
			int value;
			if (_003C_003Ef__switch_0024map5.TryGetValue(name, out value))
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
				switch (value)
				{
				case 0:
					mcPlayerInfo = new ShieldHealthPanel();
					mcPlayerInfo.c130648b59a0c8debea60aa153f844879(movieClip);
					if (mcPlayerInfo != null)
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
						if (_playerInfo != null)
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
							AvatarType c951097a6ef3eb670bc38dce2cd336b7a = _playerInfo.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a();
							mcPlayerInfo.cb8ad26e2e2615a2600329d5cd8a5b93b(120, 120);
							int num = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c4459dc4cce1d07c3d1484ae8659420f3(c951097a6ef3eb670bc38dce2cd336b7a, c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(c951097a6ef3eb670bc38dce2cd336b7a, _playerInfo.m_level));
							mcPlayerInfo.cab478a9dbd639cc459c21d4e2b0bd54c(num, num);
							mcPlayerInfo.c8a7bf734d0261ddea2b853ec9c8c88ec(_playerInfo.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a());
						}
					}
					result = true;
					break;
				case 1:
					mcLevelInfo = new ExpLevelPanel();
					mcLevelInfo.c130648b59a0c8debea60aa153f844879(movieClip);
					result = true;
					break;
				case 2:
					mcPvP = movieClip.getChildByName<MovieClip>("mc_PvPBlink");
					mcPvP.addFrameScript("blinkEnd", ccb2733c1555fa903b71f21b43a715d49);
					mcPvP.stopAll();
					mcPVPBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcPVPBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					mcPVPBtn.addEventListener(MouseEvent.CLICK, cf5d2604a4dea596154a5a3e585aaa499);
					c93da48f317472e2d30deca60386d9a58();
					result = true;
					break;
				case 3:
					mcSurviveBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcSurviveBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					mcSurviveBtn.addEventListener(MouseEvent.CLICK, c60b9c38c7038b477d00ff9e9be27f777);
					result = true;
					break;
				case 4:
					mcQuestBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcQuestBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					mcQuestBtn.addEventListener(MouseEvent.CLICK, c766d360f65b1d1c35bb2a6285127e016);
					result = true;
					break;
				case 5:
					mcInventoryBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcInventoryBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					mcInventoryBtn.addEventListener(MouseEvent.CLICK, cf0bb7eedad5ddf781eb30ce750dcdd90);
					result = true;
					break;
				case 6:
					mcSocialBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcSocialBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					mcSocialBtn.addEventListener(MouseEvent.CLICK, c4a41cb190081ad946df3617f9ccf97a1);
					mcSocialBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
					result = true;
					break;
				case 7:
					mcSkillBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcSkillBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					mcSkillBtn.addEventListener(MouseEvent.CLICK, cf95248aa8fd855fa2b6f0fd55e086c91);
					mcSkillBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = _bSkillBtnEnable;
					movieClip.addFrameScript("blinkEnd", c6d8ffc847616886ed6c2447ebe6ca5bb);
					movieClip.addFrameScript("up", c6d8ffc847616886ed6c2447ebe6ca5bb);
					cc2c9bc0084750e845c15d14e953c9abd(_bSkillIconBlink);
					result = true;
					break;
				case 8:
					mcFriend = movieClip;
					mcFriend.addFrameScript("blinkEnd", c61a05f194cee9b47c5776c27efc9645a);
					mcFriendBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcFriendBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					mcFriendBtn.addEventListener(MouseEvent.CLICK, c66bf2a7e526960b38942faa60d20870e);
					mcFriendBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
					result = true;
					break;
				case 9:
					mcGroup = movieClip;
					mcGroup.addFrameScript("blinkEnd", c5019ea2659cc1c599e571879ef3a8867);
					mcGroupBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcGroupBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					mcGroupBtn.addEventListener(MouseEvent.CLICK, c8a847ae0d0644f7a28cbf0aec35799ed);
					mcGroupBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
					result = true;
					break;
				case 10:
					mcGuild = movieClip;
					mcGuild.addFrameScript("blinkEnd", c42ad4a1be5c3ff581909c2c471c00755);
					mcGuildBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcGuildBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					mcGuildBtn.addEventListener(MouseEvent.CLICK, c0bcc88a06b4402e27249f73fcc0182d7);
					c70ea5d182c9e880a5ecefda628922302();
					result = true;
					break;
				}
			}
		}
		return result;
	}

	protected void cf5d2604a4dea596154a5a3e585aaa499(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
	{
		c71bb379df7f6732a0d2a58fd758906ec();
	}

	protected void c60b9c38c7038b477d00ff9e9be27f777(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
	{
		c3140d9ab4434d5840a6504ebdea0a751();
	}

	protected void cf0bb7eedad5ddf781eb30ce750dcdd90(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
	{
		ca941d76cfb7334ac495ef56b069b8216();
	}

	protected void c766d360f65b1d1c35bb2a6285127e016(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
	{
		c4a9b98f590a7233b6acd6f9cfbf8faf0();
	}

	protected void c4a41cb190081ad946df3617f9ccf97a1(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
	{
		c12a3a3ab04543d87864d15f907212095();
	}

	protected void cf95248aa8fd855fa2b6f0fd55e086c91(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
	{
		c4b4a94071c5ed1ff1149ac0e483d660b();
	}

	protected void c66bf2a7e526960b38942faa60d20870e(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
	{
		cea868b22606aae02cd67b61c433fa32e();
	}

	protected void c8a847ae0d0644f7a28cbf0aec35799ed(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
	{
		c73d3bb094acb20099875dce423679337();
	}

	protected void c0bcc88a06b4402e27249f73fcc0182d7(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
	{
		cff53e4b907ad13d2815c74c2ce5156dd();
	}

	protected void c6d8ffc847616886ed6c2447ebe6ca5bb(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
	{
		MovieClip movieClip = mcSkillBtn.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
		if (movieClip == null)
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
			if (_bSkillIconBlink)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						movieClip.gotoAndPlay("actived");
						return;
					}
				}
			}
			movieClip.gotoAndPlay("up");
			return;
		}
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		if (_panel == null)
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
			if (_charInfoPanel == null)
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
			base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
			_panel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = _bVisible;
			_charInfoPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = _bVisible;
			return;
		}
	}

	public override void c2c8c844535004da8c81e3bc95e8f5750()
	{
		if (mcGroup == null)
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
			mcGroup.gotoAndPlay("up");
			return;
		}
	}

	public override void cadfb3e35b7330c65cea035fdd80e3962()
	{
		if (mcFriend == null)
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
			mcFriend.gotoAndPlay("up");
			return;
		}
	}

	public override void ccf6f266a84f582fbc9e1b9a4784ed057()
	{
		if (mcGroup == null)
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
			mcGroup.gotoAndPlay("actived");
			return;
		}
	}

	public override void c47904336715d40ce61e78b89d35f292c()
	{
		if (mcGuild == null)
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
			mcGuild.gotoAndPlay("up");
			return;
		}
	}

	protected void c5019ea2659cc1c599e571879ef3a8867(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		ccf6f266a84f582fbc9e1b9a4784ed057();
	}

	public override void cf198707970ccb9ab868e90753613ed18()
	{
		if (mcFriend == null)
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
			mcFriend.gotoAndPlay("actived");
			return;
		}
	}

	public override void cffafea08501b3cd2032f152f0f047ea0()
	{
		if (mcPvP == null)
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
			mcPvP.visible = true;
			mcPvP.gotoAndPlay("actived");
			return;
		}
	}

	public override void c9e01e4a7637451efd443facb83612139()
	{
		if (mcGuild == null)
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
			mcGuild.gotoAndPlay("actived");
			return;
		}
	}

	protected void c42ad4a1be5c3ff581909c2c471c00755(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		c9e01e4a7637451efd443facb83612139();
	}

	public override void cd3edf4455690dc2bca805c557d5cfffd()
	{
		if (mcPvP == null)
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
			FriendManager.c71f6ce28731edfd43c976fbd57c57bea().m_bNewMessageUnread = false;
			mcPvP.stopAll();
			mcPvP.visible = false;
			return;
		}
	}

	protected void c61a05f194cee9b47c5776c27efc9645a(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cf198707970ccb9ab868e90753613ed18();
	}

	protected void ccb2733c1555fa903b71f21b43a715d49(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cffafea08501b3cd2032f152f0f047ea0();
	}

	public override bool c1ec009745cf889298f5dbae973f0cbd7()
	{
		bool flag = base.c1ec009745cf889298f5dbae973f0cbd7();
		return mcFriend.currentFrame >= mcFriend.getFrameLabel("actived");
	}

	public override bool c6882cd92015bfcab69976c46b09f2786()
	{
		bool flag = base.c6882cd92015bfcab69976c46b09f2786();
		int result;
		if (mcPvP.visible)
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
			result = (mcPvP.isPlaying ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public override void c70ea5d182c9e880a5ecefda628922302()
	{
		mcGuildBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
	}

	public override void c93da48f317472e2d30deca60386d9a58()
	{
		if (mcPVPBtn == null)
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
		if (LobbyManager.c71f6ce28731edfd43c976fbd57c57bea() != null)
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
			if (!LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c76154b5d193e30b53344242a665f1fe4())
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea() != null)
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
							if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
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
								if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c8a142a1ecdf6817b0b02b74d6d1c8796())
								{
									while (true)
									{
										switch (7)
										{
										case 0:
											break;
										default:
											mcPVPBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
											return;
										}
									}
								}
							}
						}
						mcPVPBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
						return;
					}
				}
			}
		}
		if (mcPVPBtn.cbf402c82d0fffee7c8f37c98e456b8f8)
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
			mcPVPBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
			if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea() == null)
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
				if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
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
					if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c8a142a1ecdf6817b0b02b74d6d1c8796())
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
						cffafea08501b3cd2032f152f0f047ea0();
						return;
					}
				}
			}
		}
	}
}
