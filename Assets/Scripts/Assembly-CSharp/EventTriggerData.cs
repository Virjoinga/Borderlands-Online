using System.Collections.Generic;
using A;
using Core;

public class EventTriggerData
{
	protected string m_fileName;

	public string[] m_moduleFileNames;

	protected string m_triggerKind;

	protected Dictionary<string, BaseEventHandler> m_eventHandlers = new Dictionary<string, BaseEventHandler>();

	protected List<EventRandomTrigger> m_randomTriggers = new List<EventRandomTrigger>();

	public Dictionary<string, BaseEventHandler> cce042d6921b01754b4b5d8013356a44d
	{
		get
		{
			return m_eventHandlers;
		}
	}

	public List<EventRandomTrigger> cc66b9d16556a63e2369ebb16c1657ca0
	{
		get
		{
			return m_randomTriggers;
		}
	}

	public void cc34cf6dc3d05cb2aa7a0a66991dcc81d(string c809a131cac2d3f365a66d27522cf5ec7, BaseEventHandler c93dbec96f39444e378558f06afbdd30f, bool c90ff1b84053ee8fa3d837b0be5fbd377)
	{
		if (cce042d6921b01754b4b5d8013356a44d.ContainsKey(c809a131cac2d3f365a66d27522cf5ec7))
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
					if (!c90ff1b84053ee8fa3d837b0be5fbd377)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "AddEventTriggerByEvent: overwrote existing event: " + c809a131cac2d3f365a66d27522cf5ec7);
								return;
							}
						}
					}
					cce042d6921b01754b4b5d8013356a44d[c809a131cac2d3f365a66d27522cf5ec7] = c93dbec96f39444e378558f06afbdd30f;
					return;
				}
			}
		}
		cce042d6921b01754b4b5d8013356a44d.Add(c809a131cac2d3f365a66d27522cf5ec7, c93dbec96f39444e378558f06afbdd30f);
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		m_eventHandlers.Clear();
		m_randomTriggers.Clear();
		m_moduleFileNames = c7e77aa637b9ae1290617ecc771e6c274.c7088de59e49f7108f520cf7e0bae167e;
	}

	public bool c1ec2cc085280a41891379cc1a1f0af4c()
	{
		int result;
		if (m_moduleFileNames != null)
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
			result = ((m_moduleFileNames.Length > 0) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}
}
