using A;
using Core;
using UnityEngine;

namespace BHV
{
	public class BHVTaskPlayerSpawn : BHVTask
	{
		private BHVTaskParamPlayerSpawn c2227ddc7fcbe3fa329465d2fa8ffb479;

		public BHVTaskPlayerSpawn()
		{
			base.m_Type = BHVTaskType.PlayerSpawn;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamPlayerSpawn;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			Entity entity = cfc241af7ab51814fc074e767be1a0bb8.m_entity;
			if (entity.caac907d451029d68503484a63934c93f())
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
				if ((bool)c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86)
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
					c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0888ee52497af70d4cc14624cbd11269(true);
					if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
						UIMessage uIMessage = new UIMessage();
						uIMessage.m_type = UIMessage.c7487b4eea694c61027850111354bc24f.ce46bb1d037377c00fcc2fab1aa927d01;
						uIMessage.m_text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c8e693f5f3ec2e82bd093c9a5d56bdf43().m_name));
						uIMessage.m_displayCountDown = false;
						uIMessage.m_duration = 5f;
						c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5(uIMessage);
						if (FriendManager.c71f6ce28731edfd43c976fbd57c57bea().m_bNewMessageUnread)
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
							if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().cd0069281ff5290a7e6c484b6aed3933d)
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
								c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().cf198707970ccb9ab868e90753613ed18();
							}
						}
						GroupManager.c71f6ce28731edfd43c976fbd57c57bea().cbbe9fff63c456ab61d7d04aab4ae5f01();
					}
				}
			}
			ParticleEffect[] componentsInChildren = cfc241af7ab51814fc074e767be1a0bb8.m_entity.GetComponentsInChildren<ParticleEffect>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (!(componentsInChildren[i].m_myName == "PlayRevive"))
				{
					continue;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				ParticleSystem particleSystem = (ParticleSystem)Object.Instantiate(componentsInChildren[i].m_effect);
				particleSystem.transform.position = cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position;
				particleSystem.transform.rotation = Quaternion.Euler(270f, 0f, 0f);
				particleSystem.transform.parent = entity.transform;
				if (!particleSystem.playOnAwake)
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
					particleSystem.Play();
				}
				Object.Destroy(particleSystem.gameObject, 3f);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				cfc241af7ab51814fc074e767be1a0bb8.m_entity.BroadcastMessage("TriggerEffectByName", "PlayerReviveStart", SendMessageOptions.DontRequireReceiver);
				EntityPlayer entityPlayer = entity as EntityPlayer;
				if ((bool)entityPlayer)
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
					entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3.OnPlayerRespawn();
					UIMapDataManager.c71f6ce28731edfd43c976fbd57c57bea().OnPlayerRevive(entityPlayer);
					entityPlayer.OnPlayerRespawn();
					entityPlayer.c8b0e994a248a912b115148e865a26464();
				}
				base.m_Status = BHVTaskStatus.RUNNING;
				return;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.BroadcastMessage("TriggerEffectByName", "PlayerReviveEnd", SendMessageOptions.DontRequireReceiver);
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
				Entity entity = cfc241af7ab51814fc074e767be1a0bb8.m_entity;
				c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c9e16403ef21c39f75e639d41fc5111b7().cddbb691fc8f8aca349591e50c2f98b80(entity);
				return;
			}
		}
	}
}
