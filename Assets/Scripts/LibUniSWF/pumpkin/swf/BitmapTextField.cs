using System;
using System.Collections.Generic;
using UnityEngine;
using pumpkin.display;
using pumpkin.displayInternal;
using pumpkin.geom;
using pumpkin.text;
using pumpkin.tweener;

namespace pumpkin.swf
{
	public class BitmapTextField : TextField
	{
		internal struct BitmapTextGroup
		{
			public int startChar;

			public int endChar;

			public Color color;

			public TextFormat textFormat;
		}

		protected SwfAssetContext assetContext;

		protected BitmapFontAssetInfo m_FontInfo;

		public static bool enableMissingCharacterWarning = false;

		public static int globalPixelSnapping = 1;

		public static int globalPixelSnapMinSize = 16;

		public static bool enableAssetInfoFallback = true;

		protected float spaceWidth;

		protected float lineH;

		protected float maxHeightBleed;

		protected float yPos = 0f;

		protected List<GraphicsDrawOP> lineDrawOps;

		protected List<float> lineYPositions;

		protected float maxW;

		protected float maxH;

		protected bool useDefaultTxt = true;

		protected pumpkin.display.Sprite m_DefaultCursor;

		protected int m_TotalLines;

		protected pumpkin.display.Sprite m_TextContainer;

		protected Color m_CursorColor;

		protected float minCharY;

		protected float maxCharY;

		protected float firstCharWidth;

		protected bool isFirstCharInLine;

		protected bool m_LineInScrollV = true;

		protected bool m_LineInScrollMaxV = true;

		protected bool m_DebugChars = true;

		public int pixelSnapping = globalPixelSnapping;

		internal FastList<BitmapTextGroup> m_GroupFormatting;

		protected string m_EscapeColCode = null;

		protected bool m_InEscapeColorCode = false;

		protected bool m_EnableEscapeColorCodes = true;

		public BitmapTextField()
		{
			m_TextContainer = new pumpkin.display.Sprite();
			addChild(m_TextContainer);
		}

		public BitmapTextField(TextFormat format)
		{
			initWithTextFormat(format);
		}

		protected virtual void onCreateCursor()
		{
			if (m_DefaultCursor == null)
			{
				m_DefaultCursor = new pumpkin.display.Sprite();
				addChild(m_DefaultCursor);
				base.cursor = m_DefaultCursor;
				onCursorComplete1();
			}
		}

		protected virtual void onDestoryCursor()
		{
			base.cursor = null;
			m_DefaultCursor = null;
		}

		protected void onCursorComplete1()
		{
			if (m_Cursor != null)
			{
				Tweener.addTween(m_Cursor, Tweener.Hash("alpha", 1, "time", 1, "transition", "easeInCubic")).OnComplete(onCursorComplete2);
			}
		}

		protected void onCursorComplete2()
		{
			if (m_Cursor != null)
			{
				Tweener.addTween(m_Cursor, Tweener.Hash("alpha", 0, "time", 1, "transition", "easeInCubic")).OnComplete(onCursorComplete1);
			}
		}

		protected virtual void initWithTextFormat(TextFormat format)
		{
			if (format == null)
			{
				return;
			}
			m_Format = format;
			m_Format.isBitmap = true;
			BitmapFontAssetInfo bitmapFontAssetInfo = null;
			if (format.fontClassName != null && format.fontClassName.Length > 0)
			{
				bitmapFontAssetInfo = MovieClipPlayer.findBitmapFontAssetInfoInSharedAssets(format.fontClassName);
			}
			if (format.exportedStyleName != null && format.exportedStyleName.Length > 0)
			{
				bitmapFontAssetInfo = MovieClipPlayer.findBitmapFontAssetInfoInSharedAssetsByAttribute("parentSymbolName", format.exportedStyleName);
			}
			if (bitmapFontAssetInfo == null)
			{
				bitmapFontAssetInfo = MovieClipPlayer.findBitmapFontAssetInfoInSharedAssetsByFontName(format.font, format.size, format.bold, format.italic, format.filtersHash);
			}
			if (bitmapFontAssetInfo == null)
			{
				Debug.LogWarning("BitmapTextField(TextFormat) '" + name + "' failed to find font '" + format.font + "', class name '" + format.fontClassName + "', Was the font preloaded with MovieClip.preloadSWF() ?");
			}
			else
			{
				if (bitmapFontAssetInfo == m_FontInfo || m_Format.leading < 1f)
				{
				}
				setAssetInfo(bitmapFontAssetInfo.assetContext, bitmapFontAssetInfo, format);
				if (m_Format.leading > 0f)
				{
					lineH = m_Format.leading;
				}
			}
		}

