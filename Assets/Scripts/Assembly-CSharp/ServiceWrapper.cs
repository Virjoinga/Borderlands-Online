using A;

public abstract class ServiceWrapper<I, T> : c1ee7921b0c3cce194fb7cae41b5a9d82<T> where I : class, IServiceWrapper where T : class, new()
{
	protected I m_wrapperOnline;

	protected I m_wrapperSession;

	protected I m_wrapperTown;

	protected virtual I c9374c9e18d64e753feff5ba5622a02ad()
	{
		if (m_wrapperSession != null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_wrapperSession.c39df47367fa21412aabfef05d9972f8c())
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return m_wrapperSession;
					}
				}
			}
		}
		return m_wrapperOnline;
	}

	public virtual void Reset()
	{
	}

	public virtual void cd93285db16841148ed53a5bbeb35cf20()
	{
		if (m_wrapperOnline != null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_wrapperOnline.cd93285db16841148ed53a5bbeb35cf20();
		}
		if (m_wrapperSession != null)
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
			m_wrapperSession.cd93285db16841148ed53a5bbeb35cf20();
		}
		if (m_wrapperTown == null)
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
			m_wrapperTown.cd93285db16841148ed53a5bbeb35cf20();
			return;
		}
	}

	public virtual bool c39df47367fa21412aabfef05d9972f8c()
	{
		I val = c9374c9e18d64e753feff5ba5622a02ad();
		return val.c39df47367fa21412aabfef05d9972f8c();
	}
}
