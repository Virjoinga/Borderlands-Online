public class PlayerFirstPersonAnimationManagerFSM : AnimationManagerFSM
{
	public override void Start()
	{
		base.Start();
		m_movementSync = GetComponent<MovementSync>();
		m_canUseFacingLogic = true;
	}
}
