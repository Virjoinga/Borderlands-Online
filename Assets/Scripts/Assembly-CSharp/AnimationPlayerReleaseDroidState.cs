using System.Collections.Generic;

public class AnimationPlayerReleaseDroidState : PlayerAnimationState
{
	public enum EPosture
	{
		FullBody = 0,
		UpperBody = 1
	}

	public float m_netLatency;

	private EPosture m_posture;

	private Dictionary<EPosture, AnimData> m_animDataDict = new Dictionary<EPosture, AnimData>();

	public AnimationPlayerReleaseDroidState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "PlayerReleaseDroid";
		m_animDataDict.Add(EPosture.FullBody, new AnimData(0, "ReleaseDroidFull", MecanimAnimationID.ID_1st_ReleaseDroid, "bReleaseDroidFull"));
		m_animDataDict.Add(EPosture.UpperBody, new AnimData(1, "ReleaseDroidUpper", MecanimAnimationID.ID_1st_ReleaseDroid, "bReleaseDroidUpper"));
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		base.m_status = AnimationStatus.RUNNING;
		m_animInfoMgr.Reset(m_netLatency);
		if (base.c90e194560a86112d38f669898a54a249)
		{
			while (true)
			{
				switch (6)
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
			ce7563fcf3b106cefb47b52f00fced07b(m_animDataDict[m_posture].m_param_1st);
		}
		c06739986a9474e249bf49d8330a68ce0(m_animDataDict[m_posture].m_param_3rd, true);
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		AnimData animData = m_animDataDict[m_posture];
		float num = m_animInfoMgr.c8d61bc457bf1e08126a3d9d2111b25df(animData.m_tag, animData.m_layer);
		if (!(num >= 0.97f))
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			cac7688b05e921e2be3f92479ba44b4a8();
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		cac7688b05e921e2be3f92479ba44b4a8();
	}

	public void c62547c0ac815478499192b622a3a73d3(bool c4c78ccfe49691dfe33d0fd71b3b7f497)
	{
		int posture;
		if (c4c78ccfe49691dfe33d0fd71b3b7f497)
		{
			while (true)
			{
				switch (7)
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
			posture = 0;
		}
		else
		{
			posture = 1;
		}
		m_posture = (EPosture)posture;
	}

	private void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.m_status = AnimationStatus.SUCCESS;
		c06739986a9474e249bf49d8330a68ce0(m_animDataDict[m_posture].m_param_3rd, false);
	}
}
