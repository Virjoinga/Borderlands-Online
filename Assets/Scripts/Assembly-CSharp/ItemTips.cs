using A;
using XsdSettings;
using pumpkin.display;

public class ItemTips : ca28a90236225d84ff4176d76e8446d33
{
	protected static ItemCardPanel _cardPanel;

	protected ItemDNA _showItem;

	public ItemTips(ItemDNA c5d720f6d007abb0c4a21d6a654e405bb)
	{
		_showItem = c5d720f6d007abb0c4a21d6a654e405bb;
	}

	public override DisplayObject c710592d0cc98297d2151ac3095b4f412()
	{
		if (_cardPanel == null)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					c932bfccc5c973fdc58a3c282d4ccc1a5();
					return null;
				}
			}
		}
		ItemDNA cd7c0d36f2c73807ca9525013ef = c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e;
		switch (_showItem.m_type)
		{
		case ItemType.Weapon:
			cd7c0d36f2c73807ca9525013ef = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CharInfoView>().ccd0f6bcfcd12e28d498bb8d9a3a245c0();
			break;
		case ItemType.Shield:
			cd7c0d36f2c73807ca9525013ef = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CharInfoView>().cac06519a9a0fc999487710a6dfd94dba();
			break;
		}
		_cardPanel.c58de56793cb96a279858c7b68a326d17(_showItem, cd7c0d36f2c73807ca9525013ef);
		return _cardPanel.c89ef242f4744e0f1c4ffea4da8b79bc1;
	}

	public static void c932bfccc5c973fdc58a3c282d4ccc1a5()
	{
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Tips.swf", "Panel_Tips_Card", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
	}

	public static void c9dec9a28db62894ffe6dd475eda41961()
	{
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Tips.swf");
		_cardPanel = c4c66dabfe7f2d9117be656807991c47b.c7088de59e49f7108f520cf7e0bae167e;
	}

	private static void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_cardPanel = new ItemCardPanel();
		_cardPanel.c130648b59a0c8debea60aa153f844879(new MovieClip());
		_cardPanel.cd351226c5175db6eab2a3dd9ec9ff57c(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
	}

	public override void OnPositionAdjusted(ceaa621c569baf012ce466a5c368364e3 tipsOrin, bool bRightExpend)
	{
		if (_cardPanel == null)
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
			_cardPanel.cdb8cb55fc5bf99fb5dd2235d0d25463a(bRightExpend);
			return;
		}
	}

	public override void OnClean()
	{
		if (_cardPanel == null)
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
			_cardPanel.c2bc47b1e29f7a6270d8c07e700f9a474();
			return;
		}
	}
}
