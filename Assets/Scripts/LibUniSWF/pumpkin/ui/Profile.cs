using System.Collections;

namespace pumpkin.ui
{
	public class Profile
	{
		protected Hashtable m_Values = new Hashtable();

		public bool Is(string name)
		{
			return m_Values.ContainsKey(name);
		}

		public void Set(string name, int num)
		{
			m_Values.Add(name, num);
		}
	}
}
