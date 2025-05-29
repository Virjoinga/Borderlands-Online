using A;
using UnityEngine;

public class TownHUDView : BaseView
{
	protected E_USE_TYPE _curType;

	protected Vector3 _screenPosition = Vector3.zero;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c858f0c33158b659215d28b3c0548a38a(this);
		Camera c91fcf132a3585bad3597263bc = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c91fcf132a3585bad3597263bc8937405;
		if (!(c91fcf132a3585bad3597263bc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			_screenPosition.Set(c91fcf132a3585bad3597263bc.pixelWidth / 2f, c91fcf132a3585bad3597263bc.pixelHeight / 2f, 0f);
			return;
		}
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ceb073876b67631e82266e224318dc9de(this);
		_screenPosition = Vector3.zero;
	}

	public virtual void c565fc8fc4a259a71ab4632066f71f0ea(E_USE_TYPE c2b4f43f34e21572af6ab4414f04cee36)
	{
		_curType = c2b4f43f34e21572af6ab4414f04cee36;
	}
}
