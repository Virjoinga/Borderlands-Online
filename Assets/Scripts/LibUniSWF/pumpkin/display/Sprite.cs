using UnityEngine;
using pumpkin.geom;

namespace pumpkin.display
{
	public class Sprite : DisplayObjectContainer
	{
		public Graphics graphics = new Graphics();

		public bool mouseEnabled = true;

		public bool mouseChildrenEnabled = true;

		public bool buttonMode
		{
			get
			{
				return !mouseChildrenEnabled;
			}
			set
			{
				if (value)
				{
					mouseChildrenEnabled = false;
				}
				else
				{
					mouseChildrenEnabled = true;
				}
			}
		}

		public override DisplayObject getObjectUnderPoint(Vector2 point)
		{
			if (!base.visible)
			{
				return null;
			}
			if (!mouseEnabled)
			{
				return null;
			}
			if (graphics != null)
			{
				Vector2 vector = globalToLocal(point);
				Rect inheritedClipRect = getInheritedClipRect();
				if (inheritedClipRect.width > 0f && inheritedClipRect.height > 0f)
				{
					for (int i = 0; i < graphics.drawOPs.Count; i++)
					{
						Rect rect = graphics.drawOPs[i].calcClipping(this, inheritedClipRect);
						if (vector.x >= rect.x && vector.y >= rect.y && vector.x < rect.x + rect.width && vector.y < rect.y + rect.height)
						{
							return this;
						}
					}
				}
				else if (graphics.HitTest(vector.x, vector.y))
				{
					if (m_Alpha == 0f)
					{
						return null;
					}
					return this;
				}
			}
			if (!mouseChildrenEnabled)
			{
				if (base.getObjectUnderPoint(point) != null)
				{
					if (m_Alpha == 0f)
					{
						return null;
					}
					return this;
				}
				return null;
			}
			return base.getObjectUnderPoint(point);
		}

		public override void updateBounds()
		{
			base.updateBounds();
			if (graphics == null)
			{
				return;
			}
			Rectangle bounds = graphics.getBounds();
			if (bounds.width != 0f || bounds.height != 0f)
			{
				bounds.width *= base.scaleX;
				bounds.height *= base.scaleY;
				if (m_BoundsRect.width == 0f && m_BoundsRect.height == 0f)
				{
					m_BoundsRect = bounds.clone();
				}
				else
				{
					m_BoundsRect = m_BoundsRect.extendBounds(bounds);
				}
			}
		}
	}
}
