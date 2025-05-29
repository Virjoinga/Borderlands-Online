using System;
using UnityEngine;

[Serializable]
public sealed class Pair<TLeft, TRight>
{
	[SerializeField]
	private readonly TLeft _left;

	[SerializeField]
	private TRight _right;

	public TLeft Left
	{
		get
		{
			return _left;
		}
	}

	public TRight Right
	{
		get
		{
			return _right;
		}
		set
		{
			_right = value;
		}
	}

	public Pair(TLeft c200772a43525719cc3830217bbba5020, TRight cbe4c9ee8543f3f45b9937f7977da3e8b)
	{
		_left = c200772a43525719cc3830217bbba5020;
		_right = cbe4c9ee8543f3f45b9937f7977da3e8b;
	}

	public override int GetHashCode()
	{
		int num;
		if (_left == null)
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
			num = 0;
		}
		else
		{
			num = _left.GetHashCode();
		}
		int num2 = num;
		int num3;
		if (_right == null)
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
			num3 = 0;
		}
		else
		{
			num3 = _right.GetHashCode();
		}
		int num4 = num3;
		return num2 ^ num4;
	}

	public override bool Equals(object obj)
	{
		Pair<TLeft, TRight> pair = obj as Pair<TLeft, TRight>;
		if (pair == null)
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
					return false;
				}
			}
		}
		int result;
		if (object.Equals(_left, pair._left))
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
			result = (object.Equals(_right, pair._right) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}
}
