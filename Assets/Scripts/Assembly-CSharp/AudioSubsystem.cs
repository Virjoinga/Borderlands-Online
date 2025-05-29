using Core;
using UnityEngine;

[ExecuteInEditMode]
public abstract class AudioSubsystem : IAudioSubsystem
{
	protected bool m_initialized;

	protected bool m_inScene;

	protected abstract bool c636d1ce20de5e9ba30d812014e152d16();

	protected abstract void cb14749be8b076f79fe42c8d8bee20c8a();

	protected virtual void OnSceneLoaded(bool loaded)
	{
	}

	public virtual void Update()
	{
	}

	public virtual void c6738a99a1dd128185a2728e161db856b()
	{
	}

	public bool cd93285db16841148ed53a5bbeb35cf20()
	{
		bool result = false;
		if (!m_initialized)
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
			result = (m_initialized = c636d1ce20de5e9ba30d812014e152d16());
		}
		else
		{
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Multiple initialization calls for subsystem: " + GetType());
		}
		return result;
	}

	public void c5c15220c3e633306fef152f245ce53fa()
	{
		if (!m_initialized)
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
			cb14749be8b076f79fe42c8d8bee20c8a();
			return;
		}
	}

	public void cf1cac2831a88ef421c1c1a462d53c86a()
	{
		OnSceneLoaded(true);
		m_inScene = true;
	}

	public void c8972ba92b262823f7442f6167f31765f()
	{
		OnSceneLoaded(false);
		m_inScene = false;
	}
}
