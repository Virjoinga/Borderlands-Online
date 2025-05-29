using A;
using BHV;
using UnityEngine;

public class AnimationMoveState : AnimationManagerState
{
	private float m_moveSpeed;

	private float m_minimumWalkSpeed = 0.5f;

	private float m_minimumRunSpeed = 2.5f;

	private float m_sprintTurnThreshold = 60f;

	private AnimatorStateInfo m_animatorStateInfo;

	public bool m_isSprint;

	private bool m_isTurning;

	private string m_moveTurnTag = "MoveTurn";

	public float c1c067e605f60d78f4fd6324f61461644
	{
		get
		{
			return m_moveSpeed;
		}
		set
		{
			m_moveSpeed = value;
		}
	}

	public float m_startTurnThreshold { get; set; }

	public AnimationMoveState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "Move";
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		ce902c639c179f2e78fd1621e43ab4593 = 0f;
		m_startTurnThreshold = 10f;
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
					switch (4)
					{
					case 0:
						break;
					default:
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("CrouchStatus", 0);
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCrouching", false);
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsMoveBackward", false);
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("FaceAngle", 0f);
						if (m_AnimationManagerFSM.cc2c8af567962955d6c13e1bff99b395d == BHVStressLevel.RELAX)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCasual", true);
									if (m_AnimationManagerFSM.m_upperBodyStateMachine != null)
									{
										while (true)
										{
											switch (3)
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
			}
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bExitTurn", false);
			return;
		}
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_AnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		cee574d4b70aafe9fe0908c9d9ec4813b();
	}

