using System;
using System.Collections;
using System.Collections.Generic;

public class Group
{
	public int Id;

	public Presence Leader;

	public List<Presence> Members;

	public string GameId;

	public int ca0dc0c335bcd7a0d16510da3a64d1c4f
	{
		get
		{
			return Members.Count + 1;
		}
	}

	public Group(Hashtable c28cf3d24e3067ef54895f824fad7fcef)
	{
		cc95f1fbaa3f9e0533900d0e3a5e0bfa2(c28cf3d24e3067ef54895f824fad7fcef);
	}

	private void cc95f1fbaa3f9e0533900d0e3a5e0bfa2(Hashtable c28cf3d24e3067ef54895f824fad7fcef)
	{
		Id = (int)c28cf3d24e3067ef54895f824fad7fcef[0];
		Leader = new Presence((Hashtable)c28cf3d24e3067ef54895f824fad7fcef[1]);
		Members = new List<Presence>();
		Hashtable hashtable = (Hashtable)c28cf3d24e3067ef54895f824fad7fcef[2];
		IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
				Members.Add(new Presence((Hashtable)dictionaryEntry.Value));
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
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						goto end_IL_00b6;
					}
					continue;
					end_IL_00b6:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
	}
}
