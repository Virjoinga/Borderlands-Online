using A;
using Core;
using UnityEngine;
using XsdSettings;

public class Skeleton : MonoBehaviour
{
	private Transform m_head;

	private Transform[] m_weapons = cf8fd77ab791dc633b20ecce3257da033.c0a0cdf4a196914163f7334d9b0781a04(5);

	private EntityNpc m_npcEntity;

	private Transform[] m_offhandWeapons = cf8fd77ab791dc633b20ecce3257da033.c0a0cdf4a196914163f7334d9b0781a04(5);

	private Transform[] m_classModeNode = cf8fd77ab791dc633b20ecce3257da033.c0a0cdf4a196914163f7334d9b0781a04(2);

	private Transform m_firstPersonCamera;

	private Transform m_firstPersonPitch;

	private Transform m_firstPersonRealPitch;

	private Transform m_firstPersonPitchAdjuster;

	public void Awake()
	{
		c08a10d470ed1e69587ec68e2eae7c23d();
	}

	private string c531964042c5990e01ec03e36797bf98e(WeaponType c27b7430edc94b8f5b543605119ec4a72)
	{
		switch (c27b7430edc94b8f5b543605119ec4a72)
		{
		case WeaponType.SMG:
			return "smg";
		case WeaponType.SniperRifle:
			return "sniper";
		case WeaponType.ShotGun:
			return "shotgun";
		case WeaponType.RepeaterPistol:
			return "rep";
		case WeaponType.CombatRifle:
			return "rifle";
		default:
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Animation, "Invalid Weapon Node Type: " + c27b7430edc94b8f5b543605119ec4a72);
			return "Invalid";
		}
	}

	private string cf032c3bcbbd9da311344b4c8b0905389(WeaponType c27b7430edc94b8f5b543605119ec4a72)
	{
		switch (c27b7430edc94b8f5b543605119ec4a72)
		{
		case WeaponType.SMG:
			return "smg";
		case WeaponType.SniperRifle:
			return "sniper";
		case WeaponType.ShotGun:
			return "shotgun";
		case WeaponType.RepeaterPistol:
			return "pistol";
		case WeaponType.CombatRifle:
			return "rifle";
		default:
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Animation, "Invalid Weapon Node Type: " + c27b7430edc94b8f5b543605119ec4a72);
			return "Invalid";
		}
	}

	private void cb0bf50c3b81f57c6136156da9e9ac357(EntityNpc c5297a9331d400c616a4af21ae6786c65)
	{
		m_head = c5297a9331d400c616a4af21ae6786c65.m_headTransform;
		if (!(c5297a9331d400c616a4af21ae6786c65.m_rightHandWeaponSlot != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_weapons[0] = c5297a9331d400c616a4af21ae6786c65.m_rightHandWeaponSlot;
			if (!(c5297a9331d400c616a4af21ae6786c65.m_leftHandWeaponSlot != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_weapons[1] = c5297a9331d400c616a4af21ae6786c65.m_leftHandWeaponSlot;
				return;
			}
		}
	}

	private void c08a10d470ed1e69587ec68e2eae7c23d()
	{
		if (base.transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		m_npcEntity = GetComponent<EntityNpc>();
		if (m_npcEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					cb0bf50c3b81f57c6136156da9e9ac357(m_npcEntity);
					return;
				}
			}
		}
		Transform[] componentsInChildren = base.transform.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			string text = transform.gameObject.name.ToLower();
			if (m_head == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (!(text == "bip01 head"))
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
					if (!(text == "export_head"))
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
						if (!(text == "out_head"))
						{
							goto IL_010a;
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								continue;
							}
							break;
						}
					}
				}
				m_head = transform;
				continue;
			}
			goto IL_010a;
			IL_010a:
			if (text.ToLower().Contains("classmode_host_"))
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
				string s = text.ToLower().Substring(text.ToLower().LastIndexOf("_") + 1);
				int num = int.Parse(s) - 1;
				if (num >= 0)
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
					if (num < m_classModeNode.Length)
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
						m_classModeNode[num] = transform;
						continue;
					}
				}
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < 5)
				{
					if (m_offhandWeapons[num2] == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						string text2 = cf032c3bcbbd9da311344b4c8b0905389((WeaponType)num2);
						if (text == "export_" + text2 + "placehold")
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
							m_offhandWeapons[num2] = transform;
							break;
						}
					}
					num2++;
					continue;
				}
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
			int num3 = 0;
			while (true)
			{
				if (num3 < 5)
				{
					if (m_weapons[num3] == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						string text3 = c531964042c5990e01ec03e36797bf98e((WeaponType)num3);
						if (!(text == "bip01 r hand_" + text3))
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
							if (!(text == "export_ r_hand_" + text3))
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
								if (!(text == "export_r_hand_" + text3))
								{
									goto IL_02b6;
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
						}
						m_weapons[num3] = transform;
						break;
					}
					goto IL_02b6;
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
				break;
				IL_02b6:
				num3++;
			}
			if (num3 < 5)
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
				continue;
			}
			if (m_firstPersonCamera == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (text == "camera")
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
					m_firstPersonCamera = transform;
					continue;
				}
			}
			if (m_firstPersonPitch == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (text.Contains("hands_chr_"))
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
					m_firstPersonPitch = transform;
					continue;
				}
			}
			if (m_firstPersonRealPitch == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (text == "export_hips")
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
					m_firstPersonRealPitch = transform;
					continue;
				}
			}
			if (!(m_firstPersonPitchAdjuster == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(text == "hipsadjuster"))
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
				break;
			}
			m_firstPersonPitchAdjuster = transform;
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

	public Transform cf40f1411a71635238075b839a6650d91(WeaponType ceccaa67e17deb18ec7c67b2cb86757de)
	{
		if (m_npcEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			EntityNpcSoldierTurret entityNpcSoldierTurret = m_npcEntity as EntityNpcSoldierTurret;
			if (entityNpcSoldierTurret != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					return entityNpcSoldierTurret.cf40f1411a71635238075b839a6650d91(ceccaa67e17deb18ec7c67b2cb86757de);
				}
			}
			if (m_npcEntity.m_rightHandWeaponSlot != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return m_weapons[0];
					}
				}
			}
		}
		return m_weapons[(int)ceccaa67e17deb18ec7c67b2cb86757de];
	}

	public Transform cf50410620462e4c261abcb41d0a98221(WeaponType c27b7430edc94b8f5b543605119ec4a72)
	{
		if ((int)c27b7430edc94b8f5b543605119ec4a72 < m_offhandWeapons.Length)
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
					return m_offhandWeapons[(int)c27b7430edc94b8f5b543605119ec4a72];
				}
			}
		}
		return null;
	}

	public Transform c99ffe9fbf560125954f0bf35b449d5c8(ClassModeType cb60928ef9d0be0bfc6010c7fcf5f6ab7)
	{
		if ((int)cb60928ef9d0be0bfc6010c7fcf5f6ab7 % 2 < m_classModeNode.Length)
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
					return m_classModeNode[(int)cb60928ef9d0be0bfc6010c7fcf5f6ab7 % 2];
				}
			}
		}
		return null;
	}

	public Transform cb2362c81dda995fcf817a341a4eb3ffb()
	{
		return m_head;
	}

	public Transform c709750b2d9310309de8766e1f010dd3e()
	{
		return m_firstPersonCamera;
	}

	public Transform caf8ace1abab4e578d22e1156ba53dd04()
	{
		return m_firstPersonPitch;
	}

	public Transform c5f221d74056f6e418f625fb75143c9dc()
	{
		return m_firstPersonPitchAdjuster;
	}

	public Transform c44a36eec8bfed33afbb5a63e5aae6c2f()
	{
		return m_firstPersonRealPitch;
	}
}
