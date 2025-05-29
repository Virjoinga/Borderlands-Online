using System.Collections.Generic;
using A;
using BHV;
using UnityEngine;

public class EntityExplosive : EntityObject, AreaDamager
{
	public Transform m_brokenEntity_prefab;

	public float m_ExplosiveForce = 300f;

	public float m_colliderRadius;

	protected Transform brokenEntity;

	public override void Start()
	{
		base.Start();
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new AreaDamage());
		if (m_subType != EntitySubType.Grenade)
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
			object[] array = c9fc033d895059e2080450369e258d5f0();
			if (array == null)
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
				if (array.Length <= 0)
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
					int c35f98ccbfa8c6bf09319c620b21b5dc = (int)array[0];
					c71e2faacad39f5de99408bee4edd5367(BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c35f98ccbfa8c6bf09319c620b21b5dc));
					return;
				}
			}
		}
	}

	public void c5253ca17ae006a22025093f8cafde97c()
	{
	}

	public void c8f0de95b6b6a3e87162079927a1bee91()
	{
		if (!(m_brokenEntity_prefab != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			brokenEntity = Object.Instantiate(m_brokenEntity_prefab, base.transform.position, m_brokenEntity_prefab.rotation) as Transform;
			if (!(brokenEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				Rigidbody componentInChildren = brokenEntity.GetComponentInChildren<Rigidbody>();
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
					componentInChildren.isKinematic = false;
					componentInChildren.transform.position += Vector3.up * 0.5f;
					componentInChildren.velocity = Vector3.up * m_ExplosiveForce;
					componentInChildren.angularVelocity = Random.insideUnitSphere * Random.Range(6f, 15f);
					return;
				}
			}
		}
	}

	public override bool cad418535912a1c3cb6ea0ce1e4cbd114()
	{
		if (m_subType != EntitySubType.ExposiveDestructible_Barrel)
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
			if (m_subType != EntitySubType.NPC_Grenade)
			{
				return base.cad418535912a1c3cb6ea0ce1e4cbd114();
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
		}
		return true;
	}

	public override bool ce003fe849cc45b85ca4570109817c796()
	{
		BHVTaskManager bHVTaskManager = c9b6d1d87bef7b03dad787ff0031551ee();
		if (bHVTaskManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return true;
				}
			}
		}
		BHVTask bHVTask = bHVTaskManager.c2d51f6bc5c05cfbf476c30230c67b09e();
		if (bHVTask == null)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return true;
				}
			}
		}
		return bHVTask.m_Type == BHVTaskType.Dead;
	}

	public override void ce7325a1f0410a6d170ae58fce0f0ae7f(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		if (c3521c9096ab7c30ece57e61bdb8622f2 == null)
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
		if (m_subType == EntitySubType.Grenade)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.CountDown, new BHVTaskCountDown());
					c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.BlowUp, new BHVTaskBlowUp());
					return;
				}
			}
		}
		if (m_subType != EntitySubType.ExposiveDestructible_Barrel)
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
			c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Default, new BHVTaskDefault());
			c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.BlowUp, new BHVTaskBlowUp());
			c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Disabled, new BHVTaskDisabled());
			return;
		}
	}
}
