using A;
using UnityEngine;

public class TexPostEffectMgr
{
	public enum POST_EFFECT_TYPE
	{
		POST_EFFECT_UI = 0,
		POST_EFFECT_FONT = 1,
		POST_EFFECT_BlUEPRINT = 2,
		POST_EFFECT_CRAFT = 3,
		POST_EFFECT_LOCK = 4,
		POST_EFFECT_UNLOCK = 5,
		POST_EFFECT_NUM = 6
	}

	private Camera mUIPostEffectCam;

	private Camera mFontPostEffectCam;

	private Camera mBluePrintPostEffectCam;

	private Camera mCraftPostEffectCam;

	private Camera mLockPostEffectCam;

	private Camera mUnlockPostEffectCam;

	private Camera mCurPostEfefctCam;

	private Texture2D mOutputTex;

	private RenderTexture mRT;

	public Texture2D c231ac37f43d8bf9cc76e857d5bebae35()
	{
		return mOutputTex;
	}

	private void cbd596a26ce797e3d7e519e01d5594318(GameObject cf460864d442388fcb2437c97d422ad7e, ref Camera cc5681de8b48bc9f26dbaad39bc1bdc88, GameObject c55ad785439ee6fce5801aeeff39f0d79)
	{
		cc5681de8b48bc9f26dbaad39bc1bdc88 = cf460864d442388fcb2437c97d422ad7e.AddComponent<Camera>();
		cc5681de8b48bc9f26dbaad39bc1bdc88.clearFlags = CameraClearFlags.Nothing;
		cc5681de8b48bc9f26dbaad39bc1bdc88.depth = 101f;
		cc5681de8b48bc9f26dbaad39bc1bdc88.hdr = true;
		cc5681de8b48bc9f26dbaad39bc1bdc88.gameObject.AddComponent<TexPostEffectLogicStart>();
		ComponentHelper.c0bd715794203aecb6153c35217fbf4f4(c55ad785439ee6fce5801aeeff39f0d79, cc5681de8b48bc9f26dbaad39bc1bdc88.gameObject);
		cc5681de8b48bc9f26dbaad39bc1bdc88.gameObject.AddComponent<TexPostEffectLogic>();
		cc5681de8b48bc9f26dbaad39bc1bdc88.gameObject.SetActive(false);
	}

	private void c19214e1e03f7c6bc38f2874a56550e39(GameObject c9b22b99c4009be721768a81dd80c0f38, string c7d6a1c747921a30f4d1c2b957723b4f0, ref Camera cc5681de8b48bc9f26dbaad39bc1bdc88, string ca8f4b30be457b5d2d88c8659a099e1ea)
	{
		GameObject gameObject = new GameObject(c7d6a1c747921a30f4d1c2b957723b4f0);
		gameObject.transform.parent = c9b22b99c4009be721768a81dd80c0f38.transform;
		gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
		GameObject c55ad785439ee6fce5801aeeff39f0d = Resources.Load(ca8f4b30be457b5d2d88c8659a099e1ea) as GameObject;
		cbd596a26ce797e3d7e519e01d5594318(gameObject, ref cc5681de8b48bc9f26dbaad39bc1bdc88, c55ad785439ee6fce5801aeeff39f0d);
	}

	public void ccc9d3a38966dc10fedb531ea17d24611(GameObject cf460864d442388fcb2437c97d422ad7e)
	{
		c19214e1e03f7c6bc38f2874a56550e39(cf460864d442388fcb2437c97d422ad7e, "UI_PostEffect_Cam", ref mUIPostEffectCam, "CameraEffect/EffectCamera_UI_Snap");
		c19214e1e03f7c6bc38f2874a56550e39(cf460864d442388fcb2437c97d422ad7e, "Font_PostEffect_Cam", ref mFontPostEffectCam, "CameraEffect/EffectCamera_UI_Snap");
		c19214e1e03f7c6bc38f2874a56550e39(cf460864d442388fcb2437c97d422ad7e, "BluePrint_PostEffect_Cam", ref mBluePrintPostEffectCam, "CameraEffect/EffectCamera_UI_Snap_BluePrint");
		c19214e1e03f7c6bc38f2874a56550e39(cf460864d442388fcb2437c97d422ad7e, "Craft_PostEffect_Cam", ref mCraftPostEffectCam, "CameraEffect/EffectCamera_UI_Snap_Craft");
		c19214e1e03f7c6bc38f2874a56550e39(cf460864d442388fcb2437c97d422ad7e, "Lock_PostEffect_Cam", ref mLockPostEffectCam, "CameraEffect/EffectCamera_UI_Snap_Lock");
		c19214e1e03f7c6bc38f2874a56550e39(cf460864d442388fcb2437c97d422ad7e, "Unlock_PostEffect_Cam", ref mUnlockPostEffectCam, "CameraEffect/EffectCamera_UI_Snap_Unlock");
	}

	public void ca489b6557226f61729b498b54e0e3d63(Texture2D c853ebd35d95c349adfcf2dcca32ad762, POST_EFFECT_TYPE cb0e4bb0b8a67a971708e7fd64825f1f4)
	{
		if (cb0e4bb0b8a67a971708e7fd64825f1f4 == POST_EFFECT_TYPE.POST_EFFECT_UI)
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
			mCurPostEfefctCam = mUIPostEffectCam;
		}
		else if (cb0e4bb0b8a67a971708e7fd64825f1f4 == POST_EFFECT_TYPE.POST_EFFECT_FONT)
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
			mCurPostEfefctCam = mFontPostEffectCam;
		}
		else if (cb0e4bb0b8a67a971708e7fd64825f1f4 == POST_EFFECT_TYPE.POST_EFFECT_BlUEPRINT)
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
			mCurPostEfefctCam = mBluePrintPostEffectCam;
		}
		else if (cb0e4bb0b8a67a971708e7fd64825f1f4 == POST_EFFECT_TYPE.POST_EFFECT_CRAFT)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			mCurPostEfefctCam = mCraftPostEffectCam;
		}
		else if (cb0e4bb0b8a67a971708e7fd64825f1f4 == POST_EFFECT_TYPE.POST_EFFECT_LOCK)
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
			mCurPostEfefctCam = mLockPostEffectCam;
		}
		else if (cb0e4bb0b8a67a971708e7fd64825f1f4 == POST_EFFECT_TYPE.POST_EFFECT_UNLOCK)
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
			mCurPostEfefctCam = mUnlockPostEffectCam;
		}
		mCurPostEfefctCam.gameObject.SetActive(true);
		if (c853ebd35d95c349adfcf2dcca32ad762 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		mRT = RenderTexture.GetTemporary(c853ebd35d95c349adfcf2dcca32ad762.width, c853ebd35d95c349adfcf2dcca32ad762.height);
		mCurPostEfefctCam.targetTexture = mRT;
		mOutputTex = c853ebd35d95c349adfcf2dcca32ad762;
	}

	public void cf9da4ddea5630a732c3109cc83da3847()
	{
		if (mRT != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			RenderTexture.active = mRT;
			mOutputTex.ReadPixels(new Rect(0f, 0f, mRT.width, mRT.height), 0, 0);
			mOutputTex.Apply();
			RenderTexture.active = ccb647d35893b403a66083910531a6e7e.c7088de59e49f7108f520cf7e0bae167e;
			RenderTexture.ReleaseTemporary(mRT);
			mRT = ccb647d35893b403a66083910531a6e7e.c7088de59e49f7108f520cf7e0bae167e;
		}
		mCurPostEfefctCam.gameObject.SetActive(false);
	}
}
