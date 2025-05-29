using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

[ExecuteInEditMode]
public class AudioEventHandler : BaseEventHandler
{
	public static Dictionary<string, List<BaseEventResponser>> s_globalActiveList = new Dictionary<string, List<BaseEventResponser>>();

	public static Dictionary<string, List<BaseEventResponser>> s_globalFreeList = new Dictionary<string, List<BaseEventResponser>>();

	public float m_distanceToTrigger = 100f;

	public AudioEventAction m_action;

	public List<CSoundPrefabInfo> m_aSoundPrefabList = new List<CSoundPrefabInfo>();

	private bool m_updateAction;

	protected List<BaseEventResponser> removeList = new List<BaseEventResponser>();

	private Dictionary<string, int> m_soundNameToLastRandomSoundBeingPlayed = new Dictionary<string, int>();

	private List<BaseEventResponser> m_toRemove = new List<BaseEventResponser>();

	public override bool Update()
	{
		if (m_updateAction)
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
			c0cb40d214539834aaa29430b40caf74b();
			m_updateAction = false;
		}
		int num = c53eb5d2d69217a78af6cb6fd323d9dde();
		return num > 0;
	}

	public void cc88ed4d299a92e70baa384198512a535()
	{
		CSoundPrefabInfo item = new CSoundPrefabInfo();
		m_aSoundPrefabList.Add(item);
	}

	public override void c15c3855d4db79068c16ffafb4dfac411(GameObject c80822505abd04406a7a821211bd77371)
	{
		if (!cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
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
			if (!cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c9d5aded6668d31de4d83fc0acc0b5378)
			{
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
			for (int i = 0; i < m_aSoundPrefabList.Count; i++)
			{
				CSoundPrefabInfo cSoundPrefabInfo = m_aSoundPrefabList[i];
				cSoundPrefabInfo.m_eAction = AudioEventAction.Play;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				if (!cf536d5b7c2ef7c47c2d751183d8f64b7(c80822505abd04406a7a821211bd77371))
				{
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
				if (!cdff82462da44eaa1e24363ba758e1c2d(c80822505abd04406a7a821211bd77371))
				{
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
				for (int j = 0; j < m_updateList.Count; j++)
				{
					m_updateList[j].ccc9d3a38966dc10fedb531ea17d24611();
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					m_updateAction = true;
					cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.c2764da59e8c286298060575e3251e48a(this);
					return;
				}
			}
		}
	}

	public override void c286b780af808436bb0a07b990296ede3(GameObject c80822505abd04406a7a821211bd77371, EventTriggerType c2b4f43f34e21572af6ab4414f04cee36 = EventTriggerType.None)
	{
		if (m_type != c2b4f43f34e21572af6ab4414f04cee36)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c15c3855d4db79068c16ffafb4dfac411(c80822505abd04406a7a821211bd77371);
			return;
		}
	}

	public override void c035f04b07ce73a4869280b94ecc42137(GameObject c80822505abd04406a7a821211bd77371)
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
					switch (6)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			for (int i = 0; i < m_aSoundPrefabList.Count; i++)
			{
				CSoundPrefabInfo cSoundPrefabInfo = m_aSoundPrefabList[i];
				cSoundPrefabInfo.m_eAction = AudioEventAction.Stop;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				if (!c67ef84fc6e7f63e11524b6612d15f7d1(c80822505abd04406a7a821211bd77371))
				{
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
				m_updateAction = true;
				cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.c2764da59e8c286298060575e3251e48a(this);
				return;
			}
		}
	}

	private bool c67ef84fc6e7f63e11524b6612d15f7d1(GameObject c80822505abd04406a7a821211bd77371)
	{
		AudioEventTriggerCtl component = c80822505abd04406a7a821211bd77371.GetComponent<AudioEventTriggerCtl>();
		if (component.c6ce4fecb4b540d34b74bd1f7ebd58577().cce042d6921b01754b4b5d8013356a44d.ContainsKey(m_eventName))
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
			AudioEventHandler audioEventHandler = component.c6ce4fecb4b540d34b74bd1f7ebd58577().cce042d6921b01754b4b5d8013356a44d[m_eventName] as AudioEventHandler;
			for (int i = 0; i < audioEventHandler.m_aSoundPrefabList.Count; i++)
			{
				CSoundPrefabInfo cSoundPrefabInfo = m_aSoundPrefabList[i];
				if (cSoundPrefabInfo.m_audioResponser == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Stop called before play? When trigger event: " + m_eventName + " at " + c80822505abd04406a7a821211bd77371.name);
				}
				else
				{
					if (cSoundPrefabInfo.m_audioResponser.m_scope == AudioLimitScope.Globally)
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
						if (!s_globalActiveList.ContainsKey(cSoundPrefabInfo.m_sAudioPrefabName))
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
							List<BaseEventResponser> list = s_globalActiveList[cSoundPrefabInfo.m_sAudioPrefabName];
							m_updateList.Clear();
							for (int j = 0; j < list.Count; j++)
							{
								if (null == list[j])
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
								if (null == list[j].transform.parent)
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
								if (!(list[j].transform.parent.gameObject == c80822505abd04406a7a821211bd77371))
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
								if (!list[j].cb9efc4af2006b47000b468b9df139a30())
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
								m_updateList.Add(list[j]);
							}
							while (true)
							{
								switch (2)
								{
								case 0:
									continue;
								}
								if (m_updateList.Count > 0)
								{
									while (true)
									{
										switch (2)
										{
										case 0:
											break;
										default:
											return true;
										}
									}
								}
								return false;
							}
						}
					}
					if (cSoundPrefabInfo.m_activeList.Count <= 0)
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
						for (int k = 0; k < cSoundPrefabInfo.m_activeList.Count; k++)
						{
							m_updateList.Add(cSoundPrefabInfo.m_activeList[k]);
						}
						while (true)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							return true;
						}
					}
				}
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
		else
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "Event : " + m_eventName + " missing on " + c80822505abd04406a7a821211bd77371.name);
		}
		return false;
	}

	private bool cf536d5b7c2ef7c47c2d751183d8f64b7(GameObject c80822505abd04406a7a821211bd77371)
	{
		if (m_resourceIsReady)
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
					return true;
				}
			}
		}
		for (int i = 0; i < m_aSoundPrefabList.Count; i++)
		{
			CSoundPrefabInfo cSoundPrefabInfo = m_aSoundPrefabList[i];
			GameObject gameObject = cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c9f6a0386ce93c761939b8a4def1e3435.cd5ef7246c436154c165ae5cdac3f0918(cSoundPrefabInfo.m_sAudioPrefabName);
			if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "*****Audio Prefab missing: " + m_aSoundPrefabList[i].m_sAudioPrefabName);
			}
			else
			{
				if (!(cSoundPrefabInfo.m_audioResponser == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				cSoundPrefabInfo.m_audioResponser = gameObject.GetComponent<BaseEventResponser>() as AudioEventResponser;
				if (!(cSoundPrefabInfo.m_audioResponser == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "Event Responser missing on sound event  " + m_eventName);
			}
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			m_resourceIsReady = true;
			return true;
		}
	}

	private bool cdff82462da44eaa1e24363ba758e1c2d(GameObject c80822505abd04406a7a821211bd77371)
	{
		AudioListener cefdcf2f4f46a0ef9161d03211b8b = cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.cefdcf2f4f46a0ef9161d03211b8b0476;
		if (null != cefdcf2f4f46a0ef9161d03211b8b)
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
			int num = 0;
			for (int i = 0; i < m_aSoundPrefabList.Count; i++)
			{
				CSoundPrefabInfo cSoundPrefabInfo = m_aSoundPrefabList[i];
				if (!(Vector3.Distance(cefdcf2f4f46a0ef9161d03211b8b.transform.position, c80822505abd04406a7a821211bd77371.transform.position) < cSoundPrefabInfo.m_fDistanceToTrigger))
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
				if (!(Time.realtimeSinceStartup - cSoundPrefabInfo.m_lastTriggerTime > cSoundPrefabInfo.m_fInterval))
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
				num++;
				AudioEventResponser audioResponser = cSoundPrefabInfo.m_audioResponser;
				if (audioResponser == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Prefab: " + cSoundPrefabInfo.m_sAudioPrefabName + " 's responser missing !");
				}
				else if (audioResponser.m_enablePlaybackLimit)
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
					AudioLimitScope scope = audioResponser.m_scope;
					if (scope != 0)
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
						if (scope != AudioLimitScope.Globally)
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
							DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "*****scope error, impossible!");
						}
						else
						{
							c88368ff4610f8cb022ecb19ec95f32a6(c80822505abd04406a7a821211bd77371, cSoundPrefabInfo);
						}
					}
					else
					{
						cdd17e6ca4e8dd5469ab040499d03b2fb(c80822505abd04406a7a821211bd77371, cSoundPrefabInfo);
					}
				}
				else if (cSoundPrefabInfo.m_activeList.Count > 0)
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
					m_updateList.Add(cSoundPrefabInfo.m_activeList[0]);
				}
				else
				{
					c89497ab2bad8c8ca99f4c299b552917e(cSoundPrefabInfo, c80822505abd04406a7a821211bd77371, cSoundPrefabInfo.m_activeList);
				}
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
		}
		else
		{
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "*****Global audio listener missing!");
		}
		return true;
	}

	private void c88368ff4610f8cb022ecb19ec95f32a6(GameObject c80822505abd04406a7a821211bd77371, CSoundPrefabInfo cb1cd16bcf469f3b4b600e9c9e96b3557)
	{
		List<BaseEventResponser> c7088de59e49f7108f520cf7e0bae167e = ce45e76f13363088988a266245d5cf4d9.c7088de59e49f7108f520cf7e0bae167e;
		List<BaseEventResponser> c7088de59e49f7108f520cf7e0bae167e2 = ce45e76f13363088988a266245d5cf4d9.c7088de59e49f7108f520cf7e0bae167e;
		string sAudioPrefabName = cb1cd16bcf469f3b4b600e9c9e96b3557.m_sAudioPrefabName;
		if (s_globalActiveList.ContainsKey(sAudioPrefabName))
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
			c7088de59e49f7108f520cf7e0bae167e = s_globalActiveList[sAudioPrefabName];
			c20c4ca2fb995061f0bb0b01a70c099b6(c7088de59e49f7108f520cf7e0bae167e);
		}
		else
		{
			c7088de59e49f7108f520cf7e0bae167e = new List<BaseEventResponser>();
			s_globalActiveList.Add(sAudioPrefabName, c7088de59e49f7108f520cf7e0bae167e);
		}
		if (s_globalFreeList.ContainsKey(sAudioPrefabName))
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
			c7088de59e49f7108f520cf7e0bae167e2 = s_globalFreeList[sAudioPrefabName];
			c20c4ca2fb995061f0bb0b01a70c099b6(c7088de59e49f7108f520cf7e0bae167e2);
		}
		else
		{
			c7088de59e49f7108f520cf7e0bae167e2 = new List<BaseEventResponser>();
			s_globalFreeList.Add(sAudioPrefabName, c7088de59e49f7108f520cf7e0bae167e2);
		}
		if (c7088de59e49f7108f520cf7e0bae167e.Count + c7088de59e49f7108f520cf7e0bae167e2.Count < cb1cd16bcf469f3b4b600e9c9e96b3557.m_audioResponser.m_instanceNum)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					c89497ab2bad8c8ca99f4c299b552917e(cb1cd16bcf469f3b4b600e9c9e96b3557, c80822505abd04406a7a821211bd77371, c7088de59e49f7108f520cf7e0bae167e);
					return;
				}
			}
		}
		for (int i = 0; i < c7088de59e49f7108f520cf7e0bae167e.Count; i++)
		{
			if (m_updateList.Contains(c7088de59e49f7108f520cf7e0bae167e[i]))
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
			if (c7088de59e49f7108f520cf7e0bae167e[i].cb9efc4af2006b47000b468b9df139a30())
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
			c7088de59e49f7108f520cf7e0bae167e2.Add(c7088de59e49f7108f520cf7e0bae167e[i]);
			removeList.Add(c7088de59e49f7108f520cf7e0bae167e[i]);
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			for (int j = 0; j < removeList.Count; j++)
			{
				c7088de59e49f7108f520cf7e0bae167e.Remove(removeList[j]);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				removeList.Clear();
				if (c7088de59e49f7108f520cf7e0bae167e2.Count > 0)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
						{
							BaseEventResponser baseEventResponser = c7088de59e49f7108f520cf7e0bae167e2[0];
							c7088de59e49f7108f520cf7e0bae167e.Add(baseEventResponser);
							c7088de59e49f7108f520cf7e0bae167e2.Remove(baseEventResponser);
							baseEventResponser.transform.parent = c80822505abd04406a7a821211bd77371.transform;
							baseEventResponser.transform.localPosition = Vector3.zero;
							baseEventResponser.transform.localRotation = Quaternion.identity;
							m_updateList.Add(baseEventResponser);
							return;
						}
						}
					}
				}
				c65e7db9b12020b66a8c9bef44a538737(cb1cd16bcf469f3b4b600e9c9e96b3557, c7088de59e49f7108f520cf7e0bae167e, c80822505abd04406a7a821211bd77371);
				return;
			}
		}
	}

	private void cdd17e6ca4e8dd5469ab040499d03b2fb(GameObject c80822505abd04406a7a821211bd77371, CSoundPrefabInfo c80faaccf7d29f00f15c0af4e2d883968)
	{
		if (c80faaccf7d29f00f15c0af4e2d883968.m_activeList.Count + c80faaccf7d29f00f15c0af4e2d883968.m_freeList.Count < c80faaccf7d29f00f15c0af4e2d883968.m_audioResponser.m_instanceNum)
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
					c89497ab2bad8c8ca99f4c299b552917e(c80faaccf7d29f00f15c0af4e2d883968, c80822505abd04406a7a821211bd77371, c80faaccf7d29f00f15c0af4e2d883968.m_activeList);
					return;
				}
			}
		}
		if (c80faaccf7d29f00f15c0af4e2d883968.m_freeList.Count > 0)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					c20b722a6aadf1d0abb31ea63dde37c11(c80faaccf7d29f00f15c0af4e2d883968);
					return;
				}
			}
		}
		if (c80faaccf7d29f00f15c0af4e2d883968.m_freeList.Count > 0)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					c20b722a6aadf1d0abb31ea63dde37c11(c80faaccf7d29f00f15c0af4e2d883968);
					return;
				}
			}
		}
		c65e7db9b12020b66a8c9bef44a538737(c80faaccf7d29f00f15c0af4e2d883968, c80faaccf7d29f00f15c0af4e2d883968.m_activeList, cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e);
	}

	private void c20c4ca2fb995061f0bb0b01a70c099b6(List<BaseEventResponser> c2d9d48506eace44a6624da0edbaf28b9)
	{
		for (int i = 0; i < c2d9d48506eace44a6624da0edbaf28b9.Count; i++)
		{
			if (!(c2d9d48506eace44a6624da0edbaf28b9[i] == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_toRemove.Add(c2d9d48506eace44a6624da0edbaf28b9[i]);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			for (int j = 0; j < m_toRemove.Count; j++)
			{
				c2d9d48506eace44a6624da0edbaf28b9.Remove(m_toRemove[j]);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				m_toRemove.Clear();
				return;
			}
		}
	}

	private void c0cb40d214539834aaa29430b40caf74b()
	{
		if (!cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
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
		c20c4ca2fb995061f0bb0b01a70c099b6(m_updateList);
		for (int i = 0; i < m_aSoundPrefabList.Count; i++)
		{
			CSoundPrefabInfo cSoundPrefabInfo = m_aSoundPrefabList[i];
			float fDelay = cSoundPrefabInfo.m_fDelay;
			float fFadeTime = cSoundPrefabInfo.m_fFadeTime;
			switch (cSoundPrefabInfo.m_eAction)
			{
			case AudioEventAction.Play:
			{
				if (fDelay > 0f)
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
					if (fFadeTime > 0f)
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
						for (int num = 0; num < m_updateList.Count; num++)
						{
							m_updateList[num].c364ecb1e3f2cafa6e8793178cfbd2327(fFadeTime, fDelay);
							cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.cfd7cc95ae872e913738fcf24e3516d08(m_updateList[num]);
							m_updateList[num].c0a75d7afd2f7f1e47a5aadaab61303c7(fDelay);
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
					for (int num2 = 0; num2 < m_updateList.Count; num2++)
					{
						m_updateList[num2].c0a75d7afd2f7f1e47a5aadaab61303c7(fDelay);
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
					break;
				}
				if (fFadeTime > 0f)
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
					for (int num3 = 0; num3 < m_updateList.Count; num3++)
					{
						m_updateList[num3].c364ecb1e3f2cafa6e8793178cfbd2327(fFadeTime, 0f);
						cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.cfd7cc95ae872e913738fcf24e3516d08(m_updateList[num3]);
						m_updateList[num3].c0a75d7afd2f7f1e47a5aadaab61303c7();
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
					break;
				}
				for (int num4 = 0; num4 < m_updateList.Count; num4++)
				{
					m_updateList[num4].c0a75d7afd2f7f1e47a5aadaab61303c7();
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
			case AudioEventAction.Stop:
			{
				if (fFadeTime > 0f)
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
					for (int m = 0; m < m_updateList.Count; m++)
					{
						m_updateList[m].cadd9bee93ecf3ad1c30c38c48b9a22ef(fFadeTime);
						cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.cfd7cc95ae872e913738fcf24e3516d08(m_updateList[m]);
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
				for (int n = 0; n < m_updateList.Count; n++)
				{
					m_updateList[n].cdada4c3678c9c23c38aaf0754a94a620();
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
			case AudioEventAction.Pause:
			{
				for (int l = 0; l < m_updateList.Count; l++)
				{
					m_updateList[l].c4207787d36579661719681a2d411dede();
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
				break;
			}
			case AudioEventAction.Resume:
			{
				if (fFadeTime > 0f)
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
					for (int j = 0; j < m_updateList.Count; j++)
					{
						m_updateList[j].c364ecb1e3f2cafa6e8793178cfbd2327(fFadeTime, fDelay, false);
						m_updateList[j].ccd732382db3f35031907fee9ca4c7dfc(true);
						cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.cfd7cc95ae872e913738fcf24e3516d08(m_updateList[j]);
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
					break;
				}
				for (int k = 0; k < m_updateList.Count; k++)
				{
					m_updateList[k].ccd732382db3f35031907fee9ca4c7dfc();
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
				break;
			}
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			m_updateList.Clear();
			return;
		}
	}

	public int c53eb5d2d69217a78af6cb6fd323d9dde()
	{
		int num = 0;
		for (int i = 0; i < m_aSoundPrefabList.Count; i++)
		{
			CSoundPrefabInfo cSoundPrefabInfo = m_aSoundPrefabList[i];
			c20c4ca2fb995061f0bb0b01a70c099b6(cSoundPrefabInfo.m_activeList);
			int num2 = cSoundPrefabInfo.cd4e12d8d6f3fb9d92eb9f9d4eb3dd826();
			if (num2 <= 0)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			num++;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			return num;
		}
	}

	public void c20b722a6aadf1d0abb31ea63dde37c11(CSoundPrefabInfo cace18a5a1f43884b1c93328117e35cae)
	{
		AudioEventResponser item = cace18a5a1f43884b1c93328117e35cae.m_freeList[0] as AudioEventResponser;
		cace18a5a1f43884b1c93328117e35cae.m_lastTriggerTime = Time.realtimeSinceStartup;
		m_updateList.Add(item);
		cace18a5a1f43884b1c93328117e35cae.m_freeList.Remove(item);
		cace18a5a1f43884b1c93328117e35cae.m_activeList.Add(item);
	}

	public void c89497ab2bad8c8ca99f4c299b552917e(CSoundPrefabInfo cb1cd16bcf469f3b4b600e9c9e96b3557, GameObject c80822505abd04406a7a821211bd77371, List<BaseEventResponser> c00a860238f81204bfe7a77ebf9ed9590)
	{
		GameObject gameObject = cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c9f6a0386ce93c761939b8a4def1e3435.c329d38a43c8592a63c19f7f24569be54(cb1cd16bcf469f3b4b600e9c9e96b3557.m_sAudioPrefabName, c80822505abd04406a7a821211bd77371);
		AudioEventResponser component = gameObject.GetComponent<AudioEventResponser>();
		AudioParameterValues component2 = c80822505abd04406a7a821211bd77371.GetComponent<AudioParameterValues>();
		if (component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			component.cc66b1b0046b75df3f2ab299d0cfa5f10(component2);
		}
		component.caf18a168df80e6ec094fac2d4a6b3c2c(c34d99ee6c38a65e4e6096951ac4ca158);
		m_updateList.Add(component);
		c00a860238f81204bfe7a77ebf9ed9590.Add(component);
		if (c00a860238f81204bfe7a77ebf9ed9590 != cb1cd16bcf469f3b4b600e9c9e96b3557.m_activeList)
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
			cb1cd16bcf469f3b4b600e9c9e96b3557.m_activeList.Add(component);
		}
		cb1cd16bcf469f3b4b600e9c9e96b3557.m_lastTriggerTime = Time.realtimeSinceStartup;
	}

	public void c65e7db9b12020b66a8c9bef44a538737(CSoundPrefabInfo cace18a5a1f43884b1c93328117e35cae, List<BaseEventResponser> c00a860238f81204bfe7a77ebf9ed9590, GameObject c128e9974ee0a216964954e0faeba7567 = null)
	{
		BaseEventResponser baseEventResponser = c77a81794feffca75455e9cbf19cb9e49.c7088de59e49f7108f520cf7e0bae167e;
		switch (cace18a5a1f43884b1c93328117e35cae.m_audioResponser.m_rule)
		{
		case AudioDiscardRule.DiscardOldest:
			if (c00a860238f81204bfe7a77ebf9ed9590.Count <= 0)
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
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			baseEventResponser = c00a860238f81204bfe7a77ebf9ed9590[0];
			break;
		case AudioDiscardRule.DiscardFarthest:
		{
			if (cace18a5a1f43884b1c93328117e35cae.m_activeList.Count < 2)
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
				break;
			}
			Vector3 position = cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.cefdcf2f4f46a0ef9161d03211b8b0476.transform.position;
			float num = Vector3.Distance(position, cace18a5a1f43884b1c93328117e35cae.m_activeList[0].transform.position);
			baseEventResponser = cace18a5a1f43884b1c93328117e35cae.m_activeList[0];
			for (int i = 1; i < cace18a5a1f43884b1c93328117e35cae.m_activeList.Count; i++)
			{
				float num2;
				if (!((num2 = Vector3.Distance(position, cace18a5a1f43884b1c93328117e35cae.m_activeList[i].transform.position)) > num))
				{
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
				num = num2;
				baseEventResponser = cace18a5a1f43884b1c93328117e35cae.m_activeList[i];
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
			break;
		}
		default:
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "*****rule error, impossible!");
			break;
		case AudioDiscardRule.DiscardNewest:
			break;
		}
		if (!baseEventResponser)
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
			if (m_updateList.Contains(baseEventResponser))
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
				if (!baseEventResponser.cb9efc4af2006b47000b468b9df139a30())
				{
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
				m_updateList.Add(baseEventResponser);
				cace18a5a1f43884b1c93328117e35cae.m_activeList.Remove(baseEventResponser);
				cace18a5a1f43884b1c93328117e35cae.m_activeList.Add(baseEventResponser);
				cace18a5a1f43884b1c93328117e35cae.m_lastTriggerTime = Time.realtimeSinceStartup;
				if (!c128e9974ee0a216964954e0faeba7567)
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
					baseEventResponser.transform.parent = c128e9974ee0a216964954e0faeba7567.transform;
					baseEventResponser.transform.localPosition = Vector3.zero;
					baseEventResponser.transform.localRotation = Quaternion.identity;
					return;
				}
			}
		}
	}

	public int c34d99ee6c38a65e4e6096951ac4ca158(string c45fd7f5a766449817c6df573f08ae226, int cd071bb754bcf7d9444da586dc51ac239)
	{
		int num = 0;
		if (cd071bb754bcf7d9444da586dc51ac239 > 1)
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
			int value = -1;
			m_soundNameToLastRandomSoundBeingPlayed.TryGetValue(c45fd7f5a766449817c6df573f08ae226, out value);
			num = c1ee7921b0c3cce194fb7cae41b5a9d82<AudioRandomResponserGlobalExclusion>.c5ee19dc8d4cccf5ae2de225410458b86.c3ec92e17a377a835b74cf48e005fe134(c45fd7f5a766449817c6df573f08ae226, cd071bb754bcf7d9444da586dc51ac239, value);
		}
		m_soundNameToLastRandomSoundBeingPlayed[c45fd7f5a766449817c6df573f08ae226] = num;
		return num;
	}
}
