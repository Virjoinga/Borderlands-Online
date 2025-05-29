namespace BHV
{
	public class BHVTaskLightHurt : BHVTask
	{
		private BHVTaskParamLightHurt c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationLightHurtState c21cc532f6821c5b7f4c9ffe258d03ae0;

		public BHVTaskLightHurt()
		{
			base.m_Type = BHVTaskType.LightHurt;
			base.m_Layer = BHVTaskLayer.ADDITIVE;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamLightHurt;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c21cc532f6821c5b7f4c9ffe258d03ae0 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("LightHurt") as AnimationLightHurtState;
			if (c21cc532f6821c5b7f4c9ffe258d03ae0 != null)
			{
				while (true)
				{
					switch (4)
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
				c21cc532f6821c5b7f4c9ffe258d03ae0.m_damageType = c2227ddc7fcbe3fa329465d2fa8ffb479.cba943e9241e86ef410ecc99294660143;
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.LightHurt);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		public override void Update(float deltaTime)
		{
			if (c21cc532f6821c5b7f4c9ffe258d03ae0.m_status != AnimationStatus.SUCCESS)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}
	}
}
