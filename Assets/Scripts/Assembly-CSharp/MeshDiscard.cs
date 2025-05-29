using A;
using UnityEngine;

public class MeshDiscard : MonoBehaviour
{
	public GameObject mStartPos;

	public GameObject mStopPos;

	public GameObject mCurPos;

	private void Start()
	{
	}

	private void Update()
	{
		MeshRenderer component = base.gameObject.GetComponent<MeshRenderer>();
		if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Material material = component.material;
			material.SetVector("_StartPosInWS", mStartPos.transform.position);
			material.SetVector("_StopPostInWS", mStopPos.transform.position);
			material.SetVector("_CurPosInWS", mCurPos.transform.position);
			return;
		}
	}
}
