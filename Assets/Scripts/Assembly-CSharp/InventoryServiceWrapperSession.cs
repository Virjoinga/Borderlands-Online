using A;
using XsdSettings;

public class InventoryServiceWrapperSession : IInventoryServiceWrapper, IServiceWrapper
{
	private EquipmentInventoryEntityPlayer m_equipment;

	private EntityPlayer m_localPlayer;

	public void cd93285db16841148ed53a5bbeb35cf20()
	{
	}

	public bool c39df47367fa21412aabfef05d9972f8c()
	{
		m_localPlayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
		if ((bool)m_localPlayer)
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
			m_equipment = m_localPlayer.c5ca38fad98337fc5c7255384b2cd1a86() as EquipmentInventoryEntityPlayer;
			if ((bool)m_equipment)
			{
				while (true)
				{
					switch (1)
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
		return m_equipment.c48db535623c3c5d4028ae3a36cb12dc6(c793014f9fd028450a4a9908376309f26);
	}

	public ItemDNA c4e0dae6a16a8a80ddb5214a896b9df58(byte c793014f9fd028450a4a9908376309f26)
	{
		return m_equipment.c20ad6bcf5b5ce2ad75ae35905409f5fa(c793014f9fd028450a4a9908376309f26);
	}

	public byte c91233b4b8268e8e24a4daa8c053e41ec()
	{
		return m_equipment.c91233b4b8268e8e24a4daa8c053e41ec();
	}

	public int c5ddb5f74d1f3e3c06409d657ed5eb7a1(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b)
	{
		return m_equipment.c19b70ea6e4db0802bb7cae385cc85109(c1e73ae4c18ab95639cb0c7604f21dc2b);
	}

	public int cd164b9ec3a9d0fc37e11d7fd46792ef2(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b)
	{
		return m_equipment.c8a605fa1a9c2a71cfb141d9433f2f958(c1e73ae4c18ab95639cb0c7604f21dc2b);
	}

	public int ca77a0dd5dbf0daa686053361865cb06a()
	{
		return m_equipment.ca77a0dd5dbf0daa686053361865cb06a();
	}

	public int caa75b946a7aa0d2b3a6d5c5b2b94f0a3()
	{
		return m_equipment.caa75b946a7aa0d2b3a6d5c5b2b94f0a3();
	}

	public void cc62b4b3e79f635a94d84949382bba1fc(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_localPlayer.cc62b4b3e79f635a94d84949382bba1fc(c42a8a9b0dd4206315a44f945fbf7331f, c5242449e40eab9ce5011e2bacd82070c);
			return;
		}
	}

	public void ccfdbed5cc5051e9ffb25bea212f7ddc6(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
		if (!m_localPlayer)
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
			m_localPlayer.ccfdbed5cc5051e9ffb25bea212f7ddc6(c42a8a9b0dd4206315a44f945fbf7331f, c5242449e40eab9ce5011e2bacd82070c);
			return;
		}
	}

	public void cabac189d699c8d8d56d0e1a68cd1440b(byte cd27037dd3bf1006e6e39ebf89cbd7b03, byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		if (!m_localPlayer)
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
			m_localPlayer.cabac189d699c8d8d56d0e1a68cd1440b(cd27037dd3bf1006e6e39ebf89cbd7b03, c19a39247ea86ffe5f0de9d429ca0ca95);
			return;
		}
	}

	public void c89361444df98c6f8354125e8bdb18882(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		if (!m_localPlayer)
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
			m_localPlayer.c89361444df98c6f8354125e8bdb18882(c19a39247ea86ffe5f0de9d429ca0ca95);
			return;
		}
	}

	public void c61f40925cf99c31aa9ac5df098110ada(byte c71953cab9dff52e14146804e2928df92)
	{
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
			m_localPlayer.c61f40925cf99c31aa9ac5df098110ada(c71953cab9dff52e14146804e2928df92);
			return;
		}
	}

	public ItemDNA cec5e771a298fe1e51f84e4ec6dcb5165()
	{
		if (m_localPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return null;
				}
			}
		}
		return m_localPlayer.ce28a223f404aa592c5a5374f3601de28();
	}

	public void c2bf177eafbfeb7beaa0bfd04facb2029(byte c71953cab9dff52e14146804e2928df92)
	{
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_localPlayer.c2bf177eafbfeb7beaa0bfd04facb2029(c71953cab9dff52e14146804e2928df92);
			return;
		}
	}

	public ItemDNA c86b944a82d70502ff9ec6c7d1fa5f420()
	{
		if (m_localPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return null;
				}
			}
		}
		return m_localPlayer.ce151fa795d7c589adcf6f778be230913();
	}

	public void cccb56495987b6a4ebab7b225fb1af261(byte c793014f9fd028450a4a9908376309f26)
	{
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_localPlayer.cccb56495987b6a4ebab7b225fb1af261(c793014f9fd028450a4a9908376309f26);
			return;
		}
	}

	public void cb71c24b68b65fe176d7936520d63a102(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!m_localPlayer.c611613a4cdf13c7acc73007bf65a3d2c(c19a39247ea86ffe5f0de9d429ca0ca95))
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
				m_localPlayer.c1fc97d9000793496ac114d06521f85a0(c19a39247ea86ffe5f0de9d429ca0ca95);
				return;
			}
		}
	}

	public bool cc7fc82e2186587ba2141daa47aab239e(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		return m_equipment.c20ad6bcf5b5ce2ad75ae35905409f5fa(c19a39247ea86ffe5f0de9d429ca0ca95) != c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e;
	}

	public void c4664d50badb8133ba931a253977f782d(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
	}

	public void c972a624b053fa175be4e64196965eb15(byte c30d73fd0c12edf60c058e08df3692557, byte cfaffa833cc1d4800aa963fe18d6e8a07, bool c57a95ebcb899508cd608bd72d959a9f9)
	{
	}

	public void cd5aabef23453e5fe1dc51bd3dddabd23()
	{
	}

	public ItemDNA[] c77d8654eaecd92e95d29266c606a0f92()
	{
		return null;
	}

	public bool c8247c0810f772f58d56e0b9d19370f8e(ItemDNA ca57e1c076c01141c5ce58c7341db7833)
	{
		if (m_equipment != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return m_equipment.c3ac9dbf338103e5bc87b5c2d6acf117a(ca57e1c076c01141c5ce58c7341db7833);
				}
			}
		}
		return false;
	}
}
