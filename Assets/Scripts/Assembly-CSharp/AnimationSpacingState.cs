using UnityEngine;

public class AnimationSpacingState : AnimationManagerState
{
	public GameObject m_targetObj;

	private bool m_bInjured;

	public bool m_normalizeTurnAngle;

	public AnimationSpacingState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "Spacing";
		m_bInjured = false;
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsSpacing", true);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bInjured", m_bInjured);
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		m_turnAngle = m_AnimationManagerFSM.m_movementSync.m_turnAngle;
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("TurnAngle", m_turnAngle);
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsSpacing", false);
	}

	public void c1a9bdac7a68b7fb9ef0734a88f1eb679(bool cd8ef4c953fc15a2d8ff1ac13b5071860)
	{
		m_bInjured = cd8ef4c953fc15a2d8ff1ac13b5071860;
	}

	public void ca2393207b55c9357d4bab9a42c7d50fc(bool cebfdeafcb068c6e8cef7ce3a797f3b9a)
	{
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsSpacing", cebfdeafcb068c6e8cef7ce3a797f3b9a);
	}
}
