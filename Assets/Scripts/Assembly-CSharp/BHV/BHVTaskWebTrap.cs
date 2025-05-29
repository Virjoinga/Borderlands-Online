using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskWebTrap : BHVTask
	{
		private BHVTaskParamWebTrap c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationWebTrapState c49f942a450af39f93ac46ecb7bb970b8;

		private Object c8e913e31a043f84fc3927285ea17b2ec;

		private Transform c379f72a0da0db85ee80fd16e7ae46083;

		public BHVTaskWebTrap()
		{
			base.m_Type = BHVTaskType.WebTrap;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamWebTrap;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c49f942a450af39f93ac46ecb7bb970b8 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("WebTrap") as AnimationWebTrapState;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.WebTrap);
			if (c8e913e31a043f84fc3927285ea17b2ec == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c8e913e31a043f84fc3927285ea17b2ec = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Entities/Object/Weapon/SpiderantWeb");
			}
			c379f72a0da0db85ee80fd16e7ae46083 = (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as WidowmakerAnimationManagerFSM).m_tailTransform;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (base.m_Status == BHVTaskStatus.SUCCESS)
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
						return;
					}
				}
			}
			if (c49f942a450af39f93ac46ecb7bb970b8.m_status == AnimationStatus.SUCCESS)
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
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
			if (!c49f942a450af39f93ac46ecb7bb970b8.m_bThrowWebTrap)
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
				c49f942a450af39f93ac46ecb7bb970b8.m_bThrowWebTrap = false;
				cffbb96bbec8758faaad10b53cb30bdac();
				return;
			}
		}

		private void cffbb96bbec8758faaad10b53cb30bdac()
		{
			if (c8e913e31a043f84fc3927285ea17b2ec == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (c379f72a0da0db85ee80fd16e7ae46083 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				GameObject gameObject = (GameObject)Object.Instantiate(c8e913e31a043f84fc3927285ea17b2ec, c379f72a0da0db85ee80fd16e7ae46083.position, Quaternion.identity);
				if (!(gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					gameObject.transform.position = c379f72a0da0db85ee80fd16e7ae46083.position;
					SpiderantWebTrap component = gameObject.GetComponent<SpiderantWebTrap>();
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
						component.cb50b0b6514bc0563cb63a6886d320d2e(c2227ddc7fcbe3fa329465d2fa8ffb479.c96d622be3be3756c5a313fa50f10bd85);
						return;
					}
				}
			}
		}
	}
}
