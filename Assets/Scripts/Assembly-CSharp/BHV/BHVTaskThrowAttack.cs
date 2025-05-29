using A;
using Core;
using UnityEngine;

namespace BHV
{
	public class BHVTaskThrowAttack : BHVTaskAnimationState, InstantiateManager.InstanciationClient
	{
		private BHVTaskParamThrowAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationThrowWeaponState c14a607c732f32524532d1bea23bdf094;

		private bool c4cdb3b8c0902e3fac5efd8ee13297eb6;

		private bool c2cfec8f33a76c66baf653a18b19b423a = true;

		private Vector3 c299295cfbeedcd6848df06bda118f3e3;

		public BHVTaskThrowAttack()
		{
			base.m_Type = BHVTaskType.ThrowAttack;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamThrowAttack;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c14a607c732f32524532d1bea23bdf094 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.ThrowWeapon)) as AnimationThrowWeaponState;
			c4cdb3b8c0902e3fac5efd8ee13297eb6 = false;
			c2cfec8f33a76c66baf653a18b19b423a = true;
			c299295cfbeedcd6848df06bda118f3e3 = new Vector3(10f, 0f, 0f);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.ThrowWeapon);
			if (c14a607c732f32524532d1bea23bdf094 != null)
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
				if (!c4cdb3b8c0902e3fac5efd8ee13297eb6)
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
					if (c14a607c732f32524532d1bea23bdf094.m_readyToLaunch)
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
						if (c2227ddc7fcbe3fa329465d2fa8ffb479.c9272de37e17e3c0a58c626855320e6c8 == EThrowWeaponType.c8abc6387b4646bc71b02b90b39c13720)
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
							c32a6aa915a0721f6ee3ea60d76c4ac05();
						}
						else if (c2227ddc7fcbe3fa329465d2fa8ffb479.c9272de37e17e3c0a58c626855320e6c8 == EThrowWeaponType.ccf31d13fac9985a7d402650943b4ade2)
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
							c598b72a9c732791685767f7bbb41363d();
						}
						else
						{
							c32a6aa915a0721f6ee3ea60d76c4ac05();
						}
						c4cdb3b8c0902e3fac5efd8ee13297eb6 = true;
					}
				}
			}
			cbe1ae5cd05c8f8629280d55ae48367fd();
		}

		public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
		{
			Vector3 normalized = (c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c.transform.position - cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position).normalized;
			normalized = (normalized + Vector3.up * 0.7f).normalized;
			float magnitude = (cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position - c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c.transform.position).magnitude;
			float num = Mathf.Clamp(magnitude * 22f, 200f, 450f);
			instance.rigidbody.AddForce(normalized * num);
			instance.rigidbody.AddTorque(c299295cfbeedcd6848df06bda118f3e3);
		}

		public void c32a6aa915a0721f6ee3ea60d76c4ac05()
		{
		}

		public void c598b72a9c732791685767f7bbb41363d()
		{
			GameObject gameObject = (GameObject)Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Entities/Object/Weapon/WPN_Axe_BadassNPC"));
			if (!(gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				Vector3 vector = c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c.transform.position + Vector3.up * 1.4f;
				GameObject weaponNPC = (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as BanditPsychoAnimationManagerFSM).m_weaponNPC;
				if (weaponNPC != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
						{
							gameObject.transform.position = weaponNPC.transform.position;
							Vector3 vector2 = vector - gameObject.transform.position;
							gameObject.transform.forward = vector2.normalized;
							c2cfec8f33a76c66baf653a18b19b423a = false;
							weaponNPC.SetActive(false);
							PsychoThrowAxe component = gameObject.GetComponent<PsychoThrowAxe>();
							if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
							{
								while (true)
								{
									switch (7)
									{
									case 0:
										break;
									default:
										component.m_BHVTaskManager = cfc241af7ab51814fc074e767be1a0bb8;
										component.m_attackObject = c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c;
										component.m_flyingCurve = AIServiceCurve.c5ee19dc8d4cccf5ae2de225410458b86.cd440a8b2fe2065c9cd33808285d3d764(AIServiceCurve.ECurveType.EThrowAxeCurve, gameObject.transform.position, vector, 2f);
										component.m_bFlying = true;
										return;
									}
								}
							}
							return;
						}
						}
					}
				}
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.AI, "Spawn axe failed!");
				return;
			}
		}

		private void cbe1ae5cd05c8f8629280d55ae48367fd()
		{
			if (c2cfec8f33a76c66baf653a18b19b423a)
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
				if (!c14a607c732f32524532d1bea23bdf094.m_spawnNewWeapon)
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
					GameObject weaponNPC = (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as BanditPsychoAnimationManagerFSM).m_weaponNPC;
					if (!(weaponNPC != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						c2cfec8f33a76c66baf653a18b19b423a = true;
						weaponNPC.SetActive(true);
						return;
					}
				}
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			if (c2cfec8f33a76c66baf653a18b19b423a)
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
				GameObject weaponNPC = (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as BanditPsychoAnimationManagerFSM).m_weaponNPC;
				if (!(weaponNPC != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					c2cfec8f33a76c66baf653a18b19b423a = true;
					weaponNPC.SetActive(true);
					return;
				}
			}
		}
	}
}
