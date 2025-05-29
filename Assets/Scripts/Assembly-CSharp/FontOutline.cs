using UnityEngine;

[AddComponentMenu("Image Effects/Font Outline")]
[ExecuteInEditMode]
public class FontOutline : PostEffectsBase
{
	public float sampleDist = 1f;

	public Shader edgeDetectShader;

	public Shader screenBlendShader;

	public Shader separableBlurShader;

	public float edgeExp = 1f;

	public Color edgeColor = Color.black;

	[Range(0f, 2f)]
	public int downsample = 1;

	[Range(0f, 10f)]
	public float blursize = 3f;

	[Range(0f, 4f)]
	public int fontBlurIterations = 2;

	[Range(0f, 6f)]
	public int outBloomIterations;

	public float bloomIntensity = 1f;

	[Range(0.1f, 10f)]
	public float outSpeBlurSpread = 1.5f;

	[Range(0f, 1f)]
	public float edgesOnly;

	public Color edgesOnlyBgColor = Color.white;

	protected Material edgeDetectMaterial;

	protected Material screenBlendMaterial;

	protected Material separableBlurMaterial;

	private void OnDestroy()
	{
		Object.Destroy(edgeDetectMaterial);
		Object.Destroy(screenBlendMaterial);
		Object.Destroy(separableBlurMaterial);
	}

