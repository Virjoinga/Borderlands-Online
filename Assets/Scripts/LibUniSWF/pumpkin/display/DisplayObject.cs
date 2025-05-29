using System;
using System.Collections.Generic;
using UnityEngine;
using pumpkin.events;
using pumpkin.geom;
using pumpkin.geom.structs;
using pumpkin.tweener;
using pumpkin.utils;

namespace pumpkin.display
{
	public class DisplayObject : EventDispatcher, IBitmapDrawable
	{
		protected float m_x;

		protected float m_y;

		protected float m_scaleX;

		protected float m_scaleY;

		protected float m_Rotation;

		protected Matrix m_Matrix;

		protected Matrix m_FullMatrix;

		protected Rectangle m_BoundsRect;

		protected DisplayObjectContainer m_Parent;

		protected bool m_Visible;

		protected float m_Alpha;

		protected bool m_OverrideMatrix = false;

		protected bool m_MatrixDirty = true;

		protected bool m_GroupMatrixDirty = true;

		protected bool m_HasTranslation3D = false;

		protected Matrix4x4 m_Matrid3D;

		protected Vector2 m_Size;

		protected bool m_CustomSize = false;

		internal int m_BlendMode = 0;

		protected Color m_ColorTransform = Color.white;

		internal int m_MatrixInvalidateCnt = -1;

		internal bool changeByUser = false;

		internal SafeHashtable m_VmData;

		protected Rect m_Scale9Rect;

		protected bool m_HasScale9 = false;

		protected bool m_HasEnterFrameListeners = false;

		public Stage stage;

		public string name;

		public uint dirtyMask = uint.MaxValue;

		protected Rect m_LocalClipRect;

		protected Rect m_GlobalClipRect;

		protected bool m_ClipRectDirty = true;

		internal bool m_HasClipRect = false;

		public float srcWidth;

		public float srcHeight;

		public float rotateX = 0f;

		public float rotateY = 0f;

		public float rotateZ = 0f;

		public object userData = null;

		public int cachedCid = -1;

		protected List<TweenerObj> m_Tweens;

		internal DisplayObject m_CachedMask;

		protected DisplayObject m_Mask;

		private static Vector2 _res_globalToLocalFastStatic = default(Vector2);

		public float translateX = 0f;

		public float translateY = 0f;

		public float translateZ = 0f;

		protected bool m_Dragging = false;

		protected Vector2 m_DragStartPos;

		protected Rect m_DragConstrainRect;

		public Rect clipRect
		{
			get
			{
				return m_LocalClipRect;
			}
			set
			{
				m_LocalClipRect = value;
				if (m_LocalClipRect.width > 0f && m_LocalClipRect.height > 0f)
				{
					if (stage != null)
					{
						stage.m_HasClipRect = true;
					}
					m_HasClipRect = true;
				}
				m_ClipRectDirty = true;
			}
		}

		public bool hasClipRect
		{
			get
			{
				return m_HasClipRect;
			}
			set
			{
				m_HasClipRect = value;
			}
		}

		public DisplayObject mask
		{
			get
			{
				return m_Mask;
			}
			set
			{
				if (!(value is Sprite))
				{
					m_Mask = null;
					Debug.LogWarning("Attempt to set DisplayObject.mask on '" + name + "' with an invalid mask, Sprite expected");
				}
				else
				{
					m_Mask = value;
				}
			}
		}

		public float mouseX
		{
			get
			{
				if (stage == null)
				{
					return 0f;
				}
				return globalToLocal(new Vector2(stage.stageMouseX, stage.stageMouseY)).x;
			}
		}

		public float mouseY
		{
			get
			{
				if (stage == null)
				{
					return 0f;
				}
				return globalToLocal(new Vector2(stage.stageMouseX, stage.stageMouseY)).y;
			}
		}

		public float x
		{
			get
			{
				if (m_OverrideMatrix)
				{
					return m_Matrix.tx;
				}
				return m_x;
			}
			set
			{
				if ((m_x != value && !m_OverrideMatrix) || (value != m_Matrix.tx && m_OverrideMatrix))
				{
					invalidateMatrix(true);
					m_x = value;
					changeByUser = true;
				}
			}
		}

