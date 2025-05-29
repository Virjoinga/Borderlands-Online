using System;
using System.Collections.Generic;
using A;
using UnityEngine;

[ExecuteInEditMode]
public class UniqueAudioObjectRegistry : AudioSubsystem
{
	private Dictionary<Guid, UniqueAudioObject> m_registry = new Dictionary<Guid, UniqueAudioObject>();

	protected override bool c636d1ce20de5e9ba30d812014e152d16()
	{
		return true;
	}

	protected override void cb14749be8b076f79fe42c8d8bee20c8a()
	{
	}

	public void c57e4d4cd41f3be21d7e24a71aa08c6ba(UniqueAudioObject cebae66039aadeac8deb1211786332a72)
	{
		m_registry.Add(cebae66039aadeac8deb1211786332a72.guid, cebae66039aadeac8deb1211786332a72);
	}

	public void cf5212e6903ec0c0b27816142c32a2d13(UniqueAudioObject cebae66039aadeac8deb1211786332a72)
	{
		m_registry.Remove(cebae66039aadeac8deb1211786332a72.guid);
	}

	public UniqueAudioObject c46866321e1bfdadef76a61d0eed2c438(Guid c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		UniqueAudioObject result = cbdac26f5e66c0e85d2536f012c837e75.c7088de59e49f7108f520cf7e0bae167e;
		if (m_registry.ContainsKey(c35f98ccbfa8c6bf09319c620b21b5dc5))
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
			result = m_registry[c35f98ccbfa8c6bf09319c620b21b5dc5];
		}
		return result;
	}
}
