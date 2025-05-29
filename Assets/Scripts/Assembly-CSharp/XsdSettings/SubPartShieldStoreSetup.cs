using System.Collections.Generic;
using System.Xml.Serialization;
using A;

namespace XsdSettings
{
	public class SubPartShieldStoreSetup
	{
		private Dictionary<int, SubPartShield> m_subPartsLUT = new Dictionary<int, SubPartShield>();

		private SubPartShield[] m_shieldSubpartsField;

		[XmlArrayItem("m_shieldSubpart", IsNullable = false)]
		public SubPartShield[] m_shieldSubparts { get; set; }

		public void c10568ff59003f0becf08e88b8999ff8c()
		{
			m_subPartsLUT.Clear();
			for (int i = 0; i < m_shieldSubparts.Length; i++)
			{
				int hashCode = m_shieldSubparts[i].GetHashCode();
				m_subPartsLUT.Add(hashCode, m_shieldSubparts[i]);
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

		public SubPartShield cdbf696aded5fd1b462c05fbd81522f65(int c875cb4aedab4dbd285f491b3440727ec)
		{
			SubPartShield value = cffe39c47f873f17b3701032cff16ff95.c7088de59e49f7108f520cf7e0bae167e;
			m_subPartsLUT.TryGetValue(c875cb4aedab4dbd285f491b3440727ec, out value);
			return value;
		}
	}
}
