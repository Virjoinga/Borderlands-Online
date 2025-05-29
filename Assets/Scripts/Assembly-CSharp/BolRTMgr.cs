using UnityEngine;

public class BolRTMgr
{
	private RenderTexture mDistortionRT;

	public int FIRST_PLAYER_LAYER = 19;

	public void ccc9d3a38966dc10fedb531ea17d24611()
	{
		mDistortionRT = new RenderTexture(Screen.width, Screen.height, 0);
		mDistortionRT.name = "BolRTMgr_mDistortionRT";
		mDistortionRT.Create();
	}

	private void OnDestroy()
	{
		mDistortionRT.Release();
	}

	public RenderTexture cb1e1e0af9cca2ee1cdfd093cc80f79e1()
	{
		return mDistortionRT;
	}
}
