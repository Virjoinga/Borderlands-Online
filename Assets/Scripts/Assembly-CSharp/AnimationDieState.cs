using A;
using Core;
using UnityEngine;

public class AnimationDieState : AnimationManagerState
{
	private enum EHandleRagdollStep
	{
		None = 0,
		EStart = 1,
		EReadyToComputeVelocity = 2,
		EReadyToSetRigidbody = 3,
		EPlayDeathAnimation = 4,
		EWaitRagdollFallDown = 5
	}

	private const string DEATH_TAG = "Death";

	private const string ZILLA_DEATH_TAG = "DieState";

	private EHandleRagdollStep m_eHandleRagdollStep;

	private bool m_deathAnimationStarted;

	private float m_fDieExitTime;

	public Vector3 m_explosionOrigin;

	public float m_force;

	public AnimationDieState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "Die";
		m_eHandleRagdollStep = EHandleRagdollStep.None;
		m_fDieExitTime = 2f;
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		ce902c639c179f2e78fd1621e43ab4593 = 0f;
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_AnimationManagerFSM.cce25835105f4aac362f76d814881a1e8();
		m_AnimationManagerFSM.m_validateNextMovePosition = false;
		m_AnimationManagerFSM.c4004fed08fd0ad52f8c3b650da10e9cb = false;
		m_eHandleRagdollStep = EHandleRagdollStep.EPlayDeathAnimation;
		m_deathAnimationStarted = false;
		base.m_status = AnimationStatus.RUNNING;
		if (m_AnimationManagerFSM.m_upperBodyStateMachine == null)
		{
			return;
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
			m_AnimationManagerFSM.m_upperBodyStateMachine.c3d651aa95fd9820e9e2c328cc63e13e9("Empty");
			return;
		}
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_eHandleRagdollStep == EHandleRagdollStep.EPlayDeathAnimation)
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
			bool flag = false;
			EntityNpc entityNpc = m_AnimationManagerFSM.m_entity as EntityNpc;
			if (entityNpc.m_subType == EntityNpc.EntitySubType.CHR_CrimsonMechaKnoxx)
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
				flag = m_AnimationManagerFSM.m_setup.m_settings.m_hasDeathAnimation;
			}
			else
			{
				AnimationJumpAttackState animationJumpAttackState = m_AnimationManagerFSM.m_animationStateMachine.m_preState as AnimationJumpAttackState;
				if (m_force < 35f)
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
					if (animationJumpAttackState == null)
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
						flag = m_AnimationManagerFSM.m_setup.m_settings.m_hasDeathAnimation;
					}
				}
				if (m_AnimationManagerFSM.m_rigidbodyTransforms.Count <= 0)
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
					flag = m_AnimationManagerFSM.m_setup.m_settings.m_hasDeathAnimation;
				}
			}
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
				if (m_deathAnimationStarted)
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
					if (m_AnimationManagerFSM.c0682f58328f23f63387e2fc5249a2cba(m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2, m_AnimationManagerFSM.m_deathLayer, "Death", 0.9f) == AnimationStatus.SUCCESS)
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
						m_eHandleRagdollStep = EHandleRagdollStep.EStart;
					}
				}
				else
				{
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsDying", true);
					int num;
					if (m_AnimationManagerFSM.m_setup.m_settings.m_headShotDeathAnimCount > 0)
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
						num = ((m_AnimationManagerFSM.m_damageType == DamageType.Death_Head) ? 1 : 0);
					}
					else
					{
						num = 0;
					}
					bool value = (byte)num != 0;
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bHeadShot", value);
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("iDeathAnimIndex", m_AnimationManagerFSM.m_iDeathAnimIndex);
					m_AnimationManagerFSM.c82680016189694aae7ffda7f93e20c78(1f);
					if (m_AnimationManagerFSM.m_deathLayer >= m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.layerCount)
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
						object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
						array[0] = "invalid death Layer ";
						array[1] = m_AnimationManagerFSM.m_deathLayer;
						array[2] = m_AnimationManagerFSM.gameObject.name;
						array[3] = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.layerCount;
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.AI, string.Concat(array));
					}
					if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(m_AnimationManagerFSM.m_deathLayer).IsTag("Death"))
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
						m_deathAnimationStarted = true;
					}
				}
			}
			else
			{
				m_eHandleRagdollStep = EHandleRagdollStep.EStart;
			}
		}
		if (m_eHandleRagdollStep == EHandleRagdollStep.EStart)
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
			m_AnimationManagerFSM.OnDeath();
			m_AnimationManagerFSM.c33f9c3a5a9687f3762dcd02c6dd2d0e2(RagdollOperationType.Save_Position);
			m_eHandleRagdollStep = EHandleRagdollStep.EReadyToComputeVelocity;
			BaseEventTriggerCtl audioCtl = m_AnimationManagerFSM.m_AudioCtl;
			if ((bool)audioCtl)
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
				if (!m_deathAnimationStarted)
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
					audioCtl.TriggerEventByName("Enemy_NormalDeath");
				}
			}
		}
		if (m_eHandleRagdollStep == EHandleRagdollStep.EReadyToComputeVelocity)
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
			m_AnimationManagerFSM.c2351b5168c48a14c25a733a532f9a41e(false);
			if (m_AnimationManagerFSM.c915fd0f71703e34ea30c40c33035a630 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				SkinnedMeshRenderer component = m_AnimationManagerFSM.c915fd0f71703e34ea30c40c33035a630.GetComponent<SkinnedMeshRenderer>();
				if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					component.updateWhenOffscreen = true;
				}
			}
			m_AnimationManagerFSM.c33f9c3a5a9687f3762dcd02c6dd2d0e2(RagdollOperationType.Enable);
			m_AnimationManagerFSM.c33f9c3a5a9687f3762dcd02c6dd2d0e2(RagdollOperationType.Compute_Velocity);
			ce26e5cdfa7aeb8af7bca30c7f7846fe6();
			Utils.ce6378e8b5a8ae9a4202182e1876677fe(m_AnimationManagerFSM.transform, LayerMask.NameToLayer("Ragdoll"), true);
			m_eHandleRagdollStep = EHandleRagdollStep.EWaitRagdollFallDown;
		}
		if (m_eHandleRagdollStep != EHandleRagdollStep.EWaitRagdollFallDown)
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
			if (m_fDieExitTime <= 0f)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						base.m_status = AnimationStatus.SUCCESS;
						return;
					}
				}
			}
			m_fDieExitTime -= Time.deltaTime;
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		m_AnimationManagerFSM.c49a0d4c35c57d927e2af7b37aaf3d99b(AudioEventName.Death);
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
	}

	public void ce26e5cdfa7aeb8af7bca30c7f7846fe6()
	{
		if (m_AnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			return;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_AnimationManagerFSM.m_rigidbodyTransforms == null)
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
				if (m_AnimationManagerFSM.m_rigidbodyTransforms.Count <= 0)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				if (m_force < 35f)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				Vector3 position = m_AnimationManagerFSM.transform.position;
				Vector3 position2 = m_AnimationManagerFSM.m_rigidbodyTransforms[0].position;
				Vector3 normalized = (position - m_explosionOrigin).normalized;
				Vector3 normalized2 = Vector3.Cross(normalized, normalized + Vector3.up).normalized;
				if (Random.Range(-1f, 1f) < 0f)
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
					normalized2 *= -1f;
				}
				float upwardsModifier = Random.Range(0.1f, 2f);
				int count = m_AnimationManagerFSM.m_rigidbodyTransforms.Count;
				for (int i = 0; i < count; i++)
				{
					Transform transform = m_AnimationManagerFSM.m_rigidbodyTransforms[i];
					if (!(transform.rigidbody != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
					{
						continue;
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
					if (m_force > 95f)
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
						transform.rigidbody.AddExplosionForce(240f, m_explosionOrigin, 20f, upwardsModifier);
						continue;
					}
					if (m_force > 75f)
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
						transform.rigidbody.AddExplosionForce(220f, m_explosionOrigin, 20f, upwardsModifier);
						continue;
					}
					if (m_force > 55f)
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
						transform.rigidbody.AddExplosionForce(200f, m_explosionOrigin, 15f, upwardsModifier);
						continue;
					}
					if (!(m_force > 35f))
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
					transform.rigidbody.AddForceAtPosition((position2 - m_explosionOrigin).normalized * 200f, position2 + normalized2);
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}
	}
}
