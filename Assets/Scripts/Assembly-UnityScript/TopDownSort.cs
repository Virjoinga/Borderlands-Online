using System;
using UnityEngine;

[Serializable]
public class TopDownSort : MonoBehaviour
{
	public float layerId;

	public Vector3 offset;

	public Vector3 basePos;

	public float zScale;

	public float zLayerScale;

	private Vector3 m_Vec;

	public TopDownSort()
	{
		zScale = 0.01f;
		zLayerScale = 1f;
	}

	public virtual void Start()
	{
		updateBasePos();
	}

	public virtual void updateBasePos()
	{
		GameObject gameObject = GameObject.Find("Bounds");
		if ((bool)gameObject)
		{
			basePos = gameObject.transform.position;
		}
	}

	public virtual void Update()
	{
		m_Vec = transform.position;
		m_Vec.y = layerId * zLayerScale - (basePos.z - (m_Vec.z + offset.z)) * (0f - zScale);
		transform.position = m_Vec;
	}
}
