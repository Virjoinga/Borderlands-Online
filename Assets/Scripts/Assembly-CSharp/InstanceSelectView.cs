using A;
using Core;
using UnityEngine;
using XsdSettings;

public class InstanceSelectView : BaseView
{
	public struct InstanceInfo
	{
		public int iUnlockExp;

		public int iID;

		public bool bUnlocked;
	}

	public Delegate_EnterLevelProc _enterLevelFunc;

	protected PlayerProperties _playerInfo;

	protected int _iPlayerExp = -1;

	protected bool _bSkillIconBlink;

	protected bool _bSkillBtnEnable;

	protected int _iLevel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c858f0c33158b659215d28b3c0548a38a(this);
		SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c39e911336cb557f0eec128814bdf7728(ce01b69c1f5aa521b180553e3031278dd);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ceb073876b67631e82266e224318dc9de(this);
	}

	protected virtual void ce01b69c1f5aa521b180553e3031278dd(int c37c8cc761dd6f739a4c896e64e44fdd5, int c43c216df6aadde10be3f9bdf566009ca)
	{
		bool c38daa1ecfc4be57f0bab6f15b4488ecc = c37c8cc761dd6f739a4c896e64e44fdd5 > 0;
		c3a2c418e6d212d98117efef5f710e5c4(c38daa1ecfc4be57f0bab6f15b4488ecc);
		int num;
		if (c37c8cc761dd6f739a4c896e64e44fdd5 > 0)
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
			num = ((c43c216df6aadde10be3f9bdf566009ca == c37c8cc761dd6f739a4c896e64e44fdd5) ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		bool cb2e8e0aee7c4feb88aeece01cf9c5bb = (byte)num != 0;
		cc2c9bc0084750e845c15d14e953c9abd(cb2e8e0aee7c4feb88aeece01cf9c5bb);
	}

	public virtual void cacb0973399bda5328a4e13f27d851fdb(int cd6bb591c33b2ee3ab93e98aa43a6da63)
	{
		_iLevel = cd6bb591c33b2ee3ab93e98aa43a6da63;
	}

	public virtual void c0be25dad7f3b503064fc98b654b8c830(PlayerProperties c25f5f36a54095a8f73d85c7f7b5af196)
	{
		if (c25f5f36a54095a8f73d85c7f7b5af196 == null)
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
			_playerInfo = c25f5f36a54095a8f73d85c7f7b5af196;
			return;
		}
	}

	public virtual void cc2c9bc0084750e845c15d14e953c9abd(bool cb2e8e0aee7c4feb88aeece01cf9c5bb1)
	{
		_bSkillIconBlink = cb2e8e0aee7c4feb88aeece01cf9c5bb1;
	}

	public virtual void c3a2c418e6d212d98117efef5f710e5c4(bool c38daa1ecfc4be57f0bab6f15b4488ecc)
	{
		_bSkillBtnEnable = c38daa1ecfc4be57f0bab6f15b4488ecc;
	}

	public virtual void c6276e463c060f727bf5215d9ced80e1a(int cd35c54bbdf8dc36adfaf77c43448813a)
	{
		if (_iPlayerExp == -1)
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
			_iPlayerExp = cd35c54bbdf8dc36adfaf77c43448813a;
		}
		_iPlayerExp = cd35c54bbdf8dc36adfaf77c43448813a;
	}

	public virtual void c490e1cdbd91f441f8899c3b557cbc807(bool c74232243aff1dcbf2e8fc243633bb51a)
	{
	}

	private void cefe421697a3bbbea5cbd44ad193a066d(int c717dab0494f3f0f159b8bd8bc7c8b729)
	{
		if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().cd0069281ff5290a7e6c484b6aed3933d)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c9d057c2188e7d2872aa3ec71517e92ae = true;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().c23ffb495db7c9da62404f1cc24a67351();
			c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cfe7182ecd28c1d073193664c0a470e42("OnGoToInstance", c717dab0494f3f0f159b8bd8bc7c8b729);
			return;
		}
	}

	private void caf8cd0aa8a374108575ecc4056e685c7(object c591d56a94543e3559945c497f37126c4)
	{
		cefe421697a3bbbea5cbd44ad193a066d((int)c591d56a94543e3559945c497f37126c4);
	}

	private void ce0e73ebe0024ee6863387694bc442126()
	{
		int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = 1001;
		array[1] = 1002;
		int[] array2 = array;
		MenuItemDef[] array3 = cacffdc9bda8a41773c3ac61797275a6c.c0a0cdf4a196914163f7334d9b0781a04(array2.Length);
		for (int i = 0; i < array2.Length; i++)
		{
			Playlist playlist = MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c2718b579e09549a1cd47620188a40a38(array2[i]);
			array3[i].itemTitle = playlist.m_name;
			array3[i].itemData = playlist.m_id;
			array3[i].itemFunc = caf8cd0aa8a374108575ecc4056e685c7;
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().c687c56ed531550f24368180c4c3bc947(array3, new Vector2(0f, 0f));
			return;
		}
	}

	protected void c71bb379df7f6732a0d2a58fd758906ec()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, " onPVPClick:");
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().c150264a18c2cb408479d3f072cac8cc1 = true;
	}

	protected void c3140d9ab4434d5840a6504ebdea0a751()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, " onSurviveClick:");
		cefe421697a3bbbea5cbd44ad193a066d(6);
	}

	protected void ca941d76cfb7334ac495ef56b069b8216()
	{
		bool flag = !c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>().c150264a18c2cb408479d3f072cac8cc1;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>().c150264a18c2cb408479d3f072cac8cc1 = flag;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CharInfoView>().c150264a18c2cb408479d3f072cac8cc1 = flag;
	}

	protected void c4a9b98f590a7233b6acd6f9cfbf8faf0()
	{
		if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<QuestListView>().cd0069281ff5290a7e6c484b6aed3933d)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<QuestListView>().c150264a18c2cb408479d3f072cac8cc1 = !c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<QuestListView>().c150264a18c2cb408479d3f072cac8cc1;
			return;
		}
	}

	protected void c4b4a94071c5ed1ff1149ac0e483d660b()
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<SkillTreeView>().c14b12898fa8e71d52bd003cdc77e9d5d();
	}

	protected void c12a3a3ab04543d87864d15f907212095()
	{
		if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GroupView>().cd0069281ff5290a7e6c484b6aed3933d)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GroupView>().c150264a18c2cb408479d3f072cac8cc1 = !c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GroupView>().c150264a18c2cb408479d3f072cac8cc1;
			return;
		}
	}

	protected void cea868b22606aae02cd67b61c433fa32e()
	{
		if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<FriendView>().cd0069281ff5290a7e6c484b6aed3933d)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<FriendView>().c150264a18c2cb408479d3f072cac8cc1 = !c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<FriendView>().c150264a18c2cb408479d3f072cac8cc1;
			return;
		}
	}

	protected void c73d3bb094acb20099875dce423679337()
	{
		if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GroupView>().cd0069281ff5290a7e6c484b6aed3933d)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GroupView>().c150264a18c2cb408479d3f072cac8cc1 = !c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GroupView>().c150264a18c2cb408479d3f072cac8cc1;
			return;
		}
	}

	protected void cff53e4b907ad13d2815c74c2ce5156dd()
	{
		if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().cd0069281ff5290a7e6c484b6aed3933d)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c150264a18c2cb408479d3f072cac8cc1 = !c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().c150264a18c2cb408479d3f072cac8cc1;
			return;
		}
	}

	public virtual void ccf6f266a84f582fbc9e1b9a4784ed057()
	{
	}

	public virtual void cf198707970ccb9ab868e90753613ed18()
	{
	}

	public virtual void cffafea08501b3cd2032f152f0f047ea0()
	{
	}

	public virtual void c9e01e4a7637451efd443facb83612139()
	{
	}

	public virtual void c2c8c844535004da8c81e3bc95e8f5750()
	{
	}

	public virtual void cadfb3e35b7330c65cea035fdd80e3962()
	{
	}

	public virtual void cd3edf4455690dc2bca805c557d5cfffd()
	{
	}

	public virtual void c47904336715d40ce61e78b89d35f292c()
	{
	}

	public virtual bool c1ec009745cf889298f5dbae973f0cbd7()
	{
		return false;
	}

	public virtual bool c6882cd92015bfcab69976c46b09f2786()
	{
		return false;
	}

	public virtual void c70ea5d182c9e880a5ecefda628922302()
	{
	}

	public virtual void c93da48f317472e2d30deca60386d9a58()
	{
	}
}
