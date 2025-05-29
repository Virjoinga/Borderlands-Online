using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

[ExecuteInEditMode]
public class AudioEventResponser : BaseEventResponser
{
	public delegate int RandomGenerator(string soundName, int max);

	public AudioClip m_clip;

	public AudioSource m_audioTemplate;

	private AudioSource m_audio;

	public bool m_enablePlaybackLimit;

	public int m_instanceNum = 1;

	public AudioLimitScope m_scope;

	public AudioDiscardRule m_rule = AudioDiscardRule.DiscardNewest;

	public bool m_enableRandomPitch;

	public float m_randomPitchRange;

	public float m_defaultPitch;

	private float m_defaultVolume;

	public AudioMixer m_mixer = new AudioMixer();

	[SerializeField]
	private AudioBusReference m_bus = new AudioBusReference();

	private AudioEventResponsers m_parentSound;

	public bool m_inheritFromParent = true;

	public AudioRTPCcurve[] m_RTPCs;

	private Dictionary<RTPCTargetType, float> m_rtpcValues = new Dictionary<RTPCTargetType, float>();

	public AudioParameterValues m_parameters;

	private float m_lastVol = -1f;

	public AudioSource c51438ec138336c21c293ac062d7620b9
	{
		get
		{
			return m_audio;
		}
	}

	public void cc66b1b0046b75df3f2ab299d0cfa5f10(AudioParameterValues c90ecb087828ed9ceb9c00eafb6d52f4c)
	{
		AudioEventResponser[] componentsInChildren = GetComponentsInChildren<AudioEventResponser>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].m_parameters = c90ecb087828ed9ceb9c00eafb6d52f4c;
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

