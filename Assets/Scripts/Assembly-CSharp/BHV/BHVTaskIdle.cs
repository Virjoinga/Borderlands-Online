using System.Text;
using A;

namespace BHV
{
	public class BHVTaskIdle : BHVTask
	{
		private enum IdleState
		{
			c6d1f578be4de6db437a078aa502b0284 = -1,
			c31cc7099a08a06274cd493826b095347 = 0,
			c1d3e2cf1545b9321547e6a21bb58bfb3 = 1,
			ccb86e27d3d17a4f78948ef02f4c4412c = 2
		}

		private BHVTaskParamIdle c2227ddc7fcbe3fa329465d2fa8ffb479;

		private IdleState c45bb77f7ef7c0cfb4e9839ab212a467f = IdleState.c6d1f578be4de6db437a078aa502b0284;

		private AnimationIdleState ce42f19ba87bc409f8d346cd704d4a78f;

		public BHVTaskIdle()
		{
			base.m_Type = BHVTaskType.Idle;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamIdle;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			if (ce42f19ba87bc409f8d346cd704d4a78f == null)
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
				ce42f19ba87bc409f8d346cd704d4a78f = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.Idle)) as AnimationIdleState;
			}
			if (ce42f19ba87bc409f8d346cd704d4a78f != null)
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
				ce42f19ba87bc409f8d346cd704d4a78f.m_stressLevel = c2227ddc7fcbe3fa329465d2fa8ffb479.c49fa7495bf59da1fbd770224875a9971;
			}
			c45bb77f7ef7c0cfb4e9839ab212a467f = IdleState.c31cc7099a08a06274cd493826b095347;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			switch (c45bb77f7ef7c0cfb4e9839ab212a467f)
			{
			case IdleState.c6d1f578be4de6db437a078aa502b0284:
				base.m_Status = BHVTaskStatus.FAILED;
				return;
			case IdleState.c31cc7099a08a06274cd493826b095347:
				if (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					base.m_Status = BHVTaskStatus.FAILED;
					c45bb77f7ef7c0cfb4e9839ab212a467f = IdleState.ccb86e27d3d17a4f78948ef02f4c4412c;
					break;
				}
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c4004fed08fd0ad52f8c3b650da10e9cb = false;
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.Idle);
				base.m_Status = BHVTaskStatus.RUNNING;
				c45bb77f7ef7c0cfb4e9839ab212a467f = IdleState.c1d3e2cf1545b9321547e6a21bb58bfb3;
				return;
			case IdleState.c1d3e2cf1545b9321547e6a21bb58bfb3:
				switch (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c388d41f72ca44e2a282caa5bc1558d3c(AnimationStateFSM.Idle))
				{
				case AnimationStatus.INVALID:
				case AnimationStatus.FAILED:
					base.m_Status = BHVTaskStatus.FAILED;
					c45bb77f7ef7c0cfb4e9839ab212a467f = IdleState.ccb86e27d3d17a4f78948ef02f4c4412c;
					break;
				case AnimationStatus.RUNNING:
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				case AnimationStatus.SUCCESS:
					c45bb77f7ef7c0cfb4e9839ab212a467f = IdleState.ccb86e27d3d17a4f78948ef02f4c4412c;
					base.m_Status = BHVTaskStatus.SUCCESS;
					break;
				}
				return;
			case IdleState.ccb86e27d3d17a4f78948ef02f4c4412c:
				return;
			}
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			object arg = c45bb77f7ef7c0cfb4e9839ab212a467f;
			object arg2;
			if (c2227ddc7fcbe3fa329465d2fa8ffb479 != null)
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
				arg2 = c2227ddc7fcbe3fa329465d2fa8ffb479.c49fa7495bf59da1fbd770224875a9971.ToString();
			}
			else
			{
				arg2 = "Unkown";
			}
			stringBuilder.Append(string.Format("        State:{0} - StressLevel:{1}\n", arg, arg2));
			return stringBuilder.ToString();
		}
	}
}
