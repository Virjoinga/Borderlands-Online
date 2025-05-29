using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

[RequireComponent(typeof(BaseEventTriggerCtl))]
public class VoiceSystem : MonoBehaviour
{
	public VoiceConfig[] m_voiceConfigs;

	public string m_currentVoice;

	public byte m_priority;

	private BaseEventTriggerCtl m_audioEventCtl;

	private Dictionary<string, byte> m_voices;

	private void Awake()
	{
		m_audioEventCtl = GetComponent<BaseEventTriggerCtl>();
		if (m_audioEventCtl == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "AudioEventTriggerCtl missing on " + base.name);
		}
		m_voices = new Dictionary<string, byte>();
		for (int i = 0; i < m_voiceConfigs.Length; i++)
		{
			if (m_voices.ContainsKey(m_voiceConfigs[i].m_voice))
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
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "Duplicate Voice Configuration '" + m_voiceConfigs[i].m_voice + "'on VoiceSystem owned by: " + base.name);
			}
			else
			{
				m_voices.Add(m_voiceConfigs[i].m_voice, m_voiceConfigs[i].m_priority);
			}
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

	public void TryToSpeak(string eventName)
	{
		if (m_audioEventCtl == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "AudioEventTriggerCtl missing on VoiceSystem owned by: " + base.name);
					return;
				}
			}
		}
		byte value;
		if (!m_voices.TryGetValue(eventName, out value))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, eventName + " missing on VoiceSystem on " + base.name);
					return;
				}
			}
		}
		if (m_currentVoice == string.Empty)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					m_currentVoice = eventName;
					m_priority = value;
					m_audioEventCtl.TriggerEventByName(eventName);
					return;
				}
			}
		}
		EventTriggerData eventTriggerData = m_audioEventCtl.c6ce4fecb4b540d34b74bd1f7ebd58577();
		BaseEventHandler value2 = c5874db6ed2097ba9cdc2517ef82b8680.c7088de59e49f7108f520cf7e0bae167e;
		if (eventTriggerData == null)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "VoiceSystem AudioEventTriggerCtl does not define any EventTriggerData, on VoiceSystem owned by: " + base.name);
		}
		if (!eventTriggerData.cce042d6921b01754b4b5d8013356a44d.TryGetValue(m_currentVoice, out value2))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "VoiceSystem event '" + eventName + "' is missing in AudioEventTriggerCtl configuration, on VoiceSystem owned by: " + base.name);
					return;
				}
			}
		}
		AudioEventHandler audioEventHandler = value2 as AudioEventHandler;
		using (List<CSoundPrefabInfo>.Enumerator enumerator = audioEventHandler.m_aSoundPrefabList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CSoundPrefabInfo current = enumerator.Current;
				if (current != null)
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
					if (!(null == current.m_audioResponser))
					{
						if (current.m_audioResponser.m_scope == AudioLimitScope.Globally)
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
							if (!AudioEventHandler.s_globalActiveList.ContainsKey(current.m_sAudioPrefabName))
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
							List<BaseEventResponser> list = AudioEventHandler.s_globalActiveList[current.m_sAudioPrefabName];
							for (int i = 0; i < list.Count; i++)
							{
								if (list[i] == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								}
								else
								{
									if (!(list[i].transform.parent == base.transform))
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
									if (!list[i].cb9efc4af2006b47000b468b9df139a30())
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
										if (value >= m_voices[m_currentVoice])
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
											m_audioEventCtl.ReleaseEventByName(m_currentVoice);
											m_currentVoice = eventName;
											m_priority = value;
											m_audioEventCtl.TriggerEventByName(eventName);
											return;
										}
									}
								}
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
							continue;
						}
						int num = 0;
						if (current.m_activeList.Count <= 0)
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
						if (current.m_activeList[0].cb9efc4af2006b47000b468b9df139a30())
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
							if (m_voices[eventName] < m_voices[m_currentVoice])
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
								m_audioEventCtl.ReleaseEventByName(m_currentVoice);
								m_currentVoice = eventName;
								m_priority = value;
								m_audioEventCtl.TriggerEventByName(eventName);
								num++;
							}
							else
							{
								DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "trigger " + current.m_sAudioPrefabName + " been omited for priority judge");
							}
						}
						else
						{
							num++;
						}
						if (num != 0)
						{
							continue;
						}
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
				if (current != null)
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
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Invalid prefab for voice trigger: " + eventName + " on entity: " + base.name);
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					goto end_IL_03f4;
				}
				continue;
				end_IL_03f4:
				break;
			}
		}
		m_currentVoice = eventName;
		m_priority = value;
		m_audioEventCtl.TriggerEventByName(eventName);
	}
}
