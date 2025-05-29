using A;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/SnapImageEffect")]
public class SnapImageEffect : PostEffectsBase
{
	public Shader mSnapEffectShader;

	private Material mSnapEffectMaterial;

	private void OnDestroy()
	{
		Object.Destroy(mSnapEffectMaterial);
	}

	private void OnDisable()
	{
		if (!mSnapEffectMaterial)
		{
			return;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Object.DestroyImmediate(mSnapEffectMaterial);
			return;
		}
	}

	public override bool CheckResources()
	{
		mSnapEffectShader = Shader.Find("Custom/SnapEffect");
		CheckSupport(true);
		mSnapEffectMaterial = CheckShaderAndCreateMaterial(mSnapEffectShader, mSnapEffectMaterial);
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
		if (!c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c848ee3ec1aba9ee52ed305a7c47e42ce().c3ed99fc46b89f7ebe24eb0d04e85db84())
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					Graphics.Blit(source, destination);
					return;
				}
			}
		}
		Rect rect = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c848ee3ec1aba9ee52ed305a7c47e42ce().c44190b16a8195463b1b40b90756b1945();
		int num = (int)(rect.width * (float)source.width);
		int num2 = (int)(rect.height * (float)source.height);
		RenderTexture temporary = RenderTexture.GetTemporary(num, num2, 0, source.format);
		int mItemTexW = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c848ee3ec1aba9ee52ed305a7c47e42ce().mItemTexW;
		int mItemTexH = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c848ee3ec1aba9ee52ed305a7c47e42ce().mItemTexH;
		RenderTexture temporary2 = RenderTexture.GetTemporary(mItemTexW, mItemTexH, 0, source.format);
		float num3 = (float)mItemTexW / (float)mItemTexH;
		float num4 = (float)num / (float)num2;
		Rect rect2 = new Rect(0f, 0f, 1f, 1f);
		if (num4 > num3)
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
			float num5 = (float)(num2 * mItemTexW) / (float)(num * mItemTexH);
			float num6 = (1f - num5) * 0.5f;
			rect2 = new Rect(0f, num6, 1f, num6 + num5);
		}
		else
		{
			float num7 = (float)(num * mItemTexH) / (float)(num2 * mItemTexW);
			float num8 = (1f - num7) * 0.5f;
			rect2 = new Rect(num8, 0f, num8 + num7, 1f);
		}
		c2313a036184a3034d300bc2a38d312ff(source, temporary, 0);
		c2313a036184a3034d300bc2a38d312ff(source, temporary, 1);
		c2313a036184a3034d300bc2a38d312ff(source, c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c848ee3ec1aba9ee52ed305a7c47e42ce().mResultRt, 0);
		ccb92f4e99d13946d79123e7a08598f93(temporary, c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c848ee3ec1aba9ee52ed305a7c47e42ce().mResultRt, 1, rect2);
		Graphics.Blit(c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c848ee3ec1aba9ee52ed305a7c47e42ce().mResultRt, destination);
		StartCoroutine(c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c848ee3ec1aba9ee52ed305a7c47e42ce().cf9da4ddea5630a732c3109cc83da3847(c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c848ee3ec1aba9ee52ed305a7c47e42ce().mResultRt));
		RenderTexture.ReleaseTemporary(temporary);
		RenderTexture.ReleaseTemporary(temporary2);
	}

	private void c2313a036184a3034d300bc2a38d312ff(RenderTexture cb7c736b17bc53c850d891f1f2cf5bdb9, RenderTexture c3bf0aba013b67d0c87c979c575ed52cf, int c41927d036299d800069a73fb0a4c3e5a)
	{
		RenderTexture.active = c3bf0aba013b67d0c87c979c575ed52cf;
		mSnapEffectMaterial.SetTexture("_MainTex", cb7c736b17bc53c850d891f1f2cf5bdb9);
		GL.PushMatrix();
		GL.LoadOrtho();
		mSnapEffectMaterial.SetPass(c41927d036299d800069a73fb0a4c3e5a);
		GL.Begin(7);
		Rect rect = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c848ee3ec1aba9ee52ed305a7c47e42ce().c44190b16a8195463b1b40b90756b1945();
		float num = 6f / (float)cb7c736b17bc53c850d891f1f2cf5bdb9.width;
		float num2 = 2f / (float)cb7c736b17bc53c850d891f1f2cf5bdb9.height;
		float x = rect.x - num;
		float y = rect.y - num2;
		float x2 = rect.x + rect.width + num;
		float y2 = rect.y + rect.height + num2;
		GL.MultiTexCoord2(0, x, y);
		GL.Vertex3(0f, 0f, 0f);
		GL.MultiTexCoord2(0, x2, y);
		GL.Vertex3(1f, 0f, 0f);
		GL.MultiTexCoord2(0, x2, y2);
		GL.Vertex3(1f, 1f, 0f);
		GL.MultiTexCoord2(0, x, y2);
		GL.Vertex3(0f, 1f, 0f);
		GL.End();
		GL.PopMatrix();
	}

	private void ccb92f4e99d13946d79123e7a08598f93(RenderTexture cb7c736b17bc53c850d891f1f2cf5bdb9, RenderTexture c3bf0aba013b67d0c87c979c575ed52cf, int c41927d036299d800069a73fb0a4c3e5a, Rect cc5deab9dabc6a5bcf9a32014be4f8877)
	{
		RenderTexture.active = c3bf0aba013b67d0c87c979c575ed52cf;
		mSnapEffectMaterial.SetTexture("_MainTex", cb7c736b17bc53c850d891f1f2cf5bdb9);
		GL.PushMatrix();
		GL.LoadOrtho();
		mSnapEffectMaterial.SetPass(c41927d036299d800069a73fb0a4c3e5a);
		GL.Begin(7);
		float x = cc5deab9dabc6a5bcf9a32014be4f8877.x;
		float y = cc5deab9dabc6a5bcf9a32014be4f8877.y;
		float width = cc5deab9dabc6a5bcf9a32014be4f8877.width;
		float height = cc5deab9dabc6a5bcf9a32014be4f8877.height;
		GL.MultiTexCoord2(0, 0f, 0f);
		GL.Vertex3(x, y, 0f);
		GL.MultiTexCoord2(0, 1f, 0f);
		GL.Vertex3(width, y, 0f);
		GL.MultiTexCoord2(0, 1f, 1f);
		GL.Vertex3(width, height, 0f);
		GL.MultiTexCoord2(0, 0f, 1f);
		GL.Vertex3(x, height, 0f);
		GL.End();
		GL.PopMatrix();
	}
}
