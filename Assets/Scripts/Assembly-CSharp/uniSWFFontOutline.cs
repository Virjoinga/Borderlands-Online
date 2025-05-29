using A;
using UnityEngine;

public class uniSWFFontOutline : FontOutline
{
	private void OnDestroy()
	{
		Object.Destroy(edgeDetectMaterial);
	}

	private void OnDisable()
	{
		if (!edgeDetectMaterial)
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
			Object.DestroyImmediate(edgeDetectMaterial);
			return;
		}
	}

	private void Awake()
	{
		CheckResources();
		Camera component = base.gameObject.GetComponent<Camera>();
		if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			component.cullingMask = 1 << LayerMask.NameToLayer("UI");
			return;
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		CheckResources();
	}

	public void c62ef01b9ff5defc3f7fb88c46b15e6f3(RenderTexture cb7c736b17bc53c850d891f1f2cf5bdb9, RenderTexture cd6a7967330188dc1a6131ff919985c04)
	{
		if (CheckResources())
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					cdad12a81653cd0167fa41848bcc3405e(cb7c736b17bc53c850d891f1f2cf5bdb9, cd6a7967330188dc1a6131ff919985c04);
					return;
				}
			}
		}
		Graphics.Blit(cb7c736b17bc53c850d891f1f2cf5bdb9, cd6a7967330188dc1a6131ff919985c04);
	}
}
