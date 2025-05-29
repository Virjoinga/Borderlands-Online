public class SpiderantAnimationManagerFSM : NPCAnimationManagerFSM
{
	public override void Start()
	{
		base.Start();
		m_movementSync = GetComponent<MovementSync>();
		m_animEventHandlerList.Add("MeleeHit", base.OnMeleeHit);
	}
}
