using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
	public delegate void TimeLineCallBack();

	private ParticleSystem m_targetParticle;

	private List<ParticleSystem> m_activeParticles = new List<ParticleSystem>();

	private List<ParticleSystem> m_particles = new List<ParticleSystem>();

	private string rule = string.Empty;

	private float m_startTime;

	private float m_triggerTime = 3f;

	private bool m_isAnimted;

	private TimeLineCallBack triggerCallBack;

	private TimeLineCallBack finishCallBack;

	public float cd4e7c1b68eb7ce6b3b5b73c4784f6a7b
	{
		get
		{
			return m_triggerTime;
		}
		set
		{
			m_triggerTime = value;
		}
	}

	public bool c60e71916893de2f43e9cca97bd0edb64
	{
		get
		{
			return m_isAnimted;
		}
	}

	public event TimeLineCallBack cfcebba48dc2e80dc073a4b69fb28025c
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			triggerCallBack = (TimeLineCallBack)Delegate.Combine(triggerCallBack, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			triggerCallBack = (TimeLineCallBack)Delegate.Remove(triggerCallBack, value);
		}
	}

	public event TimeLineCallBack c6c0ce637fe6b1e45f54d3bcdb7c3219c
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			finishCallBack = (TimeLineCallBack)Delegate.Combine(finishCallBack, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			finishCallBack = (TimeLineCallBack)Delegate.Remove(finishCallBack, value);
		}
	}

	private void ca04dc429da92778dbab77880ee0e0dc3(string cb4dc8a66214c09e6dc87bb9c8bb0f26c, string cd2cc325416f4de878de9c2335a69b248)
	{
		GameObject gameObject = GameObject.Find(cb4dc8a66214c09e6dc87bb9c8bb0f26c);
		if (!(gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			ParticleSystem[] componentsInChildren = gameObject.GetComponentsInChildren<ParticleSystem>();
			m_particles.AddRange(componentsInChildren);
			rule = cd2cc325416f4de878de9c2335a69b248;
			return;
		}
	}

	public void c0bc4c65d4c28a31ec7a86abfb1230a81()
	{
		m_activeParticles.Clear();
		m_activeParticles = c18dc4ac83b21d8c7e42bd7ff3f01cbef.c7088de59e49f7108f520cf7e0bae167e;
		m_particles.Clear();
		m_particles = c18dc4ac83b21d8c7e42bd7ff3f01cbef.c7088de59e49f7108f520cf7e0bae167e;
		triggerCallBack = null;
		finishCallBack = null;
	}

	public void c4ecc5a6775d113af396f25277e85adec()
	{
		if (m_targetParticle != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_targetParticle.Stop();
			m_targetParticle.time = 0f;
			m_targetParticle.gameObject.SetActive(false);
		}
		for (int i = 0; i < m_particles.Count; i++)
		{
			if (!(m_particles[i] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				break;
			}
			if (!m_particles[i].name.Contains(rule))
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
			m_particles[i].Stop();
			m_particles[i].gameObject.SetActive(false);
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			m_isAnimted = false;
			return;
		}
	}

	public void c3a0100e580804bee1cfac6fe64194ce6(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (c5612a459a84ffdb41c885401433cd62d < 0)
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
			if (c5612a459a84ffdb41c885401433cd62d >= m_activeParticles.Count)
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
				m_activeParticles[c5612a459a84ffdb41c885401433cd62d].gameObject.SetActive(false);
				return;
			}
		}
	}

	public void ce4c6859b04b271fe37b2049334c686b7(string c2b4f43f34e21572af6ab4414f04cee36, bool c5f84e765422baebc81449154ea8d30fe = false, bool ced0c442e7caee66f81925eab644ba898 = false, TimeLineCallBack c2db84530ef366a6deb001d449d4aa151 = null)
	{
		if (ced0c442e7caee66f81925eab644ba898)
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
			c4ecc5a6775d113af396f25277e85adec();
			m_activeParticles.Clear();
		}
		if (c2b4f43f34e21572af6ab4414f04cee36 != string.Empty)
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
			m_targetParticle = c2c8b48859579d47d4a05d8a2aa7cf509(c2b4f43f34e21572af6ab4414f04cee36);
		}
		else if (c2db84530ef366a6deb001d449d4aa151 != null)
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
			c2db84530ef366a6deb001d449d4aa151();
		}
		if (!(m_targetParticle != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_targetParticle.gameObject.SetActive(true);
			if (c5f84e765422baebc81449154ea8d30fe)
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
				m_targetParticle.loop = false;
				m_targetParticle.Play();
				if (m_triggerTime > 0f)
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
					m_startTime = Time.time;
				}
				m_isAnimted = true;
				finishCallBack = (TimeLineCallBack)Delegate.Combine(finishCallBack, c2db84530ef366a6deb001d449d4aa151);
			}
			else
			{
				m_targetParticle.renderer.enabled = true;
			}
			m_activeParticles.Add(m_targetParticle);
			return;
		}
	}

	private ParticleSystem c2c8b48859579d47d4a05d8a2aa7cf509(string c2b4f43f34e21572af6ab4414f04cee36)
	{
		return m_particles.Find((ParticleSystem c5ebdc65d5cb420faf7ba524809963aa9) => c5ebdc65d5cb420faf7ba524809963aa9.name == c2b4f43f34e21572af6ab4414f04cee36);
	}

	private void Update()
	{
		if (!m_isAnimted)
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
			if (!(m_targetParticle != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!m_targetParticle.isPlaying)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							if (finishCallBack != null)
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
								m_targetParticle.Stop();
								m_targetParticle.gameObject.SetActive(false);
								m_targetParticle = c7ef7670c971ed95fb3145d2539578635.c7088de59e49f7108f520cf7e0bae167e;
								finishCallBack();
							}
							m_isAnimted = false;
							return;
						}
					}
				}
				if (!(m_triggerTime > 0f))
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
					if (!(Time.time - m_startTime >= m_triggerTime))
					{
						return;
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						if (triggerCallBack == null)
						{
							return;
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							triggerCallBack();
							m_triggerTime = 0f;
							return;
						}
					}
				}
			}
		}
	}

	private void Awake()
	{
		ca04dc429da92778dbab77880ee0e0dc3("UI", "PTL");
	}
}
