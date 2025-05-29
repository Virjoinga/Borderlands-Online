using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pumpkin.swf;

public class SwfBackgroundPreloader : MonoBehaviour
{
	public delegate void SwfPreloadCompleteCallback(SwfBackgroundPreloader preloader);

	public static float defaultSwfStreamPreloadDelay = 0.65f;

	public static float defaultTexturePreloadDelay = 0.65f;

	public float swfStreampreloadDelay = defaultSwfStreamPreloadDelay;

	public float texturePreloadDelay = defaultTexturePreloadDelay;

	public bool completed = false;

	public bool failed = false;

	public bool initialDelay = true;

	public string swfUri;

	public SwfAssetContext assetContext;

	public SwfPreloadCompleteCallback onComplete;

	public SwfPreloadCompleteCallback onProgress;

	public bool debug = false;

	public bool logErrors = true;

	public int dataChunksPerStep = 4;

	public bool loading = false;

	public int total = 0;

	public int progress = 0;

	private void Update()
	{
		if (completed)
		{
			Object.Destroy(base.gameObject);
		}
	}

	public IEnumerator Start()
	{
		loading = true;
		total = -1;
		if (initialDelay)
		{
			yield return new WaitForSeconds(swfStreampreloadDelay);
		}
		if (debug)
		{
			Debug.Log("SwfBackgroundPreloader loading swf data: " + swfUri);
		}
		Dictionary<string, SwfAssetContext> contextCache = MovieClipPlayer.contextCache;
		string swfProfile = MovieClipPlayer.swfProfile;
		if (contextCache.ContainsKey(swfUri))
		{
			assetContext = contextCache[swfUri];
		}
		else
		{
			string swfUriTmp = BuiltinResourceLoader.swfPrefix(swfUri, swfProfile);
			TextAsset swfInfoAsset = null;
			if (swfProfile != null)
			{
				swfInfoAsset = (TextAsset)Resources.Load(swfUriTmp, typeof(TextAsset));
			}
			if (swfInfoAsset == null)
			{
				swfUriTmp = BuiltinResourceLoader.swfPrefix(swfUri, null);
				swfInfoAsset = (TextAsset)Resources.Load(swfUriTmp, typeof(TextAsset));
			}
			if (swfInfoAsset == null)
			{
				Debug.LogError("MovieClip() Invalid asset url '" + swfUri + "' actual url loaded '" + swfUriTmp + "'");
				onError();
				yield break;
			}
			SwfBinaryReader b = new SwfBinaryReader(swfInfoAsset.bytes);
			MovieClipReader reader = new MovieClipReader();
			assetContext = new SwfAssetContext();
			reader.readSwfAssetContextPrepareCO(b, swfUriTmp + "_", assetContext);
			yield return StartCoroutine(reader.getReaderImpl(assetContext.version).readSWFCO(b, assetContext, swfStreampreloadDelay, dataChunksPerStep));
			if (debug)
			{
				Debug.Log("SwfBackgroundPreloader loading swf data complete: " + swfUri);
			}
			if (assetContext == null)
			{
				Debug.LogError("MovieClip() Invalid swf '" + swfUri + "'");
				onError();
				yield break;
			}
			if (TextureManager.instance == null)
			{
				new TextureManager();
			}
			assetContext.textureManager = TextureManager.instance;
			assetContext.resourceLoader = MovieClipPlayer.rootResourceLoader;
			MovieClipPlayer.contextCache[swfUri] = assetContext;
			if ((MovieClipPlayer.profilerSettings & MovieClipProfiler.SwfLoad) == MovieClipProfiler.SwfLoad)
			{
				Debug.Log("SwfProfile->SwfLoad: " + swfUri + ", " + MovieClipPlayer.profilerSettings);
			}
		}
		if (assetContext == null)
		{
			onError();
			yield break;
		}
		List<string> assetList = new List<string>();
		total = 0;
		foreach (KeyValuePair<int, AssetBaseInfo> iter in assetContext.exports)
		{
			if (iter.Value is BitmapAssetInfo)
			{
				string assetUri = string.Concat(str1: ((BitmapAssetInfo)iter.Value).textureUri, str0: assetContext.swfPrefix);
				if (assetList.IndexOf(assetUri) == -1)
				{
					assetList.Add(assetUri);
					total++;
				}
			}
		}
		yield return new WaitForSeconds(texturePreloadDelay);
		for (int i = 0; i < assetList.Count; i++)
		{
			if (debug)
			{
				Debug.Log("SwfBackgroundPreloader loading texture: " + assetList[i] + ", " + i + ", " + assetList.Count);
			}
			assetContext.textureManager.getBitmapData(assetList[i]);
			progress++;
			if (onProgress != null)
			{
				onProgress(this);
			}
			yield return new WaitForSeconds(texturePreloadDelay);
		}
		completed = true;
		loading = false;
		progress = total;
		if (onComplete != null)
		{
			onComplete(this);
		}
	}

	public static SwfBackgroundPreloader backgroundLoadSwf(string swfUri)
	{
		GameObject gameObject = new GameObject();
		gameObject.name = "SwfBackgroundPreloader(" + swfUri + ")";
		SwfBackgroundPreloader swfBackgroundPreloader = gameObject.AddComponent<SwfBackgroundPreloader>();
		swfBackgroundPreloader.swfUri = swfUri;
		return swfBackgroundPreloader;
	}

	protected bool onError()
	{
		if (logErrors)
		{
			Debug.LogError("SwfBackgroundPreloader failed: " + swfUri);
		}
		completed = true;
		failed = true;
		loading = false;
		if (onComplete != null)
		{
			onComplete(this);
		}
		return false;
	}
}
