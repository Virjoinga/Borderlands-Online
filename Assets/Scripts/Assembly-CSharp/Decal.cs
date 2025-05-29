using System;
using System.Collections.Generic;
using A;
using UnityEngine;

public class Decal : MonoBehaviour
{
	public static int dCount;

	[HideInInspector]
	public GameObject affectedObject;

	public float maxAngle = 90f;

	private float angleCosine;

	[HideInInspector]
	public Bounds bounds;

	[HideInInspector]
	public float previousUVAngle;

	[HideInInspector]
	public Vector3 previousPosition;

	[HideInInspector]
	public Quaternion previousRotation;

	[HideInInspector]
	public Vector3 previousScale;

	[HideInInspector]
	public float previousMaxAngle;

	[HideInInspector]
	public float previousPushDistance = 0.009f;

	[HideInInspector]
	public Vector2 previousTiling;

	[HideInInspector]
	public Vector2 previousOffset;

	[HideInInspector]
	public bool useMeshCollider;

	public Vector2 tiling = Vector2.one;

	public Vector2 offset = Vector2.zero;

	[HideInInspector]
	public float uvAngle;

	private float uCos;

	private float vSin;

	public Material decalMaterial;

	[HideInInspector]
	public DecalMode decalMode;

	private static List<DecalPolygon> clippedPolygons = new List<DecalPolygon>(128);

	[HideInInspector]
	public Vector4 bottomPlane;

	[HideInInspector]
	public Vector4 topPlane;

	[HideInInspector]
	public Vector4 leftPlane;

	[HideInInspector]
	public Vector4 rightPlane;

	[HideInInspector]
	public Vector4 frontPlane;

	[HideInInspector]
	public Vector4 backPlane;

	[HideInInspector]
	public Vector3 decalNormal;

	[HideInInspector]
	public Vector3 decalCenter;

	[HideInInspector]
	public Vector3 decalTangent;

	[HideInInspector]
	public Vector3 decalBinormal;

	[HideInInspector]
	public Vector3 decalSize;

	public float pushDistance = 0.009f;

	private Mesh instanceMesh;

	public bool checkAutomatically;

	public LayerMask affectedLayers;

	public bool affectOtherDecals;

	public bool affectInactiveRenderers;

	[HideInInspector]
	public bool showAffectedObjectsOptions;

	[HideInInspector]
	public bool showObjects;

	private void OnDrawGizmosSelected()
	{
		c10dd081e0dcfaa1c0944cb1705a57375();
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.DrawWireCube(Vector3.zero, new Vector3(1f, 1f, 5f));
	}

	public void c10dd081e0dcfaa1c0944cb1705a57375()
	{
		bounds = new Bounds(base.transform.position, base.transform.lossyScale * 1.414214f);
	}

