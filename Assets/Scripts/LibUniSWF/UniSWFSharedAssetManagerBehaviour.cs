using UnityEngine;
using pumpkin.swf;

[AddComponentMenu("uniSWF/SharedAssetManager")]
[ExecuteInEditMode]
public class UniSWFSharedAssetManagerBehaviour : MonoBehaviour
{
	public static UniSWFSharedAssetManagerBehaviour instance;

	public static bool exists = false;

	public static bool preloadComplete = false;

	private static bool preloadWarnShown = false;

	private static bool sceneAssetsInstalled = false;

	public string[] preloadFonts;

	public string[] preloadMovieClips;

	public MovieClipProfiler profileOptions;

	public string swfProfile;

	public SwfSceneAssetInfo[] assets;

	public UniSWFTTFFontAssetInfo[] ttfFonts;

	public bool clearContextCache = true;

	public UniSWFSharedAssetManagerBehaviour()
	{
		exists = true;
	}

	private void Awake()
	{
		instance = this;
		if (clearContextCache)
		{
			Debug.Log("Clearing resource cache");
			MovieClipPlayer.clearContextCache();
			if (TextureManager.instance != null)
			{
				TextureManager.instance.clearTextureCache();
			}
			Resources.UnloadUnusedAssets();
		}
		installSceneLoader();
		MovieClipPlayer.profilerSettings = profileOptions;
		if (swfProfile != null && swfProfile.Length > 0)
		{
			MovieClipPlayer.swfProfile = swfProfile;
		}
		if (preloadFonts != null)
		{
			for (int i = 0; i < preloadFonts.Length; i++)
			{
				if (!string.IsNullOrEmpty(preloadFonts[i]))
				{
					MovieClipPlayer.preloadSWF(preloadFonts[i]);
				}
			}
		}
		if (preloadMovieClips != null)
		{
			for (int j = 0; j < preloadMovieClips.Length; j++)
			{
				if (!string.IsNullOrEmpty(preloadMovieClips[j]))
				{
					MovieClipPlayer.preloadSWF(preloadMovieClips[j]);
				}
			}
		}
		preloadComplete = true;
	}

	public void installSceneLoader()
	{
		if (assets != null && assets.Length > 0)
		{
			(MovieClipPlayer.rootResourceLoader as BuiltinResourceLoader).enableSceneAssetLoader = true;
			(MovieClipPlayer.rootResourceLoader as BuiltinResourceLoader).sceneAssets = assets;
		}
	}

	public static void checkPreloadExecutionOrder()
	{
		if (exists && !preloadComplete && !preloadWarnShown)
		{
			preloadWarnShown = true;
			Debug.LogWarning("Some assets may not be preloaded!, Change the 'Script Exectuion order' (Edit->Project Settings) of the UniSWFSharedAssetManagerBehaviour to higher priority to prevent this warning");
			if (!sceneAssetsInstalled && instance != null)
			{
				sceneAssetsInstalled = true;
				instance.installSceneLoader();
			}
		}
	}

	public static UniSWFSharedAssetManagerBehaviour getInstance()
	{
		return (UniSWFSharedAssetManagerBehaviour)Object.FindObjectOfType(typeof(UniSWFSharedAssetManagerBehaviour));
	}
}