		public float y
		{
			get
			{
				if (m_OverrideMatrix)
				{
					return m_Matrix.ty;
				}
				return m_y;
			}
			set
			{
				if ((m_y != value && !m_OverrideMatrix) || (value != m_Matrix.ty && m_OverrideMatrix))
				{
					invalidateMatrix(true);
					m_y = value;
					changeByUser = true;
				}
			}
		}

		public float rotation
		{
			get
			{
				return m_Rotation;
			}
			set
			{
				if (m_Rotation != value)
				{
					invalidateMatrix(true);
					m_Rotation = value;
					changeByUser = true;
				}
			}
		}

		public float scaleX
		{
			get
			{
				return m_scaleX;
			}
			set
			{
				if (m_scaleX != value)
				{
					invalidateMatrix(true);
					m_scaleX = value;
					changeByUser = true;
					if (m_HasScale9)
					{
						rebuildScale9Grid();
					}
				}
			}
		}

		public float scaleY
		{
			get
			{
				return m_scaleY;
			}
			set
			{
				if (m_scaleY != value)
				{
					invalidateMatrix(true);
					m_scaleY = value;
					changeByUser = true;
					if (m_HasScale9)
					{
						rebuildScale9Grid();
					}
				}
			}
		}

		public float alpha
		{
			get
			{
				return m_Alpha;
			}
			set
			{
				if (m_Alpha != value)
				{
					m_Alpha = value;
					if (m_Alpha > 1f)
					{
						m_Alpha = 1f;
					}
					if (m_Alpha < 0f)
					{
						m_Alpha = 0f;
					}
					changeByUser = true;
					m_ColorTransform.a = m_Alpha;
					OnSetAlpha();
					dirtyMask |= 1u;
				}
			}
		}

		internal float internalAlpha
		{
			get
			{
				return m_Alpha;
			}
			set
			{
				if (m_Alpha != value)
				{
					m_Alpha = value;
					if (m_Alpha > 1f)
					{
						m_Alpha = 1f;
					}
					if (m_Alpha < 0f)
					{
						m_Alpha = 0f;
					}
					m_ColorTransform.a = m_Alpha;
					OnSetAlpha();
					dirtyMask |= 1u;
				}
			}
		}

		public bool visible
		{
			get
			{
				return m_Visible;
			}
			set
			{
				if (m_Visible != value)
				{
					m_Visible = value;
					invalidateMatrix(true);
					changeByUser = true;
					OnSetVisble();
					dirtyMask |= 1u;
				}
			}
		}

		public bool internalVisible
		{
			get
			{
				return m_Visible;
			}
			set
			{
				if (m_Visible != value)
				{
					m_Visible = value;
					invalidateMatrix(true);
					OnSetVisble();
					dirtyMask |= 1u;
				}
			}
		}

		public DisplayObjectContainer parent
		{
			get
			{
				return m_Parent;
			}
			set
			{
				setParent(value);
			}
		}

		public float width
		{
			get
			{
				if (m_CustomSize)
				{
					return m_Size.x;
				}
				return getBounds(m_Parent).width;
			}
			set
			{
				if (!m_CustomSize)
				{
					m_CustomSize = true;
					m_Size.y = srcHeight;
				}
				m_Size.x = value;
				changeByUser = true;
				_onSizeChange();
			}
		}

		public float height
		{
			get
			{
				if (m_CustomSize)
				{
					return m_Size.y;
				}
				return getBounds(m_Parent).height;
			}
			set
			{
				if (!m_CustomSize)
				{
					m_CustomSize = true;
					m_Size.x = srcWidth;
				}
				m_Size.y = value;
				changeByUser = true;
				_onSizeChange();
			}
		}

		public int blendMode
		{
			get
			{
				return m_BlendMode;
			}
			set
			{
				if (m_BlendMode != value)
				{
					changeByUser = true;
					m_BlendMode = value;
					dirtyMask |= 1u;
				}
			}
		}

		public Color colorTransform
		{
			get
			{
				return m_ColorTransform;
			}
			set
			{
				if (m_ColorTransform != value)
				{
					changeByUser = true;
					m_ColorTransform = value;
					dirtyMask |= 1u;
				}
			}
		}

		public Rect scale9Grid
		{
			get
			{
				return m_Scale9Rect;
			}
			set
			{
				m_HasScale9 = true;
				m_Scale9Rect = value;
				OnSetScale9Grid(value);
			}
		}

		public List<TweenerObj> tweens
		{
			get
			{
				return m_Tweens;
			}
			set
			{
				m_Tweens = value;
			}
		}

