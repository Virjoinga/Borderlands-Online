using A;

public class InventorySlot
{
	public enum InventorySlotFlag
	{
		InventorySlot_Weapon = 1,
		InventorySlot_Shield = 1
	}

	protected Entity m_entity;

	protected int m_networkID;

	protected ItemDNA m_dna;

	public void c7cd2e714b90259c7cbaa0bd226fe8435(int c35f98ccbfa8c6bf09319c620b21b5dc5, ItemDNA caedbc1db6c28d44eab6021e7d674eab3)
	{
		m_networkID = c35f98ccbfa8c6bf09319c620b21b5dc5;
		m_entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(m_networkID);
		m_dna = caedbc1db6c28d44eab6021e7d674eab3;
	}

	public void c7cd2e714b90259c7cbaa0bd226fe8435(Entity c5d720f6d007abb0c4a21d6a654e405bb, ItemDNA caedbc1db6c28d44eab6021e7d674eab3)
	{
		m_entity = c5d720f6d007abb0c4a21d6a654e405bb;
		m_dna = caedbc1db6c28d44eab6021e7d674eab3;
	}

	public ItemDNA c729ce3b5f48e0eac3a7ead97b1d02f8d()
	{
		return m_dna;
	}

	public Entity c66b232dbebded7c7e9a89c1e8bd84689()
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_networkID != 0)
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
				m_entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(m_networkID);
			}
		}
		return m_entity;
	}

	public bool cc6aaf385211ddff355edfb4576dcd1d1()
	{
		int result;
		if (m_networkID == 0)
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
			result = ((m_entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e) ? 1 : 0);
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	public bool c2059a269502244da39c7c2ea73f84b76()
	{
		return m_networkID != 0;
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		m_networkID = 0;
		m_entity = c72d1b2b1b60b723ae8df41127652adb5.c7088de59e49f7108f520cf7e0bae167e;
		m_dna = c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e;
	}
}
