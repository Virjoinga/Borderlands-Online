using System.Xml;
using A;
using UnityEngine;

public class AIInventory : MonoBehaviour, IPrefabManagerXmlSetup
{
	public int[] m_weaponID;

	public int m_shieldID;

	public int m_test;

	public bool m_bIgnoreWeaponID;

	private AnimationManagerFSM m_animationManager;

	private bool m_isWeaponSetupComplete;

	private EntityNpc m_entity;

	public EntityWeapon m_weapon { get; private set; }

	public AIInventory()
	{
		int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = -1;
		m_weaponID = array;
		m_shieldID = -1;
		m_test = -1;
		base._002Ector();
	}

	public bool ceb70887701f0c688b6ddc239066fdda5(XmlNode cdb5696c71e246b885ecb288fb00687ae)
	{
		if (cdb5696c71e246b885ecb288fb00687ae == null)
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
					return false;
				}
			}
		}
		XmlAttribute xmlAttribute = cdb5696c71e246b885ecb288fb00687ae.Attributes["IgnoreWeaponID"];
		if (xmlAttribute != null)
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
			if (!bool.TryParse(xmlAttribute.Value, out m_bIgnoreWeaponID))
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return false;
					}
				}
			}
		}
		m_weaponID[0] = -1;
		if (!m_bIgnoreWeaponID)
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
			XmlAttribute xmlAttribute2 = cdb5696c71e246b885ecb288fb00687ae.Attributes["m_weaponID"];
			if (xmlAttribute2 != null)
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
				if (!int.TryParse(xmlAttribute2.Value, out m_weaponID[0]))
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							return false;
						}
					}
				}
			}
		}
		m_shieldID = -1;
		XmlAttribute xmlAttribute3 = cdb5696c71e246b885ecb288fb00687ae.Attributes["m_shieldID"];
		if (xmlAttribute3 != null)
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
			if (!int.TryParse(xmlAttribute3.Value, out m_shieldID))
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
		}
		return true;
	}

	public virtual void Start()
	{
		m_entity = GetComponent<EntityNpc>();
		ccc9d3a38966dc10fedb531ea17d24611();
	}

	private void Update()
	{
		if (m_weapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_weapon = m_entity.c5ca38fad98337fc5c7255384b2cd1a86().cdda217ef6662acf86a5584ba19758192();
		}
		if (m_animationManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (!m_isWeaponSetupComplete)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								if ((bool)m_weapon)
								{
									while (true)
									{
										switch (6)
										{
										case 0:
											break;
										default:
											if (m_weapon.m_isReady)
											{
												while (true)
												{
													switch (2)
													{
													case 0:
														break;
													default:
														if (m_animationManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
														{
															while (true)
															{
																switch (5)
																{
																case 0:
																	break;
																default:
																	m_weapon.c959567c3d0deab4dacbe2081900e09fd(m_entity);
																	m_weapon.c1c5a947f5f8c009fe6fac45c9e29ad1d(m_entity);
																	m_isWeaponSetupComplete = true;
																	return;
																}
															}
														}
														return;
													}
												}
											}
											return;
										}
									}
								}
								return;
							}
						}
					}
					return;
				}
			}
		}
		m_animationManager = GetComponent<AnimationManagerFSM>();
	}

	private int c46ab7abc4f15c3094e92c4203e709ac9()
	{
		if (m_weaponID != null)
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
			if (m_weaponID.Length > 0)
			{
				int num = Random.Range(0, m_weaponID.Length);
				return m_weaponID[num];
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
		return -1;
	}

	public void ccc9d3a38966dc10fedb531ea17d24611()
	{
	}

	public void c8a4e2b85f019d6b3fcc6696c567d5e08(int c6390c775dc481c07da81be0014af70ed)
	{
	}

	public bool cb7b4d1fe89862d3d43df618672a1c814()
	{
		return false;
	}

	public void c1131a115e8f9ffcae5cec76e1aa6b920()
	{
	}

	public Vector3 cbf03a4f84f096adb2811087b0f34146c()
	{
		if (m_weapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return m_weapon.transform.position + Vector3.up * 0.15f;
				}
			}
		}
		if ((bool)base.gameObject)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return base.gameObject.transform.position;
				}
			}
		}
		return Vector3.zero;
	}

	public void c57c843f07ba0112bdf1c5808feef0bef()
	{
		if (!m_weapon)
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
			m_weapon.gameObject.SetActive(false);
			return;
		}
	}

	public void cd5c4f3f9b4c17f86958539945d90daaa()
	{
		if (m_weapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		NetworkManager.c1b4dc5ba75599afa71e4ac05df5cba95(m_weapon);
	}

	public bool c9a9ac72fe79382b771349b9a423bd9c7()
	{
		if (m_weapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		return m_weapon.cc93370e457eb4094fe6253d1b18437ca();
	}
}
