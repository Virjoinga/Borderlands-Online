using UnityEngine;

[RequireComponent(typeof(Camera))]
public class WeaponCameraControl : MonoBehaviour
{
	private Matrix4x4 m_camProjMatForCuntomShader;

	private void Awake()
	{
		cadd19e77c13c8635640e3b9931b64a0e();
	}

	public Matrix4x4 cd392a2edecfcb3ad1e1ec6bcd9e0afde()
	{
		return m_camProjMatForCuntomShader;
	}

	public Camera c26e0cf146dbd64d5e4f1d6aff5db6cb0()
	{
		return base.camera;
	}

	public void c1464352f09fbabfd919a7e4e32f66660(float c8edef52f4cb8053af575054fc74d9608)
	{
		base.camera.fieldOfView = c8edef52f4cb8053af575054fc74d9608;
		base.camera.ResetProjectionMatrix();
		cadd19e77c13c8635640e3b9931b64a0e();
	}

	public void cadd19e77c13c8635640e3b9931b64a0e()
	{
		m_camProjMatForCuntomShader = c9d517634e43878c67dc0f443afbd0092(base.camera.projectionMatrix);
	}

	public Matrix4x4 c9d517634e43878c67dc0f443afbd0092(Matrix4x4 cc0f05d90843be7a3df5b2be5c952378f)
	{
		Matrix4x4 result = cc0f05d90843be7a3df5b2be5c952378f;
		if (SystemInfo.graphicsDeviceVersion.IndexOf("Direct3D") > -1)
		{
			while (true)
			{
				switch (4)
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
			for (int i = 0; i < 4; i++)
			{
				result[1, i] = 0f - result[1, i];
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			for (int j = 0; j < 4; j++)
			{
				result[2, j] = result[2, j] * 0.5f + result[3, j] * 0.5f;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		return result;
	}
}
