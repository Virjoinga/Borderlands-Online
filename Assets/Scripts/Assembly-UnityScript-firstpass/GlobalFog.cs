using System;
using UnityEngine;

[Serializable]
[AddComponentMenu("Image Effects/Global Fog")]
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class GlobalFog : PostEffectsBase
{
	private float CAMERA_NEAR;

	private float CAMERA_FAR;

	private float CAMERA_FOV;

	private float CAMERA_ASPECT_RATIO;

	public float startDistance;

	public float endDistance;

	public float globalDensity;

	public Color globalFogColor;

	public Shader fogShader;

	private Material fogMaterial;

	public GlobalFog()
	{
		CAMERA_NEAR = 0.5f;
		CAMERA_FAR = 50f;
		CAMERA_FOV = 60f;
		CAMERA_ASPECT_RATIO = 1.333333f;
		startDistance = 20f;
		endDistance = 100f;
		globalDensity = 1f;
		globalFogColor = Color.grey;
	}

	public override bool CheckResources()
	{
		CheckSupport(true);
		fogMaterial = CheckShaderAndCreateMaterial(fogShader, fogMaterial);
		if (!isSupported)
		{
			ReportAutoDisable();
		}
		return isSupported;
	}

	public virtual void OnDestroy()
	{
		UnityEngine.Object.Destroy(fogMaterial);
	}

	public virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!CheckResources())
		{
			Graphics.Blit(source, destination);
			return;
		}
		CAMERA_NEAR = camera.nearClipPlane;
		CAMERA_FAR = camera.farClipPlane;
		CAMERA_FOV = camera.fieldOfView;
		CAMERA_ASPECT_RATIO = camera.aspect;
		fogMaterial.SetVector("_StartDistance", new Vector4(startDistance, CAMERA_FAR - CAMERA_NEAR, endDistance - startDistance));
		fogMaterial.SetFloat("_GlobalDensity", globalDensity);
		fogMaterial.SetColor("_FogColor", globalFogColor);
		CustomGraphicsBlit(source, destination, fogMaterial);
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
