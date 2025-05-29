using A;
using UnityEngine;

public class CrabwormAnimationManagerFSM : NPCAnimationManagerFSM
{
	public ParticleSystem m_dustPS;

	public override void Start()
	{
		base.Start();
		m_movementSync = GetComponent<MovementSync>();
		m_deathLayer = 1;
		m_animEventHandlerList.Add("MeleeHit", base.OnMeleeHit);
		SkinnedMeshRenderer componentInChildren = GetComponentInChildren<SkinnedMeshRenderer>();
		if (!(componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			componentInChildren.updateWhenOffscreen = true;
			return;
		}
	}

	public void ca29607801dff711ca70056b8b5a9c58f(bool c38daa1ecfc4be57f0bab6f15b4488ecc)
	{
		if (m_dustPS == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (c38daa1ecfc4be57f0bab6f15b4488ecc)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					m_dustPS.Play();
					return;
				}
			}
		}
		m_dustPS.Stop();
	}

	public override void cce25835105f4aac362f76d814881a1e8()
	{
		base.cce25835105f4aac362f76d814881a1e8();
		ca29607801dff711ca70056b8b5a9c58f(false);
	}
}
