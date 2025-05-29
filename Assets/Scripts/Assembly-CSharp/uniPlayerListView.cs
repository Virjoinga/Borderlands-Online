using System;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;

public class uniPlayerListView : PlayerListView
{
	protected class PlayerListPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected const int ITEM_SUM = 10;

		protected MovieClip mcSelf;

		protected List<MovieClip> _arrItemList;

		protected List<c82f7c0afbcfc8c5382a8c6daa9365b7b> _arrButtonList;

		protected int startRenderIndex;

		protected int endRenderIndex;

		protected int selectedIndex;

		protected int dataIndex;

		protected int offsetTop = 27;

		protected int offsetLeft = -3;

		protected float itemHeight;

		protected float itemWidth;

		protected MenuItemDef[] listData;

		protected MenuItemDef[] sublistData;

		protected cf7ac05203029a27299d6893b2dbaee2e scrollBar;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b currentSelectButton;

		public MenuSelectedFunc menuSelFunc;

		public PlayerListPanel()
		{
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
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
			}
			mcSelf.visible = false;
			_arrButtonList.Clear();
			for (int i = 0; i < 10; i++)
			{
				MovieClip childByName = mcSelf.getChildByName<MovieClip>("item" + i);
				c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
				if (i == 0)
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
					itemHeight = childByName.height;
					itemWidth = childByName.width;
				}
				c82f7c0afbcfc8c5382a8c6daa9365b7b.c130648b59a0c8debea60aa153f844879(childByName);
				c82f7c0afbcfc8c5382a8c6daa9365b7b.c591d56a94543e3559945c497f37126c4 = i;
				c82f7c0afbcfc8c5382a8c6daa9365b7b.addEventListener(MouseEvent.MOUSE_ENTER, cadce22e7a666664f05dd9df730828905);
				childByName.visible = false;
				_arrButtonList.Add(c82f7c0afbcfc8c5382a8c6daa9365b7b);
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				selectedIndex = 0;
				dataIndex = 0;
				scrollBar = new cf7ac05203029a27299d6893b2dbaee2e();
				scrollBar.c130648b59a0c8debea60aa153f844879(mcSelf.getChildByName<MovieClip>("mcScrollingBar"));
				scrollBar.addEventListener("Scrolling", OnScrollingList);
				mcSelf.addEventListener(ccee399aceaafcace836a9d2621e66f35.cb995b44f9d3bf68faff261ab2cc8c5b7, OnMouseWheel);
				return;
			}
		}

		private void OnMouseWheel(CEvent evt)
		{
			ccee399aceaafcace836a9d2621e66f35 ccee399aceaafcace836a9d2621e66f = evt as ccee399aceaafcace836a9d2621e66f35;
			if (ccee399aceaafcace836a9d2621e66f == null)
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
				if (!scrollBar.c150264a18c2cb408479d3f072cac8cc1)
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
					int num;
					if (ccee399aceaafcace836a9d2621e66f.c46133d1809d6d3227e98e175cb2e7142 > 0f)
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
						num = -1;
					}
					else
					{
						num = 1;
					}
					int num2 = num;
					startRenderIndex += num2;
					startRenderIndex = Math.Min(endRenderIndex, Math.Max(startRenderIndex, 0));
					scrollBar.cef9712200bbe2c3873eec3ca2e18a595 = startRenderIndex;
					dataIndex = startRenderIndex + selectedIndex;
					dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7(CEvent.CHANGED, listData[dataIndex].itemData));
					return;
				}
			}
		}

		public void cac7688b05e921e2be3f92479ba44b4a8()
		{
			for (int i = 0; i < _arrButtonList.Count; i++)
			{
				_arrButtonList[i].removeEventListener(MouseEvent.MOUSE_ENTER, cadce22e7a666664f05dd9df730828905);
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
				_arrButtonList.Clear();
				listData = c61b63c200428e4dfe18b1ed9582055ba.c7088de59e49f7108f520cf7e0bae167e;
				return;
			}
		}

		protected void OnScrollingList(CEvent evt)
		{
			startRenderIndex = scrollBar.cef9712200bbe2c3873eec3ca2e18a595;
			dataIndex = startRenderIndex + selectedIndex;
			dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7(CEvent.CHANGED, listData[dataIndex].itemData));
			c5e13b5f605858cbadf3e4af03a996b4a(listData);
		}

		protected void cadce22e7a666664f05dd9df730828905(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (c3d202dee321219a80026dc3081fb3c86 == null)
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
						return;
					}
				}
			}
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = c3d202dee321219a80026dc3081fb3c86.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b == null)
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
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b != currentSelectButton)
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
				if (currentSelectButton != null)
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
					currentSelectButton.c9c364a8fd1f013589fea518a3924e711 = false;
				}
				currentSelectButton = c82f7c0afbcfc8c5382a8c6daa9365b7b;
				currentSelectButton.c9c364a8fd1f013589fea518a3924e711 = true;
			}
			selectedIndex = (int)c82f7c0afbcfc8c5382a8c6daa9365b7b.c591d56a94543e3559945c497f37126c4;
			dataIndex = startRenderIndex + selectedIndex;
			dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7(CEvent.CHANGED, listData[dataIndex].itemData));
			c5524058c2adb2e72e93ba5f22b588f6e(c61b63c200428e4dfe18b1ed9582055ba.c7088de59e49f7108f520cf7e0bae167e);
		}

		protected void c1e8cc2494908a8ab5afd4e62348f4deb(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
		}

		public virtual void c5e13b5f605858cbadf3e4af03a996b4a(MenuItemDef[] c6ffe00a26fa81a07fd2c8df9d336f864)
		{
			for (int i = 0; i < 10; i++)
			{
				if (_arrButtonList[i] == null)
				{
					continue;
				}
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
				_arrButtonList[i].c89ef242f4744e0f1c4ffea4da8b79bc1.visible = i < c6ffe00a26fa81a07fd2c8df9d336f864.Length;
				if (!_arrButtonList[i].c89ef242f4744e0f1c4ffea4da8b79bc1.visible)
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
				_arrButtonList[i].cf798cedf450c3ad2a08ce2d2fd00d464 = c6ffe00a26fa81a07fd2c8df9d336f864[startRenderIndex + i].itemTitle;
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

		public virtual void c5524058c2adb2e72e93ba5f22b588f6e(MenuItemDef[] c6ffe00a26fa81a07fd2c8df9d336f864 = null)
		{
			sublistData = c6ffe00a26fa81a07fd2c8df9d336f864;
			if (sublistData == null)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().c687c56ed531550f24368180c4c3bc947(sublistData, new Vector2(base.c89ef242f4744e0f1c4ffea4da8b79bc1.x + base.c89ef242f4744e0f1c4ffea4da8b79bc1.width + (float)offsetLeft, base.c89ef242f4744e0f1c4ffea4da8b79bc1.y + (float)offsetTop + (float)selectedIndex * itemHeight), OnSubmenuSelected);
				return;
			}
		}

		private void OnSubmenuSelected(int index)
		{
			if (mcSelf.getBounds(mcSelf).contains(mcSelf.mouseX, mcSelf.mouseY))
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
				if (this == null)
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
					dispatchEvent(new CEvent("Cancel"));
					return;
				}
			}
		}

		public virtual void ca2697a254bbeb745c522c64f883c925a(MenuItemDef[] c6ffe00a26fa81a07fd2c8df9d336f864)
		{
			if (mcSelf == null)
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
			mcSelf.visible = true;
			startRenderIndex = 0;
			endRenderIndex = Math.Max(0, c6ffe00a26fa81a07fd2c8df9d336f864.Length - 10);
			listData = c6ffe00a26fa81a07fd2c8df9d336f864;
			c5e13b5f605858cbadf3e4af03a996b4a(listData);
			scrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(10, 0, endRenderIndex, 1);
			scrollBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
			if (endRenderIndex <= startRenderIndex)
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
				scrollBar.c150264a18c2cb408479d3f072cac8cc1 = false;
			}
			else
			{
				scrollBar.c150264a18c2cb408479d3f072cac8cc1 = true;
			}
			currentSelectButton = _arrButtonList[0];
			currentSelectButton.c9c364a8fd1f013589fea518a3924e711 = true;
			mcSelf.x = ((float)Screen.width - mcSelf.width) * 0.5f;
			mcSelf.y = ((float)Screen.height - mcSelf.height) * 0.5f;
		}

		public virtual void cce6adadf40a70610ce3ae5dd40479620()
		{
			mcSelf.visible = false;
			startRenderIndex = 0;
			endRenderIndex = 0;
			selectedIndex = 0;
			dataIndex = 0;
			if (currentSelectButton != null)
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
				currentSelectButton.c9c364a8fd1f013589fea518a3924e711 = false;
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().c5bc8bb6c6b44d3d5bf9249765a5d8e27();
		}

		protected void c5c43edd352a329bc373c6a51c70355ed(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (mcSelf.getBounds(mcSelf).contains(mcSelf.mouseX, mcSelf.mouseY))
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
				if (this == null)
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
					dispatchEvent(new CEvent("Cancel"));
					return;
				}
			}
		}
	}

	protected delegate void MenuSelectedFunc(int iIndex);

	private PlayerListPanel _rootPanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("PlayerList.swf", "PlayerListPanel", cdade65fca9368f860759e1ba47026648);
	}

	private void cdade65fca9368f860759e1ba47026648(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_rootPanel = new PlayerListPanel();
		_rootPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_rootPanel.menuSelFunc = base.c3640a188d930db43e2c25dbef10d9af6;
		_rootPanel.addEventListener("Cancel", c7c2ebf9a4704bd5defd809a6b06e889a);
		_rootPanel.addEventListener(CEvent.CHANGED, c99019adcfc1dd3d2dcc29b615e322cc8);
	}

	private void c99019adcfc1dd3d2dcc29b615e322cc8(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		if (cdd9021d4f44808fce2ab49c52f0db6f == null)
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
			c3640a188d930db43e2c25dbef10d9af6((int)cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4);
			return;
		}
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_rootPanel);
		_rootPanel.cac7688b05e921e2be3f92479ba44b4a8();
		_rootPanel.menuSelFunc = null;
		_rootPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("PlayerList.swf");
	}

	public void c571b369c7d6877ca665ea39369831586(Stage c1e172bfb5184630068d909f8fe1e728c)
	{
		c1e172bfb5184630068d909f8fe1e728c.addChild(_rootPanel.c89ef242f4744e0f1c4ffea4da8b79bc1);
	}

	protected override void cee3f7e1f2fe80146187019ef16248436()
	{
		if (_rootPanel == null)
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_rootPanel);
			_rootPanel.ca2697a254bbeb745c522c64f883c925a(_arrCurrentMenu.ToArray());
			_rootPanel.c5524058c2adb2e72e93ba5f22b588f6e(_subMenu.ToArray());
			return;
		}
	}

	protected override void c54ebee936a2ce5fd38e3577cb90f2386()
	{
		if (_rootPanel == null)
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
			_rootPanel.c5524058c2adb2e72e93ba5f22b588f6e(_subMenu.ToArray());
			return;
		}
	}

	protected override void c21e36f8cd23459c6af056b4a8a451e4c()
	{
		_rootPanel.cce6adadf40a70610ce3ae5dd40479620();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_rootPanel);
	}

	protected void c7c2ebf9a4704bd5defd809a6b06e889a(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		c5bc8bb6c6b44d3d5bf9249765a5d8e27();
	}
}
