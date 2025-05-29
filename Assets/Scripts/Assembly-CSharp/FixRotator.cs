using UnityEngine;

public class FixRotator : MonoBehaviour
{
	private Transform m_myTransform;

	public Vector3 m_globalRotationAngles = Vector3.zero;

	private void Awake()
	{
		m_myTransform = base.transform;
	}

	private void LateUpdate()
	{
		m_myTransform.rotation = Quaternion.Euler(m_globalRotationAngles);
	}
}
