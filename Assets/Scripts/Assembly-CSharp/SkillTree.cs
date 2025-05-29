using System;
using System.Collections;
using System.Collections.Generic;

public class SkillTree
{
	private List<InvestedSkill> mSkills = new List<InvestedSkill>();

	public int CharacterId { get; set; }

	public int Earned { get; set; }

	public int Unspent { get; set; }

	public IEnumerable<InvestedSkill> c6a4f37ba4a1351c87aec2f808f9c9f82
	{
		get
		{
			return mSkills.AsReadOnly();
		}
		set
		{
			mSkills = new List<InvestedSkill>(value);
		}
	}

	public SkillTree(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		cc95f1fbaa3f9e0533900d0e3a5e0bfa2(c591d56a94543e3559945c497f37126c4);
	}

	public void cc95f1fbaa3f9e0533900d0e3a5e0bfa2(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		CharacterId = (int)c591d56a94543e3559945c497f37126c4[0];
		Earned = (int)c591d56a94543e3559945c497f37126c4[1];
		Unspent = (int)c591d56a94543e3559945c497f37126c4[2];
		Hashtable hashtable = (Hashtable)c591d56a94543e3559945c497f37126c4[3];
		IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
				mSkills.Add(new InvestedSkill((int)dictionaryEntry.Key, (int)dictionaryEntry.Value));
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
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_00cd;
					}
					continue;
					end_IL_00cd:
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
