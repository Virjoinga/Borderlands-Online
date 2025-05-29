using System;
using A;
using UnityEngine;
using XsdSettings;

public class TownPlayerAnimationEventController : AnimationEventController
{
	private float m_initPendingTime;

	private void Start()
	{
		m_initPendingTime = 5f;
	}

	private void Update()
	{
		if (m_initPendingTime > 0f)
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
			if (m_initPendingTime <= Time.deltaTime)
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
				cdf677c74983c232ad49b305c93ec1dde();
			}
		}
		if (m_initPendingTime >= 0f)
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
			m_initPendingTime -= Time.deltaTime;
		}
		if (m_animator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_animator = GetComponent<Animator>();
		}
		if (!(m_localPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_localPlayer = GetComponentInParent<EntityPlayer>();
			return;
		}
	}

	private void cdf677c74983c232ad49b305c93ec1dde()
	{
		if (m_localPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_animator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			EntityWeapon entityWeapon = m_localPlayer.c3941dac8608f650ceb15dc36294a741c();
			if (!(entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_currentWeaponType = entityWeapon.c83e548e5608cd7f222098a6966b16545();
				m_animator.SetInteger("iWeaponType", (int)m_currentWeaponType);
				return;
			}
		}
	}

	private void OnAnimatorIK(int layerIndex)
	{
		if (m_animator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		if (!m_animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (!m_animator.GetCurrentAnimatorStateInfo(1).IsTag("Empty"))
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (!m_enableLeftHandIK)
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
			int integer = m_animator.GetInteger("iWeaponType");
			if (Enum.IsDefined(Type.GetTypeFromHandle(cb69030d5cbca58447fc871be9aade1a0.cc1720d05c75832f704b87474932341c3()), integer))
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
				m_currentWeaponType = (WeaponType)integer;
			}
			if (m_currentWeaponType == WeaponType.RepeaterPistol)
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
				cdda1e287dce0fbab9a07cdb40c1a7ab3(m_currentWeaponType, 1f);
				return;
			}
		}
	}
}
