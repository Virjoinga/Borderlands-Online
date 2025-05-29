using A;

namespace BHV
{
	public class BHVTaskPlayerSkill : BHVTask
	{
		private BHVTaskParamPlayerSkill c2227ddc7fcbe3fa329465d2fa8ffb479;

		public BHVTaskPlayerSkill()
		{
			base.m_Type = BHVTaskType.PlayerSkill;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam c99267cf54eea4a37a361250dae6c7e27)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = c99267cf54eea4a37a361250dae6c7e27 as BHVTaskParamPlayerSkill;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(c99267cf54eea4a37a361250dae6c7e27);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		public override void Start()
		{
			base.Start();
			base.m_Status = BHVTaskStatus.RUNNING;
			EntityPlayer entityPlayer = cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityPlayer;
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.c6cb0ad55015fbddefd0fd66876c7d5f4 == ESkillStatePhase.First)
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c9d878a0c8ef401a60f254a868331d1bd();
			}
			entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3.OnSkillTask(c2227ddc7fcbe3fa329465d2fa8ffb479.c6cb0ad55015fbddefd0fd66876c7d5f4);
			entityPlayer.cc2f0113176b624e561c0a894437dd8a7();
		}
	}
}
