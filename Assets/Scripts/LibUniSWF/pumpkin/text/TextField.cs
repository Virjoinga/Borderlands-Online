using pumpkin.display;
using pumpkin.events;
using pumpkin.swf;

namespace pumpkin.text
{
	public class TextField : Sprite
	{
		public bool autoInputScroll = true;

		public static char PASSWORD_CHAR = '*';

		public static MovieClipProfiler profilerSettings = MovieClipProfiler.TextExportWarn;

		protected string m_Text = "";

		protected float m_Kerning = -1f;

		protected int m_Align = TextFieldAlign.LEFT;

		protected TextFormat m_Format = new TextFormat();

		protected int m_Type = -1;

		protected CEvent m_ChangedEvent;

		protected int m_MaxScrollV = 0;

		protected int m_ScrollV = 0;

		protected int m_MaxScrollH = 0;

		protected int m_ScrollH = 0;

		protected bool m_HasKeybaordFocus = false;

		protected int m_SelectionStart = -1;

		protected int m_SelectionEnd = -1;

		protected bool m_MouseInside = false;

		protected bool m_MultuLine = false;

		protected DisplayObject m_Cursor;

		protected int m_MaxChars = 0;

		protected string m_ValidCharacters = null;

		protected bool m_HasListener_MOUSE_UP = false;

		protected int m_NumLines = 0;

		protected Stage m_FocusStageRef;

		protected bool m_DisplayAsPassword = false;

		public string localizationName = null;

		public bool hasFilters = false;

		public string text
		{
			get
			{
				return m_Text;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				if (m_Text != value)
				{
					m_Text = value;
					_clipMaxChars();
					_textChanged();
					renderText();
					if (m_ChangedEvent == null)
					{
						m_ChangedEvent = new CEvent(CEvent.CHANGED, true, false);
					}
					fireEvent(m_ChangedEvent);
				}
			}
		}

		internal float kerningOverride
		{
			get
			{
				return m_Kerning;
			}
			set
			{
				m_Kerning = value;
				renderText();
			}
		}

		internal int align
		{
			get
			{
				return m_Align;
			}
			set
			{
				m_Align = value;
				renderText();
			}
		}

		public TextFormat textFormat
		{
			get
			{
				return m_Format;
			}
			set
			{
				if (value == null)
				{
					value = new TextFormat();
				}
				m_Format = value;
				onTextFormatUpdated();
				renderText();
			}
		}

		public int type
		{
			get
			{
				return m_Type;
			}
			set
			{
				if (m_Type != value)
				{
					m_Type = _onSetTextFieldType(value);
				}
			}
		}

		public int maxScrollH
		{
			get
			{
				return _calcMaxScrollH();
			}
		}

		public int maxScrollV
		{
			get
			{
				return _calcMaxScrollV();
			}
		}

		public int scrollV
		{
			get
			{
				return _getScrollV();
			}
			set
			{
				_setScrollV(value);
			}
		}

		public int scrollH
		{
			get
			{
				return _getScrollH();
			}
			set
			{
				_setScrollH(value);
			}
		}

		public bool multiline
		{
			get
			{
				return m_MultuLine;
			}
			set
			{
				m_MultuLine = value;
				_multiLineChange();
			}
		}

		public DisplayObject cursor
		{
			get
			{
				return m_Cursor;
			}
			set
			{
				_cursorChanged(value);
			}
		}

		public int maxChars
		{
			get
			{
				return m_MaxChars;
			}
			set
			{
				m_MaxChars = value;
				if (_clipMaxChars())
				{
					renderText();
				}
			}
		}

		public string validChars
		{
			get
			{
				return m_ValidCharacters;
			}
			set
			{
				m_ValidCharacters = value;
				if (_clipMaxChars())
				{
					renderText();
				}
			}
		}

		public float numLines
		{
			get
			{
				return m_NumLines;
			}
		}

		public bool displayAsPassword
		{
			get
			{
				return m_DisplayAsPassword;
			}
			set
			{
				if (value != m_DisplayAsPassword)
				{
					m_DisplayAsPassword = value;
					renderText();
				}
			}
		}

		public TextField()
		{
			mouseChildrenEnabled = false;
			addEventListener(FocusEvent.FOCUS_IN, onKeyboardFocusIn);
			addEventListener(FocusEvent.FOCUS_OUT, onKeyboardFocusOut);
			addEventListener(MouseEvent.CLICK, onMouseClick);
			addEventListener(MouseEvent.MOUSE_ENTER, onMouseEnter);
			addEventListener(MouseEvent.MOUSE_LEAVE, onMouseLeave);
			addEventListener(KeyboardEvent.KEY_DOWN, onKeyDown);
		}

		public virtual void setAssetInfo(SwfAssetContext assetContext, BitmapFontAssetInfo fontInfo, DisplayObjectInfo dispInfo)
		{
		}

		protected override void OnSetParent(DisplayObjectContainer inParent)
		{
			if (m_FocusStageRef != null)
			{
				m_FocusStageRef.removeEventListener(MouseEvent.MOUSE_UP, onStageMouseUp);
				if (m_FocusStageRef.focus == this)
				{
					m_FocusStageRef.focus = null;
				}
				m_FocusStageRef = null;
			}
		}

		protected virtual void _textChanged()
		{
		}

		protected virtual void renderText()
		{
		}

		protected virtual void onTextFormatUpdated()
		{
		}

