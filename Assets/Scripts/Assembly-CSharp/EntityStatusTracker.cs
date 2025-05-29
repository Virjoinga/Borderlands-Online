using A;

public class EntityStatusTracker
{
	private c46099de2cc6e7023f3abcc78fd614b34<char> m_statusBuffer = new c46099de2cc6e7023f3abcc78fd614b34<char>(200);

	private string m_previousRecord;

	public void c8f790ca9399dfd7a0a401c4a23935160(string c6acfbf09834f3e38b23e0ee6c2c97f87)
	{
		if (string.IsNullOrEmpty(c6acfbf09834f3e38b23e0ee6c2c97f87))
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
		if (m_previousRecord == c6acfbf09834f3e38b23e0ee6c2c97f87)
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
		m_previousRecord = c6acfbf09834f3e38b23e0ee6c2c97f87;
		char[] array = m_previousRecord.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			m_statusBuffer.Add(array[i]);
		}
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

	public string c6b324dcbc8d0dcd2ff97466f9af2b021()
	{
		if (m_statusBuffer != null)
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
			if (m_statusBuffer.Count != 0)
			{
				char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(m_statusBuffer.Count);
				m_statusBuffer.CopyTo(array, 0);
				return new string(array);
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		return string.Empty;
	}

	public void c2a2e8095600221f5b7fd231a2404cc0c(string cde8f0acced36a8aa8dd4c33e6e29c417 = "EntityStatusTracker\n")
	{
	}
}
