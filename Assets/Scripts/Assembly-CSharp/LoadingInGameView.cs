using A;
using UnityEngine;

internal class LoadingInGameView : BaseView
{
	protected int _instanceID;

	private GameObject _loadingIMGRoot;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		_loadingIMGRoot = Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("UI_uniSWF/LoadingResource/BOL_LoadingImg")) as GameObject;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c114035b255a7c79daf00b8613364145c(_loadingIMGRoot);
		_loadingIMGRoot.transform.position = new Vector3(-1000f, -1000f, -1000f);
	}

	public void c2374ca6e62dfcce6b68751e7ded521de(int c596ba42a2c21a67d5d3b489c87f98a3e)
	{
		_instanceID = c596ba42a2c21a67d5d3b489c87f98a3e;
		LoadingImgController loadingImgController = (LoadingImgController)_loadingIMGRoot.GetComponent("LoadingImgController");
		if (!(loadingImgController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			loadingImgController.ca7765b30cae35487f51439575e903113(c596ba42a2c21a67d5d3b489c87f98a3e);
			return;
		}
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		Object.Destroy(_loadingIMGRoot);
	}
}
