using System;
using A;
using UnityEngine;

[Serializable]
public class EffectTriggerItem
{
	public EffectConditionSourceType[] m_conditionSource;

	public EffectConditionActionType[] m_conditionAction;

	public string[] m_conditionDestination;

	public EffectBase m_effect;

	public string m_effectNameToPlay = string.Empty;

	private EffectTriggerData m_triggerData = new EffectTriggerData();

	public void c02ddda22c40e6537539ea11ecdcc6dba(EffectTrigger c93dbec96f39444e378558f06afbdd30f)
	{
		if (!c69dd021b3b5fd782ef73c20e3f570876(c93dbec96f39444e378558f06afbdd30f))
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
			m_triggerData.m_trigger = c93dbec96f39444e378558f06afbdd30f;
			m_triggerData.m_effectName = m_effectNameToPlay;
			GameObject gameObject = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
			if (m_effect != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				gameObject = m_effect.gameObject;
			}
			else
			{
				Transform parent = m_triggerData.m_trigger.transform.parent;
				if (parent != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					gameObject = parent.gameObject;
				}
			}
			if (!(gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				gameObject.BroadcastMessage("PlayEffect", m_triggerData, SendMessageOptions.DontRequireReceiver);
				return;
			}
		}
	}

	private bool c69dd021b3b5fd782ef73c20e3f570876(EffectTrigger c93dbec96f39444e378558f06afbdd30f)
	{
		bool flag = true;
		bool flag2 = true;
		if (m_conditionSource != null)
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
			int num = 0;
			while (true)
			{
				if (num < m_conditionSource.Length)
				{
					GameObject gameObject = c93dbec96f39444e378558f06afbdd30f.m_gameObject;
					if (c93dbec96f39444e378558f06afbdd30f.m_location == EffectLocationType.Raycast)
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
						gameObject = c93dbec96f39444e378558f06afbdd30f.m_raycastHit.collider.gameObject;
					}
					else if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						gameObject = c93dbec96f39444e378558f06afbdd30f.gameObject;
					}
					string text = string.Empty;
					if (m_conditionSource[num] == EffectConditionSourceType.MaterialName)
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
						if (gameObject.renderer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							if (gameObject.renderer.sharedMaterial != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								text = gameObject.renderer.sharedMaterial.name;
							}
						}
					}
					else if (m_conditionSource[num] == EffectConditionSourceType.TagName)
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
						text = gameObject.tag;
					}
					else if (m_conditionSource[num] == EffectConditionSourceType.GameObjectName)
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
						text = gameObject.name;
					}
					if (m_conditionAction[num] == EffectConditionActionType.Contains)
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
						flag2 = text.Contains(m_conditionDestination[num]);
					}
					else if (m_conditionAction[num] == EffectConditionActionType.NotContain)
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
						flag2 = !text.Contains(m_conditionDestination[num]);
					}
					else if (m_conditionAction[num] == EffectConditionActionType.Equals)
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
						flag2 = text == m_conditionDestination[num];
					}
					else if (m_conditionAction[num] == EffectConditionActionType.NotEqual)
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
						flag2 = text != m_conditionDestination[num];
					}
					int num2;
					if (flag)
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
						num2 = (flag2 ? 1 : 0);
					}
					else
					{
						num2 = 0;
					}
					flag = (byte)num2 != 0;
					if (!flag)
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
						break;
					}
					num++;
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
				break;
			}
		}
		return flag;
	}
}
