using System.Collections.Generic;
using System.Xml.Serialization;
using A;

namespace XsdSettings
{
	public class SubPartStoreSetup
	{
		private Dictionary<int, SubPartWpn> m_subPartsLUT = new Dictionary<int, SubPartWpn>();

		private SubPartWpn[] m_subPartsField;

		[XmlArrayItem("m_subPart", IsNullable = false)]
		public SubPartWpn[] m_subParts { get; set; }

		public void c10568ff59003f0becf08e88b8999ff8c()
		{
			m_subPartsLUT.Clear();
			for (int i = 0; i < m_subParts.Length; i++)
			{
				int hashCode = m_subParts[i].GetHashCode();
				m_subPartsLUT.Add(hashCode, m_subParts[i]);
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

		public SubPartWpn cdbf696aded5fd1b462c05fbd81522f65(int c875cb4aedab4dbd285f491b3440727ec)
		{
			SubPartWpn value = c21251f15e39f11db1a742cbb3e4aaa17.c7088de59e49f7108f520cf7e0bae167e;
			m_subPartsLUT.TryGetValue(c875cb4aedab4dbd285f491b3440727ec, out value);
			return value;
		}

		public List<SubPartWpn> c3c1ff2c867c8723c994fdc468d25c139(WeaponSubPart cbc817ea23a983bd92590f4718c628968)
		{
			List<SubPartWpn> list = new List<SubPartWpn>();
			using (Dictionary<int, SubPartWpn>.Enumerator enumerator = m_subPartsLUT.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<int, SubPartWpn> current = enumerator.Current;
					if (current.Value.m_Index < 0)
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
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
					}
					else if (current.Value.m_partType != cbc817ea23a983bd92590f4718c628968)
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
					}
					else
					{
						list.Add(current.Value);
					}
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					return list;
				}
			}
		}
	}
}
