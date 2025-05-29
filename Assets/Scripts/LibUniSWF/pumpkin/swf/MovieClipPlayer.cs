using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;
using pumpkin.swf.vm;
using pumpkin.system.defaults;
using pumpkin.text;
using pumpkin.utils;

namespace pumpkin.swf
{
	public class MovieClipPlayer : pumpkin.display.Sprite
	{
		private class FrameLabelSorter : IComparer
		{
			public int Compare(object aIn, object bIn)
			{
				FrameLabel frameLabel = aIn as FrameLabel;
				FrameLabel frameLabel2 = bIn as FrameLabel;
				if (frameLabel.frame < frameLabel2.frame)
				{
					return -1;
				}
				if (frameLabel.frame > frameLabel2.frame)
				{
					return 1;
				}
				return 0;
			}
		}

		public const int STATE_STOPPED = 0;

		public const int STATE_PLAYING = 1;

		public const int STATE_PLAYING_REVERSE = 2;

		public static string swfRoot = "";

		public static string swfProfile = null;

		public static MovieClipProfiler profilerSettings = MovieClipProfiler.SwfNone;

		public bool enableTextfieldKeyframes = false;

		public bool loadTextures = true;

		public static bool enableAdvancedTextfield = false;

		public static bool _dev_enable_frameReferencing = false;

		[Obsolete("enableDepreciatedPreFrameCallback has no effect")]
		public static bool enableDepreciatedPreFrameCallback = false;

		public static bool enableScale9 = false;

		public static bool enableDepreciatedInnerMovieClipFrameSetup = false;

		public static bool enableUVSubPixelBug = false;

		public static ISwfResourceLoader rootResourceLoader = MovieClipPlayerDefaults.rootResourceLoader;

		internal static Dictionary<string, SwfAssetContext> contextCache = MovieClipPlayerDefaults.contextCache;

		protected MovieClipAssetInfo m_MovieClipInfo;

		protected SwfAssetContext m_AssetContext;

		protected SwfAssetContext sharedAssetContext;

		protected int m_PlayState = 1;

		protected int m_FrameNum = -1;

		protected IntCollection m_InstanceCache = new IntCollection();

		protected bool m_Debug = false;

		protected string m_SymbolName;

		protected int m_SetFrameNextUpdate = -1;

		protected bool m_Loop = true;

		protected bool m_AllowFrameScriptableEvents = true;

		protected static Dictionary<string, Type> g_MovieClipClassMap = null;

		protected FrameScriptEventDispatcher frameScriptDispatcher;

		protected List<int> m_PrevChildren = new List<int>();

		protected bool m_ChildrendSwap = false;

		protected int m_FrameCallbackDepth = 0;

		protected CEvent m_FrameCallbackEvent = null;

		protected Rect m_CachedScale9Bounds;

		protected bool m_CachedScale = false;

		protected pumpkin.display.Sprite m_CachedSliceSprite = null;

		protected TextField m_CachedTextField;

		protected Vector2 m_CachedTxtSrcSz;

		protected Vector2 m_CachedTxtSrcPos;

		public int playState
		{
			get
			{
				return m_PlayState;
			}
			set
			{
				m_PlayState = value;
			}
		}

		public bool isPlaying
		{
			get
			{
				return m_PlayState == 1 || m_PlayState == 2;
			}
		}

		public int totalFrames
		{
			get
			{
				return getTotalFrames();
			}
		}

		public int currentFrame
		{
			get
			{
				return getCurrentFrame();
			}
			set
			{
				m_SetFrameNextUpdate = value;
			}
		}

		public string currentLabel
		{
			get
			{
				if (m_MovieClipInfo == null)
				{
					return "";
				}
				_cacheFrameLabels();
				return m_MovieClipInfo.frames[m_FrameNum].label;
			}
		}

