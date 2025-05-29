using System.Collections.Generic;
using A;
using UnityEngine;

public class PlayerListView : BaseView
{
	public delegate void SelectChangeDelegate(int index);

	public delegate void CloseMenuDelegate();

	protected List<MenuItemDef> _arrCurrentMenu = new List<MenuItemDef>();

	protected List<MenuItemDef> _subMenu = new List<MenuItemDef>();

	protected Vector2 _position;

	protected SelectChangeDelegate _onSelectedChange;

	protected CloseMenuDelegate _onMenuClosed;

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
				switch (4)
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

	public override bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		if (c150264a18c2cb408479d3f072cac8cc1)
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
			if (cd0069281ff5290a7e6c484b6aed3933d)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						c5bc8bb6c6b44d3d5bf9249765a5d8e27();
						return true;
					}
				}
			}
		}
		return false;
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

	public void ca3ea8bd7a9dcad537d36095b45cfcf5c(MenuItemDef[] c6ffe00a26fa81a07fd2c8df9d336f864)
	{
		_subMenu.Clear();
		_subMenu.AddRange(c6ffe00a26fa81a07fd2c8df9d336f864);
		c54ebee936a2ce5fd38e3577cb90f2386();
	}

	public void c687c56ed531550f24368180c4c3bc947(MenuItemDef[] c6ffe00a26fa81a07fd2c8df9d336f864, MenuItemDef[] cba2fb34ddea49181a527343170aadb90, SelectChangeDelegate c0768a1a4d0cf985f955b1e42f5c3bf7b = null, CloseMenuDelegate c9b149527649296ed336cef2b577fde36 = null)
	{
		Vector2 position = new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1bdd1e7aa891de56d871ae24289f5f8b();
		c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cca84ca4deababdecf8f3d8cc7a45edb9();
		_arrCurrentMenu.Clear();
		_arrCurrentMenu.AddRange(c6ffe00a26fa81a07fd2c8df9d336f864);
		_onSelectedChange = c0768a1a4d0cf985f955b1e42f5c3bf7b;
		_onMenuClosed = c9b149527649296ed336cef2b577fde36;
		_position = position;
		c150264a18c2cb408479d3f072cac8cc1 = true;
		ca3ea8bd7a9dcad537d36095b45cfcf5c(cba2fb34ddea49181a527343170aadb90);
		cee3f7e1f2fe80146187019ef16248436();
	}

	protected virtual void cee3f7e1f2fe80146187019ef16248436()
	{
	}

	protected virtual void c54ebee936a2ce5fd38e3577cb90f2386()
	{
	}

	protected virtual void c21e36f8cd23459c6af056b4a8a451e4c()
	{
	}

	public void c5bc8bb6c6b44d3d5bf9249765a5d8e27()
	{
		_arrCurrentMenu.Clear();
		_subMenu.Clear();
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1570506bf0b326e191d0406037cb4fef();
		c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0888ee52497af70d4cc14624cbd11269();
		c21e36f8cd23459c6af056b4a8a451e4c();
		c150264a18c2cb408479d3f072cac8cc1 = false;
		if (_onMenuClosed == null)
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
			_onMenuClosed();
			return;
		}
	}

	protected void c3640a188d930db43e2c25dbef10d9af6(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (_onSelectedChange == null)
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
			_onSelectedChange(c5612a459a84ffdb41c885401433cd62d);
			return;
		}
	}
}
