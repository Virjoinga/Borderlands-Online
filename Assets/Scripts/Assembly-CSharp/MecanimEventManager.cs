using System.Collections.Generic;
using A;
using UnityEngine;

public static class MecanimEventManager
{
	private static MecanimEventData[] eventDataSources;

	private static Dictionary<int, Dictionary<int, Dictionary<int, List<MecanimEvent>>>> globalLoadedData;

	private static Dictionary<int, Dictionary<int, AnimatorStateInfo>> globalLastStates = new Dictionary<int, Dictionary<int, AnimatorStateInfo>>();

	private static Dictionary<string, int> animatorControllerIdData;

	public static Dictionary<string, int> c18ae3439905a0b018b68783f166607d2
	{
		get
		{
			return animatorControllerIdData;
		}
	}

	public static void cc4e23f6e10a2b78b8eadcac95739d7cc(MecanimEventData cb8017885c7fbd43d03259769fb304fd8)
	{
		if (!(cb8017885c7fbd43d03259769fb304fd8 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			eventDataSources = c4c6a9bb7e6974537e1049c7fd50eaa6f.c0a0cdf4a196914163f7334d9b0781a04(1);
			eventDataSources[0] = cb8017885c7fbd43d03259769fb304fd8;
			cc09f35c9cf4e65548d30f62bfebf96e9();
			return;
		}
	}

	public static void cc4e23f6e10a2b78b8eadcac95739d7cc(MecanimEventData[] c395f8348a717dedb667e2d4bb3840c17)
	{
		if (c395f8348a717dedb667e2d4bb3840c17 == null)
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
			eventDataSources = c395f8348a717dedb667e2d4bb3840c17;
			cc09f35c9cf4e65548d30f62bfebf96e9();
			return;
		}
	}

	public static void OnLevelLoaded()
	{
		globalLastStates.Clear();
	}

	public static void c61d1999d0d09515f6fefe4c234a27452(ref List<MecanimEvent> c2a329a9122374e1550f19d87d35636e0, int c3384434055cdd84d5c34e36422c0f1a7, Animator c147ee89dce997e916872a9ab40954015)
	{
		c61d1999d0d09515f6fefe4c234a27452(ref c2a329a9122374e1550f19d87d35636e0, globalLoadedData, globalLastStates, c3384434055cdd84d5c34e36422c0f1a7, c147ee89dce997e916872a9ab40954015);
	}

