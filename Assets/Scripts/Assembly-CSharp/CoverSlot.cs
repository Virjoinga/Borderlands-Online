using System;
using Core;
using UnityEngine;

[Serializable]
public class CoverSlot : Slot
{
	public enum CoverHeight
	{
		INVALID = -1,
		LOW = 0,
		HIGH = 1
	}

	public enum CoverDirectionMask
	{
		LEFT = 1,
		CENTER = 2,
		RIGHT = 4
	}

	public enum CoverDirections
	{
		INVALID = -1,
		NONE = 0,
		LEFT = 1,
		CENTER = 2,
		RIGHT = 4,
		LEFT_CENTER = 3,
		LEFT_RIGHT = 5,
		RIGHT_CENTER = 6,
		ALL = 7
	}

	public enum CoverDepth
	{
		INVALID = -1,
		NARROW = 0,
		LARGE = 1
	}

	public CoverHeight m_coverHeight;

	public CoverDepth m_coverDepth;

	public CoverDirections m_coverDirections;

	public float m_coverRadius;

	public bool m_isLocked;

	[HideInInspector]
	public CoverContainer m_container;

	public CoverSlot()
	{
		m_coverHeight = CoverHeight.LOW;
		m_coverDepth = CoverDepth.LARGE;
		m_coverDirections = CoverDirections.CENTER;
		m_coverRadius = ce50216d739ad0a5a4af8f3d411eb1254(CoverDirectionMask.CENTER);
		m_isLocked = false;
	}

	public override SlotContainer c21fba8ad45fb411f3f304287d294575f()
	{
		return m_container;
	}

	public override void c1d303e3aadbc00416e803827a0896f3f(SlotContainer cfeb8370582646b8696da2d4f86e1197f)
	{
		m_container = (CoverContainer)cfeb8370582646b8696da2d4f86e1197f;
	}

	public float ce50216d739ad0a5a4af8f3d411eb1254(CoverDirectionMask cd74e1657fe33d2ee7ef19f6bb00c943e)
	{
		switch (cd74e1657fe33d2ee7ef19f6bb00c943e)
		{
		case CoverDirectionMask.CENTER:
			return 0.6f;
		case CoverDirectionMask.LEFT:
		case CoverDirectionMask.RIGHT:
			return 0.7f;
		default:
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.AI, "Invalid Cover Direction");
			return 0f;
		}
	}

	public float c7e4c2406c38cbd8b8e24cdf6e6d878f5()
	{
		CoverHeight coverHeight = m_coverHeight;
		if (coverHeight != 0)
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
					if (coverHeight != CoverHeight.HIGH)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.AI, "Invalid Cover Height");
								return 0f;
							}
						}
					}
					return 2f;
				}
			}
		}
		return 1f;
	}

	public float cfe13f1d9df57cd72b389af7e2986faaa()
	{
		switch (m_coverDepth)
		{
		case CoverDepth.LARGE:
			return 1.15f;
		case CoverDepth.NARROW:
			return 0.5f;
		case CoverDepth.INVALID:
			return -1f;
		default:
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.AI, "Invalid Cover Depth");
			return 0f;
		}
	}

	public void c876f0d3ae67e35cd0c91d43e97127ed0()
	{
		m_isLocked = true;
	}

	public void c7ff3e47f83c0be6db6d1bb11ec5fef30()
	{
		m_isLocked = false;
	}

	public bool c77db28d6b2fc986641939021da1290e3(CoverDirectionMask cd74e1657fe33d2ee7ef19f6bb00c943e)
	{
		return ((uint)m_coverDirections & (uint)cd74e1657fe33d2ee7ef19f6bb00c943e) != 0;
	}

	public bool c2f067072b56b676043bde5d94f821fac(Vector3 cef9712200bbe2c3873eec3ca2e18a595)
	{
		throw new NotImplementedException();
	}

	public override object Clone()
	{
		return (CoverSlot)MemberwiseClone();
	}
}
