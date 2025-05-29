namespace BHV
{
	public class BHVTaskRadiusAttack : BHVTaskAnimationState
	{
		private BHVTaskParamRadiusAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private bool c845b962450271ddddf435500a9d3a099;

		private AnimationRadiusAttackState c5ae9bc249fc03b60cae99eeef154732b;

		public BHVTaskRadiusAttack()
		{
			base.m_Type = BHVTaskType.RadiusAttack;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamRadiusAttack;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c5ae9bc249fc03b60cae99eeef154732b = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("RadiusAttack") as AnimationRadiusAttackState;
			c845b962450271ddddf435500a9d3a099 = false;
			if (!(cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).c90ea3a207cd50bba4ba7c81b9ff2bcb5())
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
				AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.cc5af0a72cac219b86ee5ccc931325456(cfc241af7ab51814fc074e767be1a0bb8.transform.position, c2227ddc7fcbe3fa329465d2fa8ffb479.cbfe48220d0686c9350881808f74550ba);
				return;
			}
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.RadiusAttack);
			if (!c5ae9bc249fc03b60cae99eeef154732b.m_bDoDamage)
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
				if (c845b962450271ddddf435500a9d3a099)
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
					if (cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVRadiusAttackSettings>() == null)
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
						if ((cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).c90ea3a207cd50bba4ba7c81b9ff2bcb5())
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
							AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.cf26f5e09ef041b20e768bbd7e1d13f3a();
						}
						c845b962450271ddddf435500a9d3a099 = true;
						return;
					}
				}
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			if (!(cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).c90ea3a207cd50bba4ba7c81b9ff2bcb5())
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
				AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.cf26f5e09ef041b20e768bbd7e1d13f3a();
				return;
			}
		}
	}
}
