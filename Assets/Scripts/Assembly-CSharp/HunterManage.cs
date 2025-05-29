using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using BHV_Skill;
using UnityEngine;
using XsdSettings;

public class HunterManage : PlayerSkillManage, InstantiateManager.InstanciationClient
{
	private bool m_bMarking_lastTick;

	private Utils.Timer m_delay_vfx_disappear = new Utils.Timer();

	[HideInInspector]
	public BHVSkillSettingsHunter m_settings;

	private HunterDroid m_droid;

	private Utils.Timer m_progressTimer_droidLife = new Utils.Timer();

	private Utils.Timer m_progressTimer_cooldown = new Utils.Timer();

	private HunterSkill_Script[] m_scriptOnVfxArray;

	private List<Entity> m_entityInViewList = new List<Entity>();

	private bool m_skill_active_local;

	private Utils.Timer m_spawnVfxTimer = new Utils.Timer();

	private Vector3 m_droidOffset_1st = Vector3.zero;

	private Vector3 m_droidOffset_3rd = Vector3.zero;

	public override void ccc9d3a38966dc10fedb531ea17d24611()
	{
		base.ccc9d3a38966dc10fedb531ea17d24611();
		m_skillId_begin_include = ESkillType.HunterFirstAction;
		m_skillId_end_exclude = ESkillType.Max;
		m_settings = cd3d8b35d2647005675ba92178c253805<BHVSkillSettingsHunter>();
		m_droidOffset_1st.Set(m_settings.m_offsetX_droid_1st, m_settings.m_offsetY_droid_1st, m_settings.m_offsetZ_droid_1st);
		m_droidOffset_3rd.Set(m_settings.m_offsetX_droid_3rd, m_settings.m_offsetY_droid_3rd, m_settings.m_offsetZ_droid_3rd);
		m_skillInfo.m_current_skillID = SkillID.Hunter;
	}

