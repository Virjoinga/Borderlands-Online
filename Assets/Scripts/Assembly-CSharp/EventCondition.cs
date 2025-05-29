using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EventCondition
{
	public List<EventConditionEntry> conditions = new List<EventConditionEntry>();

	public bool c515f796a94abd08a45b1f67775e1da8d(Animator c147ee89dce997e916872a9ab40954015)
	{
		if (conditions.Count == 0)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return true;
				}
			}
		}
		using (List<EventConditionEntry>.Enumerator enumerator = conditions.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				EventConditionEntry current = enumerator.Current;
				if (string.IsNullOrEmpty(current.conditionParam))
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
					continue;
				}
				switch (current.conditionParamType)
				{
				case EventConditionParamTypes.Int:
				{
					int integer = c147ee89dce997e916872a9ab40954015.GetInteger(current.conditionParam);
					switch (current.conditionMode)
					{
					case EventConditionModes.Equal:
						if (integer == current.intValue)
						{
							break;
						}
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							return false;
						}
					case EventConditionModes.NotEqual:
						if (integer != current.intValue)
						{
							break;
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							return false;
						}
					case EventConditionModes.GreaterThan:
						if (integer > current.intValue)
						{
							break;
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								continue;
							}
							return false;
						}
					case EventConditionModes.LessThan:
						if (integer < current.intValue)
						{
							break;
						}
						while (true)
						{
							switch (5)
							{
							case 0:
								continue;
							}
							return false;
						}
					case EventConditionModes.GreaterEqualThan:
						if (integer >= current.intValue)
						{
							break;
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								continue;
							}
							return false;
						}
					case EventConditionModes.LessEqualThan:
						if (integer <= current.intValue)
						{
							break;
						}
						while (true)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							return false;
						}
					}
					break;
				}
				case EventConditionParamTypes.Float:
				{
					float @float = c147ee89dce997e916872a9ab40954015.GetFloat(current.conditionParam);
					EventConditionModes conditionMode = current.conditionMode;
					if (conditionMode != EventConditionModes.GreaterThan)
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
						if (conditionMode != EventConditionModes.LessThan)
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
						}
						else
						{
							if (!(@float >= current.floatValue))
							{
								break;
							}
							while (true)
							{
								switch (7)
								{
								case 0:
									continue;
								}
								return false;
							}
						}
					}
					else
					{
						if (!(@float <= current.floatValue))
						{
							break;
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							return false;
						}
					}
					break;
				}
				case EventConditionParamTypes.Boolean:
				{
					bool @bool = c147ee89dce997e916872a9ab40954015.GetBool(current.conditionParam);
					if (@bool == current.boolValue)
					{
						break;
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						return false;
					}
				}
				}
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_021c;
				}
				continue;
				end_IL_021c:
				break;
			}
		}
		return true;
	}
}
