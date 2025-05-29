using UnityEngine;

public abstract class EffectBase : MonoBehaviour
{
	public string m_myName = "effect";

	[HideInInspector]
	public EffectPool m_pool;

	public void PlayEffect(EffectTriggerData data)
	{
		if (!base.enabled)
		{
			while (true)
			{
				switch (2)
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
		if (!(data.m_effectName == m_myName))
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
			PlayEffect(data.m_trigger);
			return;
		}
	}

	public abstract void PlayEffect(EffectTrigger trigger);
}
