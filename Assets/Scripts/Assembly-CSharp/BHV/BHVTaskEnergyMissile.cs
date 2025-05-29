using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskEnergyMissile : BHVTask
	{
		private BHVTaskParamEnergyMissile c2227ddc7fcbe3fa329465d2fa8ffb479;

		private float c831591e4a462496fb06cdf5ec1258964;

		private float c6d59908fcd50b479f305a233c50c2eb1;

		private float cd308f99baa3675cedf11f5d5d03d4903 = 4f;

		private int ce336efc5e278a350747daede81364f7a;

		private int c65edee5a363fb7a4371a0ae402616511 = 1;

		private int c3684183f481031b3f6e00b645d0a8843;

		private bool c22ecb6be0374527e5e222c4c627100bd;

		private List<PlayerInfoSync> c6fecf7c8cb00fc036bfb35364bc2f9a9;

		private int[] cf709ecc904f514ff271b03950d20b7d0;

		private UnityEngine.Object c4949861fe2fc4b528a573bf0ac1f9c43;

		public BHVTaskEnergyMissile()
		{
			int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(12);
			RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
			cf709ecc904f514ff271b03950d20b7d0 = array;
			base._002Ector();
			base.m_Type = BHVTaskType.EnergyMissile;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamEnergyMissile;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c831591e4a462496fb06cdf5ec1258964 = 4f;
			c6d59908fcd50b479f305a233c50c2eb1 = 0f;
			c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c6fecf7c8cb00fc036bfb35364bc2f9a9);
			c65edee5a363fb7a4371a0ae402616511 = c6fecf7c8cb00fc036bfb35364bc2f9a9.Count;
			c3684183f481031b3f6e00b645d0a8843 = c2227ddc7fcbe3fa329465d2fa8ffb479.c8e1a2faec8925b9197f4fa2c974bc6e5;
			ce336efc5e278a350747daede81364f7a = c2227ddc7fcbe3fa329465d2fa8ffb479.c5049abb54085b94d5c9e368188cf9f6e;
			c22ecb6be0374527e5e222c4c627100bd = false;
			cd308f99baa3675cedf11f5d5d03d4903 = 4f;
			if (c4949861fe2fc4b528a573bf0ac1f9c43 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c4949861fe2fc4b528a573bf0ac1f9c43 = (cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).m_spawnObjPrefabList[1];
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bEnergyMissile", true);
		}

		public override void Update(float deltaTime)
		{
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
			c831591e4a462496fb06cdf5ec1258964 -= deltaTime;
			if (c831591e4a462496fb06cdf5ec1258964 > 0f)
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
			if (c22ecb6be0374527e5e222c4c627100bd)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						cd308f99baa3675cedf11f5d5d03d4903 -= Time.deltaTime;
						if (cd308f99baa3675cedf11f5d5d03d4903 < 0f)
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									break;
								default:
									base.m_Status = BHVTaskStatus.SUCCESS;
									return;
								}
							}
						}
						return;
					}
				}
			}
			base.Update(deltaTime);
			c6d59908fcd50b479f305a233c50c2eb1 -= Time.deltaTime;
			if (c6d59908fcd50b479f305a233c50c2eb1 > 0f)
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
			PlayerInfoSync c7088de59e49f7108f520cf7e0bae167e = c7cfa05fd8fe0a2d1791d3ae1202ecb42.c7088de59e49f7108f520cf7e0bae167e;
			for (int i = 0; i < c65edee5a363fb7a4371a0ae402616511; i++)
			{
				c7088de59e49f7108f520cf7e0bae167e = c6fecf7c8cb00fc036bfb35364bc2f9a9[i];
				if (c7088de59e49f7108f520cf7e0bae167e == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					continue;
				}
				int num = cf709ecc904f514ff271b03950d20b7d0[ce336efc5e278a350747daede81364f7a];
				Transform c009f2361032cb12bf12af1b3d68decf = (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as ArchAngelAnimationManagerFSM).m_missileLunchPoints[num];
				ce336efc5e278a350747daede81364f7a++;
				if (ce336efc5e278a350747daede81364f7a >= 12)
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
					ce336efc5e278a350747daede81364f7a = 0;
				}
				c70fd0565c4ef5819b95fee37d2e82f38(c009f2361032cb12bf12af1b3d68decf, c7088de59e49f7108f520cf7e0bae167e);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				c6d59908fcd50b479f305a233c50c2eb1 = c2227ddc7fcbe3fa329465d2fa8ffb479.cfdc3cc82b127c5db251d86a8906d1d39;
				c3684183f481031b3f6e00b645d0a8843--;
				if (c3684183f481031b3f6e00b645d0a8843 > 0)
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
					c22ecb6be0374527e5e222c4c627100bd = true;
					return;
				}
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bEnergyMissile", false);
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
		}

		private void c70fd0565c4ef5819b95fee37d2e82f38(Transform c009f2361032cb12bf12af1b3d68decf4, PlayerInfoSync ceb41162a7cd2a1d5c4a03830e02b4198)
		{
			EntityPlayer entityPlayer = ceb41162a7cd2a1d5c4a03830e02b4198.c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
			if (entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!(c4949861fe2fc4b528a573bf0ac1f9c43 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(c4949861fe2fc4b528a573bf0ac1f9c43, c009f2361032cb12bf12af1b3d68decf4.position, Quaternion.identity);
				if (!(gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					EnergyMissile component = gameObject.GetComponent<EnergyMissile>();
					if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						component.cd232ee5f717924fbbb159f559bf8ed59(cfc241af7ab51814fc074e767be1a0bb8, entityPlayer, c2227ddc7fcbe3fa329465d2fa8ffb479.ce940cde6a50e3e1cb24c50e5c3f2e590);
						return;
					}
				}
			}
		}
	}
}
