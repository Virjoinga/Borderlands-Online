using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using pumpkin.events;
using pumpkin.net;
using pumpkin.swf;

namespace pumpkin.display
{
	public class WWWMovieClip : MovieClip
	{
		private URLLoader loader;

		private URLRequest request;

		private string swfFilename;

		private string baseUrl;

		private List<string> texturesLoaded;

		private List<string> texturesRequests;

		private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

		private string symbol;

		public bool nonReadableTextures = true;

		public static Dictionary<string, SwfAssetContext> wwwMovieClipCache = new Dictionary<string, SwfAssetContext>();

		public static Dictionary<string, List<WWWMovieClip>> loadingDepQueue = new Dictionary<string, List<WWWMovieClip>>();

		protected bool m_Failed = false;

		protected bool m_DeferLoadFromCache = false;

		public WWWMovieClip(string url, string symbol)
		{
			swfFilename = url.Substring(url.LastIndexOf("/") + 1);
			this.symbol = symbol;
			baseUrl = url;
			if (wwwMovieClipCache.ContainsKey(baseUrl))
			{
				if (wwwMovieClipCache[baseUrl] != null)
				{
					m_DeferLoadFromCache = true;
					return;
				}
				if (!loadingDepQueue.ContainsKey(baseUrl))
				{
					loadingDepQueue[baseUrl] = new List<WWWMovieClip>();
				}
				loadingDepQueue[baseUrl].Add(this);
			}
			else
			{
				wwwMovieClipCache.Add(baseUrl, null);
				loader = new URLLoader();
				loader.addEventListener(CEvent.COMPLETE, onRequestComplete);
				loader.addEventListener(IOErrorEvent.IO_ERROR, onIoErrorHandler);
				request = new URLRequest(baseUrl + "/" + swfFilename + ".bytes");
				request.method = URLRequestMethod.GET;
				loader.load(request);
			}
		}

		public override void updateFrame(CEvent e)
		{
			if (m_DeferLoadFromCache)
			{
				m_DeferLoadFromCache = false;
				m_AssetContext = wwwMovieClipCache[baseUrl];
				setSymbolName(symbol);
				dispatchEvent(new CEvent(CEvent.COMPLETE));
				play();
			}
			base.updateFrame(e);
		}

		private void onRequestComplete(CEvent eventIn)
		{
			SwfBinaryReader b = new SwfBinaryReader(loader.www.bytes);
			MovieClipReader movieClipReader = new MovieClipReader();
			m_AssetContext = null;
			try
			{
				m_AssetContext = movieClipReader.readSwfAssetContext(b, baseUrl + "/" + swfFilename + "_");
			}
			catch (EndOfStreamException)
			{
				Debug.LogError(string.Concat("MovieClip() corrupt swf '", swfUri, "'"));
			}
			catch (SwfSerializerException ex2)
			{
				Debug.LogError(string.Concat("MovieClip() corrupt swf '", swfUri, "', ", ex2.Message));
			}
			if (base.assetContext == null)
			{
				Debug.LogError(string.Concat("MovieClip() Invalid swf '", swfUri, "'"));
				ErrorEvent errorEvent = new ErrorEvent(ErrorEvent.ERROR);
				errorEvent.error = string.Concat("Movieclip failed to load, Reason given: Invalid swf '", swfUri, "'");
				onError(errorEvent);
				dispatchEvent(errorEvent);
				return;
			}
			base.assetContext.resourceLoader = MovieClipPlayer.rootResourceLoader;
			texturesRequests = new List<string>();
			texturesLoaded = new List<string>();
			foreach (KeyValuePair<int, AssetBaseInfo> export in base.assetContext.exports)
			{
				AssetBaseInfo value = export.Value;
				if (!(value is BitmapAssetInfo))
				{
					continue;
				}
				BitmapAssetInfo bitmapAssetInfo = value as BitmapAssetInfo;
				if (!(bitmapAssetInfo.bitmapData != null))
				{
					string text = base.assetContext.swfPrefix + bitmapAssetInfo.textureUri;
					if (!(base.assetContext.textureManager.getBitmapData(text) != null) && texturesRequests.IndexOf(text) == -1)
					{
						texturesRequests.Add(text);
						URLLoader uRLLoader = new URLLoader();
						uRLLoader.addEventListener(CEvent.COMPLETE, onTextureRequestComplete);
						uRLLoader.addEventListener(IOErrorEvent.IO_ERROR, onIoErrorHandler);
						URLRequest uRLRequest = new URLRequest(text + ".png");
						uRLRequest.method = URLRequestMethod.GET;
						uRLLoader.load(uRLRequest);
					}
				}
			}
			if (texturesRequests.Count == 0)
			{
				onAllTextureAssetsLoaded();
			}
		}

