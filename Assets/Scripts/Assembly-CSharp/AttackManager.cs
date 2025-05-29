using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using XsdSettings;

public class AttackManager : c06ca0e618478c23eba3419653a19760f<AttackManager>
{
	private BulletResolver m_bulletResolver = new BulletResolver();

	private Dictionary<double, List<AttackInfo>> m_attacInfoDic = new Dictionary<double, List<AttackInfo>>();

	[CompilerGenerated]
	private static Func<KeyValuePair<double, List<AttackInfo>>, double> _003C_003Ef__am_0024cache2;

	public void c6c6cbb0045146f9b0a890f787bad6e4d()
	{
		Dictionary<double, List<AttackInfo>> attacInfoDic = m_attacInfoDic;
		if (_003C_003Ef__am_0024cache2 == null)
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
			_003C_003Ef__am_0024cache2 = (KeyValuePair<double, List<AttackInfo>> c872943035f78644fd01b267deff00547) => c872943035f78644fd01b267deff00547.Key;
		}
		IEnumerator<KeyValuePair<double, List<AttackInfo>>> enumerator = attacInfoDic.OrderBy(_003C_003Ef__am_0024cache2).GetEnumerator();
		while (enumerator.MoveNext())
		{
			List<AttackInfo> value = enumerator.Current.Value;
			for (int i = 0; i < value.Count; i++)
			{
				AttackInfo attackInfo = value[i];
				if (attackInfo.c070529b1f39068ce13a5e9ed5c480b92() == AttackInfo.AttackType.Projectile)
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
					if (attackInfo.m_subType != AttackSubType.ProjectileSpit)
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
						if (attackInfo.m_subType == AttackSubType.ProjectileAxe)
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
						}
						else
						{
							m_bulletResolver.c6b07e4a0d8f8da69884b36612d555842(attackInfo);
						}
					}
				}
				if (attackInfo.c070529b1f39068ce13a5e9ed5c480b92() != AttackInfo.AttackType.Skill)
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
				m_bulletResolver.c6b07e4a0d8f8da69884b36612d555842(attackInfo);
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
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			m_attacInfoDic.Clear();
			return;
		}
	}

	public void c6b07e4a0d8f8da69884b36612d555842(AttackInfo c2651896b265273fbec506b1fb5f97c6e)
	{
		if (!m_attacInfoDic.ContainsKey(c2651896b265273fbec506b1fb5f97c6e.m_timeStamp))
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
			m_attacInfoDic[c2651896b265273fbec506b1fb5f97c6e.m_timeStamp] = new List<AttackInfo>();
		}
		m_attacInfoDic[c2651896b265273fbec506b1fb5f97c6e.m_timeStamp].Add(c2651896b265273fbec506b1fb5f97c6e);
	}

	[CompilerGenerated]
	private static double c5da65449a665ebcc9b642ba9cb815895(KeyValuePair<double, List<AttackInfo>> c872943035f78644fd01b267deff00547)
	{
		return c872943035f78644fd01b267deff00547.Key;
	}
}
