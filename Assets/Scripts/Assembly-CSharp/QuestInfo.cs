using System;
using System.Collections;
using System.Collections.Generic;

public class QuestInfo
{
	private List<QuestProgress> mQuests;

	public virtual IEnumerable<QuestProgress> c2fb4c9c9659765c3c70794dd27c10c69
	{
		get
		{
			return mQuests.AsReadOnly();
		}
		set
		{
			mQuests = new List<QuestProgress>(value);
		}
	}

	public QuestInfo(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		cc95f1fbaa3f9e0533900d0e3a5e0bfa2(c591d56a94543e3559945c497f37126c4);
	}

	public void cc95f1fbaa3f9e0533900d0e3a5e0bfa2(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		mQuests = new List<QuestProgress>();
		IDictionaryEnumerator enumerator = c591d56a94543e3559945c497f37126c4.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
				mQuests.Add(new QuestProgress((Hashtable)dictionaryEntry.Value));
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
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_006b;
					}
					continue;
					end_IL_006b:
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
