using System;
using System.Collections.Generic;
using System.Text;
using A;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class MB_TextureCombiner
	{
		private class MeshBakerMaterialTexture
		{
			public Vector2 offset = new Vector2(0f, 0f);

			public Vector2 scale = new Vector2(1f, 1f);

			public Vector2 obUVoffset = new Vector2(0f, 0f);

			public Vector2 obUVscale = new Vector2(1f, 1f);

			public Texture2D t;

			public MeshBakerMaterialTexture()
			{
			}

			public MeshBakerMaterialTexture(Texture2D tx)
			{
				t = tx;
			}

			public MeshBakerMaterialTexture(Texture2D tx, Vector2 o, Vector2 s, Vector2 oUV, Vector2 sUV)
			{
				t = tx;
				offset = o;
				scale = s;
				obUVoffset = oUV;
				obUVscale = sUV;
			}
		}

		private class MB_TexSet
		{
			public MeshBakerMaterialTexture[] ts;

			public List<Material> mats;

			public int idealWidth;

			public int idealHeight;

			public MB_TexSet(MeshBakerMaterialTexture[] tss)
			{
				ts = tss;
				mats = new List<Material>();
			}

			public override bool Equals(object obj)
			{
				if (!(obj is MB_TexSet))
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							if (1 == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							return false;
						}
					}
				}
				MB_TexSet mB_TexSet = (MB_TexSet)obj;
				if (mB_TexSet.ts.Length != ts.Length)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							return false;
						}
					}
				}
				for (int i = 0; i < ts.Length; i++)
				{
					if (ts[i].offset != mB_TexSet.ts[i].offset)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					if (ts[i].scale != mB_TexSet.ts[i].scale)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					if (ts[i].t != mB_TexSet.ts[i].t)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					if (ts[i].obUVoffset != mB_TexSet.ts[i].obUVoffset)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					if (!(ts[i].obUVscale != mB_TexSet.ts[i].obUVscale))
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
						return false;
					}
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					return true;
				}
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		public delegate void FileSaveFunction(string pth, byte[] bytes);

		private static bool VERBOSE = false;

		public static string[] shaderTexPropertyNames;

		private List<Texture2D> _temporaryTextures = new List<Texture2D>();

		private List<Texture2D> _texturesWithReadWriteFlagSet = new List<Texture2D>();

		static MB_TextureCombiner()
		{
			string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(14);
			array[0] = "_MainTex";
			array[1] = "_BumpMap";
			array[2] = "_Normal";
			array[3] = "_BumpSpecMap";
			array[4] = "_DecalTex";
			array[5] = "_Detail";
			array[6] = "_GlossMap";
			array[7] = "_Illum";
			array[8] = "_LightTextureB0";
			array[9] = "_ParallaxMap";
			array[10] = "_ShadowOffset";
			array[11] = "_TranslucencyMap";
			array[12] = "_SpecMap";
			array[13] = "_TranspMap";
			shaderTexPropertyNames = array;
		}

		public bool combineTexturesIntoAtlases(ProgressUpdateDelegate progressInfo, MB_AtlasesAndRects results, Material resultMaterial, List<GameObject> objsToMesh, List<Material> sourceMaterials, int atlasPadding, List<string> customShaderPropNames, bool resizePowerOfTwoTextures, bool fixOutOfBoundsUVs, int maxTilingBakeSize, bool saveAtlasesAsAssets = false, MB2_PackingAlgorithmEnum packingAlgorithm = MB2_PackingAlgorithmEnum.UnitysPackTextures, FileSaveFunction fileSaveFunction = null)
		{
			return _combineTexturesIntoAtlases(progressInfo, results, resultMaterial, objsToMesh, sourceMaterials, atlasPadding, customShaderPropNames, resizePowerOfTwoTextures, fixOutOfBoundsUVs, maxTilingBakeSize, saveAtlasesAsAssets, fileSaveFunction, packingAlgorithm);
		}

		private bool _collectPropertyNames(Material resultMaterial, List<string> customShaderPropNames, List<string> texPropertyNames)
		{
			for (int i = 0; i < texPropertyNames.Count; i++)
			{
				string text = customShaderPropNames.Find((string x) => x.Equals(texPropertyNames[i]));
				if (text == null)
				{
					continue;
				}
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
				customShaderPropNames.Remove(text);
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				if (resultMaterial == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							UnityEngine.Debug.LogError("Please assign a result material. The combined mesh will use this material.");
							return false;
						}
					}
				}
				string text2 = string.Empty;
				for (int j = 0; j < shaderTexPropertyNames.Length; j++)
				{
					if (!resultMaterial.HasProperty(shaderTexPropertyNames[j]))
					{
						continue;
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
					text2 = text2 + ", " + shaderTexPropertyNames[j];
					if (!texPropertyNames.Contains(shaderTexPropertyNames[j]))
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
						texPropertyNames.Add(shaderTexPropertyNames[j]);
					}
					if (resultMaterial.GetTextureOffset(shaderTexPropertyNames[j]) != new Vector2(0f, 0f))
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
						UnityEngine.Debug.LogWarning("Result material has non-zero offset. This is probably incorrect.");
					}
					if (!(resultMaterial.GetTextureScale(shaderTexPropertyNames[j]) != new Vector2(1f, 1f)))
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
					UnityEngine.Debug.LogWarning("Result material should probably have tiling of 1,1");
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					for (int k = 0; k < customShaderPropNames.Count; k++)
					{
						if (resultMaterial.HasProperty(customShaderPropNames[k]))
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
							text2 = text2 + ", " + customShaderPropNames[k];
							texPropertyNames.Add(customShaderPropNames[k]);
							if (resultMaterial.GetTextureOffset(customShaderPropNames[k]) != new Vector2(0f, 0f))
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									break;
								}
								UnityEngine.Debug.LogWarning("Result material has non-zero offset. This is probably incorrect.");
							}
							if (!(resultMaterial.GetTextureScale(customShaderPropNames[k]) != new Vector2(1f, 1f)))
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
							UnityEngine.Debug.LogWarning("Result material should probably have tiling of 1,1.");
						}
						else
						{
							UnityEngine.Debug.LogWarning("Result material shader does not use property " + customShaderPropNames[k] + " in the list of custom shader property names");
						}
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						return true;
					}
				}
			}
		}

		private bool _combineTexturesIntoAtlases(ProgressUpdateDelegate progressInfo, MB_AtlasesAndRects results, Material resultMaterial, List<GameObject> objsToMesh, List<Material> sourceMaterials, int atlasPadding, List<string> customShaderPropNames, bool resizePowerOfTwoTextures, bool fixOutOfBoundsUVs, int maxTilingBakeSize, bool saveAtlasesAsAssets, FileSaveFunction fileSaveFunction, MB2_PackingAlgorithmEnum packingAlgorithm)
		{
			bool result = false;
			try
			{
				_temporaryTextures.Clear();
				_texturesWithReadWriteFlagSet.Clear();
				if (objsToMesh == null)
				{
					goto IL_0045;
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (objsToMesh.Count == 0)
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
					goto IL_0045;
				}
				if (atlasPadding < 0)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						UnityEngine.Debug.LogError("Atlas padding must be zero or greater.");
						return false;
					}
				}
				if (maxTilingBakeSize < 2)
				{
					goto IL_009a;
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
				if (maxTilingBakeSize > 4096)
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
					goto IL_009a;
				}
				if (progressInfo != null)
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
					progressInfo("Collecting textures for " + objsToMesh.Count + " meshes.", 0.01f);
				}
				List<string> texPropertyNames = new List<string>();
				if (!_collectPropertyNames(resultMaterial, customShaderPropNames, texPropertyNames))
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						return false;
					}
				}
				result = __combineTexturesIntoAtlases(progressInfo, results, resultMaterial, texPropertyNames, objsToMesh, sourceMaterials, atlasPadding, resizePowerOfTwoTextures, fixOutOfBoundsUVs, maxTilingBakeSize, saveAtlasesAsAssets, fileSaveFunction, packingAlgorithm);
				goto end_IL_0002;
				IL_009a:
				UnityEngine.Debug.LogError("Invalid value for max tiling bake size.");
				return false;
				IL_0045:
				UnityEngine.Debug.LogError("No meshes to combine. Please assign some meshes to combine.");
				return false;
				end_IL_0002:;
			}
			catch (MissingReferenceException message)
			{
				UnityEngine.Debug.LogError("Creating atlases failed a MissingReferenceException was thrown. This is normally only happens when trying to create very large atlases and Unity is running out of Memory. Try changing the 'Texture Packer' to a different option, it may work with an alternate packer. This error is sometimes intermittant. Try baking again.");
				UnityEngine.Debug.LogError(message);
			}
			catch (Exception message2)
			{
				UnityEngine.Debug.LogError(message2);
			}
			finally
			{
				_destroyTemporaryTextures();
				_SetReadFlags(progressInfo);
			}
			return result;
		}

		private bool __combineTexturesIntoAtlases(ProgressUpdateDelegate progressInfo, MB_AtlasesAndRects results, Material resultMaterial, List<string> texPropertyNames, List<GameObject> objsToMesh, List<Material> sourceMaterials, int atlasPadding, bool resizePowerOfTwoTextures, bool fixOutOfBoundsUVs, int maxTilingBakeSize, bool saveAtlasesAsAssets, FileSaveFunction fileSaveFunction, MB2_PackingAlgorithmEnum packingAlgorithm)
		{
			int count = texPropertyNames.Count;
			bool flag = false;
			List<MB_TexSet> list = new List<MB_TexSet>();
			if (VERBOSE)
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
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
				array[0] = "__combineTexturesIntoAtlases atlases:";
				array[1] = texPropertyNames.Count;
				array[2] = " objsToMesh:";
				array[3] = objsToMesh.Count;
				array[4] = " fixOutOfBoundsUVs:";
				array[5] = fixOutOfBoundsUVs;
				UnityEngine.Debug.Log(string.Concat(array));
			}
			Rect c36964cf41281414170f34ee68bef6c = default(Rect);
			for (int i = 0; i < objsToMesh.Count; i++)
			{
				GameObject gameObject = objsToMesh[i];
				if (VERBOSE)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					UnityEngine.Debug.Log("Collecting textures for object " + gameObject);
				}
				if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							UnityEngine.Debug.LogError("The list of objects to mesh contained nulls.");
							return false;
						}
					}
				}
				Mesh mesh = MB_Utility.GetMesh(gameObject);
				if (mesh == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							UnityEngine.Debug.LogError("Object " + gameObject.name + " in the list of objects to mesh has no mesh.");
							return false;
						}
					}
				}
				Material[] gOMaterials = MB_Utility.GetGOMaterials(gameObject);
				if (gOMaterials == null)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							UnityEngine.Debug.LogError("Object " + gameObject.name + " in the list of objects has no materials.");
							return false;
						}
					}
				}
				for (int j = 0; j < gOMaterials.Length; j++)
				{
					Material material = gOMaterials[j];
					if (sourceMaterials != null)
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
						if (!sourceMaterials.Contains(material))
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
							continue;
						}
					}
					cb3c9a6938f5f6d2ba586599d5e174fcf.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
					bool flag2 = MB_Utility.hasOutOfBoundsUVs(mesh, ref c36964cf41281414170f34ee68bef6c, j);
					int num;
					if (!flag)
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
						num = (flag2 ? 1 : 0);
					}
					else
					{
						num = 1;
					}
					flag = (byte)num != 0;
					if (material.name.Contains("(Instance)"))
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								UnityEngine.Debug.LogError("The sharedMaterial on object " + gameObject.name + " has been 'Instanced'. This was probably caused by a script accessing the meshRender.material property in the editor.  The material to UV Rectangle mapping will be incorrect. To fix this recreate the object from its prefab or re-assign its material from the correct asset.");
								return false;
							}
						}
					}
					if (fixOutOfBoundsUVs)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						if (!MB_Utility.validateOBuvsMultiMaterial(gOMaterials))
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
							UnityEngine.Debug.LogWarning("Object " + gameObject.name + " uses the same material on multiple submeshes. This may generate strange results especially when used with fix out of bounds uvs. Try duplicating the material.");
						}
					}
					if (progressInfo != null)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						progressInfo("Collecting textures for " + material, 0.01f);
					}
					MeshBakerMaterialTexture[] array2 = new MeshBakerMaterialTexture[texPropertyNames.Count];
					for (int k = 0; k < texPropertyNames.Count; k++)
					{
						Texture2D texture2D = c9e48915b2a8c6753d0b1a12e50ad1d27.c7088de59e49f7108f520cf7e0bae167e;
						Vector2 s = Vector2.one;
						Vector2 o = Vector2.zero;
						Vector2 sUV = Vector2.one;
						Vector2 oUV = Vector2.zero;
						if (material.HasProperty(texPropertyNames[k]))
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
							Texture texture = material.GetTexture(texPropertyNames[k]);
							if (texture != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									break;
								}
								if (!(texture is Texture2D))
								{
									UnityEngine.Debug.LogError("Object " + gameObject.name + " in the list of objects to mesh uses a Texture that is not a Texture2D. Cannot build atlases.");
									return false;
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
								texture2D = (Texture2D)texture;
								TextureFormat format = texture2D.format;
								if (format != TextureFormat.ARGB32)
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
									if (format != TextureFormat.RGBA32)
									{
										while (true)
										{
											switch (1)
											{
											case 0:
												continue;
											}
											break;
										}
										if (format != TextureFormat.BGRA32)
										{
											while (true)
											{
												switch (5)
												{
												case 0:
													continue;
												}
												break;
											}
											if (format != TextureFormat.RGB24)
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
												if (format != TextureFormat.Alpha8)
												{
													object[] array3 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(7);
													array3[0] = "Object ";
													array3[1] = gameObject.name;
													array3[2] = " in the list of objects to mesh uses Texture ";
													array3[3] = texture2D.name;
													array3[4] = " uses format ";
													array3[5] = format;
													array3[6] = " that is not in: ARGB32, RGBA32, BGRA32, RGB24, Alpha8 or DXT. These textures cannot be resized at runtime. Try changing texture format. If format says 'compressed' try changing it to 'truecolor'";
													UnityEngine.Debug.LogError(string.Concat(array3));
													return false;
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
										}
									}
								}
							}
							o = material.GetTextureOffset(texPropertyNames[k]);
							s = material.GetTextureScale(texPropertyNames[k]);
						}
						if (texture2D == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							UnityEngine.Debug.LogWarning("No texture selected for " + texPropertyNames[k] + " in object " + objsToMesh[i].name);
						}
						if (fixOutOfBoundsUVs)
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
							if (flag2)
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
								sUV = new Vector2(c36964cf41281414170f34ee68bef6c.width, c36964cf41281414170f34ee68bef6c.height);
								oUV = new Vector2(c36964cf41281414170f34ee68bef6c.x, c36964cf41281414170f34ee68bef6c.y);
							}
						}
						array2[k] = new MeshBakerMaterialTexture(texture2D, o, s, oUV, sUV);
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					MB_TexSet setOfTexs = new MB_TexSet(array2);
					MB_TexSet mB_TexSet = list.Find((MB_TexSet x) => x.Equals(setOfTexs));
					if (mB_TexSet != null)
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
						setOfTexs = mB_TexSet;
					}
					else
					{
						list.Add(setOfTexs);
					}
					if (setOfTexs.mats.Contains(material))
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
					setOfTexs.mats.Add(material);
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						goto end_IL_058e;
					}
					continue;
					end_IL_058e:
					break;
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				int num2 = atlasPadding;
				if (list.Count == 1)
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
					UnityEngine.Debug.Log("All objects use the same textures.");
					num2 = 0;
				}
				int num3 = 0;
				while (num3 < list.Count)
				{
					MB_TexSet mB_TexSet2 = list[num3];
					mB_TexSet2.idealWidth = 1;
					mB_TexSet2.idealHeight = 1;
					int num4 = 1;
					int num5 = 1;
					for (int l = 0; l < mB_TexSet2.ts.Length; l++)
					{
						MeshBakerMaterialTexture meshBakerMaterialTexture = mB_TexSet2.ts[l];
						if (!meshBakerMaterialTexture.scale.Equals(Vector2.one))
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
							object[] array4 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
							array4[0] = "Texture ";
							array4[1] = meshBakerMaterialTexture.t;
							array4[2] = "is tiled by ";
							array4[3] = meshBakerMaterialTexture.scale;
							array4[4] = " tiling will be baked into a texture with maxSize:";
							array4[5] = maxTilingBakeSize;
							UnityEngine.Debug.LogWarning(string.Concat(array4));
						}
						if (!meshBakerMaterialTexture.obUVscale.Equals(Vector2.one))
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
							object[] array5 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
							array5[0] = "Texture ";
							array5[1] = meshBakerMaterialTexture.t;
							array5[2] = "has out of bounds UVs that effectively tile by ";
							array5[3] = meshBakerMaterialTexture.obUVscale;
							array5[4] = " tiling will be baked into a texture with maxSize:";
							array5[5] = maxTilingBakeSize;
							UnityEngine.Debug.LogWarning(string.Concat(array5));
						}
						if (!(meshBakerMaterialTexture.t != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						Vector2 adjustedForScaleAndOffset2Dimensions = getAdjustedForScaleAndOffset2Dimensions(meshBakerMaterialTexture, fixOutOfBoundsUVs, maxTilingBakeSize);
						num4 = (int)adjustedForScaleAndOffset2Dimensions.x;
						num5 = (int)adjustedForScaleAndOffset2Dimensions.y;
						if (meshBakerMaterialTexture.t.width * meshBakerMaterialTexture.t.height <= num4 * num5)
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
						num4 = meshBakerMaterialTexture.t.width;
						num5 = meshBakerMaterialTexture.t.height;
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						if (resizePowerOfTwoTextures)
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
							if (IsPowerOfTwo(num4))
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
								num4 -= num2 * 2;
							}
							if (IsPowerOfTwo(num5))
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
								num5 -= num2 * 2;
							}
							if (num4 < 1)
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
								num4 = 1;
							}
							if (num5 < 1)
							{
								while (true)
								{
									switch (1)
									{
									case 0:
										continue;
									}
									break;
								}
								num5 = 1;
							}
						}
						mB_TexSet2.idealWidth = num4;
						mB_TexSet2.idealHeight = num5;
						num3++;
						break;
					}
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					StringBuilder stringBuilder = new StringBuilder();
					if (count > 0)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								continue;
							}
							break;
						}
						stringBuilder = new StringBuilder();
						stringBuilder.AppendLine("Report");
						int num6 = 0;
						while (num6 < list.Count)
						{
							MB_TexSet mB_TexSet3 = list[num6];
							stringBuilder.AppendLine("----------");
							StringBuilder stringBuilder2 = stringBuilder;
							object[] array6 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
							array6[0] = "This set of textures will be resized to:";
							array6[1] = mB_TexSet3.idealWidth;
							array6[2] = "x";
							array6[3] = mB_TexSet3.idealHeight;
							array6[4] = "\n";
							stringBuilder2.Append(string.Concat(array6));
							for (int m = 0; m < mB_TexSet3.ts.Length; m++)
							{
								if (mB_TexSet3.ts[m].t != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
									StringBuilder stringBuilder3 = stringBuilder;
									object[] array7 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(9);
									array7[0] = "   [";
									array7[1] = texPropertyNames[m];
									array7[2] = " ";
									array7[3] = mB_TexSet3.ts[m].t.name;
									array7[4] = " ";
									array7[5] = mB_TexSet3.ts[m].t.width;
									array7[6] = "x";
									array7[7] = mB_TexSet3.ts[m].t.height;
									array7[8] = "]\n";
									stringBuilder3.Append(string.Concat(array7));
								}
								else
								{
									stringBuilder.Append("   [" + texPropertyNames[m] + " null a blank texture will be created]\n");
								}
							}
							while (true)
							{
								switch (2)
								{
								case 0:
									continue;
								}
								stringBuilder.AppendLine(string.Empty);
								stringBuilder.Append("Materials using:");
								for (int n = 0; n < mB_TexSet3.mats.Count; n++)
								{
									stringBuilder.Append(mB_TexSet3.mats[n].name + ", ");
								}
								while (true)
								{
									switch (7)
									{
									case 0:
										break;
									default:
										goto end_IL_0a7e;
									}
									continue;
									end_IL_0a7e:
									break;
								}
								stringBuilder.AppendLine(string.Empty);
								num6++;
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
					if (progressInfo != null)
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
						progressInfo("Creating txture atlases.", 0.1f);
					}
					GC.Collect();
					Texture2D[] array8 = c8f5fd54709f3e2dd3e1fc487ade81e68.c0a0cdf4a196914163f7334d9b0781a04(count);
					Rect[] array9;
					if (packingAlgorithm == MB2_PackingAlgorithmEnum.UnitysPackTextures)
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
						array9 = __CreateAtlasesUnityTexturePacker(progressInfo, count, list, fixOutOfBoundsUVs, maxTilingBakeSize, num2, saveAtlasesAsAssets, texPropertyNames, resultMaterial, fileSaveFunction, array8);
					}
					else
					{
						array9 = __CreateAtlasesMBTexturePacker(progressInfo, count, list, fixOutOfBoundsUVs, maxTilingBakeSize, num2, saveAtlasesAsAssets, texPropertyNames, resultMaterial, fileSaveFunction, array8);
					}
					if (progressInfo != null)
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
						progressInfo("Building Report", 0.7f);
					}
					StringBuilder stringBuilder4 = new StringBuilder();
					stringBuilder4.AppendLine("---- Atlases ------");
					for (int num7 = 0; num7 < count; num7++)
					{
						if (!(array8[num7] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						object[] array10 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
						array10[0] = "Created Atlas For: ";
						array10[1] = texPropertyNames[num7];
						array10[2] = " h=";
						array10[3] = array8[num7].height;
						array10[4] = " w=";
						array10[5] = array8[num7].width;
						stringBuilder4.AppendLine(string.Concat(array10));
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						stringBuilder.Append(stringBuilder4.ToString());
						Dictionary<Material, Rect> dictionary = new Dictionary<Material, Rect>();
						for (int num8 = 0; num8 < list.Count; num8++)
						{
							List<Material> mats = list[num8].mats;
							for (int num9 = 0; num9 < mats.Count; num9++)
							{
								if (dictionary.ContainsKey(mats[num9]))
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
								dictionary.Add(mats[num9], array9[num8]);
							}
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									goto end_IL_0c8c;
								}
								continue;
								end_IL_0c8c:
								break;
							}
						}
						while (true)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							results.atlases = array8;
							results.texPropertyNames = texPropertyNames.ToArray();
							results.mat2rect_map = dictionary;
							if (progressInfo != null)
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
								progressInfo("Restoring Texture Formats & Read Flags", 0.8f);
							}
							_destroyTemporaryTextures();
							_SetReadFlags(progressInfo);
							if (stringBuilder != null)
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
								UnityEngine.Debug.Log(stringBuilder.ToString());
							}
							return true;
						}
					}
				}
			}
		}

		private Rect[] __CreateAtlasesMBTexturePacker(ProgressUpdateDelegate progressInfo, int numAtlases, List<MB_TexSet> distinctMaterialTextures, bool fixOutOfBoundsUVs, int maxTilingBakeSize, int _padding, bool saveAtlasesAsAssets, List<string> texPropertyNames, Material resultMaterial, FileSaveFunction fileSaveFunction, Texture2D[] atlases)
		{
			List<Vector2> list = new List<Vector2>();
			for (int i = 0; i < distinctMaterialTextures.Count; i++)
			{
				list.Add(new Vector2(distinctMaterialTextures[i].idealWidth, distinctMaterialTextures[i].idealHeight));
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
				MB2_TexturePacker mB2_TexturePacker = new MB2_TexturePacker();
				int outW = 1;
				int outH = 1;
				int num = 4096;
				if (Application.platform == RuntimePlatform.Android)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					num = 2048;
				}
				if (Application.platform == RuntimePlatform.IPhonePlayer)
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
					num = 2048;
				}
				if (Application.platform == RuntimePlatform.WindowsWebPlayer)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					num = 2048;
				}
				if (Application.platform == RuntimePlatform.OSXWebPlayer)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					num = 2048;
				}
				Rect[] rects = mB2_TexturePacker.GetRects(list, num, _padding, out outW, out outH);
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(7);
				array[0] = "Generated atlas will be ";
				array[1] = outW;
				array[2] = "x";
				array[3] = outH;
				array[4] = " (Max atlas size for platform: ";
				array[5] = num;
				array[6] = ")";
				UnityEngine.Debug.Log(string.Concat(array));
				int num2 = 0;
				while (num2 < numAtlases)
				{
					GC.Collect();
					if (progressInfo != null)
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
						progressInfo("Creating Atlas '" + texPropertyNames[num2] + "'", 0.01f);
					}
					Color[] array2 = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(outW * outH);
					for (int j = 0; j < array2.Length; j++)
					{
						array2[j] = Color.clear;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						for (int num3 = 0; num3 < distinctMaterialTextures.Count; num3++)
						{
							Rect rect = rects[num3];
							Texture2D t = distinctMaterialTextures[num3].ts[num2].t;
							int targX = Mathf.RoundToInt(rect.x * (float)outW);
							int targY = Mathf.RoundToInt(rect.y * (float)outH);
							int num4 = Mathf.RoundToInt(rect.width * (float)outW);
							int num5 = Mathf.RoundToInt(rect.height * (float)outH);
							if (num4 != 0)
							{
								while (true)
								{
									switch (1)
									{
									case 0:
										continue;
									}
									break;
								}
								if (num5 != 0)
								{
									goto IL_0265;
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
							UnityEngine.Debug.LogError("Image in atlas has no height or width");
							goto IL_0265;
							IL_0265:
							setReadWriteFlag(t, true, true);
							if (progressInfo != null)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									break;
								}
								progressInfo(string.Concat("Copying to atlas: '", distinctMaterialTextures[num3].ts[num2].t, "'"), 0.02f);
							}
							CopyScaledAndTiledToAtlas(distinctMaterialTextures[num3].ts[num2], targX, targY, num4, num5, fixOutOfBoundsUVs, maxTilingBakeSize, array2, outW);
						}
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							if (progressInfo != null)
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
								progressInfo("Applying changes to atlas: '" + texPropertyNames[num2] + "'", 0.03f);
							}
							Texture2D texture2D = new Texture2D(outW, outH, TextureFormat.ARGB32, true);
							texture2D.name = "MB_TextureCombiner_atlas";
							texture2D.SetPixels(array2);
							texture2D.Apply();
							if (VERBOSE)
							{
								while (true)
								{
									switch (1)
									{
									case 0:
										continue;
									}
									break;
								}
								object[] array3 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
								array3[0] = "Saving atlas ";
								array3[1] = texPropertyNames[num2];
								array3[2] = " w=";
								array3[3] = texture2D.width;
								array3[4] = " h=";
								array3[5] = texture2D.height;
								UnityEngine.Debug.Log(string.Concat(array3));
							}
							atlases[num2] = texture2D;
							if (progressInfo != null)
							{
								while (true)
								{
									switch (1)
									{
									case 0:
										continue;
									}
									break;
								}
								progressInfo("Saving atlas: '" + texPropertyNames[num2] + "'", 0.04f);
							}
							if (saveAtlasesAsAssets)
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
								_saveAtlasToAssetDatabase(atlases[num2], texPropertyNames[num2], num2, resultMaterial, fileSaveFunction);
							}
							_destroyTemporaryTextures();
							num2++;
							break;
						}
						break;
					}
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					return rects;
				}
			}
		}

		private Rect[] __CreateAtlasesUnityTexturePacker(ProgressUpdateDelegate progressInfo, int numAtlases, List<MB_TexSet> distinctMaterialTextures, bool fixOutOfBoundsUVs, int maxTilingBakeSize, int _padding, bool saveAtlasesAsAssets, List<string> texPropertyNames, Material resultMaterial, FileSaveFunction fileSaveFunction, Texture2D[] atlases)
		{
			long num = 0L;
			int w = 1;
			int h = 1;
			Rect[] array = c3faa267691c46e5ea255de375490983a.c7088de59e49f7108f520cf7e0bae167e;
			int num2 = 0;
			while (num2 < numAtlases)
			{
				if (VERBOSE)
				{
					while (true)
					{
						switch (5)
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
					object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
					array2[0] = "Beginning loop ";
					array2[1] = num2;
					array2[2] = " num temporary textures ";
					array2[3] = _temporaryTextures.Count;
					UnityEngine.Debug.Log(string.Concat(array2));
				}
				MB_TexSet mB_TexSet;
				Texture2D texture2D;
				for (int i = 0; i < distinctMaterialTextures.Count; mB_TexSet.ts[num2].t = texture2D, i++)
				{
					mB_TexSet = distinctMaterialTextures[i];
					int idealWidth = mB_TexSet.idealWidth;
					int idealHeight = mB_TexSet.idealHeight;
					texture2D = mB_TexSet.ts[num2].t;
					if (texture2D == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						texture2D = (mB_TexSet.ts[num2].t = _createTemporaryTexture(idealWidth, idealHeight, TextureFormat.ARGB32, true));
					}
					if (progressInfo != null)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						progressInfo("Adjusting for scale and offset " + texture2D, 0.01f);
					}
					setReadWriteFlag(texture2D, true, true);
					texture2D = getAdjustedForScaleAndOffset2(mB_TexSet.ts[num2], fixOutOfBoundsUVs, maxTilingBakeSize);
					if (texture2D.width == idealWidth)
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
						if (texture2D.height == idealHeight)
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
					}
					if (progressInfo != null)
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
						progressInfo(string.Concat("Resizing texture '", texture2D, "'"), 0.01f);
					}
					if (VERBOSE)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						object[] array3 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(10);
						array3[0] = "Copying and resizing texture ";
						array3[1] = texPropertyNames[num2];
						array3[2] = " from ";
						array3[3] = texture2D.width;
						array3[4] = "x";
						array3[5] = texture2D.height;
						array3[6] = " to ";
						array3[7] = idealWidth;
						array3[8] = "x";
						array3[9] = idealHeight;
						UnityEngine.Debug.Log(string.Concat(array3));
					}
					setReadWriteFlag(texture2D, true, true);
					texture2D = _resizeTexture(texture2D, idealWidth, idealHeight);
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					Texture2D[] array4 = c8f5fd54709f3e2dd3e1fc487ade81e68.c0a0cdf4a196914163f7334d9b0781a04(distinctMaterialTextures.Count);
					for (int j = 0; j < distinctMaterialTextures.Count; j++)
					{
						Texture2D t = distinctMaterialTextures[j].ts[num2].t;
						num += t.width * t.height;
						array4[j] = t;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						if (Math.Sqrt(num) > 3500.0)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									continue;
								}
								break;
							}
							UnityEngine.Debug.LogWarning("The maximum possible atlas size is 4096. Textures may be shrunk");
						}
						atlases[num2] = new Texture2D(1, 1, TextureFormat.ARGB32, true);
						atlases[num2].name = "MB_TextureCombiner_atlases" + num2;
						if (progressInfo != null)
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
							progressInfo("Packing texture atlas " + texPropertyNames[num2], 0.25f);
						}
						if (num2 == 0)
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
							if (progressInfo != null)
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
								progressInfo("Estimated min size of atlases: " + Math.Sqrt(num).ToString("F0"), 0.1f);
							}
							UnityEngine.Debug.Log("Estimated atlas minimum size:" + Math.Sqrt(num).ToString("F0"));
							_addWatermark(array4);
							if (distinctMaterialTextures.Count == 1)
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
								Rect[] array5 = ceb2dc13fc3d1610632a74802c9d18d10.c0a0cdf4a196914163f7334d9b0781a04(1);
								array5[0] = new Rect(0f, 0f, 1f, 1f);
								array = array5;
								atlases[num2] = _copyTexturesIntoAtlas(array4, _padding, array, array4[0].width, array4[0].height);
							}
							else
							{
								int maximumAtlasSize = 4096;
								array = atlases[num2].PackTextures(array4, _padding, maximumAtlasSize, false);
							}
							object[] array6 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
							array6[0] = "After pack textures atlas size ";
							array6[1] = atlases[num2].width;
							array6[2] = " ";
							array6[3] = atlases[num2].height;
							UnityEngine.Debug.Log(string.Concat(array6));
							w = atlases[num2].width;
							h = atlases[num2].height;
							atlases[num2].Apply();
						}
						else
						{
							if (progressInfo != null)
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
								progressInfo("Copying Textures Into: " + texPropertyNames[num2], 0.1f);
							}
							atlases[num2] = _copyTexturesIntoAtlas(array4, _padding, array, w, h);
						}
						if (saveAtlasesAsAssets)
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
							_saveAtlasToAssetDatabase(atlases[num2], texPropertyNames[num2], num2, resultMaterial, fileSaveFunction);
						}
						_destroyTemporaryTextures();
						GC.Collect();
						num2++;
						break;
					}
					break;
				}
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				return array;
			}
		}

		private void _addWatermark(Texture2D[] texToPack)
		{
		}

		private Texture2D _addWatermark(Texture2D texToPack)
		{
			return texToPack;
		}

		private Texture2D _copyTexturesIntoAtlas(Texture2D[] texToPack, int padding, Rect[] rs, int w, int h)
		{
			Texture2D texture2D = new Texture2D(w, h, TextureFormat.ARGB32, true);
			texture2D.name = "MB_TextureCombiner_ta";
			MB_Utility.setSolidColor(texture2D, Color.clear);
			for (int i = 0; i < rs.Length; i++)
			{
				Rect rect = rs[i];
				Texture2D texture2D2 = texToPack[i];
				int x = Mathf.RoundToInt(rect.x * (float)w);
				int y = Mathf.RoundToInt(rect.y * (float)h);
				int num = Mathf.RoundToInt(rect.width * (float)w);
				int num2 = Mathf.RoundToInt(rect.height * (float)h);
				if (texture2D2.width != num)
				{
					while (true)
					{
						switch (5)
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
					if (texture2D2.height != num2)
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
						texture2D2 = MB_Utility.resampleTexture(texture2D2, num, num2);
						_temporaryTextures.Add(texture2D2);
					}
				}
				texture2D.SetPixels(x, y, num, num2, texture2D2.GetPixels());
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				texture2D.Apply();
				return texture2D;
			}
		}

		private bool IsPowerOfTwo(int x)
		{
			return (x & (x - 1)) == 0;
		}

		private void setReadWriteFlag(Texture2D tx, bool isReadable, bool addToList)
		{
		}

		private void setTextureSize(Texture2D tx)
		{
		}

		private bool _isCompressed(Texture2D tx)
		{
			return false;
		}

		private Vector2 getAdjustedForScaleAndOffset2Dimensions(MeshBakerMaterialTexture source, bool fixOutOfBoundsUVs, int maxSize)
		{
			if (source.offset.x == 0f)
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
				if (source.offset.y == 0f)
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
					if (source.scale.x == 1f)
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
						if (source.scale.y == 1f)
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
							if (!fixOutOfBoundsUVs)
							{
								return new Vector2(source.t.width, source.t.height);
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
							if (source.obUVoffset.x == 0f)
							{
								while (true)
								{
									switch (1)
									{
									case 0:
										continue;
									}
									break;
								}
								if (source.obUVoffset.y == 0f)
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
									if (source.obUVscale.x == 1f)
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
										if (source.obUVscale.y == 1f)
										{
											while (true)
											{
												switch (6)
												{
												case 0:
													break;
												default:
													return new Vector2(source.t.width, source.t.height);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			if (VERBOSE)
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
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
				array[0] = "getAdjustedForScaleAndOffset2Dimensions: ";
				array[1] = source.t;
				array[2] = " ";
				array[3] = source.obUVoffset;
				array[4] = " ";
				array[5] = source.obUVscale;
				UnityEngine.Debug.Log(string.Concat(array));
			}
			float num = (float)source.t.width * source.scale.x;
			float num2 = (float)source.t.height * source.scale.y;
			if (fixOutOfBoundsUVs)
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
				num *= source.obUVscale.x;
				num2 *= source.obUVscale.y;
			}
			if (num > (float)maxSize)
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
				num = maxSize;
			}
			if (num2 > (float)maxSize)
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
				num2 = maxSize;
			}
			if (num < 1f)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				num = 1f;
			}
			if (num2 < 1f)
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
				num2 = 1f;
			}
			return new Vector2(num, num2);
		}

		private Texture2D getAdjustedForScaleAndOffset2(MeshBakerMaterialTexture source, bool fixOutOfBoundsUVs, int maxSize)
		{
			if (source.offset.x == 0f)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (source.offset.y == 0f)
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
					if (source.scale.x == 1f)
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
						if (source.scale.y == 1f)
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
							if (!fixOutOfBoundsUVs)
							{
								return source.t;
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
							if (source.obUVoffset.x == 0f)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									break;
								}
								if (source.obUVoffset.y == 0f)
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
									if (source.obUVscale.x == 1f)
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
										if (source.obUVscale.y == 1f)
										{
											while (true)
											{
												switch (4)
												{
												case 0:
													break;
												default:
													return source.t;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			Vector2 adjustedForScaleAndOffset2Dimensions = getAdjustedForScaleAndOffset2Dimensions(source, fixOutOfBoundsUVs, maxSize);
			if (VERBOSE)
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
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
				array[0] = "getAdjustedForScaleAndOffset2: ";
				array[1] = source.t;
				array[2] = " ";
				array[3] = source.obUVoffset;
				array[4] = " ";
				array[5] = source.obUVscale;
				UnityEngine.Debug.Log(string.Concat(array));
			}
			float x = adjustedForScaleAndOffset2Dimensions.x;
			float y = adjustedForScaleAndOffset2Dimensions.y;
			float num = source.scale.x;
			float num2 = source.scale.y;
			float num3 = source.offset.x;
			float num4 = source.offset.y;
			if (fixOutOfBoundsUVs)
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
				num *= source.obUVscale.x;
				num2 *= source.obUVscale.y;
				num3 += source.obUVoffset.x;
				num4 += source.obUVoffset.y;
			}
			Texture2D texture2D = _createTemporaryTexture((int)x, (int)y, TextureFormat.ARGB32, true);
			for (int i = 0; i < texture2D.width; i++)
			{
				for (int j = 0; j < texture2D.height; j++)
				{
					float u = (float)i / x * num + num3;
					float v = (float)j / y * num2 + num4;
					texture2D.SetPixel(i, j, source.t.GetPixelBilinear(u, v));
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_0273;
					}
					continue;
					end_IL_0273:
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
				texture2D.Apply();
				return texture2D;
			}
		}

		private void CopyScaledAndTiledToAtlas(MeshBakerMaterialTexture source, int targX, int targY, int targW, int targH, bool fixOutOfBoundsUVs, int maxSize, Color[] atlasPixels, int atlasWidth)
		{
			if (VERBOSE)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(14);
				array[0] = "CopyScaledAndTiledToAtlas: ";
				array[1] = source.t;
				array[2] = " sourceW=";
				array[3] = source.t.width;
				array[4] = " sourceH=";
				array[5] = source.t.height;
				array[6] = " inAtlasX=";
				array[7] = targX;
				array[8] = " inAtlasY=";
				array[9] = targY;
				array[10] = " inAtlasW=";
				array[11] = targW;
				array[12] = " inAtlasH=";
				array[13] = targH;
				UnityEngine.Debug.Log(string.Concat(array));
			}
			float num = targW;
			float num2 = targH;
			float num3 = source.scale.x;
			float num4 = source.scale.y;
			float num5 = source.offset.x;
			float num6 = source.offset.y;
			if (fixOutOfBoundsUVs)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				num3 *= source.obUVscale.x;
				num4 *= source.obUVscale.y;
				num5 += source.obUVoffset.x;
				num6 += source.obUVoffset.y;
			}
			int num7 = (int)num;
			int num8 = (int)num2;
			Texture2D texture2D = source.t;
			if (texture2D == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				texture2D = _createTemporaryTexture(2, 2, TextureFormat.ARGB32, true);
				MB_Utility.setSolidColor(texture2D, Color.clear);
			}
			texture2D = _addWatermark(texture2D);
			for (int i = 0; i < num7; i++)
			{
				for (int j = 0; j < num8; j++)
				{
					float u = (float)i / num * num3 + num5;
					float v = (float)j / num2 * num4 + num6;
					atlasPixels[(targY + j) * atlasWidth + targX + i] = texture2D.GetPixelBilinear(u, v);
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_01f1;
					}
					continue;
					end_IL_01f1:
					break;
				}
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}

		private Texture2D _createTemporaryTexture(int w, int h, TextureFormat texFormat, bool mipMaps)
		{
			Texture2D texture2D = new Texture2D(w, h, texFormat, mipMaps);
			texture2D.name = "MB_TextureCombiner_t";
			MB_Utility.setSolidColor(texture2D, Color.clear);
			_temporaryTextures.Add(texture2D);
			return texture2D;
		}

		private Texture2D _createTextureCopy(Texture2D t)
		{
			Texture2D texture2D = MB_Utility.createTextureCopy(t);
			_temporaryTextures.Add(texture2D);
			return texture2D;
		}

		private Texture2D _resizeTexture(Texture2D t, int w, int h)
		{
			Texture2D texture2D = MB_Utility.resampleTexture(t, w, h);
			_temporaryTextures.Add(texture2D);
			return texture2D;
		}

		private void _destroyTemporaryTextures()
		{
			if (VERBOSE)
			{
				while (true)
				{
					switch (5)
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
				UnityEngine.Debug.Log("Destroying " + _temporaryTextures.Count + " temporary textures");
			}
			for (int i = 0; i < _temporaryTextures.Count; i++)
			{
				_destroy(_temporaryTextures[i]);
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				_temporaryTextures.Clear();
				return;
			}
		}

		private void _SetReadFlags(ProgressUpdateDelegate progressInfo)
		{
			for (int i = 0; i < _texturesWithReadWriteFlagSet.Count; i++)
			{
				if (progressInfo != null)
				{
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
					progressInfo("Restoring read flag for " + _texturesWithReadWriteFlagSet[i], 0.9f);
				}
				setReadWriteFlag(_texturesWithReadWriteFlagSet[i], false, false);
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				_texturesWithReadWriteFlagSet.Clear();
				return;
			}
		}

		private void _destroy(UnityEngine.Object o)
		{
			UnityEngine.Object.Destroy(o);
		}

		private void _saveAtlasToAssetDatabase(Texture2D atlas, string texPropertyName, int atlasNum, Material resMat, FileSaveFunction fileSaveFunction)
		{
		}

		private void _setMaterialTextureProperty(Material target, string texPropName, string texturePath)
		{
		}

		private void setNormalMap(Texture2D tx)
		{
		}
	}
}
