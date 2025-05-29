using System;
using A;
using BHV;
using Core;
using UnityEngine;

[Serializable]
[AddComponentMenu("Character/BadAss Character Motor Lite")]
public class BadAssCharacterMotorLite : MonoBehaviour, IBadAssCharacterMotor
{
	public enum MovementTransferOnJump
	{
		None = 0,
		InitTransfer = 1,
		PermaTransfer = 2,
		PermaLocked = 3
	}

	[Serializable]
	public class CharacterMotorJumping
	{
		public bool enabled = true;

		public float baseHeight = 1.4f;

		public float extraHeight = 1f;

		public float perpAmount = 1f;

		public float steepPerpAmount = 0.5f;

		[NonSerialized]
		public bool jumping;

		[NonSerialized]
		public bool holdingJumpButton;

		[NonSerialized]
		public float lastStartTime;

		[NonSerialized]
		public float lastButtonDownTime = -100f;

		[NonSerialized]
		public Vector3 jumpDir = Vector3.up;
	}

	public BadAssCharacterMotorMovement movement = new BadAssCharacterMotorMovement();

	public CharacterMotorJumping jumping = new CharacterMotorJumping();

	private bool m_inputJump;

	private Vector3 m_desiredVelocity = Vector3.zero;

	private bool m_isGrounded = true;

	private Vector3 m_groundNormal = Vector3.zero;

	private Transform m_characterTransform;

	private EntityPlayer m_entityPlayer;

	private BHVTaskManager m_taskManager;

	private float m_gravityAcceleration;

	private float m_deltaTime;

	private float m_slopeLimit = 45f;

	private CapsuleCollider m_collider;

	private GameObject m_grounded;

	public float m_stepOverScale = 0.27f;

	public float m_skin = 0.05f;

	private float m_stepOver;

	private float m_initHeight;

	private bool m_ceil;

	private float m_JumpCoolDown = 0.1f;

	private float m_lastLandingTimeStamp;

	private Vector3 m_frameMoveOffset;

	private Vector3 m_accumMovement;

	private float m_TimeFragment;

	private int m_frameUpdateCount;

	private Vector3 m_lastMovementOffset;

	private Vector3 m_groundLiftVel;

	private bool m_onLand;

	public BadAssCharacterMotorMovement c02ba69b872ce3005f0d20ea25e9b15cf()
	{
		return movement;
	}

