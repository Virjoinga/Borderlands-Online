using A;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/DeathEffect")]
public class DeathEffect : ImageEffectBase
{
	public float saturation = 1f;

	public int statIndex;

	public float lumOffset;

	public float whiteRadius;

	public float blurAmount = 0.8f;

	public bool extraBlur;

	public float lumScenePara = 3f;

	public float lumFpsPara = 1f;

	private RenderTexture accumTexture;

	protected override void Start()
	{
		if (!SystemInfo.supportsRenderTextures)
		{
			while (true)
			{
				switch (7)
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
		if (statIndex == 0)
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
					base.cf4af10ce9fa4ab84bd021b054d46a667.SetFloat("_Saturation", saturation);
					Graphics.Blit(source, destination, base.cf4af10ce9fa4ab84bd021b054d46a667, 0);
					return;
				}
			}
		}
		if (statIndex != 1)
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
			if (!(accumTexture == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (accumTexture.width == source.width)
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
					if (accumTexture.height == source.height)
					{
						goto IL_012d;
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
			}
			Object.DestroyImmediate(accumTexture);
			accumTexture = new RenderTexture(source.width, source.height, 0);
			accumTexture.name = "DeathEffect_accumTexture";
			accumTexture.hideFlags = HideFlags.HideAndDontSave;
			base.cf4af10ce9fa4ab84bd021b054d46a667.SetFloat("_LumOffset", 1f);
			Graphics.Blit(accumTexture, base.cf4af10ce9fa4ab84bd021b054d46a667, 3);
			goto IL_012d;
			IL_012d:
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
				temporary.name = "DeathEffect_blurbuffer";
				Graphics.Blit(accumTexture, temporary);
				Graphics.Blit(temporary, accumTexture);
				RenderTexture.ReleaseTemporary(temporary);
			}
			base.cf4af10ce9fa4ab84bd021b054d46a667.SetFloat("_AccumOrig", 1f - blurAmount);
			base.cf4af10ce9fa4ab84bd021b054d46a667.SetFloat("_LumScenePara", lumScenePara);
			base.cf4af10ce9fa4ab84bd021b054d46a667.SetFloat("_LumFpsPara", lumFpsPara);
			base.cf4af10ce9fa4ab84bd021b054d46a667.SetFloat("_LumOffset", lumOffset);
			Graphics.Blit(source, accumTexture, base.cf4af10ce9fa4ab84bd021b054d46a667, 1);
			Graphics.Blit(accumTexture, destination);
			return;
		}
	}
}
