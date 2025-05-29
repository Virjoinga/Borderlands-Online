using System.Collections.Generic;
using System.Xml;

public class AudioSwitch : NamedUniqueAudioObject
{
	private List<string> m_cases = new List<string>();

	private int m_defaultCaseIdx = -1;

	public static readonly string DEFAULT_ATTR = "Default";

	public static readonly string CASE_TAG = "Case";

	public List<string> c603bc87a940e6d7c15a21f73f7538591
	{
		get
		{
			return m_cases;
		}
	}

	public string cd321a58aaf57e87b4e4ae0fb0a8b868d
	{
		get
		{
			object result;
			if (m_defaultCaseIdx == -1)
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
				result = null;
			}
			else
			{
				result = m_cases[m_defaultCaseIdx];
			}
			return (string)result;
		}
		set
		{
			if (value == null)
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
				m_defaultCaseIdx = -1;
			}
			int num = c841bc10f0725d960d73090183dca610d(value);
			if (num == -1)
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
				m_defaultCaseIdx = num;
				return;
			}
		}
	}

	private int c841bc10f0725d960d73090183dca610d(string cf33639188d22b78126fbeb0744fd1f05)
	{
		return m_cases.FindIndex((string c7c80fef79e3c330ae5014832d44fcd28) => c7c80fef79e3c330ae5014832d44fcd28.Equals(cf33639188d22b78126fbeb0744fd1f05));
	}

	public bool c921dfdab73e4f5bfaecc185c5b6359ff(string cf33639188d22b78126fbeb0744fd1f05)
	{
		return -1 != c841bc10f0725d960d73090183dca610d(cf33639188d22b78126fbeb0744fd1f05);
	}

	public int c60f7dd0e5f723f9d442a9d20de9dca36(string c2b46a96fe6e7029b761fe211178a4f43)
	{
		m_cases.Add(c2b46a96fe6e7029b761fe211178a4f43);
		return m_cases.Count - 1;
	}

	public bool ce29e4f25c3fc5c23206ec15e38c6a1f4(string cf33639188d22b78126fbeb0744fd1f05)
	{
		int cae80adcd816940694e39ede2c2d356ee = m_cases.FindIndex((string c7c80fef79e3c330ae5014832d44fcd28) => c7c80fef79e3c330ae5014832d44fcd28.Equals(cf33639188d22b78126fbeb0744fd1f05));
		return ce29e4f25c3fc5c23206ec15e38c6a1f4(cae80adcd816940694e39ede2c2d356ee);
	}

	public bool ce29e4f25c3fc5c23206ec15e38c6a1f4(int cae80adcd816940694e39ede2c2d356ee)
	{
		int num;
		if (0 <= cae80adcd816940694e39ede2c2d356ee)
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
			num = ((cae80adcd816940694e39ede2c2d356ee < m_cases.Count) ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		bool flag = (byte)num != 0;
		if (flag)
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
			m_cases.RemoveAt(cae80adcd816940694e39ede2c2d356ee);
			if (cae80adcd816940694e39ede2c2d356ee == m_defaultCaseIdx)
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
				m_defaultCaseIdx = -1;
			}
			else if (cae80adcd816940694e39ede2c2d356ee < m_defaultCaseIdx)
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
				m_defaultCaseIdx--;
			}
		}
		return flag;
	}

	public override void cc09306479ed0f9f54a5e4e8dd8d72b99(XmlNode cab83bba925e6355b7d0df9fe7c31c6e1)
	{
		base.cc09306479ed0f9f54a5e4e8dd8d72b99(cab83bba925e6355b7d0df9fe7c31c6e1);
		bool flag = false;
		XmlNode xmlNode = cab83bba925e6355b7d0df9fe7c31c6e1.Attributes[DEFAULT_ATTR];
		if (xmlNode != null)
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
			flag = int.TryParse(xmlNode.Value, out m_defaultCaseIdx);
		}
		if (!flag)
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
			m_defaultCaseIdx = -1;
		}
		XmlNodeList childNodes = cab83bba925e6355b7d0df9fe7c31c6e1.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			XmlElement xmlElement = childNodes[i] as XmlElement;
			string innerText = xmlElement.InnerText;
			c60f7dd0e5f723f9d442a9d20de9dca36(innerText);
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public override void c9742307d0830ac7381f2acd66ed5a6e2(XmlElement cab83bba925e6355b7d0df9fe7c31c6e1)
	{
		base.c9742307d0830ac7381f2acd66ed5a6e2(cab83bba925e6355b7d0df9fe7c31c6e1);
		cab83bba925e6355b7d0df9fe7c31c6e1.SetAttribute(DEFAULT_ATTR, m_defaultCaseIdx.ToString());
		XmlDocument ownerDocument = cab83bba925e6355b7d0df9fe7c31c6e1.OwnerDocument;
		for (int i = 0; i < m_cases.Count; i++)
		{
			XmlElement xmlElement = ownerDocument.CreateElement(CASE_TAG);
			xmlElement.InnerText = m_cases[i];
			cab83bba925e6355b7d0df9fe7c31c6e1.AppendChild(xmlElement);
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
			return;
		}
	}
}
