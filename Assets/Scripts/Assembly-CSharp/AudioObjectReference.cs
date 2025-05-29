using System;
using A;
using Core;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class AudioObjectReference<T> : GuidObject where T : UniqueAudioObject
{
	private T m_target;

	public void cd232ee5f717924fbbb159f559bf8ed59(T c82fcbab5e578dc3a31c1f662916bd87e)
	{
		if (c82fcbab5e578dc3a31c1f662916bd87e != null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c38b0293f2e32959475dd3d81f2e1822a(c82fcbab5e578dc3a31c1f662916bd87e.guid);
		}
		else
		{
			c153e3da90824ccc888fff1572e1bb344();
		}
		m_target = c82fcbab5e578dc3a31c1f662916bd87e;
	}

	public void Reset()
	{
		c153e3da90824ccc888fff1572e1bb344();
		m_target = (T)null;
	}

	public T c588e7dbcd383d8230b2d83d7b44af23b()
	{
		if (!c943bc6a18586b3e0e6f0214717aca479())
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
					return (T)null;
				}
			}
		}
		if (m_target == null)
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
			if (cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c26971795b1d653dc38ca5b626df5799a == null)
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
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Audio System registry not available while trying to fetch audio object with id: " + base.guid);
			}
			else
			{
				UniqueAudioObject uniqueAudioObject = cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c26971795b1d653dc38ca5b626df5799a.c46866321e1bfdadef76a61d0eed2c438(base.guid);
				m_target = uniqueAudioObject as T;
			}
		}
		return m_target;
	}
}
