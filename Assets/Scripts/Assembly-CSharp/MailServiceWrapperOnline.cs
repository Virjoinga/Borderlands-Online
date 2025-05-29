using System.Collections.Generic;
using A;

internal class MailServiceWrapperOnline : IMailServiceWrapper, IServiceWrapper
{
	private bool m_isInitializing;

	private bool m_initialized;

	public void cd93285db16841148ed53a5bbeb35cf20()
	{
		if (m_isInitializing)
		{
			return;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_initialized)
			{
				return;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				m_isInitializing = true;
				m_initialized = true;
				OnAccessSingleton<IMailService, MailService, MailServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c890613d5d5185ad6eda570654aedce91(cf5e290519fc8dbad1352379c308ffaa2.c7088de59e49f7108f520cf7e0bae167e);
				OnAccessSingleton<IMailService, MailService, MailServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ca4195be1c246aa03c15dd07642fe960a(c66348853bb204011ac6a41084b2249f0);
				OnAccessSingleton<IMailService, MailService, MailServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c7e0ca5da43d892747e79cf62e65ac61d(cabcf3dfafca0f425cc6faf5d40aff614);
				return;
			}
		}
	}

	protected void c66348853bb204011ac6a41084b2249f0(MailInfo c3dcbd96db109d771ad5df31ff887a118)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<MailServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnNewMail(c3dcbd96db109d771ad5df31ff887a118);
	}

	protected void cabcf3dfafca0f425cc6faf5d40aff614(List<MailInfo> c4fc0e2096f0df7b20f7938ab21b80ea4)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<MailServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnGetMailList(c4fc0e2096f0df7b20f7938ab21b80ea4);
	}

	public void c890613d5d5185ad6eda570654aedce91(OnGotMailInfo c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<IMailService, MailService, MailServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c890613d5d5185ad6eda570654aedce91(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c8c71e978b55bc1d65cffa8cba32ed71f(OnSendMail c2db84530ef366a6deb001d449d4aa151, string c76759d33b9cb2580a3b145e1ba084675, string ca04b8fe5d43144ba3361431c00741486)
	{
		OnAccessSingleton<IMailService, MailService, MailServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c8c71e978b55bc1d65cffa8cba32ed71f(c2db84530ef366a6deb001d449d4aa151, c76759d33b9cb2580a3b145e1ba084675, ca04b8fe5d43144ba3361431c00741486);
	}

	public void c576f44b3071b0b941ce913d80b32bc52(OnReadMail c2db84530ef366a6deb001d449d4aa151, int ca5b7408e6e09760b0d233c71c059aec3)
	{
		OnAccessSingleton<IMailService, MailService, MailServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c576f44b3071b0b941ce913d80b32bc52(c2db84530ef366a6deb001d449d4aa151, ca5b7408e6e09760b0d233c71c059aec3);
	}

	public void ce7617ddfcf071c0b6b413615f347f61b(OnGetMailItem c2db84530ef366a6deb001d449d4aa151, int ca5b7408e6e09760b0d233c71c059aec3)
	{
		OnAccessSingleton<IMailService, MailService, MailServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ce7617ddfcf071c0b6b413615f347f61b(c2db84530ef366a6deb001d449d4aa151, ca5b7408e6e09760b0d233c71c059aec3);
	}

	public void c094cd005fed2c85b5b372c1cd5d05775(OnDeleteMail c2db84530ef366a6deb001d449d4aa151, int ca5b7408e6e09760b0d233c71c059aec3)
	{
		OnAccessSingleton<IMailService, MailService, MailServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c094cd005fed2c85b5b372c1cd5d05775(c2db84530ef366a6deb001d449d4aa151, ca5b7408e6e09760b0d233c71c059aec3);
	}

	public bool c39df47367fa21412aabfef05d9972f8c()
	{
		return m_initialized;
	}
}
