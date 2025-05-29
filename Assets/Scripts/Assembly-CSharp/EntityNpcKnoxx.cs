using UnityEngine;

public class EntityNpcKnoxx : EntityNpc
{
	public Transform m_lunchPointLeft;

	public Transform m_lunchPointRight;

	public override ENPCParticleType cfa1f39f0f16c281e2062553416590dbb(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c, WeakPoint c38b98045365f4b50a4fbe3f1d89af089)
	{
		return ENPCParticleType.E_DamageOnArmor;
	}
}
