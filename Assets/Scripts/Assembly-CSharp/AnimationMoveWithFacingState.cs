using A;
using BHV;
using UnityEngine;

public class AnimationMoveWithFacingState : AnimationManagerState
{
	public float m_moveSpeed;

	public bool m_isSprint;

	private AnimatorStateInfo m_animatorStateInfo;

	public AnimationMoveWithFacingState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "MoveWithFacing";
	}

	public void cb8ae301452f1a421f9c89a8fcc2bf362(float cb8ede7129a08bde672fa63e8966d4c54)
	{
		if (m_AnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
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
		if (cb8ede7129a08bde672fa63e8966d4c54 >= 270f)
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
			cb8ede7129a08bde672fa63e8966d4c54 -= 360f;
		}
		if (cb8ede7129a08bde672fa63e8966d4c54 > 90f)
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
			cb8ede7129a08bde672fa63e8966d4c54 = 180f - cb8ede7129a08bde672fa63e8966d4c54;
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsMoveBackward", true);
		}
		else
		{
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsMoveBackward", false);
		}
		float @float = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetFloat("FaceAngle");
		cb8ede7129a08bde672fa63e8966d4c54 = Mathf.Lerp(@float, cb8ede7129a08bde672fa63e8966d4c54, 0.3f);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("FaceAngle", cb8ede7129a08bde672fa63e8966d4c54);
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		if (!m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_AnimationManagerFSM.m_disableMovementAnimation = false;
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMove", true);
			if (m_AnimationManagerFSM.m_isHumanoid)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("CrouchStatus", 0);
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCrouching", false);
						return;
					}
				}
			}
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bExitTurn", false);
			return;
		}
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_AnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fMoveSpeed", m_moveSpeed);
			Animator ccaaf181e61e5f9e050ba82237ed111a = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2;
			float value;
			if (m_isSprint)
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
				value = 1f;
			}
			else
			{
				value = 0f;
			}
			ccaaf181e61e5f9e050ba82237ed111a.SetFloat("fSprintMode", value);
			if (m_AnimationManagerFSM.cc2c8af567962955d6c13e1bff99b395d == BHVStressLevel.RELAX)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCasual", true);
						if (m_AnimationManagerFSM.m_upperBodyStateMachine != null)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
									m_AnimationManagerFSM.m_upperBodyStateMachine.c3d651aa95fd9820e9e2c328cc63e13e9("Empty");
									return;
								}
							}
						}
						return;
					}
				}
			}
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCasual", false);
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		if (!m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2)
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
			if (m_AnimationManagerFSM.m_fullBodyNextState == AnimationStateFSM.MoveWithFacing)
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
				m_AnimationManagerFSM.m_disableMovementAnimation = true;
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsTurning", false);
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fSprintMode", 0f);
				return;
			}
		}
	}
}
