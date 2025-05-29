using System;
using System.Collections.Generic;
using System.IO;
using A;
using Core;

public static class Utility
{
	public enum TimeComponent : byte
	{
		Day = 2,
		Hour = 4,
		Minute = 8,
		Second = 0x10
	}

	private static uint[] CRC32Table;

	public static List<string> ccc598556a1396a884281110a8af0e303(string c8aa0e7ee156ed339de23d3fe5557b916, string cbbe12207b6d58aaa4cd60faec1c982d7)
	{
		List<string> list = new List<string>();
		string[] directories = Directory.GetDirectories(c8aa0e7ee156ed339de23d3fe5557b916);
		for (int i = 0; i < directories.Length; i++)
		{
			list.AddRange(ccc598556a1396a884281110a8af0e303(directories[i], cbbe12207b6d58aaa4cd60faec1c982d7));
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
			list.AddRange(Directory.GetFiles(c8aa0e7ee156ed339de23d3fe5557b916, cbbe12207b6d58aaa4cd60faec1c982d7));
			return list;
		}
	}

	public static uint cf642a65627df2adf4e90330457651907(string c7c80fef79e3c330ae5014832d44fcd28)
	{
		uint num = 0u;
		for (int num2 = c7c80fef79e3c330ae5014832d44fcd28.Length - 1; num2 >= 0; num2--)
		{
			num = (num << 5) - num + c7c80fef79e3c330ae5014832d44fcd28[num2];
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
			return num;
		}
	}

	public static uint cf642a65627df2adf4e90330457651907(char[] c7c80fef79e3c330ae5014832d44fcd28)
	{
		uint num = 0u;
		for (int num2 = c7c80fef79e3c330ae5014832d44fcd28.Length - 1; num2 >= 0; num2--)
		{
			num = (num << 5) - num + c7c80fef79e3c330ae5014832d44fcd28[num2];
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
			return num;
		}
	}

