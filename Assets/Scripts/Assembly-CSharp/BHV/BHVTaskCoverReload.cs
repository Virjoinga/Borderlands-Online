namespace BHV
{
	public class BHVTaskCoverReload : BHVTaskAnimationState
	{
		private BHVTaskParamCoverReload c2227ddc7fcbe3fa329465d2fa8ffb479;

		public BHVTaskCoverReload()
		{
			base.m_Type = BHVTaskType.CoverReload;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamCoverReload;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Update(float deltaTime)
		{
			State state = c45bb77f7ef7c0cfb4e9839ab212a467f;
			base.Update(deltaTime, AnimationStateFSM.CoverReload);
			if (state != 0)
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
				if (c45bb77f7ef7c0cfb4e9839ab212a467f != State.c1d3e2cf1545b9321547e6a21bb58bfb3)
				{
					return;
				}
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
		}
	}
}
