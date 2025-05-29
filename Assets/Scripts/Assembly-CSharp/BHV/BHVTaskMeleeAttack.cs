using A;
using XsdSettings;

namespace BHV
{
	public class BHVTaskMeleeAttack : BHVTask
	{
		private enum MeleeState
		{
			c6d1f578be4de6db437a078aa502b0284 = -1,
			c31cc7099a08a06274cd493826b095347 = 0,
			c1d3e2cf1545b9321547e6a21bb58bfb3 = 1,
			ccb86e27d3d17a4f78948ef02f4c4412c = 2
		}

		private BHVTaskParamMeleeAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private MeleeState c45bb77f7ef7c0cfb4e9839ab212a467f = MeleeState.c6d1f578be4de6db437a078aa502b0284;

		private int c8c1a106ea3f0953992c0105c437ba073 = 1;

		public BHVTaskMeleeAttack()
		{
			base.m_Type = BHVTaskType.MeleeAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamMeleeAttack;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			BHVMeleeAttackSettings bHVMeleeAttackSettings = cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVMeleeAttackSettings>();
			if (bHVMeleeAttackSettings != null)
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
				if (bHVMeleeAttackSettings.m_attackSubTypeList != null)
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
					if (bHVMeleeAttackSettings.m_attackSubTypeList.Length > 0)
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
						c8c1a106ea3f0953992c0105c437ba073 = cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVMeleeAttackSettings>().m_attackSubTypeList.Length;
					}
				}
			}
			c45bb77f7ef7c0cfb4e9839ab212a467f = MeleeState.c31cc7099a08a06274cd493826b095347;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.cd295c889c81e8823ba501a609b868079(false);
		}

		private int c5b6aa88a1ba008930fe37b41091a7681(float ccdcfc1d715f56f0dc2ee9e3863160d7e)
		{
			return (int)(ccdcfc1d715f56f0dc2ee9e3863160d7e * (float)c8c1a106ea3f0953992c0105c437ba073);
		}

		private AttackSubType c53bca353a14e3f4ff476cb455893f6cf(float ccdcfc1d715f56f0dc2ee9e3863160d7e)
		{
			int num = c5b6aa88a1ba008930fe37b41091a7681(ccdcfc1d715f56f0dc2ee9e3863160d7e);
			return cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVMeleeAttackSettings>().m_attackSubTypeList[num];
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c45bb77f7ef7c0cfb4e9839ab212a467f = MeleeState.ccb86e27d3d17a4f78948ef02f4c4412c;
				base.m_Status = BHVTaskStatus.FAILED;
			}
			switch (c45bb77f7ef7c0cfb4e9839ab212a467f)
			{
			case MeleeState.c6d1f578be4de6db437a078aa502b0284:
				base.m_Status = BHVTaskStatus.FAILED;
				break;
			case MeleeState.c31cc7099a08a06274cd493826b095347:
			{
				AnimationMeleeAttackState animationMeleeAttackState2 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.MeleeAttack)) as AnimationMeleeAttackState;
				if (animationMeleeAttackState2 != null)
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
					animationMeleeAttackState2.m_meleeAttackID = c5b6aa88a1ba008930fe37b41091a7681(c2227ddc7fcbe3fa329465d2fa8ffb479.c955e8bb738225c76da79fb5139b2ac37);
				}
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.MeleeAttack);
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c4004fed08fd0ad52f8c3b650da10e9cb = false;
				base.m_Status = BHVTaskStatus.RUNNING;
				c45bb77f7ef7c0cfb4e9839ab212a467f = MeleeState.c1d3e2cf1545b9321547e6a21bb58bfb3;
				break;
			}
			case MeleeState.c1d3e2cf1545b9321547e6a21bb58bfb3:
				switch (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c388d41f72ca44e2a282caa5bc1558d3c(AnimationStateFSM.MeleeAttack))
				{
				case AnimationStatus.INVALID:
				case AnimationStatus.FAILED:
					base.m_Status = BHVTaskStatus.FAILED;
					c45bb77f7ef7c0cfb4e9839ab212a467f = MeleeState.ccb86e27d3d17a4f78948ef02f4c4412c;
					break;
				case AnimationStatus.RUNNING:
				{
					base.m_Status = BHVTaskStatus.RUNNING;
					cc46841b8ed78cf172ccc816a5482cbfe();
					AnimationMeleeAttackState animationMeleeAttackState = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.MeleeAttack)) as AnimationMeleeAttackState;
					if (animationMeleeAttackState == null)
					{
						break;
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						if (!animationMeleeAttackState.m_triggetHitEvent)
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
							animationMeleeAttackState.m_triggetHitEvent = false;
							caff0fb83e895aa7112bb45dfffd6c1cc();
							return;
						}
					}
				}
				case AnimationStatus.SUCCESS:
					c45bb77f7ef7c0cfb4e9839ab212a467f = MeleeState.ccb86e27d3d17a4f78948ef02f4c4412c;
					base.m_Status = BHVTaskStatus.SUCCESS;
					break;
				}
				break;
			case MeleeState.ccb86e27d3d17a4f78948ef02f4c4412c:
				break;
			default:
				base.m_Status = BHVTaskStatus.SUCCESS;
				break;
			}
		}

		private void cc46841b8ed78cf172ccc816a5482cbfe()
		{
		}

		private void caff0fb83e895aa7112bb45dfffd6c1cc()
		{
			if (cfc241af7ab51814fc074e767be1a0bb8 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (cfc241af7ab51814fc074e767be1a0bb8.m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					return;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					if (c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								return;
							}
						}
					}
					BHVMeleeAttackSettings bHVMeleeAttackSettings = cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVMeleeAttackSettings>();
					if (bHVMeleeAttackSettings == null)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								return;
							}
						}
					}
					if (!bHVMeleeAttackSettings.m_canShakeCamera)
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
						if (!(c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
							EntityPlayer component = c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7.GetComponent<EntityPlayer>();
							if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
								BadAssFPSCamera badAssFPSCamera = component.cc6a7269e9ea93e537de47dc752b09a86();
								if (!(badAssFPSCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
								{
									return;
								}
								while (true)
								{
									switch (6)
									{
									case 0:
										continue;
									}
									badAssFPSCamera.c19a5441553998e0c8500003947ff7737(BadAssFPSCamera.ShakeType.medium);
									return;
								}
							}
						}
					}
				}
			}
		}
	}
}
