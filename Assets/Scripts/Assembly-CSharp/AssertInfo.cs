using Core;

public struct AssertInfo
{
	public enum InfoSource
	{
		FromHost = 0,
		FromClient = 1
	}

	public InfoSource m_from;

	public LogCategory m_type;

	public string m_msg;

	public string m_stackTrace;

	public AssertInfo(InfoSource cae5fea398599f41bfafc9b6bb6f4559b, LogCategory c2b4f43f34e21572af6ab4414f04cee36, string c709b291ceac9f97f0c78f269054fa014, string c234559b393d74c9d27df1458e6a16b58)
	{
		m_from = cae5fea398599f41bfafc9b6bb6f4559b;
		m_type = c2b4f43f34e21572af6ab4414f04cee36;
		m_msg = c709b291ceac9f97f0c78f269054fa014;
		m_stackTrace = c234559b393d74c9d27df1458e6a16b58;
	}

	public static InfoSource c265c495001426ebc83f0983ae99c0ead()
	{
		return InfoSource.FromClient;
	}

	public override int GetHashCode()
	{
		return cab05c97ab6dee558edc49d79f6a92ed1(m_from, m_type, m_msg, m_stackTrace);
	}

	public static int cab05c97ab6dee558edc49d79f6a92ed1(InfoSource cae5fea398599f41bfafc9b6bb6f4559b, LogCategory c2b4f43f34e21572af6ab4414f04cee36, string c709b291ceac9f97f0c78f269054fa014, string c234559b393d74c9d27df1458e6a16b58)
	{
		return cae5fea398599f41bfafc9b6bb6f4559b.GetHashCode() * 3 + c2b4f43f34e21572af6ab4414f04cee36.GetHashCode() * 5 + c709b291ceac9f97f0c78f269054fa014.GetHashCode() * 7 + c234559b393d74c9d27df1458e6a16b58.GetHashCode() * 11;
	}
}
