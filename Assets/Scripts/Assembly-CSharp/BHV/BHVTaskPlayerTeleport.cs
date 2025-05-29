using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskPlayerTeleport : BHVTask
	{
		private BHVTaskParamPlayerTeleport c2227ddc7fcbe3fa329465d2fa8ffb479;

		private float c2077b0a8c0681969c1087ffd2d18c259 = 4f;

		private Vector3 c6c15e249cd1ab294d1d599b27c3e4425;

		private Vector3 cbcba01d89b55adbfb9f6cf727d34b8ae;

		private GameObject c35121fea2aaab608ce4e6a4a44081704;

		private bool c6db23da7b30ce8545694dc567831d581;

		private bool cc5ded6525c7f2ddcdab585faee6b41c0;

		private bool cfd17cc17130e3e41b7ada46fdba969bf;

		private PlayerController caa5d6f0023e04ceaacf94554b836d4a0;

		public BHVTaskPlayerTeleport()
		{
			base.m_Type = BHVTaskType.PlayerTeleport;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamPlayerTeleport;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c2077b0a8c0681969c1087ffd2d18c259 = c2227ddc7fcbe3fa329465d2fa8ffb479.ca87f7a171027e8176ea195a9a92f70f4 + 1f;
			c6db23da7b30ce8545694dc567831d581 = false;
			cfd17cc17130e3e41b7ada46fdba969bf = false;
			cc5ded6525c7f2ddcdab585faee6b41c0 = false;
			caa5d6f0023e04ceaacf94554b836d4a0 = c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64.GetComponent<PlayerController>();
			if (c35121fea2aaab608ce4e6a4a44081704 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c35121fea2aaab608ce4e6a4a44081704 = GameObject.Find("BOSS_TELE_PLAYER");
				if (c35121fea2aaab608ce4e6a4a44081704 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					cbcba01d89b55adbfb9f6cf727d34b8ae = c35121fea2aaab608ce4e6a4a44081704.transform.position;
				}
			}
			if (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c6c15e249cd1ab294d1d599b27c3e4425 = c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64.transform.position;
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_PlayerTeleportAbsorb, c6c15e249cd1ab294d1d599b27c3e4425);
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bAttackWarning", true);
		}

		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
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
			base.Update(deltaTime);
			c2077b0a8c0681969c1087ffd2d18c259 -= Time.deltaTime;
			if (!c6db23da7b30ce8545694dc567831d581)
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
				if (c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (caa5d6f0023e04ceaacf94554b836d4a0 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if ((c6c15e249cd1ab294d1d599b27c3e4425 - c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64.transform.position).sqrMagnitude < c2227ddc7fcbe3fa329465d2fa8ffb479.ce744e5319e80ee316e783f0fce8ad670 * c2227ddc7fcbe3fa329465d2fa8ffb479.ce744e5319e80ee316e783f0fce8ad670)
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
							if (!cc5ded6525c7f2ddcdab585faee6b41c0)
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
								caa5d6f0023e04ceaacf94554b836d4a0.c63ee313b87b770d38877f71939e90417(c2227ddc7fcbe3fa329465d2fa8ffb479.cb0600547448517b2371af69450201ec5);
								cc5ded6525c7f2ddcdab585faee6b41c0 = true;
							}
						}
						else if (cc5ded6525c7f2ddcdab585faee6b41c0)
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
							caa5d6f0023e04ceaacf94554b836d4a0.c63ee313b87b770d38877f71939e90417(1f / c2227ddc7fcbe3fa329465d2fa8ffb479.cb0600547448517b2371af69450201ec5);
							cc5ded6525c7f2ddcdab585faee6b41c0 = false;
						}
					}
				}
			}
			if (c2077b0a8c0681969c1087ffd2d18c259 < 1f)
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
				if (!c6db23da7b30ce8545694dc567831d581)
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
					if (cc5ded6525c7f2ddcdab585faee6b41c0)
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
						MovementSync component = c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64.GetComponent<MovementSync>();
						if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						}
					}
					c6db23da7b30ce8545694dc567831d581 = true;
				}
			}
			if (c6db23da7b30ce8545694dc567831d581)
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
				if (!cfd17cc17130e3e41b7ada46fdba969bf)
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
					if ((c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64.transform.position - cbcba01d89b55adbfb9f6cf727d34b8ae).sqrMagnitude < 1f)
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
						c9c0fb17d9c2b63398f82c32bafc749ec();
						cfd17cc17130e3e41b7ada46fdba969bf = true;
					}
				}
			}
			if (!(c2077b0a8c0681969c1087ffd2d18c259 < 0f))
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
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			if (cc5ded6525c7f2ddcdab585faee6b41c0)
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
				if (caa5d6f0023e04ceaacf94554b836d4a0 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					caa5d6f0023e04ceaacf94554b836d4a0.c63ee313b87b770d38877f71939e90417(1f / c2227ddc7fcbe3fa329465d2fa8ffb479.cb0600547448517b2371af69450201ec5);
				}
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
					c6c15e249cd1ab294d1d599b27c3e4425 = c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64.transform.position;
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_PlayerTeleportRelease, c6c15e249cd1ab294d1d599b27c3e4425);
				}
				if (!cfd17cc17130e3e41b7ada46fdba969bf)
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
					c9c0fb17d9c2b63398f82c32bafc749ec();
				}
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bAttackWarning", false);
		}

		private void c9c0fb17d9c2b63398f82c32bafc749ec()
		{
			ParticleEffect[] componentsInChildren = c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64.GetComponentsInChildren<ParticleEffect>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (!(componentsInChildren[i].m_myName == "PlayRevive"))
				{
					continue;
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				ParticleSystem particleSystem = (ParticleSystem)Object.Instantiate(componentsInChildren[i].m_effect);
				particleSystem.transform.position = c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64.transform.position;
				particleSystem.transform.rotation = Quaternion.Euler(270f, 0f, 0f);
				particleSystem.transform.parent = c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64.transform;
				if (!particleSystem.playOnAwake)
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
					particleSystem.Play();
				}
				Object.Destroy(particleSystem.gameObject, 3f);
			}
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
	}
}
