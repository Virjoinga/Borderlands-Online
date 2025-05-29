using System.Collections.Generic;
using A;
using UnityEngine;
using XsdSettings;

public class CharInfoView : BaseView
{
	protected ItemDNA[] _arrWeapons;

	protected int _iWeaponSlotSum = 4;

	protected int _iActivedIndex = -1;

	protected ItemDNA _shieldDNA;

	protected ItemDNA _classModeDNA;

	protected Dictionary<int, Vector2> _ammoInfoList;

	protected PlayerProperties _playerInfo;

	protected UIModelController _modelController;

	public virtual bool bPVPDisp { get; set; }

	public int c8cf14f8e08f9993b9b0bbb7ad63e2a54
	{
		get
		{
			return _iActivedIndex;
		}
	}

	public ItemDNA[] c7f019a4e8415dcf5133dea4fc25c9671
	{
		get
		{
			return _arrWeapons;
		}
	}

	public CharInfoView()
	{
		_arrWeapons = cd7e95b9c3ab3ea52b4fc74831d35ced6.c0a0cdf4a196914163f7334d9b0781a04(_iWeaponSlotSum);
		_ammoInfoList = new Dictionary<int, Vector2>();
		for (int i = 0; i < 6; i++)
		{
			_ammoInfoList.Add(i, new Vector2(0f, 0f));
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
			return;
		}
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c3ee3ae9c8e9d7863fc24390827b6193f(this, "UIInventory");
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c914f3898d0cb85fdb88383c5a243cded(this);
		c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7d08ed02a7697465eaaf348e5256df6d(c15b26671218d901bb3cc2ee044f150a3);
		if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
			c15b26671218d901bb3cc2ee044f150a3(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
			c15b26671218d901bb3cc2ee044f150a3(InventoryServiceWrapper.InventoryUpdateType.ChangeActiveWeapon);
			return;
		}
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c0f8db058f30b85298d876c68b2ca7053(this);
		_modelController = c72da72cdd2313288f94c2c6d7947d8ea.c7088de59e49f7108f520cf7e0bae167e;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cee8cde4410c30a1ff6fab848a28cf88f(this, string.Empty);
		_bVisible = false;
		c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0e99b4914f8c6b80f6233d720bf3d53f(c15b26671218d901bb3cc2ee044f150a3);
	}

