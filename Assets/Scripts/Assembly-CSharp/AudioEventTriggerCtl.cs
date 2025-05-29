using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Audio/Audio Event Trigger Control %#t")]
public class AudioEventTriggerCtl : BaseEventTriggerCtl
{
	private string m_dataFileName;

	protected AudioEventTriggerData m_data = new AudioEventTriggerData();

	private AudioEventTriggerData ca78d6db1fc4b71d852c2f3e273ccb14e
	{
		get
		{
			return m_data;
		}
	}

	public string c1b477339668880c9a48a2266e4ecd7f8
	{
		get
		{
			if (string.IsNullOrEmpty(m_dataFileName))
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
				c995c3c6f1e6991c4b6dc48946b65ddff();
			}
			return m_dataFileName;
		}
	}

	public override EventTriggerData c6ce4fecb4b540d34b74bd1f7ebd58577()
	{
		return m_data;
	}

	public void c995c3c6f1e6991c4b6dc48946b65ddff()
	{
		if (base.gameObject.name.Contains("("))
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
					m_dataFileName = base.gameObject.name.Substring(0, base.gameObject.name.IndexOf("("));
					return;
				}
			}
		}
		m_dataFileName = base.gameObject.name;
	}

	protected virtual void Awake()
	{
		c995c3c6f1e6991c4b6dc48946b65ddff();
		bool flag = ca78d6db1fc4b71d852c2f3e273ccb14e.c38aeacc59bd560b59403945ae7996d79(c1b477339668880c9a48a2266e4ecd7f8, ca9af8c6e7c100b86e05b162d3a4ef0ca.c7088de59e49f7108f520cf7e0bae167e);
		cf3374f10f4f07d583f11c8f2a3429776(EventTriggerType.Awake);
	}

	private void Start()
	{
		cf3374f10f4f07d583f11c8f2a3429776(EventTriggerType.Start);
		List<EventRandomTrigger>.Enumerator enumerator = ca78d6db1fc4b71d852c2f3e273ccb14e.cc66b9d16556a63e2369ebb16c1657ca0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.Start();
		}
		while (true)
		{
			switch (1)
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

	private void OnEnable()
	{
		cf3374f10f4f07d583f11c8f2a3429776(EventTriggerType.OnEnable);
	}

	private void OnCollisionEnter()
	{
		cf3374f10f4f07d583f11c8f2a3429776(EventTriggerType.OnCollisionEnter);
	}

	private void OnTriggerEnter()
	{
		cf3374f10f4f07d583f11c8f2a3429776(EventTriggerType.OnTriggerEnter);
	}

	private void Update()
	{
		if (!cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
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
			if (!cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c9d5aded6668d31de4d83fc0acc0b5378)
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
			for (int i = 0; i < ca78d6db1fc4b71d852c2f3e273ccb14e.cc66b9d16556a63e2369ebb16c1657ca0.Count; i++)
			{
				EventRandomTrigger eventRandomTrigger = ca78d6db1fc4b71d852c2f3e273ccb14e.cc66b9d16556a63e2369ebb16c1657ca0[i];
				if (!eventRandomTrigger.c1311fffa224c7d908ff7e3b9a50dfda6())
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
				TriggerEventByName(eventRandomTrigger.m_eventName);
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

	public override void TriggerEventByName(string eventName)
	{
		if (!cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
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
		if (m_data.cce042d6921b01754b4b5d8013356a44d.ContainsKey(eventName))
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					m_data.cce042d6921b01754b4b5d8013356a44d[eventName].c15c3855d4db79068c16ffafb4dfac411(base.gameObject);
					return;
				}
			}
		}
		DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "*****Event: " + eventName + " is missing on " + Utils.c6623cde42db4307c0b144942a5a8c70d(base.gameObject));
	}

	public override void ReleaseEventByName(string eventName)
	{
		if (!cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
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
					return;
				}
			}
		}
		if (m_data.cce042d6921b01754b4b5d8013356a44d.ContainsKey(eventName))
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					m_data.cce042d6921b01754b4b5d8013356a44d[eventName].c035f04b07ce73a4869280b94ecc42137(base.gameObject);
					return;
				}
			}
		}
		DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "*****Event: " + eventName + " is missing on " + base.gameObject.name);
	}

	public override void TriggerEventOnChildren(string eventName)
	{
		if (!m_data.cce042d6921b01754b4b5d8013356a44d.ContainsKey(eventName))
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
			m_data.cce042d6921b01754b4b5d8013356a44d[eventName].c15c3855d4db79068c16ffafb4dfac411(base.gameObject);
			return;
		}
	}

	private void cf3374f10f4f07d583f11c8f2a3429776(EventTriggerType c2b4f43f34e21572af6ab4414f04cee36)
	{
		Dictionary<string, BaseEventHandler>.Enumerator enumerator = ca78d6db1fc4b71d852c2f3e273ccb14e.cce042d6921b01754b4b5d8013356a44d.GetEnumerator();
		while (enumerator.MoveNext())
		{
			BaseEventHandler value = enumerator.Current.Value;
			value.c286b780af808436bb0a07b990296ede3(base.gameObject, c2b4f43f34e21572af6ab4414f04cee36);
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
}
