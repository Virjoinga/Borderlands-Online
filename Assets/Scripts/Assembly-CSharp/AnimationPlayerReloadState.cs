using A;
using Core;
using UnityEngine;

public class AnimationPlayerReloadState : PlayerAnimationState
{
	private const string RELOAD_TAG = "Reload";

	public bool m_thirdPersonReloadStarted;

	public bool m_firstPersonReloadStarted;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	private float m_weaponMode;

	private int m_reloadLayer;

	private float m_reloadSpeed = 1f;

	public float m_netLantency;

	private bool m_bAmmoRefilled;

	private float m_reloadPercentage;

	private float m_maxReloadPercentage = 0.97f;

	private bool m_weaponReloadPending;

	public AnimationPlayerReloadState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "PlayerReload";
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_thirdPersonReloadStarted = false;
		m_firstPersonReloadStarted = false;
		m_bAmmoRefilled = false;
		m_weaponMode = ((PlayerThirdPersonAnimationManagerFSM)m_AnimationManagerFSM).c21c1c32fc4adafd3ac60f9fcd0faf29f();
		m_reloadSpeed = m_AnimationManagerFSM.m_entity.c3941dac8608f650ceb15dc36294a741c().cb4a75faedb5a5e266f1a6fbae8955f0a();
		m_reloadPercentage = c4a92afe664b68f75e668116af19e84e9().c3941dac8608f650ceb15dc36294a741c().cfc0d5bc73e67cb355e0830c69ea8ffbb();
		if (m_reloadPercentage > m_maxReloadPercentage)
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
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, "weapon type reload percentage is bigger than max value, its reload animatin can't be finished, weapon type is " + c4a92afe664b68f75e668116af19e84e9().c3941dac8608f650ceb15dc36294a741c().c83e548e5608cd7f222098a6966b16545());
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
			cb306162a8032e25a87c8a3cfc617cc8c("fWeaponMode", m_weaponMode);
			cb306162a8032e25a87c8a3cfc617cc8c("fReloadSpeed", m_reloadSpeed);
			ccadff0d4c94e9a3efd1c9a959fd4b0b9("bFire", false);
			m_weaponReloadPending = true;
		}
		c4363c9ee832d0d0155375ca61d99d853("fWeaponMode", m_weaponMode);
		c4363c9ee832d0d0155375ca61d99d853("fReloadSpeed", m_reloadSpeed);
		c06739986a9474e249bf49d8330a68ce0("bFire", false);
		base.m_status = AnimationStatus.RUNNING;
	}

	public void c844653eaef70f1089f0c83dc2458f21d()
	{
		if (m_weaponReloadPending)
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
			if (m_firstPersonAnimator.IsInTransition(0))
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
				if (m_firstPersonAnimator.GetNextAnimatorStateInfo(0).IsTag("Reload"))
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
					AnimatorTransitionInfo animatorTransitionInfo = m_firstPersonAnimator.GetAnimatorTransitionInfo(0);
					if (animatorTransitionInfo.normalizedTime - Mathf.Floor(animatorTransitionInfo.normalizedTime) > 0.7f)
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
							base.c6e68afa0a7f820f050de4b96ae1be367.OnWeaponReload(m_netLantency);
							m_weaponReloadPending = false;
						}
					}
				}
			}
		}
		m_animatorInfo = ca18251f94792b5764ab1a1024333abfb(true, 0);
		if (m_firstPersonReloadStarted)
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
		ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_Reload);
		if (!m_animatorInfo.IsTag("Reload"))
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
			if (m_weaponReloadPending)
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
				if (base.c6e68afa0a7f820f050de4b96ae1be367 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					base.c6e68afa0a7f820f050de4b96ae1be367.OnWeaponReload(m_netLantency);
					m_weaponReloadPending = false;
				}
			}
			m_firstPersonReloadStarted = true;
			return;
		}
	}

	public void ca61bae32b785f688d9a52e9844d061c9()
	{
		m_reloadLayer = 1;
		m_animatorInfo = ca18251f94792b5764ab1a1024333abfb(false, m_reloadLayer);
		if (m_thirdPersonReloadStarted)
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
					if (m_animatorInfo.IsTag("Reload"))
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
						if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, m_maxReloadPercentage))
						{
							if (!m_bAmmoRefilled)
							{
								while (true)
								{
									switch (1)
									{
									case 0:
										break;
									default:
										if (c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, m_reloadPercentage))
										{
											while (true)
											{
												switch (5)
												{
												case 0:
													break;
												default:
													m_bAmmoRefilled = true;
													if (m_AnimationManagerFSM.m_entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
													{
														while (true)
														{
															switch (4)
															{
															case 0:
																break;
															default:
																if (m_AnimationManagerFSM.m_entity.c3941dac8608f650ceb15dc36294a741c() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
																{
																	while (true)
																	{
																		switch (3)
																		{
																		case 0:
																			break;
																		default:
																			m_AnimationManagerFSM.m_entity.c3941dac8608f650ceb15dc36294a741c().OnReloadAnimDone();
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
										return;
									}
								}
							}
							return;
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					base.m_status = AnimationStatus.SUCCESS;
					c06739986a9474e249bf49d8330a68ce0("bReload", false);
					return;
				}
			}
		}
		c06739986a9474e249bf49d8330a68ce0("bReload", true);
		if (!m_animatorInfo.IsTag("Reload"))
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
			m_thirdPersonReloadStarted = true;
			m_startTime = m_animatorInfo.normalizedTime + m_netLantency / m_animatorInfo.length;
			return;
		}
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
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
			if (m_firstPersonAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c844653eaef70f1089f0c83dc2458f21d();
			}
		}
		if (!(m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			ca61bae32b785f688d9a52e9844d061c9();
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
		}
		c06739986a9474e249bf49d8330a68ce0("bReload", false);
		base.m_status = AnimationStatus.SUCCESS;
	}
}
