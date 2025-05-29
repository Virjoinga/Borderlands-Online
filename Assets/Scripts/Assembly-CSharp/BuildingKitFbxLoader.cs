using A;

public class BuildingKitFbxLoader : BuildingKitLoader
{
	private BuildingKit kit;

	private int nPart;

	private int nFbx;

	public BuildingKitFbxLoader(BuildingKit ca533a5812136f461c8c78f03d7298cca, int c3d9d5c376446c4ab8d2532d55e01ead6, int c95db7a9deb4987dae04d0be84b7d4e35)
	{
		kit = ca533a5812136f461c8c78f03d7298cca;
		nPart = c3d9d5c376446c4ab8d2532d55e01ead6;
		nFbx = c95db7a9deb4987dae04d0be84b7d4e35;
	}

	protected override object c38aeacc59bd560b59403945ae7996d79()
	{
		object c7088de59e49f7108f520cf7e0bae167e = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
		string ccc3a743cfeeaa8212871445f2d92eb9a = kit.c702db42bc09810f190028fd685ba6ee8(nPart, nFbx);
		return c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.ca587b9b39577370b2b93809ea02165bc(ccc3a743cfeeaa8212871445f2d92eb9a);
	}

	protected override uint c4cd4ae93a018bdeba99fff632cb3f04a()
	{
		return Utility.cf642a65627df2adf4e90330457651907(kit.cc985d3ce3968b538b964e683c1676ef0(nPart, nFbx));
	}
}
