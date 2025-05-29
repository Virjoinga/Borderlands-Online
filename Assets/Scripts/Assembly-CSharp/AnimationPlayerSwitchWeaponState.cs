using A;
using UnityEngine;

public class AnimationPlayerSwitchWeaponState : PlayerAnimationState
{
	public enum EAnimationSwitchStep
	{
		SwitchNull = 0,
		SwitchDown = 1,
		SwitchWeapon = 2,
		SwitchUp = 3,
		SwitchFinish = 4
	}

	private const string SWITCHUP_TAG = "SwitchUp";

	private const string SWITCHDOWN_TAG = "SwitchDown";

	public bool m_SwitchStarted;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	private EntityWeapon m_nextWeapon;

	private EntityPlayer m_entityPlayer;

	private EAnimationSwitchStep m_switchStep;

	private int m_switchWeaponLayer;

	private float m_switchSpeed = 1f;

	public AnimationPlayerSwitchWeaponState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "PlayerSwitchWeapon";
	}

	public void c6c718e75c647ef3e7bb161260ec25d23(EntityWeapon c69bf0840711997fc24c93a36e45706e0, EntityPlayer cc292a78271891d4e9a7145978b66846f)
	{
		m_nextWeapon = c69bf0840711997fc24c93a36e45706e0;
		m_entityPlayer = cc292a78271891d4e9a7145978b66846f;
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_SwitchStarted = false;
		m_switchWeaponLayer = 1;
		if (m_entityPlayer.c3941dac8608f650ceb15dc36294a741c() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_switchSpeed = m_entityPlayer.c3941dac8608f650ceb15dc36294a741c().c0debecd8729d45372929dc058e514e52();
		}
		c5c556754ed6864299f9af3eb736baf27();
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
			m_switchWeaponLayer = 0;
		}
		m_switchStep = EAnimationSwitchStep.SwitchDown;
		base.m_status = AnimationStatus.RUNNING;
		if (!(base.c6e68afa0a7f820f050de4b96ae1be367 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			base.c6e68afa0a7f820f050de4b96ae1be367.ca3a93dab876a263826750cdd7ef70f9c();
			return;
		}
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (base.c90e194560a86112d38f669898a54a249)
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
			cde1a02f355a53c1c5d20e94872e811eb();
		}
		c7df200479454c27127f6a68b18c9e8b9();
	}

	public void cde1a02f355a53c1c5d20e94872e811eb()
	{
		if (m_switchStep == EAnimationSwitchStep.SwitchDown)
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
					ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_SwitchDown);
					if (base.c6e68afa0a7f820f050de4b96ae1be367 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								base.c6e68afa0a7f820f050de4b96ae1be367.OnSwitchWeapon(true);
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (m_switchStep == EAnimationSwitchStep.SwitchWeapon)
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
		if (m_switchStep == EAnimationSwitchStep.SwitchUp)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_SwitchUp);
					if (base.c6e68afa0a7f820f050de4b96ae1be367 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								base.c6e68afa0a7f820f050de4b96ae1be367.OnSwitchWeapon(false);
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (m_switchStep != EAnimationSwitchStep.SwitchFinish)
		{
			return;
		}
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

	public void c7df200479454c27127f6a68b18c9e8b9()
	{
		m_switchWeaponLayer = 1;
		m_animatorInfo = ca18251f94792b5764ab1a1024333abfb(false, m_switchWeaponLayer);
		if (m_switchStep == EAnimationSwitchStep.SwitchDown)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						if (m_SwitchStarted)
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
							if (m_animatorInfo.IsTag("SwitchDown"))
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
								if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.98f))
								{
									goto IL_00ef;
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
							}
							m_switchStep = EAnimationSwitchStep.SwitchWeapon;
							c06739986a9474e249bf49d8330a68ce0("bSwitchDown", false);
						}
						else
						{
							c06739986a9474e249bf49d8330a68ce0("bSwitchDown", true);
							if (m_animatorInfo.IsTag("SwitchDown"))
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
								m_SwitchStarted = true;
								m_startTime = m_animatorInfo.normalizedTime;
							}
						}
						goto IL_00ef;
					}
					IL_00ef:
					if (m_entityPlayer.c3941dac8608f650ceb15dc36294a741c() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						m_switchSpeed = m_entityPlayer.c3941dac8608f650ceb15dc36294a741c().c0debecd8729d45372929dc058e514e52();
					}
					c5c556754ed6864299f9af3eb736baf27();
					return;
				}
			}
		}
		if (m_switchStep == EAnimationSwitchStep.SwitchWeapon)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					m_SwitchStarted = false;
					if (m_entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (m_nextWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							m_entityPlayer.c554459b1136a15a5b4817abd6efd4e80(m_nextWeapon);
							if (base.c6e68afa0a7f820f050de4b96ae1be367 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								base.c6e68afa0a7f820f050de4b96ae1be367.ca3a93dab876a263826750cdd7ef70f9c();
							}
						}
					}
					m_switchStep = EAnimationSwitchStep.SwitchUp;
					c5c556754ed6864299f9af3eb736baf27();
					return;
				}
			}
		}
		if (m_switchStep == EAnimationSwitchStep.SwitchUp)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					{
						if (m_SwitchStarted)
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
							if (m_AnimationManagerFSM.m_animationEventController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								if (c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.5f))
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
									m_AnimationManagerFSM.m_animationEventController.m_pendingWeaponType = m_nextWeapon.c83e548e5608cd7f222098a6966b16545();
									m_AnimationManagerFSM.m_animationEventController.m_pendingLeftHandIK = true;
								}
							}
							if (m_animatorInfo.IsTag("SwitchUp"))
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
								if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.98f))
								{
									goto IL_0325;
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
							m_switchStep = EAnimationSwitchStep.SwitchFinish;
							c06739986a9474e249bf49d8330a68ce0("bSwitchUp", false);
						}
						else
						{
							c06739986a9474e249bf49d8330a68ce0("bSwitchUp", true);
							if (m_animatorInfo.IsTag("SwitchUp"))
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
								m_SwitchStarted = true;
								m_startTime = m_animatorInfo.normalizedTime;
							}
						}
						goto IL_0325;
					}
					IL_0325:
					if (m_entityPlayer.c3941dac8608f650ceb15dc36294a741c() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						m_switchSpeed = m_entityPlayer.c3941dac8608f650ceb15dc36294a741c().ca64315a1389d64b76a2d1d9832da0f3a();
					}
					c5c556754ed6864299f9af3eb736baf27();
					return;
				}
			}
		}
		if (m_switchStep != EAnimationSwitchStep.SwitchFinish)
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
			base.m_status = AnimationStatus.SUCCESS;
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		if (base.c90e194560a86112d38f669898a54a249)
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
			ce828a5281da417bda49f7bd3dcdc3863(MecanimAnimationID.ID_1st_SwitchUp);
		}
		c06739986a9474e249bf49d8330a68ce0("bSwitchDown", false);
		c06739986a9474e249bf49d8330a68ce0("bSwitchUp", false);
		base.m_status = AnimationStatus.SUCCESS;
		m_entityPlayer.OnSwitchWeaponDone();
	}

	private void c5c556754ed6864299f9af3eb736baf27()
	{
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			cb306162a8032e25a87c8a3cfc617cc8c("fSwitchSpeed", m_switchSpeed);
		}
		c4363c9ee832d0d0155375ca61d99d853("fSwitchSpeed", m_switchSpeed);
	}
}
