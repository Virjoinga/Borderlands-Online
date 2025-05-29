using A;
using UnityEngine;

public class AnimationSuicideBombState : AnimationManagerState, InstantiateManager.InstanciationClient
{
	private const string BOMBSTART_TAG = "BombStart";

	private const string BOMBIDLE_TAG = "BombIdle";

	public EAnimationSuicideBombStep m_bombStep;

	public float m_fuzeDuration;

	private Entity m_entity;

	public float c915dac06be60ba71a3eb6ab02603d615
	{
		get
		{
			return m_fuzeDuration;
		}
		set
		{
			m_fuzeDuration = value;
		}
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_entity = m_AnimationManagerFSM.gameObject.GetComponent<Entity>();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsSuicideBomb", true);
		if (m_fuzeDuration < 0f)
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
			m_fuzeDuration = 0f;
		}
		base.m_status = AnimationStatus.RUNNING;
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCasual", false);
		m_bombStep = EAnimationSuicideBombStep.BombStart;
	}

	private void c32a6aa915a0721f6ee3ea60d76c4ac05()
	{
		InstantiateManager.SpawnRequest cf4d0bdd2d52180fa1fb008e654aef5fb = default(InstantiateManager.SpawnRequest);
		cf4d0bdd2d52180fa1fb008e654aef5fb.m_prefabName = "Entities/Object/Weapon/WPN_Grenade_NPC";
		cf4d0bdd2d52180fa1fb008e654aef5fb.m_position = m_AnimationManagerFSM.m_weaponHolder.position;
		cf4d0bdd2d52180fa1fb008e654aef5fb.m_rotation = Quaternion.identity;
		cf4d0bdd2d52180fa1fb008e654aef5fb.m_group = InstantiateManager.NetworkReplicationGroup.InGame;
		cf4d0bdd2d52180fa1fb008e654aef5fb.m_spawnData = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		cf4d0bdd2d52180fa1fb008e654aef5fb.m_spawnData[0] = m_entity.cc7403315505256d19a7b92aa614a8f10();
		cf4d0bdd2d52180fa1fb008e654aef5fb.m_callbackData = c5045159a57582d4577b6fa1bce364dca.c7088de59e49f7108f520cf7e0bae167e;
		cf4d0bdd2d52180fa1fb008e654aef5fb.m_isNetworkInstanciate = true;
		cf4d0bdd2d52180fa1fb008e654aef5fb.m_caller = this;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<InstantiateManager>().cae70a8c23e816b09c686c0715bf1337c(cf4d0bdd2d52180fa1fb008e654aef5fb);
	}

	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
		EntityObject component = instance.GetComponent<EntityObject>();
		if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			component.c71e2faacad39f5de99408bee4edd5367(c72d1b2b1b60b723ae8df41127652adb5.c7088de59e49f7108f520cf7e0bae167e);
			return;
		}
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_bombStep == EAnimationSuicideBombStep.BombStart)
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
					if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0).IsTag("BombIdle"))
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								m_bombStep = EAnimationSuicideBombStep.BombIdle;
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (m_bombStep == EAnimationSuicideBombStep.BombIdle)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (m_fuzeDuration > 0f)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								m_fuzeDuration -= Time.deltaTime;
								return;
							}
						}
					}
					m_bombStep = EAnimationSuicideBombStep.BombExplode;
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsDying", true);
					return;
				}
			}
		}
		if (m_bombStep != EAnimationSuicideBombStep.BombExplode)
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
			base.m_status = AnimationStatus.SUCCESS;
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.m_status = AnimationStatus.SUCCESS;
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsDying", true);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsSuicideBomb", false);
		m_AnimationManagerFSM.m_bPlayNormalDeathAnim = true;
	}
}
