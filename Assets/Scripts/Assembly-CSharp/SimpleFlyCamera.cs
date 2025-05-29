using UnityEngine;

public class SimpleFlyCamera : MonoBehaviour
{
	public float climbSpeed = 4f;

	public float normalMoveSpeed = 10f;

	public float slowMoveFactor = 0.25f;

	public float fastMoveFactor = 3f;

	private MouseLook mouseLook;

	private void Start()
	{
		mouseLook = base.gameObject.AddComponent<MouseLook>();
		Screen.lockCursor = true;
	}

	private void Update()
	{
		if (Screen.lockCursor)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						mouseLook.enabled = true;
						if (!Input.GetKey(KeyCode.LeftShift))
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
							if (!Input.GetKey(KeyCode.RightShift))
							{
								if (!Input.GetKey(KeyCode.LeftControl))
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
									if (!Input.GetKey(KeyCode.RightControl))
									{
										base.transform.position += base.transform.forward * normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
										base.transform.position += base.transform.right * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
										goto IL_02cd;
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
								base.transform.position += base.transform.forward * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
								base.transform.position += base.transform.right * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
								goto IL_02cd;
							}
							while (true)
							{
								switch (3)
								{
								case 0:
									continue;
								}
								break;
							}
						}
						base.transform.position += base.transform.forward * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
						base.transform.position += base.transform.right * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
						goto IL_02cd;
					}
					IL_02cd:
					if (Input.GetKey(KeyCode.Q))
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
						base.transform.position += base.transform.up * climbSpeed * Time.deltaTime;
					}
					if (Input.GetKey(KeyCode.E))
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								base.transform.position -= base.transform.up * climbSpeed * Time.deltaTime;
								return;
							}
						}
					}
					return;
				}
			}
		}
		mouseLook.enabled = false;
	}
}
