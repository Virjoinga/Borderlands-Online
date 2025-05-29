using A;
using UnityEngine;
using XsdSettings;

public class PlayerAnimationIkController : MonoBehaviour
{
	public Animator m_animator;

	public bool m_enableAimIK;

	public bool m_enableLookIK;

	private float m_aimIKweight;

	public Vector3 m_targetPosition = Vector3.zero;

	public GameObject m_targetObject;

	public bool m_hasValidTargetPosition;

	public Transform m_PlayerLeftHandSmg;

	public Transform m_PlayerLeftHandShotgun;

	public Transform m_PlayerLeftHandSniper;

	public Transform m_PlayerLeftHandPistol;

	public Transform m_PlayerLeftHandCombatRifle;

	public WeaponType m_currentWeaponType;

	public bool m_enableLeftHandIK;

	public bool m_pendingLeftHandIK;

	private float m_pendingLeftHandIKweight;

	public WeaponType m_pendingWeaponType;

	public float m_aimHightOffset = 0.4f;

	private float m_lookIKClamp = 0.7f;

	public void c1388b070a9ff180c6a0efe41ddf70e31(Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900)
	{
		m_hasValidTargetPosition = true;
		m_targetPosition = c0b885a96d3f0d32f51ff3ec0d37d2900;
	}

	public void c1e667d6f38b9e5836b1229ac7567f858(GameObject c2008d5793f81ed289732e3227d73f220)
	{
		m_hasValidTargetPosition = false;
		m_targetObject = c2008d5793f81ed289732e3227d73f220;
	}

	public void ce40f0b6c3f7714ac1c3daa73f26d266d()
	{
		m_hasValidTargetPosition = false;
		m_targetObject = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
	}

	private void Start()
	{
		m_animator = GetComponent<Animator>();
		m_aimIKweight = 0f;
		m_pendingLeftHandIKweight = 0f;
	}

