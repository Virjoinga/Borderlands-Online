using System.Collections.Generic;
using A;
using UnityEngine;
using XsdSettings;

public class PauseMenuView : BaseView
{
	public enum EscMenuFunction
	{
		BackToGame = 0,
		ReplayTutorial = 1,
		GameOptions = 2,
		QuitInstance = 3,
		Respawn = 4,
		ExitGame = 5
	}

	public enum EscMenuState
	{
		Root = 0,
		Options = 1
	}

	protected EscMenuState _curState;

	protected GameSettingMgr.SettingItemData _onProcessingData;

	protected Dictionary<SettingCategory, List<GameSettingMgr.SettingItemData>> _dicSettingsByCategory = new Dictionary<SettingCategory, List<GameSettingMgr.SettingItemData>>();

	protected bool _bWaitingForInput;

	protected bool _bIsPrimaryKey;

	protected bool _bEnable = true;

	protected bool _bRespawnEnable = true;

	protected bool _bLeaveInstanceEnable = true;

	protected bool _bReplayTutorialEnable = true;

	public bool c67b28f11a75cd869d2f715f541128e09
	{
		get
		{
			return _bEnable;
		}
		set
		{
			if (c150264a18c2cb408479d3f072cac8cc1)
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
				c150264a18c2cb408479d3f072cac8cc1 = false;
			}
			_bEnable = value;
		}
	}

	public override bool c57b6c6861c1d709f4f7aa7b8a699b5c9()
	{
		return false;
	}

	public override void OnTestGUI()
	{
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cbfdeda957ab87de3d0acf25194e61c4c(this);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c914f3898d0cb85fdb88383c5a243cded(this);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c239889f6079aa61647e3c4b8f3627d00(c12b196ef16d3d89b666906481f435d35);
		_dicSettingsByCategory = c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c2fe4b25baec7aa8444d50ef50a249e27();
		_bEnable = true;
		int bRespawnEnable;
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			bRespawnEnable = ((!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa()) ? 1 : 0);
		}
		else
		{
			bRespawnEnable = 0;
		}
		_bRespawnEnable = (byte)bRespawnEnable != 0;
		int bLeaveInstanceEnable;
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			bLeaveInstanceEnable = ((!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cd3175a878e297c0e31b1ccfc0307f2b4()) ? 1 : 0);
		}
		else
		{
			bLeaveInstanceEnable = 0;
		}
		_bLeaveInstanceEnable = (byte)bLeaveInstanceEnable != 0;
		_bReplayTutorialEnable = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51();
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cfdafa122fc114376585cbb27b8811a86(this);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c0f8db058f30b85298d876c68b2ca7053(this);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c0bd653723f77fd78e6c7d4d25ed14dcd(c12b196ef16d3d89b666906481f435d35);
		_dicSettingsByCategory = c1251d3477d7e708857cd80a40c0cb104.c7088de59e49f7108f520cf7e0bae167e;
		_bEnable = false;
	}

	public override bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		if (!_bEnable)
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
					return false;
				}
			}
		}
		if (c150264a18c2cb408479d3f072cac8cc1)
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
			if (c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c645e159b14c940d3fb6c0970dff95827())
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						c4c9df40759d8b2c274ca175c00b254b9();
						return true;
					}
				}
			}
		}
		c150264a18c2cb408479d3f072cac8cc1 = !c150264a18c2cb408479d3f072cac8cc1;
		return true;
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (c8be1fcd630e5fe96821376d111325750)
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
			c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9c468c80f530b448d1ac8906148c9a2();
			ce269ba343b870fb2522da1974bf87490(EscMenuState.Root);
		}
		else
		{
			c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c0d2abbe8042d63a7b888a59e687a440a();
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = !c8be1fcd630e5fe96821376d111325750;
	}

	protected void c12b196ef16d3d89b666906481f435d35()
	{
		if (!_bWaitingForInput)
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
			KeyCode keyCode = c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c9c68d4ce4ddf219f5a364d5155b6555c();
			InputManager.InputKeyBinding keyBinding = _onProcessingData.newValue.keyBinding;
			if (keyCode == KeyCode.None)
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
				if (keyCode != 0)
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
					if (_bIsPrimaryKey)
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
						keyBinding.primaryKey = keyCode;
					}
					else
					{
						keyBinding.seconderyKey = keyCode;
					}
				}
				else if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0c86fb4d044c654b1e26019953887548("Delete"))
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
					if (_bIsPrimaryKey)
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
						keyBinding.primaryKey = KeyCode.None;
					}
					else
					{
						keyBinding.seconderyKey = KeyCode.None;
					}
				}
				c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c239cb24a0f61f5bdbbe34f8bc97732bc(_onProcessingData.controlAction.ToString(), keyBinding.primaryKey, keyBinding.seconderyKey);
				_onProcessingData.bDirty = true;
				_bWaitingForInput = false;
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cfd58c94350618be817cfdb449a158aad();
				ce269ba343b870fb2522da1974bf87490(EscMenuState.Options);
				return;
			}
		}
	}

	protected virtual void ce269ba343b870fb2522da1974bf87490(EscMenuState c7d77be03dd09783b7cf45209bd57d03e)
	{
	}

	protected virtual void c76647445a81350a21a12e1ec5fbb0052()
	{
		c150264a18c2cb408479d3f072cac8cc1 = false;
	}

	protected void c3c93178f481a47abf762c1dec2ac4983()
	{
	}

	protected void ca64bc613abd7b2015fc221b5af350e0d()
	{
		c150264a18c2cb408479d3f072cac8cc1 = false;
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86)
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
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
				GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c3bdf56faf210277f6d5c501ade8fad5f(c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
				c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cec9cdae23444bbac5cad953e7fc1f8e9();
				return;
			}
		}
	}

	protected void cc0f6d906592b43fa741d36fb2c491011()
	{
		if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86)
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
			if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
				SessionInfo.c5ee19dc8d4cccf5ae2de225410458b86.c8e04fd0fdea380e207956035c9f9da5b();
			}
		}
		c150264a18c2cb408479d3f072cac8cc1 = false;
	}

	protected void cccec04cc6c3f4e3451c437d02a02d30c()
	{
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c72a5f2477f9a9a1490ac1711fe849b07();
	}

	protected void cea93a0f84d44233bf81f22d9265be856()
	{
		c150264a18c2cb408479d3f072cac8cc1 = false;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.c5a4ebf25aa046ef293fa9ea449fcbb09();
	}

	protected void cd029737dbbe5a57b54eb2fed49d5ce2c()
	{
		_bWaitingForInput = true;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Message_PressNewKey")), null, cbeb47692773facf72bbba031b1883666);
	}

	protected void cfc3ea7a686dc064633f50ebf49df930c()
	{
		_bWaitingForInput = false;
	}

	protected void cbeb47692773facf72bbba031b1883666()
	{
		_bWaitingForInput = false;
	}

	protected void c574a55fdda6ab4db2f0c15073868fc47()
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Warning_ResetAllKeys")), c5713a17ba16fdf4ca9a9e1b743983c51, cbeb47692773facf72bbba031b1883666);
	}

	protected void c5713a17ba16fdf4ca9a9e1b743983c51()
	{
		c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cbe349de0b5402dfd2f6c96aa50be7175();
		ce269ba343b870fb2522da1974bf87490(EscMenuState.Options);
	}

	protected void cb8cf0edccd9185292778ba8fe4933fa5()
	{
	}

	protected void c4c9df40759d8b2c274ca175c00b254b9()
	{
		string cad8d6e0a594ee2e7b3f487fb75cd3d = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("OPTION_CONFIRMATION"));
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(cad8d6e0a594ee2e7b3f487fb75cd3d, c7f8079dc3770c96b7c730aac6b494388, c92f842d0c94095220f40eceb37ba313d);
	}

	protected void c7f8079dc3770c96b7c730aac6b494388()
	{
		c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.cba9a1d533f296a781d1a6f5df178eb4a();
		ce269ba343b870fb2522da1974bf87490(EscMenuState.Root);
	}

	protected void c92f842d0c94095220f40eceb37ba313d()
	{
		c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ca065b101124effd962c1722e232bfef8();
		c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9c468c80f530b448d1ac8906148c9a2();
		ce269ba343b870fb2522da1974bf87490(EscMenuState.Root);
	}

	protected void c6a70fd9feff88d029afec071ee28a14b(GameSettingMgr.SettingItemData c6887d67d8a0ccf1b733f90ce230cfbc1)
	{
		if (c6887d67d8a0ccf1b733f90ce230cfbc1 == null)
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
		if (c6887d67d8a0ccf1b733f90ce230cfbc1.type != 0)
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
			if (c6887d67d8a0ccf1b733f90ce230cfbc1.config == null)
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
				SettingFunctionType mFunctionType = c6887d67d8a0ccf1b733f90ce230cfbc1.config.mFunctionType;
				if (mFunctionType != SettingFunctionType.ReplayTutorial)
				{
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
				c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c72a5f2477f9a9a1490ac1711fe849b07();
				return;
			}
		}
	}

	protected void caa333e802fda46f16bea83331fc54e91()
	{
		c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.cba9a1d533f296a781d1a6f5df178eb4a();
		c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9c468c80f530b448d1ac8906148c9a2();
	}

	protected void cc979c27f27a50500a198b3df3dc3de5b(SettingCategory ccc12d01a2caed4c0bee1fb76f94cbefa)
	{
		c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.cdc7e489b7c407c7945b1a30f95c525c8(ccc12d01a2caed4c0bee1fb76f94cbefa);
		c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9c468c80f530b448d1ac8906148c9a2();
		ce269ba343b870fb2522da1974bf87490(EscMenuState.Options);
	}
}
