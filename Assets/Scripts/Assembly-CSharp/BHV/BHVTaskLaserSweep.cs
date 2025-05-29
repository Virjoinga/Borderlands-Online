using A;

namespace BHV
{
	public class BHVTaskLaserSweep : BHVTask
	{
		private BHVTaskParamLaserSweep c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationLaserSweepState c0e835fc92c02e497523bac7563ad89a0;

		public BHVTaskLaserSweep()
		{
			base.m_Type = BHVTaskType.LaserSweep;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamLaserSweep;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c0e835fc92c02e497523bac7563ad89a0 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("LaserSweep") as AnimationLaserSweepState;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.LaserSweep);
			base.m_Status = BHVTaskStatus.RUNNING;
			CrimsonMechaKnoxxAnimationManagerFSM crimsonMechaKnoxxAnimationManagerFSM = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as CrimsonMechaKnoxxAnimationManagerFSM;
			if (!(crimsonMechaKnoxxAnimationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				crimsonMechaKnoxxAnimationManagerFSM.m_bLaserSweepStart = true;
				return;
			}
		}

		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
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
			base.Update(deltaTime);
			if (c0e835fc92c02e497523bac7563ad89a0.m_status != AnimationStatus.SUCCESS)
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
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			CrimsonMechaKnoxxAnimationManagerFSM crimsonMechaKnoxxAnimationManagerFSM = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as CrimsonMechaKnoxxAnimationManagerFSM;
			if (!(crimsonMechaKnoxxAnimationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				crimsonMechaKnoxxAnimationManagerFSM.cf92b766e7d91cab682055f264093a281();
				crimsonMechaKnoxxAnimationManagerFSM.caf725283d5fff82791624827b131c5eb();
				crimsonMechaKnoxxAnimationManagerFSM.m_bLaserSweepStart = false;
				return;
			}
		}
	}
}
