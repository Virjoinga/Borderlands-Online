using A;
using UnityEngine;

public class MeshCombineUtility
{
	public struct MeshInstance
	{
		public Mesh mesh;

		public int subMeshIndex;

		public Matrix4x4 transform;
	}

	public static Mesh cc4e9512abe46fc5b35caaac8d7081425(MeshInstance[] cde8a4c2583bf0906e45ff26bb97a3d1d, bool cf48f8bc095218a60438380ec0191a09e)
	{
		cf48f8bc095218a60438380ec0191a09e = false;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < cde8a4c2583bf0906e45ff26bb97a3d1d.Length; i++)
		{
			MeshInstance meshInstance = cde8a4c2583bf0906e45ff26bb97a3d1d[i];
			if (!meshInstance.mesh)
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
			num += meshInstance.mesh.vertexCount;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (!cf48f8bc095218a60438380ec0191a09e)
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
				for (int j = 0; j < cde8a4c2583bf0906e45ff26bb97a3d1d.Length; j++)
				{
					MeshInstance meshInstance2 = cde8a4c2583bf0906e45ff26bb97a3d1d[j];
					if (!meshInstance2.mesh)
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
					num2 += meshInstance2.mesh.GetTriangles(meshInstance2.subMeshIndex).Length;
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
			Vector3[] array = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(num);
			Vector3[] array2 = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(num);
			Vector4[] array3 = c6b9b486e00bdfd9ee7ce0bac7f34a00e.c0a0cdf4a196914163f7334d9b0781a04(num);
			Vector2[] array4 = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(num);
			Vector2[] array5 = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(num);
			Vector2[] array6 = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(num);
			Color[] array7 = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(num);
			int[] array8 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(num2);
			int c52921fe9488ee3d539be727c = 0;
			for (int k = 0; k < cde8a4c2583bf0906e45ff26bb97a3d1d.Length; k++)
			{
				MeshInstance meshInstance3 = cde8a4c2583bf0906e45ff26bb97a3d1d[k];
				if (!meshInstance3.mesh)
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
				c587b7c49e72369a911cce8ad4829c0e5(meshInstance3.mesh.vertexCount, meshInstance3.mesh.vertices, array, ref c52921fe9488ee3d539be727c, meshInstance3.transform);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				c52921fe9488ee3d539be727c = 0;
				for (int l = 0; l < cde8a4c2583bf0906e45ff26bb97a3d1d.Length; l++)
				{
					MeshInstance meshInstance4 = cde8a4c2583bf0906e45ff26bb97a3d1d[l];
					if (!meshInstance4.mesh)
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
					Matrix4x4 transform = meshInstance4.transform;
					transform = transform.inverse.transpose;
					cbc13e88b7f05f991e60be9bcf3b108e7(meshInstance4.mesh.vertexCount, meshInstance4.mesh.normals, array2, ref c52921fe9488ee3d539be727c, transform);
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					c52921fe9488ee3d539be727c = 0;
					for (int m = 0; m < cde8a4c2583bf0906e45ff26bb97a3d1d.Length; m++)
					{
						MeshInstance meshInstance5 = cde8a4c2583bf0906e45ff26bb97a3d1d[m];
						if (!meshInstance5.mesh)
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
						Matrix4x4 transform2 = meshInstance5.transform;
						transform2 = transform2.inverse.transpose;
						c00b740658612a98ee2be568dc797319d(meshInstance5.mesh.vertexCount, meshInstance5.mesh.tangents, array3, ref c52921fe9488ee3d539be727c, transform2);
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						c52921fe9488ee3d539be727c = 0;
						for (int n = 0; n < cde8a4c2583bf0906e45ff26bb97a3d1d.Length; n++)
						{
							MeshInstance meshInstance6 = cde8a4c2583bf0906e45ff26bb97a3d1d[n];
							if (!meshInstance6.mesh)
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
							c587b7c49e72369a911cce8ad4829c0e5(meshInstance6.mesh.vertexCount, meshInstance6.mesh.uv, array4, ref c52921fe9488ee3d539be727c);
						}
						while (true)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							c52921fe9488ee3d539be727c = 0;
							for (int num3 = 0; num3 < cde8a4c2583bf0906e45ff26bb97a3d1d.Length; num3++)
							{
								MeshInstance meshInstance7 = cde8a4c2583bf0906e45ff26bb97a3d1d[num3];
								if (!meshInstance7.mesh)
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
								c587b7c49e72369a911cce8ad4829c0e5(meshInstance7.mesh.vertexCount, meshInstance7.mesh.uv1, array5, ref c52921fe9488ee3d539be727c);
							}
							while (true)
							{
								switch (4)
								{
								case 0:
									continue;
								}
								float num4 = 0f;
								for (int num5 = 0; num5 < cde8a4c2583bf0906e45ff26bb97a3d1d.Length; num5++)
								{
									MeshInstance meshInstance8 = cde8a4c2583bf0906e45ff26bb97a3d1d[num5];
									if (!meshInstance8.mesh)
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
									num4 += meshInstance8.mesh.bounds.size.x * meshInstance8.mesh.bounds.size.y * meshInstance8.mesh.bounds.size.z;
								}
								while (true)
								{
									switch (4)
									{
									case 0:
										continue;
									}
									c52921fe9488ee3d539be727c = 0;
									float num6 = 0f;
									for (int num7 = 0; num7 < cde8a4c2583bf0906e45ff26bb97a3d1d.Length; num7++)
									{
										MeshInstance meshInstance9 = cde8a4c2583bf0906e45ff26bb97a3d1d[num7];
										if (!meshInstance9.mesh)
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
										float num8 = meshInstance9.mesh.bounds.size.x * meshInstance9.mesh.bounds.size.y * meshInstance9.mesh.bounds.size.z / num4;
										c3fd6328280d027af5c2dd9bdf50ea7a7(meshInstance9.mesh.vertexCount, meshInstance9.mesh.uv2, array6, ref c52921fe9488ee3d539be727c, num8, num6);
										num6 += num8;
									}
									while (true)
									{
										switch (3)
										{
										case 0:
											continue;
										}
										c52921fe9488ee3d539be727c = 0;
										for (int num9 = 0; num9 < cde8a4c2583bf0906e45ff26bb97a3d1d.Length; num9++)
										{
											MeshInstance meshInstance10 = cde8a4c2583bf0906e45ff26bb97a3d1d[num9];
											if (!meshInstance10.mesh)
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
											c46bfd8d901ffbc58695bdaac392b9f7b(meshInstance10.mesh.vertexCount, meshInstance10.mesh.colors, array7, ref c52921fe9488ee3d539be727c);
										}
										while (true)
										{
											switch (6)
											{
											case 0:
												continue;
											}
											int num10 = 0;
											int num11 = 0;
											for (int num12 = 0; num12 < cde8a4c2583bf0906e45ff26bb97a3d1d.Length; num12++)
											{
												MeshInstance meshInstance11 = cde8a4c2583bf0906e45ff26bb97a3d1d[num12];
												if (!meshInstance11.mesh)
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
												int[] triangles = meshInstance11.mesh.GetTriangles(meshInstance11.subMeshIndex);
												for (int num13 = 0; num13 < triangles.Length; num13++)
												{
													array8[num13 + num10] = triangles[num13] + num11;
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
												num10 += triangles.Length;
												num11 += meshInstance11.mesh.vertexCount;
											}
											while (true)
											{
												switch (4)
												{
												case 0:
													continue;
												}
												Mesh mesh = new Mesh();
												mesh.name = "Combined Mesh";
												mesh.vertices = array;
												mesh.normals = array2;
												mesh.colors = array7;
												mesh.uv = array4;
												mesh.uv1 = array5;
												mesh.uv2 = array6;
												mesh.tangents = array3;
												mesh.triangles = array8;
												return mesh;
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
	}

	private static void c587b7c49e72369a911cce8ad4829c0e5(int ccd72db90066b30ea7c672985da09dc03, Vector3[] c52511d1cb7a4974a8a4536d2cf3b423e, Vector3[] cfe2e8ee36dfb4f11f7ee1fb8d70c63dd, ref int c52921fe9488ee3d539be727c81094423, Matrix4x4 c63017dffbb632e326f1f0dbbd1ca49ca)
	{
		for (int i = 0; i < c52511d1cb7a4974a8a4536d2cf3b423e.Length; i++)
		{
			cfe2e8ee36dfb4f11f7ee1fb8d70c63dd[i + c52921fe9488ee3d539be727c81094423] = c63017dffbb632e326f1f0dbbd1ca49ca.MultiplyPoint(c52511d1cb7a4974a8a4536d2cf3b423e[i]);
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
			c52921fe9488ee3d539be727c81094423 += ccd72db90066b30ea7c672985da09dc03;
			return;
		}
	}

	private static void cbc13e88b7f05f991e60be9bcf3b108e7(int ccd72db90066b30ea7c672985da09dc03, Vector3[] c52511d1cb7a4974a8a4536d2cf3b423e, Vector3[] cfe2e8ee36dfb4f11f7ee1fb8d70c63dd, ref int c52921fe9488ee3d539be727c81094423, Matrix4x4 c63017dffbb632e326f1f0dbbd1ca49ca)
	{
		for (int i = 0; i < c52511d1cb7a4974a8a4536d2cf3b423e.Length; i++)
		{
			cfe2e8ee36dfb4f11f7ee1fb8d70c63dd[i + c52921fe9488ee3d539be727c81094423] = c63017dffbb632e326f1f0dbbd1ca49ca.MultiplyVector(c52511d1cb7a4974a8a4536d2cf3b423e[i]).normalized;
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
			c52921fe9488ee3d539be727c81094423 += ccd72db90066b30ea7c672985da09dc03;
			return;
		}
	}

	private static void c587b7c49e72369a911cce8ad4829c0e5(int ccd72db90066b30ea7c672985da09dc03, Vector2[] c52511d1cb7a4974a8a4536d2cf3b423e, Vector2[] cfe2e8ee36dfb4f11f7ee1fb8d70c63dd, ref int c52921fe9488ee3d539be727c81094423)
	{
		for (int i = 0; i < c52511d1cb7a4974a8a4536d2cf3b423e.Length; i++)
		{
			cfe2e8ee36dfb4f11f7ee1fb8d70c63dd[i + c52921fe9488ee3d539be727c81094423] = c52511d1cb7a4974a8a4536d2cf3b423e[i];
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c52921fe9488ee3d539be727c81094423 += ccd72db90066b30ea7c672985da09dc03;
			return;
		}
	}

	private static void c3fd6328280d027af5c2dd9bdf50ea7a7(int ccd72db90066b30ea7c672985da09dc03, Vector2[] c52511d1cb7a4974a8a4536d2cf3b423e, Vector2[] cfe2e8ee36dfb4f11f7ee1fb8d70c63dd, ref int c52921fe9488ee3d539be727c81094423, float c4ad83a336558d0c09f030ef7e630cd08, float c5ebdc65d5cb420faf7ba524809963aa9)
	{
		for (int i = 0; i < c52511d1cb7a4974a8a4536d2cf3b423e.Length; i++)
		{
			cfe2e8ee36dfb4f11f7ee1fb8d70c63dd[i + c52921fe9488ee3d539be727c81094423] = c52511d1cb7a4974a8a4536d2cf3b423e[i] * c4ad83a336558d0c09f030ef7e630cd08 + new Vector2(c5ebdc65d5cb420faf7ba524809963aa9, 0f);
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
			c52921fe9488ee3d539be727c81094423 += ccd72db90066b30ea7c672985da09dc03;
			return;
		}
	}

	private static void c46bfd8d901ffbc58695bdaac392b9f7b(int ccd72db90066b30ea7c672985da09dc03, Color[] c52511d1cb7a4974a8a4536d2cf3b423e, Color[] cfe2e8ee36dfb4f11f7ee1fb8d70c63dd, ref int c52921fe9488ee3d539be727c81094423)
	{
		for (int i = 0; i < c52511d1cb7a4974a8a4536d2cf3b423e.Length; i++)
		{
			cfe2e8ee36dfb4f11f7ee1fb8d70c63dd[i + c52921fe9488ee3d539be727c81094423] = c52511d1cb7a4974a8a4536d2cf3b423e[i];
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
			c52921fe9488ee3d539be727c81094423 += ccd72db90066b30ea7c672985da09dc03;
			return;
		}
	}

	private static void c00b740658612a98ee2be568dc797319d(int ccd72db90066b30ea7c672985da09dc03, Vector4[] c52511d1cb7a4974a8a4536d2cf3b423e, Vector4[] cfe2e8ee36dfb4f11f7ee1fb8d70c63dd, ref int c52921fe9488ee3d539be727c81094423, Matrix4x4 c63017dffbb632e326f1f0dbbd1ca49ca)
	{
		for (int i = 0; i < c52511d1cb7a4974a8a4536d2cf3b423e.Length; i++)
		{
			Vector4 vector = c52511d1cb7a4974a8a4536d2cf3b423e[i];
			Vector3 v = new Vector3(vector.x, vector.y, vector.z);
			v = c63017dffbb632e326f1f0dbbd1ca49ca.MultiplyVector(v).normalized;
			cfe2e8ee36dfb4f11f7ee1fb8d70c63dd[i + c52921fe9488ee3d539be727c81094423] = new Vector4(v.x, v.y, v.z, vector.w);
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
			c52921fe9488ee3d539be727c81094423 += ccd72db90066b30ea7c672985da09dc03;
			return;
		}
	}
}
