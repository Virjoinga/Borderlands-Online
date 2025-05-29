using A;
using UnityEngine;
using XsdSettings;

public class TurretManage : PlayerSkillManage, InstantiateManager.InstanciationClient
{
	private Utils.Timer m_firerate_timer = new Utils.Timer();

	private Utils.Timer m_progressTimer_turretLife = new Utils.Timer();

	private Utils.Timer m_progressTimer_cooldown = new Utils.Timer();

	public override void ccc9d3a38966dc10fedb531ea17d24611()
	{
		base.ccc9d3a38966dc10fedb531ea17d24611();
		m_skillId_begin_include = ESkillType.TurretFirstAction;
		m_skillId_end_exclude = ESkillType.HunterFirstAction;
		m_skillInfo.m_current_skillID = SkillID.Turret;
	}

	public override void Update()
	{
		base.Update();
		OnUpdateProgress_Skill(m_progressTimer_turretLife.c8d61bc457bf1e08126a3d9d2111b25df());
		OnUpdateProgress_CoolDown(m_progressTimer_cooldown.c8d61bc457bf1e08126a3d9d2111b25df());
	}

	public override float cba71a23bdb67f16190ef730e9b8368b9()
	{
		float result = 1f;
		if (m_firerate_timer.cb261500372fa488b369e9159a002977a())
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
			if (!m_firerate_timer.cf928603d375f06225f9eb5213fb17bd4())
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
				result = m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.WpnSwapFireRate);
			}
		}
		return result;
	}

	public override void OnTriggerAction(float _delay)
	{
		m_animDelay = _delay;
	}

	public override void OnSkillTask(ESkillStatePhase _phase)
	{
		if (_phase == ESkillStatePhase.First)
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
					OnTurretTask_1st();
					return;
				}
			}
		}
		if (_phase != ESkillStatePhase.Second)
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
			OnTurretTask_2nd();
			return;
		}
	}

	public override bool c5989500ec6e64423320cf907a28c4cd1()
	{
		return true;
	}

	public override void OnPlayerRespawn()
	{
	}

	public override void OnLeaveSession()
	{
	}

	public override void OnPostAssembly()
	{
		c6eb2695eb8c7e4e60396c781791597bc(false);
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.ca207f1e0d04d63120f9d87ad07507680(ENPCParticleType.E_Berserk_CureHeart, m_playerOwner.transform);
	}

	public override float c1234d6489af2ea5a3ff2b70ba1f6cc73()
	{
		return m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.WeaponReloadSpeed);
	}

	public override float c85f8da0801bec67f8d8eabc5fdb07dbb()
	{
		return m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.WeaponSwitchSpeed);
	}

	public override void OnDamaged(DamageContext context)
	{
	}

	public override void OnSwitchWeaponDone()
	{
		if (!(m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.WpnSwapFireRate) > 1f))
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
			m_firerate_timer.Start(m_playerOwner.c02f3d4a4e7d1edee179f9bf7e16aeb82.c275ce281d2ced47562dce554e5197b73(ESkillType.Readiness));
			return;
		}
	}

	public override void c36677ec303a1d28a6920e312ed95c716(Entity cf7ee7f254a35f9c53a393957e2758a0a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
	}

	private void OnTurretTask_1st()
	{
		c45eb6e54f6c8fbaef2ba4baa67b2833f();
		OnSkillEvent(SkillEvent.TurretThrowAnimStart);
	}

	private void OnTurretTask_2nd()
	{
		c7a5ee1ae2bbbc5b94ff201dc306edc7c();
	}

	private void c45eb6e54f6c8fbaef2ba4baa67b2833f()
	{
		AnimationPlayerThrowTurretState animationPlayerThrowTurretState = m_animationMgr.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerThrowTurret)) as AnimationPlayerThrowTurretState;
		animationPlayerThrowTurretState.m_netLatency = m_animDelay;
		animationPlayerThrowTurretState.c62547c0ac815478499192b622a3a73d3(m_animationMgr.c04ca5acd4c692e7b2a810ed8ac4deeca(), m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.TurretDeployFar) > 1f);
		m_animationMgr.c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerThrowTurret);
	}

	private void c7a5ee1ae2bbbc5b94ff201dc306edc7c()
	{
		AnimationPlayerRetrieveTurretState animationPlayerRetrieveTurretState = m_animationMgr.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerRetrieveTurret)) as AnimationPlayerRetrieveTurretState;
		animationPlayerRetrieveTurretState.m_netLatency = m_animDelay;
		animationPlayerRetrieveTurretState.c62547c0ac815478499192b622a3a73d3(m_animationMgr.c04ca5acd4c692e7b2a810ed8ac4deeca());
		m_animationMgr.c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerRetrieveTurret);
	}

	private void c3c1677fc4f196466e9b79250b427b49a(Vector3 c710b43a3c01ee77c7da1c2a00fa275f3)
	{
	}

	private void ca02ee559654c1a1134a0f486fc351126()
	{
	}

	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
	}

	public override void OnSkillEvent_Local(SkillEvent _event, float _duration, Vector3 _vParam)
	{
		if (!m_playerOwner.cd95354b53e674ec7dc9594e66e4d316f().c16d1154aec91a0f8f4a52d77fc081194())
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
			if (m_eventMap.ContainsKey(_event))
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
				m_eventMap[_event]();
			}
			if (_event == SkillEvent.CureHeartVFXOn)
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
				c6eb2695eb8c7e4e60396c781791597bc(true);
			}
			else if (_event == SkillEvent.CureHeartVFXOff)
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
				c6eb2695eb8c7e4e60396c781791597bc(false);
			}
			else
			{
				m_progressTimer_turretLife.cdada4c3678c9c23c38aaf0754a94a620();
				m_progressTimer_cooldown.cdada4c3678c9c23c38aaf0754a94a620();
				if (_event == SkillEvent.TurretSpawned)
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
					m_progressTimer_turretLife.Start(_duration);
				}
				else if (_event == SkillEvent.TurretCooldownStart)
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
					m_progressTimer_cooldown.Start(_duration);
				}
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDSkillStatusView>().OnSkillEvent(_event);
			return;
		}
	}

	public override void OnSkillEvent_Client(SkillEvent _event, float _fParam, Vector3 _vParam)
	{
		Vector3 c330987c4414f384d6c951ab9f68460d = _vParam + Vector3.up;
		if (_event == SkillEvent.TurretSpawned)
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
					m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_TurretSpawn, c330987c4414f384d6c951ab9f68460d, Quaternion.identity, true);
					if (m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.TurretDeployExplode) > 1f)
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
						m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_Explode, c330987c4414f384d6c951ab9f68460d, Quaternion.identity, true);
					}
					cca5b86399c7561fec112c17784c56541(_vParam);
					return;
				}
			}
		}
		if (_event == SkillEvent.TurretRetrieve)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c0c5ca8f54702477a0524e764704df02c(ENPCParticleType.E_TurretOff, null, c330987c4414f384d6c951ab9f68460d, Quaternion.identity);
					cbe13611081c960e0d98e09d4d7b43875();
					return;
				}
			}
		}
		if (_event != SkillEvent.TurretRepulseExplode)
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
			m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_Explode, c330987c4414f384d6c951ab9f68460d, Quaternion.identity, true);
			return;
		}
	}

	private void cca5b86399c7561fec112c17784c56541(Vector3 ced4db7ec37c5c4b63a2d2621865cbb6f)
	{
		ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c = ENPCParticleType.E_TurretRegenAmmo;
		bool flag = m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.AmmoRegenAOE) > 0f;
		bool flag2 = m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.HealthRegenAOE) > 0f;
		if (!flag)
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
			if (!flag2)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}
		if (flag)
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
			if (!flag2)
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
				c6e9c05551eaa310c6fcb665b20682b9c = ENPCParticleType.E_TurretRegenAmmo;
				goto IL_00be;
			}
		}
		if (!flag)
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
			if (flag2)
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
				c6e9c05551eaa310c6fcb665b20682b9c = ENPCParticleType.E_TurretRegenHealth;
				goto IL_00be;
			}
		}
		if (flag)
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
			if (flag2)
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
				c6e9c05551eaa310c6fcb665b20682b9c = ENPCParticleType.E_TurretRegenAmmoHealth;
			}
		}
		goto IL_00be;
		IL_00be:
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c930218e437c0501ced1553e08dab14d9(c6e9c05551eaa310c6fcb665b20682b9c, ced4db7ec37c5c4b63a2d2621865cbb6f + Vector3.up);
	}

	private void cbe13611081c960e0d98e09d4d7b43875()
	{
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_TurretRegenAmmo);
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_TurretRegenHealth);
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_TurretRegenAmmoHealth);
	}
}
