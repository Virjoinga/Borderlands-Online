using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public abstract class NPCAnimationManagerFSM : AnimationManagerFSM
{
	public bool m_bInDazeEffect;

	public MecanimEventEmitter m_mecanimEventEmitter;

	protected Vector3 m_vZero = Vector3.zero;

	protected Quaternion m_identityRot = Quaternion.identity;

	protected Vector3 m_pelvisPosition = Vector3.zero;

	protected Quaternion m_pelvisRotation = Quaternion.identity;

	protected Transform m_pelvis;

	private Material[] m_originalMaterials;

	private Material[] m_deathMaterials;

	private float m_fadingTime = 30f;

	private bool m_beginDeathFading;

	private float m_currentTime;

	public override bool ceb70887701f0c688b6ddc239066fdda5(string ce6be564ae39a9af3aff0a170d981d7b6)
	{
		return true;
	}

	public void c20e2314b46c8284e3ff42ed88515ca1e(EntityNpc.EntitySubType c22a75c71fa78ee19ac7d9915d41a0c01)
	{
		uint key = Utility.cf642a65627df2adf4e90330457651907(c22a75c71fa78ee19ac7d9915d41a0c01.ToString());
		if (!AIServiceSetting.c5ee19dc8d4cccf5ae2de225410458b86.m_npcAnimationMgrSetupList.TryGetValue(key, out m_setup))
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.AI, "Not find setting for " + c22a75c71fa78ee19ac7d9915d41a0c01);
		}
		AIServiceSetting.c5ee19dc8d4cccf5ae2de225410458b86.c3e8b1cf5056bc530491730c7a01bb983(c22a75c71fa78ee19ac7d9915d41a0c01, this);
	}

	protected void c0af5cff3e7daf4a4ce3d85a68c0b7f83()
	{
		if (m_animationHost != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			base.ccaaf181e61e5f9e050ba82237ed111a2 = m_animationHost.GetComponent<Animator>();
		}
		if (base.ccaaf181e61e5f9e050ba82237ed111a2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			base.ccaaf181e61e5f9e050ba82237ed111a2 = base.gameObject.GetComponentInChildren<Animator>();
		}
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
			m_animationHost = base.ccaaf181e61e5f9e050ba82237ed111a2.gameObject;
			for (int i = 0; i < base.ccaaf181e61e5f9e050ba82237ed111a2.layerCount; i++)
			{
				base.ccaaf181e61e5f9e050ba82237ed111a2.SetLayerWeight(i, 1f);
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (m_animationHost.transform.parent != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_modelScale = m_animationHost.transform.parent.localScale.x;
				}
				else
				{
					m_modelScale = m_animationHost.transform.localScale.x;
				}
				m_VFXManager = m_animationHost.GetComponent<VFXManager>();
				base.ccaaf181e61e5f9e050ba82237ed111a2.updateMode = AnimatorUpdateMode.Normal;
				cd6f933bd268aaf1967c46349307f50eb(false);
				m_canUseRootMotionPrevious = false;
				return;
			}
		}
	}

	private void Awake()
	{
		ccbfe57a4b004792a76407d3ee998c01e();
	}

	public override void Start()
	{
		c0af5cff3e7daf4a4ce3d85a68c0b7f83();
		base.Start();
		using (Dictionary<string, ce972fd150f340044b329bd2758a9cacc>.ValueCollection.Enumerator enumerator = m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ce972fd150f340044b329bd2758a9cacc current = enumerator.Current;
				if (!(current is AnimationManagerState))
				{
					continue;
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				(current as AnimationManagerState).ccc9d3a38966dc10fedb531ea17d24611(this);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					goto end_IL_0064;
				}
				continue;
				end_IL_0064:
				break;
			}
		}
		if (m_upperBodyStateMachine != null)
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
			using (Dictionary<string, ce972fd150f340044b329bd2758a9cacc>.ValueCollection.Enumerator enumerator2 = m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Values.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					ce972fd150f340044b329bd2758a9cacc current2 = enumerator2.Current;
					if (!(current2 is AnimationManagerState))
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
					(current2 as AnimationManagerState).ccc9d3a38966dc10fedb531ea17d24611(this);
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_00dd;
					}
					continue;
					end_IL_00dd:
					break;
				}
			}
		}
		m_bInDazeEffect = false;
		if (!(base.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (m_entity is EntityNpc)
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
				base.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("iEntitySubType", (int)(m_entity as EntityNpc).m_subType);
			}
			m_mecanimEventEmitter = base.ccaaf181e61e5f9e050ba82237ed111a2.GetComponent<MecanimEventEmitter>();
			if (!(m_mecanimEventEmitter != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_mecanimEventEmitter.emitType = MecanimEventEmitTypes.Upwards;
				return;
			}
		}
	}

	public virtual void c2fee075e4a1b0f8c507d7c8a821f5719(WeakPoint.PartInfo c76fc0034391c602fa96b58c36512a097)
	{
	}

	public virtual void LateUpdate()
	{
		if (m_animationHost == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		if (m_animationStateMachine.m_curState == null)
		{
			return;
		}
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

	public virtual void OnTriggerAdvanceSpawn()
	{
		AnimationAdvanceSpawnState animationAdvanceSpawnState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.AdvanceSpawn)) as AnimationAdvanceSpawnState;
		if (animationAdvanceSpawnState != null)
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
			animationAdvanceSpawnState.m_colliderTriggered = true;
		}
		AnimationCombatSpawnState animationCombatSpawnState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.CombatSpawn)) as AnimationCombatSpawnState;
		if (animationCombatSpawnState == null)
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
			animationCombatSpawnState.m_colliderTriggered = true;
			return;
		}
	}

	public void OnThrowWeapon()
	{
		AnimationThrowWeaponState animationThrowWeaponState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.ThrowWeapon)) as AnimationThrowWeaponState;
		if (animationThrowWeaponState == null)
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
			animationThrowWeaponState.m_readyToLaunch = true;
			return;
		}
	}

	public virtual bool cb8d9250c127e7972859f95eb98e07445()
	{
		EntityNpc entityNpc = m_entity as EntityNpc;
		if (entityNpc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (entityNpc.m_subType != EntityNpc.EntitySubType.CHR_BadassSpiderantWorker)
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
				if (entityNpc.m_subType != EntityNpc.EntitySubType.CHR_BadassVkag)
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
					if (entityNpc.m_subType != EntityNpc.EntitySubType.CHR_CrimsonMechaKnoxx)
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
						if (entityNpc.m_subType != EntityNpc.EntitySubType.CHR_SkagAdult)
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
							if (entityNpc.m_subType != EntityNpc.EntitySubType.CHR_SkagAlpha)
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
								if (entityNpc.m_subType != EntityNpc.EntitySubType.CHR_SkagPup)
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
									if (entityNpc.m_subType != EntityNpc.EntitySubType.CHR_SkagSpitter)
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
										if (entityNpc.m_subType != EntityNpc.EntitySubType.CHR_SkagZilla)
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
											if (entityNpc.m_subType != EntityNpc.EntitySubType.CHR_SpiderantTalos)
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
												if (entityNpc.m_subType != EntityNpc.EntitySubType.CHR_SpiderantWidowmaker)
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
													if (entityNpc.m_subType != EntityNpc.EntitySubType.CHR_SpiderantWorker)
													{
														goto IL_0119;
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
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return true;
		}
		goto IL_0119;
		IL_0119:
		return false;
	}

	public void OnMeleeHit()
	{
		AnimationMeleeAttackState animationMeleeAttackState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.MeleeAttack)) as AnimationMeleeAttackState;
		if (animationMeleeAttackState == null)
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
			animationMeleeAttackState.m_triggetHitEvent = true;
			return;
		}
	}

	public virtual void c6d990a8ab1adfc44722a078a44954178()
	{
	}

	public virtual void cdd2f24f8d58571ac78fbd3493e1022b2()
	{
	}

	private void ccbfe57a4b004792a76407d3ee998c01e()
	{
		if (!(m_pelvis == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
			int num = componentsInChildren.Length;
			for (int i = 0; i < num; i++)
			{
				Transform transform = componentsInChildren[i];
				if (!transform.name.ToLower().Contains("pelvis"))
				{
					continue;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					m_pelvis = transform;
					m_pelvisPosition = m_pelvis.localPosition;
					m_pelvisRotation = m_pelvis.localRotation;
					return;
				}
			}
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
	}

	public void c913fe3a12dbcfe01fe7b91de8c590cb0(bool c88d68571187794f20619d4ad3172afbd = false)
	{
		if (m_pelvis == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		if (!c88d68571187794f20619d4ad3172afbd)
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
			if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Die))
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
				break;
			}
			if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.Dead))
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
		m_pelvis.localPosition = m_pelvisPosition;
		m_pelvis.localRotation = m_pelvisRotation;
	}

	public virtual void OnNpcRespawn()
	{
		c2351b5168c48a14c25a733a532f9a41e(true);
		c33f9c3a5a9687f3762dcd02c6dd2d0e2(RagdollOperationType.Disable);
		c913fe3a12dbcfe01fe7b91de8c590cb0(true);
		if (base.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			base.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsDying", false);
			base.ccaaf181e61e5f9e050ba82237ed111a2.SetTrigger("tRespawn");
			if (m_isHumanoid)
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
				base.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCasual", true);
				base.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("FaceAngle", 0f);
				base.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsMoveBackward", false);
				base.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("CrouchStatus", 0);
				base.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCrouching", false);
				base.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("StanceMode", 0);
				base.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fSprintMode", 0f);
			}
			base.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fMoveSpeed", 0f);
			base.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMove", false);
			base.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bIdle", true);
			base.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsTurning", false);
			base.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fTurnAngle", 0f);
		}
		if (m_animationHost != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_animationHost.transform.localPosition = Vector3.zero;
			m_animationHost.transform.localRotation = Quaternion.identity;
		}
		if (base.c915fd0f71703e34ea30c40c33035a630 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			SkinnedMeshRenderer component = base.c915fd0f71703e34ea30c40c33035a630.GetComponent<SkinnedMeshRenderer>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				component.castShadows = true;
				component.receiveShadows = true;
				component.updateWhenOffscreen = false;
			}
		}
		c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.Idle);
	}

	public override void Update()
	{
		base.Update();
		if (!m_beginDeathFading)
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
			if (!(base.c915fd0f71703e34ea30c40c33035a630 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_currentTime += Time.deltaTime;
				SkinnedMeshRenderer component = base.c915fd0f71703e34ea30c40c33035a630.GetComponent<SkinnedMeshRenderer>();
				if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					for (int i = 0; i < component.materials.Length; i++)
					{
						component.materials[i].SetFloat("_CurrentTime", m_currentTime);
					}
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
			}
		}
	}

	protected void cba18474a8da97f54b1e49ec64dde37a0()
	{
		if (m_deathMaterials == null)
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
			for (int i = 0; i < m_deathMaterials.Length; i++)
			{
				Object.Destroy(m_deathMaterials[i]);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				m_deathMaterials = c4a89cc7ff58be6b4a23285e77aabc482.c7088de59e49f7108f520cf7e0bae167e;
				return;
			}
		}
	}

	public void ca63de49b82d676c4bacd5359997b3dba()
	{
		if (base.c915fd0f71703e34ea30c40c33035a630 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		SkinnedMeshRenderer component = base.c915fd0f71703e34ea30c40c33035a630.GetComponent<SkinnedMeshRenderer>();
		if (component == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		component.receiveShadows = false;
		component.castShadows = false;
		if (m_deathMaterials != null)
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
			if (component.materials.Length == m_deathMaterials.Length)
			{
				goto IL_0170;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		cba18474a8da97f54b1e49ec64dde37a0();
		CharacterDeathEffectData component2 = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<CharacterDeathEffectData>();
		if (component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_fadingTime = component2.FadingTime;
		}
		m_deathMaterials = cb49f36706caafb4b94436f6a37599753.c0a0cdf4a196914163f7334d9b0781a04(component.materials.Length);
		for (int i = 0; i < component.materials.Length; i++)
		{
			m_deathMaterials[i] = new Material(Shader.Find("Custom/BOL_Charactor_BRDF_DeathFading"));
			m_deathMaterials[i].CopyPropertiesFromMaterial(component.materials[i]);
			if (!(component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				continue;
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
			m_deathMaterials[i].SetTexture("_FadingMap", component2.FadingTexture);
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
		goto IL_0170;
		IL_0170:
		for (int j = 0; j < m_deathMaterials.Length; j++)
		{
			m_deathMaterials[j].SetFloat("_Fading_Time", m_fadingTime);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			m_originalMaterials = component.renderer.materials;
			component.renderer.materials = m_deathMaterials;
			m_currentTime = 0f;
			m_beginDeathFading = true;
			WeakPoint c38b98045365f4b50a4fbe3f1d89af = c581015e4f6ee9df70e01d3565f2f7aca.c7088de59e49f7108f520cf7e0bae167e;
			m_entity.c659e11237d268aac8b68c419cf6b053a(out c38b98045365f4b50a4fbe3f1d89af);
			if (c38b98045365f4b50a4fbe3f1d89af != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						m_VFXManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_DeadEffect, null, c38b98045365f4b50a4fbe3f1d89af.transform, m_vZero, m_identityRot, -1f);
						return;
					}
				}
			}
			m_VFXManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_DeadEffect, null, base.c915fd0f71703e34ea30c40c33035a630, m_vZero, m_identityRot, -1f);
			return;
		}
	}

	public void c61302ae1bd2c6402fa5cf4ba5697da7f()
	{
		if (base.c915fd0f71703e34ea30c40c33035a630 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_originalMaterials != null)
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
		}
		SkinnedMeshRenderer component = base.c915fd0f71703e34ea30c40c33035a630.GetComponent<SkinnedMeshRenderer>();
		if (component == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		component.renderer.materials = m_originalMaterials;
		m_originalMaterials = c4a89cc7ff58be6b4a23285e77aabc482.c7088de59e49f7108f520cf7e0bae167e;
		m_currentTime = 0f;
		m_beginDeathFading = false;
	}
}