		public DisplayObject()
		{
			m_Matrix = new Matrix();
			m_FullMatrix = new Matrix();
			m_BoundsRect = new Rectangle();
			m_Alpha = 1f;
			m_Visible = true;
			m_scaleX = 1f;
			m_scaleY = 1f;
		}

		public Matrix getFullMatrix()
		{
			return getFullMatrix(null);
		}

		public Matrix getFullMatrix(Matrix childMatrixIn)
		{
			if (m_MatrixDirty || m_GroupMatrixDirty)
			{
				updateMatrix();
			}
			if (childMatrixIn == null)
			{
				return m_FullMatrix.clone();
			}
			return childMatrixIn.mult(m_FullMatrix);
		}

		public Matrix _fastGetFullMatrixRef()
		{
			if (m_MatrixDirty || m_GroupMatrixDirty)
			{
				updateMatrix();
			}
			return m_FullMatrix;
		}

		public void setBounds(Rectangle b)
		{
			m_BoundsRect = b;
		}

		public Rectangle getBounds(DisplayObject targetIn)
		{
			updateMatrix();
			updateBounds();
			if (targetIn == null)
			{
				targetIn = this;
			}
			Matrix matrix = m_FullMatrix.clone();
			matrix.concat(targetIn.m_FullMatrix.clone().invert());
			return matrix.transformRect(m_BoundsRect);
		}

		public virtual void updateBounds()
		{
			m_BoundsRect = new Rectangle();
		}

		public Matrix getMatrix()
		{
			if (m_MatrixDirty || m_GroupMatrixDirty)
			{
				updateMatrix();
			}
			return m_Matrix.clone();
		}

		public Matrix getMatrixRaw()
		{
			return m_Matrix.clone();
		}

		public void setMatrix(Matrix inMatrix)
		{
			m_OverrideMatrix = false;
			m_Matrix = inMatrix.clone();
			m_Rotation = inMatrix.getRotation();
			m_scaleX = inMatrix.getScaleX();
			m_scaleY = inMatrix.getScaleY();
			m_x = inMatrix.tx;
			m_y = inMatrix.ty;
			invalidateMatrix(true);
		}

		public void setMatrixOverride(Matrix inMatrix)
		{
			inMatrix.copyTo(m_Matrix);
			m_OverrideMatrix = true;
			invalidateMatrix(false);
		}

		public void setMatrixOverride(SMatrix inMatrix, bool force = false)
		{
			m_OverrideMatrix = true;
			inMatrix.copyToMatrix(m_Matrix);
			invalidateMatrix(false);
		}

		internal Matrix _getFullMatrix_updateMatrix(Matrix allocMatrix, Matrix childMatrixIn)
		{
			if (m_MatrixDirty || m_GroupMatrixDirty)
			{
				updateMatrix();
			}
			if (childMatrixIn == null)
			{
				m_FullMatrix.copyTo(allocMatrix);
				return allocMatrix;
			}
			childMatrixIn.copyTo(allocMatrix);
			allocMatrix.multNoCopy(m_FullMatrix);
			return allocMatrix;
		}

		protected void updateMatrix()
		{
			if (!m_MatrixDirty && (!m_GroupMatrixDirty || parent == null))
			{
				return;
			}
			if (m_GroupMatrixDirty && parent != null)
			{
				parent.updateMatrix();
			}
			if (!m_OverrideMatrix && m_MatrixDirty)
			{
				m_Matrix.b = (m_Matrix.c = (m_Matrix.tx = (m_Matrix.ty = 0f)));
				m_Matrix.a = m_scaleX;
				m_Matrix.d = m_scaleY;
				float num = (float)((double)m_Rotation * Math.PI / 180.0);
				if ((double)num != 0.0)
				{
					m_Matrix.rotate(num);
				}
				m_Matrix.tx = m_x;
				m_Matrix.ty = m_y;
			}
			if (parent != null)
			{
				parent._getFullMatrix_updateMatrix(m_FullMatrix, m_Matrix);
			}
			else
			{
				m_Matrix.copyTo(m_FullMatrix);
			}
			m_MatrixDirty = false;
			m_GroupMatrixDirty = false;
		}

		public DisplayObject getObjectUnderPoint(float x, float y)
		{
			return getObjectUnderPoint(new Vector2(x, y));
		}

		public virtual DisplayObject getObjectUnderPoint(Vector2 point)
		{
			return null;
		}

