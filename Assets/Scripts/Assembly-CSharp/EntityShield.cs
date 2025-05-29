using A;
using UnityEngine;
using XsdSettings;

public class EntityShield : EntityObject
{
	public int m_maxShieldPoints = 100;

	public float m_regenerationCooldown = 15f;

	public float m_regenerationRate = 3f;

	public Utils.PouchNetwork m_shieldPoints = new Utils.PouchNetwork();

	private DamageInfo m_regenerator;

	private ShieldDNA m_dna;

	public ShieldAttribute m_attribute { get; private set; }

	public EntityShield()
	{
		DamageInfo c36964cf41281414170f34ee68bef6c = default(DamageInfo);
		c8347f10dea711681dd4ae9a2b7de6aeb.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		m_regenerator = c36964cf41281414170f34ee68bef6c;
		base._002Ector();
	}

	protected override void Awake()
	{
		base.Awake();
		m_shieldPoints.ccc9d3a38966dc10fedb531ea17d24611(m_maxShieldPoints);
	}

	public override void Start()
	{
		base.Start();
		if (m_dna != null)
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
			ItemDNA itemDNA = c9fc033d895059e2080450369e258d5f0()[0] as ItemDNA;
			if (itemDNA == null)
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
				if (itemDNA.c8e074b9d0135ff808166cc324407f74c() == null)
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
					if (itemDNA.c8e074b9d0135ff808166cc324407f74c().m_attribute == null)
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
						m_dna = itemDNA.c8e074b9d0135ff808166cc324407f74c();
						m_attribute = m_dna.m_attribute;
						m_maxShieldPoints = (int)m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(ShieldAttributeType.Capacity);
						m_regenerationCooldown = m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(ShieldAttributeType.RechargeDelay);
						m_regenerationRate = (float)m_maxShieldPoints * m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(ShieldAttributeType.RechargeRate);
						return;
					}
				}
			}
		}
	}

	public void c68cd0a841e044876d964965d7ec944bd(ShieldDNA caedbc1db6c28d44eab6021e7d674eab3, Entity c706ea4155b03100282fe553e4d0be557)
	{
		m_dna = caedbc1db6c28d44eab6021e7d674eab3;
		m_attribute = m_dna.m_attribute;
		m_maxShieldPoints = (int)m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(ShieldAttributeType.Capacity);
		m_regenerationCooldown = m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(ShieldAttributeType.RechargeDelay);
		m_regenerationRate = (float)m_maxShieldPoints * m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(ShieldAttributeType.RechargeRate);
		if (c706ea4155b03100282fe553e4d0be557 as EntityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_dna != null)
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
				float num = m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(ShieldAttributeType.Capacity) / ShieldAttributeConfig.s_maxShieldPoint;
				LevelingManager c5ee19dc8d4cccf5ae2de225410458b = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86;
				int cd6bb591c33b2ee3ab93e98aa43a6da;
				if (m_dna.m_level > 0)
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
					cd6bb591c33b2ee3ab93e98aa43a6da = m_dna.m_level;
				}
				else
				{
					cd6bb591c33b2ee3ab93e98aa43a6da = 1;
				}
				int num2 = c5ee19dc8d4cccf5ae2de225410458b.c4459dc4cce1d07c3d1484ae8659420f3(AvatarType.SIREN, cd6bb591c33b2ee3ab93e98aa43a6da);
				m_maxShieldPoints = Mathf.FloorToInt(num * (float)num2);
				m_regenerationRate = (float)m_maxShieldPoints * m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(ShieldAttributeType.RechargeRate);
			}
		}
		SkinnedMeshRenderer componentInChildren = base.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		int num3 = (int)m_dna.m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(ShieldAttributeType.Material);
		if (num3 <= 0)
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
			if (!(componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (num3 >= componentInChildren.materials.Length)
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
					componentInChildren.material = componentInChildren.materials[num3];
					return;
				}
			}
		}
	}

	public ShieldDNA c729ce3b5f48e0eac3a7ead97b1d02f8d()
	{
		return m_dna;
	}

	public override void c1c5a947f5f8c009fe6fac45c9e29ad1d(Entity c706ea4155b03100282fe553e4d0be557)
	{
		c71e2faacad39f5de99408bee4edd5367(c706ea4155b03100282fe553e4d0be557);
		if (c706ea4155b03100282fe553e4d0be557 as EntityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_shieldPoints.ccc9d3a38966dc10fedb531ea17d24611(0, m_maxShieldPoints);
					return;
				}
			}
		}
		m_shieldPoints.ccc9d3a38966dc10fedb531ea17d24611(m_maxShieldPoints);
	}

	public override void c67c35955d666a0c6fe54cd6e348b1675()
	{
		c71e2faacad39f5de99408bee4edd5367(c72d1b2b1b60b723ae8df41127652adb5.c7088de59e49f7108f520cf7e0bae167e);
	}

	public int c12ae0653eb79cbb9fc3827b68549679f(int c88d190ead93205eef032482d8085d15c)
	{
		int num = 0;
		return Mathf.Min(m_shieldPoints.c4c4b463091d2b6acfdded4fa12b32f25(), c88d190ead93205eef032482d8085d15c);
	}

	public int c161e5599d0a306e313f79a5877c6369d(int c88d190ead93205eef032482d8085d15c)
	{
		int num = 0;
		num = Mathf.Min(m_shieldPoints.c4c4b463091d2b6acfdded4fa12b32f25(), c88d190ead93205eef032482d8085d15c);
		m_shieldPoints.ca0f7f52805a9c67a892c5b479a17c3aa(m_shieldPoints.c4c4b463091d2b6acfdded4fa12b32f25() - num);
		return num;
	}

	public void c0a6259fccb95aae60756b4a48cccb967(int cefda2fdc3ce4e04f38bab77fc7998241)
	{
		m_shieldPoints.c9172684ab57085e2a77c2a3af69cb426(cefda2fdc3ce4e04f38bab77fc7998241);
	}

	public void cc0fea17131d6be72a517285b19e19d22()
	{
	}

	[RPC]
	public void RPC_ShieldPowUp()
	{
		EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
		if (!entityPlayer)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			BaseEventTriggerCtl component = entityPlayer.GetComponent<BaseEventTriggerCtl>();
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
				component.TriggerEventByName("Chr_Shr_Shield_Power_Up");
				return;
			}
		}
	}

	public void c0f566cbc91a795394e7799bfdbd784f8()
	{
		int num = m_shieldPoints.c17a506784adea8f822bee98ad9dba710() - m_shieldPoints.c4c4b463091d2b6acfdded4fa12b32f25();
		if (num <= 0)
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
		m_regenerator.m_attackSubType = AttackSubType.Recover;
		m_regenerator.m_from = base.m_owner.cc7403315505256d19a7b92aa614a8f10();
		m_regenerator.m_shieldDamagePoints = num;
		DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cd224839d5ae7fe7cd4bd73aeadd85706(m_regenerator.m_from, m_regenerator);
		m_shieldPoints.c0f566cbc91a795394e7799bfdbd784f8();
	}

	private float cf1286889f6b5436baf5b5033141780c1()
	{
		float num = m_regenerationRate;
		EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
		if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			num *= entityPlayer.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.ShieldRechargeRate);
			num *= entityPlayer.ca61d6db905e9724fdacd777186a9df71();
		}
		return num;
	}

	private float cb155757bb98df6a2528aa2079f80f8db(EntityPlayer c41edc6c4614cf807cf2505a9be83affe)
	{
		float num = m_regenerationCooldown;
		if (c41edc6c4614cf807cf2505a9be83affe == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return num;
				}
			}
		}
		float num2 = c41edc6c4614cf807cf2505a9be83affe.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.ShieldRechargeDelay);
		if (Mathf.Abs(num2) > 0f)
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
			num += num2;
		}
		return num;
	}
}