	public static void c61d1999d0d09515f6fefe4c234a27452(ref List<MecanimEvent> c2a329a9122374e1550f19d87d35636e0, Dictionary<int, Dictionary<int, Dictionary<int, List<MecanimEvent>>>> cde922ba9c400197209ff6a9040cb07b3, Dictionary<int, Dictionary<int, AnimatorStateInfo>> c987887348edf2bd4b854a7534ba4f178, int c3384434055cdd84d5c34e36422c0f1a7, Animator c147ee89dce997e916872a9ab40954015)
	{
		int hashCode = c147ee89dce997e916872a9ab40954015.GetHashCode();
		if (!c987887348edf2bd4b854a7534ba4f178.ContainsKey(hashCode))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c987887348edf2bd4b854a7534ba4f178[hashCode] = new Dictionary<int, AnimatorStateInfo>();
		}
		int layerCount = c147ee89dce997e916872a9ab40954015.layerCount;
		Dictionary<int, AnimatorStateInfo> dictionary = c987887348edf2bd4b854a7534ba4f178[hashCode];
		AnimatorStateInfo c36964cf41281414170f34ee68bef6c = default(AnimatorStateInfo);
		AnimatorStateInfo currentAnimatorStateInfo;
		for (int i = 0; i < layerCount; dictionary[i] = currentAnimatorStateInfo, i++)
		{
			if (!dictionary.ContainsKey(i))
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
				int key = i;
				c1549cb56d98a57e2c0aabf6a44808536.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
				dictionary[key] = c36964cf41281414170f34ee68bef6c;
			}
			currentAnimatorStateInfo = c147ee89dce997e916872a9ab40954015.GetCurrentAnimatorStateInfo(i);
			int num = (int)dictionary[i].normalizedTime;
			int num2 = (int)currentAnimatorStateInfo.normalizedTime;
			float c0984013ddd46fb15cdf3ce62141a9e2c = dictionary[i].normalizedTime - (float)num;
			float cd78851d308e6dccfe86f62769e9a1e = currentAnimatorStateInfo.normalizedTime - (float)num2;
			if (dictionary[i].nameHash == currentAnimatorStateInfo.nameHash)
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
				if (currentAnimatorStateInfo.loop)
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
					if (num == num2)
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
						cc0ad15ab8b2a1f8c85a12199c2dcf351(ref c2a329a9122374e1550f19d87d35636e0, cde922ba9c400197209ff6a9040cb07b3, c147ee89dce997e916872a9ab40954015, c3384434055cdd84d5c34e36422c0f1a7, i, currentAnimatorStateInfo.nameHash, currentAnimatorStateInfo.tagHash, c0984013ddd46fb15cdf3ce62141a9e2c, cd78851d308e6dccfe86f62769e9a1e);
					}
					else
					{
						cc0ad15ab8b2a1f8c85a12199c2dcf351(ref c2a329a9122374e1550f19d87d35636e0, cde922ba9c400197209ff6a9040cb07b3, c147ee89dce997e916872a9ab40954015, c3384434055cdd84d5c34e36422c0f1a7, i, currentAnimatorStateInfo.nameHash, currentAnimatorStateInfo.tagHash, c0984013ddd46fb15cdf3ce62141a9e2c, 1.00001f);
						cc0ad15ab8b2a1f8c85a12199c2dcf351(ref c2a329a9122374e1550f19d87d35636e0, cde922ba9c400197209ff6a9040cb07b3, c147ee89dce997e916872a9ab40954015, c3384434055cdd84d5c34e36422c0f1a7, i, currentAnimatorStateInfo.nameHash, currentAnimatorStateInfo.tagHash, 0f, cd78851d308e6dccfe86f62769e9a1e);
					}
					continue;
				}
				float num3 = Mathf.Clamp01(dictionary[i].normalizedTime);
				float num4 = Mathf.Clamp01(currentAnimatorStateInfo.normalizedTime);
				if (num == 0)
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
					if (num2 == 0)
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
						if (num3 == num4)
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
						cc0ad15ab8b2a1f8c85a12199c2dcf351(ref c2a329a9122374e1550f19d87d35636e0, cde922ba9c400197209ff6a9040cb07b3, c147ee89dce997e916872a9ab40954015, c3384434055cdd84d5c34e36422c0f1a7, i, currentAnimatorStateInfo.nameHash, currentAnimatorStateInfo.tagHash, num3, num4);
						continue;
					}
				}
				if (num != 0)
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
				if (num2 <= 0)
				{
					continue;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				cc0ad15ab8b2a1f8c85a12199c2dcf351(ref c2a329a9122374e1550f19d87d35636e0, cde922ba9c400197209ff6a9040cb07b3, c147ee89dce997e916872a9ab40954015, c3384434055cdd84d5c34e36422c0f1a7, i, dictionary[i].nameHash, dictionary[i].tagHash, num3, 1.00001f);
				continue;
			}
			cc0ad15ab8b2a1f8c85a12199c2dcf351(ref c2a329a9122374e1550f19d87d35636e0, cde922ba9c400197209ff6a9040cb07b3, c147ee89dce997e916872a9ab40954015, c3384434055cdd84d5c34e36422c0f1a7, i, currentAnimatorStateInfo.nameHash, currentAnimatorStateInfo.tagHash, 0f, cd78851d308e6dccfe86f62769e9a1e);
			if (dictionary[i].loop)
			{
				continue;
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
			cc0ad15ab8b2a1f8c85a12199c2dcf351(ref c2a329a9122374e1550f19d87d35636e0, cde922ba9c400197209ff6a9040cb07b3, c147ee89dce997e916872a9ab40954015, c3384434055cdd84d5c34e36422c0f1a7, i, dictionary[i].nameHash, dictionary[i].tagHash, c0984013ddd46fb15cdf3ce62141a9e2c, 1.00001f, true);
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

	private static void cc0ad15ab8b2a1f8c85a12199c2dcf351(ref List<MecanimEvent> c2a329a9122374e1550f19d87d35636e0, Dictionary<int, Dictionary<int, Dictionary<int, List<MecanimEvent>>>> cde922ba9c400197209ff6a9040cb07b3, Animator c147ee89dce997e916872a9ab40954015, int c3384434055cdd84d5c34e36422c0f1a7, int c329db3bbe38dc031eb08c342538daa1a, int c89d584e9b8c005ce9f99d498fbfc1057, int cf8a9fdd8d8e5b6240fc03f7d5e6cc8a0, float c0984013ddd46fb15cdf3ce62141a9e2c, float cd78851d308e6dccfe86f62769e9a1e32, bool cee29945ee4e0c9bfd3e8460fca6fe28e = false)
	{
		if (!cde922ba9c400197209ff6a9040cb07b3.ContainsKey(c3384434055cdd84d5c34e36422c0f1a7))
		{
			return;
		}
		EventContext c36964cf41281414170f34ee68bef6c = default(EventContext);
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
			if (!cde922ba9c400197209ff6a9040cb07b3[c3384434055cdd84d5c34e36422c0f1a7].ContainsKey(c329db3bbe38dc031eb08c342538daa1a))
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
				if (!cde922ba9c400197209ff6a9040cb07b3[c3384434055cdd84d5c34e36422c0f1a7][c329db3bbe38dc031eb08c342538daa1a].ContainsKey(c89d584e9b8c005ce9f99d498fbfc1057))
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
					List<MecanimEvent> list = cde922ba9c400197209ff6a9040cb07b3[c3384434055cdd84d5c34e36422c0f1a7][c329db3bbe38dc031eb08c342538daa1a][c89d584e9b8c005ce9f99d498fbfc1057];
					for (int i = 0; i < list.Count; i++)
					{
						MecanimEvent mecanimEvent = list[i];
						if (!mecanimEvent.isEnable)
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
						if (!(mecanimEvent.normalizedTime >= c0984013ddd46fb15cdf3ce62141a9e2c))
						{
							continue;
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
						if (!(mecanimEvent.normalizedTime < cd78851d308e6dccfe86f62769e9a1e32))
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
							break;
						}
						if (!mecanimEvent.condition.c515f796a94abd08a45b1f67775e1da8d(c147ee89dce997e916872a9ab40954015))
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
							break;
						}
						if (cee29945ee4e0c9bfd3e8460fca6fe28e)
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
							if (!mecanimEvent.critical)
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
								continue;
							}
						}
						MecanimEvent mecanimEvent2 = new MecanimEvent(mecanimEvent);
						ce4773585f26cc2e8513d3792211e9206.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
						c36964cf41281414170f34ee68bef6c.controllerId = c3384434055cdd84d5c34e36422c0f1a7;
						c36964cf41281414170f34ee68bef6c.layer = c329db3bbe38dc031eb08c342538daa1a;
						c36964cf41281414170f34ee68bef6c.stateHash = c89d584e9b8c005ce9f99d498fbfc1057;
						c36964cf41281414170f34ee68bef6c.tagHash = cf8a9fdd8d8e5b6240fc03f7d5e6cc8a0;
						mecanimEvent2.c076011a8a4a8a431f020df4195346d03(c36964cf41281414170f34ee68bef6c);
						c2a329a9122374e1550f19d87d35636e0.Add(mecanimEvent2);
					}
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
			}
		}
	}

	private static void cc09f35c9cf4e65548d30f62bfebf96e9()
	{
		if (eventDataSources == null)
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
		globalLoadedData = new Dictionary<int, Dictionary<int, Dictionary<int, List<MecanimEvent>>>>();
		animatorControllerIdData = new Dictionary<string, int>();
		MecanimEventData[] array = eventDataSources;
		foreach (MecanimEventData mecanimEventData in array)
		{
			if (mecanimEventData == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				continue;
			}
			MecanimEventDataEntry[] data = mecanimEventData.data;
			MecanimEventDataEntry[] array2 = data;
			foreach (MecanimEventDataEntry mecanimEventDataEntry in array2)
			{
				int hashCode = mecanimEventDataEntry.animatorControllerName.GetHashCode();
				if (!animatorControllerIdData.ContainsKey(mecanimEventDataEntry.animatorControllerName))
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
					animatorControllerIdData[mecanimEventDataEntry.animatorControllerName] = hashCode;
				}
				if (!globalLoadedData.ContainsKey(hashCode))
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
					globalLoadedData[hashCode] = new Dictionary<int, Dictionary<int, List<MecanimEvent>>>();
				}
				if (!globalLoadedData[hashCode].ContainsKey(mecanimEventDataEntry.layer))
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
					globalLoadedData[hashCode][mecanimEventDataEntry.layer] = new Dictionary<int, List<MecanimEvent>>();
				}
				globalLoadedData[hashCode][mecanimEventDataEntry.layer][mecanimEventDataEntry.stateNameHash] = new List<MecanimEvent>(mecanimEventDataEntry.events);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
		}
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

	public static Dictionary<int, Dictionary<int, Dictionary<int, List<MecanimEvent>>>> c1865e914aba2df7645d89113626b5104(MecanimEventData c591d56a94543e3559945c497f37126c4)
	{
		Dictionary<int, Dictionary<int, Dictionary<int, List<MecanimEvent>>>> dictionary = new Dictionary<int, Dictionary<int, Dictionary<int, List<MecanimEvent>>>>();
		MecanimEventDataEntry[] data = c591d56a94543e3559945c497f37126c4.data;
		MecanimEventDataEntry[] array = data;
		foreach (MecanimEventDataEntry mecanimEventDataEntry in array)
		{
			int instanceID = mecanimEventDataEntry.animatorController.GetInstanceID();
			if (!dictionary.ContainsKey(instanceID))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				dictionary[instanceID] = new Dictionary<int, Dictionary<int, List<MecanimEvent>>>();
			}
			if (!dictionary[instanceID].ContainsKey(mecanimEventDataEntry.layer))
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
				dictionary[instanceID][mecanimEventDataEntry.layer] = new Dictionary<int, List<MecanimEvent>>();
			}
			dictionary[instanceID][mecanimEventDataEntry.layer][mecanimEventDataEntry.stateNameHash] = new List<MecanimEvent>(mecanimEventDataEntry.events);
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			return dictionary;
		}
	}
}
