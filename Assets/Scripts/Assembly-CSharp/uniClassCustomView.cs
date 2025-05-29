using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;
using pumpkin.swf;
using pumpkin.text;

public class uniClassCustomView : ClassCustomView
{
	private class CustomRadioButton : c6425d3761c85e65e3530cc19d085d446
	{
		protected c82f7c0afbcfc8c5382a8c6daa9365b7b btnLeft;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b btnRight;

		protected uniClassCustomView _customView;

		protected int _feature;

		protected MovieClip mcTextEffect;

		public override bool cbf402c82d0fffee7c8f37c98e456b8f8
		{
			set
			{
				base.cbf402c82d0fffee7c8f37c98e456b8f8 = value;
				btnLeft.cbf402c82d0fffee7c8f37c98e456b8f8 = value;
				btnRight.cbf402c82d0fffee7c8f37c98e456b8f8 = value;
				if (value)
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
					cf798cedf450c3ad2a08ce2d2fd00d464 = string.Empty;
					return;
				}
			}
		}

		public CustomRadioButton(uniClassCustomView c6cfb3ef2904a8acae07f8c7292c74afa, int cae80adcd816940694e39ede2c2d356ee)
		{
			_customView = c6cfb3ef2904a8acae07f8c7292c74afa;
			_feature = cae80adcd816940694e39ede2c2d356ee;
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			btnLeft = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			btnLeft.addEventListener(MouseEvent.CLICK, c1aa5711acaa07fbafccef8176b2ef638);
			btnRight = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			btnRight.addEventListener(MouseEvent.CLICK, c6c647f8d5683e6d0937d65f1ae1b5371);
		}

		protected override void c16dd84132166e8847948a375ec27d1d9()
		{
			base.c16dd84132166e8847948a375ec27d1d9();
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(CEvent.ENTER_FRAME, c8f90d7d44bb9bb25af66100d24bc44bc);
			c0ffd7f3b3dfe86849f698f744e296ad3.mouseChildrenEnabled = true;
		}

