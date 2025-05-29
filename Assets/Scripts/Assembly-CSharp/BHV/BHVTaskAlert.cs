namespace BHV
{
	public class BHVTaskAlert : BHVTaskAnimationState
	{
		private BHVTaskParamAlert c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationAlertState ccde4212065122982935d093476d1c690;

		public BHVTaskAlert()
		{
			base.m_Type = BHVTaskType.Alert;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamAlert;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			if (ccde4212065122982935d093476d1c690 == null)
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
				ccde4212065122982935d093476d1c690 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.Alert)) as AnimationAlertState;
			}
			if (ccde4212065122982935d093476d1c690 == null)
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
				ccde4212065122982935d093476d1c690.m_isWarning = c2227ddc7fcbe3fa329465d2fa8ffb479.cc7d81a8db99fcd83e60b136f2338a19c;
				return;
			}
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.Alert);
		}
	}
}
