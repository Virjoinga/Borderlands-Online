using UnityEngine;
using pumpkin.events;
using pumpkin.swf;

namespace pumpkin.display
{
	public class Stage : DisplayObjectContainer
	{
		public float stageMouseX;

		public float stageMouseY;

		private Vector2 m_StageSize;

		private Vector2 m_ScreenSize;

		public DisplayObject mouseOver;

		public bool enableAlphaMask = false;

		public Component host;

		public bool defaultStageHitTest = false;

		protected DisplayObject m_Focus;

		public uint stageFlags = 0u;

		public DisplayObject focus
		{
			get
			{
				return m_Focus;
			}
			set
			{
				if (m_Focus != value)
				{
					if (m_Focus != null)
					{
						m_Focus.fireEvent(new FocusEvent(FocusEvent.FOCUS_OUT, true, false));
					}
					m_Focus = value;
					if (m_Focus != null)
					{
						m_Focus.fireEvent(new FocusEvent(FocusEvent.FOCUS_IN, true, false));
					}
				}
			}
		}

		public float stageWidth
		{
			get
			{
				return m_StageSize.x / base.scaleX;
			}
			set
			{
				m_StageSize.x = value;
			}
		}

		public float stageHeight
		{
			get
			{
				return m_StageSize.y / base.scaleY;
			}
			set
			{
				m_StageSize.y = value;
			}
		}

		public float screenWidth
		{
			get
			{
				return m_ScreenSize.x;
			}
			set
			{
				m_ScreenSize.x = value;
			}
		}

		public float screenHeight
		{
			get
			{
				return m_ScreenSize.y;
			}
			set
			{
				m_ScreenSize.y = value;
			}
		}

		public Stage()
		{
			stage = this;
			m_StageSize = new Vector2(Screen.width, Screen.height);
			m_ScreenSize = new Vector2(Screen.width, Screen.height);
			if (TextureManager.instance == null)
			{
				new TextureManager();
			}
		}

		public void handleMouseEvent(CEvent e)
		{
			dispatchEvent(e);
		}
	}
}
