using System;
using System.Collections.Generic;
using A;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class MB_Utility
	{
		private class MB_Triangle
		{
			private int submeshIdx;

			private int[] vs = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(3);

			public MB_Triangle(int[] ts, int idx, int sIdx)
			{
				vs[0] = ts[idx];
				vs[1] = ts[idx + 1];
				vs[2] = ts[idx + 2];
				submeshIdx = sIdx;
				Array.Sort(vs);
			}

			public bool isSame(object obj)
			{
				MB_Triangle mB_Triangle = (MB_Triangle)obj;
				if (vs[0] == mB_Triangle.vs[0])
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
					if (vs[1] == mB_Triangle.vs[1])
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
						if (vs[2] == mB_Triangle.vs[2])
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
							if (submeshIdx != mB_Triangle.submeshIdx)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
										return true;
									}
								}
							}
						}
					}
				}
				return false;
			}

			public bool sharesVerts(MB_Triangle obj)
			{
				if (vs[0] != obj.vs[0])
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
					if (vs[0] != obj.vs[1])
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
						if (vs[0] != obj.vs[2])
						{
							goto IL_0077;
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
					}
				}
				if (submeshIdx != obj.submeshIdx)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							return true;
						}
					}
				}
				goto IL_0077;
				IL_0153:
				return false;
				IL_00e5:
				if (vs[2] != obj.vs[0])
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
					if (vs[2] != obj.vs[1])
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
						if (vs[2] != obj.vs[2])
						{
							goto IL_0153;
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
				}
				if (submeshIdx != obj.submeshIdx)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							return true;
						}
					}
				}
				goto IL_0153;
				IL_0077:
				if (vs[1] != obj.vs[0])
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
					if (vs[1] != obj.vs[1])
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
						if (vs[1] != obj.vs[2])
						{
							goto IL_00e5;
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
					}
				}
				if (submeshIdx != obj.submeshIdx)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							return true;
						}
					}
				}
				goto IL_00e5;
			}
		}

		public static Texture2D createTextureCopy(Texture2D source)
		{
			Texture2D texture2D = new Texture2D(source.width, source.height, TextureFormat.ARGB32, true);
			texture2D.name = "createTextureCopy_newTex";
			texture2D.SetPixels(source.GetPixels());
			return texture2D;
		}

		public static Material[] GetGOMaterials(GameObject go)
		{
			if (go == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						return null;
					}
				}
			}
			Material[] array = c4a89cc7ff58be6b4a23285e77aabc482.c7088de59e49f7108f520cf7e0bae167e;
			Mesh mesh = c8daf33963c4c831f4bebda3f27067f17.c7088de59e49f7108f520cf7e0bae167e;
			MeshRenderer component = go.GetComponent<MeshRenderer>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				array = component.sharedMaterials;
				MeshFilter component2 = go.GetComponent<MeshFilter>();
				if (component2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						throw new Exception(string.Concat("Object ", go, " has a MeshRenderer but no MeshFilter."));
					}
				}
				mesh = component2.sharedMesh;
			}
			SkinnedMeshRenderer component3 = go.GetComponent<SkinnedMeshRenderer>();
			if (component3 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				array = component3.sharedMaterials;
				mesh = component3.sharedMesh;
			}
			if (array == null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						UnityEngine.Debug.LogError("Object " + go.name + " does not have a MeshRenderer or a SkinnedMeshRenderer component");
						return null;
					}
				}
			}
			if (mesh == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						UnityEngine.Debug.LogError("Object " + go.name + " has a MeshRenderer or SkinnedMeshRenderer but no mesh.");
						return null;
					}
				}
			}
			if (mesh.subMeshCount < array.Length)
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
				object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(7);
				array2[0] = "Object ";
				array2[1] = go;
				array2[2] = " has only ";
				array2[3] = mesh.subMeshCount;
				array2[4] = " submeshes and has ";
				array2[5] = array.Length;
				array2[6] = " materials. Extra materials do nothing.";
				UnityEngine.Debug.LogWarning(string.Concat(array2));
				Material[] array3 = cb49f36706caafb4b94436f6a37599753.c0a0cdf4a196914163f7334d9b0781a04(mesh.subMeshCount);
				Array.Copy(array, array3, array3.Length);
				array = array3;
			}
			return array;
		}

		public static Mesh GetMesh(GameObject go)
		{
			if (go == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return null;
					}
				}
			}
			MeshFilter component = go.GetComponent<MeshFilter>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return component.sharedMesh;
					}
				}
			}
			SkinnedMeshRenderer component2 = go.GetComponent<SkinnedMeshRenderer>();
			if (component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return component2.sharedMesh;
					}
				}
			}
			UnityEngine.Debug.LogError("Object " + go.name + " does not have a MeshFilter or a SkinnedMeshRenderer component");
			return null;
		}

		public static Renderer GetRenderer(GameObject go)
		{
			if (go == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return null;
					}
				}
			}
			MeshRenderer component = go.GetComponent<MeshRenderer>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return component;
					}
				}
			}
			SkinnedMeshRenderer component2 = go.GetComponent<SkinnedMeshRenderer>();
			if (component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return component2;
					}
				}
			}
			return null;
		}

		public static void DisableRendererInSource(GameObject go)
		{
			if (go == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						return;
					}
				}
			}
			MeshRenderer component = go.GetComponent<MeshRenderer>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						component.enabled = false;
						return;
					}
				}
			}
			SkinnedMeshRenderer component2 = go.GetComponent<SkinnedMeshRenderer>();
			if (!(component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				component2.enabled = false;
				return;
			}
		}

		public static bool hasOutOfBoundsUVs(Mesh m, ref Rect uvBounds, int submeshIndex = -1)
		{
			Vector2[] uv = m.uv;
			if (uv.Length == 0)
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
			if (submeshIndex >= m.subMeshCount)
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
			float num;
			float x;
			float num2;
			float y;
			if (submeshIndex >= 0)
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
				int[] triangles = m.GetTriangles(submeshIndex);
				if (triangles.Length == 0)
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
				num = (x = uv[triangles[0]].x);
				num2 = (y = uv[triangles[0]].y);
				foreach (int num3 in triangles)
				{
					if (uv[num3].x < num)
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
						num = uv[num3].x;
					}
					if (uv[num3].x > x)
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
						x = uv[num3].x;
					}
					if (uv[num3].y < num2)
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
						num2 = uv[num3].y;
					}
					if (!(uv[num3].y > y))
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
					y = uv[num3].y;
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
				num = (x = uv[0].x);
				num2 = (y = uv[0].y);
				for (int j = 0; j < uv.Length; j++)
				{
					if (uv[j].x < num)
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
						num = uv[j].x;
					}
					if (uv[j].x > x)
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
						x = uv[j].x;
					}
					if (uv[j].y < num2)
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
						num2 = uv[j].y;
					}
					if (!(uv[j].y > y))
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
					y = uv[j].y;
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
			}
			uvBounds.x = num;
			uvBounds.y = num2;
			uvBounds.width = x - num;
			uvBounds.height = y - num2;
			if (!(x > 1f))
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
				if (!(num < 0f))
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
					if (!(y > 1f))
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
						if (!(num2 < 0f))
						{
							float x2 = (uvBounds.y = 0f);
							uvBounds.x = x2;
							x2 = (uvBounds.height = 1f);
							uvBounds.width = x2;
							return false;
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
					}
				}
			}
			return true;
		}

		public static void setSolidColor(Texture2D t, Color c)
		{
			Color[] pixels = t.GetPixels();
			for (int i = 0; i < pixels.Length; i++)
			{
				pixels[i] = c;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				t.SetPixels(pixels);
				t.Apply();
				return;
			}
		}

		public static Texture2D resampleTexture(Texture2D source, int newWidth, int newHeight)
		{
			TextureFormat format = source.format;
			if (format != TextureFormat.ARGB32)
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
				if (format != TextureFormat.RGBA32)
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
					if (format != TextureFormat.BGRA32)
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
						if (format != TextureFormat.RGB24)
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
							if (format != TextureFormat.Alpha8)
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
								if (format != TextureFormat.DXT1)
								{
									UnityEngine.Debug.LogError("Can only resize textures in formats ARGB32, RGBA32, BGRA32, RGB24, Alpha8 or DXT");
									return null;
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
							}
						}
					}
				}
			}
			Texture2D texture2D = new Texture2D(newWidth, newHeight, TextureFormat.ARGB32, true);
			texture2D.name = "resampleTexture_newTex";
			float num = newWidth;
			float num2 = newHeight;
			for (int i = 0; i < newWidth; i++)
			{
				for (int j = 0; j < newHeight; j++)
				{
					float u = (float)i / num;
					float v = (float)j / num2;
					texture2D.SetPixel(i, j, source.GetPixelBilinear(u, v));
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						goto end_IL_00bf;
					}
					continue;
					end_IL_00bf:
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
				texture2D.Apply();
				return texture2D;
			}
		}

		public static bool validateOBuvsMultiMaterial(Material[] sharedMaterials)
		{
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				for (int j = i + 1; j < sharedMaterials.Length; j++)
				{
					if (!(sharedMaterials[i] == sharedMaterials[j]))
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
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return false;
					}
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						goto end_IL_0038;
					}
					continue;
					end_IL_0038:
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
				return true;
			}
		}

		public static int doSubmeshesShareVertsOrTris(Mesh m)
		{
			List<MB_Triangle> list = new List<MB_Triangle>();
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < m.subMeshCount; i++)
			{
				int[] triangles = m.GetTriangles(i);
				for (int j = 0; j < triangles.Length; j += 3)
				{
					MB_Triangle mB_Triangle = new MB_Triangle(triangles, j, i);
					for (int k = 0; k < list.Count; k++)
					{
						if (mB_Triangle.isSame(list[k]))
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
							flag2 = true;
						}
						if (!mB_Triangle.sharesVerts(list[k]))
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
						flag = true;
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							goto end_IL_0092;
						}
						continue;
						end_IL_0092:
						break;
					}
					list.Add(mB_Triangle);
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						goto end_IL_00b5;
					}
					continue;
					end_IL_00b5:
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
				if (flag2)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							return 2;
						}
					}
				}
				if (flag)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							return 1;
						}
					}
				}
				return 0;
			}
		}

		private static bool validateMultipleMaterials(MB_MultiMaterial[] rs)
		{
			List<Material> list = new List<Material>();
			List<Material> list2 = new List<Material>();
			for (int i = 0; i < rs.Length; i++)
			{
				if (list2.Contains(rs[i].combinedMaterial))
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
							UnityEngine.Debug.LogError("There are duplicate combined materials in the combined materials list");
							return false;
						}
					}
				}
				for (int j = 0; j < rs[i].sourceMaterials.Count; j++)
				{
					if (rs[i].sourceMaterials[j] == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								UnityEngine.Debug.LogError("There are nulls in the list of source materials");
								return false;
							}
						}
					}
					if (list.Contains(rs[i].sourceMaterials[j]))
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								UnityEngine.Debug.LogError("There are duplicate source materials in the combined materials list");
								return false;
							}
						}
					}
					list.Add(rs[i].sourceMaterials[j]);
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						goto end_IL_00de;
					}
					continue;
					end_IL_00de:
					break;
				}
				list2.Add(rs[i].combinedMaterial);
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

		public static void Destroy(UnityEngine.Object o)
		{
			UnityEngine.Object.Destroy(o);
		}
	}
}
