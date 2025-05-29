using System;
using A;
using Core;
using pumpkin.display;
using pumpkin.events;

public class WeaponSlotPanel : c196099a1254db61d3be10d70e14e7422
{
	protected const string WEAPON_SLOT_PREFIX_NAME = "mcSlot";

	protected MovieClip mcRoot;

	protected MovieClip mcSelf;

	protected UnityTextField tfSlotNumber;

	protected MovieClip[] _arrWeaponSlots = c2376ea3bd38aedb0e6abb20d59d298e8.c0a0cdf4a196914163f7334d9b0781a04(4);

	protected ItemDNA[] _arrWeapons;

	protected int _iLevel;

	protected bool _bVisible;

	public virtual bool c150264a18c2cb408479d3f072cac8cc1
	{
		get
		{
			if (mcSelf != null)
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
						return _bVisible;
					}
				}
			}
			return false;
		}
		set
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
			if (_bVisible == value)
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
			_bVisible = value;
			if (value)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						mcSelf.visible = value;
						mcSelf.gotoAndPlay("in");
						return;
					}
				}
			}
			mcSelf.gotoAndPlay("out");
			mcSelf.addFrameScript("end", ca45aa4038153928bb3c25fc71e6c45e1);
		}
	}

	protected override void c969016383f47c249932cc75475f00ae1()
	{
		base.c969016383f47c249932cc75475f00ae1();
		mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
		if (mcSelf == null)
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
					return;
				}
			}
		}
		mcSelf.stop();
		mcSelf.visible = false;
	}

	protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		if (movieClip.name.Length > "mcSlot".Length)
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
			string text = movieClip.name.Substring(0, "mcSlot".Length);
			if (text == "mcSlot")
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
					{
						int num = Convert.ToInt32(movieClip.name.Substring("mcSlot".Length, movieClip.name.Length - "mcSlot".Length));
						if (num < _arrWeaponSlots.Length)
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
							if (num >= 0)
							{
								movieClip.addEventListener(CEvent.ENTER_FRAME, cf10e9c95b696aad12824d067d0f4481f);
								movieClip.userData = num;
								_arrWeaponSlots[num] = movieClip;
								return true;
							}
							while (true)
							{
								switch (7)
								{
								case 0:
									continue;
								}
								break;
							}
						}
						object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
						array[0] = "Hud weapon slot name wrong! Index:";
						array[1] = num;
						array[2] = " is bigger than sum: ";
						array[3] = _arrWeaponSlots.Length;
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array));
						return true;
					}
					}
				}
			}
		}
		return false;
	}

	protected void cf10e9c95b696aad12824d067d0f4481f(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		MovieClip movieClip = c3d202dee321219a80026dc3081fb3c86.currentTarget as MovieClip;
		if (movieClip == null)
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
			int num = (int)movieClip.userData;
			UnityTextField childByName = movieClip.getChildByName<UnityTextField>("textField");
			if (childByName != null)
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
				childByName.text = (num + 1).ToString();
			}
			if (_arrWeapons == null)
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
				if (_arrWeapons[num] == null)
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
					MovieClip childByName2 = movieClip.getChildByName<MovieClip>("mcIcon");
					if (childByName2 == null)
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
						childByName2.gotoAndStop(_arrWeapons[num].ca79da172938fdc8c067fb64242b6174a().c83e548e5608cd7f222098a6966b16545().ToString());
						return;
					}
				}
			}
		}
	}

	private void ca45aa4038153928bb3c25fc71e6c45e1(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		mcSelf.removeFrameScript("end", ca45aa4038153928bb3c25fc71e6c45e1);
		mcSelf.visible = false;
	}

	public void Update(ItemDNA[] arrWeapons, int activeIndex)
	{
		_arrWeapons = arrWeapons;
		if (_arrWeapons == null)
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
			for (int i = 0; i < 4; i++)
			{
				string to = "none";
				if (_arrWeapons[i] != null)
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
					object obj;
					if (i == activeIndex)
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
						obj = "actived";
					}
					else
					{
						obj = "normal";
					}
					to = (string)obj;
				}
				_arrWeaponSlots[i].gotoAndStop(to);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}
}
