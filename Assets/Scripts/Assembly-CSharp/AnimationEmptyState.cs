public class AnimationEmptyState : AnimationManagerState
{
	public AnimationEmptyState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "Empty";
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		ce902c639c179f2e78fd1621e43ab4593 = 0f;
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		base.m_status = AnimationStatus.RUNNING;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		base.m_status = AnimationStatus.SUCCESS;
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		base.m_status = AnimationStatus.SUCCESS;
	}
}
