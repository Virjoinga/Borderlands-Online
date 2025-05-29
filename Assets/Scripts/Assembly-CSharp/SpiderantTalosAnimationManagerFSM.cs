using A;
using UnityEngine;

public class SpiderantTalosAnimationManagerFSM : NPCAnimationManagerFSM
{
	private EntityNpcSpiderantTalos m_entityTalos;

	public override void Start()
	{
		base.Start();
		m_deathLayer = 1;
		m_entityTalos = GetComponent<EntityNpcSpiderantTalos>();
		m_animEventHandlerList.Add("MeleeHit", base.OnMeleeHit);
		m_animEventHandlerList.Add("RadiusAttackHit", OnRadiusAttackHit);
		cac1acd3ff18d7854be00a02e8550abd8();
	}

	public override void c2fee075e4a1b0f8c507d7c8a821f5719(WeakPoint.PartInfo c76fc0034391c602fa96b58c36512a097)
	{
		if (c76fc0034391c602fa96b58c36512a097 == WeakPoint.PartInfo.Armor_Left)
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
					c31f295e8652fbe2dd683ca74a7d22dd8(m_entityTalos.m_armorLeft, false);
					cf03fc6978e1be2b239ea0ecfd5f159b7(m_entityTalos.m_armorLeft);
					return;
				}
			}
		}
		if (c76fc0034391c602fa96b58c36512a097 == WeakPoint.PartInfo.Armor_Right)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					c31f295e8652fbe2dd683ca74a7d22dd8(m_entityTalos.m_armorRight, false);
					cf03fc6978e1be2b239ea0ecfd5f159b7(m_entityTalos.m_armorRight);
					return;
				}
			}
		}
		if (c76fc0034391c602fa96b58c36512a097 != WeakPoint.PartInfo.Armor_Back)
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
			c31f295e8652fbe2dd683ca74a7d22dd8(m_entityTalos.m_armorBack, false);
			cf03fc6978e1be2b239ea0ecfd5f159b7(m_entityTalos.m_armorBack);
			return;
		}
	}

	public void cf03fc6978e1be2b239ea0ecfd5f159b7(Transform c63017dffbb632e326f1f0dbbd1ca49ca)
	{
		if (m_VFXManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_VFXManager = m_animationHost.GetComponent<VFXManager>();
		}
		WeakPoint componentInChildren = c63017dffbb632e326f1f0dbbd1ca49ca.gameObject.GetComponentInChildren<WeakPoint>();
		if (!(componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_VFXManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_IceBroken, componentInChildren.transform);
			return;
		}
	}

	public void cac1acd3ff18d7854be00a02e8550abd8()
	{
		c31f295e8652fbe2dd683ca74a7d22dd8(m_entityTalos.m_armorLeft, true);
		c31f295e8652fbe2dd683ca74a7d22dd8(m_entityTalos.m_armorRight, true);
		c31f295e8652fbe2dd683ca74a7d22dd8(m_entityTalos.m_armorBack, true);
	}

	public void c31f295e8652fbe2dd683ca74a7d22dd8(Transform c63017dffbb632e326f1f0dbbd1ca49ca, bool c920ec89e005050fc25d0cfe7686e61bc)
	{
		if (!(c63017dffbb632e326f1f0dbbd1ca49ca != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			Transform transform = c63017dffbb632e326f1f0dbbd1ca49ca.FindChild("displayObj");
			if (!(transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				MeshRenderer component = transform.gameObject.GetComponent<MeshRenderer>();
				if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					component.enabled = c920ec89e005050fc25d0cfe7686e61bc;
					return;
				}
			}
		}
	}

	public void OnRadiusAttackHit()
	{
		AnimationRadiusAttackState animationRadiusAttackState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.RadiusAttack)) as AnimationRadiusAttackState;
		if (animationRadiusAttackState == null)
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
			animationRadiusAttackState.m_radiusAttackHit = true;
			return;
		}
	}
}
