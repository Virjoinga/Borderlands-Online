using System;
using System.IO;
using A;
using Core;
using UnityEngine;

namespace pumpkin.swf
{
	public class BadAssSWFResourceLoader : BuiltinResourceLoader
	{
		public const string Path_UI_IN_ASSETS = "Assets/ArtResources/UI_uniSWF/SwfAssets/";

		public const string Path_UI_IN_RESOURCES = "UI_uniSWF/SwfAssets/";

		private const string TYPE_NAME = ".bytes";

		public void AllowSceneLoader()
		{
			enableSceneAssetLoader = true;
			sceneAssets = UniSWFSharedAssetManagerBehaviour.getInstance().assets;
		}

		public static SwfAssetContext loadFromTextAsset(ISwfResourceLoader loader, TextAsset swfInfoAsset, string swfUri, string swfUriTmp, AssetBundle useAssetBundle)
		{
			SwfBinaryReader b = new SwfBinaryReader(swfInfoAsset.bytes);
			MovieClipReader movieClipReader = new MovieClipReader();
			SwfAssetContext c7088de59e49f7108f520cf7e0bae167e = c3b2e8f5802a4f769f0d6d8a536054fa1.c7088de59e49f7108f520cf7e0bae167e;
			try
			{
				c7088de59e49f7108f520cf7e0bae167e = movieClipReader.readSwfAssetContext(b, swfUriTmp + "_");
			}
			catch (EndOfStreamException)
			{
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "MovieClip() SwfSerializerException, corrupt swf '" + swfUri + "'");
				return c3b2e8f5802a4f769f0d6d8a536054fa1.c7088de59e49f7108f520cf7e0bae167e;
			}
			catch (SwfSerializerException ex2)
			{
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "MovieClip() SwfSerializerException, corrupt swf '" + swfUri + "', " + ex2.Message);
				return c3b2e8f5802a4f769f0d6d8a536054fa1.c7088de59e49f7108f520cf7e0bae167e;
			}
			if (c7088de59e49f7108f520cf7e0bae167e == null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "MovieClip() assetContext == null, Invalid swf '" + swfUri + "'");
						return null;
					}
				}
			}
			if (UniTextureManager.instance == null)
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
				new UniTextureManager();
			}
			c7088de59e49f7108f520cf7e0bae167e.textureManager = UniTextureManager.instance;
			c7088de59e49f7108f520cf7e0bae167e.resourceLoader = loader;
			c7088de59e49f7108f520cf7e0bae167e.assetBundle = useAssetBundle;
			MovieClipPlayer.getGlobalContextCache()[swfUri] = c7088de59e49f7108f520cf7e0bae167e;
			if ((MovieClipPlayer.profilerSettings & MovieClipProfiler.SwfLoad) == MovieClipProfiler.SwfLoad)
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
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array[0] = "SwfProfile->SwfLoad: ";
				array[1] = swfUri;
				array[2] = ", ";
				array[3] = MovieClipPlayer.profilerSettings;
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, string.Concat(array));
			}
			cacheAssetContext(c7088de59e49f7108f520cf7e0bae167e);
			return c7088de59e49f7108f520cf7e0bae167e;
		}

		protected static void cacheAssetContext(SwfAssetContext swfAssetContext)
		{
			string[] stringTable = swfAssetContext.stringTable;
			for (int i = 0; i < stringTable.Length; i++)
			{
				if (i <= 0)
				{
					continue;
				}
				while (true)
				{
					switch (7)
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
				Material material = cbea7b81e65efa29a099764b7785c1976.c7088de59e49f7108f520cf7e0bae167e;
				if (swfAssetContext.assetBundle != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					material = UniTextureManager.instance.getBitmapData(swfAssetContext.assetBundle, BuiltinResourceLoader.fixAssetBundleUri(swfAssetContext.swfPrefix + stringTable[i]));
				}
				if (material == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					material = UniTextureManager.instance.getBitmapData(swfAssetContext.swfPrefix + stringTable[i]);
				}
				if (!(material == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "Missing texture : " + stringTable[i] + "in flash file:" + swfAssetContext.swfPrefix);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}

		public override Material getCharMaterial(BitmapTextField txt, SwfAssetContext assetContext, BitmapFontAssetInfo fontInfo, BitmapFontCharInfo charInfo, BitmapAssetInfo bmpInfo)
		{
			return base.getCharMaterial(txt, assetContext, fontInfo, charInfo, bmpInfo);
		}

		public override Material getMaterial(MovieClipPlayer player, SwfAssetContext assetContext, DisplayObjectInfo dispInfo, BitmapAssetInfo bmpInfo)
		{
			return base.getMaterial(player, assetContext, dispInfo, bmpInfo);
		}

		public virtual void removeOnlyAssetBundle(AssetBundle bundle)
		{
			enableAssetBundleResorceLoader = true;
			bundles.Remove(bundle);
		}

		public override SwfAssetContext loadSWF(string swfUri)
		{
			if (MovieClipPlayer.getGlobalContextCache().ContainsKey(swfUri))
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return MovieClipPlayer.getGlobalContextCache()[swfUri];
					}
				}
			}
			string text = BuiltinResourceLoader.swfPrefix(swfUri, MovieClipPlayer.swfProfile);
			TextAsset textAsset = c83605b31ccc1890819799ea0ccf10caf.c7088de59e49f7108f520cf7e0bae167e;
			if (enableSceneAssetLoader)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (sceneAssets != null)
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
					int num = 0;
					while (true)
					{
						if (num < sceneAssets.Length)
						{
							if (sceneAssets[num].resourceUri == text)
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
								textAsset = sceneAssets[num].textAsset;
								if (textAsset != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
									break;
								}
							}
							num++;
							continue;
						}
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						break;
					}
				}
			}
			AssetBundle useAssetBundle = c7ef55027131e768983c9fbde13e409ba.c7088de59e49f7108f520cf7e0bae167e;
			if (textAsset == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (enableAssetBundleResorceLoader)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					string name = BuiltinResourceLoader.fixAssetBundleUri(text);
					int num2 = 0;
					while (true)
					{
						if (num2 < bundles.Count)
						{
							AssetBundle assetBundle = bundles[num2];
							if (MovieClipPlayer.swfProfile != null)
							{
								while (true)
								{
									switch (4)
									{
									case 0:
										continue;
									}
									break;
								}
								textAsset = (TextAsset)assetBundle.Load(name, Type.GetTypeFromHandle(cda4706963b5b94cc26d866126dd86f9c.cc1720d05c75832f704b87474932341c3()));
							}
							if (textAsset == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								textAsset = (TextAsset)assetBundle.Load(name, Type.GetTypeFromHandle(cda4706963b5b94cc26d866126dd86f9c.cc1720d05c75832f704b87474932341c3()));
							}
							if (textAsset != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								useAssetBundle = assetBundle;
								break;
							}
							num2++;
							continue;
						}
						while (true)
						{
							switch (5)
							{
							case 0:
								continue;
							}
							break;
						}
						break;
					}
				}
			}
			if (textAsset == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (enableLocalResorceLoader)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					if (MovieClipPlayer.swfProfile != null)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							break;
						}
						textAsset = Resources.Load<TextAsset>("UI_uniSWF/SwfAssets/" + text);
						if (textAsset == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
						{
							while (true)
							{
								switch (2)
								{
								case 0:
									continue;
								}
								break;
							}
							textAsset = Resources.Load<TextAsset>(text);
						}
					}
					if (textAsset == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								continue;
							}
							break;
						}
						text = BuiltinResourceLoader.swfPrefix(swfUri, c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e);
						textAsset = Resources.Load<TextAsset>("UI_uniSWF/SwfAssets/" + text);
						if (textAsset == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									continue;
								}
								break;
							}
							textAsset = Resources.Load<TextAsset>(text);
						}
					}
				}
			}
			if (textAsset == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
					{
						string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(5);
						array[0] = "MovieClip() Invalid asset url '";
						array[1] = swfUri;
						array[2] = "' actual url loaded '";
						array[3] = text;
						array[4] = "'";
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, string.Concat(array));
						return null;
					}
					}
				}
			}
			return loadFromTextAsset(this, textAsset, swfUri, text, useAssetBundle);
		}
	}
}