		protected void c8f90d7d44bb9bb25af66100d24bc44bc(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mcTextEffect = c0ffd7f3b3dfe86849f698f744e296ad3.getChildByName<MovieClip>("textEffect");
			if (mcTextEffect == null)
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
				TextField childByName = mcTextEffect.getChildByName<TextField>("textField");
				if (childByName == null)
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
					childByName.text = c8b24514933da61f4fae114de5154e38a;
					return;
				}
			}
		}

		protected override void c521641d7216a0be9dad8c7a8b29a8791()
		{
			base.c521641d7216a0be9dad8c7a8b29a8791();
		}

		protected override void c9f8eeb310eab54c590c996dd8e63e346()
		{
			base.c9f8eeb310eab54c590c996dd8e63e346();
			ca08748e235f2abf925ebb3dfb3b858e8 = c0ffd7f3b3dfe86849f698f744e296ad3.getChildByName<BitmapTextField>("textField");
			MovieClip c7088de59e49f7108f520cf7e0bae167e = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
			c7088de59e49f7108f520cf7e0bae167e = c0ffd7f3b3dfe86849f698f744e296ad3.getChildByName("btnLeft") as MovieClip;
			if (c7088de59e49f7108f520cf7e0bae167e != null)
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
				btnLeft.c130648b59a0c8debea60aa153f844879(c7088de59e49f7108f520cf7e0bae167e);
			}
			else
			{
				btnLeft = c97069a74e409c00ffe9b90ba6b0c56c7.c7088de59e49f7108f520cf7e0bae167e;
			}
			c7088de59e49f7108f520cf7e0bae167e = c0ffd7f3b3dfe86849f698f744e296ad3.getChildByName("btnRight") as MovieClip;
			if (c7088de59e49f7108f520cf7e0bae167e != null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						btnRight.c130648b59a0c8debea60aa153f844879(c7088de59e49f7108f520cf7e0bae167e);
						return;
					}
				}
			}
			btnRight = c97069a74e409c00ffe9b90ba6b0c56c7.c7088de59e49f7108f520cf7e0bae167e;
		}

		protected void c1aa5711acaa07fbafccef8176b2ef638(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			int num = _customView.c6412dee21869cb067c5e01137bf5e450(_feature) - 1;
			num = (num + 3) % 3;
			_customView.cfbd9ccf2762acc9ab5b9ff3e8975e3b9(_feature, num);
			c14bbdc4858582827d560278993007f62(_feature);
		}

		protected void c6c647f8d5683e6d0937d65f1ae1b5371(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			int num = _customView.c6412dee21869cb067c5e01137bf5e450(_feature) + 1;
			num %= 3;
			_customView.cfbd9ccf2762acc9ab5b9ff3e8975e3b9(_feature, num);
			c14bbdc4858582827d560278993007f62(_feature);
		}

		public void c14bbdc4858582827d560278993007f62(int c4d7aa49aee8e99233ad8b8fd4359c08e)
		{
			cf798cedf450c3ad2a08ce2d2fd00d464 = _customView.c64cf9e4192445a3dfe6687ff0dec4168(c4d7aa49aee8e99233ad8b8fd4359c08e);
		}

		public void c6fcf909a66d355f419b634445be0f7c9(int c5612a459a84ffdb41c885401433cd62d)
		{
			int c343f09726f61b6b56d24591379c667b = c5612a459a84ffdb41c885401433cd62d % 3;
			_customView.cfbd9ccf2762acc9ab5b9ff3e8975e3b9(_feature, c343f09726f61b6b56d24591379c667b, false);
			c14bbdc4858582827d560278993007f62(_feature);
		}
	}

	private class FeaturePanel : ExpandPanel
	{
		private CustomRadioButton[] _arrRadioBtn;

		protected uniClassCustomView _customView;

		private int _iSelIndex;

		public FeaturePanel(uniClassCustomView c6cfb3ef2904a8acae07f8c7292c74afa)
		{
			_arrRadioBtn = new CustomRadioButton[6];
			_customView = c6cfb3ef2904a8acae07f8c7292c74afa;
			c3fb55599d4047226010e75d667d65f43("maskMC", "mcButton");
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			if (movieClip.name.Length > "element".Length)
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
				string text = movieClip.name.Substring(0, "element".Length);
				if (text == "element")
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
					int num = Convert.ToInt32(movieClip.name.Substring("element".Length, 1));
					MovieClip c7088de59e49f7108f520cf7e0bae167e = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
					if (num < _arrRadioBtn.Length)
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
						_arrRadioBtn[num] = null;
						c7088de59e49f7108f520cf7e0bae167e = movieClip.getChildByName<MovieClip>("mcButton");
						if (c7088de59e49f7108f520cf7e0bae167e != null)
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
							_arrRadioBtn[num] = new CustomRadioButton(_customView, num);
							_arrRadioBtn[num].c130648b59a0c8debea60aa153f844879(c7088de59e49f7108f520cf7e0bae167e);
							_arrRadioBtn[num].addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, ce6339c56d641da0fbe7f6951a1fd295a);
							_arrRadioBtn[num].ce84b930a12a1d06512c79320b3f0d3f4 = false;
							_arrRadioBtn[num].cec024da8c099380cfe1334bfe4c8f30f = "clsCusView";
							_arrRadioBtn[num].c591d56a94543e3559945c497f37126c4 = num;
							_arrRadioBtn[num].c14bbdc4858582827d560278993007f62(num);
						}
						result = true;
					}
					else
					{
						movieClip.visible = false;
					}
				}
			}
			return result;
		}

		protected void ce6339c56d641da0fbe7f6951a1fd295a(CEvent c05f6b47f5e84359168dfe9aaf57b8a79)
		{
			CustomRadioButton customRadioButton = c05f6b47f5e84359168dfe9aaf57b8a79.target as CustomRadioButton;
			if (!customRadioButton.c9c364a8fd1f013589fea518a3924e711)
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
				if (customRadioButton.c591d56a94543e3559945c497f37126c4 == null)
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
					_iSelIndex = (int)customRadioButton.c591d56a94543e3559945c497f37126c4;
					_customView.cfbd9ccf2762acc9ab5b9ff3e8975e3b9(_iSelIndex, _customView.c6412dee21869cb067c5e01137bf5e450(_iSelIndex));
					c6e9df472ca5f99cfa7a405bcfed3cc2b(_iSelIndex);
					return;
				}
			}
		}

		public void cffbf487941c0edf8e76c287f346aa9a1()
		{
			for (int i = 0; i < _arrRadioBtn.Length; i++)
			{
				int c5612a459a84ffdb41c885401433cd62d = UnityEngine.Random.Range(0, 3);
				_arrRadioBtn[i].c6fcf909a66d355f419b634445be0f7c9(c5612a459a84ffdb41c885401433cd62d);
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

		protected void cb8cc2ee81b097ca42e6b4697ef8c2dc0(CEvent c05f6b47f5e84359168dfe9aaf57b8a79)
		{
			c6e9df472ca5f99cfa7a405bcfed3cc2b(_iSelIndex);
		}

		protected void cfe1f62f6b0fad72d689d4935778b9284(CEvent c05f6b47f5e84359168dfe9aaf57b8a79)
		{
			MovieClip movieClip = c05f6b47f5e84359168dfe9aaf57b8a79.currentTarget as MovieClip;
			if (movieClip.userData == null)
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
				c6e9df472ca5f99cfa7a405bcfed3cc2b((int)movieClip.userData);
				return;
			}
		}
	}

	private c196099a1254db61d3be10d70e14e7422 _panel;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b _mcPrevBtn;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b _mcNextBtn;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b _mcRandomBtn;

	private MovieClip _warning;

	private ccf8bd4afc86b3c33d69f65b1612538ce _mcNameField;

	private static int MAX_CHAR = 16;

	private FeaturePanel mcFeaturePanel;

	private MovieClip _mcPanelRotateZone;

	[CompilerGenerated]
	private static Dictionary<string, int> _003C_003Ef__switch_0024mapD;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		_panel = new c196099a1254db61d3be10d70e14e7422();
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "UI Base: Customization initializing!");
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("ClassCustomization.swf", "CustomizationPannel", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_warning = cbe9ca8ddb3cdc2312e6ff8411b2db2c8.getChildByName("warning") as MovieClip;
		_panel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8, OnWidgetInitialized);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_panel);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c0c584b58aa13cc5471c8b4aec04bf8a1.addEventListener(MouseEvent.MOUSE_UP, c6993aba38b6f7f24bf3ad1595b9080ad);
	}

	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool result = false;
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
			if (_003C_003Ef__switch_0024mapD == null)
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
				Dictionary<string, int> dictionary = new Dictionary<string, int>(6);
				dictionary.Add("mcPrevBtn", 0);
				dictionary.Add("mcNextBtn", 1);
				dictionary.Add("mcNameInput", 2);
				dictionary.Add("mcRandomBtn", 3);
				dictionary.Add("mcRotateZone", 4);
				dictionary.Add("mcFeaturePanel", 5);
				_003C_003Ef__switch_0024mapD = dictionary;
			}
			int value;
			if (_003C_003Ef__switch_0024mapD.TryGetValue(name, out value))
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
				switch (value)
				{
				case 0:
					_mcPrevBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					_mcPrevBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					_mcPrevBtn.addEventListener(MouseEvent.CLICK, c8e60fb4f81068550dfc04c72900be46e);
					break;
				case 1:
					_mcNextBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					_mcNextBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					_mcNextBtn.addEventListener(MouseEvent.CLICK, cfc5920a5bb9bf351536e2ca4aea54e54);
					break;
				case 2:
					_mcNameField = new ccf8bd4afc86b3c33d69f65b1612538ce();
					_mcNameField.c130648b59a0c8debea60aa153f844879(movieClip);
					_mcNameField.c275618f45ace7b211e4da85cecbb43d4 = MAX_CHAR;
					_mcNameField.c09721d98c247dde8efe59bc3cebbad00 = _name;
					break;
				case 3:
					_mcRandomBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					_mcRandomBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					_mcRandomBtn.addEventListener(MouseEvent.CLICK, c188a033be8f700c0572d12c5c889af74);
					break;
				case 4:
					_mcPanelRotateZone = movieClip;
					_mcPanelRotateZone.addEventListener(MouseEvent.MOUSE_DOWN, cf3b3e915898c79d6019f68dc99a9694e, false);
					_mcPanelRotateZone.addEventListener(MouseEvent.MOUSE_UP, c0e580a222c7ff2a4a8f30e91f4b6917c, false);
					_mcPanelRotateZone.addEventListener(MouseEvent.MOUSE_ENTER, c6dc049ada3211d0e1fa8e39c5b12ac10, false);
					_mcPanelRotateZone.addEventListener(MouseEvent.MOUSE_LEAVE, cf71257903898e3353635675ae9c63c1b, false);
					_mcPanelRotateZone.addEventListener(c649b5d45cf350f685c56c4bd02800198.ca402a9e0fe9df670714b50e5c72a12d0, c0e580a222c7ff2a4a8f30e91f4b6917c, false);
					break;
				case 5:
					mcFeaturePanel = new FeaturePanel(this);
					mcFeaturePanel.c130648b59a0c8debea60aa153f844879(movieClip);
					break;
				}
			}
		}
		return result;
	}

	public override void c7d1840b98a06410c4a22d4c051ecae9f(c2597280f86604f98f89309a4de95dd62 c72943404493c5c9abc349e4b65bfe91b)
	{
		if (_warning != null)
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
			_warning.visible = true;
			TextField textField = _warning.getChildByName("tfLabel") as TextField;
			if (c72943404493c5c9abc349e4b65bfe91b == c2597280f86604f98f89309a4de95dd62.Error)
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
				textField.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("NAME_INPUT"));
			}
			else if (c72943404493c5c9abc349e4b65bfe91b == c2597280f86604f98f89309a4de95dd62.Error_NameAlreadyExists)
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
				textField.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("NAME_INVALID"));
			}
			else if (c72943404493c5c9abc349e4b65bfe91b == c2597280f86604f98f89309a4de95dd62.Error_NameContainsIllegalWords)
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
				textField.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("NAME_ILLEGAL"));
			}
			else if (c72943404493c5c9abc349e4b65bfe91b == c2597280f86604f98f89309a4de95dd62.Error_NameTooLong)
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
				textField.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("NAME_TOOLONG"));
			}
		}
		c3a85bc47e8d2691a24c6ba1bfe27b9c4();
	}

	public override void cfcad2bb178b2ee0f48018fadc7c7352a()
	{
		if (_warning != null)
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
			_warning.visible = false;
		}
		cdec6986a7370bcaee4647e04db28e5cb();
	}

	private void c3a85bc47e8d2691a24c6ba1bfe27b9c4()
	{
		if (_mcNextBtn != null)
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
			_mcNextBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
		}
		if (_mcPrevBtn == null)
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
			_mcPrevBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
			return;
		}
	}

	private void cdec6986a7370bcaee4647e04db28e5cb()
	{
		if (_mcNextBtn != null)
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
			_mcNextBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
		}
		if (_mcPrevBtn == null)
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
			_mcPrevBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			return;
		}
	}

	private void c188a033be8f700c0572d12c5c889af74(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		mcFeaturePanel.cffbf487941c0edf8e76c287f346aa9a1();
	}

	private void cf3b3e915898c79d6019f68dc99a9694e(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		_bRotateEnable = true;
		c69b7264d5f6dc27474e86b241d437906();
	}

	private void c0e580a222c7ff2a4a8f30e91f4b6917c(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		_bRotateEnable = false;
		c69b7264d5f6dc27474e86b241d437906();
	}

	private void c6dc049ada3211d0e1fa8e39c5b12ac10(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		_bCursorInCheckRect = true;
		c69b7264d5f6dc27474e86b241d437906();
	}

	private void cf71257903898e3353635675ae9c63c1b(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		_bCursorInCheckRect = false;
		c69b7264d5f6dc27474e86b241d437906();
	}

	private void c6993aba38b6f7f24bf3ad1595b9080ad(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		if (!_bRotateEnable)
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
			c0e580a222c7ff2a4a8f30e91f4b6917c(c3d202dee321219a80026dc3081fb3c86);
			return;
		}
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_panel);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c0c584b58aa13cc5471c8b4aec04bf8a1.removeEventListener(MouseEvent.MOUSE_UP, c6993aba38b6f7f24bf3ad1595b9080ad);
		_panel = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("ClassCustomization.swf");
	}

	private bool cf04b3b202e820e17012ce747725c7e35()
	{
		if (_name.Trim() == string.Empty)
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
					c7d1840b98a06410c4a22d4c051ecae9f(c2597280f86604f98f89309a4de95dd62.Error);
					return false;
				}
			}
		}
		return true;
	}

	protected void c8e60fb4f81068550dfc04c72900be46e(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
	{
		c8e60fb4f81068550dfc04c72900be46e();
	}

	protected void cfc5920a5bb9bf351536e2ca4aea54e54(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
	{
		_name = _mcNameField.c09721d98c247dde8efe59bc3cebbad00;
		if (!cf04b3b202e820e17012ce747725c7e35())
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
			cfcad2bb178b2ee0f48018fadc7c7352a();
			cfc5920a5bb9bf351536e2ca4aea54e54();
			return;
		}
	}
}
