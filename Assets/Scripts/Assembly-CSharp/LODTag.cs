using UnityEngine;

public class LODTag : MonoBehaviour
{
	public int levelsOfDetial = 3;

	private void Start()
	{
		LODSystem.cdd06e4efd6e69863d8b70e6de8c9542e(base.gameObject, levelsOfDetial);
	}

	private void Update()
	{
	}
}