	public bool c94210167d913c8791d422af746616869()
	{
		int result;
		if (!(m_targetObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			result = (m_hasValidTargetPosition ? 1 : 0);
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	private Vector3 c73e2bfa4617ac967e7785d3787e0eaba()
	{
		if (m_targetObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					EntityPlayer component = m_targetObject.GetComponent<EntityPlayer>();
					if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								if (component.cc6a7269e9ea93e537de47dc752b09a86() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
								{
									while (true)
									{
										switch (4)
										{
										case 0:
											break;
										default:
											return component.c4fba392e405428b3fd4874067a8b82ac();
										}
									}
								}
								return component.c8cc25ca9fd18f583f33395178ef47f1d();
							}
						}
					}
					return m_targetObject.transform.position;
				}
				}
			}
		}
		return m_targetPosition;
	}

	private void OnAnimatorIK(int layerIndex)
	{
		if (m_animator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_animator = GetComponent<Animator>();
		}
		if (m_enableAimIK)
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
			if (c94210167d913c8791d422af746616869())
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
				if (layerIndex == 0)
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
					m_aimIKweight = Mathf.Lerp(m_aimIKweight, 1f, 0.2f);
					Vector3 lookAtPosition = c73e2bfa4617ac967e7785d3787e0eaba();
					m_animator.SetLookAtWeight(1f * m_aimIKweight, 0.6f * m_aimIKweight, 0.6f * m_aimIKweight, 1f * m_aimIKweight, 0.5f);
					m_animator.SetLookAtPosition(lookAtPosition);
				}
			}
		}
		else
		{
			m_aimIKweight = 0f;
		}
		if (!m_enableAimIK)
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
			if (m_enableLookIK)
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
				if (c94210167d913c8791d422af746616869())
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
					Vector3 lookAtPosition2 = c73e2bfa4617ac967e7785d3787e0eaba();
					m_animator.SetLookAtWeight(1f, 0f, 0.7f, 1f, m_lookIKClamp);
					m_animator.SetLookAtPosition(lookAtPosition2);
				}
			}
		}
		if (layerIndex != 1)
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
			if (m_enableLeftHandIK)
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
				cdda1e287dce0fbab9a07cdb40c1a7ab3(m_currentWeaponType, 1f);
				m_pendingLeftHandIK = false;
			}
			if (m_pendingLeftHandIK)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						m_pendingLeftHandIKweight = Mathf.Lerp(m_pendingLeftHandIKweight, 1f, 0.3f);
						cdda1e287dce0fbab9a07cdb40c1a7ab3(m_pendingWeaponType, m_pendingLeftHandIKweight);
						return;
					}
				}
			}
			m_pendingLeftHandIKweight = 0f;
			return;
		}
	}

	public bool cdda1e287dce0fbab9a07cdb40c1a7ab3(WeaponType c27b7430edc94b8f5b543605119ec4a72, float c115a49db0f305d86b716636a3ea5c482)
	{
		if (c27b7430edc94b8f5b543605119ec4a72 == WeaponType.RepeaterPistol)
		{
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
				return true;
			}
		}
		if (!(c115a49db0f305d86b716636a3ea5c482 > 1f))
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
			if (!(c115a49db0f305d86b716636a3ea5c482 < 0f))
			{
				goto IL_0053;
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
		c115a49db0f305d86b716636a3ea5c482 = Mathf.Clamp(c115a49db0f305d86b716636a3ea5c482, 0f, 1f);
		goto IL_0053;
		IL_0053:
		if (m_PlayerLeftHandSmg == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c957eb7bd5fb2aef5d3eca9eab35ba4f8();
		}
		Transform transform = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
		switch (c27b7430edc94b8f5b543605119ec4a72)
		{
		case WeaponType.SMG:
			transform = m_PlayerLeftHandSmg;
			break;
		case WeaponType.ShotGun:
			transform = m_PlayerLeftHandShotgun;
			break;
		case WeaponType.SniperRifle:
			transform = m_PlayerLeftHandSniper;
			break;
		case WeaponType.RepeaterPistol:
			transform = m_PlayerLeftHandPistol;
			break;
		case WeaponType.CombatRifle:
			transform = m_PlayerLeftHandCombatRifle;
			break;
		}
		if (transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		m_animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, c115a49db0f305d86b716636a3ea5c482);
		m_animator.SetIKPosition(AvatarIKGoal.LeftHand, transform.position);
		m_animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, c115a49db0f305d86b716636a3ea5c482);
		m_animator.SetIKRotation(AvatarIKGoal.LeftHand, transform.rotation);
		return true;
	}

	public bool c957eb7bd5fb2aef5d3eca9eab35ba4f8()
	{
		if (m_PlayerLeftHandSmg != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_PlayerLeftHandShotgun != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_PlayerLeftHandSniper != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (m_PlayerLeftHandPistol != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (m_PlayerLeftHandCombatRifle != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					}
				}
			}
		}
		Transform[] componentsInChildren = base.gameObject.transform.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			if (transform.gameObject.name.ToLower() == "export_l_hand_smg")
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
				m_PlayerLeftHandSmg = transform;
			}
			else if (transform.gameObject.name.ToLower() == "export_l_hand_shotgun")
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
				m_PlayerLeftHandShotgun = transform;
			}
			else if (transform.gameObject.name.ToLower() == "export_l_hand_sniper")
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
				m_PlayerLeftHandSniper = transform;
			}
			else if (transform.gameObject.name.ToLower() == "export_l_hand_pistol")
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
				m_PlayerLeftHandPistol = transform;
			}
			else
			{
				if (!(transform.gameObject.name.ToLower() == "export_l_hand_combatrifle"))
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
					if (!(transform.gameObject.name.ToLower() == "export_l_hand_rifle"))
					{
						goto IL_020e;
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
				m_PlayerLeftHandCombatRifle = transform;
			}
			goto IL_020e;
			IL_020e:
			if (m_PlayerLeftHandSmg != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_PlayerLeftHandShotgun != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (m_PlayerLeftHandSniper != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (m_PlayerLeftHandPistol != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							if (m_PlayerLeftHandCombatRifle != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
							{
								while (true)
								{
									switch (3)
									{
									case 0:
										break;
									default:
										return true;
									}
								}
							}
						}
					}
				}
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	public GameObject c8e92f5daba4d906708741a0b5f7afb19()
	{
		return m_targetObject;
	}
}
