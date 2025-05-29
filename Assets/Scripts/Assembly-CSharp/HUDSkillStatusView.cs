using System.Collections.Generic;
using A;

public class HUDSkillStatusView : BaseView
{
	public enum eCurState
	{
		None = 0,
		Normal = 1,
		Prelude = 2,
		FirstAction = 3,
		SecondAction = 4,
		Collsion = 5,
		Explosion = 6,
		Cooldown = 7
	}

	protected bool _bInitialised;

	protected bool _bFirstActionUnlocked;

	protected bool _bSecActionUnlocked;

	protected SkillInfo _curSkillInfo;

	protected eCurState _curState;

	protected MarkManager.BroadcastMarkedInfo _hunterMarkInfo;

	protected SkillID _curCharacterSkillID;

	protected int _iUnSpentSkillPt;

	protected int _iEarnedSkillPt;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		_curState = eCurState.None;
		SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c39e911336cb557f0eec128814bdf7728(c91b0bad551b5877ac848dcbffd1fcd76);
		SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().ce299e6d366e2dbedce1e85e4f5aaedf8(c06849da5ccfc56f96a6b2185a29653d6);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c858f0c33158b659215d28b3c0548a38a(this);
		c06849da5ccfc56f96a6b2185a29653d6(c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cbdc3d31ee9ec65e6f0badf60655c8747());
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		_bInitialised = false;
		SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c47e881bbdb23d9f2d20b66a55626b570(c91b0bad551b5877ac848dcbffd1fcd76);
		SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c813c04cff18bcb0a23378cfc5a4c4e9a(c06849da5ccfc56f96a6b2185a29653d6);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ceb073876b67631e82266e224318dc9de(this);
	}

	protected virtual void c91b0bad551b5877ac848dcbffd1fcd76(int c37c8cc761dd6f739a4c896e64e44fdd5, int c43c216df6aadde10be3f9bdf566009ca)
	{
		ca99d83562046345488d42e3917afb097(c37c8cc761dd6f739a4c896e64e44fdd5, c43c216df6aadde10be3f9bdf566009ca);
	}

	public virtual void Update(SkillInfo curSkillInfo)
	{
		_curSkillInfo = curSkillInfo;
		if (curSkillInfo != null)
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
			_curCharacterSkillID = curSkillInfo.m_current_skillID;
		}
		if (_curCharacterSkillID != SkillID.Hunter)
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
			_hunterMarkInfo = MarkManager.c5ee19dc8d4cccf5ae2de225410458b86.cbc9dccee600d372155410dce2062bf8d();
			return;
		}
	}

	protected virtual void c06849da5ccfc56f96a6b2185a29653d6(List<InvestedSkill> c2a84e1af1999f8830e06d6fd6cb8ebb9)
	{
		int bFirstActionUnlocked;
		if (SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cea0fda735aa58693de81cd5dabada6f7(1) <= 0)
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
			if (SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cea0fda735aa58693de81cd5dabada6f7(51) <= 0)
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
				if (SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cea0fda735aa58693de81cd5dabada6f7(101) <= 0)
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
					bFirstActionUnlocked = ((SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cea0fda735aa58693de81cd5dabada6f7(151) > 0) ? 1 : 0);
					goto IL_0079;
				}
			}
		}
		bFirstActionUnlocked = 1;
		goto IL_0079;
		IL_0079:
		_bFirstActionUnlocked = (byte)bFirstActionUnlocked != 0;
		int bSecActionUnlocked;
		if (SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cea0fda735aa58693de81cd5dabada6f7(2) <= 0)
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
			if (SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cea0fda735aa58693de81cd5dabada6f7(52) <= 0)
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
				if (SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cea0fda735aa58693de81cd5dabada6f7(102) <= 0)
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
					bSecActionUnlocked = ((SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cea0fda735aa58693de81cd5dabada6f7(152) > 0) ? 1 : 0);
					goto IL_00ee;
				}
			}
		}
		bSecActionUnlocked = 1;
		goto IL_00ee;
		IL_00ee:
		_bSecActionUnlocked = (byte)bSecActionUnlocked != 0;
	}

	public void OnSkillEvent(SkillEvent skillEvent)
	{
		if (!_bFirstActionUnlocked)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		switch (skillEvent)
		{
		case SkillEvent.None:
			_curState = eCurState.None;
			break;
		case SkillEvent.FireBirdDive:
			_curState = eCurState.Collsion;
			ccb413e2cca8f18b5041ee18ab96e729e();
			break;
		case SkillEvent.FireBirdAnimStart:
		case SkillEvent.BerserkChargeStart:
		case SkillEvent.TurretThrowAnimStart:
		case SkillEvent.HunterReleaseAnimStart:
			_curState = eCurState.Prelude;
			c33e0d6a16ca598fe0a5efac6a4501b86();
			break;
		case SkillEvent.FireBirdSpawn:
		case SkillEvent.BerserkStomp:
		case SkillEvent.TurretSpawned:
		case SkillEvent.HunterDroidSpawned:
			_curState = eCurState.FirstAction;
			c5b87f18653eabd4e44743a6d81126088();
			break;
		case SkillEvent.FireBirdTurnStart:
		case SkillEvent.BerserkDashStart:
			_curState = eCurState.SecondAction;
			cb6db4663b8a403fb17de5e7062aad56c();
			break;
		case SkillEvent.FireBirdExplode:
		case SkillEvent.FireBirdAbsorb:
		case SkillEvent.BerserkPunchEnd:
		case SkillEvent.BerserkCoolDownStart:
		case SkillEvent.TurretCooldownStart:
		case SkillEvent.HunterCooldownStart:
			_curState = eCurState.Cooldown;
			c17a51851547cf76fd3f481284c811a01();
			break;
		case SkillEvent.FireBirdCoolDownEnd:
		case SkillEvent.BerserkCoolDownEnd:
		case SkillEvent.TurretCooldownEnd:
		case SkillEvent.HunterCooldownEnd:
			_curState = eCurState.Normal;
			cb7f9721277f1652ea629c68bc6538c74();
			break;
		case SkillEvent.CureHeartVFXOn:
		case SkillEvent.CureHeartVFXOff:
		case SkillEvent.SkillExit:
		case SkillEvent.ToSpawnFireBird:
		case SkillEvent.FirebirdDestroyed:
		case SkillEvent.FirebirdReachEnd:
		case SkillEvent.FirebirdCollideEnviorment:
		case SkillEvent.BerserkDashEnd:
		case SkillEvent.BerserkPunchStart:
		case SkillEvent.BerserkDashStateExit:
		case SkillEvent.BerserkExplodeOnHit:
		case SkillEvent.TurretRetrieve:
		case SkillEvent.TurretRepulseExplode:
		case SkillEvent.HunterDroidEnd:
		case SkillEvent.HunterCooldownJump:
			break;
		}
	}

	protected virtual void cb524d3624c5f1725ff22bdc4cc78c3ce()
	{
	}

	protected virtual void c33e0d6a16ca598fe0a5efac6a4501b86()
	{
	}

	protected virtual void c5b87f18653eabd4e44743a6d81126088()
	{
		if (_curCharacterSkillID != SkillID.Berserk)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c20e43347435e746a8d6d3d2c3d99c2f6().cad4b9805ada962a49e6eb4b43bce403b(true);
			return;
		}
	}

	protected virtual void cb6db4663b8a403fb17de5e7062aad56c()
	{
		if (_curCharacterSkillID != SkillID.Berserk)
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
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c20e43347435e746a8d6d3d2c3d99c2f6().c881ca682404299c847daa474407e6ac0(true);
			return;
		}
	}

	protected virtual void c17a51851547cf76fd3f481284c811a01()
	{
		if (_curCharacterSkillID != SkillID.Berserk)
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
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c20e43347435e746a8d6d3d2c3d99c2f6().cad4b9805ada962a49e6eb4b43bce403b(false);
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c20e43347435e746a8d6d3d2c3d99c2f6().c881ca682404299c847daa474407e6ac0(false);
			return;
		}
	}

	protected virtual void ccb413e2cca8f18b5041ee18ab96e729e()
	{
	}

	protected virtual void c90029e26232721bff12dcbcc05c24b8e()
	{
	}

	protected virtual void cb7f9721277f1652ea629c68bc6538c74()
	{
	}

	public virtual void ca99d83562046345488d42e3917afb097(int c8939189c1c9b16ae9037abd7790c7dba, int c87d6075ee471733370e7bb9406d2a685)
	{
		_iUnSpentSkillPt = c87d6075ee471733370e7bb9406d2a685;
		_iEarnedSkillPt = c8939189c1c9b16ae9037abd7790c7dba;
	}
}
