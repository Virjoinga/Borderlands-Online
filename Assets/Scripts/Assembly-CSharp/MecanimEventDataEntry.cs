using System;
using A;
using UnityEngine;

[Serializable]
public class MecanimEventDataEntry
{
	public UnityEngine.Object animatorController;

	public string animatorControllerName;

	public int layer;

	public int stateNameHash;

	public MecanimEvent[] events;

	public MecanimEventDataEntry()
	{
		events = c6e5ce74a91ab17378381741dc6751d19.c0a0cdf4a196914163f7334d9b0781a04(0);
	}

	public MecanimEventDataEntry(MecanimEventDataEntry c6ab743f31b30bfca58e451188f2c9421)
	{
		animatorController = c6ab743f31b30bfca58e451188f2c9421.animatorController;
		layer = c6ab743f31b30bfca58e451188f2c9421.layer;
		stateNameHash = c6ab743f31b30bfca58e451188f2c9421.stateNameHash;
		if (c6ab743f31b30bfca58e451188f2c9421.events == null)
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
					events = c6e5ce74a91ab17378381741dc6751d19.c0a0cdf4a196914163f7334d9b0781a04(0);
					return;
				}
			}
		}
		events = c6e5ce74a91ab17378381741dc6751d19.c0a0cdf4a196914163f7334d9b0781a04(c6ab743f31b30bfca58e451188f2c9421.events.Length);
		for (int i = 0; i < events.Length; i++)
		{
			events[i] = new MecanimEvent(c6ab743f31b30bfca58e451188f2c9421.events[i]);
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