		protected override void onTextFormatUpdated()
		{
			if (m_Format == null)
			{
				return;
			}
			float leading = m_Format.leading;
			initWithTextFormat(m_Format);
			if (m_FontInfo != null)
			{
				if (leading != 0f)
				{
					lineH = leading;
				}
				if (m_Format.color != Color.white && m_FontInfo.color != Color.white && (TextField.profilerSettings & MovieClipProfiler.TextExportWarn) == MovieClipProfiler.TextExportWarn)
				{
					Debug.LogWarning("BitmapTextField(TextFormat) '" + name + "' using color transforms on non-white font '" + m_FontInfo.name + "'");
				}
				if (hasFilters)
				{
					m_Format.color = Color.white;
					m_CursorColor = m_FontInfo.color;
				}
				else
				{
					m_CursorColor = m_Format.color;
				}
				changeByUser = true;
			}
		}

		public override void setAssetInfo(SwfAssetContext assetContext, BitmapFontAssetInfo fontInfo, DisplayObjectInfo dispInfo)
		{
			m_Format = new TextFormat(fontInfo);
			if (dispInfo != null && dispInfo.textInfo != null)
			{
				m_Format.align = dispInfo.textInfo.align;
			}
			setAssetInfo(assetContext, fontInfo, m_Format);
			if (m_FontInfo != null)
			{
				hasFilters = m_FontInfo.hasFilters != 0;
				if (hasFilters)
				{
					m_Format.color = Color.white;
					m_CursorColor = m_FontInfo.color;
				}
				else if (dispInfo.textInfo != null)
				{
					m_CursorColor = dispInfo.textInfo.color;
				}
			}
		}

