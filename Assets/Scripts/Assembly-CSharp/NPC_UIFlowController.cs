using System;
using System.Collections.Generic;
using A;
using UnityEngine;
using XsdSettings;

public class NPC_UIFlowController
{
	public enum NPC_UIFlowState
	{
		None = 0,
		FunctionList = 1,
		NpcDialog = 2,
		Quest = 3,
		Crafting = 4,
		Melting = 5,
		Mail = 6,
		WeaponShop = 7,
		CoinShieldShop = 8,
		ClassModeShop = 9,
		Warehouse = 10,
		CreateGuild = 11,
		DismissGuild = 12,
		QuitGuild = 13,
		WeaponUpgrade = 14
	}

	public enum NPCCameraAnimtion
	{
		None = 0,
		Aside = 1,
		SideToMiddle = 2,
		MiddleToSide = 3
	}

	public class NPC_UI_Context
	{
		public GameObject CurNPCCamera;

		public GameObject CraftCamera;

		public GameObject UpgradeCamera;

		public TownNPCAnimationManagerFSM CurNPCAnimaMgr;

		public XsdSettings.TownNpc CurNPCSetting;

		public QuestUIData CurQuestData;
	}

	public class NPC_FlowBase
	{
		protected NPC_UIFlowState _previousStep;

		public virtual void c23ffb495db7c9da62404f1cc24a67351(NPC_UIFlowState ce03df81849539ef25fafc22a02797218)
		{
			if (ce03df81849539ef25fafc22a02797218 == NPC_UIFlowState.None)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c71f6ce28731edfd43c976fbd57c57bea().c7ff3e47f83c0be6db6d1bb11ec5fef30();
				c71f6ce28731edfd43c976fbd57c57bea().c26d02f71de2b974ad15922d07cf9797d(NPCCameraAnimtion.Aside);
			}
			_previousStep = ce03df81849539ef25fafc22a02797218;
		}

