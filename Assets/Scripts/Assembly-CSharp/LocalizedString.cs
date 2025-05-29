using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using A;
using Core;

public class LocalizedString : ILocalizedContent
{
	private string _lanValue = string.Empty;

	private string _codeValue = string.Empty;

	private string[] _arrParamString;

	private static Regex regex = new Regex("\\{P(\\d+)\\}");

	public string c6ef1290751f4a29a1b80526cf77756ba
	{
		get
		{
			return _codeValue;
		}
	}

	private LocalizedString()
	{
	}

	public LocalizedString(string c0ecc54688f26e096af3299c445becd1a)
	{
		_codeValue = c0ecc54688f26e096af3299c445becd1a;
		LocalizeSystem.c71f6ce28731edfd43c976fbd57c57bea().c52e8444f2d4cfbbf467b736b371362e8(this);
	}

	public LocalizedString(string c0ecc54688f26e096af3299c445becd1a, string[] cea64b924a102a02c933c0b0b8cf5c2fa)
	{
		_codeValue = c0ecc54688f26e096af3299c445becd1a;
		LocalizeSystem.c71f6ce28731edfd43c976fbd57c57bea().c52e8444f2d4cfbbf467b736b371362e8(this);
		_arrParamString = cea64b924a102a02c933c0b0b8cf5c2fa;
	}

	protected virtual string ccf7810d24757730925d31e060f5d1f98(Match ce56fde8d3509d0493a8f32b937ad243e)
	{
		string s = ce56fde8d3509d0493a8f32b937ad243e.Value.Substring(2, ce56fde8d3509d0493a8f32b937ad243e.Value.Length - 3);
		int result = -1;
		if (int.TryParse(s, out result))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (result >= 0)
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
				if (result < _arrParamString.Length)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							return _arrParamString[result];
						}
					}
				}
			}
		}
		string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(7);
		array[0] = "Localize parameter wrong! Key: ";
		array[1] = _codeValue;
		array[2] = " Language string: ";
		array[3] = _lanValue;
		array[4] = "  !!@ ";
		array[5] = ce56fde8d3509d0493a8f32b937ad243e.Value;
		array[6] = " can not be substituted!";
		DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array));
		return ce56fde8d3509d0493a8f32b937ad243e.Value;
	}

	public override string ToString()
	{
		return _codeValue;
	}

	public void cd957b62b335eee8b757c4f6a17d901ff(string c0ecc54688f26e096af3299c445becd1a)
	{
		_lanValue = c0ecc54688f26e096af3299c445becd1a;
	}

	[SpecialName]
	public static string c00ae05b9ced94c9fc5f4be4892e6192b(LocalizedString c7576bcddfcc6ec6c3725a9f54e8061a6)
	{
		if (c7576bcddfcc6ec6c3725a9f54e8061a6._lanValue != string.Empty)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return regex.Replace(c7576bcddfcc6ec6c3725a9f54e8061a6._lanValue, c7576bcddfcc6ec6c3725a9f54e8061a6.ccf7810d24757730925d31e060f5d1f98);
				}
			}
		}
		return "!-- " + c7576bcddfcc6ec6c3725a9f54e8061a6._codeValue + "--!";
	}
}
