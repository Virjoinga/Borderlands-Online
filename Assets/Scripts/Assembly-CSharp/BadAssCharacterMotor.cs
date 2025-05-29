using System;
using BHV;
using UnityEngine;

[Serializable]
[AddComponentMenu("Character/BadAss Character Motor")]
[RequireComponent(typeof(CharacterController))]
public class BadAssCharacterMotor : MonoBehaviour, IBadAssCharacterMotor
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

		public float baseHeight = 1f;

		public float extraHeight = 0.6f;

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

	private Vector3 m_lastGroundNormal = Vector3.zero;

	private Transform m_characterTransform;

	private CharacterController m_characterController;

	private EntityPlayer m_entityPlayer;

	private BHVTaskManager m_taskManager;

	private float m_gravityAcceleration;

	private float m_deltaTime;

	public BadAssCharacterMotorMovement c02ba69b872ce3005f0d20ea25e9b15cf()
	{
		return movement;
	}

	private void Start()
	{
		m_characterController = GetComponent<CharacterController>();
		m_entityPlayer = GetComponent<EntityPlayer>();
		m_taskManager = GetComponent<BHVTaskManager>();
		m_gravityAcceleration = m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_gravityAcceleration;
		jumping.baseHeight = m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_jumpHeight;
		m_characterTransform = base.transform;
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

	public void cf6d13369bfe58cb51873fb954772b80a()
	{
		if (c19ddc344c8db4d54d8ccaf70de033b4a() < float.Epsilon)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		Vector3 velocity = movement.velocity;
		velocity = c09138085b86a42e2efcae98de1ae8ab3(velocity);
		velocity = caa918ce32ae34bf86bc43c9f2ad735fd(velocity);
		velocity = m_entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3.c74699dab1caa7a33358332f2adcd2f23(velocity);
		Vector3 position = m_characterTransform.position;
		Vector3 motion = velocity * c19ddc344c8db4d54d8ccaf70de033b4a();
		float num = Mathf.Max(m_characterController.stepOffset, new Vector3(motion.x, 0f, motion.z).magnitude);
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
			motion -= num * Vector3.up;
		}
		m_groundNormal = Vector3.zero;
		movement.collisionFlags = m_characterController.Move(motion);
		movement.lastHitPoint = movement.hitPoint;
		m_lastGroundNormal = m_groundNormal;
		Vector3 vector = new Vector3(velocity.x, 0f, velocity.z);
		movement.velocity = (m_characterTransform.position - position) / c19ddc344c8db4d54d8ccaf70de033b4a();
		Vector3 lhs = new Vector3(movement.velocity.x, 0f, movement.velocity.z);
		if (vector == Vector3.zero)
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
			movement.velocity = new Vector3(0f, movement.velocity.y, 0f);
		}
		else
		{
			float value = Vector3.Dot(lhs, vector) / vector.sqrMagnitude;
			movement.velocity = vector * Mathf.Clamp01(value) + movement.velocity.y * Vector3.up;
		}
		if (movement.velocity.y < velocity.y - 0.001f)
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
			if (movement.velocity.y < 0f)
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
				movement.velocity.y = velocity.y;
			}
			else
			{
				jumping.holdingJumpButton = false;
			}
		}
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
			if (!c0c0ebca6b40745ed97a9c2d325018b64())
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						m_isGrounded = false;
						SendMessage("OnFall", SendMessageOptions.DontRequireReceiver);
						m_characterTransform.position += num * Vector3.up;
						return;
					}
				}
			}
		}
		if (m_isGrounded)
		{
			return;
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			if (!c0c0ebca6b40745ed97a9c2d325018b64())
			{
				return;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				m_isGrounded = true;
				jumping.jumping = false;
				SendMessage("OnLand", SendMessageOptions.DontRequireReceiver);
				return;
			}
		}
	}

	private Vector3 c09138085b86a42e2efcae98de1ae8ab3(Vector3 ccb960b1045f89ea696f13319e5d8d099)
	{
		Vector3 vector = c5029e2aa1ee64f1c88a54ace1850735a();
		if (m_isGrounded)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			vector = cdcd177ebeda7572bc684eceecf07f405(vector, m_groundNormal);
		}
		else
		{
			ccb960b1045f89ea696f13319e5d8d099.y = 0f;
		}
		float num = c1d53c0f271c36f66a74a8aa6793904c7(m_isGrounded) * c19ddc344c8db4d54d8ccaf70de033b4a();
		Vector3 vector2 = vector - ccb960b1045f89ea696f13319e5d8d099;
		if (vector2.sqrMagnitude > num * num)
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
			vector2 = vector2.normalized * num;
		}
		ccb960b1045f89ea696f13319e5d8d099 += vector2;
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
			ccb960b1045f89ea696f13319e5d8d099.y = Mathf.Min(ccb960b1045f89ea696f13319e5d8d099.y, 0f);
		}
		return ccb960b1045f89ea696f13319e5d8d099;
	}

	private Vector3 caa918ce32ae34bf86bc43c9f2ad735fd(Vector3 ccb960b1045f89ea696f13319e5d8d099)
	{
		if (!m_inputJump)
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
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			jumping.lastButtonDownTime = Time.time;
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
			ccb960b1045f89ea696f13319e5d8d099.y = Mathf.Min(0f, ccb960b1045f89ea696f13319e5d8d099.y) - m_gravityAcceleration * c19ddc344c8db4d54d8ccaf70de033b4a();
		}
		else
		{
			ccb960b1045f89ea696f13319e5d8d099.y = movement.velocity.y - m_gravityAcceleration * c19ddc344c8db4d54d8ccaf70de033b4a();
			if (jumping.jumping)
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
				if (jumping.holdingJumpButton)
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
					if (Time.time < jumping.lastStartTime + jumping.extraHeight / cfb58a0800932e1a675748717a082d2a1(jumping.baseHeight))
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
				switch (2)
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
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				if (Time.time - jumping.lastButtonDownTime < 0.2f)
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
					m_isGrounded = false;
					jumping.jumping = true;
					jumping.lastStartTime = Time.time;
					jumping.lastButtonDownTime = -100f;
					jumping.holdingJumpButton = true;
					jumping.jumpDir = Vector3.up;
					ccb960b1045f89ea696f13319e5d8d099.y = 0f;
					ccb960b1045f89ea696f13319e5d8d099 += jumping.jumpDir * cfb58a0800932e1a675748717a082d2a1(jumping.baseHeight);
					SendMessage("OnJump", SendMessageOptions.DontRequireReceiver);
					goto IL_029b;
				}
			}
			jumping.holdingJumpButton = false;
		}
		goto IL_029b;
		IL_029b:
		return ccb960b1045f89ea696f13319e5d8d099;
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (!(hit.normal.y > 0f))
		{
			return;
		}
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
			if (!(hit.normal.y > m_groundNormal.y))
			{
				return;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (!(hit.moveDirection.y < 0f))
				{
					return;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					if (!((hit.point - movement.lastHitPoint).sqrMagnitude > 0.001f))
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
						if (!(m_lastGroundNormal == Vector3.zero))
						{
							m_groundNormal = m_lastGroundNormal;
							goto IL_00ec;
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					m_groundNormal = hit.normal;
					goto IL_00ec;
					IL_00ec:
					movement.hitPoint = hit.point;
					movement.frameVelocity = Vector3.zero;
					return;
				}
			}
		}
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
				switch (6)
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
		return (movement.collisionFlags & CollisionFlags.Above) != 0;
	}

	private bool c037035e4d559a76f971adb4022e4f1bf()
	{
		return m_groundNormal.y <= Mathf.Cos(m_characterController.slopeLimit * ((float)Math.PI / 180f));
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
		Vector3 vector = c6fbf9bf303de8f447f09fde3a44278f2 + m_characterController.center + Vector3.up * ((0f - m_characterController.height) * 0.5f + m_characterController.radius + m_characterController.stepOffset);
		Vector3 point = vector + Vector3.up * (m_characterController.height - 2f * m_characterController.radius);
		bool flag = false;
		return Physics.CapsuleCast(vector, point, m_characterController.radius, cd74e1657fe33d2ee7ef19f6bb00c943e.normalized, out cab3b059ef8d7994c0474c0fc10a08d33, cb860c68e8987c2f6cf793ed82b51be06, TargetingService.c766b2ad3bfeb136864b1696e7dda3d4c);
	}

	public bool cbcfd3b06e164a3e40fe416ad7dd0e1c7(Vector3 c6fbf9bf303de8f447f09fde3a44278f2, float cdfb3569b5c3a736a4b6dd8e7dc1efcab)
	{
		Vector3 start = c6fbf9bf303de8f447f09fde3a44278f2 + m_characterController.center + Vector3.up * ((0f - cdfb3569b5c3a736a4b6dd8e7dc1efcab) * 0.5f + m_characterController.radius + m_characterController.stepOffset);
		Vector3 end = m_characterTransform.position + m_characterController.center + Vector3.up * (cdfb3569b5c3a736a4b6dd8e7dc1efcab * 0.5f - m_characterController.radius + 0.2f);
		bool flag = false;
		flag = Physics.CheckCapsule(start, end, m_characterController.radius, TargetingService.c1d20cac39a8f2f2d40244b2db94423b7);
		return !flag;
	}

	public void c9cd9d634c23883f713b1e7dc6def6a1e(float cdfb3569b5c3a736a4b6dd8e7dc1efcab)
	{
		m_characterController.height = cdfb3569b5c3a736a4b6dd8e7dc1efcab;
		m_characterController.center = new Vector3(0f, cdfb3569b5c3a736a4b6dd8e7dc1efcab * 0.5f, 0f);
	}
}
