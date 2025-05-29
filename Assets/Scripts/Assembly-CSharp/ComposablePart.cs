using System;
using System.Collections.Generic;

[Serializable]
public class ComposablePart
{
	public string m_sPartName;

	public List<ComposableFBX> m_aFbxs;

	private ComposablePart()
	{
	}

	public ComposablePart(string c31a1a67ede8fc96d9be330cb5f09ae98)
	{
		m_sPartName = c31a1a67ede8fc96d9be330cb5f09ae98;
		m_aFbxs = new List<ComposableFBX>();
	}
}