		public Vector2 localToGlobal(Vector2 point)
		{
			return m_FullMatrix.transformPoint(point);
		}

		public Vector2 globalToLocal(float x, float y)
		{
			updateMatrix();
			return globalToLocalFastStatic(x, y);
		}

		internal Vector2 globalToLocalFastStatic(float inPos_x, float inPos_y)
		{
			updateMatrix();
			float b = m_FullMatrix.b;
			float c = m_FullMatrix.c;
			float num = m_FullMatrix.a * m_FullMatrix.d - m_FullMatrix.b * m_FullMatrix.c;
			float num3;
			float num2;
			float num4;
			float num5;
			if (num == 0f)
			{
				num3 = (b = (c = (num2 = 0f)));
				num4 = 0f - m_FullMatrix.tx;
				num5 = 0f - m_FullMatrix.ty;
			}
			else
			{
				num = 1f / num;
				float num6 = m_FullMatrix.d * num;
				num2 = m_FullMatrix.a * num;
				num3 = num6;
				b *= 0f - num;
				c *= 0f - num;
				float num7 = (0f - num3) * m_FullMatrix.tx - c * m_FullMatrix.ty;
				num5 = (0f - b) * m_FullMatrix.tx - num2 * m_FullMatrix.ty;
				num4 = num7;
			}
			_res_globalToLocalFastStatic.x = inPos_x * num3 + inPos_y * c + num4;
			_res_globalToLocalFastStatic.y = inPos_x * b + inPos_y * num2 + num5;
			return _res_globalToLocalFastStatic;
		}

		public Vector2 globalToLocal(Vector2 inPos)
		{
			return globalToLocal(inPos.x, inPos.y);
		}

		public float getInheritedAlpha()
		{
			if (parent == null)
			{
				return m_Alpha;
			}
			return m_Alpha * parent.getInheritedAlpha();
		}

		public Color getInheritedColor()
		{
			m_ColorTransform.a = m_Alpha;
			if (parent == null)
			{
				return m_ColorTransform;
			}
			return m_ColorTransform * parent.getInheritedColor();
		}

		public int getInheritedBlendMode()
		{
			if (m_BlendMode != 0)
			{
				return m_BlendMode;
			}
			if (parent == null)
			{
				return m_BlendMode;
			}
			return parent.getInheritedBlendMode();
		}

		internal DisplayObject getInheritedMask()
		{
			if (mask != null)
			{
				return mask;
			}
			if (parent == null)
			{
				return mask;
			}
			return parent.getInheritedMask();
		}

		internal Rect getInheritedClipRect()
		{
			ref Rect globalClipRect = ref m_GlobalClipRect;
			float num = 0f;
			m_GlobalClipRect.height = num;
			num = num;
			m_GlobalClipRect.width = num;
			num = num;
			m_GlobalClipRect.y = num;
			globalClipRect.x = num;
			if (rotation != 0f || scaleX < 0f || scaleY < 0f)
			{
				return m_GlobalClipRect;
			}
			if (m_HasClipRect)
			{
				m_GlobalClipRect.x = m_LocalClipRect.x * m_FullMatrix.a + m_LocalClipRect.y * m_FullMatrix.c + m_FullMatrix.tx;
				m_GlobalClipRect.y = m_LocalClipRect.x * m_FullMatrix.b + m_LocalClipRect.y * m_FullMatrix.d + m_FullMatrix.ty;
				m_GlobalClipRect.width = m_FullMatrix.a * m_LocalClipRect.width;
				m_GlobalClipRect.height = m_FullMatrix.d * m_LocalClipRect.height;
				if (parent != null)
				{
					Rect inheritedClipRect = parent.getInheritedClipRect();
					Rectangle rectangle = new Rectangle(inheritedClipRect.x, inheritedClipRect.y, inheritedClipRect.width, inheritedClipRect.height);
					Rectangle toIntersect = new Rectangle(m_GlobalClipRect.x, m_GlobalClipRect.y, m_GlobalClipRect.width, m_GlobalClipRect.height);
					Rectangle rectangle2 = rectangle.intersection(toIntersect);
					if (inheritedClipRect.width != 0f && inheritedClipRect.height != 0f)
					{
						if (rectangle2.width != 0f && rectangle2.height != 0f)
						{
							m_GlobalClipRect = rectangle2.rect;
						}
						else
						{
							m_GlobalClipRect.x -= 100000f;
						}
					}
				}
				return m_GlobalClipRect;
			}
			if (parent == null)
			{
				return m_GlobalClipRect;
			}
			return parent.getInheritedClipRect();
		}

