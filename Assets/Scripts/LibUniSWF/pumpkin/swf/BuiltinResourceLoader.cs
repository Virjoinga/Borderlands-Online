using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace pumpkin.swf
{
	public class BuiltinResourceLoader : ISwfResourceLoader
	{
		public bool enableSceneAssetLoader = false;

		public bool enableAssetBundleResorceLoader = false;

		public bool enableLocalResorceLoader = true;

		public List<AssetBundle> bundles = new List<AssetBundle>();

		public SwfSceneAssetInfo[] sceneAssets;

		public virtual Material getMaterial(MovieClipPlayer player, SwfAssetContext assetContext, DisplayObjectInfo dispInfo, BitmapAssetInfo bmpInfo)
		{
			if ((bool)assetContext.assetBundle)
			{
				return assetContext.textureManager.getBitmapData(assetContext.assetBundle, fixAssetBundleUri(assetContext.swfPrefix + bmpInfo.textureUri));
			}
			string text = assetContext.swfPrefix + bmpInfo.textureUri;
			if (enableSceneAssetLoader && sceneAssets != null)
			{
				for (int i = 0; i < sceneAssets.Length; i++)
				{
					if (sceneAssets[i].resourceUri == text && sceneAssets[i].texture != null)
					{
						return assetContext.textureManager.getBitmapDataFromSceneTexture(text, sceneAssets[i].texture);
					}
				}
			}
			return assetContext.textureManager.getBitmapData(text);
		}

		public virtual Material getCharMaterial(BitmapTextField txt, SwfAssetContext assetContext, BitmapFontAssetInfo fontInfo, BitmapFontCharInfo charInfo, BitmapAssetInfo bmpInfo)
		{
			if ((bool)assetContext.assetBundle)
			{
				return assetContext.textureManager.getBitmapData(assetContext.assetBundle, fixAssetBundleUri(assetContext.swfPrefix + bmpInfo.textureUri));
			}
			string text = assetContext.swfPrefix + bmpInfo.textureUri;
			if (enableSceneAssetLoader && sceneAssets != null)
			{
				for (int i = 0; i < sceneAssets.Length; i++)
				{
					if (sceneAssets[i].resourceUri == text && sceneAssets[i].texture != null)
					{
						return assetContext.textureManager.getBitmapDataFromSceneTexture(text, sceneAssets[i].texture);
					}
				}
			}
			return assetContext.textureManager.getBitmapData(text);
		}

		public virtual SwfAssetContext loadSWF(string swfUri)
		{
			if (MovieClipPlayer.contextCache.ContainsKey(swfUri))
			{
				return MovieClipPlayer.contextCache[swfUri];
			}
			string text = swfPrefix(swfUri, MovieClipPlayer.swfProfile);
			TextAsset textAsset = null;
			if (enableSceneAssetLoader && sceneAssets != null)
			{
				for (int i = 0; i < sceneAssets.Length; i++)
				{
					if (sceneAssets[i].resourceUri == text)
					{
						textAsset = sceneAssets[i].textAsset;
						if (textAsset != null)
						{
							break;
						}
					}
				}
			}
			AssetBundle useAssetBundle = null;
			if (textAsset == null && enableAssetBundleResorceLoader)
			{
				string name = fixAssetBundleUri(text);
				for (int j = 0; j < bundles.Count; j++)
				{
					AssetBundle assetBundle = bundles[j];
					if (MovieClipPlayer.swfProfile != null)
					{
						textAsset = (TextAsset)assetBundle.Load(name, typeof(TextAsset));
					}
					if (textAsset == null)
					{
						text = swfPrefix(swfUri, null);
						textAsset = (TextAsset)assetBundle.Load(name, typeof(TextAsset));
					}
					if (textAsset != null)
					{
						useAssetBundle = assetBundle;
						break;
					}
				}
			}
			if (textAsset == null && enableLocalResorceLoader)
			{
				if (MovieClipPlayer.swfProfile != null)
				{
					textAsset = (TextAsset)Resources.Load(text, typeof(TextAsset));
				}
				if (textAsset == null)
				{
					text = swfPrefix(swfUri, null);
					textAsset = (TextAsset)Resources.Load(text, typeof(TextAsset));
				}
			}
			if (textAsset == null)
			{
				Debug.LogError("MovieClip() Invalid asset url '" + swfUri + "' actual url loaded '" + text + "'");
				return null;
			}
			return _loadFromTextAsset(this, textAsset, swfUri, text, useAssetBundle);
		}

		public bool unloadSWF(string swfUri)
		{
			if (!MovieClipPlayer.contextCache.ContainsKey(swfUri))
			{
				return false;
			}
			SwfAssetContext swfAssetContext = MovieClipPlayer.contextCache[swfUri];
			MovieClipPlayer.contextCache.Remove(swfUri);
			swfAssetContext.textureManager.clearTextureMatchingPrefix(swfAssetContext.swfPrefix);
			return true;
		}

		public static SwfAssetContext _loadFromTextAsset(ISwfResourceLoader loader, TextAsset swfInfoAsset, string swfUri, string swfUriTmp, AssetBundle useAssetBundle)
		{
			SwfBinaryReader b = new SwfBinaryReader(swfInfoAsset.bytes);
			MovieClipReader movieClipReader = new MovieClipReader();
			SwfAssetContext swfAssetContext = null;
			try
			{
				swfAssetContext = movieClipReader.readSwfAssetContext(b, swfUriTmp + "_");
			}
			catch (EndOfStreamException)
			{
				Debug.LogError("MovieClip() SwfSerializerException, corrupt swf '" + swfUri + "'");
				return null;
			}
			catch (SwfSerializerException ex2)
			{
				Debug.LogError("MovieClip() SwfSerializerException, corrupt swf '" + swfUri + "', " + ex2.Message);
				return null;
			}
			if (swfAssetContext == null)
			{
				Debug.LogError("MovieClip() assetContext == null, Invalid swf '" + swfUri + "'");
				return null;
			}
			if (TextureManager.instance == null)
			{
				new TextureManager();
			}
			swfAssetContext.textureManager = TextureManager.instance;
			swfAssetContext.resourceLoader = loader;
			swfAssetContext.assetBundle = useAssetBundle;
			MovieClipPlayer.contextCache[swfUri] = swfAssetContext;
			if ((MovieClipPlayer.profilerSettings & MovieClipProfiler.SwfLoad) == MovieClipProfiler.SwfLoad)
			{
				Debug.Log("SwfProfile->SwfLoad: " + swfUri + ", " + MovieClipPlayer.profilerSettings);
			}
			return swfAssetContext;
		}

		public virtual void addAssetBundle(AssetBundle bundle)
		{
			enableAssetBundleResorceLoader = true;
			bundles.Add(bundle);
		}

		public virtual void removeAssetBundle(AssetBundle bundle)
		{
			enableAssetBundleResorceLoader = true;
			bundles.Remove(bundle);
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, SwfAssetContext> item in MovieClipPlayer.contextCache)
			{
				SwfAssetContext value = item.Value;
				Debug.Log("" + item.Value.assetBundle);
				if (item.Value.assetBundle == bundle)
				{
					Debug.Log("context.swfPrefix=" + value.swfPrefix);
					value.textureManager.clearTextureMatchingPrefix(value.swfPrefix);
					list.Add(item.Key);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				Debug.Log("Remove context: " + list[i]);
				MovieClipPlayer.contextCache.Remove(list[i]);
			}
		}

		public static string swfPrefix(string movieClip, string profile)
		{
			string fileName = Path.GetFileName(movieClip);
			if (profile != null)
			{
				return MovieClipPlayer.swfRoot + movieClip + "." + profile + "/" + fileName + "." + profile;
			}
			return MovieClipPlayer.swfRoot + movieClip + "/" + fileName;
		}

		public static string fixAssetBundleUri(string uri)
		{
			int num = uri.LastIndexOf("/");
			if (num != -1)
			{
				return uri.Substring(num + 1);
			}
			return uri;
		}
	}
}
