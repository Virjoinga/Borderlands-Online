using UnityEngine;

namespace pumpkin.geom
{
	public class Rectangle
	{
		public Rect rect = default(Rect);

		public float x
		{
			get
			{
				return rect.x;
			}
			set
			{
				rect.x = value;
			}
		}

		public float y
		{
			get
			{
				return rect.y;
			}
			set
			{
				rect.y = value;
			}
		}

		public float width
		{
			get
			{
				return rect.width;
			}
			set
			{
				rect.width = value;
			}
		}

		public float height
		{
			get
			{
				return rect.height;
			}
			set
			{
				rect.height = value;
			}
		}

		public float left
		{
			get
			{
				return x;
			}
			set
			{
				width -= value - x;
				x = value;
			}
		}

		public float top
		{
			get
			{
				return y;
			}
			set
			{
				height -= value - y;
				y = value;
			}
		}

		public float right
		{
			get
			{
				return x + width;
			}
			set
			{
				width = value - x;
			}
		}

		public float bottom
		{
			get
			{
				return y + height;
			}
			set
			{
				height = value - y;
			}
		}

		public Rectangle()
		{
		}

		public Rectangle(Rect rect)
		{
			this.rect = rect;
		}

		public Rectangle(float x, float y, float width, float height)
		{
			rect = new Rect(x, y, width, height);
		}

		internal Rectangle extendBounds(Rectangle r)
		{
			float num = x - r.x;
			if (num > 0f)
			{
				x -= num;
				width += num;
			}
			float num2 = y - r.y;
			if (num2 > 0f)
			{
				y -= num2;
				height += num2;
			}
			if (r.right > right)
			{
				right = r.right;
			}
			if (r.bottom > bottom)
			{
				bottom = r.bottom;
			}
			return this;
		}

		public Rectangle clone()
		{
			return new Rectangle(x, y, width, height);
		}

		public bool contains(float inX, float inY)
		{
			return inX >= x && inY >= y && inX < right && inY < bottom;
		}

		public override string ToString()
		{
			return "Rectangle(" + x + ", " + y + ", " + width + ", " + height + ")";
		}

		public Rectangle intersection(Rectangle toIntersect)
		{
			float num = ((!(x < toIntersect.x)) ? x : toIntersect.x);
			float num2 = ((!(right > toIntersect.right)) ? right : toIntersect.right);
			if (num2 <= num)
			{
				return new Rectangle();
			}
			float num3 = ((!(y < toIntersect.y)) ? y : toIntersect.y);
			float num4 = ((!(bottom > toIntersect.bottom)) ? bottom : toIntersect.bottom);
			if (num4 <= num3)
			{
				return new Rectangle();
			}
			return new Rectangle(num, num3, num2 - num, num4 - num3);
		}
	}
}