	public override void Update()
	{
		base.Update();
		OnUpdateProgress_Skill(m_progressTimer_droidLife.c8d61bc457bf1e08126a3d9d2111b25df());
		OnUpdateProgress_CoolDown(m_progressTimer_cooldown.c8d61bc457bf1e08126a3d9d2111b25df());
		if (m_spawnVfxTimer.cf928603d375f06225f9eb5213fb17bd4())
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_HunterDroid_Spawn, c15becf98c36914d82019201e341dc58d(ENPCParticleType.E_HunterDroid_Spawn));
		}
		bool flag = MarkCollect.c5ee19dc8d4cccf5ae2de225410458b86.c1368da069da66a9f601698db875daa18();
		if (m_bMarking_lastTick != flag)
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
			if (m_droid != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (flag)
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
					Quaternion rotation = m_playerOwner.cc6a7269e9ea93e537de47dc752b09a86().transform.rotation;
					m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_HunterDroid_Marking, c15becf98c36914d82019201e341dc58d(ENPCParticleType.E_HunterDroid_Marking), rotation, true);
				}
				else
				{
					m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_HunterDroid_Marking);
				}
			}
		}
		m_bMarking_lastTick = flag;
		if (!m_delay_vfx_disappear.cf928603d375f06225f9eb5213fb17bd4())
		{
			return;
		}
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
				switch (6)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					OnHunterTask_1st();
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
			switch (6)
			{
			case 0:
				continue;
			}
			OnHunterTask_2nd();
			return;
		}
	}

	public override bool c5989500ec6e64423320cf907a28c4cd1()
	{
		return true;
	}

	public override void OnPlayerRespawn()
	{
		cac7688b05e921e2be3f92479ba44b4a8();
	}

	public override void OnLeaveSession()
	{
		cac7688b05e921e2be3f92479ba44b4a8();
		m_scriptOnVfxArray = cad7c8e81ee9014afc41b9ab3ef599ca1.c7088de59e49f7108f520cf7e0bae167e;
	}

	public override void OnPostAssembly()
	{
		c6eb2695eb8c7e4e60396c781791597bc(false);
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.ca207f1e0d04d63120f9d87ad07507680(ENPCParticleType.E_Berserk_CureHeart, m_playerOwner.transform);
	}

	public override void c36677ec303a1d28a6920e312ed95c716(Entity cf7ee7f254a35f9c53a393957e2758a0a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
	}

	public override void OnPlayerKillEnemy(Entity _enemy, KillContext _context)
	{
	}

	public override void OnDamaged(DamageContext context)
	{
	}

	private void OnHunterTask_1st()
	{
		ccd7392b5bb04c7abed100316b1ec9d82();
		c861e58b8a6a383773de537b8215cf635();
	}

	private void OnHunterTask_2nd()
	{
		cb191b4c474d70a7772fd4b3901208f3e();
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_HunterDroid_SecondAction, c15becf98c36914d82019201e341dc58d(ENPCParticleType.E_HunterDroid_SecondAction));
		m_delay_vfx_disappear.Start(m_settings.m_retrievedroid_delay);
		using (List<Entity>.Enumerator enumerator = MarkManager.c5ee19dc8d4cccf5ae2de225410458b86.m_titleCrl.c435356281ba1e3f425fbeeb2da333da7().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Entity current = enumerator.Current;
				if (!(current != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
				}
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
				WeakPoint c38b98045365f4b50a4fbe3f1d89af = c581015e4f6ee9df70e01d3565f2f7aca.c7088de59e49f7108f520cf7e0bae167e;
				current.c659e11237d268aac8b68c419cf6b053a(out c38b98045365f4b50a4fbe3f1d89af);
				current.ccdbbc6879c7efc53e81b9c2fbaceead9().c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_Marked_Slag, current, c38b98045365f4b50a4fbe3f1d89af.transform, Vector3.zero, Quaternion.identity);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
	}

	public void cde5dfac4b028730e95b33872d6b077b2(HunterDroid c79a9891835b4bea90d7d60032515f74f)
	{
		m_droid = c79a9891835b4bea90d7d60032515f74f;
		m_skill_active_local = true;
	}

	public override void OnSkillEvent_Local(SkillEvent _event, float _duration, Vector3 _vParam)
	{
		if (_event == SkillEvent.HunterExplodeWhenMarkedKilled)
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
		if (_event == SkillEvent.HunterSkillDurationExtend)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					m_progressTimer_droidLife.c5a00d1ab96cc4cdd950eefdf7ac6be0c(_duration);
					return;
				}
			}
		}
		if (_event == SkillEvent.HunterCooldownJump)
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
			m_progressTimer_cooldown.cbc7bb46a052fc3a5521eb00eb22b1beb(_duration);
		}
		else
		{
			m_progressTimer_cooldown.cdada4c3678c9c23c38aaf0754a94a620();
		}
		m_progressTimer_droidLife.cdada4c3678c9c23c38aaf0754a94a620();
		if (_event == SkillEvent.HunterDroidSpawned)
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
			m_progressTimer_droidLife.Start(_duration);
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c988e4ac6fdd1506753a02a8d529aa7be().c02b20c991314989826a70c235439571f(m_playerOwner, ENPCParticleType.E_Hunter_FullScreen, new Vector3(0f, 0f, 1.65f), Quaternion.Euler(0f, 180f, 180f));
			VFXforNPC vFXforNPC = m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.ce8ff2ad1330d7ace4db19e7af93c265f(ENPCParticleType.E_Hunter_FullScreen);
			if (vFXforNPC != null)
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
				if (vFXforNPC.m_particleGameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (m_scriptOnVfxArray == null)
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
						m_scriptOnVfxArray = vFXforNPC.m_particleGameObject.GetComponentsInChildren<HunterSkill_Script>();
					}
					for (int i = 0; i < m_scriptOnVfxArray.Length; i++)
					{
						m_scriptOnVfxArray[i].cb87648b83ed063b8b24a3769197f46d0();
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
				}
			}
		}
		else if (_event == SkillEvent.HunterCooldownStart)
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
			m_progressTimer_cooldown.Start(_duration);
		}
		else if (_event == SkillEvent.HunterDroidEnd)
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
			m_skill_active_local = false;
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c988e4ac6fdd1506753a02a8d529aa7be().cf431f37720a42b1f9cfcdc32ff9dcd71(m_playerOwner, ENPCParticleType.E_Hunter_FullScreen);
		}
		else if (_event == SkillEvent.HunterMarkInView)
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
			cee254569cf37fcaa950b62e7b9ee6c86();
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDSkillStatusView>().OnSkillEvent(_event);
	}

	public override void OnSkillEvent_Client(SkillEvent _event, float _fParam, Vector3 _vParam)
	{
		if (_event == SkillEvent.HunterDroidEnd)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_HunterDroid_Marking);
					m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_HunterDroid_Disappear, c15becf98c36914d82019201e341dc58d(ENPCParticleType.E_HunterDroid_Disappear));
					return;
				}
			}
		}
		if (_event != SkillEvent.HunterExplodeWhenMarkedKilled)
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
			m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_Explode, _vParam);
			return;
		}
	}

	private void cee254569cf37fcaa950b62e7b9ee6c86()
	{
		m_entityInViewList.Clear();
		using (List<Entity>.Enumerator enumerator = DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cb8a72c40c1b6db1b4a333f6af978a477().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Entity current = enumerator.Current;
				if (!(current is EntityNpc))
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
					if (!(current is EntityPlayer))
					{
						continue;
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				if (c52b0e4c302961935453bec436d84dc68(current))
				{
					continue;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (current.c5ca38fad98337fc5c7255384b2cd1a86() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (current.c5ca38fad98337fc5c7255384b2cd1a86().ca2ff7a501878363cb1d5f0472e306620() <= 0)
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
					continue;
				}
				Vector3 vector = m_playerOwner.cc6a7269e9ea93e537de47dc752b09a86().camera.WorldToScreenPoint(current.transform.position);
				if (vector.x < 0f)
				{
					continue;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (vector.x > (float)Screen.width)
				{
					continue;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (vector.y < 0f)
				{
					continue;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (vector.y > (float)Screen.height)
				{
					continue;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (vector.z < 0f)
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
				}
				else if (MarkManager.c5ee19dc8d4cccf5ae2de225410458b86.m_titleCrl.cbab2dad8aaf1583a05752c4116f9b8c4(current))
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
				}
				else
				{
					m_entityInViewList.Add(current);
				}
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					goto end_IL_019a;
				}
				continue;
				end_IL_019a:
				break;
			}
		}
		if (m_entityInViewList.Count <= 0)
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
		int num = (int)m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.MultiMarkCount);
		if (m_entityInViewList.Count <= num)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
				{
					using (List<Entity>.Enumerator enumerator2 = m_entityInViewList.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							Entity current2 = enumerator2.Current;
							MarkCollect.c5ee19dc8d4cccf5ae2de225410458b86.cedc6ad9f42294f43a5568d1e54f44ea7(current2);
						}
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
				}
			}
		}
		m_entityInViewList = m_entityInViewList.OrderBy((Entity c872943035f78644fd01b267deff00547) => Vector3.Distance(m_playerOwner.transform.position, c872943035f78644fd01b267deff00547.transform.position)).ToList();
		for (int i = 0; i < num; i++)
		{
			MarkCollect.c5ee19dc8d4cccf5ae2de225410458b86.cedc6ad9f42294f43a5568d1e54f44ea7(m_entityInViewList[i]);
		}
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

	private bool c52b0e4c302961935453bec436d84dc68(Entity c6e853f452cc819532893b63942b8ed3d)
	{
		if (m_playerOwner == c6e853f452cc819532893b63942b8ed3d)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return true;
				}
			}
		}
		if (c6e853f452cc819532893b63942b8ed3d.ceb10167333758220ffb9bc66317ad763() == m_playerOwner.ceb10167333758220ffb9bc66317ad763())
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
			if (!m_playerOwner.cad418535912a1c3cb6ea0ce1e4cbd114())
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		return false;
	}

	public bool c41b7b1203f98ea7135c9a65278b49c7f()
	{
		return m_skill_active_local;
	}

	private void c861e58b8a6a383773de537b8215cf635()
	{
		m_spawnVfxTimer.Start(m_settings.m_spawnVfx_delay);
	}

	private Vector3 c15becf98c36914d82019201e341dc58d(ENPCParticleType c4f09c39924e70788c7b055c1d1490578)
	{
		Vector3 position = m_playerOwner.transform.position;
		Vector3 zero = Vector3.zero;
		switch (c4f09c39924e70788c7b055c1d1490578)
		{
		case ENPCParticleType.E_HunterDroid_Spawn:
			zero.y = -0.3f;
			position += m_playerOwner.transform.TransformDirection(cfef58f1c4809b15e4f65eab00b461e41() + zero);
			break;
		case ENPCParticleType.E_HunterDroid_Marking:
			zero = m_droid.transform.TransformDirection(new Vector3(-0.05f, 0.08f, 0.22f));
			position += m_playerOwner.transform.TransformDirection(cfef58f1c4809b15e4f65eab00b461e41());
			position += zero;
			break;
		case ENPCParticleType.E_HunterDroid_SecondAction:
			position += m_playerOwner.transform.TransformDirection(cfef58f1c4809b15e4f65eab00b461e41());
			break;
		case ENPCParticleType.E_HunterDroid_Disappear:
			position += m_playerOwner.transform.TransformDirection(cfef58f1c4809b15e4f65eab00b461e41());
			break;
		}
		return position;
	}

	public void cdf62d155034dbd0911fda9d270fcaa2b()
	{
	}

	private void ccd7392b5bb04c7abed100316b1ec9d82()
	{
		AnimationPlayerReleaseDroidState animationPlayerReleaseDroidState = m_animationMgr.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerReleaseDroid)) as AnimationPlayerReleaseDroidState;
		animationPlayerReleaseDroidState.m_netLatency = m_animDelay;
		animationPlayerReleaseDroidState.c62547c0ac815478499192b622a3a73d3(m_animationMgr.c04ca5acd4c692e7b2a810ed8ac4deeca());
		m_animationMgr.c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerReleaseDroid);
	}

	private void cb191b4c474d70a7772fd4b3901208f3e()
	{
		AnimationPlayerRetrieveDroidState animationPlayerRetrieveDroidState = m_animationMgr.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerRetrieveDroid)) as AnimationPlayerRetrieveDroidState;
		animationPlayerRetrieveDroidState.m_netLatency = m_animDelay;
		animationPlayerRetrieveDroidState.c62547c0ac815478499192b622a3a73d3(m_animationMgr.c04ca5acd4c692e7b2a810ed8ac4deeca());
		m_animationMgr.c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerRetrieveDroid);
	}

	private void cac7688b05e921e2be3f92479ba44b4a8()
	{
		m_skill_active_local = false;
		OnSkillEvent(SkillEvent.HunterCooldownEnd);
		OnSkillEvent(SkillEvent.HunterCooldownStart);
		c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c988e4ac6fdd1506753a02a8d529aa7be().cf431f37720a42b1f9cfcdc32ff9dcd71(m_playerOwner, ENPCParticleType.E_Hunter_FullScreen);
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_HunterDroid_Marking);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDSkillStatusView>().OnSkillEvent(SkillEvent.HunterDroidEnd);
		m_progressTimer_droidLife.cdada4c3678c9c23c38aaf0754a94a620();
	}

	public Vector3 cfef58f1c4809b15e4f65eab00b461e41()
	{
		Vector3 result;
		if (m_playerOwner.cd95354b53e674ec7dc9594e66e4d316f().c16d1154aec91a0f8f4a52d77fc081194())
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			result = m_droidOffset_1st;
		}
		else
		{
			result = m_droidOffset_3rd;
		}
		return result;
	}

	[CompilerGenerated]
	private float cfe6d97a4555e9486a562653a3e38c135(Entity c872943035f78644fd01b267deff00547)
	{
		return Vector3.Distance(m_playerOwner.transform.position, c872943035f78644fd01b267deff00547.transform.position);
	}
}
