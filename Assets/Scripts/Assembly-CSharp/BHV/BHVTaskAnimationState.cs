using System.Text;

namespace BHV
{
	public class BHVTaskAnimationState : BHVTask
	{
		protected enum State
		{
			c6d1f578be4de6db437a078aa502b0284 = -1,
			c31cc7099a08a06274cd493826b095347 = 0,
			c1d3e2cf1545b9321547e6a21bb58bfb3 = 1,
			ccb86e27d3d17a4f78948ef02f4c4412c = 2
		}

		private BHVTaskParamAnimationState c2227ddc7fcbe3fa329465d2fa8ffb479;

		protected State c45bb77f7ef7c0cfb4e9839ab212a467f = State.c6d1f578be4de6db437a078aa502b0284;

		public BHVTaskAnimationState()
		{
			base.m_Type = BHVTaskType.INVALID;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamAnimationState;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c45bb77f7ef7c0cfb4e9839ab212a467f = State.c31cc7099a08a06274cd493826b095347;
		}

		public override void Update(float deltaTime)
		{
			if (base.m_Type != BHVTaskType.PlayAnimation)
			{
				return;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				Update(deltaTime, c2227ddc7fcbe3fa329465d2fa8ffb479.cd4c6f5bc0ffba00956fa80fc2758673f);
				return;
			}
		}

		public virtual void Update(float deltaTime, AnimationStateFSM animationState = AnimationStateFSM.Invalid)
		{
			base.Update(deltaTime);
			switch (c45bb77f7ef7c0cfb4e9839ab212a467f)
			{
			case State.c6d1f578be4de6db437a078aa502b0284:
				base.m_Status = BHVTaskStatus.FAILED;
				break;
			case State.c31cc7099a08a06274cd493826b095347:
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(animationState);
				base.m_Status = BHVTaskStatus.RUNNING;
				c45bb77f7ef7c0cfb4e9839ab212a467f = State.c1d3e2cf1545b9321547e6a21bb58bfb3;
				break;
			case State.c1d3e2cf1545b9321547e6a21bb58bfb3:
				switch (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c388d41f72ca44e2a282caa5bc1558d3c(animationState))
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
					c45bb77f7ef7c0cfb4e9839ab212a467f = State.ccb86e27d3d17a4f78948ef02f4c4412c;
					base.m_Status = BHVTaskStatus.SUCCESS;
					break;
				}
				break;
			case State.ccb86e27d3d17a4f78948ef02f4c4412c:
				break;
			default:
				base.m_Status = BHVTaskStatus.SUCCESS;
				break;
			}
		}

		protected void c27dba26b1f36450e0fe5aec9ef628804()
		{
			c45bb77f7ef7c0cfb4e9839ab212a467f = State.ccb86e27d3d17a4f78948ef02f4c4412c;
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			stringBuilder.Append(string.Format("        State:{0}\n", c45bb77f7ef7c0cfb4e9839ab212a467f));
			return stringBuilder.ToString();
		}
	}
}
