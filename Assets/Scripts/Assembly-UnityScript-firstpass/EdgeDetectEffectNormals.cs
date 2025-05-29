using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Edge Detection (Geometry)")]
[ExecuteInEditMode]
public class EdgeDetectEffectNormals : PostEffectsBase
{
	public float edgeExp;

	public float sampleDist;

	public float threshold;

	public float edgesOnly;

	public Color edgesOnlyBgColor;

	public Shader edgeDetectShader;

	private Material edgeDetectMaterial;

	private bool alphaCorrection;

	public EdgeDetectEffectNormals()
	{
		edgeExp = 1f;
		sampleDist = 1f;
		threshold = 100f;
		edgesOnlyBgColor = Color.white;
	}

	public virtual void OnDestroy()
	{
		UnityEngine.Object.DestroyImmediate(edgeDetectMaterial);
	}

	public override bool CheckResources()
	{
		CheckSupport(true);
		edgeDetectMaterial = CheckShaderAndCreateMaterial(edgeDetectShader, edgeDetectMaterial);
		if (!isSupported)
		{
			ReportAutoDisable();
		}
		EnableAlphaCorrection(alphaCorrection);
		return isSupported;
	}

	public override void Start()
	{
	}

	public override void OnEnable()
	{
	}

	public virtual void EnableAlphaCorrection(bool enable)
	{
		alphaCorrection = enable;
		if (edgeDetectMaterial != null)
		{
			if (alphaCorrection)
			{
				edgeDetectMaterial.EnableKeyword("AlphaCorrection");
			}
			else
			{
				edgeDetectMaterial.EnableKeyword("NoAlphaCorrection");
			}
		}
	}

	[ImageEffectOpaque]
	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!CheckResources())
		{
			Graphics.Blit(source, destination);
			return;
		}
		edgeDetectMaterial.SetFloat("_BgFade", edgesOnly);
		edgeDetectMaterial.SetFloat("_SampleDistance", sampleDist);
		edgeDetectMaterial.SetVector("_BgColor", edgesOnlyBgColor);
		edgeDetectMaterial.SetFloat("_Exponent", edgeExp);
		edgeDetectMaterial.SetFloat("_Threshold", threshold);
		Graphics.Blit(source, destination, edgeDetectMaterial);
	}

	public static void CustomGraphicsBlit(RenderTexture source, RenderTexture dest, Material fxMaterial)
	{
		RenderTexture.active = dest;
		fxMaterial.SetTexture("_MainTex", source);
		GL.PushMatrix();
		GL.LoadOrtho();
		fxMaterial.SetPass(0);
		GL.Begin(7);
		GL.MultiTexCoord2(0, 0f, 0f);
		GL.Vertex3(0f, 0f, 3f);
		GL.MultiTexCoord2(0, 1f, 0f);
		GL.Vertex3(1f, 0f, 2f);
		GL.MultiTexCoord2(0, 1f, 1f);
		GL.Vertex3(1f, 1f, 1f);
		GL.MultiTexCoord2(0, 0f, 1f);
		GL.Vertex3(0f, 1f, 0f);
		GL.End();
		GL.PopMatrix();
	}

	public override void Main()
	{
	}
}
