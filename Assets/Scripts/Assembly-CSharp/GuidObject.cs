using System;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class GuidObject
{
	private Guid m_guid = Guid.Empty;

	[SerializeField]
	private string m_guidString = string.Empty;

	public Guid guid
	{
		get
		{
			if (Guid.Empty == m_guid)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (string.Empty != m_guidString)
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
					m_guid = new Guid(m_guidString);
				}
			}
			return m_guid;
		}
	}

	protected void c6fe03fa1f08db5f045e967bfb1012526()
	{
		m_guid = Guid.NewGuid();
		m_guidString = m_guid.ToString();
	}

	protected virtual void c38b0293f2e32959475dd3d81f2e1822a(Guid c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		m_guid = c35f98ccbfa8c6bf09319c620b21b5dc5;
		m_guidString = c35f98ccbfa8c6bf09319c620b21b5dc5.ToString();
	}

	public bool c943bc6a18586b3e0e6f0214717aca479()
	{
		return string.Empty != m_guidString;
	}

	protected virtual void c153e3da90824ccc888fff1572e1bb344()
	{
		m_guidString = string.Empty;
		m_guid = Guid.Empty;
	}

	protected bool c4f6c27479fe2944078755693878d5cb0()
	{
		bool flag = guid.ToString() != m_guidString;
		if (flag)
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
			c153e3da90824ccc888fff1572e1bb344();
		}
		return flag;
	}
}
