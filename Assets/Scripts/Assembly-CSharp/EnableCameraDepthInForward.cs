using UnityEngine;

[RequireComponent(typeof(Camera))]
public class EnableCameraDepthInForward : MonoBehaviour
{
	private void Start()
	{
		c107f68161c8b715372227214447cabf9();
	}

	private void c107f68161c8b715372227214447cabf9()
	{
		if (base.camera.depthTextureMode != 0)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			base.camera.depthTextureMode = DepthTextureMode.Depth;
			return;
		}
	}
}
