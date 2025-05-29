using A;

namespace BHV
{
	public class BHVTaskAdvanceSpawn : BHVTaskAnimationState
	{
		private BHVTaskParamAdvanceSpawn c2227ddc7fcbe3fa329465d2fa8ffb479;

		public BHVTaskAdvanceSpawn()
		{
			base.m_Type = BHVTaskType.AdvanceSpawn;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamAdvanceSpawn;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.c5ba0fce5895e015467c6c68bb950b1e4 != BHVTaskParamAdvanceSpawn.EAdvanceSpawnType.cd4c6462452152f433a2598d8fae14ea1)
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
				AnimationCombatSpawnState animationCombatSpawnState = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.CombatSpawn)) as AnimationCombatSpawnState;
				if (animationCombatSpawnState == null)
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
					animationCombatSpawnState.m_walkAfterSpawnTime = cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVNavAgentSettings>().m_combatSpawnDuration;
					animationCombatSpawnState.m_moveSpeed = cfc241af7ab51814fc074e767be1a0bb8.cde528db37f7946caf38a2c719cf0471e(BHVMovementSpeed.RUN, BHVStressLevel.COMBAT);
					animationCombatSpawnState.ce734d5ea91008df465ad3fe84ce57372 = cfc241af7ab51814fc074e767be1a0bb8.transform.forward;
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c5a566dbd0e781356afaeb0774ab2f0b1 = 0f;
					return;
				}
			}
		}

		public override void Update(float deltaTime)
		{
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.c5ba0fce5895e015467c6c68bb950b1e4 == BHVTaskParamAdvanceSpawn.EAdvanceSpawnType.c281dcfcc0cb4d7f1df2e3947bd9882ce)
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
				base.Update(deltaTime, AnimationStateFSM.AdvanceSpawn);
			}
			else
			{
				base.Update(deltaTime, AnimationStateFSM.CombatSpawn);
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.c3bf54d312726877e5f77b6d475aef510();
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			if (!(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				NPCAnimationManagerFSM nPCAnimationManagerFSM = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as NPCAnimationManagerFSM;
				if (!(nPCAnimationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					nPCAnimationManagerFSM.c913fe3a12dbcfe01fe7b91de8c590cb0();
					return;
				}
			}
		}
	}
}
