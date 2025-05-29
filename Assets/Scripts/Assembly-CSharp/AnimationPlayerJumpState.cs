using A;
using UnityEngine;

public class AnimationPlayerJumpState : PlayerAnimationState
{
	private const string JUMPSTART_TAG = "JumpStart";

	private const string JUMPIDLE_TAG = "JumpIdle";

	private const string JUMPLAND_TAG = "JumpLand";

	public bool m_jumpStartedFirst;

	public bool m_jumpStartedThird;

	public bool m_jumpLandStartedFirst;

	public bool m_jumpLandStartedThird;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	private EAnimationJumpStep m_animationJumpStep;

	private float m_jumpStartAnimDuration = 0.2f;

	private float m_jumpLandAnimDuration = 0.3f;

	private float m_jumpLandStartTime;

	public EAnimationJumpStep c4de9959131c2e376835be9d32b952b04
	{
		get
		{
			return m_animationJumpStep;
		}
		set
		{
			m_animationJumpStep = value;
			if (m_animationJumpStep != EAnimationJumpStep.JumpLand)
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
				m_jumpLandStartTime = Time.time;
				return;
			}
		}
	}

	public AnimationPlayerJumpState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "PlayerJump";
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		c202233e8aff844f80007ac3ee8c065a8();
	}

	public void c0309186ebbfb1fbe3085ca4ff2549812()
	{
		m_animatorInfo = ca18251f94792b5764ab1a1024333abfb(true, 0);
		if (c4de9959131c2e376835be9d32b952b04 == EAnimationJumpStep.JumpNull)
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
		if (c4de9959131c2e376835be9d32b952b04 == EAnimationJumpStep.JumpPre)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (c5b1d2ed82148bbacbab996774cdb039d())
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								if (m_jumpStartedFirst)
								{
									while (true)
									{
										switch (3)
										{
										case 0:
											break;
										default:
											if (m_animatorInfo.IsTag("JumpStart"))
											{
												while (true)
												{
													switch (2)
													{
													case 0:
														break;
													default:
														if (Time.time - m_startTime > m_jumpStartAnimDuration * 0.97f)
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
														return;
													}
												}
											}
											return;
										}
									}
								}
								if (m_animatorInfo.IsTag("JumpStart"))
								{
									while (true)
									{
										switch (7)
										{
										case 0:
											break;
										default:
											m_jumpStartedFirst = true;
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
		if (c4de9959131c2e376835be9d32b952b04 == EAnimationJumpStep.JumpLoop)
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
		if (c4de9959131c2e376835be9d32b952b04 == EAnimationJumpStep.JumpLand)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_JumpLand);
					return;
				}
			}
		}
		if (c4de9959131c2e376835be9d32b952b04 != EAnimationJumpStep.JumpFinish)
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
			base.m_status = AnimationStatus.SUCCESS;
			return;
		}
	}

	public bool c5b1d2ed82148bbacbab996774cdb039d()
	{
		if (m_AnimationManagerFSM.ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerSwitchWeapon))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_AnimationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("PlayerSwitchWeapon").m_status == AnimationStatus.RUNNING)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return false;
					}
				}
			}
		}
		if (m_AnimationManagerFSM.ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerReload))
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
			if (m_AnimationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("PlayerReload").m_status == AnimationStatus.RUNNING)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return false;
					}
				}
			}
		}
		if (m_AnimationManagerFSM.ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerPickupWeapon))
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
			if (m_AnimationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("PlayerPickupWeapon").m_status == AnimationStatus.RUNNING)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return false;
					}
				}
			}
		}
		return true;
	}

	public void c5bd94841c00634929641d9da6507cb69()
	{
		m_animatorInfo = ca18251f94792b5764ab1a1024333abfb(false, 0);
		if (c4de9959131c2e376835be9d32b952b04 == EAnimationJumpStep.JumpNull)
		{
			while (true)
			{
				switch (6)
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
		if (c4de9959131c2e376835be9d32b952b04 == EAnimationJumpStep.JumpPre)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (m_jumpStartedThird)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								if (Time.time - m_startTime > m_jumpStartAnimDuration * 0.9f)
								{
									while (true)
									{
										switch (5)
										{
										case 0:
											break;
										default:
											if (base.c90e194560a86112d38f669898a54a249)
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
												ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_JumpStart);
											}
											c06739986a9474e249bf49d8330a68ce0("bJumpStart", false);
											c4de9959131c2e376835be9d32b952b04 = EAnimationJumpStep.JumpLoop;
											return;
										}
									}
								}
								return;
							}
						}
					}
					if (base.c90e194560a86112d38f669898a54a249)
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
						ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_JumpStart);
					}
					c06739986a9474e249bf49d8330a68ce0("bJumpStart", true);
					if (m_animatorInfo.IsTag("JumpIdle"))
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								m_jumpStartedThird = true;
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (c4de9959131c2e376835be9d32b952b04 == EAnimationJumpStep.JumpLoop)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (c4de9959131c2e376835be9d32b952b04 == EAnimationJumpStep.JumpLand)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (m_jumpLandStartedThird)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								if (Time.time - m_jumpLandStartTime > m_jumpLandAnimDuration * 0.9f)
								{
									while (true)
									{
										switch (7)
										{
										case 0:
											break;
										default:
											c4de9959131c2e376835be9d32b952b04 = EAnimationJumpStep.JumpFinish;
											return;
										}
									}
								}
								return;
							}
						}
					}
					if (base.c90e194560a86112d38f669898a54a249)
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
						ce828a5281da417bda49f7bd3dcdc3863(MecanimAnimationID.ID_1st_JumpStart);
						ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_JumpLand);
					}
					c06739986a9474e249bf49d8330a68ce0("bJumpStart", false);
					c06739986a9474e249bf49d8330a68ce0("bJumpLand", true);
					if (!m_animatorInfo.IsTag("JumpIdle"))
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								m_jumpLandStartedThird = true;
								if (base.c90e194560a86112d38f669898a54a249)
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
									ce828a5281da417bda49f7bd3dcdc3863(MecanimAnimationID.ID_1st_JumpLand);
								}
								c06739986a9474e249bf49d8330a68ce0("bJumpLand", false);
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (c4de9959131c2e376835be9d32b952b04 != EAnimationJumpStep.JumpFinish)
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
			base.m_status = AnimationStatus.SUCCESS;
			if (base.c90e194560a86112d38f669898a54a249)
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
				ce828a5281da417bda49f7bd3dcdc3863(MecanimAnimationID.ID_1st_JumpStart);
				ce828a5281da417bda49f7bd3dcdc3863(MecanimAnimationID.ID_1st_JumpLand);
			}
			c06739986a9474e249bf49d8330a68ce0("bJumpStart", false);
			c06739986a9474e249bf49d8330a68ce0("bJumpLand", false);
			return;
		}
	}

	public void c202233e8aff844f80007ac3ee8c065a8()
	{
		m_jumpStartedFirst = false;
		m_jumpStartedThird = false;
		m_jumpLandStartedFirst = false;
		m_jumpLandStartedThird = false;
		if (base.c90e194560a86112d38f669898a54a249)
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
			ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_JumpStart);
			ce828a5281da417bda49f7bd3dcdc3863(MecanimAnimationID.ID_1st_JumpLand);
		}
		c06739986a9474e249bf49d8330a68ce0("bJumpStart", true);
		c06739986a9474e249bf49d8330a68ce0("bJumpLand", false);
		m_startTime = Time.time;
		c4de9959131c2e376835be9d32b952b04 = EAnimationJumpStep.JumpPre;
		base.m_status = AnimationStatus.RUNNING;
	}

	public bool c7e5c0cc1fae32a7779550f78113cc845()
	{
		if (c4de9959131c2e376835be9d32b952b04 != EAnimationJumpStep.JumpFinish)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (c4de9959131c2e376835be9d32b952b04 != EAnimationJumpStep.JumpLand)
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
				if (c4de9959131c2e376835be9d32b952b04 != 0)
				{
					return false;
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
		}
		return true;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (base.c90e194560a86112d38f669898a54a249)
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
			c0309186ebbfb1fbe3085ca4ff2549812();
		}
		c5bd94841c00634929641d9da6507cb69();
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		BaseEventTriggerCtl componentInChildren = m_AnimationManagerFSM.m_animationHost.GetComponentInChildren<BaseEventTriggerCtl>();
		if (componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (base.c90e194560a86112d38f669898a54a249)
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
				componentInChildren.TriggerEventByName("Chr_Land_Rnd");
			}
			componentInChildren.TriggerEventByName("Chr_Shr_Foley_Run_Rnd");
			componentInChildren.TriggerEventByName("Chr_Shr_FootStep_Run");
		}
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		base.m_status = AnimationStatus.SUCCESS;
		if (base.c90e194560a86112d38f669898a54a249)
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
			ce828a5281da417bda49f7bd3dcdc3863(MecanimAnimationID.ID_1st_JumpStart);
			ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_JumpLand);
		}
		c06739986a9474e249bf49d8330a68ce0("bJumpStart", false);
		c06739986a9474e249bf49d8330a68ce0("bJumpLand", true);
	}
}