		private void onIoErrorHandler(CEvent e)
		{
			if (!m_Failed)
			{
				m_Failed = true;
				IOErrorEvent iOErrorEvent = e.toEvent<IOErrorEvent>();
				ErrorEvent errorEvent = new ErrorEvent(ErrorEvent.ERROR);
				errorEvent.error = "Movieclip failed to load, Reason given: " + iOErrorEvent.error;
				onError(errorEvent);
				dispatchEvent(errorEvent);
			}
		}

		private void onTextureRequestComplete(CEvent eventIn)
		{
			if (m_Failed)
			{
				return;
			}
			URLLoader uRLLoader = eventIn.target as URLLoader;
			if (texturesLoaded.IndexOf(uRLLoader.request.url) != -1)
			{
				return;
			}
			texturesLoaded.Add(uRLLoader.request.url);
			if (nonReadableTextures)
			{
				textures[uRLLoader.request.url] = uRLLoader.www.textureNonReadable;
			}
			else
			{
				textures[uRLLoader.request.url] = uRLLoader.www.texture;
			}
			if (texturesLoaded.Count < texturesRequests.Count)
			{
				return;
			}
			foreach (KeyValuePair<int, AssetBaseInfo> export in base.assetContext.exports)
			{
				AssetBaseInfo value = export.Value;
				if (value is BitmapAssetInfo)
				{
					BitmapAssetInfo bitmapAssetInfo = value as BitmapAssetInfo;
					if (!(bitmapAssetInfo.bitmapData != null))
					{
						string text = base.assetContext.swfPrefix + bitmapAssetInfo.textureUri + ".png";
						bitmapAssetInfo.bitmapData = base.assetContext.textureManager.createBitmapDataFromTexture(text, textures[text]);
						Vector2 vector = TextureManager.MaterialPixelSpaceToUVSpace(bitmapAssetInfo.bitmapData, new Vector2(bitmapAssetInfo.srcRect.x, bitmapAssetInfo.srcRect.y));
						Vector2 vector2 = TextureManager.MaterialPixelSpaceToUVSpace(bitmapAssetInfo.bitmapData, new Vector2(bitmapAssetInfo.srcRect.width, bitmapAssetInfo.srcRect.height));
						bitmapAssetInfo.uvRect = new Rect(vector.x, vector.y, vector2.x, vector2.y);
					}
				}
			}
			onAllTextureAssetsLoaded();
		}

		private void onAllTextureAssetsLoaded()
		{
			wwwMovieClipCache[baseUrl] = base.assetContext;
			setSymbolName(symbol);
			play();
			dispatchEvent(new CEvent(CEvent.COMPLETE));
			if (loadingDepQueue.ContainsKey(baseUrl))
			{
				List<WWWMovieClip> list = loadingDepQueue[baseUrl];
				for (int i = 0; i < list.Count; i++)
				{
					list[i].m_DeferLoadFromCache = true;
				}
			}
		}

		private void onError(ErrorEvent error)
		{
			if (loadingDepQueue.ContainsKey(baseUrl))
			{
				loadingDepQueue.Remove(baseUrl);
			}
			if (wwwMovieClipCache.ContainsKey(baseUrl))
			{
				wwwMovieClipCache.Remove(baseUrl);
			}
			if (loadingDepQueue.ContainsKey(baseUrl))
			{
				List<WWWMovieClip> list = loadingDepQueue[baseUrl];
				for (int i = 0; i < list.Count; i++)
				{
					list[i].dispatchEvent(error);
				}
			}
			unload();
		}

		public void unload()
		{
			unload(true);
		}

