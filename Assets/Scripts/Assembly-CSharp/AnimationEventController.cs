using A;
using Core;
using UnityEngine;
using XsdSettings;

public class AnimationEventController : MonoBehaviour
{
	public ParticleSystem m_muzzleFlash;

	public ParticleSystem m_coneFlash;

	public ParticleSystem m_sniperLight;

	public GameObject m_cameraGlow;

	public bool m_enableSniperAim;

	public Animation m_muzzleLight;

	public Animator m_animator;

	public bool m_enableAimIK;

	protected float m_aimIKweight;

	private bool m_alreadyInFiring;

	protected Vector3 m_targetPosition = Vector3.zero;

	protected GameObject m_targetObject;

	protected bool m_hasValidTargetPosition;

	public Transform m_PlayerLeftHandSmg;

	public Transform m_PlayerLeftHandShotgun;

	public Transform m_PlayerLeftHandSniper;

	public Transform m_PlayerLeftHandPistol;

	public Transform m_PlayerLeftHandCombatRifle;

	public WeaponType m_currentWeaponType;

	public bool m_enableLeftHandIK;

	public bool m_pendingLeftHandIK;

	private float m_pendingLeftHandIKweight;

	public WeaponType m_pendingWeaponType;

	protected EntityNpc m_entityNpc;

	protected EntityWeapon m_entityNpcWeapon;

	public float m_aimHightOffset = 0.4f;

	protected EntityPlayer m_localPlayer;

	private float m_sniperLightDisapperTimer;

	public void c1388b070a9ff180c6a0efe41ddf70e31(Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900)
	{
		m_hasValidTargetPosition = true;
		m_targetPosition = c0b885a96d3f0d32f51ff3ec0d37d2900;
	}

	public void c1e667d6f38b9e5836b1229ac7567f858(GameObject c2008d5793f81ed289732e3227d73f220)
	{
		m_hasValidTargetPosition = false;
		m_targetObject = c2008d5793f81ed289732e3227d73f220;
	}

	public void ce40f0b6c3f7714ac1c3daa73f26d266d()
	{
		m_hasValidTargetPosition = false;
		m_targetObject = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
	}