	protected AudioParameterValues cab010853285c6825c61de59deedff427()
	{
		AudioParameterValues result;
		if (null != m_parameters)
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
			result = m_parameters;
		}
		else
		{
			result = cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.ca32cea5690944ab3b10bc11ad74a0cc7;
		}
		return result;
	}

	public AudioMixer c29d0bac2e9f266c244ba1ee8613309ba()
	{
		return m_mixer;
	}

	public bool c7c7bc6006ae74fc8339e6ff93988a5a8()
	{
		return m_bus.c943bc6a18586b3e0e6f0214717aca479();
	}

	public AudioBus caa99e4aaf4b417cb6994af3adf45d1b3()
	{
		return m_bus.c588e7dbcd383d8230b2d83d7b44af23b();
	}

	public AudioBus c3facc767beb8d74f5ad31823245234b3()
	{
		if (m_bus.c943bc6a18586b3e0e6f0214717aca479())
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
					return m_bus.c588e7dbcd383d8230b2d83d7b44af23b();
				}
			}
		}
		if (null != m_parentSound)
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
			if (m_parentSound.c7c7bc6006ae74fc8339e6ff93988a5a8())
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return m_parentSound.c3facc767beb8d74f5ad31823245234b3();
					}
				}
			}
		}
		return cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.cc6e3847a57e10af584d6f85377557e52.cf545464dc99cdf36da32313ba7325675();
	}

	public void c1f6ea15a14c7949841d1094e9ecceb69(AudioBus cfd5a27176a32d67f3d4a39549a377bf8)
	{
		m_bus.cd232ee5f717924fbbb159f559bf8ed59(cfd5a27176a32d67f3d4a39549a377bf8);
		c40940025d8dc42a9183c59cec8f3c618();
	}

	public AudioEventResponsers c250783c219e5191f706df9ed222f6b38()
	{
		return m_parentSound;
	}

	public void c3cbb887eeba52f2125aa47b794ceeb5e(AudioEventResponsers c0b8b4f11377b8a222dc728ff2c622559)
	{
		if (!(m_parentSound != c0b8b4f11377b8a222dc728ff2c622559))
		{
			return;
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
			m_parentSound = c0b8b4f11377b8a222dc728ff2c622559;
			c40940025d8dc42a9183c59cec8f3c618();
			return;
		}
	}

	public virtual void caf18a168df80e6ec094fac2d4a6b3c2c(RandomGenerator c4e92c721e96d4bb1b50291f9c471cee2)
	{
	}

	public string ce3e478508e5e484d064256062bedc4a4()
	{
		string result;
		if (null != m_parentSound)
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
			result = m_parentSound.ce3e478508e5e484d064256062bedc4a4() + "/" + base.name;
		}
		else
		{
			result = base.name;
		}
		return result;
	}

	public override void Awake()
	{
		base.Awake();
		if (!cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
		{
			return;
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
			m_mixer.ccc9d3a38966dc10fedb531ea17d24611();
			cc0bd83b8979d14808e2fb0312dadb1d2();
			cbd96582ad20c4b8278477bab7289264c();
			cfac1fd2f36703e732caa84d2b65010c6();
			if ((bool)m_parentSound)
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
				if (m_inheritFromParent)
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
					m_RTPCs = m_parentSound.m_RTPCs;
				}
			}
			m_defaultPitch = m_audio.pitch;
			return;
		}
	}

	public virtual void Update()
	{
		float num = m_mixer.c609ccaaff98c19a49a8607c90d848bc9();
		if ((bool)m_audio)
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
			if ((double)Mathf.Abs(m_lastVol - num) > 0.01)
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
				float num2 = num;
				m_audio.volume = num2;
				m_lastVol = num2;
			}
		}
		if (!cb9efc4af2006b47000b468b9df139a30())
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			ce002532b35316bc780482776b8176935();
			return;
		}
	}

	private void cbd96582ad20c4b8278477bab7289264c()
	{
		if ((bool)m_clip)
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
			if ((bool)m_audioTemplate)
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
				m_audio = (AudioSource)Object.Instantiate(m_audioTemplate);
				m_audio.transform.parent = base.transform;
				m_audio.transform.localPosition = Vector3.zero;
				m_audio.transform.localRotation = Quaternion.identity;
				m_audio.clip = m_clip;
				goto IL_00c6;
			}
		}
		m_audio = base.audio;
		goto IL_00c6;
		IL_00c6:
		m_audio.Stop();
		m_audio.timeSamples = 0;
	}

	public void cc0bd83b8979d14808e2fb0312dadb1d2()
	{
		Transform parent = base.transform.parent;
		if (null != parent)
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
			m_parentSound = parent.gameObject.GetComponent<AudioEventResponsers>();
		}
		c33bee38029e0138174adfee15792a8b9();
		c40940025d8dc42a9183c59cec8f3c618();
	}

	private void c40940025d8dc42a9183c59cec8f3c618()
	{
		AudioBus audioBus = m_bus.c588e7dbcd383d8230b2d83d7b44af23b();
		if (audioBus != null)
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
					m_mixer.c3cbb887eeba52f2125aa47b794ceeb5e(audioBus.c29d0bac2e9f266c244ba1ee8613309ba());
					return;
				}
			}
		}
		if (null != m_parentSound)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					m_mixer.c3cbb887eeba52f2125aa47b794ceeb5e(m_parentSound.c29d0bac2e9f266c244ba1ee8613309ba());
					return;
				}
			}
		}
		DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "EventResponser: " + ce3e478508e5e484d064256062bedc4a4() + " has no bus assigned. auto-assigning it to master bus");
		m_mixer.c3cbb887eeba52f2125aa47b794ceeb5e(cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.cc6e3847a57e10af584d6f85377557e52.cf545464dc99cdf36da32313ba7325675().c29d0bac2e9f266c244ba1ee8613309ba());
	}

	private void c33bee38029e0138174adfee15792a8b9()
	{
		if (!(null != m_parentSound))
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
			if (!(null != m_parentSound.m_audioTemplate))
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
				if (!(null == m_audioTemplate))
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
					m_audioTemplate = m_parentSound.m_audioTemplate;
					return;
				}
			}
		}
	}

	private void cfac1fd2f36703e732caa84d2b65010c6()
	{
		m_audio.volume = (m_defaultVolume = m_mixer.c609ccaaff98c19a49a8607c90d848bc9());
	}

	public override bool cc56123259c44174bf6c32d225c07c313()
	{
		AudioFadeType audioFadeType = m_mixer.c350ea3caf2fea949768363379f212ce4();
		if (audioFadeType == AudioFadeType.None)
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
					return true;
				}
			}
		}
		bool flag = m_mixer.cc56123259c44174bf6c32d225c07c313();
		m_audio.volume = m_mixer.c609ccaaff98c19a49a8607c90d848bc9();
		if (flag)
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
			if (audioFadeType == AudioFadeType.FadeOut)
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
				cdada4c3678c9c23c38aaf0754a94a620();
			}
		}
		return flag;
	}

	public override void c364ecb1e3f2cafa6e8793178cfbd2327(float c2796c66c13e4346cf101d7928a271951, float cb17344c6ba6038b9297f344b2472c2f5 = 0f, bool c41a65acdc6feabec040241b1170d6b34 = true)
	{
		m_mixer.c364ecb1e3f2cafa6e8793178cfbd2327(c2796c66c13e4346cf101d7928a271951, cb17344c6ba6038b9297f344b2472c2f5, c41a65acdc6feabec040241b1170d6b34);
	}

	public override void cadd9bee93ecf3ad1c30c38c48b9a22ef(float c2796c66c13e4346cf101d7928a271951)
	{
		m_mixer.cadd9bee93ecf3ad1c30c38c48b9a22ef(c2796c66c13e4346cf101d7928a271951);
	}

	public override void c0a75d7afd2f7f1e47a5aadaab61303c7()
	{
		if (!c816b189fc276c71ec9e8bd0b46e3a042())
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
			if (!base.gameObject.activeInHierarchy)
			{
				return;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				if (!m_audio.enabled)
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
					m_audio.Play();
					return;
				}
			}
		}
	}

	public override void c0a75d7afd2f7f1e47a5aadaab61303c7(float cb17344c6ba6038b9297f344b2472c2f5)
	{
		if (!c816b189fc276c71ec9e8bd0b46e3a042())
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
			m_audio.PlayDelayed(cb17344c6ba6038b9297f344b2472c2f5);
			return;
		}
	}

	private bool c816b189fc276c71ec9e8bd0b46e3a042()
	{
		cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.c0927e04752baf8bb95ea1d3bffe4ae50(this);
		bool flag = m_mixer.c9195b8abe338cb95c3049fa8932947a9();
		if (flag)
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
			c29d0bac2e9f266c244ba1ee8613309ba().caf3e02be9e4a934ca58b0bb0fd29af4d();
			if (m_audio.timeSamples != 0)
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
				m_audio.timeSamples = 0;
			}
			if (m_enableRandomPitch)
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
				m_audio.pitch = Random.Range(m_defaultPitch - m_randomPitchRange, m_defaultPitch + m_randomPitchRange);
			}
			cfac1fd2f36703e732caa84d2b65010c6();
			ce002532b35316bc780482776b8176935();
		}
		return flag;
	}

	public override bool cb9efc4af2006b47000b468b9df139a30()
	{
		int result;
		if (null != m_audio)
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
			result = (m_audio.isPlaying ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public override void c4207787d36579661719681a2d411dede()
	{
		m_audio.Pause();
	}

	public override void ccd732382db3f35031907fee9ca4c7dfc(bool c0c5a5a34f77f86de88b9a3c43d8f76fc = false)
	{
		if (!c0c5a5a34f77f86de88b9a3c43d8f76fc)
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
			m_mixer.c0bd8cf08184012e45f262f69c8c2860e();
			m_audio.volume = m_defaultVolume;
		}
		if (m_audio.isPlaying)
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
			m_audio.Play();
			return;
		}
	}

	public override void cdada4c3678c9c23c38aaf0754a94a620()
	{
		cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.c8aa8d201cd10228ac9fea715b3b44f3d(this);
		m_audio.Stop();
	}

	public void OnStopped()
	{
		m_audio.timeSamples = 0;
	}

	private void ce002532b35316bc780482776b8176935()
	{
		AudioParameterValues audioParameterValues = cab010853285c6825c61de59deedff427();
		if (m_RTPCs == null)
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
			if (!(audioParameterValues != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_rtpcValues.Clear();
				for (int i = 0; i < m_RTPCs.Length; i++)
				{
					AudioRTPCDefinition audioRTPCDefinition = m_RTPCs[i].objRef.c588e7dbcd383d8230b2d83d7b44af23b();
					float c8f6f53ee3b51a3ea94ddedc3968eef;
					audioParameterValues.c4e0f63f4b4d409c5e3992c71520e30a0(audioRTPCDefinition, out c8f6f53ee3b51a3ea94ddedc3968eef);
					float num = m_RTPCs[i].curveObj.curve.Evaluate(audioRTPCDefinition.cd2b4a7bb19779290a5d990bfbfe2f27f(c8f6f53ee3b51a3ea94ddedc3968eef));
					if (m_rtpcValues.ContainsKey(m_RTPCs[i].type))
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
						Dictionary<RTPCTargetType, float> rtpcValues;
						Dictionary<RTPCTargetType, float> dictionary = (rtpcValues = m_rtpcValues);
						RTPCTargetType type;
						RTPCTargetType key = (type = m_RTPCs[i].type);
						float num2 = rtpcValues[type];
						dictionary[key] = num2 + num;
					}
					else
					{
						m_rtpcValues.Add(m_RTPCs[i].type, num);
					}
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					c82a12b9b41ed74a5335c56c719435999();
					return;
				}
			}
		}
	}

	private void c82a12b9b41ed74a5335c56c719435999()
	{
		using (Dictionary<RTPCTargetType, float>.Enumerator enumerator = m_rtpcValues.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<RTPCTargetType, float> current = enumerator.Current;
				RTPCTargetType key = current.Key;
				if (key != 0)
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
					if (key != RTPCTargetType.Pitch)
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
					}
					else
					{
						m_audio.pitch = current.Value;
					}
				}
				else
				{
					m_mixer.m_scale = current.Value;
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
}
