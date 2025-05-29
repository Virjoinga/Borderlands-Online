using UnityEngine;

namespace BHV
{
	public class BHVTaskRecharge : BHVTask
	{
		private BHVTaskParamRecharge c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationIdleState c8b898abf5a78061e4d350c23bd4f1e33;

		public BHVTaskRecharge()
		{
			base.m_Type = BHVTaskType.Recharge;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamRecharge;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.Idle);
			c8b898abf5a78061e4d350c23bd4f1e33 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("Idle") as AnimationIdleState;
			if (c8b898abf5a78061e4d350c23bd4f1e33 != null)
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
				c8b898abf5a78061e4d350c23bd4f1e33.m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bIdle", true);
				c8b898abf5a78061e4d350c23bd4f1e33.m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bTurnOnSpot", false);
				c8b898abf5a78061e4d350c23bd4f1e33.m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fMoveSpeed", 0f);
				c8b898abf5a78061e4d350c23bd4f1e33.m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackTakeOff", false);
				c8b898abf5a78061e4d350c23bd4f1e33.m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackLoop", false);
				c8b898abf5a78061e4d350c23bd4f1e33.m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackLand", false);
				c8b898abf5a78061e4d350c23bd4f1e33.m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMortarAttack", false);
				c8b898abf5a78061e4d350c23bd4f1e33.m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bRailgunAttack", false);
				c8b898abf5a78061e4d350c23bd4f1e33.m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bLaserSweep", false);
				c8b898abf5a78061e4d350c23bd4f1e33.m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bChargeEnd", false);
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_validateNextMovePosition = false;
			Renderer[] componentsInChildren = cfc241af7ab51814fc074e767be1a0bb8.m_entity.gameObject.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = true;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				Collider[] componentsInChildren2 = cfc241af7ab51814fc074e767be1a0bb8.m_entity.gameObject.GetComponentsInChildren<Collider>();
				for (int j = 0; j < componentsInChildren2.Length; j++)
				{
					componentsInChildren2[j].enabled = true;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cd5e20c96aa545559531f1792ec0f8b61(cfc241af7ab51814fc074e767be1a0bb8.m_entity);
					return;
				}
			}
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cf3d2cb82d21abb0d2de84f85c25fdb49(cfc241af7ab51814fc074e767be1a0bb8.m_entity);
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_validateNextMovePosition = true;
		}
	}
}