		protected virtual void setAssetInfo(SwfAssetContext assetContext, BitmapFontAssetInfo fontInfoIn, TextFormat format)
		{
			if (fontInfoIn == null)
			{
				return;
			}
			if (fontInfoIn.shared)
			{
				m_FontInfo = MovieClipPlayer.findBitmapFontAssetInfoInSharedAssets(fontInfoIn.className);
				if (m_FontInfo == null)
				{
					if (!enableAssetInfoFallback)
					{
						Debug.LogWarning("BitmapTextField() '" + name + "' failed to find shared font '" + fontInfoIn.className + "', forget to MovieClip.preloadSWF() ?");
						return;
					}
					m_FontInfo = MovieClipPlayer.findBitmapFontAssetInfoInSharedAssetsByFontName(format.font, format.size, format.bold, format.italic, format.filtersHash);
					if (m_FontInfo == null)
					{
						Debug.LogWarning("BitmapTextField() '" + name + "' failed to find shared font '" + format.font + "', className '" + fontInfoIn.className + "' forget to MovieClip.preloadSWF() ?");
						return;
					}
				}
				this.assetContext = m_FontInfo.assetContext;
				TextFormat textFormat = new TextFormat(m_FontInfo);
				textFormat.align = format.align;
				m_Format = textFormat;
			}
			else
			{
				this.assetContext = assetContext;
				m_FontInfo = fontInfoIn;
			}
			m_Align = fontInfoIn.align;
			if (useDefaultTxt)
			{
				useDefaultTxt = false;
				base.text = fontInfoIn.text;
			}
			spaceWidth = 1f;
			if (m_FontInfo.spaceWidth <= 0f)
			{
				BitmapFontCharInfo bitmapFontCharInfo = null;
				if (m_FontInfo.characters.ContainsKey(' '))
				{
					bitmapFontCharInfo = m_FontInfo.characters[' '];
				}
				else
				{
					Debug.LogWarning("BitmapTextField() class '" + m_FontInfo.className + "' Doesnt have space character");
				}
				if (bitmapFontCharInfo != null)
				{
					BitmapAssetInfo bitmapAssetInfo = ((bitmapFontCharInfo.cid < 0) ? null : assetContext.getBitmapInfoByCid(bitmapFontCharInfo.cid));
					if (bitmapAssetInfo != null)
					{
						if (bitmapFontCharInfo.charWidth != 0f)
						{
							spaceWidth = bitmapFontCharInfo.charWidth;
						}
						else
						{
							spaceWidth = bitmapAssetInfo.srcRect.width;
						}
					}
					else if (bitmapFontCharInfo.charWidth != 0f)
					{
						spaceWidth = bitmapFontCharInfo.charWidth;
					}
				}
				m_FontInfo.spaceWidth = spaceWidth;
			}
			else
			{
				spaceWidth = m_FontInfo.spaceWidth;
			}
			if (m_Format.size > 0f)
			{
				lineH = m_Format.size + 2f;
			}
			else
			{
				lineH = m_FontInfo.size + 2f;
			}
			maxHeightBleed = lineH / 2f;
			m_Format.leading = lineH;
			m_Format.fontClassName = fontInfoIn.className;
			if ((assetContext != null && assetContext.version >= MovieClipReader.FORMAT_VERSION_5) || assetContext.version == 0)
			{
				if (m_FontInfo.cursorMinY == m_FontInfo.cursorMaxY)
				{
					minCharY = lineH;
					maxCharY = 0f;
					float num = 0f;
					float num2 = 0f;
					int num3 = 0;
					foreach (KeyValuePair<char, BitmapFontCharInfo> character in m_FontInfo.characters)
					{
						BitmapFontCharInfo value = character.Value;
						if (!_cacheCharBitmap(value) || value.bmpInfo == null)
						{
							continue;
						}
						float pixelSize = m_FontInfo.pixelSize;
						float num4 = (value.topLine + value.charStartY) * pixelSize;
						float num5 = (value.topLine + value.charStartY + value.charHeight) * pixelSize;
						if (num4 < minCharY)
						{
							minCharY = num4;
							if (minCharY < 0f)
							{
								minCharY = 0f;
							}
						}
						if (num5 > maxCharY)
						{
							maxCharY = num5;
						}
						num += minCharY;
						num2 += maxCharY;
						num3++;
					}
					minCharY = num / (float)num3;
					maxCharY = num2 / (float)num3;
					m_FontInfo.cursorMinY = minCharY;
					m_FontInfo.cursorMaxY = maxCharY;
				}
				else
				{
					minCharY = m_FontInfo.cursorMinY;
					maxCharY = m_FontInfo.cursorMaxY;
				}
			}
			else
			{
				minCharY = 0f;
				maxCharY = lineH;
			}
			if (m_Format.letterSpacing <= 0f)
			{
				m_Format.letterSpacing = fontInfoIn.letterSpacing;
			}
			if (globalPixelSnapMinSize > 0 && m_FontInfo.size <= (float)globalPixelSnapMinSize)
			{
				pixelSnapping = 1;
			}
		}

