using System;
using UnityEngine;

[Serializable]
public class BadAssCharacterMotorMovement
{
	[NonSerialized]
	public CollisionFlags collisionFlags;

	[NonSerialized]
	public Vector3 velocity;

	[NonSerialized]
	public Vector3 frameVelocity = Vector3.zero;

	[NonSerialized]
	public Vector3 hitPoint = Vector3.zero;

	[NonSerialized]
	public Vector3 lastHitPoint = Vector3.zero;

	[NonSerialized]
	public Vector3 lastHitNormal = Vector3.zero;

	[NonSerialized]
	public Vector3 frameOffset = Vector3.zero;
}
