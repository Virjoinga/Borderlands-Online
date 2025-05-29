using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace A
{
	public class c46099de2cc6e7023f3abcc78fd614b34<c272566d4edbf24bb8c4df6114a524ac9> : IEnumerable, IList<c272566d4edbf24bb8c4df6114a524ac9>, ICollection<c272566d4edbf24bb8c4df6114a524ac9>, IEnumerable<c272566d4edbf24bb8c4df6114a524ac9>
	{
		private c272566d4edbf24bb8c4df6114a524ac9[] ca3466b467e402ee0a8e34e1a4f350462;

		private int c04ba525bab5d8f8fabbbacc4a40f4d21;

		private long c3b11636d98707dcbbc9934994f0e0fab;

		[CompilerGenerated]
		private int c6d7796a8116f9c2ac25f1231b6a86942;

		[CompilerGenerated]
		private int c1138a5b19fa55c747f85dad42b25358a;

		private bool c25642826fe08681b57a8f3352d36a087
		{
			get
			{
				return false;
			}
		}

		public c272566d4edbf24bb8c4df6114a524ac9 this[int index]
		{
			get
			{
				if (index >= 0)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (index < Count)
					{
						int num = (c04ba525bab5d8f8fabbbacc4a40f4d21 - Count + index + Capacity) % Capacity;
						return ca3466b467e402ee0a8e34e1a4f350462[num];
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				throw new IndexOutOfRangeException();
			}
			set
			{
				Insert(index, value);
			}
		}

		public int Capacity
		{
			[CompilerGenerated]
			get
			{
				return c6d7796a8116f9c2ac25f1231b6a86942;
			}
			[CompilerGenerated]
			private set
			{
				c6d7796a8116f9c2ac25f1231b6a86942 = value;
			}
		}

		public int Count
		{
			[CompilerGenerated]
			get
			{
				return c1138a5b19fa55c747f85dad42b25358a;
			}
			[CompilerGenerated]
			private set
			{
				c1138a5b19fa55c747f85dad42b25358a = value;
			}
		}

		public c46099de2cc6e7023f3abcc78fd614b34(int ca7647c1955daedb45f4af47781bd2c64)
		{
			if (ca7647c1955daedb45f4af47781bd2c64 <= 0)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						throw new ArgumentException("Must be greater than zero", "capacity");
					}
				}
			}
			Capacity = ca7647c1955daedb45f4af47781bd2c64;
			ca3466b467e402ee0a8e34e1a4f350462 = new c272566d4edbf24bb8c4df6114a524ac9[ca7647c1955daedb45f4af47781bd2c64];
		}

		private IEnumerator c4a38a8641d1ad88bc0a042724815ce10()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in c4a38a8641d1ad88bc0a042724815ce10
			return this.c4a38a8641d1ad88bc0a042724815ce10();
		}

		public void Add(c272566d4edbf24bb8c4df6114a524ac9 item)
		{
			if (c04ba525bab5d8f8fabbbacc4a40f4d21 == int.MaxValue)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c04ba525bab5d8f8fabbbacc4a40f4d21 %= Capacity;
			}
			ca3466b467e402ee0a8e34e1a4f350462[c04ba525bab5d8f8fabbbacc4a40f4d21++ % Capacity] = item;
			if (Count < Capacity)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				Count += 1;
			}
			c3b11636d98707dcbbc9934994f0e0fab++;
		}

		public void Clear()
		{
			for (int i = 0; i < Capacity; i++)
			{
				ca3466b467e402ee0a8e34e1a4f350462[i] = default(c272566d4edbf24bb8c4df6114a524ac9);
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c04ba525bab5d8f8fabbbacc4a40f4d21 = 0;
				Count = 0;
				c3b11636d98707dcbbc9934994f0e0fab++;
				return;
			}
		}

		public bool Contains(c272566d4edbf24bb8c4df6114a524ac9 item)
		{
			int num = IndexOf(item);
			return num != -1;
		}

		public void CopyTo(c272566d4edbf24bb8c4df6114a524ac9[] array, int arrayIndex)
		{
			int num = array.Length;
			for (int i = 0; i < Count; i++)
			{
				array[(i + arrayIndex) % num] = ca3466b467e402ee0a8e34e1a4f350462[(c04ba525bab5d8f8fabbbacc4a40f4d21 - Count + i + Capacity) % Capacity];
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return;
			}
		}

		public IEnumerator<c272566d4edbf24bb8c4df6114a524ac9> GetEnumerator()
		{
			long num = c3b11636d98707dcbbc9934994f0e0fab;
			for (int i = 0; i < Count; i++)
			{
				if (num != c3b11636d98707dcbbc9934994f0e0fab)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							if (1 == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							throw new InvalidOperationException("Collection changed");
						}
					}
				}
				yield return this[i];
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					yield break;
				}
			}
		}

		public int IndexOf(c272566d4edbf24bb8c4df6114a524ac9 item)
		{
			for (int i = 0; i < Count; i++)
			{
				c272566d4edbf24bb8c4df6114a524ac9 val = ca3466b467e402ee0a8e34e1a4f350462[(c04ba525bab5d8f8fabbbacc4a40f4d21 - Count + i + Capacity) % Capacity];
				if (item == null)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (val == null)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								return i;
							}
						}
					}
				}
				if (item == null)
				{
					continue;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!item.Equals(val))
				{
					continue;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					return i;
				}
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				return -1;
			}
		}

		public void Insert(int index, c272566d4edbf24bb8c4df6114a524ac9 item)
		{
			if (index >= 0)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (index <= Count)
				{
					if (index == Count)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								Add(item);
								return;
							}
						}
					}
					int num = Math.Min(Count, Capacity - 1) - index;
					int num2 = (c04ba525bab5d8f8fabbbacc4a40f4d21 - Count + index + Capacity) % Capacity;
					for (int num3 = num2 + num; num3 > num2; num3--)
					{
						int num4 = num3 % Capacity;
						int num5 = (num3 - 1 + Capacity) % Capacity;
						ca3466b467e402ee0a8e34e1a4f350462[num4] = ca3466b467e402ee0a8e34e1a4f350462[num5];
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						ca3466b467e402ee0a8e34e1a4f350462[num2] = item;
						if (Count < Capacity)
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									continue;
								}
								break;
							}
							Count += 1;
							c04ba525bab5d8f8fabbbacc4a40f4d21++;
						}
						c3b11636d98707dcbbc9934994f0e0fab++;
						return;
					}
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			throw new IndexOutOfRangeException();
		}

		public bool Remove(c272566d4edbf24bb8c4df6114a524ac9 item)
		{
			int num = IndexOf(item);
			if (num == -1)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return false;
					}
				}
			}
			RemoveAt(num);
			return true;
		}

		public void RemoveAt(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (index < Count)
				{
					for (int i = index; i < Count - 1; i++)
					{
						int num = (c04ba525bab5d8f8fabbbacc4a40f4d21 - Count + i + Capacity) % Capacity;
						int num2 = (c04ba525bab5d8f8fabbbacc4a40f4d21 - Count + i + 1 + Capacity) % Capacity;
						ca3466b467e402ee0a8e34e1a4f350462[num] = ca3466b467e402ee0a8e34e1a4f350462[num2];
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						int num3 = (c04ba525bab5d8f8fabbbacc4a40f4d21 - 1 + Capacity) % Capacity;
						ca3466b467e402ee0a8e34e1a4f350462[num3] = default(c272566d4edbf24bb8c4df6114a524ac9);
						c04ba525bab5d8f8fabbbacc4a40f4d21--;
						Count -= 1;
						c3b11636d98707dcbbc9934994f0e0fab++;
						return;
					}
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			throw new IndexOutOfRangeException();
		}
	}
}
