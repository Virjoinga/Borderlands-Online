using System;
using UnityEngine;

[Serializable]
public class ImpactSetup
{
	public string m_impactType;

	public ParticleSystem m_particuleSystem;

	public Vector3 m_decalSize = new Vector3(0.22f, 0.22f, 0.22f);

	public Texture2D[] m_texture;

	public Material m_material;
}