	private void OnDisable()
	{
		if ((bool)edgeDetectMaterial)
		{
			while (true)
			{
				switch (6)
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
			Object.DestroyImmediate(edgeDetectMaterial);
		}
		if ((bool)screenBlendMaterial)
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
			Object.DestroyImmediate(screenBlendMaterial);
		}
		if (!separableBlurMaterial)
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
			Object.DestroyImmediate(separableBlurMaterial);
			return;
		}
	}

	public override bool CheckResources()
	{
		CheckSupport(true);
		edgeDetectMaterial = CheckShaderAndCreateMaterial(edgeDetectShader, edgeDetectMaterial);
		screenBlendMaterial = CheckShaderAndCreateMaterial(screenBlendShader, screenBlendMaterial);
		separableBlurMaterial = CheckShaderAndCreateMaterial(separableBlurShader, separableBlurMaterial);
		if (!isSupported)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			ReportAutoDisable();
		}
		return isSupported;
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!CheckResources())
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					Graphics.Blit(source, destination);
					return;
				}
			}
		}
		cdad12a81653cd0167fa41848bcc3405e(source, destination);
	}

	protected void cdad12a81653cd0167fa41848bcc3405e(RenderTexture cb7c736b17bc53c850d891f1f2cf5bdb9, RenderTexture cd6a7967330188dc1a6131ff919985c04)
	{
		edgeDetectMaterial.SetFloat("_SampleDistance", sampleDist);
		edgeDetectMaterial.SetFloat("_Exponent", edgeExp);
		edgeDetectMaterial.SetColor("_OutlineColor", edgeColor);
		edgeDetectMaterial.SetFloat("_BgFade", edgesOnly);
		edgeDetectMaterial.SetVector("_BgFadeColor", edgesOnlyBgColor);
		RenderTexture temporary = RenderTexture.GetTemporary(cb7c736b17bc53c850d891f1f2cf5bdb9.width, cb7c736b17bc53c850d891f1f2cf5bdb9.height, 0, cb7c736b17bc53c850d891f1f2cf5bdb9.format);
		temporary.filterMode = FilterMode.Bilinear;
		Graphics.Blit(cb7c736b17bc53c850d891f1f2cf5bdb9, temporary, edgeDetectMaterial, 0);
		float num = 1f / (1f * (float)(1 << downsample));
		edgeDetectMaterial.SetFloat("_Parameter", blursize * num);
		RenderTexture renderTexture = temporary;
		int width = renderTexture.width >> downsample;
		int height = renderTexture.height >> downsample;
		temporary = RenderTexture.GetTemporary(width, height, 0, cb7c736b17bc53c850d891f1f2cf5bdb9.format);
		temporary.filterMode = FilterMode.Bilinear;
		renderTexture.filterMode = FilterMode.Bilinear;
		Graphics.Blit(renderTexture, temporary, edgeDetectMaterial, 1);
		RenderTexture.ReleaseTemporary(renderTexture);
		for (int i = 0; i < fontBlurIterations; i++)
		{
			float num2 = (float)i * 1f;
			edgeDetectMaterial.SetFloat("_Parameter", blursize * num + num2);
			RenderTexture temporary2 = RenderTexture.GetTemporary(width, height, 0, cb7c736b17bc53c850d891f1f2cf5bdb9.format);
			temporary2.filterMode = FilterMode.Bilinear;
			Graphics.Blit(temporary, temporary2, edgeDetectMaterial, 2);
			RenderTexture.ReleaseTemporary(temporary);
			temporary = temporary2;
			temporary2 = RenderTexture.GetTemporary(width, height, 0, cb7c736b17bc53c850d891f1f2cf5bdb9.format);
			temporary2.filterMode = FilterMode.Bilinear;
			Graphics.Blit(temporary, temporary2, edgeDetectMaterial, 3);
			RenderTexture.ReleaseTemporary(temporary);
			temporary = temporary2;
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
			if (outBloomIterations > 0)
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
				RenderTexture temporary3 = RenderTexture.GetTemporary((int)(0.5 * (double)cb7c736b17bc53c850d891f1f2cf5bdb9.width), (int)(0.5 * (double)cb7c736b17bc53c850d891f1f2cf5bdb9.height), 0, cb7c736b17bc53c850d891f1f2cf5bdb9.format);
				RenderTexture temporary4 = RenderTexture.GetTemporary((int)(0.25 * (double)cb7c736b17bc53c850d891f1f2cf5bdb9.width), (int)(0.25 * (double)cb7c736b17bc53c850d891f1f2cf5bdb9.height), 0, cb7c736b17bc53c850d891f1f2cf5bdb9.format);
				RenderTexture temporary5 = RenderTexture.GetTemporary((int)(0.25 * (double)cb7c736b17bc53c850d891f1f2cf5bdb9.width), (int)(0.25 * (double)cb7c736b17bc53c850d891f1f2cf5bdb9.height), 0, cb7c736b17bc53c850d891f1f2cf5bdb9.format);
				float num3 = 1f * (float)cb7c736b17bc53c850d891f1f2cf5bdb9.width / (1f * (float)cb7c736b17bc53c850d891f1f2cf5bdb9.height);
				float num4 = 0.001953125f;
				Graphics.Blit(cb7c736b17bc53c850d891f1f2cf5bdb9, temporary3, screenBlendMaterial, 2);
				Graphics.Blit(temporary3, temporary4, screenBlendMaterial, 2);
				Graphics.Blit(temporary, temporary4);
				for (int j = 0; j < outBloomIterations; j++)
				{
					float num5 = (1f + (float)j * 0.5f) * outSpeBlurSpread;
					separableBlurMaterial.SetVector("offsets", new Vector4(0f, num5 * num4, 0f, 0f));
					Graphics.Blit(temporary4, temporary5, separableBlurMaterial);
					separableBlurMaterial.SetVector("offsets", new Vector4(num5 / num3 * num4, 0f, 0f, 0f));
					Graphics.Blit(temporary5, temporary4, separableBlurMaterial);
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
				edgeDetectMaterial.SetFloat("_Intensity", bloomIntensity);
				edgeDetectMaterial.SetTexture("_OriTex", cb7c736b17bc53c850d891f1f2cf5bdb9);
				Graphics.Blit(temporary4, cd6a7967330188dc1a6131ff919985c04, edgeDetectMaterial, 5);
				RenderTexture.ReleaseTemporary(temporary3);
				RenderTexture.ReleaseTemporary(temporary4);
				RenderTexture.ReleaseTemporary(temporary5);
			}
			else
			{
				edgeDetectMaterial.SetTexture("_OriTex", cb7c736b17bc53c850d891f1f2cf5bdb9);
				Graphics.Blit(temporary, cd6a7967330188dc1a6131ff919985c04, edgeDetectMaterial, 4);
			}
			RenderTexture.ReleaseTemporary(temporary);
			return;
		}
	}
}
