using System.Collections.Generic;
using UnityEngine;
using pumpkin.events;
using pumpkin.geom;

namespace pumpkin.display
{
	public class DisplayObjectContainer : DisplayObject
	{
		public static bool depreciatedInvalidateMatrixAfterAddChild = false;

		protected List<DisplayObject> m_Children = new List<DisplayObject>();

		public int numChildren
		{
			get
			{
				return m_Children.Count;
			}
		}

		~DisplayObjectContainer()
		{
			int i = 0;
			for (; i < m_Children.Count; i++)
			{
				DisplayObject displayObject = m_Children[i];
				displayObject._destoryImpl();
			}
		}

		public void addChildAt(DisplayObject displayObject, int index)
		{
			addChild(displayObject);
			setChildIndex(displayObject, index);
		}

		public void addChild(DisplayObject displayObject)
		{
			if (displayObject != null && m_Children.IndexOf(displayObject) == -1)
			{
				if (displayObject.parent != null)
				{
					displayObject.parent.removeChild(displayObject);
				}
				displayObject.setParent(this);
				m_Children.Add(displayObject);
				dirtyMask |= 1u;
				if (depreciatedInvalidateMatrixAfterAddChild)
				{
					invalidateMatrix(true);
				}
			}
		}

		public void removeChild(DisplayObject displayObject)
		{
			if (displayObject != null && m_Children.IndexOf(displayObject) != -1)
			{
				displayObject.setParent(null);
				m_Children.Remove(displayObject);
				invalidateMatrix(true);
				dirtyMask |= 1u;
			}
		}

		public void setChildIndex(DisplayObject child, int index)
		{
			if (index > m_Children.Count)
			{
				return;
			}
			int childIndex = getChildIndex(child);
			if (childIndex < 0)
			{
				return;
			}
			dirtyMask |= 1u;
			child.dirtyMask |= 1u;
			if (index < childIndex)
			{
				for (int num = childIndex; num > index; num--)
				{
					m_Children[num] = m_Children[num - 1];
				}
				m_Children[index] = child;
			}
			else if (childIndex < index)
			{
				for (int i = childIndex; i < index; i++)
				{
					m_Children[i] = m_Children[i + 1];
				}
				m_Children[index] = child;
			}
		}

		public void removeAllChildren()
		{
			while (numChildren > 0)
			{
				removeChildAt(0);
			}
		}

		public void removeChildAt(int id)
		{
			removeChild(getChildAt(id));
		}

		public int getChildIndex(DisplayObject child)
		{
			return m_Children.IndexOf(child);
		}

		public override DisplayObject getChildAt(int id)
		{
			if (id >= m_Children.Count)
			{
				return null;
			}
			return m_Children[id];
		}

		public bool contains(DisplayObject obj)
		{
			for (int i = 0; i < m_Children.Count; i++)
			{
				if (obj == m_Children[i])
				{
					return true;
				}
			}
			return false;
		}

		internal override void _cacheInternal()
		{
			base._cacheInternal();
			for (int i = 0; i < m_Children.Count; i++)
			{
				m_Children[i]._cacheInternal();
			}
		}

		protected override void OnSetParent(DisplayObjectContainer inParent)
		{
			if (inParent == null)
			{
				for (int i = 0; i < m_Children.Count; i++)
				{
					m_Children[i]._cacheInternal();
				}
			}
		}

		internal override void _destoryImpl()
		{
			for (int i = 0; i < m_Children.Count; i++)
			{
				m_Children[i]._destoryImpl();
			}
		}

		public override DisplayObject getChildByName(string name)
		{
			for (int i = 0; i < m_Children.Count; i++)
			{
				DisplayObject displayObject = m_Children[i];
				if (displayObject.name == name)
				{
					return displayObject;
				}
			}
			return null;
		}

		public override void updateFrame(CEvent e)
		{
			base.updateFrame(e);
			for (int i = 0; i < m_Children.Count; i++)
			{
				DisplayObject displayObject = m_Children[i];
				displayObject.updateFrame(e);
			}
		}

		public override DisplayObject getObjectUnderPoint(Vector2 point)
		{
			if (!base.visible)
			{
				return null;
			}
			for (int num = m_Children.Count - 1; num >= 0; num--)
			{
				DisplayObject objectUnderPoint = m_Children[num].getObjectUnderPoint(point);
				if (objectUnderPoint != null)
				{
					return objectUnderPoint;
				}
			}
			return base.getObjectUnderPoint(point);
		}

		public override void updateBounds()
		{
			base.updateBounds();
			for (int i = 0; i < m_Children.Count; i++)
			{
				DisplayObject displayObject = m_Children[i];
				if (!displayObject.visible)
				{
					continue;
				}
				Rectangle bounds = displayObject.getBounds(this);
				if (bounds.width != 0f || bounds.height != 0f)
				{
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

		public override void invalidateMatrix(bool isLocal)
		{
			for (int i = 0; i < m_Children.Count; i++)
			{
				DisplayObject displayObject = m_Children[i];
				displayObject.invalidateMatrix(false);
			}
			base.invalidateMatrix(isLocal);
		}

		public override void broadcastEvent(CEvent e)
		{
			List<DisplayObject> m_ChildrenCopy = new List<DisplayObject>();
			m_Children.ForEach(delegate(DisplayObject item)
			{
				m_ChildrenCopy.Add(item);
			});
			for (int i = 0; i < m_ChildrenCopy.Count; i++)
			{
				DisplayObject displayObject = m_ChildrenCopy[i];
				displayObject.broadcastEvent(e);
			}
			dispatchEvent(e);
		}
	}
}