	private static void c140d3641ca3cba342455bae0ff1a0392()
	{
		if (CRC32Table != null)
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
		CRC32Table = ce55979e9f08acdc753c56cf4f3bd0dcf.c0a0cdf4a196914163f7334d9b0781a04(256);
		for (uint num = 0u; num < 256; num++)
		{
			uint num2 = num;
			for (int i = 0; i < 8; i++)
			{
				if (num2 % 2 == 0)
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
					num2 >>= 1;
				}
				else
				{
					num2 = (num2 >> 1) ^ 0xEDB88320u;
				}
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_005d;
				}
				continue;
				end_IL_005d:
				break;
			}
			CRC32Table[num] = num2;
		}
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

	public static uint cd12e6a8420d1adaedb2c2afeafc98f5a(string cd1e3dee5c83b42041dac36bf26b36d23)
	{
		c140d3641ca3cba342455bae0ff1a0392();
		uint result = uint.MaxValue;
		if (File.Exists(cd1e3dee5c83b42041dac36bf26b36d23))
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
			FileStream fileStream = new FileStream(cd1e3dee5c83b42041dac36bf26b36d23, FileMode.Open, FileAccess.Read);
			result = cd12e6a8420d1adaedb2c2afeafc98f5a(fileStream);
			fileStream.Close();
			fileStream.Dispose();
		}
		else
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Tool, "File Not Exists: " + cd1e3dee5c83b42041dac36bf26b36d23);
		}
		return result;
	}

	public static uint cd12e6a8420d1adaedb2c2afeafc98f5a(Stream c4f572e677246eb1a0cf92afc8682dc7b)
	{
		c140d3641ca3cba342455bae0ff1a0392();
		long length = c4f572e677246eb1a0cf92afc8682dc7b.Length;
		uint num = uint.MaxValue;
		for (long num2 = 0L; num2 < length; num2++)
		{
			byte b = (byte)c4f572e677246eb1a0cf92afc8682dc7b.ReadByte();
			num = ((num >> 8) & 0xFFFFFFu) ^ CRC32Table[(num ^ b) & 0xFF];
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
			return num ^ 0xFFFFFFFFu;
		}
	}

	public static uint cd12e6a8420d1adaedb2c2afeafc98f5a(byte[] caaeca6e35667f32ce3da8be21b2cc4b8)
	{
		c140d3641ca3cba342455bae0ff1a0392();
		long num = caaeca6e35667f32ce3da8be21b2cc4b8.Length;
		uint num2 = uint.MaxValue;
		for (long num3 = 0L; num3 < num; num3++)
		{
			byte b = caaeca6e35667f32ce3da8be21b2cc4b8[num3];
			num2 = ((num2 >> 8) & 0xFFFFFFu) ^ CRC32Table[(num2 ^ b) & 0xFF];
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
			return num2 ^ 0xFFFFFFFFu;
		}
	}

	public static string c12cf74d239864b4c456273b0defe220a(int c91f3e8180fa591f162af678df7a0c637, int c3e1851e67225b4f8072a589e9d76f03b, bool c2bfb9dae13870ad580615ef7fdd8c479 = false)
	{
		string text = string.Empty;
		int num;
		if (((uint)c3e1851e67225b4f8072a589e9d76f03b & 8u) != 0)
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
			num = c91f3e8180fa591f162af678df7a0c637 % 60;
		}
		else
		{
			num = c91f3e8180fa591f162af678df7a0c637;
		}
		int num2 = num;
		int num3;
		if (((uint)c3e1851e67225b4f8072a589e9d76f03b & 4u) != 0)
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
			num3 = c91f3e8180fa591f162af678df7a0c637 / 60 % 60;
		}
		else
		{
			num3 = c91f3e8180fa591f162af678df7a0c637 / 60;
		}
		int num4 = num3;
		int num5;
		if (((uint)c3e1851e67225b4f8072a589e9d76f03b & 2u) != 0)
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
			num5 = c91f3e8180fa591f162af678df7a0c637 / 60 / 60 % 24;
		}
		else
		{
			num5 = c91f3e8180fa591f162af678df7a0c637 / 60 / 60;
		}
		int num6 = num5;
		int num7 = c91f3e8180fa591f162af678df7a0c637 / 60 / 60 / 24;
		if (((uint)c3e1851e67225b4f8072a589e9d76f03b & 2u) != 0)
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
			if (num7 <= 0)
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
				if (!c2bfb9dae13870ad580615ef7fdd8c479)
				{
					goto IL_00be;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			text = text + num7 + LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Day"));
		}
		goto IL_00be;
		IL_0152:
		if (((uint)c3e1851e67225b4f8072a589e9d76f03b & 0x10u) != 0)
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
			if (num2 <= 0)
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
				if (!c2bfb9dae13870ad580615ef7fdd8c479)
				{
					goto IL_019d;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			text = text + num2 + LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Second"));
		}
		goto IL_019d;
		IL_0108:
		if (((uint)c3e1851e67225b4f8072a589e9d76f03b & 8u) != 0)
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
			if (num4 <= 0)
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
				if (!c2bfb9dae13870ad580615ef7fdd8c479)
				{
					goto IL_0152;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			text = text + num4 + LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Minute"));
		}
		goto IL_0152;
		IL_00be:
		if (((uint)c3e1851e67225b4f8072a589e9d76f03b & 4u) != 0)
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
			if (num6 <= 0)
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
				if (!c2bfb9dae13870ad580615ef7fdd8c479)
				{
					goto IL_0108;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			text = text + num6 + LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Hour"));
		}
		goto IL_0108;
		IL_019d:
		return text;
	}

	public static string c3702d7d2ce9dcf64b29c2fab82d733d5(DateTime cea283d66900cb173d912b4ab24dcf451)
	{
		string text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Offline"));
		TimeSpan timeSpan = DateTime.Now.Subtract(cea283d66900cb173d912b4ab24dcf451);
		if (timeSpan.Days != 0)
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
					return text + timeSpan.Days + LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Day"));
				}
			}
		}
		if (timeSpan.Hours != 0)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return text + timeSpan.Hours + LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Hour"));
				}
			}
		}
		if (timeSpan.Minutes != 0)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return text + timeSpan.Minutes + LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Minute"));
				}
			}
		}
		return text + "1" + LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Minute"));
	}
}
