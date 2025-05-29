using A;
using UnityEngine;

[AddComponentMenu("Image Effects/Gamma")]
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class GammaEffect : MonoBehaviour
{
	public Shader shaderGamma;

	private Material m_matGamma;

	protected Material cf4af10ce9fa4ab84bd021b054d46a667
	{
		get
		{
			if (m_matGamma == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (7)
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
				m_matGamma = new Material(shaderGamma);
				m_matGamma.hideFlags = HideFlags.HideAndDontSave;
			}
			return m_matGamma;
		}
	}

	protected void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			while (true)
			{
				switch (4)
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
		if (shaderGamma == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					base.enabled = false;
					return;
				}
			}
		}
		if (shaderGamma.isSupported)
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
			base.enabled = false;
			return;
		}
	}

	protected void OnDisable()
	{
		if (!m_matGamma)
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
			Object.DestroyImmediate(m_matGamma);
			return;
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, cf4af10ce9fa4ab84bd021b054d46a667);
	}
}