		protected override void renderText()
		{
			graphics.clear();
			if (base.type == TextFieldType.INPUT)
			{
				graphics.drawSolidRectangle(new Color(0f, 0f, 0f, 0f), 0f, 0f, srcWidth, srcHeight);
			}
			if (base.multiline)
			{
				lineYPositions = new List<float>();
				m_NumLines = 0;
			}
			else
			{
				m_NumLines = 1;
			}
			if (m_Cursor != null)
			{
				m_Cursor.visible = false;
			}
			maxW = ((!m_CustomSize) ? srcWidth : m_Size.x);
			maxH = ((!m_CustomSize) ? srcHeight : m_Size.y);
			if (maxW < 1f || maxH < 1f)
			{
				m_TextContainer.graphics.clear();
			}
			else if (m_Format.fitSize)
			{
				_renderText(m_FontInfo, false);
				float num = calcBoundsScaleFactor();
				BitmapFontAssetInfo bitmapFontAssetInfo = MovieClipPlayer.findBitmapFontAssetInfoInSharedAssetsByFontName(m_Format.font, m_Format.size * num, m_Format.bold, m_Format.italic, m_Format.filtersHash);
				if (bitmapFontAssetInfo != m_FontInfo)
				{
					_renderText(bitmapFontAssetInfo, false);
					num = calcBoundsScaleFactor();
				}
				if (num < 1f && m_Format.align == TextFieldAlign.CENTER)
				{
					m_Format.align = TextFieldAlign.LEFT;
					_renderText(bitmapFontAssetInfo, false);
					m_Format.align = TextFieldAlign.CENTER;
				}
				base.scaleX = num;
				base.scaleY = num;
			}
			else
			{
				_renderText(m_FontInfo, true);
			}
		}

		protected virtual float calcBoundsScaleFactor()
		{
			Rectangle bounds = m_TextContainer.graphics.getBounds();
			float result = 1f;
			if (bounds.width > maxW && bounds.height > maxH)
			{
				result = ((!(bounds.width < bounds.height)) ? (bounds.height / bounds.width) : (bounds.width / bounds.height));
			}
			else if (bounds.width > maxW && bounds.height <= maxH)
			{
				result = maxW / bounds.width;
			}
			else if (bounds.height > maxH && bounds.width <= maxW)
			{
				result = maxH / bounds.height;
			}
			return result;
		}

