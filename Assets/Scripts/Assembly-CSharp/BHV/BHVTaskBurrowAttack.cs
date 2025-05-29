namespace BHV
{
	public class BHVTaskBurrowAttack : BHVTask
	{
		private enum State
		{
			c6d1f578be4de6db437a078aa502b0284 = -1,
			cf62c3d5254d26ace31e30c21c6853ed0 = 0,
			ccb86e27d3d17a4f78948ef02f4c4412c = 1
		}

		private BHVTaskParamBurrowAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationBurrowState cca90a79408b8fccb360f84a549a7c80d;

		private State c45bb77f7ef7c0cfb4e9839ab212a467f = State.c6d1f578be4de6db437a078aa502b0284;

		private float cfc545847af1ac173a766188bf58195af;

		public BHVTaskBurrowAttack()
		{
			base.m_Type = BHVTaskType.BurrowAttack;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamBurrowAttack;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c45bb77f7ef7c0cfb4e9839ab212a467f = State.cf62c3d5254d26ace31e30c21c6853ed0;
			cca90a79408b8fccb360f84a549a7c80d = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("Burrow") as AnimationBurrowState;
			cfc545847af1ac173a766188bf58195af = 0f;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (cca90a79408b8fccb360f84a549a7c80d == null)
			{
				while (true)
				{
					switch (2)
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
			case State.cf62c3d5254d26ace31e30c21c6853ed0:
				switch (cca90a79408b8fccb360f84a549a7c80d.c1f794dd9234741183dc11abed251450b)
				{
				case EAnimationBurrowStep.BurrowNull:
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.Burrow);
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				case EAnimationBurrowStep.BurrowEnter:
					break;
				case EAnimationBurrowStep.BurrowWait:
					cfc545847af1ac173a766188bf58195af += deltaTime;
					if (!(cfc545847af1ac173a766188bf58195af >= c2227ddc7fcbe3fa329465d2fa8ffb479.ce5e766c95e8eb052ec042fe9c910a1fc))
					{
						break;
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						cca90a79408b8fccb360f84a549a7c80d.c1f794dd9234741183dc11abed251450b = EAnimationBurrowStep.BurrowExit;
						cfc241af7ab51814fc074e767be1a0bb8.gameObject.transform.position = c2227ddc7fcbe3fa329465d2fa8ffb479.c43b879ebd43866fa135bbbda643a6b75;
						return;
					}
				case EAnimationBurrowStep.BurrowExit:
					break;
				case EAnimationBurrowStep.BurrowFinish:
					base.m_Status = BHVTaskStatus.SUCCESS;
					c45bb77f7ef7c0cfb4e9839ab212a467f = State.ccb86e27d3d17a4f78948ef02f4c4412c;
					cca90a79408b8fccb360f84a549a7c80d.c1f794dd9234741183dc11abed251450b = EAnimationBurrowStep.BurrowNull;
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
			cca90a79408b8fccb360f84a549a7c80d.c1f794dd9234741183dc11abed251450b = EAnimationBurrowStep.BurrowFinish;
		}
	}
}
