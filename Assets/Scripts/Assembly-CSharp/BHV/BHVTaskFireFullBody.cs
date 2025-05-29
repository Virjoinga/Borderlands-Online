using System.Text;
using A;
using Core;
using UnityEngine;

namespace BHV
{
	public class BHVTaskFireFullBody : BHVTask
	{
		private enum FireState
		{
			c6d1f578be4de6db437a078aa502b0284 = -1,
			c31cc7099a08a06274cd493826b095347 = 0,
			c1d3e2cf1545b9321547e6a21bb58bfb3 = 1,
			ccb86e27d3d17a4f78948ef02f4c4412c = 2
		}

		private BHVTaskParamFireFullBody c2227ddc7fcbe3fa329465d2fa8ffb479;

		private FireState c45bb77f7ef7c0cfb4e9839ab212a467f = FireState.c6d1f578be4de6db437a078aa502b0284;

		private int c2486cdc43e9c03391ab4fab5ebbcc7c8;

		private BHVTaskFirePatternManager c8cc1424fa250673567c7b37c2049f91a = new BHVTaskFirePatternManager();

		private float ccdeafe316e9613cf140584215c65f7ad;

		private bool c64502e67a2b13f38f2cac13ec15a1bad;

		private float c3b95a4a6b35b7ba9e4c9ed72a9add297;

		private AnimationFireFullBodyState c08664e2498d77e0ffdb744e33c663305;

		private EntityWeapon cfa257e87ee889b5d74d79438e43de7df;

		private AIInventory c5e7434ccec13c1b548ce2f375c8b74da;

