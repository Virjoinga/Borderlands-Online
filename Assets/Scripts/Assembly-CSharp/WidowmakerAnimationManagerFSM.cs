using UnityEngine;

public class WidowmakerAnimationManagerFSM : SpiderantAnimationManagerFSM
{
	public Transform m_tailTransform;

	public override void Start()
	{
		base.Start();
		m_deathLayer = 1;
		Transform[] componentsInChildren = base.gameObject.transform.GetComponentsInChildren<Transform>();
		int num = componentsInChildren.Length;
		int num2 = 0;
		while (true)
		{
			if (num2 < num)
			{
				Transform transform = componentsInChildren[num2];
				if (transform.gameObject.name == "Bip01 Tail4")
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					m_tailTransform = transform;
					break;
				}
				num2++;
				continue;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			break;
		}
		m_animEventHandlerList.Add("RadiusAttackHit", OnRadiusAttackHit);
		m_animEventHandlerList.Add("ThrowWebTrap", OnThrowWebTrap);
	}

	public void OnRadiusAttackHit()
	{
		AnimationRadiusAttackState animationRadiusAttackState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.RadiusAttack)) as AnimationRadiusAttackState;
		if (animationRadiusAttackState == null)
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
			animationRadiusAttackState.m_radiusAttackHit = true;
			return;
		}
	}

	public void OnThrowWebTrap()
	{
		AnimationWebTrapState animationWebTrapState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.WebTrap)) as AnimationWebTrapState;
		if (animationWebTrapState == null)
		{
			return;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			animationWebTrapState.m_bThrowWebTrap = true;
			return;
		}
	}
}
