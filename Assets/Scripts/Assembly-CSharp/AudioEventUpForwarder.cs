using A;
using Core;
using UnityEngine;

[AddComponentMenu("Audio/Audio Event Up Forwarder %#t")]
public class AudioEventUpForwarder : BaseEventTriggerCtl
{
	private const bool FORCE_UPDATE_TARGET = false;

	private AudioEventTriggerCtl m_target;

	private void Start()
	{
		cf2be8f745f6b0db1fa95dbe65003d189(true);
	}

	private void Update()
	{
		cf2be8f745f6b0db1fa95dbe65003d189(false);
	}

	public AudioEventTriggerCtl c81c42059fd6a3367fa9d0249bb2e956f()
	{
		return m_target;
	}

	private void cf2be8f745f6b0db1fa95dbe65003d189(bool c9165cd419ba9a89cbaa6c1cff01757c7)
	{
		if (!c9165cd419ba9a89cbaa6c1cff01757c7)
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
			if (!(null == m_target))
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
				break;
			}
		}
		AudioEventTriggerCtl c7088de59e49f7108f520cf7e0bae167e = ce34853976748310379de3fbe57c13b78.c7088de59e49f7108f520cf7e0bae167e;
		GameObject gameObject = base.gameObject;
		while (null != gameObject.transform.parent)
		{
			gameObject = gameObject.transform.parent.gameObject;
			c7088de59e49f7108f520cf7e0bae167e = gameObject.GetComponent<AudioEventTriggerCtl>();
			if (!(null != c7088de59e49f7108f520cf7e0bae167e))
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
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "AudioEventUpForwarder @: " + Utils.c6623cde42db4307c0b144942a5a8c70d(base.gameObject) + " found target @: " + Utils.c6623cde42db4307c0b144942a5a8c70d(c7088de59e49f7108f520cf7e0bae167e.gameObject));
				m_target = c7088de59e49f7108f520cf7e0bae167e;
				return;
			}
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

	public override EventTriggerData c6ce4fecb4b540d34b74bd1f7ebd58577()
	{
		object result;
		if (null != c81c42059fd6a3367fa9d0249bb2e956f())
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
			result = c81c42059fd6a3367fa9d0249bb2e956f().c6ce4fecb4b540d34b74bd1f7ebd58577();
		}
		else
		{
			result = null;
		}
		return (EventTriggerData)result;
	}

	public override void TriggerEventByName(string eventName)
	{
		if (null == m_target)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "TriggerEventByName: AudioEventUpForwarder @: " + Utils.c6623cde42db4307c0b144942a5a8c70d(base.gameObject) + " has no target to respond to event: " + eventName);
					return;
				}
			}
		}
		m_target.TriggerEventByName(eventName);
	}

	public override void ReleaseEventByName(string eventName)
	{
		if (null == m_target)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "ReleaseEventByName: AudioEventUpForwarder @: " + Utils.c6623cde42db4307c0b144942a5a8c70d(base.gameObject) + " has no target to respond to event: " + eventName);
					return;
				}
			}
		}
		m_target.ReleaseEventByName(eventName);
	}
}
