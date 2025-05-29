using System;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

[AddComponentMenu("Audio/Audio ParameterValues")]
public class AudioParameterValues : MonoBehaviour
{
	public AudioParameterValues m_delegate;

	public bool m_resolveCycleGuard;

	public RTPCValue[] m_rtpcValues;

	private Dictionary<Guid, RTPCValue> m_rtpcValueMap = new Dictionary<Guid, RTPCValue>();

	public SwitchValue[] m_switchValues;

	private Dictionary<Guid, SwitchValue> m_switchValueMap = new Dictionary<Guid, SwitchValue>();

	private void cf01ccb4f45a31bb119ab3c43a3084644()
	{
		m_rtpcValueMap.Clear();
		if (m_rtpcValues != null)
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
			for (int i = 0; i < m_rtpcValues.Length; i++)
			{
				RTPCValue rTPCValue = m_rtpcValues[i];
				m_rtpcValueMap.Add(rTPCValue.m_rtpc.guid, rTPCValue);
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
		m_switchValueMap.Clear();
		if (m_switchValues == null)
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
			for (int j = 0; j < m_switchValues.Length; j++)
			{
				SwitchValue switchValue = m_switchValues[j];
				if (switchValue == null)
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
					m_switchValueMap.Add(switchValue.m_switch.guid, switchValue);
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
	}

	private void c8d96c2b6220153cec544b80badc2857e()
	{
		if (m_rtpcValues != null)
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
			for (int i = 0; i < m_rtpcValues.Length; i++)
			{
				m_rtpcValues[i].c027d356075f5ffe51097f553637ef8df();
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
		if (m_switchValues == null)
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
			for (int j = 0; j < m_switchValues.Length; j++)
			{
				m_switchValues[j].c027d356075f5ffe51097f553637ef8df();
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
	}

	protected void Awake()
	{
		cf01ccb4f45a31bb119ab3c43a3084644();
	}

	protected void Start()
	{
		c8d96c2b6220153cec544b80badc2857e();
	}

	private RTPCValue c3dd589b17fd6f22ea92ed29569ead28c(AudioRTPCDefinition cd4a0f7761e48cb8f77e54d4cfa88e83b)
	{
		RTPCValue value = cab3957f850940a20709004d971edb0a0.c7088de59e49f7108f520cf7e0bae167e;
		if (!m_rtpcValueMap.TryGetValue(cd4a0f7761e48cb8f77e54d4cfa88e83b.guid, out value))
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
			value = new RTPCValue();
			value.m_rtpc.cd232ee5f717924fbbb159f559bf8ed59(cd4a0f7761e48cb8f77e54d4cfa88e83b);
			c38445b09c040ca07e40420956f29582f(value);
		}
		return value;
	}

	private void c38445b09c040ca07e40420956f29582f(RTPCValue cf33639188d22b78126fbeb0744fd1f05)
	{
		RTPCValue[] array = c511ef2604193cd4ea5b892966576d006.c0a0cdf4a196914163f7334d9b0781a04(m_rtpcValues.Length + 1);
		Array.Copy(m_rtpcValues, array, m_rtpcValues.Length);
		m_rtpcValues = array;
		m_rtpcValueMap.Add(cf33639188d22b78126fbeb0744fd1f05.m_rtpc.guid, cf33639188d22b78126fbeb0744fd1f05);
	}

	public void c7abcd8e1dac947affc4d7e0c4f0c5f15(AudioRTPCDefinition cd4a0f7761e48cb8f77e54d4cfa88e83b, float c8f6f53ee3b51a3ea94ddedc3968eef91)
	{
		RTPCValue rTPCValue = c3dd589b17fd6f22ea92ed29569ead28c(cd4a0f7761e48cb8f77e54d4cfa88e83b);
		rTPCValue.m_type = EParameterValueType.Static;
		rTPCValue.m_value = c8f6f53ee3b51a3ea94ddedc3968eef91;
	}

	public void cdb3c79ab1bbbee4838514dd518876277(AudioRTPCDefinition cd4a0f7761e48cb8f77e54d4cfa88e83b, UnityEngine.Object c82fcbab5e578dc3a31c1f662916bd87e, string ca57789de86459caf1b0cd284afe32a38)
	{
		RTPCValue rTPCValue = c3dd589b17fd6f22ea92ed29569ead28c(cd4a0f7761e48cb8f77e54d4cfa88e83b);
		rTPCValue.m_type = EParameterValueType.Dynamic;
		rTPCValue.DynamicTarget = c82fcbab5e578dc3a31c1f662916bd87e;
		rTPCValue.DynamicMethodName = ca57789de86459caf1b0cd284afe32a38;
	}

	public bool c4e0f63f4b4d409c5e3992c71520e30a0(AudioRTPCDefinition cd4a0f7761e48cb8f77e54d4cfa88e83b, out float c8f6f53ee3b51a3ea94ddedc3968eef91)
	{
		bool flag = false;
		if (!m_resolveCycleGuard)
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
			flag = c52a1c07feaf1a92ed5e66ddb4a0c2d4d(cd4a0f7761e48cb8f77e54d4cfa88e83b, out c8f6f53ee3b51a3ea94ddedc3968eef91);
			if (!flag)
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
				if (null != m_delegate)
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
					m_resolveCycleGuard = true;
					flag = m_delegate.c4e0f63f4b4d409c5e3992c71520e30a0(cd4a0f7761e48cb8f77e54d4cfa88e83b, out c8f6f53ee3b51a3ea94ddedc3968eef91);
					m_resolveCycleGuard = false;
				}
				else
				{
					AudioParameterValues ca32cea5690944ab3b10bc11ad74a0cc = cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.ca32cea5690944ab3b10bc11ad74a0cc7;
					if (null != ca32cea5690944ab3b10bc11ad74a0cc)
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
						if (this != ca32cea5690944ab3b10bc11ad74a0cc)
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
							flag = ca32cea5690944ab3b10bc11ad74a0cc.c4e0f63f4b4d409c5e3992c71520e30a0(cd4a0f7761e48cb8f77e54d4cfa88e83b, out c8f6f53ee3b51a3ea94ddedc3968eef91);
						}
					}
				}
			}
		}
		else
		{
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Resolve cycle when trying to get RTPC: " + cd4a0f7761e48cb8f77e54d4cfa88e83b.Name + " @: " + Utils.c6623cde42db4307c0b144942a5a8c70d(base.gameObject));
			c8f6f53ee3b51a3ea94ddedc3968eef91 = 0f;
		}
		return flag;
	}

	private bool c52a1c07feaf1a92ed5e66ddb4a0c2d4d(AudioRTPCDefinition cd4a0f7761e48cb8f77e54d4cfa88e83b, out float c8f6f53ee3b51a3ea94ddedc3968eef91)
	{
		RTPCValue value;
		bool flag = m_rtpcValueMap.TryGetValue(cd4a0f7761e48cb8f77e54d4cfa88e83b.guid, out value);
		if (flag)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c8f6f53ee3b51a3ea94ddedc3968eef91 = value.c4e0f63f4b4d409c5e3992c71520e30a0();
		}
		else
		{
			c8f6f53ee3b51a3ea94ddedc3968eef91 = 0f;
		}
		return flag;
	}

	private SwitchValue c8084bb63b6df39d07d3197c47d94998e(AudioSwitch c911ada89452184b31d186c26c1fc6ada)
	{
		SwitchValue value = c4e8b84f317d6b51b61d5b15684bcce51.c7088de59e49f7108f520cf7e0bae167e;
		if (!m_switchValueMap.TryGetValue(c911ada89452184b31d186c26c1fc6ada.guid, out value))
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
			value = new SwitchValue();
			value.m_switch.cd232ee5f717924fbbb159f559bf8ed59(c911ada89452184b31d186c26c1fc6ada);
			c3d5018168fb104d7ea2e148a93e3ae35(value);
		}
		return value;
	}

	private void c3d5018168fb104d7ea2e148a93e3ae35(SwitchValue cf33639188d22b78126fbeb0744fd1f05)
	{
		if (m_switchValueMap.ContainsKey(cf33639188d22b78126fbeb0744fd1f05.m_switch.guid))
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
		int num;
		if (m_switchValues != null)
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
			num = m_switchValues.Length;
		}
		else
		{
			num = 0;
		}
		int num2 = num;
		SwitchValue[] array = c0fe6c69ad18a9b3524ecf8557c496342.c0a0cdf4a196914163f7334d9b0781a04(num2 + 1);
		array[num2] = cf33639188d22b78126fbeb0744fd1f05;
		if (0 < num2)
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
			Array.Copy(m_switchValues, array, m_switchValues.Length);
		}
		m_switchValues = array;
		m_switchValueMap.Add(cf33639188d22b78126fbeb0744fd1f05.m_switch.guid, cf33639188d22b78126fbeb0744fd1f05);
	}

	public void c7abcd8e1dac947affc4d7e0c4f0c5f15(AudioSwitch c911ada89452184b31d186c26c1fc6ada, string cbba496e96e28b7629dc91ff46a0a919a)
	{
		SwitchValue switchValue = c8084bb63b6df39d07d3197c47d94998e(c911ada89452184b31d186c26c1fc6ada);
		switchValue.m_type = EParameterValueType.Static;
		switchValue.m_value = cbba496e96e28b7629dc91ff46a0a919a;
	}

	public void cdb3c79ab1bbbee4838514dd518876277(AudioSwitch c911ada89452184b31d186c26c1fc6ada, UnityEngine.Object c82fcbab5e578dc3a31c1f662916bd87e, string ca57789de86459caf1b0cd284afe32a38)
	{
		SwitchValue switchValue = c8084bb63b6df39d07d3197c47d94998e(c911ada89452184b31d186c26c1fc6ada);
		switchValue.m_type = EParameterValueType.Dynamic;
		switchValue.DynamicTarget = c82fcbab5e578dc3a31c1f662916bd87e;
		switchValue.DynamicMethodName = ca57789de86459caf1b0cd284afe32a38;
	}

	public bool c4e0f63f4b4d409c5e3992c71520e30a0(AudioSwitch c911ada89452184b31d186c26c1fc6ada, out string cbba496e96e28b7629dc91ff46a0a919a)
	{
		bool flag = false;
		if (!m_resolveCycleGuard)
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
			flag = c52a1c07feaf1a92ed5e66ddb4a0c2d4d(c911ada89452184b31d186c26c1fc6ada, out cbba496e96e28b7629dc91ff46a0a919a);
			if (!flag)
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
				if (null != m_delegate)
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
					m_resolveCycleGuard = true;
					flag = m_delegate.c4e0f63f4b4d409c5e3992c71520e30a0(c911ada89452184b31d186c26c1fc6ada, out cbba496e96e28b7629dc91ff46a0a919a);
					m_resolveCycleGuard = false;
				}
				else
				{
					AudioParameterValues ca32cea5690944ab3b10bc11ad74a0cc = cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.ca32cea5690944ab3b10bc11ad74a0cc7;
					if (null != ca32cea5690944ab3b10bc11ad74a0cc)
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
						if (this != ca32cea5690944ab3b10bc11ad74a0cc)
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
							flag = ca32cea5690944ab3b10bc11ad74a0cc.c4e0f63f4b4d409c5e3992c71520e30a0(c911ada89452184b31d186c26c1fc6ada, out cbba496e96e28b7629dc91ff46a0a919a);
						}
					}
				}
			}
		}
		else
		{
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Resolve cycle when trying to get Switch: " + c911ada89452184b31d186c26c1fc6ada.Name + " @: " + Utils.c6623cde42db4307c0b144942a5a8c70d(base.gameObject));
			cbba496e96e28b7629dc91ff46a0a919a = null;
		}
		return flag;
	}

	private bool c52a1c07feaf1a92ed5e66ddb4a0c2d4d(AudioSwitch c911ada89452184b31d186c26c1fc6ada, out string cbba496e96e28b7629dc91ff46a0a919a)
	{
		bool result = false;
		cbba496e96e28b7629dc91ff46a0a919a = string.Empty;
		SwitchValue value;
		if (m_switchValueMap.TryGetValue(c911ada89452184b31d186c26c1fc6ada.guid, out value))
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
			string text = value.c4e0f63f4b4d409c5e3992c71520e30a0();
			if (text == null)
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
			}
			else if (c911ada89452184b31d186c26c1fc6ada.c921dfdab73e4f5bfaecc185c5b6359ff(text))
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
				cbba496e96e28b7629dc91ff46a0a919a = text;
				result = true;
			}
			else
			{
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Audio Switch: " + c911ada89452184b31d186c26c1fc6ada.Name + " doesn't define a case for value: " + text);
			}
		}
		return result;
	}
}
