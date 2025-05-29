using A;
using Core;

public class BolBitArray
{
	private uint[] data;

	public int size { get; private set; }

	public BolBitArray(int c9e63d37175a5a5f9e2f1cf8e4c8d384a)
	{
		int num = c9e63d37175a5a5f9e2f1cf8e4c8d384a / 32;
		int num2;
		if (c9e63d37175a5a5f9e2f1cf8e4c8d384a % 32 == 0)
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
			num2 = 0;
		}
		else
		{
			num2 = 1;
		}
		int c36964cf41281414170f34ee68bef6c = num + num2;
		data = ce55979e9f08acdc753c56cf4f3bd0dcf.c0a0cdf4a196914163f7334d9b0781a04(c36964cf41281414170f34ee68bef6c);
		size = c9e63d37175a5a5f9e2f1cf8e4c8d384a;
	}

	public void cd1109b7ea29846a9735888dcb26a97fe(int c5612a459a84ffdb41c885401433cd62d, bool c875946a646fae34d94f2c30b013218d9)
	{
		int num = c5612a459a84ffdb41c885401433cd62d / 32;
		int num2 = c5612a459a84ffdb41c885401433cd62d % 32;
		if (c875946a646fae34d94f2c30b013218d9)
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
					data[num] |= (uint)(1 << num2);
					return;
				}
			}
		}
		data[num] &= (uint)(~(1 << num2));
	}

	public bool c4e0f63f4b4d409c5e3992c71520e30a0(int c5612a459a84ffdb41c885401433cd62d)
	{
		int num = c5612a459a84ffdb41c885401433cd62d / 32;
		int num2 = c5612a459a84ffdb41c885401433cd62d % 32;
		return (data[num] & (1 << num2)) != 0;
	}

	public void cdf9bd484c34b28bc08efb156117d4c00(int c9e63d37175a5a5f9e2f1cf8e4c8d384a)
	{
		size = c9e63d37175a5a5f9e2f1cf8e4c8d384a;
		if (c9e63d37175a5a5f9e2f1cf8e4c8d384a <= data.Length * 32)
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
			int num = c9e63d37175a5a5f9e2f1cf8e4c8d384a / 32;
			int num2;
			if (c9e63d37175a5a5f9e2f1cf8e4c8d384a % 32 == 0)
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
				num2 = 0;
			}
			else
			{
				num2 = 1;
			}
			int c36964cf41281414170f34ee68bef6c = num + num2;
			data = ce55979e9f08acdc753c56cf4f3bd0dcf.c0a0cdf4a196914163f7334d9b0781a04(c36964cf41281414170f34ee68bef6c);
			return;
		}
	}

	public bool c2597b50d417a76d0f3a2da9e6a95337b(BolBitArray c013143408b38d23070435dd98c1f06c0)
	{
		bool flag = true;
		if (c013143408b38d23070435dd98c1f06c0.size != size)
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
					return false;
				}
			}
		}
		for (int i = 0; i < data.Length; i++)
		{
			flag &= data[i] == c013143408b38d23070435dd98c1f06c0.data[i];
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			return flag;
		}
	}

	public void cd660fc4a18e29ee0236e3ea00091100a()
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = uint.MaxValue;
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
			return;
		}
	}

	public void cf45e42101e33efef33d634d1d0a308e3()
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = 0u;
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
			return;
		}
	}

	public bool c9582dfe940be0b515fdd8b46939faf38(BolBitArray c013143408b38d23070435dd98c1f06c0)
	{
		if (c013143408b38d23070435dd98c1f06c0.size == size)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					for (int i = 0; i < data.Length; i++)
					{
						data[i] &= c013143408b38d23070435dd98c1f06c0.data[i];
					}
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
			}
		}
		return false;
	}

	public bool caa9aa059f6d3891c4e705025ceae72f8(BolBitArray c013143408b38d23070435dd98c1f06c0)
	{
		if (c013143408b38d23070435dd98c1f06c0.size == size)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					for (int i = 0; i < data.Length; i++)
					{
						data[i] |= c013143408b38d23070435dd98c1f06c0.data[i];
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							return true;
						}
					}
				}
				}
			}
		}
		return false;
	}

	public BolBitArray c6247b97516f0f47835aa21a8285ce7e5()
	{
		BolBitArray bolBitArray = new BolBitArray(size);
		if (bolBitArray.data.Length != data.Length)
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
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(9);
			array[0] = "New/Old Size[";
			array[1] = bolBitArray.size;
			array[2] = "][";
			array[3] = size;
			array[4] = " New/Old data Length[";
			array[5] = bolBitArray.data.Length;
			array[6] = "][";
			array[7] = data.Length;
			array[8] = "]";
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, string.Concat(array));
		}
		for (int i = 0; i < data.Length; i++)
		{
			bolBitArray.data[i] = data[i];
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			return bolBitArray;
		}
	}

	private bool cc4a9433b6af5c97f1ed3d78ef166b57f(int c5612a459a84ffdb41c885401433cd62d)
	{
		int num = c5612a459a84ffdb41c885401433cd62d / 32;
		int num2 = c5612a459a84ffdb41c885401433cd62d % 32;
		return (data[num] & (1 << num2)) != 0;
	}

	public override string ToString()
	{
		string text = string.Empty;
		for (int i = 0; i < data.Length * 32; i++)
		{
			string text2 = text;
			int num;
			if (cc4a9433b6af5c97f1ed3d78ef166b57f(i))
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
				num = 1;
			}
			else
			{
				num = 0;
			}
			text = text2 + num;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return text + ":" + size;
		}
	}
}
