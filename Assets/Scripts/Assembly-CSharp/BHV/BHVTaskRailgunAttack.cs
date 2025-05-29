using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskRailgunAttack : BHVTask
	{
		private BHVTaskParamRailgunAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationRailgunAttackState c5ae9bc249fc03b60cae99eeef154732b;

		private float c23144d4b849283cd12fc6407ffc6f9ec;

		private bool c3174c69970acf30bf99c4a9ca4bc4052;

		public BHVTaskRailgunAttack()
		{
			base.m_Type = BHVTaskType.RailgunAttack;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamRailgunAttack;
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
			c3174c69970acf30bf99c4a9ca4bc4052 = false;
			c5ae9bc249fc03b60cae99eeef154732b = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("RailgunAttack") as AnimationRailgunAttackState;
			Object c8a9803eea6a7a3df08a031d389151b = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Entities/Object/Weapon/PlasmaBall");
			c6bbb38b9eccc88ce1b52dbe61daf5fc7(c8a9803eea6a7a3df08a031d389151b, (cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).m_leftHandWeaponSlot);
			c6bbb38b9eccc88ce1b52dbe61daf5fc7(c8a9803eea6a7a3df08a031d389151b, (cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).m_rightHandWeaponSlot);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		public override void Update(float deltaTime)
		{
			cb9639a2fcbb63d05803cb6f04384c8ca();
			c23144d4b849283cd12fc6407ffc6f9ec += Time.deltaTime;
			if (c23144d4b849283cd12fc6407ffc6f9ec < 1f)
			{
				while (true)
				{
					switch (3)
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
			if (!c3174c69970acf30bf99c4a9ca4bc4052)
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
				c3174c69970acf30bf99c4a9ca4bc4052 = true;
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.RailgunAttack);
			}
			if (c5ae9bc249fc03b60cae99eeef154732b.m_status != AnimationStatus.SUCCESS)
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
				if (!(c23144d4b849283cd12fc6407ffc6f9ec > 2f))
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
					base.m_Status = BHVTaskStatus.SUCCESS;
					return;
				}
			}
		}

		private void c6bbb38b9eccc88ce1b52dbe61daf5fc7(Object c8a9803eea6a7a3df08a031d389151b62, Transform cc8ba5bf3ffd83c0f05222a33b893942d)
		{
			if (c8a9803eea6a7a3df08a031d389151b62 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			GameObject gameObject = (GameObject)Object.Instantiate(c8a9803eea6a7a3df08a031d389151b62, cc8ba5bf3ffd83c0f05222a33b893942d.position, cc8ba5bf3ffd83c0f05222a33b893942d.rotation);
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
				gameObject.transform.parent = cc8ba5bf3ffd83c0f05222a33b893942d;
				PlasmaBall component = gameObject.GetComponent<PlasmaBall>();
				if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					component.m_damageRadius = c2227ddc7fcbe3fa329465d2fa8ffb479.cbfe48220d0686c9350881808f74550ba;
					component.m_flyingSpeed = c2227ddc7fcbe3fa329465d2fa8ffb479.c33f61bf31429003b457d54fc20133b0f;
					component.m_damageDuration = c2227ddc7fcbe3fa329465d2fa8ffb479.cb31e7a7cc3352d6e80d9e8944777a410;
					component.m_damage = c2227ddc7fcbe3fa329465d2fa8ffb479.c78a81a448556cec8bf5b37e4b17c5c5d;
					component.m_chargeTime = 1f;
					component.m_BHVTaskManager = cfc241af7ab51814fc074e767be1a0bb8;
					component.m_attackObject = c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c;
					component.m_vTargetPos = c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c.transform.position + Vector3.up * 1.4f;
					return;
				}
			}
		}

		private void cb9639a2fcbb63d05803cb6f04384c8ca()
		{
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Vector3 normalized = (c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c.transform.position - cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position).normalized;
			normalized.y = 0f;
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward = Vector3.Slerp(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, normalized, Time.deltaTime * 2f);
		}
	}
}
