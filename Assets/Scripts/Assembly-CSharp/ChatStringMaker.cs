using System;
using System.Collections.Generic;

public class ChatStringMaker
{
	public enum ChatInputType
	{
		CT_Text = 0,
		CT_Weapon = 1,
		CT_Mat = 2
	}

	public struct InputInfo
	{
		public ChatInputType inputType;

		public string strValue;

		public string strViewValue;

		public string strTransValue;
	}

	protected List<InputInfo> m_arrInputInfoList = new List<InputInfo>();

	private int _iMaxChars;

	private string m_strID;

	private string _strPreText;

	private bool c2d824e883a52b1132f4796917d503ba5(int cf3e4129b0eb46f551cced0e004806ce6, out int c9526cedaae8a6f13c52592df57f78e6e)
	{
		int num = 0;
		int num2 = 0;
		using (List<InputInfo>.Enumerator enumerator = m_arrInputInfoList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				InputInfo current = enumerator.Current;
				if (cf3e4129b0eb46f551cced0e004806ce6 == num)
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
							c9526cedaae8a6f13c52592df57f78e6e = num2;
							return false;
						}
					}
				}
				num += current.strValue.Length;
				if (cf3e4129b0eb46f551cced0e004806ce6 < num)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							c9526cedaae8a6f13c52592df57f78e6e = num2;
							return true;
						}
					}
				}
				num2++;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					goto end_IL_0073;
				}
				continue;
				end_IL_0073:
				break;
			}
		}
		c9526cedaae8a6f13c52592df57f78e6e = m_arrInputInfoList.Count;
		return false;
	}

	public void c9d07e0a52df67b746698e11beb235411(int cf3e4129b0eb46f551cced0e004806ce6, string c094a4a1a0156e95bfac75eed5f525426)
	{
		int c9526cedaae8a6f13c52592df57f78e6e = 0;
		if (c2d824e883a52b1132f4796917d503ba5(cf3e4129b0eb46f551cced0e004806ce6, out c9526cedaae8a6f13c52592df57f78e6e))
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
					return;
				}
			}
		}
		InputInfo item = default(InputInfo);
		for (int i = 0; i < c094a4a1a0156e95bfac75eed5f525426.Length; i++)
		{
			item.inputType = ChatInputType.CT_Text;
			item.strValue = c094a4a1a0156e95bfac75eed5f525426[i].ToString();
			item.strTransValue = c094a4a1a0156e95bfac75eed5f525426[i].ToString();
			item.strViewValue = c094a4a1a0156e95bfac75eed5f525426[i].ToString();
			if (_iMaxChars > 0)
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
				if (c5a5630b1016bdc33ab28b84ab4f68857() + item.strValue.Length > _iMaxChars)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
			}
			m_arrInputInfoList.Insert(c9526cedaae8a6f13c52592df57f78e6e++, item);
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

	public void ce37049b1c6e60b25a6114f7be9e22d7d(int cf3e4129b0eb46f551cced0e004806ce6, InputInfo c00bb86ffbeb6764fbe60d7b64859db7f)
	{
		int c9526cedaae8a6f13c52592df57f78e6e;
		if (c2d824e883a52b1132f4796917d503ba5(cf3e4129b0eb46f551cced0e004806ce6, out c9526cedaae8a6f13c52592df57f78e6e))
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
					return;
				}
			}
		}
		if (_iMaxChars > 0)
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
			if (c5a5630b1016bdc33ab28b84ab4f68857() + c00bb86ffbeb6764fbe60d7b64859db7f.strValue.Length > _iMaxChars)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}
		m_arrInputInfoList.Insert(c9526cedaae8a6f13c52592df57f78e6e, c00bb86ffbeb6764fbe60d7b64859db7f);
	}

	public void c2f60e15b853088b328c7029c944d4176(int cf3e4129b0eb46f551cced0e004806ce6, int c3cee319d8825508319fd8e6a1168fe0d = 1)
	{
		if (m_arrInputInfoList.Count == 0)
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
		int num = 1;
		int c9526cedaae8a6f13c52592df57f78e6e;
		c2d824e883a52b1132f4796917d503ba5(cf3e4129b0eb46f551cced0e004806ce6, out c9526cedaae8a6f13c52592df57f78e6e);
		if (c3cee319d8825508319fd8e6a1168fe0d > 1)
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
			int c9526cedaae8a6f13c52592df57f78e6e2;
			c2d824e883a52b1132f4796917d503ba5(cf3e4129b0eb46f551cced0e004806ce6 + c3cee319d8825508319fd8e6a1168fe0d, out c9526cedaae8a6f13c52592df57f78e6e2);
			num = c9526cedaae8a6f13c52592df57f78e6e2 - c9526cedaae8a6f13c52592df57f78e6e;
		}
		if (c9526cedaae8a6f13c52592df57f78e6e < 0)
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
			if (num < 0)
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
				m_arrInputInfoList.RemoveRange(c9526cedaae8a6f13c52592df57f78e6e, num);
				return;
			}
		}
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		m_arrInputInfoList.Clear();
	}

	public int c63717d634de6b4a849edf089c8403f89(int cf3e4129b0eb46f551cced0e004806ce6, bool cebe4dc737bf45e32b5cbf902e82b7d94 = true)
	{
		int num = Math.Max(Math.Min(c5a5630b1016bdc33ab28b84ab4f68857(), cf3e4129b0eb46f551cced0e004806ce6), 0);
		int c9526cedaae8a6f13c52592df57f78e6e;
		if (c2d824e883a52b1132f4796917d503ba5(cf3e4129b0eb46f551cced0e004806ce6, out c9526cedaae8a6f13c52592df57f78e6e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			num = 0;
			if (cebe4dc737bf45e32b5cbf902e82b7d94)
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
				c9526cedaae8a6f13c52592df57f78e6e++;
			}
			for (int i = 0; i < c9526cedaae8a6f13c52592df57f78e6e; i++)
			{
				num += m_arrInputInfoList[i].strValue.Length;
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
		return num;
	}

	public string cfe82d5ebd5c716e55fdac199f3db7db1(int cfcb28aa552fb34b47d70420bac13fde4, int c7aa65860d91cc9a800a4f9a000e19bf0)
	{
		if (c7aa65860d91cc9a800a4f9a000e19bf0 < cfcb28aa552fb34b47d70420bac13fde4)
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
					return string.Empty;
				}
			}
		}
		string text = string.Empty;
		int i;
		c2d824e883a52b1132f4796917d503ba5(cfcb28aa552fb34b47d70420bac13fde4, out i);
		int c9526cedaae8a6f13c52592df57f78e6e;
		c2d824e883a52b1132f4796917d503ba5(c7aa65860d91cc9a800a4f9a000e19bf0, out c9526cedaae8a6f13c52592df57f78e6e);
		for (; i <= c9526cedaae8a6f13c52592df57f78e6e; i++)
		{
			text += m_arrInputInfoList[i].strValue;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return text;
		}
	}

	public string cacb712132910f653280e21b175dc564d()
	{
		string text = string.Empty;
		using (List<InputInfo>.Enumerator enumerator = m_arrInputInfoList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				text += enumerator.Current.strViewValue;
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
				break;
			}
		}
		return _strPreText + text;
	}

	public string cc4110c4a5820d26a32d025fd117df81a()
	{
		string text = string.Empty;
		using (List<InputInfo>.Enumerator enumerator = m_arrInputInfoList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				text += enumerator.Current.strTransValue;
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
				break;
			}
		}
		return text;
	}

	public int c5a5630b1016bdc33ab28b84ab4f68857()
	{
		int num = 0;
		using (List<InputInfo>.Enumerator enumerator = m_arrInputInfoList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				num += enumerator.Current.strValue.Length;
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
				break;
			}
		}
		return num;
	}

	public void cea52b661c66d32af86a6a15d54bd8f92(int c94309deb88d2b1d167b132a063e3595a)
	{
		_iMaxChars = Math.Max(c94309deb88d2b1d167b132a063e3595a, 0);
	}

	public void c75d58403d1e8b87c008cb98f50c8978b(string c094a4a1a0156e95bfac75eed5f525426)
	{
		_strPreText = c094a4a1a0156e95bfac75eed5f525426;
	}

	public string cd839be44bdc7701fb49aff03122ddd39()
	{
		return _strPreText;
	}
}
