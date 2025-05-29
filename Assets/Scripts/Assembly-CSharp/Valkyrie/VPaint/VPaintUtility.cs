using System.Collections;
using System.Collections.Generic;
using A;
using UnityEngine;

namespace Valkyrie.VPaint
{
	public static class VPaintUtility
	{
		public static void MergeColors(Color[] source, float[] sourceTransparency, Color[] target, float[] targetTransparency, VPaintBlendMode blendMode, float opacity, bool maskR, bool maskG, bool maskB, bool maskA)
		{
			if (source.Length != target.Length)
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
						return;
					}
				}
			}
			for (int i = 0; i < source.Length; i++)
			{
				Color color = source[i];
				Color b = color;
				Color color2 = target[i];
				float num = Mathf.Clamp01(targetTransparency[i] * opacity);
				switch (blendMode)
				{
				case VPaintBlendMode.Additive:
					b = color + color2;
					break;
				case VPaintBlendMode.Multiply:
					b = color * color2;
					break;
				case VPaintBlendMode.Opaque:
					b = color2;
					break;
				case VPaintBlendMode.Overlay:
					b = color * color2 * 2f;
					break;
				}
				b = Color.Lerp(color, b, num);
				if (maskR)
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
					color.r = b.r;
				}
				if (maskG)
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
					color.g = b.g;
				}
				if (maskB)
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
					color.b = b.b;
				}
				if (maskA)
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
					color.a = b.a;
				}
				source[i] = color;
				sourceTransparency[i] = Mathf.Clamp01(sourceTransparency[i] + num);
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}

		public static void BlendRadial(VPaintLayer[] layers, VPaintObject[] blendObjects, VPaintObject[] blendTargets, float radius, float intensity = 1f, Bounds? bounds = null)
		{
			IEnumerator<VPaintProgress> enumerator = BlendRadialAsync(layers, blendObjects, blendTargets, radius, intensity, bounds);
			while (enumerator.MoveNext())
			{
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
				return;
			}
		}

		public static IEnumerator<VPaintProgress> BlendRadialAsync(VPaintLayer[] layers, VPaintObject[] blendObjects, VPaintObject[] blendTargets, float radius, float intensity = 1f, Bounds? bounds = null)
		{
			List<VPaintObject> validTargets = new List<VPaintObject>();
			foreach (VPaintObject vc in blendTargets)
			{
				if (Application.isPlaying)
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
					if (!vc.c38cb1eed166b6c6ce16a48473b997952)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								throw new VPaintObjectNotDynamicException();
							}
						}
					}
				}
				if (bounds.HasValue)
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
					if (!bounds.Value.Intersects(vc.editorCollider.bounds))
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
						continue;
					}
				}
				validTargets.Add(vc);
			}
			VPaintProgress c36964cf41281414170f34ee68bef6c = default(VPaintProgress);
			Color c36964cf41281414170f34ee68bef6c2 = default(Color);
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				foreach (VPaintLayer layer in layers)
				{
					int i = 0;
					while (i < blendObjects.Length)
					{
						VPaintObject vc2 = blendObjects[i];
						c0abf21262b9574c3a618cd8cf60328be.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
						c36964cf41281414170f34ee68bef6c.message = "Blending " + vc2.name + " on layer " + layer.name;
						c36964cf41281414170f34ee68bef6c.progress = (float)i / (float)blendObjects.Length;
						yield return c36964cf41281414170f34ee68bef6c;
						Mesh k = vc2.cdde5b1604999906d214f0b05ebcc515b();
						Vector3[] vertices = k.vertices;
						VPaintVertexData paintData = layer.GetOrCreate(vc2);
						Color[] colors = paintData.colors;
						float[] trans = paintData.transparency;
						Transform t = vc2.transform;
						Vector4[] colTotal = c6b9b486e00bdfd9ee7ce0bac7f34a00e.c0a0cdf4a196914163f7334d9b0781a04(colors.Length);
						float[] transTotal = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(trans.Length);
						float[] facTotal = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(trans.Length);
						float[] distTotal = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(trans.Length);
						float[] countTotal = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(trans.Length);
						for (int d = 0; d < distTotal.Length; d++)
						{
							distTotal[d] = radius;
						}
						while (true)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							for (int tg = 0; tg < validTargets.Count; tg++)
							{
								VPaintObject targ = validTargets[tg];
								VPaintVertexData targPaintData = layer.GetOrCreate(targ);
								if (targPaintData == null)
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
									continue;
								}
								Mesh targMesh = targ.cdde5b1604999906d214f0b05ebcc515b();
								Vector3[] targVerts = targMesh.vertices;
								Color[] targCols = targPaintData.colors;
								float[] targTrans = targPaintData.transparency;
								Transform transform = targ.transform;
								for (int v2 = 0; v2 < vertices.Length; v2++)
								{
									Vector4 avg = Vector4.zero;
									float avgTrans = 0f;
									float shortestDist = radius;
									float fac = 0f;
									int total = 0;
									Vector3 vert = t.TransformPoint(vertices[v2]);
									for (int v3 = 0; v3 < targVerts.Length; v3++)
									{
										Vector3 targVert = transform.TransformPoint(targVerts[v3]);
										if (bounds.HasValue)
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
											if (!bounds.Value.Contains(targVert))
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
												continue;
											}
										}
										float dist = Vector3.Distance(vert, targVert);
										if (radius < dist)
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
										}
										else
										{
											float factor = 1f - dist / radius;
											fac += factor;
											avg += (Vector4)(targCols[v3] * factor);
											avgTrans += targTrans[v3] * factor;
											total++;
											shortestDist = Mathf.Min(dist, shortestDist);
										}
									}
									while (true)
									{
										switch (3)
										{
										case 0:
											break;
										default:
											goto end_IL_057e;
										}
										continue;
										end_IL_057e:
										break;
									}
									colTotal[v2] += avg;
									transTotal[v2] += avgTrans;
									facTotal[v2] += fac;
									countTotal[v2] += total;
									distTotal[v2] = Mathf.Min(distTotal[v2], shortestDist);
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
							while (true)
							{
								switch (6)
								{
								case 0:
									continue;
								}
								for (int v = 0; v < colors.Length; v++)
								{
									float fac2 = facTotal[v];
									Color color;
									if (fac2 == 0f)
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
										c67da02ed34f2b38120196017e8aed320.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c2);
										color = c36964cf41281414170f34ee68bef6c2;
									}
									else
									{
										color = (Color)colTotal[v] / fac2;
									}
									Color col = color;
									float num;
									if (fac2 == 0f)
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
										num = 0f;
									}
									else
									{
										num = transTotal[v] / fac2;
									}
									float tr = num;
									float count = countTotal[v];
									float num2;
									if (count == 0f)
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
										num2 = 0f;
									}
									else
									{
										num2 = 1f - distTotal[v] / radius;
									}
									float lerp2 = num2;
									lerp2 *= intensity;
									paintData.colors[v] = Color.Lerp(paintData.colors[v], col, lerp2);
									paintData.transparency[v] = Mathf.Lerp(paintData.transparency[v], tr, lerp2);
								}
								while (true)
								{
									switch (4)
									{
									case 0:
										break;
									default:
										goto end_IL_0833;
									}
									continue;
									end_IL_0833:
									break;
								}
								i++;
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
							break;
						default:
							goto end_IL_085e;
						}
						continue;
						end_IL_085e:
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
						yield break;
					}
				}
			}
		}

		public static void BlendDirectional(VPaintLayer[] layers, VPaintObject[] blendObjects, VPaintObject[] blendTargets, Vector3 direction, float distance, float intensity = 1f, float falloff = 1f, Vector3? offset = null, Bounds? bounds = null)
		{
			IEnumerator<VPaintProgress> enumerator = BlendDirectionalAsync(layers, blendObjects, blendTargets, direction, distance, intensity, falloff, offset, bounds);
			while (enumerator.MoveNext())
			{
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return;
			}
		}

		public static IEnumerator<VPaintProgress> BlendDirectionalAsync(VPaintLayer[] layers, VPaintObject[] blendObjects, VPaintObject[] blendTargets, Vector3 direction, float distance, float intensity = 1f, float falloff = 1f, Vector3? offset = null, Bounds? bounds = null)
		{
			if (!offset.HasValue)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				offset = Vector3.zero;
			}
			List<VPaintObject> validTargets = new List<VPaintObject>();
			foreach (VPaintObject vc in blendTargets)
			{
				if (Application.isPlaying)
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
					if (!vc.c38cb1eed166b6c6ce16a48473b997952)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								throw new VPaintObjectNotDynamicException();
							}
						}
					}
				}
				if (bounds.HasValue)
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
					if (!bounds.Value.Intersects(vc.editorCollider.bounds))
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
						continue;
					}
				}
				validTargets.Add(vc);
			}
			VPaintProgress c36964cf41281414170f34ee68bef6c = default(VPaintProgress);
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				foreach (VPaintLayer layer in layers)
				{
					for (int i = 0; i < blendObjects.Length; i++)
					{
						VPaintObject vc2 = blendObjects[i];
						string message = "Blending " + vc2.name + " on layer " + layer.name;
						float progressBase = (float)i / (float)blendObjects.Length;
						float progressRange = ((float)(i + 1) / (float)blendObjects.Length - progressBase) / 1f;
						Mesh k = vc2.cdde5b1604999906d214f0b05ebcc515b();
						Vector3[] vertices = k.vertices;
						VPaintVertexData paintData = layer.GetOrCreate(vc2);
						Color[] colors = paintData.colors;
						float[] trans = paintData.transparency;
						Transform t = vc2.transform;
						float offsetMagnitude = offset.Value.magnitude;
						for (int v = 0; v < vertices.Length; v++)
						{
							c0abf21262b9574c3a618cd8cf60328be.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
							c36964cf41281414170f34ee68bef6c.message = message;
							c36964cf41281414170f34ee68bef6c.progress = progressBase + progressRange * (float)v / (float)vertices.Length;
							yield return c36964cf41281414170f34ee68bef6c;
							Vector3 vert = t.TransformPoint(vertices[v]);
							if (bounds.HasValue)
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
								if (!bounds.Value.Contains(vert))
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
									continue;
								}
							}
							Vector4 avgCol = Vector4.zero;
							float avgTran = 0f;
							float fac = 0f;
							float count = 0f;
							using (List<VPaintObject>.Enumerator enumerator = validTargets.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									VPaintObject target = enumerator.Current;
									MeshCollider mc = target.editorCollider;
									Ray r = new Ray(vert + offset.Value, direction);
									RaycastHit hit;
									if (!mc.Raycast(r, out hit, distance))
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
									if (bounds.HasValue)
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
										if (!bounds.Value.Contains(hit.point))
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
											continue;
										}
									}
									Mesh mi = target.cdde5b1604999906d214f0b05ebcc515b();
									if (!mi)
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
										continue;
									}
									int[] triangles = mi.triangles;
									VPaintVertexData pd = layer.GetOrCreate(target);
									int t2 = triangles[hit.triangleIndex * 3];
									int t3 = triangles[hit.triangleIndex * 3 + 1];
									int t4 = triangles[hit.triangleIndex * 3 + 2];
									Color c1 = pd.colors[t2];
									Color c2 = pd.colors[t3];
									Color c3 = pd.colors[t4];
									float tr1 = pd.transparency[t2];
									float tr2 = pd.transparency[t3];
									float tr3 = pd.transparency[t4];
									Vector3 bc = hit.barycentricCoordinate;
									Color sampleColor = c1 * bc.x + c2 * bc.y + c3 * bc.z;
									float sampleTran = tr1 * bc.x + tr2 * bc.y + tr3 * bc.z;
									float factor = Mathf.Pow(1f - (hit.distance - offsetMagnitude) / distance, falloff);
									fac += factor;
									avgTran += sampleTran * factor;
									avgCol += (Vector4)sampleColor * factor;
									count += 1f;
								}
								while (true)
								{
									switch (2)
									{
									case 0:
										break;
									default:
										goto end_IL_071f;
									}
									continue;
									end_IL_071f:
									break;
								}
							}
							Color col = avgCol / fac;
							float tran = avgTran / fac;
							if (fac == 0f)
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
							float lerp = intensity * (fac / count);
							colors[v] = Color.Lerp(colors[v], col, lerp);
							trans[v] = Mathf.Lerp(trans[v], tran, lerp);
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								goto end_IL_0830;
							}
							continue;
							end_IL_0830:
							break;
						}
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							goto end_IL_085b;
						}
						continue;
						end_IL_085b:
						break;
					}
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						yield break;
					}
				}
			}
		}

		public static IEnumerator LerpColors(VPaintObject obj, Color[] start, Color[] end, float time)
		{
			float t = 0f;
			int len = start.Length;
			Color[] lerp = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(len);
			while (t < time)
			{
				float f = t / time;
				for (int i = 0; i < len; i++)
				{
					lerp[i] = Color.Lerp(start[i], end[i], f);
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					obj.cbec59bd01f76e4395aca1fade53c4ae3(lerp);
					yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
					t += Time.deltaTime;
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
				obj.cbec59bd01f76e4395aca1fade53c4ae3(end);
				yield break;
			}
		}
	}
}
