using System.Collections.Generic;
using Core;
using UnityEngine;

public abstract class BaseEventHandler
{
	public string m_eventName = "new event";

	public EventTriggerType m_type;

	private bool m_definedInThisEntity = true;

	protected bool m_resourceIsReady;

	protected List<BaseEventResponser> m_updateList = new List<BaseEventResponser>();

	public virtual void c15c3855d4db79068c16ffafb4dfac411(GameObject c80822505abd04406a7a821211bd77371)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Event:" + m_eventName + " is triggered in base class on " + c80822505abd04406a7a821211bd77371.name);
	}

	public virtual void c286b780af808436bb0a07b990296ede3(GameObject c80822505abd04406a7a821211bd77371, EventTriggerType c2b4f43f34e21572af6ab4414f04cee36 = EventTriggerType.None)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Event:" + m_eventName + " is triggered in base class on " + c80822505abd04406a7a821211bd77371.name);
	}

	public virtual void c035f04b07ce73a4869280b94ecc42137(GameObject c80822505abd04406a7a821211bd77371)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Event:" + m_eventName + " is released in base class on " + c80822505abd04406a7a821211bd77371.name);
	}

	public virtual bool Update()
	{
		return false;
	}

	public bool c4e63cdf7582b2c7b45768fe92e5993ed()
	{
		return m_definedInThisEntity;
	}

	public void c833355f28871126c97086f4d9e61227e(bool c150264a18c2cb408479d3f072cac8cc1)
	{
		m_definedInThisEntity = c150264a18c2cb408479d3f072cac8cc1;
	}
}
