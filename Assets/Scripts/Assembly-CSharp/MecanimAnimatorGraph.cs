using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using A;
using UnityEngine;

public class MecanimAnimatorGraph
{
	public class MecanimAnimatorNode
	{
		public string m_parameter;

		public string m_tag;

		public int m_priority;

		public float m_ExitTime;

		public MecanimAnimatorNode(string ccd4c4d1bf19201b655f7340c8aeada4a, string c48a1f5a040a419463768e79ec76c00e4, int c3fcc88d8d4eb4cb2ef35bc2cf9400f43, float c11a5fef1b28b92dc6bc1f6c4240cb2b2)
		{
			m_parameter = ccd4c4d1bf19201b655f7340c8aeada4a;
			m_tag = c48a1f5a040a419463768e79ec76c00e4;
			m_priority = c3fcc88d8d4eb4cb2ef35bc2cf9400f43;
			m_ExitTime = c11a5fef1b28b92dc6bc1f6c4240cb2b2;
		}
	}

	public Dictionary<int, MecanimAnimatorNode> m_Nodes = new Dictionary<int, MecanimAnimatorNode>();

	private List<string> m_parameterNameList = new List<string>();

	private PlayerThirdPersonAnimationManagerFSM m_Owner;

	private MecanimAnimationID m_inner_currentAnimationID = MecanimAnimationID.ID_1st_SwitchUp;

	private float m_startTime = -1f;

	private int m_recoilExitTick;

	private MecanimAnimationID c910a56a3683716657b8a5f880908d559
	{
		get
		{
			return m_inner_currentAnimationID;
		}
		set
		{
			m_inner_currentAnimationID = value;
			m_startTime = -1f;
		}
	}

	public MecanimAnimatorGraph(PlayerThirdPersonAnimationManagerFSM cf811c0d5de19d7fe22be8d61350b722d)
	{
		m_Owner = cf811c0d5de19d7fe22be8d61350b722d;
		c3fbcd84a491944d7864e62b7fd1ec32c();
	}

