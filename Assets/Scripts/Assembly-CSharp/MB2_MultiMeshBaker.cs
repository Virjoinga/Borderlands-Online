using A;
using Core;
using DigitalOpus.MB.Core;
using UnityEngine;

public class MB2_MultiMeshBaker : MB2_MeshBakerCommon
{
	[HideInInspector]
	public MB2_MultiMeshCombiner meshCombiner = new MB2_MultiMeshCombiner();

	public override void c3526b7743e758bf0d85ba6e775467053()
	{
		cba9435b7e992f61473aa9f495c0379c3();
		meshCombiner.ClearMesh();
	}

	public override void ca900df651f664f4039e746f782ff684c()
	{
		cba9435b7e992f61473aa9f495c0379c3();
		meshCombiner.DestroyMesh();
	}

	public override int c2c713e1a856c7e4508b2d7226687e1ca()
	{
		return meshCombiner.GetNumObjectsInCombined();
	}

	public override int c223dd5fd4a0ef03848a00541e38722a2(GameObject c68eeb75ae8e0180ebe74a7f42c8bcf3f)
	{
		return meshCombiner.GetNumVerticesFor(c68eeb75ae8e0180ebe74a7f42c8bcf3f);
	}

	public override Mesh c20644a3d22dac45527e76abd8f53b31b(GameObject[] cd6132a0f568d62c52930d181eae6e436, GameObject[] c32ebe39c6803145e44ac7d08179fab27, bool ca429fb3bdb4bebd3468256b53d663b41, bool c8a0dbfa05fa739e94f0dee79d145b674)
	{
		if (resultSceneObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			resultSceneObject = new GameObject("CombinedMesh-" + base.name);
		}
		cba9435b7e992f61473aa9f495c0379c3();
		return meshCombiner.AddDeleteGameObjects(cd6132a0f568d62c52930d181eae6e436, c32ebe39c6803145e44ac7d08179fab27, ca429fb3bdb4bebd3468256b53d663b41, c8a0dbfa05fa739e94f0dee79d145b674);
	}

	public override bool c1fe589d6674ebc847031e56c3e98e288(GameObject c68eeb75ae8e0180ebe74a7f42c8bcf3f)
	{
		return meshCombiner.CombinedMeshContains(c68eeb75ae8e0180ebe74a7f42c8bcf3f);
	}

	public override void c4113537832685263bdaa6f17c94219f5(GameObject[] cd6132a0f568d62c52930d181eae6e436, bool ca571a7161dd1bcd0a0224efac9f7a757 = true)
	{
		cba9435b7e992f61473aa9f495c0379c3();
		meshCombiner.UpdateGameObjects(cd6132a0f568d62c52930d181eae6e436, ca571a7161dd1bcd0a0224efac9f7a757);
	}

	public override void c7bf42af57574bc29c352a54914d44300()
	{
		cba9435b7e992f61473aa9f495c0379c3();
		meshCombiner.Apply();
	}

	public override void c7bf42af57574bc29c352a54914d44300(bool c09583c63cbfbdcda97d5d9c5557f6129, bool c7fb0aefb8f2dc14cbe94d14d6b9a1c38, bool cac39042fb4f8f11421c87908902aa57e, bool cf2a21a6fe141ff09e93f2fbde463db3f, bool c5c7840b8c213b489776e8cf829bc7ca4, bool c81ab568aadb36f0d1d090dcd90f07953, bool c1908eae885607825b17c5908a23f9a34, bool cc8163fd77ec67140e1cf8469c0185dd4, bool c47def65b102e0d279855c9f654f68bab = false)
	{
		cba9435b7e992f61473aa9f495c0379c3();
		meshCombiner.Apply(c09583c63cbfbdcda97d5d9c5557f6129, c7fb0aefb8f2dc14cbe94d14d6b9a1c38, cac39042fb4f8f11421c87908902aa57e, cf2a21a6fe141ff09e93f2fbde463db3f, c5c7840b8c213b489776e8cf829bc7ca4, c81ab568aadb36f0d1d090dcd90f07953, c1908eae885607825b17c5908a23f9a34, cc8163fd77ec67140e1cf8469c0185dd4, c47def65b102e0d279855c9f654f68bab);
	}

	public override void cd0d50c6c9382f212d6ec3ff5627b9a6e(string cf289dc6c4260f98c7141ad293924384d, string c177c93acc35b276c847d81b563229057)
	{
		meshCombiner.SaveMeshsToAssetDatabase(cf289dc6c4260f98c7141ad293924384d, c177c93acc35b276c847d81b563229057);
	}

	public override void c308f78957ff1dcfdf14eee9aef4cbd87()
	{
		if (renderType == MB_RenderType.skinnedMeshRenderer)
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Default, "Prefab will not be updated for skinned mesh. This is because all bones need to be included in the prefab for it to be usefull.");
					return;
				}
			}
		}
		meshCombiner.RebuildPrefab(resultPrefab);
	}

	private void cba9435b7e992f61473aa9f495c0379c3()
	{
		meshCombiner.name = base.name;
		meshCombiner.textureBakeResults = textureBakeResults;
		meshCombiner.resultSceneObject = resultSceneObject;
		meshCombiner.renderType = renderType;
		meshCombiner.outputOption = outputOption;
		meshCombiner.lightmapOption = lightmapOption;
		meshCombiner.doNorm = doNorm;
		meshCombiner.doTan = doTan;
		meshCombiner.doCol = doCol;
		meshCombiner.doUV = doUV;
		meshCombiner.doUV1 = doUV1;
	}
}
