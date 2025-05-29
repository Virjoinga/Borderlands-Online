namespace pumpkin.displayInternal
{
	public class IntArrayPool<T>
	{
		public FastList<T[]> pool = new FastList<T[]>();

		public void addArray(T[] data)
		{
			int count = pool.Count;
			for (int i = 0; i < count; i++)
			{
				if (pool[i] == null)
				{
					pool[i] = data;
					return;
				}
			}
			pool.Add(data);
		}

		public T[] popArray(int allocSz, bool doAlloc)
		{
			int count = pool.Count;
			for (int i = 0; i < count; i++)
			{
				T[] array = pool[i];
				if (array != null && array.Length == allocSz)
				{
					pool[i] = null;
					return array;
				}
			}
			if (doAlloc)
			{
				return new T[allocSz];
			}
			return null;
		}
	}
}
