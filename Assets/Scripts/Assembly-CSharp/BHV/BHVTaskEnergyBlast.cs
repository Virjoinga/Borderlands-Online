using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskEnergyBlast : BHVTask
	{
		private BHVTaskParamEnergyBlast c2227ddc7fcbe3fa329465d2fa8ffb479;

		private bool cc358350f35e19d49efd6dce1d24747e2;

		private Object ced77abc53b39e5f4bc9e54686a35567d;

		private Vector3 c90eed506e58e58546f7e5b2e242da752;

		public BHVTaskEnergyBlast()
		{
			base.m_Type = BHVTaskType.EnergyBlast;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamEnergyBlast;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			if (cfc241af7ab51814fc074e767be1a0bb8 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (cfc241af7ab51814fc074e767be1a0bb8.m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bEnergyBlaster", true);
				}
			}
			if (ced77abc53b39e5f4bc9e54686a35567d == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				ced77abc53b39e5f4bc9e54686a35567d = (cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).m_spawnObjPrefabList[0];
			}
			cc358350f35e19d49efd6dce1d24747e2 = false;
			if (c2227ddc7fcbe3fa329465d2fa8ffb479 == null)
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
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c90eed506e58e58546f7e5b2e242da752 = c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64.transform.position;
			if (!(cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).c90ea3a207cd50bba4ba7c81b9ff2bcb5())
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
				float cbac8b1e8ba44d23d7b3364e72446ccf = Mathf.Clamp(c2227ddc7fcbe3fa329465d2fa8ffb479.c96b73df2e38746423d4a344a16dad21d, 1f, c2227ddc7fcbe3fa329465d2fa8ffb479.c96b73df2e38746423d4a344a16dad21d);
				AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.cc5af0a72cac219b86ee5ccc931325456(c90eed506e58e58546f7e5b2e242da752, cbac8b1e8ba44d23d7b3364e72446ccf);
				return;
			}
		}

		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
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
			base.Update(deltaTime);
			AnimatorStateInfo currentAnimatorStateInfo = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0);
			if (!currentAnimatorStateInfo.IsTag("EnergyBlast"))
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
				if (!cc358350f35e19d49efd6dce1d24747e2)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							if (currentAnimatorStateInfo.normalizedTime > 0.5f)
							{
								while (true)
								{
									switch (6)
									{
									case 0:
										break;
									default:
										if (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
											cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_ArchangelOpenFace, cfc241af7ab51814fc074e767be1a0bb8.m_entity, (cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).m_headTransform, Vector3.zero, Quaternion.identity, 5f);
										}
										cc358350f35e19d49efd6dce1d24747e2 = true;
										if (ced77abc53b39e5f4bc9e54686a35567d != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
										{
											while (true)
											{
												switch (3)
												{
												case 0:
													break;
												default:
													if (c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
													{
														while (true)
														{
															switch (3)
															{
															case 0:
																break;
															default:
															{
																GameObject gameObject = (GameObject)Object.Instantiate(ced77abc53b39e5f4bc9e54686a35567d, c90eed506e58e58546f7e5b2e242da752, Quaternion.identity);
																if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
																{
																	while (true)
																	{
																		switch (2)
																		{
																		case 0:
																			break;
																		default:
																		{
																			EnergyBlast component = gameObject.GetComponent<EnergyBlast>();
																			component.m_taskManager = cfc241af7ab51814fc074e767be1a0bb8;
																			component.m_delayTimer = c2227ddc7fcbe3fa329465d2fa8ffb479.ca8e64932c38c6e6fbc8e7a37caa55b3c;
																			return;
																		}
																		}
																	}
																}
																return;
															}
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
				if (!(currentAnimatorStateInfo.normalizedTime > 0.97f))
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
					AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.cf26f5e09ef041b20e768bbd7e1d13f3a();
					base.m_Status = BHVTaskStatus.SUCCESS;
					return;
				}
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bEnergyBlaster", false);
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.cf26f5e09ef041b20e768bbd7e1d13f3a();
		}
	}
}
