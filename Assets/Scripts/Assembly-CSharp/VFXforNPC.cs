using System;
using UnityEngine;

[Serializable]
public class VFXforNPC
{
	public ENPCParticleType m_type;

	[HideInInspector]
	public GameObject m_particleGameObject;

	public string m_particleGameObjectName;

	[HideInInspector]
	public ParticleSystem m_particle;

	public Transform m_particleTransform;

	[HideInInspector]
	public Utils.Timer m_timer = new Utils.Timer();

	public string m_audioEvent = string.Empty;

	public string m_boneParent = string.Empty;

	[HideInInspector]
	public Transform m_boneTr;
}
