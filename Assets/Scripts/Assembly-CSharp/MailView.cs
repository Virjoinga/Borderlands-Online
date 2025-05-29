using System;
using System.Collections.Generic;
using A;

public class MailView : BaseView, IMailServiceNotificationListener
{
	protected enum MailAnimaState
	{
		None = 0,
		KickOff = 1,
		MailList = 2,
		MailContent = 3,
		CreateNewMail = 4,
		Reply = 5,
		Quit = 6
	}

	protected class NewMailInfoContainer
	{
		public string StrReceiverNickName;

		public string StrMailContent;
	}

	protected static readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

	protected List<MailInfo> _mailInfoList = new List<MailInfo>();

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cbfdeda957ab87de3d0acf25194e61c4c(this);
		_mailInfoList = c1ee7921b0c3cce194fb7cae41b5a9d82<MailServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cfd9d57231f4e8e67b5a6a492bc70a1a0();
		c1ee7921b0c3cce194fb7cae41b5a9d82<MailServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c523e4a3a3feaf78d0e1c44cb5f113f7c(this);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cfdafa122fc114376585cbb27b8811a86(this);
		c1ee7921b0c3cce194fb7cae41b5a9d82<MailServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c92508dc6911d2386ea0db5b2e4a3f935(this);
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (!c8be1fcd630e5fe96821376d111325750)
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
			NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.None);
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = !c8be1fcd630e5fe96821376d111325750;
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
					c150264a18c2cb408479d3f072cac8cc1 = false;
					return true;
				}
			}
		}
		return base.cc130a2d46a451dc54b61a8f0d60794ae();
	}

	protected virtual void c9c040a2d0edf8852c382f5612a6dfe82()
	{
		_mailInfoList = c1ee7921b0c3cce194fb7cae41b5a9d82<MailServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cfd9d57231f4e8e67b5a6a492bc70a1a0();
	}

	protected virtual void cb220312ba4169f4e8539d19ff2cc826e(MailAnimaState c7d77be03dd09783b7cf45209bd57d03e)
	{
	}

	protected void cfa3d216ee6c8a280caacb43ec2d88010(MailInfo c581d1dfdd43628e29bfec127d5c010fa)
	{
		MenuItemDef[] array = cacffdc9bda8a41773c3ac61797275a6c.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("MAIL_OPEN"));
		array[0].itemData = c581d1dfdd43628e29bfec127d5c010fa;
		array[0].itemFunc = c2bf5de9410e290af8bda22039a6ab9b2;
		array[1].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("MAIL_DELETE"));
		array[1].itemData = c581d1dfdd43628e29bfec127d5c010fa;
		array[1].itemFunc = c9129cf3e79c61648e97fa216119300b4;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().c687c56ed531550f24368180c4c3bc947(array);
	}

	protected virtual void c2bf5de9410e290af8bda22039a6ab9b2(object c591d56a94543e3559945c497f37126c4)
	{
	}

	protected void c9129cf3e79c61648e97fa216119300b4(object c591d56a94543e3559945c497f37126c4)
	{
		MailInfo mailInfo = c591d56a94543e3559945c497f37126c4 as MailInfo;
		if (mailInfo == null)
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
			cfbc6cd6bdb17c11ccf2b97a9f4f290a1(mailInfo.MailID);
			return;
		}
	}

	protected virtual void c330521174d958b9cdc7af9387000e5a0(NewMailInfoContainer c3173e0dbe4f694d48d83f191d48d4f87)
	{
		if (c3173e0dbe4f694d48d83f191d48d4f87.StrReceiverNickName == null)
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
			if (c3173e0dbe4f694d48d83f191d48d4f87.StrMailContent == null)
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<MailServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c8c71e978b55bc1d65cffa8cba32ed71f(c3173e0dbe4f694d48d83f191d48d4f87.StrReceiverNickName, c3173e0dbe4f694d48d83f191d48d4f87.StrMailContent);
				return;
			}
		}
	}

	protected virtual void c3f2eb1fe3e05b644222ef6a3f96fd9b2(MailInfo c581d1dfdd43628e29bfec127d5c010fa)
	{
	}

	protected virtual void cfbc6cd6bdb17c11ccf2b97a9f4f290a1(int c12459f7fd9a58b1a6784df61f00ccdd9)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<MailServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c094cd005fed2c85b5b372c1cd5d05775(c12459f7fd9a58b1a6784df61f00ccdd9);
	}

	protected virtual void c0af0340887d57a212d15eed714538f79(MailInfo c6ee8156bd1252a322811a721a2b0be39)
	{
		if (c6ee8156bd1252a322811a721a2b0be39.Mailstate != 0)
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<MailServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c576f44b3071b0b941ce913d80b32bc52(c6ee8156bd1252a322811a721a2b0be39.MailID);
			return;
		}
	}

	protected virtual void cf2c155218c6f8005bc83c51eaa64aafb(MailInfo c581d1dfdd43628e29bfec127d5c010fa)
	{
		if (c581d1dfdd43628e29bfec127d5c010fa == null)
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
			if (c581d1dfdd43628e29bfec127d5c010fa.Item == null)
			{
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
			if (c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c6facc64e2d5edf33221db1a902d2ccf3(c581d1dfdd43628e29bfec127d5c010fa.Item.mItem))
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<MailServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ce7617ddfcf071c0b6b413615f347f61b(c581d1dfdd43628e29bfec127d5c010fa.MailID);
				return;
			}
		}
	}

	public void OnGetNewMail(MailInfo newmail)
	{
		c9c040a2d0edf8852c382f5612a6dfe82();
	}

	public void OnGetPlayerMail(List<MailInfo> mailList)
	{
		c9c040a2d0edf8852c382f5612a6dfe82();
	}

	public void OnGetMailList(List<MailInfo> mailInfoList)
	{
		c9c040a2d0edf8852c382f5612a6dfe82();
	}

	public void OnSendMail(bool bIsSuccessful)
	{
		if (bIsSuccessful)
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
			c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5("81005");
		}
		else
		{
			c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5("81006");
		}
		c9c040a2d0edf8852c382f5612a6dfe82();
	}

	public void OnReadMail(int mailID)
	{
		c9c040a2d0edf8852c382f5612a6dfe82();
	}

	public void OnDeleteMail(int mailID)
	{
		c9c040a2d0edf8852c382f5612a6dfe82();
	}

	public void OnGetmailItem(short result, int mailID)
	{
		if (result == 0)
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
			cfbc6cd6bdb17c11ccf2b97a9f4f290a1(mailID);
		}
		c9c040a2d0edf8852c382f5612a6dfe82();
	}
}