	public void OnBanditShootStart()
	{
		m_entityNpc = base.gameObject.transform.parent.GetComponent<EntityNpc>();
		if (m_entityNpc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_entityNpcWeapon = m_entityNpc.cdcf5e0592c05a681a8470f66674efd0b().m_weapon;
		}
		if (m_entityNpcWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					m_entityNpcWeapon.c6f2004a1cbc439c9b630d1dd5c028bf3();
					return;
				}
			}
		}
		if (m_alreadyInFiring)
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
		m_alreadyInFiring = true;
		if (m_muzzleFlash != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_muzzleFlash.Play();
		}
		if (m_coneFlash != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_coneFlash.Play();
		}
		if (!(m_muzzleLight != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(m_muzzleLight.GetClip("PTL_MuzzleFlash_LightFX_01") != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_muzzleLight.Play("PTL_MuzzleFlash_LightFX_01");
				return;
			}
		}
	}

	public void OnBanditShootStop()
	{
		if (!m_alreadyInFiring)
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
			m_alreadyInFiring = false;
			if (m_muzzleFlash != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_muzzleFlash.Stop();
				m_muzzleFlash.Clear();
			}
			if (m_coneFlash != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_coneFlash.Stop();
				m_coneFlash.Clear();
			}
			if (!(m_muzzleLight != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!(m_muzzleLight.GetClip("PTL_MuzzleFlash_LightFX_01") != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					m_muzzleLight.Rewind();
					m_muzzleLight.Play();
					m_muzzleLight.Sample();
					m_muzzleLight.Stop();
					return;
				}
			}
		}
	}

	private void Start()
	{
		m_animator = GetComponent<Animator>();
		m_aimIKweight = 0f;
		m_pendingLeftHandIKweight = 0f;
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
					if (playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
									m_localPlayer = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
									return;
								}
							}
						}
					}
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "m_entityPlayer is not ready!");
					return;
				}
				}
			}
		}
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "game session is not ready!");
	}

	public bool c94210167d913c8791d422af746616869()
	{
		int result;
		if (!(m_targetObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			result = (m_hasValidTargetPosition ? 1 : 0);
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	protected Vector3 c73e2bfa4617ac967e7785d3787e0eaba()
	{
		if (m_targetObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					EntityPlayer component = m_targetObject.GetComponent<EntityPlayer>();
					if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								if (component.cc6a7269e9ea93e537de47dc752b09a86() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
								{
									while (true)
									{
										switch (5)
										{
										case 0:
											break;
										default:
											return component.c4fba392e405428b3fd4874067a8b82ac();
										}
									}
								}
								return component.c8cc25ca9fd18f583f33395178ef47f1d();
							}
						}
					}
					return m_targetObject.transform.position;
				}
				}
			}
		}
		return m_targetPosition;
	}

	private void cd13dcbde7f3e5039a70349efc4daf9da(float cccd1dc6c1fa3319aa484fdddb9a35fbb, float cc58e718a5627015e35dec58982a69949)
	{
		if (m_cameraGlow == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (m_targetObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					m_cameraGlow.SetActive(false);
					return;
				}
			}
		}
		EntityPlayer component = m_targetObject.GetComponent<EntityPlayer>();
		if (component == m_localPlayer)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					m_cameraGlow.SetActive(true);
					Color color = m_cameraGlow.renderer.material.GetColor("_TintColor");
					color.a = cc58e718a5627015e35dec58982a69949 * cccd1dc6c1fa3319aa484fdddb9a35fbb * 0.3f;
					m_cameraGlow.renderer.material.SetColor("_TintColor", color);
					return;
				}
				}
			}
		}
		m_cameraGlow.SetActive(false);
	}

	private void c1fed1fc8422d12e325d44383d2fccd52()
	{
		if (!(m_sniperLight != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(m_entityNpcWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (m_enableSniperAim)
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
					if (m_animator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (c94210167d913c8791d422af746616869())
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
							if (!m_animator.GetBool("IsCasual"))
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
								if (m_localPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
								{
									while (true)
									{
										float num;
										float num2;
										RaycastHit[] array;
										Vector3 normalized;
										int num3;
										bool flag;
										Color color;
										Vector3 normalized2;
										float num5;
										float num4;
										switch (6)
										{
										case 0:
											break;
										default:
											{
												m_sniperLight.Play();
												num = 1f;
												float magnitude = (m_localPlayer.c4fba392e405428b3fd4874067a8b82ac() - m_sniperLight.transform.position).magnitude;
												if (magnitude < 15f)
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
													if (magnitude >= 5f)
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
														num = (magnitude - 5f) / 10f;
														goto IL_0173;
													}
												}
												if (magnitude < 5f)
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
													num = 0f;
												}
												else
												{
													num = 1f;
												}
												goto IL_0173;
											}
											IL_0243:
											m_sniperLightDisapperTimer += Time.deltaTime;
											num2 = 1f;
											array = Physics.RaycastAll(m_sniperLight.transform.position, normalized, (m_localPlayer.c4fba392e405428b3fd4874067a8b82ac() - m_entityNpcWeapon.transform.position).magnitude);
											num3 = 0;
											flag = false;
											while (true)
											{
												if (num3 >= array.Length)
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
													break;
												}
												RaycastHit raycastHit = array[num3];
												if (m_localPlayer.collider.attachedRigidbody == raycastHit.collider.attachedRigidbody)
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
													flag = false;
												}
												else
												{
													if (!raycastHit.collider.isTrigger)
													{
														flag = true;
														break;
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
													flag = false;
												}
												num3++;
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
												if (m_sniperLightDisapperTimer > 0.5f)
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
													num2 = 0f;
												}
												else if (m_sniperLightDisapperTimer < 0.5f)
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
													if (m_sniperLightDisapperTimer > 0f)
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
														num2 = (0.5f - m_sniperLightDisapperTimer) / 0.5f;
													}
												}
											}
											else
											{
												num2 = 1f;
												m_sniperLightDisapperTimer = 0f;
											}
											color = m_sniperLight.renderer.material.GetColor("_TintColor");
											color.a = num * num4 * num2;
											m_sniperLight.renderer.material.SetColor("_TintColor", color);
											cd13dcbde7f3e5039a70349efc4daf9da(num2, num);
											return;
											IL_0173:
											normalized2 = (c73e2bfa4617ac967e7785d3787e0eaba() - m_entityNpcWeapon.transform.position).normalized;
											normalized = (m_localPlayer.c4fba392e405428b3fd4874067a8b82ac() - m_entityNpcWeapon.transform.position).normalized;
											num5 = Vector3.Angle(normalized2, normalized);
											num4 = 1f;
											if (num5 < 60f)
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
												if (num5 >= 15f)
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
													num4 = (60f - num5) / 45f;
													goto IL_0243;
												}
											}
											if (num5 < 15f)
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
												num4 = 1f;
											}
											else
											{
												num4 = 0f;
											}
											goto IL_0243;
										}
									}
								}
							}
						}
					}
				}
				m_sniperLight.Stop();
				m_sniperLightDisapperTimer = 0f;
				m_cameraGlow.SetActive(false);
				return;
			}
		}
	}

	private void Update()
	{
		if (m_entityNpc == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (base.gameObject.transform.parent != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_entityNpc = base.gameObject.transform.parent.GetComponent<EntityNpc>();
			}
		}
		if (m_entityNpcWeapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_entityNpc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				AIInventory aIInventory = m_entityNpc.cdcf5e0592c05a681a8470f66674efd0b();
				if (aIInventory != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_entityNpcWeapon = aIInventory.m_weapon;
				}
			}
		}
		c1fed1fc8422d12e325d44383d2fccd52();
	}

	private void OnAnimatorIK(int layerIndex)
	{
		if (m_animator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_animator = GetComponent<Animator>();
		}
		if (m_enableAimIK)
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
			if (c94210167d913c8791d422af746616869())
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
				if (layerIndex == 0)
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
					m_aimIKweight = Mathf.Lerp(m_aimIKweight, 1f, 0.2f);
					Vector3 vector = c73e2bfa4617ac967e7785d3787e0eaba();
					if (m_entityNpc == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (base.gameObject.transform.parent != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							m_entityNpc = base.gameObject.transform.parent.GetComponent<EntityNpc>();
							if (m_entityNpc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								AIInventory aIInventory = m_entityNpc.cdcf5e0592c05a681a8470f66674efd0b();
								if (aIInventory != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
									m_entityNpcWeapon = aIInventory.m_weapon;
								}
							}
						}
					}
					if (m_entityNpc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (m_entityNpc.m_subType == EntityNpc.EntitySubType.CHR_BanditScout)
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
							if (Mathf.Abs(m_animator.GetFloat("fMoveSpeed")) < float.Epsilon)
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
								Vector3 vector2 = vector;
								vector2.y -= m_aimHightOffset;
								Vector3 iKPosition = m_animator.GetIKPosition(AvatarIKGoal.RightHand);
								Vector3 normalized = (vector2 - iKPosition).normalized;
								if (m_entityNpcWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
									m_entityNpcWeapon.transform.forward = normalized;
								}
							}
							goto IL_028e;
						}
					}
					m_animator.SetLookAtWeight(1f * m_aimIKweight, 0.6f * m_aimIKweight, 0.6f * m_aimIKweight, 1f * m_aimIKweight, 0.5f);
					m_animator.SetLookAtPosition(vector);
				}
			}
		}
		else
		{
			m_aimIKweight = 0f;
		}
		goto IL_028e;
		IL_028e:
		if (layerIndex != 1)
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
			if (m_enableLeftHandIK)
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
				cdda1e287dce0fbab9a07cdb40c1a7ab3(m_currentWeaponType, 1f);
				m_pendingLeftHandIK = false;
			}
			if (m_pendingLeftHandIK)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						m_pendingLeftHandIKweight = Mathf.Lerp(m_pendingLeftHandIKweight, 1f, 0.3f);
						cdda1e287dce0fbab9a07cdb40c1a7ab3(m_pendingWeaponType, m_pendingLeftHandIKweight);
						return;
					}
				}
			}
			m_pendingLeftHandIKweight = 0f;
			return;
		}
	}

	public bool cdda1e287dce0fbab9a07cdb40c1a7ab3(WeaponType c27b7430edc94b8f5b543605119ec4a72, float c115a49db0f305d86b716636a3ea5c482)
	{
		if (!(c115a49db0f305d86b716636a3ea5c482 > 1f))
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
			if (!(c115a49db0f305d86b716636a3ea5c482 < 0f))
			{
				goto IL_0043;
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
		c115a49db0f305d86b716636a3ea5c482 = Mathf.Clamp(c115a49db0f305d86b716636a3ea5c482, 0f, 1f);
		goto IL_0043;
		IL_0043:
		if (m_PlayerLeftHandSmg == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c957eb7bd5fb2aef5d3eca9eab35ba4f8();
		}
		Transform transform = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
		switch (c27b7430edc94b8f5b543605119ec4a72)
		{
		case WeaponType.SMG:
			transform = m_PlayerLeftHandSmg;
			break;
		case WeaponType.ShotGun:
			transform = m_PlayerLeftHandShotgun;
			break;
		case WeaponType.SniperRifle:
			transform = m_PlayerLeftHandSniper;
			break;
		case WeaponType.RepeaterPistol:
			transform = m_PlayerLeftHandPistol;
			break;
		case WeaponType.CombatRifle:
			transform = m_PlayerLeftHandCombatRifle;
			break;
		}
		if (transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		m_animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, c115a49db0f305d86b716636a3ea5c482);
		m_animator.SetIKPosition(AvatarIKGoal.LeftHand, transform.position);
		m_animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, c115a49db0f305d86b716636a3ea5c482);
		m_animator.SetIKRotation(AvatarIKGoal.LeftHand, transform.rotation);
		return true;
	}

	public bool c957eb7bd5fb2aef5d3eca9eab35ba4f8()
	{
		if (m_PlayerLeftHandSmg != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_PlayerLeftHandShotgun != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_PlayerLeftHandSniper != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return true;
						}
					}
				}
			}
		}
		Transform[] componentsInChildren = base.gameObject.transform.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			if (transform.gameObject.name.ToLower() == "export_l_hand_smg")
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
				m_PlayerLeftHandSmg = transform;
				continue;
			}
			if (transform.gameObject.name.ToLower() == "export_l_hand_shotgun")
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
				m_PlayerLeftHandShotgun = transform;
				continue;
			}
			if (transform.gameObject.name.ToLower() == "export_l_hand_sniper")
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
				m_PlayerLeftHandSniper = transform;
				continue;
			}
			if (transform.gameObject.name.ToLower() == "export_l_hand_pistol")
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
				m_PlayerLeftHandPistol = transform;
				continue;
			}
			if (!(transform.gameObject.name.ToLower() == "export_l_hand_combatrifle"))
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
				if (!(transform.gameObject.name.ToLower() == "export_l_hand_rifle"))
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
			}
			m_PlayerLeftHandCombatRifle = transform;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (m_PlayerLeftHandSmg != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_PlayerLeftHandShotgun != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (m_PlayerLeftHandSniper != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								return true;
							}
						}
					}
				}
			}
			return false;
		}
	}

	public GameObject c8e92f5daba4d906708741a0b5f7afb19()
	{
		return m_targetObject;
	}
}
