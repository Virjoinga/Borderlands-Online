public class TheInsaneTentacleAnimationManagerFSM : NPCAnimationManagerFSM
{
	public override void Start()
	{
		base.Start();
		m_deathLayer = 1;
		m_isHumanoid = false;
		m_animEventHandlerList.Add("MeleeHit", base.OnMeleeHit);
	}
}
