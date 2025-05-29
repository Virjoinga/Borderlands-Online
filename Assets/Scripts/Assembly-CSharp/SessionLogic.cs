using A;
using Core;

public abstract class SessionLogic
{
	private Utils.Timer m_timer = new Utils.Timer();

	protected c0f3c1d262ce52808e3809fe84e7b77f8 m_SessionSM = new c0f3c1d262ce52808e3809fe84e7b77f8();

	public bool m_isMapLoaded;

	public abstract void cd93285db16841148ed53a5bbeb35cf20();

	public abstract void cad90a477761d59d842235621762e4fe8();

	public abstract void c5c15220c3e633306fef152f245ce53fa();

	public virtual void c6c6cbb0045146f9b0a890f787bad6e4d()
	{
		if (m_timer.cf928603d375f06225f9eb5213fb17bd4())
		{
			while (true)
			{
				switch (7)
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
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
			array[0] = "SessionLogic: ";
			array[1] = m_SessionSM.m_curState.ca5a2b345087379ea02ec4ca950356e9f;
			array[2] = " - map: ";
			array[3] = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.ce5a94914572053ccdd4c35353ff8d650();
			array[4] = " - #players: ";
			array[5] = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c64f58cc60811857c739035f7a63f475c();
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, string.Concat(array));
			m_timer.cdada4c3678c9c23c38aaf0754a94a620();
		}
		if (!m_timer.cb261500372fa488b369e9159a002977a())
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			m_timer.Start(300f);
		}
		m_SessionSM.Update();
	}

	public abstract bool cb9efc4af2006b47000b468b9df139a30();

	public abstract void OnGoToSubInstance(string mapName);

	public abstract void OnGoToInstance();

	public abstract void OnMapChange();
}
