using A;
using UnityEngine;

[AddComponentMenu("")]
[RequireComponent(typeof(Camera))]
public class ImageEffectBase : MonoBehaviour
{
	public Shader shader;

	private Material m_Material;

	protected Material cf4af10ce9fa4ab84bd021b054d46a667
	{
		get
		{
			if (m_Material == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_Material = new Material(shader);
				m_Material.hideFlags = HideFlags.HideAndDontSave;
			}
			return m_Material;
		}
	}

	protected virtual void Start()
	{
		if (!SystemInfo.supportsImageEffects)
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
					base.enabled = false;
					return;
				}
			}
		}
		if ((bool)shader)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			if (shader.isSupported)
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
				break;
			}
		}
		base.enabled = false;
	}

	protected virtual void OnDisable()
	{
		if (!m_Material)
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
			Object.DestroyImmediate(m_Material);
			return;
		}
	}
}
