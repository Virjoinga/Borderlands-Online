using System;
using System.Collections.Generic;
using A;
using UnityEngine;

public class Scene : MonoBehaviour
{
	public enum SceneState
	{
		Sleeping = 0,
		Alerted = 1,
		Awake = 2,
		Active = 3,
		Completed = 4
	}

	public enum LogicOperator
	{
		AND = 0,
		OR = 1
	}

	public enum TargetType
	{
		None = 0,
		EntityNPC = 1,
		StaticObject = 2
	}

	[HideInInspector]
	public bool m_showStartConditions;

	[HideInInspector]
	public bool m_showOnActiveActions;

	[HideInInspector]
	public bool m_showCompletionActions;

	[HideInInspector]
	public HashSet<int> m_playerIds = new HashSet<int>();

	public List<PlayerInfoSync> m_linkedPlayers = new List<PlayerInfoSync>();

	public LogicOperator m_conditionLogic;

	[HideInInspector]
	public ClusterCompletionCondition[] m_completionConditions = ca2a819d817a2164f41283350aed328ba.c0a0cdf4a196914163f7334d9b0781a04(0);

	public ClusterCondition[] m_clusterConditions = c4ea4951765af6c06e985936c97dd5af8.c0a0cdf4a196914163f7334d9b0781a04(0);

	public int m_minDelay;

	public int m_maxDelay;

	public bool m_showDelayCountDown;

	[HideInInspector]
	private SceneState m_state;

	private int m_playerInTriggerCount;

	public HashSet<int> m_playerIdsInTrigger = new HashSet<int>();

	private Utils.Timer m_activationTimer = new Utils.Timer();

	public ClusterAction[] m_onActiveActions = c111275d4ad878a6fe2a6c4e067bb8986.c0a0cdf4a196914163f7334d9b0781a04(0);

	public ClusterAction[] m_completionActions = c111275d4ad878a6fe2a6c4e067bb8986.c0a0cdf4a196914163f7334d9b0781a04(0);

	protected bool m_resetOnNextUpdate;

	protected static UnityEngine.Object[] m_allclusters;

	public SceneState c3f963ede023fab99c4b2097e3537c34c()
	{
		return m_state;
	}

