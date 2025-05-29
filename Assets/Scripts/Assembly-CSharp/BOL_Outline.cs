using A;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/BOL Outline")]
[RequireComponent(typeof(Camera))]
public class BOL_Outline : MonoBehaviour
{
	public enum AntiAliasSwitch
	{
		AntiAliasingOff = 0,
		AntiAliasingOn = 1
	}

	public enum ArtStyleSwitch
	{
		ArtStyle_BOL = 0,
		ArtStyle_Lines = 1,
		ArtStyle_Brush = 2
	}

	public enum AntiRimLightingSwitch
	{
		AntiRimLighting_OFF = 0,
		AntiRimLighting_ON2 = 1
	}

	public Shader m_BOL_Outline_Shader;

	private Material m_BOL_Outline_Material;

	public Texture2D m_RandomTexture;

	public AntiAliasSwitch m_AntiAliasSwitch = AntiAliasSwitch.AntiAliasingOn;

	public ArtStyleSwitch m_ArtStyleSwitch;

	public float m_LineWidth = 1.5f;

	public float m_LineSoftness = 0.5f;

	public AntiRimLightingSwitch m_AntiRimLightingSwitch = AntiRimLightingSwitch.AntiRimLighting_ON2;

	private static Material c172f9d0eb2874d9d30bb9354caf9aab4(Shader c40c70042e9f80ae992c24cd664606aca)
	{
		if (!c40c70042e9f80ae992c24cd664606aca)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return null;
				}
			}
		}
		Material material = new Material(c40c70042e9f80ae992c24cd664606aca);
		material.hideFlags = HideFlags.HideAndDontSave;
		return material;
	}

	private static void cf872b94395c2b6f5dd22c3fb8af150cd(Material c4b37d539f2c2303a31bf314f3f555bef)
	{
		if (!c4b37d539f2c2303a31bf314f3f555bef)
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
			Object.DestroyImmediate(c4b37d539f2c2303a31bf314f3f555bef);
			c4b37d539f2c2303a31bf314f3f555bef = cbea7b81e65efa29a099764b7785c1976.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	private void OnDisable()
	{
		cf872b94395c2b6f5dd22c3fb8af150cd(m_BOL_Outline_Material);
	}

	private void Start()
	{
		if (SystemInfo.supportsImageEffects)
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
			if (SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
			{
				c72c7481f513b7200638e67d1a5e9fb4e();
				if ((bool)m_BOL_Outline_Material)
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
					if (m_BOL_Outline_Material.passCount == 6)
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
						break;
					}
				}
				base.enabled = false;
				return;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		base.enabled = false;
	}

	private void OnEnable()
	{
		base.camera.depthTextureMode |= DepthTextureMode.DepthNormals;
	}

	private void c72c7481f513b7200638e67d1a5e9fb4e()
	{
		if ((bool)m_BOL_Outline_Material)
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
			if (!m_BOL_Outline_Shader.isSupported)
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
				m_BOL_Outline_Material = c172f9d0eb2874d9d30bb9354caf9aab4(m_BOL_Outline_Shader);
				m_BOL_Outline_Material.SetTexture("_RandomTexture", m_RandomTexture);
				return;
			}
		}
	}

	[ImageEffectOpaque]
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		c72c7481f513b7200638e67d1a5e9fb4e();
		RenderTexture temporary;
		RenderTexture temporary2;
		if (m_AntiAliasSwitch == AntiAliasSwitch.AntiAliasingOn)
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
			temporary = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.ARGBHalf);
			temporary2 = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.ARGBHalf);
		}
		else
		{
			temporary = RenderTexture.GetTemporary(source.width, source.height, 0);
			temporary2 = RenderTexture.GetTemporary(source.width, source.height, 0);
		}
		temporary.name = "BOL_Outline_rtEC0";
		temporary2.name = "BOL_Outline_rtEC1";
		temporary.filterMode = FilterMode.Point;
		temporary2.filterMode = FilterMode.Point;
		Graphics.Blit(source, temporary, m_BOL_Outline_Material, 0);
		m_BOL_Outline_Material.SetFloat("_Step", 1f);
		m_BOL_Outline_Material.SetTexture("_BOL", temporary);
		Graphics.Blit(source, temporary2, m_BOL_Outline_Material, 1);
		m_BOL_Outline_Material.SetFloat("_Step", 2f);
		m_BOL_Outline_Material.SetTexture("_BOL", temporary2);
		Graphics.Blit(source, temporary, m_BOL_Outline_Material, 1);
		m_BOL_Outline_Material.SetFloat("_Step", 4f);
		m_BOL_Outline_Material.SetTexture("_BOL", temporary);
		Graphics.Blit(source, temporary2, m_BOL_Outline_Material, 1);
		m_BOL_Outline_Material.SetFloat("_Step", 8f);
		m_BOL_Outline_Material.SetTexture("_BOL", temporary2);
		Graphics.Blit(source, temporary, m_BOL_Outline_Material, 1);
		m_BOL_Outline_Material.SetFloat("_Step", 16f);
		m_BOL_Outline_Material.SetTexture("_BOL", temporary);
		Graphics.Blit(source, temporary2, m_BOL_Outline_Material, 1);
		if (m_AntiAliasSwitch == AntiAliasSwitch.AntiAliasingOn)
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
			m_BOL_Outline_Material.SetTexture("_BOL", temporary2);
			Graphics.Blit(source, temporary, m_BOL_Outline_Material, 2);
			m_BOL_Outline_Material.SetTexture("_NoiseTex", m_RandomTexture);
			m_BOL_Outline_Material.SetTexture("_BOL", temporary);
		}
		else
		{
			m_BOL_Outline_Material.SetTexture("_NoiseTex", m_RandomTexture);
			m_BOL_Outline_Material.SetTexture("_BOL", temporary2);
		}
		m_LineWidth = Mathf.Clamp(m_LineWidth, 1f, 3f);
		m_LineSoftness = Mathf.Clamp(m_LineSoftness, 0f, 2f);
		if (m_AntiRimLightingSwitch == AntiRimLightingSwitch.AntiRimLighting_OFF)
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
			m_BOL_Outline_Material.SetFloat("_AntiRimParam", 0f);
		}
		else if (m_AntiRimLightingSwitch == AntiRimLightingSwitch.AntiRimLighting_ON2)
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
			m_BOL_Outline_Material.SetFloat("_AntiRimParam", 2f);
		}
		if (m_ArtStyleSwitch == ArtStyleSwitch.ArtStyle_BOL)
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
			m_BOL_Outline_Material.SetFloat("_LineWidth", (m_LineWidth - 1f) * 0.5f);
			m_BOL_Outline_Material.SetFloat("_LineSoftness", m_LineSoftness + 1f);
			Graphics.Blit(source, destination, m_BOL_Outline_Material, 3);
		}
		else if (m_ArtStyleSwitch == ArtStyleSwitch.ArtStyle_Lines)
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
			m_BOL_Outline_Material.SetFloat("_LineWidth", (m_LineWidth - 1f) * 0.5f);
			m_BOL_Outline_Material.SetFloat("_LineSoftness", m_LineSoftness + 1f);
			Graphics.Blit(source, destination, m_BOL_Outline_Material, 4);
		}
		else if (m_ArtStyleSwitch == ArtStyleSwitch.ArtStyle_Brush)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			Graphics.Blit(source, destination, m_BOL_Outline_Material, 5);
		}
		RenderTexture.ReleaseTemporary(temporary);
		RenderTexture.ReleaseTemporary(temporary2);
	}
}
