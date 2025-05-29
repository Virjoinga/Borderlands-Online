namespace BHV
{
	public class BHVTaskChargeAttack : BHVTask
	{
		private enum State
		{
			c6d1f578be4de6db437a078aa502b0284 = -1,
			c02b181b971acdaa53332236d0851c1bb = 0,
			ccb86e27d3d17a4f78948ef02f4c4412c = 1
		}

		private AnimationChargeState ccc5ecc6e6139d47b9bae6e1cd3b795dd;

		private BHVTaskParamChargeAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private State c45bb77f7ef7c0cfb4e9839ab212a467f = State.c6d1f578be4de6db437a078aa502b0284;

		public BHVTaskChargeAttack()
		{
			base.m_Type = BHVTaskType.ChargeAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamChargeAttack;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c45bb77f7ef7c0cfb4e9839ab212a467f = State.c02b181b971acdaa53332236d0851c1bb;
			ccc5ecc6e6139d47b9bae6e1cd3b795dd = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("Charge") as AnimationChargeState;
			ccc5ecc6e6139d47b9bae6e1cd3b795dd.ce8aefb20ab2781fdc33c39eb5ef73a9b = EAnimationChargeStep.ChargeNull;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (ccc5ecc6e6139d47b9bae6e1cd3b795dd == null)
			{
				while (true)
				{
					switch (6)
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
				c45bb77f7ef7c0cfb4e9839ab212a467f = State.c6d1f578be4de6db437a078aa502b0284;
			}
			switch (c45bb77f7ef7c0cfb4e9839ab212a467f)
			{
			case State.c6d1f578be4de6db437a078aa502b0284:
				base.m_Status = BHVTaskStatus.FAILED;
				break;
			case State.c02b181b971acdaa53332236d0851c1bb:
				switch (ccc5ecc6e6139d47b9bae6e1cd3b795dd.ce8aefb20ab2781fdc33c39eb5ef73a9b)
				{
				case EAnimationChargeStep.ChargeNull:
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.Charge);
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c4004fed08fd0ad52f8c3b650da10e9cb = true;
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				case EAnimationChargeStep.ChargePre:
				case EAnimationChargeStep.ChargeLoop:
					if (ccc5ecc6e6139d47b9bae6e1cd3b795dd.ce8aefb20ab2781fdc33c39eb5ef73a9b == EAnimationChargeStep.ChargeReach)
					{
						break;
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						if (ccc5ecc6e6139d47b9bae6e1cd3b795dd == null)
						{
							return;
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								continue;
							}
							ccc5ecc6e6139d47b9bae6e1cd3b795dd.c060feea153fe2c724e32cc3b16e6bb12 = c2227ddc7fcbe3fa329465d2fa8ffb479.c8a2af45a880b27fa0012457d167c4b27;
							ccc5ecc6e6139d47b9bae6e1cd3b795dd.m_destinationDistanceFactor = BHVTaskUtils.cdb901bc7fb6b3c7de30e9b074bfb0279(cfc241af7ab51814fc074e767be1a0bb8.transform.position, ccc5ecc6e6139d47b9bae6e1cd3b795dd.c060feea153fe2c724e32cc3b16e6bb12);
							return;
						}
					}
				case EAnimationChargeStep.ChargeReach:
					break;
				case EAnimationChargeStep.ChargeFinish:
					base.m_Status = BHVTaskStatus.FAILED;
					c45bb77f7ef7c0cfb4e9839ab212a467f = State.ccb86e27d3d17a4f78948ef02f4c4412c;
					break;
				}
				break;
			case State.ccb86e27d3d17a4f78948ef02f4c4412c:
				break;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			ccc5ecc6e6139d47b9bae6e1cd3b795dd.ce8aefb20ab2781fdc33c39eb5ef73a9b = EAnimationChargeStep.ChargeReach;
		}
	}
}
