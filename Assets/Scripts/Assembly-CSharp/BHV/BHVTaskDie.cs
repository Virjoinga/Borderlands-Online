namespace BHV
{
	public class BHVTaskDie : BHVTaskAnimationState
	{
		private BHVTaskParamDie c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationDieState c7c138697d2e11c8822a331bd25514377;

		public BHVTaskDie()
		{
			base.m_Type = BHVTaskType.Die;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamDie;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c7c138697d2e11c8822a331bd25514377 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("Die") as AnimationDieState;
			if (c7c138697d2e11c8822a331bd25514377 != null)
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
				c7c138697d2e11c8822a331bd25514377.m_force = c2227ddc7fcbe3fa329465d2fa8ffb479.c8603e2027b78e6b01305715886ad95a2;
				c7c138697d2e11c8822a331bd25514377.m_explosionOrigin = c2227ddc7fcbe3fa329465d2fa8ffb479.c9287e7fd25716f0fb6137e5d4ebfb94f;
			}
			AnimationManagerFSM animationManagerFSM = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM;
			int damageType;
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.cd7166a76de731e5b161e03f4d830b4b5)
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
				damageType = 1;
			}
			else
			{
				damageType = 0;
			}
			animationManagerFSM.m_damageType = (DamageType)damageType;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_iDeathAnimIndex = c2227ddc7fcbe3fa329465d2fa8ffb479.cb4f02774bd5e0e375e5223103830ce78;
			DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cd5e20c96aa545559531f1792ec0f8b61(cfc241af7ab51814fc074e767be1a0bb8.m_entity);
		}

		public override void Update(float deltaTime)
		{
			State state = c45bb77f7ef7c0cfb4e9839ab212a467f;
			base.Update(deltaTime, AnimationStateFSM.Die);
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
					switch (1)
					{
					case 0:
						continue;
					}
					AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.ce674c03a24ec89ef7cb066f5795f06c8(cfc241af7ab51814fc074e767be1a0bb8, false);
					return;
				}
			}
		}
	}
}
