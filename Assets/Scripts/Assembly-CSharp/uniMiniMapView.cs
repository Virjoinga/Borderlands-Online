using A;
using pumpkin.display;

public class uniMiniMapView : MiniMapView
{
	protected c196099a1254db61d3be10d70e14e7422 _container;

	protected UIMapDisplayManager.UIMapRoot _mapRoot;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		_bActive = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("MiniMap.swf", "Panel_MiniMapContainer", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_bActive = true;
		_container = new c196099a1254db61d3be10d70e14e7422();
		_container.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_container);
		MovieClip childByName = cbe9ca8ddb3cdc2312e6ff8411b2db2c8.getChildByName<MovieClip>("mcMiniMapRoot");
		if (childByName == null)
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
			_mapRoot = new UIMapDisplayManager.UIMapRoot();
			_mapRoot.c4ff0d4ba3eeaed831ca975de7848acce = UIMapDisplayManager.MapCategoryTag.MiniMap;
			_mapRoot.c729bd42662457ecf184ce15af0942cbe = false;
			_mapRoot.cd61d9f244ef37bfca642c090f0dd57af = false;
			_mapRoot.c130648b59a0c8debea60aa153f844879(childByName);
			UIMapDisplayManager.c71f6ce28731edfd43c976fbd57c57bea().c79b68441494b2679b55be7197f656be8(_mapRoot);
			return;
		}
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_container);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("MiniMap.swf");
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (_container == null)
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
			if (_container.c89ef242f4744e0f1c4ffea4da8b79bc1 != null)
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
				_container.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = c8be1fcd630e5fe96821376d111325750;
			}
			if (_mapRoot == null)
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
				if (_mapRoot.c89ef242f4744e0f1c4ffea4da8b79bc1 == null)
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
					_mapRoot.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = c8be1fcd630e5fe96821376d111325750;
					return;
				}
			}
		}
	}
}
