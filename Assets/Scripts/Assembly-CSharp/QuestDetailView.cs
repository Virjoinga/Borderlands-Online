using A;
using XsdSettings;

public class QuestDetailView : BaseView
{
	public delegate void DeleOnClickAccept();

	public delegate void DeleOnClickCancel();

	protected QuestUIData _questData;

	protected XsdSettings.TownNpc _NPCSetting;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cbfdeda957ab87de3d0acf25194e61c4c(this);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cfdafa122fc114376585cbb27b8811a86(this);
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
	}

	public override bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		if (c150264a18c2cb408479d3f072cac8cc1)
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
					NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.FunctionList);
					return true;
				}
			}
		}
		return base.cc130a2d46a451dc54b61a8f0d60794ae();
	}

	public virtual void c0dab2d74aa11ce604cc5b34076d37dea(QuestUIData c03a4aef4270a8b2a2426ba59fb48cf53)
	{
		_questData = c03a4aef4270a8b2a2426ba59fb48cf53;
	}

	protected virtual void c02ed51fd65a976a6ef07902fa09bef51()
	{
		if (_questData == null)
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
		if (_questData._questProgress.mStatus == QuestState.Available)
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
			QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().cf7f98b1de39f26f9a9d63b5d8ac5a26b(_questData._quest.mId);
		}
		else if (_questData._questProgress.mStatus == QuestState.Completed)
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
			QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().c5fdc976a8c3f9e6e8516525fd2a5396f(_questData._quest.mId);
		}
		NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.FunctionList);
	}

	protected virtual void c160c4effdbc25f551e67296293735016()
	{
		NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.FunctionList);
	}
}
