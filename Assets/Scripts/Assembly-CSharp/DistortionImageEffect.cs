using A;
using UnityEngine;

[AddComponentMenu("Image Effects/Distortion")]
[ExecuteInEditMode]
public class DistortionImageEffect : ImageEffectBase
{
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		RenderTexture texture = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ccffb6c52596bb8aa19fb001ee528ca6d().cb1e1e0af9cca2ee1cdfd093cc80f79e1();
		base.cf4af10ce9fa4ab84bd021b054d46a667.SetTexture("_OffsetTex", texture);
		Graphics.Blit(source, destination, base.cf4af10ce9fa4ab84bd021b054d46a667);
	}
}