		public void unload(bool unloadUnusedAssets)
		{
			if (base.assetContext != null)
			{
				foreach (KeyValuePair<int, AssetBaseInfo> export in base.assetContext.exports)
				{
					if (export.Value is BitmapAssetInfo)
					{
						BitmapAssetInfo bitmapAssetInfo = export.Value as BitmapAssetInfo;
						bitmapAssetInfo.bitmapData.mainTexture = null;
						bitmapAssetInfo.bitmapData = null;
						bitmapAssetInfo.embedeData = null;
					}
				}
			}
			List<string> list = new List<string>();
			List<Texture> list2 = new List<Texture>();
			string value = baseUrl;
			Texture[] array = (Texture[])Resources.FindObjectsOfTypeAll(typeof(Texture));
			Dictionary<string, Texture> dictionary = TextureManager.instance.textures;
			foreach (string key in dictionary.Keys)
			{
				if (Array.IndexOf(array, dictionary[key]) != -1 && key.StartsWith(value))
				{
					list.Add(key);
					list2.Add(dictionary[key]);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (dictionary.ContainsKey(list[i]))
				{
					Texture2D texture2D = dictionary[list[i]] as Texture2D;
					dictionary.Remove(list[i]);
					if ((bool)texture2D)
					{
						UnityEngine.Object.Destroy(texture2D);
					}
				}
			}
			if (wwwMovieClipCache.ContainsKey(baseUrl))
			{
				wwwMovieClipCache.Remove(baseUrl);
			}
			if (unloadUnusedAssets)
			{
				Resources.UnloadUnusedAssets();
			}
			loader = null;
			request = null;
			swfFilename = null;
			texturesLoaded = null;
			texturesRequests = null;
			dictionary = null;
			if (loadingDepQueue.ContainsKey(baseUrl))
			{
				loadingDepQueue.Remove(baseUrl);
			}
			if (wwwMovieClipCache.ContainsKey(baseUrl))
			{
				wwwMovieClipCache.Remove(baseUrl);
			}
			removeAllChildren();
		}

		public static bool unloadCache(string baseUrl)
		{
			return unloadCache(baseUrl, true);
		}

		public static bool unloadCache(string baseUrl, bool unloadUnusedAssets)
		{
			if (!wwwMovieClipCache.ContainsKey(baseUrl))
			{
				return false;
			}
			SwfAssetContext swfAssetContext = wwwMovieClipCache[baseUrl];
			if (swfAssetContext != null)
			{
				foreach (KeyValuePair<int, AssetBaseInfo> export in swfAssetContext.exports)
				{
					if (export.Value is BitmapAssetInfo)
					{
						BitmapAssetInfo bitmapAssetInfo = export.Value as BitmapAssetInfo;
						bitmapAssetInfo.bitmapData.mainTexture = null;
						bitmapAssetInfo.bitmapData = null;
						bitmapAssetInfo.embedeData = null;
					}
				}
			}
			List<string> list = new List<string>();
			List<Texture> list2 = new List<Texture>();
			Texture[] array = (Texture[])Resources.FindObjectsOfTypeAll(typeof(Texture));
			Dictionary<string, Texture> dictionary = TextureManager.instance.textures;
			foreach (string key in dictionary.Keys)
			{
				if (Array.IndexOf(array, dictionary[key]) != -1 && key.StartsWith(baseUrl))
				{
					list.Add(key);
					list2.Add(dictionary[key]);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (dictionary.ContainsKey(list[i]))
				{
					(dictionary[list[i]] as Texture2D).Resize(0, 0);
					dictionary.Remove(list[i]);
				}
			}
			if (wwwMovieClipCache.ContainsKey(baseUrl))
			{
				wwwMovieClipCache.Remove(baseUrl);
			}
			if (unloadUnusedAssets)
			{
				Resources.UnloadUnusedAssets();
			}
			if (loadingDepQueue.ContainsKey(baseUrl))
			{
				loadingDepQueue.Remove(baseUrl);
			}
			if (wwwMovieClipCache.ContainsKey(baseUrl))
			{
				wwwMovieClipCache.Remove(baseUrl);
			}
			return true;
		}

		public new static void clearContextCache()
		{
			clearContextCache(true);
		}

		public static void clearContextCache(bool unloadUnusedAssets)
		{
			List<string> list = new List<string>();
			foreach (string key in wwwMovieClipCache.Keys)
			{
				list.Add(key);
			}
			for (int i = 0; i < list.Count; i++)
			{
				unloadCache(list[i], unloadUnusedAssets);
			}
		}
	}
}
