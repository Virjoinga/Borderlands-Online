using System;
using System.Collections.Generic;

public class LocalizeSystem
{
	protected string _curLanguage = "CHI";

	protected Dictionary<Type, IContentManager> _dicContentMgrs = new Dictionary<Type, IContentManager>();

	private static LocalizeSystem s_instance;

	public string c0942034ca9742c1fa5f9f5a8d1fd0663
	{
		get
		{
			return _curLanguage;
		}
	}

	private LocalizeSystem()
	{
	}

	public static LocalizeSystem c71f6ce28731edfd43c976fbd57c57bea()
	{
		if (s_instance == null)
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
			s_instance = new LocalizeSystem();
		}
		return s_instance;
	}

	public void cfc8ae7589bb86588d34a387a4dbf2280(string cd3d074e2f700204b5e406a7161f3f5f9)
	{
		if (!(_curLanguage != cd3d074e2f700204b5e406a7161f3f5f9))
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
			_curLanguage = cd3d074e2f700204b5e406a7161f3f5f9;
			OnLanguageChanged();
			return;
		}
	}

	public void c4abf4b2a135ff23fb33a4355cec2a85c<c59782ef8bca74bd5a9b3205cc5720dce>(IContentManager c532b9e27685f696d32331c089aec2fc2) where c59782ef8bca74bd5a9b3205cc5720dce : ILocalizedContent
	{
		if (c532b9e27685f696d32331c089aec2fc2 == null)
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
		if (_dicContentMgrs.ContainsKey(typeof(c59782ef8bca74bd5a9b3205cc5720dce)))
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
			_dicContentMgrs[typeof(c59782ef8bca74bd5a9b3205cc5720dce)] = c532b9e27685f696d32331c089aec2fc2;
		}
		else
		{
			_dicContentMgrs.Add(typeof(c59782ef8bca74bd5a9b3205cc5720dce), c532b9e27685f696d32331c089aec2fc2);
		}
		c532b9e27685f696d32331c089aec2fc2.OnLanguageChange(_curLanguage);
	}

	public virtual void c52e8444f2d4cfbbf467b736b371362e8(ILocalizedContent c2f5bf353a014eb0dbbe5bc14ea35c833)
	{
		if (c2f5bf353a014eb0dbbe5bc14ea35c833 == null)
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
		if (!_dicContentMgrs.ContainsKey(c2f5bf353a014eb0dbbe5bc14ea35c833.GetType()))
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
			_dicContentMgrs[c2f5bf353a014eb0dbbe5bc14ea35c833.GetType()].OnContentAdded(c2f5bf353a014eb0dbbe5bc14ea35c833);
			return;
		}
	}

	protected virtual void OnLanguageChanged()
	{
		using (Dictionary<Type, IContentManager>.Enumerator enumerator = _dicContentMgrs.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current.Value.OnLanguageChange(_curLanguage);
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
}