		protected virtual void _renderText(BitmapFontAssetInfo fontInfo, bool enableWrap)
		{
			m_TextContainer.graphics.clear();
			isFirstCharInLine = true;
			if (fontInfo == null)
			{
				return;
			}
			bool flag = m_Format.wordWrap;
			yPos = 0f;
			if (flag)
			{
				m_Format.charClip = true;
			}
			if (!base.multiline)
			{
				flag = false;
			}
			if (base.multiline)
			{
				m_LineInScrollV = m_ScrollV == 0;
			}
			m_LineInScrollMaxV = true;
			float num = 0f;
			_initLineDropOPList();
			for (int i = 0; i < m_Text.Length; i++)
			{
				if (yPos + lineH > maxH + maxHeightBleed && enableWrap && m_Format.charClip)
				{
					m_LineInScrollMaxV = false;
					m_LineInScrollV = false;
				}
				char c = m_Text[i];
				if (!base.multiline && c == '\n')
				{
					c = ' ';
				}
				switch (c)
				{
				case ' ':
					num += spaceWidth;
					continue;
				case '\n':
					if (base.multiline)
					{
						num = _nextLine(num);
						continue;
					}
					goto default;
				default:
					if (c == '\t')
					{
						num += spaceWidth * 4f;
						continue;
					}
					if (!flag && m_Format.charClip)
					{
						float num2 = _renderChar(num, c, i, false);
						if (num2 < maxW)
						{
							num = _renderChar(num, c, i, true);
						}
						continue;
					}
					if (m_Format.charClip)
					{
						bool flag2 = true;
						float num3 = 0f;
						for (int j = i; j < m_Text.Length; j++)
						{
							char c2 = m_Text[j];
							if (!base.multiline && c2 == '\n')
							{
								c2 = ' ';
							}
							if (c2 == ' ' || c2 == '\n' || c2 == '\n')
							{
								break;
							}
							float num4 = _renderChar(num, c2, i, false);
							num3 += num4 - num;
						}
						if (num3 > maxW)
						{
							for (int k = i; k < m_Text.Length; k++)
							{
								char c3 = m_Text[k];
								if (!base.multiline && c3 == '\n')
								{
									c3 = ' ';
								}
								if (c3 == ' ' || c3 == '\n' || c3 == '\n')
								{
									num += spaceWidth;
									if (c3 == '\n')
									{
										num = _nextLine(num);
									}
									break;
								}
								float num5 = _renderChar(num, c3, i, false);
								num = ((!(num5 > maxW)) ? _renderChar(num, c3, i, true) : num5);
								i++;
							}
							flag2 = false;
						}
						else if (num + num3 > maxW && maxW > 0f)
						{
							num = _nextLine(num);
						}
						if (!flag2)
						{
							continue;
						}
						if (yPos + lineH > maxH + maxHeightBleed && enableWrap && m_Format.charClip)
						{
							break;
						}
						for (int l = i; l < m_Text.Length; l++)
						{
							char c4 = m_Text[l];
							if (!base.multiline && c4 == '\n')
							{
								c4 = ' ';
							}
							if (c4 == ' ' || c4 == '\n' || c4 == '\n')
							{
								num += spaceWidth;
								if (c4 == '\n')
								{
									num = _nextLine(num);
								}
								break;
							}
							num = _renderChar(num, c4, i, true);
							i++;
						}
						continue;
					}
					num = _renderChar(num, c, i, true);
					continue;
				}
				break;
			}
			if (base.type == TextFieldType.INPUT)
			{
				if (m_Cursor != null)
				{
					m_Cursor.visible = m_HasKeybaordFocus;
					m_Cursor.x = num;
					m_Cursor.y = yPos;
					if (m_DefaultCursor != null)
					{
						m_DefaultCursor.graphics.clear();
						m_DefaultCursor.graphics.drawSolidRectangle(Color.white, 0f, minCharY, 2f, maxCharY - minCharY);
						m_DefaultCursor.colorTransform = m_CursorColor;
					}
					if ((yPos + lineH > maxH + maxHeightBleed && enableWrap && m_Format.charClip) || num > maxW)
					{
						m_Cursor.visible = false;
					}
					if (m_Format.align == TextFieldAlign.CENTER)
					{
						if (m_Text.Length == 0 || lineDrawOps.Count == 0)
						{
							m_Cursor.x += maxW / 2f;
						}
					}
					else if (m_Format.align == TextFieldAlign.RIGHT && (m_Text.Length == 0 || lineDrawOps.Count == 0))
					{
						m_Cursor.x += maxW;
					}
				}
			}
			else if (m_Cursor != null)
			{
				m_Cursor.visible = false;
			}
			if (lineDrawOps != null && lineDrawOps.Count > 0)
			{
				num = _nextLine(num);
			}
		}

		protected virtual float _nextLine(float lastX)
		{
			isFirstCharInLine = true;
			if (base.multiline)
			{
				lineYPositions.Add(yPos);
				lastX = 0f;
				m_NumLines++;
				bool lineInScrollV = m_LineInScrollV;
				if (m_NumLines >= m_ScrollV)
				{
					if (m_LineInScrollMaxV)
					{
						m_LineInScrollV = true;
					}
				}
				else
				{
					m_LineInScrollV = false;
				}
				if (m_LineInScrollV && lineInScrollV)
				{
					yPos += lineH;
				}
			}
			float num = 0f;
			for (int i = 0; i < lineDrawOps.Count; i++)
			{
				float num2 = lineDrawOps[i].x + lineDrawOps[i].drawWidth;
				if (num2 > num)
				{
					num = num2;
				}
			}
			if (m_Format.align == TextFieldAlign.CENTER)
			{
				float num3 = (maxW - num) / 2f;
				if (pixelSnapping == 1)
				{
					num3 = Mathf.Round(num3);
				}
				if (num3 != 0f)
				{
					for (int j = 0; j < lineDrawOps.Count; j++)
					{
						lineDrawOps[j].x += num3;
					}
				}
				if (m_Cursor != null && m_Cursor.visible)
				{
					m_Cursor.x += num3;
					m_Cursor.visible = m_Cursor.visible && m_Cursor.x < maxW;
				}
				_initLineDropOPList();
				m_TextContainer.graphics.cacheBounds();
			}
			else if (m_Format.align == TextFieldAlign.RIGHT)
			{
				float num4 = maxW - num;
				if (num4 != 0f)
				{
					if (pixelSnapping == 1)
					{
						num4 = Mathf.Round(num4);
					}
					for (int k = 0; k < lineDrawOps.Count; k++)
					{
						lineDrawOps[k].x += num4;
					}
				}
				if (m_Cursor != null && m_Cursor.visible)
				{
					m_Cursor.x += num4 - m_Cursor.width;
					m_Cursor.visible = m_Cursor.visible && m_Cursor.x < maxW;
				}
				_initLineDropOPList();
				m_TextContainer.graphics.cacheBounds();
			}
			return lastX;
		}

