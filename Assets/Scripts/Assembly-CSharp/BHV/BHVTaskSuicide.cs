using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskSuicide : BHVTask
	{
		private enum SuicideState
		{
			c6d1f578be4de6db437a078aa502b0284 = -1,
			c31cc7099a08a06274cd493826b095347 = 0,
			c1d3e2cf1545b9321547e6a21bb58bfb3 = 1,
			c206d50de74d85959165d7aef4dad76e7 = 2,
			ccb86e27d3d17a4f78948ef02f4c4412c = 3
		}

		private BHVTaskParamSuicide c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationSuicideBombState cb97c13fda705ae7b4453c8c8bb7883ca;

		private SuicideState c3e0737c2faada470fd7714fe213dff53 = SuicideState.c6d1f578be4de6db437a078aa502b0284;

		private bool cfdc3f64f875fa218bdee5ef55a3ece69;

		public BHVTaskSuicide()
		{
			base.m_Type = BHVTaskType.Suicide;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamSuicide;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			cb97c13fda705ae7b4453c8c8bb7883ca = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.SuicideBomb)) as AnimationSuicideBombState;
			if (cb97c13fda705ae7b4453c8c8bb7883ca != null)
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
				cb97c13fda705ae7b4453c8c8bb7883ca.m_fuzeDuration = c2227ddc7fcbe3fa329465d2fa8ffb479.c6eec9c03360117ad1f3f68c77abdce44;
			}
			c3e0737c2faada470fd7714fe213dff53 = SuicideState.c31cc7099a08a06274cd493826b095347;
			cfdc3f64f875fa218bdee5ef55a3ece69 = false;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (!(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (cb97c13fda705ae7b4453c8c8bb7883ca != null)
				{
					goto IL_0055;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			base.m_Status = BHVTaskStatus.FAILED;
			c3e0737c2faada470fd7714fe213dff53 = SuicideState.ccb86e27d3d17a4f78948ef02f4c4412c;
			goto IL_0055;
			IL_0055:
			switch (c3e0737c2faada470fd7714fe213dff53)
			{
			case SuicideState.c6d1f578be4de6db437a078aa502b0284:
				base.m_Status = BHVTaskStatus.FAILED;
				break;
			case SuicideState.c31cc7099a08a06274cd493826b095347:
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c4004fed08fd0ad52f8c3b650da10e9cb = false;
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.SuicideBomb);
				base.m_Status = BHVTaskStatus.RUNNING;
				c3e0737c2faada470fd7714fe213dff53 = SuicideState.c1d3e2cf1545b9321547e6a21bb58bfb3;
				break;
			case SuicideState.c1d3e2cf1545b9321547e6a21bb58bfb3:
				switch (cb97c13fda705ae7b4453c8c8bb7883ca.m_bombStep)
				{
				case EAnimationSuicideBombStep.BombNull:
					base.m_Status = BHVTaskStatus.FAILED;
					c3e0737c2faada470fd7714fe213dff53 = SuicideState.ccb86e27d3d17a4f78948ef02f4c4412c;
					break;
				case EAnimationSuicideBombStep.BombStart:
					base.m_Status = BHVTaskStatus.RUNNING;
					cfdc3f64f875fa218bdee5ef55a3ece69 = true;
					break;
				case EAnimationSuicideBombStep.BombIdle:
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				case EAnimationSuicideBombStep.BombExplode:
					base.m_Status = BHVTaskStatus.RUNNING;
					c3e0737c2faada470fd7714fe213dff53 = SuicideState.c206d50de74d85959165d7aef4dad76e7;
					break;
				}
				break;
			case SuicideState.c206d50de74d85959165d7aef4dad76e7:
				if (cfdc3f64f875fa218bdee5ef55a3ece69)
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
					ced4b7f24f81cbbb318970a09ed8c5e51();
					cfdc3f64f875fa218bdee5ef55a3ece69 = false;
				}
				base.m_Status = BHVTaskStatus.RUNNING;
				c3e0737c2faada470fd7714fe213dff53 = SuicideState.ccb86e27d3d17a4f78948ef02f4c4412c;
				break;
			case SuicideState.ccb86e27d3d17a4f78948ef02f4c4412c:
				base.m_Status = BHVTaskStatus.SUCCESS;
				break;
			default:
				base.m_Status = BHVTaskStatus.SUCCESS;
				break;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			if (!cfdc3f64f875fa218bdee5ef55a3ece69)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				ced4b7f24f81cbbb318970a09ed8c5e51();
				cfdc3f64f875fa218bdee5ef55a3ece69 = false;
				return;
			}
		}

		public void ced4b7f24f81cbbb318970a09ed8c5e51()
		{
			if (!cfc241af7ab51814fc074e767be1a0bb8)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (!cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM)
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
					if (!cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_weaponHolder)
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
						ParticleEffect componentInChildren = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_weaponHolder.GetComponentInChildren<ParticleEffect>();
						if (componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							ParticleSystem particleSystem = (ParticleSystem)Object.Instantiate(componentInChildren.m_effect);
							particleSystem.transform.position = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_weaponHolder.position;
							particleSystem.transform.rotation = Quaternion.identity;
							if (!particleSystem.playOnAwake)
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
								particleSystem.Play();
							}
							Object.Destroy(particleSystem.gameObject, 3f);
						}
						BaseEventTriggerCtl componentInChildren2 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_weaponHolder.GetComponentInChildren<BaseEventTriggerCtl>();
						if ((bool)componentInChildren2)
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
							componentInChildren2.TriggerEventByName("Grenade_Explosion_Rnd");
						}
						Renderer componentInChildren3 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_weaponHolder.GetComponentInChildren<Renderer>();
						if (!(componentInChildren3 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
							componentInChildren3.transform.position = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_weaponHolder.position;
							componentInChildren3.enabled = false;
							return;
						}
					}
				}
			}
		}
	}
}
