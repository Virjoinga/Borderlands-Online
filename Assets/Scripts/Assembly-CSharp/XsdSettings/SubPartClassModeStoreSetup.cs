using System.Collections.Generic;
using System.Xml.Serialization;
using A;

namespace XsdSettings
{
	public class SubPartClassModeStoreSetup
	{
		private Dictionary<int, SubPartClassMode> m_subPartsLUT = new Dictionary<int, SubPartClassMode>();

		private SubPartClassMode[] m_classModeSubpartsField;

		[XmlArrayItem("m_classModeSubpart", IsNullable = false)]
		public SubPartClassMode[] m_classModeSubparts { get; set; }

		public void c10568ff59003f0becf08e88b8999ff8c()
		{
			m_subPartsLUT.Clear();
			for (int i = 0; i < m_classModeSubparts.Length; i++)
			{
				int hashCode = m_classModeSubparts[i].GetHashCode();
				m_subPartsLUT.Add(hashCode, m_classModeSubparts[i]);
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

		public SubPartClassMode cdbf696aded5fd1b462c05fbd81522f65(int c875cb4aedab4dbd285f491b3440727ec)
		{
			SubPartClassMode value = cbd74752f9544c55edeeca4b9dd15b605.c7088de59e49f7108f520cf7e0bae167e;
			m_subPartsLUT.TryGetValue(c875cb4aedab4dbd285f491b3440727ec, out value);
			return value;
		}
	}
}
