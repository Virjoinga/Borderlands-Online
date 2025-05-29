using System;
using System.Collections.Generic;

[Serializable]
public class ComposableMaterial
{
	public string m_sMaterial;

	public string m_sShader;

	public List<string> m_sTexName;

	public List<string> m_sTexFileName;

	public List<ShaderProperty> m_sShaderProperties;

	public ComposableMaterial()
	{
		m_sTexName = new List<string>();
		m_sTexFileName = new List<string>();
		m_sShaderProperties = new List<ShaderProperty>();
	}
}