		public virtual void cac7688b05e921e2be3f92479ba44b4a8()
		{
		}
	}

	public class NPCFlow_None : NPC_FlowBase
	{
		public override void c23ffb495db7c9da62404f1cc24a67351(NPC_UIFlowState ce03df81849539ef25fafc22a02797218)
		{
			base.c23ffb495db7c9da62404f1cc24a67351(ce03df81849539ef25fafc22a02797218);
			c71f6ce28731edfd43c976fbd57c57bea().c876f0d3ae67e35cd0c91d43e97127ed0();
		}
	}

	public class NPCFlow_ShowFunctionList : NPC_FlowBase
	{
		public override void c23ffb495db7c9da62404f1cc24a67351(NPC_UIFlowState ce03df81849539ef25fafc22a02797218)
		{
			base.c23ffb495db7c9da62404f1cc24a67351(ce03df81849539ef25fafc22a02797218);
			if (ce03df81849539ef25fafc22a02797218 == NPC_UIFlowState.NpcDialog)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c71f6ce28731edfd43c976fbd57c57bea().c26d02f71de2b974ad15922d07cf9797d(NPCCameraAnimtion.MiddleToSide);
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<NPCInteractiveView>().cf15a2a34d3ddcc09914934a114ef53e0(c71f6ce28731edfd43c976fbd57c57bea().cca0442ccb623885a072dc61860e6655c().CurNPCSetting);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<NPCInteractiveView>().c150264a18c2cb408479d3f072cac8cc1 = true;
		}

		public override void cac7688b05e921e2be3f92479ba44b4a8()
		{
			base.cac7688b05e921e2be3f92479ba44b4a8();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<NPCInteractiveView>().c150264a18c2cb408479d3f072cac8cc1 = false;
		}
	}

	public class NPCFlow_ShowDialog : NPC_FlowBase
	{
		public override void c23ffb495db7c9da62404f1cc24a67351(NPC_UIFlowState ce03df81849539ef25fafc22a02797218)
		{
			base.c23ffb495db7c9da62404f1cc24a67351(ce03df81849539ef25fafc22a02797218);
			QuestUIData curQuestData = c71f6ce28731edfd43c976fbd57c57bea().cca0442ccb623885a072dc61860e6655c().CurQuestData;
			if (curQuestData == null)
			{
				while (true)
				{
					switch (6)
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
			string[] cd5dc5763f862b67fe053750383f78df = c7e77aa637b9ae1290617ecc771e6c274.c7088de59e49f7108f520cf7e0bae167e;
			if (curQuestData._questProgress.mStatus == QuestState.Available)
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
				cd5dc5763f862b67fe053750383f78df = curQuestData._quest.mAvailableDialog;
			}
			else if (curQuestData._questProgress.mStatus == QuestState.InProgress)
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
				cd5dc5763f862b67fe053750383f78df = curQuestData._quest.mInProgressDialog;
			}
			else if (curQuestData._questProgress.mStatus == QuestState.Completed)
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
				cd5dc5763f862b67fe053750383f78df = curQuestData._quest.mCompletedDialog;
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<NPCDialogView>().c150264a18c2cb408479d3f072cac8cc1 = true;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<NPCDialogView>().cbf02f618cec2bb6ec0c7e716b8cbce65(cd5dc5763f862b67fe053750383f78df);
			c71f6ce28731edfd43c976fbd57c57bea().c26d02f71de2b974ad15922d07cf9797d(NPCCameraAnimtion.SideToMiddle);
		}

		public override void cac7688b05e921e2be3f92479ba44b4a8()
		{
			base.cac7688b05e921e2be3f92479ba44b4a8();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<NPCDialogView>().c150264a18c2cb408479d3f072cac8cc1 = false;
		}
	}

	public class NPCFlow_ShowQuestDetail : NPC_FlowBase
	{
		public override void c23ffb495db7c9da62404f1cc24a67351(NPC_UIFlowState ce03df81849539ef25fafc22a02797218)
		{
			base.c23ffb495db7c9da62404f1cc24a67351(ce03df81849539ef25fafc22a02797218);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<QuestDetailView>().c0dab2d74aa11ce604cc5b34076d37dea(c71f6ce28731edfd43c976fbd57c57bea().cca0442ccb623885a072dc61860e6655c().CurQuestData);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<QuestDetailView>().c150264a18c2cb408479d3f072cac8cc1 = true;
			if (ce03df81849539ef25fafc22a02797218 != NPC_UIFlowState.FunctionList)
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
				c71f6ce28731edfd43c976fbd57c57bea().c26d02f71de2b974ad15922d07cf9797d(NPCCameraAnimtion.MiddleToSide);
			}
			if (ce03df81849539ef25fafc22a02797218 != NPC_UIFlowState.NpcDialog)
			{
				return;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				QuestUIData curQuestData = c71f6ce28731edfd43c976fbd57c57bea().cca0442ccb623885a072dc61860e6655c().CurQuestData;
				if (curQuestData == null)
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
					if (curQuestData._questProgress.mStatus != QuestState.Completed)
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
						if (!(c71f6ce28731edfd43c976fbd57c57bea().cca0442ccb623885a072dc61860e6655c().CurNPCAnimaMgr != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
							c71f6ce28731edfd43c976fbd57c57bea().cca0442ccb623885a072dc61860e6655c().CurNPCAnimaMgr.c979843b9afa58b1781f5d83769d1e4fb(TownNPCAnimationManagerFSM.TownNpcAnimationType.FINISH);
							return;
						}
					}
				}
			}
		}

		public override void cac7688b05e921e2be3f92479ba44b4a8()
		{
			base.cac7688b05e921e2be3f92479ba44b4a8();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<QuestDetailView>().c150264a18c2cb408479d3f072cac8cc1 = false;
		}
	}

	public class NPCFlow_ShowCraftMenu : NPC_FlowBase
	{
		public override void c23ffb495db7c9da62404f1cc24a67351(NPC_UIFlowState ce03df81849539ef25fafc22a02797218)
		{
			base.c23ffb495db7c9da62404f1cc24a67351(ce03df81849539ef25fafc22a02797218);
			c71f6ce28731edfd43c976fbd57c57bea().c21aa374b2797a8b7a75e7fd8bcfa140e();
			if (c71f6ce28731edfd43c976fbd57c57bea()._context.CurNPCCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c71f6ce28731edfd43c976fbd57c57bea()._context.CurNPCCamera.SetActive(false);
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WeaponCraftView>().c150264a18c2cb408479d3f072cac8cc1 = true;
		}

		public override void cac7688b05e921e2be3f92479ba44b4a8()
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WeaponCraftView>().c150264a18c2cb408479d3f072cac8cc1 = false;
			c71f6ce28731edfd43c976fbd57c57bea().c7952c31c99bd536d09bd757060c70aee();
			base.cac7688b05e921e2be3f92479ba44b4a8();
		}
	}

	public class NPCFlow_Melting : NPC_FlowBase
	{
		public override void c23ffb495db7c9da62404f1cc24a67351(NPC_UIFlowState ce03df81849539ef25fafc22a02797218)
		{
			base.c23ffb495db7c9da62404f1cc24a67351(ce03df81849539ef25fafc22a02797218);
			c71f6ce28731edfd43c976fbd57c57bea().c21aa374b2797a8b7a75e7fd8bcfa140e(false);
			if (c71f6ce28731edfd43c976fbd57c57bea()._context.CurNPCCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c71f6ce28731edfd43c976fbd57c57bea()._context.CurNPCCamera.SetActive(false);
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WeaponMeltView>().c150264a18c2cb408479d3f072cac8cc1 = true;
		}

		public override void cac7688b05e921e2be3f92479ba44b4a8()
		{
			base.cac7688b05e921e2be3f92479ba44b4a8();
			c71f6ce28731edfd43c976fbd57c57bea().c7952c31c99bd536d09bd757060c70aee(false);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WeaponMeltView>().c150264a18c2cb408479d3f072cac8cc1 = false;
		}
	}

	public class NPCFlow_CreateGuild : NPC_FlowBase
	{
		public override void c23ffb495db7c9da62404f1cc24a67351(NPC_UIFlowState ce03df81849539ef25fafc22a02797218)
		{
			base.c23ffb495db7c9da62404f1cc24a67351(ce03df81849539ef25fafc22a02797218);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildCreateView>().c150264a18c2cb408479d3f072cac8cc1 = true;
		}

		public override void cac7688b05e921e2be3f92479ba44b4a8()
		{
			base.cac7688b05e921e2be3f92479ba44b4a8();
		}
	}

	public class NPCFlow_WeaponUpgrade : NPC_FlowBase
	{
		public override void c23ffb495db7c9da62404f1cc24a67351(NPC_UIFlowState ce03df81849539ef25fafc22a02797218)
		{
			base.c23ffb495db7c9da62404f1cc24a67351(ce03df81849539ef25fafc22a02797218);
			c71f6ce28731edfd43c976fbd57c57bea().c3fb028a78a9aba6c365a212057a7f011();
			if (c71f6ce28731edfd43c976fbd57c57bea()._context.CurNPCCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c71f6ce28731edfd43c976fbd57c57bea()._context.CurNPCCamera.SetActive(false);
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WeaponUpgradeView>().c150264a18c2cb408479d3f072cac8cc1 = true;
		}

		public override void cac7688b05e921e2be3f92479ba44b4a8()
		{
			base.cac7688b05e921e2be3f92479ba44b4a8();
			c71f6ce28731edfd43c976fbd57c57bea().c0bd7040cb81b6726b39263a1aeb4239c();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WeaponUpgradeView>().c150264a18c2cb408479d3f072cac8cc1 = false;
		}
	}

	public class NPCFlow_WeaponShop : NPC_FlowBase
	{
		public override void c23ffb495db7c9da62404f1cc24a67351(NPC_UIFlowState ce03df81849539ef25fafc22a02797218)
		{
			base.c23ffb495db7c9da62404f1cc24a67351(ce03df81849539ef25fafc22a02797218);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ShopView>().c150264a18c2cb408479d3f072cac8cc1 = true;
			XsdSettings.TownNpc curNPCSetting = c71f6ce28731edfd43c976fbd57c57bea()._context.CurNPCSetting;
			if (curNPCSetting == null)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ShopView>().cf2355e2a47f860be2c9f1914df5bc924(curNPCSetting.m_WeaponShopID);
				return;
			}
		}

		public override void cac7688b05e921e2be3f92479ba44b4a8()
		{
			base.cac7688b05e921e2be3f92479ba44b4a8();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ShopView>().c150264a18c2cb408479d3f072cac8cc1 = false;
		}
	}

	public class NPCFlow_CoinShieldShop : NPC_FlowBase
	{
		public override void c23ffb495db7c9da62404f1cc24a67351(NPC_UIFlowState ce03df81849539ef25fafc22a02797218)
		{
			base.c23ffb495db7c9da62404f1cc24a67351(ce03df81849539ef25fafc22a02797218);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ShopView>().c150264a18c2cb408479d3f072cac8cc1 = true;
			XsdSettings.TownNpc curNPCSetting = c71f6ce28731edfd43c976fbd57c57bea()._context.CurNPCSetting;
			if (curNPCSetting == null)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ShopView>().cf2355e2a47f860be2c9f1914df5bc924(curNPCSetting.m_CoinShieldShopID);
				return;
			}
		}

		public override void cac7688b05e921e2be3f92479ba44b4a8()
		{
			base.cac7688b05e921e2be3f92479ba44b4a8();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ShopView>().c150264a18c2cb408479d3f072cac8cc1 = false;
		}
	}

	public class NPCFlow_ClassModeShop : NPC_FlowBase
	{
		public override void c23ffb495db7c9da62404f1cc24a67351(NPC_UIFlowState ce03df81849539ef25fafc22a02797218)
		{
			base.c23ffb495db7c9da62404f1cc24a67351(ce03df81849539ef25fafc22a02797218);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ShopView>().c150264a18c2cb408479d3f072cac8cc1 = true;
			XsdSettings.TownNpc curNPCSetting = c71f6ce28731edfd43c976fbd57c57bea()._context.CurNPCSetting;
			if (curNPCSetting == null)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ShopView>().cf2355e2a47f860be2c9f1914df5bc924(curNPCSetting.m_ClassModeShopID);
				return;
			}
		}

		public override void cac7688b05e921e2be3f92479ba44b4a8()
		{
			base.cac7688b05e921e2be3f92479ba44b4a8();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ShopView>().c150264a18c2cb408479d3f072cac8cc1 = false;
		}
	}

	public class NPCFlow_Warehouse : NPC_FlowBase
	{
		public override void c23ffb495db7c9da62404f1cc24a67351(NPC_UIFlowState ce03df81849539ef25fafc22a02797218)
		{
			base.c23ffb495db7c9da62404f1cc24a67351(ce03df81849539ef25fafc22a02797218);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WareHouseView>().c150264a18c2cb408479d3f072cac8cc1 = true;
		}

		public override void cac7688b05e921e2be3f92479ba44b4a8()
		{
			base.cac7688b05e921e2be3f92479ba44b4a8();
		}
	}

	public class NPCFlow_Mail : NPC_FlowBase
	{
		public override void c23ffb495db7c9da62404f1cc24a67351(NPC_UIFlowState ce03df81849539ef25fafc22a02797218)
		{
			base.c23ffb495db7c9da62404f1cc24a67351(ce03df81849539ef25fafc22a02797218);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MailView>().c150264a18c2cb408479d3f072cac8cc1 = true;
		}

		public override void cac7688b05e921e2be3f92479ba44b4a8()
		{
			base.cac7688b05e921e2be3f92479ba44b4a8();
		}
	}

	public delegate void onUIShowOff(bool bShow);

	protected const string NPC_CAMERA_ANIMATION_ASIDE = "ANI_NPCCameraMotionFloasm";

	protected const string NPC_CAMERA_ANIMATION_TOMIDDLE = "ANI_NPCCameraMotionToMiddle";

	protected NPC_UI_Context _context;

	private static NPC_UIFlowController _instance;

	protected Dictionary<NPC_UIFlowState, Type> _UIFlowSteps = new Dictionary<NPC_UIFlowState, Type>();

	protected Dictionary<NPC_UIFlowState, NPC_FlowBase> _UIFlowAcureClass = new Dictionary<NPC_UIFlowState, NPC_FlowBase>();

	protected NPC_UIFlowState _curState;

	protected bool _bUIOnShow;

	protected onUIShowOff _callbackOnUIShowOff;

	public bool cd885bd4479d20f52c6f209bf46f58b98
	{
		get
		{
			return _bUIOnShow;
		}
	}

	protected NPC_UIFlowController()
	{
		_context = new NPC_UI_Context();
		_UIFlowSteps.Add(NPC_UIFlowState.None, typeof(NPCFlow_None));
		_UIFlowSteps.Add(NPC_UIFlowState.FunctionList, typeof(NPCFlow_ShowFunctionList));
		_UIFlowSteps.Add(NPC_UIFlowState.NpcDialog, typeof(NPCFlow_ShowDialog));
		_UIFlowSteps.Add(NPC_UIFlowState.Quest, typeof(NPCFlow_ShowQuestDetail));
		_UIFlowSteps.Add(NPC_UIFlowState.Crafting, typeof(NPCFlow_ShowCraftMenu));
		_UIFlowSteps.Add(NPC_UIFlowState.Melting, typeof(NPCFlow_Melting));
		_UIFlowSteps.Add(NPC_UIFlowState.Mail, typeof(NPCFlow_Mail));
		_UIFlowSteps.Add(NPC_UIFlowState.CreateGuild, typeof(NPCFlow_CreateGuild));
		_UIFlowSteps.Add(NPC_UIFlowState.DismissGuild, typeof(NPCFlow_None));
		_UIFlowSteps.Add(NPC_UIFlowState.QuitGuild, typeof(NPCFlow_None));
		_UIFlowSteps.Add(NPC_UIFlowState.WeaponShop, typeof(NPCFlow_WeaponShop));
		_UIFlowSteps.Add(NPC_UIFlowState.CoinShieldShop, typeof(NPCFlow_CoinShieldShop));
		_UIFlowSteps.Add(NPC_UIFlowState.ClassModeShop, typeof(NPCFlow_ClassModeShop));
		_UIFlowSteps.Add(NPC_UIFlowState.Warehouse, typeof(NPCFlow_Warehouse));
		_UIFlowSteps.Add(NPC_UIFlowState.WeaponUpgrade, typeof(NPCFlow_WeaponUpgrade));
	}

	public NPC_UI_Context cca0442ccb623885a072dc61860e6655c()
	{
		return _context;
	}

	public static NPC_UIFlowController c71f6ce28731edfd43c976fbd57c57bea()
	{
		if (_instance == null)
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
			_instance = new NPC_UIFlowController();
		}
		return _instance;
	}

	public void c26d02f71de2b974ad15922d07cf9797d(NPCCameraAnimtion c8c20be089fb639cbcad2b94ebad3256c)
	{
		string text = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		bool flag = false;
		switch (c8c20be089fb639cbcad2b94ebad3256c)
		{
		case NPCCameraAnimtion.None:
			return;
		case NPCCameraAnimtion.Aside:
			text = "ANI_NPCCameraMotionFloasm";
			break;
		case NPCCameraAnimtion.SideToMiddle:
			text = "ANI_NPCCameraMotionToMiddle";
			break;
		case NPCCameraAnimtion.MiddleToSide:
			text = "ANI_NPCCameraMotionToMiddle";
			flag = true;
			break;
		}
		if (!(_context.CurNPCCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			Animation component = _context.CurNPCCamera.GetComponent<Animation>();
			if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				return;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				AnimationState animationState = component[text];
				float speed;
				if (flag)
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
					speed = -0.5f;
				}
				else
				{
					speed = 0.5f;
				}
				animationState.speed = speed;
				AnimationState animationState2 = component[text];
				float time;
				if (flag)
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
					time = component[text].length;
				}
				else
				{
					time = 0f;
				}
				animationState2.time = time;
				component[text].wrapMode = WrapMode.Once;
				component.Play(text);
				return;
			}
		}
	}

	protected NPC_FlowBase c096a6a2e33ce86f56a7aceaa94022e7c(NPC_UIFlowState ca96a0c359a7a7dd4adbf255c923f40ca)
	{
		if (!_UIFlowAcureClass.ContainsKey(ca96a0c359a7a7dd4adbf255c923f40ca))
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					NPC_FlowBase nPC_FlowBase = Activator.CreateInstance(_UIFlowSteps[ca96a0c359a7a7dd4adbf255c923f40ca]) as NPC_FlowBase;
					if (nPC_FlowBase != null)
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
						_UIFlowAcureClass.Add(ca96a0c359a7a7dd4adbf255c923f40ca, nPC_FlowBase);
					}
					return nPC_FlowBase;
				}
				}
			}
		}
		return _UIFlowAcureClass[ca96a0c359a7a7dd4adbf255c923f40ca];
	}

	public void cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowState c4992f8f718608974873b2575dfecfda0)
	{
		if (_curState == c4992f8f718608974873b2575dfecfda0)
		{
			while (true)
			{
				switch (7)
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
		NPC_FlowBase nPC_FlowBase = c096a6a2e33ce86f56a7aceaa94022e7c(c4992f8f718608974873b2575dfecfda0);
		nPC_FlowBase.c23ffb495db7c9da62404f1cc24a67351(_curState);
		NPC_FlowBase nPC_FlowBase2 = c096a6a2e33ce86f56a7aceaa94022e7c(_curState);
		nPC_FlowBase2.cac7688b05e921e2be3f92479ba44b4a8();
		_curState = c4992f8f718608974873b2575dfecfda0;
	}

	public void c7ff3e47f83c0be6db6d1bb11ec5fef30()
	{
		if (_context.CurNPCCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c91fcf132a3585bad3597263bc8937405 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c91fcf132a3585bad3597263bc8937405.gameObject.SetActive(false);
			}
			_context.CurNPCCamera.SetActive(true);
		}
		EntityPlayer entityPlayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
		if ((bool)entityPlayer)
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
			entityPlayer.c2f18a3b5ccc9813ca1b7e1fcfcffdc75(true);
		}
		_bUIOnShow = true;
		_callbackOnUIShowOff(true);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = false;
	}

	public void c876f0d3ae67e35cd0c91d43e97127ed0()
	{
		if (_context.CurNPCCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			_context.CurNPCCamera.SetActive(false);
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c91fcf132a3585bad3597263bc8937405 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c91fcf132a3585bad3597263bc8937405.gameObject.SetActive(true);
			}
		}
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			EntityPlayer entityPlayer = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
			if ((bool)entityPlayer)
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
				entityPlayer.c2f18a3b5ccc9813ca1b7e1fcfcffdc75(false);
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.cd76850fff3f38531496e8d16b9a1db09().cf838f7acd5eb655ae8a916dd0f765a44();
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c6394b4e5eb2c68525f7e96959e519fb7();
		}
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1570506bf0b326e191d0406037cb4fef();
		c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0888ee52497af70d4cc14624cbd11269();
		_bUIOnShow = false;
		_callbackOnUIShowOff(false);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = true;
	}

	public void c21aa374b2797a8b7a75e7fd8bcfa140e(bool cd1e2f3937aeb889cc63494f62ca34e86 = true)
	{
		GameObject gameObject = GameObject.Find("WeaponcraftingCameraRoot");
		object obj;
		if (cd1e2f3937aeb889cc63494f62ca34e86)
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
			obj = "Base Layer.ANI_WeaponcraftingCameraMotion";
		}
		else
		{
			obj = "Base Layer.ANI_WeaponMeltingCameraMotion";
		}
		string stateName = (string)obj;
		Animator componentInChildren = gameObject.GetComponentInChildren<Animator>();
		componentInChildren.enabled = true;
		if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Camera[] componentsInChildren = gameObject.GetComponentsInChildren<Camera>(true);
			if (componentsInChildren != null)
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
				Camera[] array = componentsInChildren;
				foreach (Camera camera in array)
				{
					if (!(camera.name == "WeaponcraftingCamera"))
					{
						continue;
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					_context.CraftCamera = camera.gameObject;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
			}
		}
		if (!(_context.CraftCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			_context.CraftCamera.SetActive(true);
			componentInChildren.CrossFade(stateName, 1f);
			return;
		}
	}

	public void c7952c31c99bd536d09bd757060c70aee(bool cd1e2f3937aeb889cc63494f62ca34e86 = true)
	{
		if (!(_context.CraftCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			GameObject gameObject = GameObject.Find("WeaponcraftingCameraRoot");
			Animator componentInChildren = gameObject.GetComponentInChildren<Animator>();
			componentInChildren.CrossFade("Base Layer.Idle", 0f);
			_context.CraftCamera.SetActive(false);
			return;
		}
	}

	public void c3fb028a78a9aba6c365a212057a7f011()
	{
		GameObject gameObject = GameObject.Find("PRO_WeaponUpgrade");
		if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Camera[] componentsInChildren = gameObject.GetComponentsInChildren<Camera>(true);
			if (componentsInChildren != null)
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
				Camera[] array = componentsInChildren;
				foreach (Camera camera in array)
				{
					if (!(camera.name == "WeaponupgradeCamera"))
					{
						continue;
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					_context.UpgradeCamera = camera.gameObject;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
			}
		}
		if (!(_context.UpgradeCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			_context.UpgradeCamera.SetActive(true);
			return;
		}
	}

	public void c0bd7040cb81b6726b39263a1aeb4239c()
	{
		if (!(_context.UpgradeCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			_context.UpgradeCamera.SetActive(false);
			return;
		}
	}

	public void cd2beda30e19af44fd0d1bdf7f55c9f4d(onUIShowOff c2db84530ef366a6deb001d449d4aa151)
	{
		_callbackOnUIShowOff = (onUIShowOff)Delegate.Combine(_callbackOnUIShowOff, c2db84530ef366a6deb001d449d4aa151);
	}

	public void c7f1091fa96379f982bfcae30e3cca0ff(onUIShowOff c2db84530ef366a6deb001d449d4aa151)
	{
		_callbackOnUIShowOff = (onUIShowOff)Delegate.Remove(_callbackOnUIShowOff, c2db84530ef366a6deb001d449d4aa151);
	}
}
