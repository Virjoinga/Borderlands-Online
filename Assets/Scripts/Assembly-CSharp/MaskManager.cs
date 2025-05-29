using System.Collections.Generic;
using pumpkin.display;

public class MaskManager
{
	private Dictionary<MovieClip, MovieClip[]> map;

	protected static MaskManager _MaskInstance;

	public MaskManager()
	{
		map = new Dictionary<MovieClip, MovieClip[]>();
	}

	public void c691ab6ea2ee6d471d8daa38c709e55f3(MovieClip c00e847a806ec2a41adb14fba59305dba, MovieClip[] caa55e0718174061fc168a54e16732a8e)
	{
		if (c00e847a806ec2a41adb14fba59305dba == null)
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
					return;
				}
			}
		}
		if (!map.ContainsKey(c00e847a806ec2a41adb14fba59305dba))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					map.Add(c00e847a806ec2a41adb14fba59305dba, caa55e0718174061fc168a54e16732a8e);
					return;
				}
			}
		}
		map[c00e847a806ec2a41adb14fba59305dba] = caa55e0718174061fc168a54e16732a8e;
	}

	public void c6a66de0dc4243b4bccc9ecf8069b15d9(MovieClip c00e847a806ec2a41adb14fba59305dba)
	{
		if (c00e847a806ec2a41adb14fba59305dba == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			map.Remove(c00e847a806ec2a41adb14fba59305dba);
			return;
		}
	}

	public static MaskManager c71f6ce28731edfd43c976fbd57c57bea()
	{
		if (_MaskInstance == null)
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
			_MaskInstance = new MaskManager();
		}
		return _MaskInstance;
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		map.Clear();
	}

	public void Update(MovieClip masker)
	{
		if (map.Count == 0)
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
					return;
				}
			}
		}
		if (masker == null)
		{
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
		MovieClip[] array = map[masker];
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == null)
			{
				continue;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			array[i].clipRect = masker.getBounds(array[i]).rect;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public void Update()
	{
		if (map.Count == 0)
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
		using (Dictionary<MovieClip, MovieClip[]>.Enumerator enumerator = map.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<MovieClip, MovieClip[]> current = enumerator.Current;
				if (current.Key == null)
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
				}
				else
				{
					Update(current.Key);
				}
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}
}
