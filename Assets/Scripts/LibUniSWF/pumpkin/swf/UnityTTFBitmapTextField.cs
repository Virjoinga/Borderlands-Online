using System;
using System.Collections.Generic;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;
using pumpkin.geom;
using pumpkin.text;
using pumpkin.uniSWFInternal;

namespace pumpkin.swf
{
	public class UnityTTFBitmapTextField : BitmapTextField
	{
		private UnityTTFFontInfo m_TTFFontInfo;

		public bool _renderTextNextFrame = true;

		private BitmapFontAssetInfo fontInfo;

		private bool enableWrap;

		internal static bool m_lcheck = false;

		public static List<UnityTTFBitmapTextField> allTextFields = new List<UnityTTFBitmapTextField>();

		public static Dictionary<Font, UnityFontGeneratorCache> fontGenCache = new Dictionary<Font, UnityFontGeneratorCache>();

		private float currKernHack = 0f;

		public UnityTTFBitmapTextField()
		{
			if (!m_lcheck)
			{
				if (!UniSWFLicense.isPro())
				{
					throw new Exception(UniSWFLicense.PRO_WARNING_STR);
				}
				m_lcheck = true;
			}
		}

		~UnityTTFBitmapTextField()
		{
			Debug.Log("Destory UnityTTFBitmapTextField");
			allTextFields.Remove(this);
		}

		public override void updateFrame(CEvent e)
		{
			if (m_lcheck)
			{
				base.updateFrame(e);
				if (m_Format.size == 0f)
				{
					m_Format.size = 32f;
				}
				m_TTFFontInfo.font.RequestCharactersInTexture(m_Text, (int)m_Format.size);
				if (_renderTextNextFrame)
				{
					Debug.Log("Render text: " + name);
					_deferedRenderText();
				}
				if (!allTextFields.Contains(this))
				{
					allTextFields.Add(this);
				}
				if (m_TTFFontInfo.fontCacheDirty)
				{
					m_TTFFontInfo.fontCacheDirty = false;
					Debug.Log("Cache dirty");
					renderText();
				}
			}
		}

		protected override void _renderText(BitmapFontAssetInfo fontInfo, bool enableWrap)
		{
			if (m_TTFFontInfo == null)
			{
				m_TTFFontInfo = m_FontInfo as UnityTTFFontInfo;
			}
			_renderTextNextFrame = true;
			this.fontInfo = fontInfo;
			this.enableWrap = enableWrap;
		}

		protected void _deferedRenderText()
		{
			_renderTextNextFrame = false;
			m_TextContainer.removeAllChildren();
			base._renderText(fontInfo, enableWrap);
		}

		protected override float _renderChar(float lastX, char c, int charId, bool draw)
		{
			if (!m_LineInScrollV)
			{
			}
			if (!m_Format.charClip || lastX > maxW)
			{
			}
			float num = 1f;
			float num2 = 0f - firstCharWidth;
			if (m_DisplayAsPassword)
			{
				c = TextField.PASSWORD_CHAR;
			}
			UnityTTFFontInfo unityTTFFontInfo = m_FontInfo as UnityTTFFontInfo;
			bool flag = true;
			int num3 = (int)m_Format.size;
			if (flag)
			{
				num3 = (int)doNonScaledFontSize();
			}
			UnityTTFGlyph cacheUnityTTFGlyph = getCacheUnityTTFGlyph(unityTTFFontInfo, c, num3);
			if (cacheUnityTTFGlyph == null)
			{
				lastX += m_FontInfo.spaceWidth;
				if (c > '\r' && c != ' ')
				{
					if (BitmapTextField.enableMissingCharacterWarning)
					{
						Debug.LogWarning("Missing embeded character '" + c + "' ( 0x" + string.Format("{0:x}", (int)c) + ") in font '" + m_FontInfo.className + "'");
					}
					Debug.LogWarning("Missing char " + c);
				}
				return lastX;
			}
			if (isFirstCharInLine)
			{
				firstCharWidth = cacheUnityTTFGlyph.charStartX;
				isFirstCharInLine = false;
			}
			float num4 = lastX;
			currKernHack = 0f;
			if (charId > 0)
			{
				int num5 = 0;
				for (int i = 0; i < unityTTFFontInfo.fontAssetInfo.kerning.Length; i++)
				{
					FTKerningInfo fTKerningInfo = unityTTFFontInfo.fontAssetInfo.kerning[i];
					if ((ushort)fTKerningInfo.right == c && (ushort)fTKerningInfo.left == m_Text[charId - 1])
					{
						num5 = fTKerningInfo.kern;
						break;
					}
				}
				if (num5 != 0)
				{
					float num6 = (float)num5 / (float)unityTTFFontInfo.fontAssetInfo.unitsPerEM * m_Format.size;
					lastX += num6;
					Debug.Log("kerningOverride[src] " + c + " = " + currKernHack);
				}
			}
			float offsetY = 0f;
			if (draw)
			{
				float num7 = drawUnityTTF(unityTTFFontInfo, cacheUnityTTFGlyph, lastX, offsetY, c);
				lastX += num7;
			}
			lastX += m_Format.letterSpacing;
			return lastX;
		}