		protected virtual void _initLineDropOPList()
		{
			lineDrawOps = new List<GraphicsDrawOP>();
		}

		protected virtual bool _cacheCharBitmap(BitmapFontCharInfo charInfo)
		{
			if (charInfo.cid < 0)
			{
				return true;
			}
			if (charInfo.bmpInfo == null)
			{
				BitmapAssetInfo bitmapAssetInfo = ((charInfo.cid < 0) ? null : assetContext.getBitmapInfoByCid(charInfo.cid));
				if (bitmapAssetInfo == null)
				{
					return false;
				}
				if (bitmapAssetInfo.bitmapData == null)
				{
					bitmapAssetInfo.bitmapData = assetContext.resourceLoader.getCharMaterial(this, assetContext, m_FontInfo, charInfo, bitmapAssetInfo);
					if (bitmapAssetInfo.bitmapData == null)
					{
						return false;
					}
				}
				charInfo.bmpInfo = bitmapAssetInfo;
				Vector2 vector = TextureManager.MaterialPixelSpaceToUVSpace(bitmapAssetInfo.bitmapData, new Vector2(bitmapAssetInfo.srcRect.x, bitmapAssetInfo.srcRect.y));
				Vector2 vector2 = TextureManager.MaterialPixelSpaceToUVSpace(bitmapAssetInfo.bitmapData, new Vector2(bitmapAssetInfo.srcRect.width, bitmapAssetInfo.srcRect.height));
				charInfo.uvRect = new Rect(vector.x, vector.y, vector2.x, vector2.y);
			}
			return true;
		}

