namespace BHV
{
	public class BHVTaskShowWeapon : BHVTaskAnimationState
	{
		private BHVTaskParamShowWeapon c2227ddc7fcbe3fa329465d2fa8ffb479;

		public BHVTaskShowWeapon()
		{
			base.m_Type = BHVTaskType.ShowWeapon;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamShowWeapon;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			if (!cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c39997c2d57776ba3c104737021557daf())
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
				c45bb77f7ef7c0cfb4e9839ab212a467f = State.ccb86e27d3d17a4f78948ef02f4c4412c;
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.ShowWeapon);
		}
	}
}
