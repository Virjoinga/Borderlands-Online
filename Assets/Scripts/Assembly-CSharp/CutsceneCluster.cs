using A;
using Core;

public class CutsceneCluster : Scene
{
	public CutScene m_cutscene;

	public float m_duration;

	private Utils.Timer m_cutsceneTimer = new Utils.Timer();

	protected override void Awake()
	{
		base.Awake();
	}

	protected override void c881f5c9f672eba2e02441e1387a821ba()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "CutScene.Begin");
		IHostSession hostSession = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8762b0b9a035bab0b07fd588a158cd62();
		if (hostSession != null)
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
			hostSession.c228cd5253b68fa5d8c2b33af0db7ebb4(base.name);
		}
		m_cutsceneTimer.Start(m_duration);
	}

	protected override bool c6b55d8e5c9702fae8ea5ac979f1a8713()
	{
		return m_cutsceneTimer.cf928603d375f06225f9eb5213fb17bd4();
	}

	protected override void ca9b3a2d1fbbeafb416b7e606f618cdf5()
	{
		IHostSession hostSession = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8762b0b9a035bab0b07fd588a158cd62();
		if (hostSession != null)
		{
			while (true)
			{
				switch (2)
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
			hostSession.c49fd3d63b08aab39adae6cda3ec40c66(base.name);
		}
		base.ca9b3a2d1fbbeafb416b7e606f618cdf5();
	}
}