		public BHVTaskFireFullBody()
		{
			base.m_Type = BHVTaskType.FireFullBody;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamFireFullBody;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c3b95a4a6b35b7ba9e4c9ed72a9add297 = Time.time;
			c2486cdc43e9c03391ab4fab5ebbcc7c8 = c2227ddc7fcbe3fa329465d2fa8ffb479.c8030d9f0c728ff10de1ba33f9105ff30;
			c45bb77f7ef7c0cfb4e9839ab212a467f = FireState.c31cc7099a08a06274cd493826b095347;
			ccdeafe316e9613cf140584215c65f7ad = 0f;
			c64502e67a2b13f38f2cac13ec15a1bad = false;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c4004fed08fd0ad52f8c3b650da10e9cb = true;
			c08664e2498d77e0ffdb744e33c663305 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.FireFullBody)) as AnimationFireFullBodyState;
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
						switch (3)
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
			base.Update(deltaTime);
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return;
					}
				}
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.c3bf54d312726877e5f77b6d475aef510();
			if (!c0cb29b4baaf7df8bf8dfca26fb77f6a2())
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
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.AI, "FireState NO valid tareget: " + Time.time);
				c45bb77f7ef7c0cfb4e9839ab212a467f = FireState.ccb86e27d3d17a4f78948ef02f4c4412c;
				base.m_Status = BHVTaskStatus.FAILED;
			}
			if (c5e7434ccec13c1b548ce2f375c8b74da == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c5e7434ccec13c1b548ce2f375c8b74da = cfc241af7ab51814fc074e767be1a0bb8.m_entity.cdcf5e0592c05a681a8470f66674efd0b();
			}
			switch (c45bb77f7ef7c0cfb4e9839ab212a467f)
			{
			case FireState.c6d1f578be4de6db437a078aa502b0284:
				base.m_Status = BHVTaskStatus.FAILED;
				break;
			case FireState.c31cc7099a08a06274cd493826b095347:
			{
				if (c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.c1388b070a9ff180c6a0efe41ddf70e31(c2227ddc7fcbe3fa329465d2fa8ffb479.c8a2af45a880b27fa0012457d167c4b27);
				}
				else
				{
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.c1e667d6f38b9e5836b1229ac7567f858(c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7);
				}
				float num = cfc241af7ab51814fc074e767be1a0bb8.c62614a5ace3c704a56712e723a657907(c2227ddc7fcbe3fa329465d2fa8ffb479.c7e51fddad5ba955e865c93444ce9bf84);
				float num2 = cfc241af7ab51814fc074e767be1a0bb8.cdec9589c1698402d0a21ebc506ba03e9(c2227ddc7fcbe3fa329465d2fa8ffb479.c7e51fddad5ba955e865c93444ce9bf84);
				if (c08664e2498d77e0ffdb744e33c663305 != null)
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
					c08664e2498d77e0ffdb744e33c663305.cfd7a98e9e0dc6e7b96d719aa7ca13c98 = num;
					c08664e2498d77e0ffdb744e33c663305.c927347792f0c19e41f1b6fa39d6db3fd = num2;
					c08664e2498d77e0ffdb744e33c663305.m_stance = c2227ddc7fcbe3fa329465d2fa8ffb479.cabd31980fc78efe17153b1acf216a763;
					c08664e2498d77e0ffdb744e33c663305.m_fallBackAfterShot = c2227ddc7fcbe3fa329465d2fa8ffb479.cdc084f6ea47fad83821f9ad10bebb608;
				}
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c84d33ddfa4e085e39ae42f40e2ba6952 = true;
				if (cfc241af7ab51814fc074e767be1a0bb8.c04ca5acd4c692e7b2a810ed8ac4deeca())
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
					ccdeafe316e9613cf140584215c65f7ad = BHVTaskUtils.c4d8568e8355dc3342546a10728d3a1a2(c4abe11a77e071a3885acd1dc78717d7f(), cfc241af7ab51814fc074e767be1a0bb8.m_entity);
					BHVTaskUtils.cb9639a2fcbb63d05803cb6f04384c8ca(ccdeafe316e9613cf140584215c65f7ad, cfc241af7ab51814fc074e767be1a0bb8.m_entity, c4abe11a77e071a3885acd1dc78717d7f(), ref c64502e67a2b13f38f2cac13ec15a1bad);
				}
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.FireFullBody);
				c8cc1424fa250673567c7b37c2049f91a.Start(num, num2, c5e7434ccec13c1b548ce2f375c8b74da);
				base.m_Status = BHVTaskStatus.RUNNING;
				c45bb77f7ef7c0cfb4e9839ab212a467f = FireState.c1d3e2cf1545b9321547e6a21bb58bfb3;
				break;
			}
			case FireState.c1d3e2cf1545b9321547e6a21bb58bfb3:
				if (c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.c1388b070a9ff180c6a0efe41ddf70e31(c2227ddc7fcbe3fa329465d2fa8ffb479.c8a2af45a880b27fa0012457d167c4b27);
				}
				else
				{
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.c1e667d6f38b9e5836b1229ac7567f858(c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7);
				}
				if (cfc241af7ab51814fc074e767be1a0bb8.c04ca5acd4c692e7b2a810ed8ac4deeca())
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
					ccdeafe316e9613cf140584215c65f7ad = BHVTaskUtils.c4d8568e8355dc3342546a10728d3a1a2(c4abe11a77e071a3885acd1dc78717d7f(), cfc241af7ab51814fc074e767be1a0bb8.m_entity);
					BHVTaskUtils.cb9639a2fcbb63d05803cb6f04384c8ca(ccdeafe316e9613cf140584215c65f7ad, cfc241af7ab51814fc074e767be1a0bb8.m_entity, c4abe11a77e071a3885acd1dc78717d7f(), ref c64502e67a2b13f38f2cac13ec15a1bad);
				}
				switch (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c388d41f72ca44e2a282caa5bc1558d3c(AnimationStateFSM.FireFullBody))
				{
				case AnimationStatus.INVALID:
				case AnimationStatus.FAILED:
					base.m_Status = BHVTaskStatus.FAILED;
					c45bb77f7ef7c0cfb4e9839ab212a467f = FireState.ccb86e27d3d17a4f78948ef02f4c4412c;
					break;
				case AnimationStatus.PREPARE:
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				case AnimationStatus.RUNNING:
					base.m_Status = BHVTaskStatus.RUNNING;
					if (cfa257e87ee889b5d74d79438e43de7df == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						cfa257e87ee889b5d74d79438e43de7df = cfc241af7ab51814fc074e767be1a0bb8.m_entity.c3941dac8608f650ceb15dc36294a741c();
					}
					if (!(cfa257e87ee889b5d74d79438e43de7df != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
					{
						break;
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						if (cfa257e87ee889b5d74d79438e43de7df.cc93370e457eb4094fe6253d1b18437ca())
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
									c8cc1424fa250673567c7b37c2049f91a.Update(deltaTime, c5e7434ccec13c1b548ce2f375c8b74da, c5e7434ccec13c1b548ce2f375c8b74da.cbf03a4f84f096adb2811087b0f34146c(), c4abe11a77e071a3885acd1dc78717d7f());
									return;
								}
							}
						}
						if (c08664e2498d77e0ffdb744e33c663305 == null)
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
							if (!c08664e2498d77e0ffdb744e33c663305.m_shotPending)
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
								c8cc1424fa250673567c7b37c2049f91a.c1ce589e4f7a15f1a76558a9625f44b2b(c5e7434ccec13c1b548ce2f375c8b74da, c5e7434ccec13c1b548ce2f375c8b74da.cbf03a4f84f096adb2811087b0f34146c(), c4abe11a77e071a3885acd1dc78717d7f());
								c08664e2498d77e0ffdb744e33c663305.m_shotPending = false;
								return;
							}
						}
					}
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
								c45bb77f7ef7c0cfb4e9839ab212a467f = FireState.ccb86e27d3d17a4f78948ef02f4c4412c;
								base.m_Status = BHVTaskStatus.SUCCESS;
								return;
							}
						}
					}
					c45bb77f7ef7c0cfb4e9839ab212a467f = FireState.c31cc7099a08a06274cd493826b095347;
					break;
				}
				break;
			case FireState.ccb86e27d3d17a4f78948ef02f4c4412c:
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.ce40f0b6c3f7714ac1c3daa73f26d266d();
				break;
			default:
				base.m_Status = BHVTaskStatus.SUCCESS;
				break;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c4004fed08fd0ad52f8c3b650da10e9cb = false;
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			string text = "Terminate taskFire: " + Time.time;
			if (Time.time - c3b95a4a6b35b7ba9e4c9ed72a9add297 < 1.5f)
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
				text = text + ">>>>> duration: " + (Time.time - c3b95a4a6b35b7ba9e4c9ed72a9add297);
			}
			if (ce5e813b93a5483775927292e3ba4b8ef)
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
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.ce40f0b6c3f7714ac1c3daa73f26d266d();
			c08664e2498d77e0ffdb744e33c663305.caeee91e34d54e1e41ab1b380f7d8c9a4();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			if (c2227ddc7fcbe3fa329465d2fa8ffb479 != null)
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
				EntityWeapon entityWeapon = cfc241af7ab51814fc074e767be1a0bb8.m_entity.c3941dac8608f650ceb15dc36294a741c();
				if ((bool)entityWeapon)
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
