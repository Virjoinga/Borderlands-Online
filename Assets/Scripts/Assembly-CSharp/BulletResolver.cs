using A;
using UnityEngine;

public class BulletResolver : Arbitrator.ArbitratorClient, IAttackResolver
{
	private DamageManager m_damageManager;

	public void OnArbitrated(Arbitrator.ArbitrableData data)
	{
		HitInfo cab3b059ef8d7994c0474c0fc10a08d = data as HitInfo;
		m_damageManager.cf0cf12bb1103f08c7a5d05618e0f8781(cab3b059ef8d7994c0474c0fc10a08d, true);
	}

	public void c6b07e4a0d8f8da69884b36612d555842(AttackInfo c00bb86ffbeb6764fbe60d7b64859db7f)
	{
		if (m_damageManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_damageManager = DamageManager.c5ee19dc8d4cccf5ae2de225410458b86;
		}
		Entity c0402779363a90fb1388693c197ee744a = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c00bb86ffbeb6764fbe60d7b64859db7f.m_owner);
		Entity entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c00bb86ffbeb6764fbe60d7b64859db7f.m_attacker);
		if (!(m_damageManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.ccea6604e5df6fe408bddcb2ff37758ef(c00bb86ffbeb6764fbe60d7b64859db7f);
			HitInfo c7088de59e49f7108f520cf7e0bae167e = c0ef4be8da673190f8f6a7aad2ffe88c5.c7088de59e49f7108f520cf7e0bae167e;
			Collider c5c049386ad279173b227358fda3eaaf = cba31495600bcc560b910fdfa4123ae28.c7088de59e49f7108f520cf7e0bae167e;
			float c85645ac328a4c6e6c17d3da3be1e11f = float.MaxValue;
			Entity entity2 = TargetingService.cdb2b353157196638ba0e612861776113(c00bb86ffbeb6764fbe60d7b64859db7f.m_origin, c00bb86ffbeb6764fbe60d7b64859db7f.m_direction, c0402779363a90fb1388693c197ee744a, out c5c049386ad279173b227358fda3eaaf, ref c85645ac328a4c6e6c17d3da3be1e11f);
			if (!(entity2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!entity2.m_bCanReceiveShootDamage)
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
				c7088de59e49f7108f520cf7e0bae167e = new HitInfo();
				c7088de59e49f7108f520cf7e0bae167e.m_from = c00bb86ffbeb6764fbe60d7b64859db7f.m_attacker;
				c7088de59e49f7108f520cf7e0bae167e.m_owner = c00bb86ffbeb6764fbe60d7b64859db7f.m_owner;
				c7088de59e49f7108f520cf7e0bae167e.m_to = entity2.cc7403315505256d19a7b92aa614a8f10();
				c7088de59e49f7108f520cf7e0bae167e.m_timeStamp = c00bb86ffbeb6764fbe60d7b64859db7f.m_timeStamp;
				c7088de59e49f7108f520cf7e0bae167e.m_distance = c85645ac328a4c6e6c17d3da3be1e11f;
				c7088de59e49f7108f520cf7e0bae167e.m_rayOrigin = c00bb86ffbeb6764fbe60d7b64859db7f.m_origin;
				c7088de59e49f7108f520cf7e0bae167e.m_rayDirection = c00bb86ffbeb6764fbe60d7b64859db7f.m_direction * DamageForceFactor.c7018363381b768b9669018477728bc48(c00bb86ffbeb6764fbe60d7b64859db7f, c85645ac328a4c6e6c17d3da3be1e11f);
				c7088de59e49f7108f520cf7e0bae167e.m_damagePoint = c00bb86ffbeb6764fbe60d7b64859db7f.m_damagePoint;
				c7088de59e49f7108f520cf7e0bae167e.m_attackSubType = c00bb86ffbeb6764fbe60d7b64859db7f.m_subType;
				c7088de59e49f7108f520cf7e0bae167e.m_elementalType = entity.c338e1019b68c1ba415414bd8d6cd4cae();
				WeakPoint component = c5c049386ad279173b227358fda3eaaf.gameObject.GetComponent<WeakPoint>();
				if ((bool)component)
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
					c7088de59e49f7108f520cf7e0bae167e.m_weakPointIndex = entity2.c63f8f07320313ddc4213cb59ee025962().cb74e05c70b659a8c77daaa12fcbf3a74(component);
				}
				c06ca0e618478c23eba3419653a19760f<Arbitrator>.c5ee19dc8d4cccf5ae2de225410458b86.c8c74afb1815288ac458f6f092fe723d9(this, c7088de59e49f7108f520cf7e0bae167e);
				return;
			}
		}
	}
}
