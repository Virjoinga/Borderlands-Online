using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskSpit : BHVTask
	{
		private BHVTaskParamSpit c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationSpitState c5dd4c5d9bccb8b2ad75622ebe70a1e91;

		private GameObject cf15264149d1fc20653cb21324b8fb4cc;

		private AIServiceCurve.Curve c7670123a80282f7fb0a8499f2726859e;

		private Vector3 cae073684178dc3e9118c0085b4608051;

		private float cd2febac5f1c0b2396c6588ca20a63afd;

		public BHVTaskSpit()
		{
			base.m_Type = BHVTaskType.Spit;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamSpit;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			cf15264149d1fc20653cb21324b8fb4cc = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
			cd2febac5f1c0b2396c6588ca20a63afd = 0f;
			c5dd4c5d9bccb8b2ad75622ebe70a1e91 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("Spit") as AnimationSpitState;
			if (c5dd4c5d9bccb8b2ad75622ebe70a1e91 != null)
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
				c5dd4c5d9bccb8b2ad75622ebe70a1e91.m_spitAttackIndex = c2227ddc7fcbe3fa329465d2fa8ffb479.c7156b2a1d5fa4abd74f23a8857e87318;
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.Spit);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				while (true)
				{
					switch (3)
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
			cb9639a2fcbb63d05803cb6f04384c8ca();
			Vector3 vector = c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c.transform.position + Vector3.up * 1.4f;
			if (cf15264149d1fc20653cb21324b8fb4cc == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						cf15264149d1fc20653cb21324b8fb4cc = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.caa7c42ac554726b9f073f5a59404e5b5();
						if (cf15264149d1fc20653cb21324b8fb4cc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							c7670123a80282f7fb0a8499f2726859e = AIServiceCurve.c5ee19dc8d4cccf5ae2de225410458b86.cd440a8b2fe2065c9cd33808285d3d764(AIServiceCurve.ECurveType.ESpitCurve, cf15264149d1fc20653cb21324b8fb4cc.transform.position, vector);
						}
						if (c5dd4c5d9bccb8b2ad75622ebe70a1e91.m_bSpitAttackAnimFinished)
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									break;
								default:
									if (cf15264149d1fc20653cb21324b8fb4cc == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
									{
										while (true)
										{
											switch (2)
											{
											case 0:
												break;
											default:
												cd2febac5f1c0b2396c6588ca20a63afd += deltaTime;
												if (cd2febac5f1c0b2396c6588ca20a63afd > 2f)
												{
													while (true)
													{
														switch (5)
														{
														case 0:
															break;
														default:
															base.m_Status = BHVTaskStatus.SUCCESS;
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
			bool flag = c7670123a80282f7fb0a8499f2726859e.Update(deltaTime, 18f, out cae073684178dc3e9118c0085b4608051);
			cf15264149d1fc20653cb21324b8fb4cc.transform.forward = (cae073684178dc3e9118c0085b4608051 - cf15264149d1fc20653cb21324b8fb4cc.transform.position).normalized;
			if ((cf15264149d1fc20653cb21324b8fb4cc.transform.position - vector).sqrMagnitude < 0.64f)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						cc802177c1eb91081e66d2391055dda41();
						return;
					}
				}
			}
			cf15264149d1fc20653cb21324b8fb4cc.transform.position = cae073684178dc3e9118c0085b4608051;
			if (!flag)
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
				cc802177c1eb91081e66d2391055dda41();
				return;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			c5dd4c5d9bccb8b2ad75622ebe70a1e91.c026b86b80b40f849c0d707e8b70266be(false);
			if (!(cf15264149d1fc20653cb21324b8fb4cc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				Object.Destroy(cf15264149d1fc20653cb21324b8fb4cc);
				return;
			}
		}

		private void cb9639a2fcbb63d05803cb6f04384c8ca()
		{
			Vector3 normalized = (c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c.transform.position - cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position).normalized;
			normalized.y = 0f;
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward = Vector3.Slerp(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, normalized, Time.deltaTime * 2f);
		}

		private void cc802177c1eb91081e66d2391055dda41()
		{
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.cb082f0bd0e14bac93e6ee86bb882c71d(ENPCParticleType.E_DamageSpitAtTouchedObject, cf15264149d1fc20653cb21324b8fb4cc.transform);
			VFXforNPC[] particleList = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager.m_particleList;
			for (int i = 0; i < particleList.Length; i++)
			{
				if (particleList[i].m_type != ENPCParticleType.E_DamageSpitAtTouchedObject)
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
				particleList[i].m_particleGameObject.GetComponent<BaseEventTriggerCtl>().TriggerEventByName("Corrosive_Blast_Small_Rnd");
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				Object.Destroy(cf15264149d1fc20653cb21324b8fb4cc);
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}
	}
}
