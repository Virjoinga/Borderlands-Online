using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using BHV_Skill;
using Core;
using UnityEngine;
using XsdSettings;

public class PlayerSkillManage : MonoBehaviour, IPrefabManagerXmlGenericSetup
{
	public class BaseSkillBehavior
	{
		protected PlayerSkillManage m_owner;

		public BaseSkillBehavior(PlayerSkillManage cf811c0d5de19d7fe22be8d61350b722d)
		{
			m_owner = cf811c0d5de19d7fe22be8d61350b722d;
		}

		public virtual void OnFirstAction()
		{
		}

		public virtual void OnSecondAction()
		{
		}

		public virtual bool c2176115289098326a113fedc4000e330()
		{
			return false;
		}
	}

	public class RegenHealthManage
	{
		public class RegenHealthTask
		{
			public float m_speed;

			public float m_duration;

			public RegenHealthTask(float ca43de9e73b38961ae74baf0076418786, float c704812431a0b104a6ced6cea948cd0e8)
			{
				m_speed = ca43de9e73b38961ae74baf0076418786;
				m_duration = c704812431a0b104a6ced6cea948cd0e8;
			}
		}

		private EntityPlayer m_playerOwner;

		private List<RegenHealthTask> m_taskList = new List<RegenHealthTask>();

		public RegenHealthManage(EntityPlayer cf811c0d5de19d7fe22be8d61350b722d)
		{
			m_playerOwner = cf811c0d5de19d7fe22be8d61350b722d;
		}

		public void c444e6956d2e3aa629944329c6fa446be(float ca43de9e73b38961ae74baf0076418786, float c704812431a0b104a6ced6cea948cd0e8)
		{
			m_taskList.Add(new RegenHealthTask(ca43de9e73b38961ae74baf0076418786, c704812431a0b104a6ced6cea948cd0e8));
			m_playerOwner.ccaf53be8b86b7016efd6970ff8c92ad3.c6eb2695eb8c7e4e60396c781791597bc(true);
		}