	public void c979843b9afa58b1781f5d83769d1e4fb(MecanimAnimationID cbd26e39b8b1d5b0abffedcac5d1ecc8f)
	{
		if (cbd26e39b8b1d5b0abffedcac5d1ecc8f == c910a56a3683716657b8a5f880908d559)
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
			if (cbd26e39b8b1d5b0abffedcac5d1ecc8f != MecanimAnimationID.ID_1st_CrouchIdle)
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
				if (cbd26e39b8b1d5b0abffedcac5d1ecc8f != 0)
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
			}
		}
		if (c9f0427d35dc233bd7b8a42190cf6c521(cbd26e39b8b1d5b0abffedcac5d1ecc8f) >= c9f0427d35dc233bd7b8a42190cf6c521(c910a56a3683716657b8a5f880908d559))
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
			cb6ddb86ff592b855d40e4b6baac609bf();
			m_Owner.m_firstPersonAnimator.SetBool(m_Nodes[(int)cbd26e39b8b1d5b0abffedcac5d1ecc8f].m_parameter, true);
			c910a56a3683716657b8a5f880908d559 = cbd26e39b8b1d5b0abffedcac5d1ecc8f;
		}
		if (c9f0427d35dc233bd7b8a42190cf6c521(cbd26e39b8b1d5b0abffedcac5d1ecc8f) < 4)
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
			c85bc252ea47ef21d952c7680c77b6321(true);
			return;
		}
	}

	private void c85bc252ea47ef21d952c7680c77b6321(bool c6bd29844a2f49ffb6e2cba8f1433b4ed)
	{
		if (c6bd29844a2f49ffb6e2cba8f1433b4ed)
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
					m_Owner.m_firstPersonAnimator.SetBool("bFire", false);
					m_Owner.m_firstPersonAnimator.SetBool("bRecoilExit_1st", true);
					m_recoilExitTick = Time.frameCount;
					return;
				}
			}
		}
		if (!m_Owner.m_firstPersonAnimator.GetBool("bRecoilExit_1st"))
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
			if (Time.frameCount - m_recoilExitTick <= 3)
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
				m_Owner.m_firstPersonAnimator.SetBool("bRecoilExit_1st", false);
				return;
			}
		}
	}

	public void c21f4463c05bd3111b521d9507363eba0(MecanimAnimationID cbd26e39b8b1d5b0abffedcac5d1ecc8f)
	{
		if (cbd26e39b8b1d5b0abffedcac5d1ecc8f != c910a56a3683716657b8a5f880908d559)
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
					return;
				}
			}
		}
		m_Owner.m_firstPersonAnimator.SetBool(m_Nodes[(int)cbd26e39b8b1d5b0abffedcac5d1ecc8f].m_parameter, false);
		c910a56a3683716657b8a5f880908d559 = MecanimAnimationID.ID_1st_None;
	}

	public void Update()
	{
		if (m_Owner.m_firstPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
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
		if (c4fe348ec0e7367c5a15bd653b3228b12(c910a56a3683716657b8a5f880908d559) > 0f)
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
			AnimatorStateInfo currentAnimatorStateInfo = m_Owner.m_firstPersonAnimator.GetCurrentAnimatorStateInfo(0);
			if (!currentAnimatorStateInfo.IsTag(c81b228adfe8362430fe9aec83dee1f07(c910a56a3683716657b8a5f880908d559)))
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
			if (m_startTime < 0f)
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
				m_startTime = currentAnimatorStateInfo.normalizedTime;
			}
			if (currentAnimatorStateInfo.normalizedTime < 1f)
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
				if (m_startTime > 1f)
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
					m_startTime = c5254344b462d1a19fa1dc23a74eb8d96(m_startTime);
				}
			}
			if (currentAnimatorStateInfo.normalizedTime >= Mathf.Floor(m_startTime) + c4fe348ec0e7367c5a15bd653b3228b12(c910a56a3683716657b8a5f880908d559))
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
				m_startTime = -1f;
				c910a56a3683716657b8a5f880908d559 = MecanimAnimationID.ID_1st_None;
			}
		}
		c85bc252ea47ef21d952c7680c77b6321(false);
	}

	private void c80d22b2d69ee8405f58e755529177fef(MecanimAnimationID cbd26e39b8b1d5b0abffedcac5d1ecc8f)
	{
		(m_Owner.m_upperBodyStateMachine.m_curState as PlayerAnimationState).OnMecanimAnimOver(cbd26e39b8b1d5b0abffedcac5d1ecc8f);
	}

	public string c81b228adfe8362430fe9aec83dee1f07(MecanimAnimationID cbd26e39b8b1d5b0abffedcac5d1ecc8f)
	{
		if (cbd26e39b8b1d5b0abffedcac5d1ecc8f == MecanimAnimationID.ID_1st_None)
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
					return string.Empty;
				}
			}
		}
		return m_Nodes[(int)cbd26e39b8b1d5b0abffedcac5d1ecc8f].m_tag;
	}

	private int c9f0427d35dc233bd7b8a42190cf6c521(MecanimAnimationID cbd26e39b8b1d5b0abffedcac5d1ecc8f)
	{
		if (cbd26e39b8b1d5b0abffedcac5d1ecc8f == MecanimAnimationID.ID_1st_None)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return -1;
				}
			}
		}
		return m_Nodes[(int)cbd26e39b8b1d5b0abffedcac5d1ecc8f].m_priority;
	}

	private float c4fe348ec0e7367c5a15bd653b3228b12(MecanimAnimationID cbd26e39b8b1d5b0abffedcac5d1ecc8f)
	{
		if (cbd26e39b8b1d5b0abffedcac5d1ecc8f == MecanimAnimationID.ID_1st_None)
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
					return -1f;
				}
			}
		}
		return m_Nodes[(int)cbd26e39b8b1d5b0abffedcac5d1ecc8f].m_ExitTime;
	}

	private void cb6ddb86ff592b855d40e4b6baac609bf()
	{
		Dictionary<int, MecanimAnimatorNode>.Enumerator enumerator = m_Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			m_Owner.m_firstPersonAnimator.SetBool(enumerator.Current.Value.m_parameter, false);
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
			return;
		}
	}

	private void c3fbcd84a491944d7864e62b7fd1ec32c()
	{
		m_Nodes.Clear();
		m_parameterNameList.Clear();
		TextAsset textAsset = Resources.Load("Entities/Player_Mecanim/Config_Animation_Priority", Type.GetTypeFromHandle(cda4706963b5b94cc26d866126dd86f9c.cc1720d05c75832f704b87474932341c3())) as TextAsset;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNode xmlNode = xmlDocument.GetElementsByTagName("Animations")[0];
		IEnumerator enumerator = xmlNode.ChildNodes.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode2 = (XmlNode)enumerator.Current;
				string value = xmlNode2.Attributes["ID"].Value;
				MecanimAnimationID key = (MecanimAnimationID)(int)Enum.Parse(Type.GetTypeFromHandle(c8176fe82a8697420046664740ae333b3.cc1720d05c75832f704b87474932341c3()), value);
				string value2 = xmlNode2.Attributes["Parameter"].Value;
				string value3 = xmlNode2.Attributes["Tag"].Value;
				int c3fcc88d8d4eb4cb2ef35bc2cf9400f = int.Parse(xmlNode2.Attributes["Priority"].Value);
				float c11a5fef1b28b92dc6bc1f6c4240cb2b = float.Parse(xmlNode2.Attributes["ExitTime"].Value);
				m_Nodes.Add((int)key, new MecanimAnimatorNode(value2, value3, c3fcc88d8d4eb4cb2ef35bc2cf9400f, c11a5fef1b28b92dc6bc1f6c4240cb2b));
				m_parameterNameList.Add(value2);
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
					switch (7)
					{
					case 0:
						break;
					default:
						goto end_IL_0199;
					}
					continue;
					end_IL_0199:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	private float c5254344b462d1a19fa1dc23a74eb8d96(float cbcb4d0d61010c5fd365d3732d2205449)
	{
		return cbcb4d0d61010c5fd365d3732d2205449 - Mathf.Floor(cbcb4d0d61010c5fd365d3732d2205449);
	}

	public List<string> c8ce5a230d9f8687db39b5315551900fd()
	{
		return m_parameterNameList;
	}
}
