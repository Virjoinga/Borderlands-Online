using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using A;
using UnityEngine;

public class StatePriorityManage
{
	public class PriorityInfo
	{
		public int m_priority;

		public bool m_bCanOverrideSamePriority;

		public PriorityInfo(int c3fcc88d8d4eb4cb2ef35bc2cf9400f43, bool c0c4c3fb11e61c11259fdb0d712820759)
		{
			m_priority = c3fcc88d8d4eb4cb2ef35bc2cf9400f43;
			m_bCanOverrideSamePriority = c0c4c3fb11e61c11259fdb0d712820759;
		}
	}

	private PlayerThirdPersonAnimationManagerFSM m_Owner;

	private Dictionary<string, PriorityInfo> m_infos = new Dictionary<string, PriorityInfo>();

	public StatePriorityManage(PlayerThirdPersonAnimationManagerFSM cf811c0d5de19d7fe22be8d61350b722d)
	{
		m_Owner = cf811c0d5de19d7fe22be8d61350b722d;
		c71e86b23dc1f5e7b0d35701157f67fd4();
	}

	public bool ccdc879751e4e899129390bfd75c37e16(string c4358daf22b0e6d46a28d25b67ef40694)
	{
		if (m_Owner.m_upperBodyStateMachine != null)
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
			if (m_Owner.m_upperBodyStateMachine.m_curState != null)
			{
				string ca5a2b345087379ea02ec4ca950356e9f = m_Owner.m_upperBodyStateMachine.m_curState.ca5a2b345087379ea02ec4ca950356e9f;
				if (m_infos.ContainsKey(ca5a2b345087379ea02ec4ca950356e9f))
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
					if (m_infos.ContainsKey(c4358daf22b0e6d46a28d25b67ef40694))
					{
						int priority = m_infos[c4358daf22b0e6d46a28d25b67ef40694].m_priority;
						int priority2 = m_infos[ca5a2b345087379ea02ec4ca950356e9f].m_priority;
						if (priority > priority2)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
									return true;
								}
							}
						}
						if (priority == priority2)
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
							if (m_infos[ca5a2b345087379ea02ec4ca950356e9f].m_bCanOverrideSamePriority)
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
								if (m_infos[c4358daf22b0e6d46a28d25b67ef40694].m_bCanOverrideSamePriority)
								{
									while (true)
									{
										switch (3)
										{
										case 0:
											break;
										default:
											return true;
										}
									}
								}
							}
						}
						return false;
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
				return true;
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
		}
		return false;
	}

	private void c71e86b23dc1f5e7b0d35701157f67fd4()
	{
		m_infos.Clear();
		TextAsset textAsset = Resources.Load("Entities/Player_Mecanim/Config_Animation_Priority", Type.GetTypeFromHandle(cda4706963b5b94cc26d866126dd86f9c.cc1720d05c75832f704b87474932341c3())) as TextAsset;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNode xmlNode = xmlDocument.GetElementsByTagName("States")[0];
		IEnumerator enumerator = xmlNode.ChildNodes.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode2 = (XmlNode)enumerator.Current;
				string value = xmlNode2.Attributes["Name"].Value;
				int c3fcc88d8d4eb4cb2ef35bc2cf9400f = int.Parse(xmlNode2.Attributes["Priority"].Value);
				bool c0c4c3fb11e61c11259fdb0d = bool.Parse(xmlNode2.Attributes["Override"].Value);
				m_infos.Add(value, new PriorityInfo(c3fcc88d8d4eb4cb2ef35bc2cf9400f, c0c4c3fb11e61c11259fdb0d));
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						goto end_IL_0125;
					}
					continue;
					end_IL_0125:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
	}
}
