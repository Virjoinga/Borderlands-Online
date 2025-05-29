using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public abstract class UniqueAudioObjectManager<T> : AudioSubsystem where T : NamedUniqueAudioObject, new()
{
	private List<T> m_objects = new List<T>();

	private List<string> m_objectNames = new List<string>();

	public List<T> c1805d5170a48b3a8510e57fd9095ce11
	{
		get
		{
			return m_objects;
		}
	}

	public List<string> c2541c04c6cdfaab2b924200fcd93b628
	{
		get
		{
			return m_objectNames;
		}
	}

	public UniqueAudioObjectManager()
	{
	}

	public T c1dbab84ec70b47ceb7556534f9774c7e(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		T val = new T
		{
			Name = cd99af21e22e356018b8f72d4a7e4872a
		};
		c6f49409b2929e4f0c4160ced1e7704fb(val, string.Empty);
		return val;
	}

	public int c5617cd9d4613b653423c8eccb0d8bf0b(Guid c8617b5eb968b7f3507d7a864ef849cb1)
	{
		return m_objects.FindIndex((T cbd1639b67f4774915e463c3fd4e982f3) => c8617b5eb968b7f3507d7a864ef849cb1.Equals(cbd1639b67f4774915e463c3fd4e982f3.guid));
	}

	public T c7d8bcbffd0abba75bb0f851c10e4cf50(Guid c8617b5eb968b7f3507d7a864ef849cb1)
	{
		int num = c5617cd9d4613b653423c8eccb0d8bf0b(c8617b5eb968b7f3507d7a864ef849cb1);
		object result;
		if (num >= 0)
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
			result = m_objects[num];
		}
		else
		{
			result = (T)null;
		}
		return (T)result;
	}

	public int c191ca98eb7ae3212e47cbf2f46c4ede0(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		return m_objectNames.IndexOf(cd99af21e22e356018b8f72d4a7e4872a);
	}

	public T c9a0fb97bf320c11bf5802038abd88405(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		int num = c191ca98eb7ae3212e47cbf2f46c4ede0(cd99af21e22e356018b8f72d4a7e4872a);
		object result;
		if (num >= 0)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			result = m_objects[num];
		}
		else
		{
			result = (T)null;
		}
		return (T)result;
	}

	protected override bool c636d1ce20de5e9ba30d812014e152d16()
	{
		c38aeacc59bd560b59403945ae7996d79();
		return true;
	}

	protected override void cb14749be8b076f79fe42c8d8bee20c8a()
	{
	}

	protected virtual void c6f49409b2929e4f0c4160ced1e7704fb(T cebae66039aadeac8deb1211786332a72, string c26bc9278762c84e1e76177f085674c7e)
	{
		m_objects.Add(cebae66039aadeac8deb1211786332a72);
		m_objectNames.Add(c26bc9278762c84e1e76177f085674c7e + cebae66039aadeac8deb1211786332a72.Name);
	}

	protected virtual void c09d511c3784ab095450edb35ff70e674()
	{
		for (int i = 0; i < m_objects.Count; i++)
		{
			T val = m_objects[i];
			val.cf5212e6903ec0c0b27816142c32a2d13();
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
			m_objects.Clear();
			m_objectNames.Clear();
			return;
		}
	}

	public virtual void c89e353632385d799ae18926f4d1896ab()
	{
	}

	public virtual void c38aeacc59bd560b59403945ae7996d79()
	{
		c09d511c3784ab095450edb35ff70e674();
	}
}
