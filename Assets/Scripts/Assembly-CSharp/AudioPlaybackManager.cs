using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

[ExecuteInEditMode]
public class AudioPlaybackManager : AudioSubsystem
{
	private List<AudioEventResponser> m_playingList = new List<AudioEventResponser>();

	private List<BaseEventHandler> m_triggerUpdateList = new List<BaseEventHandler>();

	private List<BaseEventResponser> m_fadeList = new List<BaseEventResponser>();

	private TensityControlSystem m_tensity;

	private AudioListener m_audioListener;

	private float m_lastCleanTime;

	private List<BaseEventHandler> m_removeList = new List<BaseEventHandler>();

	private List<BaseEventResponser> m_removeListR = new List<BaseEventResponser>();

	private List<int> m_removeListAD = new List<int>();

	private Vector2 m_scrollPos;

	public TensityControlSystem ce693c931d729e0b4883c89920d35043a
	{
		get
		{
			return m_tensity;
		}
		set
		{
			m_tensity = value;
			if (!m_tensity)
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
				m_tensity.c9b1d0dbe283462b532b8dfa340a18e2f();
				return;
			}
		}
	}

	public AudioListener cefdcf2f4f46a0ef9161d03211b8b0476
	{
		get
		{
			if (m_audioListener == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c6629b0929a61da3f8929c92b762b8811();
				c3ec6c8a3b3017de44fe7215da4f4ba2d(c06ca0e618478c23eba3419653a19760f<AudioManager>.c5ee19dc8d4cccf5ae2de225410458b86.transform);
			}
			return m_audioListener;
		}
	}

	protected override bool c636d1ce20de5e9ba30d812014e152d16()
	{
		m_lastCleanTime = Time.time;
		c6699cb5cacfd025526d2bbd6609656f1();
		return true;
	}

	private void c6629b0929a61da3f8929c92b762b8811()
	{
		GameObject gameObject = new GameObject("AUDIO_LISTENER");
		m_audioListener = gameObject.AddComponent<AudioListener>();
		Object.DontDestroyOnLoad(gameObject);
	}

	protected override void cb14749be8b076f79fe42c8d8bee20c8a()
	{
	}

	public override void c6738a99a1dd128185a2728e161db856b()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<AudioRandomResponserGlobalExclusion>.c5ee19dc8d4cccf5ae2de225410458b86.Reset();
	}

	public override void Update()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<AudioRandomResponserGlobalExclusion>.c5ee19dc8d4cccf5ae2de225410458b86.c766f96b9a191c766ab6ba852f923d296();
		c7cdad414004163409c167be8ce818727();
		c0afb51fe201eece6e4fd4a80f458352d();
		cb3d75f11d2aabbc93f8c9496364fd4e3();
	}

	public void c0927e04752baf8bb95ea1d3bffe4ae50(AudioEventResponser c17790d5897e0071708b2e5eceaa6bbab)
	{
		if (m_playingList.Contains(c17790d5897e0071708b2e5eceaa6bbab))
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
			m_playingList.Add(c17790d5897e0071708b2e5eceaa6bbab);
			return;
		}
	}

	public void c8aa8d201cd10228ac9fea715b3b44f3d(AudioEventResponser c17790d5897e0071708b2e5eceaa6bbab)
	{
		if (!m_playingList.Contains(c17790d5897e0071708b2e5eceaa6bbab))
		{
			return;
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
			m_playingList.Remove(c17790d5897e0071708b2e5eceaa6bbab);
			return;
		}
	}

	public void c3ec6c8a3b3017de44fe7215da4f4ba2d(Transform c3cb1f1345dbfd94c51709a9b2e9a9704)
	{
		if (m_audioListener == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c6629b0929a61da3f8929c92b762b8811();
		}
		if ((bool)m_audioListener)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					m_audioListener.transform.parent = c3cb1f1345dbfd94c51709a9b2e9a9704;
					m_audioListener.transform.localPosition = Vector3.zero;
					m_audioListener.transform.localRotation = Quaternion.identity;
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "Now audio listener is put on " + c3cb1f1345dbfd94c51709a9b2e9a9704.name);
					return;
				}
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "where is my audio listener?");
	}

	private void c6699cb5cacfd025526d2bbd6609656f1()
	{
		if (Camera.allCameras == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			for (int i = 0; i < Camera.allCameras.Length; i++)
			{
				AudioListener component;
				if (!(component = Camera.allCameras[i].GetComponent<AudioListener>()))
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
				if (!component.enabled)
				{
					continue;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					string text = Utils.c6623cde42db4307c0b144942a5a8c70d(component.gameObject);
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "find audio listener on camera: " + text + " - in Scene: " + Application.loadedLevelName);
					component.enabled = false;
					return;
				}
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	private void cb3d75f11d2aabbc93f8c9496364fd4e3()
	{
		for (int i = 0; i < m_triggerUpdateList.Count; i++)
		{
			if (m_triggerUpdateList[i].Update())
			{
				continue;
			}
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
			m_removeList.Add(m_triggerUpdateList[i]);
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			for (int j = 0; j < m_removeList.Count; j++)
			{
				m_triggerUpdateList.Remove(m_removeList[j]);
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				m_removeList.Clear();
				return;
			}
		}
	}

	public void c2764da59e8c286298060575e3251e48a(BaseEventHandler c93dbec96f39444e378558f06afbdd30f)
	{
		m_triggerUpdateList.Add(c93dbec96f39444e378558f06afbdd30f);
	}

	private void c0afb51fe201eece6e4fd4a80f458352d()
	{
		if (Time.time - m_lastCleanTime < 0.33f)
		{
			while (true)
			{
				switch (7)
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
		m_lastCleanTime = Time.time;
		int num = 0;
		for (int i = 0; i < m_playingList.Count; i++)
		{
			if (m_playingList[i] == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_removeListAD.Add(i);
				num++;
			}
			else
			{
				if (m_playingList[i].cb9efc4af2006b47000b468b9df139a30())
				{
					continue;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				m_playingList[i].OnStopped();
				m_removeListAD.Add(i);
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (0 < num)
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
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "CleanIdleSound(): " + num + "untracked sound!");
			}
			for (int num2 = m_removeListAD.Count - 1; num2 >= 0; num2--)
			{
				m_playingList.RemoveAt(m_removeListAD[num2]);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				m_removeListAD.Clear();
				c2ced5038bedacbd441e01546f5ac4b2d();
				return;
			}
		}
	}

	private void c2ced5038bedacbd441e01546f5ac4b2d()
	{
		cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.cc6e3847a57e10af584d6f85377557e52.cdd38a19c1260df758b2e7faf25fbd945();
		for (int i = 0; i < m_playingList.Count; i++)
		{
			AudioEventResponser audioEventResponser = m_playingList[i];
			audioEventResponser.c3facc767beb8d74f5ad31823245234b3().c29d0bac2e9f266c244ba1ee8613309ba().caf3e02be9e4a934ca58b0bb0fd29af4d();
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

	public void cfd7cc95ae872e913738fcf24e3516d08(BaseEventResponser ce8e7f17de45cb0d5369257e58968ade3)
	{
		if (m_fadeList.Contains(ce8e7f17de45cb0d5369257e58968ade3))
		{
			while (true)
			{
				switch (2)
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
		m_fadeList.Add(ce8e7f17de45cb0d5369257e58968ade3);
	}

	private void c7cdad414004163409c167be8ce818727()
	{
		if (m_fadeList.Count == 0)
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
			for (int i = 0; i < m_fadeList.Count; i++)
			{
				if (!(m_fadeList[i] == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					if (!m_fadeList[i].cc56123259c44174bf6c32d225c07c313())
					{
						continue;
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				m_removeListR.Add(m_fadeList[i]);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				for (int j = 0; j < m_removeListR.Count; j++)
				{
					m_fadeList.Remove(m_removeListR[j]);
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					m_removeListR.Clear();
					return;
				}
			}
		}
	}
}
