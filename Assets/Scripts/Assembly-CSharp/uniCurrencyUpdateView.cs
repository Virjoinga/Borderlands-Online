using System;
using System.Collections.Generic;
using A;
using Core;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniCurrencyUpdateView : CurrencyUpdateView
{
	public class AmmoGainEffect : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip mcRoot;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcRoot = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("mcRoot");
			mcRoot.visible = false;
			mcRoot.mouseEnabled = false;
		}

		public void c0a75d7afd2f7f1e47a5aadaab61303c7()
		{
			mcRoot.visible = true;
			mcRoot.gotoAndPlay("fadein");
		}
	}

	public class UIMoneySlotMachine : c196099a1254db61d3be10d70e14e7422
	{
		protected const int SLOT_MACHINE_BIT_COUNT = 8;

		protected const string SLOT_NAME_PREFIX = "mcSlotBit_";

		protected const string SLOTBG_NAME_PREFIX = "mcSlotBitBG_";

		protected const string DOLLARSYMBOL_NAME_PREFIX = "mcDollarSymbol_";

		protected MovieClip _rootMC;

		protected UIMoneySlotMachineBit[] _slotBits = new UIMoneySlotMachineBit[8];

		protected MovieClip[] _slotBG = c2376ea3bd38aedb0e6abb20d59d298e8.c0a0cdf4a196914163f7334d9b0781a04(8);

		protected MovieClip[] _dollarSymbol = c2376ea3bd38aedb0e6abb20d59d298e8.c0a0cdf4a196914163f7334d9b0781a04(8);

		protected List<int> _curNumSequence;

		protected List<int> _tarNumSequence;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			if (movieClip.name.Contains("mcSlotBit_"))
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
				result = true;
				string name = movieClip.name;
				char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = '_';
				string[] array2 = name.Split(array);
				int num = Convert.ToInt32(array2[1]);
				if (num >= 1)
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
					if (num <= 8)
					{
						movieClip.visible = false;
						if (_slotBits[num - 1] == null)
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
							_slotBits[num - 1] = new UIMoneySlotMachineBit();
						}
						_slotBits[num - 1].c130648b59a0c8debea60aa153f844879(movieClip);
						goto IL_020e;
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "Wrong Slot machine bit name " + movieClip.name);
			}
			else if (movieClip.name.Contains("mcSlotBitBG_"))
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
				result = true;
				string name2 = movieClip.name;
				char[] array3 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
				array3[0] = '_';
				string[] array4 = name2.Split(array3);
				int num2 = Convert.ToInt32(array4[1]);
				if (num2 >= 1)
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
					if (num2 <= 8)
					{
						_slotBG[num2 - 1] = movieClip;
						movieClip.visible = false;
						goto IL_020e;
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
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "Wrong Slot machine bit BG name " + movieClip.name);
			}
			else if (movieClip.name.Contains("mcDollarSymbol_"))
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
				result = true;
				string name3 = movieClip.name;
				char[] array5 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
				array5[0] = '_';
				string[] array6 = name3.Split(array5);
				int num3 = Convert.ToInt32(array6[1]);
				if (num3 >= 1)
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
					if (num3 <= 8)
					{
						_dollarSymbol[num3 - 1] = movieClip;
						movieClip.visible = false;
						goto IL_020e;
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
				}
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "Wrong Dollar Symbol name " + movieClip.name);
			}
			goto IL_020e;
			IL_020e:
			return result;
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_rootMC = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			_rootMC.visible = false;
		}

		public void ce2bcbd7a318cd1d20e00c4fc086f8e71(int cf08a897ffade5deb445615f6a1c76a3c, int ccac4f7af17f5353bb30affea3d2cef4e)
		{
			int i = 0;
			_curNumSequence = c8f571f121b48bb30bcaebe4fdeeaf0c1(cf08a897ffade5deb445615f6a1c76a3c);
			_tarNumSequence = c8f571f121b48bb30bcaebe4fdeeaf0c1(ccac4f7af17f5353bb30affea3d2cef4e);
			int count;
			if (_tarNumSequence.Count > _curNumSequence.Count)
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
				count = _tarNumSequence.Count;
			}
			else
			{
				count = _curNumSequence.Count;
			}
			int num = count;
			int count2;
			if (_tarNumSequence.Count < _curNumSequence.Count)
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
				count2 = _tarNumSequence.Count;
			}
			else
			{
				count2 = _curNumSequence.Count;
			}
			int num2 = count2;
			MovieClip[] dollarSymbol = _dollarSymbol;
			foreach (MovieClip movieClip in dollarSymbol)
			{
				movieClip.visible = false;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (num > 0)
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
					_dollarSymbol[num - 1].visible = true;
				}
				for (; i < num2; i++)
				{
					_slotBG[i].visible = true;
					_slotBits[i].c43cbb41bf755dfa61de619fc6e86ab31(true);
					if (_tarNumSequence[i] == _curNumSequence[i])
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
						_slotBits[i].cdada4c3678c9c23c38aaf0754a94a620(_tarNumSequence[i]);
					}
					else
					{
						_slotBits[i].ce2bcbd7a318cd1d20e00c4fc086f8e71(_tarNumSequence[i]);
					}
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					if (num > num2)
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
						for (; i < num; i++)
						{
							int num3;
							if (num == _tarNumSequence.Count)
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
								num3 = _tarNumSequence[i];
							}
							else
							{
								num3 = 0;
							}
							int c94309deb88d2b1d167b132a063e3595a = num3;
							_slotBits[i].ce2bcbd7a318cd1d20e00c4fc086f8e71(c94309deb88d2b1d167b132a063e3595a);
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
					for (; i < 8; i++)
					{
						_slotBits[i].c43cbb41bf755dfa61de619fc6e86ab31(false);
						_slotBG[i].visible = false;
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

		public void cdada4c3678c9c23c38aaf0754a94a620(int cf08a897ffade5deb445615f6a1c76a3c, int ccac4f7af17f5353bb30affea3d2cef4e)
		{
			int i = 0;
			_curNumSequence = c8f571f121b48bb30bcaebe4fdeeaf0c1(cf08a897ffade5deb445615f6a1c76a3c);
			_tarNumSequence = c8f571f121b48bb30bcaebe4fdeeaf0c1(ccac4f7af17f5353bb30affea3d2cef4e);
			int count;
			if (_tarNumSequence.Count > _curNumSequence.Count)
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
				count = _tarNumSequence.Count;
			}
			else
			{
				count = _curNumSequence.Count;
			}
			int num = count;
			MovieClip[] dollarSymbol = _dollarSymbol;
			foreach (MovieClip movieClip in dollarSymbol)
			{
				movieClip.visible = false;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (num > 0)
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
					_dollarSymbol[num - 1].visible = true;
				}
				for (; i < num; i++)
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
					if (i < 8)
					{
						int num2;
						if (i < _curNumSequence.Count)
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
							num2 = _curNumSequence[i];
						}
						else
						{
							num2 = 0;
						}
						int c94309deb88d2b1d167b132a063e3595a = num2;
						_slotBits[i].cdada4c3678c9c23c38aaf0754a94a620(c94309deb88d2b1d167b132a063e3595a);
						_slotBits[i].c43cbb41bf755dfa61de619fc6e86ab31(true);
						_slotBG[i].visible = true;
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
					break;
				}
				for (; i < 8; i++)
				{
					_slotBits[i].c43cbb41bf755dfa61de619fc6e86ab31(false);
					_slotBG[i].visible = false;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}

		protected List<int> c8f571f121b48bb30bcaebe4fdeeaf0c1(int ccac4f7af17f5353bb30affea3d2cef4e)
		{
			List<int> list = new List<int>();
			while (ccac4f7af17f5353bb30affea3d2cef4e != 0)
			{
				int item = ccac4f7af17f5353bb30affea3d2cef4e % 10;
				list.Add(item);
				ccac4f7af17f5353bb30affea3d2cef4e /= 10;
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
				return list;
			}
		}
	}

	public class UIMoneySlotMachineBit : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip _rootMC;

		protected MovieClip _slotBitMC;

		protected string _strFramePrefix = "Number_";

		protected string _strSlotPrefix = "mcSLot_";

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_rootMC = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			_rootMC.visible = false;
		}

		public void c43cbb41bf755dfa61de619fc6e86ab31(bool c74232243aff1dcbf2e8fc243633bb51a)
		{
			if (_rootMC == null)
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
				_rootMC.visible = c74232243aff1dcbf2e8fc243633bb51a;
				return;
			}
		}

		public void ce2bcbd7a318cd1d20e00c4fc086f8e71(int c94309deb88d2b1d167b132a063e3595a)
		{
			if (!c7f1991582abee274ccce62faa5f2506b(c94309deb88d2b1d167b132a063e3595a))
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
				_slotBitMC.gotoAndPlay("Start");
				return;
			}
		}

		public void cdada4c3678c9c23c38aaf0754a94a620(int c94309deb88d2b1d167b132a063e3595a)
		{
			if (!c7f1991582abee274ccce62faa5f2506b(c94309deb88d2b1d167b132a063e3595a))
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
				_slotBitMC.gotoAndStop("Final");
				return;
			}
		}

		protected bool c7f1991582abee274ccce62faa5f2506b(int c94309deb88d2b1d167b132a063e3595a)
		{
			bool result = false;
			if (c94309deb88d2b1d167b132a063e3595a >= 0)
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
				if (c94309deb88d2b1d167b132a063e3595a <= 9)
				{
					if (_rootMC != null)
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
						string to = _strFramePrefix + c94309deb88d2b1d167b132a063e3595a;
						_rootMC.gotoAndStop(to);
						string name = _strSlotPrefix + c94309deb88d2b1d167b132a063e3595a;
						_slotBitMC = _rootMC.getChildByName<MovieClip>(name);
						if (_slotBitMC != null)
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
							result = true;
						}
					}
					return result;
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
			array[0] = "Wrong slot machine bit num at ";
			array[1] = _rootMC.name;
			array[2] = "  value : ";
			array[3] = c94309deb88d2b1d167b132a063e3595a;
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, string.Concat(array));
			return result;
		}
	}

	protected c196099a1254db61d3be10d70e14e7422 _root;

	protected MovieClip _rootMC;

	protected UIMoneySlotMachine _slotMachine;

	protected AmmoGainEffect _ammoPanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Money_Value.swf", "Movie_MoneyAnimaRoot", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Ammo_Value.swf", "Panel_Ammo_Value", cd5817ba9c2890468b9f8dae09370ec7b);
	}

	private void cd5817ba9c2890468b9f8dae09370ec7b(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_ammoPanel = new AmmoGainEffect();
		_ammoPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.stop();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_ammoPanel);
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_root = new c196099a1254db61d3be10d70e14e7422();
		_root.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_rootMC = cbe9ca8ddb3cdc2312e6ff8411b2db2c8.getChildByName<MovieClip>("mcMoneyAnimation");
		if (_rootMC == null)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "Can not find MovieClip : mcMoneyAnimation");
					return;
				}
			}
		}
		_rootMC.addFrameScript("KeyFrame_1", c46531bf8dd90b4a97a822cb61e6f253c);
		_rootMC.addFrameScript("KeyFrame_2", c46531bf8dd90b4a97a822cb61e6f253c);
		_rootMC.addFrameScript("KeyFrame_3", c46531bf8dd90b4a97a822cb61e6f253c);
		_rootMC.addFrameScript("disappear", c006caa8efcaf62e2ef8c341ea18d7c2d);
		_rootMC.addFrameScript("normal", c21e57127e35f2b9fdb4fe0a069f045b9);
		_rootMC.addFrameScript("getNewacount", cb1c7b8485a0b06ba30a9524b27699725);
		_rootMC.addFrameScript("fadeout", c3eb3a3106dcdc1fbb46d89ba1f278533);
		_rootMC.addFrameScript("fadeoutEnd", c90b8f3c7c55511377f8b8d0554b881be);
		_rootMC.visible = false;
		_slotMachine = new UIMoneySlotMachine();
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_ammoPanel);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Ammo_Value.swf");
		_ammoPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_root);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Money_Value.swf");
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (_rootMC == null)
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
		if (c8be1fcd630e5fe96821376d111325750)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_root);
					_rootMC.visible = true;
					_rootMC.gotoAndPlay("fadein");
					return;
				}
			}
		}
		_rootMC.gotoAndPlay("fadeout");
	}

	protected override void c3723bc2341f87418cba5e783555f62f0()
	{
		base.c3723bc2341f87418cba5e783555f62f0();
		if (_rootMC == null)
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
			_rootMC.visible = true;
			_rootMC.gotoAndPlay("getNewacount");
			return;
		}
	}

	protected void c21e57127e35f2b9fdb4fe0a069f045b9(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		_curStatus = SlotMachineAnimaStatus.Normal;
		c6dd9bbf0b0808e0e305ffbbbf9734815();
	}

	protected void cb1c7b8485a0b06ba30a9524b27699725(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcDeltaMoney");
		if (childByName != null)
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
			childByName.addFrameScript("Start", c006caa8efcaf62e2ef8c341ea18d7c2d);
			childByName.addFrameScript("KeyFrame_1", c006caa8efcaf62e2ef8c341ea18d7c2d);
			childByName.addFrameScript("KeyFrame_2", c006caa8efcaf62e2ef8c341ea18d7c2d);
			childByName.addFrameScript("KeyFrame_3", c006caa8efcaf62e2ef8c341ea18d7c2d);
			childByName.addFrameScript("KeyFrame_4", c006caa8efcaf62e2ef8c341ea18d7c2d);
			childByName.gotoAndPlay("Start");
		}
		_slotMachine.ce2bcbd7a318cd1d20e00c4fc086f8e71(_iCurMoneyAmount, _iTarMoneyAmount);
	}

	protected void c46531bf8dd90b4a97a822cb61e6f253c(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		c39f09b39c2daa300759c28dce41877c5();
	}

	protected void c006caa8efcaf62e2ef8c341ea18d7c2d(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cae42a80bbb60d370cb1bfbfa040925a6();
	}

	protected void c3eb3a3106dcdc1fbb46d89ba1f278533(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cff51e7d7a60eed5b9546252eaabc3433();
	}

	protected void c90b8f3c7c55511377f8b8d0554b881be(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		_rootMC.visible = false;
		c4db5fa5386f84039532ef81b7823c3d9();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_root);
	}

	protected void cae42a80bbb60d370cb1bfbfa040925a6()
	{
		int num = _iTarMoneyAmount - _iCurMoneyAmount;
		MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcDeltaMoney");
		if (childByName == null)
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
			MovieClip childByName2 = childByName.getChildByName<MovieClip>("mcMoneyCount");
			if (num > 0)
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
				childByName2.gotoAndStop("Gain");
			}
			else
			{
				childByName2.gotoAndStop("Lose");
			}
			UnityTextField unityTextField = (UnityTextField)childByName2.getChildByName<TextField>("textDelta");
			if (unityTextField == null)
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
				string c7088de59e49f7108f520cf7e0bae167e = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
				if (num > 0)
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
					c7088de59e49f7108f520cf7e0bae167e = "+" + num;
				}
				else
				{
					c7088de59e49f7108f520cf7e0bae167e = num.ToString();
				}
				unityTextField.text = c7088de59e49f7108f520cf7e0bae167e;
				return;
			}
		}
	}

	protected void c39f09b39c2daa300759c28dce41877c5()
	{
		MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcSlotMachine");
		_slotMachine.c130648b59a0c8debea60aa153f844879(childByName);
		_slotMachine.cdada4c3678c9c23c38aaf0754a94a620(_iCurMoneyAmount, _iTarMoneyAmount);
	}

	public override void c4c93611d50d24eb4ab3a3549d4422105(bool cec71e896a1c86e99ae329fd9aaab93e8 = false)
	{
		base.c4c93611d50d24eb4ab3a3549d4422105(cec71e896a1c86e99ae329fd9aaab93e8);
		_ammoPanel.c0a75d7afd2f7f1e47a5aadaab61303c7();
	}
}
