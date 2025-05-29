using A;
using UnityEngine;

public class LightPillar : MonoBehaviour
{
	public float m_LightPillarSpeed = 1f;

	public float m_LightPillarInterval = 1f;

	public float m_LightPillarOffset;

	private float m_LightPillarStartTime;

	private void Start()
	{
	}

	private void OnWillRenderObject()
	{
		Renderer component = GetComponent<MeshRenderer>();
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
			for (int i = 0; i < component.materials.Length; i++)
			{
				Material material = component.renderer.materials[i];
				if (!(material != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!(material.shader.name == "TKC/Scene/LightPillar"))
				{
					continue;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				float time = Time.time;
				float num = (time - (float)(int)m_LightPillarStartTime) * m_LightPillarSpeed;
				if ((double)num < 1.0)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					material.SetFloat("_EmissiveOffset", num - m_LightPillarOffset);
					continue;
				}
				float num2 = 1f / m_LightPillarSpeed;
				if (!(time > m_LightPillarStartTime + m_LightPillarInterval + num2))
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
				m_LightPillarStartTime = time;
			}
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
	}
}
