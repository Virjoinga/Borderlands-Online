using System;
using Core;
using UnityEngine;

[Serializable]
public class ValueHolder<T>
{
	public EParameterValueType m_type;

	public T m_value = default(T);

	[SerializeField]
	private UnityEngine.Object m_target;

	[SerializeField]
	private string m_method;

	protected Func<T> m_resolvedMethod;

	public UnityEngine.Object DynamicTarget
	{
		get
		{
			return m_target;
		}
		set
		{
			m_target = value;
			cad98c9e22c3ac35759098d9ae5ccc347();
		}
	}

	public string DynamicMethodName
	{
		get
		{
			return m_method;
		}
		set
		{
			m_method = value;
			cad98c9e22c3ac35759098d9ae5ccc347();
		}
	}

	private bool cad98c9e22c3ac35759098d9ae5ccc347()
	{
		if (!(null == m_target))
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
			if (!string.IsNullOrEmpty(m_method))
			{
				m_resolvedMethod = DynamicValueHelper<T>.cbbd483c23cdc95cb8bf738e3ce780729(m_target, m_method);
				goto IL_005e;
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
		m_resolvedMethod = null;
		goto IL_005e;
		IL_005e:
		return null != m_resolvedMethod;
	}

	public void c027d356075f5ffe51097f553637ef8df()
	{
		if (m_type != EParameterValueType.Dynamic)
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
			if (cad98c9e22c3ac35759098d9ae5ccc347())
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
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "failed resolving dynamic parameter value accessor");
				m_type = EParameterValueType.Static;
				return;
			}
		}
	}

	public T c4e0f63f4b4d409c5e3992c71520e30a0()
	{
		EParameterValueType type = m_type;
		if (type != 0)
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
					if (type != EParameterValueType.Dynamic)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								throw new NotImplementedException();
							}
						}
					}
					return m_resolvedMethod();
				}
			}
		}
		return m_value;
	}
}
