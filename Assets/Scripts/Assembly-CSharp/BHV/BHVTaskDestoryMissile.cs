namespace BHV
{
	public class BHVTaskDestoryMissile : BHVTask
	{
		private BHVTaskParamDestoryMissile c2227ddc7fcbe3fa329465d2fa8ffb479;

		public BHVTaskDestoryMissile()
		{
			base.m_Type = BHVTaskType.DestoryMissile;
			base.m_Layer = BHVTaskLayer.ADDITIVE;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamDestoryMissile;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return;
					}
				}
			}
			if ((float)c2227ddc7fcbe3fa329465d2fa8ffb479.c894d137ec42f10f37a5582cf60893357 <= 0f)
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
				AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.cc68caa211e09465abc8826c12bc6904d(c2227ddc7fcbe3fa329465d2fa8ffb479.cb0afba6c0e46440994e8d5aabeafccd4);
			}
			else
			{
				AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.ca97706914b3798af26c15d29a21cdcb1(c2227ddc7fcbe3fa329465d2fa8ffb479.cb0afba6c0e46440994e8d5aabeafccd4, c2227ddc7fcbe3fa329465d2fa8ffb479.c894d137ec42f10f37a5582cf60893357);
			}
			base.m_Status = BHVTaskStatus.SUCCESS;
		}
	}
}