		public void Update()
		{
			for (int num = m_taskList.Count - 1; num >= 0; num--)
			{
				RegenHealthTask regenHealthTask = m_taskList[num];
				if (regenHealthTask.m_duration <= 0f)
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
					m_taskList.RemoveAt(num);
					if (m_taskList.Count == 0)
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
						m_playerOwner.ccaf53be8b86b7016efd6970ff8c92ad3.c6eb2695eb8c7e4e60396c781791597bc(false);
					}
				}
				else
				{
					regenHealthTask.m_duration -= Time.deltaTime;
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	public delegate void SkillDelegate();

	public PlayerSkillTreeManage m_eventSender;

	protected float m_animDelay;

	private float m_regenAmmoSum;

	private PlayerSkillAction m_skillAction;

	protected PlayerThirdPersonAnimationManagerFSM m_animationMgr;

	protected BaseSkillBehavior m_behavior;

	protected SkillInfo m_skillInfo = new SkillInfo();

	protected Dictionary<SkillEvent, SkillDelegate> m_eventMap = new Dictionary<SkillEvent, SkillDelegate>();

	protected EntityPlayer m_playerOwner;

	private BHVSkillSetup m_setup;

	protected ESkillType m_skillId_begin_include;

	protected ESkillType m_skillId_end_exclude = ESkillType.Max;

	private List<int> m_skillList = new List<int>();

	private bool bForceMotionless;

	protected RegenHealthManage m_regenHealthMgr;

	public bool cd7688bb64fe5a3b2c83a8ce5891f00aa
	{
		get
		{
			return bForceMotionless;
		}
		set
		{
			bForceMotionless = value;
		}
	}

	public RegenHealthManage c4272679fcbdb32603c8619b840e38e80
	{
		get
		{
			return m_regenHealthMgr;
		}
	}

	public BaseSkillBehavior c3536236f69002b26addec689ed17dc6f()
	{
		return m_behavior;
	}

	public c272566d4edbf24bb8c4df6114a524ac9 cd3d8b35d2647005675ba92178c253805<c272566d4edbf24bb8c4df6114a524ac9>() where c272566d4edbf24bb8c4df6114a524ac9 : BHVSkillSettings
	{
		return m_setup.cd3d8b35d2647005675ba92178c253805<c272566d4edbf24bb8c4df6114a524ac9>();
	}

	private void OnSpawnCompleted()
	{
		m_playerOwner = GetComponent<EntityPlayer>();
		m_regenHealthMgr = new RegenHealthManage(m_playerOwner);
	}

	public bool ceb70887701f0c688b6ddc239066fdda5(string ce6be564ae39a9af3aff0a170d981d7b6)
	{
		if (string.IsNullOrEmpty(ce6be564ae39a9af3aff0a170d981d7b6))
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
					return false;
				}
			}
		}
		try
		{
			StringReader stringReader = new StringReader(ce6be564ae39a9af3aff0a170d981d7b6);
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c93cd038fa0eab73e33735c803636d656.cc1720d05c75832f704b87474932341c3()));
				m_setup = xmlSerializer.Deserialize(stringReader) as BHVSkillSetup;
			}
			finally
			{
				if (stringReader != null)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						((IDisposable)stringReader).Dispose();
						break;
					}
				}
			}
		}
		catch (Exception ex)
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "Invalid Skill Manager Settings:" + ex.Message);
			return false;
		}
		m_setup.ccc9d3a38966dc10fedb531ea17d24611();
		return true;
	}

	public List<int> cf7f0990d94f23818b80b300c2e741783()
	{
		m_skillList.Clear();
		ESkillType[] array = (ESkillType[])Enum.GetValues(Type.GetTypeFromHandle(cb41faa2564c052311c91f10ef4b5b17b.cc1720d05c75832f704b87474932341c3()));
		ESkillType[] array2 = array;
		foreach (ESkillType eSkillType in array2)
		{
			if (eSkillType < m_skillId_begin_include)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (eSkillType >= m_skillId_end_exclude)
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
			m_skillList.Add((int)eSkillType);
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			return m_skillList;
		}
	}

	public virtual void ccc9d3a38966dc10fedb531ea17d24611()
	{
		m_skillAction = new PlayerSkillAction();
		m_animationMgr = m_playerOwner.cb8119a2676bfbd4df00a9ed683eed91a() as PlayerThirdPersonAnimationManagerFSM;
		if (!AuthoritativeActionManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_playerOwner.m_ability.ce385d5e67ccaf21ebf4f026a4744475e(m_skillAction);
			return;
		}
	}

	public virtual void Update()
	{
		m_regenHealthMgr.Update();
	}

	public virtual void ca2deb9a5d1216bb1f968806841f1236f()
	{
		m_playerOwner.m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("PlayerSkillAction", false);
	}

	public virtual float cba71a23bdb67f16190ef730e9b8368b9()
	{
		return 1f;
	}

	public virtual void OnTriggerAction(float _delay)
	{
	}

	public virtual bool c5989500ec6e64423320cf907a28c4cd1()
	{
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "Must override CanSkill()");
		return false;
	}

	public virtual float c468fbfea492ec867a1235b96939944ea(float c9f45936f2c17ac69988f93398e451ad5)
	{
		return c9f45936f2c17ac69988f93398e451ad5;
	}

	public virtual Vector3 c74699dab1caa7a33358332f2adcd2f23(Vector3 ce7083ddfe8079e1afb14ce01648c5d92)
	{
		return ce7083ddfe8079e1afb14ce01648c5d92;
	}

	public virtual void OnPlayerRespawn()
	{
	}

	public virtual void OnLeaveSession()
	{
	}

	public virtual void ccd4b1b5dac40c581cbd4343173219b40(MoveBloodWing c5f80bb56b3443c5a87b3da1802de1944)
	{
	}

	public virtual void OnPostAssembly()
	{
	}

	public virtual void OnSkillTask(ESkillStatePhase _phase)
	{
	}

	public virtual float c1234d6489af2ea5a3ff2b70ba1f6cc73()
	{
		return 1f;
	}

	public virtual float c85f8da0801bec67f8d8eabc5fdb07dbb()
	{
		return 1f;
	}

	public virtual void OnDamaged(DamageContext context)
	{
	}

	public virtual bool cdbe6e0582d3cd852a5ba1af0c375d570(EntityWeapon c63e77db49ee63186e474d32152b9912c)
	{
		return false;
	}

	public virtual int c9a052dde945512b2cc3dba220f073664(int c7ac2b014c9a1e2781ac116cc2fdaf591, float c9c14a8c95c2b692926b3e06f5b03883d)
	{
		return c7ac2b014c9a1e2781ac116cc2fdaf591;
	}

	public virtual int c7e67956d6ba1aa89d73314b76e1a2506(int c99e61eced0a1e01a6fc25d26ba70db65)
	{
		return c99e61eced0a1e01a6fc25d26ba70db65;
	}

	public virtual void c36677ec303a1d28a6920e312ed95c716(Entity cf7ee7f254a35f9c53a393957e2758a0a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
		m_playerOwner.c04d623108b1bd03e6013396a14c892c0(1f);
	}

	public virtual void OnPlayerKillEnemy(Entity _enemy, KillContext _context)
	{
	}

	public virtual bool cad91320deb5a8ef065bc5ee36fea3e2e()
	{
		return false;
	}

	public virtual void OnSwitchWeaponDone()
	{
	}

	public virtual bool cf5261b7a90515bca15928ed9a04778d0()
	{
		return false;
	}

	protected void c4fa4fc6a0bd02deb82ae409bdbf356af(Entity c42167b7db020f2e5cd252c40ece23f3b, int c0047817893bd833231211ee7dea8fa75)
	{
		HitInfo hitInfo = new HitInfo();
		hitInfo.m_from = m_playerOwner.cc7403315505256d19a7b92aa614a8f10();
		hitInfo.m_owner = m_playerOwner.cc7403315505256d19a7b92aa614a8f10();
		hitInfo.m_to = c42167b7db020f2e5cd252c40ece23f3b.cc7403315505256d19a7b92aa614a8f10();
		hitInfo.m_timeStamp = Time.time;
		hitInfo.m_damagePoint = c0047817893bd833231211ee7dea8fa75;
		hitInfo.m_attackSubType = AttackSubType.SkillReflect;
		hitInfo.m_elementalType = AttackInfo.ElementalType.None;
		hitInfo.m_weakPointIndex = (sbyte)c42167b7db020f2e5cd252c40ece23f3b.c659e11237d268aac8b68c419cf6b053a();
		DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cf0cf12bb1103f08c7a5d05618e0f8781(hitInfo, false);
	}

	public void OnUpdateProgress_Skill(float _progress)
	{
		m_skillInfo.m_skillProgress = _progress;
	}

	public void OnUpdateProgress_CoolDown(float _progress)
	{
		m_skillInfo.m_cooldownProgress = _progress;
	}

	public SkillInfo cd70afabd410fbe72ad6b0d5874fa3d9f()
	{
		return m_skillInfo;
	}

	protected void c2b15824eb5a2e2532e68e0501319ae90(SkillEvent cbd26e39b8b1d5b0abffedcac5d1ecc8f, SkillDelegate c908ba3ce506eb433fa43130004092c6a)
	{
		if (m_eventMap.ContainsKey(cbd26e39b8b1d5b0abffedcac5d1ecc8f))
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Format("SkillEvent {0} is already registered", cbd26e39b8b1d5b0abffedcac5d1ecc8f));
					return;
				}
			}
		}
		m_eventMap.Add(cbd26e39b8b1d5b0abffedcac5d1ecc8f, c908ba3ce506eb433fa43130004092c6a);
	}

	public void OnSkillEvent(SkillEvent _event)
	{
		if (m_eventMap.ContainsKey(_event))
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
			m_eventMap[_event]();
		}
		if (!m_playerOwner.cd95354b53e674ec7dc9594e66e4d316f().c16d1154aec91a0f8f4a52d77fc081194())
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDSkillStatusView>().OnSkillEvent(_event);
			return;
		}
	}

	public virtual void OnSkillEvent_Local(SkillEvent _event, float _fParam, Vector3 _vParam)
	{
		if (!m_playerOwner.cd95354b53e674ec7dc9594e66e4d316f().c16d1154aec91a0f8f4a52d77fc081194())
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (_event == SkillEvent.CureHeartVFXOn)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						c6eb2695eb8c7e4e60396c781791597bc(true);
						return;
					}
				}
			}
			if (_event != SkillEvent.CureHeartVFXOff)
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
				c6eb2695eb8c7e4e60396c781791597bc(false);
				return;
			}
		}
	}

	public virtual void OnSkillEvent_Client(SkillEvent _event, float _fParam, Vector3 _vParam)
	{
	}

	public void c6eb2695eb8c7e4e60396c781791597bc(bool c93f525ed928b54f8eb035ee537387461)
	{
		if (!VFXManager.c4accf76c0f19b142d9a734118edfa5ce())
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
			GameObject c7088de59e49f7108f520cf7e0bae167e = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
			if (m_playerOwner.caac907d451029d68503484a63934c93f())
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						c7088de59e49f7108f520cf7e0bae167e = m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.ce3d5e90605924606973312e2618e2dac(ENPCParticleType.E_Berserk_CureHeart);
						if (c7088de59e49f7108f520cf7e0bae167e != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
									c7088de59e49f7108f520cf7e0bae167e.SetActive(c93f525ed928b54f8eb035ee537387461);
									return;
								}
							}
						}
						return;
					}
				}
			}
			c7088de59e49f7108f520cf7e0bae167e = m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.ce3d5e90605924606973312e2618e2dac(ENPCParticleType.E_Berserk_CureHeart);
			if (!(c7088de59e49f7108f520cf7e0bae167e != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				c7088de59e49f7108f520cf7e0bae167e.SetActive(false);
				return;
			}
		}
	}

	public void c2750e73d7a0e76aed016e99f6a769a13(float ca43de9e73b38961ae74baf0076418786)
	{
		float num = ca43de9e73b38961ae74baf0076418786 * Time.deltaTime;
		m_regenAmmoSum += num;
		int num2 = Mathf.FloorToInt(m_regenAmmoSum);
		if (num2 <= 0)
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
			WeaponType c21171aa66b09d27be1f523137627333d = m_playerOwner.c3941dac8608f650ceb15dc36294a741c().c83e548e5608cd7f222098a6966b16545();
			int num3 = m_playerOwner.c5ca38fad98337fc5c7255384b2cd1a86().c5c30fc221fd2805f9535a08995b34b98(c21171aa66b09d27be1f523137627333d);
			m_playerOwner.c5ca38fad98337fc5c7255384b2cd1a86().ce653df38cbca26f91f2e8654ccc7b048(num3 + num2, c21171aa66b09d27be1f523137627333d);
			m_regenAmmoSum -= num2;
			return;
		}
	}

	public static int c2dd18403fa78b17c55fa02287de38e78(int cc94be3685c24bbbca06b26f5dc51a92c, float c740b3e55709408e0e5b39ade51a3a5e5)
	{
		float num = 0f;
		int num2 = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_experienceTable.Length;
		int num3 = cc94be3685c24bbbca06b26f5dc51a92c - 1;
		float powerRating;
		if (num3 < c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_experienceTable.Length)
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
			powerRating = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_experienceTable[num3].m_powerRating;
		}
		else
		{
			powerRating = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_experienceTable[num2 - 1].m_powerRating;
		}
		num = powerRating;
		return (int)(c740b3e55709408e0e5b39ade51a3a5e5 * num);
	}
}
