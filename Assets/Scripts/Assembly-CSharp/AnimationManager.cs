using System;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
	public virtual void c05d2e80683acf62635b2b48542fa4468(EntityWeapon c39409683a32e09391d094314ffeae2b5)
	{
		throw new NotImplementedException();
	}

	public virtual void OnPickUpWeapon(EntityWeapon weapon)
	{
	}

	public virtual void OnSwitchWeapon(EntityWeapon weapon)
	{
	}

	public virtual void OnAttack()
	{
	}

	public virtual void OnReload(float compensation)
	{
	}

	public virtual void OnMelee()
	{
	}

	public virtual void OnDamaged(DamageInfo damageInfo)
	{
	}

	public virtual void OnThrow(float networkLatency, AnimationPlayerThrowGrenadeState.SpawnGrenadeDelegate spawnGrenadeDelegate)
	{
	}

	public virtual void OnTeleportMe(Vector3 teleportPos)
	{
	}

	public virtual void OnReceiveEvent(string eventData)
	{
	}
}
