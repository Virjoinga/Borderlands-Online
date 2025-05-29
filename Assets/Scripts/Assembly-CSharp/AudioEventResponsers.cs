using System.Collections.Generic;
using Core;
using UnityEngine;

[ExecuteInEditMode]
public abstract class AudioEventResponsers : AudioEventResponser
{
	public List<AudioEventResponser> m_responsers;

	protected BaseEventResponser m_currentResponser;

	protected int m_currentIndex = -1;

	public override void Awake()
	{
		cc0bd83b8979d14808e2fb0312dadb1d2();
		m_responsers = new List<AudioEventResponser>();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			AudioEventResponser component = base.transform.GetChild(i).GetComponent<AudioEventResponser>();
			m_responsers.Add(component);
			if (!m_audioTemplate)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			component.m_audioTemplate = m_audioTemplate;
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			if (m_responsers.Count <= 0)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "Audio event responsers missing");
						return;
					}
				}
			}
			m_currentResponser = m_responsers[0];
			return;
		}
	}

	public override void caf18a168df80e6ec094fac2d4a6b3c2c(RandomGenerator c4e92c721e96d4bb1b50291f9c471cee2)
	{
		base.caf18a168df80e6ec094fac2d4a6b3c2c(c4e92c721e96d4bb1b50291f9c471cee2);
		for (int i = 0; i < m_responsers.Count; i++)
		{
			m_responsers[i].caf18a168df80e6ec094fac2d4a6b3c2c(c4e92c721e96d4bb1b50291f9c471cee2);
		}
		while (true)
		{
			switch (3)
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

	public override void ccc9d3a38966dc10fedb531ea17d24611()
	{
		base.ccc9d3a38966dc10fedb531ea17d24611();
		if (!(null != m_currentResponser))
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
			m_currentResponser.ccc9d3a38966dc10fedb531ea17d24611();
			return;
		}
	}

	public override void c0a75d7afd2f7f1e47a5aadaab61303c7()
	{
		if (!(null != m_currentResponser))
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
			m_currentResponser.c0a75d7afd2f7f1e47a5aadaab61303c7();
			return;
		}
	}

	public override void c0a75d7afd2f7f1e47a5aadaab61303c7(float cb17344c6ba6038b9297f344b2472c2f5)
	{
		if (!(null != m_currentResponser))
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
			m_currentResponser.c0a75d7afd2f7f1e47a5aadaab61303c7(cb17344c6ba6038b9297f344b2472c2f5);
			return;
		}
	}

	public override bool cb9efc4af2006b47000b468b9df139a30()
	{
		if (null != m_currentResponser)
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
					return m_currentResponser.cb9efc4af2006b47000b468b9df139a30();
				}
			}
		}
		return false;
	}

	public override void c4207787d36579661719681a2d411dede()
	{
		if (!(null != m_currentResponser))
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
			m_currentResponser.c4207787d36579661719681a2d411dede();
			return;
		}
	}

	public override void ccd732382db3f35031907fee9ca4c7dfc(bool c0c5a5a34f77f86de88b9a3c43d8f76fc = false)
	{
		if (!(null != m_currentResponser))
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
			m_currentResponser.ccd732382db3f35031907fee9ca4c7dfc(c0c5a5a34f77f86de88b9a3c43d8f76fc);
			return;
		}
	}

	public override void cdada4c3678c9c23c38aaf0754a94a620()
	{
		if (!(null != m_currentResponser))
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
			m_currentResponser.cdada4c3678c9c23c38aaf0754a94a620();
			return;
		}
	}

	public override bool cc56123259c44174bf6c32d225c07c313()
	{
		if (null != m_currentResponser)
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
					return m_currentResponser.cc56123259c44174bf6c32d225c07c313();
				}
			}
		}
		return true;
	}

	public override void c364ecb1e3f2cafa6e8793178cfbd2327(float cf1fc845d0d1ce740b7de3654160c1cc5, float cb17344c6ba6038b9297f344b2472c2f5 = 0f, bool c41a65acdc6feabec040241b1170d6b34 = true)
	{
		if (!(null != m_currentResponser))
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
			m_currentResponser.c364ecb1e3f2cafa6e8793178cfbd2327(cf1fc845d0d1ce740b7de3654160c1cc5, cb17344c6ba6038b9297f344b2472c2f5, c41a65acdc6feabec040241b1170d6b34);
			return;
		}
	}

	public override void cadd9bee93ecf3ad1c30c38c48b9a22ef(float cf1fc845d0d1ce740b7de3654160c1cc5)
	{
		if (!(null != m_currentResponser))
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
			m_currentResponser.cadd9bee93ecf3ad1c30c38c48b9a22ef(cf1fc845d0d1ce740b7de3654160c1cc5);
			return;
		}
	}
}
