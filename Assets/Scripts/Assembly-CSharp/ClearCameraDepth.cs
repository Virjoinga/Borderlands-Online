using UnityEngine;

public class ClearCameraDepth : MonoBehaviour
{
	public Camera mWpnCamera;

	private void FixedUpdate()
	{
		if (!mWpnCamera)
		{
			return;
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
			base.camera.worldToCameraMatrix = mWpnCamera.worldToCameraMatrix;
			base.camera.transform.position = mWpnCamera.transform.position;
			base.camera.transform.rotation = mWpnCamera.transform.rotation;
			base.camera.ResetWorldToCameraMatrix();
			return;
		}
	}
}
