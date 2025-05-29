namespace BHV
{
	public class BHVTaskSlideMoveTo : BHVTask
	{
		private enum State
		{
			c6d1f578be4de6db437a078aa502b0284 = -1,
			c2d86b890ced0b9b0a7b6a6bba58ddc62 = 0,
			ce9251add56fe03f45ea8af9c04dcc059 = 1,
			ccb86e27d3d17a4f78948ef02f4c4412c = 2,
			c9d3c2ab25f15e75fe648bc9b2bb14eb7 = 3
		}

		private BHVTaskParamSlideMoveTo c2227ddc7fcbe3fa329465d2fa8ffb479;

		private State c45bb77f7ef7c0cfb4e9839ab212a467f = State.c6d1f578be4de6db437a078aa502b0284;

		public BHVTaskSlideMoveTo()
		{
			base.m_Type = BHVTaskType.SlideMoveTo;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamSlideMoveTo;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c45bb77f7ef7c0cfb4e9839ab212a467f = State.c2d86b890ced0b9b0a7b6a6bba58ddc62;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			switch (c45bb77f7ef7c0cfb4e9839ab212a467f)
			{
			case State.c6d1f578be4de6db437a078aa502b0284:
				base.m_Status = BHVTaskStatus.FAILED;
				break;
			case State.c2d86b890ced0b9b0a7b6a6bba58ddc62:
				cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVNavAgentSettings>().m_canUseFacingLogic = true;
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.SlideMove);
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.cd295c889c81e8823ba501a609b868079(c2227ddc7fcbe3fa329465d2fa8ffb479.ce3c92525e7a791e903eb8d7b15265b99);
				c45bb77f7ef7c0cfb4e9839ab212a467f = State.ce9251add56fe03f45ea8af9c04dcc059;
				break;
			case State.ce9251add56fe03f45ea8af9c04dcc059:
				break;
			case State.ccb86e27d3d17a4f78948ef02f4c4412c:
				break;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
		}
	}
}
