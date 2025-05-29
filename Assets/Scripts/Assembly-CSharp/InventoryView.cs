using System.Collections.Generic;
using A;
using UnityEngine;
using XsdSettings;

public class InventoryView : BaseView
{
	protected class CharInfoNotification : ICharacterServiceNotificationListerner
	{
		public InventoryView view;

		void ICharacterServiceNotificationListerner.OnGotMyCurrencies(CurrencyInfo currency)
		{
			if (view == null)
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
				view.OnGotMyCurrencies(currency);
				return;
			}
		}

		void ICharacterServiceNotificationListerner.OnExperienceUpdated(int experience)
		{
		}

		void ICharacterServiceNotificationListerner.OnGetPersonalSettings(string strSettings)
		{
		}

		void ICharacterServiceNotificationListerner.OnSetPersonalSettings(int iResult)
		{
		}
	}

	protected List<ItemDNA> _arrItems = new List<ItemDNA>();

	protected int _iSlotSum = 42;

	protected int _iItemSum;

	protected CharInfoNotification _currencyListener = new CharInfoNotification();

	protected CurrencyInfo _currencyInfo;

	protected int _iDropItemIndex = -1;

	private HashSet<ItemDNA> _previousItems = new HashSet<ItemDNA>();

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cbfdeda957ab87de3d0acf25194e61c4c(this);
		_iSlotSum = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ca77a0dd5dbf0daa686053361865cb06a();
		_iItemSum = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.caa75b946a7aa0d2b3a6d5c5b2b94f0a3();
		c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7d08ed02a7697465eaaf348e5256df6d(c223fa13462383b866a17f6b609b07fc3);
		_currencyListener.view = this;
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(_currencyListener);
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ceaf946a4b1d023143d622c7be7019235();
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c704834a4a19f1f8555b44d9c021845ab(_currencyListener);
		c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0e99b4914f8c6b80f6233d720bf3d53f(c223fa13462383b866a17f6b609b07fc3);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cfdafa122fc114376585cbb27b8811a86(this);
		_bVisible = false;
	}

	public virtual void cc70485d0f318bdcb115a41bc918cae44(Vector2 c330987c4414f384d6c951ab9f68460d8)
	{
	}

	public override bool OnShortCutCMD(string command)
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
			if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					return false;
				}
			}
			Entity entity = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689();
			if (entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					return false;
				}
			}
			PlayerController component = entity.GetComponent<PlayerController>();
			if (component == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					return false;
				}
			}
			if (!component.c3f5a0de60e63b40404559fa7bafafee2(PlayerAction.AccessInventory))
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return false;
					}
				}
			}
		}
		if (!cd0069281ff5290a7e6c484b6aed3933d)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		c150264a18c2cb408479d3f072cac8cc1 = !c150264a18c2cb408479d3f072cac8cc1;
		return true;
	}

	public override bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		if (c150264a18c2cb408479d3f072cac8cc1)
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
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WeaponPreviewView>().c150264a18c2cb408479d3f072cac8cc1)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WeaponPreviewView>().c0027208817ce8ec1d561f1d34af428c3();
						return true;
					}
				}
			}
		}
		if (c150264a18c2cb408479d3f072cac8cc1)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					c150264a18c2cb408479d3f072cac8cc1 = false;
					return true;
				}
			}
		}
		return base.cc130a2d46a451dc54b61a8f0d60794ae();
	}

	public virtual void c223fa13462383b866a17f6b609b07fc3(InventoryServiceWrapper.InventoryUpdateType c8caa3fd8318cafc7e124efd1475a86a1)
	{
		if (c8caa3fd8318cafc7e124efd1475a86a1 == InventoryServiceWrapper.InventoryUpdateType.ChangeActiveWeapon)
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
			if (!c066383eaf66d1236a53fa37d19602699())
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
				ca71ff9e891e72ba05d0d35e6c20d3292();
				cdb61fd817ac27166903b9ffc008ad1dd();
				return;
			}
		}
	}

	public virtual void c3aa85fcf668307b56a215299bba49e31(ItemDNA cf4af10ce9fa4ab84bd021b054d46a667, out Texture2D cd6102468cd57214a9f3e10633998391b)
	{
		cd6102468cd57214a9f3e10633998391b = null;
	}

	public void OnGotMyCurrencies(CurrencyInfo currency)
	{
		_currencyInfo = currency;
		c59da8661588e408c0b48d7a9ddc11ab9();
		cf157ca65df0b4e8c64213bea4c8767f2();
	}

	protected virtual void cdb61fd817ac27166903b9ffc008ad1dd()
	{
	}

	protected virtual void ca71ff9e891e72ba05d0d35e6c20d3292()
	{
	}

	protected virtual void c59da8661588e408c0b48d7a9ddc11ab9()
	{
	}

	protected virtual void cf157ca65df0b4e8c64213bea4c8767f2()
	{
	}

	protected bool c066383eaf66d1236a53fa37d19602699()
	{
		if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
					return false;
				}
			}
		}
		_previousItems.Clear();
		for (int i = 0; i < _arrItems.Count; i++)
		{
			_previousItems.Add(_arrItems[i]);
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			_arrItems.Clear();
			for (int j = 0; j < _iSlotSum; j++)
			{
				ItemDNA item = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c48db535623c3c5d4028ae3a36cb12dc6(j);
				if (!_previousItems.Contains(item))
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
					c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnObtainItem(item);
				}
				_arrItems.Add(item);
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				_iItemSum = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.caa75b946a7aa0d2b3a6d5c5b2b94f0a3();
				return true;
			}
		}
	}

	protected void c1a8455a9ebc438c42697a10f94624a4a(int c4a883be0fb2fdc6dbc20fe7b0985aa11, int caaa3357772493402d14383b3a06e89ee)
	{
		if (c4a883be0fb2fdc6dbc20fe7b0985aa11 < 0)
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
			if (c4a883be0fb2fdc6dbc20fe7b0985aa11 >= _iSlotSum)
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
				if (caaa3357772493402d14383b3a06e89ee < 0)
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
					if (caaa3357772493402d14383b3a06e89ee >= _iSlotSum)
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
					if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
						c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cc62b4b3e79f635a94d84949382bba1fc((byte)c4a883be0fb2fdc6dbc20fe7b0985aa11, (byte)caaa3357772493402d14383b3a06e89ee);
						return;
					}
				}
			}
		}
	}

	protected void c1313402f01ea427301c8dc00be412797(int c1546e92474fce4c07c8adf7df1ff61c7, int caaa3357772493402d14383b3a06e89ee)
	{
		if (caaa3357772493402d14383b3a06e89ee < 0)
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
			if (caaa3357772493402d14383b3a06e89ee >= _iSlotSum)
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
			if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c972a624b053fa175be4e64196965eb15((byte)c1546e92474fce4c07c8adf7df1ff61c7, (byte)caaa3357772493402d14383b3a06e89ee, false);
				return;
			}
		}
	}

	protected void cc1a21f1cffbc622feb03d37e28d50bdb(int c9526cedaae8a6f13c52592df57f78e6e)
	{
		if (c9526cedaae8a6f13c52592df57f78e6e < 0)
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
			if (c9526cedaae8a6f13c52592df57f78e6e >= _iSlotSum)
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
			if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cabac189d699c8d8d56d0e1a68cd1440b((byte)c9526cedaae8a6f13c52592df57f78e6e, 0);
				return;
			}
		}
	}

	protected void ced89d39fd82d07f930c30c633a3ad475(int c9526cedaae8a6f13c52592df57f78e6e)
	{
		_iDropItemIndex = c9526cedaae8a6f13c52592df57f78e6e;
		ItemDNA itemDNA = _arrItems[_iDropItemIndex];
		if (itemDNA.ced1a24617421c162b3c986ffdc1eb4d3())
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Warning_Inventory_Discard")), c7a55fdd4b516bfbddcd4f7e4d8b59584, c550849b51a681ea4eca1adec27c06f45);
					return;
				}
			}
		}
		c7a55fdd4b516bfbddcd4f7e4d8b59584();
	}

	protected void c95c907131d60893ab10124305650f93f(int c9526cedaae8a6f13c52592df57f78e6e)
	{
		if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c89361444df98c6f8354125e8bdb18882((byte)c9526cedaae8a6f13c52592df57f78e6e);
			return;
		}
	}

	protected void c196ad5f133a65d2658191c2ea2bb7a7a(UIItemSlotData cb4be6dae1755138c26d22542471266a1)
	{
		List<MenuItemDef> list = new List<MenuItemDef>();
		MenuItemDef item = default(MenuItemDef);
		item.itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("DiscardItem"));
		item.itemData = cb4be6dae1755138c26d22542471266a1.index;
		item.itemFunc = c2f7d208e086f17f1eca31cc7b31ef35c;
		list.Add(item);
		if (cb4be6dae1755138c26d22542471266a1.item.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Weapon))
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
			item.itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PreviewItem"));
			item.itemData = cb4be6dae1755138c26d22542471266a1.item.ca79da172938fdc8c067fb64242b6174a();
			item.itemFunc = c66cb2e413758b9c2e40c02da523e55fb;
			list.Add(item);
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().c687c56ed531550f24368180c4c3bc947(list.ToArray());
	}

	protected void c2f7d208e086f17f1eca31cc7b31ef35c(object cb4be6dae1755138c26d22542471266a1)
	{
		_iDropItemIndex = (int)cb4be6dae1755138c26d22542471266a1;
		ced89d39fd82d07f930c30c633a3ad475(_iDropItemIndex);
	}

	protected virtual void c7a55fdd4b516bfbddcd4f7e4d8b59584()
	{
		if (_iDropItemIndex < 0)
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
			if (_iDropItemIndex >= _iSlotSum)
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
			if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cccb56495987b6a4ebab7b225fb1af261((byte)_iDropItemIndex);
				return;
			}
		}
	}

	protected virtual void c550849b51a681ea4eca1adec27c06f45()
	{
		_iDropItemIndex = -1;
	}

	protected void c66cb2e413758b9c2e40c02da523e55fb(object cb4be6dae1755138c26d22542471266a1)
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WeaponPreviewView>().c6187275e7336eafc3a9acc48a6644c55((WeaponDNA)cb4be6dae1755138c26d22542471266a1);
	}
}