		internal virtual void _onSizeChange()
		{
		}

		internal void setParent(DisplayObjectContainer inParent)
		{
			if (m_Parent == inParent)
			{
				return;
			}
			if (m_Parent != null)
			{
			}
			dirtyMask |= 1u;
			m_Parent = inParent;
			Stage stage = this.stage;
			if (m_Parent != null)
			{
				this.stage = m_Parent.stage;
			}
			OnSetParent(inParent);
			OnSetAlpha();
			OnSetVisble();
			if (stage == null && this.stage != null)
			{
				dispatchEvent(new CEvent(CEvent.ADDED_TO_STAGE));
			}
			_cacheInternal();
			if (m_Parent == null)
			{
				if (this.stage != null)
				{
					dispatchEvent(new CEvent(CEvent.REMOVED_FROM_STAGE));
				}
				this.stage = null;
			}
		}

		protected virtual void OnSetParent(DisplayObjectContainer inParent)
		{
		}

		internal virtual void _cacheInternal()
		{
			Stage stage = this.stage;
			if (m_Parent != null)
			{
				this.stage = m_Parent.stage;
			}
			if (this.stage != null)
			{
				if (stage == null)
				{
					dispatchEvent(new CEvent(CEvent.ADDED_TO_STAGE));
				}
				if (m_LocalClipRect.width > 0f && m_LocalClipRect.height > 0f)
				{
					this.stage.m_HasClipRect = true;
				}
			}
			else if (stage != null)
			{
				dispatchEvent(new CEvent(CEvent.REMOVED_FROM_STAGE));
			}
		}

		internal virtual void _destoryImpl()
		{
		}

		protected virtual void OnSetAlpha()
		{
		}

		protected virtual void OnSetVisble()
		{
		}

		public virtual void updateFrame(CEvent e)
		{
			if (m_HasEnterFrameListeners)
			{
				e.currentTarget = this;
				dispatchEvent(e);
			}
			if (m_Tweens != null)
			{
				for (int i = 0; i < m_Tweens.Count; i++)
				{
					TweenerObj tweenerObj = m_Tweens[i];
					tweenerObj.tweenUpdate();
				}
				for (int j = 0; j < m_Tweens.Count; j++)
				{
					TweenerObj tweenerObj2 = m_Tweens[j];
					tweenerObj2.targetDisplayObj = this;
					if (tweenerObj2.percentage >= 1f && tweenerObj2.isCompleted)
					{
						m_Tweens.Remove(tweenerObj2);
						break;
					}
				}
			}
			if (!m_Dragging)
			{
				return;
			}
			if (parent == null)
			{
				m_Dragging = false;
				return;
			}
			x = parent.mouseX - m_DragStartPos.x;
			y = parent.mouseY - m_DragStartPos.y;
			if (x < m_DragConstrainRect.x)
			{
				x = m_DragConstrainRect.x;
			}
			if (x > m_DragConstrainRect.x + m_DragConstrainRect.width)
			{
				x = m_DragConstrainRect.x + m_DragConstrainRect.width;
			}
			if (y < m_DragConstrainRect.y)
			{
				y = m_DragConstrainRect.y;
			}
			if (y > m_DragConstrainRect.y + m_DragConstrainRect.height)
			{
				y = m_DragConstrainRect.y + m_DragConstrainRect.height;
			}
		}

		protected override void _eventAdded(string type)
		{
			if (type == CEvent.ENTER_FRAME)
			{
				m_HasEnterFrameListeners = true;
			}
		}

		protected override void _eventRemoved(string type)
		{
			if (type == CEvent.ENTER_FRAME)
			{
				m_HasEnterFrameListeners = willTrigger(CEvent.ENTER_FRAME);
			}
		}

		public virtual void invalidateMatrix(bool isLocal)
		{
			m_GroupMatrixDirty = m_GroupMatrixDirty || !isLocal;
			m_MatrixDirty = m_GroupMatrixDirty || isLocal;
			dirtyMask |= 1u;
			if (m_OverrideMatrix && isLocal)
			{
				m_OverrideMatrix = false;
				m_x = m_Matrix.tx;
				m_y = m_Matrix.ty;
				m_Rotation = m_Matrix.getRotation();
				m_scaleX = m_Matrix.getScaleX();
				m_scaleY = m_Matrix.getScaleY();
				if (m_HasScale9)
				{
					rebuildScale9Grid();
				}
			}
			if (m_HasClipRect)
			{
				m_ClipRectDirty = true;
			}
			m_MatrixInvalidateCnt++;
		}

