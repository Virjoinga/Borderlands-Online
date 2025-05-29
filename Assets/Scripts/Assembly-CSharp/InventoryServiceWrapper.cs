using System;
using System.Collections.Generic;
using A;
using XsdSettings;

public class InventoryServiceWrapper : ServiceWrapper<IInventoryServiceWrapper, InventoryServiceWrapper>
{
	public enum InventoryUpdateType
	{
		None = 0,
		ItemUpdate = 1,
		ChangeActiveWeapon = 2,
		ChangeEquipedShield = 3,
		ChangeEquipedClassMod = 4,
		FullUpdate = 5
	}

	public delegate void InventoryUpdateCallback(InventoryUpdateType updateType);

	private List<InventoryUpdateCallback> m_inventoryCallbacks = new List<InventoryUpdateCallback>();

	private InventoryUpdateCallback m_WareHouseCallback;

	public void c7d08ed02a7697465eaaf348e5256df6d(InventoryUpdateCallback c2db84530ef366a6deb001d449d4aa151)
	{
		m_inventoryCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c0e99b4914f8c6b80f6233d720bf3d53f(InventoryUpdateCallback c2db84530ef366a6deb001d449d4aa151)
	{
		m_inventoryCallbacks.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c3f364b40c92f5f9e53e65ac9b0913add(InventoryUpdateType c8caa3fd8318cafc7e124efd1475a86a1)
	{
		m_inventoryCallbacks.ForEach(delegate(InventoryUpdateCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(c8caa3fd8318cafc7e124efd1475a86a1);
		});
	}

	public void c05f80d16e3170409ad1eb25c2513dafe(InventoryUpdateCallback c2db84530ef366a6deb001d449d4aa151)
	{
		m_WareHouseCallback = (InventoryUpdateCallback)Delegate.Combine(m_WareHouseCallback, c2db84530ef366a6deb001d449d4aa151);
	}

	public void c65c59da24f9798ba26f34e1faad4f76a(InventoryUpdateCallback c2db84530ef366a6deb001d449d4aa151)
	{
		m_WareHouseCallback = (InventoryUpdateCallback)Delegate.Remove(m_WareHouseCallback, c2db84530ef366a6deb001d449d4aa151);
	}

	public void c88f3382ffcb45577bad5d2f4b01cfb38(InventoryUpdateType c8caa3fd8318cafc7e124efd1475a86a1)
	{
		if (m_WareHouseCallback == null)
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
			m_WareHouseCallback(c8caa3fd8318cafc7e124efd1475a86a1);
			return;
		}
	}

	protected override IInventoryServiceWrapper c9374c9e18d64e753feff5ba5622a02ad()
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
				if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
					if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689())
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								return m_wrapperSession;
							}
						}
					}
				}
			}
		}
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
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
				if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
					if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689())
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								return m_wrapperTown;
							}
						}
					}
				}
			}
		}
		return m_wrapperOnline;
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		m_wrapperOnline = new InventoryServiceWrapperOnline();
		m_wrapperSession = new InventoryServiceWrapperSession();
		m_wrapperTown = new InventoryServiceWrapperTown();
		base.cd93285db16841148ed53a5bbeb35cf20();
	}

	public ItemDNA c48db535623c3c5d4028ae3a36cb12dc6(int c793014f9fd028450a4a9908376309f26)
	{
		return c9374c9e18d64e753feff5ba5622a02ad().c48db535623c3c5d4028ae3a36cb12dc6(c793014f9fd028450a4a9908376309f26);
	}

	public ItemDNA c4e0dae6a16a8a80ddb5214a896b9df58(byte c793014f9fd028450a4a9908376309f26)
	{
		return c9374c9e18d64e753feff5ba5622a02ad().c4e0dae6a16a8a80ddb5214a896b9df58(c793014f9fd028450a4a9908376309f26);
	}

	public byte c91233b4b8268e8e24a4daa8c053e41ec()
	{
		return c9374c9e18d64e753feff5ba5622a02ad().c91233b4b8268e8e24a4daa8c053e41ec();
	}

	public int c5ddb5f74d1f3e3c06409d657ed5eb7a1(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b)
	{
		return c9374c9e18d64e753feff5ba5622a02ad().c5ddb5f74d1f3e3c06409d657ed5eb7a1(c1e73ae4c18ab95639cb0c7604f21dc2b);
	}

	public int cd164b9ec3a9d0fc37e11d7fd46792ef2(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b)
	{
		return c9374c9e18d64e753feff5ba5622a02ad().cd164b9ec3a9d0fc37e11d7fd46792ef2(c1e73ae4c18ab95639cb0c7604f21dc2b);
	}

	public void cc62b4b3e79f635a94d84949382bba1fc(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
		if (c42a8a9b0dd4206315a44f945fbf7331f == c5242449e40eab9ce5011e2bacd82070c)
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
			c9374c9e18d64e753feff5ba5622a02ad().cc62b4b3e79f635a94d84949382bba1fc(c42a8a9b0dd4206315a44f945fbf7331f, c5242449e40eab9ce5011e2bacd82070c);
			return;
		}
	}

	public void ccfdbed5cc5051e9ffb25bea212f7ddc6(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
		if (c42a8a9b0dd4206315a44f945fbf7331f == c5242449e40eab9ce5011e2bacd82070c)
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
		c9374c9e18d64e753feff5ba5622a02ad().ccfdbed5cc5051e9ffb25bea212f7ddc6(c42a8a9b0dd4206315a44f945fbf7331f, c5242449e40eab9ce5011e2bacd82070c);
	}

	public void cabac189d699c8d8d56d0e1a68cd1440b(byte cd27037dd3bf1006e6e39ebf89cbd7b03, byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cabac189d699c8d8d56d0e1a68cd1440b(cd27037dd3bf1006e6e39ebf89cbd7b03, c19a39247ea86ffe5f0de9d429ca0ca95);
		c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134("guidance_equip_weapon");
	}

	public void c89361444df98c6f8354125e8bdb18882(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c89361444df98c6f8354125e8bdb18882(c19a39247ea86ffe5f0de9d429ca0ca95);
	}

	public void cccb56495987b6a4ebab7b225fb1af261(byte c793014f9fd028450a4a9908376309f26)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cccb56495987b6a4ebab7b225fb1af261(c793014f9fd028450a4a9908376309f26);
	}

	public void c61f40925cf99c31aa9ac5df098110ada(byte c71953cab9dff52e14146804e2928df92)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c61f40925cf99c31aa9ac5df098110ada(c71953cab9dff52e14146804e2928df92);
		c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134("guidance_equip_shield");
	}

	public void c2bf177eafbfeb7beaa0bfd04facb2029(byte c71953cab9dff52e14146804e2928df92)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c2bf177eafbfeb7beaa0bfd04facb2029(c71953cab9dff52e14146804e2928df92);
		c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134("guidance_equip_classMod");
	}

	public ItemDNA cec5e771a298fe1e51f84e4ec6dcb5165()
	{
		if (c9374c9e18d64e753feff5ba5622a02ad() == null)
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
					return null;
				}
			}
		}
		return c9374c9e18d64e753feff5ba5622a02ad().cec5e771a298fe1e51f84e4ec6dcb5165();
	}

	public ItemDNA c86b944a82d70502ff9ec6c7d1fa5f420()
	{
		if (c9374c9e18d64e753feff5ba5622a02ad() == null)
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
					return null;
				}
			}
		}
		return c9374c9e18d64e753feff5ba5622a02ad().c86b944a82d70502ff9ec6c7d1fa5f420();
	}

	public void cb71c24b68b65fe176d7936520d63a102(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		if (!cc7fc82e2186587ba2141daa47aab239e(c19a39247ea86ffe5f0de9d429ca0ca95))
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
			c9374c9e18d64e753feff5ba5622a02ad().cb71c24b68b65fe176d7936520d63a102(c19a39247ea86ffe5f0de9d429ca0ca95);
			return;
		}
	}

	public bool cc7fc82e2186587ba2141daa47aab239e(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		return c9374c9e18d64e753feff5ba5622a02ad().cc7fc82e2186587ba2141daa47aab239e(c19a39247ea86ffe5f0de9d429ca0ca95);
	}

	public int ca77a0dd5dbf0daa686053361865cb06a()
	{
		return c9374c9e18d64e753feff5ba5622a02ad().ca77a0dd5dbf0daa686053361865cb06a();
	}

	public int caa75b946a7aa0d2b3a6d5c5b2b94f0a3()
	{
		return c9374c9e18d64e753feff5ba5622a02ad().caa75b946a7aa0d2b3a6d5c5b2b94f0a3();
	}

	public int cdff08bd623e04fdde40092784eebdeec(MaterialType c424fafa6354141c1e81d53efca575d8d)
	{
		int num = 0;
		for (sbyte b = 0; b < ca77a0dd5dbf0daa686053361865cb06a(); b++)
		{
			ItemDNA itemDNA = c48db535623c3c5d4028ae3a36cb12dc6(b);
			if (itemDNA != null)
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
				if (itemDNA.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Material))
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
					if (itemDNA.m_materialType == c424fafa6354141c1e81d53efca575d8d)
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
						num += itemDNA.m_value;
					}
				}
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			return num;
		}
	}

	public void c4664d50badb8133ba931a253977f782d(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
		if (c42a8a9b0dd4206315a44f945fbf7331f == c5242449e40eab9ce5011e2bacd82070c)
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
		c9374c9e18d64e753feff5ba5622a02ad().c4664d50badb8133ba931a253977f782d(c42a8a9b0dd4206315a44f945fbf7331f, c5242449e40eab9ce5011e2bacd82070c);
	}

	public void c972a624b053fa175be4e64196965eb15(byte c30d73fd0c12edf60c058e08df3692557, byte cfaffa833cc1d4800aa963fe18d6e8a07, bool c57a95ebcb899508cd608bd72d959a9f9)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c972a624b053fa175be4e64196965eb15(c30d73fd0c12edf60c058e08df3692557, cfaffa833cc1d4800aa963fe18d6e8a07, c57a95ebcb899508cd608bd72d959a9f9);
	}

	public void cd5aabef23453e5fe1dc51bd3dddabd23()
	{
		c9374c9e18d64e753feff5ba5622a02ad().cd5aabef23453e5fe1dc51bd3dddabd23();
	}

	public ItemDNA[] c77d8654eaecd92e95d29266c606a0f92()
	{
		return c9374c9e18d64e753feff5ba5622a02ad().c77d8654eaecd92e95d29266c606a0f92();
	}

	public bool c8247c0810f772f58d56e0b9d19370f8e(ItemDNA ca57e1c076c01141c5ce58c7341db7833)
	{
		return c9374c9e18d64e753feff5ba5622a02ad().c8247c0810f772f58d56e0b9d19370f8e(ca57e1c076c01141c5ce58c7341db7833);
	}

	public bool c6facc64e2d5edf33221db1a902d2ccf3(ItemDNA ca57e1c076c01141c5ce58c7341db7833)
	{
		bool flag = c8247c0810f772f58d56e0b9d19370f8e(ca57e1c076c01141c5ce58c7341db7833);
		if (flag)
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
			c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5("70001");
		}
		return flag;
	}
}
