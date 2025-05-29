using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

internal class uniCharacterSelectView : CharacterSelectView
{
	private class CharacterButton : c82f7c0afbcfc8c5382a8c6daa9365b7b
	{
		public void c8fa88a1daa5ca501420e08fdeef7d6c6()
		{
			MovieClip movieClip = c0ffd7f3b3dfe86849f698f744e296ad3.getChildByName("label") as MovieClip;
			TextField textField = movieClip.getChildByName("tfClassLabel") as TextField;
			textField.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("CLASS")) + ":";
			textField = movieClip.getChildByName("tfTimeLabel") as TextField;
			textField.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GAME_TIME")) + ":";
		}

		public void c0b8386688f89d5e57306b329c252b6cb(string cd99af21e22e356018b8f72d4a7e4872a)
		{
			MovieClip movieClip = c0ffd7f3b3dfe86849f698f744e296ad3.getChildByName("label") as MovieClip;
			TextField textField = movieClip.getChildByName("tfName") as TextField;
			if (textField == null)
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
				textField.text = cd99af21e22e356018b8f72d4a7e4872a;
				return;
			}
		}

		public void ce0a1aa1547e9d4b71db93a8d19aefe40(int cd6bb591c33b2ee3ab93e98aa43a6da63)
		{
			MovieClip movieClip = c0ffd7f3b3dfe86849f698f744e296ad3.getChildByName("label") as MovieClip;
			TextField textField = movieClip.getChildByName("tfLevel") as TextField;
			if (textField == null)
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
				textField.text = "Lv." + cd6bb591c33b2ee3ab93e98aa43a6da63;
				return;
			}
		}

		public void c544385cdcf88dd50a68964795ddb91ba(string cd99af21e22e356018b8f72d4a7e4872a)
		{
			MovieClip movieClip = c0ffd7f3b3dfe86849f698f744e296ad3.getChildByName("label") as MovieClip;
			TextField textField = movieClip.getChildByName("tfClass") as TextField;
			if (textField != null)
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
				textField.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("CLASS_" + cd99af21e22e356018b8f72d4a7e4872a));
			}
			MovieClip movieClip2 = c0ffd7f3b3dfe86849f698f744e296ad3.getChildByName("mcIcon") as MovieClip;
			movieClip2 = movieClip2.getChildByName("mcClassIcon") as MovieClip;
			movieClip2.gotoAndStop(cd99af21e22e356018b8f72d4a7e4872a);
		}

		public void c048c6a5844cb0eecc60774fd21b29f2e(int cb3d2bffae21da96491575e42414232f7)
		{
			MovieClip movieClip = c0ffd7f3b3dfe86849f698f744e296ad3.getChildByName("label") as MovieClip;
			TextField textField = movieClip.getChildByName("tfTime") as TextField;
			if (textField == null)
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
				textField.text = Utility.c12cf74d239864b4c456273b0defe220a(cb3d2bffae21da96491575e42414232f7, 4, true);
				return;
			}
		}
	}

	private c196099a1254db61d3be10d70e14e7422 _panel;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcSetBtn;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcDeleteBtn;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcCreateBtn;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcEnterBtn;

	private List<CharacterButton> _characterList;

	private int MAX_CHAR_COUNT = 5;

	[CompilerGenerated]
	private static Dictionary<string, int> _003C_003Ef__switch_0024mapB;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		_panel = new c196099a1254db61d3be10d70e14e7422();
		_characterList = new List<CharacterButton>();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("CharacterList.swf", "CharacterSelectPanel", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_panel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8, OnWidgetInitialized);
		for (int i = 0; i < MAX_CHAR_COUNT; i++)
		{
			CharacterButton characterButton = new CharacterButton();
			characterButton.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8.getChildByName("item" + i) as MovieClip);
			characterButton.addEventListener(MouseEvent.CLICK, OnSwtichCharacter);
			_characterList.Add(characterButton);
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_panel);
			if (_data == null)
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
				c55bc5054839e272068bc0668938fa6fb();
				return;
			}
		}
	}

	private void c55bc5054839e272068bc0668938fa6fb()
	{
		if (_characterList.Count > 0)
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
			for (int i = 0; i < MAX_CHAR_COUNT; i++)
			{
				_characterList[i].c9c364a8fd1f013589fea518a3924e711 = false;
				if (i < _data.Count)
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
					_characterList[i].cbf402c82d0fffee7c8f37c98e456b8f8 = true;
					if (_currentSelect == i)
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
						_characterList[i].c9c364a8fd1f013589fea518a3924e711 = true;
					}
					_characterList[i].c8fa88a1daa5ca501420e08fdeef7d6c6();
					_characterList[i].c0b8386688f89d5e57306b329c252b6cb(_data[i].Name);
					_characterList[i].ce0a1aa1547e9d4b71db93a8d19aefe40(_data[i].Level);
					_characterList[i].c544385cdcf88dd50a68964795ddb91ba(_data[i].AvatarType.ToString());
					_characterList[i].c048c6a5844cb0eecc60774fd21b29f2e(_data[i].TimePlayed);
					_characterList[i].addEventListener(c649b5d45cf350f685c56c4bd02800198.cd58336ed361ce802b5f1a11c492908c2, OnDoubleClick);
				}
				else
				{
					_characterList[i].cbf402c82d0fffee7c8f37c98e456b8f8 = false;
				}
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
		if (mcCreateBtn != null)
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
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = mcCreateBtn;
			int cbf402c82d0fffee7c8f37c98e456b8f;
			if (_data != null)
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
				cbf402c82d0fffee7c8f37c98e456b8f = ((_data.Count < MAX_CHAR_COUNT) ? 1 : 0);
			}
			else
			{
				cbf402c82d0fffee7c8f37c98e456b8f = 0;
			}
			c82f7c0afbcfc8c5382a8c6daa9365b7b.cbf402c82d0fffee7c8f37c98e456b8f8 = (byte)cbf402c82d0fffee7c8f37c98e456b8f != 0;
		}
		if (mcDeleteBtn == null)
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
			mcDeleteBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			return;
		}
	}

	private void OnDoubleClick(CEvent e)
	{
		ccd4de5ee253f41f4bb424ad2d551276c(_data[_currentSelect].Id);
	}

	public override void c697cea1a39d7a5dfd46cd14d3c068be3(List<Character> c591d56a94543e3559945c497f37126c4)
	{
		base.c697cea1a39d7a5dfd46cd14d3c068be3(c591d56a94543e3559945c497f37126c4);
		int currentSelect;
		if (_data.Count > 0)
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
			currentSelect = 0;
		}
		else
		{
			currentSelect = -1;
		}
		_currentSelect = currentSelect;
		c55bc5054839e272068bc0668938fa6fb();
		if (_currentSelect < 0)
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
			c090a1e1498ac2bf3b242fa7878200faa(_data[_currentSelect].Id);
			return;
		}
	}

	private void OnSwtichCharacter(CEvent e)
	{
		int num = _characterList.IndexOf(e.currentTarget as CharacterButton);
		if (num == -1)
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
			if (num == _currentSelect)
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
				_characterList[_currentSelect].c9c364a8fd1f013589fea518a3924e711 = false;
				c2c1fbad35ca7743f1b3fc129ddc73f3f(num);
				_characterList[_currentSelect].c9c364a8fd1f013589fea518a3924e711 = true;
				c090a1e1498ac2bf3b242fa7878200faa(_data[_currentSelect].Id);
				return;
			}
		}
	}

	private void OnEnterLobby(CEvent e)
	{
		ccd4de5ee253f41f4bb424ad2d551276c(_data[_currentSelect].Id);
	}

	private void OnDeleteCharacter(CEvent e)
	{
		if (_currentSelect >= _data.Count)
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
			_data.RemoveAt(_currentSelect);
			c2c1fbad35ca7743f1b3fc129ddc73f3f(_data.Count - 1);
			c55bc5054839e272068bc0668938fa6fb();
			return;
		}
	}

	private void OnCreateCharacter(CEvent e)
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.ClassSelect, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_panel);
		_panel = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("CharacterList.swf");
	}

	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool result = false;
		string name = movieClip.name;
		if (name != null)
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
			if (_003C_003Ef__switch_0024mapB == null)
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
				Dictionary<string, int> dictionary = new Dictionary<string, int>(4);
				dictionary.Add("mcSetBtn", 0);
				dictionary.Add("mcDeleteBtn", 1);
				dictionary.Add("mcCreateBtn", 2);
				dictionary.Add("mcEnterBtn", 3);
				_003C_003Ef__switch_0024mapB = dictionary;
			}
			int value;
			if (_003C_003Ef__switch_0024mapB.TryGetValue(name, out value))
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
					mcSetBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcSetBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					result = true;
					mcSetBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
					break;
				case 1:
					mcDeleteBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcDeleteBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					mcDeleteBtn.addEventListener(MouseEvent.CLICK, OnDeleteCharacter);
					mcDeleteBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
					mcDeleteBtn.c150264a18c2cb408479d3f072cac8cc1 = false;
					result = true;
					break;
				case 2:
					mcCreateBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcCreateBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					mcCreateBtn.addEventListener(MouseEvent.CLICK, OnCreateCharacter);
					result = true;
					mcCreateBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
					break;
				case 3:
					mcEnterBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcEnterBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					mcEnterBtn.addEventListener(MouseEvent.CLICK, OnEnterLobby);
					result = true;
					break;
				}
			}
		}
		return result;
	}
}
