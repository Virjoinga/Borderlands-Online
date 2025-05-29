using System;
using System.Collections;
using A;
using UnityEngine;

public class CurtainMecanimManager : MonoBehaviour
{
	public bool m_enableLift;

	private bool m_needUpdate;

	public bool m_liftStarted;

	public Animator m_curtainAnimator;

	private bool m_foundNPC;

	private NPCAnimationManagerFSM m_npcAnimManger;

	private void Start()
	{
		m_curtainAnimator = GetComponent<Animator>();
		IEnumerator enumerator = base.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Transform transform = (Transform)enumerator.Current;
				if (!transform.name.ToLower().Contains("cube"))
				{
					continue;
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
					CurtainTriggerHelper curtainTriggerHelper = transform.gameObject.AddComponent<CurtainTriggerHelper>();
					curtainTriggerHelper.m_curtainManager = this;
					return;
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
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						goto end_IL_0097;
					}
					continue;
					end_IL_0097:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	private void Update()
	{
		if (m_foundNPC)
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
			c794594733998881757167af37b7b962b();
		}
		if (m_liftStarted)
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
			m_enableLift = false;
			m_needUpdate = true;
		}
		m_liftStarted = m_enableLift;
		if (!(m_curtainAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!m_needUpdate)
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
				m_curtainAnimator.SetBool("IsLifting", m_enableLift);
				m_needUpdate = false;
				return;
			}
		}
	}

	public void OnTriggerEnter(Collider intruder)
	{
		if (m_enableLift)
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
					return;
				}
			}
		}
		m_npcAnimManger = intruder.gameObject.GetComponentInParent<NPCAnimationManagerFSM>();
		if (!(m_npcAnimManger != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_foundNPC = true;
			return;
		}
	}

	private void c794594733998881757167af37b7b962b()
	{
		if (!m_foundNPC)
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
			if (!(m_npcAnimManger != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!(m_curtainAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					float sqrMagnitude = (base.transform.position - m_npcAnimManger.transform.position).sqrMagnitude;
					if (m_npcAnimManger.ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.CombatSpawn))
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
							{
								float num = 3f;
								if (sqrMagnitude < num)
								{
									while (true)
									{
										switch (2)
										{
										case 0:
											break;
										default:
											m_curtainAnimator.SetTrigger("tCombatLift");
											m_foundNPC = false;
											return;
										}
									}
								}
								return;
							}
							}
						}
					}
					if (!m_npcAnimManger.ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.AdvanceSpawn))
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
						float num2 = 0.5f;
						if (!(sqrMagnitude < num2))
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
							m_curtainAnimator.SetTrigger("tAdvanceLift");
							m_npcAnimManger.OnTriggerAdvanceSpawn();
							m_foundNPC = false;
							return;
						}
					}
				}
			}
		}
	}
}
