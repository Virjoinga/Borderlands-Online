using System;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class FrontEndStepManager : MonoBehaviour
{
	public enum StepState
	{
		Login = 0,
		CharacterSelect = 1,
		ClassSelect = 2,
		CharacterCreate = 3,
		Town = 4,
		WorldMap = 5,
		Gaming = 6,
		PVP = 7,
		none = 8
	}

	private Dictionary<StepState, Type> m_dicFrontEndSteps;

	private StepBehaviour m_curStepBehaviour;

	private StepState m_curStep;

	private GameObject m_scene;

	private GameObject m_bg;

	private string _accountName = string.Empty;

	private string _password = string.Empty;

	private bool _isExistingUser;

	private AvatarType _classType = AvatarType.BERSERKER;

	public bool c7c80683fbe2a8ba978d53115286c4c8a
	{
		get
		{
			return _isExistingUser;
		}
		set
		{
			_isExistingUser = value;
		}
	}

	public string c3b8d7ef091ecb61c8a7ddeaa2a74c5c0
	{
		get
		{
			return _accountName;
		}
		set
		{
			_accountName = value;
		}
	}

	public string c86c4af95f93a5ad7dc980e3792620d3c
	{
		get
		{
			return _password;
		}
		set
		{
			_password = value;
		}
	}

	public AvatarType c530262bed2fed8bf0fa08fae31480158
	{
		get
		{
			return _classType;
		}
		set
		{
			_classType = value;
		}
	}

	public StepState c350c64083eadfb4a76f2dba7c66fd0be
	{
		get
		{
			return m_curStep;
		}
	}

	private void Awake()
	{
		m_dicFrontEndSteps = new Dictionary<StepState, Type>
		{
			{
				StepState.Login,
				Type.GetTypeFromHandle(ce85f354e4aa6d9137eb52c06d0a2b7a7.cc1720d05c75832f704b87474932341c3())
			},
			{
				StepState.CharacterSelect,
				Type.GetTypeFromHandle(c1723875dff7a8eee0288e5105b08aeb4.cc1720d05c75832f704b87474932341c3())
			},
			{
				StepState.ClassSelect,
				Type.GetTypeFromHandle(c450495470f1b3bd488ed85dd5ee6088f.cc1720d05c75832f704b87474932341c3())
			},
			{
				StepState.CharacterCreate,
				Type.GetTypeFromHandle(c3f1114c483f7aa0bd5404ff7e05641c6.cc1720d05c75832f704b87474932341c3())
			},
			{
				StepState.WorldMap,
				Type.GetTypeFromHandle(ce3788ee196bf23969602e74635f23503.cc1720d05c75832f704b87474932341c3())
			},
			{
				StepState.Gaming,
				Type.GetTypeFromHandle(c5176b5b6b5ed28eadd3072e703a7f7ee.cc1720d05c75832f704b87474932341c3())
			},
			{
				StepState.Town,
				Type.GetTypeFromHandle(c38542ca7e13e46c83a884cc789a09f85.cc1720d05c75832f704b87474932341c3())
			},
			{
				StepState.PVP,
				Type.GetTypeFromHandle(c71f67af10281aa24d6df8f2b81c69545.cc1720d05c75832f704b87474932341c3())
			}
		};
		m_curStepBehaviour = cd628cd0a579108e69ab10f61be9c63f8.c7088de59e49f7108f520cf7e0bae167e;
		m_curStep = StepState.none;
	}

	public void c5124035d2e3f608c852e4662920ed796()
	{
		if (m_scene == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_scene = GameObject.Find("LA");
		}
		if (m_bg == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_bg = GameObject.Find("BG");
		}
		if (m_scene != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_scene.SetActive(true);
		}
		if (!(m_bg != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_bg.SetActive(false);
			return;
		}
	}

	public void cee3677bab0ba68add73016d37ed87bd2()
	{
		if (m_scene == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_scene = GameObject.Find("LA");
		}
		if (m_bg == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_bg = GameObject.Find("BG");
		}
		if (m_scene != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_scene.SetActive(false);
		}
		if (!(m_bg != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_bg.SetActive(true);
			return;
		}
	}

	public void cb3797f1f72105333c59934e3f0944657()
	{
		if (m_scene == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_scene = GameObject.Find("LA");
		}
		if (m_bg == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_bg = GameObject.Find("BG");
		}
		if (m_scene != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_scene.SetActive(true);
		}
		if (!(m_bg != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_bg.SetActive(false);
			return;
		}
	}

	public void c80de27b415dc1bfb2c73a64cfcafa59f(StepState c63eb768318f60a5039031142213d13b9, object c591d56a94543e3559945c497f37126c4 = null)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
		StepState curStep = m_curStep;
		if (m_curStepBehaviour != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_curStepBehaviour.ca9a7e4f5830bea46045e5de793b42658(c63eb768318f60a5039031142213d13b9);
			UnityEngine.Object.Destroy(m_curStepBehaviour);
			m_curStepBehaviour = cd628cd0a579108e69ab10f61be9c63f8.c7088de59e49f7108f520cf7e0bae167e;
			m_curStep = StepState.none;
		}
		if (c63eb768318f60a5039031142213d13b9 == StepState.none)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					m_curStepBehaviour = cd628cd0a579108e69ab10f61be9c63f8.c7088de59e49f7108f520cf7e0bae167e;
					m_curStep = StepState.none;
					return;
				}
			}
		}
		Type type = m_dicFrontEndSteps[c63eb768318f60a5039031142213d13b9];
		if (type == null)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, string.Concat("FrontEnd Step:", c63eb768318f60a5039031142213d13b9, "'s behaviour does not exist!!!"));
					return;
				}
			}
		}
		StepBehaviour stepBehaviour = base.gameObject.AddComponent(type) as StepBehaviour;
		if (stepBehaviour == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "FrontEnd Step: can not create instance of class: [" + type.ToString() + "]");
					return;
				}
			}
		}
		stepBehaviour.OnShow(curStep, c591d56a94543e3559945c497f37126c4);
		m_curStepBehaviour = stepBehaviour;
		m_curStep = c63eb768318f60a5039031142213d13b9;
	}

	public void OnCurStepLevelLoadingFinish()
	{
		if (m_curStep == StepState.none)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_curStepBehaviour.OnLevelLoadingFinish();
			return;
		}
	}
}
