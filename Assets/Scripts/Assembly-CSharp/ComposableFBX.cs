using System;
using System.Collections.Generic;

[Serializable]
public class ComposableFBX
{
	public string m_sFileName;

	public List<ComposableMaterial> m_aMaterials;

	public ComposableFBX()
	{
		m_aMaterials = new List<ComposableMaterial>();
	}
}
