using System;
using System.Collections.Generic;
using A;
using UnityEngine;

public class CharacterSelectView : BaseView
{
	protected List<Character> _data;

	protected int _currentSelect;

	public CharacterSelectBehaviour _logicBehaviour;

	public override bool c57b6c6861c1d709f4f7aa7b8a699b5c9()
	{
		return false;
	}

	public override void OnTestGUI()
	{
		string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(_data.Count);
		for (int i = 0; i < _data.Count; i++)
		{
			array[i] = _data[i].Name;
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
			c2c1fbad35ca7743f1b3fc129ddc73f3f(GUI.SelectionGrid(new Rect(100f, 100f, 400f, 200f), 0, array, 1));
			if (!GUI.Button(new Rect(140f, 470f, 100f, 25f), "Enter with " + _data[_currentSelect].Name))
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
				ccd4de5ee253f41f4bb424ad2d551276c(_data[_currentSelect].Id);
				return;
			}
		}
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
	}

	public virtual void ccd4de5ee253f41f4bb424ad2d551276c(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		_logicBehaviour.ccd4de5ee253f41f4bb424ad2d551276c(c35f98ccbfa8c6bf09319c620b21b5dc5);
	}

	public virtual void c090a1e1498ac2bf3b242fa7878200faa(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		_logicBehaviour.c090a1e1498ac2bf3b242fa7878200faa(c35f98ccbfa8c6bf09319c620b21b5dc5);
	}

	public virtual void c697cea1a39d7a5dfd46cd14d3c068be3(List<Character> c591d56a94543e3559945c497f37126c4)
	{
		_data = c591d56a94543e3559945c497f37126c4;
	}

	public virtual void c2c1fbad35ca7743f1b3fc129ddc73f3f(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (_data == null)
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
		_currentSelect = Math.Max(0, Math.Min(c5612a459a84ffdb41c885401433cd62d, _data.Count - 1));
	}
}
