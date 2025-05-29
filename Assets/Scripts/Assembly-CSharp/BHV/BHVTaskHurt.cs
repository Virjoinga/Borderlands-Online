namespace BHV
{
	public class BHVTaskHurt : BHVTaskAnimationState
	{
		private BHVTaskParamHurt c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationHurtState c21cc532f6821c5b7f4c9ffe258d03ae0;

		public BHVTaskHurt()
		{
			base.m_Type = BHVTaskType.Hurt;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamHurt;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			if (c21cc532f6821c5b7f4c9ffe258d03ae0 == null)
			{
				while (true)
				{
					switch (5)
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
				c21cc532f6821c5b7f4c9ffe258d03ae0 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.Hurt)) as AnimationHurtState;
			}
			if (c21cc532f6821c5b7f4c9ffe258d03ae0 == null)
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
				c21cc532f6821c5b7f4c9ffe258d03ae0.m_damageType = c2227ddc7fcbe3fa329465d2fa8ffb479.cba943e9241e86ef410ecc99294660143;
				c21cc532f6821c5b7f4c9ffe258d03ae0.m_heavyHurtAnimIndex = c2227ddc7fcbe3fa329465d2fa8ffb479.cb8205628bc070a20f3fb0d80dbfef005;
				return;
			}
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.Hurt);
		}
	}
}
