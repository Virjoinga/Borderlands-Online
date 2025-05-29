using System;
using System.Collections.Generic;
using UnityEngine;

namespace pumpkin.displayInternal
{
	public class FastList<T>
	{
		private const int ALLOC_BLOCK_SZ = 32;

		public T[] m_Buffer;

		public int Size = 0;

		public int Count
		{
			get
			{
				return Size;
			}
		}

		public T this[int i]
		{
			get
			{
				return m_Buffer[i];
			}
			set
			{
				m_Buffer[i] = value;
			}
		}

		private void _moreElements()
		{
			T[] array = null;
			array = ((m_Buffer == null) ? new T[32] : new T[Mathf.Max(m_Buffer.Length << 1, 32)]);
			if (m_Buffer != null && Size > 0)
			{
				m_Buffer.CopyTo(array, 0);
			}
			m_Buffer = array;
		}

		private void _trimElements()
		{
			if (Size > 0)
			{
				if (Size < m_Buffer.Length)
				{
					T[] array = new T[Size];
					for (int i = 0; i < Size; i++)
					{
						array[i] = m_Buffer[i];
					}
					m_Buffer = array;
				}
			}
			else
			{
				m_Buffer = null;
			}
		}

		public void Clear()
		{
			Size = 0;
		}

		public void Release()
		{
			Size = 0;
			m_Buffer = null;
		}

		public void Add(T item)
		{
			if (m_Buffer == null || Size == m_Buffer.Length)
			{
				_moreElements();
			}
			m_Buffer[Size++] = item;
		}

		public void Remove(T item)
		{
			if (m_Buffer == null)
			{
				return;
			}
			EqualityComparer<T> @default = EqualityComparer<T>.Default;
			for (int i = 0; i < Size; i++)
			{
				if (@default.Equals(m_Buffer[i], item))
				{
					Size--;
					m_Buffer[i] = default(T);
					for (int j = i; j < Size; j++)
					{
						m_Buffer[j] = m_Buffer[j + 1];
					}
					break;
				}
			}
		}

		public void RemoveAt(int index)
		{
			if (m_Buffer != null && index < Size)
			{
				Size--;
				m_Buffer[index] = default(T);
				for (int i = index; i < Size; i++)
				{
					m_Buffer[i] = m_Buffer[i + 1];
				}
			}
		}

		public T[] ToArray()
		{
			_trimElements();
			return m_Buffer;
		}

		public int IndexOf(T item)
		{
			if (m_Buffer == null)
			{
				return -1;
			}
			int num = Array.IndexOf(m_Buffer, item);
			if (num >= Size)
			{
				return -1;
			}
			return num;
		}

		public T GetUnused()
		{
			if (m_Buffer == null)
			{
				return default(T);
			}
			for (int i = 0; i < m_Buffer.Length; i++)
			{
				if (i >= Size && m_Buffer[i] != null)
				{
					return m_Buffer[i];
				}
			}
			return default(T);
		}

		public T GetUnusedList()
		{
			if (m_Buffer == null)
			{
				return default(T);
			}
			for (int i = Size; i < m_Buffer.Length; i++)
			{
				if (m_Buffer[i] != null)
				{
					return m_Buffer[i];
				}
			}
			return default(T);
		}

		public void Reverse()
		{
			if (Size > 1 && m_Buffer != null)
			{
				Array.Reverse(m_Buffer, 0, Size);
			}
		}

		public void ClearReferences()
		{
			Array.Clear(m_Buffer, 0, m_Buffer.Length);
		}

		public IEnumerator<T> GetEnumerator()
		{
			if (m_Buffer != null)
			{
				for (int i = 0; i < Size; i++)
				{
					yield return m_Buffer[i];
				}
			}
		}

		public void resizeToCount()
		{
			if (m_Buffer != null && m_Buffer.Length != Size)
			{
				Array.Resize(ref m_Buffer, Size);
			}
		}
	}
}
