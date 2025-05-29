namespace pumpkin.displayInternal
{
	public class IntGenerationalArrayPool<T>
	{
		public static bool useAlloc = false;

		public IntArrayPool<T>[] pools;

		public IntGenerationalArrayPool(int t)
		{
			pools = new IntArrayPool<T>[t];
			for (int i = 0; i < t; i++)
			{
				pools[i] = new IntArrayPool<T>();
			}
		}

		public void addArray(T[] data)
		{
			pools[0].addArray(data);
		}

		public T[] popArray(int allocSz)
		{
			if (useAlloc)
			{
				return new T[allocSz];
			}
			int num = pools.Length;
			for (int i = 0; i < num; i++)
			{
				T[] array = pools[i].popArray(allocSz, false);
				if (array != null)
				{
					return array;
				}
			}
			return new T[allocSz];
		}

		public void cycle()
		{
			IntArrayPool<T> intArrayPool = pools[pools.Length - 1];
			for (int num = pools.Length - 1; num >= 1; num--)
			{
				pools[num] = pools[num - 1];
			}
			pools[0] = intArrayPool;
			pools[0].pool.Clear();
		}
	}
}
