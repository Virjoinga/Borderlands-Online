using System.Collections.Generic;

public class TransitionHistoryManage
{
	public class Transition
	{
		public string m_from;

		public string m_to;

		public Transition(string c28340657247ce0251dabfe62d39c3ff3, string cb0b72b1ec03105cdaa5be61456ef75f4)
		{
			m_from = c28340657247ce0251dabfe62d39c3ff3;
			m_to = cb0b72b1ec03105cdaa5be61456ef75f4;
		}

		public bool c8168c4615d003f5ee72b2e464b1c1f7f(Transition c3bf4de86d48eac7c5a6503f7ef4a570b)
		{
			int result;
			if (m_from.Equals(c3bf4de86d48eac7c5a6503f7ef4a570b.m_from))
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
				result = (m_to.Equals(c3bf4de86d48eac7c5a6503f7ef4a570b.m_to) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	private PlayerThirdPersonAnimationManagerFSM m_owner;

	private int m_size = 5;

	private Queue<Transition> m_history = new Queue<Transition>();

	private Transition m_lastTransition;

	public TransitionHistoryManage(PlayerThirdPersonAnimationManagerFSM cf811c0d5de19d7fe22be8d61350b722d)
	{
		m_owner = cf811c0d5de19d7fe22be8d61350b722d;
		m_lastTransition = null;
	}

	public void Update()
	{
		if (!m_owner.m_firstPersonAnimator.IsInTransition(0))
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
			string name = m_owner.m_firstPersonAnimator.GetCurrentAnimationClipState(0)[0].clip.name;
			string name2 = m_owner.m_firstPersonAnimator.GetNextAnimationClipState(0)[0].clip.name;
			Transition cc3e92804c693fbe227a2510535b1c4c = new Transition(name, name2);
			cd6dedd89a8f4ff2fe963d7a22098dd65(cc3e92804c693fbe227a2510535b1c4c);
			if (m_history.Count <= m_size)
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
				m_history.Dequeue();
				return;
			}
		}
	}

	public override string ToString()
	{
		string text = string.Empty;
		using (Queue<Transition>.Enumerator enumerator = m_history.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Transition current = enumerator.Current;
				text += string.Format("  {0} -> {1},", current.m_from, current.m_to);
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
				break;
			}
		}
		return text;
	}

	private void cd6dedd89a8f4ff2fe963d7a22098dd65(Transition cc3e92804c693fbe227a2510535b1c4c7)
	{
		if (m_lastTransition != null)
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
			if (m_lastTransition.c8168c4615d003f5ee72b2e464b1c1f7f(cc3e92804c693fbe227a2510535b1c4c7))
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
				break;
			}
		}
		m_history.Enqueue(cc3e92804c693fbe227a2510535b1c4c7);
		m_lastTransition = cc3e92804c693fbe227a2510535b1c4c7;
	}
}
