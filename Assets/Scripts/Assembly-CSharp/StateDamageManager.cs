using System.Collections.Generic;
using A;
using UnityEngine;
using XsdSettings;

public class StateDamageManager : c06ca0e618478c23eba3419653a19760f<StateDamageManager>
{
	private DamageManager m_damageManager;

	private List<DamageEmitter> m_damageEmiters = new List<DamageEmitter>();

	private List<DamageEmitter> m_toDelete = new List<DamageEmitter>();

	public void cafe676ccf3cf6b69db4f76056920fcb6(HitInfo c3ced719b4780c1919017d69e82521ab3, float c46b361ee1a87173ef6885513d3e7cca9, float cdc9f6ace07173b95607c1a4b98439397)
	{
		DamageEmitter c36964cf41281414170f34ee68bef6c = default(DamageEmitter);
		cd56bca080fd0f72963c2a92af6407a97.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		c36964cf41281414170f34ee68bef6c.m_startDate = Time.time;
		c36964cf41281414170f34ee68bef6c.m_owner = c3ced719b4780c1919017d69e82521ab3.m_owner;
		c36964cf41281414170f34ee68bef6c.m_receiver = c3ced719b4780c1919017d69e82521ab3.m_to;
		c36964cf41281414170f34ee68bef6c.m_weakpointIndex = c3ced719b4780c1919017d69e82521ab3.m_weakPointIndex;
		c36964cf41281414170f34ee68bef6c.m_elementalType = c3ced719b4780c1919017d69e82521ab3.m_elementalType;
		c36964cf41281414170f34ee68bef6c.m_attackSubType = cc4445c3eea4cfbd3af127cd89e868e81(c3ced719b4780c1919017d69e82521ab3.m_elementalType);
		c36964cf41281414170f34ee68bef6c.m_damagePerSecond = c46b361ee1a87173ef6885513d3e7cca9;
		c36964cf41281414170f34ee68bef6c.m_duration = cdc9f6ace07173b95607c1a4b98439397;
		c36964cf41281414170f34ee68bef6c.m_frequency = 2f;
		m_damageEmiters.Add(c36964cf41281414170f34ee68bef6c);
	}

	private void Update()
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c5d990cbeec5731a071ad4e21a2ad1d91())
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
		if (m_damageManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_damageManager = DamageManager.c5ee19dc8d4cccf5ae2de225410458b86;
		}
		m_toDelete.Clear();
		float time = Time.time;
		for (int i = 0; i < m_damageEmiters.Count; i++)
		{
			if (m_damageEmiters[i].m_startDate + m_damageEmiters[i].m_duration < time)
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
				m_toDelete.Add(m_damageEmiters[i]);
				continue;
			}
			DamageEmitter c8e4748ae8b3209b568564c0a39d544a = m_damageEmiters[i];
			float num = time - c8e4748ae8b3209b568564c0a39d544a.m_startDate;
			if ((int)(num * c8e4748ae8b3209b568564c0a39d544a.m_frequency) <= c8e4748ae8b3209b568564c0a39d544a.m_damageApplicationCounter)
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
			cc8ba2141b51c42c3d4abb063d0d7c59c(ref c8e4748ae8b3209b568564c0a39d544a);
			m_damageEmiters[i] = c8e4748ae8b3209b568564c0a39d544a;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			for (int j = 0; j < m_toDelete.Count; j++)
			{
				m_damageEmiters.Remove(m_toDelete[j]);
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

	public static AttackSubType cc4445c3eea4cfbd3af127cd89e868e81(AttackInfo.ElementalType c2b4f43f34e21572af6ab4414f04cee36)
	{
		AttackSubType result = AttackSubType.DamageOverTimeGeneric;
		switch (c2b4f43f34e21572af6ab4414f04cee36)
		{
		case AttackInfo.ElementalType.Fire:
			result = AttackSubType.DamageOverTimeFire;
			break;
		case AttackInfo.ElementalType.Shock:
			result = AttackSubType.DamageOverTimeShock;
			break;
		case AttackInfo.ElementalType.Corrosive:
			result = AttackSubType.DamageOverTimeCorrosive;
			break;
		}
		return result;
	}

	private void cc8ba2141b51c42c3d4abb063d0d7c59c(ref DamageEmitter c8e4748ae8b3209b568564c0a39d544a0)
	{
		Entity entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c8e4748ae8b3209b568564c0a39d544a0.m_receiver);
		if (entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		HitInfo hitInfo = new HitInfo();
		hitInfo.m_from = c8e4748ae8b3209b568564c0a39d544a0.m_owner;
		hitInfo.m_owner = hitInfo.m_from;
		hitInfo.m_to = c8e4748ae8b3209b568564c0a39d544a0.m_receiver;
		hitInfo.m_timeStamp = Time.time;
		hitInfo.m_damagePoint = (int)(c8e4748ae8b3209b568564c0a39d544a0.m_damagePerSecond / c8e4748ae8b3209b568564c0a39d544a0.m_frequency);
		hitInfo.m_attackSubType = c8e4748ae8b3209b568564c0a39d544a0.m_attackSubType;
		hitInfo.m_elementalType = c8e4748ae8b3209b568564c0a39d544a0.m_elementalType;
		hitInfo.m_weakPointIndex = c8e4748ae8b3209b568564c0a39d544a0.m_weakpointIndex;
		m_damageManager.cf0cf12bb1103f08c7a5d05618e0f8781(hitInfo, false);
		c8e4748ae8b3209b568564c0a39d544a0.m_damageApplicationCounter++;
	}

	public void c1f9f176cdb2563b3c256c7645ee6b779(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		for (int num = m_damageEmiters.Count - 1; num > 0; num--)
		{
			Entity entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(m_damageEmiters[num].m_receiver);
			if (c5d720f6d007abb0c4a21d6a654e405bb == entity)
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
						m_damageEmiters.RemoveAt(num);
						return;
					}
				}
			}
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

	public bool c97b42995bf77c5e730d5e17bdf823764(Entity c6e853f452cc819532893b63942b8ed3d, ref AttackInfo.ElementalType c4f09c39924e70788c7b055c1d1490578)
	{
		for (int i = 0; i < m_damageEmiters.Count; i++)
		{
			DamageEmitter damageEmitter = m_damageEmiters[i];
			Entity entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(damageEmitter.m_receiver);
			if (!(c6e853f452cc819532893b63942b8ed3d == entity))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c4f09c39924e70788c7b055c1d1490578 = damageEmitter.m_elementalType;
				return true;
			}
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			return false;
		}
	}
}
