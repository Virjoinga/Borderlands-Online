using UnityEngine;

[RequireComponent(typeof(Camera))]
public class BadAssTPSCamera : MonoBehaviour
{
	public Transform mCharacter;

	private Vector3 tPos;

	private Transform mTarget;

	private Transform camTransform;

	private float xCamera;

	private float yCamera;

	private Vector3 camDir;

	private Vector3 standingCamDir;

	private Vector3 aimingCamDir;

	private int standingFOV = 60;

	private int aimingFOV = 30;

	private float lerpFOVSpeed = 8f;

	private float cameraSpeed = 2700f;

	private float aimCameraSpeed = 1400f;

	private float maxCameraSpeed = 2000f;

	private float standingTargetHeight = 1.5f;

	private float standingTargetDistance = 2.5f;

	private float aimingTargetHeight = 1.8f;

	private float aimingTargetDistance = 1.5f;

	private float targetHeight;

	private float targetDistance;

	private float minDistance = 0.2f;

	private float maxHeight = 2f;

	private bool bAiming;

	private bool orbit;

	private float idleTime;

	private void Start()
	{
		GameObject gameObject = new GameObject();
		mTarget = gameObject.transform;
		mTarget.name = "ForCamera";
		mTarget.parent = mCharacter;
		standingCamDir = new Vector3(-1f, 0f, 0.3f);
		aimingCamDir = new Vector3(-1f, 0f, 0.5f);
		camTransform = base.transform;
		targetHeight = standingTargetHeight;
		targetDistance = standingTargetDistance;
		Vector3 eulerAngles = camTransform.eulerAngles;
		xCamera = eulerAngles.y;
		yCamera = eulerAngles.x;
	}

	private void Update()
	{
		if (orbit)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!Input.GetKeyDown(KeyCode.O))
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
				if ((double)Input.GetAxis("Horizontal") == 0.0)
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
					if ((double)Input.GetAxis("Vertical") == 0.0)
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
						if (!Input.GetMouseButtonDown(0))
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
							if (!Input.GetMouseButtonDown(1))
							{
								goto IL_00a9;
							}
							while (true)
							{
								switch (6)
								{
								case 0:
									continue;
								}
								break;
							}
						}
					}
				}
			}
			cb04c43f7865bbe9b9ec5902f79d21329(false);
		}
		goto IL_00a9;
		IL_00a9:
		if (!orbit)
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
			if (idleTime > 0.1f)
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
				cb04c43f7865bbe9b9ec5902f79d21329(true);
			}
		}
		if (Input.GetMouseButton(1))
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
			bAiming = true;
		}
		else
		{
			bAiming = false;
		}
		idleTime += Time.deltaTime;
	}

	private void LateUpdate()
	{
		c3d77dbc3e250da4b2184d9fd7307a3a6();
		ca0db9de6de9b7643c158d6e014fb59d1();
		c896a12d52e1afc53300e4a115d4debfa();
	}

	private void cb04c43f7865bbe9b9ec5902f79d21329(bool c17fcd0ed1024ad7689991a96ed60deb1)
	{
		orbit = c17fcd0ed1024ad7689991a96ed60deb1;
		idleTime = 0f;
	}

	private void c896a12d52e1afc53300e4a115d4debfa()
	{
		if (bAiming)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, aimingFOV, Time.deltaTime * lerpFOVSpeed);
			camDir = aimingCamDir.x * mTarget.forward + aimingCamDir.z * mTarget.right;
			targetHeight = aimingTargetHeight;
			targetDistance = aimingTargetDistance;
		}
		else
		{
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, standingFOV, Time.deltaTime * lerpFOVSpeed);
			camDir = standingCamDir.x * mTarget.forward + standingCamDir.z * mTarget.right;
			targetHeight = standingTargetHeight;
			targetDistance = standingTargetDistance;
		}
		camDir = camDir.normalized;
		tPos = mCharacter.position + new Vector3(0f, targetHeight, 0f);
		RaycastHit hitInfo;
		if (Physics.Raycast(tPos, camDir, out hitInfo, targetDistance + 0.2f))
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
			float num = hitInfo.distance - 0.1f;
			num -= minDistance;
			num /= targetDistance - minDistance;
			targetHeight = Mathf.Lerp(maxHeight, targetHeight, Mathf.Clamp(num, 0f, 1f));
			tPos = mCharacter.position + new Vector3(0f, targetHeight, 0f);
		}
		if (Physics.Raycast(tPos, camDir, out hitInfo, targetDistance + 0.2f))
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
			targetDistance = hitInfo.distance - 0.1f;
		}
		Vector3 worldPosition = tPos;
		worldPosition += mTarget.right * Vector3.Dot(camDir * targetDistance, mTarget.right);
		camTransform.position = tPos + camDir * targetDistance;
		camTransform.LookAt(worldPosition);
		mTarget.position = tPos;
		mTarget.rotation = Quaternion.Euler(yCamera, xCamera, 0f);
	}

	private void c3d77dbc3e250da4b2184d9fd7307a3a6()
	{
		float num;
		if (bAiming)
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
			num = aimCameraSpeed;
		}
		else
		{
			num = cameraSpeed;
		}
		float num2 = num;
		xCamera += Mathf.Clamp(Input.GetAxis("Mouse X") * num2, 0f - maxCameraSpeed, maxCameraSpeed) * Time.deltaTime;
		yCamera -= Mathf.Clamp(Input.GetAxis("Mouse Y") * num2, 0f - maxCameraSpeed, maxCameraSpeed) * Time.deltaTime;
		yCamera = c59a1e85f63b91ede971052b4e6a87a28(yCamera, -85f, 85f);
	}

	private void ca0db9de6de9b7643c158d6e014fb59d1()
	{
		if (orbit)
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
					return;
				}
			}
		}
		float y = mCharacter.transform.rotation.eulerAngles.y;
		float num = Mathf.Repeat(xCamera - y, 360f);
		if (num > 180f)
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
			num -= 360f;
		}
		mCharacter.transform.Rotate(new Vector3(0f, num, 0f), Space.World);
	}

	private float c59a1e85f63b91ede971052b4e6a87a28(float cdeaa898a2de80d01f4d89a02fcb24a09, float c1a0139d78d4b74044f06b4e676dcc511, float c8cc109d7daf35ef5b180de3c5ac6de20)
	{
		if (cdeaa898a2de80d01f4d89a02fcb24a09 < -360f)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			cdeaa898a2de80d01f4d89a02fcb24a09 += 360f;
		}
		if (cdeaa898a2de80d01f4d89a02fcb24a09 > 360f)
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
			cdeaa898a2de80d01f4d89a02fcb24a09 -= 360f;
		}
		return Mathf.Clamp(cdeaa898a2de80d01f4d89a02fcb24a09, c1a0139d78d4b74044f06b4e676dcc511, c8cc109d7daf35ef5b180de3c5ac6de20);
	}
}
