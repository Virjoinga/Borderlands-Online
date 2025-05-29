using A;
using UnityEngine;

public class BuildingKitTextureLoader : BuildingKitLoader
{
	private BuildingKit kit;

	private int nPart;

	private int nFbx;

	private int nMate;

	private int nTex;

	public BuildingKitTextureLoader(BuildingKit ca533a5812136f461c8c78f03d7298cca, int c3d9d5c376446c4ab8d2532d55e01ead6, int c95db7a9deb4987dae04d0be84b7d4e35, int c999a4be83a45b3b1a487981f31b0c07a, int c5479d526034842525c9e0c6754e64cc8)
	{
		kit = ca533a5812136f461c8c78f03d7298cca;
		nPart = c3d9d5c376446c4ab8d2532d55e01ead6;
		nFbx = c95db7a9deb4987dae04d0be84b7d4e35;
		nMate = c999a4be83a45b3b1a487981f31b0c07a;
		nTex = c5479d526034842525c9e0c6754e64cc8;
	}

	protected override object c38aeacc59bd560b59403945ae7996d79()
	{
		object c7088de59e49f7108f520cf7e0bae167e = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
		string ccc3a743cfeeaa8212871445f2d92eb9a = kit.cdc42c79663ca79a71f3537492abcec13(nPart, nFbx, nMate, nTex);
		return (Texture)c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.ca587b9b39577370b2b93809ea02165bc(ccc3a743cfeeaa8212871445f2d92eb9a);
	}

	protected override uint c4cd4ae93a018bdeba99fff632cb3f04a()
	{
		return Utility.cf642a65627df2adf4e90330457651907(kit.cde9f5a234249ce753831178fa2cc0648(nPart, nFbx, nMate, nTex));
	}
}
