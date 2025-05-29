using A;

namespace BHV
{
	public class BHVTaskWarcry : BHVTaskAnimationState
	{
		private BHVTaskParamWarcry c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationWarcryState c051ea683fd1f0dd7fdcfa66dd0d04996;

		public BHVTaskWarcry()
		{
			base.m_Type = BHVTaskType.Warcry;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamWarcry;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c051ea683fd1f0dd7fdcfa66dd0d04996 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.Warcry)) as AnimationWarcryState;
			if (c051ea683fd1f0dd7fdcfa66dd0d04996 == null)
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
				c051ea683fd1f0dd7fdcfa66dd0d04996.m_WarcryPhase = c2227ddc7fcbe3fa329465d2fa8ffb479.c6cb0ad55015fbddefd0fd66876c7d5f4 - 1;
				return;
			}
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.Warcry);
		}

		private void c7f66ee54711583a655d481a3785164f2()
		{
			ZillaFuryEffect componentInChildren = cfc241af7ab51814fc074e767be1a0bb8.m_entity.GetComponentInChildren<ZillaFuryEffect>();
			if (!(componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				componentInChildren.c7f66ee54711583a655d481a3785164f2();
				return;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			if (!c2227ddc7fcbe3fa329465d2fa8ffb479.c219a696a1a78b8a7787c1c5082d9c00d)
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
				c7f66ee54711583a655d481a3785164f2();
				return;
			}
		}
	}
}
