using A;
using UnityEngine;

public class AnimationReloadState : AnimationManagerState
{
	private const string RELOAD_TAG = "StandReload";

	private const int UPPERBODY_LAYER = 1;

	public bool m_reloadStarted;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_reloadStarted = false;
		base.m_status = AnimationStatus.PREPARE;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_AnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (base.m_status == AnimationStatus.PREPARE)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						m_animatorInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0);
						if (!m_animatorInfo.IsTag("Fire"))
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
									base.m_status = AnimationStatus.RUNNING;
									return;
								}
							}
						}
						return;
					}
				}
			}
			if (base.m_status != AnimationStatus.RUNNING)
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
				m_animatorInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(1);
				if (m_reloadStarted)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.98f))
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
								if (m_animatorInfo.IsTag("StandReload"))
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
									break;
								}
							}
							m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsReloading", false);
							if (m_AnimationManagerFSM.m_entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								if (m_AnimationManagerFSM.m_entity.c3941dac8608f650ceb15dc36294a741c() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
									m_AnimationManagerFSM.m_entity.c3941dac8608f650ceb15dc36294a741c().OnReloadAnimDone();
								}
							}
							base.m_status = AnimationStatus.SUCCESS;
							return;
						}
					}
				}
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsReloading", true);
				if (!m_animatorInfo.IsTag("StandReload"))
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
					m_reloadStarted = true;
					m_startTime = m_animatorInfo.normalizedTime;
					return;
				}
			}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsReloading", false);
		}
		base.m_status = AnimationStatus.SUCCESS;
	}
}
