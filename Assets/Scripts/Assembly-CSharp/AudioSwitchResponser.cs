using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Audio/Audio Switch Responser")]
public class AudioSwitchResponser : AudioEventResponsers
{
	public AudioSwitchReference m_switch;

	public SwitchAssignment[] m_assignments;

	private Dictionary<string, SwitchAssignment> m_assignmentMap = new Dictionary<string, SwitchAssignment>();

	private void c9cbc2fe47645750090766797122af7d6()
	{
		m_assignmentMap.Clear();
		if (m_assignments == null)
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
			if (m_switch == null)
			{
				return;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				if (!m_switch.c943bc6a18586b3e0e6f0214717aca479())
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
					AudioSwitch audioSwitch = m_switch.c588e7dbcd383d8230b2d83d7b44af23b();
					for (int i = 0; i < m_assignments.Length; i++)
					{
						SwitchAssignment switchAssignment = m_assignments[i];
						if (!audioSwitch.c921dfdab73e4f5bfaecc185c5b6359ff(switchAssignment.m_case))
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
							string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(6);
							array[0] = "AudioSwitchResponser '";
							array[1] = base.gameObject.name;
							array[2] = "': No case named '";
							array[3] = switchAssignment.m_case;
							array[4] = "' in switch ";
							array[5] = audioSwitch.Name;
							DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, string.Concat(array));
							continue;
						}
						if (m_assignmentMap.ContainsKey(switchAssignment.m_case))
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
							string[] array2 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(5);
							array2[0] = "AudioSwitchResponser '";
							array2[1] = base.gameObject.name;
							array2[2] = "': already have an assignment for case: '";
							array2[3] = switchAssignment.m_case;
							array2[4] = "'";
							DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, string.Concat(array2));
							continue;
						}
						if (null != switchAssignment.m_responser)
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
							if (switchAssignment.m_responser.c250783c219e5191f706df9ed222f6b38() != this)
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
								string[] array3 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(5);
								array3[0] = "AudioSwitchResponser '";
								array3[1] = base.gameObject.name;
								array3[2] = "': assigned responser '";
								array3[3] = switchAssignment.m_responser.name;
								array3[4] = "' is not a child";
								DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, string.Concat(array3));
								continue;
							}
						}
						m_assignmentMap.Add(switchAssignment.m_case, switchAssignment);
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
			}
		}
	}

	public override void Awake()
	{
		base.Awake();
	}

	public override void ccc9d3a38966dc10fedb531ea17d24611()
	{
		base.ccc9d3a38966dc10fedb531ea17d24611();
		AudioSwitch audioSwitch = m_switch.c588e7dbcd383d8230b2d83d7b44af23b();
		if (null == m_parameters)
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
			if (audioSwitch != null)
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
				if (audioSwitch.cd321a58aaf57e87b4e4ae0fb0a8b868d != null)
				{
					goto IL_0082;
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
			}
			string text = Utils.c6623cde42db4307c0b144942a5a8c70d(base.gameObject);
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "AudioSwitchResponser '" + text + "': switch parameter value is not assigned so this sound instance is useless. Check the entity prefab to make sure it has an AudioParameterValueComponent assigned, so it can resolve audio parameters");
			return;
		}
		goto IL_0082;
		IL_0082:
		if (m_assignmentMap.Count >= 1)
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
			c9cbc2fe47645750090766797122af7d6();
			return;
		}
	}

	public override void Update()
	{
		base.Update();
	}

	private void cf9da6ecbf229374d78e1e352056455be()
	{
		AudioSwitch audioSwitch = m_switch.c588e7dbcd383d8230b2d83d7b44af23b();
		AudioParameterValues audioParameterValues = cab010853285c6825c61de59deedff427();
		string cbba496e96e28b7629dc91ff46a0a919a = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		if (!audioParameterValues.c4e0f63f4b4d409c5e3992c71520e30a0(audioSwitch, out cbba496e96e28b7629dc91ff46a0a919a))
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
			cbba496e96e28b7629dc91ff46a0a919a = audioSwitch.cd321a58aaf57e87b4e4ae0fb0a8b868d;
		}
		if (cbba496e96e28b7629dc91ff46a0a919a == null)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "AudioSwitchResponser '" + base.gameObject.name + "': cannot find a valid value for switch: " + audioSwitch.Name);
					m_currentResponser = c77a81794feffca75455e9cbf19cb9e49.c7088de59e49f7108f520cf7e0bae167e;
					return;
				}
			}
		}
		SwitchAssignment value = cbccc133f2e434fb6ccbddd1db5680ed2.c7088de59e49f7108f520cf7e0bae167e;
		if (m_assignmentMap.TryGetValue(cbba496e96e28b7629dc91ff46a0a919a, out value))
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					m_currentResponser = value.m_responser;
					return;
				}
			}
		}
		DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "AudioSwitchResponser '" + base.gameObject.name + "': does not define a mapping for case: " + cbba496e96e28b7629dc91ff46a0a919a);
		m_currentResponser = c77a81794feffca75455e9cbf19cb9e49.c7088de59e49f7108f520cf7e0bae167e;
	}

	public override void c0a75d7afd2f7f1e47a5aadaab61303c7()
	{
		cf9da6ecbf229374d78e1e352056455be();
		base.c0a75d7afd2f7f1e47a5aadaab61303c7();
	}

	public override void c0a75d7afd2f7f1e47a5aadaab61303c7(float cb17344c6ba6038b9297f344b2472c2f5)
	{
		cf9da6ecbf229374d78e1e352056455be();
		base.c0a75d7afd2f7f1e47a5aadaab61303c7(cb17344c6ba6038b9297f344b2472c2f5);
	}
}