	public override bool OnShortCutCMD(string command)
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
			if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (6)
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
					switch (1)
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
					switch (2)
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
					switch (5)
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
				switch (4)
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
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WeaponPreviewView>().c150264a18c2cb408479d3f072cac8cc1)
			{
				while (true)
				{
					switch (1)
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
				switch (6)
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

	public virtual void c15b26671218d901bb3cc2ee044f150a3(InventoryServiceWrapper.InventoryUpdateType c8caa3fd8318cafc7e124efd1475a86a1)
	{
		if (c8caa3fd8318cafc7e124efd1475a86a1 == InventoryServiceWrapper.InventoryUpdateType.ChangeActiveWeapon)
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
			cf26a78bc33ebfadb5f863b8e4b2a4c11();
			c84f8fe2787c4ed57941b65ae934afecb();
			cd4ae322c1148400237b6aaa1cba32b5a();
		}
		else if (c8caa3fd8318cafc7e124efd1475a86a1 == InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedShield)
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
			c6a28684e0402034394b3571708716d13();
			ca247e8f91ccc6b7709c863cbf715e1ee();
		}
		else if (c8caa3fd8318cafc7e124efd1475a86a1 == InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedClassMod)
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
			c151b853214a88129c3f5fbd16506cec1();
			c005e92d6b4fdb43cc882206a3f0c3ffb();
		}
		else if (cf4d62ec2a313603754923cf944d2d815())
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
			ca71ff9e891e72ba05d0d35e6c20d3292();
			cf26a78bc33ebfadb5f863b8e4b2a4c11();
			c84f8fe2787c4ed57941b65ae934afecb();
		}
		c27bd9cdd263e29de38d1f6ea82554bbe();
	}

	public virtual void c0be25dad7f3b503064fc98b654b8c830(PlayerProperties c25f5f36a54095a8f73d85c7f7b5af196)
	{
		if (c25f5f36a54095a8f73d85c7f7b5af196 != null)
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
			_playerInfo = c25f5f36a54095a8f73d85c7f7b5af196;
		}
		ca3635a4b4a9f3ba6302a0d67a0e4bdd1();
	}

	public virtual void c8de516016f86a6aaeb78036625c2510a()
	{
		if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
		Vector2 c36964cf41281414170f34ee68bef6c = default(Vector2);
		for (int i = 0; i < 6; i++)
		{
			c9ef4b269732f6eff7b215dc57e5e252c.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
			c36964cf41281414170f34ee68bef6c.x = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c5ddb5f74d1f3e3c06409d657ed5eb7a1((AmmoType)i);
			c36964cf41281414170f34ee68bef6c.y = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cd164b9ec3a9d0fc37e11d7fd46792ef2((AmmoType)i);
			_ammoInfoList[i] = c36964cf41281414170f34ee68bef6c;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			cd71e2126c8425bde7ada191d04ee332b();
			return;
		}
	}

	public virtual ItemDNA ccd0f6bcfcd12e28d498bb8d9a3a245c0()
	{
		if (_arrWeapons != null)
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
			if (_arrWeapons[_iActivedIndex] != null)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return _arrWeapons[_iActivedIndex];
					}
				}
			}
		}
		return null;
	}

	public ItemDNA cac06519a9a0fc999487710a6dfd94dba()
	{
		return _shieldDNA;
	}

	public virtual void c5942a289bb847abf2556f0b87b099420(bool cd46bd0dec07884f25a87a6fe53c8a9c2)
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
				if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689())
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
					GameObject gameObject = (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689().cb8119a2676bfbd4df00a9ed683eed91a() as PlayerThirdPersonAnimationManagerFSM).cd6ae848bd7b355e87c47ead3c3deb3fb(cd46bd0dec07884f25a87a6fe53c8a9c2);
					if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (cd46bd0dec07884f25a87a6fe53c8a9c2)
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
							MaterialHelper.c8aad2693bab239127d92af8c0b0b8c3c(gameObject);
							Vector3 c4d08ae331c26afaf32f24366155aeda = new Vector3(0f, 0f, 0f);
							Vector3 c4ea6de03c1203f2470a6677821ad93f = new Vector3(0f, 180f, 0f);
							c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c6de8002d9a233bb083beb8d2a147d3b0(gameObject, c4d08ae331c26afaf32f24366155aeda, c4ea6de03c1203f2470a6677821ad93f, false);
							_modelController = gameObject.GetComponent<UIModelController>();
							if (_modelController == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								_modelController = gameObject.AddComponent<UIModelController>();
							}
							else
							{
								_modelController.c68d90d817b360f3767f83d5ba152ef76();
							}
						}
					}
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c9ff0f0f2e42ce6e75d98e84a884b4452(cd46bd0dec07884f25a87a6fe53c8a9c2);
	}

	protected virtual void c84f8fe2787c4ed57941b65ae934afecb()
	{
	}

	protected virtual void ca3635a4b4a9f3ba6302a0d67a0e4bdd1()
	{
	}

	protected virtual void cd71e2126c8425bde7ada191d04ee332b()
	{
	}

	protected virtual void c27bd9cdd263e29de38d1f6ea82554bbe()
	{
	}

	protected virtual void cd4ae322c1148400237b6aaa1cba32b5a()
	{
	}

	protected virtual void ca247e8f91ccc6b7709c863cbf715e1ee()
	{
	}

	protected virtual void c005e92d6b4fdb43cc882206a3f0c3ffb()
	{
	}

	protected virtual void ca71ff9e891e72ba05d0d35e6c20d3292()
	{
	}

	protected bool cf4d62ec2a313603754923cf944d2d815()
	{
		if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
					return false;
				}
			}
		}
		cf26a78bc33ebfadb5f863b8e4b2a4c11();
		for (int i = 0; i < _iWeaponSlotSum; i++)
		{
			_arrWeapons[i] = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4e0dae6a16a8a80ddb5214a896b9df58((byte)i);
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return true;
		}
	}

	protected void cf26a78bc33ebfadb5f863b8e4b2a4c11()
	{
		_iActivedIndex = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c91233b4b8268e8e24a4daa8c053e41ec();
	}

	protected void c6a28684e0402034394b3571708716d13()
	{
		_shieldDNA = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cec5e771a298fe1e51f84e4ec6dcb5165();
	}

	protected void c151b853214a88129c3f5fbd16506cec1()
	{
		_classModeDNA = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c86b944a82d70502ff9ec6c7d1fa5f420();
	}

	protected void c8e05ed0c132b36a56b8484bb4dabb30e(int c1f39b3fb59d07b393dabdda16dac5830, int c1af59fd75613564047db200fe4884cd0)
	{
		if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cabac189d699c8d8d56d0e1a68cd1440b((byte)c1f39b3fb59d07b393dabdda16dac5830, (byte)c1af59fd75613564047db200fe4884cd0);
			return;
		}
	}

	protected void c62e2102e53dae59b098c9594c8583845(int c9526cedaae8a6f13c52592df57f78e6e)
	{
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (_iActivedIndex == c9526cedaae8a6f13c52592df57f78e6e)
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cb71c24b68b65fe176d7936520d63a102((byte)c9526cedaae8a6f13c52592df57f78e6e);
				return;
			}
		}
	}

	protected void cc7927fb2f699a2f6495cf21a5cf02606(int c4a883be0fb2fdc6dbc20fe7b0985aa11, int caaa3357772493402d14383b3a06e89ee)
	{
		if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ccfdbed5cc5051e9ffb25bea212f7ddc6((byte)c4a883be0fb2fdc6dbc20fe7b0985aa11, (byte)caaa3357772493402d14383b3a06e89ee);
			return;
		}
	}

	protected void c7cd1f59ace6ee251759251efbe7bb224(int c1f39b3fb59d07b393dabdda16dac5830)
	{
		if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c61f40925cf99c31aa9ac5df098110ada((byte)c1f39b3fb59d07b393dabdda16dac5830);
			return;
		}
	}

	protected void c66b709849d82c29e7dc0c64463b37c17(int c1f39b3fb59d07b393dabdda16dac5830)
	{
		if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c2bf177eafbfeb7beaa0bfd04facb2029((byte)c1f39b3fb59d07b393dabdda16dac5830);
			return;
		}
	}
}
