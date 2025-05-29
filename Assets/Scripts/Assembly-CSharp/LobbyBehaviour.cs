using A;
using UnityEngine;

public class LobbyBehaviour : MonoBehaviour
{
	public string m_LightID;

	private bool m_bShowLight;

	private bool m_bParticleEnable;

	private bool m_bMouseOver;

	private bool m_bLock;

	private string m_LevelID;

	private ParticleSystem m_UnlockParticle;

	public Delegate_EnterLevelProc _EnterLevelProc;

	public void Start()
	{
		m_bShowLight = false;
		m_bParticleEnable = false;
		m_bMouseOver = false;
		m_bLock = false;
		m_LevelID = base.gameObject.name.Substring(base.gameObject.name.Length - 3, 3);
		Transform component = base.gameObject.GetComponent<Transform>();
		int num = 0;
		while (true)
		{
			if (num < component.childCount)
			{
				if (component.GetChild(num).gameObject.name == "PTL_UnlockInstance")
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
					m_UnlockParticle = component.GetChild(num).gameObject.particleSystem;
					break;
				}
				num++;
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
			break;
		}
		base.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (!m_bParticleEnable)
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
			if (!m_UnlockParticle.isPlaying)
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
				cc66df42259640546f045d485a9fef7b3("PTL_UnlockInstance");
			}
			if (!((double)m_UnlockParticle.time > 0.7))
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
				if (m_bShowLight)
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
					if (LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().cb6bb5b1eab94d6a9e847453cd616d1a6(int.Parse(m_LevelID)))
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
						cd3fcd64e9828445090a355571e27f3b3("Quest");
					}
					else
					{
						cd3fcd64e9828445090a355571e27f3b3("Normal");
					}
					m_bShowLight = true;
					return;
				}
			}
		}
	}

	public void c53110ece4e7b27b1427b8ee45884568e()
	{
		if (!base.gameObject.activeSelf)
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
			base.gameObject.SetActive(true);
		}
		m_bLock = LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().cfbf6ce5213eb84d4ac07084f783da2ed(int.Parse(m_LevelID));
		if (!LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().c8d5186b7fb030f2b629c651fef672388())
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
			GameObject gameObject = GameObject.Find("LA");
			if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				Transform transform = gameObject.transform.FindChild("Scenes/PRO_Looby_Logo");
				if (transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					transform.gameObject.SetActive(false);
				}
			}
		}
		if (m_bLock)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					c876f0d3ae67e35cd0c91d43e97127ed0();
					return;
				}
			}
		}
		if (!LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().c8d5186b7fb030f2b629c651fef672388())
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().c6080f1351b3cc5b24904b27bb1bb49ad(int.Parse(m_LevelID)))
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								c7ff3e47f83c0be6db6d1bb11ec5fef30();
								return;
							}
						}
					}
					if (LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().cb6bb5b1eab94d6a9e847453cd616d1a6(int.Parse(m_LevelID)))
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								cd3fcd64e9828445090a355571e27f3b3("Quest");
								return;
							}
						}
					}
					cd3fcd64e9828445090a355571e27f3b3("Normal");
					return;
				}
			}
		}
		if (LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().cb6bb5b1eab94d6a9e847453cd616d1a6(int.Parse(m_LevelID)))
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					cd3fcd64e9828445090a355571e27f3b3("Quest");
					return;
				}
			}
		}
		cd3fcd64e9828445090a355571e27f3b3("Normal");
	}

	public void OnMouseOver()
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c7239543e613e42c603e3f4786aa2ecb7())
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
					return;
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c9d057c2188e7d2872aa3ec71517e92ae)
		{
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
		if (m_bMouseOver)
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
			m_bMouseOver = true;
			if (!cd00386c5dda834ce20cc917596af668f("Normal"))
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
				if (!cd00386c5dda834ce20cc917596af668f("Quest"))
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
					break;
				}
			}
			cd3fcd64e9828445090a355571e27f3b3("MouseOver");
			return;
		}
	}

	public void OnMouseExit()
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c7239543e613e42c603e3f4786aa2ecb7())
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
					return;
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c9d057c2188e7d2872aa3ec71517e92ae)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (!m_bMouseOver)
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
			m_bMouseOver = false;
			if (!cd00386c5dda834ce20cc917596af668f("MouseOver"))
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
				if (LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().cb6bb5b1eab94d6a9e847453cd616d1a6(int.Parse(m_LevelID)))
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							cd3fcd64e9828445090a355571e27f3b3("Quest");
							return;
						}
					}
				}
				cd3fcd64e9828445090a355571e27f3b3("Normal");
				return;
			}
		}
	}

	public void ca1b9dbcdbe8df928e93eeb9f3a881f3d()
	{
		OnMouseExit();
	}

	public void OnMouseUp()
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c7239543e613e42c603e3f4786aa2ecb7())
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
					return;
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c9d057c2188e7d2872aa3ec71517e92ae)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (_EnterLevelProc == null)
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
			if (m_bLock)
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
				_EnterLevelProc(int.Parse(m_LevelID));
				return;
			}
		}
	}

	private void c876f0d3ae67e35cd0c91d43e97127ed0()
	{
		cd3fcd64e9828445090a355571e27f3b3("Lock");
	}

	private void c7ff3e47f83c0be6db6d1bb11ec5fef30()
	{
		cd3fcd64e9828445090a355571e27f3b3("PTL_UnlockInstance");
	}

	private GameObject c66db829b79bedfd2a8452f642f287f2a(string c5fe690777bf5dec9374fa61ab6703175)
	{
		Transform component = base.gameObject.GetComponent<Transform>();
		for (int i = 0; i < component.childCount; i++)
		{
			if (!(component.GetChild(i).gameObject.name == c5fe690777bf5dec9374fa61ab6703175))
			{
				continue;
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
				return component.GetChild(i).gameObject;
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	private bool cd00386c5dda834ce20cc917596af668f(string c5fe690777bf5dec9374fa61ab6703175)
	{
		Transform component = base.gameObject.GetComponent<Transform>();
		for (int i = 0; i < component.childCount; i++)
		{
			if (!(component.GetChild(i).gameObject.name == c5fe690777bf5dec9374fa61ab6703175))
			{
				continue;
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
				return component.GetChild(i).gameObject.activeSelf;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	private void cd3fcd64e9828445090a355571e27f3b3(string c5fe690777bf5dec9374fa61ab6703175)
	{
		if (m_bLock)
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
			if (c5fe690777bf5dec9374fa61ab6703175 != "Lock")
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}
		Transform component = base.gameObject.GetComponent<Transform>();
		for (int i = 0; i < component.childCount; i++)
		{
			if (component.GetChild(i).gameObject.name != c5fe690777bf5dec9374fa61ab6703175)
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
				if (c5fe690777bf5dec9374fa61ab6703175 == "PTL_UnlockInstance")
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
					if (m_bMouseOver)
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
						if (component.GetChild(i).gameObject.name == "MouseOver")
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
							component.GetChild(i).gameObject.SetActive(false);
						}
					}
					if (!m_bMouseOver)
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
						if (component.GetChild(i).gameObject.name == "Normal")
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
							component.GetChild(i).gameObject.SetActive(false);
						}
					}
					if (m_bMouseOver)
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
					if (!(component.GetChild(i).gameObject.name == "Quest"))
					{
						continue;
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					component.GetChild(i).gameObject.SetActive(false);
					continue;
				}
				if (component.GetChild(i).gameObject.name == "PTL_UnlockInstance")
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
					if (m_bParticleEnable)
					{
						continue;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				component.GetChild(i).gameObject.SetActive(false);
				continue;
			}
			component.GetChild(i).gameObject.SetActive(true);
			if (!(c5fe690777bf5dec9374fa61ab6703175 == "PTL_UnlockInstance"))
			{
				continue;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			m_bParticleEnable = true;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	private void cc66df42259640546f045d485a9fef7b3(string c5fe690777bf5dec9374fa61ab6703175)
	{
		Transform component = base.gameObject.GetComponent<Transform>();
		for (int i = 0; i < component.childCount; i++)
		{
			if (!(component.GetChild(i).gameObject.name == c5fe690777bf5dec9374fa61ab6703175))
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
			component.GetChild(i).gameObject.SetActive(false);
			if (!(c5fe690777bf5dec9374fa61ab6703175 == "PTL_UnlockInstance"))
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
			m_bParticleEnable = false;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (m_bMouseOver)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						cd3fcd64e9828445090a355571e27f3b3("MouseOver");
						return;
					}
				}
			}
			if (LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().cb6bb5b1eab94d6a9e847453cd616d1a6(int.Parse(m_LevelID)))
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						if (!cd00386c5dda834ce20cc917596af668f("Quest"))
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									cd3fcd64e9828445090a355571e27f3b3("Quest");
									return;
								}
							}
						}
						return;
					}
				}
			}
			if (cd00386c5dda834ce20cc917596af668f("Normal"))
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
				cd3fcd64e9828445090a355571e27f3b3("Normal");
				return;
			}
		}
	}
}
