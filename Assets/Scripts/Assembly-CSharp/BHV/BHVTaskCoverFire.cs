using System.Text;
using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskCoverFire : BHVTask
	{
		private enum CoverFireState
		{
			c6d1f578be4de6db437a078aa502b0284 = -1,
			c31cc7099a08a06274cd493826b095347 = 0,
			c1d3e2cf1545b9321547e6a21bb58bfb3 = 1,
			ccb86e27d3d17a4f78948ef02f4c4412c = 2
		}

		private BHVTaskParamCoverFire c2227ddc7fcbe3fa329465d2fa8ffb479;

		private CoverFireState c45bb77f7ef7c0cfb4e9839ab212a467f = CoverFireState.c6d1f578be4de6db437a078aa502b0284;

		private int c2486cdc43e9c03391ab4fab5ebbcc7c8;

		private BHVTaskFirePatternManager c8cc1424fa250673567c7b37c2049f91a = new BHVTaskFirePatternManager();

		private float ccdeafe316e9613cf140584215c65f7ad;

		private bool c64502e67a2b13f38f2cac13ec15a1bad;

		private AnimationCoverFireState c2b4faf2c8213de9e50ef2d8856270936;

		public BHVTaskCoverFire()
		{
			base.m_Type = BHVTaskType.CoverFire;
			base.m_Layer = BHVTaskLayer.TOPBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamCoverFire;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c2486cdc43e9c03391ab4fab5ebbcc7c8 = c2227ddc7fcbe3fa329465d2fa8ffb479.c8030d9f0c728ff10de1ba33f9105ff30;
			c45bb77f7ef7c0cfb4e9839ab212a467f = CoverFireState.c31cc7099a08a06274cd493826b095347;
			ccdeafe316e9613cf140584215c65f7ad = 0f;
			c64502e67a2b13f38f2cac13ec15a1bad = false;
			c2b4faf2c8213de9e50ef2d8856270936 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.CoverFire)) as AnimationCoverFireState;
		}

		public bool c0cb29b4baaf7df8bf8dfca26fb77f6a2()
		{
			if (c2227ddc7fcbe3fa329465d2fa8ffb479 == null)
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
						return false;
					}
				}
			}
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (!c2227ddc7fcbe3fa329465d2fa8ffb479.c8a2af45a880b27fa0012457d167c4b27.c943bc6a18586b3e0e6f0214717aca479())
				{
					while (true)
					{
						switch (6)
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
					switch (1)
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
			if (base.m_Status == BHVTaskStatus.SUCCESS)
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
				if (base.m_Status == BHVTaskStatus.FAILED)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
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
					c45bb77f7ef7c0cfb4e9839ab212a467f = CoverFireState.ccb86e27d3d17a4f78948ef02f4c4412c;
					base.m_Status = BHVTaskStatus.FAILED;
				}
				switch (c45bb77f7ef7c0cfb4e9839ab212a467f)
				{
				case CoverFireState.c6d1f578be4de6db437a078aa502b0284:
					base.m_Status = BHVTaskStatus.FAILED;
					break;
				case CoverFireState.c31cc7099a08a06274cd493826b095347:
				{
					if (c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.c1388b070a9ff180c6a0efe41ddf70e31(c2227ddc7fcbe3fa329465d2fa8ffb479.c8a2af45a880b27fa0012457d167c4b27);
					}
					else
					{
						cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.c1e667d6f38b9e5836b1229ac7567f858(c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7);
					}
					float num = cfc241af7ab51814fc074e767be1a0bb8.c62614a5ace3c704a56712e723a657907(c2227ddc7fcbe3fa329465d2fa8ffb479.c7e51fddad5ba955e865c93444ce9bf84);
					float num2 = cfc241af7ab51814fc074e767be1a0bb8.cdec9589c1698402d0a21ebc506ba03e9(c2227ddc7fcbe3fa329465d2fa8ffb479.c7e51fddad5ba955e865c93444ce9bf84);
					if (c2b4faf2c8213de9e50ef2d8856270936 != null)
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
						c2b4faf2c8213de9e50ef2d8856270936.cfd7a98e9e0dc6e7b96d719aa7ca13c98 = num;
						c2b4faf2c8213de9e50ef2d8856270936.c927347792f0c19e41f1b6fa39d6db3fd = num2;
					}
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.CoverFire);
					c8cc1424fa250673567c7b37c2049f91a.Start(num, num2, cfc241af7ab51814fc074e767be1a0bb8.m_entity.cdcf5e0592c05a681a8470f66674efd0b());
					base.m_Status = BHVTaskStatus.RUNNING;
					c45bb77f7ef7c0cfb4e9839ab212a467f = CoverFireState.c1d3e2cf1545b9321547e6a21bb58bfb3;
					break;
				}
				case CoverFireState.c1d3e2cf1545b9321547e6a21bb58bfb3:
					if (c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.c1388b070a9ff180c6a0efe41ddf70e31(c2227ddc7fcbe3fa329465d2fa8ffb479.c8a2af45a880b27fa0012457d167c4b27);
					}
					else
					{
						cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.c1e667d6f38b9e5836b1229ac7567f858(c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7);
					}
					ccdeafe316e9613cf140584215c65f7ad = BHVTaskUtils.c4d8568e8355dc3342546a10728d3a1a2(c4abe11a77e071a3885acd1dc78717d7f(), cfc241af7ab51814fc074e767be1a0bb8.m_entity);
					BHVTaskUtils.cb9639a2fcbb63d05803cb6f04384c8ca(ccdeafe316e9613cf140584215c65f7ad, cfc241af7ab51814fc074e767be1a0bb8.m_entity, c4abe11a77e071a3885acd1dc78717d7f(), ref c64502e67a2b13f38f2cac13ec15a1bad);
					switch (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c388d41f72ca44e2a282caa5bc1558d3c(AnimationStateFSM.CoverFire))
					{
					case AnimationStatus.INVALID:
					case AnimationStatus.FAILED:
						base.m_Status = BHVTaskStatus.FAILED;
						c45bb77f7ef7c0cfb4e9839ab212a467f = CoverFireState.ccb86e27d3d17a4f78948ef02f4c4412c;
						break;
					case AnimationStatus.RUNNING:
						base.m_Status = BHVTaskStatus.RUNNING;
						c8cc1424fa250673567c7b37c2049f91a.Update(deltaTime, cfc241af7ab51814fc074e767be1a0bb8.m_entity.cdcf5e0592c05a681a8470f66674efd0b(), cfc241af7ab51814fc074e767be1a0bb8.m_entity.cdcf5e0592c05a681a8470f66674efd0b().cbf03a4f84f096adb2811087b0f34146c(), c4abe11a77e071a3885acd1dc78717d7f());
						break;
					case AnimationStatus.SUCCESS:
						c2486cdc43e9c03391ab4fab5ebbcc7c8--;
						if (c2486cdc43e9c03391ab4fab5ebbcc7c8 <= 0)
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									break;
								default:
									c45bb77f7ef7c0cfb4e9839ab212a467f = CoverFireState.ccb86e27d3d17a4f78948ef02f4c4412c;
									base.m_Status = BHVTaskStatus.SUCCESS;
									return;
								}
							}
						}
						c45bb77f7ef7c0cfb4e9839ab212a467f = CoverFireState.c31cc7099a08a06274cd493826b095347;
						break;
					}
					break;
				case CoverFireState.ccb86e27d3d17a4f78948ef02f4c4412c:
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.ce40f0b6c3f7714ac1c3daa73f26d266d();
					break;
				default:
					base.m_Status = BHVTaskStatus.SUCCESS;
					break;
				}
				return;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			if (ce5e813b93a5483775927292e3ba4b8ef)
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
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.ce40f0b6c3f7714ac1c3daa73f26d266d();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			if (c2227ddc7fcbe3fa329465d2fa8ffb479 != null)
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
				EntityWeapon entityWeapon = cfc241af7ab51814fc074e767be1a0bb8.m_entity.c3941dac8608f650ceb15dc36294a741c();
				if ((bool)entityWeapon)
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
					object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
					array[0] = c45bb77f7ef7c0cfb4e9839ab212a467f;
					array[1] = c2227ddc7fcbe3fa329465d2fa8ffb479.c7e51fddad5ba955e865c93444ce9bf84;
					array[2] = c2486cdc43e9c03391ab4fab5ebbcc7c8;
					array[3] = entityWeapon.m_ammoCount;
					array[4] = ccdeafe316e9613cf140584215c65f7ad;
					stringBuilder.Append(string.Format("        State:{0} - FireStyle:{1} - Loop:{2} - Ammo:{3} - Yaw:{4:0.00}\n", array));
				}
				else
				{
					object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
					array2[0] = c45bb77f7ef7c0cfb4e9839ab212a467f;
					array2[1] = c2227ddc7fcbe3fa329465d2fa8ffb479.c7e51fddad5ba955e865c93444ce9bf84;
					array2[2] = c2486cdc43e9c03391ab4fab5ebbcc7c8;
					array2[3] = ccdeafe316e9613cf140584215c65f7ad;
					stringBuilder.Append(string.Format("        State:{0} - FireStyle:{1} - Loop:{2} - No Weapon - Yaw:{3:0.00}\n", array2));
				}
			}
			return stringBuilder.ToString();
		}
	}
}
