namespace BHV
{
	public class BHVTaskRoll : BHVTaskAnimationState
	{
		private BHVTaskParamRoll c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationRollState c5991791c21fe870f3e3a55f232de0ef6;

		public BHVTaskRoll()
		{
			base.m_Type = BHVTaskType.Roll;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamRoll;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			if (c5991791c21fe870f3e3a55f232de0ef6 == null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c5991791c21fe870f3e3a55f232de0ef6 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.Roll)) as AnimationRollState;
			}
			if (c5991791c21fe870f3e3a55f232de0ef6 == null)
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
				c5991791c21fe870f3e3a55f232de0ef6.m_isSideStep = false;
				c5991791c21fe870f3e3a55f232de0ef6.m_isDodgeRight = c2227ddc7fcbe3fa329465d2fa8ffb479.c2709c6a07153f2c4768a8d9a4995c0cd;
				return;
			}
		}

		public override void Update(float deltaTime)
		{
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.c3bf54d312726877e5f77b6d475aef510();
			base.Update(deltaTime, AnimationStateFSM.Roll);
		}
	}
}