	public void ce281869c43f18fb7a3f5381b24b58075()
	{
		maxAngle = Mathf.Clamp(maxAngle, 0f, 180f);
		angleCosine = Mathf.Cos(maxAngle * ((float)Math.PI / 180f));
		uvAngle = Mathf.Clamp(uvAngle, 0f, 360f);
		uCos = Mathf.Cos(uvAngle * ((float)Math.PI / 180f));
		vSin = Mathf.Sin(uvAngle * ((float)Math.PI / 180f));
		if (affectedObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		Matrix4x4 worldToLocalMatrix = base.transform.worldToLocalMatrix;
		c9e8ad7b33575f08b12e908e910371e51(affectedObject, worldToLocalMatrix);
		if (!(instanceMesh != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			MeshRenderer meshRenderer = base.gameObject.GetComponent<MeshRenderer>();
			if (meshRenderer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			}
			meshRenderer.material = decalMaterial;
			MeshFilter meshFilter = base.gameObject.GetComponent<MeshFilter>();
			if (meshFilter == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				meshFilter = base.gameObject.AddComponent<MeshFilter>();
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(meshFilter.sharedMesh);
			}
			meshFilter.mesh = instanceMesh;
			instanceMesh = c8daf33963c4c831f4bebda3f27067f17.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c37e9f795abd5c836dec708e7a495581d()
	{
		MeshFilter component = base.gameObject.GetComponent<MeshFilter>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			UnityEngine.Object.DestroyImmediate(component.sharedMesh);
			UnityEngine.Object.DestroyImmediate(component);
		}
		MeshRenderer component2 = base.gameObject.GetComponent<MeshRenderer>();
		if (!(component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			UnityEngine.Object.DestroyImmediate(component2);
			return;
		}
	}

	private Vector3 c6419f7950ac507fab23e80b75110ece2(float[,] cc385d9018471945d25327e8673729b8d, Vector3 c8f2e6daa38c5f080addf79ac78ac1d7b, int c5ebdc65d5cb420faf7ba524809963aa9, int cdf8ebc7410f0549033e8e891f11aeecc)
	{
		return Vector3.Scale(c8f2e6daa38c5f080addf79ac78ac1d7b, new Vector3(c5ebdc65d5cb420faf7ba524809963aa9, cc385d9018471945d25327e8673729b8d[cdf8ebc7410f0549033e8e891f11aeecc, c5ebdc65d5cb420faf7ba524809963aa9], cdf8ebc7410f0549033e8e891f11aeecc));
	}

	public void c9e8ad7b33575f08b12e908e910371e51(GameObject cebae66039aadeac8deb1211786332a72, Matrix4x4 c435231341115d65162ffc1e7193d90ff)
	{
		decalCenter = cebae66039aadeac8deb1211786332a72.transform.InverseTransformPoint(base.transform.position);
		decalNormal = cebae66039aadeac8deb1211786332a72.transform.InverseTransformDirection(base.transform.up).normalized;
		decalBinormal = cebae66039aadeac8deb1211786332a72.transform.InverseTransformDirection(base.transform.right).normalized;
		decalTangent = cebae66039aadeac8deb1211786332a72.transform.InverseTransformDirection(base.transform.forward).normalized;
		float num = Mathf.Max(cebae66039aadeac8deb1211786332a72.transform.lossyScale.x, cebae66039aadeac8deb1211786332a72.transform.lossyScale.y);
		decalSize = new Vector3(base.transform.lossyScale.x / num, base.transform.lossyScale.x / num, base.transform.lossyScale.x / num);
		leftPlane = new Vector4(0f - decalBinormal.x, 0f - decalBinormal.y, 0f - decalBinormal.z, decalSize.y * 0.5f + Vector3.Dot(decalCenter, decalBinormal));
		rightPlane = new Vector4(decalBinormal.x, decalBinormal.y, decalBinormal.z, decalSize.y * 0.5f - Vector3.Dot(decalCenter, decalBinormal));
		backPlane = new Vector4(0f - decalTangent.x, 0f - decalTangent.y, 0f - decalTangent.z, decalSize.x * 0.5f + Vector3.Dot(decalCenter, decalTangent));
		frontPlane = new Vector4(decalTangent.x, decalTangent.y, decalTangent.z, decalSize.x * 0.5f - Vector3.Dot(decalCenter, decalTangent));
		topPlane = new Vector4(decalNormal.x, decalNormal.y, decalNormal.z, decalSize.z * 0.5f - Vector3.Dot(decalCenter, decalNormal));
		bottomPlane = new Vector4(0f - decalNormal.x, 0f - decalNormal.y, 0f - decalNormal.z, decalSize.z * 0.5f + Vector3.Dot(decalCenter, decalNormal));
		Mesh mesh = c8daf33963c4c831f4bebda3f27067f17.c7088de59e49f7108f520cf7e0bae167e;
		Terrain component = cebae66039aadeac8deb1211786332a72.GetComponent<Terrain>();
		int[] array4;
		Vector3[] array2;
		Vector3[] array;
		Vector4[] array3;
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			TerrainData terrainData = component.terrainData;
			int heightmapWidth = terrainData.heightmapWidth;
			int heightmapHeight = terrainData.heightmapHeight;
			Vector3 heightmapScale = terrainData.heightmapScale;
			float[,] heights = terrainData.GetHeights(0, 0, heightmapWidth, heightmapHeight);
			int num2 = (int)(decalCenter.x / heightmapScale.x);
			int num3 = (int)(decalCenter.z / heightmapScale.z);
			int num4 = (int)Mathf.Ceil(decalSize.x / heightmapScale.x);
			int num5 = (int)Mathf.Ceil(decalSize.z / heightmapScale.z);
			int num6;
			if (num4 > num5)
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
				num6 = num4;
			}
			else
			{
				num6 = num5;
			}
			int num7 = num6;
			num7 = 3 * num7 / 4 + 1;
			array = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04((num7 * 2 + 1) * (num7 * 2 + 1));
			array2 = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04((num7 * 2 + 1) * (num7 * 2 + 1));
			array3 = c6b9b486e00bdfd9ee7ce0bac7f34a00e.c0a0cdf4a196914163f7334d9b0781a04((num7 * 2 + 1) * (num7 * 2 + 1));
			array4 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(num7 * 2 * (num7 * 2) * 6);
			int num8 = 0;
			int num9 = 0;
			int num10 = 0;
			for (int i = num2 - num7; i <= num2 + num7; i++)
			{
				int num11;
				if (i < 0)
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
					num11 = 0;
				}
				else
				{
					num11 = i;
				}
				num9 = num11;
				int num12;
				if (num9 >= heightmapWidth)
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
					num12 = heightmapWidth - 1;
				}
				else
				{
					num12 = num9;
				}
				num9 = num12;
				for (int j = num3 - num7; j <= num3 + num7; j++)
				{
					int num13;
					if (j < 0)
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
						num13 = 0;
					}
					else
					{
						num13 = j;
					}
					num10 = num13;
					int num14;
					if (num10 >= heightmapHeight)
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
						num14 = heightmapHeight - 1;
					}
					else
					{
						num14 = num10;
					}
					num10 = num14;
					array[num8] = c6419f7950ac507fab23e80b75110ece2(heights, heightmapScale, num9, num10);
					array2[num8] = new Vector3(0f, 1f, 0f);
					array3[num8] = new Vector4(0f, 0f, -1f, -1f);
					num8++;
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
			num8 = 0;
			int num15 = num7 * 2 + 1;
			for (int k = 0; k < num7 * 2; k++)
			{
				for (int l = 0; l < num7 * 2; l++)
				{
					array4[6 * num8] = k * num15 + l;
					array4[6 * num8 + 1] = k * num15 + l + 1;
					array4[6 * num8 + 2] = (k + 1) * num15 + l;
					array4[6 * num8 + 3] = (k + 1) * num15 + l;
					array4[6 * num8 + 4] = k * num15 + l + 1;
					array4[6 * num8 + 5] = (k + 1) * num15 + l + 1;
					num8++;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						goto end_IL_063d;
					}
					continue;
					end_IL_063d:
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
				break;
			}
			mesh = new Mesh();
			mesh.vertices = array;
			mesh.normals = array2;
			mesh.tangents = array3;
			mesh.triangles = array4;
			mesh.RecalculateNormals();
			goto IL_075a;
		}
		if (decalMode == DecalMode.MESH_COLLIDER)
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
			if (cebae66039aadeac8deb1211786332a72.GetComponent<MeshCollider>() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				mesh = cebae66039aadeac8deb1211786332a72.GetComponent<MeshCollider>().sharedMesh;
			}
			else
			{
				mesh = c8daf33963c4c831f4bebda3f27067f17.c7088de59e49f7108f520cf7e0bae167e;
			}
		}
		if (!(mesh == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (decalMode != DecalMode.MESH_FILTER)
			{
				goto IL_073f;
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
		if (cebae66039aadeac8deb1211786332a72.GetComponent<BatchingMeshContainer>() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		mesh = cebae66039aadeac8deb1211786332a72.GetComponent<BatchingMeshContainer>().m_mesh;
		goto IL_073f;
		IL_073f:
		if (mesh == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
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
		goto IL_075a;
		IL_075a:
		array4 = mesh.triangles;
		array = mesh.vertices;
		array2 = mesh.normals;
		array3 = mesh.tangents;
		instanceMesh = c31cc3c2b6dafdb4545ecfef4d8380d7c(cff3f87356db17234ec941f7269319417(array4, array, array2, array3), cebae66039aadeac8deb1211786332a72.transform);
		array4 = cdaeaf95d71df33e056aef814d5b686ff.c7088de59e49f7108f520cf7e0bae167e;
		array2 = c7e47b2227048cd3c1ab2307c7def8132.c7088de59e49f7108f520cf7e0bae167e;
		array = c7e47b2227048cd3c1ab2307c7def8132.c7088de59e49f7108f520cf7e0bae167e;
		array3 = c0e552405175bc23f27c9b62d54b104ac.c7088de59e49f7108f520cf7e0bae167e;
	}

	private Mesh c31cc3c2b6dafdb4545ecfef4d8380d7c(int cc4da7627128ee75d456c90ce32de5f19, Transform c6cb66aa8544c442eb14b92180640f843)
	{
		if (clippedPolygons == null)
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
		if (clippedPolygons.Count <= 0)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return null;
				}
			}
		}
		if (cc4da7627128ee75d456c90ce32de5f19 < 3)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return null;
				}
			}
		}
		int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04((cc4da7627128ee75d456c90ce32de5f19 - 2) * 3);
		Vector3[] array2 = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(cc4da7627128ee75d456c90ce32de5f19);
		Vector3[] array3 = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(cc4da7627128ee75d456c90ce32de5f19);
		Vector2[] array4 = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(cc4da7627128ee75d456c90ce32de5f19);
		Vector4[] array5 = c6b9b486e00bdfd9ee7ce0bac7f34a00e.c0a0cdf4a196914163f7334d9b0781a04(cc4da7627128ee75d456c90ce32de5f19);
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		float num4 = 1f / decalSize.x;
		float num5 = 1f / decalSize.y;
		using (List<DecalPolygon>.Enumerator enumerator = clippedPolygons.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				DecalPolygon current = enumerator.Current;
				for (int i = 0; i < current.verticeCount; i++)
				{
					array2[num] = current.vertice[i];
					array3[num] = current.normal[i];
					array5[num] = current.tangent[i];
					if (i < current.verticeCount - 2)
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
						array[num2] = num3;
						array[num2 + 1] = num + 1;
						array[num2 + 2] = num + 2;
						num2 += 3;
					}
					num++;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						goto end_IL_0180;
					}
					continue;
					end_IL_0180:
					break;
				}
				num3 = num;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_019c;
				}
				continue;
				end_IL_019c:
				break;
			}
		}
		for (int j = 0; j < array2.Length; j++)
		{
			Vector3 lhs = array2[j] - decalCenter;
			float num6 = Vector3.Dot(lhs, decalTangent);
			float num7 = Vector3.Dot(lhs, decalBinormal);
			float num8 = num6 * num4;
			float num9 = num7 * num5;
			float num10 = num8 * uCos - num9 * vSin + 0.5f;
			float num11 = num8 * vSin + num9 * uCos + 0.5f;
			num10 *= tiling.x;
			num11 *= tiling.y;
			num10 += offset.x;
			num11 += offset.y;
			array4[j] = new Vector2(num10, num11);
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			for (int k = 0; k < array2.Length; k++)
			{
				array2[k] += array3[k] * pushDistance;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				Matrix4x4 matrix4x = base.transform.worldToLocalMatrix * c6cb66aa8544c442eb14b92180640f843.localToWorldMatrix;
				Matrix4x4 transpose = matrix4x.inverse.transpose;
				for (int l = 0; l < array2.Length; l++)
				{
					array2[l] = matrix4x.MultiplyPoint(array2[l]);
					array3[l] = transpose.MultiplyVector(array3[l]).normalized;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					Mesh mesh = new Mesh();
					mesh.vertices = array2;
					mesh.normals = array3;
					mesh.triangles = array;
					mesh.uv = array4;
					mesh.uv1 = array4;
					mesh.uv2 = array4;
					mesh.tangents = array5;
					return mesh;
				}
			}
		}
	}

	private int cff3f87356db17234ec941f7269319417(int[] c09583c63cbfbdcda97d5d9c5557f6129, Vector3[] c7fb0aefb8f2dc14cbe94d14d6b9a1c38, Vector3[] cac39042fb4f8f11421c87908902aa57e, Vector4[] cf2a21a6fe141ff09e93f2fbde463db3f)
	{
		int num;
		if (cf2a21a6fe141ff09e93f2fbde463db3f != null)
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
			num = ((cf2a21a6fe141ff09e93f2fbde463db3f.Length > 0) ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		bool flag = (byte)num != 0;
		DecalPolygon decalPolygon = new DecalPolygon();
		int num2 = 0;
		clippedPolygons.Clear();
		for (int i = 0; i < c09583c63cbfbdcda97d5d9c5557f6129.Length; i += 3)
		{
			int num3 = c09583c63cbfbdcda97d5d9c5557f6129[i];
			Vector3 vector = cac39042fb4f8f11421c87908902aa57e[num3];
			float num4 = Vector3.Dot(vector, decalNormal);
			if (num4 <= angleCosine)
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
			int num5 = c09583c63cbfbdcda97d5d9c5557f6129[i + 1];
			int num6 = c09583c63cbfbdcda97d5d9c5557f6129[i + 2];
			Vector3 vector2 = c7fb0aefb8f2dc14cbe94d14d6b9a1c38[num3];
			Vector3 vector3 = c7fb0aefb8f2dc14cbe94d14d6b9a1c38[num5];
			Vector3 vector4 = c7fb0aefb8f2dc14cbe94d14d6b9a1c38[num6];
			decalPolygon.verticeCount = 3;
			decalPolygon.vertice[0] = vector2;
			decalPolygon.vertice[1] = vector3;
			decalPolygon.vertice[2] = vector4;
			decalPolygon.normal[0] = vector;
			decalPolygon.normal[1] = vector;
			decalPolygon.normal[2] = vector;
			if (flag)
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
				Vector3 vector5 = cf2a21a6fe141ff09e93f2fbde463db3f[num3];
				Vector3 vector6 = cf2a21a6fe141ff09e93f2fbde463db3f[num5];
				Vector3 vector7 = cf2a21a6fe141ff09e93f2fbde463db3f[num6];
				decalPolygon.tangent[0] = vector5;
				decalPolygon.tangent[1] = vector6;
				decalPolygon.tangent[2] = vector7;
			}
			DecalPolygon decalPolygon2 = DecalPolygon.cf0a9a3bfee56e76a71a93f682acff18d(decalPolygon, frontPlane);
			if (decalPolygon2 == null)
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
			decalPolygon2 = DecalPolygon.cf0a9a3bfee56e76a71a93f682acff18d(decalPolygon2, backPlane);
			if (decalPolygon2 == null)
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
			decalPolygon2 = DecalPolygon.cf0a9a3bfee56e76a71a93f682acff18d(decalPolygon2, rightPlane);
			if (decalPolygon2 == null)
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
			decalPolygon2 = DecalPolygon.cf0a9a3bfee56e76a71a93f682acff18d(decalPolygon2, leftPlane);
			if (decalPolygon2 == null)
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
			decalPolygon2 = DecalPolygon.cf0a9a3bfee56e76a71a93f682acff18d(decalPolygon2, bottomPlane);
			if (decalPolygon2 == null)
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
			decalPolygon2 = DecalPolygon.cf0a9a3bfee56e76a71a93f682acff18d(decalPolygon2, topPlane);
			if (decalPolygon2 == null)
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
			num2 += decalPolygon2.verticeCount;
			if (decalPolygon2 == decalPolygon)
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
				decalPolygon2 = decalPolygon2.cec9cb9cf17a528b9795669bbc8fc8b30();
			}
			clippedPolygons.Add(decalPolygon2);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return num2;
		}
	}

	public bool c9a73ee7b9ee6ca3c3bd9ae3cc907a31c()
	{
		Transform transform = base.transform;
		bool result = false;
		maxAngle = Mathf.Clamp(maxAngle, 0f, 180f);
		uvAngle = Mathf.Clamp(uvAngle, 0f, 360f);
		if (previousPosition != transform.position)
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
			result = true;
		}
		else if (previousScale != transform.lossyScale)
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
			result = true;
		}
		else if (previousRotation != transform.rotation)
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
			result = true;
		}
		else if (previousPushDistance != pushDistance)
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
			result = true;
		}
		else if (previousTiling != tiling)
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
			result = true;
		}
		else if (previousOffset != offset)
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
			result = true;
		}
		else if (previousMaxAngle != maxAngle)
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
			result = true;
		}
		else if (previousUVAngle != uvAngle)
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
			result = true;
		}
		previousUVAngle = uvAngle;
		previousMaxAngle = maxAngle;
		previousTiling = tiling;
		previousOffset = offset;
		previousPushDistance = pushDistance;
		previousPosition = transform.position;
		previousRotation = transform.rotation;
		previousScale = transform.lossyScale;
		return result;
	}
}