		protected float drawUnityTTF(UnityTTFFontInfo fontInfo, UnityTTFGlyph charInfoIn, float lastX, float offsetY, char c)
		{
			bool flag = false;
			CharacterInfo unityCharInfo = charInfoIn.unityCharInfo;
			Texture mainTexture = fontInfo.font.material.mainTexture;
			Font font = fontInfo.font;
			float num = m_Format.size;
			float num2 = unityCharInfo.vert.y;
			float num3 = unityCharInfo.uv.x * (float)mainTexture.width;
			float num4 = (float)mainTexture.height - unityCharInfo.uv.y * (float)mainTexture.height;
			float num5 = unityCharInfo.uv.width * (float)mainTexture.width;
			float num6 = 0f - unityCharInfo.uv.height * (float)mainTexture.height;
			Rect rect = default(Rect);
			Rect rect2 = default(Rect);
			pumpkin.display.Sprite sprite = new pumpkin.display.Sprite();
			float num7 = 0f;
			float num8 = 0f;
			int ascender = fontInfo.fontAssetInfo.ascender;
			int unitsPerEM = fontInfo.fontAssetInfo.unitsPerEM;
			float num9 = 0f;
			if (unityCharInfo.flipped)
			{
				Matrix matrix = new Matrix();
				matrix.tx = 0f - num3 - num5;
				matrix.ty = 0f - num4;
				matrix.rotate(0f - Angle.degreesToRadians(90f));
				sprite.graphics.drawTile(font.material, matrix, 0f, 0f, num6, num5);
				float num10 = (float)ascender / (float)unitsPerEM * num;
				float num11 = (float)ascender / (float)unitsPerEM * 16f;
				sprite.y = 0f - unityCharInfo.vert.y;
				sprite.y += num10;
				sprite.y += 2f;
				sprite.y -= num11;
				if (c == 'm')
				{
					int num12 = 1540;
					num8 = (float)num12 / (float)unitsPerEM * num;
					int num13 = 43;
					num9 = (float)num13 / (float)unitsPerEM * num;
				}
				else
				{
					num8 = unityCharInfo.width;
				}
			}
			else
			{
				Matrix matrix2 = new Matrix();
				matrix2.tx = 0f - num3;
				matrix2.ty = 0f - num4 - num6;
				matrix2.scale(1f, -1f);
				sprite.graphics.drawTile(font.material, matrix2, 0f, 0f, num5, num6);
				num9 = unityCharInfo.vert.x;
				if (num == 16f)
				{
					num = num;
				}
				float num14 = (float)ascender / (float)unitsPerEM * num;
				float num15 = (float)ascender / (float)unitsPerEM * 16f;
				sprite.y = 0f - unityCharInfo.vert.y;
				sprite.y += num14;
				sprite.y += 2f;
				sprite.y -= num15;
				num8 = unityCharInfo.width;
			}
			sprite.x = num9 + lastX;
			Debug.Log("kerningOverride " + c + " = " + currKernHack);
			m_TextContainer.addChild(sprite);
			return num8;
		}

		public static UnityTTFFontInfo createTTFFont(UniSWFTTFFontAssetInfo fontAssetInfo, int size, FontStyle style, string[] aliasNames = null)
		{
			return createTTFFont(fontAssetInfo, size, style, null, MovieClipPlayer.getRuntimeContent("UnityTTFTextField"), aliasNames);
		}

