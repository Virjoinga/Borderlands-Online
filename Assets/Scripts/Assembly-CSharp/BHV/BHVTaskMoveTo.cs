using System.Text;
using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskMoveTo : BHVTask
	{
		private enum MoveToState
		{
			c6d1f578be4de6db437a078aa502b0284 = -1,
			c2d86b890ced0b9b0a7b6a6bba58ddc62 = 0,
			ce9251add56fe03f45ea8af9c04dcc059 = 1,
			cd3afd3f536367e363efe9ae4cd479956 = 2,
			ccb86e27d3d17a4f78948ef02f4c4412c = 3,
			c9d3c2ab25f15e75fe648bc9b2bb14eb7 = 4
		}

		private BHVTaskParamMoveTo c2227ddc7fcbe3fa329465d2fa8ffb479;

		private MoveToState c45bb77f7ef7c0cfb4e9839ab212a467f = MoveToState.c6d1f578be4de6db437a078aa502b0284;

		private AnimationMoveState cde9264f4bc6347cbcdf206841ef20e3a;

		public BHVTaskMoveTo()
		{
			base.m_Type = BHVTaskType.MoveTo;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamMoveTo;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c45bb77f7ef7c0cfb4e9839ab212a467f = MoveToState.c2d86b890ced0b9b0a7b6a6bba58ddc62;
			cde9264f4bc6347cbcdf206841ef20e3a = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.Move)) as AnimationMoveState;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			c8143c49c5316e50f68745e2419d66ca1(deltaTime);
		}

		public void c5d8766fe5b42d2e00dad1c162c7eb32d(float c2002bb238c228cf502166e05c0d89311)
		{
		}

		public void c8143c49c5316e50f68745e2419d66ca1(float c2002bb238c228cf502166e05c0d89311)
		{
			switch (c45bb77f7ef7c0cfb4e9839ab212a467f)
			{
			case MoveToState.c6d1f578be4de6db437a078aa502b0284:
				base.m_Status = BHVTaskStatus.FAILED;
				break;
			case MoveToState.c2d86b890ced0b9b0a7b6a6bba58ddc62:
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.cc2c8af567962955d6c13e1bff99b395d = c2227ddc7fcbe3fa329465d2fa8ffb479.c49fa7495bf59da1fbd770224875a9971;
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c84d33ddfa4e085e39ae42f40e2ba6952 = false;
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.Move);
				cb9639a2fcbb63d05803cb6f04384c8ca();
				if (cde9264f4bc6347cbcdf206841ef20e3a != null)
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
					cde9264f4bc6347cbcdf206841ef20e3a.c1c067e605f60d78f4fd6324f61461644 = cfc241af7ab51814fc074e767be1a0bb8.cde528db37f7946caf38a2c719cf0471e(c2227ddc7fcbe3fa329465d2fa8ffb479.c034f614b05c66464092b15f427ea086d, c2227ddc7fcbe3fa329465d2fa8ffb479.c49fa7495bf59da1fbd770224875a9971);
					cde9264f4bc6347cbcdf206841ef20e3a.m_destinationDistanceFactor = 1f;
					cde9264f4bc6347cbcdf206841ef20e3a.m_isSprint = c2227ddc7fcbe3fa329465d2fa8ffb479.c034f614b05c66464092b15f427ea086d == BHVMovementSpeed.SPRINT;
				}
				base.m_Status = BHVTaskStatus.RUNNING;
				c45bb77f7ef7c0cfb4e9839ab212a467f = MoveToState.ce9251add56fe03f45ea8af9c04dcc059;
				break;
			case MoveToState.ce9251add56fe03f45ea8af9c04dcc059:
				cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVNavAgentSettings>().m_canUseFacingLogic = false;
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_canUseFacingLogic = false;
				cb9639a2fcbb63d05803cb6f04384c8ca();
				base.m_Status = BHVTaskStatus.RUNNING;
				break;
			case MoveToState.cd3afd3f536367e363efe9ae4cd479956:
				base.m_Status = BHVTaskStatus.RUNNING;
				break;
			case MoveToState.ccb86e27d3d17a4f78948ef02f4c4412c:
				break;
			}
		}

		private bool ccce60d55e7ff50d56da96452a5071658(GameObject c80822505abd04406a7a821211bd77371, bool c2bf4bb70f02b11e43c5329af5f2acb78, Vector3 cd74e1657fe33d2ee7ef19f6bb00c943e, out Vector3 c30bab1a9674b1965e1cd3e8b18dc4750)
		{
			if (c80822505abd04406a7a821211bd77371 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						Vector3 vector = c80822505abd04406a7a821211bd77371.transform.position - cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position;
						vector.y = 0f;
						c30bab1a9674b1965e1cd3e8b18dc4750 = vector.normalized;
						return true;
					}
					}
				}
			}
			if (c2bf4bb70f02b11e43c5329af5f2acb78)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						c30bab1a9674b1965e1cd3e8b18dc4750 = cd74e1657fe33d2ee7ef19f6bb00c943e.normalized;
						return true;
					}
				}
			}
			c30bab1a9674b1965e1cd3e8b18dc4750 = Vector3.zero;
			return false;
		}

		private void cb9639a2fcbb63d05803cb6f04384c8ca()
		{
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.ce16937d8aca427101b7ddcbda8a6f2e5)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (!(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					NPCAnimationManagerFSM nPCAnimationManagerFSM = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as NPCAnimationManagerFSM;
					if (!(nPCAnimationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
					{
						return;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						nPCAnimationManagerFSM.c913fe3a12dbcfe01fe7b91de8c590cb0();
						return;
					}
				}
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			if (c2227ddc7fcbe3fa329465d2fa8ffb479 != null)
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
				float num = 0f;
				if (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					num = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c5a566dbd0e781356afaeb0774ab2f0b1;
				}
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array[0] = c45bb77f7ef7c0cfb4e9839ab212a467f;
				array[1] = c2227ddc7fcbe3fa329465d2fa8ffb479.c49fa7495bf59da1fbd770224875a9971;
				array[2] = c2227ddc7fcbe3fa329465d2fa8ffb479.c034f614b05c66464092b15f427ea086d;
				array[3] = num;
				stringBuilder.Append(string.Format("        State:{0} - StressLevel:{1} - MovementSpeed:{2} - FacingAngle:{3}\n", array));
			}
			return stringBuilder.ToString();
		}
	}
}
