using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public class InstanceInfo
{
	[CompilerGenerated]
	private static Func<DictionaryEntry, int> _003C_003Ef__am_0024cache1;

	[CompilerGenerated]
	private static Func<DictionaryEntry, int> _003C_003Ef__am_0024cache2;

	public virtual Dictionary<int, int> UnlockedInstances { get; set; }

	public InstanceInfo(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		cc95f1fbaa3f9e0533900d0e3a5e0bfa2(c591d56a94543e3559945c497f37126c4);
	}

	public virtual void cc95f1fbaa3f9e0533900d0e3a5e0bfa2(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		IEnumerable<DictionaryEntry> source = c591d56a94543e3559945c497f37126c4.Cast<DictionaryEntry>();
		if (_003C_003Ef__am_0024cache1 == null)
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
			_003C_003Ef__am_0024cache1 = (DictionaryEntry c872943035f78644fd01b267deff00547) => (int)c872943035f78644fd01b267deff00547.Key;
		}
		Func<DictionaryEntry, int> keySelector = _003C_003Ef__am_0024cache1;
		if (_003C_003Ef__am_0024cache2 == null)
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
			_003C_003Ef__am_0024cache2 = (DictionaryEntry c86067da2dafe73be3843733a6188b0e1) => (int)c86067da2dafe73be3843733a6188b0e1.Value;
		}
		UnlockedInstances = source.ToDictionary(keySelector, _003C_003Ef__am_0024cache2);
	}

	[CompilerGenerated]
	private static int ca62a814d79d7fcb598bcecf19fdc0627(DictionaryEntry c872943035f78644fd01b267deff00547)
	{
		return (int)c872943035f78644fd01b267deff00547.Key;
	}

	[CompilerGenerated]
	private static int c94afacbbe310305884040ba4dd851c7b(DictionaryEntry c86067da2dafe73be3843733a6188b0e1)
	{
		return (int)c86067da2dafe73be3843733a6188b0e1.Value;
	}
}
