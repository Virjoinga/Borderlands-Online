using System;
using System.Collections.Generic;
using A;
using Core;
using DigitalOpus.MB.Core;
using UnityEngine;

public class MB2_TextureBaker : MB2_MeshBakerRoot
{
	private static bool VERBOSE;

	[HideInInspector]
	public int maxTilingBakeSize = 1024;

	[HideInInspector]
	public bool doMultiMaterial;

	[HideInInspector]
	public bool fixOutOfBoundsUVs;

	[HideInInspector]
	public Material resultMaterial;

	public MB_MultiMaterial[] resultMaterials = c6eeab63285e4b64991749bfc90da825d.c0a0cdf4a196914163f7334d9b0781a04(0);

	[HideInInspector]
	public int atlasPadding = 1;

	[HideInInspector]
	public bool resizePowerOfTwoTextures = true;

	[HideInInspector]
	public MB2_PackingAlgorithmEnum texturePackingAlgorithm;

	public List<string> customShaderPropNames = new List<string>();

	public List<GameObject> objsToMesh;

	public override List<GameObject> c1de633fcf95c62e1f3b66800c18177ab()
	{
		return objsToMesh;
	}

	public MB_AtlasesAndRects[] ce783698d9e4d4039a03b9527ffe202ce(ProgressUpdateDelegate cbac0d8652f8505d54b73629c458d217c, bool c740cd242c41a361bd76708dd4aeaf967 = false, MB_TextureCombiner.FileSaveFunction c22d08568de13a0dff8ae075341151675 = null)
	{
		if (doMultiMaterial)
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
			for (int i = 0; i < resultMaterials.Length; i++)
			{
				MB_MultiMaterial mB_MultiMaterial = resultMaterials[i];
				if (mB_MultiMaterial.combinedMaterial == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Default, "Combined Material is null please create and assign a result material.");
							return null;
						}
					}
				}
				Shader shader = mB_MultiMaterial.combinedMaterial.shader;
				for (int j = 0; j < mB_MultiMaterial.sourceMaterials.Count; j++)
				{
					if (mB_MultiMaterial.sourceMaterials[j] == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Default, "There are null entries in the list of Source Materials");
								return null;
							}
						}
					}
					if (!(shader != mB_MultiMaterial.sourceMaterials[j].shader))
					{
						continue;
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
					array[0] = "Source material ";
					array[1] = mB_MultiMaterial.sourceMaterials[j];
					array[2] = " does not use shader ";
					array[3] = shader;
					array[4] = " it may not have the required textures. If not empty textures will be generated.";
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Default, string.Concat(array));
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_0123;
					}
					continue;
					end_IL_0123:
					break;
				}
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		else
		{
			if (resultMaterial == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Default, "Combined Material is null please create and assign a result material.");
					return null;
				}
			}
			Shader shader2 = resultMaterial.shader;
			for (int k = 0; k < objsToMesh.Count; k++)
			{
				Material[] gOMaterials = MB_Utility.GetGOMaterials(objsToMesh[k]);
				foreach (Material material in gOMaterials)
				{
					if (material == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Default, string.Concat("Game object ", objsToMesh[k], " has a null material. Can't build atlases"));
								return null;
							}
						}
					}
					if (!(material.shader != shader2))
					{
						continue;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
					array2[0] = "Game object ";
					array2[1] = objsToMesh[k];
					array2[2] = " does not use shader ";
					array2[3] = shader2;
					array2[4] = " it may not have the required textures. If not empty textures will be generated.";
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Default, string.Concat(array2));
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_026c;
					}
					continue;
					end_IL_026c:
					break;
				}
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		int c36964cf41281414170f34ee68bef6c = 1;
		if (doMultiMaterial)
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
			c36964cf41281414170f34ee68bef6c = resultMaterials.Length;
		}
		MB_AtlasesAndRects[] array3 = ca1799c9b6738fc25f1a9b42fadb0716a.c0a0cdf4a196914163f7334d9b0781a04(c36964cf41281414170f34ee68bef6c);
		for (int m = 0; m < array3.Length; m++)
		{
			array3[m] = new MB_AtlasesAndRects();
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			MB_TextureCombiner mB_TextureCombiner = new MB_TextureCombiner();
			Material c7088de59e49f7108f520cf7e0bae167e = cbea7b81e65efa29a099764b7785c1976.c7088de59e49f7108f520cf7e0bae167e;
			List<Material> sourceMaterials = ce3eb729698dd08fe58b813a08449138b.c7088de59e49f7108f520cf7e0bae167e;
			for (int n = 0; n < array3.Length; n++)
			{
				if (doMultiMaterial)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					sourceMaterials = resultMaterials[n].sourceMaterials;
					c7088de59e49f7108f520cf7e0bae167e = resultMaterials[n].combinedMaterial;
				}
				else
				{
					c7088de59e49f7108f520cf7e0bae167e = resultMaterial;
				}
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Default, "Creating atlases for result material " + c7088de59e49f7108f520cf7e0bae167e);
				if (mB_TextureCombiner.combineTexturesIntoAtlases(cbac0d8652f8505d54b73629c458d217c, array3[n], c7088de59e49f7108f520cf7e0bae167e, objsToMesh, sourceMaterials, atlasPadding, customShaderPropNames, resizePowerOfTwoTextures, fixOutOfBoundsUVs, maxTilingBakeSize, c740cd242c41a361bd76708dd4aeaf967, texturePackingAlgorithm, c22d08568de13a0dff8ae075341151675))
				{
					continue;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					return null;
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				if (array3 != null)
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
					textureBakeResults.combinedMaterialInfo = array3;
					textureBakeResults.doMultiMaterial = doMultiMaterial;
					textureBakeResults.resultMaterial = resultMaterial;
					textureBakeResults.resultMaterials = resultMaterials;
					textureBakeResults.fixOutOfBoundsUVs = fixOutOfBoundsUVs;
					c5ced09467d6fc5309d13721454e44fa6(textureBakeResults);
					if (Application.isPlaying)
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
						if (doMultiMaterial)
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									continue;
								}
								break;
							}
							for (int num = 0; num < resultMaterials.Length; num++)
							{
								Material combinedMaterial = resultMaterials[num].combinedMaterial;
								Texture2D[] atlases = array3[num].atlases;
								for (int num2 = 0; num2 < atlases.Length; num2++)
								{
									combinedMaterial.SetTexture(array3[num].texPropertyNames[num2], atlases[num2]);
								}
								while (true)
								{
									switch (7)
									{
									case 0:
										break;
									default:
										goto end_IL_04a6;
									}
									continue;
									end_IL_04a6:
									break;
								}
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
						}
						else
						{
							Material material2 = resultMaterial;
							Texture2D[] atlases2 = array3[0].atlases;
							for (int num3 = 0; num3 < atlases2.Length; num3++)
							{
								material2.SetTexture(array3[0].texPropertyNames[num3], atlases2[num3]);
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
						}
					}
				}
				if (VERBOSE)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Default, "Created Atlases");
				}
				return array3;
			}
		}
	}

	public MB_AtlasesAndRects[] ce783698d9e4d4039a03b9527ffe202ce()
	{
		return ce783698d9e4d4039a03b9527ffe202ce(null);
	}

	private void c5ced09467d6fc5309d13721454e44fa6(MB2_TextureBakeResults c3f8491cd12d543b02f01e69770675b4c)
	{
		List<Material> list = new List<Material>();
		List<Rect> list2 = new List<Rect>();
		for (int i = 0; i < c3f8491cd12d543b02f01e69770675b4c.combinedMaterialInfo.Length; i++)
		{
			MB_AtlasesAndRects mB_AtlasesAndRects = c3f8491cd12d543b02f01e69770675b4c.combinedMaterialInfo[i];
			Dictionary<Material, Rect> mat2rect_map = mB_AtlasesAndRects.mat2rect_map;
			using (Dictionary<Material, Rect>.KeyCollection.Enumerator enumerator = mat2rect_map.Keys.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Material current = enumerator.Current;
					list.Add(current);
					list2.Add(mat2rect_map[current]);
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
					break;
				}
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			c3f8491cd12d543b02f01e69770675b4c.materials = list.ToArray();
			c3f8491cd12d543b02f01e69770675b4c.prefabUVRects = list2.ToArray();
			return;
		}
	}

	public void c92d46dd8dd7480febd5452d6b5c107b7(ProgressUpdateDelegate cbac0d8652f8505d54b73629c458d217c, MB_TextureCombiner.FileSaveFunction c22d08568de13a0dff8ae075341151675)
	{
		MB_AtlasesAndRects[] array = c89e1edf88b56cfe70ea344b56d0086c6.c7088de59e49f7108f520cf7e0bae167e;
		try
		{
			if (!MB2_MeshBakerRoot.c369f181a8c83d841d203d3b8dd753c4d(this, MB_ObjsToCombineTypes.dontCare))
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
				array = ce783698d9e4d4039a03b9527ffe202ce(cbac0d8652f8505d54b73629c458d217c, true, c22d08568de13a0dff8ae075341151675);
				if (array == null)
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
					MB2_MeshBakerCommon component = GetComponent<MB2_MeshBakerCommon>();
					if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
					{
						return;
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						component.textureBakeResults = textureBakeResults;
						return;
					}
				}
			}
		}
		catch (Exception message)
		{
			UnityEngine.Debug.LogError(message);
		}
		finally
		{
			if (array != null)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					foreach (MB_AtlasesAndRects mB_AtlasesAndRects in array)
					{
						if (mB_AtlasesAndRects == null)
						{
							continue;
						}
						while (true)
						{
							switch (5)
							{
							case 0:
								continue;
							}
							break;
						}
						if (mB_AtlasesAndRects.atlases == null)
						{
							continue;
						}
						while (true)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							break;
						}
						for (int j = 0; j < mB_AtlasesAndRects.atlases.Length; j++)
						{
							if (!(mB_AtlasesAndRects.atlases[j] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
							{
								continue;
							}
							while (true)
							{
								switch (3)
								{
								case 0:
									continue;
								}
								break;
							}
							MB_Utility.Destroy(mB_AtlasesAndRects.atlases[j]);
						}
						while (true)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							goto end_IL_0119;
						}
						continue;
						end_IL_0119:
						break;
					}
					break;
				}
			}
		}
	}

	public static void c06cfa4c0b8b220397c2055759c10fd60(Material c152e156f6568acd3e7001e44855e54dd, Material cd3fd8cff9444e8e69036b2b139290946)
	{
		c152e156f6568acd3e7001e44855e54dd.shader = cd3fd8cff9444e8e69036b2b139290946.shader;
		c152e156f6568acd3e7001e44855e54dd.CopyPropertiesFromMaterial(cd3fd8cff9444e8e69036b2b139290946);
		string[] shaderTexPropertyNames = MB_TextureCombiner.shaderTexPropertyNames;
		for (int i = 0; i < shaderTexPropertyNames.Length; i++)
		{
			Vector2 one = Vector2.one;
			Vector2 zero = Vector2.zero;
			if (!c152e156f6568acd3e7001e44855e54dd.HasProperty(shaderTexPropertyNames[i]))
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
			c152e156f6568acd3e7001e44855e54dd.SetTextureOffset(shaderTexPropertyNames[i], zero);
			c152e156f6568acd3e7001e44855e54dd.SetTextureScale(shaderTexPropertyNames[i], one);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}
}
