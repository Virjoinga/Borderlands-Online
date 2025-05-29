using System;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Depth of Field (Lens Blur, Scatter, DX11)")]
public class DepthOfFieldScatter : PostEffectsBase
{
	[Serializable]
	public enum BlurSampleCount
	{
		Low = 0,
		Medium = 1,
		High = 2
	}

	public bool visualizeFocus;

	public float focalLength;

	public float focalSize;

	public float aperture;

	public Transform focalTransform;

	public float maxBlurSize;

	public bool highResolution;

	public BlurSampleCount blurSampleCount;

	public bool nearBlur;

	public float foregroundOverlap;

	public bool useGPUFocalDistance;

	public Shader dofHdrShader;

	private Material dofHdrMaterial;

	private float focalDistance01;

	private ComputeBuffer cbDrawArgs;

	private ComputeBuffer cbPoints;

	private float internalBlurWidth;

	public DepthOfFieldScatter()
	{
		focalLength = 10f;
		focalSize = 0.05f;
		aperture = 11.5f;
		maxBlurSize = 2f;
		blurSampleCount = BlurSampleCount.High;
		foregroundOverlap = 1f;
		focalDistance01 = 10f;
		internalBlurWidth = 1f;
	}

	public virtual void OnDestroy()
	{
		UnityEngine.Object.Destroy(dofHdrMaterial);
	}

	public override bool CheckResources()
	{
		CheckSupport(true);
		dofHdrMaterial = CheckShaderAndCreateMaterial(dofHdrShader, dofHdrMaterial);
		if (!isSupported)
		{
			ReportAutoDisable();
		}
		return isSupported;
	}

	public override void OnEnable()
	{
		camera.depthTextureMode |= DepthTextureMode.Depth;
	}

	public virtual void OnDisable()
	{
		if ((bool)dofHdrMaterial)
		{
			UnityEngine.Object.DestroyImmediate(dofHdrMaterial);
		}
		dofHdrMaterial = null;
	}

	public virtual float FocalDistance01(float worldDist)
	{
		return camera.WorldToViewportPoint((worldDist - camera.nearClipPlane) * camera.transform.forward + camera.transform.position).z / (camera.farClipPlane - camera.nearClipPlane);
	}

	private void WriteCoc(RenderTexture fromTo, RenderTexture temp1, RenderTexture temp2, bool fgDilate)
	{
		dofHdrMaterial.SetTexture("_FgOverlap", null);
		if (nearBlur && fgDilate)
		{
			Graphics.Blit(fromTo, temp2, dofHdrMaterial, 4);
			float num = internalBlurWidth * foregroundOverlap;
			dofHdrMaterial.SetVector("_Offsets", new Vector4(0f, num, 0f, num));
			Graphics.Blit(temp2, temp1, dofHdrMaterial, 2);
			dofHdrMaterial.SetVector("_Offsets", new Vector4(num, 0f, 0f, num));
			Graphics.Blit(temp1, temp2, dofHdrMaterial, 2);
			dofHdrMaterial.SetTexture("_FgOverlap", temp2);
			Graphics.Blit(fromTo, fromTo, dofHdrMaterial, 13);
		}
		else
		{
			Graphics.Blit(fromTo, fromTo, dofHdrMaterial, 0);
		}
	}

	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!CheckResources())
		{
			Graphics.Blit(source, destination);
			return;
		}
		if (!(aperture >= 0f))
		{
			aperture = 0f;
		}
		if (!(maxBlurSize >= 0.1f))
		{
			maxBlurSize = 0.1f;
		}
		focalSize = Mathf.Clamp(focalSize, 0f, 2f);
		internalBlurWidth = Mathf.Max(maxBlurSize, 0f);
		focalDistance01 = ((!focalTransform) ? FocalDistance01(focalLength) : (camera.WorldToViewportPoint(focalTransform.position).z / camera.farClipPlane));
		dofHdrMaterial.SetVector("_CurveParams", new Vector4(1f, focalSize, aperture / 10f, focalDistance01));
		dofHdrMaterial.SetVector("_GunSightExtension", new Vector4((!useGPUFocalDistance) ? 0f : 1f, 0f, 0f, 0f));
		RenderTexture renderTexture = null;
		RenderTexture renderTexture2 = null;
		RenderTexture renderTexture3 = null;
		RenderTexture renderTexture4 = null;
		float num = internalBlurWidth * foregroundOverlap;
		if (visualizeFocus)
		{
			renderTexture = RenderTexture.GetTemporary(source.width >> 1, source.height >> 1, 0, source.format);
			renderTexture2 = RenderTexture.GetTemporary(source.width >> 1, source.height >> 1, 0, source.format);
			WriteCoc(source, renderTexture, renderTexture2, true);
			Graphics.Blit(source, destination, dofHdrMaterial, 16);
		}
		else
		{
			renderTexture = RenderTexture.GetTemporary(source.width >> 1, source.height >> 1, 0, source.format);
			renderTexture2 = RenderTexture.GetTemporary(source.width >> 1, source.height >> 1, 0, source.format);
			source.filterMode = FilterMode.Bilinear;
			if (highResolution)
			{
				internalBlurWidth *= 2f;
			}
			WriteCoc(source, renderTexture, renderTexture2, true);
			int pass = ((blurSampleCount != BlurSampleCount.High && blurSampleCount != BlurSampleCount.Medium) ? 11 : 17);
			if (highResolution)
			{
				dofHdrMaterial.SetVector("_Offsets", new Vector4(0f, internalBlurWidth, 0.025f, internalBlurWidth));
				Graphics.Blit(source, destination, dofHdrMaterial, pass);
			}
			else
			{
				dofHdrMaterial.SetVector("_Offsets", new Vector4(0f, internalBlurWidth, 0.1f, internalBlurWidth));
				Graphics.Blit(source, renderTexture, dofHdrMaterial, 6);
				Graphics.Blit(renderTexture, renderTexture2, dofHdrMaterial, pass);
				dofHdrMaterial.SetTexture("_LowRez", renderTexture2);
				dofHdrMaterial.SetTexture("_FgOverlap", null);
				dofHdrMaterial.SetVector("_Offsets", Vector4.one * (1f * (float)source.width / (1f * (float)renderTexture2.width)) * internalBlurWidth);
				Graphics.Blit(source, destination, dofHdrMaterial, (blurSampleCount != BlurSampleCount.High) ? 12 : 18);
			}
		}
		if ((bool)renderTexture)
		{
			RenderTexture.ReleaseTemporary(renderTexture);
		}
		if ((bool)renderTexture2)
		{
			RenderTexture.ReleaseTemporary(renderTexture2);
		}
	}

	public override void Main()
	{
	}
}
