using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using Photon;
using UnityEngine;
using XsdSettings;

public class DamageManager : Photon.MonoBehaviour
{
	private DamageSystem m_damageSystem = new DamageSystem();

	private Dictionary<Pair<int, short>, List<DamageContext>> m_damageBuffer = new Dictionary<Pair<int, short>, List<DamageContext>>();

	private Dictionary<Pair<int, short>, List<DamageContext>> m_appliedDamageBuffer = new Dictionary<Pair<int, short>, List<DamageContext>>();

	private List<Entity> m_damageableEntities = new List<Entity>();

	private List<IDamageListener> m_damageListeners = new List<IDamageListener>();

	private static DamageManager s_instance;

	private Dictionary<int, int> m_multiKillsToSerialize = new Dictionary<int, int>();

	public static DamageManager c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			return s_instance;
		}
	}

	public List<Entity> cb8a72c40c1b6db1b4a333f6af978a477()
	{
		return m_damageableEntities;
	}

	public void cf3d2cb82d21abb0d2de84f85c25fdb49(Entity c549114bcc0adc0850579ffbf2b8d0aa6)
	{
		if (m_damageableEntities.Contains(c549114bcc0adc0850579ffbf2b8d0aa6))
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
			m_damageableEntities.Add(c549114bcc0adc0850579ffbf2b8d0aa6);
			return;
		}
	}

	public void cd5e20c96aa545559531f1792ec0f8b61(Entity c549114bcc0adc0850579ffbf2b8d0aa6)
	{
		if (!m_damageableEntities.Contains(c549114bcc0adc0850579ffbf2b8d0aa6))
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
			m_damageableEntities.Remove(c549114bcc0adc0850579ffbf2b8d0aa6);
			return;
		}
	}

	public void c5c5b57d23b5b73637a6ed6524fed2be5(IDamageListener c4fb424736fa316f1f6c03dd59f419dd2)
	{
		m_damageListeners.Add(c4fb424736fa316f1f6c03dd59f419dd2);
	}

	public void c67b40caae87a37a992e8004e2229b0eb(IDamageListener c4fb424736fa316f1f6c03dd59f419dd2)
	{
		if (!m_damageListeners.Contains(c4fb424736fa316f1f6c03dd59f419dd2))
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
			m_damageListeners.Remove(c4fb424736fa316f1f6c03dd59f419dd2);
			return;
		}
	}

	private void Awake()
	{
		s_instance = this;
	}

	private void Start()
	{
		m_damageSystem.ccc9d3a38966dc10fedb531ea17d24611();
	}

	public float c99eed77fc7972e1cedd74ab862117b4e(AttackInfo.ElementalType cdde15e415d8c1cdd0d502ae01b80b58d, Entity c42167b7db020f2e5cd252c40ece23f3b, Entity c9fd4dd0ab9bc10aa34242de0def9d8f4)
	{
		return m_damageSystem.c99eed77fc7972e1cedd74ab862117b4e(cdde15e415d8c1cdd0d502ae01b80b58d, c42167b7db020f2e5cd252c40ece23f3b, c9fd4dd0ab9bc10aa34242de0def9d8f4);
	}

	public void cf0cf12bb1103f08c7a5d05618e0f8781(HitInfo cab3b059ef8d7994c0474c0fc10a08d33, bool c0ea90b943954dfb309da54924fca03b4)
	{
		DamageInfo c36964cf41281414170f34ee68bef6c = default(DamageInfo);
		c8347f10dea711681dd4ae9a2b7de6aeb.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		if (!m_damageSystem.c4946f219fce052aa41b878a8c07b1f78(cab3b059ef8d7994c0474c0fc10a08d33, c0ea90b943954dfb309da54924fca03b4, ref c36964cf41281414170f34ee68bef6c))
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
			c31b3c5366409f071ae3f6e5c252b70d7(cab3b059ef8d7994c0474c0fc10a08d33.m_to, c36964cf41281414170f34ee68bef6c, false);
			return;
		}
	}

	public void c47cb2969becdbe14624ace7928b1e732(HitInfo cab3b059ef8d7994c0474c0fc10a08d33, float c997345152cfe8f0da7a8ebca2c0b00b6)
	{
		DamageInfo c36964cf41281414170f34ee68bef6c = default(DamageInfo);
		c8347f10dea711681dd4ae9a2b7de6aeb.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		if (!m_damageSystem.c47cb2969becdbe14624ace7928b1e732(cab3b059ef8d7994c0474c0fc10a08d33, c997345152cfe8f0da7a8ebca2c0b00b6, ref c36964cf41281414170f34ee68bef6c))
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
			c31b3c5366409f071ae3f6e5c252b70d7(cab3b059ef8d7994c0474c0fc10a08d33.m_to, c36964cf41281414170f34ee68bef6c, false);
			return;
		}
	}

	public void Update()
	{
		c8780ff6ab9f38f3519e2dfcee6233f48();
		c5453f53c9b67cf0dc076eae9ed3a015b();
	}

	private void c5453f53c9b67cf0dc076eae9ed3a015b()
	{
		KillContext c36964cf41281414170f34ee68bef6c = default(KillContext);
		cd9a35fa8458adae2bf60f2f0d45530ff.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		Dictionary<Pair<int, short>, List<DamageContext>> appliedDamageBuffer = m_appliedDamageBuffer;
		m_appliedDamageBuffer = m_damageBuffer;
		m_damageBuffer = appliedDamageBuffer;
		Dictionary<Pair<int, short>, List<DamageContext>>.Enumerator enumerator = m_appliedDamageBuffer.GetEnumerator();
		while (enumerator.MoveNext())
		{
			for (int i = 0; i < enumerator.Current.Value.Count; i++)
			{
				DamageContext context = enumerator.Current.Value[i];
				if (AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(context.m_damageInfo.m_attackSubType) == AttackInfo.AttackType.Recover)
				{
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (!context.m_isRemote)
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
				DamageInfo damageInfo = context.m_damageInfo;
				if (damageInfo.m_isLethal)
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
					WeakPoint weakPoint = context.m_victim.c63f8f07320313ddc4213cb59ee025962().c92b2d96b80fc4e8dc19a3368e56dbacb(damageInfo.m_weakPointIndex);
					c36964cf41281414170f34ee68bef6c.m_isRemote = context.m_isRemote;
					c36964cf41281414170f34ee68bef6c.m_killer = context.m_killer;
					c36964cf41281414170f34ee68bef6c.m_victim = context.m_victim;
					c36964cf41281414170f34ee68bef6c.m_strengthType = weakPoint.cf7d609e6e0384b70ae8d814e5f8712be();
					c36964cf41281414170f34ee68bef6c.m_partInfo = weakPoint.m_partInfo;
					c36964cf41281414170f34ee68bef6c.m_subType = damageInfo.m_attackSubType;
					c36964cf41281414170f34ee68bef6c.m_elementalType = damageInfo.m_elementalType;
					if (c36964cf41281414170f34ee68bef6c.m_victim != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (c36964cf41281414170f34ee68bef6c.m_killer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							c36964cf41281414170f34ee68bef6c.m_killDistance = Vector3.Distance(c36964cf41281414170f34ee68bef6c.m_victim.c4cf00ced2bc60ae908904eb73692869f(), c36964cf41281414170f34ee68bef6c.m_killer.c4cf00ced2bc60ae908904eb73692869f());
						}
					}
				}
				for (int j = 0; j < m_damageListeners.Count; j++)
				{
					IDamageListener damageListener = m_damageListeners[j];
					damageListener.OnDamaged(context);
					if (!damageInfo.m_isLethal)
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
					damageListener.OnEntityKill(c36964cf41281414170f34ee68bef6c);
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
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			m_appliedDamageBuffer.Clear();
			return;
		}
	}

	private void cce30b97abe77829589f89d476a11ebca(Hashtable c46c28f9df8f298f653c065268a14c4de)
	{
		if (c46c28f9df8f298f653c065268a14c4de.Count == 0)
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
					return;
				}
			}
		}
		DamageInfo c36964cf41281414170f34ee68bef6c = default(DamageInfo);
		c8347f10dea711681dd4ae9a2b7de6aeb.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		int num = 0;
		m_multiKillsToSerialize.Clear();
		byte b = (byte)c46c28f9df8f298f653c065268a14c4de[num++];
		for (int i = 0; i < b; i++)
		{
			c36964cf41281414170f34ee68bef6c.m_from = (int)c46c28f9df8f298f653c065268a14c4de[num++];
			short num2 = (short)c46c28f9df8f298f653c065268a14c4de[num++];
			c36964cf41281414170f34ee68bef6c.m_attackSubType = (AttackSubType)(num2 >> 3);
			c36964cf41281414170f34ee68bef6c.m_elementalType = (AttackInfo.ElementalType)(num2 & 7);
			byte b2 = (byte)c46c28f9df8f298f653c065268a14c4de[num++];
			for (int j = 0; j < b2; j++)
			{
				int c6b41901a8ed7aa93c4da3ace90527fd = c36964cf41281414170f34ee68bef6c.m_from;
				if (AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(c36964cf41281414170f34ee68bef6c.m_attackSubType) != AttackInfo.AttackType.Recover)
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
					c6b41901a8ed7aa93c4da3ace90527fd = (int)c46c28f9df8f298f653c065268a14c4de[num++];
				}
				short num3 = (short)c46c28f9df8f298f653c065268a14c4de[num++];
				c36964cf41281414170f34ee68bef6c.m_weakPointIndex = num3 >> 8;
				c36964cf41281414170f34ee68bef6c.m_healthDamagePoints = 0;
				c36964cf41281414170f34ee68bef6c.m_shieldDamagePoints = 0;
				if (((uint)num3 & 8u) != 0)
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
					c36964cf41281414170f34ee68bef6c.m_healthDamagePoints = (int)c46c28f9df8f298f653c065268a14c4de[num++];
				}
				if (((uint)num3 & 4u) != 0)
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
					c36964cf41281414170f34ee68bef6c.m_shieldDamagePoints = (int)c46c28f9df8f298f653c065268a14c4de[num++];
				}
				c36964cf41281414170f34ee68bef6c.m_isTriggeringDamageOverTime = (num3 & 2) != 0;
				c36964cf41281414170f34ee68bef6c.m_isLethal = (num3 & 1) == 1;
				c36964cf41281414170f34ee68bef6c.m_force = 0f;
				if (c36964cf41281414170f34ee68bef6c.m_isLethal)
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
					c36964cf41281414170f34ee68bef6c.m_force = (int)(byte)c46c28f9df8f298f653c065268a14c4de[num++];
					int value = 0;
					if (m_multiKillsToSerialize.TryGetValue(c36964cf41281414170f34ee68bef6c.m_from, out value))
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
						m_multiKillsToSerialize[c36964cf41281414170f34ee68bef6c.m_from] = value + 1;
					}
					else
					{
						value = 1;
						m_multiKillsToSerialize.Add(c36964cf41281414170f34ee68bef6c.m_from, value);
					}
				}
				c31b3c5366409f071ae3f6e5c252b70d7(c6b41901a8ed7aa93c4da3ace90527fd, c36964cf41281414170f34ee68bef6c, true);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_0259;
				}
				continue;
				end_IL_0259:
				break;
			}
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			Dictionary<int, int>.Enumerator enumerator = m_multiKillsToSerialize.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Value <= 1)
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
				c06ca0e618478c23eba3419653a19760f<ScoringManager>.c5ee19dc8d4cccf5ae2de225410458b86.cb61f0369d09ada426256a3f4b80236fa(enumerator.Current.Key);
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
	}

	public void cd224839d5ae7fe7cd4bd73aeadd85706(int c6b41901a8ed7aa93c4da3ace90527fd9, DamageInfo cd267a5dc6434bf247c67a6b37ed70c84)
	{
		c31b3c5366409f071ae3f6e5c252b70d7(c6b41901a8ed7aa93c4da3ace90527fd9, cd267a5dc6434bf247c67a6b37ed70c84, false);
	}

	private void c31b3c5366409f071ae3f6e5c252b70d7(int c6b41901a8ed7aa93c4da3ace90527fd9, DamageInfo cd267a5dc6434bf247c67a6b37ed70c84, bool cda06e7be7f2d67ea759e0c02c7f27d60)
	{
		Entity entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(cd267a5dc6434bf247c67a6b37ed70c84.m_from);
		Entity entity2 = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c6b41901a8ed7aa93c4da3ace90527fd9);
		if (entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			return;
		}
		DamageContext c36964cf41281414170f34ee68bef6c = default(DamageContext);
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
			if (entity2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
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
			CollisionManager collisionManager = entity2.c63f8f07320313ddc4213cb59ee025962();
			if (collisionManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			WeakPoint weakPoint = collisionManager.c92b2d96b80fc4e8dc19a3368e56dbacb(cd267a5dc6434bf247c67a6b37ed70c84.m_weakPointIndex);
			c5b252c14162865d44a44d7be43e5ca3f.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
			c36964cf41281414170f34ee68bef6c.m_killer = entity;
			c36964cf41281414170f34ee68bef6c.m_victim = entity2;
			int strengthType;
			if (weakPoint != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				strengthType = (int)weakPoint.cf7d609e6e0384b70ae8d814e5f8712be();
			}
			else
			{
				strengthType = 2;
			}
			c36964cf41281414170f34ee68bef6c.m_strengthType = (WeakPoint.StrengthType)strengthType;
			c36964cf41281414170f34ee68bef6c.m_subType = cd267a5dc6434bf247c67a6b37ed70c84.m_attackSubType;
			c36964cf41281414170f34ee68bef6c.m_damageInfo = cd267a5dc6434bf247c67a6b37ed70c84;
			c36964cf41281414170f34ee68bef6c.m_isRemote = cda06e7be7f2d67ea759e0c02c7f27d60;
			int num = ((short)cd267a5dc6434bf247c67a6b37ed70c84.m_attackSubType << 3) | ((byte)cd267a5dc6434bf247c67a6b37ed70c84.m_elementalType & 7);
			Pair<int, short> key = new Pair<int, short>(cd267a5dc6434bf247c67a6b37ed70c84.m_from, (short)num);
			List<DamageContext> value;
			if (m_damageBuffer.TryGetValue(key, out value))
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						value.Add(c36964cf41281414170f34ee68bef6c);
						return;
					}
				}
			}
			value = new List<DamageContext>();
			value.Add(c36964cf41281414170f34ee68bef6c);
			m_damageBuffer.Add(key, value);
			return;
		}
	}

	private void c8780ff6ab9f38f3519e2dfcee6233f48()
	{
		Dictionary<Pair<int, short>, List<DamageContext>>.Enumerator enumerator = m_damageBuffer.GetEnumerator();
		while (enumerator.MoveNext())
		{
			List<DamageContext> value = enumerator.Current.Value;
			for (int i = 0; i < value.Count; i++)
			{
				DamageContext value2 = value[i];
				c5520d5df549295f1a70dc0731be6884f(value[i].m_victim, value2.m_damageInfo, value[i].m_isRemote);
				value[i] = value2;
			}
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
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	private bool c5520d5df549295f1a70dc0731be6884f(Entity cf7ee7f254a35f9c53a393957e2758a0a, DamageInfo cd267a5dc6434bf247c67a6b37ed70c84, bool cda06e7be7f2d67ea759e0c02c7f27d60)
	{
		bool flag = AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(cd267a5dc6434bf247c67a6b37ed70c84.m_attackSubType) == AttackInfo.AttackType.Recover;
		bool result = false;
		EquipmentInventoryEntity equipmentInventoryEntity = cf7ee7f254a35f9c53a393957e2758a0a.c5ca38fad98337fc5c7255384b2cd1a86();
		if (equipmentInventoryEntity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return result;
				}
			}
		}
		if (!cda06e7be7f2d67ea759e0c02c7f27d60)
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
			equipmentInventoryEntity.cdfac57bd798072bd71a801c00909ad5c();
		}
		int c94fb97bff20285635980507f7f1a581a = 0;
		if (cd267a5dc6434bf247c67a6b37ed70c84.m_shieldDamagePoints > 0)
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
			EntityShield entityShield = cf7ee7f254a35f9c53a393957e2758a0a.c136b0f223897fdf01d18a9a5e3745433();
			if (entityShield != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (flag)
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
					entityShield.c0a6259fccb95aae60756b4a48cccb967(cd267a5dc6434bf247c67a6b37ed70c84.m_shieldDamagePoints);
					c06ca0e618478c23eba3419653a19760f<ScoringManager>.c5ee19dc8d4cccf5ae2de225410458b86.c79b0bc249fb8e76dcf6d1941f8abaee5(cf7ee7f254a35f9c53a393957e2758a0a);
				}
				else if (cda06e7be7f2d67ea759e0c02c7f27d60)
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
					c94fb97bff20285635980507f7f1a581a = entityShield.c161e5599d0a306e313f79a5877c6369d(cd267a5dc6434bf247c67a6b37ed70c84.m_shieldDamagePoints);
				}
				else
				{
					c94fb97bff20285635980507f7f1a581a = entityShield.c12ae0653eb79cbb9fc3827b68549679f(cd267a5dc6434bf247c67a6b37ed70c84.m_shieldDamagePoints);
				}
			}
			else if (!flag)
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
				string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(5);
				array[0] = "Shield Damage: [";
				array[1] = cd267a5dc6434bf247c67a6b37ed70c84.m_shieldDamagePoints.ToString();
				array[2] = "] on Entity: [";
				array[3] = cf7ee7f254a35f9c53a393957e2758a0a.m_name;
				array[4] = "] without shield!";
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Concat(array));
			}
		}
		int num = cd267a5dc6434bf247c67a6b37ed70c84.m_healthDamagePoints;
		int num2 = 0;
		WeakPoint weakPoint = cf7ee7f254a35f9c53a393957e2758a0a.c63f8f07320313ddc4213cb59ee025962().c92b2d96b80fc4e8dc19a3368e56dbacb(cd267a5dc6434bf247c67a6b37ed70c84.m_weakPointIndex);
		if (weakPoint != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!flag)
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
				int num3 = equipmentInventoryEntity.c0e018ed0ee4ac2592fafd36d256cd617(weakPoint);
				if (num3 > 0)
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
					if (cda06e7be7f2d67ea759e0c02c7f27d60)
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
						equipmentInventoryEntity.c15ecef7ebaa3979b9ad1ce64ac8a6c25(weakPoint, num3 - cd267a5dc6434bf247c67a6b37ed70c84.m_healthDamagePoints);
						num2 = num3 - equipmentInventoryEntity.c0e018ed0ee4ac2592fafd36d256cd617(weakPoint);
					}
					else
					{
						num2 = cd267a5dc6434bf247c67a6b37ed70c84.m_healthDamagePoints;
					}
					num -= num2;
				}
			}
		}
		int num4 = num;
		if (num > 0)
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
			int num5 = equipmentInventoryEntity.ca2ff7a501878363cb1d5f0472e306620();
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
				equipmentInventoryEntity.cf0a63fdc9831dd55ae40ac6a5f5eb7e0(num5 + num);
			}
			else if (cda06e7be7f2d67ea759e0c02c7f27d60)
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
				equipmentInventoryEntity.cf0a63fdc9831dd55ae40ac6a5f5eb7e0(Mathf.Max(0, num5 - num));
				num4 = num5 - equipmentInventoryEntity.ca2ff7a501878363cb1d5f0472e306620();
			}
		}
		if (!cda06e7be7f2d67ea759e0c02c7f27d60)
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
			equipmentInventoryEntity.c06ade3733c4658b091be622d9d3b4034();
		}
		if (c06ca0e618478c23eba3419653a19760f<ImpactManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c06ca0e618478c23eba3419653a19760f<ImpactManager>.c5ee19dc8d4cccf5ae2de225410458b86.c32fc71b48a1dfa81f5deb24415522cea(cf7ee7f254a35f9c53a393957e2758a0a, cd267a5dc6434bf247c67a6b37ed70c84, c94fb97bff20285635980507f7f1a581a, num4 + num2, cda06e7be7f2d67ea759e0c02c7f27d60);
			}
		}
		return result;
	}

	[RPC]
	private void RPC_D(Hashtable t)
	{
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		if (playerInfoSync.c2d17ea39faa888e633ce06615ddf5c6a < PlayerInfoSync.PlayerState.PlayerAndMapReady)
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
		for (int i = 0; i < t.Count; i++)
		{
			cce30b97abe77829589f89d476a11ebca(t[i] as Hashtable);
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

	public int c1f787f99a147b5c013b65bed97203d9d()
	{
		return m_damageSystem.c1f787f99a147b5c013b65bed97203d9d();
	}

	public int cf81797f580e0ae4c2e2409eb821640dc()
	{
		return m_damageSystem.cf81797f580e0ae4c2e2409eb821640dc();
	}
}
