using System;
using A;
using UnityEngine;

[Serializable]
public class Slot : ICloneable
{
	public Vector3 m_localePosition;

	public Vector3 m_localeFacingDirection;

	public virtual SlotContainer c21fba8ad45fb411f3f304287d294575f()
	{
		throw new NotImplementedException();
	}

	public virtual void c1d303e3aadbc00416e803827a0896f3f(SlotContainer cfeb8370582646b8696da2d4f86e1197f)
	{
		throw new NotImplementedException();
	}

	public Vector3 c4cf00ced2bc60ae908904eb73692869f()
	{
		if (c21fba8ad45fb411f3f304287d294575f() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return Vector3.zero;
				}
			}
		}
		return c21fba8ad45fb411f3f304287d294575f().gameObject.transform.TransformPoint(m_localePosition);
	}

	public Quaternion c3dcd4e7042ca1a56c152f61b0297b08f()
	{
		return Quaternion.LookRotation(ccce60d55e7ff50d56da96452a5071658());
	}

	public Vector3 ccce60d55e7ff50d56da96452a5071658()
	{
		if (c21fba8ad45fb411f3f304287d294575f() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return Vector3.forward;
				}
			}
		}
		return c21fba8ad45fb411f3f304287d294575f().gameObject.transform.TransformDirection(m_localeFacingDirection);
	}

	public virtual object Clone()
	{
		throw new NotImplementedException();
	}
}
