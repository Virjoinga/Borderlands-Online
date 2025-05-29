using A;
using UnityEngine;

public class SkagAnimationManagerFSM : NPCAnimationManagerFSM
{
	public string m_onSpotJumpParticleName;

	public bool m_bReadyToSpitball;

	public override void Start()
	{
		base.Start();
		m_movementSync = GetComponent<MovementSync>();
		m_isHumanoid = false;
		m_deathLayer = 1;
		m_bReadyToSpitball = false;
		m_animEventHandlerList.Add("SpitBall", OnSpitBall);
		m_animEventHandlerList.Add("MeleeHit", base.OnMeleeHit);
	}

	public void OnSpitBall()
	{
		m_bReadyToSpitball = true;
	}

	public override GameObject caa7c42ac554726b9f073f5a59404e5b5()
	{
		if (!m_bReadyToSpitball)
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
					return null;
				}
			}
		}
		cb082f0bd0e14bac93e6ee86bb882c71d(ENPCParticleType.E_DamageSpitAtMouth, m_skeleton.cb2362c81dda995fcf817a341a4eb3ffb());
		GameObject gameObject = Object.Instantiate(GetComponent<EntityNpc>().m_spawnObjPrefab, m_skeleton.cb2362c81dda995fcf817a341a4eb3ffb().position + base.gameObject.transform.forward * 0.3f, Quaternion.identity) as GameObject;
		if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_bReadyToSpitball = false;
		}
		return gameObject;
	}
}
