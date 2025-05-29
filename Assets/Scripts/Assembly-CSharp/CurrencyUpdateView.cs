using A;
using UnityEngine;

public class CurrencyUpdateView : BaseView
{
	public enum SlotMachineAnimaStatus
	{
		None = 0,
		FadeIn = 1,
		ShowDelta = 2,
		Normal = 3,
		FadeOut = 4
	}

	protected class currencyUpdateListener : ICharacterServiceNotificationListerner
	{
		public CurrencyUpdateView RootView;

		public void OnGotMyCurrencies(CurrencyInfo currency)
		{
			if (RootView == null)
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
			if (!RootView.c42d1d57c94c6c92fe67bcd3b65757664)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						RootView.cf777b31f4340d66ce59d63bea6447a1a(currency.BondCurrency);
						RootView.c42d1d57c94c6c92fe67bcd3b65757664 = true;
						return;
					}
				}
			}
			RootView.cf078ee2364d62350a0925cc2e817bf76(currency.BondCurrency);
		}

		public void OnExperienceUpdated(int experience)
		{
		}

		public void OnGetPersonalSettings(string strSettings)
		{
		}

		public void OnSetPersonalSettings(int iReslut)
		{
		}
	}

	protected const float NORMAL_STATUS_DURTION = 1f;

	protected int _iCurMoneyAmount;

	protected int _iTarMoneyAmount;

	protected SlotMachineAnimaStatus _curStatus;

	protected bool _bMoneyCountInited;

	protected float _fDeltaTime;

	protected currencyUpdateListener _currencyUpdateListener;

	public bool c42d1d57c94c6c92fe67bcd3b65757664
	{
		get
		{
			return _bMoneyCountInited;
		}
		set
		{
			_bMoneyCountInited = value;
		}
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c239889f6079aa61647e3c4b8f3627d00(c12b196ef16d3d89b666906481f435d35);
		_currencyUpdateListener = new currencyUpdateListener();
		_currencyUpdateListener.RootView = this;
		_bMoneyCountInited = false;
		_fDeltaTime = 0f;
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(_currencyUpdateListener);
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ceaf946a4b1d023143d622c7be7019235();
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c0bd653723f77fd78e6c7d4d25ed14dcd(c12b196ef16d3d89b666906481f435d35);
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c704834a4a19f1f8555b44d9c021845ab(_currencyUpdateListener);
		_currencyUpdateListener = null;
		_bMoneyCountInited = false;
	}

	public virtual void cf078ee2364d62350a0925cc2e817bf76(int c927ae6f6adb068c807290589cdad2b8a)
	{
		_iTarMoneyAmount = c927ae6f6adb068c807290589cdad2b8a;
		if (_iTarMoneyAmount == _iCurMoneyAmount)
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
		if (_curStatus == SlotMachineAnimaStatus.None)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					cbf5f806ecf4d92b475f68040522616cf(true);
					return;
				}
			}
		}
		if (_curStatus == SlotMachineAnimaStatus.FadeIn)
		{
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
		c3723bc2341f87418cba5e783555f62f0();
	}

	protected virtual void c074724ba91a1a2755813047719879b8d()
	{
	}

	protected virtual void cce09be34ce60bbc6a3817c65ec4a46f3()
	{
	}

	protected virtual void c6dd9bbf0b0808e0e305ffbbbf9734815()
	{
		_iCurMoneyAmount = _iTarMoneyAmount;
	}

	protected virtual void cff51e7d7a60eed5b9546252eaabc3433()
	{
	}

	protected virtual void c4db5fa5386f84039532ef81b7823c3d9()
	{
		_curStatus = SlotMachineAnimaStatus.None;
	}

	protected virtual void c3723bc2341f87418cba5e783555f62f0()
	{
		_curStatus = SlotMachineAnimaStatus.ShowDelta;
	}

	public virtual void cf777b31f4340d66ce59d63bea6447a1a(int cfc9f863ce920ec222226647f8ab16603)
	{
		if (_bMoneyCountInited)
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
			_iCurMoneyAmount = cfc9f863ce920ec222226647f8ab16603;
			_iTarMoneyAmount = cfc9f863ce920ec222226647f8ab16603;
			_bMoneyCountInited = true;
			return;
		}
	}

	public virtual void c83911ddf53d8a41720a6b49d8db3cae9()
	{
		cbf5f806ecf4d92b475f68040522616cf(false);
		_curStatus = SlotMachineAnimaStatus.FadeOut;
		cff51e7d7a60eed5b9546252eaabc3433();
		_fDeltaTime = 0f;
	}

	private void c12b196ef16d3d89b666906481f435d35()
	{
		if (!_bMoneyCountInited)
		{
			while (true)
			{
				switch (2)
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
		if (_curStatus != SlotMachineAnimaStatus.Normal)
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
			_fDeltaTime += Time.deltaTime;
			if (!(_fDeltaTime > 1f))
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
				c83911ddf53d8a41720a6b49d8db3cae9();
				return;
			}
		}
	}

	public virtual void c4c93611d50d24eb4ab3a3549d4422105(bool cec71e896a1c86e99ae329fd9aaab93e8 = false)
	{
	}
}
