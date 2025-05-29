using System.Collections.Generic;
using UnityEngine;
using pumpkin.events;

namespace pumpkin.swf
{
	public class SwfAssetContext : EventDispatcher
	{
		public ITextureManager textureManager;

		public Dictionary<int, AssetBaseInfo> exports = new Dictionary<int, AssetBaseInfo>();

		public string swfPrefix;

		public string sharedAssets;

		public int version;

		public ISwfResourceLoader resourceLoader;

		public AssetBundle assetBundle;

		public string[] stringTable;

		public BitmapAssetInfo getBitmapInfoByCid(int cid)
		{
			if (!exports.ContainsKey(cid))
			{
				Debug.LogWarning("Failed to find cid: " + cid);
				return null;
			}
			if (exports[cid] is BitmapAssetInfo)
			{
				return (BitmapAssetInfo)exports[cid];
			}
			return null;
		}

		public MovieClipAssetInfo getMovieInfoByCid(int cid)
		{
			if (exports[cid] is MovieClipAssetInfo)
			{
				return (MovieClipAssetInfo)exports[cid];
			}
			return null;
		}

		public MovieClipAssetInfo getMovieInfoByName(string name)
		{
			foreach (KeyValuePair<int, AssetBaseInfo> export in exports)
			{
				if (export.Value is MovieClipAssetInfo)
				{
					MovieClipAssetInfo movieClipAssetInfo = (MovieClipAssetInfo)export.Value;
					if (movieClipAssetInfo.className == name)
					{
						return movieClipAssetInfo;
					}
				}
			}
			return null;
		}

		public T getAssetInfoByName<T>(string name) where T : AssetBaseInfo
		{
			foreach (KeyValuePair<int, AssetBaseInfo> export in exports)
			{
				AssetBaseInfo value = export.Value;
				if (value.className == null || value.className.CompareTo(name) != 0 || !(value is T))
				{
					continue;
				}
				return value as T;
			}
			return (T)null;
		}

		public int genUniqueCid()
		{
			int i;
			for (i = 0; exports.ContainsKey(i); i++)
			{
			}
			return i;
		}

		public void optimize()
		{
			foreach (KeyValuePair<int, AssetBaseInfo> export in exports)
			{
				if (export.Value is MovieClipAssetInfo)
				{
					MovieClipAssetInfo info = (MovieClipAssetInfo)export.Value;
					optimizeFrameReferences(info);
				}
			}
		}

		public void optimizeFrameReferences(MovieClipAssetInfo info)
		{
			for (int i = 1; i < info.frames.Count; i++)
			{
				FrameInfo frameInfo = info.frames[i];
				if (frameInfo.actions != null || frameInfo.frameUserActionsXML != null)
				{
					continue;
				}
				bool flag = false;
				FrameInfo frameInfo2 = info.frames[i - 1];
				if (frameInfo2.displayList.Count != frameInfo.displayList.Count)
				{
					continue;
				}
				flag = true;
				for (int j = 0; j < frameInfo.displayList.Count; j++)
				{
					if (frameInfo.displayList[j] != frameInfo2.displayList[j])
					{
						flag = false;
						break;
					}
				}
				if (flag && flag)
				{
					info.frames[i] = frameInfo2;
				}
			}
		}
	}
}
