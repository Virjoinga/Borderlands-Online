using UnityEngine;

public class BillboardAnimator : MonoBehaviour
{
	private enum EBillboardState
	{
		EBS_Stop = 0,
		EBS_Play = 1,
		EBS_Stopping = 2
	}

	public Vector3 SpeedDirection = new Vector3(0f, 1f, 0f);

	public float Amplitude = 1f;

	public float Velocity = 2.5f;

	public float TotalTime = 0.1f;

	private Vector3 mOriginalPosition = new Vector3(0f, 0f, 0f);

	private EBillboardState mState;

	private float mCurrentAcceleration;

	private float mCurrentVelocity;

	private Vector3 mCurrentSpeedDirection = new Vector3(0f, 0f, 0f);

	private void Start()
	{
		mOriginalPosition = base.gameObject.transform.localPosition;
		SpeedDirection.Normalize();
	}

	private void Update()
	{
		if (mState != EBillboardState.EBS_Stopping)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (mState != EBillboardState.EBS_Play)
			{
				return;
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
		mCurrentVelocity += mCurrentAcceleration * Time.deltaTime;
		if (mCurrentVelocity >= Velocity)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					mCurrentVelocity = Velocity;
					mCurrentAcceleration = 0f - mCurrentAcceleration;
					return;
				}
			}
		}
		if (mCurrentVelocity <= 0f)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					mCurrentVelocity = 0f;
					mCurrentAcceleration = 0f - mCurrentAcceleration;
					mCurrentSpeedDirection = -mCurrentSpeedDirection;
					if (mState == EBillboardState.EBS_Stopping)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								if (Vector3.Dot(mCurrentSpeedDirection, SpeedDirection) < 0f)
								{
									while (true)
									{
										switch (6)
										{
										case 0:
											break;
										default:
											base.gameObject.transform.localPosition = mOriginalPosition;
											OnStateChanged(EBillboardState.EBS_Stop);
											return;
										}
									}
								}
								return;
							}
						}
					}
					return;
				}
			}
		}
		base.gameObject.transform.localPosition += mCurrentVelocity * Time.deltaTime * mCurrentSpeedDirection;
	}

	private void OnStateChanged(EBillboardState eState)
	{
		if (eState == EBillboardState.EBS_Play)
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
			mCurrentAcceleration = Velocity / TotalTime / 2f;
			mCurrentVelocity = 0f;
			mCurrentSpeedDirection = SpeedDirection;
		}
		else if (eState == EBillboardState.EBS_Stop)
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
			mCurrentAcceleration = 0f;
			mCurrentVelocity = 0f;
		}
		mState = eState;
	}

	public void c0a75d7afd2f7f1e47a5aadaab61303c7()
	{
		OnStateChanged(EBillboardState.EBS_Play);
	}

	public void cdada4c3678c9c23c38aaf0754a94a620()
	{
		if (mState == EBillboardState.EBS_Stop)
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
		OnStateChanged(EBillboardState.EBS_Stopping);
	}
}