		public static UnityTTFFontInfo createTTFFont(UniSWFTTFFontAssetInfo fontAssetInfo, int size, FontStyle style, string characters, SwfAssetContext context, string[] aliasNames = null)
		{
			Font unityFont = fontAssetInfo.unityFont;
			string text = unityFont.fontNames[0];
			Debug.Log("registerName=" + text + ", " + unityFont.fontNames.Length);
			UnityTTFFontInfo fontInfo = new UnityTTFFontInfo();
			fontInfo.isTTF = true;
			fontInfo.className = text;
			fontInfo.assetContext = context;
			fontInfo.fontAssetInfo = fontAssetInfo;
			fontInfo.font = unityFont;
			fontInfo.size = size;
			fontInfo.font.textureRebuildCallback = delegate
			{
				fontInfo.ttfAllCharacters.Clear();
			};
			fontInfo.autoGenerateSizes = size == 0;
			context.exports[context.genUniqueCid()] = fontInfo;
			UnityTTFFontInfo result = fontInfo;
			if (aliasNames != null)
			{
				for (int i = 0; i < aliasNames.Length; i++)
				{
					fontInfo = new UnityTTFFontInfo();
					fontInfo.className = unityFont.name;
					fontInfo.assetContext = context;
					fontInfo.font = unityFont;
					fontInfo.size = size;
					fontInfo.name = aliasNames[i];
					UnityFontGeneratorCache genCache = null;
					if (!fontGenCache.ContainsKey(unityFont))
					{
						genCache = new UnityFontGeneratorCache();
						fontGenCache[unityFont] = genCache;
						genCache.font = unityFont;
						fontInfo.font.textureRebuildCallback = delegate
						{
							Debug.LogWarning("textureRebuildCallback");
							for (int j = 0; j < genCache.fontInfoList.Count; j++)
							{
								UnityTTFFontInfo unityTTFFontInfo = genCache.fontInfoList[j];
								unityTTFFontInfo.ttfAllCharacters.Clear();
								unityTTFFontInfo.fontCacheDirty = true;
							}
							for (int k = 0; k < allTextFields.Count; k++)
							{
								allTextFields[k]._renderTextNextFrame = true;
							}
						};
					}
					genCache.fontInfoList.Add(fontInfo);
					fontInfo.autoGenerateSizes = size == 0;
					context.exports[context.genUniqueCid()] = fontInfo;
				}
			}
			return result;
		}

		public static UnityTTFGlyph getCacheUnityTTFGlyph(UnityTTFFontInfo fontInfo, char c, float fontSize)
		{
			int fontSize2 = (int)fontSize;
			Dictionary<char, UnityTTFGlyph> dictionary = ((!fontInfo.autoGenerateSizes) ? fontInfo.getCharCacheForSize((int)fontInfo.size, true) : fontInfo.getCharCacheForSize(fontSize2, true));
			if (dictionary.ContainsKey(c))
			{
			}
			if (!fontInfo.allChars.Contains("" + c))
			{
				fontInfo.allChars += c;
			}
			UnityTTFGlyph unityTTFGlyph2 = (dictionary[c] = new UnityTTFGlyph());
			bool flag = false;
			for (int i = 0; i < fontInfo.font.characterInfo.Length; i++)
			{
				CharacterInfo unityCharInfo = fontInfo.font.characterInfo[i];
				if ((ushort)unityCharInfo.index == c && ((fontSize == 16f && unityCharInfo.size == 0) || (float)unityCharInfo.size == fontSize))
				{
					unityTTFGlyph2.unityCharInfo = unityCharInfo;
					flag = true;
				}
			}
			if (!flag)
			{
				return null;
			}
			return unityTTFGlyph2;
		}

		public float doNonScaledFontSize()
		{
			Matrix matrix = _fastGetFullMatrixRef();
			if (matrix.a == 1f && matrix.b == 1f)
			{
				m_TextContainer.scaleX = 1f;
				m_TextContainer.scaleY = 1f;
				return m_Format.size;
			}
			float num = Mathf.Max(matrix.getScaleX(), matrix.getScaleY());
			float result = m_Format.size * num;
			m_TextContainer.scaleX = 1f / num;
			m_TextContainer.scaleY = 1f / num;
			return result;
		}

		public void forceRender()
		{
			renderText();
		}
	}
}
