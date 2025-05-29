using System.Collections.Generic;
using A;
using Core;
using XsdSettings;

public class HUDPvPInfoView : BaseView
{
	public class KillInfo
	{
		public string strKiller;

		public string strVictim;

		public AttackSubType attackSubType;

		public List<ScoringActionType> scoringActionList;
	}

	public class ScoreInfo
	{
		public int iScore;

		public float fTimeLeft;

		public ScoringActionType ScoringType;
	}

	private const float m_killInfoDurationInSec = 7f;

	private const float m_scoreInfoDurationInSec = 4f;

	protected Queue<KillInfo> m_killingInfoQueue = new Queue<KillInfo>();

	protected Queue<ScoreInfo> m_scoreInfoQueue = new Queue<ScoreInfo>();

	protected static Dictionary<int, int> m_PlayerTeamMap = new Dictionary<int, int>();

	public bool m_bKillInfoNeedUpdate;

	protected bool m_killInfoVisible;

	private float m_killInfoShowTime;

	public static int m_sMaxKillInfoCount = 7;

	public static int m_sMaxScoreInfoCount = 3;

	public override bool c57b6c6861c1d709f4f7aa7b8a699b5c9()
	{
		return true;
	}

	public override void OnTestGUI()
	{
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "----------------SetVisible");
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		m_killingInfoQueue = new Queue<KillInfo>();
		m_scoreInfoQueue = new Queue<ScoreInfo>();
	}

	public virtual void Update(float fDeltaTime)
	{
		c7ba3429fee00eecd5933751342411be8(fDeltaTime);
		c04ef5b99f419a4d197b8aee089d17013(fDeltaTime);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
	}

	protected void cae4d5f3ea26ef08f162561464693dd61(bool c01b7f034089695ae79144510f65ec2e5 = true)
	{
		if (c01b7f034089695ae79144510f65ec2e5)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c239889f6079aa61647e3c4b8f3627d00(c7bb86b60f299c950179b9bd1c30a2a68);
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c0bd653723f77fd78e6c7d4d25ed14dcd(c7bb86b60f299c950179b9bd1c30a2a68);
	}

	protected virtual void c7bb86b60f299c950179b9bd1c30a2a68()
	{
	}

	public virtual void c4effbb7e0f68e0d6297d5bb56a935bfb()
	{
		m_PlayerTeamMap.Clear();
		List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
		for (int i = 0; i < c9c8de68aa0982db2bbd496692c37e.Count; i++)
		{
			m_PlayerTeamMap.Add(c9c8de68aa0982db2bbd496692c37e[i].m_characterId, c9c8de68aa0982db2bbd496692c37e[i].m_teamID);
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return;
		}
	}

	protected virtual void c7ba3429fee00eecd5933751342411be8(float c4bb7d253cf6d616d835d0c2bfca8a211)
	{
		m_killInfoVisible = false;
		if (m_killingInfoQueue.Count == 0)
		{
			return;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_killInfoShowTime <= 0f)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			m_killInfoShowTime -= c4bb7d253cf6d616d835d0c2bfca8a211;
			m_killInfoVisible = true;
			return;
		}
	}

	protected void c2a041f325b4a47cb1fdb49089b371132(bool cb4040e85ef24e4c9dea5dfc714598840)
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c06326d0c295575336bc4e5c2f994ab8e(cb4040e85ef24e4c9dea5dfc714598840);
	}

	protected virtual void c04ef5b99f419a4d197b8aee089d17013(float c4bb7d253cf6d616d835d0c2bfca8a211)
	{
	}

	public void c763c3f7eaf4d35f4e79c81e24b3a2dc1(string ca15db9170f4b2624eb418325113f24a1, string ce73e16481d34186c3b219b995e41c810, AttackSubType c9bc42c3c9a45508364b2a2caf8aea33c, List<ScoringActionType> cb0d5d15056e0d7a6e60a76492d8203a3, bool c54664cdf82f6a65391a63533937b556a)
	{
		KillInfo killInfo = new KillInfo();
		killInfo.strKiller = ca15db9170f4b2624eb418325113f24a1;
		killInfo.strVictim = ce73e16481d34186c3b219b995e41c810;
		killInfo.attackSubType = c9bc42c3c9a45508364b2a2caf8aea33c;
		m_killInfoShowTime = 7f;
		killInfo.scoringActionList = new List<ScoringActionType>(cb0d5d15056e0d7a6e60a76492d8203a3);
		m_killingInfoQueue.Enqueue(killInfo);
		if (m_killingInfoQueue.Count >= m_sMaxKillInfoCount)
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
			m_killingInfoQueue.Dequeue();
		}
		m_bKillInfoNeedUpdate = true;
		if (!c54664cdf82f6a65391a63533937b556a)
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
			for (int i = 0; i < cb0d5d15056e0d7a6e60a76492d8203a3.Count; i++)
			{
				ScoreInfo scoreInfo = new ScoreInfo();
				scoreInfo.iScore = c06ca0e618478c23eba3419653a19760f<ScoringManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1cf78bc79484f63267d4766d6776b199(cb0d5d15056e0d7a6e60a76492d8203a3[i]);
				scoreInfo.fTimeLeft = 4f;
				scoreInfo.ScoringType = cb0d5d15056e0d7a6e60a76492d8203a3[i];
				m_scoreInfoQueue.Enqueue(scoreInfo);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}
}
