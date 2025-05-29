using System.Collections.Generic;

public class AnimationPlayerThrowTurretState : PlayerAnimationState
{
	public enum EPosture
	{
		FullBodyLong = 0,
		UpperBodyLong = 1,
		FullBodyNear = 2,
		UpperBodyNear = 3
	}

	public float m_netLatency;

	private EPosture m_posture = EPosture.UpperBodyNear;

	private Dictionary<EPosture, AnimData> m_animDataDict = new Dictionary<EPosture, AnimData>();

	public AnimationPlayerThrowTurretState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "PlayerThrowTurret";
		m_animDataDict.Add(EPosture.FullBodyLong, new AnimData(0, "ThrowTurretLongFull", MecanimAnimationID.ID_1st_ThrowTurretLong, "bThrowTurretLongFull"));
		m_animDataDict.Add(EPosture.FullBodyNear, new AnimData(0, "ThrowTurretNearFull", MecanimAnimationID.ID_1st_ThrowTurretNear, "bThrowTurretNearFull"));
		m_animDataDict.Add(EPosture.UpperBodyLong, new AnimData(1, "ThrowTurretLongUpper", MecanimAnimationID.ID_1st_ThrowTurretLong, "bThrowTurretLongUpper"));
		m_animDataDict.Add(EPosture.UpperBodyNear, new AnimData(1, "ThrowTurretNearUpper", MecanimAnimationID.ID_1st_ThrowTurretNear, "bThrowTurretNearUpper"));
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
				switch (1)
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
			switch (7)
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

	public void c62547c0ac815478499192b622a3a73d3(bool cc258cad0104ac7aa342c8052ddf85543, bool cd01973a2263536e20de99e2221becc1b)
	{
		if (cc258cad0104ac7aa342c8052ddf85543)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (cd01973a2263536e20de99e2221becc1b)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						m_posture = EPosture.FullBodyLong;
						return;
					}
				}
			}
		}
		if (cc258cad0104ac7aa342c8052ddf85543)
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
			if (!cd01973a2263536e20de99e2221becc1b)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						m_posture = EPosture.FullBodyNear;
						return;
					}
				}
			}
		}
		if (!cc258cad0104ac7aa342c8052ddf85543)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			if (cd01973a2263536e20de99e2221becc1b)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						m_posture = EPosture.UpperBodyLong;
						return;
					}
				}
			}
		}
		if (cc258cad0104ac7aa342c8052ddf85543)
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
			if (cd01973a2263536e20de99e2221becc1b)
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
				m_posture = EPosture.UpperBodyNear;
				return;
			}
		}
	}

	private void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.m_status = AnimationStatus.SUCCESS;
		c06739986a9474e249bf49d8330a68ce0(m_animDataDict[m_posture].m_param_3rd, false);
	}
}
