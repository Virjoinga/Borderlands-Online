using A;
using Core;
using XsdSettings;

public class WeaponMeltView : BaseView
{
	protected ItemDNA _meltWeapon;

	protected int _inventoryIndex = -1;

	protected int _meltingIndex = -1;

	protected AcquiredMaterial[] _arrMaterialList;

	protected ParticleManager m_particleManager;

	protected string TYPE_GARBAGE = string.Empty;

	protected string TYPE_MELTING = "PTL_Weapon_Melting";

	public ParticleManager c451f04a91206cc21efd84192906fe8e3
	{
		get
		{
			return m_particleManager;
		}
		set
		{
			m_particleManager = value;
		}
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		m_particleManager = cdf6841adbd4c48d1529ac5b42bd58b0a.c7088de59e49f7108f520cf7e0bae167e;
	}

	public override bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		if (c150264a18c2cb408479d3f072cac8cc1)
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
					c150264a18c2cb408479d3f072cac8cc1 = false;
					return true;
				}
			}
		}
		return base.cc130a2d46a451dc54b61a8f0d60794ae();
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		c2d912a7f9ac2a871043051cfa59c20c8(null, -1);
		if (m_particleManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_particleManager.c4ecc5a6775d113af396f25277e85adec();
		}
		if (c150264a18c2cb408479d3f072cac8cc1)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cff2b0374fa4093a26652f81f964f8e9f(GameUIManager.CursorManager.CursorType.HammerLift);
					m_particleManager.cfcebba48dc2e80dc073a4b69fb28025c += c587531823733f1a08c78dbf3118d0930;
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cff2b0374fa4093a26652f81f964f8e9f(GameUIManager.CursorManager.CursorType.DefaultCursor);
		NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.None);
		m_particleManager.cfcebba48dc2e80dc073a4b69fb28025c -= c587531823733f1a08c78dbf3118d0930;
	}

	public void c2d912a7f9ac2a871043051cfa59c20c8(ItemDNA ca57e1c076c01141c5ce58c7341db7833, int cc9e01f27c0efed9577d81fb17c1fba75)
	{
		if (_meltWeapon == ca57e1c076c01141c5ce58c7341db7833)
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
			if (_inventoryIndex == cc9e01f27c0efed9577d81fb17c1fba75)
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
		}
		_arrMaterialList = c61748f02dbf9c81bf0e2b31b40e2fd38.c7088de59e49f7108f520cf7e0bae167e;
		_meltWeapon = c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e;
		_inventoryIndex = cc9e01f27c0efed9577d81fb17c1fba75;
		if (ca57e1c076c01141c5ce58c7341db7833 != null)
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
			if (ca57e1c076c01141c5ce58c7341db7833.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Weapon))
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
				_meltWeapon = ca57e1c076c01141c5ce58c7341db7833;
				if (c1ee7921b0c3cce194fb7cae41b5a9d82<CraftingServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
					_arrMaterialList = c1ee7921b0c3cce194fb7cae41b5a9d82<CraftingServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c8f918c4274c34c1d3e8adb2ea8dd8022(_meltWeapon.ca79da172938fdc8c067fb64242b6174a());
					if (_arrMaterialList == null)
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
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "Weapon melting config wrong! Weapon:" + _meltWeapon.ca79da172938fdc8c067fb64242b6174a().c5f6245b591c90000d8430fc1ca8cc4de());
					}
				}
			}
		}
		cdb61fd817ac27166903b9ffc008ad1dd();
	}

	protected virtual void c51c797c62accc8fc47deb91ab4fc68ce(bool cc76b4d742c039cbe828e163818855cc2)
	{
		c2d912a7f9ac2a871043051cfa59c20c8(null, -1);
		if (!cc76b4d742c039cbe828e163818855cc2)
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Weapon_Melting_Failure")), c15fbbda1d70f36f173c3b5377b68c071, c68ab6f5d12f16a1d54aa92651de73463.c7088de59e49f7108f520cf7e0bae167e);
					return;
				}
			}
		}
		m_particleManager.cd4e7c1b68eb7ce6b3b5b73c4784f6a7b = 1f;
		m_particleManager.ce4c6859b04b271fe37b2049334c686b7(TYPE_MELTING, true, true);
	}

	protected virtual void cdb61fd817ac27166903b9ffc008ad1dd()
	{
	}

	protected void cbd17533d988e0766ca8ea8becca77b78()
	{
		if (m_particleManager.c60e71916893de2f43e9cca97bd0edb64)
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
		_meltingIndex = _inventoryIndex;
		if (_meltingIndex == -1)
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
		if (c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c6facc64e2d5edf33221db1a902d2ccf3(c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e))
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
		if (_meltWeapon.ca79da172938fdc8c067fb64242b6174a().m_generationSource == GenerationSource.Shop)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Weapon_Melting_Failure")), cf8d48a5777b98cfaee8ed73556ffe92a, c68ab6f5d12f16a1d54aa92651de73463.c7088de59e49f7108f520cf7e0bae167e);
					return;
				}
			}
		}
		if (_meltWeapon.ced1a24617421c162b3c986ffdc1eb4d3())
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Warning_Weapon_Melting")), cbe11bd46110bca91fb5268e91350dc31, cf8d48a5777b98cfaee8ed73556ffe92a);
					return;
				}
			}
		}
		cbe11bd46110bca91fb5268e91350dc31();
	}

	public void c587531823733f1a08c78dbf3118d0930()
	{
		m_particleManager.c4ecc5a6775d113af396f25277e85adec();
	}

	protected virtual void cf8d48a5777b98cfaee8ed73556ffe92a()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "Player cancelled weapon melt!");
	}

	protected virtual void c15fbbda1d70f36f173c3b5377b68c071()
	{
	}

	protected virtual void cbe11bd46110bca91fb5268e91350dc31()
	{
		if (!c1ee7921b0c3cce194fb7cae41b5a9d82<CraftingServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<CraftingServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c2b738a0787415710b9ab86768a28207d(c51c797c62accc8fc47deb91ab4fc68ce, _meltingIndex);
			c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134("guidance_melt");
			return;
		}
	}
}
