using System.Collections.Generic;
using A;
using UnityEngine;

public class AnimationPlayerDieState : PlayerAnimationState
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

	private EHandleRagdollStep m_eHandleRagdollStep;

	private bool m_deathAnimationStarted;

	public Vector3 m_explosionOrigin;

	public float m_force;

	public int m_deathAnimIndex;

	private int m_deathLayerIndex = 2;

	private float m_startTime;

	private AnimatorStateInfo m_animatorInfo;

	public bool m_isHeadShot;

	public AnimationPlayerDieState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "PlayerDie";
		m_eHandleRagdollStep = EHandleRagdollStep.None;
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		ce902c639c179f2e78fd1621e43ab4593 = 0f;
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_AnimationManagerFSM.m_validateNextMovePosition = false;
		m_AnimationManagerFSM.c4004fed08fd0ad52f8c3b650da10e9cb = false;
		m_AnimationManagerFSM.c9620207019eec58f6f3d1178159e1111(false);
		m_eHandleRagdollStep = EHandleRagdollStep.EPlayDeathAnimation;
		m_deathAnimationStarted = false;
		base.m_status = AnimationStatus.RUNNING;
		if (m_AnimationManagerFSM.m_upperBodyStateMachine == null)
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
			m_animatorInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(m_deathLayerIndex);
			if (m_force < 35f)
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
				if (m_deathAnimationStarted)
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
					if (m_animatorInfo.IsTag("Death"))
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
						if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.98f))
						{
							goto IL_0190;
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					m_eHandleRagdollStep = EHandleRagdollStep.EStart;
				}
				else
				{
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bIsDying", true);
					int num;
					if (m_AnimationManagerFSM.m_setup.m_settings.m_headShotDeathAnimCount > 0)
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
						num = (m_isHeadShot ? 1 : 0);
					}
					else
					{
						num = 0;
					}
					bool value = (byte)num != 0;
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bHeadShot", value);
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("iDeathAnimIndex", m_deathAnimIndex);
					if (m_animatorInfo.IsTag("Death"))
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
						m_startTime = m_animatorInfo.normalizedTime;
						m_deathAnimationStarted = true;
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bIsDying", false);
					}
				}
			}
			else
			{
				m_eHandleRagdollStep = EHandleRagdollStep.EStart;
			}
		}
		goto IL_0190;
		IL_0190:
		if (m_eHandleRagdollStep == EHandleRagdollStep.EStart)
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
			m_AnimationManagerFSM.c33f9c3a5a9687f3762dcd02c6dd2d0e2(RagdollOperationType.Save_Position);
			m_eHandleRagdollStep = EHandleRagdollStep.EReadyToComputeVelocity;
		}
		if (m_eHandleRagdollStep == EHandleRagdollStep.EReadyToComputeVelocity)
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.enabled = false;
			m_AnimationManagerFSM.c33f9c3a5a9687f3762dcd02c6dd2d0e2(RagdollOperationType.Enable);
			m_AnimationManagerFSM.c33f9c3a5a9687f3762dcd02c6dd2d0e2(RagdollOperationType.SetRagdollLayer);
			m_AnimationManagerFSM.c33f9c3a5a9687f3762dcd02c6dd2d0e2(RagdollOperationType.Compute_Velocity);
			m_eHandleRagdollStep = EHandleRagdollStep.EReadyToSetRigidbody;
		}
		if (m_eHandleRagdollStep == EHandleRagdollStep.EReadyToSetRigidbody)
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
			ce26e5cdfa7aeb8af7bca30c7f7846fe6();
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
				break;
			default:
				return;
			}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		m_AnimationManagerFSM.cdb22a9a349507be00401b4d9fc80d1bb();
		m_AnimationManagerFSM.c33f9c3a5a9687f3762dcd02c6dd2d0e2(RagdollOperationType.Disable);
		m_AnimationManagerFSM.c33f9c3a5a9687f3762dcd02c6dd2d0e2(RagdollOperationType.SetDefaultLayer);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.enabled = true;
		m_AnimationManagerFSM.c9620207019eec58f6f3d1178159e1111(true);
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
	}

	public void ce26e5cdfa7aeb8af7bca30c7f7846fe6()
	{
		if (m_force < 35f)
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
					return;
				}
			}
		}
		Vector3 position = m_AnimationManagerFSM.transform.position;
		Skeleton skeleton = m_AnimationManagerFSM.m_entity.ccd8e6ea278245d0f158036267242e60f();
		Vector3 position2 = skeleton.cb2362c81dda995fcf817a341a4eb3ffb().position;
		Vector3 normalized = (position - m_explosionOrigin).normalized;
		if ((position - m_explosionOrigin).magnitude > 3f)
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
			m_explosionOrigin = position - normalized * 3f;
		}
		float upwardsModifier = Random.Range(0.1f, 2f);
		Vector3 normalized2 = Vector3.Cross(normalized, normalized + Vector3.up).normalized;
		if (Random.Range(-1f, 1f) < 0f)
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
			normalized2 *= -1f;
		}
		using (List<Transform>.Enumerator enumerator = m_AnimationManagerFSM.m_rigidbodyTransforms.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Transform current = enumerator.Current;
				if (!(current.rigidbody != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
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
					current.rigidbody.AddExplosionForce(700f, m_explosionOrigin, 20f, upwardsModifier);
				}
				else if (m_force > 75f)
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
					current.rigidbody.AddExplosionForce(600f, m_explosionOrigin, 20f, upwardsModifier);
				}
				else if (m_force > 55f)
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
					current.rigidbody.AddExplosionForce(500f, m_explosionOrigin, 20f, upwardsModifier);
				}
				else
				{
					if (!(m_force > 35f))
					{
						continue;
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
					current.rigidbody.AddForceAtPosition((position2 - m_explosionOrigin).normalized * 200f, position2 + normalized2);
				}
			}
			while (true)
			{
				switch (7)
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
