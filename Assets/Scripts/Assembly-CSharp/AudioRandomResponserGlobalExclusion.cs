using System.Collections.Generic;
using System.Linq;
using A;
using UnityEngine;

public class AudioRandomResponserGlobalExclusion : c1ee7921b0c3cce194fb7cae41b5a9d82<AudioRandomResponserGlobalExclusion>
{
	private class VariationRegistry
	{
		private List<int> m_variations = new List<int>();

		private bool m_empty;

		private int m_count = -1;

		public VariationRegistry(int c9b15165c908ac1f9e9396c57137d3a67)
		{
			m_count = c9b15165c908ac1f9e9396c57137d3a67;
			Reset();
		}

		public int c4e225d735830d0a56ebb20e99126ef21()
		{
			return m_count;
		}

		public int cb0ecef4c16552f6a35841d9e172c5501()
		{
			return m_variations.Count;
		}

		public void Reset()
		{
			m_empty = false;
			m_variations.Clear();
			m_variations.AddRange(Enumerable.Range(0, m_count));
		}

		public int c91981f6f625269653864723407355244(int c897b8835bcabb2236d77c1847574ddbf)
		{
			int result = -1;
			if (!m_empty)
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
				int num = Random.Range(0, m_variations.Count);
				bool flag = m_variations.Count == 1;
				if (!flag)
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
					if (m_variations[num] == c897b8835bcabb2236d77c1847574ddbf)
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
						num = (num + 1) % m_variations.Count;
					}
				}
				result = m_variations[num];
				m_variations.RemoveAt(num);
				if (flag)
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
					m_empty = true;
				}
			}
			return result;
		}
	}

	private Dictionary<string, VariationRegistry> m_data = new Dictionary<string, VariationRegistry>();

	public void Reset()
	{
		m_data.Clear();
	}

	public void c766f96b9a191c766ab6ba852f923d296()
	{
		Dictionary<string, VariationRegistry>.Enumerator enumerator = m_data.GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.Value.Reset();
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

	public int c3ec92e17a377a835b74cf48e005fe134(string c45fd7f5a766449817c6df573f08ae226, int cd071bb754bcf7d9444da586dc51ac239, int c897b8835bcabb2236d77c1847574ddbf)
	{
		VariationRegistry value = null;
		if (!m_data.TryGetValue(c45fd7f5a766449817c6df573f08ae226, out value))
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
			value = new VariationRegistry(cd071bb754bcf7d9444da586dc51ac239);
			m_data.Add(c45fd7f5a766449817c6df573f08ae226, value);
		}
		return value.c91981f6f625269653864723407355244(c897b8835bcabb2236d77c1847574ddbf);
	}
}
