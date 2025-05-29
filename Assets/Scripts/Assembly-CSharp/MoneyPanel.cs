using System;
using A;
using Core;
using UnityEngine;
using pumpkin.display;

public class MoneyPanel : c196099a1254db61d3be10d70e14e7422
{
	private const string SLOT_NAME = "mcSlotBit_";

	private const string Number_NAME = "Number_";

	private const int SLOT_NUMBER = 8;

	protected MovieClip[] _arrNumberSlots;

	protected int _iMoneyValue;

	public MoneyPanel()
	{
		_arrNumberSlots = c2376ea3bd38aedb0e6abb20d59d298e8.c0a0cdf4a196914163f7334d9b0781a04(8);
	}

	protected override void c969016383f47c249932cc75475f00ae1()
	{
		base.c969016383f47c249932cc75475f00ae1();
	}

	protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool result = false;
		if (movieClip.name.Length > "mcSlotBit_".Length)
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
			string text = movieClip.name.Substring(0, "mcSlotBit_".Length);
			if (text == "mcSlotBit_")
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
					{
						int num = Convert.ToInt32(movieClip.name.Substring("mcSlotBit_".Length, movieClip.name.Length - "mcSlotBit_".Length));
						if (num < _arrNumberSlots.Length)
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
							if (num >= 0)
							{
								_arrNumberSlots[num] = movieClip;
								return true;
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
						}
						object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
						array[0] = "Money name wrong! Index:";
						array[1] = num;
						array[2] = " is bigger than sum: ";
						array[3] = 8;
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array));
						return true;
					}
					}
				}
			}
		}
		return result;
	}

	public void ca422f6f2e66465eb697c47f8f5c61516(int c6b81e5ffe7e1f7e3eec582ca933c63e0)
	{
		_iMoneyValue = Mathf.FloorToInt(c1ee7921b0c3cce194fb7cae41b5a9d82<ShopServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4a75d81249f55113c773cfaeb64936ea.m_soldRatio * (float)c6b81e5ffe7e1f7e3eec582ca933c63e0);
		int num = -1;
		int num2 = _iMoneyValue;
		for (int i = 0; i < 8; i++)
		{
			if (_arrNumberSlots[i] == null)
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
			}
			else if (num2 > 0)
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
				num = num2 % 10;
				num2 = Mathf.FloorToInt(num2 / 10);
				_arrNumberSlots[i].gotoAndStop("Number_" + num);
			}
			else
			{
				_arrNumberSlots[i].gotoAndStop("Number_none");
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}
}