		public virtual TextField clone()
		{
			return null;
		}

		protected virtual int _onSetTextFieldType(int newType)
		{
			return TextFieldType.STATIC;
		}

		protected virtual int _calcMaxScrollH()
		{
			return m_MaxScrollH;
		}

		protected virtual int _calcMaxScrollV()
		{
			return m_MaxScrollV;
		}

		protected virtual int _getScrollV()
		{
			return m_ScrollV;
		}

		protected virtual void _setScrollV(int newScrollV)
		{
			if (newScrollV < 0)
			{
				newScrollV = 0;
			}
			m_ScrollV = newScrollV;
			renderText();
		}

		protected virtual int _getScrollH()
		{
			return m_ScrollH;
		}

		protected virtual void _setScrollH(int newScrollH)
		{
			m_ScrollH = newScrollH;
			renderText();
		}

		protected virtual void _multiLineChange()
		{
			renderText();
		}

		protected virtual void _cursorChanged(DisplayObject cursor)
		{
		}

		protected void onMouseClick(CEvent e)
		{
			if (stage != null && type == TextFieldType.INPUT)
			{
				stage.focus = this;
				if (m_FocusStageRef != null)
				{
					m_FocusStageRef.removeEventListener(MouseEvent.MOUSE_UP, onStageMouseUp);
					m_FocusStageRef = null;
				}
				stage.addEventListener(MouseEvent.MOUSE_UP, onStageMouseUp);
				m_FocusStageRef = stage;
			}
		}

		protected void onStageMouseUp(CEvent e)
		{
			if (!m_MouseInside && m_HasKeybaordFocus)
			{
				onKeyboardFocusOut(null);
				stage.focus = null;
			}
		}

		protected void onMouseEnter(CEvent e)
		{
			m_MouseInside = true;
		}

		protected void onMouseLeave(CEvent e)
		{
			m_MouseInside = false;
		}

		protected virtual void _KeyboardFocusChange()
		{
			renderText();
		}

		protected void onKeyboardFocusIn(CEvent e)
		{
			if (!m_HasKeybaordFocus)
			{
				m_HasKeybaordFocus = true;
				if (type == TextFieldType.INPUT && m_HasKeybaordFocus && autoInputScroll)
				{
					scrollV = maxScrollV;
				}
				renderText();
			}
		}

		protected void onKeyboardFocusOut(CEvent e)
		{
			if (m_HasKeybaordFocus)
			{
				m_HasKeybaordFocus = false;
				renderText();
			}
		}

		protected virtual void _selectionChanged()
		{
			renderText();
		}

		public void debugSetSelection(int start, int end)
		{
			m_SelectionStart = start;
			m_SelectionEnd = end;
			if (m_SelectionEnd < m_SelectionStart)
			{
				m_SelectionEnd = m_SelectionStart;
			}
		}

		protected void onKeyDown(CEvent e)
		{
			KeyboardEvent keyboardEvent = e as KeyboardEvent;
			if (type != TextFieldType.INPUT || !m_HasKeybaordFocus)
			{
				return;
			}
			bool flag = false;
			if (keyboardEvent.charString == "\b")
			{
				_removeLastChar();
				flag = true;
			}
			else if (keyboardEvent.charString == "\n" || keyboardEvent.charString == "\r")
			{
				if (multiline)
				{
					_appendChar('\n');
					flag = true;
				}
			}
			else if (keyboardEvent.charString != null && keyboardEvent.charString.Length > 0)
			{
				_appendChar(keyboardEvent.charString[0]);
				flag = true;
			}
			if (flag)
			{
				if (m_ChangedEvent == null)
				{
					m_ChangedEvent = new CEvent(CEvent.CHANGED, true, false);
				}
				fireEvent(m_ChangedEvent);
			}
		}

		protected virtual void _appendChar(char c)
		{
			m_Text += c;
			_clipMaxChars();
			renderText();
			if (autoInputScroll)
			{
				scrollV = maxScrollV;
			}
		}

		protected virtual void _removeLastChar()
		{
			if (m_Text.Length > 0)
			{
				m_Text = m_Text.Substring(0, m_Text.Length - 1);
				_clipMaxChars();
				renderText();
				if (autoInputScroll)
				{
					scrollV = maxScrollV;
				}
			}
		}

		protected bool _clipMaxChars()
		{
			bool result = false;
			if (m_MaxChars > 0 && m_Text.Length > m_MaxChars)
			{
				m_Text = m_Text.Substring(0, m_MaxChars);
				result = true;
			}
			if (m_ValidCharacters != null)
			{
				string text = "";
				for (int i = 0; i < m_Text.Length; i++)
				{
					for (int j = 0; j < m_ValidCharacters.Length; j++)
					{
						if (m_Text[i] == m_ValidCharacters[j])
						{
							text += m_Text[i];
						}
					}
				}
				if (text.Length != m_Text.Length)
				{
					m_Text = text;
					result = true;
				}
			}
			return result;
		}

		public GlyphInfo getGlyph(char c)
		{
			return _getGlyph(c);
		}

		protected virtual GlyphInfo _getGlyph(char c)
		{
			return null;
		}

		public GlyphInfo createGlyph(char c)
		{
			return _createGlyph(c);
		}

		protected virtual GlyphInfo _createGlyph(char c)
		{
			return null;
		}

		public virtual void appendText(string txt)
		{
			text += text;
		}
	}
}
