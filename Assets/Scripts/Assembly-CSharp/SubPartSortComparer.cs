using System.Collections.Generic;
using XsdSettings;

public class SubPartSortComparer : IComparer<SubPartWpn>
{
	public int Compare(SubPartWpn part1, SubPartWpn part2)
	{
		if (part1 == null)
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
			if (part2 == null)
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
		}
		if (part1 != null)
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
			if (part2 == null)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return 1;
					}
				}
			}
		}
		if (part1 == null)
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
			if (part2 != null)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return -1;
					}
				}
			}
		}
		if (part1.m_weaponType > part2.m_weaponType)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return 1;
				}
			}
		}
		if (part1.m_weaponType < part2.m_weaponType)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return -1;
				}
			}
		}
		if (part1.m_partType > part2.m_partType)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return 1;
				}
			}
		}
		if (part1.m_partType < part2.m_partType)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return -1;
				}
			}
		}
		if (part1.m_Index > part2.m_Index)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return 1;
				}
			}
		}
		if (part1.m_Index < part2.m_Index)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return -1;
				}
			}
		}
		if (part1.m_Index == part2.m_Index)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return 0;
				}
			}
		}
		return 0;
	}
}