		protected virtual float _renderChar(float lastX, char c, int charId, bool draw)
		{
			if (!m_LineInScrollV)
			{
				draw = false;
			}
			if (m_Format.charClip && lastX > maxW)
			{
				draw = false;
			}
			float pixelSize = m_FontInfo.pixelSize;
			float num = 0f - firstCharWidth;
			if (m_DisplayAsPassword)
			{
				c = TextField.PASSWORD_CHAR;
			}
			BitmapFontCharInfo bitmapFontCharInfo = null;
			if (m_FontInfo.characters.ContainsKey(c))
			{
				bitmapFontCharInfo = m_FontInfo.characters[c];
			}
			if (bitmapFontCharInfo == null)
			{
				lastX += m_FontInfo.spaceWidth;
				if (c > '\r' && c != ' ')
				{
					if (enableMissingCharacterWarning)
					{
						Debug.LogWarning("Missing embeded character '" + c + "' ( 0x" + string.Format("{0:x}", (int)c) + ") in font '" + m_FontInfo.className + "'");
					}
					if (m_FontInfo.characters.ContainsKey('?'))
					{
						bitmapFontCharInfo = m_FontInfo.characters['?'];
					}
				}
				return lastX;
			}
			if (!_cacheCharBitmap(bitmapFontCharInfo) || bitmapFontCharInfo.bmpInfo == null)
			{
				BitmapAssetInfo bitmapAssetInfo = ((bitmapFontCharInfo.cid < 0) ? null : assetContext.getBitmapInfoByCid(bitmapFontCharInfo.cid));
				if (bitmapAssetInfo == null)
				{
					lastX += m_FontInfo.spaceWidth;
					return lastX;
				}
			}
			if (bitmapFontCharInfo.bmpInfo == null)
			{
				return lastX;
			}
			if (isFirstCharInLine)
			{
				firstCharWidth = bitmapFontCharInfo.charStartX;
				isFirstCharInLine = false;
			}
			Rect uvRect = bitmapFontCharInfo.uvRect;
			Material bitmapData = bitmapFontCharInfo.bmpInfo.bitmapData;
			float num2 = lastX;
			if (assetContext.version >= MovieClipReader.FORMAT_VERSION_6)
			{
				num2 += bitmapFontCharInfo.minX;
			}
			if (charId > 0)
			{
				num2 += bitmapFontCharInfo.getKerning(m_Text[charId - 1]);
			}
			float num3 = bitmapFontCharInfo.topLine * pixelSize + yPos;
			if (draw)
			{
				GraphicsDrawOP graphicsDrawOP = m_TextContainer.graphics.drawRectUV(bitmapData, uvRect, num2 + num, num3, bitmapFontCharInfo.bmpInfo.srcRect.width * pixelSize, bitmapFontCharInfo.bmpInfo.srcRect.height * pixelSize);
				graphicsDrawOP.userData = c;
				if (m_GroupFormatting != null)
				{
					bool flag = false;
					for (int i = 0; i < m_GroupFormatting.Size; i++)
					{
						if (charId >= m_GroupFormatting[i].startChar && charId <= m_GroupFormatting[i].endChar)
						{
							graphicsDrawOP.color = m_GroupFormatting[i].color;
							flag = true;
						}
					}
					if (!flag)
					{
						graphicsDrawOP.color = m_Format.color;
					}
				}
				else
				{
					graphicsDrawOP.color = m_Format.color;
				}
				graphicsDrawOP.pixelSnapping = pixelSnapping;
				if (graphicsDrawOP != null && lineDrawOps != null)
				{
					lineDrawOps.Add(graphicsDrawOP);
				}
			}
			if (pixelSnapping == 1)
			{
				lastX = ((bitmapFontCharInfo.charWidth == 0f) ? (lastX + Mathf.Round(bitmapFontCharInfo.bmpInfo.srcRect.width * pixelSize)) : (lastX + Mathf.Round(bitmapFontCharInfo.charWidth * pixelSize)));
				lastX += Mathf.Round(m_Format.letterSpacing);
			}
			else
			{
				lastX = ((bitmapFontCharInfo.charWidth == 0f) ? (lastX + bitmapFontCharInfo.bmpInfo.srcRect.width * pixelSize) : (lastX + bitmapFontCharInfo.charWidth * pixelSize));
				lastX += m_Format.letterSpacing;
			}
			return lastX;
		}

		public override TextField clone()
		{
			BitmapTextField bitmapTextField = new BitmapTextField();
			bitmapTextField.mouseEnabled = mouseEnabled;
			bitmapTextField.srcWidth = srcWidth;
			bitmapTextField.srcHeight = srcHeight;
			bitmapTextField.textFormat = base.textFormat.clone();
			bitmapTextField.setAssetInfo(assetContext, m_FontInfo, bitmapTextField.textFormat);
			bitmapTextField.text = base.text;
			return bitmapTextField;
		}

		internal override void _onSizeChange()
		{
			renderText();
		}

		protected override void _KeyboardFocusChange()
		{
			if (m_Cursor != null)
			{
				m_Cursor.visible = m_HasKeybaordFocus;
			}
		}

		protected override int _onSetTextFieldType(int newType)
		{
			m_Type = newType;
			if (m_Type == TextFieldType.INPUT)
			{
				onCreateCursor();
			}
			else
			{
				onDestoryCursor();
			}
			renderText();
			return newType;
		}

		protected override void _textChanged()
		{
			for (int i = 0; i < m_Text.Length; i++)
			{
				if (m_Text[i] == '\n')
				{
					m_TotalLines++;
				}
			}
			m_TotalLines++;
			m_MaxScrollV = m_TotalLines;
			m_MaxScrollH = m_Text.Length;
			m_GroupFormatting = null;
		}

