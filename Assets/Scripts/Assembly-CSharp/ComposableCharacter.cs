using System;
using System.Collections.Generic;

[Serializable]
public class ComposableCharacter
{
	public uint bkID;

	public string m_sTypeName;

	public string m_sCharacterName;

	public string m_sSkeletonName;

	public List<ComposablePart> m_aParts;

	public ComposableCharacter()
	{
	}

	public ComposableCharacter(string c14cf1778b4df0dadc29b72a8e2a1ea6f, string c838cfb4afccba36126f6b6bdc60154da)
	{
		m_sTypeName = c14cf1778b4df0dadc29b72a8e2a1ea6f;
		m_sCharacterName = c838cfb4afccba36126f6b6bdc60154da;
		m_aParts = new List<ComposablePart>();
		bkID = 0u;
	}

	public bool cef7d19a41873e5964e1625425908d994(string c4b0035839780b3333a08e7ba3af86445)
	{
		using (List<ComposablePart>.Enumerator enumerator = m_aParts.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ComposablePart current = enumerator.Current;
				if (!(current.m_sPartName == c4b0035839780b3333a08e7ba3af86445))
				{
					continue;
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
					return true;
				}
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_004c;
				}
				continue;
				end_IL_004c:
				break;
			}
		}
		return false;
	}
}