	protected void c32f11f01b3e3682f9b84ceb8b90c934b(SceneState c17fcd0ed1024ad7689991a96ed60deb1)
	{
		if (c17fcd0ed1024ad7689991a96ed60deb1 == SceneState.Active)
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
			if (m_state != c17fcd0ed1024ad7689991a96ed60deb1)
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
				for (int i = 0; i < m_onActiveActions.Length; i++)
				{
					m_onActiveActions[i].c07b7ce37423e253b784029efb12b608f(this);
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
			}
		}
		m_state = c17fcd0ed1024ad7689991a96ed60deb1;
	}

	private void OnLevelWasLoaded()
	{
		m_allclusters = UnityEngine.Object.FindObjectsOfType(Type.GetTypeFromHandle(cc32c3fbd13665939ed96b9a163d55dc9.cc1720d05c75832f704b87474932341c3()));
	}

	protected virtual void Awake()
	{
		base.enabled = false;
		if (base.transform.parent != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Act component = base.transform.parent.gameObject.GetComponent<Act>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		}
		base.gameObject.layer = 2;
	}

	public void OnClusterCompleted(Scene cluster)
	{
	}

	protected virtual void c881f5c9f672eba2e02441e1387a821ba()
	{
	}

	protected virtual void ca9b3a2d1fbbeafb416b7e606f618cdf5()
	{
		for (int i = 0; i < m_completionActions.Length; i++)
		{
			m_completionActions[i].c07b7ce37423e253b784029efb12b608f(this);
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
			c6187f42ea3b1aeb063666a8e29a37db5();
			return;
		}
	}

	protected virtual void c6187f42ea3b1aeb063666a8e29a37db5()
	{
		for (int i = 0; i < m_allclusters.Length; i++)
		{
			Scene scene = m_allclusters[i] as Scene;
			if (!scene.cf1b9e9a0d37b53d7eb1b1902507d2399())
			{
				continue;
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
			scene.OnClusterCompleted(this);
		}
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

	protected virtual bool c6b55d8e5c9702fae8ea5ac979f1a8713()
	{
		return true;
	}

	protected virtual void c6ba75e48af85bad1397056f3a37bf686()
	{
		bool flag = m_conditionLogic == LogicOperator.AND;
		for (int i = 0; i < m_clusterConditions.Length; i++)
		{
			if (!m_clusterConditions[i])
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			bool flag2 = m_clusterConditions[i].c943bc6a18586b3e0e6f0214717aca479();
			if (m_conditionLogic == LogicOperator.AND)
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
				int num;
				if (flag)
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
					num = (flag2 ? 1 : 0);
				}
				else
				{
					num = 0;
				}
				flag = (byte)num != 0;
			}
			else
			{
				int num2;
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
					num2 = (flag2 ? 1 : 0);
				}
				else
				{
					num2 = 1;
				}
				flag = (byte)num2 != 0;
			}
			if (!flag2)
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
			c32f11f01b3e3682f9b84ceb8b90c934b(SceneState.Alerted);
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (!flag)
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
				int num3 = UnityEngine.Random.Range(m_minDelay, m_maxDelay);
				if (m_showDelayCountDown)
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
				}
				m_activationTimer.Start(num3);
				c32f11f01b3e3682f9b84ceb8b90c934b(SceneState.Awake);
				return;
			}
		}
	}

	protected void cf3732cd94d5e74f6e9706d93d7b5b577()
	{
		if (!m_activationTimer.cf928603d375f06225f9eb5213fb17bd4())
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
			c881f5c9f672eba2e02441e1387a821ba();
			c32f11f01b3e3682f9b84ceb8b90c934b(SceneState.Active);
			return;
		}
	}

	protected virtual void cb537a7cebe404b48035eab26b9fd89b8()
	{
	}

	protected bool cf1b9e9a0d37b53d7eb1b1902507d2399()
	{
		int result;
		if (m_state != 0)
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
			result = ((m_state == SceneState.Alerted) ? 1 : 0);
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	private void Update()
	{
		switch (c3f963ede023fab99c4b2097e3537c34c())
		{
		case SceneState.Sleeping:
		case SceneState.Alerted:
			c6ba75e48af85bad1397056f3a37bf686();
			break;
		case SceneState.Awake:
			cf3732cd94d5e74f6e9706d93d7b5b577();
			break;
		case SceneState.Active:
			cb537a7cebe404b48035eab26b9fd89b8();
			if (!c6b55d8e5c9702fae8ea5ac979f1a8713())
			{
				break;
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c32f11f01b3e3682f9b84ceb8b90c934b(SceneState.Completed);
			ca9b3a2d1fbbeafb416b7e606f618cdf5();
			break;
		}
		if (!m_resetOnNextUpdate)
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
			c32f11f01b3e3682f9b84ceb8b90c934b(SceneState.Sleeping);
			for (int i = 0; i < m_clusterConditions.Length; i++)
			{
				if (!m_clusterConditions[i])
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
				m_clusterConditions[i].Reset();
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				m_resetOnNextUpdate = false;
				return;
			}
		}
	}

	protected void cdada4c3678c9c23c38aaf0754a94a620(bool c4dcafb983502da14728d3a540094a2c8)
	{
		c32f11f01b3e3682f9b84ceb8b90c934b(SceneState.Completed);
		ca9b3a2d1fbbeafb416b7e606f618cdf5();
	}

	public bool c30130372b82a52ab327fd70b4e72d877()
	{
		for (int i = 0; i < m_clusterConditions.Length; i++)
		{
			if (!(m_clusterConditions[i] is ClusterCondition_TriggerZone))
			{
				continue;
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
				return true;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		EntityPlayer component = other.GetComponent<EntityPlayer>();
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			PlayerInfoSync playerInfoSync = component.cd95354b53e674ec7dc9594e66e4d316f();
			if ((bool)playerInfoSync)
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
				m_playerIdsInTrigger.Add(playerInfoSync.m_id);
			}
			m_playerInTriggerCount++;
			return;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		EntityPlayer component = other.GetComponent<EntityPlayer>();
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			PlayerInfoSync playerInfoSync = component.cd95354b53e674ec7dc9594e66e4d316f();
			if ((bool)playerInfoSync)
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
				m_playerIdsInTrigger.Remove(playerInfoSync.m_id);
			}
			m_playerInTriggerCount--;
			return;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		for (int i = 0; i < m_clusterConditions.Length; i++)
		{
			if (!(m_clusterConditions[i] is ClusterCondition_TriggerZone))
			{
				continue;
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
			ClusterCondition_TriggerZone clusterCondition_TriggerZone = m_clusterConditions[i] as ClusterCondition_TriggerZone;
			if (clusterCondition_TriggerZone.c943bc6a18586b3e0e6f0214717aca479())
			{
				continue;
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
			int num = c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c6d037f57d903e6bcdcc24348eeefb88c(Entity.EntityType.Player);
			switch (clusterCondition_TriggerZone.m_triggeringCondition)
			{
			case ClusterCondition_TriggerZone.TriggerCondition.OnePlayer:
				if (m_playerInTriggerCount <= 0)
				{
					break;
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
				if (clusterCondition_TriggerZone.m_linkPlayersToThisClusterFlow)
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
					m_linkedPlayers.Clear();
					HashSet<int>.Enumerator enumerator2 = m_playerIdsInTrigger.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						m_linkedPlayers.Add(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cb062638207d3746ee631744a4709b38f(enumerator2.Current));
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
				}
				clusterCondition_TriggerZone.caf3df0cd4df215222aaa3f9ff254f1bd();
				break;
			case ClusterCondition_TriggerZone.TriggerCondition.AtLeastHalfPlayers:
				if (!((double)(num / m_playerInTriggerCount) >= 0.5))
				{
					break;
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
				if (clusterCondition_TriggerZone.m_linkPlayersToThisClusterFlow)
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
					m_linkedPlayers.Clear();
					HashSet<int>.Enumerator enumerator3 = m_playerIdsInTrigger.GetEnumerator();
					while (enumerator3.MoveNext())
					{
						m_linkedPlayers.Add(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cb062638207d3746ee631744a4709b38f(enumerator3.Current));
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
				clusterCondition_TriggerZone.caf3df0cd4df215222aaa3f9ff254f1bd();
				break;
			case ClusterCondition_TriggerZone.TriggerCondition.AllPlayers:
				if (num != m_playerInTriggerCount)
				{
					break;
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
				if (clusterCondition_TriggerZone.m_linkPlayersToThisClusterFlow)
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
					m_linkedPlayers.Clear();
					HashSet<int>.Enumerator enumerator = m_playerIdsInTrigger.GetEnumerator();
					while (enumerator.MoveNext())
					{
						m_linkedPlayers.Add(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cb062638207d3746ee631744a4709b38f(enumerator.Current));
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
				clusterCondition_TriggerZone.caf3df0cd4df215222aaa3f9ff254f1bd();
				break;
			}
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

	public void cdb5e01c8eda349f3ce37f9ce31e20845(out List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e538)
	{
		if (m_linkedPlayers.Count > 0)
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
					c9c8de68aa0982db2bbd496692c37e538 = m_linkedPlayers;
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e538);
	}

	public void ca4ab5b388a95a995236d6d405a1c1db5(Scene c0b8b4f11377b8a222dc728ff2c622559)
	{
		if (c0b8b4f11377b8a222dc728ff2c622559.m_linkedPlayers.Count <= 0)
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
			m_linkedPlayers = c0b8b4f11377b8a222dc728ff2c622559.m_linkedPlayers;
			return;
		}
	}

	public bool c6d925511a08a1bfb02c7f48ba4d49c7a(PlayerInfoSync ceb41162a7cd2a1d5c4a03830e02b4198)
	{
		if (ceb41162a7cd2a1d5c4a03830e02b4198 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return false;
				}
			}
		}
		if (m_linkedPlayers.Count > 0)
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
			for (int i = 0; i < m_linkedPlayers.Count; i++)
			{
				if (m_linkedPlayers[i].m_id != ceb41162a7cd2a1d5c4a03830e02b4198.m_id)
				{
					continue;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					return true;
				}
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
		else
		{
			List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
			c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
			for (int j = 0; j < c9c8de68aa0982db2bbd496692c37e.Count; j++)
			{
				if (c9c8de68aa0982db2bbd496692c37e[j].m_id != ceb41162a7cd2a1d5c4a03830e02b4198.m_id)
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
					return true;
				}
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
		return false;
	}
}
