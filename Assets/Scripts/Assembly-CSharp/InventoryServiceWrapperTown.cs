using A;
using XsdSettings;

public class InventoryServiceWrapperTown : IInventoryServiceWrapper, IServiceWrapper
{
	private bool m_isInitializing;

	private Inventory m_inventory;

	private Warehouse m_warehouse;

	private EquipmentInventoryEntityPlayerTown m_equipment;

	private EntityPlayer m_localPlayer;

	public void c6f6b6fb3691ffafe13efe37894bc5404(Inventory cfcf820426a6e568b08865de5afa27d4e)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
	}

	public void c1deba548d6db208c9065475098b7986f(int c24a23635a8b6b95d7730eefdf77f7b9e, Inventory c4191fdc7c13b1aad0b75ecae47de44af)
	{
		m_inventory = c4191fdc7c13b1aad0b75ecae47de44af;
		c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
	}

	public void c4532f3cc311651513a8ebf84f9bd2c46(Warehouse ca2a0d36a318420cc3d4237ec9582010b)
	{
		m_warehouse = ca2a0d36a318420cc3d4237ec9582010b;
		c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c88f3382ffcb45577bad5d2f4b01cfb38(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
	}

	public void cd93285db16841148ed53a5bbeb35cf20()
	{
		if (m_isInitializing)
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
			m_isInitializing = true;
			OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c7d08ed02a7697465eaaf348e5256df6d(c6f6b6fb3691ffafe13efe37894bc5404);
			OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c844f1a916a01fdb8a6a6e640d1811cf2(OnlineService.s_characterId, c1deba548d6db208c9065475098b7986f);
			OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c05f80d16e3170409ad1eb25c2513dafe(c4532f3cc311651513a8ebf84f9bd2c46);
			OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cd5aabef23453e5fe1dc51bd3dddabd23();
			return;
		}
	}

	public bool c39df47367fa21412aabfef05d9972f8c()
	{
		m_localPlayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
		if ((bool)m_localPlayer)
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
			m_equipment = m_localPlayer.c5ca38fad98337fc5c7255384b2cd1a86() as EquipmentInventoryEntityPlayerTown;
			if ((bool)m_equipment)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		return false;
	}

	public ItemDNA c48db535623c3c5d4028ae3a36cb12dc6(int c793014f9fd028450a4a9908376309f26)
	{
		return m_inventory.c48db535623c3c5d4028ae3a36cb12dc6(c793014f9fd028450a4a9908376309f26);
	}

	public ItemDNA c4e0dae6a16a8a80ddb5214a896b9df58(byte c793014f9fd028450a4a9908376309f26)
	{
		return m_inventory.c4e0dae6a16a8a80ddb5214a896b9df58(c793014f9fd028450a4a9908376309f26);
	}

	public byte c91233b4b8268e8e24a4daa8c053e41ec()
	{
		if (m_localPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return 0;
				}
			}
		}
		EquipmentInventoryEntityPlayerTown equipmentInventoryEntityPlayerTown = m_localPlayer.c5ca38fad98337fc5c7255384b2cd1a86() as EquipmentInventoryEntityPlayerTown;
		if (equipmentInventoryEntityPlayerTown == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return 0;
				}
			}
		}
		return equipmentInventoryEntityPlayerTown.c91233b4b8268e8e24a4daa8c053e41ec();
	}

	public int c5ddb5f74d1f3e3c06409d657ed5eb7a1(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b)
	{
		return m_inventory.c5ddb5f74d1f3e3c06409d657ed5eb7a1(c1e73ae4c18ab95639cb0c7604f21dc2b);
	}

	public int cd164b9ec3a9d0fc37e11d7fd46792ef2(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b)
	{
		return m_inventory.cd164b9ec3a9d0fc37e11d7fd46792ef2(c1e73ae4c18ab95639cb0c7604f21dc2b);
	}

	public int ca77a0dd5dbf0daa686053361865cb06a()
	{
		return m_inventory.c5bca3d5ccc1b3ed0b9472295fb3f6c73();
	}

	public int caa75b946a7aa0d2b3a6d5c5b2b94f0a3()
	{
		return m_inventory.c53fd283cda80105bc6325451be44376d;
	}

	public void cc62b4b3e79f635a94d84949382bba1fc(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
		m_inventory.cc62b4b3e79f635a94d84949382bba1fc(c42a8a9b0dd4206315a44f945fbf7331f, c5242449e40eab9ce5011e2bacd82070c);
	}

	public void ccfdbed5cc5051e9ffb25bea212f7ddc6(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
		m_inventory.ccfdbed5cc5051e9ffb25bea212f7ddc6(c42a8a9b0dd4206315a44f945fbf7331f, c5242449e40eab9ce5011e2bacd82070c);
		m_equipment.c0086d06d399d3534d81eb73a2590310c();
		if (!m_localPlayer)
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
			m_localPlayer.ccfdbed5cc5051e9ffb25bea212f7ddc6(c42a8a9b0dd4206315a44f945fbf7331f, c5242449e40eab9ce5011e2bacd82070c);
			return;
		}
	}

	public bool ce30d65b28e5e27287812b940c39aacf7(byte cd27037dd3bf1006e6e39ebf89cbd7b03)
	{
		ItemDNA itemDNA = m_inventory.c48db535623c3c5d4028ae3a36cb12dc6(cd27037dd3bf1006e6e39ebf89cbd7b03);
		if (itemDNA.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.ClassMode))
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
			ClassModeDNA classModeDNA = itemDNA.c253c28f3a59bc5e5a528dfbb463a8a45();
			if (classModeDNA.c95c0ac986e3767a549cf71c2cf28b34f(classModeDNA.m_cmType) != m_localPlayer.cb21345185f43f30c1edeaf8faafb0f2c())
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return false;
					}
				}
			}
		}
		return itemDNA.ce30d65b28e5e27287812b940c39aacf7(m_localPlayer.c7513e66c4e0fc55e6fea9dd9cb8b9943());
	}

	public void cabac189d699c8d8d56d0e1a68cd1440b(byte cd27037dd3bf1006e6e39ebf89cbd7b03, byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		if (!ce30d65b28e5e27287812b940c39aacf7(cd27037dd3bf1006e6e39ebf89cbd7b03))
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
		m_inventory.cabac189d699c8d8d56d0e1a68cd1440b(cd27037dd3bf1006e6e39ebf89cbd7b03, c19a39247ea86ffe5f0de9d429ca0ca95);
		m_equipment.c0086d06d399d3534d81eb73a2590310c();
		if ((bool)m_localPlayer)
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
			m_localPlayer.cabac189d699c8d8d56d0e1a68cd1440b(cd27037dd3bf1006e6e39ebf89cbd7b03, c19a39247ea86ffe5f0de9d429ca0ca95);
		}
		cb71c24b68b65fe176d7936520d63a102(c19a39247ea86ffe5f0de9d429ca0ca95);
	}

	public void c89361444df98c6f8354125e8bdb18882(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		if (c91233b4b8268e8e24a4daa8c053e41ec() == c19a39247ea86ffe5f0de9d429ca0ca95)
		{
			while (true)
			{
				switch (4)
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
		m_inventory.c89361444df98c6f8354125e8bdb18882(c19a39247ea86ffe5f0de9d429ca0ca95);
		m_equipment.c0086d06d399d3534d81eb73a2590310c();
		if (!m_localPlayer)
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
			m_localPlayer.c89361444df98c6f8354125e8bdb18882(c19a39247ea86ffe5f0de9d429ca0ca95);
			return;
		}
	}

	public void c61f40925cf99c31aa9ac5df098110ada(byte c71953cab9dff52e14146804e2928df92)
	{
		if (!ce30d65b28e5e27287812b940c39aacf7(c71953cab9dff52e14146804e2928df92))
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
		if (m_inventory != null)
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
			m_inventory.c61f40925cf99c31aa9ac5df098110ada(c71953cab9dff52e14146804e2928df92);
		}
		if (!m_localPlayer)
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
			m_localPlayer.c61f40925cf99c31aa9ac5df098110ada(c71953cab9dff52e14146804e2928df92);
			return;
		}
	}

	public ItemDNA cec5e771a298fe1e51f84e4ec6dcb5165()
	{
		return m_inventory.cec5e771a298fe1e51f84e4ec6dcb5165();
	}

	public void c2bf177eafbfeb7beaa0bfd04facb2029(byte c71953cab9dff52e14146804e2928df92)
	{
		if (!ce30d65b28e5e27287812b940c39aacf7(c71953cab9dff52e14146804e2928df92))
		{
			while (true)
			{
				switch (4)
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
		if (m_inventory != null)
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
			m_inventory.c8bd71a55c46846de17877d69bbae8bc3(c71953cab9dff52e14146804e2928df92);
		}
		if (!m_localPlayer)
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
			m_localPlayer.c2bf177eafbfeb7beaa0bfd04facb2029(c71953cab9dff52e14146804e2928df92);
			return;
		}
	}

	public ItemDNA c86b944a82d70502ff9ec6c7d1fa5f420()
	{
		return m_inventory.c86b944a82d70502ff9ec6c7d1fa5f420();
	}

	public void cccb56495987b6a4ebab7b225fb1af261(byte c793014f9fd028450a4a9908376309f26)
	{
		m_inventory.cccb56495987b6a4ebab7b225fb1af261(c793014f9fd028450a4a9908376309f26);
	}

	public void cb71c24b68b65fe176d7936520d63a102(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		if (m_localPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!m_localPlayer.c611613a4cdf13c7acc73007bf65a3d2c(c19a39247ea86ffe5f0de9d429ca0ca95))
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
			m_inventory.cb71c24b68b65fe176d7936520d63a102(c19a39247ea86ffe5f0de9d429ca0ca95);
			if (!m_localPlayer)
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
				m_localPlayer.c1fc97d9000793496ac114d06521f85a0(c19a39247ea86ffe5f0de9d429ca0ca95);
				EquipmentInventoryEntityPlayerTown equipmentInventoryEntityPlayerTown = m_localPlayer.c5ca38fad98337fc5c7255384b2cd1a86() as EquipmentInventoryEntityPlayerTown;
				if (!(equipmentInventoryEntityPlayerTown != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					equipmentInventoryEntityPlayerTown.cb71c24b68b65fe176d7936520d63a102(c19a39247ea86ffe5f0de9d429ca0ca95);
					return;
				}
			}
		}
	}

	public bool cc7fc82e2186587ba2141daa47aab239e(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		int result;
		if (m_equipment.c20ad6bcf5b5ce2ad75ae35905409f5fa(c19a39247ea86ffe5f0de9d429ca0ca95) != null)
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
			result = ((m_inventory.c4e0dae6a16a8a80ddb5214a896b9df58(c19a39247ea86ffe5f0de9d429ca0ca95) != c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public void c4664d50badb8133ba931a253977f782d(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
		if (m_warehouse == null)
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
			OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
			array[0] = c42a8a9b0dd4206315a44f945fbf7331f;
			array[1] = c5242449e40eab9ce5011e2bacd82070c;
			onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(98, array);
			return;
		}
	}

	public void c972a624b053fa175be4e64196965eb15(byte c30d73fd0c12edf60c058e08df3692557, byte cfaffa833cc1d4800aa963fe18d6e8a07, bool c57a95ebcb899508cd608bd72d959a9f9)
	{
		if (m_warehouse == null)
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
			OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(3);
			array[0] = c30d73fd0c12edf60c058e08df3692557;
			array[1] = cfaffa833cc1d4800aa963fe18d6e8a07;
			array[2] = c57a95ebcb899508cd608bd72d959a9f9;
			onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(97, array);
			return;
		}
	}

	public void cd5aabef23453e5fe1dc51bd3dddabd23()
	{
		if (m_warehouse == null)
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
			OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cd5aabef23453e5fe1dc51bd3dddabd23();
			return;
		}
	}

	public ItemDNA[] c77d8654eaecd92e95d29266c606a0f92()
	{
		if (m_warehouse != null)
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
					return m_warehouse.cabea7fa8a6965fb908a577c67283aba5();
				}
			}
		}
		return null;
	}

	public bool c8247c0810f772f58d56e0b9d19370f8e(ItemDNA ca57e1c076c01141c5ce58c7341db7833)
	{
		return m_inventory.c3ac9dbf338103e5bc87b5c2d6acf117a();
	}
}
