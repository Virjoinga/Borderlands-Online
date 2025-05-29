using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;

public class uniPopupMenuView : PopupMenuView
{
	protected class ListMenuPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected const int ITEM_SUM = 12;

		protected MovieClip mcSelf;

		protected BadAssMovieClip _background;

		protected List<MovieClip> _arrItemList;

		protected List<c82f7c0afbcfc8c5382a8c6daa9365b7b> _arrButtonList;

		public MenuSelectedFunc menuSelFunc;

		public ListMenuPanel()
		{
			_arrItemList = new List<MovieClip>();
			_arrButtonList = new List<c82f7c0afbcfc8c5382a8c6daa9365b7b>();
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mcSelf == null)
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
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
			}
			mcSelf.visible = false;
			_arrItemList.Clear();
			_arrButtonList.Clear();
			_background = mcSelf.getChildByName<BadAssMovieClip>("bg");
			for (int i = 0; i < 12; i++)
			{
				MovieClip childByName = mcSelf.getChildByName<MovieClip>("item" + i);
				c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = c97069a74e409c00ffe9b90ba6b0c56c7.c7088de59e49f7108f520cf7e0bae167e;
				if (childByName != null)
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
					childByName.visible = false;
					MovieClip childByName2 = childByName.getChildByName<MovieClip>("mcButton");
					if (childByName2 != null)
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
						c82f7c0afbcfc8c5382a8c6daa9365b7b = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						c82f7c0afbcfc8c5382a8c6daa9365b7b.c130648b59a0c8debea60aa153f844879(childByName2);
						c82f7c0afbcfc8c5382a8c6daa9365b7b.c591d56a94543e3559945c497f37126c4 = i;
						c82f7c0afbcfc8c5382a8c6daa9365b7b.addEventListener(MouseEvent.CLICK, ceaa483d1c7de4ff85b2bd14fa57fd849);
					}
				}
				_arrItemList.Add(childByName);
				_arrButtonList.Add(c82f7c0afbcfc8c5382a8c6daa9365b7b);
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

		public virtual void ca2697a254bbeb745c522c64f883c925a(MenuItemDef[] c6ffe00a26fa81a07fd2c8df9d336f864, Vector2 cef9712200bbe2c3873eec3ca2e18a595)
		{
			if (mcSelf == null)
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
			mcSelf.visible = true;
			float num = 8f;
			for (int i = 0; i < 12; i++)
			{
				if (_arrItemList[i] == null)
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
				_arrItemList[i].visible = i < c6ffe00a26fa81a07fd2c8df9d336f864.Length;
				if (!_arrItemList[i].visible)
				{
					continue;
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
				if (_arrButtonList[i] == null)
				{
					continue;
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
				_arrButtonList[i].cf798cedf450c3ad2a08ce2d2fd00d464 = c6ffe00a26fa81a07fd2c8df9d336f864[i].itemTitle;
				_arrButtonList[i].cbf402c82d0fffee7c8f37c98e456b8f8 = (object)c6ffe00a26fa81a07fd2c8df9d336f864[i].itemFunc != cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
				num += 30.5f;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				num += 27f;
				_background.cf7772a1df19641cd211b92f3f6b89005 = num;
				_background.c93e718634f0a0a9662e4e62dc1b5d8a5 = 123f;
				Vector2 vector = new Vector2(cef9712200bbe2c3873eec3ca2e18a595.x, cef9712200bbe2c3873eec3ca2e18a595.y);
				float num2 = vector.y + num - ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c5b74b332e25262d06ef731df64d69ccc;
				if (num2 > 0f)
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
					vector.y -= num2;
				}
				mcSelf.x = vector.x;
				mcSelf.y = vector.y;
				ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c1e172bfb5184630068d909f8fe1e728c.addEventListener(MouseEvent.MOUSE_DOWN, c5c43edd352a329bc373c6a51c70355ed);
				return;
			}
		}

		public virtual void cce6adadf40a70610ce3ae5dd40479620()
		{
			mcSelf.visible = false;
			ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c1e172bfb5184630068d909f8fe1e728c.removeEventListener(MouseEvent.MOUSE_DOWN, c5c43edd352a329bc373c6a51c70355ed);
		}

		protected void ceaa483d1c7de4ff85b2bd14fa57fd849(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c649b5d45cf350f685c56c4bd02800198 c649b5d45cf350f685c56c4bd = c3d202dee321219a80026dc3081fb3c86 as c649b5d45cf350f685c56c4bd02800198;
			if (c649b5d45cf350f685c56c4bd == null)
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
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = c649b5d45cf350f685c56c4bd.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b == null)
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
				if (c82f7c0afbcfc8c5382a8c6daa9365b7b.c591d56a94543e3559945c497f37126c4 == null)
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
					if (menuSelFunc == null)
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
						menuSelFunc((int)c82f7c0afbcfc8c5382a8c6daa9365b7b.c591d56a94543e3559945c497f37126c4);
						return;
					}
				}
			}
		}

		protected void c5c43edd352a329bc373c6a51c70355ed(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (mcSelf.getBounds(mcSelf).contains(mcSelf.mouseX, mcSelf.mouseY))
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
				dispatchEvent(new CEvent("Cancel"));
				return;
			}
		}
	}

	protected delegate void MenuSelectedFunc(int iIndex);

	private ListMenuPanel _rootPanel;

	public override void OnTestGUI()
	{
		if (!GUI.Button(new Rect(Screen.width / 2 - 200, 100f, 140f, 60f), "PopupMenu"))
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
			MenuItemDef[] array = cacffdc9bda8a41773c3ac61797275a6c.c0a0cdf4a196914163f7334d9b0781a04(6);
			for (int i = 0; i < 6; i++)
			{
				array[i].itemTitle = "Right Menu " + i;
				array[i].itemData = i;
				array[i].itemFunc = cedbb1e9520562cf31c78148767c48bce;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().c687c56ed531550f24368180c4c3bc947(array);
				return;
			}
		}
	}

	private void cedbb1e9520562cf31c78148767c48bce(object c591d56a94543e3559945c497f37126c4)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "onMenuClick : " + (int)c591d56a94543e3559945c497f37126c4);
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		BadAssMovieClip c998c56e5cab278873f1a5722e79733da = new BadAssMovieClip("CommonLib.swf", "PopupMenuPanel");
		_rootPanel = new ListMenuPanel();
		_rootPanel.c130648b59a0c8debea60aa153f844879(c998c56e5cab278873f1a5722e79733da);
		_rootPanel.menuSelFunc = base.c3640a188d930db43e2c25dbef10d9af6;
		_rootPanel.addEventListener("Cancel", c7c2ebf9a4704bd5defd809a6b06e889a);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_rootPanel);
		_rootPanel.menuSelFunc = null;
		_rootPanel = null;
	}

	protected override void cee3f7e1f2fe80146187019ef16248436()
	{
		if (_rootPanel == null)
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c120a0ab44e69ef682f36041c0b116750(_rootPanel);
			Vector2 cef9712200bbe2c3873eec3ca2e18a = _position / ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c38416c96b869af0e164ff13994b8aa12;
			_rootPanel.ca2697a254bbeb745c522c64f883c925a(_arrCurrentMenu.ToArray(), cef9712200bbe2c3873eec3ca2e18a);
			return;
		}
	}

	protected override void c21e36f8cd23459c6af056b4a8a451e4c()
	{
		if (_rootPanel == null)
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_rootPanel);
			_rootPanel.cce6adadf40a70610ce3ae5dd40479620();
			return;
		}
	}

	protected void c7c2ebf9a4704bd5defd809a6b06e889a(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		c74d5d0129904385e473258ef8327225b(-1);
	}
}