	private void cc6f5fac76f9896c64bf727df043ccb72()
	{
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fMoveSpeed", m_moveSpeed);
		float num;
		if (m_isSprint)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			num = 1f;
		}
		else
		{
			num = 0f;
		}
		float value = num;
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fSprintMode", value);
		bool flag = false;
		if (((NPCAnimationManagerFSM)m_AnimationManagerFSM).cb8d9250c127e7972859f95eb98e07445())
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
			if (m_destinationFacing.magnitude > float.Epsilon)
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
				Vector3 forward = m_AnimationManagerFSM.transform.forward;
				forward.y = 0f;
				Vector3 destinationFacing = m_destinationFacing;
				destinationFacing.y = 0f;
				float num2 = BHVTaskUtils.cb9d402b3a18cd6eb6f306d1024377f7f(forward.normalized, destinationFacing.normalized);
				if (num2 > 180f)
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
					num2 -= 360f;
				}
				if (m_moveSpeed < m_minimumWalkSpeed)
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
					if (Mathf.Abs(num2) < m_startTurnThreshold)
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
						cf80e9704d378d2a4f8d30d91f51692b5();
						m_isTurning = false;
					}
					else
					{
						m_turnAngle = num2;
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("TurnAngle", m_turnAngle);
						flag = true;
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsTurning", true);
						m_isTurning = true;
					}
				}
				else if (m_destinationDistanceFactor < 1f)
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
					cf80e9704d378d2a4f8d30d91f51692b5();
					if (!m_AnimationManagerFSM.c4004fed08fd0ad52f8c3b650da10e9cb)
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
						ce70ba642d835e644edfccf2e6c5f105f();
					}
					m_isTurning = false;
				}
				else if (m_moveSpeed < m_minimumRunSpeed)
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
					m_turnAngle = num2;
					if (Mathf.Abs(m_turnAngle) < m_startTurnThreshold)
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
						m_isTurning = false;
						cf80e9704d378d2a4f8d30d91f51692b5();
					}
					else if (m_isTurning)
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
						m_animatorStateInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0);
						m_isTurning = m_animatorStateInfo.IsTag(m_moveTurnTag);
					}
					else if (Mathf.Abs(m_turnAngle) > m_startTurnThreshold * 3f)
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
						m_isTurning = true;
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("TurnAngle", m_turnAngle);
						flag = true;
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsTurning", m_isTurning);
					}
					else
					{
						cf80e9704d378d2a4f8d30d91f51692b5();
						m_isTurning = false;
					}
				}
				else
				{
					m_turnAngle = num2;
					if (Mathf.Abs(m_turnAngle) < m_startTurnThreshold)
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
						cf80e9704d378d2a4f8d30d91f51692b5();
						m_isTurning = false;
					}
					else if (m_isTurning)
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
						m_animatorStateInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0);
						m_isTurning = m_animatorStateInfo.IsTag(m_moveTurnTag);
					}
					else if (Mathf.Abs(m_turnAngle) > m_sprintTurnThreshold)
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
						m_isTurning = true;
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("TurnAngle", m_turnAngle);
						flag = true;
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsTurning", m_isTurning);
					}
					else
					{
						cf80e9704d378d2a4f8d30d91f51692b5();
						m_isTurning = false;
					}
				}
			}
		}
		else
		{
			c080fb7a0b91d6fb3ad1093d75aa80e5f();
		}
		if (!NetworkManager.c449802e708e91a9150466060fbab2ad6())
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
			if (!(m_AnimationManagerFSM.m_movementSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (Mathf.Abs(m_turnAngle) < m_startTurnThreshold)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							m_AnimationManagerFSM.m_movementSync.m_turnAngle = 0f;
							return;
						}
					}
				}
				if (!flag)
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
					m_AnimationManagerFSM.m_movementSync.m_turnAngle = m_turnAngle;
					return;
				}
			}
		}
	}

	private void cee574d4b70aafe9fe0908c9d9ec4813b()
	{
		if (m_AnimationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_AnimationManagerFSM.m_movementSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_turnAngle = m_AnimationManagerFSM.m_movementSync.m_turnAngle;
			}
		}
		while (m_turnAngle > 180f)
		{
			m_turnAngle -= 360f;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fMoveSpeed", m_moveSpeed);
			float num;
			if (m_isSprint)
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
				num = 1f;
			}
			else
			{
				num = 0f;
			}
			float value = num;
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fSprintMode", value);
			if (!((NPCAnimationManagerFSM)m_AnimationManagerFSM).cb8d9250c127e7972859f95eb98e07445())
			{
				return;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				if (Mathf.Abs(m_turnAngle) > float.Epsilon)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetBool("IsTurning"))
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
							m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("TurnAngle", m_turnAngle);
							m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsTurning", true);
							return;
						}
					}
				}
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("TurnAngle", 0f);
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsTurning", false);
				return;
			}
		}
	}

	public void c080fb7a0b91d6fb3ad1093d75aa80e5f()
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
		if (!(m_destinationFacing.magnitude > float.Epsilon))
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
			if (!(Mathf.Abs(m_AnimationManagerFSM.c5a566dbd0e781356afaeb0774ab2f0b1) < float.Epsilon))
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
				cf80e9704d378d2a4f8d30d91f51692b5();
				if (m_AnimationManagerFSM.c4004fed08fd0ad52f8c3b650da10e9cb)
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
					ce70ba642d835e644edfccf2e6c5f105f();
					return;
				}
			}
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
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_AnimationManagerFSM.m_fullBodyNextState == AnimationStateFSM.Move)
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
				m_AnimationManagerFSM.m_disableMovementAnimation = true;
				if (!m_AnimationManagerFSM.m_isHumanoid)
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
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bExitTurn", true);
				}
				if (((NPCAnimationManagerFSM)m_AnimationManagerFSM).cb8d9250c127e7972859f95eb98e07445())
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
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("TurnAngle", 0f);
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsTurning", false);
				}
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fSprintMode", 0f);
				return;
			}
		}
	}

	public void cf80e9704d378d2a4f8d30d91f51692b5()
	{
	}

	public void ce70ba642d835e644edfccf2e6c5f105f()
	{
	}
}
