using A;
using UnityEngine;

public class RakkAnimationManagerFSM : NPCAnimationManagerFSM
{
	public override void Start()
	{
		base.Start();
		m_isHumanoid = false;
		m_canUseFacingLogic = false;
		m_deathLayer = 2;
	}

	public override int c43e01190c713db1f8a78d1529ae2d2ed(string cb6ecce17c4a10cf4ade445feb45a0355)
	{
		if (cb6ecce17c4a10cf4ade445feb45a0355.ToLower() == "hurtlight")
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return 1;
				}
			}
		}
		return 0;
	}

	public override void LateUpdate()
	{
		if (m_animationHost == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		if (m_animationStateMachine.m_curState == null)
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
			((AnimationManagerState)m_animationStateMachine.m_curState).FixedUpdate();
			Vector3 vector = m_animationHost.transform.localPosition * m_modelScale;
			Vector3 c3e32dcf701d8dae92a9d3c989f9eb = base.transform.position + base.transform.rotation * vector;
			if (m_validateNextMovePosition)
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
				if (m_entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (m_entity.cb7fad43afb51f83d8698379136b46e95() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						AIServicePathfinding.c5ee19dc8d4cccf5ae2de225410458b86.cdc4e149cd54739f999b6786b45f53db7(m_entity.cb7fad43afb51f83d8698379136b46e95(), c3e32dcf701d8dae92a9d3c989f9eb, out c3e32dcf701d8dae92a9d3c989f9eb);
					}
				}
			}
			base.transform.position = c3e32dcf701d8dae92a9d3c989f9eb;
			m_animationHost.transform.localPosition = Vector3.zero;
			base.transform.forward = m_animationHost.transform.forward;
			m_animationHost.transform.localRotation = Quaternion.identity;
			return;
		}
	}
}
