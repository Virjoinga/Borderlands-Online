using A;
using UnityEngine;

public class AnimationAdvanceSpawnState : AnimationManagerState
{
	public enum EAdvanceSpawnStep
	{
		Disabled = 0,
		WalkForward = 1,
		LiftCurtain = 2
	}

	private const string SPAWN_TAG = "AdvacneSpawn";

	private float m_walkOnNavMeshDuration;

	private bool m_spawnAnimationStarted;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	public EAdvanceSpawnStep m_spawnStep;

	public bool m_colliderTriggered;

	private float m_checkTriggerTime;

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_AnimationManagerFSM.m_isHumanoid)
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
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCasual", true);
			}
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fMoveSpeed", 1f);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMove", true);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("FaceAngle", 0f);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsMoveBackward", false);
		}
		m_spawnAnimationStarted = false;
		m_AnimationManagerFSM.m_validateNextMovePosition = false;
		base.m_status = AnimationStatus.RUNNING;
		m_spawnStep = EAdvanceSpawnStep.WalkForward;
		m_colliderTriggered = false;
		m_walkOnNavMeshDuration = 0.3f;
		m_checkTriggerTime = 0f;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (base.m_status == AnimationStatus.SUCCESS)
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
		if (m_spawnStep == EAdvanceSpawnStep.WalkForward)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (m_AnimationManagerFSM.m_isHumanoid)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								m_checkTriggerTime += Time.deltaTime;
								if (!m_colliderTriggered)
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
									if (!(m_checkTriggerTime > 2.5f))
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
										break;
									}
								}
								m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsLiftCurtain", true);
								m_spawnStep = EAdvanceSpawnStep.LiftCurtain;
								return;
							}
						}
					}
					if (c2e1ae09c9380e41cbb7d5735a884f922(m_AnimationManagerFSM.transform.position))
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								m_walkOnNavMeshDuration -= Time.deltaTime;
								if (m_walkOnNavMeshDuration <= 0f)
								{
									while (true)
									{
										switch (7)
										{
										case 0:
											break;
										default:
											base.m_status = AnimationStatus.SUCCESS;
											return;
										}
									}
								}
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (m_spawnStep != EAdvanceSpawnStep.LiftCurtain)
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
			m_animatorInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0);
			if (m_spawnAnimationStarted)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.98f))
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
							if (m_animatorInfo.IsTag("AdvacneSpawn"))
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
								break;
							}
						}
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsLiftCurtain", false);
						base.m_status = AnimationStatus.SUCCESS;
						return;
					}
				}
			}
			if (!m_animatorInfo.IsTag("AdvacneSpawn"))
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
				m_spawnAnimationStarted = true;
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsLiftCurtain", false);
				m_startTime = m_animatorInfo.normalizedTime;
				return;
			}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		if (m_AnimationManagerFSM.m_isHumanoid)
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsLiftCurtain", false);
		}
		m_AnimationManagerFSM.m_validateNextMovePosition = true;
		base.m_status = AnimationStatus.SUCCESS;
	}
}
