using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskRocketAttack : BHVTask
	{
		private BHVTaskParamRocketAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private BHVTaskTurretRocketSetting c697a926f079a12e098a01de0186698e4;

		private float c23144d4b849283cd12fc6407ffc6f9ec;

		private Object ccfaa5f6c4752685efc96185906c00c31;

		private bool cb4fd534ac5a4dbaeff782621bc838e75;

		private Transform ce43490f5b91fc28c5588b27c12a02979;

		private Transform c4be7b390cacba91ca98ad8bdbd5a748a;

		public BHVTaskRocketAttack()
		{
			base.m_Type = BHVTaskType.RocketAttack;
			base.m_Layer = BHVTaskLayer.TOPBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamRocketAttack;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c23144d4b849283cd12fc6407ffc6f9ec = 0f;
			cb4fd534ac5a4dbaeff782621bc838e75 = false;
			ce43490f5b91fc28c5588b27c12a02979 = (cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).m_leftHandWeaponSlot;
			c4be7b390cacba91ca98ad8bdbd5a748a = (cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).m_rightHandWeaponSlot;
			ccfaa5f6c4752685efc96185906c00c31 = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Entities/Object/Weapon/WPN_Soldier_Turret_Rocket");
			c697a926f079a12e098a01de0186698e4 = cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVTaskTurretRocketSetting>();
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			c23144d4b849283cd12fc6407ffc6f9ec += deltaTime;
			if (!(c23144d4b849283cd12fc6407ffc6f9ec > c697a926f079a12e098a01de0186698e4.m_fireInterval))
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
				c23144d4b849283cd12fc6407ffc6f9ec -= c697a926f079a12e098a01de0186698e4.m_fireInterval;
				c3d00e8ddab69f8a8e2d067d619a1d594();
				return;
			}
		}

		private void c3d00e8ddab69f8a8e2d067d619a1d594()
		{
			if (ccfaa5f6c4752685efc96185906c00c31 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						return;
					}
				}
			}
			Vector3 position;
			if (cb4fd534ac5a4dbaeff782621bc838e75)
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
				position = ce43490f5b91fc28c5588b27c12a02979.position;
			}
			else
			{
				position = c4be7b390cacba91ca98ad8bdbd5a748a.position;
			}
			Vector3 vector = position;
			Vector3 normalized = (c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7.transform.position - vector).normalized;
			Debug.c01037ade1f1152c7345e14ef90726aba(vector, c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7.transform.position, Color.gray);
			cb4fd534ac5a4dbaeff782621bc838e75 = !cb4fd534ac5a4dbaeff782621bc838e75;
			Quaternion rotation = Quaternion.Euler(normalized);
			GameObject gameObject = (GameObject)Object.Instantiate(ccfaa5f6c4752685efc96185906c00c31, vector, rotation);
			if (!(gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				TurretRocket component = gameObject.GetComponent<TurretRocket>();
				gameObject.transform.forward = normalized;
				component.m_fSpeed = c697a926f079a12e098a01de0186698e4.m_speed;
				component.m_fLifeTime = c697a926f079a12e098a01de0186698e4.m_lifeTime;
				component.m_BHVTaskManager = cfc241af7ab51814fc074e767be1a0bb8;
				component.m_targetEntity = c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7.GetComponent<Entity>();
				return;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			base.m_Status = BHVTaskStatus.SUCCESS;
		}
	}
}
