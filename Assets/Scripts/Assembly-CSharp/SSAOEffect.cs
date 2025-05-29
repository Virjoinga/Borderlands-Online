using System;
using A;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Screen Space Ambient Occlusion")]
[ExecuteInEditMode]
public class SSAOEffect : MonoBehaviour
{
	public enum SSAOSamples
	{
		Low = 0,
		Medium = 1,
		High = 2
	}

	public float m_Radius = 0.4f;

	public SSAOSamples m_SampleCount = SSAOSamples.Medium;

	public float m_OcclusionIntensity = 1.5f;

	public int m_Blur = 2;

	public int m_Downsampling = 2;

	public float m_OcclusionAttenuation = 1f;

	public float m_MinZ = 0.01f;

	public float m_NoSsaoDist = 50f;

	public Shader m_SSAOShader;

	private Material m_SSAOMaterial;

	public Texture2D m_RandomTexture;

	private bool m_Supported;

	private static Material c172f9d0eb2874d9d30bb9354caf9aab4(Shader c40c70042e9f80ae992c24cd664606aca)
	{
		if (!c40c70042e9f80ae992c24cd664606aca)
		{
			while (true)
			{
				switch (6)
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
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			UnityEngine.Object.DestroyImmediate(c4b37d539f2c2303a31bf314f3f555bef);
			c4b37d539f2c2303a31bf314f3f555bef = cbea7b81e65efa29a099764b7785c1976.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	private void OnDisable()
	{
		cf872b94395c2b6f5dd22c3fb8af150cd(m_SSAOMaterial);
	}

	private void Start()
	{
		if (SystemInfo.supportsImageEffects)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
			{
				c72c7481f513b7200638e67d1a5e9fb4e();
				if ((bool)m_SSAOMaterial)
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
					if (m_SSAOMaterial.passCount == 5)
					{
						m_Supported = true;
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
				m_Supported = false;
				base.enabled = false;
				return;
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
		m_Supported = false;
		base.enabled = false;
	}

	private void OnEnable()
	{
		base.camera.depthTextureMode |= DepthTextureMode.DepthNormals;
	}

	private void c72c7481f513b7200638e67d1a5e9fb4e()
	{
		if ((bool)m_SSAOMaterial)
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
			if (!m_SSAOShader.isSupported)
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
				m_SSAOMaterial = c172f9d0eb2874d9d30bb9354caf9aab4(m_SSAOShader);
				m_SSAOMaterial.SetTexture("_RandomTexture", m_RandomTexture);
				return;
			}
		}
	}

	[ImageEffectOpaque]
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (m_Supported)
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
			if (m_SSAOShader.isSupported)
			{
				c72c7481f513b7200638e67d1a5e9fb4e();
				m_Downsampling = Mathf.Clamp(m_Downsampling, 1, 6);
				m_Radius = Mathf.Clamp(m_Radius, 0.05f, 1f);
				m_MinZ = Mathf.Clamp(m_MinZ, 1E-05f, 0.5f);
				m_OcclusionIntensity = Mathf.Clamp(m_OcclusionIntensity, 0.5f, 4f);
				m_OcclusionAttenuation = Mathf.Clamp(m_OcclusionAttenuation, 0.2f, 2f);
				m_Blur = Mathf.Clamp(m_Blur, 0, 4);
				RenderTexture renderTexture = RenderTexture.GetTemporary(source.width / m_Downsampling, source.height / m_Downsampling, 0);
				renderTexture.name = "SSAOEffect_rtAO";
				float fieldOfView = base.camera.fieldOfView;
				float farClipPlane = base.camera.farClipPlane;
				float num = Mathf.Tan(fieldOfView * ((float)Math.PI / 180f) * 0.5f) * farClipPlane;
				float x = num * base.camera.aspect;
				m_SSAOMaterial.SetVector("_FarCorner", new Vector3(x, num, farClipPlane));
				int num2;
				int num3;
				if ((bool)m_RandomTexture)
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
					num2 = m_RandomTexture.width;
					num3 = m_RandomTexture.height;
				}
				else
				{
					num2 = 1;
					num3 = 1;
				}
				m_SSAOMaterial.SetVector("_NoiseScale", new Vector3((float)renderTexture.width / (float)num2, (float)renderTexture.height / (float)num3, 0f));
				m_SSAOMaterial.SetVector("_Params", new Vector4(m_Radius, m_MinZ, 1f / m_OcclusionAttenuation, m_OcclusionIntensity));
				m_SSAOMaterial.SetFloat("_NoSsaoDist", m_NoSsaoDist);
				bool flag = m_Blur > 0;
				object source2;
				if (flag)
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
					source2 = null;
				}
				else
				{
					source2 = source;
				}
				Graphics.Blit((Texture)source2, renderTexture, m_SSAOMaterial, (int)m_SampleCount);
				if (flag)
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
					RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 0);
					temporary.name = "SSAOEffect_rtBlurX";
					m_SSAOMaterial.SetVector("_TexelOffsetScale", new Vector4((float)m_Blur / (float)source.width, 0f, 0f, 0f));
					m_SSAOMaterial.SetTexture("_SSAO", renderTexture);
					Graphics.Blit(null, temporary, m_SSAOMaterial, 3);
					RenderTexture.ReleaseTemporary(renderTexture);
					RenderTexture temporary2 = RenderTexture.GetTemporary(source.width, source.height, 0);
					temporary2.name = "SSAOEffect_rtBlurY";
					m_SSAOMaterial.SetVector("_TexelOffsetScale", new Vector4(0f, (float)m_Blur / (float)source.height, 0f, 0f));
					m_SSAOMaterial.SetTexture("_SSAO", temporary);
					Graphics.Blit(source, temporary2, m_SSAOMaterial, 3);
					RenderTexture.ReleaseTemporary(temporary);
					renderTexture = temporary2;
				}
				m_SSAOMaterial.SetTexture("_SSAO", renderTexture);
				Graphics.Blit(source, destination, m_SSAOMaterial, 4);
				RenderTexture.ReleaseTemporary(renderTexture);
				return;
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
		}
		base.enabled = false;
	}
}
