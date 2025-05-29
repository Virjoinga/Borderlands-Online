using BHV;
using UnityEngine;

public class AnimationTurnOnSpotState : AnimationManagerState
{
	public Vector3 m_finalFacing;

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_finalFacing.y = 0f;
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("TurnAngle", c86453676811402dd84f02125775b68e0());
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bTurnOnSpot", true);
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		float num = BHVTaskUtils.cb9d402b3a18cd6eb6f306d1024377f7f(m_finalFacing, m_AnimationManagerFSM.transform.forward);
		if (!(num >= 345f))
		{
			while (true)
			{
				switch (5)
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
			if (!(num <= 15f))
			{
				if (!(m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetFloat("TurnAngle") >= 345f))
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
					if (!(m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetFloat("TurnAngle") <= 15f))
					{
						return;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("TurnAngle", c86453676811402dd84f02125775b68e0());
				return;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		base.m_status = AnimationStatus.SUCCESS;
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bTurnOnSpot", false);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("TurnAngle", 0f);
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bTurnOnSpot", false);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("TurnAngle", 0f);
	}

	private float c86453676811402dd84f02125775b68e0()
	{
		float num = 360f - BHVTaskUtils.cb9d402b3a18cd6eb6f306d1024377f7f(m_finalFacing, m_AnimationManagerFSM.transform.forward);
		if (!(num >= 345f))
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
			if (!(num <= 15f))
			{
				if (num > 15f)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					if (num <= 60f)
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
						num = 45f;
						goto IL_016f;
					}
				}
				if (num > 60f)
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
					if (num <= 100f)
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
						num = 90f;
						goto IL_016f;
					}
				}
				if (num > 100f)
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
					if (num <= 180f)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								continue;
							}
							break;
						}
						num = 179f;
						goto IL_016f;
					}
				}
				if (num > 180f)
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
					if (num <= 260f)
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
						num = 181f;
						goto IL_016f;
					}
				}
				if (num > 260f)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					if (num <= 300f)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								continue;
							}
							break;
						}
						num = 270f;
						goto IL_016f;
					}
				}
				if (num > 300f)
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
					if (num <= 345f)
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
						num = 315f;
					}
				}
				goto IL_016f;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		num = 0f;
		goto IL_016f;
		IL_016f:
		return num;
	}
}
