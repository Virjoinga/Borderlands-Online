using System.Collections.Generic;
using A;
using UnityEngine;

public class PopupMenuView : BaseView
{
	public delegate void MouseClickHooker(int index);

	protected List<MenuItemDef> _arrCurrentMenu = new List<MenuItemDef>();

	protected bool _bCursorLockState;

	protected Vector2 _position;

	protected MouseClickHooker _funcMouseClkHooker;

	public override bool c150264a18c2cb408479d3f072cac8cc1
	{
		get
		{
			return _bVisible;
		}
		set
		{
			if (!cd0069281ff5290a7e6c484b6aed3933d)
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
				cbf5f806ecf4d92b475f68040522616cf(value, true);
				return;
			}
		}
	}

	public override bool c57b6c6861c1d709f4f7aa7b8a699b5c9()
	{
		return false;
	}

	public override void OnTestGUI()
	{
		int num = 0;
		using (List<MenuItemDef>.Enumerator enumerator = _arrCurrentMenu.GetEnumerator())
		{
			while (true)
			{
				if (enumerator.MoveNext())
				{
					MenuItemDef current = enumerator.Current;
					if (GUI.Button(new Rect(Screen.width / 4 - 100, 200 + num * 41, 100f, 40f), current.itemTitle))
					{
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
							break;
						}
						break;
					}
					num++;
					continue;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						goto end_IL_0077;
					}
					continue;
					end_IL_0077:
					break;
				}
				break;
			}
		}
		if (num >= _arrCurrentMenu.Count)
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
			c3640a188d930db43e2c25dbef10d9af6(num);
			return;
		}
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c5bc8bb6c6b44d3d5bf9249765a5d8e27();
	}

	public void c687c56ed531550f24368180c4c3bc947(MenuItemDef[] c6ffe00a26fa81a07fd2c8df9d336f864)
	{
		Vector2 cef9712200bbe2c3873eec3ca2e18a = Input.mousePosition;
		cef9712200bbe2c3873eec3ca2e18a.y = (float)Screen.height - cef9712200bbe2c3873eec3ca2e18a.y;
		c687c56ed531550f24368180c4c3bc947(c6ffe00a26fa81a07fd2c8df9d336f864, cef9712200bbe2c3873eec3ca2e18a);
	}

	public void c687c56ed531550f24368180c4c3bc947(MenuItemDef[] c6ffe00a26fa81a07fd2c8df9d336f864, Vector2 cef9712200bbe2c3873eec3ca2e18a595, MouseClickHooker c8ec8b5b0f7b040226698be31ffc9d9c9 = null)
	{
		_bCursorLockState = Screen.lockCursor;
		_arrCurrentMenu.Clear();
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1bdd1e7aa891de56d871ae24289f5f8b();
		c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cca84ca4deababdecf8f3d8cc7a45edb9();
		_arrCurrentMenu.AddRange(c6ffe00a26fa81a07fd2c8df9d336f864);
		_position = cef9712200bbe2c3873eec3ca2e18a595;
		c150264a18c2cb408479d3f072cac8cc1 = true;
		cee3f7e1f2fe80146187019ef16248436();
		_funcMouseClkHooker = c8ec8b5b0f7b040226698be31ffc9d9c9;
	}

	protected void c74d5d0129904385e473258ef8327225b(int c94d6d23bf4cb406cc7b215b0991afb4f)
	{
		MenuItemDef menuItemDef = new MenuItemDef(string.Empty, null, cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e);
		if (c94d6d23bf4cb406cc7b215b0991afb4f >= 0)
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
			if (c94d6d23bf4cb406cc7b215b0991afb4f < _arrCurrentMenu.Count)
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
				menuItemDef = _arrCurrentMenu[c94d6d23bf4cb406cc7b215b0991afb4f];
			}
		}
		if (_funcMouseClkHooker == null)
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
			c5bc8bb6c6b44d3d5bf9249765a5d8e27();
		}
		else
		{
			_funcMouseClkHooker(c94d6d23bf4cb406cc7b215b0991afb4f);
		}
		if (menuItemDef.itemFunc == null)
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
			menuItemDef.itemFunc(menuItemDef.itemData);
			return;
		}
	}

	public void c5bc8bb6c6b44d3d5bf9249765a5d8e27()
	{
		if (_bCursorLockState)
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
			c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1570506bf0b326e191d0406037cb4fef();
			c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0888ee52497af70d4cc14624cbd11269();
		}
		_arrCurrentMenu.Clear();
		c21e36f8cd23459c6af056b4a8a451e4c();
		c150264a18c2cb408479d3f072cac8cc1 = false;
		_funcMouseClkHooker = null;
	}

	protected virtual void cee3f7e1f2fe80146187019ef16248436()
	{
	}

	protected virtual void c21e36f8cd23459c6af056b4a8a451e4c()
	{
	}

	protected void c3640a188d930db43e2c25dbef10d9af6(int c9526cedaae8a6f13c52592df57f78e6e)
	{
		c74d5d0129904385e473258ef8327225b(c9526cedaae8a6f13c52592df57f78e6e);
	}
}