		protected override void _cursorChanged(DisplayObject cursor)
		{
			if (m_Cursor != null && m_Cursor == m_DefaultCursor)
			{
				Tweener.removeTweens(m_Cursor);
			}
			if (m_Cursor != null)
			{
				if (m_Cursor.parent != null)
				{
					m_Cursor.parent.removeChild(m_Cursor);
				}
				m_Cursor = null;
			}
			m_Cursor = cursor;
			if (m_Cursor != null)
			{
				addChild(m_Cursor);
				m_Cursor.visible = false;
			}
			renderText();
		}

		protected override GlyphInfo _getGlyph(char c)
		{
			if (!m_FontInfo.characters.ContainsKey(c))
			{
				return null;
			}
			return m_FontInfo.characters[c];
		}

		protected override GlyphInfo _createGlyph(char c)
		{
			BitmapFontCharInfo bitmapFontCharInfo = new BitmapFontCharInfo();
			m_FontInfo.characters[c] = bitmapFontCharInfo;
			return bitmapFontCharInfo;
		}

		protected virtual void _setGlyph(char c, GlyphInfo glyph)
		{
			if (glyph is BitmapFontCharInfo)
			{
				m_FontInfo.characters[c] = (BitmapFontCharInfo)glyph;
			}
			else
			{
				Debug.LogWarning("_setGlyph failed because the paramater is not an implementation type.");
			}
		}

		protected override int _calcMaxScrollV()
		{
			renderText();
			float num = (float)m_NumLines - maxH / lineH;
			num = (float)Math.Ceiling(num);
			m_MaxScrollV = (int)num;
			return m_MaxScrollV;
		}

		public static BitmapFontAssetInfo createBitmapFont(string fontName)
		{
			return createBitmapFont(fontName, MovieClipPlayer.getRuntimeContent("BitmapTextField"));
		}

		public static BitmapFontAssetInfo createBitmapFont(string fontName, SwfAssetContext context)
		{
			BitmapFontAssetInfo bitmapFontAssetInfo = new BitmapFontAssetInfo();
			bitmapFontAssetInfo.className = fontName;
			bitmapFontAssetInfo.assetContext = context;
			context.exports[context.genUniqueCid()] = bitmapFontAssetInfo;
			return bitmapFontAssetInfo;
		}

		public virtual void clearCharColors()
		{
			m_GroupFormatting = null;
		}

		public virtual void addCharColor(int startChar, int endChar, Color color)
		{
			BitmapTextGroup item = default(BitmapTextGroup);
			item.startChar = startChar;
			item.endChar = endChar;
			item.color = color;
			item.textFormat = null;
			if (m_GroupFormatting == null)
			{
				m_GroupFormatting = new FastList<BitmapTextGroup>();
			}
			m_GroupFormatting.Add(item);
			renderText();
		}

		public override void appendText(string txt)
		{
			FastList<BitmapTextGroup> groupFormatting = m_GroupFormatting;
			m_Text += txt;
			_clipMaxChars();
			_textChanged();
			renderText();
			m_GroupFormatting = groupFormatting;
			renderText();
		}

		protected override void _removeLastChar()
		{
			if (m_GroupFormatting != null)
			{
				bool flag = true;
				int num = m_Text.Length - 1;
				while (flag)
				{
					flag = false;
					for (int i = 0; i < m_GroupFormatting.Size; i++)
					{
						BitmapTextGroup value = m_GroupFormatting[i];
						if (num >= m_GroupFormatting[i].startChar && num <= m_GroupFormatting[i].endChar)
						{
							if (num == m_GroupFormatting[i].startChar)
							{
								m_GroupFormatting.RemoveAt(i);
							}
							else
							{
								value.endChar = num - 1;
								m_GroupFormatting[i] = value;
							}
							flag = true;
							break;
						}
					}
				}
			}
			base._removeLastChar();
		}

		public virtual pumpkin.display.Sprite getTextContainer()
		{
			return m_TextContainer;
		}
	}
}
