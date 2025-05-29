using Core;
using UnityEngine;

public class VertexDataCache : MonoBehaviour
{
	[HideInInspector]
	public Vector3[] vertices;

	[HideInInspector]
	public Vector3[] normals;

	[HideInInspector]
	public Vector4[] tangents;

	[HideInInspector]
	public Vector2[] uv1;

	[HideInInspector]
	public Vector2[] uv2;

	[HideInInspector]
	public int[] triangles;

	[ContextMenu("Cache")]
	public void cba02ca1a8a050ac54c694317b191cc63()
	{
		MeshFilter component = GetComponent<MeshFilter>();
		if (!component)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Graphics, "This method requires a mesh filter!");
					return;
				}
			}
		}
		Mesh sharedMesh = component.sharedMesh;
		vertices = sharedMesh.vertices;
		normals = sharedMesh.normals;
		tangents = sharedMesh.tangents;
		uv1 = sharedMesh.uv;
		uv2 = sharedMesh.uv2;
		triangles = sharedMesh.triangles;
	}

	public Mesh cdde5b1604999906d214f0b05ebcc515b()
	{
		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.normals = normals;
		mesh.tangents = tangents;
		mesh.uv = uv1;
		mesh.uv2 = uv2;
		mesh.triangles = triangles;
		return mesh;
	}
}
