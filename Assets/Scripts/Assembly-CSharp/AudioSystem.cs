using A;
using Core;
using UnityEngine;

[ExecuteInEditMode]
public class AudioSystem : cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>, IAudioSubsystem
{
	private IAudioSubsystem[] m_subsystems;

	private AudioManager m_controller;

	private bool m_initialized;

	private bool m_enabled = true;

	public bool c9d5aded6668d31de4d83fc0acc0b5378
	{
		get
		{
			return m_enabled;
		}
		set
		{
			m_enabled = value;
		}
	}

	public AudioManager c25046e6b975d93d61f54b600e399597d
	{
		get
		{
			return m_controller;
		}
		private set
		{
			m_controller = value;
		}
	}

	public UniqueAudioObjectRegistry c26971795b1d653dc38ca5b626df5799a
	{
		get
		{
			return c4c23c2dea2651df547654d57a723f847<UniqueAudioObjectRegistry>(EAudioSubsystems.BEGIN);
		}
	}

	public AudioResourceManager c9f6a0386ce93c761939b8a4def1e3435
	{
		get
		{
			return c4c23c2dea2651df547654d57a723f847<AudioResourceManager>(EAudioSubsystems.RESOURCE);
		}
	}

	public AudioBusManager cc6e3847a57e10af584d6f85377557e52
	{
		get
		{
			return c4c23c2dea2651df547654d57a723f847<AudioBusManager>(EAudioSubsystems.BUS);
		}
	}

	public AudioPlaybackManager c68d5fe96dbd54537a81187198113d273
	{
		get
		{
			return c4c23c2dea2651df547654d57a723f847<AudioPlaybackManager>(EAudioSubsystems.PLAYBACK);
		}
	}

	public AudioRTPCManager c9953d92a9c161783264e2ac3970133a7
	{
		get
		{
			return c4c23c2dea2651df547654d57a723f847<AudioRTPCManager>(EAudioSubsystems.RTPC);
		}
	}

	public AudioSwitchManager c3229ba9047e17cc44ef40a4662327489
	{
		get
		{
			return c4c23c2dea2651df547654d57a723f847<AudioSwitchManager>(EAudioSubsystems.SWITCH);
		}
	}

	public AudioParameterValues ca32cea5690944ab3b10bc11ad74a0cc7
	{
		get
		{
			object result;
			if (m_controller != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				result = m_controller.gameObject.GetComponent<AudioParameterValues>();
			}
			else
			{
				result = null;
			}
			return (AudioParameterValues)result;
		}
	}

	public AudioSystem()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "Creating AudioSystem");
		m_subsystems = caf18fd8921d3089367b8f51760a2a7dc.c0a0cdf4a196914163f7334d9b0781a04(6);
		m_subsystems[0] = new UniqueAudioObjectRegistry();
		m_subsystems[1] = new AudioResourceManager();
		m_subsystems[2] = new AudioBusManager();
		m_subsystems[3] = new AudioPlaybackManager();
		m_subsystems[4] = new AudioRTPCManager();
		m_subsystems[5] = new AudioSwitchManager();
	}

	protected c18a666b7cc7dfce5218aae4b13df952d c4c23c2dea2651df547654d57a723f847<c18a666b7cc7dfce5218aae4b13df952d>(EAudioSubsystems c1d8bc3d1bb232d35a9ad7e6861d857e7)
	{
		return (c18a666b7cc7dfce5218aae4b13df952d)m_subsystems[(int)c1d8bc3d1bb232d35a9ad7e6861d857e7];
	}

	public bool cd93285db16841148ed53a5bbeb35cf20()
	{
		if (!m_initialized)
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "AudioSystem.Initialize()");
			bool initialized = true;
			int num = 0;
			while (true)
			{
				if (num < m_subsystems.Length)
				{
					if (!m_subsystems[num].cd93285db16841148ed53a5bbeb35cf20())
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
						initialized = false;
						c5c15220c3e633306fef152f245ce53fa();
						break;
					}
					num++;
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
				break;
			}
			m_initialized = initialized;
		}
		return m_initialized;
	}

	public void c5c15220c3e633306fef152f245ce53fa()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "AudioSystem.Deinitialize()");
		for (int num = m_subsystems.Length - 1; num >= 0; num--)
		{
			m_subsystems[num].c5c15220c3e633306fef152f245ce53fa();
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
			m_initialized = false;
			return;
		}
	}

	public void cf1cac2831a88ef421c1c1a462d53c86a()
	{
		for (int i = 0; i < m_subsystems.Length; i++)
		{
			m_subsystems[i].cf1cac2831a88ef421c1c1a462d53c86a();
		}
		while (true)
		{
			switch (2)
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

	public void c8972ba92b262823f7442f6167f31765f()
	{
		for (int num = m_subsystems.Length - 1; num >= 0; num--)
		{
			m_subsystems[num].c8972ba92b262823f7442f6167f31765f();
		}
		while (true)
		{
			switch (5)
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

	public void Update()
	{
		for (int i = 0; i < m_subsystems.Length; i++)
		{
			m_subsystems[i].Update();
		}
		while (true)
		{
			switch (5)
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

	public void c6738a99a1dd128185a2728e161db856b()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "AudioSystem ReleaseMemory - " + Time.time);
		for (int i = 0; i < m_subsystems.Length; i++)
		{
			m_subsystems[i].c6738a99a1dd128185a2728e161db856b();
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
			return;
		}
	}

	public void c91a7840b219e99c4672cde05157d8b6d(AudioManager c13c2de52afd8df2d5f6a9c3902dba7cc)
	{
		m_controller = c13c2de52afd8df2d5f6a9c3902dba7cc;
		if (!(null != m_controller))
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
			c9f6a0386ce93c761939b8a4def1e3435.c7868c1f01d2505d185b6c0fe2bd93abd();
			return;
		}
	}
}
