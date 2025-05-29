using A;
using Core;
using UnityEngine;
using XsdSettings;

public class HUDPlayerInfoView : BaseView
{
	protected int _iCurHealth;

	protected int _iMaxHealth;

	protected int _iCurShield;

	protected int _iMaxShield;

	protected int _iCurExp;

	protected int _iMaxExp;

	protected int _iCurBullets;

	protected int _iClipBullets;

	protected int _iMaxBullets;

	protected int _iCurGrenades;

	protected int _iMaxGrenades;

	protected WeaponType _curWeaponType;

	protected int _iLevel;

	protected string _strName = string.Empty;

	protected AvatarType _playerClass = AvatarType.TOTAL;

	public bool bAlwaysShowWeaponSlot { get; set; }

	public virtual bool bPVPDisp { get; set; }

	public override void OnTestGUI()
	{
		Rect position = new Rect(20f, 630f, 200f, 25f);
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "Health:";
		array[1] = _iCurHealth;
		array[2] = " / ";
		array[3] = _iMaxHealth;
		GUI.TextField(position, string.Concat(array));
		Rect position2 = new Rect(20f, 600f, 200f, 25f);
		object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array2[0] = "Shield:";
		array2[1] = _iCurShield;
		array2[2] = " / ";
		array2[3] = _iMaxShield;
		GUI.TextField(position2, string.Concat(array2));
		Rect position3 = new Rect(580f, 600f, 200f, 25f);
		object[] array3 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array3[0] = "Exp:";
		array3[1] = _iCurExp;
		array3[2] = " / ";
		array3[3] = _iMaxExp;
		GUI.TextField(position3, string.Concat(array3));
		Rect position4 = new Rect(1000f, 630f, 200f, 25f);
		object[] array4 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array4[0] = "Ammo:";
		array4[1] = _iCurBullets;
		array4[2] = " / ";
		array4[3] = _iMaxBullets;
		GUI.TextField(position4, string.Concat(array4));
		GUI.TextField(new Rect(1000f, 600f, 200f, 25f), "Weapon Type:" + _curWeaponType);
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c858f0c33158b659215d28b3c0548a38a(this);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ceb073876b67631e82266e224318dc9de(this);
	}

	public virtual void c5939103e64f288dfce17db2fb4594432(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6)
	{
		_iCurShield = ca78de5e2084d6b058e6ebdc8e85d7fae;
		_iMaxShield = ce565b32ce48270d8a80781c7ab11cae6;
	}

	public virtual void c24573231c964a8e1b6c359bcdc11ac2e(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6)
	{
		_iCurHealth = ca78de5e2084d6b058e6ebdc8e85d7fae;
		_iMaxHealth = ce565b32ce48270d8a80781c7ab11cae6;
	}

	public virtual void cf2a380a4692cc5676e8aa35a6ac96305(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6)
	{
		_iCurExp = ca78de5e2084d6b058e6ebdc8e85d7fae;
		_iMaxExp = ce565b32ce48270d8a80781c7ab11cae6;
	}

	public virtual void c20894ccb970fa2a20c47d5540f4bf0fe(int ca78de5e2084d6b058e6ebdc8e85d7fae, int cd6c1d47c8a2cec3796fb541deb86e312, int c6c65a33e62768daae81c67db16e9f118, WeaponType ccc3129646b2d42ec7517a480b9cf8c9b)
	{
		int iCurBullets;
		if (ca78de5e2084d6b058e6ebdc8e85d7fae < 0)
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
			iCurBullets = 0;
		}
		else
		{
			iCurBullets = ca78de5e2084d6b058e6ebdc8e85d7fae;
		}
		_iCurBullets = iCurBullets;
		_iClipBullets = cd6c1d47c8a2cec3796fb541deb86e312;
		_iMaxBullets = c6c65a33e62768daae81c67db16e9f118;
		_curWeaponType = ccc3129646b2d42ec7517a480b9cf8c9b;
	}

	public virtual void ce97bd49017579e3133b38884c053821f(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6)
	{
		_iCurGrenades = ca78de5e2084d6b058e6ebdc8e85d7fae;
		_iMaxGrenades = ce565b32ce48270d8a80781c7ab11cae6;
	}

	public virtual void c457db9cda354860a735321a344aa0ecf(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		_strName = cd99af21e22e356018b8f72d4a7e4872a;
	}

	public virtual void c722314920476b2c350e95cac25fa5871(int cd6bb591c33b2ee3ab93e98aa43a6da63)
	{
		_iLevel = cd6bb591c33b2ee3ab93e98aa43a6da63;
	}

	public virtual void cacb0973399bda5328a4e13f27d851fdb(int cd6bb591c33b2ee3ab93e98aa43a6da63)
	{
		_iLevel = cd6bb591c33b2ee3ab93e98aa43a6da63;
	}

	public virtual void ce3841e95e779dd0c94cd831fe7d0b869(AvatarType cb5482a2a46b0f936c871f58108c762d2)
	{
		_playerClass = cb5482a2a46b0f936c871f58108c762d2;
	}

	public virtual void c59f32a9a9fe18a592073d653d06b2269(int cd31e74dcfb94f61992cc4a53880440a3, int c69dfec69714c5584671c26a3a6311e79)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "Money changed: ";
		array[1] = cd31e74dcfb94f61992cc4a53880440a3;
		array[2] = " Total money left:";
		array[3] = c69dfec69714c5584671c26a3a6311e79;
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, string.Concat(array));
	}

	public virtual void c490e1cdbd91f441f8899c3b557cbc807(bool c74232243aff1dcbf2e8fc243633bb51a)
	{
	}

	public virtual void c660501325b92420b182c10632cb9aa92(WeaponDNA c7ad992a76feafc31f8ad6e56516da24f, WeaponDNA cfe74b263a7818f4cb67012603360ce86)
	{
	}

	public virtual void ca330dd5237a52ac8e99b440a78802ff6(bool c9385a8b4aa29165e7f6c6d3bfcf4c20b)
	{
	}
}
