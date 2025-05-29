using System.Collections.Generic;
using A;
using Core;
using DigitalOpus.MB.Core;
using UnityEngine;

public abstract class MB2_MeshBakerCommon : MB2_MeshBakerRoot
{
	public List<GameObject> objsToMesh;

	public bool useObjsToMeshFromTexBaker = true;

	[HideInInspector]
	public GameObject resultPrefab;

	[HideInInspector]
	public GameObject resultSceneObject;

	[HideInInspector]
	public MB_RenderType renderType;

	[HideInInspector]
	public MB2_OutputOptions outputOption;

	[HideInInspector]
	public MB2_LightmapOptions lightmapOption = MB2_LightmapOptions.ignore_UV2;

	[HideInInspector]
	public bool doNorm = true;

	[HideInInspector]
	public bool doTan = true;

	[HideInInspector]
	public bool doCol;

	[HideInInspector]
	public bool doUV = true;

	[HideInInspector]
	public bool doUV1;

	public override List<GameObject> c1de633fcf95c62e1f3b66800c18177ab()
	{
		if (objsToMesh == null)
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
			objsToMesh = new List<GameObject>();
		}
		return objsToMesh;
	}

	public void c4c122d2f54531c90155016534753fa4e(bool cba6f93f70090951862639df1bdf0f8ed)
	{
		for (int i = 0; i < objsToMesh.Count; i++)
		{
			GameObject gameObject = objsToMesh[i];
			if (!(gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				continue;
			}
			while (true)
			{
				switch (1)
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
			Renderer renderer = MB_Utility.GetRenderer(gameObject);
			if (!(renderer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				continue;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			renderer.enabled = cba6f93f70090951862639df1bdf0f8ed;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public abstract void c3526b7743e758bf0d85ba6e775467053();

	public abstract void ca900df651f664f4039e746f782ff684c();

	public abstract int c2c713e1a856c7e4508b2d7226687e1ca();

	public abstract int c223dd5fd4a0ef03848a00541e38722a2(GameObject c68eeb75ae8e0180ebe74a7f42c8bcf3f);

	public Mesh c20644a3d22dac45527e76abd8f53b31b(GameObject[] cd6132a0f568d62c52930d181eae6e436, GameObject[] c32ebe39c6803145e44ac7d08179fab27)
	{
		if (textureBakeResults == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Default, "Material Bake Results is not set.");
					return null;
				}
			}
		}
		return c20644a3d22dac45527e76abd8f53b31b(cd6132a0f568d62c52930d181eae6e436, c32ebe39c6803145e44ac7d08179fab27, true, textureBakeResults.fixOutOfBoundsUVs);
	}

	public Mesh c20644a3d22dac45527e76abd8f53b31b(GameObject[] cd6132a0f568d62c52930d181eae6e436, GameObject[] c32ebe39c6803145e44ac7d08179fab27, bool ca429fb3bdb4bebd3468256b53d663b41)
	{
		if (textureBakeResults == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Default, "Material Bake Results is not set.");
					return null;
				}
			}
		}
		return c20644a3d22dac45527e76abd8f53b31b(cd6132a0f568d62c52930d181eae6e436, c32ebe39c6803145e44ac7d08179fab27, ca429fb3bdb4bebd3468256b53d663b41, textureBakeResults.fixOutOfBoundsUVs);
	}

	public abstract Mesh c20644a3d22dac45527e76abd8f53b31b(GameObject[] cd6132a0f568d62c52930d181eae6e436, GameObject[] c32ebe39c6803145e44ac7d08179fab27, bool ca429fb3bdb4bebd3468256b53d663b41, bool c8a0dbfa05fa739e94f0dee79d145b674);

	public abstract bool c1fe589d6674ebc847031e56c3e98e288(GameObject c68eeb75ae8e0180ebe74a7f42c8bcf3f);

	public abstract void c4113537832685263bdaa6f17c94219f5(GameObject[] cd6132a0f568d62c52930d181eae6e436, bool ca571a7161dd1bcd0a0224efac9f7a757 = true);

	public abstract void c7bf42af57574bc29c352a54914d44300();

	public abstract void c7bf42af57574bc29c352a54914d44300(bool c09583c63cbfbdcda97d5d9c5557f6129, bool c7fb0aefb8f2dc14cbe94d14d6b9a1c38, bool cac39042fb4f8f11421c87908902aa57e, bool cf2a21a6fe141ff09e93f2fbde463db3f, bool c5c7840b8c213b489776e8cf829bc7ca4, bool c81ab568aadb36f0d1d090dcd90f07953, bool c1908eae885607825b17c5908a23f9a34, bool cc8163fd77ec67140e1cf8469c0185dd4, bool c47def65b102e0d279855c9f654f68bab = false);

	public abstract void cd0d50c6c9382f212d6ec3ff5627b9a6e(string cf289dc6c4260f98c7141ad293924384d, string c177c93acc35b276c847d81b563229057);

	public abstract void c308f78957ff1dcfdf14eee9aef4cbd87();
}
