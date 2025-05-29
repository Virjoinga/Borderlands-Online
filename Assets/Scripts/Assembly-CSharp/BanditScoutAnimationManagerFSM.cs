using A;
using BHV;
using UnityEngine;

public class BanditScoutAnimationManagerFSM : NPCAnimationManagerFSM, IDamageListener
{
	private const int UPPERBODY_LAYER = 1;

	protected Transform m_laserTransform;

	protected LineRenderer m_laserRender;

	protected EntityWeapon m_weapon;

	protected bool m_bHide;

	protected bool m_bIsCasual;

	protected bool m_bShieldFull;

	protected float m_hideCooldownTime = 5f;

	protected float m_hideTime = 5f;

	protected Renderer[] m_enetiyRenders;

	protected Renderer[] m_enetiyWeaponRenders;

	protected GameObject m_lastAimingObject;

	protected EntityPlayer m_lastAimingEntityPlayer;

	public override void Start()
	{
		base.Start();
		m_movementSync = GetComponent<MovementSync>();
		m_isHumanoid = true;
		m_canUseFacingLogic = true;
		m_bHide = false;
		m_bIsCasual = false;
		m_bShieldFull = false;
		m_hideCooldownTime = 5f;
		m_hideTime = 5f;
		m_lastAimingObject = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		m_lastAimingEntityPlayer = c709fa52dfb309bbfe248c9f258832331.c7088de59e49f7108f520cf7e0bae167e;
		m_laserRender = m_entity.GetComponent<LineRenderer>();
		if (m_entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_enetiyRenders = m_entity.gameObject.GetComponentsInChildren<Renderer>();
		}
		if (m_weapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_enetiyWeaponRenders = m_weapon.gameObject.GetComponentsInChildren<Renderer>();
		}
		if (m_animEventHandlerList != null)
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
			m_animEventHandlerList.Add("StartShoot", OnStartShoot);
		}
		m_animEventHandlerList.Add("MeleeHit", base.OnMeleeHit);
		if (!DamageManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.c5c5b57d23b5b73637a6ed6524fed2be5(this);
			return;
		}
	}

	public override void Update()
	{
		base.Update();
		c66a9b75f483fe37627ac1addeadab222();
		cb2ae3609edf6a3938d0a90dbe71309e1();
		cb3493dbedcf81d50c2e472dcd2e3a572();
		ce26d18c278c91af07e350a5f832f2eef();
	}

	public void cb2ae3609edf6a3938d0a90dbe71309e1()
	{
		if (!(base.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (base.ccaaf181e61e5f9e050ba82237ed111a2.GetInteger("StanceMode") == 0)
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
				if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Alert))
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
					if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Warning))
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
						if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.MeleeAttack))
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
							if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Move))
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
								if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Die))
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
				switch (3)
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
					switch (7)
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
						switch (3)
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
						switch (1)
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
					goto IL_0103;
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
		goto IL_00e9;
		IL_0103:
		if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Fire))
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
			if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.CoverFire))
			{
				m_animationEventController.m_enableSniperAim = false;
				return;
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
		m_animationEventController.m_enableSniperAim = true;
		return;
		IL_00e9:
		m_animationEventController.m_enableAimIK = true;
		goto IL_0103;
	}

	public override int c43e01190c713db1f8a78d1529ae2d2ed(string cb6ecce17c4a10cf4ade445feb45a0355)
	{
		if (cb6ecce17c4a10cf4ade445feb45a0355.ToLower() == "hurtlight")
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
					return 4;
				}
			}
		}
		return 0;
	}

	private void cb3493dbedcf81d50c2e472dcd2e3a572()
	{
		if (m_laserTransform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			AIInventory aIInventory = m_entity.cdcf5e0592c05a681a8470f66674efd0b();
			if (aIInventory == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
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
			m_weapon = aIInventory.m_weapon;
			if (m_weapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					if (!(m_laserRender != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						m_laserRender.SetPosition(0, m_vZero);
						m_laserRender.SetPosition(1, m_vZero);
						return;
					}
				}
			}
			m_laserTransform = aIInventory.m_weapon.ced69ef722ca6f581cc2cb268b54f5cf4();
			if (m_laserTransform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}
		m_laserRender.SetPosition(0, m_laserTransform.position);
		Vector3 position = m_laserTransform.position;
		GameObject gameObject = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		if (m_animationEventController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (base.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (!base.ccaaf181e61e5f9e050ba82237ed111a2.GetBool("IsCasual"))
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
					gameObject = m_animationEventController.c8e92f5daba4d906708741a0b5f7afb19();
					if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						int layerMask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));
						RaycastHit hitInfo;
						if (Physics.Raycast(m_laserTransform.position, m_weapon.transform.forward, out hitInfo, float.PositiveInfinity, layerMask))
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
							position = hitInfo.point;
							position += m_weapon.transform.forward * 1.5f;
						}
						else
						{
							float num = (gameObject.transform.position - m_laserTransform.position).magnitude + 0.25f;
							position = m_laserTransform.position + m_weapon.transform.forward * num;
						}
					}
				}
			}
		}
		m_laserRender.SetPosition(1, position);
		if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_lastAimingObject != gameObject)
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
				c6663506f66d30b5cd46712693ff2ae06(gameObject, true);
				if (m_lastAimingObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					c6663506f66d30b5cd46712693ff2ae06(m_lastAimingObject, false);
				}
			}
			else if (m_lastAimingEntityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_lastAimingEntityPlayer.ca2ff7a501878363cb1d5f0472e306620() <= 0)
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
					c6663506f66d30b5cd46712693ff2ae06(m_lastAimingObject, false);
				}
			}
		}
		else
		{
			c6663506f66d30b5cd46712693ff2ae06(m_lastAimingObject, false);
		}
		m_lastAimingObject = gameObject;
	}

	private void c6663506f66d30b5cd46712693ff2ae06(GameObject c037b2b31038cc02a7c3892a247f5fd4d, bool c232363d391ddf136de98040c51b456ba)
	{
		if (!(c037b2b31038cc02a7c3892a247f5fd4d != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			EntityPlayer component = c037b2b31038cc02a7c3892a247f5fd4d.GetComponent<EntityPlayer>();
			if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (c232363d391ddf136de98040c51b456ba)
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
					if (component.ca2ff7a501878363cb1d5f0472e306620() > 0)
					{
						goto IL_0076;
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
				if (c232363d391ddf136de98040c51b456ba)
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
					break;
				}
				goto IL_0076;
				IL_0076:
				component.c5c2aca029c3e1bc2bb64865a174ee334(c232363d391ddf136de98040c51b456ba);
				EntityPlayer lastAimingEntityPlayer;
				if (c232363d391ddf136de98040c51b456ba)
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
					lastAimingEntityPlayer = component;
				}
				else
				{
					lastAimingEntityPlayer = c709fa52dfb309bbfe248c9f258832331.c7088de59e49f7108f520cf7e0bae167e;
				}
				m_lastAimingEntityPlayer = lastAimingEntityPlayer;
				return;
			}
		}
	}

	private void ce26d18c278c91af07e350a5f832f2eef()
	{
		if (m_bHide)
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
					m_hideTime -= Time.deltaTime;
					if (m_hideTime < 0f)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								cce6adadf40a70610ce3ae5dd40479620(false);
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (!(m_hideCooldownTime > 0f))
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
			m_hideCooldownTime -= Time.deltaTime;
			return;
		}
	}

	protected virtual void c8b7cecc28bb9c1640be075c3829771da(bool c931294945eb91e7c5c56f2a38ca1fcd9)
	{
		if (m_enetiyRenders == null)
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
			m_enetiyRenders = m_entity.gameObject.GetComponentsInChildren<Renderer>();
		}
		int num = m_enetiyRenders.Length;
		for (int i = 0; i < num; i++)
		{
			Renderer renderer = m_enetiyRenders[i];
			if (!(renderer as LineRenderer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			renderer.enabled = !c931294945eb91e7c5c56f2a38ca1fcd9;
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

	protected virtual void cce6adadf40a70610ce3ae5dd40479620(bool c931294945eb91e7c5c56f2a38ca1fcd9)
	{
	}

	public void OnStartShoot()
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		EntityWeapon weapon = m_entity.cdcf5e0592c05a681a8470f66674efd0b().m_weapon;
		if (!(weapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			weapon.c6f2004a1cbc439c9b630d1dd5c028bf3();
			return;
		}
	}

	public void OnDamaged(DamageContext context)
	{
		if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Dead))
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
			if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Die))
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
			if (context.m_victim == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (context.m_victim.gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				if (m_bHide)
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
					if (!(context.m_victim.gameObject == base.gameObject))
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
						cce6adadf40a70610ce3ae5dd40479620(true);
						return;
					}
				}
			}
		}
	}

	public void OnEntityKill(KillContext context)
	{
		if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Dead))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Die))
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
			if (context.m_victim == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (context.m_victim.gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (!m_bHide)
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
					if (!(context.m_victim.gameObject == base.gameObject))
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
						cce6adadf40a70610ce3ae5dd40479620(false);
						return;
					}
				}
			}
		}
	}

	private void OnDestroy()
	{
		if (!DamageManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.c67b40caae87a37a992e8004e2229b0eb(this);
			return;
		}
	}
}
