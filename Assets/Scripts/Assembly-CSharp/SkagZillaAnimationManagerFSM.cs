public class SkagZillaAnimationManagerFSM : NPCAnimationManagerFSM
{
	public override void Start()
	{
		base.Start();
		m_isHumanoid = false;
		m_canUseFacingLogic = false;
		m_animEventHandlerList.Add("MeleeHit", base.OnMeleeHit);
		m_animEventHandlerList.Add("JumpOnSpotHit", c68fbf506a8a2bd9315c3bbd470861939);
		m_deathLayer = 1;
	}

	public void c68fbf506a8a2bd9315c3bbd470861939()
	{
		AnimationJumpOnSpotState animationJumpOnSpotState = c059bb29245b8e57e3b793798ddfdb249(AnimationStateFSM.JumpOnSpot.ToString()) as AnimationJumpOnSpotState;
		if (animationJumpOnSpotState == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			animationJumpOnSpotState.m_jumpOnSpotHit = true;
			return;
		}
	}
}
