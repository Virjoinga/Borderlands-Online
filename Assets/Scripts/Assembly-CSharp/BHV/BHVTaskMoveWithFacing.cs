using System.Text;
using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskMoveWithFacing : BHVTask
	{
		private BHVTaskParamMoveWithFacing c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationMoveWithFacingState ca93524c83eb0a52056b459ba13fa1a9c;

		public BHVTaskMoveWithFacing()
		{
			base.m_Type = BHVTaskType.MoveWithFacing;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamMoveWithFacing;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			ca93524c83eb0a52056b459ba13fa1a9c = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationStateMachine.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0("MoveWithFacing") as AnimationMoveWithFacingState;
			if (ca93524c83eb0a52056b459ba13fa1a9c != null)
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
				ca93524c83eb0a52056b459ba13fa1a9c.m_moveSpeed = cfc241af7ab51814fc074e767be1a0bb8.cde528db37f7946caf38a2c719cf0471e(c2227ddc7fcbe3fa329465d2fa8ffb479.c034f614b05c66464092b15f427ea086d, c2227ddc7fcbe3fa329465d2fa8ffb479.c49fa7495bf59da1fbd770224875a9971);
				ca93524c83eb0a52056b459ba13fa1a9c.m_isSprint = c2227ddc7fcbe3fa329465d2fa8ffb479.c034f614b05c66464092b15f427ea086d == BHVMovementSpeed.SPRINT;
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c4004fed08fd0ad52f8c3b650da10e9cb = true;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.cc2c8af567962955d6c13e1bff99b395d = c2227ddc7fcbe3fa329465d2fa8ffb479.c49fa7495bf59da1fbd770224875a9971;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c84d33ddfa4e085e39ae42f40e2ba6952 = c84d33ddfa4e085e39ae42f40e2ba6952();
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.MoveWithFacing);
		}

		private bool c84d33ddfa4e085e39ae42f40e2ba6952()
		{
			if (c2227ddc7fcbe3fa329465d2fa8ffb479 == null)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return false;
					}
				}
			}
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.ca0c376bdd2ff6a3b6ad6e051444cd3c7 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return false;
					}
				}
			}
			return true;
		}

		public void cfab53f8041103ebfb42e7e8de48f550c(float c2002bb238c228cf502166e05c0d89311)
		{
			if (ca93524c83eb0a52056b459ba13fa1a9c == null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				Vector3 normalized = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_movementSync.Velocity.normalized;
				float cb8ede7129a08bde672fa63e8966d4c = c92a96ca76d2cd897cc4ce11846ab6d16(cfc241af7ab51814fc074e767be1a0bb8.transform, normalized);
				ca93524c83eb0a52056b459ba13fa1a9c.cb8ae301452f1a421f9c89a8fcc2bf362(cb8ede7129a08bde672fa63e8966d4c);
				return;
			}
		}

		public float c92a96ca76d2cd897cc4ce11846ab6d16(Transform c63017dffbb632e326f1f0dbbd1ca49ca, Vector3 c051cc2f87c4805915f2241ff754271af)
		{
			Vector3 forward = c63017dffbb632e326f1f0dbbd1ca49ca.forward;
			forward.y = 0f;
			c051cc2f87c4805915f2241ff754271af.y = 0f;
			float num = Vector3.Angle(forward, c051cc2f87c4805915f2241ff754271af);
			float num2 = Vector3.Dot(c051cc2f87c4805915f2241ff754271af, c63017dffbb632e326f1f0dbbd1ca49ca.right);
			float result;
			if (num2 > 0f)
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
				result = num;
			}
			else
			{
				result = 360f - num;
			}
			return result;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			cfab53f8041103ebfb42e7e8de48f550c(deltaTime);
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
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
				float num = 0f;
				if (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					num = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c5a566dbd0e781356afaeb0774ab2f0b1;
				}
				stringBuilder.Append(string.Format("        StressLevel:{0} - MovementSpeed:{1} - FacingAngle:{2}\n", c2227ddc7fcbe3fa329465d2fa8ffb479.c49fa7495bf59da1fbd770224875a9971, c2227ddc7fcbe3fa329465d2fa8ffb479.c034f614b05c66464092b15f427ea086d, num));
			}
			return stringBuilder.ToString();
		}
	}
}