	protected void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawRay(base.transform.position, m_desiredVelocity);
		Gizmos.color = Color.red;
		Gizmos.DrawRay(base.transform.position, m_groundNormal);
	}

	private void Start()
	{
		m_entityPlayer = GetComponent<EntityPlayer>();
		m_taskManager = GetComponent<BHVTaskManager>();
		m_gravityAcceleration = m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_gravityAcceleration;
		jumping.baseHeight = m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_jumpHeight;
		m_characterTransform = base.transform;
		m_collider = GetComponent<CapsuleCollider>();
		m_initHeight = m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_standHeight;
	}

	private float c19ddc344c8db4d54d8ccaf70de033b4a()
	{
		return m_deltaTime;
	}

	public void c60a6395cd90cf9a40262240e16874381(float c2002bb238c228cf502166e05c0d89311)
	{
		m_deltaTime = c2002bb238c228cf502166e05c0d89311;
	}

	public void c5dfd692baf59326fa95f05a5a39d0a92(Vector3 c8219c6868423de9618a622239ee682ba)
	{
		m_desiredVelocity = c8219c6868423de9618a622239ee682ba;
	}

	public void c99cb1807ef027ac299c6fe9a57d28006(bool cd21a02552d9f84649358651c68373816)
	{
		m_inputJump = cd21a02552d9f84649358651c68373816;
	}

	private void Update()
	{
		m_frameMoveOffset += m_accumMovement;
		m_frameMoveOffset -= m_lastMovementOffset;
		Vector3 vector = m_lastMovementOffset * (Time.fixedDeltaTime - (m_TimeFragment + (float)m_frameUpdateCount * Time.fixedDeltaTime - Time.deltaTime)) / Time.fixedDeltaTime;
		m_frameMoveOffset += vector;
		movement.frameVelocity = m_frameMoveOffset / Time.deltaTime;
		m_frameMoveOffset = m_lastMovementOffset - vector;
		movement.frameOffset = m_frameMoveOffset;
		m_TimeFragment = Time.fixedTime - Time.time + Time.fixedDeltaTime;
		m_frameUpdateCount = 0;
		m_accumMovement = Vector3.zero;
	}

	public void cf6d13369bfe58cb51873fb954772b80a()
	{
		m_frameUpdateCount++;
		if (c19ddc344c8db4d54d8ccaf70de033b4a() < float.Epsilon)
		{
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
		m_stepOver = m_collider.height * m_stepOverScale * (m_collider.height / m_initHeight);
		m_onLand = false;
		if (m_isGrounded)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			if (!c0c0ebca6b40745ed97a9c2d325018b64())
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				m_isGrounded = false;
			}
		}
		if (!m_isGrounded)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			if (c0c0ebca6b40745ed97a9c2d325018b64())
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				m_isGrounded = true;
				jumping.jumping = false;
				m_lastLandingTimeStamp = Time.fixedTime;
				m_onLand = true;
			}
		}
		Vector3 velocity = movement.velocity;
		Vector3 ccb960b1045f89ea696f13319e5d8d = velocity;
		ccb960b1045f89ea696f13319e5d8d.x = 0f;
		ccb960b1045f89ea696f13319e5d8d.z = 0f;
		ccb960b1045f89ea696f13319e5d8d = caa918ce32ae34bf86bc43c9f2ad735fd(ccb960b1045f89ea696f13319e5d8d);
		velocity = c09138085b86a42e2efcae98de1ae8ab3(velocity, ccb960b1045f89ea696f13319e5d8d);
		velocity = m_entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3.c74699dab1caa7a33358332f2adcd2f23(velocity);
		Vector3 vector = velocity * c19ddc344c8db4d54d8ccaf70de033b4a();
		Debug.cd311b36270223e532813522a1f24cc90(m_characterTransform.position, vector);
		float num = 0f;
		if (m_isGrounded)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			float distance = 2f * m_stepOver;
			RaycastHit c36964cf41281414170f34ee68bef6c = default(RaycastHit);
			cf64d0536c25365fcd13a5b7fc17ba508.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
			RaycastHit hitInfo = c36964cf41281414170f34ee68bef6c;
			Ray ray = new Ray(m_characterTransform.position + new Vector3(vector.x, vector.y + m_stepOver, vector.z), Vector3.down);
			if (movement.lastHitNormal == Vector3.zero)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (Physics.Raycast(ray, out hitInfo, distance, TargetingService.c1d20cac39a8f2f2d40244b2db94423b7))
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					m_groundNormal = hitInfo.normal;
					if (m_groundNormal.y < 0f)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							break;
						}
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "invalid ground normal at:" + hitInfo.point);
					}
					if (hitInfo.distance < m_stepOver - m_skin)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						num = m_stepOver - hitInfo.distance - m_skin;
					}
					else if (hitInfo.distance > m_stepOver + m_skin)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						num = m_stepOver - hitInfo.distance + m_skin;
					}
				}
				else
				{
					m_groundNormal = Vector3.zero;
				}
			}
			RaycastHit c36964cf41281414170f34ee68bef6c2 = default(RaycastHit);
			cf64d0536c25365fcd13a5b7fc17ba508.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c2);
			hitInfo = c36964cf41281414170f34ee68bef6c2;
			Ray ray2 = new Ray(m_characterTransform.position + new Vector3(0f, m_collider.height, 0f) + new Vector3(vector.x, m_stepOver, vector.z), Vector3.up);
			Debug.cd311b36270223e532813522a1f24cc90(ray2.origin, ray2.direction, Color.black);
			if (Physics.Raycast(ray2, out hitInfo, distance, TargetingService.c1d20cac39a8f2f2d40244b2db94423b7))
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				m_ceil = true;
			}
			else
			{
				m_ceil = false;
			}
		}
		else
		{
			if (jumping.jumping)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (Time.fixedTime < jumping.lastStartTime + jumping.extraHeight / cfb58a0800932e1a675748717a082d2a1(jumping.baseHeight))
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					goto IL_04fc;
				}
			}
			float distance2 = 2f * m_skin;
			RaycastHit c36964cf41281414170f34ee68bef6c3 = default(RaycastHit);
			cf64d0536c25365fcd13a5b7fc17ba508.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c3);
			RaycastHit hitInfo2 = c36964cf41281414170f34ee68bef6c3;
			Ray ray3 = new Ray(m_characterTransform.position + new Vector3(vector.x, vector.y + m_skin, vector.z), Vector3.down);
			if (movement.lastHitNormal == Vector3.zero)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (Physics.Raycast(ray3, out hitInfo2, distance2, TargetingService.c1d20cac39a8f2f2d40244b2db94423b7))
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					m_groundNormal = hitInfo2.normal;
					if (m_groundNormal.y < 0f)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								continue;
							}
							break;
						}
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "invalid ground normal at:" + hitInfo2.point);
					}
				}
				else
				{
					m_groundNormal = Vector3.zero;
				}
			}
		}
		goto IL_04fc;
		IL_04fc:
		if (!c037035e4d559a76f971adb4022e4f1bf(movement.lastHitNormal))
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			m_groundNormal = movement.lastHitNormal;
		}
		vector += new Vector3(0f, num, 0f);
		if (!vector.magnitude.ce5aad699df330ff708587e4fabea8cbb(0f, float.Epsilon))
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			m_characterTransform.position += vector;
		}
		m_accumMovement += vector;
		m_lastMovementOffset = vector;
		movement.collisionFlags = CollisionFlags.None;
		if (!m_onLand)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			m_groundLiftVel = new Vector3(0f, num / c19ddc344c8db4d54d8ccaf70de033b4a(), 0f);
		}
		movement.velocity = velocity;
	}

	private Vector3 cb3145fc30e7d9c377664746fce77d883(Vector3 ca1223a809f38aa46b06fd568134b5fd3)
	{
		Vector3 result = ca1223a809f38aa46b06fd568134b5fd3;
		Vector3 point = m_characterTransform.position + m_collider.center + Vector3.up * ((0f - m_collider.height) * 0.5f + m_collider.radius + m_stepOver);
		if (!m_isGrounded)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			point = m_characterTransform.position + m_collider.center + Vector3.up * ((0f - m_collider.height) * 0.5f + m_collider.radius + m_skin);
		}
		Vector3 point2 = m_characterTransform.position + m_collider.center + Vector3.up * (m_collider.height * 0.5f - m_collider.radius + 0.2f);
		if ((double)ca1223a809f38aa46b06fd568134b5fd3.magnitude > 0.0001)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			RaycastHit hitInfo;
			if (Physics.CapsuleCast(point, point2, m_collider.radius + 0.01f, ca1223a809f38aa46b06fd568134b5fd3.normalized, out hitInfo, ca1223a809f38aa46b06fd568134b5fd3.magnitude, TargetingService.c1d20cac39a8f2f2d40244b2db94423b7))
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				movement.lastHitNormal = hitInfo.normal;
				movement.lastHitPoint = hitInfo.point;
				float distance = hitInfo.distance;
				float num = distance - m_skin;
				if (num < 0f)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					num = 0f;
				}
				float num2 = m_skin - distance;
				if (num2 < 0f)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					num2 = 0f;
				}
				Vector3 normal = hitInfo.normal;
				Vector3 vector = ca1223a809f38aa46b06fd568134b5fd3.normalized * num;
				if (!m_isGrounded)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					vector += num2 * normal;
				}
				Vector3 vector2 = ca1223a809f38aa46b06fd568134b5fd3 - vector;
				vector2.x *= 0.8f;
				vector2.z *= 0.8f;
				Debug.cd311b36270223e532813522a1f24cc90(hitInfo.point, normal, Color.blue, 10f);
				Vector3 vector3 = -1f * Vector3.Dot(vector2, normal) * normal;
				ca1223a809f38aa46b06fd568134b5fd3 = vector2 + vector3;
				Debug.cd311b36270223e532813522a1f24cc90(m_characterTransform.position, ca1223a809f38aa46b06fd568134b5fd3, Color.yellow);
				if (m_isGrounded)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					Vector3 vector4 = c89eb4b96de881b227fab4f5acac79a85(m_groundNormal, normal);
					ca1223a809f38aa46b06fd568134b5fd3 -= Vector3.Dot(vector2, vector4.normalized) * vector4.normalized;
				}
				if ((double)ca1223a809f38aa46b06fd568134b5fd3.magnitude > 0.0001)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					point += vector;
					point2 += vector;
					if (Physics.CapsuleCast(point, point2, m_collider.radius + 0.01f, ca1223a809f38aa46b06fd568134b5fd3, out hitInfo, ca1223a809f38aa46b06fd568134b5fd3.magnitude, TargetingService.c1d20cac39a8f2f2d40244b2db94423b7))
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							break;
						}
						movement.lastHitNormal = hitInfo.normal;
						movement.lastHitPoint = hitInfo.point;
						distance = hitInfo.distance;
						distance -= m_skin;
						if (distance < 0f)
						{
							while (true)
							{
								switch (7)
								{
								case 0:
									continue;
								}
								break;
							}
							distance = 0f;
						}
						Vector3 vector5 = ca1223a809f38aa46b06fd568134b5fd3.normalized * distance;
						Vector3 normal2 = hitInfo.normal;
						Debug.cd311b36270223e532813522a1f24cc90(hitInfo.point, normal2, Color.red, 10f);
						if (m_isGrounded)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									continue;
								}
								break;
							}
							if (Vector3.Dot(normal, normal2) <= 0f)
							{
								while (true)
								{
									switch (7)
									{
									case 0:
										continue;
									}
									break;
								}
								Debug.cd311b36270223e532813522a1f24cc90(hitInfo.point, normal, Color.cyan, 10f);
								Debug.cd311b36270223e532813522a1f24cc90(hitInfo.point, normal2, Color.magenta, 10f);
								result = vector + vector5;
							}
							else
							{
								vector2 = ca1223a809f38aa46b06fd568134b5fd3 - vector5;
								vector2.x *= 0.8f;
								vector2.z *= 0.8f;
								Vector3 vector6 = -1f * Vector3.Dot(vector2, normal2) * normal2;
								Vector3 vector7 = vector2 + vector6;
								if (m_isGrounded)
								{
									while (true)
									{
										switch (1)
										{
										case 0:
											continue;
										}
										break;
									}
									Vector3 vector4 = c89eb4b96de881b227fab4f5acac79a85(m_groundNormal, normal2);
									vector7 -= Vector3.Dot(vector7, vector4.normalized) * vector4.normalized;
								}
								Debug.cd311b36270223e532813522a1f24cc90(hitInfo.point, normal, Color.cyan, 10f);
								Debug.cd311b36270223e532813522a1f24cc90(hitInfo.point, normal2, Color.magenta, 10f);
								result = vector + vector5 + vector7;
							}
						}
						else
						{
							vector2 = ca1223a809f38aa46b06fd568134b5fd3 - vector5;
							vector2.x *= 0.8f;
							vector2.z *= 0.8f;
							Vector3 vector8 = -1f * Vector3.Dot(vector2, normal2) * normal2;
							ca1223a809f38aa46b06fd568134b5fd3 = vector2 + vector8;
							Vector3 vector4 = c89eb4b96de881b227fab4f5acac79a85(normal, normal2);
							ca1223a809f38aa46b06fd568134b5fd3 -= Vector3.Dot(ca1223a809f38aa46b06fd568134b5fd3, vector4.normalized) * vector4.normalized;
							result = vector + vector5 + ca1223a809f38aa46b06fd568134b5fd3;
							if ((double)ca1223a809f38aa46b06fd568134b5fd3.magnitude > 0.0001)
							{
								while (true)
								{
									switch (3)
									{
									case 0:
										continue;
									}
									break;
								}
								point += vector5;
								point2 += vector5;
								if (Physics.CapsuleCast(point, point2, m_collider.radius + 0.01f, ca1223a809f38aa46b06fd568134b5fd3, out hitInfo, ca1223a809f38aa46b06fd568134b5fd3.magnitude, TargetingService.c1d20cac39a8f2f2d40244b2db94423b7))
								{
									while (true)
									{
										switch (7)
										{
										case 0:
											continue;
										}
										break;
									}
									movement.lastHitNormal = hitInfo.normal;
									movement.lastHitPoint = hitInfo.point;
									distance = hitInfo.distance;
									distance -= m_skin;
									if (distance < 0f)
									{
										while (true)
										{
											switch (5)
											{
											case 0:
												continue;
											}
											break;
										}
										distance = 0f;
									}
									Vector3 vector9 = ca1223a809f38aa46b06fd568134b5fd3.normalized * distance;
									result = vector + vector5 + vector9;
								}
							}
						}
					}
					else
					{
						result = vector + ca1223a809f38aa46b06fd568134b5fd3;
						Debug.cd311b36270223e532813522a1f24cc90(m_characterTransform.position, vector + ca1223a809f38aa46b06fd568134b5fd3, Color.white, 10f);
					}
				}
				else
				{
					result = vector;
				}
			}
			else
			{
				movement.lastHitNormal = Vector3.zero;
				movement.lastHitPoint = Vector3.zero;
			}
		}
		else
		{
			result = Vector3.zero;
		}
		return result;
	}

	private Vector3 c09138085b86a42e2efcae98de1ae8ab3(Vector3 ccb960b1045f89ea696f13319e5d8d099, Vector3 c0c83fb31614d61f000fb1db3b54c1abe)
	{
		Vector3 vector = c5029e2aa1ee64f1c88a54ace1850735a();
		if (m_isGrounded)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			vector = cdcd177ebeda7572bc684eceecf07f405(vector, m_groundNormal);
			if (m_groundLiftVel.y > 0f)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				m_groundLiftVel.y -= m_gravityAcceleration * c19ddc344c8db4d54d8ccaf70de033b4a();
				if (m_groundLiftVel.y < 0f)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					m_groundLiftVel.y = 0f;
				}
			}
			if (m_groundLiftVel.y < 0f)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				m_groundLiftVel.y += m_gravityAcceleration * c19ddc344c8db4d54d8ccaf70de033b4a();
				if (m_groundLiftVel.y > 0f)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					m_groundLiftVel.y = 0f;
				}
			}
			vector += m_groundLiftVel;
		}
		else
		{
			vector.y = 0f;
			vector = ccb960b1045f89ea696f13319e5d8d099 + vector * 0.05f;
			vector.y = 0f;
		}
		Vector3 vector2 = ccb960b1045f89ea696f13319e5d8d099;
		vector2.y = 0f;
		float num = c1d53c0f271c36f66a74a8aa6793904c7(m_isGrounded) * c19ddc344c8db4d54d8ccaf70de033b4a();
		Vector3 vector3 = vector - vector2;
		if (vector3.sqrMagnitude > num * num)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			vector3 = vector3.normalized * num;
			vector = vector3 + vector2;
		}
		if (c0c83fb31614d61f000fb1db3b54c1abe.y != 0f)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			vector.y = c0c83fb31614d61f000fb1db3b54c1abe.y;
		}
		Vector3 ca1223a809f38aa46b06fd568134b5fd = vector * c19ddc344c8db4d54d8ccaf70de033b4a();
		ca1223a809f38aa46b06fd568134b5fd = cb3145fc30e7d9c377664746fce77d883(ca1223a809f38aa46b06fd568134b5fd);
		vector = ca1223a809f38aa46b06fd568134b5fd / c19ddc344c8db4d54d8ccaf70de033b4a();
		ccb960b1045f89ea696f13319e5d8d099 = vector;
		return ccb960b1045f89ea696f13319e5d8d099;
	}

	private Vector3 caa918ce32ae34bf86bc43c9f2ad735fd(Vector3 ccb960b1045f89ea696f13319e5d8d099)
	{
		if (!m_inputJump)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			jumping.holdingJumpButton = false;
			jumping.lastButtonDownTime = -100f;
		}
		else if (jumping.lastButtonDownTime < 0f)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			jumping.lastButtonDownTime = Time.fixedTime;
		}
		if (m_isGrounded)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			ccb960b1045f89ea696f13319e5d8d099.y = 0f;
		}
		else
		{
			ccb960b1045f89ea696f13319e5d8d099.y -= m_gravityAcceleration * c19ddc344c8db4d54d8ccaf70de033b4a();
			if (jumping.jumping)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (jumping.holdingJumpButton)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					if (Time.fixedTime < jumping.lastStartTime + jumping.extraHeight / cfb58a0800932e1a675748717a082d2a1(jumping.baseHeight))
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						ccb960b1045f89ea696f13319e5d8d099 += jumping.jumpDir * m_gravityAcceleration * c19ddc344c8db4d54d8ccaf70de033b4a();
					}
				}
			}
			ccb960b1045f89ea696f13319e5d8d099.y = Mathf.Max(ccb960b1045f89ea696f13319e5d8d099.y, 0f - m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_velocityFallMax);
		}
		if (m_isGrounded)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			if (Time.fixedTime - m_lastLandingTimeStamp > m_JumpCoolDown)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (jumping.enabled)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					if (Time.fixedTime - jumping.lastButtonDownTime < 0.2f)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						m_isGrounded = false;
						m_groundNormal = Vector3.zero;
						jumping.jumping = true;
						jumping.lastStartTime = Time.fixedTime;
						jumping.lastButtonDownTime = -100f;
						jumping.holdingJumpButton = true;
						jumping.jumpDir = Vector3.up;
						ccb960b1045f89ea696f13319e5d8d099.y = 0f;
						ccb960b1045f89ea696f13319e5d8d099 += jumping.jumpDir * cfb58a0800932e1a675748717a082d2a1(jumping.baseHeight);
						goto IL_0298;
					}
				}
				jumping.holdingJumpButton = false;
			}
		}
		goto IL_0298;
		IL_0298:
		return ccb960b1045f89ea696f13319e5d8d099;
	}

	private Vector3 c5029e2aa1ee64f1c88a54ace1850735a()
	{
		return m_desiredVelocity;
	}

	private Vector3 cdcd177ebeda7572bc684eceecf07f405(Vector3 cb5e4a2378278443e1570b12f5f59cfa2, Vector3 c2567414fa34692aa3a6d732c22e74821)
	{
		Vector3 lhs = Vector3.Cross(Vector3.up, cb5e4a2378278443e1570b12f5f59cfa2);
		return Vector3.Cross(lhs, c2567414fa34692aa3a6d732c22e74821).normalized * cb5e4a2378278443e1570b12f5f59cfa2.magnitude;
	}

	private Vector3 c89eb4b96de881b227fab4f5acac79a85(Vector3 c849b3c9ff3b6f4efb2c1a6b19391cbae, Vector3 cae6eb0f0c20e0d5f1c07b0cae3808137)
	{
		Vector3 lhs = Vector3.Cross(c849b3c9ff3b6f4efb2c1a6b19391cbae, cae6eb0f0c20e0d5f1c07b0cae3808137);
		return Vector3.Cross(lhs, cae6eb0f0c20e0d5f1c07b0cae3808137);
	}

	private bool c0c0ebca6b40745ed97a9c2d325018b64()
	{
		return m_groundNormal.y > 0.01f;
	}

	private float c1d53c0f271c36f66a74a8aa6793904c7(bool c9e3be1d11ae64ec8c9105b27922b8224)
	{
		if (c9e3be1d11ae64ec8c9105b27922b8224)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_velocityChangeGroundMax;
				}
			}
		}
		return m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_velocityChangeAirMax;
	}

	private float cfb58a0800932e1a675748717a082d2a1(float c88fdec8da188bc3e66ae52fe7c078916)
	{
		return Mathf.Sqrt(2f * c88fdec8da188bc3e66ae52fe7c078916 * m_gravityAcceleration);
	}

	public bool c3919eac209f354ea44f6195a74d0cd9f()
	{
		return m_ceil;
	}

	private bool c037035e4d559a76f971adb4022e4f1bf(Vector3 cdb904a3027943a47994b1cd1d4f659fc)
	{
		return cdb904a3027943a47994b1cd1d4f659fc.y <= Mathf.Cos(m_slopeLimit * ((float)Math.PI / 180f));
	}

	public bool c4ea65a191eec783b57d9624a6d06cf30()
	{
		return m_isGrounded;
	}

	public bool c8cc0ce1bacf416fdd879d1e63947960f()
	{
		return jumping.jumping;
	}

	public bool ce43542aec9cbb169187d2e5eafe6dc72(Vector3 c6fbf9bf303de8f447f09fde3a44278f2, Vector3 cd74e1657fe33d2ee7ef19f6bb00c943e, float cb860c68e8987c2f6cf793ed82b51be06, out RaycastHit cab3b059ef8d7994c0474c0fc10a08d33)
	{
		Vector3 point = c6fbf9bf303de8f447f09fde3a44278f2 + m_collider.center + Vector3.up * ((0f - m_collider.height) * 0.5f + m_collider.radius + m_stepOver);
		Vector3 point2 = m_characterTransform.position + m_collider.center + Vector3.up * (m_collider.height * 0.5f - m_collider.radius + 0.2f);
		bool flag = false;
		return Physics.CapsuleCast(point, point2, m_collider.radius, cd74e1657fe33d2ee7ef19f6bb00c943e.normalized, out cab3b059ef8d7994c0474c0fc10a08d33, cb860c68e8987c2f6cf793ed82b51be06, TargetingService.c1d20cac39a8f2f2d40244b2db94423b7);
	}

	public bool cbcfd3b06e164a3e40fe416ad7dd0e1c7(Vector3 c6fbf9bf303de8f447f09fde3a44278f2, float cdfb3569b5c3a736a4b6dd8e7dc1efcab)
	{
		Vector3 start = c6fbf9bf303de8f447f09fde3a44278f2 + new Vector3(0f, cdfb3569b5c3a736a4b6dd8e7dc1efcab * 0.5f, 0f) + Vector3.up * ((0f - cdfb3569b5c3a736a4b6dd8e7dc1efcab) * 0.5f + m_collider.radius + m_stepOver);
		Vector3 end = m_characterTransform.position + new Vector3(0f, cdfb3569b5c3a736a4b6dd8e7dc1efcab * 0.5f, 0f) + Vector3.up * (cdfb3569b5c3a736a4b6dd8e7dc1efcab * 0.5f - m_collider.radius + 0.2f);
		bool flag = false;
		flag = Physics.CheckCapsule(start, end, m_collider.radius + m_skin, TargetingService.c1d20cac39a8f2f2d40244b2db94423b7);
		return !flag;
	}

	public void c9cd9d634c23883f713b1e7dc6def6a1e(float cdfb3569b5c3a736a4b6dd8e7dc1efcab)
	{
		m_collider.height = cdfb3569b5c3a736a4b6dd8e7dc1efcab;
		m_collider.center = new Vector3(0f, cdfb3569b5c3a736a4b6dd8e7dc1efcab * 0.5f, 0f);
	}
}
