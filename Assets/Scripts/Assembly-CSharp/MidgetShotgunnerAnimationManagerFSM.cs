using A;

public class MidgetShotgunnerAnimationManagerFSM : NPCAnimationManagerFSM
{
	private const int UPPERBODY_LAYER = 1;

	public float m_lastShotSoundTime;

	public override void Start()
	{
		base.Start();
		m_movementSync = GetComponent<MovementSync>();
		m_isHumanoid = true;
		m_canUseFacingLogic = true;
		if (m_animEventHandlerList == null)
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
			m_animEventHandlerList.Add("StartShoot", OnStartShoot);
			m_animEventHandlerList.Add("MeleeHit", base.OnMeleeHit);
			return;
		}
	}

	public override void Update()
	{
		base.Update();
	}

	public override int c43e01190c713db1f8a78d1529ae2d2ed(string cb6ecce17c4a10cf4ade445feb45a0355)
	{
		if (cb6ecce17c4a10cf4ade445feb45a0355.ToLower() == "hurtlight")
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
					return 4;
				}
			}
		}
		return 0;
	}

	public void OnStartShoot()
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		EntityWeapon weapon = m_entity.cdcf5e0592c05a681a8470f66674efd0b().m_weapon;
		if (!(weapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			weapon.c6f2004a1cbc439c9b630d1dd5c028bf3();
			return;
		}
	}
}
