using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskPlayerDead : BHVTask
	{
		private BHVTaskParamPlayerDead c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationPlayerDieState c4064b5bd0ba5efd836387954f7982acc;

		public BHVTaskPlayerDead()
		{
			base.m_Type = BHVTaskType.PlayerDead;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamPlayerDead;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			base.m_Status = BHVTaskStatus.RUNNING;
			EntityPlayer entityPlayer = cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityPlayer;
			if (entityPlayer.caac907d451029d68503484a63934c93f())
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
				if ((bool)c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
						{
							c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cca84ca4deababdecf8f3d8cc7a45edb9(true);
							if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
							{
								while (true)
								{
									switch (4)
									{
									case 0:
										break;
									default:
									{
										Entity c22049b7d048f5ceaad7bdef828bdb85c = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c2227ddc7fcbe3fa329465d2fa8ffb479.cfacf58293befcb7d4cbee737e80184b0);
										c1ee7921b0c3cce194fb7cae41b5a9d82<DeathCamManager>.c5ee19dc8d4cccf5ae2de225410458b86.cc3249dca17182b3b5eacef5b5ac6620f(c22049b7d048f5ceaad7bdef828bdb85c, entityPlayer);
										cb743b0d8a8a6535d24aa1f75e21595a9();
										return;
									}
									}
								}
							}
							cfc241af7ab51814fc074e767be1a0bb8.m_entity.BroadcastMessage("TriggerEffectByName", "PlayDeath", SendMessageOptions.DontRequireReceiver);
							BaseEventTriggerCtl component = entityPlayer.GetComponent<BaseEventTriggerCtl>();
							if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
							{
								while (true)
								{
									switch (1)
									{
									case 0:
										break;
									default:
										component.TriggerEventByName("Chr_Shr_Respawn");
										return;
									}
								}
							}
							return;
						}
						}
					}
				}
			}
			cb743b0d8a8a6535d24aa1f75e21595a9();
		}

		private void cb743b0d8a8a6535d24aa1f75e21595a9()
		{
			c4064b5bd0ba5efd836387954f7982acc = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("PlayerDie") as AnimationPlayerDieState;
			c4064b5bd0ba5efd836387954f7982acc.m_force = c2227ddc7fcbe3fa329465d2fa8ffb479.c8603e2027b78e6b01305715886ad95a2;
			c4064b5bd0ba5efd836387954f7982acc.m_explosionOrigin = c2227ddc7fcbe3fa329465d2fa8ffb479.c9287e7fd25716f0fb6137e5d4ebfb94f;
			c4064b5bd0ba5efd836387954f7982acc.m_isHeadShot = c2227ddc7fcbe3fa329465d2fa8ffb479.cd7166a76de731e5b161e03f4d830b4b5;
			c4064b5bd0ba5efd836387954f7982acc.m_deathAnimIndex = c2227ddc7fcbe3fa329465d2fa8ffb479.cb4f02774bd5e0e375e5223103830ce78;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerDie);
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			if (c4064b5bd0ba5efd836387954f7982acc != null)
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
				c4064b5bd0ba5efd836387954f7982acc.caeee91e34d54e1e41ab1b380f7d8c9a4();
			}
			EntityPlayer entityPlayer = cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityPlayer;
			if (entityPlayer.caac907d451029d68503484a63934c93f())
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
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
							c1ee7921b0c3cce194fb7cae41b5a9d82<DeathCamManager>.c5ee19dc8d4cccf5ae2de225410458b86.c204f539b7fcf04cfc94507be74843444(entityPlayer);
						}
						entityPlayer.BroadcastMessage("TriggerEffectByName", "PlayRevive", SendMessageOptions.DontRequireReceiver);
						return;
					}
				}
			}
			if (!cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM)
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
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerIdle);
				return;
			}
		}
	}
}
