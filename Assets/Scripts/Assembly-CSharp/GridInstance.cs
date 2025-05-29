using UnityEngine;

public class GridInstance : MonoBehaviour
{
	[SerializeField]
	public Vector3 size;

	[SerializeField]
	public Vector3 halfsize;

	private void Awake()
	{
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(base.transform.position, size);
	}
}
