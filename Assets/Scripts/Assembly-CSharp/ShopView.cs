using System;
using System.Collections.Generic;
using A;

public class ShopView : BaseView, ICharacterServiceNotificationListerner, IShopServiceNotificationListerner
{
	public enum ShopTabState
	{
		None = 0,
		Shop = 1,
		SoldItems = 2
	}

	public class ShopItemUIData
	{
		public int iIndex;

		public ShopItem RelateData;

		public bool bAffordable;
	}

	protected float _fOnHoldingTime;

	protected int _iOnShowShopID = -1;

	protected int _iMoney = -1;

	protected Shop _onShowShop;

	protected ShopTabState _curState;

	protected TimeSpan _remainTime;

	protected int _iPendingSellIndex;

	protected int _iPendingSellQuantity;

	protected List<ShopItemUIData> _onShowItemList;

	public ShopView()
	{
		TimeSpan c36964cf41281414170f34ee68bef6c = default(TimeSpan);
		c83ae1ba42d705aff0ac83ebb7beefb54.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		_remainTime = c36964cf41281414170f34ee68bef6c;
		_iPendingSellIndex = -1;
		_iPendingSellQuantity = -1;
		_onShowItemList = new List<ShopItemUIData>();
		base._002Ector();
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cbfdeda957ab87de3d0acf25194e61c4c(this);
		c150264a18c2cb408479d3f072cac8cc1 = false;
		c1ee7921b0c3cce194fb7cae41b5a9d82<ShopServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ca2884d7256ce0aea83f1514943d01516(this);
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(this);
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ceaf946a4b1d023143d622c7be7019235();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c239889f6079aa61647e3c4b8f3627d00(c04cc4c530372db0a04d942ee08561daa);
		_curState = ShopTabState.Shop;
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cfdafa122fc114376585cbb27b8811a86(this);
		c1ee7921b0c3cce194fb7cae41b5a9d82<ShopServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ca26d27966aa77e63db313b86dba22cf2(this);
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c704834a4a19f1f8555b44d9c021845ab(this);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c0bd653723f77fd78e6c7d4d25ed14dcd(c04cc4c530372db0a04d942ee08561daa);
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (!c8be1fcd630e5fe96821376d111325750)
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
			NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.None);
			_curState = ShopTabState.Shop;
		}
		if (c8be1fcd630e5fe96821376d111325750)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cff2b0374fa4093a26652f81f964f8e9f(GameUIManager.CursorManager.CursorType.Money);
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cff2b0374fa4093a26652f81f964f8e9f(GameUIManager.CursorManager.CursorType.DefaultCursor);
	}

	public override bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		if (c150264a18c2cb408479d3f072cac8cc1)
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
					cbf5f806ecf4d92b475f68040522616cf(false);
					return true;
				}
			}
		}
		return base.cc130a2d46a451dc54b61a8f0d60794ae();
	}

	public void cf2355e2a47f860be2c9f1914df5bc924(int cf610d94618b9f7d566b3ae454dc2189f)
	{
		_iOnShowShopID = cf610d94618b9f7d566b3ae454dc2189f;
		_onShowShop = c1ee7921b0c3cce194fb7cae41b5a9d82<ShopServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cee370ce68b9715d7b8caecb310431e99(cf610d94618b9f7d566b3ae454dc2189f);
		c363ffa9972525058a49f41a533885921();
	}

	protected virtual void c04cc4c530372db0a04d942ee08561daa()
	{
		if (!_bVisible)
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
			if (_onShowShop == null)
			{
				return;
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

	protected virtual void c363ffa9972525058a49f41a533885921()
	{
		_onShowItemList.Clear();
		if (_curState == ShopTabState.None)
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
					return;
				}
			}
		}
		if (_curState == ShopTabState.Shop)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (_onShowShop != null)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								if (_onShowShop.cf29c277dedbf8f02ae332e42e112a348 != null)
								{
									while (true)
									{
										switch (1)
										{
										case 0:
											break;
										default:
										{
											for (int i = 0; i < _onShowShop.cf29c277dedbf8f02ae332e42e112a348.Count; i++)
											{
												ShopItemUIData shopItemUIData = new ShopItemUIData();
												shopItemUIData.RelateData = _onShowShop.cf29c277dedbf8f02ae332e42e112a348[i];
												shopItemUIData.iIndex = i;
												shopItemUIData.bAffordable = shopItemUIData.RelateData.Price <= _iMoney;
												_onShowItemList.Add(shopItemUIData);
											}
											while (true)
											{
												switch (6)
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
								}
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (_curState != ShopTabState.SoldItems)
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
			List<ShopItem> list = c1ee7921b0c3cce194fb7cae41b5a9d82<ShopServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c5c425976647efd150c2c4d1b924e1640();
			if (list == null)
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
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j] == null)
					{
						continue;
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
					ShopItemUIData shopItemUIData2 = new ShopItemUIData();
					shopItemUIData2.RelateData = list[j];
					shopItemUIData2.iIndex = j;
					shopItemUIData2.bAffordable = true;
					_onShowItemList.Add(shopItemUIData2);
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
	}

	protected void ce949eff967c8bef62f7ca157b7e3d4af(ShopTabState c7d77be03dd09783b7cf45209bd57d03e)
	{
		if (c7d77be03dd09783b7cf45209bd57d03e == _curState)
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
		_curState = c7d77be03dd09783b7cf45209bd57d03e;
		c363ffa9972525058a49f41a533885921();
	}

	protected void c0daf1eb16f82daaf7d68848a80e12ec8(ShopItemUIData cc79b1a9efd32e0ddd9d02036b6e5ab46, int c19c97216472918df7449a5e047301b39 = 1)
	{
		if (cc79b1a9efd32e0ddd9d02036b6e5ab46 == null)
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
			if (cc79b1a9efd32e0ddd9d02036b6e5ab46.RelateData == null)
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
				if (_onShowShop == null)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				if (!c0d940d6ded636672b15d03910df32182(cc79b1a9efd32e0ddd9d02036b6e5ab46.RelateData))
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
					c1ee7921b0c3cce194fb7cae41b5a9d82<ShopServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7f28ddd1220dda589dc52ee35675cae0(_onShowShop.Id, cc79b1a9efd32e0ddd9d02036b6e5ab46.iIndex, c19c97216472918df7449a5e047301b39);
					return;
				}
			}
		}
	}

	protected void c80a25b271ce3a17774934ece68f549eb(ShopItemUIData cc79b1a9efd32e0ddd9d02036b6e5ab46, int c19c97216472918df7449a5e047301b39 = 1)
	{
		if (cc79b1a9efd32e0ddd9d02036b6e5ab46 == null)
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
			if (cc79b1a9efd32e0ddd9d02036b6e5ab46.RelateData == null)
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
				if (_onShowShop == null)
				{
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
				if (!c0d940d6ded636672b15d03910df32182(cc79b1a9efd32e0ddd9d02036b6e5ab46.RelateData))
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
					c1ee7921b0c3cce194fb7cae41b5a9d82<ShopServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c43edc1499847c0402cc4e606bd144483(cc79b1a9efd32e0ddd9d02036b6e5ab46.iIndex);
					return;
				}
			}
		}
	}

	protected bool c0d940d6ded636672b15d03910df32182(ShopItem cc79b1a9efd32e0ddd9d02036b6e5ab46)
	{
		bool result = false;
		if (cc79b1a9efd32e0ddd9d02036b6e5ab46.Price <= _iMoney)
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
			if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c6facc64e2d5edf33221db1a902d2ccf3(cc79b1a9efd32e0ddd9d02036b6e5ab46.Item))
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
				result = true;
			}
			else
			{
				cc000a344cdad533d803612c38cc86b08();
			}
		}
		else
		{
			cc1c2481d0270b1299a68075c97ce0d6a();
		}
		return result;
	}

	protected void c2c3ac86434d1a4c7cff44aeb0e855931(int c1f39b3fb59d07b393dabdda16dac5830, int c19c97216472918df7449a5e047301b39 = 1)
	{
		if (_onShowShop == null)
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
			ItemDNA itemDNA = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c48db535623c3c5d4028ae3a36cb12dc6(c1f39b3fb59d07b393dabdda16dac5830);
			_iPendingSellIndex = c1f39b3fb59d07b393dabdda16dac5830;
			_iPendingSellQuantity = c19c97216472918df7449a5e047301b39;
			if (itemDNA.ced1a24617421c162b3c986ffdc1eb4d3())
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Warning_Shop_Sell")), c9d043fcf67d0622298737fab331bacb1, cf469c3edecd7b1ed4e6978d7842bab5e);
						return;
					}
				}
			}
			c9d043fcf67d0622298737fab331bacb1();
			return;
		}
	}

	protected virtual void cc000a344cdad533d803612c38cc86b08()
	{
	}

	protected virtual void c9d043fcf67d0622298737fab331bacb1()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<ShopServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cad34423fd2aee433703096e2c5a63d71(_onShowShop.Id, _iPendingSellIndex, _iPendingSellQuantity);
		_iPendingSellIndex = -1;
		_iPendingSellQuantity = -1;
	}

	protected void cf469c3edecd7b1ed4e6978d7842bab5e()
	{
		_iPendingSellIndex = -1;
		_iPendingSellQuantity = -1;
	}

	protected virtual void cc1c2481d0270b1299a68075c97ce0d6a()
	{
		string cad8d6e0a594ee2e7b3f487fb75cd3d = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("FAILURE_INSUFFICIENCY"));
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(cad8d6e0a594ee2e7b3f487fb75cd3d, c0c9bb811823f44359ff2355d0e223848, c68ab6f5d12f16a1d54aa92651de73463.c7088de59e49f7108f520cf7e0bae167e);
	}

	protected void c0c9bb811823f44359ff2355d0e223848()
	{
	}

	protected virtual void c6c05b7fcf02ae4ca0a240a5e85fc0da2()
	{
	}

	public void OnBuyItem(ItemDNA itemDna)
	{
		c6c05b7fcf02ae4ca0a240a5e85fc0da2();
		c363ffa9972525058a49f41a533885921();
	}

	public void OnRedeemItem(ItemDNA itemDna)
	{
		c363ffa9972525058a49f41a533885921();
	}

	public void OnGetShop(Shop shop)
	{
		if (shop != null)
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
			if (shop.cf29c277dedbf8f02ae332e42e112a348 != null)
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
				using (Dictionary<int, ShopItem>.ValueCollection.Enumerator enumerator = shop.cf29c277dedbf8f02ae332e42e112a348.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ShopItem current = enumerator.Current;
						c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c6965e945a09324a9af86f14518e0a697(current.Item);
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							goto end_IL_0075;
						}
						continue;
						end_IL_0075:
						break;
					}
				}
			}
		}
		if (shop == null)
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
			if (shop.Id != _iOnShowShopID)
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
				if (_curState != ShopTabState.Shop)
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
					_onShowShop = shop;
					c363ffa9972525058a49f41a533885921();
					return;
				}
			}
		}
	}

	public void OnGetSoldItems(Shop soldItems)
	{
		if (_curState != ShopTabState.SoldItems)
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
			c363ffa9972525058a49f41a533885921();
			return;
		}
	}

	public void OnSellItem(int newBondCurrency)
	{
		if (_curState != ShopTabState.SoldItems)
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
			c363ffa9972525058a49f41a533885921();
			return;
		}
	}

	public void OnGotMyCurrencies(CurrencyInfo currency)
	{
		if (currency == null)
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
			_iMoney = currency.BondCurrency;
			c363ffa9972525058a49f41a533885921();
			return;
		}
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
