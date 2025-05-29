using System.Text;
using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskCoverFireIdle : BHVTask
	{
		private enum CoverFireIdleState
		{
			c6d1f578be4de6db437a078aa502b0284 = -1,
			c31cc7099a08a06274cd493826b095347 = 0,
			c1d3e2cf1545b9321547e6a21bb58bfb3 = 1,
			ccb86e27d3d17a4f78948ef02f4c4412c = 2
		}

		private BHVTaskParamCoverFireIdle c2227ddc7fcbe3fa329465d2fa8ffb479;

		private CoverFireIdleState c45bb77f7ef7c0cfb4e9839ab212a467f = CoverFireIdleState.c6d1f578be4de6db437a078aa502b0284;

		private float c8d6d0618a619c5377bfa2192b652bb59;

		private bool c64502e67a2b13f38f2cac13ec15a1bad;

		public BHVTaskCoverFireIdle()
		{
			base.m_Type = BHVTaskType.CoverFireIdle;
			base.m_Layer = BHVTaskLayer.TOPBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamCoverFireIdle;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c45bb77f7ef7c0cfb4e9839ab212a467f = CoverFireIdleState.c31cc7099a08a06274cd493826b095347;
			c8d6d0618a619c5377bfa2192b652bb59 = c2227ddc7fcbe3fa329465d2fa8ffb479.c8d6d0618a619c5377bfa2192b652bb59;
			c64502e67a2b13f38f2cac13ec15a1bad = false;
		}

		public bool c0cb29b4baaf7df8bf8dfca26fb77f6a2()
		{
			if (c2227ddc7fcbe3fa329465d2fa8ffb479 == null)
			{
				while (true)
				{
					switch (2)
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
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (!c2227ddc7fcbe3fa329465d2fa8ffb479.c8a2af45a880b27fa0012457d167c4b27.c943bc6a18586b3e0e6f0214717aca479())
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							return false;
						}
					}
				}
			}
			return true;
		}

		public Vector3 c4abe11a77e071a3885acd1dc78717d7f()
		{
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						Entity component = c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7.GetComponent<Entity>();
						Debug.c01037ade1f1152c7345e14ef90726aba(cfc241af7ab51814fc074e767be1a0bb8.transform.position, component.c8cc25ca9fd18f583f33395178ef47f1d(), Color.yellow);
						return component.c8cc25ca9fd18f583f33395178ef47f1d();
					}
					}
				}
			}
			Debug.c01037ade1f1152c7345e14ef90726aba(cfc241af7ab51814fc074e767be1a0bb8.transform.position, c2227ddc7fcbe3fa329465d2fa8ffb479.c8a2af45a880b27fa0012457d167c4b27, Color.red);
			return c2227ddc7fcbe3fa329465d2fa8ffb479.c8a2af45a880b27fa0012457d167c4b27;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (!c0cb29b4baaf7df8bf8dfca26fb77f6a2())
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
				c45bb77f7ef7c0cfb4e9839ab212a467f = CoverFireIdleState.ccb86e27d3d17a4f78948ef02f4c4412c;
				base.m_Status = BHVTaskStatus.FAILED;
			}
			switch (c45bb77f7ef7c0cfb4e9839ab212a467f)
			{
			case CoverFireIdleState.c6d1f578be4de6db437a078aa502b0284:
				base.m_Status = BHVTaskStatus.FAILED;
				break;
			case CoverFireIdleState.c31cc7099a08a06274cd493826b095347:
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.CoverIdleBeforeFire);
				base.m_Status = BHVTaskStatus.RUNNING;
				c45bb77f7ef7c0cfb4e9839ab212a467f = CoverFireIdleState.c1d3e2cf1545b9321547e6a21bb58bfb3;
				if (c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.c1388b070a9ff180c6a0efe41ddf70e31(c2227ddc7fcbe3fa329465d2fa8ffb479.c8a2af45a880b27fa0012457d167c4b27);
							return;
						}
					}
				}
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.c1e667d6f38b9e5836b1229ac7567f858(c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7);
				break;
			case CoverFireIdleState.c1d3e2cf1545b9321547e6a21bb58bfb3:
			{
				float ccc714c0eabb517feca15832e42c5ea = BHVTaskUtils.c4d8568e8355dc3342546a10728d3a1a2(c4abe11a77e071a3885acd1dc78717d7f(), cfc241af7ab51814fc074e767be1a0bb8.m_entity);
				BHVTaskUtils.cb9639a2fcbb63d05803cb6f04384c8ca(ccc714c0eabb517feca15832e42c5ea, cfc241af7ab51814fc074e767be1a0bb8.m_entity, c4abe11a77e071a3885acd1dc78717d7f(), ref c64502e67a2b13f38f2cac13ec15a1bad);
				if (c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.c1388b070a9ff180c6a0efe41ddf70e31(c2227ddc7fcbe3fa329465d2fa8ffb479.c8a2af45a880b27fa0012457d167c4b27);
				}
				else
				{
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.c1e667d6f38b9e5836b1229ac7567f858(c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7);
				}
				switch (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c388d41f72ca44e2a282caa5bc1558d3c(AnimationStateFSM.CoverIdleBeforeFire))
				{
				case AnimationStatus.INVALID:
				case AnimationStatus.FAILED:
					base.m_Status = BHVTaskStatus.FAILED;
					c45bb77f7ef7c0cfb4e9839ab212a467f = CoverFireIdleState.ccb86e27d3d17a4f78948ef02f4c4412c;
					break;
				case AnimationStatus.RUNNING:
					c8d6d0618a619c5377bfa2192b652bb59 -= deltaTime;
					if (c8d6d0618a619c5377bfa2192b652bb59 <= 0f)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								c45bb77f7ef7c0cfb4e9839ab212a467f = CoverFireIdleState.ccb86e27d3d17a4f78948ef02f4c4412c;
								base.m_Status = BHVTaskStatus.SUCCESS;
								return;
							}
						}
					}
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				case AnimationStatus.SUCCESS:
					c45bb77f7ef7c0cfb4e9839ab212a467f = CoverFireIdleState.ccb86e27d3d17a4f78948ef02f4c4412c;
					base.m_Status = BHVTaskStatus.SUCCESS;
					break;
				}
				break;
			}
			case CoverFireIdleState.ccb86e27d3d17a4f78948ef02f4c4412c:
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.ce40f0b6c3f7714ac1c3daa73f26d266d();
				break;
			default:
				base.m_Status = BHVTaskStatus.SUCCESS;
				break;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.ce40f0b6c3f7714ac1c3daa73f26d266d();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			stringBuilder.Append(string.Format("        State:{0} - Time:{1}\n", c45bb77f7ef7c0cfb4e9839ab212a467f, c8d6d0618a619c5377bfa2192b652bb59));
			return stringBuilder.ToString();
		}
	}
}
