namespace pumpkin.geom.structs
{
	public struct SMatrix
	{
		public float a;

		public float b;

		public float c;

		public float d;

		public float tx;

		public float ty;

		public static SMatrix identity
		{
			get
			{
				SMatrix result = default(SMatrix);
				result.a = 1f;
				result.b = 0f;
				result.c = 0f;
				result.d = 1f;
				result.tx = 0f;
				result.ty = 0f;
				return result;
			}
		}

		public SMatrix(float a, float b, float c, float d, float tx, float ty)
		{
			this.a = a;
			this.b = b;
			this.c = c;
			this.d = d;
			this.tx = tx;
			this.ty = ty;
		}

		public void copyToStruct(ref SMatrix to)
		{
			to.a = a;
			to.b = b;
			to.c = c;
			to.d = d;
			to.tx = tx;
			to.ty = ty;
		}

		public void copyToMatrix(Matrix to)
		{
			to.a = a;
			to.b = b;
			to.c = c;
			to.d = d;
			to.tx = tx;
			to.ty = ty;
		}

		public bool equals(Matrix other)
		{
			return a == other.a && b == other.b && c == other.c && d == other.d && tx == other.tx && ty == other.ty;
		}

		public bool equals(ref SMatrix other)
		{
			return a == other.a && b == other.b && c == other.c && d == other.d && tx == other.tx && ty == other.ty;
		}
	}
}