		public FrameLabel[] currentLabels
		{
			get
			{
				if (m_MovieClipInfo == null || m_MovieClipInfo.labels == null)
				{
					return new FrameLabel[0];
				}
				List<FrameLabel> list = new List<FrameLabel>();
				_cacheFrameLabels();
				foreach (string key in m_MovieClipInfo.labels.Keys)
				{
					bool flag = false;
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].name == key)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						list.Add(new FrameLabel(m_MovieClipInfo.labels[key], key));
					}
				}
				FrameLabel[] array = list.ToArray();
				Array.Sort(array, new FrameLabelSorter());
				return array;
			}
		}

		public bool looping
		{
			get
			{
				return m_Loop;
			}
			set
			{
				m_Loop = value;
			}
		}

		public SwfAssetContext assetContext
		{
			get
			{
				return m_AssetContext;
			}
		}

		public MovieClipAssetInfo movieClipInfo
		{
			get
			{
				return m_MovieClipInfo;
			}
		}

		internal MovieClipPlayer(SwfAssetContext assetContext, string symbolName)
		{
			m_AssetContext = assetContext;
			if (symbolName != null)
			{
				setSymbolName(symbolName);
			}
			if (totalFrames == 1)
			{
				m_PlayState = 0;
			}
		}

		public void setSymbolName(string symbolName)
		{
			if (m_AssetContext != null)
			{
				m_FrameNum = -1;
				m_SymbolName = symbolName;
				m_MovieClipInfo = m_AssetContext.getMovieInfoByName(symbolName);
				OnSetMovieClipInfo();
				setFrame(1);
			}
		}

		internal void setSymbolByCid(SwfAssetContext assetContext, int cid)
		{
			m_MovieClipInfo = assetContext.getMovieInfoByCid(cid);
			if (m_MovieClipInfo.shared)
			{
				string className = m_MovieClipInfo.className;
				m_MovieClipInfo = findMovieClipInSharedAssets(className);
				if (m_MovieClipInfo == null)
				{
					Debug.LogWarning("MovieClipPlayer() failed to find shared clip '" + className + "'");
					return;
				}
				m_AssetContext = m_MovieClipInfo.assetContext;
				m_FrameNum = -1;
				m_SymbolName = "cid(" + cid + ")";
				if (m_MovieClipInfo != null)
				{
					m_SymbolName = m_MovieClipInfo.className;
				}
			}
			else
			{
				m_AssetContext = assetContext;
				m_FrameNum = -1;
				m_SymbolName = "cid(" + cid + ")";
				if (m_MovieClipInfo != null)
				{
					m_SymbolName = m_MovieClipInfo.className;
				}
			}
			OnSetMovieClipInfo();
			setFrame(1);
		}

		public void setFrameLabel(string label)
		{
			if (m_MovieClipInfo != null && m_MovieClipInfo.labels.ContainsKey(label))
			{
				setFrame(m_MovieClipInfo.labels[label]);
			}
		}

		public int getFrameLabel(string label)
		{
			if (m_MovieClipInfo == null)
			{
				return 0;
			}
			if (!m_MovieClipInfo.labels.ContainsKey(label))
			{
				return 0;
			}
			return m_MovieClipInfo.labels[label];
		}

		protected void OnSetMovieClipInfo()
		{
			if (m_MovieClipInfo != null && m_MovieClipInfo.scale9grid != null)
			{
				base.scale9Grid = m_MovieClipInfo.scale9grid.rect;
			}
		}

		public void setFrameForce(int frameNum)
		{
			m_FrameNum = -1;
			setFrame(frameNum, false);
		}

		public void setFrame(int frameNum)
		{
			setFrame(frameNum, false);
		}

		protected void setFrame(int frameNum, bool isFrameUpdate)
		{
			_setFrame(frameNum - 1, isFrameUpdate);
		}

		protected void _setFrame(int frameNum, bool isFrameUpdate)
		{
			if (m_FrameNum == frameNum)
			{
				return;
			}
			if (frameNum < 0)
			{
				frameNum = 0;
				if (m_FrameNum == frameNum)
				{
					return;
				}
			}
			else if (frameNum >= totalFrames)
			{
				frameNum = totalFrames - 1;
				if (m_FrameNum == frameNum)
				{
					return;
				}
			}
			m_FrameNum = frameNum;
			m_PrevChildren.Clear();
			for (int i = 0; i < m_Children.Count; i++)
			{
				m_PrevChildren.Add(m_Children[i].GetHashCode());
			}
			m_Children.Clear();
			if (m_MovieClipInfo == null)
			{
				while (base.numChildren > 0)
				{
					getChildAt(0)._destoryImpl();
					removeChildAt(0);
				}
				m_PlayState = 0;
				if (m_SymbolName != null && m_SymbolName.Length > 0)
				{
					Debug.LogWarning("Missing symbol name: " + m_SymbolName + " in " + m_AssetContext.swfPrefix);
				}
			}
			else
			{
				if (m_FrameNum < 0 || m_FrameNum >= m_MovieClipInfo.frames.Count)
				{
					return;
				}
				FrameInfo frameInfo = m_MovieClipInfo.frames[m_FrameNum];
				bool flag = false;
				if (_dev_enable_frameReferencing && m_FrameNum > 0)
				{
					FrameInfo frameInfo2 = m_MovieClipInfo.frames[m_FrameNum - 1];
					if (frameInfo2 == frameInfo)
					{
						flag = true;
					}
				}
				for (int j = 0; j < frameInfo.displayList.Count; j++)
				{
					DisplayObjectInfo displayObjectInfo = frameInfo.displayList[j];
					AssetBaseInfo assetBaseInfo = m_AssetContext.exports[displayObjectInfo.cid];
					if (assetBaseInfo is BitmapAssetInfo)
					{
						pumpkin.display.Sprite sprite = ((!m_InstanceCache.ContainsKey(displayObjectInfo.instanceId)) ? null : ((pumpkin.display.Sprite)m_InstanceCache[displayObjectInfo.instanceId]));
						if (sprite != null && sprite.cachedCid != displayObjectInfo.cid)
						{
							sprite = null;
						}
						if (sprite == null)
						{
							BitmapAssetInfo bitmapAssetInfo = assetBaseInfo as BitmapAssetInfo;
							if (bitmapAssetInfo == null)
							{
								continue;
							}
							if (loadTextures && bitmapAssetInfo.bitmapData == null)
							{
								bitmapAssetInfo.bitmapData = m_AssetContext.resourceLoader.getMaterial(this, m_AssetContext, displayObjectInfo, bitmapAssetInfo);
								if (bitmapAssetInfo.bitmapData == null)
								{
									continue;
								}
								Vector2 vector = TextureManager.MaterialPixelSpaceToUVSpace(bitmapAssetInfo.bitmapData, new Vector2(bitmapAssetInfo.srcRect.x, bitmapAssetInfo.srcRect.y));
								Vector2 vector2 = TextureManager.MaterialPixelSpaceToUVSpace(bitmapAssetInfo.bitmapData, new Vector2(bitmapAssetInfo.srcRect.width, bitmapAssetInfo.srcRect.height));
								bitmapAssetInfo.uvRect = new Rect(vector.x, vector.y, vector2.x, vector2.y);
							}
							sprite = new pumpkin.display.Sprite();
							sprite.graphics.perPixelHitTestEnabled = graphics.perPixelHitTestEnabled || bitmapAssetInfo.textureReadWrite;
							sprite.graphics.drawRectUV(bitmapAssetInfo.bitmapData, bitmapAssetInfo.uvRect, 0f, 0f, bitmapAssetInfo.shapeRect.width, bitmapAssetInfo.shapeRect.height);
							sprite.cachedCid = displayObjectInfo.cid;
							if (displayObjectInfo.name != null)
							{
								sprite.name = displayObjectInfo.name;
							}
							m_InstanceCache[displayObjectInfo.instanceId] = sprite;
						}
						_addChildInternal(sprite);
						if (!flag)
						{
							displayObjectInfo.tranform.applyToSprite(sprite);
						}
						if (displayObjectInfo.blendMode != sprite.blendMode)
						{
							sprite.m_BlendMode = displayObjectInfo.blendMode;
						}
					}
					else if (assetBaseInfo is MovieClipAssetInfo)
					{
						MovieClipPlayer movieClipPlayer = ((!m_InstanceCache.ContainsKey(displayObjectInfo.instanceId)) ? null : ((MovieClipPlayer)m_InstanceCache[displayObjectInfo.instanceId]));
						if (movieClipPlayer != null && movieClipPlayer.cachedCid != displayObjectInfo.cid)
						{
							movieClipPlayer = null;
						}
						if (movieClipPlayer == null)
						{
							movieClipPlayer = onInstanceChildMovieClip(displayObjectInfo, j);
							movieClipPlayer.graphics.perPixelHitTestEnabled = graphics.perPixelHitTestEnabled;
							movieClipPlayer.loadTextures = loadTextures;
							movieClipPlayer.setSymbolByCid(m_AssetContext, displayObjectInfo.cid);
							movieClipPlayer.name = displayObjectInfo.name;
							movieClipPlayer.cachedCid = displayObjectInfo.cid;
							if (enableDepreciatedInnerMovieClipFrameSetup)
							{
								movieClipPlayer.setFrame(1);
							}
							else if (isFrameUpdate)
							{
								movieClipPlayer.m_FrameNum = -1;
							}
							else
							{
								movieClipPlayer.setFrame(1, isFrameUpdate);
							}
							m_InstanceCache[displayObjectInfo.instanceId] = movieClipPlayer;
						}
						_addChildInternal(movieClipPlayer);
						if (!flag)
						{
							displayObjectInfo.tranform.applyToSprite(movieClipPlayer);
						}
						if (displayObjectInfo.blendMode != movieClipPlayer.blendMode)
						{
							movieClipPlayer.m_BlendMode = displayObjectInfo.blendMode;
						}
					}
					else if (assetBaseInfo is SimpleShapeAssetInfo)
					{
						pumpkin.display.Sprite sprite2 = ((!m_InstanceCache.ContainsKey(displayObjectInfo.instanceId)) ? null : ((pumpkin.display.Sprite)m_InstanceCache[displayObjectInfo.instanceId]));
						if (sprite2 != null && sprite2.cachedCid != displayObjectInfo.cid)
						{
							sprite2 = null;
						}
						if (sprite2 == null)
						{
							sprite2 = new pumpkin.display.Sprite();
							sprite2.name = displayObjectInfo.name;
							sprite2.cachedCid = displayObjectInfo.cid;
							SimpleShapeAssetInfo simpleShapeAssetInfo = assetBaseInfo as SimpleShapeAssetInfo;
							simpleShapeAssetInfo.applyToSprite(m_AssetContext, sprite2, displayObjectInfo, this);
							m_InstanceCache[displayObjectInfo.instanceId] = sprite2;
						}
						_addChildInternal(sprite2);
						if (!flag)
						{
							displayObjectInfo.tranform.applyToSprite(sprite2);
						}
						if (displayObjectInfo.blendMode != sprite2.blendMode)
						{
							sprite2.m_BlendMode = displayObjectInfo.blendMode;
						}
					}
					else
					{
						if (!(assetBaseInfo is BitmapFontAssetInfo))
						{
							continue;
						}
						TextField textField = ((!m_InstanceCache.ContainsKey(displayObjectInfo.instanceId)) ? null : ((TextField)m_InstanceCache[displayObjectInfo.instanceId]));
						if (enableTextfieldKeyframes && textField != null && textField.cachedCid != displayObjectInfo.cid)
						{
							textField = null;
						}
						bool flag2 = false;
						if (textField == null)
						{
							BitmapFontAssetInfo bitmapFontAssetInfo = assetBaseInfo as BitmapFontAssetInfo;
							textField = onInstanceBitmapTextField(bitmapFontAssetInfo, j);
							textField.cachedCid = displayObjectInfo.cid;
							textField.srcWidth = displayObjectInfo.tranform.width;
							textField.srcHeight = displayObjectInfo.tranform.height;
							textField.setAssetInfo(m_AssetContext, bitmapFontAssetInfo, displayObjectInfo);
							textField.name = displayObjectInfo.name;
							m_InstanceCache[displayObjectInfo.instanceId] = textField;
							flag2 = true;
						}
						_addChildInternal(textField);
						if (!flag)
						{
							displayObjectInfo.tranform.applyToSprite(textField);
						}
						if (displayObjectInfo.textInfo != null && (enableTextfieldKeyframes || flag2))
						{
							if (textField.textFormat.align != displayObjectInfo.textInfo.align)
							{
								textField.textFormat.align = displayObjectInfo.textInfo.align;
							}
							if (textField.type != displayObjectInfo.textInfo.type)
							{
								textField.type = displayObjectInfo.textInfo.type;
							}
							if (textField.multiline != (displayObjectInfo.textInfo.multiline == 1))
							{
								textField.multiline = displayObjectInfo.textInfo.multiline == 1;
							}
							if (textField.maxChars != displayObjectInfo.textInfo.maxChars)
							{
								textField.maxChars = displayObjectInfo.textInfo.maxChars;
							}
							if (displayObjectInfo.textInfo.letterSpacing != -1f && textField.textFormat.letterSpacing != displayObjectInfo.textInfo.letterSpacing)
							{
								textField.textFormat.letterSpacing = displayObjectInfo.textInfo.letterSpacing;
							}
							if (textField.textFormat.color != displayObjectInfo.textInfo.color && !textField.hasFilters)
							{
								textField.textFormat.color = displayObjectInfo.textInfo.color;
							}
						}
						if ((enableTextfieldKeyframes || flag2) && (textField.text == null || textField.text.Length == 0) && displayObjectInfo.textInfo.text != null && displayObjectInfo.textInfo.text.Length > 0)
						{
							textField.text = displayObjectInfo.textInfo.text;
						}
						if (displayObjectInfo.blendMode != textField.blendMode)
						{
							textField.m_BlendMode = displayObjectInfo.blendMode;
						}
					}
				}
				if (m_AllowFrameScriptableEvents)
				{
					if (frameScriptDispatcher != null)
					{
						int frameNum2 = m_FrameNum;
						try
						{
							m_FrameCallbackDepth++;
							if (m_FrameCallbackDepth > 128)
							{
								throw new Exception("addFrameScript() callback depth limit reached");
							}
							if (m_FrameCallbackEvent == null)
							{
								m_FrameCallbackEvent = new CEvent(CEvent.ENTER_FRAME);
							}
							m_FrameCallbackEvent.target = this;
							m_FrameCallbackEvent.currentTarget = this;
							frameScriptDispatcher.dispatchEventId(m_FrameNum, m_FrameCallbackEvent);
						}
						finally
						{
							m_FrameCallbackDepth--;
						}
						if (frameNum2 != m_FrameNum)
						{
							return;
						}
					}
					if (frameInfo.actions != null && m_FrameCallbackDepth == 0)
					{
						SimpleActionVM globalVM = SimpleActionVM.getGlobalVM();
						try
						{
							m_FrameCallbackDepth++;
							if (m_FrameCallbackDepth > 128)
							{
								throw new Exception("SimpleActionVM callback depth limit reached");
							}
							int frameNum3 = m_FrameNum;
							globalVM.runFrame(this as MovieClip, frameInfo.actions, null, null);
							if (frameNum3 != m_FrameNum)
							{
								return;
							}
						}
						finally
						{
							m_FrameCallbackDepth--;
						}
					}
				}
				if (m_HasScale9)
				{
					_clearScale9Cache();
					rebuildScale9Grid();
				}
			}
		}

		protected void _addChildInternal(DisplayObject d)
		{
			if (m_Children.Count < m_PrevChildren.Count && m_PrevChildren[m_Children.Count] == d.GetHashCode())
			{
				m_Children.Add(d);
			}
			else
			{
				addChild(d);
			}
		}

		public void invalidateFrameCache()
		{
			m_FrameNum = -1;
		}

		public override void updateFrame(CEvent e)
		{
			int frameNum = m_FrameNum;
			if (m_SetFrameNextUpdate != -1)
			{
				setFrame(m_SetFrameNextUpdate, true);
				m_SetFrameNextUpdate = -1;
			}
			if (m_PlayState == 1)
			{
				if (m_FrameNum + 1 >= totalFrames)
				{
					if (m_Loop)
					{
						_setFrame(0, true);
					}
					else
					{
						setPlayState(0);
					}
				}
				else
				{
					_setFrame(m_FrameNum + 1, true);
				}
			}
			else if (m_PlayState == 2)
			{
				if (m_FrameNum - 1 < 0)
				{
					if (m_Loop)
					{
						_setFrame(totalFrames - 1, true);
					}
					else
					{
						setPlayState(0);
					}
				}
				else
				{
					_setFrame(m_FrameNum - 1, true);
				}
			}
			else
			{
				_setFrame(m_FrameNum, true);
			}
			base.updateFrame(e);
			_cacheInternal();
		}

		public void setPlayState(int i)
		{
			m_PlayState = i;
		}

		protected void _cacheFrameLabels()
		{
			if (m_MovieClipInfo.frameLabelsCached)
			{
				return;
			}
			string label = null;
			for (int i = 0; i < m_MovieClipInfo.frames.Count; i++)
			{
				FrameInfo frameInfo = m_MovieClipInfo.frames[i];
				foreach (KeyValuePair<string, int> label2 in m_MovieClipInfo.labels)
				{
					if (label2.Value == i + 1)
					{
						label = label2.Key;
					}
				}
				frameInfo.label = label;
			}
			m_MovieClipInfo.frameLabelsCached = true;
		}

		public int getTotalFrames()
		{
			return (m_MovieClipInfo != null) ? m_MovieClipInfo.frames.Count : 0;
		}

		public int getCurrentFrame()
		{
			return m_FrameNum + 1;
		}

		public string getSymbolName()
		{
			return m_SymbolName;
		}

		public bool addFrameScript(object frameOrLabel, EventCallback callback)
		{
			if (m_MovieClipInfo == null)
			{
				return false;
			}
			int num = 0;
			if (frameOrLabel is string)
			{
				num = getFrameLabel((string)frameOrLabel) - 1;
			}
			else if (frameOrLabel is int)
			{
				num = (int)frameOrLabel - 1;
			}
			if (num < 0 || num >= m_MovieClipInfo.frames.Count)
			{
				return false;
			}
			if (frameScriptDispatcher == null)
			{
				frameScriptDispatcher = new FrameScriptEventDispatcher();
			}
			frameScriptDispatcher.addEventListener(num, callback);
			return true;
		}

		public bool removeFrameScript(object frameOrLabel, EventCallback callback)
		{
			if (m_MovieClipInfo == null)
			{
				return false;
			}
			if (frameScriptDispatcher == null)
			{
				return false;
			}
			int num = 0;
			if (frameOrLabel is string)
			{
				num = getFrameLabel((string)frameOrLabel) - 1;
			}
			else if (frameOrLabel is int)
			{
				num = (int)frameOrLabel - 1;
			}
			if (num < 0 || num >= m_MovieClipInfo.frames.Count)
			{
				return false;
			}
			return frameScriptDispatcher.removeEventListener(num, callback);
		}

		public static MovieClipAssetInfo findMovieClipInSharedAssets(string symbolName)
		{
			foreach (KeyValuePair<string, SwfAssetContext> item in contextCache)
			{
				SwfAssetContext value = item.Value;
				MovieClipAssetInfo movieInfoByName = value.getMovieInfoByName(symbolName);
				if (movieInfoByName == null || movieInfoByName.shared)
				{
					continue;
				}
				return movieInfoByName;
			}
			return null;
		}

		public static BitmapFontAssetInfo findBitmapFontAssetInfoInSharedAssets(string symbolName)
		{
			foreach (KeyValuePair<string, SwfAssetContext> item in contextCache)
			{
				SwfAssetContext value = item.Value;
				BitmapFontAssetInfo assetInfoByName = value.getAssetInfoByName<BitmapFontAssetInfo>(symbolName);
				if (assetInfoByName != null && !assetInfoByName.shared)
				{
					return assetInfoByName;
				}
			}
			return null;
		}

		public static BitmapFontAssetInfo findBitmapFontAssetInfoInSharedAssetsByFontName(string fontName, float size, bool bold, bool italic, string filterHash)
		{
			if (fontName == null)
			{
				return null;
			}
			BitmapFontAssetInfo bitmapFontAssetInfo = null;
			float num = 0f;
			foreach (KeyValuePair<string, SwfAssetContext> item in contextCache)
			{
				SwfAssetContext value = item.Value;
				foreach (KeyValuePair<int, AssetBaseInfo> export in value.exports)
				{
					if (!(export.Value is BitmapFontAssetInfo))
					{
						continue;
					}
					BitmapFontAssetInfo bitmapFontAssetInfo2 = export.Value as BitmapFontAssetInfo;
					if (!bitmapFontAssetInfo2.shared && bitmapFontAssetInfo2.className != null && bitmapFontAssetInfo2.className.StartsWith(fontName))
					{
						float num2 = Math.Abs(bitmapFontAssetInfo2.size - size);
						if (bitmapFontAssetInfo == null || num2 < num)
						{
							bitmapFontAssetInfo = bitmapFontAssetInfo2;
							num = num2;
						}
					}
				}
			}
			return bitmapFontAssetInfo;
		}

		public static BitmapFontAssetInfo findBitmapFontAssetInfoInSharedAssetsByAttribute(string attrName, object equals)
		{
			if (attrName == null || equals == null)
			{
				return null;
			}
			foreach (KeyValuePair<string, SwfAssetContext> item in contextCache)
			{
				SwfAssetContext value = item.Value;
				foreach (KeyValuePair<int, AssetBaseInfo> export in value.exports)
				{
					if (export.Value is BitmapFontAssetInfo)
					{
						BitmapFontAssetInfo bitmapFontAssetInfo = export.Value as BitmapFontAssetInfo;
						if (attrName == "parentSymbolName" && equals is string && bitmapFontAssetInfo.parentSymbolName != null && bitmapFontAssetInfo.parentSymbolName.CompareTo(equals as string) == 0 && !bitmapFontAssetInfo.shared)
						{
							return bitmapFontAssetInfo;
						}
					}
				}
			}
			return null;
		}

		internal static List<BitmapFontAssetInfo> findBitmapFontAssetInfoListInSharedAssetsByFontName(string fontName)
		{
			List<BitmapFontAssetInfo> list = new List<BitmapFontAssetInfo>();
			foreach (KeyValuePair<string, SwfAssetContext> item in contextCache)
			{
				SwfAssetContext value = item.Value;
				foreach (KeyValuePair<int, AssetBaseInfo> export in value.exports)
				{
					if (export.Value is BitmapFontAssetInfo)
					{
						BitmapFontAssetInfo bitmapFontAssetInfo = export.Value as BitmapFontAssetInfo;
						if (bitmapFontAssetInfo.className.StartsWith(fontName) && !bitmapFontAssetInfo.shared)
						{
							list.Add(bitmapFontAssetInfo);
						}
					}
				}
			}
			return list;
		}

		public static bool preloadSWF(string swfUri)
		{
			if ((profilerSettings & MovieClipProfiler.SwfLoad) == MovieClipProfiler.SwfLoad)
			{
				Debug.Log("SwfProfile->SwfPreLoad: " + swfUri + ", " + profilerSettings);
			}
			return _preloadSWF(swfUri) != null;
		}

		public static bool preloadSWF(string swfUri, bool preloadTextures)
		{
			if ((profilerSettings & MovieClipProfiler.SwfLoad) == MovieClipProfiler.SwfLoad)
			{
				Debug.Log("SwfProfile->SwfPreLoad: " + swfUri + ", " + profilerSettings);
			}
			if (_preloadSWF(swfUri) == null)
			{
				return false;
			}
			return preloadSWFTextures(swfUri);
		}

		internal static SwfAssetContext _preloadSWF(string swfUri)
		{
			return rootResourceLoader.loadSWF(swfUri);
		}

		public static bool preloadSWFTextures(string swfUri)
		{
			SwfAssetContext swfAssetContext = _preloadSWF(swfUri);
			if (swfAssetContext == null)
			{
				return false;
			}
			if (swfAssetContext.exports == null)
			{
				Debug.LogWarning("assetContext.exports == null");
				return false;
			}
			if (swfAssetContext.resourceLoader == null)
			{
				Debug.LogWarning("assetContext.resourceLoader == null");
				return false;
			}
			foreach (KeyValuePair<int, AssetBaseInfo> export in swfAssetContext.exports)
			{
				if (export.Value is BitmapAssetInfo)
				{
					BitmapAssetInfo bmpInfo = (BitmapAssetInfo)export.Value;
					swfAssetContext.resourceLoader.getMaterial(null, swfAssetContext, null, bmpInfo);
				}
			}
			return true;
		}

		public static void clearContextCache()
		{
			contextCache = new Dictionary<string, SwfAssetContext>();
			if (Application.isPlaying && TextureManager.instance != null)
			{
				TextureManager.instance.clearTextureCache();
			}
		}

		public static bool unloadSwf(string swfUri)
		{
			if ((profilerSettings & MovieClipProfiler.SwfUnload) == MovieClipProfiler.SwfUnload)
			{
				Debug.Log("SwfProfile->SwfUnkoad: " + swfUri);
			}
			return rootResourceLoader.unloadSWF(swfUri);
		}

		public static SwfAssetContext getRuntimeContent(string name)
		{
			string key = "DYN::_" + name;
			if (contextCache.ContainsKey(key))
			{
				return contextCache[key];
			}
			SwfAssetContext swfAssetContext = new SwfAssetContext();
			swfAssetContext.textureManager = TextureManager.instance;
			contextCache[key] = swfAssetContext;
			return swfAssetContext;
		}

		public static Dictionary<string, SwfAssetContext> getGlobalContextCache()
		{
			return contextCache;
		}

		protected override void OnSetScale9Grid(Rect rect)
		{
			if (!enableScale9)
			{
				m_HasScale9 = false;
			}
			else
			{
				rebuildScale9Grid();
			}
		}

		protected void _clearScale9Cache()
		{
			if (m_CachedScale)
			{
				m_CachedTextField = null;
				m_CachedScale = false;
				graphics.clear();
			}
		}

		protected override void rebuildScale9Grid()
		{
			if (base.numChildren < 1)
			{
				return;
			}
			if (!m_CachedScale)
			{
				m_CachedScale9Bounds = getBounds(null).rect;
				m_CachedScale = true;
				m_CachedSliceSprite = getChildAt(0) as pumpkin.display.Sprite;
				m_CachedSliceSprite.visible = false;
				m_CachedTextField = getChildAt(1) as TextField;
				if (m_CachedTextField != null)
				{
					m_CachedTxtSrcPos.x = m_CachedTextField.x;
					m_CachedTxtSrcPos.y = m_CachedTextField.y;
					m_CachedTxtSrcSz.x = m_CachedTextField.srcWidth;
					m_CachedTxtSrcSz.y = m_CachedTextField.srcHeight;
				}
			}
			if (m_CachedSliceSprite == null || m_CachedSliceSprite.graphics.drawOPs.Count == 0)
			{
				return;
			}
			if (m_CachedTextField != null)
			{
				m_CachedTextField.width = m_CachedTxtSrcSz.x * base.scaleX;
				m_CachedTextField.height = m_CachedTxtSrcSz.y * base.scaleY;
				m_CachedTextField.scaleX = 1f / base.scaleX;
				m_CachedTextField.scaleY = 1f / base.scaleY;
			}
			m_CachedSliceSprite.visible = false;
			GraphicsDrawOP graphicsDrawOP = m_CachedSliceSprite.graphics.drawOPs[0];
			Material material = graphicsDrawOP.material;
			graphics.clear();
			bool flag = false;
			int num = 0;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					num++;
					Rect rectForTileId = getRectForTileId(m_CachedScale9Bounds, m_Scale9Rect, j, i, new Vector2(base.scaleX, base.scaleY));
					Rect srcRectForTileId = getSrcRectForTileId(graphicsDrawOP, base.scale9Grid, j, i);
					if (flag && j == 2 && i == 2)
					{
						break;
					}
					GraphicsDrawOP graphicsDrawOP2 = graphics.drawRectUV(material, srcRectForTileId, rectForTileId);
					if (flag)
					{
						if (i == 2)
						{
							graphicsDrawOP2.color.g = 0.5f;
						}
						if (j == 1 && i == 1)
						{
							graphicsDrawOP2.color.r = 0.5f;
						}
					}
				}
			}
		}

		private Vector2 getRectAxisForTileId(Rect bounds, Rect slice9, int x, float scale, bool isY)
		{
			float num = slice9.x;
			float num2 = slice9.width;
			float num3 = bounds.width;
			if (isY)
			{
				num = slice9.y;
				num2 = slice9.height;
				num3 = bounds.height;
			}
			float num4 = 0f;
			float num5 = 0f;
			switch (x)
			{
			case 0:
				num4 = 0f;
				num5 = num / scale;
				break;
			case 1:
				num4 = num / scale;
				num5 = num3 - num / scale * 2f;
				break;
			case 2:
			{
				num4 = num3 - num / scale * 1f;
				float num6 = num3 - (num + num2);
				num5 = num6 / scale;
				break;
			}
			}
			return new Vector2(num4, num5);
		}

		private Rect getRectForTileId(Rect bounds, Rect slice9, int x, int y, Vector2 scale)
		{
			Vector2 rectAxisForTileId = getRectAxisForTileId(bounds, slice9, x, scale.x, false);
			Vector2 rectAxisForTileId2 = getRectAxisForTileId(bounds, slice9, y, scale.y, true);
			return new Rect(rectAxisForTileId.x, rectAxisForTileId2.x, rectAxisForTileId.y, rectAxisForTileId2.y);
		}

		private Vector2 getSrcRectAxisForTileId(GraphicsDrawOP srcOp, Rect slice9, int x, bool isY)
		{
			float num = slice9.x;
			float num2 = slice9.width;
			float num3 = srcOp.drawWidth;
			float num4 = srcOp.drawSrcRect.width;
			float num5 = srcOp.drawSrcRect.x;
			if (isY)
			{
				num = slice9.y;
				num2 = slice9.height;
				num3 = srcOp.drawHeight;
				num4 = srcOp.drawSrcRect.height;
				num5 = srcOp.drawSrcRect.y;
			}
			float num6 = 0f;
			float num7 = 0f;
			switch (x)
			{
			case 0:
				num6 = num5;
				num7 = num / num3 * num4;
				break;
			case 1:
			{
				float num12 = num / num3 * num4;
				num6 = num5 + num12;
				num7 = num2 / num3 * num4;
				break;
			}
			case 2:
			{
				float num8 = num / num3 * num4;
				float num9 = num2 / num3 * num4;
				float num10 = num3 - (num + num2);
				float num11 = num10 / num3 * num4;
				num6 = num5 + num8 + num9;
				num7 = num11;
				break;
			}
			}
			return new Vector2(num6, num7);
		}

		private Rect getSrcRectForTileId(GraphicsDrawOP srcOp, Rect slice9, int x, int y)
		{
			Vector2 srcRectAxisForTileId = getSrcRectAxisForTileId(srcOp, slice9, x, false);
			Vector2 srcRectAxisForTileId2 = getSrcRectAxisForTileId(srcOp, slice9, y, true);
			return new Rect(srcRectAxisForTileId.x, srcRectAxisForTileId2.x, srcRectAxisForTileId.y, srcRectAxisForTileId2.y);
		}

		protected virtual MovieClip onInstanceChildMovieClip(DisplayObjectInfo dispInfo, int depthSlot)
		{
			if (g_MovieClipClassMap != null)
			{
				MovieClipAssetInfo movieInfoByCid = assetContext.getMovieInfoByCid(dispInfo.cid);
				if (!string.IsNullOrEmpty(movieInfoByCid.className) && g_MovieClipClassMap.ContainsKey(movieInfoByCid.className))
				{
					MovieClip movieClip = (MovieClip)Activator.CreateInstance(g_MovieClipClassMap[movieInfoByCid.className]);
					if (movieClip != null)
					{
						return movieClip;
					}
					Debug.LogWarning(string.Concat("Failed to instantate MovieClip class mapping of type '", g_MovieClipClassMap[movieInfoByCid.className], "'"));
				}
			}
			return new MovieClip();
		}

		protected virtual BitmapTextField onInstanceBitmapTextField(BitmapFontAssetInfo bmpAssetInfo, int depthSlot)
		{
			if (bmpAssetInfo.isTTF)
			{
				return new UnityTTFBitmapTextField();
			}
			if (enableAdvancedTextfield)
			{
				return new AdvancedBitmapTextField();
			}
			return new BitmapTextField();
		}

		public static void registerGlobalLinkage(Type type)
		{
			if (g_MovieClipClassMap == null)
			{
				g_MovieClipClassMap = new Dictionary<string, Type>();
			}
			g_MovieClipClassMap[type.Name] = type;
		}

		public static void registerGlobalLinkage(string customName, Type type)
		{
			if (g_MovieClipClassMap == null)
			{
				g_MovieClipClassMap = new Dictionary<string, Type>();
			}
			g_MovieClipClassMap[customName] = type;
		}
	}
}
