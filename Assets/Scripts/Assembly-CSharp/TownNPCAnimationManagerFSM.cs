using A;
using UnityEngine;

public class TownNPCAnimationManagerFSM : MonoBehaviour
{
	public enum TownNpcAnimationType
	{
		NONE = 0,
		IDLE = 1,
		GREET = 2,
		FINISH = 3
	}

	private bool m_missionFinishPending;

	private bool m_greetPending;

	private Animator m_animator;

	public int m_extraIdleAnimCount;

	public float m_extraIdlePlayChance;

	public void Start()
	{
		m_animator = GetComponentInChildren<Animator>();
		m_animator.applyRootMotion = false;
		m_animator.updateMode = AnimatorUpdateMode.Normal;
		m_animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
		for (int i = 0; i < m_animator.layerCount; i++)
		{
			m_animator.SetLayerWeight(i, 1f);
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
			return;
		}
	}

	public void Update()
	{
		if (!m_greetPending)
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
			if (!m_missionFinishPending)
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
				if (m_extraIdleAnimCount > 0)
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
					if (Random.Range(0f, 1f) < m_extraIdlePlayChance)
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
						m_animator.SetBool("bIdleExtra", true);
						int value = (int)(Random.Range(0f, 0.9999f) * (float)m_extraIdleAnimCount);
						m_animator.SetInteger("iIdleIndex", value);
					}
					else
					{
						m_animator.SetBool("bIdleExtra", false);
					}
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<NPCDialogView>() != null)
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
				if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<NPCDialogView>().c3dcc75cd10b9ee6a7830e31932f6df00())
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
					m_animator.SetBool("bIdleExtra", false);
				}
			}
		}
		if (m_greetPending)
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
			m_animator.SetBool("bGreet", true);
			m_greetPending = false;
		}
		else
		{
			m_animator.SetBool("bGreet", false);
		}
		if (m_missionFinishPending)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					m_animator.SetBool("bMissionComplete", true);
					m_missionFinishPending = false;
					return;
				}
			}
		}
		m_animator.SetBool("bMissionComplete", false);
	}

	public bool c979843b9afa58b1781f5d83769d1e4fb(TownNpcAnimationType c0776ef3d9221a4a4962a4559b0e35bdd)
	{
		if (c0776ef3d9221a4a4962a4559b0e35bdd == TownNpcAnimationType.GREET)
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
					m_greetPending = true;
					return true;
				}
			}
		}
		if (c0776ef3d9221a4a4962a4559b0e35bdd == TownNpcAnimationType.FINISH)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					m_missionFinishPending = true;
					return true;
				}
			}
		}
		return false;
	}
}
