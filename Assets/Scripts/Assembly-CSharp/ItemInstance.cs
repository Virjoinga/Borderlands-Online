public class ItemInstance
{
	public int m_exp;

	public string m_id { get; private set; }

	public ItemInstance(string c35f98ccbfa8c6bf09319c620b21b5dc5, int cf13fd632f93aa296c99679582ff35a65 = 0)
	{
		m_id = c35f98ccbfa8c6bf09319c620b21b5dc5;
		m_exp = cf13fd632f93aa296c99679582ff35a65;
	}

	public override string ToString()
	{
		return m_id;
	}

	public override bool Equals(object obj)
	{
		ItemInstance itemInstance = obj as ItemInstance;
		if (itemInstance != null)
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
					return itemInstance.m_id == m_id;
				}
			}
		}
		return false;
	}

	public override int GetHashCode()
	{
		return m_id.GetHashCode();
	}
}
