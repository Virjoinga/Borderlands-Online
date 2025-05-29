using System;
using A;
using UnityEngine;

public class BassBillboard : MonoBehaviour
{
	public Camera m_camera;

	public bool m_isActive = true;

	public bool m_isVertical;

	private Renderer m_render;

	public void Start()
	{
		m_render = (Renderer)base.gameObject.GetComponent(Type.GetTypeFromHandle(c1e516986f72a006d858f0218621fc458.cc1720d05c75832f704b87474932341c3()));
		if (!c06ca0e618478c23eba3419653a19760f<VisibilityManager>.c5ee19dc8d4cccf5ae2de225410458b86)
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
			if (!m_render)
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
				c06ca0e618478c23eba3419653a19760f<VisibilityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c57e4d4cd41f3be21d7e24a71aa08c6ba(m_render);
				return;
			}
		}
	}

	private void Ondestroy()
	{
		if (!c06ca0e618478c23eba3419653a19760f<VisibilityManager>.c5ee19dc8d4cccf5ae2de225410458b86)
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
			if (!m_render)
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
				c06ca0e618478c23eba3419653a19760f<VisibilityManager>.c5ee19dc8d4cccf5ae2de225410458b86.cf5212e6903ec0c0b27816142c32a2d13(m_render);
				return;
			}
		}
	}

	public void cf56993352e12c8ddfb28612b4def357f()
	{
		if (m_camera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		for (int i = 0; i < Camera.allCameras.Length; i++)
		{
			Camera camera = Camera.allCameras[i];
			if (!camera.name.ToLower().Contains("fps"))
			{
				continue;
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
			m_camera = camera;
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	private void OnWillRenderObject()
	{
		if (!m_isActive)
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			cf56993352e12c8ddfb28612b4def357f();
			if (!m_isVertical)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (m_camera == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									return;
								}
							}
						}
						base.transform.LookAt(base.transform.position + m_camera.transform.localToWorldMatrix.MultiplyVector(Vector3.forward), Vector3.up);
						return;
					}
				}
			}
			if (m_camera == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			Vector3 position = m_camera.transform.position;
			position.y = base.transform.position.y;
			base.transform.LookAt(position, Vector3.up);
			return;
		}
	}
}
