using A;
using Core;
using UnityEngine;

[AddComponentMenu("Event/Auto Trigger")]
public class AutoEventTrigger : MonoBehaviour
{
	public EventAutoTriggerType m_type;

	public string m_onEnterEvent;

	public string m_onExitEvent;

	private BaseEventTriggerCtl m_eventTriggerCtl;

	private void Awake()
	{
		m_eventTriggerCtl = base.transform.parent.GetComponent<BaseEventTriggerCtl>();
		if (!(m_eventTriggerCtl == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Framework, "*****EventTriggerCtl Missing! on " + base.gameObject.name);
			return;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (m_eventTriggerCtl == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Framework, "*****EventTriggerCtl Missing! on " + base.gameObject.name);
					return;
				}
			}
		}
		if (!c4d98d77e27d446dac7c29423924f9aa0(other.gameObject))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (m_type != 0)
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
			if (m_type != EventAutoTriggerType.OnEnterAndOnExit)
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
		m_eventTriggerCtl.TriggerEventByName(m_onEnterEvent);
	}

	private void OnTriggerExit(Collider other)
	{
		if (m_eventTriggerCtl == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Framework, "*****EventTriggerCtl Missing! on " + base.gameObject.name);
					return;
				}
			}
		}
		if (!c4d98d77e27d446dac7c29423924f9aa0(other.gameObject))
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
		if (m_type != EventAutoTriggerType.OnExit)
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
			if (m_type != EventAutoTriggerType.OnEnterAndOnExit)
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
				break;
			}
		}
		m_eventTriggerCtl.TriggerEventByName(m_onExitEvent);
	}

	private bool c4d98d77e27d446dac7c29423924f9aa0(GameObject c93dbec96f39444e378558f06afbdd30f)
	{
		return c93dbec96f39444e378558f06afbdd30f.GetComponent<EntityPlayer>().caac907d451029d68503484a63934c93f();
	}
}
