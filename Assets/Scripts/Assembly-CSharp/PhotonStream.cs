using System.Collections.Generic;
using Core;
using UnityEngine;

public class PhotonStream
{
	private bool write;

	internal List<object> data;

	private byte currentItem;

	public bool c8b2526be2638bb30a29ab8314b369311
	{
		get
		{
			return write;
		}
	}

	public bool cb8e0d05aa2c04e14f3633a4d8d11cfd7
	{
		get
		{
			return !write;
		}
	}

	public int c9a57a1c6eac92cceec2de50aa04e4757
	{
		get
		{
			return data.Count;
		}
	}

	public PhotonStream(bool cd675e8acb51af7b6826061b071bd00bc, object[] cc06f5ba84af5d3e05231605132ca8761)
	{
		write = cd675e8acb51af7b6826061b071bd00bc;
		if (cc06f5ba84af5d3e05231605132ca8761 == null)
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
					data = new List<object>();
					return;
				}
			}
		}
		data = new List<object>(cc06f5ba84af5d3e05231605132ca8761);
	}

	public object cbc3e6f46d26c8fb00a98f05fc700248a()
	{
		if (write)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Error: you cannot read this stream that you are writing!");
					return null;
				}
			}
		}
		object result = data[currentItem];
		currentItem++;
		return result;
	}

	public void caf7283cc5cd9725a88a9cdfa630d92f8(object cebae66039aadeac8deb1211786332a72)
	{
		if (!write)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Error: you cannot write/send to this stream that you are reading!");
					return;
				}
			}
		}
		data.Add(cebae66039aadeac8deb1211786332a72);
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		data.Clear();
	}

	public bool c0c94263e548501b400c7350444d3fe35()
	{
		return data.Count == 0;
	}

	public object[] c31f9a91c3c697b1aa6620a91d7d94572()
	{
		return data.ToArray();
	}

	public void c21abc56059d171e999147f26bbf75889(ref bool c46f2b6014954246f83001e8ad8ee3060)
	{
		if (write)
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
					data.Add(c46f2b6014954246f83001e8ad8ee3060);
					return;
				}
			}
		}
		if (data.Count <= currentItem)
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
			c46f2b6014954246f83001e8ad8ee3060 = (bool)data[currentItem];
			currentItem++;
			return;
		}
	}

	public void c21abc56059d171e999147f26bbf75889(ref int c8624938a2f16b964995dc93ad888c473)
	{
		if (write)
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
					data.Add(c8624938a2f16b964995dc93ad888c473);
					return;
				}
			}
		}
		if (data.Count <= currentItem)
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
			c8624938a2f16b964995dc93ad888c473 = (int)data[currentItem];
			currentItem++;
			return;
		}
	}

	public void c21abc56059d171e999147f26bbf75889(ref string cefda2fdc3ce4e04f38bab77fc7998241)
	{
		if (write)
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
					data.Add(cefda2fdc3ce4e04f38bab77fc7998241);
					return;
				}
			}
		}
		if (data.Count <= currentItem)
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
			cefda2fdc3ce4e04f38bab77fc7998241 = (string)data[currentItem];
			currentItem++;
			return;
		}
	}

	public void c21abc56059d171e999147f26bbf75889(ref char cefda2fdc3ce4e04f38bab77fc7998241)
	{
		if (write)
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
					data.Add(cefda2fdc3ce4e04f38bab77fc7998241);
					return;
				}
			}
		}
		if (data.Count <= currentItem)
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
			cefda2fdc3ce4e04f38bab77fc7998241 = (char)data[currentItem];
			currentItem++;
			return;
		}
	}

	public void c21abc56059d171e999147f26bbf75889(ref short cefda2fdc3ce4e04f38bab77fc7998241)
	{
		if (write)
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
					data.Add(cefda2fdc3ce4e04f38bab77fc7998241);
					return;
				}
			}
		}
		if (data.Count <= currentItem)
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
			cefda2fdc3ce4e04f38bab77fc7998241 = (short)data[currentItem];
			currentItem++;
			return;
		}
	}

	public void c21abc56059d171e999147f26bbf75889(ref float cebae66039aadeac8deb1211786332a72)
	{
		if (write)
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
					data.Add(cebae66039aadeac8deb1211786332a72);
					return;
				}
			}
		}
		if (data.Count <= currentItem)
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
			cebae66039aadeac8deb1211786332a72 = (float)data[currentItem];
			currentItem++;
			return;
		}
	}

	public void c21abc56059d171e999147f26bbf75889(ref PhotonPlayer cebae66039aadeac8deb1211786332a72)
	{
		if (write)
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
					data.Add(cebae66039aadeac8deb1211786332a72);
					return;
				}
			}
		}
		if (data.Count <= currentItem)
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
			cebae66039aadeac8deb1211786332a72 = (PhotonPlayer)data[currentItem];
			currentItem++;
			return;
		}
	}

	public void c21abc56059d171e999147f26bbf75889(ref Vector3 cebae66039aadeac8deb1211786332a72)
	{
		if (write)
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
					data.Add(cebae66039aadeac8deb1211786332a72);
					return;
				}
			}
		}
		if (data.Count <= currentItem)
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
			cebae66039aadeac8deb1211786332a72 = (Vector3)data[currentItem];
			currentItem++;
			return;
		}
	}

	public void c21abc56059d171e999147f26bbf75889(ref Vector2 cebae66039aadeac8deb1211786332a72)
	{
		if (write)
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
					data.Add(cebae66039aadeac8deb1211786332a72);
					return;
				}
			}
		}
		if (data.Count <= currentItem)
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
			cebae66039aadeac8deb1211786332a72 = (Vector2)data[currentItem];
			currentItem++;
			return;
		}
	}

	public void c21abc56059d171e999147f26bbf75889(ref Quaternion cebae66039aadeac8deb1211786332a72)
	{
		if (write)
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
					data.Add(cebae66039aadeac8deb1211786332a72);
					return;
				}
			}
		}
		if (data.Count <= currentItem)
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
			cebae66039aadeac8deb1211786332a72 = (Quaternion)data[currentItem];
			currentItem++;
			return;
		}
	}
}
