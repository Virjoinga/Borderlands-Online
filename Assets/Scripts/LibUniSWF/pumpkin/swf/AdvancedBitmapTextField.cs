using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using pumpkin.display;

namespace pumpkin.swf
{
	public class AdvancedBitmapTextField : BitmapTextField
	{
		private List<TextGroup> m_TextGroups = new List<TextGroup>();

		private Dictionary<int, TextGroup> m_SyncDisplayObjects;

		private string newText = "";

		private TextGroup m_LastTextGroup;

		protected override void _textChanged()
		{
			newText = "";
			if (m_Text.Length < 1)
			{
				return;
			}
			m_Text = "<root>" + m_Text + "</root>";
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(new StringReader(m_Text));
			XmlNode firstChild = xmlDocument.FirstChild;
			TextGroup parentTextGroup = new TextGroup();
			foreach (XmlNode item in firstChild)
			{
				processTextXmlNode(item, parentTextGroup);
			}
			m_Text = newText;
		}

		internal void processTextXmlNode(XmlNode parent, TextGroup parentTextGroup)
		{
			TextGroup textGroup = (m_LastTextGroup = parentTextGroup.clone());
			if (parent.Name == "font")
			{
				if (parent.Attributes["color"] != null)
				{
					string text = parent.Attributes["color"].InnerText;
					if (text.Length > 0 && text[0] == '#')
					{
						text = text.Substring(1);
					}
					int num = Convert.ToInt32(text, 16);
					Color color = new Color((num & 0xFF0000) >> 16, (num & 0xFF00) >> 8, num & 0xFF);
					color.r /= 255f;
					color.g /= 255f;
					color.b /= 255f;
					textGroup.color = color;
				}
			}
			else if (parent.Name == "movieClip")
			{
				if (parent.Attributes["src"] != null)
				{
					textGroup.movieClipUri = parent.Attributes["src"].InnerText;
				}
				if (parent.Attributes["width"] != null)
				{
					textGroup.width = Convert.ToInt32(parent.Attributes["src"].InnerText, 10);
				}
			}
			string value = parent.Value;
			if (value != null && value.Length > 0)
			{
				newText += value;
				for (int i = 0; i < value.Length; i++)
				{
					m_TextGroups.Add(textGroup);
					if (textGroup.movieClipUri != null)
					{
						textGroup = textGroup.clone();
						textGroup.drawMovieClip = false;
					}
				}
			}
			foreach (XmlNode item in parent)
			{
				processTextXmlNode(item, textGroup);
			}
		}

		protected override float _renderChar(float lastX, char c, int charId, bool draw)
		{
			if (!m_LineInScrollV)
			{
				draw = false;
			}
			TextGroup textGroup = m_TextGroups[charId];
			if (m_Format.charClip && lastX > maxW)
			{
				draw = false;
			}
			if (textGroup.movieClipUri != null)
			{
				if (!textGroup.drawMovieClip)
				{
					return lastX;
				}
				MovieClip movieClip = (MovieClip)(textGroup.clipCache = new MovieClip(textGroup.movieClipUri));
				m_TextContainer.addChild(movieClip);
				m_SyncDisplayObjects[lineDrawOps.Count - 1] = textGroup;
				Debug.Log(textGroup.movieClipUri);
				lastX += movieClip.width;
				return lastX;
			}
			float pixelSize = m_FontInfo.pixelSize;
			float num = 0f - firstCharWidth;
			BitmapFontCharInfo bitmapFontCharInfo = null;
			if (m_FontInfo.characters.ContainsKey(c))
			{
				bitmapFontCharInfo = m_FontInfo.characters[c];
			}
			if (bitmapFontCharInfo == null)
			{
				lastX += m_FontInfo.spaceWidth;
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
			if (isFirstCharInLine)
			{
				firstCharWidth = bitmapFontCharInfo.charStartX;
				isFirstCharInLine = false;
			}
			Rect uvRect = bitmapFontCharInfo.uvRect;
			Material bitmapData = bitmapFontCharInfo.bmpInfo.bitmapData;
			float num2 = lastX * pixelSize;
			float num3 = bitmapFontCharInfo.topLine * pixelSize + yPos;
			if (draw)
			{
				GraphicsDrawOP graphicsDrawOP = m_TextContainer.graphics.drawRectUV(bitmapData, uvRect, num2 + num, num3, bitmapFontCharInfo.bmpInfo.srcRect.width * pixelSize, bitmapFontCharInfo.bmpInfo.srcRect.height * pixelSize);
				graphicsDrawOP.color = textGroup.color;
				if (graphicsDrawOP != null && lineDrawOps != null)
				{
					lineDrawOps.Add(graphicsDrawOP);
				}
			}
			lastX = ((bitmapFontCharInfo.charWidth == 0f) ? (lastX + bitmapFontCharInfo.bmpInfo.srcRect.width) : (lastX + bitmapFontCharInfo.charWidth));
			lastX += m_Format.letterSpacing;
			return lastX;
		}

		protected override float _nextLine(float lastX)
		{
			float result = base._nextLine(lastX);
			_syncClips();
			return result;
		}

		protected override void _initLineDropOPList()
		{
			_syncClips();
			base._initLineDropOPList();
			_syncClips();
			m_SyncDisplayObjects = new Dictionary<int, TextGroup>();
		}

		protected void _syncClips()
		{
			if (m_SyncDisplayObjects == null)
			{
				return;
			}
			foreach (KeyValuePair<int, TextGroup> syncDisplayObject in m_SyncDisplayObjects)
			{
				if (syncDisplayObject.Key < lineDrawOps.Count)
				{
					m_SyncDisplayObjects[syncDisplayObject.Key].clipCache.x = lineDrawOps[syncDisplayObject.Key].x + lineDrawOps[syncDisplayObject.Key].drawWidth;
					m_SyncDisplayObjects[syncDisplayObject.Key].clipCache.y = lineDrawOps[syncDisplayObject.Key].y;
				}
			}
		}

		protected override void _appendChar(char c)
		{
			base._appendChar(c);
			m_TextGroups.Add(m_LastTextGroup);
		}

		protected override void _removeLastChar()
		{
			base._removeLastChar();
			if (m_TextGroups.Count > 0)
			{
				m_TextGroups.RemoveAt(m_TextGroups.Count - 1);
			}
		}
	}
}
