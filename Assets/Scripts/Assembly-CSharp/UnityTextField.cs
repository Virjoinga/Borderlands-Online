using System;
using System.Reflection;
using A;
using UnityEngine;
using pumpkin.display;
using pumpkin.swf;
using pumpkin.text;

public class UnityTextField : BitmapTextField
{
	protected int _iCaretIndex;

	protected Color _textColor;

	public BitmapFontAssetInfo c21a96789c15a7f0c78c3584bd463637d
	{
		get
		{
			return m_FontInfo;
		}
	}

	public Color c34fce3bccfffc6feb3579939c6d9a057
	{
		get
		{
			return _textColor;
		}
		set
		{
			if (value == _textColor)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return;
					}
				}
			}
			_textColor = value;
			base.textFormat.color = _textColor;
			c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.cba23612a1580080a6189ff33fe2e2d9c(this);
		}
	}

	public bool ca07ebfaabd41a5a4b21a0ae22c34e17b
	{
		get
		{
			return m_HasKeybaordFocus;
		}
		private set
		{
		}
	}

	public float c5966fc7f2f1243425ba932fa3223e264()
	{
		return maxW;
	}

	public float c4d9308ce196d48f1d1782f14331cbae6()
	{
		return maxH;
	}

	protected void cea08d84f688d7344b7b064a8b551cd97(BitmapTextField ca08748e235f2abf925ebb3dfb3b858e8, out float cc63a40108f7294f19e932d331ffc0f14, out float c184831b330c8e3758b6edad55c95f3dc)
	{
		Type type = ca08748e235f2abf925ebb3dfb3b858e8.GetType();
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
		FieldInfo field = type.GetField("maxW", bindingAttr);
		FieldInfo field2 = type.GetField("maxH", bindingAttr);
		cc63a40108f7294f19e932d331ffc0f14 = (float)field.GetValue(ca08748e235f2abf925ebb3dfb3b858e8);
		c184831b330c8e3758b6edad55c95f3dc = (float)field2.GetValue(ca08748e235f2abf925ebb3dfb3b858e8);
	}

	public void cab0bb682ae5fcb74dec34d839a21ea45()
	{
		renderText();
	}

	protected override void _removeLastChar()
	{
		base._removeLastChar();
		_iCaretIndex = Math.Max(0, --_iCaretIndex);
		if (base.type != TextFieldType.INPUT)
		{
			return;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.cba23612a1580080a6189ff33fe2e2d9c(this);
			return;
		}
	}

	protected int c55b860b84fffb26bede25fcc5c383886()
	{
		int num = 0;
		for (int i = 0; i < m_Text.Length; i++)
		{
			num += ca1a5c06e21123112664c60958e640ed4(m_Text[i]);
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return num;
		}
	}

	protected int ca1a5c06e21123112664c60958e640ed4(char ceacb19a4ed73f90d25df5977139fddb1)
	{
		if (ceacb19a4ed73f90d25df5977139fddb1 < '\u007f')
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return 1;
				}
			}
		}
		return 2;
	}

	protected override void _appendChar(char c)
	{
		if (base.maxChars > 0)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (c55b860b84fffb26bede25fcc5c383886() + ca1a5c06e21123112664c60958e640ed4(c) > base.maxChars)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}
		m_Text = m_Text.Insert(_iCaretIndex, string.Empty + c);
		_iCaretIndex++;
		if (autoInputScroll)
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
			base.scrollV = base.maxScrollV;
		}
		if (base.type != TextFieldType.INPUT)
		{
			return;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.cba23612a1580080a6189ff33fe2e2d9c(this);
			return;
		}
	}

	protected override void renderText()
	{
		if (!base.visible)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		Rect cadc118b5c81bb89bf38380c9747869ba;
		Vector3 cb25294f966b28cdf44d1bc2462c479c;
		Material c7eee70227d1080f1380b85d2d75607ad;
		if (base.type == TextFieldType.INPUT)
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
			Vector2 c73ab8fbcc72afbd787a3dd69ddc;
			c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.c5269337dd37446a5b02beed784c874e0(this, out cadc118b5c81bb89bf38380c9747869ba, out cb25294f966b28cdf44d1bc2462c479c, out c7eee70227d1080f1380b85d2d75607ad, _iCaretIndex, out c73ab8fbcc72afbd787a3dd69ddc);
			c7a40c86d9375e9cb625b9780f1cf83b4(c73ab8fbcc72afbd787a3dd69ddc, cb25294f966b28cdf44d1bc2462c479c);
		}
		else
		{
			c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.c5269337dd37446a5b02beed784c874e0(this, out cadc118b5c81bb89bf38380c9747869ba, out cb25294f966b28cdf44d1bc2462c479c, out c7eee70227d1080f1380b85d2d75607ad);
		}
		if (!(c7eee70227d1080f1380b85d2d75607ad != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			graphics.drawOPs.Clear();
			graphics.clear();
			graphics.drawRectUV(c7eee70227d1080f1380b85d2d75607ad, cadc118b5c81bb89bf38380c9747869ba, new Rect(0f, 0f, cb25294f966b28cdf44d1bc2462c479c.x, cb25294f966b28cdf44d1bc2462c479c.y));
			return;
		}
	}

	protected void c7a40c86d9375e9cb625b9780f1cf83b4(Vector2 c73ab8fbcc72afbd787a3dd69ddc69496, Vector3 cb25294f966b28cdf44d1bc2462c479c1)
	{
		if (m_Cursor != null)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					m_Cursor.visible = m_HasKeybaordFocus;
					m_Cursor.colorTransform = _textColor;
					m_Cursor.x = Math.Min(c73ab8fbcc72afbd787a3dd69ddc69496.x, cb25294f966b28cdf44d1bc2462c479c1.x);
					m_Cursor.y = c73ab8fbcc72afbd787a3dd69ddc69496.y;
					return;
				}
			}
		}
		if (m_Cursor == null)
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			m_Cursor.visible = false;
			return;
		}
	}

	protected override void _textChanged()
	{
		base._textChanged();
		_iCaretIndex = Math.Max(0, Math.Min(m_Text.Length, _iCaretIndex));
		_textColor = base.textFormat.color;
		c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.cba23612a1580080a6189ff33fe2e2d9c(this);
	}

	protected override void _cursorChanged(DisplayObject cursor)
	{
		if (m_Cursor != null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_Cursor.parent != null)
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
				m_Cursor.parent.removeChild(m_Cursor);
			}
			m_Cursor = cc7b206340b600c7decc4e7b5711da220.c7088de59e49f7108f520cf7e0bae167e;
		}
		m_Cursor = cursor;
		if (m_Cursor != null)
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
			addChild(m_Cursor);
		}
		renderText();
	}

	protected override void onCreateCursor()
	{
	}

	public override void setAssetInfo(SwfAssetContext assetContext, BitmapFontAssetInfo fontInfo, DisplayObjectInfo dispInfo)
	{
		int bold;
		if (fontInfo.className.Contains("b:1"))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			bold = 1;
		}
		else
		{
			bold = 0;
		}
		fontInfo.bold = bold;
		int italic;
		if (fontInfo.className.Contains("i:1"))
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
			italic = 1;
		}
		else
		{
			italic = 0;
		}
		fontInfo.italic = italic;
		fontInfo.spaceWidth = 1f;
		m_Type = dispInfo.textInfo.type;
		if (base.type == TextFieldType.INPUT)
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
			base.cursor = c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.c5606a4cc3e40f37e543dde9ae004c3e0.newInstance();
		}
		fontInfo.shared = base.type == TextFieldType.INPUT;
		fontInfo.color = Color.white;
		base.setAssetInfo(assetContext, fontInfo, dispInfo);
		base.assetContext.resourceLoader = assetContext.resourceLoader;
		base.assetContext.textureManager = assetContext.textureManager;
		maxW = dispInfo.tranform.width;
		maxH = dispInfo.tranform.height;
		c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.c88f5bae060324fb84669348fec1dcf3b(this);
	}

	protected override void setAssetInfo(SwfAssetContext assetContext, BitmapFontAssetInfo fontInfoIn, TextFormat format)
	{
		base.setAssetInfo(assetContext, fontInfoIn, format);
		m_CursorColor = Color.white;
		base.textFormat.bold = fontInfoIn.bold > 0;
		base.textFormat.italic = fontInfoIn.italic > 0;
		base.textFormat.color = fontInfoIn.color;
		_textColor = fontInfoIn.color;
		c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.c7c180d3766c7861a208cfd3dc537208c(this);
	}

	protected override void _KeyboardFocusChange()
	{
		base._KeyboardFocusChange();
		_iCaretIndex = m_Text.Length;
		renderText();
	}
}
