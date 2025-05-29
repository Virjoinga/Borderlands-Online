using System;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Sky Color Correction (Curves, Saturation)")]
public class SkyColorCorrectionCurves : PostEffectsBase
{
	public AnimationCurve redChannel;

	public AnimationCurve greenChannel;

	public AnimationCurve blueChannel;

	public AnimationCurve zCurve;

	private Material ccMaterial;

	private Texture2D rgbChannelTex;

	private Texture2D zCurveTex;

	public float saturation;

	public bool updateTextures;

	public Shader skyColorCorrectionCurvesShader;

	private bool updateTexturesOnStartup;

	public SkyColorCorrectionCurves()
	{
		saturation = 1f;
		updateTextures = true;
		updateTexturesOnStartup = true;
	}

	public override void Start()
	{
		base.Start();
		updateTexturesOnStartup = true;
	}

	public virtual void Awake()
	{
	}

	public virtual void OnDestroy()
	{
		UnityEngine.Object.Destroy(ccMaterial);
		UnityEngine.Object.Destroy(rgbChannelTex);
		UnityEngine.Object.Destroy(zCurveTex);
	}

	public override bool CheckResources()
	{
		ccMaterial = CheckShaderAndCreateMaterial(skyColorCorrectionCurvesShader, ccMaterial);
		if (!rgbChannelTex)
		{
			rgbChannelTex = new Texture2D(256, 4, TextureFormat.ARGB32, false, true);
			rgbChannelTex.name = "SkyColorCorrectionCurves_rgbChannelTex";
		}
		if (!zCurveTex)
		{
			zCurveTex = new Texture2D(256, 1, TextureFormat.ARGB32, false, true);
			zCurveTex.name = "SkyColorCorrectionCurves_zCurveTex";
		}
		rgbChannelTex.hideFlags = HideFlags.DontSave;
		zCurveTex.hideFlags = HideFlags.DontSave;
		rgbChannelTex.wrapMode = TextureWrapMode.Clamp;
		zCurveTex.wrapMode = TextureWrapMode.Clamp;
		if (!isSupported)
		{
			ReportAutoDisable();
		}
		return isSupported;
	}

	public virtual void UpdateParameters()
	{
		if (redChannel != null && greenChannel != null && blueChannel != null)
		{
			for (float num = 0f; num <= 1f; num += 0.003921569f)
			{
				float num2 = Mathf.Clamp(redChannel.Evaluate(num), 0f, 1f);
				float num3 = Mathf.Clamp(greenChannel.Evaluate(num), 0f, 1f);
				float num4 = Mathf.Clamp(blueChannel.Evaluate(num), 0f, 1f);
				rgbChannelTex.SetPixel((int)Mathf.Floor(num * 255f), 0, new Color(num2, num2, num2));
				rgbChannelTex.SetPixel((int)Mathf.Floor(num * 255f), 1, new Color(num3, num3, num3));
				rgbChannelTex.SetPixel((int)Mathf.Floor(num * 255f), 2, new Color(num4, num4, num4));
				float num5 = Mathf.Clamp(zCurve.Evaluate(num), 0f, 1f);
				zCurveTex.SetPixel((int)Mathf.Floor(num * 255f), 0, new Color(num5, num5, num5));
			}
			rgbChannelTex.Apply();
			zCurveTex.Apply();
		}
	}

	public virtual void UpdateTextures()
	{
		UpdateParameters();
	}

	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!CheckResources())
		{
			Graphics.Blit(source, destination);
			return;
		}
		if (updateTexturesOnStartup)
		{
			UpdateParameters();
			updateTexturesOnStartup = false;
		}
		camera.depthTextureMode |= DepthTextureMode.Depth;
		ccMaterial.SetTexture("_RgbTex", rgbChannelTex);
		ccMaterial.SetTexture("_ZCurve", zCurveTex);
		ccMaterial.SetFloat("_Saturation", saturation);
		Graphics.Blit(source, destination, ccMaterial);
	}

	public override void Main()
	{
	}
}
