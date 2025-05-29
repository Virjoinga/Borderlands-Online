using A;
using UnityEngine;

public class DistrotionLogic : MonoBehaviour
{
	private GameObject mDistortionLogic;

	private Camera mFpsCamera;

	private Camera mDistortionCamera;

	private void Start()
	{
		mDistortionLogic = new GameObject("DistortionLogic");
		mDistortionLogic.transform.parent = base.gameObject.transform;
		if (mFpsCamera == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			mFpsCamera = base.gameObject.GetComponent<Camera>();
		}
		mDistortionCamera = mDistortionLogic.AddComponent<Camera>();
		Utils.c2a8451521957c62f3c9e4fe1e3e5797d(ref mFpsCamera, ref mDistortionCamera);
		Utils.c2a8451521957c62f3c9e4fe1e3e5797d(ref mFpsCamera, ref mDistortionCamera);
		mDistortionCamera.targetTexture = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ccffb6c52596bb8aa19fb001ee528ca6d().cb1e1e0af9cca2ee1cdfd093cc80f79e1();
		mDistortionCamera.cullingMask = 131072;
		mDistortionCamera.clearFlags = CameraClearFlags.Color;
		mDistortionCamera.backgroundColor = Color.black;
	}

	private void FixedUpdate()
	{
		if (!(mFpsCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!(mDistortionCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				mDistortionCamera.worldToCameraMatrix = mFpsCamera.worldToCameraMatrix;
				mDistortionCamera.transform.position = mFpsCamera.transform.position;
				mDistortionCamera.transform.rotation = mFpsCamera.transform.rotation;
				mDistortionCamera.ResetWorldToCameraMatrix();
				return;
			}
		}
	}
}
