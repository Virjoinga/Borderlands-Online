using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;
using pumpkin.geom;

internal class ExpandPanel : c196099a1254db61d3be10d70e14e7422
{
	protected class ElementState
	{
		public Vector2 vecOrinSize;

		public Vector2 vecOrinPos;

		public float fOffset;
	}

	protected const string ELEM_NAME = "element";

	protected int _iExpandIndex = -1;

	protected List<MovieClip> _arrElemList;

	protected List<ElementState> _arrElemStateList;

	protected bool _bHorizontal = true;

	protected MovieClip mcSelf;

	protected string _strMaskName = string.Empty;

	protected string _strMaskedChild = string.Empty;

	public ExpandPanel()
	{
		_arrElemList = new List<MovieClip>();
		_arrElemStateList = new List<ElementState>();
	}

	public void c3fb55599d4047226010e75d667d65f43(string c3fe88f2f682b5ad7d0b3e1d9ece6b8b7, string c56c9f2a170a8e0bea91018bb97084f04)
	{
		_strMaskName = c3fe88f2f682b5ad7d0b3e1d9ece6b8b7;
		_strMaskedChild = c56c9f2a170a8e0bea91018bb97084f04;
	}

	protected override void c969016383f47c249932cc75475f00ae1()
	{
		base.c969016383f47c249932cc75475f00ae1();
		mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
		if (mcSelf == null)
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
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
		}
		string symbolName = mcSelf.getSymbolName();
		char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = '_';
		string[] array2 = symbolName.Split(array);
		if (array2[1] != null)
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
			if (array2[1].ToLower() == "v")
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
				_bHorizontal = false;
			}
		}
		mcSelf.addEventListener(CEvent.ENTER_FRAME, c76216b0160127678d814881927d77f3e);
	}

	public void c6e9df472ca5f99cfa7a405bcfed3cc2b(int c5612a459a84ffdb41c885401433cd62d = 0)
	{
		if (_iExpandIndex == c5612a459a84ffdb41c885401433cd62d)
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
		int iExpandIndex = _iExpandIndex;
		_iExpandIndex = c5612a459a84ffdb41c885401433cd62d;
		if (_arrElemList.Count <= 0)
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
			if (c5612a459a84ffdb41c885401433cd62d >= _arrElemList.Count)
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
				if (iExpandIndex != -1)
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
					_arrElemList[iExpandIndex].gotoAndPlay("shrinkStart");
				}
				_arrElemList[c5612a459a84ffdb41c885401433cd62d].gotoAndPlay("expandStart");
				return;
			}
		}
	}

	protected void cf2e8367fbce4c190d75d4517861225d7(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
	}

	protected void c3b95085df80c2b5bdb93930d91e3eeff(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
	}

	protected void c76216b0160127678d814881927d77f3e(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		mcSelf.removeEventListener(CEvent.ENTER_FRAME, c76216b0160127678d814881927d77f3e);
		MovieClip c7088de59e49f7108f520cf7e0bae167e = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
		int num = 0;
		do
		{
			c7088de59e49f7108f520cf7e0bae167e = mcSelf.getChildByName("element" + num) as MovieClip;
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				ElementState elementState = new ElementState();
				elementState.vecOrinPos = new Vector2(c7088de59e49f7108f520cf7e0bae167e.x, c7088de59e49f7108f520cf7e0bae167e.y);
				DisplayObject childByName = c7088de59e49f7108f520cf7e0bae167e.getChildByName<DisplayObject>(_strMaskName);
				elementState.vecOrinSize = Vector2.zero;
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
					elementState.vecOrinSize = new Vector2(childByName.width, childByName.height);
				}
				c7088de59e49f7108f520cf7e0bae167e.userData = num;
				if (_bHorizontal)
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
					c7088de59e49f7108f520cf7e0bae167e.addEventListener(CEvent.ENTER_FRAME, cf2e8367fbce4c190d75d4517861225d7);
				}
				else
				{
					c7088de59e49f7108f520cf7e0bae167e.addEventListener(CEvent.ENTER_FRAME, c3b95085df80c2b5bdb93930d91e3eeff);
				}
				if (num != _iExpandIndex)
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
					c7088de59e49f7108f520cf7e0bae167e.gotoAndStop("shrinked");
				}
				_arrElemList.Add(c7088de59e49f7108f520cf7e0bae167e);
				_arrElemStateList.Add(elementState);
			}
			num++;
		}
		while (c7088de59e49f7108f520cf7e0bae167e != null);
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			c6e9df472ca5f99cfa7a405bcfed3cc2b(_iExpandIndex);
			return;
		}
	}

	protected void c42bc8d875f9889daa54eb27caddd7120(int c5612a459a84ffdb41c885401433cd62d)
	{
		float num = 0f;
		ce24f7954663fe09cbaac77668929fd6c(_arrElemList[c5612a459a84ffdb41c885401433cd62d], _strMaskName, _strMaskedChild);
		for (int i = 0; i < c5612a459a84ffdb41c885401433cd62d; i++)
		{
			num += _arrElemStateList[i].fOffset;
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
			_arrElemList[c5612a459a84ffdb41c885401433cd62d].x = _arrElemStateList[c5612a459a84ffdb41c885401433cd62d].vecOrinPos.x + num;
			DisplayObject childByName = _arrElemList[c5612a459a84ffdb41c885401433cd62d].getChildByName<DisplayObject>(_strMaskName);
			_arrElemStateList[c5612a459a84ffdb41c885401433cd62d].fOffset = childByName.width - _arrElemStateList[c5612a459a84ffdb41c885401433cd62d].vecOrinSize.x;
			return;
		}
	}

	protected void cb002dad39a9757f923166d66abcc3bc2(int c5612a459a84ffdb41c885401433cd62d)
	{
		float num = 0f;
		ce24f7954663fe09cbaac77668929fd6c(_arrElemList[c5612a459a84ffdb41c885401433cd62d], _strMaskName, _strMaskedChild);
		for (int i = 0; i < c5612a459a84ffdb41c885401433cd62d; i++)
		{
			num += _arrElemStateList[i].fOffset;
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
			_arrElemList[c5612a459a84ffdb41c885401433cd62d].y = _arrElemStateList[c5612a459a84ffdb41c885401433cd62d].vecOrinPos.y + num;
			DisplayObject childByName = _arrElemList[c5612a459a84ffdb41c885401433cd62d].getChildByName<DisplayObject>(_strMaskName);
			_arrElemStateList[c5612a459a84ffdb41c885401433cd62d].fOffset = childByName.height - _arrElemStateList[c5612a459a84ffdb41c885401433cd62d].vecOrinSize.y;
			return;
		}
	}

	public void ce24f7954663fe09cbaac77668929fd6c(MovieClip c3cb1f1345dbfd94c51709a9b2e9a9704, string c25628daf35e442cef159b98056ddbd48, string c4fb25df90c3625b98b7a405b83e51b81)
	{
		if (c3cb1f1345dbfd94c51709a9b2e9a9704 == null)
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
			if (c25628daf35e442cef159b98056ddbd48 == null)
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
				if (c25628daf35e442cef159b98056ddbd48 == string.Empty)
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
				DisplayObject childByName = c3cb1f1345dbfd94c51709a9b2e9a9704.getChildByName(c25628daf35e442cef159b98056ddbd48);
				DisplayObject displayObject = c3cb1f1345dbfd94c51709a9b2e9a9704.getChildByName(c4fb25df90c3625b98b7a405b83e51b81);
				if (displayObject == null)
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
					displayObject = c3cb1f1345dbfd94c51709a9b2e9a9704;
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, " --- null!!!! ");
				}
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
					Rectangle bounds = childByName.getBounds(displayObject);
					displayObject.clipRect = bounds.rect;
					return;
				}
			}
		}
	}
}
