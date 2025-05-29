using A;
using UnityEngine;

public class AnimationCombatSpawnState : AnimationManagerState
{
	private const string SPAWN_TAG = "CombatSpawn";

	public ECombatSpawnStep m_spawnStep;

	public bool m_colliderTriggered;

	public float m_walkAfterSpawnTime = 0.5f;

	public float m_moveSpeed;

	private float m_startTime;

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_AnimationManagerFSM.m_isHumanoid)
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
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCasual", false);
			}
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fMoveSpeed", m_moveSpeed);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMove", true);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("FaceAngle", 0f);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsMoveBackward", false);
		}
		m_AnimationManagerFSM.m_validateNextMovePosition = false;
		m_spawnStep = ECombatSpawnStep.WalkBeforeSpawn;
		m_colliderTriggered = false;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_spawnStep == ECombatSpawnStep.WalkBeforeSpawn)
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
					if (c2e1ae09c9380e41cbb7d5735a884f922(m_AnimationManagerFSM.transform.position))
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								m_spawnStep = ECombatSpawnStep.WalkAfterSpawn;
								m_startTime = Time.time;
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (m_spawnStep != ECombatSpawnStep.WalkAfterSpawn)
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			if (!(Time.time - m_startTime >= m_walkAfterSpawnTime))
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
				base.m_status = AnimationStatus.SUCCESS;
				return;
			}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		m_AnimationManagerFSM.m_validateNextMovePosition = true;
	}
}
