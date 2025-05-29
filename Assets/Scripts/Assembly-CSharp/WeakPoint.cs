using System;
using A;
using UnityEngine;

[Serializable]
[AddComponentMenu("Physics/WeakPoint")]
public class WeakPoint : MonoBehaviour
{
	public enum MatterType
	{
		INVALID = -1,
		Flesh = 0,
		Armor = 1,
		MAX = 2
	}

	public enum StrengthType
	{
		INVALID = -1,
		VeryWeak = 0,
		Weak = 1,
		Normal = 2,
		Strong = 3,
		VeryStrong = 4,
		Indestructible = 5,
		MAX = 6
	}

	public enum DamagePropagationType
	{
		INVALID = -1,
		ApplyToOwner = 0,
		ApplyToSelf = 1,
		MAX = 2
	}

	public enum PartInfo
	{
		None = 0,
		Head = 1,
		Body = 2,
		Hand = 3,
		Foot = 4,
		Armor_Left = 5,
		Armor_Right = 6,
		Armor_Back = 7,
		Armor_Front = 8
	}

	public DamagePropagationType m_damagePropagationType;

	public StrengthType m_strengthType = StrengthType.Normal;

	public StrengthType m_strengthTypeForPvP = StrengthType.Normal;

	public MatterType m_matterType;

	public PartInfo m_partInfo;

	public bool m_isDefaultWeakPoint;

	private Collider m_collider;

	private Vector3 m_vInitPos;

	private Quaternion m_initRotation;

	public Collider cac6286fb02aed4914febe35bdf6b9e2e()
	{
		return m_collider;
	}

	public bool cf3d09e30f1d1bc489a1c3a97d696dbe2()
	{
		int result;
		if (m_partInfo != PartInfo.Armor_Back)
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
			if (m_partInfo != PartInfo.Armor_Front)
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
				if (m_partInfo != PartInfo.Armor_Left)
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
					result = ((m_partInfo == PartInfo.Armor_Right) ? 1 : 0);
					goto IL_004e;
				}
			}
		}
		result = 1;
		goto IL_004e;
		IL_004e:
		return (byte)result != 0;
	}

	private void Awake()
	{
		m_vInitPos = base.transform.localPosition;
		m_initRotation = base.transform.localRotation;
		m_collider = GetComponent<Collider>();
	}

	public void c23487ba5bae52418f400eca74da63212()
	{
		base.transform.localPosition = m_vInitPos;
		base.transform.localRotation = m_initRotation;
	}

	public StrengthType cf7d609e6e0384b70ae8d814e5f8712be()
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return m_strengthType;
				}
			}
		}
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return m_strengthType;
				}
			}
		}
		return m_strengthTypeForPvP;
	}
}
