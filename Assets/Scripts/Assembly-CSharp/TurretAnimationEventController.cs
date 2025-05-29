using A;
using BHV;
using UnityEngine;

public class TurretAnimationEventController : AnimationEventController
{
	private bool m_weaponInitPending;

	private Animator m_weaponAnimator;

	public Transform m_yawFulcrum;

	public Transform m_pitchFulcrum;

	public Transform m_missleLeft;

	public Transform m_missleRight;

	[SerializeField]
	private float m_yawAnglePrevious;

	[SerializeField]
	private float m_pitchAnglePrevious;

	private float m_pitchAngleThreshold = 50f;

	private void Start()
	{
		m_weaponInitPending = true;
	}

	public bool c44eade940817eaa11b873a6707e9beb9()
	{
		if (base.gameObject.transform.parent == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
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
		m_entityNpc = base.gameObject.transform.parent.GetComponent<EntityNpc>();
		if (m_entityNpc == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (m_entityNpc.cdcf5e0592c05a681a8470f66674efd0b() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		m_entityNpcWeapon = m_entityNpc.cdcf5e0592c05a681a8470f66674efd0b().m_weapon;
		if (m_entityNpcWeapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		SkinnedMeshRenderer componentInChildren = m_entityNpcWeapon.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		componentInChildren.enabled = false;
		m_weaponAnimator = m_entityNpcWeapon.GetComponentInChildren<Animator>();
		if (m_weaponAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_weaponAnimator.transform.localPosition = new Vector3(-0.5f, 0f, 0f);
			m_weaponAnimator.transform.localRotation = Quaternion.Euler(0f, 270f, 0f);
		}
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
		int num = 0;
		while (true)
		{
			if (num < componentsInChildren.Length)
			{
				Transform transform = componentsInChildren[num];
				if (m_pitchFulcrum != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (m_yawFulcrum != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (m_missleLeft != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							if (m_missleRight != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								break;
							}
						}
					}
				}
				if (transform.name == "Export_BasePitch")
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
					m_yawFulcrum = transform;
				}
				else if (transform.name == "Export_SecondaryPitch")
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
					m_pitchFulcrum = transform;
				}
				else if (transform.name == "Missle_Launch_L")
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
					m_missleLeft = transform;
				}
				else if (transform.name == "Missle_Launch_R")
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
					m_missleRight = transform;
				}
				num++;
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
			break;
		}
		return true;
	}

	private void Update()
	{
		if (m_weaponInitPending)
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
			m_weaponInitPending = !c44eade940817eaa11b873a6707e9beb9();
		}
		c7789fd79e95bd9f0c30cfa3b5488d1c9();
	}

	[ContextMenu("Start Shoot")]
	public void OnShootStart()
	{
		if (!(m_entityNpcWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_entityNpcWeapon.c6f2004a1cbc439c9b630d1dd5c028bf3();
			return;
		}
	}

	private void c7789fd79e95bd9f0c30cfa3b5488d1c9()
	{
		if (!c94210167d913c8791d422af746616869())
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
		if (m_entityNpcWeapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		Vector3 vector = m_targetPosition;
		if (!m_hasValidTargetPosition)
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
			if (m_targetObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				vector = m_targetObject.transform.position;
				Entity component = m_targetObject.GetComponent<Entity>();
				if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					vector += new Vector3(0f, component.m_entityHeight / 2f, 0f);
				}
			}
		}
		Vector3 normalized = (vector - m_entityNpcWeapon.transform.position).normalized;
		Vector3 normalized2 = base.transform.forward.normalized;
		Debug.c01037ade1f1152c7345e14ef90726aba(m_entityNpcWeapon.transform.position, vector, Color.red);
		Debug.c01037ade1f1152c7345e14ef90726aba(m_entityNpcWeapon.transform.position, m_entityNpcWeapon.transform.position + normalized2, Color.blue);
		if (!(m_pitchFulcrum != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			float to = BHVTaskUtils.cb9d402b3a18cd6eb6f306d1024377f7f(normalized2, normalized);
			float value = BHVTaskUtils.c05f720acdd75c6e6928513766665807d(-m_entityNpcWeapon.transform.right, normalized);
			value = Mathf.Clamp(value, -80f, 40f);
			m_yawAnglePrevious = Mathf.Lerp(m_yawAnglePrevious, to, 0.3f);
			if (Mathf.Abs(m_pitchAnglePrevious - value) > m_pitchAngleThreshold)
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
				m_pitchAnglePrevious = Mathf.Lerp(m_pitchAnglePrevious, value, 0.1f);
			}
			else
			{
				m_pitchAnglePrevious = Mathf.Lerp(m_pitchAnglePrevious, value, 0.01f);
			}
			m_pitchFulcrum.localRotation = Quaternion.Euler(0f, m_yawAnglePrevious, m_pitchAnglePrevious);
			return;
		}
	}
}
