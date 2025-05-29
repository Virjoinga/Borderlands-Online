namespace BHV
{
	public class BHVTaskCoverLookAround : BHVTaskAnimationState
	{
		private BHVTaskParamCoverLookAround c2227ddc7fcbe3fa329465d2fa8ffb479;

		private float c8d6d0618a619c5377bfa2192b652bb59;

		public BHVTaskCoverLookAround()
		{
			base.m_Type = BHVTaskType.CoverLookAround;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamCoverLookAround;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c8d6d0618a619c5377bfa2192b652bb59 = c2227ddc7fcbe3fa329465d2fa8ffb479.c8d6d0618a619c5377bfa2192b652bb59;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.CoverLookAround);
			c8d6d0618a619c5377bfa2192b652bb59 -= deltaTime;
			if (!(c8d6d0618a619c5377bfa2192b652bb59 <= 0f))
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
				c27dba26b1f36450e0fe5aec9ef628804();
				return;
			}
		}
	}
}
