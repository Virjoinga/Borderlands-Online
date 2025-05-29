using UnityEngine;

namespace BHV
{
	public class BHVTaskJumpAttackLand : BHVTask
	{
		private enum State
		{
			c6d1f578be4de6db437a078aa502b0284 = -1,
			c257e6956f511c4ba2162298abacade7d = 0,
			cb358e6b5505e4c02e70c04c07af13768 = 1,
			ccb86e27d3d17a4f78948ef02f4c4412c = 2
		}

		private BHVTaskParamJumpAttackLand c2227ddc7fcbe3fa329465d2fa8ffb479;

		private State c45bb77f7ef7c0cfb4e9839ab212a467f = State.c6d1f578be4de6db437a078aa502b0284;

		private Vector3 c989561c786ba1a829d6caab7f79b0ced = Vector3.zero;

		private float c7c1ccb3f2e7a0942399d718ab18fa288;

		private float c90c042cab25b505ec702d0c265670875 = 0.5f;

		public BHVTaskJumpAttackLand()
		{
			base.m_Type = BHVTaskType.JumpAttackLand;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamJumpAttackLand;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c45bb77f7ef7c0cfb4e9839ab212a467f = State.c257e6956f511c4ba2162298abacade7d;
			c989561c786ba1a829d6caab7f79b0ced = cfc241af7ab51814fc074e767be1a0bb8.m_entity.c4c38fdc58f120e1209ca439fa8ee5818();
			c7c1ccb3f2e7a0942399d718ab18fa288 = 0f;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			switch (c45bb77f7ef7c0cfb4e9839ab212a467f)
			{
			case State.c6d1f578be4de6db437a078aa502b0284:
				base.m_Status = BHVTaskStatus.FAILED;
				break;
			case State.c257e6956f511c4ba2162298abacade7d:
			{
				base.m_Status = BHVTaskStatus.RUNNING;
				Vector3 position = cfc241af7ab51814fc074e767be1a0bb8.transform.position;
				c7c1ccb3f2e7a0942399d718ab18fa288 -= deltaTime * c90c042cab25b505ec702d0c265670875;
				position.y += c7c1ccb3f2e7a0942399d718ab18fa288;
				if (position.y <= c989561c786ba1a829d6caab7f79b0ced.y)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							if (1 == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							position.y = c989561c786ba1a829d6caab7f79b0ced.y;
							cfc241af7ab51814fc074e767be1a0bb8.transform.position = position;
							cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.JumpAttackCrash);
							c45bb77f7ef7c0cfb4e9839ab212a467f = State.cb358e6b5505e4c02e70c04c07af13768;
							return;
						}
					}
				}
				cfc241af7ab51814fc074e767be1a0bb8.transform.position = position;
				break;
			}
			case State.cb358e6b5505e4c02e70c04c07af13768:
				switch (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c388d41f72ca44e2a282caa5bc1558d3c(AnimationStateFSM.JumpAttackCrash))
				{
				case AnimationStatus.INVALID:
				case AnimationStatus.FAILED:
					base.m_Status = BHVTaskStatus.FAILED;
					c45bb77f7ef7c0cfb4e9839ab212a467f = State.ccb86e27d3d17a4f78948ef02f4c4412c;
					break;
				case AnimationStatus.RUNNING:
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				case AnimationStatus.SUCCESS:
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.Idle);
					c45bb77f7ef7c0cfb4e9839ab212a467f = State.ccb86e27d3d17a4f78948ef02f4c4412c;
					base.m_Status = BHVTaskStatus.SUCCESS;
					break;
				}
				break;
			case State.ccb86e27d3d17a4f78948ef02f4c4412c:
				break;
			}
		}
	}
}
