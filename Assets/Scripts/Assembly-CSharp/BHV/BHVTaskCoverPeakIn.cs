namespace BHV
{
	public class BHVTaskCoverPeakIn : BHVTaskAnimationState
	{
		private BHVTaskParamCoverPeakIn c2227ddc7fcbe3fa329465d2fa8ffb479;

		public BHVTaskCoverPeakIn()
		{
			base.m_Type = BHVTaskType.CoverPeakIn;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamCoverPeakIn;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.CoverPeakIn);
		}
	}
}
