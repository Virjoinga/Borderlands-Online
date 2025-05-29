using A;
using UnityEngine;

public class TreasureBoxBehaviour : MonoBehaviour
{
	private Camera m_Camera;

	private static GameObject m_CameraObj;

	public RenderTexture m_RTexture;

	public void Start()
	{
		GameObject gameObject = base.gameObject.transform.parent.gameObject;
		if (!(gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Transform component = gameObject.GetComponent<Transform>();
			for (int i = 0; i < component.childCount; i++)
			{
				if (!(component.GetChild(i).gameObject.name == "Camera"))
				{
					continue;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					m_CameraObj = component.GetChild(i).gameObject;
					m_Camera = m_CameraObj.GetComponent<Camera>();
					m_RTexture = new RenderTexture(512, 512, 24);
					m_RTexture.name = "TreasureBox_RT";
					m_RTexture.Create();
					m_Camera.clearFlags = CameraClearFlags.Skybox;
					m_Camera.targetTexture = m_RTexture;
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTreasureBoxView>().c34d668560660d3e6282a1bcef2bc598b(m_RTexture);
					return;
				}
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	public void Awake()
	{
	}

	private void Update()
	{
	}

	public static void c4b862ab166e0c3a6993a9cef5f0b64ab()
	{
		if (m_CameraObj.activeSelf)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_CameraObj.SetActive(true);
			return;
		}
	}
}
