namespace BHV
{
	public class BHVTaskDrillAttack : BHVTask
	{
		private BHVTaskParamDrillAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private BHVTaskDrillAttackSettings c0859aad0cdaa1294f51f5a5e796546ba;

		private float c588e32794066adce62c15ff7e74ad1e1 = 3f;

		private float cc4992052077ed5a6ff3dcc120d2bf3f3 = 1f;

		private bool cb68ec3343e41c40b44f8ac09631216e5;

		private Entity ce1e7a598367c55ecf2058047b5bb8545;

		public BHVTaskDrillAttack()
		{
			base.m_Type = BHVTaskType.DrillAttack;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamDrillAttack;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			if (c0859aad0cdaa1294f51f5a5e796546ba == null)
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
				c0859aad0cdaa1294f51f5a5e796546ba = cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVTaskDrillAttackSettings>();
			}
			c588e32794066adce62c15ff7e74ad1e1 = c0859aad0cdaa1294f51f5a5e796546ba.m_drillDuration;
			cb68ec3343e41c40b44f8ac09631216e5 = false;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("DrillAttackStep", 1);
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsAlert", false);
			ce1e7a598367c55ecf2058047b5bb8545 = c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64.GetComponent<Entity>();
			cc4992052077ed5a6ff3dcc120d2bf3f3 = 1f;
		}

		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
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
			base.Update(deltaTime);
			if (cb68ec3343e41c40b44f8ac09631216e5)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						cc4992052077ed5a6ff3dcc120d2bf3f3 -= deltaTime;
						if (cc4992052077ed5a6ff3dcc120d2bf3f3 < 0f)
						{
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("DrillAttackStep", 2);
									if (c0859aad0cdaa1294f51f5a5e796546ba.m_bKnockback)
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
										if ((ce1e7a598367c55ecf2058047b5bb8545.transform.position - cfc241af7ab51814fc074e767be1a0bb8.transform.position).sqrMagnitude < 0.5f)
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
											(cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).c2752f2e288d1e93ed4cdbb91832ec547(ce1e7a598367c55ecf2058047b5bb8545);
										}
									}
									base.m_Status = BHVTaskStatus.SUCCESS;
									return;
								}
							}
						}
						return;
					}
				}
			}
			c588e32794066adce62c15ff7e74ad1e1 -= deltaTime;
			if (!(c588e32794066adce62c15ff7e74ad1e1 < 0f))
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
				cb68ec3343e41c40b44f8ac09631216e5 = true;
				return;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
		}
	}
}
