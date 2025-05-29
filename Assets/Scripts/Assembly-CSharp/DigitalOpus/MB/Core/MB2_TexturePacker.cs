using System;
using System.Collections.Generic;
using A;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class MB2_TexturePacker
	{
		private class PixRect
		{
			public int x;

			public int y;

			public int w;

			public int h;

			public PixRect()
			{
			}

			public PixRect(int xx, int yy, int ww, int hh)
			{
				x = xx;
				y = yy;
				w = ww;
				h = hh;
			}
		}

		private class Image
		{
			public int imgId;

			public int w;

			public int h;

			public int x;

			public int y;

			public Image(int id, int tw, int th, int padding)
			{
				imgId = id;
				w = tw + padding * 2;
				h = th + padding * 2;
			}
		}

		private class ImgIDComparer : IComparer<Image>
		{
			public int Compare(Image x, Image y)
			{
				if (x.imgId > y.imgId)
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
							return 1;
						}
					}
				}
				if (x.imgId == y.imgId)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							return 0;
						}
					}
				}
				return -1;
			}
		}

		private class ImageHeightComparer : IComparer<Image>
		{
			public int Compare(Image x, Image y)
			{
				if (x.h > y.h)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							if (1 == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							return -1;
						}
					}
				}
				if (x.h == y.h)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							return 0;
						}
					}
				}
				return 1;
			}
		}

		private class ImageWidthComparer : IComparer<Image>
		{
			public int Compare(Image x, Image y)
			{
				if (x.w > y.w)
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
							return -1;
						}
					}
				}
				if (x.w == y.w)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							return 0;
						}
					}
				}
				return 1;
			}
		}

		private class ImageAreaComparer : IComparer<Image>
		{
			public int Compare(Image x, Image y)
			{
				int num = x.w * x.h;
				int num2 = y.w * y.h;
				if (num > num2)
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
							return -1;
						}
					}
				}
				if (num == num2)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							return 0;
						}
					}
				}
				return 1;
			}
		}

		private class ProbeResult
		{
			public int w;

			public int h;

			public Node root;

			public bool fitsInMaxSize;

			public float efficiency;

			public float squareness;

			public void Set(int ww, int hh, Node r, bool fits, float e, float sq)
			{
				w = ww;
				h = hh;
				root = r;
				fitsInMaxSize = fits;
				efficiency = e;
				squareness = sq;
			}

			public float GetScore()
			{
				float num;
				if (fitsInMaxSize)
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
					num = 1f;
				}
				else
				{
					num = 0f;
				}
				float num2 = num;
				return squareness + 2f * efficiency + num2;
			}
		}

		private class Node
		{
			public Node[] child = new Node[2];

			public PixRect r;

			public Image img;

			private bool isLeaf()
			{
				if (child[0] != null)
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
					if (child[1] != null)
					{
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
				return true;
			}

			public Node Insert(Image im, bool handed)
			{
				int num;
				int num2;
				if (handed)
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
					num = 0;
					num2 = 1;
				}
				else
				{
					num = 1;
					num2 = 0;
				}
				if (!isLeaf())
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
						{
							Node node = child[num].Insert(im, handed);
							if (node != null)
							{
								while (true)
								{
									switch (7)
									{
									case 0:
										break;
									default:
										return node;
									}
								}
							}
							return child[num2].Insert(im, handed);
						}
						}
					}
				}
				if (img != null)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return null;
						}
					}
				}
				if (r.w >= im.w)
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
					if (r.h >= im.h)
					{
						if (r.w == im.w)
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
							if (r.h == im.h)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
										img = im;
										return this;
									}
								}
							}
						}
						child[num] = new Node();
						child[num2] = new Node();
						int num3 = r.w - im.w;
						int num4 = r.h - im.h;
						if (num3 > num4)
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
							child[num].r = new PixRect(r.x, r.y, im.w, r.h);
							child[num2].r = new PixRect(r.x + im.w, r.y, r.w - im.w, r.h);
						}
						else
						{
							child[num].r = new PixRect(r.x, r.y, r.w, im.h);
							child[num2].r = new PixRect(r.x, r.y + im.h, r.w, r.h - im.h);
						}
						return child[num].Insert(im, handed);
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
				return null;
			}
		}

		public MB2_LogLevel LOG_LEVEL = MB2_LogLevel.warn;

		private ProbeResult bestRoot;

		private static void printTree(Node r, string spc)
		{
			if (r.child[0] != null)
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
				printTree(r.child[0], spc + "  ");
			}
			if (r.child[1] == null)
			{
				return;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				printTree(r.child[1], spc + "  ");
				return;
			}
		}

		private static void flattenTree(Node r, List<Image> putHere)
		{
			if (r.img != null)
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
				r.img.x = r.r.x;
				r.img.y = r.r.y;
				putHere.Add(r.img);
			}
			if (r.child[0] != null)
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
				flattenTree(r.child[0], putHere);
			}
			if (r.child[1] == null)
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
				flattenTree(r.child[1], putHere);
				return;
			}
		}

		private static void drawGizmosNode(Node r)
		{
			Vector3 size = new Vector3(r.r.w, r.r.h, 0f);
			Vector3 center = new Vector3((float)r.r.x + size.x / 2f, (float)(-r.r.y) - size.y / 2f, 0f);
			Gizmos.DrawWireCube(center, size);
			if (r.img != null)
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
				Gizmos.color = Color.blue;
				size = new Vector3(r.img.w, r.img.h, 0f);
				center = new Vector3((float)r.img.x + size.x / 2f, (float)(-r.img.y) - size.y / 2f, 0f);
				Gizmos.DrawCube(center, size);
			}
			if (r.child[0] != null)
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
				Gizmos.color = Color.red;
				drawGizmosNode(r.child[0]);
			}
			if (r.child[1] == null)
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
				Gizmos.color = Color.green;
				drawGizmosNode(r.child[1]);
				return;
			}
		}

		private static Texture2D createFilledTex(Color c, int w, int h)
		{
			Texture2D texture2D = new Texture2D(w, h);
			texture2D.name = "createFilledTex_t";
			int num = 0;
			while (num < w)
			{
				for (int i = 0; i < h; i++)
				{
					texture2D.SetPixel(num, i, c);
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
					num++;
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
				texture2D.Apply();
				return texture2D;
			}
		}

		public void DrawGizmos()
		{
			if (bestRoot == null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				drawGizmosNode(bestRoot.root);
				return;
			}
		}

		private bool Probe(Image[] imgsToAdd, int idealAtlasW, int idealAtlasH, float imgArea, int maxAtlasDim, ProbeResult pr)
		{
			Node node = new Node();
			node.r = new PixRect(0, 0, idealAtlasW, idealAtlasH);
			for (int i = 0; i < imgsToAdd.Length; i++)
			{
				Node node2 = node.Insert(imgsToAdd[i], false);
				if (node2 == null)
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
							return false;
						}
					}
				}
				if (i != imgsToAdd.Length - 1)
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
					int x = 0;
					int y = 0;
					GetExtent(node, ref x, ref y);
					float num = 1f - ((float)(x * y) - imgArea) / (float)(x * y);
					float num2;
					if (x < y)
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
						num2 = (float)x / (float)y;
					}
					else
					{
						num2 = (float)y / (float)x;
					}
					int num3;
					if (x <= maxAtlasDim)
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
						num3 = ((y <= maxAtlasDim) ? 1 : 0);
					}
					else
					{
						num3 = 0;
					}
					bool flag = (byte)num3 != 0;
					pr.Set(x, y, node, flag, num, num2);
					if (LOG_LEVEL >= MB2_LogLevel.info)
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
						object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(10);
						array[0] = "Probe success efficiency w=";
						array[1] = x;
						array[2] = " h=";
						array[3] = y;
						array[4] = " e=";
						array[5] = num;
						array[6] = " sq=";
						array[7] = num2;
						array[8] = " fits=";
						array[9] = flag;
						UnityEngine.Debug.Log(string.Concat(array));
					}
					return true;
				}
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (LOG_LEVEL >= MB2_LogLevel.error)
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
					UnityEngine.Debug.LogError("Should never get here.");
				}
				return false;
			}
		}

		private void GetExtent(Node r, ref int x, ref int y)
		{
			if (r.img != null)
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
				if (r.r.x + r.img.w > x)
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
					x = r.r.x + r.img.w;
				}
				if (r.r.y + r.img.h > y)
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
					y = r.r.y + r.img.h;
				}
			}
			if (r.child[0] != null)
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
				GetExtent(r.child[0], ref x, ref y);
			}
			if (r.child[1] == null)
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
				GetExtent(r.child[1], ref x, ref y);
				return;
			}
		}

		public Rect[] GetRects(List<Vector2> imgWidthHeights, int maxDimension, int padding, out int outW, out int outH)
		{
			float num = 0f;
			int num2 = 0;
			int num3 = 0;
			Image[] array = new Image[imgWidthHeights.Count];
			for (int i = 0; i < array.Length; i++)
			{
				Image image = (array[i] = new Image(i, (int)imgWidthHeights[i].x, (int)imgWidthHeights[i].y, padding));
				num += (float)(image.w * image.h);
				num2 = Mathf.Max(num2, image.w);
				num3 = Mathf.Max(num3, image.h);
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
				if ((float)num3 / (float)num2 > 2f)
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
					if (LOG_LEVEL >= MB2_LogLevel.info)
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
						UnityEngine.Debug.Log("Using height Comparer");
					}
					Array.Sort(array, new ImageHeightComparer());
				}
				else if ((double)((float)num3 / (float)num2) < 0.5)
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
					if (LOG_LEVEL >= MB2_LogLevel.info)
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
						UnityEngine.Debug.Log("Using width Comparer");
					}
					Array.Sort(array, new ImageWidthComparer());
				}
				else
				{
					if (LOG_LEVEL >= MB2_LogLevel.info)
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
						UnityEngine.Debug.Log("Using area Comparer");
					}
					Array.Sort(array, new ImageAreaComparer());
				}
				int num4 = (int)Mathf.Sqrt(num);
				int num5 = num4;
				int num6 = num4;
				if (num2 > num4)
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
					num5 = num2;
					num6 = Mathf.Max(Mathf.CeilToInt(num / (float)num2), num3);
				}
				if (num3 > num4)
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
					num5 = Mathf.Max(Mathf.CeilToInt(num / (float)num3), num2);
					num6 = num3;
				}
				if (num5 == 0)
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
				if (num6 == 0)
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
					num6 = 1;
				}
				int num7 = (int)((float)num5 * 0.15f);
				int num8 = (int)((float)num6 * 0.15f);
				if (num7 == 0)
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
					num7 = 1;
				}
				if (num8 == 0)
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
					num8 = 1;
				}
				int num9 = 2;
				int num10 = num6;
				while (num9 > 1)
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
					if (num10 < num4 * 1000)
					{
						bool flag = false;
						num9 = 0;
						int num11 = num5;
						while (!flag)
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
							if (num11 < num4 * 1000)
							{
								ProbeResult probeResult = new ProbeResult();
								if (Probe(array, num11, num10, num, maxDimension, probeResult))
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
									flag = true;
									if (bestRoot == null)
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
										bestRoot = probeResult;
										continue;
									}
									if (!(probeResult.GetScore() > bestRoot.GetScore()))
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
									bestRoot = probeResult;
									continue;
								}
								num9++;
								num11 += num7;
								if (LOG_LEVEL < MB2_LogLevel.info)
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
								object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
								array2[0] = "increasing Width h=";
								array2[1] = num10;
								array2[2] = " w=";
								array2[3] = num11;
								UnityEngine.Debug.Log(string.Concat(array2));
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
							break;
						}
						num10 += num8;
						if (LOG_LEVEL < MB2_LogLevel.info)
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
						object[] array3 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
						array3[0] = "increasing Height h=";
						array3[1] = num10;
						array3[2] = " w=";
						array3[3] = num11;
						UnityEngine.Debug.Log(string.Concat(array3));
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
					break;
				}
				outW = 0;
				outH = 0;
				if (bestRoot == null)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							return null;
						}
					}
				}
				if (LOG_LEVEL >= MB2_LogLevel.info)
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
					object[] array4 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(10);
					array4[0] = "Best fit found: w=";
					array4[1] = bestRoot.w;
					array4[2] = " h=";
					array4[3] = bestRoot.h;
					array4[4] = " efficiency=";
					array4[5] = bestRoot.efficiency;
					array4[6] = " squareness=";
					array4[7] = bestRoot.squareness;
					array4[8] = " fits in max dimension=";
					array4[9] = bestRoot.fitsInMaxSize;
					UnityEngine.Debug.Log(string.Concat(array4));
				}
				outW = bestRoot.w;
				outH = bestRoot.h;
				List<Image> list = new List<Image>();
				flattenTree(bestRoot.root, list);
				list.Sort(new ImgIDComparer());
				if (list.Count != array.Length)
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
					UnityEngine.Debug.LogError("Result images not the same lentgh as source");
				}
				float num12 = (float)padding / (float)bestRoot.w;
				if (bestRoot.w > maxDimension)
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
					num12 = (float)padding / (float)maxDimension;
					float num13 = (float)maxDimension / (float)bestRoot.w;
					if (LOG_LEVEL >= MB2_LogLevel.warn)
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
						UnityEngine.Debug.LogWarning("Packing exceeded atlas width shrinking to " + num13);
					}
					for (int j = 0; j < list.Count; j++)
					{
						Image image2 = list[j];
						int num14 = (int)((float)(image2.x + image2.w) * num13);
						image2.x = (int)(num13 * (float)image2.x);
						image2.w = num14 - image2.x;
						if (image2.w != 0)
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
						UnityEngine.Debug.LogError("rounding scaled image w to zero");
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
					outW = maxDimension;
				}
				float num15 = (float)padding / (float)bestRoot.h;
				if (bestRoot.h > maxDimension)
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
					num15 = (float)padding / (float)maxDimension;
					float num16 = (float)maxDimension / (float)bestRoot.h;
					if (LOG_LEVEL >= MB2_LogLevel.warn)
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
						UnityEngine.Debug.LogWarning("Packing exceeded atlas height shrinking to " + num16);
					}
					for (int k = 0; k < list.Count; k++)
					{
						Image image3 = list[k];
						int num17 = (int)((float)(image3.y + image3.h) * num16);
						image3.y = (int)(num16 * (float)image3.y);
						image3.h = num17 - image3.y;
						if (image3.h != 0)
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
						UnityEngine.Debug.LogError("rounding scaled image h to zero");
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
					outH = maxDimension;
				}
				Rect[] array5 = ceb2dc13fc3d1610632a74802c9d18d10.c0a0cdf4a196914163f7334d9b0781a04(list.Count);
				for (int l = 0; l < list.Count; l++)
				{
					Image image4 = list[l];
					Rect rect = (array5[l] = new Rect((float)image4.x / (float)outW + num12, (float)image4.y / (float)outH + num15, (float)image4.w / (float)outW - num12 * 2f, (float)image4.h / (float)outH - num15 * 2f));
					if (LOG_LEVEL < MB2_LogLevel.info)
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
					object[] array6 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(14);
					array6[0] = "Image: ";
					array6[1] = l;
					array6[2] = " imgID=";
					array6[3] = image4.imgId;
					array6[4] = " x=";
					array6[5] = rect.x * (float)outW;
					array6[6] = " y=";
					array6[7] = rect.y * (float)outH;
					array6[8] = " w=";
					array6[9] = rect.width * (float)outW;
					array6[10] = " h=";
					array6[11] = rect.height * (float)outH;
					array6[12] = " padding=";
					array6[13] = padding;
					UnityEngine.Debug.Log(string.Concat(array6));
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					if (LOG_LEVEL >= MB2_LogLevel.info)
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
						UnityEngine.Debug.Log("Done GetRects");
					}
					return array5;
				}
			}
		}

		public void RunTestHarness()
		{
			List<Vector2> list = new List<Vector2>();
			list.Add(new Vector2(128f, 128f));
			list.Add(new Vector2(256f, 256f));
			list.Add(new Vector2(512f, 512f));
			int padding = 1;
			int outW;
			int outH;
			GetRects(list, 2048, padding, out outW, out outH);
		}
	}
}
