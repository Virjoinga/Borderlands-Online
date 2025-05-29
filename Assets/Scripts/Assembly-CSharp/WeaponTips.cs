using A;
using pumpkin.display;

public class WeaponTips : ca28a90236225d84ff4176d76e8446d33
{
	protected static SmallWeaponCardNoAnimation _weaponCardPanel;

	public WeaponDNA _showItem;

	public WeaponTips(WeaponDNA c5d720f6d007abb0c4a21d6a654e405bb)
	{
		_showItem = c5d720f6d007abb0c4a21d6a654e405bb;
	}

	public override DisplayObject c710592d0cc98297d2151ac3095b4f412()
	{
		if (_weaponCardPanel == null)
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
					ca49e5e0015ea1ca43f1040447671e38a();
					return null;
				}
			}
		}
		if (_showItem == null)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return null;
				}
			}
		}
		ItemDNA itemDNA = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CharInfoView>().ccd0f6bcfcd12e28d498bb8d9a3a245c0();
		SmallWeaponCardNoAnimation weaponCardPanel = _weaponCardPanel;
		WeaponDNA showItem = _showItem;
		WeaponDNA c04d182ebd13b8bf7e53d75bb60be41b;
		if (itemDNA == null)
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
			c04d182ebd13b8bf7e53d75bb60be41b = cc607e9943fa3c5044ada833720c23c9a.c7088de59e49f7108f520cf7e0bae167e;
		}
		else
		{
			c04d182ebd13b8bf7e53d75bb60be41b = itemDNA.ca79da172938fdc8c067fb64242b6174a();
		}
		weaponCardPanel.c58de56793cb96a279858c7b68a326d17(showItem, c04d182ebd13b8bf7e53d75bb60be41b);
		return _weaponCardPanel.c89ef242f4744e0f1c4ffea4da8b79bc1;
	}

	public static void ca49e5e0015ea1ca43f1040447671e38a()
	{
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Weapon_card.swf", "Panel_SWC_No_Anim", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
	}

	private static void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_weaponCardPanel = new SmallWeaponCardNoAnimation();
		_weaponCardPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
	}
}
