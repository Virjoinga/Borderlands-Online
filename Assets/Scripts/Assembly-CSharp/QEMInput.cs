using UnityEngine;

internal class QEMInput
{
	public float m_percentage = 0.5f;

	public float s_vertexCombineThreshold = 0.001f;

	public int s_boundaryPlaneWeight = 100;

	public Vector2[] m_uv;

	public float m_uvWeight;

	public Vector2[] m_uv2;

	public float m_uv2Weight;

	public Vector3[] m_normal;

	public float m_normalWeight;

	public Vector3[] m_vertex;

	public int[] m_triangle;
}
