using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskIceMeteorAttack : BHVTask
	{
		private BHVTaskParamIceMeteorAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private float c0153bbe6abcba0b2822156ab6a79a3b7;

		private int ce1151010934b03814fa2e2d41cd5d202;

		private Transform c13eebd5bde6d21917a28d88a260d7b45;

		private AnimationIceMeteorAttackState c56549cb30af086d4c191b1cbc62105d3;

		public BHVTaskIceMeteorAttack()
		{
			base.m_Type = BHVTaskType.IceMeteorAttack;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamIceMeteorAttack;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c0153bbe6abcba0b2822156ab6a79a3b7 = 0f;
			ce1151010934b03814fa2e2d41cd5d202 = 0;
			c13eebd5bde6d21917a28d88a260d7b45 = cfc241af7ab51814fc074e767be1a0bb8.GetComponent<EntityNpcSpiderantTalos>().m_armorBack;
			c56549cb30af086d4c191b1cbc62105d3 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("IceMeteorAttack") as AnimationIceMeteorAttackState;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.IceMeteorAttack);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				while (true)
				{
					switch (4)
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
			if (c56549cb30af086d4c191b1cbc62105d3.m_meteorStep != EAnimationMeteorStep.MeteorLoop)
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
				if (c56549cb30af086d4c191b1cbc62105d3.m_meteorStep != EAnimationMeteorStep.MeteorFinish)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
			}
			c0153bbe6abcba0b2822156ab6a79a3b7 += deltaTime;
			if (c0153bbe6abcba0b2822156ab6a79a3b7 >= (float)c2227ddc7fcbe3fa329465d2fa8ffb479.c847416d37b991d227537108be7e018d6 * 0.5f)
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
				c56549cb30af086d4c191b1cbc62105d3.m_meteorStep = EAnimationMeteorStep.MeteorFinish;
			}
			if (ce1151010934b03814fa2e2d41cd5d202 != c2227ddc7fcbe3fa329465d2fa8ffb479.c847416d37b991d227537108be7e018d6)
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
				if (!(c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					if (ce1151010934b03814fa2e2d41cd5d202 >= c2227ddc7fcbe3fa329465d2fa8ffb479.c847416d37b991d227537108be7e018d6)
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
						if (!(c0153bbe6abcba0b2822156ab6a79a3b7 >= (float)(ce1151010934b03814fa2e2d41cd5d202 + 1) * 0.5f))
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
							c8470affcd2f2063130cbac28740bf2c3();
							if (!(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
								cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_IceThorn, 2f);
								return;
							}
						}
					}
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			c56549cb30af086d4c191b1cbc62105d3.m_meteorStep = EAnimationMeteorStep.MeteorFinish;
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		private void cb9639a2fcbb63d05803cb6f04384c8ca()
		{
			Vector3 normalized = (c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c.transform.position - cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position).normalized;
			normalized.y = 0f;
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward = Vector3.Slerp(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, normalized, Time.deltaTime * 2f);
		}

		private void c8470affcd2f2063130cbac28740bf2c3()
		{
			GameObject gameObject = (GameObject)Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Entities/Object/Weapon/IcePick"));
			if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				Vector3 position = c13eebd5bde6d21917a28d88a260d7b45.position;
				position.y += 1.5f;
				gameObject.transform.position = position;
				gameObject.transform.rotation = cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.rotation;
			}
			OnInstanciate(gameObject);
		}

		public void OnInstanciate(GameObject instance)
		{
			if (!(instance != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				Vector3 vector = c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c.transform.position;
				if (c2227ddc7fcbe3fa329465d2fa8ffb479.cd94e3de8ae7934ce3d7def2a31f129d7 == BHVTaskParamIceMeteorAttack.EAttackMode.c86188343b4fbcf4c3b94b32228d85cb3)
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
					Vector2 vector2 = Random.insideUnitCircle * Random.Range(0f, c2227ddc7fcbe3fa329465d2fa8ffb479.cbfe48220d0686c9350881808f74550ba);
					vector.x += vector2.x;
					vector.z += vector2.y;
				}
				else
				{
					float magnitude = (c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c.transform.position - cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position).magnitude;
					Vector3 normalized = (c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c.transform.position - cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position).normalized;
					normalized.y = 0f;
					Vector3 vector3 = Vector3.Cross(normalized, Vector3.up);
					Vector3 vector4 = vector + c2227ddc7fcbe3fa329465d2fa8ffb479.cb04ae3d0740704306ed2b9109ba63ea1 * (float)(c2227ddc7fcbe3fa329465d2fa8ffb479.c847416d37b991d227537108be7e018d6 - 1) * 0.5f * vector3;
					vector = vector4 - vector3 * c2227ddc7fcbe3fa329465d2fa8ffb479.cb04ae3d0740704306ed2b9109ba63ea1 * ce1151010934b03814fa2e2d41cd5d202;
					Vector3 normalized2 = (vector - cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position).normalized;
					normalized2.y = 0f;
					vector = cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position + normalized2 * magnitude;
				}
				RaycastHit hitInfo;
				if (Physics.Raycast(vector + Vector3.up * 25f, -Vector3.up, out hitInfo, 27f, 1 << LayerMask.NameToLayer("Walkable")))
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
					vector = hitInfo.point;
				}
				IcePick component = instance.GetComponent<IcePick>();
				if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					component.m_vLandPos = vector;
					component.m_BHVTaskManager = cfc241af7ab51814fc074e767be1a0bb8;
					component.m_damageRadius = c2227ddc7fcbe3fa329465d2fa8ffb479.cbfe48220d0686c9350881808f74550ba;
					component.m_damage = c2227ddc7fcbe3fa329465d2fa8ffb479.c9b36e132c2f043a337fddf91e2a1d3ba;
					component.m_flyingCurve = AIServiceCurve.c5ee19dc8d4cccf5ae2de225410458b86.cd440a8b2fe2065c9cd33808285d3d764(AIServiceCurve.ECurveType.EIcePickAttackFlyingCurve, instance.transform.position, vector, 1f);
				}
				ce1151010934b03814fa2e2d41cd5d202++;
				return;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			c56549cb30af086d4c191b1cbc62105d3.m_meteorStep = EAnimationMeteorStep.MeteorFinish;
		}
	}
}
