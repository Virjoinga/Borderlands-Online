using A;
using UnityEngine;

public class CrimsonLanceSniperAnimationManagerFSM : BanditScoutAnimationManagerFSM
{
	private SniperStealthEffect m_sniperStealEffect;

	private SkinnedMeshRenderer m_displayObjRender;

	public override void Start()
	{
		base.Start();
		m_sniperStealEffect = base.gameObject.GetComponent<SniperStealthEffect>();
		if (base.c915fd0f71703e34ea30c40c33035a630 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_displayObjRender = base.c915fd0f71703e34ea30c40c33035a630.GetComponent<SkinnedMeshRenderer>();
		}
		if (!(m_sniperStealEffect != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(m_displayObjRender != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_sniperStealEffect.m_sniperMaterials = m_displayObjRender.materials;
				return;
			}
		}
	}

	protected override void c8b7cecc28bb9c1640be075c3829771da(bool c931294945eb91e7c5c56f2a38ca1fcd9)
	{
		if (!(m_sniperStealEffect != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(m_displayObjRender != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_sniperStealEffect.cad9a3be7846b818e8bd3827fe93ef1bc(m_bHide, m_displayObjRender);
				return;
			}
		}
	}

	protected override void cce6adadf40a70610ce3ae5dd40479620(bool c931294945eb91e7c5c56f2a38ca1fcd9)
	{
		if (m_bHide == c931294945eb91e7c5c56f2a38ca1fcd9)
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
		if (c931294945eb91e7c5c56f2a38ca1fcd9)
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
			if (m_hideCooldownTime > 0f)
			{
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
		m_bHide = c931294945eb91e7c5c56f2a38ca1fcd9;
		c8b7cecc28bb9c1640be075c3829771da(c931294945eb91e7c5c56f2a38ca1fcd9);
		if (m_weapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_enetiyWeaponRenders == null)
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
				m_enetiyWeaponRenders = m_weapon.gameObject.GetComponentsInChildren<Renderer>();
			}
			int num = m_enetiyWeaponRenders.Length;
			for (int i = 0; i < num; i++)
			{
				Renderer renderer = m_enetiyWeaponRenders[i];
				if (!(renderer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				renderer.enabled = !c931294945eb91e7c5c56f2a38ca1fcd9;
			}
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
		if (c931294945eb91e7c5c56f2a38ca1fcd9)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					m_hideTime = 5f;
					return;
				}
			}
		}
		m_hideCooldownTime = 5f;
	}
}
