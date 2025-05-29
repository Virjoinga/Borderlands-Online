using A;
using UnityEngine;
using XsdSettings;

public class SoldierTurretBasicAnimationManagerFSM : NPCAnimationManagerFSM
{
	private bool m_firstTick = true;

	private GameObject m_vfx_shield;

	public override void Start()
	{
		base.Start();
		if (m_animEventHandlerList != null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_animEventHandlerList.Add("StartShoot", OnStartShoot);
		}
		cb6134b6218fa87cebeaa44c1e5ee868b();
	}

	public override void Update()
	{
		base.Update();
		if (!m_firstTick)
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
			m_firstTick = false;
			cfe93941b14e28baa59c497f98102ccd5();
			return;
		}
	}

	public void OnStartShoot()
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		EntityWeapon weapon = (m_entity as EntityNpc).cdcf5e0592c05a681a8470f66674efd0b().m_weapon;
		if (!(weapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			weapon.c6f2004a1cbc439c9b630d1dd5c028bf3();
			return;
		}
	}

	private void cb6134b6218fa87cebeaa44c1e5ee868b()
	{
		int c35f98ccbfa8c6bf09319c620b21b5dc = (int)m_entity.photonView.c332524fa6b5f6c2dfdb5f39c56de7f45[1];
		m_entity.m_relatedPlayer = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c35f98ccbfa8c6bf09319c620b21b5dc) as EntityPlayer;
	}

	private void cfe93941b14e28baa59c497f98102ccd5()
	{
		if (!VFXManager.c4accf76c0f19b142d9a734118edfa5ce())
		{
			while (true)
			{
				switch (1)
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
		if (m_vfx_shield == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			VFXManager vFXManager = m_entity.ccdbbc6879c7efc53e81b9c2fbaceead9();
			int num = 0;
			while (true)
			{
				if (num < vFXManager.m_particleList.Length)
				{
					VFXforNPC vFXforNPC = vFXManager.m_particleList[num];
					if (vFXforNPC.m_type == ENPCParticleType.E_TurretShield)
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
						m_vfx_shield = vFXforNPC.m_particleGameObject;
						break;
					}
					num++;
					continue;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				break;
			}
		}
		bool flag = m_entity.m_relatedPlayer.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.TurretShield) > 0f;
		m_vfx_shield.SetActive(flag);
	}
}
