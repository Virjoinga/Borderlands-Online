using A;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Blur/Motion Blur (Color Accumulation)")]
public class MotionBlur : ImageEffectBase
{
	public float blurAmount = 0.8f;

	public bool extraBlur;

	private RenderTexture accumTexture;

	protected override void Start()
	{
		if (!SystemInfo.supportsRenderTextures)
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
					base.enabled = false;
					return;
				}
			}
		}
		base.Start();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		Object.DestroyImmediate(accumTexture);
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!(accumTexture == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (accumTexture.width == source.width)
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
				if (accumTexture.height == source.height)
				{
					goto IL_00a9;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
			}
		}
		Object.DestroyImmediate(accumTexture);
		accumTexture = new RenderTexture(source.width, source.height, 0);
		accumTexture.hideFlags = HideFlags.HideAndDontSave;
		Graphics.Blit(source, accumTexture);
		goto IL_00a9;
		IL_00a9:
		if (extraBlur)
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
			RenderTexture temporary = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
			accumTexture.MarkRestoreExpected();
			Graphics.Blit(accumTexture, temporary);
			Graphics.Blit(temporary, accumTexture);
			RenderTexture.ReleaseTemporary(temporary);
		}
		blurAmount = Mathf.Clamp(blurAmount, 0f, 0.92f);
		base.cf4af10ce9fa4ab84bd021b054d46a667.SetTexture("_MainTex", accumTexture);
		base.cf4af10ce9fa4ab84bd021b054d46a667.SetFloat("_AccumOrig", 1f - blurAmount);
		accumTexture.MarkRestoreExpected();
		Graphics.Blit(source, accumTexture, base.cf4af10ce9fa4ab84bd021b054d46a667);
		Graphics.Blit(accumTexture, destination);
	}
}
