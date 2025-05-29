using A;
using BHV;
using UnityEngine;

public class BanditKillerAnimationManagerFSM : NPCAnimationManagerFSM
{
	private const int UPPERBODY_LAYER = 1;

	private float m_shotSoundType;

	public override void Start()
	{
		base.Start();
		m_movementSync = GetComponent<MovementSync>();
		m_isHumanoid = true;
		m_canUseFacingLogic = false;
		m_shotSoundType = Random.Range(0f, 3f);
		m_animEventHandlerList.Add("MeleeHit", base.OnMeleeHit);
		if (m_animEventHandlerList == null)
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
			m_animEventHandlerList.Add("StartShoot", OnStartShoot);
			return;
		}
	}

	public override void Update()
	{
		base.Update();
		c66a9b75f483fe37627ac1addeadab222();
		cb2ae3609edf6a3938d0a90dbe71309e1();
	}

	public void cb2ae3609edf6a3938d0a90dbe71309e1()
	{
		if (!(base.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (base.ccaaf181e61e5f9e050ba82237ed111a2.GetInteger("StanceMode") == 0)
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
				if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Alert))
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
					if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Warning))
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
						if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.MeleeAttack))
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
							if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Move))
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
								if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Die))
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
									break;
								}
							}
						}
					}
				}
				base.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("StanceMode", 0);
				return;
			}
		}
	}

	public void c66a9b75f483fe37627ac1addeadab222()
	{
		if (m_animationEventController == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
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
				return;
			}
		}
		if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Fire))
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
			if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.CoverFire))
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
				if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Idle))
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
					if (base.cc2c8af567962955d6c13e1bff99b395d == BHVStressLevel.COMBAT)
					{
						goto IL_00e9;
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
				if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Move))
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
					if (base.cc2c8af567962955d6c13e1bff99b395d == BHVStressLevel.COMBAT)
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
						if (base.ccaaf181e61e5f9e050ba82237ed111a2.GetFloat("fSprintMode") < 0.5f)
						{
							goto IL_00e9;
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
				if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.CoverIdleBeforeFire))
				{
					m_animationEventController.m_enableAimIK = false;
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
		}
		goto IL_00e9;
		IL_00e9:
		m_animationEventController.m_enableAimIK = true;
	}

	public override int c43e01190c713db1f8a78d1529ae2d2ed(string cb6ecce17c4a10cf4ade445feb45a0355)
	{
		if (cb6ecce17c4a10cf4ade445feb45a0355.ToLower() == "hurtlight")
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
					return 4;
				}
			}
		}
		return 0;
	}

	public void cab94d057a7a34ace28571b802d18642e(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		if (m_AudioCtl == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		BroadcastMessage("TriggerEffectByName", "OnAttack", SendMessageOptions.DontRequireReceiver);
		switch (cd99af21e22e356018b8f72d4a7e4872a)
		{
		default:
			return;
		case "First":
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (m_shotSoundType > 2f)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							m_AudioCtl.TriggerEventByName("Wep_SMG_NPC_Shoot_HL_Rnd");
							return;
						}
					}
				}
				if (m_shotSoundType > 1f)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							m_AudioCtl.TriggerEventByName("Wep_SMG_NPC_Shoot_ML_Rnd");
							return;
						}
					}
				}
				m_AudioCtl.TriggerEventByName("Wep_SMG_NPC_Shoot_LL_Rnd");
				return;
			}
		case "Chain":
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				if (m_shotSoundType > 2f)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							m_AudioCtl.TriggerEventByName("Wep_SMG_NPC_Shoot_HS_Rnd");
							return;
						}
					}
				}
				if (m_shotSoundType > 1f)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							m_AudioCtl.TriggerEventByName("Wep_SMG_NPC_Shoot_MS_Rnd");
							return;
						}
					}
				}
				m_AudioCtl.TriggerEventByName("Wep_SMG_NPC_Shoot_LS_Rnd");
				return;
			}
		case "Last":
			break;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (m_shotSoundType > 2f)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						m_AudioCtl.TriggerEventByName("Wep_SMG_NPC_High_Tail_Rnd");
						return;
					}
				}
			}
			if (m_shotSoundType > 1f)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						m_AudioCtl.TriggerEventByName("Wep_SMG_NPC_Med_Tail_Rnd");
						return;
					}
				}
			}
			m_AudioCtl.TriggerEventByName("Wep_SMG_NPC_Low_Tail_Rnd");
			return;
		}
	}

	public void OnStartShoot()
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		EntityWeapon weapon = m_entity.cdcf5e0592c05a681a8470f66674efd0b().m_weapon;
		if (!(weapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			weapon.c6f2004a1cbc439c9b630d1dd5c028bf3();
			cab94d057a7a34ace28571b802d18642e("Chain");
			return;
		}
	}
}
