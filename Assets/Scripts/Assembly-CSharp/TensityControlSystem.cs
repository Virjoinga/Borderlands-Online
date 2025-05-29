using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(AudioEventTriggerCtl))]
public class TensityControlSystem : MonoBehaviour
{
	public TensityState m_currentState;

	public TensityState m_targetState;

	public TensityControlElement[] m_controllers;

	private AudioEventTriggerCtl m_eventCtl;

	private bool m_needUpdate;

	private float m_nextTime;

	private string m_currentMusicEvent = string.Empty;

	private void Awake()
	{
		if (cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
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
			cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.ce693c931d729e0b4883c89920d35043a = this;
		}
		m_eventCtl = GetComponent<AudioEventTriggerCtl>();
		if (m_eventCtl == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "AudioEventTriggerCtl missing, impossible!");
		}
		c61e8a55f99e8b04100e138d2ad26dcad();
	}

	private void c61e8a55f99e8b04100e138d2ad26dcad()
	{
		List<TensityState> list = new List<TensityState>();
		for (int i = 0; i < m_controllers.Length; i++)
		{
			if (list.Contains(m_controllers[i].m_state))
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
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "*****Same state group in tensity controllers!");
			}
			else
			{
				list.Add(m_controllers[i].m_state);
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

	private void OnDestroy()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "Tensity.OnDestroy");
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
			cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.ce693c931d729e0b4883c89920d35043a = c7f6eb1a1afbb80d78120097ee68f84eb.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	private void Update()
	{
		if (!cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
		{
			while (true)
			{
				switch (6)
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
		if (Time.time < m_nextTime)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (!m_needUpdate)
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
			if (m_eventCtl == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			cd31c7e1def638838f6aa738200a48a18();
			return;
		}
	}

	private void cd31c7e1def638838f6aa738200a48a18()
	{
		for (int i = 0; i < m_controllers.Length; i++)
		{
			if (m_controllers[i].m_state != m_currentState)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			TensityControlElement tensityControlElement = m_controllers[i];
			for (int j = 0; j < tensityControlElement.m_eventPackages.Length; j++)
			{
				if (tensityControlElement.m_eventPackages[j].m_targetState != m_targetState)
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
					TensityStateChangeEventPackage tensityStateChangeEventPackage = tensityControlElement.m_eventPackages[j];
					if (m_currentMusicEvent != string.Empty)
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
						m_eventCtl.ReleaseEventByName(m_currentMusicEvent);
					}
					for (int k = 0; k < m_controllers.Length; k++)
					{
						if (m_controllers[k].m_state != m_targetState)
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
						m_currentMusicEvent = m_controllers[k].m_event;
						if (!(m_controllers[k].m_event != string.Empty))
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
						m_eventCtl.TriggerEventByName(m_controllers[k].m_event);
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						m_currentState = m_targetState;
						m_nextTime = Time.time + tensityStateChangeEventPackage.m_lastingTime;
						m_needUpdate = false;
						cf84421bb197aecb61b01c3aacc5fdb11(tensityStateChangeEventPackage.m_autoTurnToState, false);
						return;
					}
				}
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
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public void c9b1d0dbe283462b532b8dfa340a18e2f()
	{
		m_needUpdate = true;
	}

	public void cf84421bb197aecb61b01c3aacc5fdb11(TensityState c4992f8f718608974873b2575dfecfda0, bool ce3fec8a40bbefb5cc146c81386bacfe8 = true)
	{
		if (c4992f8f718608974873b2575dfecfda0 == m_currentState)
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
		if (ce3fec8a40bbefb5cc146c81386bacfe8)
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
			m_nextTime = 0f;
		}
		m_targetState = c4992f8f718608974873b2575dfecfda0;
		c9b1d0dbe283462b532b8dfa340a18e2f();
	}
}
