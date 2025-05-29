using A;
using UnityEngine;

public class TexPostEffectLogicStart : MonoBehaviour
{
	[ImageEffectOpaque]
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Texture2D source2 = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c0e679f4989d9772fd4db03bedfd64968().c231ac37f43d8bf9cc76e857d5bebae35();
		Graphics.Blit(source2, destination);
	}
}
