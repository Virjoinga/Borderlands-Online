public class GUIDGenerator
{
	private static int s_guid;

	public int cbe79b1a2ad9e29920a501c4d8fd47a4c()
	{
		s_guid++;
		return s_guid;
	}

	public string c6e2b9ff42c167dc996f3caa221267502(bool c27e474c790bd92e08ecd05ed04acb3bf = false)
	{
		if (c27e474c790bd92e08ecd05ed04acb3bf)
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
					return (cbe79b1a2ad9e29920a501c4d8fd47a4c() + 10000).ToString();
				}
			}
		}
		return cbe79b1a2ad9e29920a501c4d8fd47a4c().ToString();
	}
}