		public virtual DisplayObject getChildByName(string name)
		{
			return null;
		}

		public T getChildByName<T>(string name) where T : DisplayObject
		{
			DisplayObject childByName = getChildByName(name);
			if (!(childByName is T))
			{
				if (childByName != null)
				{
					Debug.LogError(string.Concat("getChildByName<", typeof(T), ">( '", name, "' ) failed to cast, got: ", childByName.GetType(), ", did you remember export the symbol from Flash?"));
				}
				return (T)null;
			}
			return childByName as T;
		}

		public virtual DisplayObject getChildAt(int id)
		{
			return null;
		}

		public T getChildAt<T>(int id) where T : DisplayObject
		{
			return getChildAt(id) as T;
		}

		public void setBlendmodeChildren(int mode)
		{
			blendMode = mode;
			if (!(this is DisplayObjectContainer))
			{
				return;
			}
			for (int i = 0; i < (this as DisplayObjectContainer).numChildren; i++)
			{
				DisplayObject childAt = (this as DisplayObjectContainer).getChildAt(i);
				if (childAt is DisplayObjectContainer)
				{
					(childAt as DisplayObjectContainer).setBlendmodeChildren(mode);
				}
			}
		}

		public void setColorTransformChildren(Color col)
		{
			colorTransform = col;
			if (!(this is DisplayObjectContainer))
			{
				return;
			}
			for (int i = 0; i < (this as DisplayObjectContainer).numChildren; i++)
			{
				DisplayObject childAt = (this as DisplayObjectContainer).getChildAt(i);
				if (childAt is DisplayObjectContainer)
				{
					(childAt as DisplayObjectContainer).colorTransform = col;
				}
			}
		}

		public override string ToString()
		{
			return string.Concat(GetType(), "(", name, ")");
		}

		public virtual void broadcastEvent(CEvent e)
		{
			dispatchEvent(e);
		}

		public virtual void fireEvent(CEvent e)
		{
			e.eventPhase = EventPhase.AT_TARGET;
			e.target = this;
			e.currentTarget = this;
			dispatchEvent(e);
			if (!e.isCancelled() && e.bubbles)
			{
				e.eventPhase = EventPhase.BUBBLING_PHASE;
				if (m_Parent != null)
				{
					m_Parent.childFireBubblingEvent(e);
				}
			}
		}

		internal virtual void childFireBubblingEvent(CEvent e)
		{
			e.currentTarget = this;
			dispatchEvent(e);
			if (!e.isCancelled() && m_Parent != null)
			{
				m_Parent.childFireBubblingEvent(e);
			}
		}

		internal Matrix testGetMatrix()
		{
			if (parent != null)
			{
				return getMatrix().mult(parent.testGetMatrix());
			}
			return getMatrix();
		}

		public void startDrag()
		{
			startDrag(false, new Rect(-99999f, -99999f, 199998f, 199998f));
		}

		public void startDrag(bool stopOnStageUp)
		{
			startDrag(stopOnStageUp, new Rect(-99999f, -99999f, 199998f, 199998f));
		}

		public void startDrag(bool stopOnStageUp, Rect constrainRect)
		{
			if (!m_Dragging)
			{
				m_Dragging = true;
				m_DragStartPos.x = mouseX;
				m_DragStartPos.y = mouseY;
				m_DragConstrainRect = constrainRect;
				if (stopOnStageUp && stage != null)
				{
					stage.addEventListener(MouseEvent.MOUSE_UP, onDragStageMouseUp);
				}
			}
		}

		protected void onDragStageMouseUp(CEvent e)
		{
			(e.currentTarget as EventDispatcher).removeEventListener(MouseEvent.MOUSE_UP, onDragStageMouseUp);
			stopDrag();
		}

		public void stopDrag()
		{
			if (m_Dragging)
			{
				m_Dragging = false;
			}
		}

		protected virtual void OnSetScale9Grid(Rect rect)
		{
		}

		protected virtual void rebuildScale9Grid()
		{
		}
	}
}
